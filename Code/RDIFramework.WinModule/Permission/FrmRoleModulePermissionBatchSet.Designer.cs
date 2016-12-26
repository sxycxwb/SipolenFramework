/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:54:57
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-19 15:32:25
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmRoleModulePermissionBatchSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoleModulePermissionBatchSet));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.tcModule = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvModuleList = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemModuleList = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcRole = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbRoleList = new System.Windows.Forms.ListBox();
            this.tabItemRoleList = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).BeginInit();
            this.tcModule.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).BeginInit();
            this.tcRole.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tcModule);
            this.gbMain.Controls.Add(this.panel1);
            this.gbMain.Controls.Add(this.tcRole);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(663, 541);
            this.gbMain.TabIndex = 7;
            this.gbMain.TabStop = false;
            // 
            // tcModule
            // 
            this.tcModule.BackColor = System.Drawing.SystemColors.Window;
            this.tcModule.CanReorderTabs = true;
            this.tcModule.Controls.Add(this.tabControlPanel3);
            this.tcModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModule.Location = new System.Drawing.Point(209, 19);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcModule.SelectedTabIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(451, 519);
            this.tcModule.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcModule.TabIndex = 26;
            this.tcModule.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcModule.Tabs.Add(this.tabItemModuleList);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.tvModuleList);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(451, 492);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 1;
            this.tabControlPanel3.TabItem = this.tabItemModuleList;
            this.tabControlPanel3.Text = "归属角色";
            // 
            // tvModuleList
            // 
            this.tvModuleList.AllowDrop = true;
            this.tvModuleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvModuleList.CheckBoxes = true;
            this.tvModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModuleList.Enabled = false;
            this.tvModuleList.ImageIndex = 0;
            this.tvModuleList.ImageList = this.imgList;
            this.tvModuleList.Location = new System.Drawing.Point(1, 1);
            this.tvModuleList.Name = "tvModuleList";
            this.tvModuleList.SelectedImageIndex = 1;
            this.tvModuleList.Size = new System.Drawing.Size(449, 490);
            this.tvModuleList.TabIndex = 1;
            this.tvModuleList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModuleList_AfterCheck);
            this.tvModuleList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModuleListList_NodeMouseClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "menu1.png");
            this.imgList.Images.SetKeyName(1, "menu2.png");
            // 
            // tabItemModuleList
            // 
            this.tabItemModuleList.AttachedControl = this.tabControlPanel3;
            this.tabItemModuleList.Name = "tabItemModuleList";
            this.tabItemModuleList.Text = "模块|菜单访问权限(选中则拥有此权限)";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(199, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 519);
            this.panel1.TabIndex = 1;
            // 
            // tcRole
            // 
            this.tcRole.BackColor = System.Drawing.SystemColors.Window;
            this.tcRole.CanReorderTabs = true;
            this.tcRole.Controls.Add(this.tabControlPanel1);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcRole.Location = new System.Drawing.Point(3, 19);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcRole.SelectedTabIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(196, 519);
            this.tcRole.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcRole.TabIndex = 24;
            this.tcRole.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcRole.Tabs.Add(this.tabItemRoleList);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lbRoleList);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(196, 492);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemRoleList;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // lbRoleList
            // 
            this.lbRoleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbRoleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoleList.FormattingEnabled = true;
            this.lbRoleList.ItemHeight = 14;
            this.lbRoleList.Location = new System.Drawing.Point(1, 1);
            this.lbRoleList.Name = "lbRoleList";
            this.lbRoleList.Size = new System.Drawing.Size(194, 490);
            this.lbRoleList.TabIndex = 1;
            this.lbRoleList.Click += new System.EventHandler(this.lbRoleList_SelectedIndexChanged);
            this.lbRoleList.SelectedIndexChanged += new System.EventHandler(this.lbRoleList_SelectedIndexChanged);
            // 
            // tabItemRoleList
            // 
            this.tabItemRoleList.AttachedControl = this.tabControlPanel1;
            this.tabItemRoleList.Name = "tabItemRoleList";
            this.tabItemRoleList.Text = "角色";
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(663, 25);
            this.tlsTool.TabIndex = 19;
            this.tlsTool.Text = "toolStrip1";
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
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmRoleModulePermissionBatchSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 566);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsTool);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRoleModulePermissionBatchSet";
            this.Text = "角色模块（菜单）权限集中设置";
            this.gbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).EndInit();
            this.tcModule.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).EndInit();
            this.tcRole.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imgList;
        private DevComponents.DotNetBar.TabControl tcRole;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.ListBox lbRoleList;
        private DevComponents.DotNetBar.TabItem tabItemRoleList;
        private DevComponents.DotNetBar.TabControl tcModule;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.TreeView tvModuleList;
        private DevComponents.DotNetBar.TabItem tabItemModuleList;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}