namespace RDIFramework.WinModule
{
    partial class FrmStaffAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStaffAdmin));
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkIsDimission = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOfficePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentTvPath = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.rbCustomerLikeSearch = new System.Windows.Forms.RadioButton();
            this.rbCustomerExactSearch = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchValue = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSearchValue = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkNotDepartment = new System.Windows.Forms.CheckBox();
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoveTo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoEllipsis = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(15, 9);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(109, 18);
            this.chkEnabled.TabIndex = 8;
            this.chkEnabled.Text = "有效的";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkIsDimission_CheckedChanged);
            // 
            // chkIsDimission
            // 
            this.chkIsDimission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsDimission.AutoEllipsis = true;
            this.chkIsDimission.Checked = true;
            this.chkIsDimission.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDimission.Location = new System.Drawing.Point(15, 30);
            this.chkIsDimission.Name = "chkIsDimission";
            this.chkIsDimission.Size = new System.Drawing.Size(123, 18);
            this.chkIsDimission.TabIndex = 7;
            this.chkIsDimission.Text = "未离职的";
            this.chkIsDimission.UseVisualStyleBackColor = true;
            this.chkIsDimission.CheckedChanged += new System.EventHandler(this.chkIsDimission_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 522);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvInfo);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(201, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(756, 497);
            this.pnlMain.TabIndex = 4;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToOrderColumns = true;
            this.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfo.ColumnHeadersHeight = 26;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.UserId,
            this.colSelected,
            this.colCode,
            this.colRealName,
            this.colGender,
            this.colMobile,
            this.colOfficePhone,
            this.colEmail,
            this.colEnabled,
            this.colDescription});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(0, 35);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInfo.RowHeadersWidth = 35;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(756, 462);
            this.dgvInfo.TabIndex = 6;
            this.dgvInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInfo_DataBindingComplete);
            this.dgvInfo.Click += new System.EventHandler(this.dgvInfo_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.Frozen = true;
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = false;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "编号";
            this.colCode.Name = "colCode";
            this.colCode.Width = 80;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.Frozen = true;
            this.colRealName.HeaderText = "姓名";
            this.colRealName.Name = "colRealName";
            this.colRealName.Width = 120;
            // 
            // colGender
            // 
            this.colGender.DataPropertyName = "Gender";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colGender.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGender.Frozen = true;
            this.colGender.HeaderText = "性别";
            this.colGender.Name = "colGender";
            this.colGender.Width = 50;
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Mobile";
            this.colMobile.Frozen = true;
            this.colMobile.HeaderText = "手机号码";
            this.colMobile.Name = "colMobile";
            this.colMobile.Width = 120;
            // 
            // colOfficePhone
            // 
            this.colOfficePhone.DataPropertyName = "OfficePhone";
            this.colOfficePhone.Frozen = true;
            this.colOfficePhone.HeaderText = "办公电话";
            this.colOfficePhone.Name = "colOfficePhone";
            this.colOfficePhone.Width = 120;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "邮箱";
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 130;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 250;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblCurrentTvPath);
            this.panel1.Controls.Add(this.lblCurrentPosition);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(756, 35);
            this.panel1.TabIndex = 7;
            // 
            // lblCurrentTvPath
            // 
            this.lblCurrentTvPath.AutoSize = true;
            this.lblCurrentTvPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentTvPath.Font = new System.Drawing.Font("新宋体", 11F);
            this.lblCurrentTvPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentTvPath.Location = new System.Drawing.Point(121, 10);
            this.lblCurrentTvPath.Name = "lblCurrentTvPath";
            this.lblCurrentTvPath.Size = new System.Drawing.Size(31, 15);
            this.lblCurrentTvPath.TabIndex = 1;
            this.lblCurrentTvPath.Text = "   ";
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.AutoEllipsis = true;
            this.lblCurrentPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentPosition.Font = new System.Drawing.Font("新宋体", 11F);
            this.lblCurrentPosition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentPosition.Image = global::RDIFramework.WinModule.Properties.Resources.CurrentPosition;
            this.lblCurrentPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentPosition.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(111, 15);
            this.lblCurrentPosition.TabIndex = 0;
            this.lblCurrentPosition.Text = "   当前位置：";
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlStaffAdmin
            // 
            this.tabControlStaffAdmin.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlStaffAdmin.CanReorderTabs = true;
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel4);
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel3);
            this.tabControlStaffAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlStaffAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlStaffAdmin.Name = "tabControlStaffAdmin";
            this.tabControlStaffAdmin.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlStaffAdmin.SelectedTabIndex = 0;
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(198, 522);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 5;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemOrganize);
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemSearch);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvOrganize);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(198, 495);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItemOrganize;
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.HotTracking = true;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imgList;
            this.tvOrganize.Location = new System.Drawing.Point(1, 1);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(196, 493);
            this.tvOrganize.TabIndex = 2;
            this.tvOrganize.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterExpand);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "company.ico");
            this.imgList.Images.SetKeyName(1, "ok.png");
            // 
            // tabItemOrganize
            // 
            this.tabItemOrganize.AttachedControl = this.tabControlPanel4;
            this.tabItemOrganize.Name = "tabItemOrganize";
            this.tabItemOrganize.Text = "组织机构";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 495);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItemSearch;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel3);
            this.gbCustomSearch.Controls.Add(this.panel2);
            this.gbCustomSearch.Controls.Add(this.panel4);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 485);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "员工常规搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.rbCustomerLikeSearch);
            this.panel3.Controls.Add(this.rbCustomerExactSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 96);
            this.panel3.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Image = global::RDIFramework.WinModule.Properties.Resources.Find;
            this.btnSearch.Location = new System.Drawing.Point(9, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbCustomerLikeSearch
            // 
            this.rbCustomerLikeSearch.AutoSize = true;
            this.rbCustomerLikeSearch.Checked = true;
            this.rbCustomerLikeSearch.Location = new System.Drawing.Point(13, 36);
            this.rbCustomerLikeSearch.Name = "rbCustomerLikeSearch";
            this.rbCustomerLikeSearch.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerLikeSearch.TabIndex = 12;
            this.rbCustomerLikeSearch.TabStop = true;
            this.rbCustomerLikeSearch.Text = "模糊";
            this.rbCustomerLikeSearch.UseVisualStyleBackColor = true;
            // 
            // rbCustomerExactSearch
            // 
            this.rbCustomerExactSearch.AutoSize = true;
            this.rbCustomerExactSearch.Location = new System.Drawing.Point(13, 12);
            this.rbCustomerExactSearch.Name = "rbCustomerExactSearch";
            this.rbCustomerExactSearch.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerExactSearch.TabIndex = 11;
            this.rbCustomerExactSearch.Text = "精确";
            this.rbCustomerExactSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearchValue);
            this.panel2.Controls.Add(this.lblSearchValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 56);
            this.panel2.TabIndex = 3;
            // 
            // txtSearchValue
            // 
            // 
            // 
            // 
            this.txtSearchValue.Border.Class = "TextBoxBorder";
            this.txtSearchValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchValue.FocusHighlightEnabled = true;
            this.txtSearchValue.Location = new System.Drawing.Point(9, 22);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.SelectedValue = null;
            this.txtSearchValue.Size = new System.Drawing.Size(160, 23);
            this.txtSearchValue.TabIndex = 3;
            // 
            // lblSearchValue
            // 
            this.lblSearchValue.AutoSize = true;
            this.lblSearchValue.Location = new System.Drawing.Point(9, 5);
            this.lblSearchValue.Name = "lblSearchValue";
            this.lblSearchValue.Size = new System.Drawing.Size(77, 14);
            this.lblSearchValue.TabIndex = 2;
            this.lblSearchValue.Text = "搜索内容：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkNotDepartment);
            this.panel4.Controls.Add(this.chkEnabled);
            this.panel4.Controls.Add(this.chkIsDimission);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 76);
            this.panel4.TabIndex = 9;
            // 
            // chkNotDepartment
            // 
            this.chkNotDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNotDepartment.AutoEllipsis = true;
            this.chkNotDepartment.Location = new System.Drawing.Point(15, 52);
            this.chkNotDepartment.Name = "chkNotDepartment";
            this.chkNotDepartment.Size = new System.Drawing.Size(166, 18);
            this.chkNotDepartment.TabIndex = 9;
            this.chkNotDepartment.Text = "未设置组织机构的员工";
            this.chkNotDepartment.UseVisualStyleBackColor = true;
            this.chkNotDepartment.CheckedChanged += new System.EventHandler(this.chkNotDepartment_CheckedChanged);
            // 
            // tabItemSearch
            // 
            this.tabItemSearch.AttachedControl = this.tabControlPanel3;
            this.tabItemSearch.Name = "tabItemSearch";
            this.tabItemSearch.Text = "搜索";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 11F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator6,
            this.btnMoveTo,
            this.toolStripSeparator1,
            this.btnExport,
            this.btnPrint,
            this.toolStripSeparator5,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(201, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(756, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::RDIFramework.WinModule.Properties.Resources.addCustomer;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 22);
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::RDIFramework.WinModule.Properties.Resources.editCustomer;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 22);
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::RDIFramework.WinModule.Properties.Resources.deleteCustomer;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnMoveTo
            // 
            this.btnMoveTo.Image = global::RDIFramework.WinModule.Properties.Resources.TaskItemIcon;
            this.btnMoveTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveTo.Name = "btnMoveTo";
            this.btnMoveTo.Size = new System.Drawing.Size(81, 22);
            this.btnMoveTo.Text = "移动(&M)";
            this.btnMoveTo.ToolTipText = "移动";
            this.btnMoveTo.Click += new System.EventHandler(this.btnMoveTo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::RDIFramework.WinModule.Properties.Resources.export1;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(57, 22);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::RDIFramework.WinModule.Properties.Resources.print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 22);
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmStaffAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 522);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.Name = "FrmStaffAdmin";
            this.Text = "员工管理";
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlMain;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentTvPath;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOfficePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.CheckBox chkIsDimission;
        private System.Windows.Forms.CheckBox chkEnabled;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItemOrganize;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel3;
        private Controls.UcButton btnSearch;
        private System.Windows.Forms.RadioButton rbCustomerLikeSearch;
        private System.Windows.Forms.RadioButton rbCustomerExactSearch;
        private System.Windows.Forms.Panel panel2;
        private Controls.UcTextBox txtSearchValue;
        private System.Windows.Forms.Label lblSearchValue;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnMoveTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.CheckBox chkNotDepartment;
        private System.Windows.Forms.ImageList imgList;
    }
}