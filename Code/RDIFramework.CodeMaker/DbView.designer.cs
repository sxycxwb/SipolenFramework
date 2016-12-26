﻿namespace RDIFramework.CodeMaker
{
    partial class DbView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbView));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ID", 7, 7);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("table1", 5, 5, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("表", 3, 4, new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点4", 7, 7);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("view1", 6, 6, new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("视图", 3, 4, new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("master", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("127.0.0.1", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("服务器", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.treeImgs = new System.Windows.Forms.ImageList(this.components);
            this.DbTreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adfsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAddServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDisConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.bgwRegServer = new System.ComponentModel.BackgroundWorker();
            this.bgwConnServer = new System.ComponentModel.BackgroundWorker();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.DbTreeContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeImgs
            // 
            this.treeImgs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImgs.ImageStream")));
            this.treeImgs.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImgs.Images.SetKeyName(0, "servers.png");
            this.treeImgs.Images.SetKeyName(1, "server.png");
            this.treeImgs.Images.SetKeyName(2, "db.gif");
            this.treeImgs.Images.SetKeyName(3, "Folderclose.gif");
            this.treeImgs.Images.SetKeyName(4, "Folderopen.gif");
            this.treeImgs.Images.SetKeyName(5, "tab2.gif");
            this.treeImgs.Images.SetKeyName(6, "view.gif");
            this.treeImgs.Images.SetKeyName(7, "fild2.gif");
            this.treeImgs.Images.SetKeyName(8, "sp.gif");
            this.treeImgs.Images.SetKeyName(9, "sp_p.gif");
            // 
            // DbTreeContextMenu
            // 
            this.DbTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加服务器ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.DbTreeContextMenu.Name = "DbTreeContextMenu";
            this.DbTreeContextMenu.Size = new System.Drawing.Size(131, 32);
            // 
            // 添加服务器ToolStripMenuItem
            // 
            this.添加服务器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adfsToolStripMenuItem});
            this.添加服务器ToolStripMenuItem.Name = "添加服务器ToolStripMenuItem";
            this.添加服务器ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.添加服务器ToolStripMenuItem.Text = "添加服务器";
            // 
            // adfsToolStripMenuItem
            // 
            this.adfsToolStripMenuItem.Name = "adfsToolStripMenuItem";
            this.adfsToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.adfsToolStripMenuItem.Text = "adfs";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 6);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStrip1.BackgroundImage")));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddServer,
            this.toolStripSeparator2,
            this.tsbtnConnect,
            this.tsbtnDisConnect,
            this.toolStripSeparator1,
            this.tsbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(171, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAddServer
            // 
            this.tsbtnAddServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAddServer.Image = global::RDIFramework.CodeMaker.Properties.Resources.serverAdd;
            this.tsbtnAddServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAddServer.Name = "tsbtnAddServer";
            this.tsbtnAddServer.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAddServer.Text = "新增服务器注册";
            this.tsbtnAddServer.ToolTipText = "新增服务器注册";
            this.tsbtnAddServer.Click += new System.EventHandler(this.tsbtnAddServer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnConnect
            // 
            this.tsbtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnConnect.Image = global::RDIFramework.CodeMaker.Properties.Resources.serverLink;
            this.tsbtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnect.Name = "tsbtnConnect";
            this.tsbtnConnect.Size = new System.Drawing.Size(23, 22);
            this.tsbtnConnect.Text = "连接服务器";
            this.tsbtnConnect.ToolTipText = "连接服务器";
            this.tsbtnConnect.Click += new System.EventHandler(this.tsbtnConnect_Click);
            // 
            // tsbtnDisConnect
            // 
            this.tsbtnDisConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDisConnect.Image = global::RDIFramework.CodeMaker.Properties.Resources.serverDelete;
            this.tsbtnDisConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDisConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDisConnect.Name = "tsbtnDisConnect";
            this.tsbtnDisConnect.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDisConnect.Text = "断开服务器";
            this.tsbtnDisConnect.ToolTipText = "断开服务器";
            this.tsbtnDisConnect.Click += new System.EventHandler(this.tsbtnDisConnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = global::RDIFramework.CodeMaker.Properties.Resources.refresh;
            this.tsbtnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRefresh.Text = "刷新";
            this.tsbtnRefresh.ToolTipText = "刷新";
            // 
            // bgwRegServer
            // 
            this.bgwRegServer.WorkerReportsProgress = true;
            this.bgwRegServer.WorkerSupportsCancellation = true;
            // 
            // bgwConnServer
            // 
            this.bgwConnServer.WorkerReportsProgress = true;
            this.bgwConnServer.WorkerSupportsCancellation = true;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.ContextMenuStrip = this.DbTreeContextMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.treeImgs;
            this.treeView1.Location = new System.Drawing.Point(0, 25);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 7;
            treeNode1.Name = "ID";
            treeNode1.SelectedImageIndex = 7;
            treeNode1.Text = "ID";
            treeNode2.ImageIndex = 5;
            treeNode2.Name = "table1";
            treeNode2.SelectedImageIndex = 5;
            treeNode2.Text = "table1";
            treeNode3.ImageIndex = 3;
            treeNode3.Name = "表";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.Text = "表";
            treeNode4.ImageIndex = 7;
            treeNode4.Name = "节点4";
            treeNode4.SelectedImageIndex = 7;
            treeNode4.Text = "节点4";
            treeNode5.ImageIndex = 6;
            treeNode5.Name = "view1";
            treeNode5.SelectedImageIndex = 6;
            treeNode5.Text = "view1";
            treeNode6.ImageIndex = 3;
            treeNode6.Name = "视图";
            treeNode6.SelectedImageIndex = 4;
            treeNode6.Text = "视图";
            treeNode7.ImageIndex = 2;
            treeNode7.Name = "master";
            treeNode7.SelectedImageIndex = 2;
            treeNode7.Text = "master";
            treeNode8.ImageIndex = 1;
            treeNode8.Name = "";
            treeNode8.SelectedImageIndex = 1;
            treeNode8.Text = "127.0.0.1";
            treeNode9.ImageIndex = 0;
            treeNode9.Name = "";
            treeNode9.SelectedImageIndex = 0;
            treeNode9.Text = "服务器";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(171, 414);
            this.treeView1.TabIndex = 4;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // DbView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 439);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DbView";
            this.Text = "导航栏";
            this.Load += new System.EventHandler(this.DbView_Load);
            this.DbTreeContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList treeImgs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAddServer;
        private System.Windows.Forms.ToolStripButton tsbtnDisConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnConnect;
        private System.Windows.Forms.ContextMenuStrip DbTreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem 添加服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adfsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.ComponentModel.BackgroundWorker bgwRegServer;
        public System.ComponentModel.BackgroundWorker bgwConnServer;
        public System.Windows.Forms.TreeView treeView1;

    }
}