namespace RDIFramework.WinModule
{
    partial class FrmModuleAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblWinWebFormColor = new System.Windows.Forms.Label();
            this.lblWinWebType = new System.Windows.Forms.Label();
            this.lblWebFormColor = new System.Windows.Forms.Label();
            this.lblWinFormColor = new System.Windows.Forms.Label();
            this.lblWebFormType = new System.Windows.Forms.Label();
            this.lblWinFormType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucSortControl = new RDIFramework.WinModule.UcSortControl();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvModule = new System.Windows.Forms.TreeView();
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
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnBatchSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoveTo = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModuleConfig = new System.Windows.Forms.ToolStripButton();
            this.btnModulePermissionItem = new System.Windows.Forms.ToolStripButton();
            this.ddbModulePermissionSet = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnUserModulePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRoleModulePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrganizeModulePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.colMODULETYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colASSEMBLYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFORMNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNAVIGATEURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMVCNAVIGATEURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAllowEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAllowDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsMenu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitMain.Location = new System.Drawing.Point(227, 25);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.dgvInfo);
            this.splitMain.Panel1.Controls.Add(this.panel5);
            this.splitMain.Panel1.Controls.Add(this.panel1);
            this.splitMain.Panel2Collapsed = true;
            this.splitMain.Size = new System.Drawing.Size(921, 716);
            this.splitMain.SplitterDistance = 665;
            this.splitMain.TabIndex = 7;
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
            this.colMODULETYPE,
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colASSEMBLYNAME,
            this.colFORMNAME,
            this.colNAVIGATEURL,
            this.colMVCNAVIGATEURL,
            this.colIsPublic,
            this.colEnabled,
            this.colAllowEdit,
            this.colAllowDelete,
            this.colIsMenu,
            this.colDescription});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(0, 42);
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
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInfo.Size = new System.Drawing.Size(921, 639);
            this.dgvInfo.TabIndex = 5;
            this.dgvInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellDoubleClick);
            this.dgvInfo.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvInfo_RowPrePaint);
            this.dgvInfo.Sorted += new System.EventHandler(this.dgvInfo_Sorted);
            this.dgvInfo.Click += new System.EventHandler(this.dgvInfo_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Info;
            this.panel5.Controls.Add(this.lblWinWebFormColor);
            this.panel5.Controls.Add(this.lblWinWebType);
            this.panel5.Controls.Add(this.lblWebFormColor);
            this.panel5.Controls.Add(this.lblWinFormColor);
            this.panel5.Controls.Add(this.lblWebFormType);
            this.panel5.Controls.Add(this.lblWinFormType);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(921, 42);
            this.panel5.TabIndex = 8;
            // 
            // lblWinWebFormColor
            // 
            this.lblWinWebFormColor.AutoSize = true;
            this.lblWinWebFormColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblWinWebFormColor.Location = new System.Drawing.Point(255, 14);
            this.lblWinWebFormColor.Name = "lblWinWebFormColor";
            this.lblWinWebFormColor.Size = new System.Drawing.Size(28, 14);
            this.lblWinWebFormColor.TabIndex = 5;
            this.lblWinWebFormColor.Text = "   ";
            // 
            // lblWinWebType
            // 
            this.lblWinWebType.AutoSize = true;
            this.lblWinWebType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(127)))), ((int)(((byte)(178)))));
            this.lblWinWebType.Location = new System.Drawing.Point(286, 14);
            this.lblWinWebType.Name = "lblWinWebType";
            this.lblWinWebType.Size = new System.Drawing.Size(140, 14);
            this.lblWinWebType.TabIndex = 4;
            this.lblWinWebType.Text = "WinForm/WebForm类型";
            // 
            // lblWebFormColor
            // 
            this.lblWebFormColor.AutoSize = true;
            this.lblWebFormColor.BackColor = System.Drawing.Color.YellowGreen;
            this.lblWebFormColor.Location = new System.Drawing.Point(133, 14);
            this.lblWebFormColor.Name = "lblWebFormColor";
            this.lblWebFormColor.Size = new System.Drawing.Size(28, 14);
            this.lblWebFormColor.TabIndex = 3;
            this.lblWebFormColor.Text = "   ";
            // 
            // lblWinFormColor
            // 
            this.lblWinFormColor.AutoSize = true;
            this.lblWinFormColor.BackColor = System.Drawing.Color.Coral;
            this.lblWinFormColor.Location = new System.Drawing.Point(11, 14);
            this.lblWinFormColor.Name = "lblWinFormColor";
            this.lblWinFormColor.Size = new System.Drawing.Size(28, 14);
            this.lblWinFormColor.TabIndex = 2;
            this.lblWinFormColor.Text = "   ";
            // 
            // lblWebFormType
            // 
            this.lblWebFormType.AutoSize = true;
            this.lblWebFormType.ForeColor = System.Drawing.Color.YellowGreen;
            this.lblWebFormType.Location = new System.Drawing.Point(165, 14);
            this.lblWebFormType.Name = "lblWebFormType";
            this.lblWebFormType.Size = new System.Drawing.Size(84, 14);
            this.lblWebFormType.TabIndex = 1;
            this.lblWebFormType.Text = "WebForm类型";
            // 
            // lblWinFormType
            // 
            this.lblWinFormType.AutoSize = true;
            this.lblWinFormType.ForeColor = System.Drawing.Color.Coral;
            this.lblWinFormType.Location = new System.Drawing.Point(43, 14);
            this.lblWinFormType.Name = "lblWinFormType";
            this.lblWinFormType.Size = new System.Drawing.Size(84, 14);
            this.lblWinFormType.TabIndex = 0;
            this.lblWinFormType.Text = "WinForm类型";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucSortControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 681);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(921, 35);
            this.panel1.TabIndex = 6;
            // 
            // ucSortControl
            // 
            this.ucSortControl.BackColor = System.Drawing.SystemColors.Window;
            this.ucSortControl.Location = new System.Drawing.Point(5, 5);
            this.ucSortControl.Name = "ucSortControl";
            this.ucSortControl.OEntityId = null;
            this.ucSortControl.Padding = new System.Windows.Forms.Padding(2);
            this.ucSortControl.SetBottomEnabled = true;
            this.ucSortControl.SetDownEnabled = true;
            this.ucSortControl.SetTopEnabled = true;
            this.ucSortControl.SetUpEnabled = true;
            this.ucSortControl.Size = new System.Drawing.Size(139, 25);
            this.ucSortControl.TabIndex = 3;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "menu1.png");
            this.imgList.Images.SetKeyName(1, "menu2.png");
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
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(224, 741);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 12;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemOrganize);
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemSearch);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvModule);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(224, 714);
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
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.HotTracking = true;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imgList;
            this.tvModule.Location = new System.Drawing.Point(1, 1);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 1;
            this.tvModule.Size = new System.Drawing.Size(222, 712);
            this.tvModule.TabIndex = 1;
            this.tvModule.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvModule_ItemDrag);
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            this.tvModule.Click += new System.EventHandler(this.tvModule_Click);
            this.tvModule.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvModule_DragDrop);
            this.tvModule.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvModule_DragEnter);
            this.tvModule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvModule_MouseDown);
            // 
            // tabItemOrganize
            // 
            this.tabItemOrganize.AttachedControl = this.tabControlPanel4;
            this.tabItemOrganize.Name = "tabItemOrganize";
            this.tabItemOrganize.Text = "模块（菜单）";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(224, 714);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
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
            this.gbCustomSearch.Size = new System.Drawing.Size(214, 704);
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
            this.panel3.Size = new System.Drawing.Size(208, 65);
            this.panel3.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(110, 22);
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
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(208, 56);
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
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(208, 11);
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
            this.splitter1.Location = new System.Drawing.Point(224, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 741);
            this.splitter1.TabIndex = 14;
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
            this.btnBatchSave,
            this.toolStripSeparator6,
            this.btnMoveTo,
            this.btnExport,
            this.toolStripSeparator5,
            this.btnModuleConfig,
            this.btnModulePermissionItem,
            this.ddbModulePermissionSet,
            this.toolStripSeparator1,
            this.btnClose});
            this.tsTool.Location = new System.Drawing.Point(227, 0);
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(921, 25);
            this.tsTool.TabIndex = 15;
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
            // btnMoveTo
            // 
            this.btnMoveTo.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveTo.Image")));
            this.btnMoveTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveTo.Name = "btnMoveTo";
            this.btnMoveTo.Size = new System.Drawing.Size(81, 22);
            this.btnMoveTo.Text = "移动(&M)";
            this.btnMoveTo.ToolTipText = "移动";
            this.btnMoveTo.Click += new System.EventHandler(this.btnMoveTo_Click);
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
            // btnModuleConfig
            // 
            this.btnModuleConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnModuleConfig.Image")));
            this.btnModuleConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModuleConfig.Name = "btnModuleConfig";
            this.btnModuleConfig.Size = new System.Drawing.Size(87, 22);
            this.btnModuleConfig.Text = "模块配置";
            this.btnModuleConfig.Click += new System.EventHandler(this.btnModuleConfig_Click);
            // 
            // btnModulePermissionItem
            // 
            this.btnModulePermissionItem.Image = ((System.Drawing.Image)(resources.GetObject("btnModulePermissionItem.Image")));
            this.btnModulePermissionItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModulePermissionItem.Name = "btnModulePermissionItem";
            this.btnModulePermissionItem.Size = new System.Drawing.Size(132, 22);
            this.btnModulePermissionItem.Text = "模块操作权限项";
            this.btnModulePermissionItem.Click += new System.EventHandler(this.btnModulePermissionItem_Click);
            // 
            // ddbModulePermissionSet
            // 
            this.ddbModulePermissionSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserModulePermission,
            this.btnRoleModulePermission,
            this.btnOrganizeModulePermission});
            this.ddbModulePermissionSet.Image = ((System.Drawing.Image)(resources.GetObject("ddbModulePermissionSet.Image")));
            this.ddbModulePermissionSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbModulePermissionSet.Name = "ddbModulePermissionSet";
            this.ddbModulePermissionSet.Size = new System.Drawing.Size(126, 22);
            this.ddbModulePermissionSet.Text = "模块权限设置";
            // 
            // btnUserModulePermission
            // 
            this.btnUserModulePermission.Image = ((System.Drawing.Image)(resources.GetObject("btnUserModulePermission.Image")));
            this.btnUserModulePermission.Name = "btnUserModulePermission";
            this.btnUserModulePermission.Size = new System.Drawing.Size(194, 22);
            this.btnUserModulePermission.Text = "用户模块权限";
            this.btnUserModulePermission.Click += new System.EventHandler(this.btnUserModulePermission_Click);
            // 
            // btnRoleModulePermission
            // 
            this.btnRoleModulePermission.Image = ((System.Drawing.Image)(resources.GetObject("btnRoleModulePermission.Image")));
            this.btnRoleModulePermission.Name = "btnRoleModulePermission";
            this.btnRoleModulePermission.Size = new System.Drawing.Size(194, 22);
            this.btnRoleModulePermission.Text = "角色模块权限";
            this.btnRoleModulePermission.Click += new System.EventHandler(this.btnRoleModulePermission_Click);
            // 
            // btnOrganizeModulePermission
            // 
            this.btnOrganizeModulePermission.Image = ((System.Drawing.Image)(resources.GetObject("btnOrganizeModulePermission.Image")));
            this.btnOrganizeModulePermission.Name = "btnOrganizeModulePermission";
            this.btnOrganizeModulePermission.Size = new System.Drawing.Size(194, 22);
            this.btnOrganizeModulePermission.Text = "组织机构模块权限";
            this.btnOrganizeModulePermission.Click += new System.EventHandler(this.btnOrganizeModulePermission_Click);
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
            // colMODULETYPE
            // 
            this.colMODULETYPE.DataPropertyName = "MODULETYPE";
            this.colMODULETYPE.Frozen = true;
            this.colMODULETYPE.HeaderText = "MODULETYPE";
            this.colMODULETYPE.Name = "colMODULETYPE";
            this.colMODULETYPE.Visible = false;
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
            this.colFullName.Frozen = true;
            this.colFullName.HeaderText = "名称";
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 120;
            // 
            // colASSEMBLYNAME
            // 
            this.colASSEMBLYNAME.DataPropertyName = "ASSEMBLYNAME";
            this.colASSEMBLYNAME.HeaderText = "程序集名称";
            this.colASSEMBLYNAME.Name = "colASSEMBLYNAME";
            this.colASSEMBLYNAME.Width = 180;
            // 
            // colFORMNAME
            // 
            this.colFORMNAME.DataPropertyName = "FORMNAME";
            this.colFORMNAME.HeaderText = "窗体名称";
            this.colFORMNAME.Name = "colFORMNAME";
            this.colFORMNAME.Width = 300;
            // 
            // colNAVIGATEURL
            // 
            this.colNAVIGATEURL.DataPropertyName = "NAVIGATEURL";
            this.colNAVIGATEURL.HeaderText = "链接地址";
            this.colNAVIGATEURL.Name = "colNAVIGATEURL";
            this.colNAVIGATEURL.Width = 200;
            // 
            // colMVCNAVIGATEURL
            // 
            this.colMVCNAVIGATEURL.DataPropertyName = "MVCNAVIGATEURL";
            this.colMVCNAVIGATEURL.HeaderText = "MVC链接";
            this.colMVCNAVIGATEURL.Name = "colMVCNAVIGATEURL";
            this.colMVCNAVIGATEURL.Width = 200;
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
            // colAllowEdit
            // 
            this.colAllowEdit.DataPropertyName = "AllowEdit";
            this.colAllowEdit.HeaderText = "可编辑";
            this.colAllowEdit.Name = "colAllowEdit";
            this.colAllowEdit.Width = 45;
            // 
            // colAllowDelete
            // 
            this.colAllowDelete.DataPropertyName = "AllowDelete";
            this.colAllowDelete.HeaderText = "可删除";
            this.colAllowDelete.Name = "colAllowDelete";
            this.colAllowDelete.Width = 45;
            // 
            // colIsMenu
            // 
            this.colIsMenu.DataPropertyName = "IsMenu";
            this.colIsMenu.HeaderText = "菜单";
            this.colIsMenu.Name = "colIsMenu";
            this.colIsMenu.Width = 45;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // FrmModuleAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 741);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.tsTool);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.DoubleBuffered = true;
            this.Name = "FrmModuleAdmin";
            this.Text = "模块管理";
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.ToolStrip tsTool;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnMoveTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.ToolStripButton btnModuleConfig;
        private System.Windows.Forms.Panel panel1;
        private UcSortControl ucSortControl;
        private System.Windows.Forms.ToolStripButton btnBatchSave;
        private System.Windows.Forms.ToolStripDropDownButton ddbModulePermissionSet;
        private System.Windows.Forms.ToolStripMenuItem btnUserModulePermission;
        private System.Windows.Forms.ToolStripMenuItem btnRoleModulePermission;
        private System.Windows.Forms.ToolStripMenuItem btnOrganizeModulePermission;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblWebFormColor;
        private System.Windows.Forms.Label lblWinFormColor;
        private System.Windows.Forms.Label lblWebFormType;
        private System.Windows.Forms.Label lblWinFormType;
        private System.Windows.Forms.Label lblWinWebFormColor;
        private System.Windows.Forms.Label lblWinWebType;
        private System.Windows.Forms.ToolStripButton btnModulePermissionItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMODULETYPE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colASSEMBLYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFORMNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNAVIGATEURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMVCNAVIGATEURL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAllowEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAllowDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}