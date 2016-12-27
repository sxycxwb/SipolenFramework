/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:54:58
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserModulePermissionBatchSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserModulePermissionBatchSet));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.tcModuleList = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvModuleList = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemModuleAccessPermission = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcUserList = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbUserList = new System.Windows.Forms.ListBox();
            this.tabItemUserList = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcModuleList)).BeginInit();
            this.tcModuleList.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUserList)).BeginInit();
            this.tcUserList.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tcModuleList);
            this.gbMain.Controls.Add(this.panel1);
            this.gbMain.Controls.Add(this.tcUserList);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(656, 529);
            this.gbMain.TabIndex = 10;
            this.gbMain.TabStop = false;
            // 
            // tcModuleList
            // 
            this.tcModuleList.BackColor = System.Drawing.SystemColors.Window;
            this.tcModuleList.CanReorderTabs = true;
            this.tcModuleList.Controls.Add(this.tabControlPanel3);
            this.tcModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModuleList.Location = new System.Drawing.Point(225, 19);
            this.tcModuleList.Name = "tcModuleList";
            this.tcModuleList.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcModuleList.SelectedTabIndex = 0;
            this.tcModuleList.Size = new System.Drawing.Size(428, 507);
            this.tcModuleList.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcModuleList.TabIndex = 26;
            this.tcModuleList.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcModuleList.Tabs.Add(this.tabItemModuleAccessPermission);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.tvModuleList);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(428, 480);
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
            this.tvModuleList.Size = new System.Drawing.Size(426, 478);
            this.tvModuleList.TabIndex = 1;
            this.tvModuleList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModuleList_AfterCheck);
            this.tvModuleList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvModuleList_NodeMouseClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "menu1.png");
            this.imgList.Images.SetKeyName(1, "menu2.png");
            // 
            // tabItemModuleAccessPermission
            // 
            this.tabItemModuleAccessPermission.AttachedControl = this.tabControlPanel3;
            this.tabItemModuleAccessPermission.Name = "tabItemModuleAccessPermission";
            this.tabItemModuleAccessPermission.Text = "模块（菜单）访问权限";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(215, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 507);
            this.panel1.TabIndex = 1;
            // 
            // tcUserList
            // 
            this.tcUserList.BackColor = System.Drawing.SystemColors.Window;
            this.tcUserList.CanReorderTabs = true;
            this.tcUserList.Controls.Add(this.tabControlPanel2);
            this.tcUserList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcUserList.Location = new System.Drawing.Point(3, 19);
            this.tcUserList.Name = "tcUserList";
            this.tcUserList.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUserList.SelectedTabIndex = 0;
            this.tcUserList.Size = new System.Drawing.Size(212, 507);
            this.tcUserList.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUserList.TabIndex = 21;
            this.tcUserList.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUserList.Tabs.Add(this.tabItemUserList);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lbUserList);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(212, 480);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemUserList;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // lbUserList
            // 
            this.lbUserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUserList.FormattingEnabled = true;
            this.lbUserList.ItemHeight = 14;
            this.lbUserList.Location = new System.Drawing.Point(1, 1);
            this.lbUserList.Name = "lbUserList";
            this.lbUserList.Size = new System.Drawing.Size(210, 478);
            this.lbUserList.TabIndex = 1;
            this.lbUserList.SelectedIndexChanged += new System.EventHandler(this.lbUserList_SelectedIndexChanged);
            // 
            // tabItemUserList
            // 
            this.tabItemUserList.AttachedControl = this.tabControlPanel2;
            this.tabItemUserList.Name = "tabItemUserList";
            this.tabItemUserList.Text = "用户";
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
            this.tlsTool.Size = new System.Drawing.Size(656, 25);
            this.tlsTool.TabIndex = 18;
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
            this.btnSave.Click += new System.EventHandler(this.btnBatchSave_Click);
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
            // FrmUserModulePermissionBatchSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 554);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmUserModulePermissionBatchSet";
            this.Text = "用户模块（菜单）权限批量设置";
            this.gbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcModuleList)).EndInit();
            this.tcModuleList.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUserList)).EndInit();
            this.tcUserList.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.TabControl tcUserList;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.ListBox lbUserList;
        private DevComponents.DotNetBar.TabItem tabItemUserList;
        private DevComponents.DotNetBar.TabControl tcModuleList;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.TreeView tvModuleList;
        private DevComponents.DotNetBar.TabItem tabItemModuleAccessPermission;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ImageList imgList;
    }
}