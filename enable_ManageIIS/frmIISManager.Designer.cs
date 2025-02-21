namespace enable_ManageIIS
{
    partial class frmIISManager 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true);
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tlpProjectDetails = new System.Windows.Forms.TableLayoutPanel();
            this.txtCompanyId = new Relyon.Controls.NumericTextBox();
            this.lblCloudId = new DevExpress.XtraEditors.LabelControl();
            this.lblProjectNameReq = new DevExpress.XtraEditors.LabelControl();
            this.lblCloudIdReq = new DevExpress.XtraEditors.LabelControl();
            this.lblInstanceName = new DevExpress.XtraEditors.LabelControl();
            this.lblSqlUserName = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new Relyon.Controls.RSXTextBox();
            this.lblSqlPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtUserpwd = new Relyon.Controls.RSXTextBox();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            this.cmbServer = new Relyon.Controls.RSXComboEdit();
            this.cmbComapny = new Relyon.Controls.RSXComboEdit();
            this.lblProjectName = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectName = new Relyon.Controls.RSXTextBox();
            this.lblServerReq = new DevExpress.XtraEditors.LabelControl();
            this.lblFileNameReq = new DevExpress.XtraEditors.LabelControl();
            this.lblProjectPath = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectPath = new DevExpress.XtraEditors.ButtonEdit();
            this.tlpProjectBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCreate_project = new System.Windows.Forms.Button();
            this.lblIP = new Relyon.Controls.RSXLabel();
            this.lblIpRequired = new DevExpress.XtraEditors.LabelControl();
            this.txtIpAddress = new Relyon.Controls.RSXTextBox();
            this.tlpLinks = new System.Windows.Forms.TableLayoutPanel();
            this.lblCheckUpdates = new System.Windows.Forms.LinkLabel();
            this.lblCheckPreRequsistes = new System.Windows.Forms.LinkLabel();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaption = new Relyon.Controls.RSXLabel();
            this.tooltipPath = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tlpProjectDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserpwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComapny.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectPath.Properties)).BeginInit();
            this.tlpProjectBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress.Properties)).BeginInit();
            this.tlpLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.LineAnimationElementType = DevExpress.Utils.Animation.LineAnimationElementType.Triangle;
            this.progressPanel1.Location = new System.Drawing.Point(102, 47);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(343, 358);
            this.progressPanel1.TabIndex = 1;
            this.progressPanel1.Text = "progressPanel1";
            this.progressPanel1.Visible = false;
            // 
            // tlpProjectDetails
            // 
            this.tlpProjectDetails.ColumnCount = 3;
            this.tlpProjectDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.26804F));
            this.tlpProjectDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.731959F));
            this.tlpProjectDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.tlpProjectDetails.Controls.Add(this.txtCompanyId, 2, 5);
            this.tlpProjectDetails.Controls.Add(this.lblCloudId, 0, 5);
            this.tlpProjectDetails.Controls.Add(this.lblProjectNameReq, 1, 1);
            this.tlpProjectDetails.Controls.Add(this.lblCloudIdReq, 1, 4);
            this.tlpProjectDetails.Controls.Add(this.lblInstanceName, 0, 1);
            this.tlpProjectDetails.Controls.Add(this.lblSqlUserName, 0, 2);
            this.tlpProjectDetails.Controls.Add(this.txtUserName, 2, 2);
            this.tlpProjectDetails.Controls.Add(this.lblSqlPassword, 0, 3);
            this.tlpProjectDetails.Controls.Add(this.txtUserpwd, 2, 3);
            this.tlpProjectDetails.Controls.Add(this.lblFileName, 0, 4);
            this.tlpProjectDetails.Controls.Add(this.cmbServer, 2, 1);
            this.tlpProjectDetails.Controls.Add(this.cmbComapny, 2, 4);
            this.tlpProjectDetails.Controls.Add(this.lblProjectName, 0, 6);
            this.tlpProjectDetails.Controls.Add(this.txtProjectName, 2, 6);
            this.tlpProjectDetails.Controls.Add(this.lblServerReq, 1, 5);
            this.tlpProjectDetails.Controls.Add(this.lblFileNameReq, 1, 6);
            this.tlpProjectDetails.Controls.Add(this.lblProjectPath, 0, 7);
            this.tlpProjectDetails.Controls.Add(this.txtProjectPath, 2, 7);
            this.tlpProjectDetails.Controls.Add(this.tlpProjectBtn, 2, 9);
            this.tlpProjectDetails.Controls.Add(this.lblIP, 0, 8);
            this.tlpProjectDetails.Controls.Add(this.lblIpRequired, 1, 8);
            this.tlpProjectDetails.Controls.Add(this.txtIpAddress, 2, 8);
            this.tlpProjectDetails.Controls.Add(this.tlpLinks, 0, 9);
            this.tlpProjectDetails.Controls.Add(this.radioGroup1, 0, 0);
            this.tlpProjectDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProjectDetails.Location = new System.Drawing.Point(4, 104);
            this.tlpProjectDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpProjectDetails.Name = "tlpProjectDetails";
            this.tlpProjectDetails.RowCount = 10;
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.07011F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.43911F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpProjectDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpProjectDetails.Size = new System.Drawing.Size(440, 318);
            this.tlpProjectDetails.TabIndex = 0;
            // 
            // txtCompanyId
            // 
            this.txtCompanyId.AllowNegetive = false;
            this.txtCompanyId.ButtonName = "";
            this.txtCompanyId.ConvertToComma = false;
            this.txtCompanyId.DecimalPlaces = 0;
            this.txtCompanyId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompanyId.Enabled = false;
            this.txtCompanyId.InitialString = "";
            this.txtCompanyId.Location = new System.Drawing.Point(197, 153);
            this.txtCompanyId.Name = "txtCompanyId";
            this.txtCompanyId.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyId.Properties.Appearance.Options.UseFont = true;
            this.txtCompanyId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCompanyId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtCompanyId.Properties.Mask.EditMask = "f0";
            this.txtCompanyId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCompanyId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtCompanyId.Properties.MaxLength = 14;
            this.txtCompanyId.Size = new System.Drawing.Size(240, 20);
            this.txtCompanyId.SupressModifiedState = false;
            this.txtCompanyId.TabIndex = 65;
            // 
            // lblCloudId
            // 
            this.lblCloudId.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloudId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCloudId.Location = new System.Drawing.Point(4, 153);
            this.lblCloudId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblCloudId.Name = "lblCloudId";
            this.lblCloudId.Size = new System.Drawing.Size(171, 24);
            this.lblCloudId.TabIndex = 27;
            this.lblCloudId.Text = "Cloud ID";
            // 
            // lblProjectNameReq
            // 
            this.lblProjectNameReq.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblProjectNameReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectNameReq.Location = new System.Drawing.Point(182, 33);
            this.lblProjectNameReq.Name = "lblProjectNameReq";
            this.lblProjectNameReq.Size = new System.Drawing.Size(9, 24);
            this.lblProjectNameReq.TabIndex = 35;
            this.lblProjectNameReq.Text = "*";
            // 
            // lblCloudIdReq
            // 
            this.lblCloudIdReq.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblCloudIdReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCloudIdReq.Location = new System.Drawing.Point(182, 123);
            this.lblCloudIdReq.Name = "lblCloudIdReq";
            this.lblCloudIdReq.Size = new System.Drawing.Size(9, 24);
            this.lblCloudIdReq.TabIndex = 38;
            this.lblCloudIdReq.Text = "*";
            // 
            // lblInstanceName
            // 
            this.lblInstanceName.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstanceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInstanceName.Location = new System.Drawing.Point(4, 33);
            this.lblInstanceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblInstanceName.Name = "lblInstanceName";
            this.lblInstanceName.Size = new System.Drawing.Size(171, 24);
            this.lblInstanceName.TabIndex = 25;
            this.lblInstanceName.Text = "Server\\SQL Instance Name";
            // 
            // lblSqlUserName
            // 
            this.lblSqlUserName.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSqlUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlUserName.Location = new System.Drawing.Point(4, 63);
            this.lblSqlUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblSqlUserName.Name = "lblSqlUserName";
            this.lblSqlUserName.Size = new System.Drawing.Size(171, 24);
            this.lblSqlUserName.TabIndex = 29;
            this.lblSqlUserName.Text = "SQL User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserName.EnterMoveNextControl = true;
            this.txtUserName.InitialString = "";
            this.txtUserName.Location = new System.Drawing.Point(198, 63);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(238, 20);
            this.txtUserName.StringCasing = Relyon.Controls.RSXTextBox.stringCase.None;
            this.txtUserName.SupressModifiedState = false;
            this.txtUserName.TabIndex = 61;
            // 
            // lblSqlPassword
            // 
            this.lblSqlPassword.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSqlPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSqlPassword.Location = new System.Drawing.Point(4, 93);
            this.lblSqlPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblSqlPassword.Name = "lblSqlPassword";
            this.lblSqlPassword.Size = new System.Drawing.Size(171, 24);
            this.lblSqlPassword.TabIndex = 30;
            this.lblSqlPassword.Text = "SQL Password";
            // 
            // txtUserpwd
            // 
            this.txtUserpwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserpwd.EnterMoveNextControl = true;
            this.txtUserpwd.InitialString = "";
            this.txtUserpwd.Location = new System.Drawing.Point(198, 93);
            this.txtUserpwd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserpwd.Name = "txtUserpwd";
            this.txtUserpwd.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtUserpwd.Properties.Appearance.Options.UseFont = true;
            this.txtUserpwd.Size = new System.Drawing.Size(238, 20);
            this.txtUserpwd.StringCasing = Relyon.Controls.RSXTextBox.stringCase.None;
            this.txtUserpwd.SupressModifiedState = false;
            this.txtUserpwd.TabIndex = 63;
            this.txtUserpwd.Leave += new System.EventHandler(this.txtUserpwd_Leave);
            // 
            // lblFileName
            // 
            this.lblFileName.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileName.Location = new System.Drawing.Point(4, 123);
            this.lblFileName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(171, 24);
            this.lblFileName.TabIndex = 26;
            this.lblFileName.Text = "Company Name";
            // 
            // cmbServer
            // 
            this.cmbServer.ClearOnPressingDelete = true;
            this.cmbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbServer.EnterMoveNextControl = true;
            this.cmbServer.InitialString = "";
            this.cmbServer.Location = new System.Drawing.Point(197, 33);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmbServer.Properties.Appearance.Options.UseFont = true;
            this.cmbServer.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmbServer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServer.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
            this.cmbServer.Properties.PopupSizeable = true;
            this.cmbServer.Size = new System.Drawing.Size(240, 20);
            this.cmbServer.StringCasing = Relyon.Controls.RSXComboEdit.stringCase.None;
            this.cmbServer.SupressModifiedState = false;
            this.cmbServer.TabIndex = 60;
            // 
            // cmbComapny
            // 
            this.cmbComapny.ClearOnPressingDelete = true;
            this.cmbComapny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbComapny.EnterMoveNextControl = true;
            this.cmbComapny.InitialString = "";
            this.cmbComapny.Location = new System.Drawing.Point(197, 123);
            this.cmbComapny.Name = "cmbComapny";
            this.cmbComapny.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmbComapny.Properties.Appearance.Options.UseFont = true;
            this.cmbComapny.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmbComapny.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbComapny.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbComapny.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
            this.cmbComapny.Properties.PopupSizeable = true;
            this.cmbComapny.Size = new System.Drawing.Size(240, 20);
            this.cmbComapny.StringCasing = Relyon.Controls.RSXComboEdit.stringCase.None;
            this.cmbComapny.SupressModifiedState = false;
            this.cmbComapny.TabIndex = 64;
            this.cmbComapny.SelectedIndexChanged += new System.EventHandler(this.cmbComapny_SelectedIndexChanged);
            // 
            // lblProjectName
            // 
            this.lblProjectName.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectName.Location = new System.Drawing.Point(4, 183);
            this.lblProjectName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(171, 24);
            this.lblProjectName.TabIndex = 24;
            this.lblProjectName.Text = "Branch Name";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectName.EnterMoveNextControl = true;
            this.txtProjectName.InitialString = "";
            this.txtProjectName.Location = new System.Drawing.Point(198, 183);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.Properties.Appearance.Options.UseFont = true;
            this.txtProjectName.Size = new System.Drawing.Size(238, 20);
            this.txtProjectName.StringCasing = Relyon.Controls.RSXTextBox.stringCase.None;
            this.txtProjectName.SupressModifiedState = false;
            this.txtProjectName.TabIndex = 66;
            this.txtProjectName.ToolTipTitle = "Branch name will be available in Company Information, Address Tab as \"Data Config" +
    "\" For Mobile app Cloud ID will be Branch Name";
            // 
            // lblServerReq
            // 
            this.lblServerReq.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblServerReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerReq.Location = new System.Drawing.Point(182, 153);
            this.lblServerReq.Name = "lblServerReq";
            this.lblServerReq.Size = new System.Drawing.Size(9, 24);
            this.lblServerReq.TabIndex = 36;
            this.lblServerReq.Text = "*";
            // 
            // lblFileNameReq
            // 
            this.lblFileNameReq.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblFileNameReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileNameReq.Location = new System.Drawing.Point(182, 183);
            this.lblFileNameReq.Name = "lblFileNameReq";
            this.lblFileNameReq.Size = new System.Drawing.Size(9, 24);
            this.lblFileNameReq.TabIndex = 37;
            this.lblFileNameReq.Text = "*";
            // 
            // lblProjectPath
            // 
            this.lblProjectPath.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectPath.Location = new System.Drawing.Point(4, 213);
            this.lblProjectPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblProjectPath.Name = "lblProjectPath";
            this.lblProjectPath.Size = new System.Drawing.Size(171, 24);
            this.lblProjectPath.TabIndex = 28;
            this.lblProjectPath.Text = "Project Path";
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectPath.EditValue = "";
            this.txtProjectPath.Location = new System.Drawing.Point(197, 213);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectPath.Properties.Appearance.Options.UseFont = true;
            this.txtProjectPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtProjectPath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txtProjectPath.Size = new System.Drawing.Size(240, 20);
            this.txtProjectPath.TabIndex = 68;
            this.txtProjectPath.EditValueChanged += new System.EventHandler(this.txtProjectPath_EditValueChanged);
            this.txtProjectPath.Click += new System.EventHandler(this.txtProjectPath_Click);
            // 
            // tlpProjectBtn
            // 
            this.tlpProjectBtn.ColumnCount = 2;
            this.tlpProjectBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.40485F));
            this.tlpProjectBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.59515F));
            this.tlpProjectBtn.Controls.Add(this.btnClose, 1, 0);
            this.tlpProjectBtn.Controls.Add(this.btnCreate_project, 0, 0);
            this.tlpProjectBtn.Location = new System.Drawing.Point(198, 274);
            this.tlpProjectBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpProjectBtn.Name = "tlpProjectBtn";
            this.tlpProjectBtn.RowCount = 1;
            this.tlpProjectBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProjectBtn.Size = new System.Drawing.Size(238, 34);
            this.tlpProjectBtn.TabIndex = 31;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(115, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.MinimumSize = new System.Drawing.Size(95, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCreate_project
            // 
            this.btnCreate_project.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate_project.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate_project.Location = new System.Drawing.Point(3, 2);
            this.btnCreate_project.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreate_project.Name = "btnCreate_project";
            this.btnCreate_project.Size = new System.Drawing.Size(106, 30);
            this.btnCreate_project.TabIndex = 69;
            this.btnCreate_project.Text = "C&reate";
            this.btnCreate_project.UseVisualStyleBackColor = true;
            this.btnCreate_project.Click += new System.EventHandler(this.btnCreate_project_Click);
            // 
            // lblIP
            // 
            this.lblIP.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIP.Location = new System.Drawing.Point(3, 243);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(173, 25);
            this.lblIP.TabIndex = 69;
            this.lblIP.Text = "IP Address";
            // 
            // lblIpRequired
            // 
            this.lblIpRequired.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblIpRequired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIpRequired.Location = new System.Drawing.Point(182, 243);
            this.lblIpRequired.Name = "lblIpRequired";
            this.lblIpRequired.Size = new System.Drawing.Size(9, 25);
            this.lblIpRequired.TabIndex = 70;
            this.lblIpRequired.Text = "*";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIpAddress.EnterMoveNextControl = true;
            this.txtIpAddress.InitialString = "";
            this.txtIpAddress.Location = new System.Drawing.Point(198, 243);
            this.txtIpAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtIpAddress.Properties.Appearance.Options.UseFont = true;
            this.txtIpAddress.Size = new System.Drawing.Size(238, 20);
            this.txtIpAddress.StringCasing = Relyon.Controls.RSXTextBox.stringCase.None;
            this.txtIpAddress.SupressModifiedState = false;
            this.txtIpAddress.TabIndex = 71;
            // 
            // tlpLinks
            // 
            this.tlpLinks.ColumnCount = 1;
            this.tlpLinks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinks.Controls.Add(this.lblCheckUpdates, 0, 1);
            this.tlpLinks.Controls.Add(this.lblCheckPreRequsistes, 0, 0);
            this.tlpLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLinks.Location = new System.Drawing.Point(3, 274);
            this.tlpLinks.Name = "tlpLinks";
            this.tlpLinks.RowCount = 2;
            this.tlpLinks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinks.Size = new System.Drawing.Size(173, 41);
            this.tlpLinks.TabIndex = 72;
            // 
            // lblCheckUpdates
            // 
            this.lblCheckUpdates.AutoSize = true;
            this.lblCheckUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckUpdates.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckUpdates.Location = new System.Drawing.Point(3, 20);
            this.lblCheckUpdates.Name = "lblCheckUpdates";
            this.lblCheckUpdates.Size = new System.Drawing.Size(167, 21);
            this.lblCheckUpdates.TabIndex = 43;
            this.lblCheckUpdates.TabStop = true;
            this.lblCheckUpdates.Text = "Check Updates";
            this.lblCheckUpdates.Click += new System.EventHandler(this.lblCheckUpdates_Click);
            // 
            // lblCheckPreRequsistes
            // 
            this.lblCheckPreRequsistes.AutoSize = true;
            this.lblCheckPreRequsistes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckPreRequsistes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckPreRequsistes.Location = new System.Drawing.Point(3, 0);
            this.lblCheckPreRequsistes.Name = "lblCheckPreRequsistes";
            this.lblCheckPreRequsistes.Size = new System.Drawing.Size(167, 20);
            this.lblCheckPreRequsistes.TabIndex = 42;
            this.lblCheckPreRequsistes.TabStop = true;
            this.lblCheckPreRequsistes.Text = "Check Pre Requisites";
            this.lblCheckPreRequsistes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCheckPreRequsistes_LinkClicked);
            // 
            // radioGroup1
            // 
            this.tlpProjectDetails.SetColumnSpan(this.radioGroup1, 3);
            this.radioGroup1.Location = new System.Drawing.Point(3, 3);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Columns = 3;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Automatic"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Manual"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Json Import")});
            this.radioGroup1.Size = new System.Drawing.Size(434, 24);
            this.radioGroup1.TabIndex = 73;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::enable_ManageIIS.Properties.Resources.saral;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tlpProjectDetails, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCaption, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.70588F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.882353F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.176471F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(448, 425);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(3, 82);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(320, 16);
            this.lblCaption.TabIndex = 5;
            this.lblCaption.Text = "                          Saral IIS Server Configuration";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmIISManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(451, 429);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.progressPanel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmIISManager";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saral Server Configuration";
            this.Load += new System.EventHandler(this.frmIISManager_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tlpProjectDetails.ResumeLayout(false);
            this.tlpProjectDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserpwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbComapny.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectPath.Properties)).EndInit();
            this.tlpProjectBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtIpAddress.Properties)).EndInit();
            this.tlpLinks.ResumeLayout(false);
            this.tlpLinks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreate_project;
        private System.Windows.Forms.Button btnClose;
        private Relyon.Controls.RSXTextBox txtUserName;
        private Relyon.Controls.RSXTextBox txtUserpwd;
        private DevExpress.XtraEditors.LabelControl lblProjectName;
        private DevExpress.XtraEditors.LabelControl lblInstanceName;
        private DevExpress.XtraEditors.LabelControl lblFileName;
        private DevExpress.XtraEditors.LabelControl lblCloudId;
        private DevExpress.XtraEditors.LabelControl lblProjectPath;
        private DevExpress.XtraEditors.LabelControl lblSqlUserName;
        private DevExpress.XtraEditors.LabelControl lblSqlPassword;
        private System.Windows.Forms.TableLayoutPanel tlpProjectDetails;
        private System.Windows.Forms.TableLayoutPanel tlpProjectBtn;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private Relyon.Controls.NumericTextBox txtCompanyId;
        private DevExpress.XtraEditors.LabelControl lblProjectNameReq;
        private DevExpress.XtraEditors.LabelControl lblServerReq;
        private DevExpress.XtraEditors.LabelControl lblFileNameReq;
        private DevExpress.XtraEditors.LabelControl lblCloudIdReq;
        private Relyon.Controls.RSXTextBox txtProjectName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.ButtonEdit txtProjectPath;
        private System.Windows.Forms.LinkLabel lblCheckPreRequsistes;
        private Relyon.Controls.RSXComboEdit cmbServer;
        private Relyon.Controls.RSXComboEdit cmbComapny;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Relyon.Controls.RSXLabel lblCaption;
        private Relyon.Controls.RSXLabel lblIP;
        private DevExpress.XtraEditors.LabelControl lblIpRequired;
        private Relyon.Controls.RSXTextBox txtIpAddress;
        private System.Windows.Forms.TableLayoutPanel tlpLinks;
        private System.Windows.Forms.LinkLabel lblCheckUpdates;
        private System.Windows.Forms.ToolTip tooltipPath;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

