using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Security.AccessControl;
using System.IO;
using System.Management;
using System.Threading.Tasks;
using Relyon.Utilities;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Data.Sql;
using System.Data;
using System.IO.Compression;
using System.Net.NetworkInformation;
using DevExpress.XtraSplashScreen;
using System.Text.RegularExpressions;

namespace enable_ManageIIS
{

    public partial class frmIISManager : Form
    {
        static string projectName = null;
        //private string projectFilesPath = @"\\rslserver\Products\Saral Accounts\Daily updates\Server";
        private string IISPath = null;
        static string IISProjectPath = null;
        private const string NetExecutable = "net.exe";
        private string _userName = null;
        private string _Password = null;
        private string localZipPath = null;
        private const string zipUrl = "https://www.etds-payroll-salary-software-india.com/downloads/RELYONMICROUPDATE/SaralAccess/IIS_PhysicalpathFiles.zip";
      
        public frmIISManager()
        {
            InitializeComponent();
            txtProjectName.KeyPress += OnKeyPress;
            txtUserpwd.Properties.UseSystemPasswordChar = true;
            txtComputerName.Text = Dns.GetHostName().ToUpper();
            LogEvent($"Application Saral IIS Configuration Launched");
            LoadDataFromRegsitry();

            //string iisVersion = GetIISVersion();
           
        }
        private void IsIISInstalled()
        {
            if (IsIISServiceInstalled())
            {
               EnableIISFeatures();     
            }
            else
            {              
               EnableIISFeatures();
            }
        }
        private bool IsIISServiceInstalled()
        {
            try
            {
                // Query WMI for IIS services (World Wide Web Publishing Service, W3SVC)
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Name = 'W3SVC'");

                // Execute the query and check if the service is installed
                ManagementObjectCollection queryCollection = searcher.Get();


                return queryCollection.Count > 0;        
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static string GetLocalIPAddress()
        {
            //GET LOCAL IPV4 
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }
        private void EnableIISFeatures()
        {
            string[] features = new string[]
            {
        
                "IIS-WebServerRole",
                "IIS-WebServer",
                "IIS-CommonHttpFeatures",
                "IIS-StaticContent",
                "IIS-DefaultDocument",
                "IIS-DirectoryBrowsing",
                "IIS-HttpErrors",
                "IIS-HttpRedirect",
                "IIS-ApplicationDevelopment",
                "IIS-ASPNET",
                "IIS-NetFxExtensibility",
                "IIS-ASP",
                "IIS-CGI",
                "IIS-ISAPIExtensions",
                "IIS-ISAPIFilter",
                "IIS-ServerSideIncludes",
                "IIS-HealthAndDiagnostics",
                "IIS-HttpLogging",
                "IIS-LoggingLibraries",
                "IIS-RequestMonitor",
                "IIS-HttpTracing",
                "IIS-CustomLogging",
                "IIS-Security",
                "IIS-BasicAuthentication",
                "IIS-WindowsAuthentication",
                "IIS-DigestAuthentication",
                "IIS-ClientCertificateMappingAuthentication",
                "IIS-IISCertificateMappingAuthentication",
                "IIS-URLAuthorization",
                "IIS-RequestFiltering",
                "IIS-IPSecurity",
                "IIS-HttpCompressionDynamic",
                "IIS-HttpCompressionStatic",
                "IIS-WebServerManagementTools",
                "IIS-ManagementConsole",
                "IIS-ManagementScriptingTools",
                "IIS-ManagementService",
                "IIS-PerformanceFeatures",
                "WCF-Services45",
                "WCF-HTTP-Activation45",
                "WCF-TCP-Activation45",
                "WCF-Pipe-Activation45",
                "WCF-MSMQ-Activation45",
                "WCF-TCP-PortSharing45"

            };

            const string CommandArgumentOnline = "/online";
            const string CommandArgumentEnableFeature = "/enable-feature";
            const string CommandArgumentFeatureName = "/featurename:";      
            const string CommandArgumentQueryFeature = "/get-featureinfo";

            this.Invoke((Action)(() =>
            {
                this.FormBorderStyle = FormBorderStyle.None;
                progressPanel1.Visible = true;
                progressPanel1.Description = "Starting IIS feature...";
                tableLayoutPanel2.Visible = false;           
            }));

            int totalFeatures = features.Length;

            for (int i = 0; i < totalFeatures; i++)
            {
                string feature = features[i];

                string queryCommand = $"dism {CommandArgumentOnline} {CommandArgumentQueryFeature} {CommandArgumentFeatureName}{feature}";
                string output = ExecuteCommandWithOutput(queryCommand);

                if (!(output == "NOTFOUND"))
                {
                    bool isEnabled = output.Contains("State : Enabled");
                 
                    int progress = (i + 1) * 100 / totalFeatures;
                    this.Invoke((Action)(() =>
                    {
                        if (isEnabled)
                        {
                            progressPanel1.Description = $"Checking {feature}... {progress}%";
                        }
                        else
                        {
                            progressPanel1.Description = $"Enabling {feature}... {progress}%";
                        }
                    }));

                    if(!isEnabled)
                    {
                         queryCommand = $"dism {CommandArgumentOnline} {CommandArgumentEnableFeature} {CommandArgumentFeatureName}{feature}";
                        ExecuteCommandWithOutput(queryCommand);
                    }   
                }
            }

            this.Invoke((Action)(() =>
            {
                progressPanel1.Description = "IIS features enabled successfully.";
                progressPanel1.Visible = false;
                tableLayoutPanel2.Visible = true;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
            }));
        }
        private string ExecuteCommandWithOutput(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe"; // Use cmd.exe to run DISM command
            process.StartInfo.Arguments = $"/c {command}"; // Command to run in cmd.exe
            process.StartInfo.UseShellExecute = false; // Do not use the shell to execute the command
            process.StartInfo.RedirectStandardOutput = true; // Redirect the standard output of the command
            process.StartInfo.RedirectStandardError = true; // Redirect any error messages from the command
            process.StartInfo.CreateNoWindow = true; // Do not show the command prompt window

            process.Start(); // Start the process

            string output = process.StandardOutput.ReadToEnd(); // Capture the output of the command
            string errorOutput = process.StandardError.ReadToEnd(); // Capture any error messages

            process.WaitForExit(); // Wait for the process to complete

            if (process.ExitCode != 0)
            {
                string logMessage = $"Failed to enable IIS feature '{command}'.\n" +
                                       $"Exit Code: {process.ExitCode}\n" +
                                       $"Error Output: {errorOutput}\n" +
                                       $"Time: {DateTime.Now}\n\n";
                LogEvent($"{logMessage}");
                return "NOTFOUND";
            }
            return output; // Return the output of the command
        }
        private  void btnCreate_project_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (validate())
            {

                projectName = txtProjectName.Text;
                IISPath = txtProjectPath.Text + '\\';
                IISProjectPath = IISPath + projectName;
                Directory.CreateDirectory(IISProjectPath);
                SetPermission(IISProjectPath);
                try
                {
                    localZipPath = Path.Combine(IISProjectPath + "\\Updates\\" + "IIS_PhysicalpathFiles.zip");
                    DownloadFile(zipUrl, localZipPath);
                }
                catch (Exception ex)
                {
                    LogEvent($"Error downloading or extracting ZIP file: {ex.Message}", true); // Log error
                    MessageBox.Show($"Error downloading or extracting ZIP file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Create JSON file
                string server = cmbServer.Text;
                string fileName = cmbComapny.Text;
                string userId = txtUserName.Text;
                string password = txtUserpwd.Text;
                int CompanyId = Convert.ToInt32(txtCompanyId.Text);

                var connectionStringData = new
                {
                    Data = new
                    {
                        ConnectionStrings = $"SERVER={server};Initial Catalog={fileName};User ID={userId};Password={password};"
                    },
                    CompanyId
                };

                try
                {
                    string jsonPath = IISProjectPath + '\\';
                    string filePath = Path.Combine(jsonPath, "appsettings.json");
                    string json = JsonConvert.SerializeObject(connectionStringData, Formatting.Indented);
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.Write(json);
                        LogEvent($"Json File Created in {jsonPath}");
                    }                    
                    string newSettingValue = "http://" + txtIpAddress.Text + "/" + txtProjectName.Text;
                    UpdateSettingValue(newSettingValue);                   
                   
                }

                catch (IOException ex)
                {
                    LogEvent($"IO Error while creating Json: {ex}", true);
                    Common.ShowMessageBox("Error creating file. Please check the log for more information.", "Internet Information Services");
                }
                catch (UnauthorizedAccessException ex)
                {
                    LogEvent($"Unauthorized AccessException Error while creating Json: {ex.Message}", true);
                    Common.ShowMessageBox("Error creating file. You do not have permission to write to the file.", "Internet Information Services");
                }

                //Create BranchDataToImport folder
                try
                {
                    string DataFolder = IISProjectPath + "\\BranchDataToImport";

                    //Create the folder
                    if (Directory.Exists(IISProjectPath))
                    {
                        //Directory.Delete(IISProjectPath);
                        Directory.CreateDirectory(DataFolder);
                    }
                    else
                    {
                        Common.ShowMessageBox("Folder already exists.", "Internet Information Services");
                    }
                }
                catch (Exception ex)
                {
                    //Common.ShowMessageBox($"Error creating folder: {ex.Message}","Internet Information Services");
                }

                //Creating sites Under Default Web SItes
                using (ServerManager serverManager = new ServerManager())
                {
                    Site appPool = serverManager.Sites["Default Web Site"];

                    if (appPool != null)
                    {
                        try
                        {
                            Microsoft.Web.Administration.Application existingApp = appPool.Applications["/" + projectName];
                            if (existingApp == null)
                            {
                                var newApp = appPool.Applications.Add("/" + projectName, IISProjectPath);
                                serverManager.CommitChanges();
                                LogEvent($"Created Project {projectName}");
                                Common.ShowMessageBox($"Project {projectName} created", "Internet Information Services");
                            }
                            else
                            {
                                Common.ShowMessageBox($"Project {projectName} already exist", "Internet Information Services");
                                txtProjectName.Focus();
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogEvent($"Error while creating Project {projectName}: {ex}", true);
                            Common.ShowMessageBox($"Error creating new project : {ex.Message}", "Internet Information Services");
                            Cursor = Cursors.Default;
                        }
                                               
                    }
                    else
                    {
                        Common.ShowMessageBox("Default Web site not found", "Internet Information Services");
                        btnCreate_project.Focus();
                        LogEvent($"Error while creating Project Default Web site not found {projectName}", true);
                    }
                }
                ClearControls();
            }
            this.Cursor = Cursors.Default;  
        }      
        public static void UnzipFile(string zipFilePath, string destinationFolder)
        {
            SplashScreenManager.CloseForm(false);
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            SplashScreenManager.Default.SetWaitFormDescription("Extracting Downloaded files.");

            try
            {
                using (ZipArchive zipArchive = ZipFile.OpenRead(zipFilePath))
                {
                    int totalEntries = zipArchive.Entries.Count;
                    int extractedEntries = 0;

                    foreach (ZipArchiveEntry entry in zipArchive.Entries)
                    {
                        string filePath = Path.Combine(destinationFolder, entry.FullName);

                        // Check if the entry is a directory (ends with a backslash) and create the directory if necessary
                        if (entry.FullName.EndsWith("/")) // It's a directory
                        {
                            Directory.CreateDirectory(filePath); // Create the directory
                        }
                        else
                        {
                            // Create directory for the file if needed
                            string directoryPath = Path.GetDirectoryName(filePath);
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // Extract the file
                            entry.ExtractToFile(filePath, overwrite: true);
                        }
                        extractedEntries++;
                    }
                }
                SplashScreenManager.CloseForm(false);
                LogEvent("Extraction complete!"); // Log success
                //Common.ShowMessageBox("Files Downloaded and Updated Successfully!", "Internet Information Services", true);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                LogEvent($"An error occurred during extraction: {ex.Message}", true); // Log error
                Common.ShowMessageBox($"An error occurred: {ex.Message}", "Internet Information Services");
            }
        }
        public static void DownloadFile(string url, string destinationPath)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string directoryPath = Path.GetDirectoryName(destinationPath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    SplashScreenManager.CloseForm(false);
                    SplashScreenManager.ShowForm(typeof(WaitForm1));
                    SplashScreenManager.Default.SetWaitFormDescription("Downloading required files.");

                    // Blocking download
                    webClient.DownloadFile(url, destinationPath);

                    LogEvent($"File downloaded successfully to {destinationPath}"); // Log success
                                                                                               // Proceed to unzip after download completes
                    UnzipFile(destinationPath, IISProjectPath); // Extract the ZIP file
                }
                catch (Exception ex)
                {
                    SplashScreenManager.CloseForm(false);
                    LogEvent($"An error occurred: {ex.Message}", true); // Log error
                    Common.ShowMessageBox($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool SetEveryOnePermission(string folderPath,string type)
        {
            try
            {
                // Get the directory's current security settings
                DirectorySecurity directorySecurity = new DirectoryInfo(folderPath).GetAccessControl();

                // Create a FileSystemAccessRule for the specified user with full control rights
                //FileSystemAccessRule accessRule = new FileSystemAccessRule(
                //    type,                                // User name
                //    FileSystemRights.Modify,            // Full control
                //    AccessControlType.Allow                  // Allow the access rule
                //);
                directorySecurity.AddAccessRule(new FileSystemAccessRule(type, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));

                // Add the access rule to the directory's security settings
                //directorySecurity.SetAccessRule(accessRule);

                // Apply the updated access control settings to the directory
                new DirectoryInfo(folderPath).SetAccessControl(directorySecurity);

                return true;  // Successfully added full control
                
            }
            catch (Exception ex)
            {
                LogEvent($"An error occurred during set user permissions : {ex.Message}", true); 
                Common.ShowMessageBox($"An error occurred: {ex.Message}", "Internet Information Services");
                return false;
            }
        }
        private bool validate()
        {
            if(!CheckForInternetConnection())
            {
                Common.ShowMessageBox("Please Check Internet Connection", "Internet Information Services");
                return false;
            }            

            if (!IsIISServiceInstalled())
            {
                Common.ShowMessageBox("Internet Information Services is not enabled Or some features needs to enable click on Check Pre Requisites", "Internet Information Services");
                return false;
            }
            if (txtProjectName.Text.Trim() == string.Empty)
            {
                Common.ShowMessageBox("Enable Data Sync for selected Company", "Internet Information Services");
                txtProjectName.Focus();
                return false;
            }
            if (cmbServer.Text.Trim() != string.Empty)
            {
                this.Invoke((Action)(() =>
                {
                    progressPanel1.Visible = true;
                    progressPanel1.Description = "While Checking Sql Server Instance";
                    
                }));
                if (CheckInstanceExists(cmbServer.Text.Trim()))
                {
                    if (!CheckInstanceIsActive(cmbServer.Text.Trim()))
                    {
                        Common.ShowMessageBox("Sql instance is not started", "Internet Information Services");
                        cmbServer.Focus();
                        
                        return false;
                    }
                    this.Invoke((Action)(() =>
                    {
                        progressPanel1.Visible = false;

                    }));
                }
                else
                {
                    Common.ShowMessageBox("Sql instance not found,Check Instance name", "Internet Information Services");
                    cmbServer.Focus();
                    this.Invoke((Action)(() =>
                    {
                        progressPanel1.Visible = false;

                    }));
                    return false;
                }
                
            }
            else
            {
                Common.ShowMessageBox("Specify the sql instance", "Internet Information Services");
                cmbServer.Focus();
                return false;

            }
            if (cmbComapny.Text.Trim() == string.Empty)
            {
                Common.ShowMessageBox("Unable to find Cloud registration ID For selected file, Complete Cloud Registration", "Internet Information Services");
                cmbComapny.Focus();
                return false;
            }

            if(txtCompanyId.Text.Trim() == string.Empty || txtCompanyId.Text.Trim()=="0")
            {
                Common.ShowMessageBox("Specify the Cloud Id", "Internet Information Services");
                txtCompanyId.Focus();
                return false;
            }

            string Message = string.Empty;
            if (txtProjectPath.Text.Trim() == string.Empty)
            {
                Message = "Project path blank Default path taken as C:\\inetpub \n";
                txtProjectPath.Text = @"C:\inetpub";
                IISPath = txtProjectPath.Text;
            }
            else
            {
                if (Directory.Exists(txtProjectPath.Text.Trim()))
                {             
                    IISPath = txtProjectPath.Text;
                }
                else
                {
                    Message = "\nProject path is not valid. Default path taken as C:\\inetpub \n";
                    txtProjectPath.Text = @"C:\inetpub";
                    IISPath = txtProjectPath.Text;
                }
            }
           

            //Validations username
            if (txtUserName.Text.Trim() == string.Empty)
            {
                Message += "\nUser name entered blank default user name will be 'sa' \n";
                txtUserName.Text = "sa";
            }

            //Validations Password
            if (txtUserpwd.Text.Trim() == string.Empty)
            {
                Message += "\nPasswrod entered is blank Default password will be updated as 'reladmin@123' \n";
                txtUserpwd.Text = "reladmin@123";
            }

            //Validate IP address
            if (txtIpAddress.Text.Trim() == string.Empty || txtIpAddress.Text.Trim() == "0")
            {
                Common.ShowMessageBox("Specify IP address", "Internet Information Services");
                txtIpAddress.Focus();
                return false;
            }

            string ipAddress = txtIpAddress.Text;

            if (IsValidIPAddress(ipAddress))
            {
                SplashScreenManager.CloseForm(false);
                SplashScreenManager.ShowForm(typeof(WaitForm1));
                SplashScreenManager.Default.SetWaitFormDescription("Validating IP v4 address.");
                if (!CheckPing(ipAddress))
                    return false;
                    
                SplashScreenManager.CloseForm(false);
                btnCreate_project.Focus();
                return true;
            }
            else
            {
                Common.ShowMessageBox("Invalid IP Address. Enter a valid IP address in Format as 192.168.1.1 , 10.89.171.4", "Internet Information Services");
                return false;
                txtIpAddress.Focus();           
            }
        }

        private bool IsValidIPAddress(string ipAddress)
        {
            // Regular expression for matching a valid IPv4 address, restricting other special characters
            string pattern = @"^([0-9]{1,3}\.){3}[0-9]{1,3}$";
            Regex regex = new Regex(pattern);

            // Ensure that the IP address matches the regex pattern
            return regex.IsMatch(ipAddress) && IsValidRange(ipAddress);
        }

        private bool IsValidRange(string ipAddress)
        {
            // Split the IP address into segments based on the dot separator
            string[] segments = ipAddress.Split('.');

            foreach (var segment in segments)
            {
                int num;
                // Check if each segment is a valid number between 0 and 255
                if (int.TryParse(segment, out num))
                {
                    if (num < 0 || num > 255)
                        return false;
                }
                else
                {
                    return false; // If it's not a number, return false
                }
            }

            return true;
        }
        static void RunNetCommand(string commandLineArgs)
        {
            // Use a more descriptive variable name to avoid conflicts
            string netCommandArguments = $"SHARE {projectName}={IISProjectPath}";

            using (Process process = new Process())
            {
                process.StartInfo = new ProcessStartInfo(NetExecutable, netCommandArguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
                
            }
        }
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // allow numerics
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;

            // allow lowercase characters
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                return;

            // allow uppercase characters
            if (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                return;

            // allow backspace and other special characters in the string
            if ("\b".Contains(e.KeyChar))
                return;

            e.Handled = true;
        }
        static bool CheckInstanceIsActive(string serverInstanceName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection($"Data Source={serverInstanceName};Integrated Security=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT 1", connection);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException)
            {             
                return false;
            }
        }
        //private void CopyDirectory(string sourcePath, string destinationPath)
        //{

        //    if (!Directory.Exists(destinationPath))
        //    {
        //        Directory.CreateDirectory(destinationPath);//COPY FILES 
                
        //        DirectoryInfo directoryInfo = new DirectoryInfo(destinationPath);
        //        SetEveryOnePermission(IISProjectPath, "EveryOne");
        //        SetEveryOnePermission(IISProjectPath, "IUSR");
        //        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
        //    }
        //    //sourcePath = txtProjectPath.Text;
        //    foreach (string file in Directory.GetFiles(sourcePath))
        //    {
        //        string destinationFile = Path.Combine(destinationPath, Path.GetFileName(file));
        //        File.Copy(file, destinationFile, true);
        //    }

        //    foreach (string dir in Directory.GetDirectories(sourcePath))
        //    {
        //        string destinationDir = Path.Combine(destinationPath, Path.GetFileName(dir));
        //        CopyDirectory(dir, destinationDir);
        //    }
        //}
        private bool CheckInstanceExists(string serverInstanceName)
        {
            try
            {
                string selectedInstance = cmbServer.Text.Trim().ToString();
                string connectionString = GetConnectionString(selectedInstance, "");
                using (SqlConnection connection = new SqlConnection($"Data Source={serverInstanceName};Integrated Security=True"))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            cmbServer.Focus();
            cmbServer.ShowPopup(); 
        }
        private void ClearControls()
        {
            cmbComapny.EditValue = null;
            txtCompanyId.EditValue = string.Empty;
            txtProjectName.Text = string.Empty;
            txtProjectPath.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtUserpwd.Text = string.Empty;
            txtIpAddress.Text = string.Empty;
           // cmbServer.Text = string.Empty;
            cmbServer.Focus();
        }
        private void txtProjectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {              
                string selectedPath = folderBrowserDialog1.SelectedPath;             
                txtProjectPath.Text = selectedPath;
            }
        }
        private void lblCheckPreRequsistes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogEvent("$ Cheking Pre-Requsits started");
            Task.Run(() =>
            {
                IsIISInstalled();
            });
            LogEvent("$ Cheking Pre-Requsits Ends");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {           
            if (Common.ShowMessageBox("Do you want to exit?", "Internet Information Services", false, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            System.Windows.Forms.Application.Exit();
            LogEvent($"Application Closed Manually");
        }
        private void LoadSQLInstances()
        {
            SplashScreenManager.CloseForm(false);
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            SplashScreenManager.Default.SetWaitFormDescription("Loading Sql Instaces");
          
            try
            {            
                SqlDataSourceEnumerator instanceEnumerator = SqlDataSourceEnumerator.Instance;
                DataTable instances = instanceEnumerator.GetDataSources();
                if (instances.Rows.Count > 0)
                {
                    foreach (DataRow row in instances.Rows)
                    {
                        string serverName = row["ServerName"].ToString();
                        string instanceName = row["InstanceName"].ToString();
                        string fullInstanceName = string.IsNullOrEmpty(instanceName) ?
                        serverName : $"{serverName}\\{instanceName}";
                        cmbServer.Properties.Items.Add(fullInstanceName);
                    }
                    SplashScreenManager.CloseForm(false);
                    LogEvent("$Loaded Instance form SQL Data Source");
                }
                else
                {
                    SplashScreenManager.CloseForm(false);
                    Common.ShowMessageBox("No SQL Server instances found or SQL Instance Not accessiable due to Network restrictions",  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogEvent("$ Not able to load instance",true);
                }
                                
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                Common.ShowMessageBox("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogEvent("$ Not able to load instance {ex}", true);
            }
        }
        private void LoadDataFromRegsitry()
        {
            string rootPath = @".\"; // Change this to your actual root path if needed
            string accountsExePath = Path.Combine(rootPath, "SaralAccounts.exe");
            string billingExePath = Path.Combine(rootPath, "SaralBiling.exe");

            // Check for saralaccounts.exe
            if (File.Exists(accountsExePath))
            {
                LoadSettingsFromRegistry(@"HKEY_CURRENT_USER\Software\Relyon Softech Ltd\Saral_Accounts\SETTINGS");
                txtUserpwd.Focus();
                LogEvent("Loaded Instance from registry, Saral Accounts");
            }
            // Check for saralbiling.exe
            else if (File.Exists(billingExePath))
            {
                LoadSettingsFromRegistry(@"HKEY_CURRENT_USER\Software\Relyon Softech Ltd\Saral_Billing\SETTINGS");
                txtUserpwd.Focus();
                LogEvent("Loaded Instance from registry, Saral Billing");
            }
            else
            {
                Common.ShowMessageBox("Saral application exe was not found in the path {rootPath}.", "Internet Information Services",true);
                LoadSQLInstances();
            }
        }
        private void LoadDataBase()
        {
            Cursor = Cursors.WaitCursor;

            _userName = txtUserName.Text;
            _Password = txtUserpwd.Text;
            cmbComapny.Properties.Items.Clear();
            txtProjectName.Text=string.Empty;
            txtCompanyId.EditValue = string.Empty;
           

            string selectedInstance = cmbServer.Text.Trim().ToString();
            string connectionString = GetConnectionString(selectedInstance, "");
            SplashScreenManager.CloseForm(false);
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            SplashScreenManager.Default.SetWaitFormDescription("Loading Company's");

            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DATABASENAME FROM [RELPRODUCT].[dbo].[SARALACCOUNTS]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                string companyName = reader["DATABASENAME"].ToString();
                                cmbComapny.Properties.Items.Add(companyName);
                            }
                            SplashScreenManager.CloseForm(false);
                            this.Show();
                            // If no companies found, show a message
                            if (cmbComapny.Properties.Items.Count == 0)
                            {
                                Common.ShowMessageBox("No company names found in the database.", "Internet Information Services");
                            }
                            else
                            {
                                cmbComapny.Focus();
                                cmbComapny.ShowPopup();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                this.Show();
                if (connectionString.Contains("Integrated Security=true") && (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_Password)))
                {
                    Common.ShowMessageBox("User name and password can not be empty", "Internet Information Services");
                }
                else
                {
                    Common.ShowMessageBox($"Error connecting to SQL Server: {ex.Message}", "Internet Information Services");
                }
            }
            Cursor = Cursors.Default;

        }
        private string GetConnectionString(string instance, string companyName)
        {
            string _userName = txtUserName.Text;
            string _Password = txtUserpwd.Text;

            if (string.IsNullOrEmpty(_userName) || string.IsNullOrEmpty(_Password))
            {
                if(!(companyName == string.Empty))
                {
                    return $"Server={instance}; Initial Catalog={companyName}; Integrated Security=true";  // Exit the function if the credentials are invalid.
                }
                else
                    return $"Server={instance}; Integrated Security=true";  // Exit the function if the credentials are invalid.
            }
            else if (!(companyName == string.Empty))
            {
                return $"Server={instance}; Initial Catalog={companyName}; Integrated Security=false; User Id={_userName}; Password={_Password};";
            }
            else
            {
                return $"Server={instance}; Integrated Security=false; User Id={_userName}; Password={_Password};";
            }
        }
        private void txtUserpwd_Leave(object sender, EventArgs e)
        {
            if (cmbServer.Text.Trim() != string.Empty)
            {
                LoadDataBase();
            }
        }
        private void cmbComapny_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (cmbComapny.EditValue == null)
            {
                Cursor = Cursors.Default;
                return;
            }
            if (cmbComapny == null || cmbComapny.SelectedItem == null)
            {
                throw new InvalidOperationException("{cmbComapny} + or its selected item is not initialized.");
            }

            string selectedCompany = cmbComapny.SelectedItem.ToString();
            string connectionString = GetConnectionString(cmbServer.Text.Trim(), selectedCompany);
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT compnotes, mobileid FROM acc_company ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string branchName = string.Empty;
                                branchName = reader["compnotes"].ToString();
                                txtCompanyId.Text = reader["mobileid"].ToString();

                                if(string.IsNullOrEmpty(branchName))
                                {
                                    branchName = cmbComapny.Text + txtCompanyId.Text;
                                }
                                txtProjectName.Text = branchName;
                                
                            }
                            else
                            {
                                Common.ShowMessageBox("No data found for the selected company.","Internet Information Services");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ShowMessageBox($"Error retrieving company details: {ex.Message}", "Internet Information Services");
            }
            Cursor = Cursors.Default;

        }
        private bool CheckForInternetConnection()
        {

            try
            {
                System.Net.HttpWebRequest hwebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://www.google.co.in");
                hwebRequest.Timeout = 10000;
                System.Net.HttpWebResponse hWebResponse = (System.Net.HttpWebResponse)hwebRequest.GetResponse();
                if (hWebResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private string GetIISVersion()
        {
            try
            {
                // Query the registry for IIS version
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\InetStp"))
                {
                    if (key != null)
                    {
                        Object version = key.GetValue("VersionString");
                        if (version != null)
                        {
                            return version.ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        private void SetPermission(string folderPath)
        {
            try
            {
                // Get the current directory security settings
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                // Define the permissions to add
                FileSystemAccessRule everyoneRule = new FileSystemAccessRule("Everyone",
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);
        
                FileSystemAccessRule iusrRule = new FileSystemAccessRule("IUSR",
                    FileSystemRights.FullControl,
                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);

                // Add the new rules to the directory security
                directorySecurity.AddAccessRule(everyoneRule);
                directorySecurity.AddAccessRule(iusrRule);

                // Set the new access settings
                directoryInfo.SetAccessControl(directorySecurity);
            }
            catch (UnauthorizedAccessException ex)
            {
                Common.ShowMessageBox(ex.Message);
            }
            catch (Exception ex)
            {
                Common.ShowMessageBox("An error occurred: " + ex.Message, "Internet Information Services");
            }
        }
        private void UpdateSettingValue(string newSettingValue)
        {
            //string connectionString = "Server=cmbServer.Text;Database=cmbComapny.Text;User Id=(_UserName);Password=(_Password);";
            string connectionString = GetConnectionString(cmbServer.Text,cmbComapny.Text);
            // SQL query to check if the value exists
            string checkQuery = "SELECT COUNT(*) FROM ACC_SETTINGS WHERE SETTINGID = 181 AND SETTINGNAME = 'Static IP Address'";
            // SQL query to update the SettingValue
            string updateQuery = "UPDATE ACC_SETTINGS SET SettingValue = @SettingValue WHERE SETTINGID = 181 AND SETTINGNAME = 'Static IP Address'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if the value exists
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            // Value exists, proceed to update
                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@SettingValue", newSettingValue);
                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    //Common.ShowMessageBox("Ip updated in DataBase successfully.");
                                    LogEvent("$ IP updated in DataBase successfully" + txtIpAddress.Text);
                                }
                                else
                                {
                                    Common.ShowMessageBox("Failed to update Ip in Data Base.", "Internet Information Services");
                                    LogEvent("$ Failed to update Ip in Data Base." + txtIpAddress.Text);
                                }
                            }
                        }
                        else
                        {
                            Common.ShowMessageBox("Settings (ID) in Data Base not found.", "Internet Information Services");
                            LogEvent("$ Failed to update IP in Data Base, Settings (ID) in Data Base not found." + txtIpAddress.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Common.ShowMessageBox( "Error: " + ex.Message);
                    LogEvent("$ Error {ex}", true);
                }
            }
        }       
        public static void LogEvent(string message, bool isError = false)
        {
            string logFilePath = isError ? @".\IIS.fail" : @".\IIS.log"; // Change the path as needed

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during logging
                MessageBox.Show($"Failed to write to log file: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool CheckPing(string ipAddress)
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    // Send a ping request
                    PingReply reply = ping.Send(ipAddress);

                    // Check the status of the reply
                    if (reply.Status == IPStatus.Success)
                    {
                        //Common.ShowMessageBox($"Ping to {ipAddress} successful.","Internet Information Services", true);
                        //Common.ShowMessageBox($"Response Time: {reply.RoundtripTime} ms", "Internet Information Services", true);
                        //Common.ShowMessageBox($"TTL: {reply.Options.Ttl}", "Internet Information Services", true);
                        //Common.ShowMessageBox($"Buffer Size: {reply.Buffer.Length} bytes", "Internet Information Services", true);
                        LogEvent("$ IP response {ipAddress},  Response Time: {reply.RoundtripTime} ms, TTL: {reply.Options.Ttl},  Buffer Size: {reply.Buffer.Length} bytes ");
                        return true;
                    }
                    else
                    {
                        Common.ShowMessageBox($"Ping to {ipAddress} failed. Status: {reply.Status}");
                        txtIpAddress.Focus();
                        LogEvent("$Ping to IP {ipAddress} failes", true);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Common.ShowMessageBox($"An error occurred: {ex.Message}");
                    txtIpAddress.Focus();
                    LogEvent("$Ping to IP {ipAddress} failes   {ex.Message}", true);
                    return false;
                }
            }
        }
        private void LoadSettingsFromRegistry(string registryPath)
        {
            try
            {
                // Read the registry values
                string server = (string)Registry.GetValue(registryPath, "MSSQLSERVER", null);
                string user = (string)Registry.GetValue(registryPath, "USER", null);
                string password = (string)Registry.GetValue(registryPath, "MSSQLPWD", null);
                string path = (string)Registry.GetValue(registryPath, "PATH", null);

                // Populate the fields in your application
                cmbServer.Text = server ?? string.Empty; 
                txtUserName.Text = user ?? string.Empty; 
                txtUserpwd.Text = password ?? string.Empty; 
                txtProjectPath.Text = path ?? string.Empty; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading the registry: {ex.Message}");
            }
        }

        private void lblCheckUpdates_Click(object sender, EventArgs e)
        {
            frmManageProject manageProject = new frmManageProject();
            manageProject.ShowDialog();
        }

        private void txtProjectPath_EditValueChanged(object sender, EventArgs e)
        {
            tooltipPath.SetToolTip(txtProjectPath, txtProjectPath.Text);
        }
    }
}
