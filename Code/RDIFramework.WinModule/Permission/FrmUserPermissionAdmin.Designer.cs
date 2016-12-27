/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:54:59
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserPermissionAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermissionAdmin));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCurrentTvPath = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.splUser = new System.Windows.Forms.Splitter();
            this.tabMain = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.btnPermission = new System.Windows.Forms.ToolStripButton();
            this.btnUserRole = new System.Windows.Forms.ToolStripButton();
            this.btnRoleUserBatchSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBatchPermission = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.lblSerach = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDropDownPermission = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnUserPermissionScope = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTableFieldPermission = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserTableConstraintSet = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvInfo);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.splUser);
            this.splitContainer1.Panel1.Controls.Add(this.tabMain);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(911, 545);
            this.splitContainer1.SplitterDistance = 490;
            this.splitContainer1.TabIndex = 7;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToOrderColumns = true;
            this.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInfo.ColumnHeadersHeight = 26;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colId,
            this.colCode,
            this.colUserName,
            this.colRealName,
            this.colDepartmentName,
            this.colRoleName,
            this.colEnabled,
            this.colEmail,
            this.colMobile,
            this.colDescription});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(249, 35);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInfo.RowHeadersWidth = 30;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(662, 479);
            this.dgvInfo.TabIndex = 7;
            this.dgvInfo.SelectionChanged += new System.EventHandler(this.dgvInfo_SelectionChanged);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 48;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.Frozen = true;
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "编号";
            this.colCode.Name = "colCode";
            // 
            // colUserName
            // 
            this.colUserName.DataPropertyName = "UserName";
            this.colUserName.Frozen = true;
            this.colUserName.HeaderText = "登录名";
            this.colUserName.Name = "colUserName";
            this.colUserName.Width = 150;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.Frozen = true;
            this.colRealName.HeaderText = "用户名";
            this.colRealName.Name = "colRealName";
            this.colRealName.Width = 150;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.DataPropertyName = "DepartmentName";
            this.colDepartmentName.HeaderText = "部门";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Width = 150;
            // 
            // colRoleName
            // 
            this.colRoleName.DataPropertyName = "RoleName";
            this.colRoleName.HeaderText = "默认角色";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.Width = 150;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 48;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "邮箱";
            this.colEmail.Name = "colEmail";
            this.colEmail.Width = 200;
            // 
            // colMobile
            // 
            this.colMobile.DataPropertyName = "Mobile";
            this.colMobile.HeaderText = "手机号码";
            this.colMobile.Name = "colMobile";
            this.colMobile.Width = 150;
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
            this.panel1.Controls.Add(this.ucPager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(249, 514);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(662, 31);
            this.panel1.TabIndex = 13;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(149, 5);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(507, 20);
            this.ucPager.TabIndex = 1;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Info;
            this.panel6.Controls.Add(this.lblCurrentTvPath);
            this.panel6.Controls.Add(this.lblCurrentPosition);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(249, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10);
            this.panel6.Size = new System.Drawing.Size(662, 35);
            this.panel6.TabIndex = 12;
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
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splUser
            // 
            this.splUser.Location = new System.Drawing.Point(246, 0);
            this.splUser.Name = "splUser";
            this.splUser.Size = new System.Drawing.Size(3, 545);
            this.splUser.TabIndex = 11;
            this.splUser.TabStop = false;
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.SystemColors.Window;
            this.tabMain.CanReorderTabs = true;
            this.tabMain.Controls.Add(this.tabControlPanel4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabMain.SelectedTabIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(246, 545);
            this.tabMain.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabMain.TabIndex = 10;
            this.tabMain.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabMain.Tabs.Add(this.tabItemOrganize);
            this.tabMain.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvOrganize);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(246, 518);
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
            this.tvOrganize.SelectedImageIndex = 6;
            this.tvOrganize.Size = new System.Drawing.Size(244, 516);
            this.tvOrganize.TabIndex = 2;
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "company.ico");
            this.imgList.Images.SetKeyName(1, "subcompany.ico");
            this.imgList.Images.SetKeyName(2, "department.ico");
            this.imgList.Images.SetKeyName(3, "subdepartment.ico");
            this.imgList.Images.SetKeyName(4, "workgroup.ico");
            this.imgList.Images.SetKeyName(5, "noOrganize.ico");
            this.imgList.Images.SetKeyName(6, "selected.ico");
            // 
            // tabItemOrganize
            // 
            this.tabItemOrganize.AttachedControl = this.tabControlPanel4;
            this.tabItemOrganize.Name = "tabItemOrganize";
            this.tabItemOrganize.Text = "组织机构";
            // 
            // btnPermission
            // 
            this.btnPermission.Image = global::RDIFramework.WinModule.Properties.Resources.userPermission;
            this.btnPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(111, 22);
            this.btnPermission.Text = "用户权限(&P)";
            this.btnPermission.ToolTipText = "角色权限";
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // btnUserRole
            // 
            this.btnUserRole.Image = global::RDIFramework.WinModule.Properties.Resources.Role;
            this.btnUserRole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserRole.Name = "btnUserRole";
            this.btnUserRole.Size = new System.Drawing.Size(87, 22);
            this.btnUserRole.Text = "用户角色";
            this.btnUserRole.Click += new System.EventHandler(this.btnUserRole_Click);
            // 
            // btnRoleUserBatchSet
            // 
            this.btnRoleUserBatchSet.Image = ((System.Drawing.Image)(resources.GetObject("btnRoleUserBatchSet.Image")));
            this.btnRoleUserBatchSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoleUserBatchSet.Name = "btnRoleUserBatchSet";
            this.btnRoleUserBatchSet.Size = new System.Drawing.Size(117, 22);
            this.btnRoleUserBatchSet.Text = "用户角色关联";
            this.btnRoleUserBatchSet.ToolTipText = "移动";
            this.btnRoleUserBatchSet.Click += new System.EventHandler(this.btnRoleUserBatchSet_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBatchPermission
            // 
            this.btnBatchPermission.Image = global::RDIFramework.WinModule.Properties.Resources.mnuShowRecordDetail_Image;
            this.btnBatchPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBatchPermission.Name = "btnBatchPermission";
            this.btnBatchPermission.Size = new System.Drawing.Size(117, 22);
            this.btnBatchPermission.Text = "权限批量设置";
            this.btnBatchPermission.Click += new System.EventHandler(this.btnBatchPermission_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // tsTool
            // 
            this.tsTool.AutoSize = false;
            this.tsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSerach,
            this.txtSearch,
            this.toolStripSeparator2,
            this.btnPermission,
            this.btnUserRole,
            this.btnRoleUserBatchSet,
            this.toolStripSeparator6,
            this.btnBatchPermission,
            this.btnDropDownPermission,
            this.toolStripSeparator1,
            this.btnClose});
            this.tsTool.Location = new System.Drawing.Point(0, 0);
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(911, 25);
            this.tsTool.TabIndex = 15;
            this.tsTool.Text = "toolStrip1";
            // 
            // lblSerach
            // 
            this.lblSerach.Name = "lblSerach";
            this.lblSerach.Size = new System.Drawing.Size(82, 22);
            this.lblSerach.Text = "搜索内容：";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDropDownPermission
            // 
            this.btnDropDownPermission.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserPermissionScope,
            this.btnTableFieldPermission,
            this.btnUserTableConstraintSet});
            this.btnDropDownPermission.Image = global::RDIFramework.WinModule.Properties.Resources.permission;
            this.btnDropDownPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDropDownPermission.Name = "btnDropDownPermission";
            this.btnDropDownPermission.Size = new System.Drawing.Size(96, 22);
            this.btnDropDownPermission.Text = "权限设置";
            // 
            // btnUserPermissionScope
            // 
            this.btnUserPermissionScope.Image = global::RDIFramework.WinModule.Properties.Resources.OrganizeList;
            this.btnUserPermissionScope.Name = "btnUserPermissionScope";
            this.btnUserPermissionScope.Size = new System.Drawing.Size(194, 22);
            this.btnUserPermissionScope.Text = "用户授权范围";
            this.btnUserPermissionScope.Click += new System.EventHandler(this.btnUserPermissionScope_Click);
            // 
            // btnTableFieldPermission
            // 
            this.btnTableFieldPermission.Image = global::RDIFramework.WinModule.Properties.Resources.fieldPermission;
            this.btnTableFieldPermission.Name = "btnTableFieldPermission";
            this.btnTableFieldPermission.Size = new System.Drawing.Size(194, 22);
            this.btnTableFieldPermission.Text = "表字段权限设置";
            this.btnTableFieldPermission.Click += new System.EventHandler(this.btnTableFieldPermission_Click);
            // 
            // btnUserTableConstraintSet
            // 
            this.btnUserTableConstraintSet.Image = global::RDIFramework.WinModule.Properties.Resources.tableConstraint;
            this.btnUserTableConstraintSet.Name = "btnUserTableConstraintSet";
            this.btnUserTableConstraintSet.Size = new System.Drawing.Size(194, 22);
            this.btnUserTableConstraintSet.Text = "约束条件权限设置";
            this.btnUserTableConstraintSet.Click += new System.EventHandler(this.btnUserTableConstraintSet_Click);
            // 
            // FrmUserPermissionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 570);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsTool);
            this.Name = "FrmUserPermissionAdmin";
            this.Text = "用户权限管理";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.tsTool.ResumeLayout(false);
            this.tsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripButton btnPermission;
        private System.Windows.Forms.ToolStripButton btnUserRole;
        private System.Windows.Forms.ToolStripButton btnRoleUserBatchSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnBatchPermission;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStrip tsTool;
        private System.Windows.Forms.ToolStripDropDownButton btnDropDownPermission;
        private System.Windows.Forms.ToolStripMenuItem btnUserPermissionScope;
        private System.Windows.Forms.ToolStripMenuItem btnTableFieldPermission;
        private System.Windows.Forms.ToolStripMenuItem btnUserTableConstraintSet;
        private DevComponents.DotNetBar.TabControl tabMain;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TreeView tvOrganize;
        private DevComponents.DotNetBar.TabItem tabItemOrganize;
        private System.Windows.Forms.Splitter splUser;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCurrentTvPath;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcPagerEx ucPager;
        private System.Windows.Forms.ToolStripLabel lblSerach;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imgList;
    }
}