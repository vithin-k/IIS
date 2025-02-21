using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Relyon.Utilities;
using Relyon.Controls;
using Microsoft.Web.Administration;

namespace enable_ManageIIS
{
    public partial class frmManageProject : Form
    {
        public frmManageProject()
        {
            InitializeComponent();
            LoadDefaultWebSite();
        }

        private void LoadDefaultWebSite()
        {
            try
            {
                // Clear existing items in the ComboBox
                using (ServerManager serverManager = new ServerManager())
                {
                    // Get the "Default Web Site"
                    var defaultSite = serverManager.Sites.FirstOrDefault(site =>
                        site.Name.Equals("Default Web Site", StringComparison.OrdinalIgnoreCase));

                    if (defaultSite != null)
                    {
                        // Iterate through applications (subsites) under Default Web Site
                        foreach (var app in defaultSite.Applications)
                        {
                            // Ignore the root ("/") and add only sub-sites
                            if (!app.Path.Equals("/", StringComparison.OrdinalIgnoreCase))
                            {
                                string subsiteName = app.Path.TrimStart('/'); // Remove leading "/"
                                cmbProject.Properties.Items.Add(subsiteName);                               
                                //cmbWebsites.Items.Add(subsiteName);
                            }
                        }
                    }
                }

                // Set default selection if items exist
                if (cmbProject.Properties.Items.Count > 0)
                {
                    cmbProject.SelectedIndex = 0;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void StartSelectedSite()
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    if (cmbProject.SelectedItem != null)
                    {
                        string selectedSubsite = cmbProject.SelectedItem.ToString();
                        Site defaultSite = serverManager.Sites["Default Web Site"]; // Root site

                        if (defaultSite != null)
                        {
                            // Start the root site if it is stopped
                            if (defaultSite.State == ObjectState.Stopped)
                            {
                                defaultSite.Start();
                                Common.ShowMessageBox($"Started root site: {defaultSite.Name}", "Internet Information Services");
                            }
                            else
                            {
                                Common.ShowMessageBox($"Root site {defaultSite.Name} is already running.", "Internet Information Services");
                            }
                        }
                    }
                    else
                    {
                        // If no subsite is selected, start all stopped root sites
                        foreach (Site site in serverManager.Sites)
                        {
                            if (site.State == ObjectState.Stopped)
                            {
                                site.Start();
                                Common.ShowMessageBox($"Started site: {site.Name}", "Internet Information Services");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ShowMessageBox("Error starting site:" + ex.Message, "Internet Information Services");
            }
        }

        private void StopSelectedSite()
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    if (cmbProject.SelectedItem != null)
                    {
                        string selectedSiteName = cmbProject.SelectedItem.ToString();
                        Site selectedSite = serverManager.Sites["Default Web Site"];

                        if (selectedSite.State == ObjectState.Started)
                        {
                            selectedSite.Stop();
                            Common.ShowMessageBox($"Stopped site: {selectedSiteName}", "Internet Information Services");
                        }
                        else
                        {
                            Common.ShowMessageBox($"Site {selectedSiteName} is already stopped.", "Internet Information Services");
                        }
                    }
                    else
                    {
                        // Stop all sites if no site is selected
                        foreach (Site site in serverManager.Sites)
                        {
                            if (site.State == ObjectState.Started)
                            {
                                site.Stop();
                                Common.ShowMessageBox($"Stopped site: {site.Name}", "Internet Information Services");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ShowMessageBox("Error stopping site: " + ex.Message, "Internet Information Services");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            validate();
            //  frmIISManager.DownloadFile();
            Common.ShowMessageBox("validating","Update");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            validate();
            Common.ShowMessageBox("validating", "start");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            validate();
            Common.ShowMessageBox("validating", "stop");
        }

        private void validate()
        {
            if (cmbProject.Text == string.Empty || string.IsNullOrWhiteSpace(cmbProject.Text))
            {
                Common.ShowMessageBox("Please select a valid IIS site.", "IIS Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Common.ShowMessageBox("Valid IIS Site Selected: " + cmbProject.Text.ToString(), "Internet Information Services", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
