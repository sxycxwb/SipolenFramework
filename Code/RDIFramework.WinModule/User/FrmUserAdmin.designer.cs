/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:57
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAdmin));
            this.line1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucSortControl = new RDIFramework.WinModule.UcSortControl();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCurrentTvPath = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.splUser = new System.Windows.Forms.Splitter();
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.mnuEditUserPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnBatchSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetPassword = new System.Windows.Forms.ToolStripButton();
            this.btnUserOrganize = new System.Windows.Forms.ToolStripButton();
            this.btnDimission = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnLogByUser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogByGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSearch = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.cboEnabledSearch = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnViewEnabledUser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewAllUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsDimission = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.DimGray;
            this.line1.Dock = System.Windows.Forms.DockStyle.Top;
            this.line1.Location = new System.Drawing.Point(0, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1201, 2);
            this.line1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(1201, 509);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvInfo);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.splUser);
            this.panel2.Controls.Add(this.tabControlStaffAdmin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1201, 509);
            this.panel2.TabIndex = 8;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToOrderColumns = true;
            this.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInfo.CheckboxFieldName = "colSelected";
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
            this.colSelected,
            this.colId,
            this.colCode,
            this.colUserName,
            this.colRealName,
            this.colDepartmentName,
            this.colRoleName,
            this.colEnabled,
            this.colIsDimission,
            this.colEmail,
            this.colMobile,
            this.colDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(249, 35);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.RowHeadersWidth = 30;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(952, 443);
            this.dgvInfo.TabIndex = 7;
            this.dgvInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellDoubleClick);
            this.dgvInfo.CurrentCellChanged += new System.EventHandler(this.dgvInfo_CurrentCellChanged);
            this.dgvInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInfo_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucSortControl);
            this.panel1.Controls.Add(this.ucPager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(249, 478);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(952, 31);
            this.panel1.TabIndex = 8;
            // 
            // ucSortControl
            // 
            this.ucSortControl.BackColor = System.Drawing.SystemColors.Window;
            this.ucSortControl.Location = new System.Drawing.Point(1, 2);
            this.ucSortControl.Name = "ucSortControl";
            this.ucSortControl.OEntityId = null;
            this.ucSortControl.Padding = new System.Windows.Forms.Padding(2);
            this.ucSortControl.SetBottomEnabled = true;
            this.ucSortControl.SetDownEnabled = true;
            this.ucSortControl.SetTopEnabled = true;
            this.ucSortControl.SetUpEnabled = true;
            this.ucSortControl.Size = new System.Drawing.Size(138, 27);
            this.ucSortControl.TabIndex = 2;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(439, 5);
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
            this.panel6.Size = new System.Drawing.Size(952, 35);
            this.panel6.TabIndex = 11;
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
            this.splUser.Size = new System.Drawing.Size(3, 509);
            this.splUser.TabIndex = 10;
            this.splUser.TabStop = false;
            // 
            // tabControlStaffAdmin
            // 
            this.tabControlStaffAdmin.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlStaffAdmin.CanReorderTabs = true;
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel4);
            this.tabControlStaffAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlStaffAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlStaffAdmin.Name = "tabControlStaffAdmin";
            this.tabControlStaffAdmin.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlStaffAdmin.SelectedTabIndex = 0;
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(246, 509);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 9;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemOrganize);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvOrganize);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(246, 482);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
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
            this.tvOrganize.Size = new System.Drawing.Size(244, 480);
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
            // toolTipInfo
            // 
            this.toolTipInfo.AutoPopDelay = 1000;
            this.toolTipInfo.InitialDelay = 500;
            this.toolTipInfo.IsBalloon = true;
            this.toolTipInfo.ReshowDelay = 100;
            this.toolTipInfo.ShowAlways = true;
            this.toolTipInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipInfo.ToolTipTitle = "行数据基本信息";
            // 
            // mnuEditUserPwd
            // 
            this.mnuEditUserPwd.Name = "mnuEditUserPwd";
            this.mnuEditUserPwd.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 11F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnBatchSave,
            this.toolStripSeparator6,
            this.btnSetPassword,
            this.btnUserOrganize,
            this.btnDimission,
            this.btnExport,
            this.toolStripDropDownButton1,
            this.toolStripSeparator4,
            this.lblSearch,
            this.txtSearch,
            this.btnFind,
            this.cboEnabledSearch,
            this.toolStripSeparator5,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1201, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 22);
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 22);
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Image = ((System.Drawing.Image)(resources.GetObject("btnBatchSave.Image")));
            this.btnBatchSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(81, 22);
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSetPassword
            // 
            this.btnSetPassword.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPassword.Image")));
            this.btnSetPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetPassword.Name = "btnSetPassword";
            this.btnSetPassword.Size = new System.Drawing.Size(87, 22);
            this.btnSetPassword.Text = "设置密码";
            this.btnSetPassword.Click += new System.EventHandler(this.btnSetPassword_Click);
            // 
            // btnUserOrganize
            // 
            this.btnUserOrganize.Image = ((System.Drawing.Image)(resources.GetObject("btnUserOrganize.Image")));
            this.btnUserOrganize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserOrganize.Name = "btnUserOrganize";
            this.btnUserOrganize.Size = new System.Drawing.Size(57, 22);
            this.btnUserOrganize.Text = "兼职";
            this.btnUserOrganize.Click += new System.EventHandler(this.btnUserOrganize_Click);
            // 
            // btnDimission
            // 
            this.btnDimission.Image = ((System.Drawing.Image)(resources.GetObject("btnDimission.Image")));
            this.btnDimission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDimission.Name = "btnDimission";
            this.btnDimission.Size = new System.Drawing.Size(57, 22);
            this.btnDimission.Text = "离职";
            this.btnDimission.Click += new System.EventHandler(this.btnDimission_Click);
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
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogByUser,
            this.btnLogByGeneral});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(96, 22);
            this.toolStripDropDownButton1.Text = "访问日志";
            // 
            // btnLogByUser
            // 
            this.btnLogByUser.Image = ((System.Drawing.Image)(resources.GetObject("btnLogByUser.Image")));
            this.btnLogByUser.Name = "btnLogByUser";
            this.btnLogByUser.Size = new System.Drawing.Size(164, 22);
            this.btnLogByUser.Text = "用户访问详情";
            this.btnLogByUser.Click += new System.EventHandler(this.btnLogByUser_Click);
            // 
            // btnLogByGeneral
            // 
            this.btnLogByGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnLogByGeneral.Image")));
            this.btnLogByGeneral.Name = "btnLogByGeneral";
            this.btnLogByGeneral.Size = new System.Drawing.Size(164, 22);
            this.btnLogByGeneral.Text = "用户访问情况";
            this.btnLogByGeneral.Click += new System.EventHandler(this.btnLogByGeneral_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 22);
            this.lblSearch.Text = "搜索：";
            this.lblSearch.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(57, 22);
            this.btnFind.Text = "查询";
            this.btnFind.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboEnabledSearch
            // 
            this.cboEnabledSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewEnabledUser,
            this.btnViewAllUser});
            this.cboEnabledSearch.Image = global::RDIFramework.WinModule.Properties.Resources.mnuShowRecordDetail_Image;
            this.cboEnabledSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cboEnabledSearch.Name = "cboEnabledSearch";
            this.cboEnabledSearch.Size = new System.Drawing.Size(111, 22);
            this.cboEnabledSearch.Text = "有效性搜索";
            // 
            // btnViewEnabledUser
            // 
            this.btnViewEnabledUser.Name = "btnViewEnabledUser";
            this.btnViewEnabledUser.Size = new System.Drawing.Size(164, 22);
            this.btnViewEnabledUser.Text = "查看有效用户";
            this.btnViewEnabledUser.Click += new System.EventHandler(this.btnViewEnabledUser_Click);
            // 
            // btnViewAllUser
            // 
            this.btnViewAllUser.Name = "btnViewAllUser";
            this.btnViewAllUser.Size = new System.Drawing.Size(164, 22);
            this.btnViewAllUser.Text = "查看全部用户";
            this.btnViewAllUser.Click += new System.EventHandler(this.btnViewAllUser_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.colRoleName.Visible = false;
            this.colRoleName.Width = 150;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 50;
            // 
            // colIsDimission
            // 
            this.colIsDimission.DataPropertyName = "IsDimission";
            this.colIsDimission.HeaderText = "离职";
            this.colIsDimission.Name = "colIsDimission";
            this.colIsDimission.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsDimission.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsDimission.Width = 50;
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
            // FrmUserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 536);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.line1);
            this.DoubleBuffered = true;
            this.Name = "FrmUserAdmin";
            this.Text = "用户管理";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label line1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuEditUserPwd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblSearch;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnSetPassword;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.ToolStripButton btnBatchSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripDropDownButton cboEnabledSearch;
        private System.Windows.Forms.ToolStripMenuItem btnViewEnabledUser;
        private System.Windows.Forms.ToolStripMenuItem btnViewAllUser;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TreeView tvOrganize;
        private DevComponents.DotNetBar.TabItem tabItemOrganize;
        private System.Windows.Forms.Splitter splUser;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblCurrentTvPath;
        private System.Windows.Forms.Label lblCurrentPosition;
        private Controls.UcPagerEx ucPager;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnUserOrganize;
        private UcSortControl ucSortControl;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnLogByUser;
        private System.Windows.Forms.ToolStripMenuItem btnLogByGeneral;
        private System.Windows.Forms.ToolStripButton btnDimission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsDimission;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;

    }
}