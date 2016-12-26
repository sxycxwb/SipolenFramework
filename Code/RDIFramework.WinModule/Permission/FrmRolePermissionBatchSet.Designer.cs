namespace RDIFramework.WinModule
{
    partial class FrmRolePermissionBatchSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolePermissionBatchSet));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcPermissionItem = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemHavePermissionItem = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.tcModule = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.tabItemModuleAccessPermission = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.cklstUser = new System.Windows.Forms.CheckedListBox();
            this.tabItemHaveUsers = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tcRole = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lstRole = new System.Windows.Forms.ListBox();
            this.tabItemRole = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.lblRole = new System.Windows.Forms.ToolStripLabel();
            this.txtRole = new System.Windows.Forms.ToolStripTextBox();
            this.btnFilteringRole = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClearPermission = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcPermissionItem)).BeginInit();
            this.tcPermissionItem.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).BeginInit();
            this.tcModule.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).BeginInit();
            this.tcRole.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1MinSize = 5;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcPermissionItem);
            this.splitContainer1.Panel2.Controls.Add(this.splitter3);
            this.splitContainer1.Panel2.Controls.Add(this.tcModule);
            this.splitContainer1.Panel2.Controls.Add(this.splitter2);
            this.splitContainer1.Panel2.Controls.Add(this.tcUser);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.tcRole);
            this.splitContainer1.Size = new System.Drawing.Size(1050, 600);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 8;
            // 
            // tcPermissionItem
            // 
            this.tcPermissionItem.BackColor = System.Drawing.SystemColors.Window;
            this.tcPermissionItem.CanReorderTabs = true;
            this.tcPermissionItem.Controls.Add(this.tabControlPanel4);
            this.tcPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPermissionItem.Location = new System.Drawing.Point(663, 0);
            this.tcPermissionItem.Name = "tcPermissionItem";
            this.tcPermissionItem.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcPermissionItem.SelectedTabIndex = 0;
            this.tcPermissionItem.Size = new System.Drawing.Size(387, 600);
            this.tcPermissionItem.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcPermissionItem.TabIndex = 27;
            this.tcPermissionItem.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcPermissionItem.Tabs.Add(this.tabItemHavePermissionItem);
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvPermissionItem);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(387, 573);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItemHavePermissionItem;
            this.tabControlPanel4.Text = "归属角色";
            // 
            // tvPermissionItem
            // 
            this.tvPermissionItem.AllowDrop = true;
            this.tvPermissionItem.CheckBoxes = true;
            this.tvPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissionItem.Enabled = false;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imgList;
            this.tvPermissionItem.Location = new System.Drawing.Point(1, 1);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 1;
            this.tvPermissionItem.Size = new System.Drawing.Size(385, 571);
            this.tvPermissionItem.TabIndex = 2;
            this.tvPermissionItem.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissionItem_AfterCheck);
            this.tvPermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPermissionItem_NodeMouseClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "button.png");
            this.imgList.Images.SetKeyName(1, "ok.png");
            this.imgList.Images.SetKeyName(2, "menu1.png");
            this.imgList.Images.SetKeyName(3, "menu2.png");
            // 
            // tabItemHavePermissionItem
            // 
            this.tabItemHavePermissionItem.AttachedControl = this.tabControlPanel4;
            this.tabItemHavePermissionItem.Name = "tabItemHavePermissionItem";
            this.tabItemHavePermissionItem.Text = "拥有操作权限";
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(660, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 600);
            this.splitter3.TabIndex = 29;
            this.splitter3.TabStop = false;
            // 
            // tcModule
            // 
            this.tcModule.BackColor = System.Drawing.SystemColors.Window;
            this.tcModule.CanReorderTabs = true;
            this.tcModule.Controls.Add(this.tabControlPanel3);
            this.tcModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcModule.Location = new System.Drawing.Point(389, 0);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcModule.SelectedTabIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(271, 600);
            this.tcModule.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcModule.TabIndex = 25;
            this.tcModule.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcModule.Tabs.Add(this.tabItemModuleAccessPermission);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.tvModule);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(271, 573);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 1;
            this.tabControlPanel3.TabItem = this.tabItemModuleAccessPermission;
            this.tabControlPanel3.Text = "归属角色";
            // 
            // tvModule
            // 
            this.tvModule.AllowDrop = true;
            this.tvModule.CheckBoxes = true;
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.Enabled = false;
            this.tvModule.ImageIndex = 2;
            this.tvModule.ImageList = this.imgList;
            this.tvModule.Location = new System.Drawing.Point(1, 1);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 3;
            this.tvModule.Size = new System.Drawing.Size(269, 571);
            this.tvModule.TabIndex = 2;
            this.tvModule.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterCheck);
            this.tvModule.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModule_NodeMouseClick);
            // 
            // tabItemModuleAccessPermission
            // 
            this.tabItemModuleAccessPermission.AttachedControl = this.tabControlPanel3;
            this.tabItemModuleAccessPermission.Name = "tabItemModuleAccessPermission";
            this.tabItemModuleAccessPermission.Text = "模块（菜单）访问权限";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(386, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 600);
            this.splitter2.TabIndex = 28;
            this.splitter2.TabStop = false;
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcUser.Location = new System.Drawing.Point(193, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(193, 600);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 20;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemHaveUsers);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.cklstUser);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(193, 573);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemHaveUsers;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // cklstUser
            // 
            this.cklstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstUser.Enabled = false;
            this.cklstUser.FormattingEnabled = true;
            this.cklstUser.Location = new System.Drawing.Point(1, 1);
            this.cklstUser.Name = "cklstUser";
            this.cklstUser.Size = new System.Drawing.Size(191, 571);
            this.cklstUser.TabIndex = 2;
            this.cklstUser.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstUser_ItemCheck);
            // 
            // tabItemHaveUsers
            // 
            this.tabItemHaveUsers.AttachedControl = this.tabControlPanel2;
            this.tabItemHaveUsers.Name = "tabItemHaveUsers";
            this.tabItemHaveUsers.Text = "拥有的用户";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(190, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 600);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // tcRole
            // 
            this.tcRole.BackColor = System.Drawing.SystemColors.Window;
            this.tcRole.CanReorderTabs = true;
            this.tcRole.Controls.Add(this.tabControlPanel1);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcRole.Location = new System.Drawing.Point(0, 0);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcRole.SelectedTabIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(190, 600);
            this.tcRole.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcRole.TabIndex = 23;
            this.tcRole.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcRole.Tabs.Add(this.tabItemRole);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lstRole);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(190, 573);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemRole;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // lstRole
            // 
            this.lstRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRole.FormattingEnabled = true;
            this.lstRole.ItemHeight = 14;
            this.lstRole.Location = new System.Drawing.Point(1, 1);
            this.lstRole.Name = "lstRole";
            this.lstRole.Size = new System.Drawing.Size(188, 571);
            this.lstRole.TabIndex = 2;
            this.lstRole.SelectedIndexChanged += new System.EventHandler(this.lstRole_SelectedIndexChanged);
            // 
            // tabItemRole
            // 
            this.tabItemRole.AttachedControl = this.tabControlPanel1;
            this.tabItemRole.Name = "tabItemRole";
            this.tabItemRole.Text = "角色（用户组）";
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRole,
            this.txtRole,
            this.btnFilteringRole,
            this.toolStripSeparator2,
            this.btnClearPermission,
            this.toolStripSeparator5,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(1050, 25);
            this.tlsTool.TabIndex = 17;
            this.tlsTool.Text = "toolStrip1";
            // 
            // lblRole
            // 
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(76, 22);
            this.lblRole.Text = "角色(&R)：";
            // 
            // txtRole
            // 
            this.txtRole.BackColor = System.Drawing.Color.White;
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(150, 25);
            // 
            // btnFilteringRole
            // 
            this.btnFilteringRole.Image = global::RDIFramework.WinModule.Properties.Resources.filter;
            this.btnFilteringRole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilteringRole.Name = "btnFilteringRole";
            this.btnFilteringRole.Size = new System.Drawing.Size(111, 22);
            this.btnFilteringRole.Text = "过滤角色(&F)";
            this.btnFilteringRole.Click += new System.EventHandler(this.btnFilteringRole_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Image = global::RDIFramework.WinModule.Properties.Resources.清除查询条件;
            this.btnClearPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(111, 22);
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.ToolTipText = "清除权限";
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::RDIFramework.WinModule.Properties.Resources.copy;
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(87, 22);
            this.btnCopy.Text = "复制权限";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Image = global::RDIFramework.WinModule.Properties.Resources.paste;
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(87, 22);
            this.btnPaste.Text = "粘贴权限";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
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
            // FrmRolePermissionBatchSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1050, 625);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmRolePermissionBatchSet";
            this.Text = "角色权限批量设置";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcPermissionItem)).EndInit();
            this.tcPermissionItem.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).EndInit();
            this.tcModule.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).EndInit();
            this.tcRole.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.TabControl tcPermissionItem;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private DevComponents.DotNetBar.TabItem tabItemHavePermissionItem;
        private DevComponents.DotNetBar.TabControl tcModule;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.TreeView tvModule;
        private DevComponents.DotNetBar.TabItem tabItemModuleAccessPermission;
        private DevComponents.DotNetBar.TabControl tcRole;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItemRole;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemHaveUsers;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.CheckedListBox cklstUser;
        private System.Windows.Forms.ListBox lstRole;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripLabel lblRole;
        private System.Windows.Forms.ToolStripTextBox txtRole;
        private System.Windows.Forms.ToolStripButton btnClearPermission;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnFilteringRole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}