/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:56:13
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmPermissionItemAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissionItemAdmin));
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsScope = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucSortControl = new RDIFramework.WinModule.UcSortControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentTvPath = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvPermission = new System.Windows.Forms.TreeView();
            this.tabItemPermissionItem = new DevComponents.DotNetBar.TabItem(this.components);
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
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBatchSave = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ddbPermissionItemPermissionSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnUserPermissionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRolePermissionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(235, 25);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvInfo);
            this.splitMain.Panel1.Controls.Add(this.panel5);
            this.splitMain.Panel1.Controls.Add(this.panel1);
            this.splitMain.Panel2Collapsed = true;
            this.splitMain.Size = new System.Drawing.Size(722, 609);
            this.splitMain.SplitterDistance = 506;
            this.splitMain.TabIndex = 10;
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
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colIsScope,
            this.colIsPublic,
            this.colEnabled,
            this.colDescription});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(0, 35);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInfo.RowHeadersWidth = 30;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(722, 543);
            this.dgvInfo.TabIndex = 7;
            this.dgvInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellDoubleClick);
            this.dgvInfo.Sorted += new System.EventHandler(this.dgvInfo_Sorted);
            this.dgvInfo.Click += new System.EventHandler(this.dgvInfo_Click);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 45;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCode.Frozen = true;
            this.colCode.HeaderText = "编号";
            this.colCode.Name = "colCode";
            this.colCode.Width = 150;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.HeaderText = "名称";
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 120;
            // 
            // colIsScope
            // 
            this.colIsScope.DataPropertyName = "IsScope";
            this.colIsScope.HeaderText = "数据权限";
            this.colIsScope.Name = "colIsScope";
            this.colIsScope.Width = 80;
            // 
            // colIsPublic
            // 
            this.colIsPublic.DataPropertyName = "IsPublic";
            this.colIsPublic.HeaderText = "公开";
            this.colIsPublic.Name = "colIsPublic";
            this.colIsPublic.Width = 45;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 45;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ucSortControl);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 578);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(722, 31);
            this.panel5.TabIndex = 9;
            // 
            // ucSortControl
            // 
            this.ucSortControl.BackColor = System.Drawing.SystemColors.Window;
            this.ucSortControl.Location = new System.Drawing.Point(3, 3);
            this.ucSortControl.Name = "ucSortControl";
            this.ucSortControl.OEntityId = null;
            this.ucSortControl.Padding = new System.Windows.Forms.Padding(2);
            this.ucSortControl.SetBottomEnabled = true;
            this.ucSortControl.SetDownEnabled = true;
            this.ucSortControl.SetTopEnabled = true;
            this.ucSortControl.SetUpEnabled = true;
            this.ucSortControl.Size = new System.Drawing.Size(139, 25);
            this.ucSortControl.TabIndex = 0;
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
            this.panel1.Size = new System.Drawing.Size(722, 35);
            this.panel1.TabIndex = 8;
            // 
            // lblCurrentTvPath
            // 
            this.lblCurrentTvPath.AutoSize = true;
            this.lblCurrentTvPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentTvPath.Font = new System.Drawing.Font("新宋体", 11F);
            this.lblCurrentTvPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentTvPath.Location = new System.Drawing.Point(113, 10);
            this.lblCurrentTvPath.Name = "lblCurrentTvPath";
            this.lblCurrentTvPath.Size = new System.Drawing.Size(39, 15);
            this.lblCurrentTvPath.TabIndex = 1;
            this.lblCurrentTvPath.Text = "    ";
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
            this.lblCurrentPosition.Size = new System.Drawing.Size(103, 15);
            this.lblCurrentPosition.TabIndex = 0;
            this.lblCurrentPosition.Text = "   当前位置:";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "button.png");
            this.imgList.Images.SetKeyName(1, "ok.png");
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
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(232, 634);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 11;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemPermissionItem);
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemSearch);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvPermission);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(232, 607);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItemPermissionItem;
            // 
            // tvPermission
            // 
            this.tvPermission.AllowDrop = true;
            this.tvPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermission.HotTracking = true;
            this.tvPermission.ImageIndex = 0;
            this.tvPermission.ImageList = this.imgList;
            this.tvPermission.Location = new System.Drawing.Point(1, 1);
            this.tvPermission.Name = "tvPermission";
            this.tvPermission.SelectedImageIndex = 1;
            this.tvPermission.Size = new System.Drawing.Size(230, 605);
            this.tvPermission.TabIndex = 1;
            this.tvPermission.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvPermission_ItemDrag);
            this.tvPermission.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPermission_AfterSelect);
            this.tvPermission.Click += new System.EventHandler(this.tvPermission_Click);
            this.tvPermission.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvPermission_DragDrop);
            this.tvPermission.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvPermission_DragEnter);
            this.tvPermission.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvPermission_MouseDown);
            // 
            // tabItemPermissionItem
            // 
            this.tabItemPermissionItem.AttachedControl = this.tabControlPanel4;
            this.tabItemPermissionItem.Name = "tabItemPermissionItem";
            this.tabItemPermissionItem.Text = "操作权限";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(232, 607);
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
            this.gbCustomSearch.Size = new System.Drawing.Size(222, 597);
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
            this.panel3.Location = new System.Drawing.Point(3, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 110);
            this.panel3.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(13, 58);
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
            this.rbCustomerLikeSearch.Location = new System.Drawing.Point(13, 32);
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
            this.rbCustomerExactSearch.Location = new System.Drawing.Point(13, 8);
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
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 56);
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
            this.txtSearchValue.SelectedValue = ((object)(resources.GetObject("txtSearchValue.SelectedValue")));
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
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 11);
            this.panel4.TabIndex = 9;
            // 
            // tabItemSearch
            // 
            this.tabItemSearch.AttachedControl = this.tabControlPanel3;
            this.tabItemSearch.Name = "tabItemSearch";
            this.tabItemSearch.Text = "搜索";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(232, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 634);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // tsTool
            // 
            this.tsTool.AutoSize = false;
            this.tsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnMove,
            this.toolStripSeparator6,
            this.btnBatchSave,
            this.btnExport,
            this.toolStripSeparator5,
            this.ddbPermissionItemPermissionSet,
            this.toolStripSeparator1,
            this.btnClose});
            this.tsTool.Location = new System.Drawing.Point(235, 0);
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(722, 25);
            this.tsTool.TabIndex = 14;
            this.tsTool.Text = "toolStrip1";
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
            this.btnDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnMove
            // 
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(81, 22);
            this.btnMove.Text = "移动(&M)";
            this.btnMove.ToolTipText = "移动";
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
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
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(57, 22);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // ddbPermissionItemPermissionSet
            // 
            this.ddbPermissionItemPermissionSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserPermissionItem,
            this.btnRolePermissionItem});
            this.ddbPermissionItemPermissionSet.Image = ((System.Drawing.Image)(resources.GetObject("ddbPermissionItemPermissionSet.Image")));
            this.ddbPermissionItemPermissionSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbPermissionItemPermissionSet.Name = "ddbPermissionItemPermissionSet";
            this.ddbPermissionItemPermissionSet.Size = new System.Drawing.Size(171, 22);
            this.ddbPermissionItemPermissionSet.Text = "操作权限项权限设置";
            // 
            // btnUserPermissionItem
            // 
            this.btnUserPermissionItem.Image = ((System.Drawing.Image)(resources.GetObject("btnUserPermissionItem.Image")));
            this.btnUserPermissionItem.Name = "btnUserPermissionItem";
            this.btnUserPermissionItem.Size = new System.Drawing.Size(164, 22);
            this.btnUserPermissionItem.Text = "用户操作权限";
            this.btnUserPermissionItem.Click += new System.EventHandler(this.btnUserPermissionItem_Click);
            // 
            // btnRolePermissionItem
            // 
            this.btnRolePermissionItem.Image = ((System.Drawing.Image)(resources.GetObject("btnRolePermissionItem.Image")));
            this.btnRolePermissionItem.Name = "btnRolePermissionItem";
            this.btnRolePermissionItem.Size = new System.Drawing.Size(164, 22);
            this.btnRolePermissionItem.Text = "角色操作权限";
            this.btnRolePermissionItem.Click += new System.EventHandler(this.btnRolePermissionItem_Click);
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
            // FrmPermissionItemAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 634);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.tsTool);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.Name = "FrmPermissionItemAdmin";
            this.Text = "操作权限管理";
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel5.ResumeLayout(false);
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
            this.tsTool.ResumeLayout(false);
            this.tsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ImageList imgList;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItemPermissionItem;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel3;
        private Controls.UcButton btnSearch;
        private System.Windows.Forms.RadioButton rbCustomerLikeSearch;
        private System.Windows.Forms.RadioButton rbCustomerExactSearch;
        private System.Windows.Forms.Panel panel2;
        private Controls.UcTextBox txtSearchValue;
        private System.Windows.Forms.Label lblSearchValue;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip tsTool;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnMove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.TreeView tvPermission;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentTvPath;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsScope;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripButton btnBatchSave;
        private System.Windows.Forms.Panel panel5;
        private UcSortControl ucSortControl;
        private System.Windows.Forms.ToolStripDropDownButton ddbPermissionItemPermissionSet;
        private System.Windows.Forms.ToolStripMenuItem btnUserPermissionItem;
        private System.Windows.Forms.ToolStripMenuItem btnRolePermissionItem;
    }
}