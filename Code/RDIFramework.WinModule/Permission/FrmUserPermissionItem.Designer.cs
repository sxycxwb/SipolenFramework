/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:55:00
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserPermissionItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermissionItem));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.tcPermissionItem = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.tabItemHavePermissionItem = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcUserList = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbUserList = new System.Windows.Forms.ListBox();
            this.tabItemUser = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnClearPermission = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcPermissionItem)).BeginInit();
            this.tcPermissionItem.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUserList)).BeginInit();
            this.tcUserList.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tcPermissionItem);
            this.gbMain.Controls.Add(this.panel1);
            this.gbMain.Controls.Add(this.tcUserList);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(709, 581);
            this.gbMain.TabIndex = 14;
            this.gbMain.TabStop = false;
            // 
            // tcPermissionItem
            // 
            this.tcPermissionItem.BackColor = System.Drawing.SystemColors.Window;
            this.tcPermissionItem.CanReorderTabs = true;
            this.tcPermissionItem.Controls.Add(this.tabControlPanel4);
            this.tcPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPermissionItem.Location = new System.Drawing.Point(237, 19);
            this.tcPermissionItem.Name = "tcPermissionItem";
            this.tcPermissionItem.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcPermissionItem.SelectedTabIndex = 0;
            this.tcPermissionItem.Size = new System.Drawing.Size(469, 559);
            this.tcPermissionItem.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcPermissionItem.TabIndex = 28;
            this.tcPermissionItem.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcPermissionItem.Tabs.Add(this.tabItemHavePermissionItem);
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvPermissionItem);
            this.tabControlPanel4.Controls.Add(this.treeView2);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(469, 532);
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
            this.tvPermissionItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvPermissionItem.CheckBoxes = true;
            this.tvPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPermissionItem.Enabled = false;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imgList;
            this.tvPermissionItem.Location = new System.Drawing.Point(1, 1);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 1;
            this.tvPermissionItem.Size = new System.Drawing.Size(467, 530);
            this.tvPermissionItem.TabIndex = 3;
            this.tvPermissionItem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPermissionItem_AfterCheck);
            this.tvPermissionItem.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPermissionItem_NodeMouseClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "button.png");
            this.imgList.Images.SetKeyName(1, "ok.png");
            // 
            // treeView2
            // 
            this.treeView2.AllowDrop = true;
            this.treeView2.CheckBoxes = true;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Enabled = false;
            this.treeView2.Location = new System.Drawing.Point(1, 1);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(467, 530);
            this.treeView2.TabIndex = 2;
            // 
            // tabItemHavePermissionItem
            // 
            this.tabItemHavePermissionItem.AttachedControl = this.tabControlPanel4;
            this.tabItemHavePermissionItem.Name = "tabItemHavePermissionItem";
            this.tabItemHavePermissionItem.Text = "拥有操作权限";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(227, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 559);
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
            this.tcUserList.Size = new System.Drawing.Size(224, 559);
            this.tcUserList.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUserList.TabIndex = 21;
            this.tcUserList.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUserList.Tabs.Add(this.tabItemUser);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lbUserList);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(224, 532);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemUser;
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
            this.lbUserList.Size = new System.Drawing.Size(222, 530);
            this.lbUserList.TabIndex = 1;
            this.lbUserList.SelectedIndexChanged += new System.EventHandler(this.lbUserList_SelectedIndexChanged);
            // 
            // tabItemUser
            // 
            this.tabItemUser.AttachedControl = this.tabControlPanel2;
            this.tabItemUser.Name = "tabItemUser";
            this.tabItemUser.Text = "用户";
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearPermission,
            this.btnSave,
            this.toolStripSeparator5,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(709, 25);
            this.tlsTool.TabIndex = 18;
            this.tlsTool.Text = "toolStrip1";
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
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.ToolTipText = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            // FrmUserPermissionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 606);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmUserPermissionItem";
            this.Text = "用户权限批量设置";
            this.gbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcPermissionItem)).EndInit();
            this.tcPermissionItem.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
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
        private System.Windows.Forms.ImageList imgList;
        private DevComponents.DotNetBar.TabControl tcUserList;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.ListBox lbUserList;
        private DevComponents.DotNetBar.TabItem tabItemUser;
        private DevComponents.DotNetBar.TabControl tcPermissionItem;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.TreeView treeView2;
        private DevComponents.DotNetBar.TabItem tabItemHavePermissionItem;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnClearPermission;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}