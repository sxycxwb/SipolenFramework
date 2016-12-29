namespace RDIFramework.NET
{
    partial class FrmOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOption));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.btnSave = new RDIFramework.Controls.UcButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new DevComponents.DotNetBar.TabControl();
            this.tabPnlServer = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EnableOrganizePermission = new System.Windows.Forms.CheckBox();
            this.PasswordErrorLockCycle = new DevComponents.Editors.IntegerInput();
            this.PasswordMiniLength = new DevComponents.Editors.IntegerInput();
            this.PasswordChangeCycle = new DevComponents.Editors.IntegerInput();
            this.OnLineTime0ut = new DevComponents.Editors.IntegerInput();
            this.PasswordErrorLockLimit = new DevComponents.Editors.IntegerInput();
            this.AccountMinimumLength = new DevComponents.Editors.IntegerInput();
            this.OnLineLimit = new DevComponents.Editors.IntegerInput();
            this.lblPasswordErrorLockCycle = new System.Windows.Forms.Label();
            this.lblPasswordErrorLockLimit = new System.Windows.Forms.Label();
            this.lblAccountMinimumLength = new System.Windows.Forms.Label();
            this.lblOnLineTime0ut = new System.Windows.Forms.Label();
            this.lblPasswordChangeCycle = new System.Windows.Forms.Label();
            this.lblPasswordMiniLength = new System.Windows.Forms.Label();
            this.DefaultPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDefaultPassword = new System.Windows.Forms.Label();
            this.lblOnLineLimit = new System.Windows.Forms.Label();
            this.CheckOnLine = new System.Windows.Forms.CheckBox();
            this.NumericCharacters = new System.Windows.Forms.CheckBox();
            this.EnableCheckPasswordStrength = new System.Windows.Forms.CheckBox();
            this.EnableEncryptServerPassword = new System.Windows.Forms.CheckBox();
            this.EnableTableConstraintPermission = new System.Windows.Forms.CheckBox();
            this.EnableTableFieldPermission = new System.Windows.Forms.CheckBox();
            this.EnablePermissionItem = new System.Windows.Forms.CheckBox();
            this.EnableModulePermission = new System.Windows.Forms.CheckBox();
            this.EnableUserAuthorization = new System.Windows.Forms.CheckBox();
            this.EnableUserAuthorizationScope = new System.Windows.Forms.CheckBox();
            this.EnableCheckIPAddress = new System.Windows.Forms.CheckBox();
            this.EnableRecordLog = new System.Windows.Forms.CheckBox();
            this.AllowUserToRegister = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTipServerConfig = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabItemServerConfig = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabPnlSystemPar = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MainForm = new RDIFramework.Controls.UcComboBoxEx();
            this.FrmRDIFrameworkNav = new DevComponents.Editors.ComboItem();
            this.FrmRDIFrameworkTree = new DevComponents.Editors.ComboItem();
            this.FrmRDIFrameworkRibbon = new DevComponents.Editors.ComboItem();
            this.Service = new RDIFramework.Controls.UcComboBoxEx();
            this.lblService = new System.Windows.Forms.Label();
            this.RegisterKey = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRegisterKey = new System.Windows.Forms.Label();
            this.Version = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.SoftFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSoftFullName = new System.Windows.Forms.Label();
            this.SoftName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSoftName = new System.Windows.Forms.Label();
            this.ConfigurationFrom = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblConfigurationFrom = new System.Windows.Forms.Label();
            this.CustomerCompanyName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCustomerCompanyName = new System.Windows.Forms.Label();
            this.LogOnAssembly = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblLogOnAssembly = new System.Windows.Forms.Label();
            this.LogOnForm = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblLogOnForm = new System.Windows.Forms.Label();
            this.lblMainForm = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTipSystemParConfig = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabItemSystemParConfig = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabPnlClient = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CurrentLanguage = new RDIFramework.Controls.UcComboBoxEx();
            this.zhCN = new DevComponents.Editors.ComboItem();
            this.zhTW = new DevComponents.Editors.ComboItem();
            this.enUS = new DevComponents.Editors.ComboItem();
            this.lblCurrentLanguage = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.RDIFrameworkDbConection = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblRDIFrameworkDbConection = new System.Windows.Forms.Label();
            this.EncryptDbConnection = new System.Windows.Forms.CheckBox();
            this.RDIFrameworkDbType = new RDIFramework.Controls.UcComboBoxEx();
            this.lblRDIFrameworkDbType = new System.Windows.Forms.Label();
            this.ServicePassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblServicePassword = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ServiceUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblServiceUserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LoadAllUser = new System.Windows.Forms.CheckBox();
            this.AutoLogOn = new System.Windows.Forms.CheckBox();
            this.RememberPassword = new System.Windows.Forms.CheckBox();
            this.EncryptClientPassword = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTipClientConfig = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabItemClientConfig = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabPnlReport = new DevComponents.DotNetBar.TabControlPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ErrorReportMailServer = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblErrorReportMailServer = new System.Windows.Forms.Label();
            this.ErrorReportMailPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblErrorReportMailPassword = new System.Windows.Forms.Label();
            this.ErrorReportMailUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblErrorReportMailUserName = new System.Windows.Forms.Label();
            this.ErrorReportFrom = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblErrorReportFrom = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTipReportConfig = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tabItemReportConfig = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPnlServer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordErrorLockCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordMiniLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordChangeCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnLineTime0ut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordErrorLockLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountMinimumLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnLineLimit)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPnlSystemPar.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPnlClient.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPnlReport.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Info;
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(1, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(568, 78);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(1, 524);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(568, 43);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(454, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(360, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabControlMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(1, 79);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(568, 445);
            this.pnlMain.TabIndex = 2;
            // 
            // tabControlMain
            // 
            this.tabControlMain.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlMain.CanReorderTabs = true;
            this.tabControlMain.Controls.Add(this.tabPnlClient);
            this.tabControlMain.Controls.Add(this.tabPnlServer);
            this.tabControlMain.Controls.Add(this.tabPnlSystemPar);
            this.tabControlMain.Controls.Add(this.tabPnlReport);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlMain.SelectedTabIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(568, 445);
            this.tabControlMain.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControlMain.Tabs.Add(this.tabItemClientConfig);
            this.tabControlMain.Tabs.Add(this.tabItemServerConfig);
            this.tabControlMain.Tabs.Add(this.tabItemSystemParConfig);
            this.tabControlMain.Tabs.Add(this.tabItemReportConfig);
            // 
            // tabPnlServer
            // 
            this.tabPnlServer.Controls.Add(this.groupBox2);
            this.tabPnlServer.Controls.Add(this.panel2);
            this.tabPnlServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPnlServer.Location = new System.Drawing.Point(0, 27);
            this.tabPnlServer.Name = "tabPnlServer";
            this.tabPnlServer.Padding = new System.Windows.Forms.Padding(5);
            this.tabPnlServer.Size = new System.Drawing.Size(568, 418);
            this.tabPnlServer.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabPnlServer.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabPnlServer.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabPnlServer.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabPnlServer.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabPnlServer.Style.GradientAngle = 90;
            this.tabPnlServer.TabIndex = 2;
            this.tabPnlServer.TabItem = this.tabItemServerConfig;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.EnableOrganizePermission);
            this.groupBox2.Controls.Add(this.PasswordErrorLockCycle);
            this.groupBox2.Controls.Add(this.PasswordMiniLength);
            this.groupBox2.Controls.Add(this.PasswordChangeCycle);
            this.groupBox2.Controls.Add(this.OnLineTime0ut);
            this.groupBox2.Controls.Add(this.PasswordErrorLockLimit);
            this.groupBox2.Controls.Add(this.AccountMinimumLength);
            this.groupBox2.Controls.Add(this.OnLineLimit);
            this.groupBox2.Controls.Add(this.lblPasswordErrorLockCycle);
            this.groupBox2.Controls.Add(this.lblPasswordErrorLockLimit);
            this.groupBox2.Controls.Add(this.lblAccountMinimumLength);
            this.groupBox2.Controls.Add(this.lblOnLineTime0ut);
            this.groupBox2.Controls.Add(this.lblPasswordChangeCycle);
            this.groupBox2.Controls.Add(this.lblPasswordMiniLength);
            this.groupBox2.Controls.Add(this.DefaultPassword);
            this.groupBox2.Controls.Add(this.lblDefaultPassword);
            this.groupBox2.Controls.Add(this.lblOnLineLimit);
            this.groupBox2.Controls.Add(this.CheckOnLine);
            this.groupBox2.Controls.Add(this.NumericCharacters);
            this.groupBox2.Controls.Add(this.EnableCheckPasswordStrength);
            this.groupBox2.Controls.Add(this.EnableEncryptServerPassword);
            this.groupBox2.Controls.Add(this.EnableTableConstraintPermission);
            this.groupBox2.Controls.Add(this.EnableTableFieldPermission);
            this.groupBox2.Controls.Add(this.EnablePermissionItem);
            this.groupBox2.Controls.Add(this.EnableModulePermission);
            this.groupBox2.Controls.Add(this.EnableUserAuthorization);
            this.groupBox2.Controls.Add(this.EnableUserAuthorizationScope);
            this.groupBox2.Controls.Add(this.EnableCheckIPAddress);
            this.groupBox2.Controls.Add(this.EnableRecordLog);
            this.groupBox2.Controls.Add(this.AllowUserToRegister);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 367);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // EnableOrganizePermission
            // 
            this.EnableOrganizePermission.AutoSize = true;
            this.EnableOrganizePermission.Location = new System.Drawing.Point(253, 171);
            this.EnableOrganizePermission.Name = "EnableOrganizePermission";
            this.EnableOrganizePermission.Size = new System.Drawing.Size(180, 18);
            this.EnableOrganizePermission.TabIndex = 61;
            this.EnableOrganizePermission.Text = "是否启用组织机构权限。";
            this.EnableOrganizePermission.UseVisualStyleBackColor = true;
            // 
            // PasswordErrorLockCycle
            // 
            // 
            // 
            // 
            this.PasswordErrorLockCycle.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PasswordErrorLockCycle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PasswordErrorLockCycle.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PasswordErrorLockCycle.Location = new System.Drawing.Point(404, 257);
            this.PasswordErrorLockCycle.Name = "PasswordErrorLockCycle";
            this.PasswordErrorLockCycle.ShowUpDown = true;
            this.PasswordErrorLockCycle.Size = new System.Drawing.Size(130, 23);
            this.PasswordErrorLockCycle.TabIndex = 60;
            // 
            // PasswordMiniLength
            // 
            // 
            // 
            // 
            this.PasswordMiniLength.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PasswordMiniLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PasswordMiniLength.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PasswordMiniLength.Location = new System.Drawing.Point(404, 288);
            this.PasswordMiniLength.Name = "PasswordMiniLength";
            this.PasswordMiniLength.ShowUpDown = true;
            this.PasswordMiniLength.Size = new System.Drawing.Size(130, 23);
            this.PasswordMiniLength.TabIndex = 59;
            // 
            // PasswordChangeCycle
            // 
            // 
            // 
            // 
            this.PasswordChangeCycle.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PasswordChangeCycle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PasswordChangeCycle.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PasswordChangeCycle.Location = new System.Drawing.Point(404, 228);
            this.PasswordChangeCycle.Name = "PasswordChangeCycle";
            this.PasswordChangeCycle.ShowUpDown = true;
            this.PasswordChangeCycle.Size = new System.Drawing.Size(130, 23);
            this.PasswordChangeCycle.TabIndex = 58;
            // 
            // OnLineTime0ut
            // 
            // 
            // 
            // 
            this.OnLineTime0ut.BackgroundStyle.Class = "DateTimeInputBackground";
            this.OnLineTime0ut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OnLineTime0ut.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.OnLineTime0ut.Location = new System.Drawing.Point(404, 196);
            this.OnLineTime0ut.Name = "OnLineTime0ut";
            this.OnLineTime0ut.ShowUpDown = true;
            this.OnLineTime0ut.Size = new System.Drawing.Size(130, 23);
            this.OnLineTime0ut.TabIndex = 57;
            // 
            // PasswordErrorLockLimit
            // 
            // 
            // 
            // 
            this.PasswordErrorLockLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.PasswordErrorLockLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.PasswordErrorLockLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.PasswordErrorLockLimit.Location = new System.Drawing.Point(133, 257);
            this.PasswordErrorLockLimit.Name = "PasswordErrorLockLimit";
            this.PasswordErrorLockLimit.ShowUpDown = true;
            this.PasswordErrorLockLimit.Size = new System.Drawing.Size(111, 23);
            this.PasswordErrorLockLimit.TabIndex = 56;
            // 
            // AccountMinimumLength
            // 
            // 
            // 
            // 
            this.AccountMinimumLength.BackgroundStyle.Class = "DateTimeInputBackground";
            this.AccountMinimumLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.AccountMinimumLength.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.AccountMinimumLength.Location = new System.Drawing.Point(133, 228);
            this.AccountMinimumLength.Name = "AccountMinimumLength";
            this.AccountMinimumLength.ShowUpDown = true;
            this.AccountMinimumLength.Size = new System.Drawing.Size(111, 23);
            this.AccountMinimumLength.TabIndex = 55;
            // 
            // OnLineLimit
            // 
            // 
            // 
            // 
            this.OnLineLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.OnLineLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OnLineLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.OnLineLimit.Location = new System.Drawing.Point(133, 199);
            this.OnLineLimit.Name = "OnLineLimit";
            this.OnLineLimit.ShowUpDown = true;
            this.OnLineLimit.Size = new System.Drawing.Size(111, 23);
            this.OnLineLimit.TabIndex = 54;
            // 
            // lblPasswordErrorLockCycle
            // 
            this.lblPasswordErrorLockCycle.Location = new System.Drawing.Point(251, 260);
            this.lblPasswordErrorLockCycle.Name = "lblPasswordErrorLockCycle";
            this.lblPasswordErrorLockCycle.Size = new System.Drawing.Size(154, 29);
            this.lblPasswordErrorLockCycle.TabIndex = 51;
            this.lblPasswordErrorLockCycle.Text = "密码错误锁定周期(分钟)：";
            this.lblPasswordErrorLockCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPasswordErrorLockLimit
            // 
            this.lblPasswordErrorLockLimit.AutoEllipsis = true;
            this.lblPasswordErrorLockLimit.Location = new System.Drawing.Point(6, 258);
            this.lblPasswordErrorLockLimit.Name = "lblPasswordErrorLockLimit";
            this.lblPasswordErrorLockLimit.Size = new System.Drawing.Size(126, 28);
            this.lblPasswordErrorLockLimit.TabIndex = 49;
            this.lblPasswordErrorLockLimit.Text = "密码错误锁定次数：";
            this.lblPasswordErrorLockLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccountMinimumLength
            // 
            this.lblAccountMinimumLength.AutoEllipsis = true;
            this.lblAccountMinimumLength.Location = new System.Drawing.Point(6, 225);
            this.lblAccountMinimumLength.Name = "lblAccountMinimumLength";
            this.lblAccountMinimumLength.Size = new System.Drawing.Size(126, 28);
            this.lblAccountMinimumLength.TabIndex = 47;
            this.lblAccountMinimumLength.Text = "用户名最小长度：";
            this.lblAccountMinimumLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOnLineTime0ut
            // 
            this.lblOnLineTime0ut.Location = new System.Drawing.Point(251, 196);
            this.lblOnLineTime0ut.Name = "lblOnLineTime0ut";
            this.lblOnLineTime0ut.Size = new System.Drawing.Size(154, 29);
            this.lblOnLineTime0ut.TabIndex = 45;
            this.lblOnLineTime0ut.Text = "在线超时时间（以秒为单位）：";
            this.lblOnLineTime0ut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPasswordChangeCycle
            // 
            this.lblPasswordChangeCycle.Location = new System.Drawing.Point(251, 228);
            this.lblPasswordChangeCycle.Name = "lblPasswordChangeCycle";
            this.lblPasswordChangeCycle.Size = new System.Drawing.Size(154, 29);
            this.lblPasswordChangeCycle.TabIndex = 43;
            this.lblPasswordChangeCycle.Text = "密码修改周期(月)：";
            this.lblPasswordChangeCycle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPasswordMiniLength
            // 
            this.lblPasswordMiniLength.Location = new System.Drawing.Point(249, 286);
            this.lblPasswordMiniLength.Name = "lblPasswordMiniLength";
            this.lblPasswordMiniLength.Size = new System.Drawing.Size(154, 24);
            this.lblPasswordMiniLength.TabIndex = 41;
            this.lblPasswordMiniLength.Text = "密码最小长度：";
            this.lblPasswordMiniLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DefaultPassword
            // 
            // 
            // 
            // 
            this.DefaultPassword.Border.Class = "TextBoxBorder";
            this.DefaultPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.DefaultPassword.FocusHighlightEnabled = true;
            this.DefaultPassword.Location = new System.Drawing.Point(133, 293);
            this.DefaultPassword.Name = "DefaultPassword";
            this.DefaultPassword.PasswordChar = '*';
            this.DefaultPassword.SelectedValue = null;
            this.DefaultPassword.Size = new System.Drawing.Size(111, 23);
            this.DefaultPassword.TabIndex = 40;
            // 
            // lblDefaultPassword
            // 
            this.lblDefaultPassword.AutoEllipsis = true;
            this.lblDefaultPassword.Location = new System.Drawing.Point(6, 289);
            this.lblDefaultPassword.Name = "lblDefaultPassword";
            this.lblDefaultPassword.Size = new System.Drawing.Size(126, 28);
            this.lblDefaultPassword.TabIndex = 39;
            this.lblDefaultPassword.Text = "系统默认密码：";
            this.lblDefaultPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOnLineLimit
            // 
            this.lblOnLineLimit.AutoEllipsis = true;
            this.lblOnLineLimit.Location = new System.Drawing.Point(6, 197);
            this.lblOnLineLimit.Name = "lblOnLineLimit";
            this.lblOnLineLimit.Size = new System.Drawing.Size(126, 28);
            this.lblOnLineLimit.TabIndex = 37;
            this.lblOnLineLimit.Text = "最大在线用户数量限制：";
            this.lblOnLineLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckOnLine
            // 
            this.CheckOnLine.AutoSize = true;
            this.CheckOnLine.Location = new System.Drawing.Point(23, 171);
            this.CheckOnLine.Name = "CheckOnLine";
            this.CheckOnLine.Size = new System.Drawing.Size(152, 18);
            this.CheckOnLine.TabIndex = 36;
            this.CheckOnLine.Text = "检测用户是否在线。";
            this.CheckOnLine.UseVisualStyleBackColor = true;
            // 
            // NumericCharacters
            // 
            this.NumericCharacters.AutoSize = true;
            this.NumericCharacters.Location = new System.Drawing.Point(253, 148);
            this.NumericCharacters.Name = "NumericCharacters";
            this.NumericCharacters.Size = new System.Drawing.Size(229, 18);
            this.NumericCharacters.TabIndex = 34;
            this.NumericCharacters.Text = "密码是否必须为字母+数字组合。";
            this.NumericCharacters.UseVisualStyleBackColor = true;
            // 
            // EnableCheckPasswordStrength
            // 
            this.EnableCheckPasswordStrength.AutoSize = true;
            this.EnableCheckPasswordStrength.Location = new System.Drawing.Point(23, 148);
            this.EnableCheckPasswordStrength.Name = "EnableCheckPasswordStrength";
            this.EnableCheckPasswordStrength.Size = new System.Drawing.Size(180, 18);
            this.EnableCheckPasswordStrength.TabIndex = 33;
            this.EnableCheckPasswordStrength.Text = "是否进行密码强度检查。";
            this.EnableCheckPasswordStrength.UseVisualStyleBackColor = true;
            // 
            // EnableEncryptServerPassword
            // 
            this.EnableEncryptServerPassword.AutoSize = true;
            this.EnableEncryptServerPassword.Location = new System.Drawing.Point(253, 124);
            this.EnableEncryptServerPassword.Name = "EnableEncryptServerPassword";
            this.EnableEncryptServerPassword.Size = new System.Drawing.Size(208, 18);
            this.EnableEncryptServerPassword.TabIndex = 32;
            this.EnableEncryptServerPassword.Text = "是否加密存储服务器端密码。";
            this.EnableEncryptServerPassword.UseVisualStyleBackColor = true;
            // 
            // EnableTableConstraintPermission
            // 
            this.EnableTableConstraintPermission.AutoSize = true;
            this.EnableTableConstraintPermission.Location = new System.Drawing.Point(23, 124);
            this.EnableTableConstraintPermission.Name = "EnableTableConstraintPermission";
            this.EnableTableConstraintPermission.Size = new System.Drawing.Size(194, 18);
            this.EnableTableConstraintPermission.TabIndex = 31;
            this.EnableTableConstraintPermission.Text = "是否启用数据表的列权限。";
            this.EnableTableConstraintPermission.UseVisualStyleBackColor = true;
            // 
            // EnableTableFieldPermission
            // 
            this.EnableTableFieldPermission.AutoSize = true;
            this.EnableTableFieldPermission.Location = new System.Drawing.Point(253, 100);
            this.EnableTableFieldPermission.Name = "EnableTableFieldPermission";
            this.EnableTableFieldPermission.Size = new System.Drawing.Size(166, 18);
            this.EnableTableFieldPermission.TabIndex = 30;
            this.EnableTableFieldPermission.Text = "是否启用表字段权限。";
            this.EnableTableFieldPermission.UseVisualStyleBackColor = true;
            // 
            // EnablePermissionItem
            // 
            this.EnablePermissionItem.AutoSize = true;
            this.EnablePermissionItem.Location = new System.Drawing.Point(23, 100);
            this.EnablePermissionItem.Name = "EnablePermissionItem";
            this.EnablePermissionItem.Size = new System.Drawing.Size(152, 18);
            this.EnablePermissionItem.TabIndex = 29;
            this.EnablePermissionItem.Text = "是否启用操作权限。";
            this.EnablePermissionItem.UseVisualStyleBackColor = true;
            // 
            // EnableModulePermission
            // 
            this.EnableModulePermission.AutoSize = true;
            this.EnableModulePermission.Location = new System.Drawing.Point(253, 75);
            this.EnableModulePermission.Name = "EnableModulePermission";
            this.EnableModulePermission.Size = new System.Drawing.Size(264, 18);
            this.EnableModulePermission.TabIndex = 28;
            this.EnableModulePermission.Text = "是否用户是否需要配置模块菜单权限。";
            this.EnableModulePermission.UseVisualStyleBackColor = true;
            // 
            // EnableUserAuthorization
            // 
            this.EnableUserAuthorization.AutoSize = true;
            this.EnableUserAuthorization.Location = new System.Drawing.Point(23, 75);
            this.EnableUserAuthorization.Name = "EnableUserAuthorization";
            this.EnableUserAuthorization.Size = new System.Drawing.Size(166, 18);
            this.EnableUserAuthorization.TabIndex = 27;
            this.EnableUserAuthorization.Text = "是否启用按用户授权。";
            this.EnableUserAuthorization.UseVisualStyleBackColor = true;
            // 
            // EnableUserAuthorizationScope
            // 
            this.EnableUserAuthorizationScope.AutoSize = true;
            this.EnableUserAuthorizationScope.Location = new System.Drawing.Point(253, 50);
            this.EnableUserAuthorizationScope.Name = "EnableUserAuthorizationScope";
            this.EnableUserAuthorizationScope.Size = new System.Drawing.Size(208, 18);
            this.EnableUserAuthorizationScope.TabIndex = 26;
            this.EnableUserAuthorizationScope.Text = "是否启用分级授权分级管理。";
            this.EnableUserAuthorizationScope.UseVisualStyleBackColor = true;
            // 
            // EnableCheckIPAddress
            // 
            this.EnableCheckIPAddress.AutoSize = true;
            this.EnableCheckIPAddress.Location = new System.Drawing.Point(23, 50);
            this.EnableCheckIPAddress.Name = "EnableCheckIPAddress";
            this.EnableCheckIPAddress.Size = new System.Drawing.Size(138, 18);
            this.EnableCheckIPAddress.TabIndex = 25;
            this.EnableCheckIPAddress.Text = "是否开启IP限制。";
            this.EnableCheckIPAddress.UseVisualStyleBackColor = true;
            // 
            // EnableRecordLog
            // 
            this.EnableRecordLog.AutoSize = true;
            this.EnableRecordLog.Location = new System.Drawing.Point(253, 22);
            this.EnableRecordLog.Name = "EnableRecordLog";
            this.EnableRecordLog.Size = new System.Drawing.Size(152, 18);
            this.EnableRecordLog.TabIndex = 24;
            this.EnableRecordLog.Text = "是否记录系统日志。";
            this.EnableRecordLog.UseVisualStyleBackColor = true;
            // 
            // AllowUserToRegister
            // 
            this.AllowUserToRegister.Location = new System.Drawing.Point(23, 22);
            this.AllowUserToRegister.Name = "AllowUserToRegister";
            this.AllowUserToRegister.Size = new System.Drawing.Size(152, 18);
            this.AllowUserToRegister.TabIndex = 23;
            this.AllowUserToRegister.Text = "是否允许用户注册。";
            this.AllowUserToRegister.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTipServerConfig);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 41);
            this.panel2.TabIndex = 3;
            // 
            // lblTipServerConfig
            // 
            this.lblTipServerConfig.AutoSize = true;
            this.lblTipServerConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipServerConfig.Location = new System.Drawing.Point(71, 16);
            this.lblTipServerConfig.Name = "lblTipServerConfig";
            this.lblTipServerConfig.Size = new System.Drawing.Size(317, 12);
            this.lblTipServerConfig.TabIndex = 34;
            this.lblTipServerConfig.Text = "此处主要是对服务器进行配置，一般仅开放给超级管理员。";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(21, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "小Tip：";
            // 
            // tabItemServerConfig
            // 
            this.tabItemServerConfig.AttachedControl = this.tabPnlServer;
            this.tabItemServerConfig.Name = "tabItemServerConfig";
            this.tabItemServerConfig.Text = "服务器端配置";
            // 
            // tabPnlSystemPar
            // 
            this.tabPnlSystemPar.Controls.Add(this.groupBox4);
            this.tabPnlSystemPar.Controls.Add(this.panel4);
            this.tabPnlSystemPar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPnlSystemPar.Location = new System.Drawing.Point(0, 27);
            this.tabPnlSystemPar.Name = "tabPnlSystemPar";
            this.tabPnlSystemPar.Padding = new System.Windows.Forms.Padding(5);
            this.tabPnlSystemPar.Size = new System.Drawing.Size(568, 418);
            this.tabPnlSystemPar.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabPnlSystemPar.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabPnlSystemPar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabPnlSystemPar.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabPnlSystemPar.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabPnlSystemPar.Style.GradientAngle = 90;
            this.tabPnlSystemPar.TabIndex = 4;
            this.tabPnlSystemPar.TabItem = this.tabItemSystemParConfig;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.MainForm);
            this.groupBox4.Controls.Add(this.Service);
            this.groupBox4.Controls.Add(this.lblService);
            this.groupBox4.Controls.Add(this.RegisterKey);
            this.groupBox4.Controls.Add(this.lblRegisterKey);
            this.groupBox4.Controls.Add(this.Version);
            this.groupBox4.Controls.Add(this.lblVersion);
            this.groupBox4.Controls.Add(this.SoftFullName);
            this.groupBox4.Controls.Add(this.lblSoftFullName);
            this.groupBox4.Controls.Add(this.SoftName);
            this.groupBox4.Controls.Add(this.lblSoftName);
            this.groupBox4.Controls.Add(this.ConfigurationFrom);
            this.groupBox4.Controls.Add(this.lblConfigurationFrom);
            this.groupBox4.Controls.Add(this.CustomerCompanyName);
            this.groupBox4.Controls.Add(this.lblCustomerCompanyName);
            this.groupBox4.Controls.Add(this.LogOnAssembly);
            this.groupBox4.Controls.Add(this.lblLogOnAssembly);
            this.groupBox4.Controls.Add(this.LogOnForm);
            this.groupBox4.Controls.Add(this.lblLogOnForm);
            this.groupBox4.Controls.Add(this.lblMainForm);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(5, 46);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(558, 367);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // MainForm
            // 
            this.MainForm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.MainForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MainForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainForm.FormattingEnabled = true;
            this.MainForm.Items.AddRange(new object[] {
            this.FrmRDIFrameworkNav,
            this.FrmRDIFrameworkTree,
            this.FrmRDIFrameworkRibbon});
            this.MainForm.Location = new System.Drawing.Point(114, 24);
            this.MainForm.Name = "MainForm";
            this.MainForm.Size = new System.Drawing.Size(159, 24);
            this.MainForm.TabIndex = 62;
            // 
            // FrmRDIFrameworkNav
            // 
            this.FrmRDIFrameworkNav.Text = "FrmRDIFrameworkNav";
            // 
            // FrmRDIFrameworkTree
            // 
            this.FrmRDIFrameworkTree.Text = "FrmRDIFrameworkTree";
            // 
            // FrmRDIFrameworkRibbon
            // 
            this.FrmRDIFrameworkRibbon.Text = "FrmRDIFrameworkRibbon";
            // 
            // Service
            // 
            this.Service.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Service.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Service.FormattingEnabled = true;
            this.Service.Items.AddRange(new object[] {
            "RDIFramework.BizLogic",
            "RDIFramework.ServiceClient"});
            this.Service.Location = new System.Drawing.Point(114, 209);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(396, 24);
            this.Service.TabIndex = 61;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(9, 214);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(105, 14);
            this.lblService.TabIndex = 59;
            this.lblService.Text = "服务提供程序：";
            // 
            // RegisterKey
            // 
            this.RegisterKey.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.RegisterKey.Border.Class = "TextBoxBorder";
            this.RegisterKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RegisterKey.FocusHighlightEnabled = true;
            this.RegisterKey.Location = new System.Drawing.Point(114, 238);
            this.RegisterKey.Multiline = true;
            this.RegisterKey.Name = "RegisterKey";
            this.RegisterKey.ReadOnly = true;
            this.RegisterKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RegisterKey.SelectedValue = null;
            this.RegisterKey.Size = new System.Drawing.Size(396, 81);
            this.RegisterKey.TabIndex = 58;
            // 
            // lblRegisterKey
            // 
            this.lblRegisterKey.AutoSize = true;
            this.lblRegisterKey.Location = new System.Drawing.Point(51, 242);
            this.lblRegisterKey.Name = "lblRegisterKey";
            this.lblRegisterKey.Size = new System.Drawing.Size(63, 14);
            this.lblRegisterKey.TabIndex = 57;
            this.lblRegisterKey.Text = "注册码：";
            // 
            // Version
            // 
            // 
            // 
            // 
            this.Version.Border.Class = "TextBoxBorder";
            this.Version.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Version.FocusHighlightEnabled = true;
            this.Version.Location = new System.Drawing.Point(366, 150);
            this.Version.Name = "Version";
            this.Version.SelectedValue = null;
            this.Version.Size = new System.Drawing.Size(144, 23);
            this.Version.TabIndex = 56;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(300, 155);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(77, 14);
            this.lblVersion.TabIndex = 55;
            this.lblVersion.Text = "软件版本：";
            // 
            // SoftFullName
            // 
            // 
            // 
            // 
            this.SoftFullName.Border.Class = "TextBoxBorder";
            this.SoftFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SoftFullName.FocusHighlightEnabled = true;
            this.SoftFullName.Location = new System.Drawing.Point(114, 180);
            this.SoftFullName.Name = "SoftFullName";
            this.SoftFullName.SelectedValue = null;
            this.SoftFullName.Size = new System.Drawing.Size(396, 23);
            this.SoftFullName.TabIndex = 54;
            // 
            // lblSoftFullName
            // 
            this.lblSoftFullName.AutoSize = true;
            this.lblSoftFullName.Location = new System.Drawing.Point(37, 186);
            this.lblSoftFullName.Name = "lblSoftFullName";
            this.lblSoftFullName.Size = new System.Drawing.Size(77, 14);
            this.lblSoftFullName.TabIndex = 53;
            this.lblSoftFullName.Text = "软件全称：";
            // 
            // SoftName
            // 
            // 
            // 
            // 
            this.SoftName.Border.Class = "TextBoxBorder";
            this.SoftName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SoftName.FocusHighlightEnabled = true;
            this.SoftName.Location = new System.Drawing.Point(114, 151);
            this.SoftName.Name = "SoftName";
            this.SoftName.SelectedValue = null;
            this.SoftName.Size = new System.Drawing.Size(185, 23);
            this.SoftName.TabIndex = 52;
            // 
            // lblSoftName
            // 
            this.lblSoftName.AutoSize = true;
            this.lblSoftName.Location = new System.Drawing.Point(37, 156);
            this.lblSoftName.Name = "lblSoftName";
            this.lblSoftName.Size = new System.Drawing.Size(77, 14);
            this.lblSoftName.TabIndex = 51;
            this.lblSoftName.Text = "软件名称：";
            // 
            // ConfigurationFrom
            // 
            // 
            // 
            // 
            this.ConfigurationFrom.Border.Class = "TextBoxBorder";
            this.ConfigurationFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ConfigurationFrom.FocusHighlightEnabled = true;
            this.ConfigurationFrom.Location = new System.Drawing.Point(114, 122);
            this.ConfigurationFrom.Name = "ConfigurationFrom";
            this.ConfigurationFrom.SelectedValue = null;
            this.ConfigurationFrom.Size = new System.Drawing.Size(396, 23);
            this.ConfigurationFrom.TabIndex = 50;
            // 
            // lblConfigurationFrom
            // 
            this.lblConfigurationFrom.AutoSize = true;
            this.lblConfigurationFrom.Location = new System.Drawing.Point(9, 126);
            this.lblConfigurationFrom.Name = "lblConfigurationFrom";
            this.lblConfigurationFrom.Size = new System.Drawing.Size(105, 14);
            this.lblConfigurationFrom.TabIndex = 49;
            this.lblConfigurationFrom.Text = "配置信息来源：";
            // 
            // CustomerCompanyName
            // 
            // 
            // 
            // 
            this.CustomerCompanyName.Border.Class = "TextBoxBorder";
            this.CustomerCompanyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CustomerCompanyName.FocusHighlightEnabled = true;
            this.CustomerCompanyName.Location = new System.Drawing.Point(114, 90);
            this.CustomerCompanyName.Name = "CustomerCompanyName";
            this.CustomerCompanyName.SelectedValue = null;
            this.CustomerCompanyName.Size = new System.Drawing.Size(396, 23);
            this.CustomerCompanyName.TabIndex = 48;
            // 
            // lblCustomerCompanyName
            // 
            this.lblCustomerCompanyName.AutoSize = true;
            this.lblCustomerCompanyName.Location = new System.Drawing.Point(37, 94);
            this.lblCustomerCompanyName.Name = "lblCustomerCompanyName";
            this.lblCustomerCompanyName.Size = new System.Drawing.Size(77, 14);
            this.lblCustomerCompanyName.TabIndex = 47;
            this.lblCustomerCompanyName.Text = "公司名称：";
            // 
            // LogOnAssembly
            // 
            // 
            // 
            // 
            this.LogOnAssembly.Border.Class = "TextBoxBorder";
            this.LogOnAssembly.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LogOnAssembly.FocusHighlightEnabled = true;
            this.LogOnAssembly.Location = new System.Drawing.Point(114, 59);
            this.LogOnAssembly.Name = "LogOnAssembly";
            this.LogOnAssembly.SelectedValue = null;
            this.LogOnAssembly.Size = new System.Drawing.Size(396, 23);
            this.LogOnAssembly.TabIndex = 46;
            // 
            // lblLogOnAssembly
            // 
            this.lblLogOnAssembly.Location = new System.Drawing.Point(12, 55);
            this.lblLogOnAssembly.Name = "lblLogOnAssembly";
            this.lblLogOnAssembly.Size = new System.Drawing.Size(102, 40);
            this.lblLogOnAssembly.TabIndex = 45;
            this.lblLogOnAssembly.Text = "登录部分所在程序集：";
            // 
            // LogOnForm
            // 
            // 
            // 
            // 
            this.LogOnForm.Border.Class = "TextBoxBorder";
            this.LogOnForm.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LogOnForm.FocusHighlightEnabled = true;
            this.LogOnForm.Location = new System.Drawing.Point(366, 24);
            this.LogOnForm.Name = "LogOnForm";
            this.LogOnForm.SelectedValue = null;
            this.LogOnForm.Size = new System.Drawing.Size(144, 23);
            this.LogOnForm.TabIndex = 44;
            // 
            // lblLogOnForm
            // 
            this.lblLogOnForm.AutoSize = true;
            this.lblLogOnForm.Location = new System.Drawing.Point(272, 29);
            this.lblLogOnForm.Name = "lblLogOnForm";
            this.lblLogOnForm.Size = new System.Drawing.Size(105, 14);
            this.lblLogOnForm.TabIndex = 43;
            this.lblLogOnForm.Text = "系统登录窗体：";
            // 
            // lblMainForm
            // 
            this.lblMainForm.AutoSize = true;
            this.lblMainForm.Location = new System.Drawing.Point(23, 26);
            this.lblMainForm.Name = "lblMainForm";
            this.lblMainForm.Size = new System.Drawing.Size(91, 14);
            this.lblMainForm.TabIndex = 41;
            this.lblMainForm.Text = "主界面风格：";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblTipSystemParConfig);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 41);
            this.panel4.TabIndex = 3;
            // 
            // lblTipSystemParConfig
            // 
            this.lblTipSystemParConfig.AutoSize = true;
            this.lblTipSystemParConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipSystemParConfig.Location = new System.Drawing.Point(72, 13);
            this.lblTipSystemParConfig.Name = "lblTipSystemParConfig";
            this.lblTipSystemParConfig.Size = new System.Drawing.Size(413, 12);
            this.lblTipSystemParConfig.TabIndex = 36;
            this.lblTipSystemParConfig.Text = "此处主要是对系统参数进行配置，包括平台相关程序集，客户端信息的配置。";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(22, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 12);
            this.label25.TabIndex = 35;
            this.label25.Text = "小Tip：";
            // 
            // tabItemSystemParConfig
            // 
            this.tabItemSystemParConfig.AttachedControl = this.tabPnlSystemPar;
            this.tabItemSystemParConfig.Name = "tabItemSystemParConfig";
            this.tabItemSystemParConfig.Text = "系统参数配置";
            // 
            // tabPnlClient
            // 
            this.tabPnlClient.Controls.Add(this.groupBox1);
            this.tabPnlClient.Controls.Add(this.panel1);
            this.tabPnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPnlClient.Location = new System.Drawing.Point(0, 27);
            this.tabPnlClient.Margin = new System.Windows.Forms.Padding(5);
            this.tabPnlClient.Name = "tabPnlClient";
            this.tabPnlClient.Padding = new System.Windows.Forms.Padding(5);
            this.tabPnlClient.Size = new System.Drawing.Size(568, 418);
            this.tabPnlClient.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabPnlClient.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabPnlClient.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabPnlClient.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabPnlClient.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabPnlClient.Style.GradientAngle = 90;
            this.tabPnlClient.TabIndex = 1;
            this.tabPnlClient.TabItem = this.tabItemClientConfig;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CurrentLanguage);
            this.groupBox1.Controls.Add(this.lblCurrentLanguage);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.RDIFrameworkDbConection);
            this.groupBox1.Controls.Add(this.lblRDIFrameworkDbConection);
            this.groupBox1.Controls.Add(this.EncryptDbConnection);
            this.groupBox1.Controls.Add(this.RDIFrameworkDbType);
            this.groupBox1.Controls.Add(this.lblRDIFrameworkDbType);
            this.groupBox1.Controls.Add(this.ServicePassword);
            this.groupBox1.Controls.Add(this.lblServicePassword);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.ServiceUserName);
            this.groupBox1.Controls.Add(this.lblServiceUserName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LoadAllUser);
            this.groupBox1.Controls.Add(this.AutoLogOn);
            this.groupBox1.Controls.Add(this.RememberPassword);
            this.groupBox1.Controls.Add(this.EncryptClientPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 367);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(22, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 14);
            this.label6.TabIndex = 52;
            this.label6.Text = "9.";
            // 
            // CurrentLanguage
            // 
            this.CurrentLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CurrentLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurrentLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CurrentLanguage.FormattingEnabled = true;
            this.CurrentLanguage.Items.AddRange(new object[] {
            this.zhCN,
            this.zhTW,
            this.enUS});
            this.CurrentLanguage.Location = new System.Drawing.Point(203, 257);
            this.CurrentLanguage.Name = "CurrentLanguage";
            this.CurrentLanguage.Size = new System.Drawing.Size(313, 24);
            this.CurrentLanguage.TabIndex = 51;
            // 
            // zhCN
            // 
            this.zhCN.Text = "zh-CN";
            // 
            // zhTW
            // 
            this.zhTW.Text = "zh-TW";
            // 
            // enUS
            // 
            this.enUS.Text = "en-US";
            // 
            // lblCurrentLanguage
            // 
            this.lblCurrentLanguage.Location = new System.Drawing.Point(50, 261);
            this.lblCurrentLanguage.Name = "lblCurrentLanguage";
            this.lblCurrentLanguage.Size = new System.Drawing.Size(148, 18);
            this.lblCurrentLanguage.TabIndex = 50;
            this.lblCurrentLanguage.Text = "当前语言：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(22, 225);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 14);
            this.label23.TabIndex = 49;
            this.label23.Text = "8.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Blue;
            this.label22.Location = new System.Drawing.Point(22, 302);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 14);
            this.label22.TabIndex = 48;
            this.label22.Text = "10.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.Location = new System.Drawing.Point(22, 192);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 14);
            this.label21.TabIndex = 47;
            this.label21.Text = "7.";
            // 
            // RDIFrameworkDbConection
            // 
            // 
            // 
            // 
            this.RDIFrameworkDbConection.Border.Class = "TextBoxBorder";
            this.RDIFrameworkDbConection.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RDIFrameworkDbConection.FocusHighlightEnabled = true;
            this.RDIFrameworkDbConection.Location = new System.Drawing.Point(203, 294);
            this.RDIFrameworkDbConection.Multiline = true;
            this.RDIFrameworkDbConection.Name = "RDIFrameworkDbConection";
            this.RDIFrameworkDbConection.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RDIFrameworkDbConection.SelectedValue = null;
            this.RDIFrameworkDbConection.Size = new System.Drawing.Size(313, 62);
            this.RDIFrameworkDbConection.TabIndex = 46;
            // 
            // lblRDIFrameworkDbConection
            // 
            this.lblRDIFrameworkDbConection.AutoEllipsis = true;
            this.lblRDIFrameworkDbConection.Location = new System.Drawing.Point(50, 298);
            this.lblRDIFrameworkDbConection.Name = "lblRDIFrameworkDbConection";
            this.lblRDIFrameworkDbConection.Size = new System.Drawing.Size(152, 40);
            this.lblRDIFrameworkDbConection.TabIndex = 45;
            this.lblRDIFrameworkDbConection.Text = "RDIFramework.NET框架数据库连接字符串：";
            // 
            // EncryptDbConnection
            // 
            this.EncryptDbConnection.AutoSize = true;
            this.EncryptDbConnection.Location = new System.Drawing.Point(50, 135);
            this.EncryptDbConnection.Name = "EncryptDbConnection";
            this.EncryptDbConnection.Size = new System.Drawing.Size(236, 18);
            this.EncryptDbConnection.TabIndex = 44;
            this.EncryptDbConnection.Text = "是否加密存储数据库连接字符串。";
            this.EncryptDbConnection.UseVisualStyleBackColor = true;
            // 
            // RDIFrameworkDbType
            // 
            this.RDIFrameworkDbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RDIFrameworkDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RDIFrameworkDbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RDIFrameworkDbType.FormattingEnabled = true;
            this.RDIFrameworkDbType.Items.AddRange(new object[] {
            "SqlServer",
            "Oracle",
            "MySql",
            "DB2",
            "SQLite",
            "Access"});
            this.RDIFrameworkDbType.Location = new System.Drawing.Point(203, 225);
            this.RDIFrameworkDbType.Name = "RDIFrameworkDbType";
            this.RDIFrameworkDbType.Size = new System.Drawing.Size(313, 24);
            this.RDIFrameworkDbType.TabIndex = 43;
            // 
            // lblRDIFrameworkDbType
            // 
            this.lblRDIFrameworkDbType.AutoEllipsis = true;
            this.lblRDIFrameworkDbType.Location = new System.Drawing.Point(50, 220);
            this.lblRDIFrameworkDbType.Name = "lblRDIFrameworkDbType";
            this.lblRDIFrameworkDbType.Size = new System.Drawing.Size(148, 34);
            this.lblRDIFrameworkDbType.TabIndex = 42;
            this.lblRDIFrameworkDbType.Text = "RDIFramework.NET框架数据库类型：";
            // 
            // ServicePassword
            // 
            // 
            // 
            // 
            this.ServicePassword.Border.Class = "TextBoxBorder";
            this.ServicePassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ServicePassword.FocusHighlightEnabled = true;
            this.ServicePassword.Location = new System.Drawing.Point(203, 191);
            this.ServicePassword.Name = "ServicePassword";
            this.ServicePassword.PasswordChar = '*';
            this.ServicePassword.SelectedValue = null;
            this.ServicePassword.Size = new System.Drawing.Size(313, 23);
            this.ServicePassword.TabIndex = 32;
            // 
            // lblServicePassword
            // 
            this.lblServicePassword.AutoSize = true;
            this.lblServicePassword.Location = new System.Drawing.Point(50, 195);
            this.lblServicePassword.Name = "lblServicePassword";
            this.lblServicePassword.Size = new System.Drawing.Size(147, 14);
            this.lblServicePassword.TabIndex = 31;
            this.lblServicePassword.Text = "远程调用服务的密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(22, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "6.";
            // 
            // ServiceUserName
            // 
            // 
            // 
            // 
            this.ServiceUserName.Border.Class = "TextBoxBorder";
            this.ServiceUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ServiceUserName.FocusHighlightEnabled = true;
            this.ServiceUserName.Location = new System.Drawing.Point(203, 161);
            this.ServiceUserName.Name = "ServiceUserName";
            this.ServiceUserName.SelectedValue = null;
            this.ServiceUserName.Size = new System.Drawing.Size(313, 23);
            this.ServiceUserName.TabIndex = 29;
            // 
            // lblServiceUserName
            // 
            this.lblServiceUserName.AutoSize = true;
            this.lblServiceUserName.Location = new System.Drawing.Point(50, 164);
            this.lblServiceUserName.Name = "lblServiceUserName";
            this.lblServiceUserName.Size = new System.Drawing.Size(161, 14);
            this.lblServiceUserName.TabIndex = 28;
            this.lblServiceUserName.Text = "远程调用服务的用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(22, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "5.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(22, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "4.";
            // 
            // LoadAllUser
            // 
            this.LoadAllUser.AutoSize = true;
            this.LoadAllUser.Location = new System.Drawing.Point(50, 108);
            this.LoadAllUser.Name = "LoadAllUser";
            this.LoadAllUser.Size = new System.Drawing.Size(180, 18);
            this.LoadAllUser.TabIndex = 25;
            this.LoadAllUser.Text = "是否一次加载所有用户。";
            this.LoadAllUser.UseVisualStyleBackColor = true;
            // 
            // AutoLogOn
            // 
            this.AutoLogOn.AutoSize = true;
            this.AutoLogOn.Location = new System.Drawing.Point(50, 49);
            this.AutoLogOn.Name = "AutoLogOn";
            this.AutoLogOn.Size = new System.Drawing.Size(152, 18);
            this.AutoLogOn.TabIndex = 24;
            this.AutoLogOn.Text = "是否可以自动登录。";
            this.AutoLogOn.UseVisualStyleBackColor = true;
            // 
            // RememberPassword
            // 
            this.RememberPassword.AutoSize = true;
            this.RememberPassword.Location = new System.Drawing.Point(50, 78);
            this.RememberPassword.Name = "RememberPassword";
            this.RememberPassword.Size = new System.Drawing.Size(152, 18);
            this.RememberPassword.TabIndex = 23;
            this.RememberPassword.Text = "是否记住登录密码。";
            this.RememberPassword.UseVisualStyleBackColor = true;
            // 
            // EncryptClientPassword
            // 
            this.EncryptClientPassword.Location = new System.Drawing.Point(50, 22);
            this.EncryptClientPassword.Name = "EncryptClientPassword";
            this.EncryptClientPassword.Size = new System.Drawing.Size(194, 18);
            this.EncryptClientPassword.TabIndex = 22;
            this.EncryptClientPassword.Text = "客户端加密存储登录密码。";
            this.EncryptClientPassword.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(22, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "3.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(22, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "2.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(22, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "1.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTipClientConfig);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 41);
            this.panel1.TabIndex = 1;
            // 
            // lblTipClientConfig
            // 
            this.lblTipClientConfig.AutoSize = true;
            this.lblTipClientConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipClientConfig.Location = new System.Drawing.Point(72, 13);
            this.lblTipClientConfig.Name = "lblTipClientConfig";
            this.lblTipClientConfig.Size = new System.Drawing.Size(269, 12);
            this.lblTipClientConfig.TabIndex = 32;
            this.lblTipClientConfig.Text = "客户端配置项主要是集中配置客户端的相关信息。";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(22, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "小Tip：";
            // 
            // tabItemClientConfig
            // 
            this.tabItemClientConfig.AttachedControl = this.tabPnlClient;
            this.tabItemClientConfig.Name = "tabItemClientConfig";
            this.tabItemClientConfig.Text = "客户端配置";
            // 
            // tabPnlReport
            // 
            this.tabPnlReport.Controls.Add(this.groupBox5);
            this.tabPnlReport.Controls.Add(this.panel5);
            this.tabPnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPnlReport.Location = new System.Drawing.Point(0, 27);
            this.tabPnlReport.Name = "tabPnlReport";
            this.tabPnlReport.Padding = new System.Windows.Forms.Padding(5);
            this.tabPnlReport.Size = new System.Drawing.Size(568, 418);
            this.tabPnlReport.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabPnlReport.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabPnlReport.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabPnlReport.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabPnlReport.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabPnlReport.Style.GradientAngle = 90;
            this.tabPnlReport.TabIndex = 5;
            this.tabPnlReport.TabItem = this.tabItemReportConfig;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.ErrorReportMailServer);
            this.groupBox5.Controls.Add(this.lblErrorReportMailServer);
            this.groupBox5.Controls.Add(this.ErrorReportMailPassword);
            this.groupBox5.Controls.Add(this.lblErrorReportMailPassword);
            this.groupBox5.Controls.Add(this.ErrorReportMailUserName);
            this.groupBox5.Controls.Add(this.lblErrorReportMailUserName);
            this.groupBox5.Controls.Add(this.ErrorReportFrom);
            this.groupBox5.Controls.Add(this.lblErrorReportFrom);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(5, 46);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(558, 367);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // ErrorReportMailServer
            // 
            // 
            // 
            // 
            this.ErrorReportMailServer.Border.Class = "TextBoxBorder";
            this.ErrorReportMailServer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ErrorReportMailServer.FocusHighlightEnabled = true;
            this.ErrorReportMailServer.Location = new System.Drawing.Point(200, 126);
            this.ErrorReportMailServer.Name = "ErrorReportMailServer";
            this.ErrorReportMailServer.SelectedValue = null;
            this.ErrorReportMailServer.Size = new System.Drawing.Size(306, 23);
            this.ErrorReportMailServer.TabIndex = 56;
            // 
            // lblErrorReportMailServer
            // 
            this.lblErrorReportMailServer.AutoSize = true;
            this.lblErrorReportMailServer.Location = new System.Drawing.Point(37, 130);
            this.lblErrorReportMailServer.Name = "lblErrorReportMailServer";
            this.lblErrorReportMailServer.Size = new System.Drawing.Size(161, 14);
            this.lblErrorReportMailServer.TabIndex = 55;
            this.lblErrorReportMailServer.Text = "发出错误邮箱的服务器：";
            // 
            // ErrorReportMailPassword
            // 
            // 
            // 
            // 
            this.ErrorReportMailPassword.Border.Class = "TextBoxBorder";
            this.ErrorReportMailPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ErrorReportMailPassword.FocusHighlightEnabled = true;
            this.ErrorReportMailPassword.Location = new System.Drawing.Point(200, 88);
            this.ErrorReportMailPassword.Name = "ErrorReportMailPassword";
            this.ErrorReportMailPassword.PasswordChar = '*';
            this.ErrorReportMailPassword.SelectedValue = null;
            this.ErrorReportMailPassword.Size = new System.Drawing.Size(306, 23);
            this.ErrorReportMailPassword.TabIndex = 54;
            // 
            // lblErrorReportMailPassword
            // 
            this.lblErrorReportMailPassword.AutoSize = true;
            this.lblErrorReportMailPassword.Location = new System.Drawing.Point(51, 92);
            this.lblErrorReportMailPassword.Name = "lblErrorReportMailPassword";
            this.lblErrorReportMailPassword.Size = new System.Drawing.Size(147, 14);
            this.lblErrorReportMailPassword.TabIndex = 53;
            this.lblErrorReportMailPassword.Text = "发出错误邮箱的密码：";
            // 
            // ErrorReportMailUserName
            // 
            // 
            // 
            // 
            this.ErrorReportMailUserName.Border.Class = "TextBoxBorder";
            this.ErrorReportMailUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ErrorReportMailUserName.FocusHighlightEnabled = true;
            this.ErrorReportMailUserName.Location = new System.Drawing.Point(200, 53);
            this.ErrorReportMailUserName.Name = "ErrorReportMailUserName";
            this.ErrorReportMailUserName.SelectedValue = null;
            this.ErrorReportMailUserName.Size = new System.Drawing.Size(306, 23);
            this.ErrorReportMailUserName.TabIndex = 52;
            // 
            // lblErrorReportMailUserName
            // 
            this.lblErrorReportMailUserName.AutoSize = true;
            this.lblErrorReportMailUserName.Location = new System.Drawing.Point(51, 57);
            this.lblErrorReportMailUserName.Name = "lblErrorReportMailUserName";
            this.lblErrorReportMailUserName.Size = new System.Drawing.Size(147, 14);
            this.lblErrorReportMailUserName.TabIndex = 51;
            this.lblErrorReportMailUserName.Text = "发出错误邮箱的地址：";
            // 
            // ErrorReportFrom
            // 
            // 
            // 
            // 
            this.ErrorReportFrom.Border.Class = "TextBoxBorder";
            this.ErrorReportFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ErrorReportFrom.FocusHighlightEnabled = true;
            this.ErrorReportFrom.Location = new System.Drawing.Point(200, 19);
            this.ErrorReportFrom.Name = "ErrorReportFrom";
            this.ErrorReportFrom.SelectedValue = null;
            this.ErrorReportFrom.Size = new System.Drawing.Size(306, 23);
            this.ErrorReportFrom.TabIndex = 50;
            // 
            // lblErrorReportFrom
            // 
            this.lblErrorReportFrom.AutoSize = true;
            this.lblErrorReportFrom.Location = new System.Drawing.Point(23, 24);
            this.lblErrorReportFrom.Name = "lblErrorReportFrom";
            this.lblErrorReportFrom.Size = new System.Drawing.Size(175, 14);
            this.lblErrorReportFrom.TabIndex = 49;
            this.lblErrorReportFrom.Text = "反馈错误报告的邮箱地址：";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.lblTipReportConfig);
            this.panel5.Controls.Add(this.label41);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(558, 41);
            this.panel5.TabIndex = 3;
            // 
            // lblTipReportConfig
            // 
            this.lblTipReportConfig.AutoSize = true;
            this.lblTipReportConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipReportConfig.Location = new System.Drawing.Point(69, 15);
            this.lblTipReportConfig.Name = "lblTipReportConfig";
            this.lblTipReportConfig.Size = new System.Drawing.Size(317, 12);
            this.lblTipReportConfig.TabIndex = 38;
            this.lblTipReportConfig.Text = "此处主要是对系统的错误信息，反馈信息的发送进行配置。";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.ForeColor = System.Drawing.Color.Blue;
            this.label41.Location = new System.Drawing.Point(19, 15);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(52, 12);
            this.label41.TabIndex = 37;
            this.label41.Text = "小Tip：";
            // 
            // tabItemReportConfig
            // 
            this.tabItemReportConfig.AttachedControl = this.tabPnlReport;
            this.tabItemReportConfig.Name = "tabItemReportConfig";
            this.tabItemReportConfig.Text = "错误报告反馈配置";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Blue;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(1, 78);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(568, 1);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // FrmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(570, 567);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmOption";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Text = "选项";
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPnlServer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordErrorLockCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordMiniLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordChangeCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnLineTime0ut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordErrorLockLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountMinimumLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OnLineLimit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPnlSystemPar.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPnlClient.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPnlReport.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tabControlMain;
        private DevComponents.DotNetBar.TabControlPanel tabPnlClient;
        private DevComponents.DotNetBar.TabItem tabItemClientConfig;
        private DevComponents.DotNetBar.TabControlPanel tabPnlSystemPar;
        private DevComponents.DotNetBar.TabItem tabItemSystemParConfig;
        private DevComponents.DotNetBar.TabControlPanel tabPnlServer;
        private DevComponents.DotNetBar.TabItem tabItemServerConfig;
        private DevComponents.DotNetBar.TabControlPanel tabPnlReport;
        private DevComponents.DotNetBar.TabItem tabItemReportConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox LoadAllUser;
        private System.Windows.Forms.CheckBox AutoLogOn;
        private System.Windows.Forms.CheckBox EncryptClientPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServiceUserName;
        private Controls.UcTextBox ServiceUserName;
        private Controls.UcTextBox ServicePassword;
        private System.Windows.Forms.Label lblServicePassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTipClientConfig;
        private Controls.UcButton btnSave;
        private System.Windows.Forms.CheckBox AllowUserToRegister;
        private System.Windows.Forms.CheckBox NumericCharacters;
        private System.Windows.Forms.CheckBox EnableCheckPasswordStrength;
        private System.Windows.Forms.CheckBox EnableEncryptServerPassword;
        private System.Windows.Forms.CheckBox EnableTableConstraintPermission;
        private System.Windows.Forms.CheckBox EnableTableFieldPermission;
        private System.Windows.Forms.CheckBox EnablePermissionItem;
        private System.Windows.Forms.CheckBox EnableModulePermission;
        private System.Windows.Forms.CheckBox EnableUserAuthorization;
        private System.Windows.Forms.CheckBox EnableUserAuthorizationScope;
        private System.Windows.Forms.CheckBox EnableCheckIPAddress;
        private System.Windows.Forms.CheckBox EnableRecordLog;
        private System.Windows.Forms.CheckBox CheckOnLine;
        private System.Windows.Forms.Label lblOnLineLimit;
        private System.Windows.Forms.Label lblAccountMinimumLength;
        private System.Windows.Forms.Label lblOnLineTime0ut;
        private System.Windows.Forms.Label lblPasswordChangeCycle;
        private System.Windows.Forms.Label lblPasswordMiniLength;
        private Controls.UcTextBox DefaultPassword;
        private System.Windows.Forms.Label lblDefaultPassword;
        private System.Windows.Forms.Label lblPasswordErrorLockCycle;
        private System.Windows.Forms.Label lblPasswordErrorLockLimit;
        private System.Windows.Forms.Label lblTipServerConfig;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRDIFrameworkDbConection;
        private System.Windows.Forms.CheckBox EncryptDbConnection;
        private Controls.UcComboBoxEx RDIFrameworkDbType;
        private System.Windows.Forms.Label lblRDIFrameworkDbType;
        private Controls.UcTextBox RDIFrameworkDbConection;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblTipSystemParConfig;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblMainForm;
        private Controls.UcTextBox LogOnForm;
        private System.Windows.Forms.Label lblLogOnForm;
        private Controls.UcTextBox Version;
        private System.Windows.Forms.Label lblVersion;
        private Controls.UcTextBox SoftFullName;
        private System.Windows.Forms.Label lblSoftFullName;
        private Controls.UcTextBox SoftName;
        private System.Windows.Forms.Label lblSoftName;
        private Controls.UcTextBox ConfigurationFrom;
        private System.Windows.Forms.Label lblConfigurationFrom;
        private Controls.UcTextBox CustomerCompanyName;
        private System.Windows.Forms.Label lblCustomerCompanyName;
        private Controls.UcTextBox LogOnAssembly;
        private System.Windows.Forms.Label lblLogOnAssembly;
        private System.Windows.Forms.Label lblService;
        private Controls.UcTextBox RegisterKey;
        private System.Windows.Forms.Label lblRegisterKey;
        private Controls.UcComboBoxEx Service;
        private Controls.UcTextBox ErrorReportMailServer;
        private System.Windows.Forms.Label lblErrorReportMailServer;
        private Controls.UcTextBox ErrorReportMailPassword;
        private System.Windows.Forms.Label lblErrorReportMailPassword;
        private Controls.UcTextBox ErrorReportMailUserName;
        private System.Windows.Forms.Label lblErrorReportMailUserName;
        private Controls.UcTextBox ErrorReportFrom;
        private System.Windows.Forms.Label lblErrorReportFrom;
        private System.Windows.Forms.Label lblTipReportConfig;
        private System.Windows.Forms.Label label41;
        private DevComponents.Editors.IntegerInput PasswordErrorLockCycle;
        private DevComponents.Editors.IntegerInput PasswordMiniLength;
        private DevComponents.Editors.IntegerInput PasswordChangeCycle;
        private DevComponents.Editors.IntegerInput OnLineTime0ut;
        private DevComponents.Editors.IntegerInput PasswordErrorLockLimit;
        private DevComponents.Editors.IntegerInput AccountMinimumLength;
        private DevComponents.Editors.IntegerInput OnLineLimit;
        private Controls.UcComboBoxEx MainForm;
        private DevComponents.Editors.ComboItem FrmRDIFrameworkNav;
        private DevComponents.Editors.ComboItem FrmRDIFrameworkTree;
        private DevComponents.Editors.ComboItem FrmRDIFrameworkRibbon;
        private System.Windows.Forms.CheckBox RememberPassword;
        private Controls.UcButton btnCancel;
        private System.Windows.Forms.Label label6;
        private Controls.UcComboBoxEx CurrentLanguage;
        private System.Windows.Forms.Label lblCurrentLanguage;
        private DevComponents.Editors.ComboItem zhCN;
        private DevComponents.Editors.ComboItem zhTW;
        private DevComponents.Editors.ComboItem enUS;
        private System.Windows.Forms.CheckBox EnableOrganizePermission;
    }
}