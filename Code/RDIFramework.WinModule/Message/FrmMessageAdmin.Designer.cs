namespace RDIFramework.WinModule
{
    partial class FrmMessageAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageAdmin));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("消息", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("提示", 2, 2);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("用户信息", 3, 3);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("警示", 4, 4);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("待审核事项", 5, 5);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("待审核", 6, 6);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("角色信息", 7, 7);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("组织机构信息", 8, 8);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("系统推送", 9, 9);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("消息功能分类", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefreash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendMessage = new System.Windows.Forms.ToolStripButton();
            this.btnBroadcastMessage = new System.Windows.Forms.ToolStripButton();
            this.btnReadMessage = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteMessage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvList = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tcRole = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvList = new RDIFramework.Controls.UcDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFUNCTIONCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCATEGORYCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMSGCONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRECEIVERREALNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colISNEW = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colREADCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colREADDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIPADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCREATEBY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colENABLED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).BeginInit();
            this.tcRole.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 11F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreash,
            this.toolStripSeparator3,
            this.btnSendMessage,
            this.btnBroadcastMessage,
            this.btnReadMessage,
            this.btnDeleteMessage,
            this.toolStripSeparator2,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(714, 25);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefreash
            // 
            this.btnRefreash.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreash.Image")));
            this.btnRefreash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(57, 22);
            this.btnRefreash.Text = "刷新";
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.Image")));
            this.btnSendMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(111, 22);
            this.btnSendMessage.Text = "发送消息(&S)";
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnBroadcastMessage
            // 
            this.btnBroadcastMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnBroadcastMessage.Image")));
            this.btnBroadcastMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBroadcastMessage.Name = "btnBroadcastMessage";
            this.btnBroadcastMessage.Size = new System.Drawing.Size(111, 22);
            this.btnBroadcastMessage.Text = "广播消息(&B)";
            this.btnBroadcastMessage.Click += new System.EventHandler(this.btnBroadcastMessage_Click);
            // 
            // btnReadMessage
            // 
            this.btnReadMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnReadMessage.Image")));
            this.btnReadMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReadMessage.Name = "btnReadMessage";
            this.btnReadMessage.Size = new System.Drawing.Size(81, 22);
            this.btnReadMessage.Text = "已读(&R)";
            this.btnReadMessage.Click += new System.EventHandler(this.btnReadMessage_Click);
            // 
            // btnDeleteMessage
            // 
            this.btnDeleteMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteMessage.Image")));
            this.btnDeleteMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteMessage.Name = "btnDeleteMessage";
            this.btnDeleteMessage.Size = new System.Drawing.Size(81, 22);
            this.btnDeleteMessage.Text = "删除(&D)";
            this.btnDeleteMessage.Click += new System.EventHandler(this.btnDeleteMessage_Click);
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
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(212, 506);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 22;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemOrganize);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvList);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(212, 479);
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
            // tvList
            // 
            this.tvList.AllowDrop = true;
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.HotTracking = true;
            this.tvList.ImageIndex = 0;
            this.tvList.ImageList = this.imgList;
            this.tvList.Location = new System.Drawing.Point(1, 1);
            this.tvList.Name = "tvList";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "Message";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Tag = "Message";
            treeNode1.Text = "消息";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "Remind";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Tag = "Remind";
            treeNode2.Text = "提示";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "UserMessage";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Tag = "UserMessage";
            treeNode3.Text = "用户信息";
            treeNode4.ImageIndex = 4;
            treeNode4.Name = "Warning";
            treeNode4.SelectedImageIndex = 4;
            treeNode4.Tag = "Warning";
            treeNode4.Text = "警示";
            treeNode5.ImageIndex = 5;
            treeNode5.Name = "WaitForAudit";
            treeNode5.SelectedImageIndex = 5;
            treeNode5.Tag = "WaitForAudit";
            treeNode5.Text = "待审核事项";
            treeNode6.ImageIndex = 6;
            treeNode6.Name = "TodoList";
            treeNode6.SelectedImageIndex = 6;
            treeNode6.Tag = "TodoList";
            treeNode6.Text = "待审核";
            treeNode7.ImageIndex = 7;
            treeNode7.Name = "RoleMessage";
            treeNode7.SelectedImageIndex = 7;
            treeNode7.Tag = "RoleMessage";
            treeNode7.Text = "角色信息";
            treeNode8.ImageIndex = 8;
            treeNode8.Name = "OrganizeMessage";
            treeNode8.SelectedImageIndex = 8;
            treeNode8.Tag = "OrganizeMessage";
            treeNode8.Text = "组织机构信息";
            treeNode9.ImageIndex = 9;
            treeNode9.Name = "SystemPush";
            treeNode9.SelectedImageIndex = 9;
            treeNode9.Tag = "SystemPush";
            treeNode9.Text = "系统推送";
            treeNode10.ImageIndex = 0;
            treeNode10.Name = "All";
            treeNode10.SelectedImageIndex = 0;
            treeNode10.Tag = "All";
            treeNode10.Text = "消息功能分类";
            this.tvList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.tvList.SelectedImageIndex = 1;
            this.tvList.Size = new System.Drawing.Size(210, 477);
            this.tvList.TabIndex = 1;
            this.tvList.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvList_BeforeSelect);
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "email_trace.png");
            this.imgList.Images.SetKeyName(1, "flag_1.png");
            this.imgList.Images.SetKeyName(2, "flag_2.png");
            this.imgList.Images.SetKeyName(3, "flag_blue.png");
            this.imgList.Images.SetKeyName(4, "flag_red.png");
            this.imgList.Images.SetKeyName(5, "flag_finish.png");
            this.imgList.Images.SetKeyName(6, "flag_green.png");
            this.imgList.Images.SetKeyName(7, "flag_orange.png");
            this.imgList.Images.SetKeyName(8, "flag_pink.png");
            this.imgList.Images.SetKeyName(9, "flag_yellow.png");
            this.imgList.Images.SetKeyName(10, "flag_nepal.png");
            // 
            // tabItemOrganize
            // 
            this.tabItemOrganize.AttachedControl = this.tabControlPanel4;
            this.tabItemOrganize.Name = "tabItemOrganize";
            this.tabItemOrganize.Text = "消息分类列表";
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(212, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.panel4);
            this.splitMain.Panel1.Controls.Add(this.toolStrip1);
            this.splitMain.Panel2Collapsed = true;
            this.splitMain.Size = new System.Drawing.Size(714, 506);
            this.splitMain.SplitterDistance = 454;
            this.splitMain.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tcRole);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(714, 481);
            this.panel4.TabIndex = 21;
            // 
            // tcRole
            // 
            this.tcRole.BackColor = System.Drawing.SystemColors.Window;
            this.tcRole.CanReorderTabs = true;
            this.tcRole.Controls.Add(this.tabControlPanel2);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRole.Location = new System.Drawing.Point(0, 0);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcRole.SelectedTabIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(714, 481);
            this.tcRole.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcRole.TabIndex = 22;
            this.tcRole.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcRole.Tabs.Add(this.tabItem1);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvList);
            this.tabControlPanel2.Controls.Add(this.panel5);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(714, 454);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItem1;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvList.ColumnHeadersHeight = 26;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colID,
            this.colFUNCTIONCODE,
            this.colCATEGORYCODE,
            this.colTITLE,
            this.colMSGCONTENT,
            this.colRECEIVERREALNAME,
            this.colISNEW,
            this.colREADCOUNT,
            this.colREADDATE,
            this.colIPADDRESS,
            this.colCREATEBY,
            this.colENABLED});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvList.Location = new System.Drawing.Point(1, 1);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvList.RowHeadersWidth = 20;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(712, 421);
            this.dgvList.TabIndex = 10;
            this.dgvList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvList_CellPainting);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ucPager);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 422);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(712, 31);
            this.panel5.TabIndex = 11;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(202, 3);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(507, 27);
            this.ucPager.TabIndex = 10;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel2;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "消息列表";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(212, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 506);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colFUNCTIONCODE
            // 
            this.colFUNCTIONCODE.DataPropertyName = "FUNCTIONCODE";
            this.colFUNCTIONCODE.HeaderText = "功能代码";
            this.colFUNCTIONCODE.Name = "colFUNCTIONCODE";
            // 
            // colCATEGORYCODE
            // 
            this.colCATEGORYCODE.DataPropertyName = "CATEGORYCODE";
            this.colCATEGORYCODE.HeaderText = "分类代码";
            this.colCATEGORYCODE.Name = "colCATEGORYCODE";
            // 
            // colTITLE
            // 
            this.colTITLE.DataPropertyName = "TITLE";
            this.colTITLE.HeaderText = "主题";
            this.colTITLE.Name = "colTITLE";
            // 
            // colMSGCONTENT
            // 
            this.colMSGCONTENT.DataPropertyName = "MSGCONTENT";
            this.colMSGCONTENT.HeaderText = "内容";
            this.colMSGCONTENT.Name = "colMSGCONTENT";
            // 
            // colRECEIVERREALNAME
            // 
            this.colRECEIVERREALNAME.DataPropertyName = "RECEIVERREALNAME";
            this.colRECEIVERREALNAME.HeaderText = "接收者";
            this.colRECEIVERREALNAME.Name = "colRECEIVERREALNAME";
            // 
            // colISNEW
            // 
            this.colISNEW.DataPropertyName = "ISNEW";
            this.colISNEW.HeaderText = "新消息";
            this.colISNEW.Name = "colISNEW";
            this.colISNEW.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colISNEW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colISNEW.Width = 70;
            // 
            // colREADCOUNT
            // 
            this.colREADCOUNT.DataPropertyName = "READCOUNT";
            this.colREADCOUNT.HeaderText = "阅读次数";
            this.colREADCOUNT.Name = "colREADCOUNT";
            this.colREADCOUNT.Width = 80;
            // 
            // colREADDATE
            // 
            this.colREADDATE.DataPropertyName = "READDATE";
            this.colREADDATE.HeaderText = "阅读日期";
            this.colREADDATE.Name = "colREADDATE";
            this.colREADDATE.Width = 150;
            // 
            // colIPADDRESS
            // 
            this.colIPADDRESS.DataPropertyName = "IPADDRESS";
            this.colIPADDRESS.HeaderText = "IP地址";
            this.colIPADDRESS.Name = "colIPADDRESS";
            // 
            // colCREATEBY
            // 
            this.colCREATEBY.DataPropertyName = "CREATEBY";
            this.colCREATEBY.HeaderText = "发送者";
            this.colCREATEBY.Name = "colCREATEBY";
            // 
            // colENABLED
            // 
            this.colENABLED.DataPropertyName = "ENABLED";
            this.colENABLED.HeaderText = "状态";
            this.colENABLED.Name = "colENABLED";
            this.colENABLED.Width = 60;
            // 
            // FrmMessageAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 506);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.DoubleBuffered = true;
            this.Name = "FrmMessageAdmin";
            this.Text = "消息管理";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).EndInit();
            this.tcRole.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSendMessage;
        private System.Windows.Forms.ToolStripButton btnBroadcastMessage;
        private System.Windows.Forms.ToolStripButton btnDeleteMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.ImageList imgList;
        private DevComponents.DotNetBar.TabItem tabItemOrganize;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.TabControl tcRole;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.Panel panel5;
        private Controls.UcPagerEx ucPager;
        private Controls.UcDataGridView dgvList;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private System.Windows.Forms.ToolStripButton btnRefreash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnReadMessage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFUNCTIONCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCATEGORYCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTITLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSGCONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRECEIVERREALNAME;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colISNEW;
        private System.Windows.Forms.DataGridViewTextBoxColumn colREADCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colREADDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIPADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCREATEBY;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colENABLED;
    }
}