namespace RDIFramework.WinModule
{
    partial class FrmModuleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleEdit));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.txtMvcNavigateUrl = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblMvcNavigateUrl = new System.Windows.Forms.Label();
            this.chkIsMenu = new System.Windows.Forms.CheckBox();
            this.chkAllowDelete = new System.Windows.Forms.CheckBox();
            this.chkAllowEdit = new System.Windows.Forms.CheckBox();
            this.rbModuleType3 = new System.Windows.Forms.RadioButton();
            this.rbModuleType2 = new System.Windows.Forms.RadioButton();
            this.rbModuleType1 = new System.Windows.Forms.RadioButton();
            this.lblOptionSet = new System.Windows.Forms.Label();
            this.lblModuleType = new System.Windows.Forms.Label();
            this.txtIconCss = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblIconCss = new System.Windows.Forms.Label();
            this.chkExpand = new System.Windows.Forms.CheckBox();
            this.txtIconUrl = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblIconUrl = new System.Windows.Forms.Label();
            this.txtAssemblyName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblAssemblyName = new System.Windows.Forms.Label();
            this.txtFormName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFormName = new System.Windows.Forms.Label();
            this.btnEmptyModulePic = new RDIFramework.Controls.UcButton();
            this.btnSelectModulePic = new RDIFramework.Controls.UcButton();
            this.pictureModulePic = new System.Windows.Forms.PictureBox();
            this.lblModuleIcon = new System.Windows.Forms.Label();
            this.btnSetEmpty = new RDIFramework.Controls.UcButton();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.btnSelect = new RDIFramework.Controls.UcButton();
            this.txtNavigateUrl = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtTarget = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblNavigateUrl = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCode = new System.Windows.Forms.Label();
            this.txtParentId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblParentId = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.balloonTip = new DevComponents.DotNetBar.BalloonTip();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAccessPermission = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureModulePic)).BeginInit();
            this.tlsUserAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.txtMvcNavigateUrl);
            this.gbMain.Controls.Add(this.lblMvcNavigateUrl);
            this.gbMain.Controls.Add(this.chkIsMenu);
            this.gbMain.Controls.Add(this.chkAllowDelete);
            this.gbMain.Controls.Add(this.chkAllowEdit);
            this.gbMain.Controls.Add(this.rbModuleType3);
            this.gbMain.Controls.Add(this.rbModuleType2);
            this.gbMain.Controls.Add(this.rbModuleType1);
            this.gbMain.Controls.Add(this.lblOptionSet);
            this.gbMain.Controls.Add(this.lblModuleType);
            this.gbMain.Controls.Add(this.txtIconCss);
            this.gbMain.Controls.Add(this.lblIconCss);
            this.gbMain.Controls.Add(this.chkExpand);
            this.gbMain.Controls.Add(this.txtIconUrl);
            this.gbMain.Controls.Add(this.lblIconUrl);
            this.gbMain.Controls.Add(this.txtAssemblyName);
            this.gbMain.Controls.Add(this.lblAssemblyName);
            this.gbMain.Controls.Add(this.txtFormName);
            this.gbMain.Controls.Add(this.lblFormName);
            this.gbMain.Controls.Add(this.btnEmptyModulePic);
            this.gbMain.Controls.Add(this.btnSelectModulePic);
            this.gbMain.Controls.Add(this.pictureModulePic);
            this.gbMain.Controls.Add(this.lblModuleIcon);
            this.gbMain.Controls.Add(this.btnSetEmpty);
            this.gbMain.Controls.Add(this.txtDescription);
            this.gbMain.Controls.Add(this.lblDescription);
            this.gbMain.Controls.Add(this.chkIsPublic);
            this.gbMain.Controls.Add(this.chkEnabled);
            this.gbMain.Controls.Add(this.lblUserNameReq);
            this.gbMain.Controls.Add(this.btnSelect);
            this.gbMain.Controls.Add(this.txtNavigateUrl);
            this.gbMain.Controls.Add(this.txtTarget);
            this.gbMain.Controls.Add(this.lblNavigateUrl);
            this.gbMain.Controls.Add(this.lblTarget);
            this.gbMain.Controls.Add(this.txtCode);
            this.gbMain.Controls.Add(this.txtFullName);
            this.gbMain.Controls.Add(this.lblCode);
            this.gbMain.Controls.Add(this.txtParentId);
            this.gbMain.Controls.Add(this.lblParentId);
            this.gbMain.Controls.Add(this.lblFullName);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(523, 550);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            // 
            // txtMvcNavigateUrl
            // 
            this.txtMvcNavigateUrl.AccessibleName = "EmptyValue";
            this.txtMvcNavigateUrl.BackColor = System.Drawing.Color.Peru;
            this.balloonTip.SetBalloonCaption(this.txtMvcNavigateUrl, "录入提示");
            this.balloonTip.SetBalloonText(this.txtMvcNavigateUrl, "主要针对WebForm（相对地址）");
            // 
            // 
            // 
            this.txtMvcNavigateUrl.Border.Class = "TextBoxBorder";
            this.txtMvcNavigateUrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMvcNavigateUrl.FocusHighlightEnabled = true;
            this.txtMvcNavigateUrl.Location = new System.Drawing.Point(116, 201);
            this.txtMvcNavigateUrl.MaxLength = 200;
            this.txtMvcNavigateUrl.Name = "txtMvcNavigateUrl";
            this.txtMvcNavigateUrl.SelectedValue = null;
            this.txtMvcNavigateUrl.Size = new System.Drawing.Size(368, 23);
            this.txtMvcNavigateUrl.TabIndex = 6;
            this.txtMvcNavigateUrl.Tag = "Mvc地址";
            // 
            // lblMvcNavigateUrl
            // 
            this.lblMvcNavigateUrl.AutoEllipsis = true;
            this.lblMvcNavigateUrl.BackColor = System.Drawing.Color.Transparent;
            this.lblMvcNavigateUrl.Location = new System.Drawing.Point(10, 205);
            this.lblMvcNavigateUrl.Name = "lblMvcNavigateUrl";
            this.lblMvcNavigateUrl.Size = new System.Drawing.Size(106, 14);
            this.lblMvcNavigateUrl.TabIndex = 77;
            this.lblMvcNavigateUrl.Text = "MVC地址：";
            this.lblMvcNavigateUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsMenu
            // 
            this.chkIsMenu.AccessibleName = "EmptyValue";
            this.chkIsMenu.Location = new System.Drawing.Point(334, 373);
            this.chkIsMenu.Name = "chkIsMenu";
            this.chkIsMenu.Size = new System.Drawing.Size(106, 18);
            this.chkIsMenu.TabIndex = 18;
            this.chkIsMenu.Tag = "菜单";
            this.chkIsMenu.Text = "菜单";
            this.chkIsMenu.UseVisualStyleBackColor = true;
            // 
            // chkAllowDelete
            // 
            this.chkAllowDelete.AccessibleName = "EmptyValue";
            this.chkAllowDelete.Checked = true;
            this.chkAllowDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowDelete.Location = new System.Drawing.Point(229, 373);
            this.chkAllowDelete.Name = "chkAllowDelete";
            this.chkAllowDelete.Size = new System.Drawing.Size(96, 18);
            this.chkAllowDelete.TabIndex = 17;
            this.chkAllowDelete.Tag = "允许删除";
            this.chkAllowDelete.Text = "允许删除";
            this.chkAllowDelete.UseVisualStyleBackColor = true;
            // 
            // chkAllowEdit
            // 
            this.chkAllowEdit.AccessibleName = "EmptyValue";
            this.chkAllowEdit.Checked = true;
            this.chkAllowEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowEdit.Location = new System.Drawing.Point(125, 373);
            this.chkAllowEdit.Name = "chkAllowEdit";
            this.chkAllowEdit.Size = new System.Drawing.Size(93, 18);
            this.chkAllowEdit.TabIndex = 16;
            this.chkAllowEdit.Tag = "允许编辑";
            this.chkAllowEdit.Text = "允许编辑";
            this.chkAllowEdit.UseVisualStyleBackColor = true;
            // 
            // rbModuleType3
            // 
            this.rbModuleType3.AutoSize = true;
            this.rbModuleType3.Checked = true;
            this.rbModuleType3.Location = new System.Drawing.Point(125, 322);
            this.rbModuleType3.Name = "rbModuleType3";
            this.rbModuleType3.Size = new System.Drawing.Size(130, 18);
            this.rbModuleType3.TabIndex = 10;
            this.rbModuleType3.TabStop = true;
            this.rbModuleType3.Text = "WinForm/WebForm";
            this.rbModuleType3.UseVisualStyleBackColor = true;
            // 
            // rbModuleType2
            // 
            this.rbModuleType2.AutoSize = true;
            this.rbModuleType2.Location = new System.Drawing.Point(341, 322);
            this.rbModuleType2.Name = "rbModuleType2";
            this.rbModuleType2.Size = new System.Drawing.Size(74, 18);
            this.rbModuleType2.TabIndex = 12;
            this.rbModuleType2.TabStop = true;
            this.rbModuleType2.Text = "WebForm";
            this.rbModuleType2.UseVisualStyleBackColor = true;
            // 
            // rbModuleType1
            // 
            this.rbModuleType1.AutoSize = true;
            this.rbModuleType1.Location = new System.Drawing.Point(261, 322);
            this.rbModuleType1.Name = "rbModuleType1";
            this.rbModuleType1.Size = new System.Drawing.Size(74, 18);
            this.rbModuleType1.TabIndex = 11;
            this.rbModuleType1.Text = "WinForm";
            this.rbModuleType1.UseVisualStyleBackColor = true;
            // 
            // lblOptionSet
            // 
            this.lblOptionSet.AutoEllipsis = true;
            this.lblOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.lblOptionSet.Location = new System.Drawing.Point(11, 350);
            this.lblOptionSet.Name = "lblOptionSet";
            this.lblOptionSet.Size = new System.Drawing.Size(106, 14);
            this.lblOptionSet.TabIndex = 75;
            this.lblOptionSet.Text = "选项设置：";
            this.lblOptionSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblModuleType
            // 
            this.lblModuleType.AutoEllipsis = true;
            this.lblModuleType.BackColor = System.Drawing.Color.Transparent;
            this.lblModuleType.Location = new System.Drawing.Point(11, 322);
            this.lblModuleType.Name = "lblModuleType";
            this.lblModuleType.Size = new System.Drawing.Size(106, 14);
            this.lblModuleType.TabIndex = 74;
            this.lblModuleType.Text = "模块类型：";
            this.lblModuleType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIconCss
            // 
            this.txtIconCss.AccessibleName = "EmptyValue";
            this.txtIconCss.BackColor = System.Drawing.Color.YellowGreen;
            this.balloonTip.SetBalloonCaption(this.txtIconCss, "录入提示");
            this.balloonTip.SetBalloonText(this.txtIconCss, "主要针对WebForm");
            // 
            // 
            // 
            this.txtIconCss.Border.Class = "TextBoxBorder";
            this.txtIconCss.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIconCss.FocusHighlightEnabled = true;
            this.txtIconCss.Location = new System.Drawing.Point(117, 287);
            this.txtIconCss.MaxLength = 45;
            this.txtIconCss.Name = "txtIconCss";
            this.txtIconCss.SelectedValue = null;
            this.txtIconCss.Size = new System.Drawing.Size(367, 23);
            this.txtIconCss.TabIndex = 9;
            this.txtIconCss.Tag = "目标";
            // 
            // lblIconCss
            // 
            this.lblIconCss.AutoEllipsis = true;
            this.lblIconCss.BackColor = System.Drawing.Color.Transparent;
            this.lblIconCss.Location = new System.Drawing.Point(11, 289);
            this.lblIconCss.Name = "lblIconCss";
            this.lblIconCss.Size = new System.Drawing.Size(106, 14);
            this.lblIconCss.TabIndex = 73;
            this.lblIconCss.Text = "图标样式：";
            this.lblIconCss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkExpand
            // 
            this.chkExpand.AccessibleName = "EmptyValue";
            this.chkExpand.Location = new System.Drawing.Point(334, 351);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Size = new System.Drawing.Size(106, 18);
            this.chkExpand.TabIndex = 15;
            this.chkExpand.Tag = "展开";
            this.chkExpand.Text = "展开";
            this.chkExpand.UseVisualStyleBackColor = true;
            // 
            // txtIconUrl
            // 
            this.txtIconUrl.AccessibleName = "EmptyValue";
            this.txtIconUrl.BackColor = System.Drawing.Color.YellowGreen;
            this.balloonTip.SetBalloonCaption(this.txtIconUrl, "录入提示");
            this.balloonTip.SetBalloonText(this.txtIconUrl, "主要针对WebForm");
            // 
            // 
            // 
            this.txtIconUrl.Border.Class = "TextBoxBorder";
            this.txtIconUrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIconUrl.FocusHighlightEnabled = true;
            this.txtIconUrl.Location = new System.Drawing.Point(117, 258);
            this.txtIconUrl.MaxLength = 45;
            this.txtIconUrl.Name = "txtIconUrl";
            this.txtIconUrl.SelectedValue = null;
            this.txtIconUrl.Size = new System.Drawing.Size(367, 23);
            this.txtIconUrl.TabIndex = 8;
            this.txtIconUrl.Tag = "目标";
            // 
            // lblIconUrl
            // 
            this.lblIconUrl.AutoEllipsis = true;
            this.lblIconUrl.BackColor = System.Drawing.Color.Transparent;
            this.lblIconUrl.Location = new System.Drawing.Point(11, 260);
            this.lblIconUrl.Name = "lblIconUrl";
            this.lblIconUrl.Size = new System.Drawing.Size(106, 14);
            this.lblIconUrl.TabIndex = 71;
            this.lblIconUrl.Text = "图标地址：";
            this.lblIconUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.AccessibleName = "EmptyValue";
            this.txtAssemblyName.BackColor = System.Drawing.Color.AntiqueWhite;
            this.balloonTip.SetBalloonCaption(this.txtAssemblyName, "录入提示");
            this.balloonTip.SetBalloonText(this.txtAssemblyName, "主要针对WinForm结构（程序集名称，带扩展名）");
            // 
            // 
            // 
            this.txtAssemblyName.Border.Class = "TextBoxBorder";
            this.txtAssemblyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAssemblyName.FocusHighlightEnabled = true;
            this.txtAssemblyName.Location = new System.Drawing.Point(117, 138);
            this.txtAssemblyName.MaxLength = 100;
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.SelectedValue = null;
            this.txtAssemblyName.Size = new System.Drawing.Size(367, 23);
            this.txtAssemblyName.TabIndex = 4;
            this.txtAssemblyName.Tag = "目标";
            // 
            // lblAssemblyName
            // 
            this.lblAssemblyName.AutoEllipsis = true;
            this.lblAssemblyName.BackColor = System.Drawing.Color.Transparent;
            this.lblAssemblyName.Location = new System.Drawing.Point(11, 140);
            this.lblAssemblyName.Name = "lblAssemblyName";
            this.lblAssemblyName.Size = new System.Drawing.Size(106, 14);
            this.lblAssemblyName.TabIndex = 69;
            this.lblAssemblyName.Text = "程序集名称：";
            this.lblAssemblyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFormName
            // 
            this.txtFormName.AccessibleName = "EmptyValue";
            this.txtFormName.BackColor = System.Drawing.Color.AntiqueWhite;
            this.balloonTip.SetBalloonCaption(this.txtFormName, "录入提示");
            this.balloonTip.SetBalloonText(this.txtFormName, "主要针对WinForm结构（窗体的名称，格式为：命名空间+窗体的名称）");
            // 
            // 
            // 
            this.txtFormName.Border.Class = "TextBoxBorder";
            this.txtFormName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFormName.FocusHighlightEnabled = true;
            this.txtFormName.Location = new System.Drawing.Point(117, 109);
            this.txtFormName.MaxLength = 100;
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.SelectedValue = null;
            this.txtFormName.Size = new System.Drawing.Size(367, 23);
            this.txtFormName.TabIndex = 3;
            this.txtFormName.Tag = "目标";
            // 
            // lblFormName
            // 
            this.lblFormName.AutoEllipsis = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Location = new System.Drawing.Point(11, 111);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(106, 14);
            this.lblFormName.TabIndex = 67;
            this.lblFormName.Text = "窗体名：";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEmptyModulePic
            // 
            this.btnEmptyModulePic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEmptyModulePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmptyModulePic.AutoSize = true;
            this.btnEmptyModulePic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnEmptyModulePic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEmptyModulePic.Location = new System.Drawing.Point(271, 492);
            this.btnEmptyModulePic.Name = "btnEmptyModulePic";
            this.btnEmptyModulePic.Padding = new System.Windows.Forms.Padding(1);
            this.btnEmptyModulePic.Size = new System.Drawing.Size(54, 26);
            this.btnEmptyModulePic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEmptyModulePic.TabIndex = 20;
            this.btnEmptyModulePic.Text = "置空";
            this.btnEmptyModulePic.Click += new System.EventHandler(this.btnEmptyModulePic_Click);
            // 
            // btnSelectModulePic
            // 
            this.btnSelectModulePic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectModulePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectModulePic.AutoSize = true;
            this.btnSelectModulePic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSelectModulePic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectModulePic.Location = new System.Drawing.Point(209, 492);
            this.btnSelectModulePic.Name = "btnSelectModulePic";
            this.btnSelectModulePic.Padding = new System.Windows.Forms.Padding(1);
            this.btnSelectModulePic.Size = new System.Drawing.Size(46, 26);
            this.btnSelectModulePic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectModulePic.TabIndex = 19;
            this.btnSelectModulePic.Text = "选择";
            this.btnSelectModulePic.Click += new System.EventHandler(this.btnSelectModulePic_Click);
            // 
            // pictureModulePic
            // 
            this.pictureModulePic.BackColor = System.Drawing.Color.Khaki;
            this.pictureModulePic.Location = new System.Drawing.Point(117, 478);
            this.pictureModulePic.Name = "pictureModulePic";
            this.pictureModulePic.Size = new System.Drawing.Size(76, 53);
            this.pictureModulePic.TabIndex = 63;
            this.pictureModulePic.TabStop = false;
            // 
            // lblModuleIcon
            // 
            this.lblModuleIcon.AutoEllipsis = true;
            this.lblModuleIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblModuleIcon.Location = new System.Drawing.Point(16, 488);
            this.lblModuleIcon.Name = "lblModuleIcon";
            this.lblModuleIcon.Size = new System.Drawing.Size(106, 14);
            this.lblModuleIcon.TabIndex = 62;
            this.lblModuleIcon.Text = "模块图标：";
            this.lblModuleIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetEmpty
            // 
            this.btnSetEmpty.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetEmpty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSetEmpty.AutoSize = true;
            this.btnSetEmpty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSetEmpty.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetEmpty.Location = new System.Drawing.Point(440, 17);
            this.btnSetEmpty.Name = "btnSetEmpty";
            this.btnSetEmpty.Padding = new System.Windows.Forms.Padding(1);
            this.btnSetEmpty.Size = new System.Drawing.Size(54, 26);
            this.btnSetEmpty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetEmpty.TabIndex = 2;
            this.btnSetEmpty.Text = "置空";
            this.btnSetEmpty.Click += new System.EventHandler(this.btnSetEmpty_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(117, 400);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(368, 66);
            this.txtDescription.TabIndex = 19;
            this.txtDescription.Tag = "描述";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(11, 400);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(106, 14);
            this.lblDescription.TabIndex = 60;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AccessibleName = "EmptyValue";
            this.chkIsPublic.Location = new System.Drawing.Point(229, 351);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(96, 18);
            this.chkIsPublic.TabIndex = 14;
            this.chkIsPublic.Tag = "公开";
            this.chkIsPublic.Text = "公开";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AccessibleName = "EmptyValue";
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(125, 351);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(93, 18);
            this.chkEnabled.TabIndex = 13;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(493, 56);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 57;
            this.lblUserNameReq.Text = "*";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelect.AutoSize = true;
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(382, 17);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Padding = new System.Windows.Forms.Padding(1);
            this.btnSelect.Size = new System.Drawing.Size(46, 26);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtNavigateUrl
            // 
            this.txtNavigateUrl.AccessibleName = "EmptyValue";
            this.txtNavigateUrl.BackColor = System.Drawing.Color.YellowGreen;
            this.balloonTip.SetBalloonCaption(this.txtNavigateUrl, "录入提示");
            this.balloonTip.SetBalloonText(this.txtNavigateUrl, "主要针对WebForm（相对地址）");
            // 
            // 
            // 
            this.txtNavigateUrl.Border.Class = "TextBoxBorder";
            this.txtNavigateUrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNavigateUrl.FocusHighlightEnabled = true;
            this.txtNavigateUrl.Location = new System.Drawing.Point(117, 170);
            this.txtNavigateUrl.MaxLength = 200;
            this.txtNavigateUrl.Name = "txtNavigateUrl";
            this.txtNavigateUrl.SelectedValue = null;
            this.txtNavigateUrl.Size = new System.Drawing.Size(368, 23);
            this.txtNavigateUrl.TabIndex = 5;
            this.txtNavigateUrl.Tag = "Web地址";
            // 
            // txtTarget
            // 
            this.txtTarget.AccessibleName = "EmptyValue";
            this.txtTarget.BackColor = System.Drawing.Color.YellowGreen;
            this.balloonTip.SetBalloonCaption(this.txtTarget, "录入提示");
            this.balloonTip.SetBalloonText(this.txtTarget, "主要针对WebForm");
            // 
            // 
            // 
            this.txtTarget.Border.Class = "TextBoxBorder";
            this.txtTarget.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTarget.FocusHighlightEnabled = true;
            this.txtTarget.Location = new System.Drawing.Point(117, 230);
            this.txtTarget.MaxLength = 45;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.SelectedValue = null;
            this.txtTarget.Size = new System.Drawing.Size(367, 23);
            this.txtTarget.TabIndex = 7;
            this.txtTarget.Tag = "目标";
            // 
            // lblNavigateUrl
            // 
            this.lblNavigateUrl.AutoEllipsis = true;
            this.lblNavigateUrl.BackColor = System.Drawing.Color.Transparent;
            this.lblNavigateUrl.Location = new System.Drawing.Point(11, 174);
            this.lblNavigateUrl.Name = "lblNavigateUrl";
            this.lblNavigateUrl.Size = new System.Drawing.Size(106, 14);
            this.lblNavigateUrl.TabIndex = 56;
            this.lblNavigateUrl.Text = "Web地址：";
            this.lblNavigateUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoEllipsis = true;
            this.lblTarget.BackColor = System.Drawing.Color.Transparent;
            this.lblTarget.Location = new System.Drawing.Point(11, 234);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(106, 14);
            this.lblTarget.TabIndex = 54;
            this.lblTarget.Text = "目标：";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.AccessibleName = "EmptyValue|NotNull";
            this.txtCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.FocusHighlightEnabled = true;
            this.txtCode.Location = new System.Drawing.Point(117, 80);
            this.txtCode.MaxLength = 45;
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedValue = null;
            this.txtCode.Size = new System.Drawing.Size(367, 23);
            this.txtCode.TabIndex = 2;
            this.txtCode.Tag = "编号";
            // 
            // txtFullName
            // 
            this.txtFullName.AccessibleName = "EmptyValue|NotNull";
            this.txtFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(117, 51);
            this.txtFullName.MaxLength = 150;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(367, 23);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Tag = "名称";
            // 
            // lblCode
            // 
            this.lblCode.AutoEllipsis = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Location = new System.Drawing.Point(11, 82);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(106, 14);
            this.lblCode.TabIndex = 45;
            this.lblCode.Text = "编号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentId
            // 
            this.txtParentId.AccessibleName = "";
            this.txtParentId.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtParentId.Border.Class = "TextBoxBorder";
            this.txtParentId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtParentId.FocusHighlightEnabled = true;
            this.txtParentId.Location = new System.Drawing.Point(118, 20);
            this.txtParentId.MaxLength = 15;
            this.txtParentId.Name = "txtParentId";
            this.txtParentId.ReadOnly = true;
            this.txtParentId.SelectedValue = null;
            this.txtParentId.Size = new System.Drawing.Size(256, 23);
            this.txtParentId.TabIndex = 0;
            this.txtParentId.Tag = "父节点";
            // 
            // lblParentId
            // 
            this.lblParentId.AutoEllipsis = true;
            this.lblParentId.BackColor = System.Drawing.Color.Transparent;
            this.lblParentId.Location = new System.Drawing.Point(11, 22);
            this.lblParentId.Name = "lblParentId";
            this.lblParentId.Size = new System.Drawing.Size(106, 14);
            this.lblParentId.TabIndex = 42;
            this.lblParentId.Text = "父模块：";
            this.lblParentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(11, 55);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(106, 14);
            this.lblFullName.TabIndex = 48;
            this.lblFullName.Text = "名称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // balloonTip
            // 
            this.balloonTip.DefaultBalloonWidth = 500;
            // 
            // tlsUserAdd
            // 
            this.tlsUserAdd.AutoSize = false;
            this.tlsUserAdd.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsUserAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSaveContinue,
            this.toolStripSeparator5,
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnAccessPermission,
            this.toolStripSeparator2,
            this.btnClose});
            this.tlsUserAdd.Location = new System.Drawing.Point(0, 0);
            this.tlsUserAdd.Name = "tlsUserAdd";
            this.tlsUserAdd.Size = new System.Drawing.Size(523, 25);
            this.tlsUserAdd.TabIndex = 1;
            this.tlsUserAdd.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.ToolTipText = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveContinue.Image")));
            this.btnSaveContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(57, 22);
            this.btnSaveContinue.Text = "继续";
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 22);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.ToolTipText = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAccessPermission
            // 
            this.btnAccessPermission.Image = ((System.Drawing.Image)(resources.GetObject("btnAccessPermission.Image")));
            this.btnAccessPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccessPermission.Name = "btnAccessPermission";
            this.btnAccessPermission.Size = new System.Drawing.Size(87, 22);
            this.btnAccessPermission.Text = "访问权限";
            this.btnAccessPermission.Visible = false;
            this.btnAccessPermission.Click += new System.EventHandler(this.btnAccessPermission_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&Q)";
            this.btnClose.ToolTipText = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 575);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsUserAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModuleEdit";
            this.Text = "模块新增";
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureModulePic)).EndInit();
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private Controls.UcButton btnSelect;
        private Controls.UcTextBox txtNavigateUrl;
        private Controls.UcTextBox txtTarget;
        private System.Windows.Forms.Label lblNavigateUrl;
        private System.Windows.Forms.Label lblTarget;
        private Controls.UcTextBox txtCode;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtFullName;
        private System.Windows.Forms.Label lblCode;
        private Controls.UcTextBox txtParentId;
        private System.Windows.Forms.Label lblParentId;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcTextBox txtDescription;
        private Controls.UcButton btnSetEmpty;
        private System.Windows.Forms.Label lblModuleIcon;
        private System.Windows.Forms.PictureBox pictureModulePic;
        private Controls.UcButton btnEmptyModulePic;
        private Controls.UcButton btnSelectModulePic;
        private DevComponents.DotNetBar.BalloonTip balloonTip;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveContinue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAccessPermission;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Controls.UcTextBox txtFormName;
        private System.Windows.Forms.Label lblFormName;
        private Controls.UcTextBox txtAssemblyName;
        private System.Windows.Forms.Label lblAssemblyName;
        private Controls.UcTextBox txtIconUrl;
        private System.Windows.Forms.Label lblIconUrl;
        private System.Windows.Forms.CheckBox chkExpand;
        private Controls.UcTextBox txtIconCss;
        private System.Windows.Forms.Label lblIconCss;
        private System.Windows.Forms.Label lblOptionSet;
        private System.Windows.Forms.Label lblModuleType;
        private System.Windows.Forms.RadioButton rbModuleType3;
        private System.Windows.Forms.RadioButton rbModuleType2;
        private System.Windows.Forms.RadioButton rbModuleType1;
        private System.Windows.Forms.CheckBox chkAllowEdit;
        private System.Windows.Forms.CheckBox chkIsMenu;
        private System.Windows.Forms.CheckBox chkAllowDelete;
        private Controls.UcTextBox txtMvcNavigateUrl;
        private System.Windows.Forms.Label lblMvcNavigateUrl;
    }
}