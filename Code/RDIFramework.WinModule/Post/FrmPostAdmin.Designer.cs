﻿/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:53:11
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmPostAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPostAdmin));
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvRole = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentTvPath = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.mnuOrganize = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnMoveTo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRoleUsers = new System.Windows.Forms.ToolStripButton();
            this.btnRolePermission = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
            this.panel1.SuspendLayout();
            this.mnuOrganize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(204, 28);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvRole);
            this.splitMain.Panel1.Controls.Add(this.panel1);
            this.splitMain.Panel2Collapsed = true;
            this.splitMain.Size = new System.Drawing.Size(729, 710);
            this.splitMain.SplitterDistance = 582;
            this.splitMain.TabIndex = 6;
            // 
            // dgvRole
            // 
            this.dgvRole.AllowUserToAddRows = false;
            this.dgvRole.AllowUserToDeleteRows = false;
            this.dgvRole.AllowUserToOrderColumns = true;
            this.dgvRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRole.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRole.ColumnHeadersHeight = 26;
            this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colRealName,
            this.colUsers,
            this.colEnabled,
            this.colDescription});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRole.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRole.EnableHeadersVisualStyles = false;
            this.dgvRole.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvRole.Location = new System.Drawing.Point(0, 35);
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRole.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRole.RowHeadersWidth = 20;
            this.dgvRole.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRole.RowTemplate.Height = 23;
            this.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRole.Size = new System.Drawing.Size(729, 675);
            this.dgvRole.TabIndex = 6;
            this.dgvRole.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRole_CellClick);
            this.dgvRole.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellDoubleClick);
            this.dgvRole.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInfo_DataBindingComplete);
            this.dgvRole.Click += new System.EventHandler(this.dgvInfo_Click);
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
            this.colCode.DataPropertyName = "CODE";
            this.colCode.HeaderText = "编号";
            this.colCode.Name = "colCode";
            this.colCode.Width = 150;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "名称";
            this.colRealName.Name = "colRealName";
            this.colRealName.Width = 180;
            // 
            // colUsers
            // 
            this.colUsers.DataPropertyName = "Users";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUsers.HeaderText = "成员";
            this.colUsers.Name = "colUsers";
            this.colUsers.Width = 400;
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
            this.colDescription.Width = 300;
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
            this.panel1.Size = new System.Drawing.Size(729, 35);
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
            this.lblCurrentPosition.AutoSize = true;
            this.lblCurrentPosition.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentPosition.Font = new System.Drawing.Font("新宋体", 11F);
            this.lblCurrentPosition.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentPosition.Image = ((System.Drawing.Image)(resources.GetObject("lblCurrentPosition.Image")));
            this.lblCurrentPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentPosition.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(111, 15);
            this.lblCurrentPosition.TabIndex = 0;
            this.lblCurrentPosition.Text = "   当前位置：";
            // 
            // mnuOrganize
            // 
            this.mnuOrganize.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete});
            this.mnuOrganize.Name = "mnuOrganize";
            this.mnuOrganize.Size = new System.Drawing.Size(179, 92);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(178, 22);
            this.mnuAdd.Text = "添加岗位(&A)...";
            this.mnuAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(178, 22);
            this.mnuEdit.Text = "编辑组织机构(&E)...";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(178, 22);
            this.mnuDelete.Text = "删除组织机构(&D)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // tabControlStaffAdmin
            // 
            this.tabControlStaffAdmin.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlStaffAdmin.CanReorderTabs = true;
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel3);
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel4);
            this.tabControlStaffAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlStaffAdmin.Location = new System.Drawing.Point(3, 3);
            this.tabControlStaffAdmin.Name = "tabControlStaffAdmin";
            this.tabControlStaffAdmin.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlStaffAdmin.SelectedTabIndex = 0;
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(198, 735);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 9;
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
            this.tabControlPanel4.Size = new System.Drawing.Size(198, 708);
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
            this.tvOrganize.ContextMenuStrip = this.mnuOrganize;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.HotTracking = true;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imgList;
            this.tvOrganize.Location = new System.Drawing.Point(1, 1);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(196, 706);
            this.tvOrganize.TabIndex = 1;
            this.tvOrganize.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvOrganize_ItemDrag);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganize_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvOrganize_Click);
            this.tvOrganize.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragDrop);
            this.tvOrganize.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragEnter);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOrganize_MouseDown);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "package.png");
            this.imgList.Images.SetKeyName(1, "package_open.png");
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
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 708);
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
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 698);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "常规搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.rbCustomerLikeSearch);
            this.panel3.Controls.Add(this.rbCustomerExactSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 106);
            this.panel3.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(9, 55);
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
            this.rbCustomerLikeSearch.Location = new System.Drawing.Point(9, 31);
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
            this.rbCustomerExactSearch.Location = new System.Drawing.Point(9, 7);
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
            this.panel2.Location = new System.Drawing.Point(3, 19);
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
            this.lblSearchValue.AutoEllipsis = true;
            this.lblSearchValue.Location = new System.Drawing.Point(9, 5);
            this.lblSearchValue.Name = "lblSearchValue";
            this.lblSearchValue.Size = new System.Drawing.Size(138, 14);
            this.lblSearchValue.TabIndex = 2;
            this.lblSearchValue.Text = "搜索内容：";
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
            this.btnMoveTo,
            this.toolStripSeparator6,
            this.btnRoleUsers,
            this.btnRolePermission,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(204, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(729, 25);
            this.toolStrip1.TabIndex = 11;
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
            // btnMoveTo
            // 
            this.btnMoveTo.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveTo.Image")));
            this.btnMoveTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveTo.Name = "btnMoveTo";
            this.btnMoveTo.Size = new System.Drawing.Size(57, 22);
            this.btnMoveTo.Text = "移动";
            this.btnMoveTo.Click += new System.EventHandler(this.btnMoveTo_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRoleUsers
            // 
            this.btnRoleUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnRoleUsers.Image")));
            this.btnRoleUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRoleUsers.Name = "btnRoleUsers";
            this.btnRoleUsers.Size = new System.Drawing.Size(57, 22);
            this.btnRoleUsers.Text = "用户";
            this.btnRoleUsers.Click += new System.EventHandler(this.btnRoleUsers_Click);
            // 
            // btnRolePermission
            // 
            this.btnRolePermission.Image = ((System.Drawing.Image)(resources.GetObject("btnRolePermission.Image")));
            this.btnRolePermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRolePermission.Name = "btnRolePermission";
            this.btnRolePermission.Size = new System.Drawing.Size(57, 22);
            this.btnRolePermission.Text = "权限";
            this.btnRolePermission.Click += new System.EventHandler(this.btnRolePermission_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(201, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 735);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // FrmPostAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 741);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.Name = "FrmPostAdmin";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "岗位管理";
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mnuOrganize.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ContextMenuStrip mnuOrganize;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TreeView tvOrganize;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.UcDataGridView dgvRole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentTvPath;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsers;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripButton btnRoleUsers;
        private System.Windows.Forms.ToolStripButton btnRolePermission;
        private System.Windows.Forms.ToolStripButton btnMoveTo;
    }
}