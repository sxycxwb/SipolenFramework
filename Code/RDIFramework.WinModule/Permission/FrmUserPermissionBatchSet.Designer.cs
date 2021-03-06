﻿/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:54:59
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserPermissionBatchSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPermissionBatchSet));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcPermissionItem = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvPermissionItem = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.tabItemHavePermissionItem = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.tcModule = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.tabItemModuleAccessPermission = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tcRole = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.cklstRole = new System.Windows.Forms.CheckedListBox();
            this.tabItemRoleList = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.tabItemUser = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.lblUser = new System.Windows.Forms.ToolStripLabel();
            this.txtUserName = new System.Windows.Forms.ToolStripTextBox();
            this.btnFilteringUser = new System.Windows.Forms.ToolStripButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).BeginInit();
            this.tcRole.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.tcRole);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.tcUser);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 665);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 7;
            // 
            // tcPermissionItem
            // 
            this.tcPermissionItem.BackColor = System.Drawing.SystemColors.Window;
            this.tcPermissionItem.CanReorderTabs = true;
            this.tcPermissionItem.Controls.Add(this.tabControlPanel4);
            this.tcPermissionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPermissionItem.Location = new System.Drawing.Point(689, 0);
            this.tcPermissionItem.Name = "tcPermissionItem";
            this.tcPermissionItem.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcPermissionItem.SelectedTabIndex = 0;
            this.tcPermissionItem.Size = new System.Drawing.Size(339, 665);
            this.tcPermissionItem.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcPermissionItem.TabIndex = 27;
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
            this.tabControlPanel4.Size = new System.Drawing.Size(339, 638);
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
            this.tvPermissionItem.HotTracking = true;
            this.tvPermissionItem.ImageIndex = 0;
            this.tvPermissionItem.ImageList = this.imgList;
            this.tvPermissionItem.Location = new System.Drawing.Point(1, 1);
            this.tvPermissionItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tvPermissionItem.Name = "tvPermissionItem";
            this.tvPermissionItem.SelectedImageIndex = 1;
            this.tvPermissionItem.Size = new System.Drawing.Size(337, 636);
            this.tvPermissionItem.TabIndex = 3;
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
            // treeView2
            // 
            this.treeView2.AllowDrop = true;
            this.treeView2.CheckBoxes = true;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Enabled = false;
            this.treeView2.Location = new System.Drawing.Point(1, 1);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(337, 636);
            this.treeView2.TabIndex = 2;
            // 
            // tabItemHavePermissionItem
            // 
            this.tabItemHavePermissionItem.AttachedControl = this.tabControlPanel4;
            this.tabItemHavePermissionItem.Name = "tabItemHavePermissionItem";
            this.tabItemHavePermissionItem.Text = "拥有操作权限";
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(686, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 665);
            this.splitter3.TabIndex = 26;
            this.splitter3.TabStop = false;
            // 
            // tcModule
            // 
            this.tcModule.BackColor = System.Drawing.SystemColors.Window;
            this.tcModule.CanReorderTabs = true;
            this.tcModule.Controls.Add(this.tabControlPanel3);
            this.tcModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcModule.Location = new System.Drawing.Point(371, 0);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcModule.SelectedTabIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(315, 665);
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
            this.tabControlPanel3.Size = new System.Drawing.Size(315, 638);
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
            this.tvModule.Size = new System.Drawing.Size(313, 636);
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
            this.splitter2.Location = new System.Drawing.Point(368, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 665);
            this.splitter2.TabIndex = 24;
            this.splitter2.TabStop = false;
            // 
            // tcRole
            // 
            this.tcRole.BackColor = System.Drawing.SystemColors.Window;
            this.tcRole.CanReorderTabs = true;
            this.tcRole.Controls.Add(this.tabControlPanel1);
            this.tcRole.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcRole.Location = new System.Drawing.Point(172, 0);
            this.tcRole.Name = "tcRole";
            this.tcRole.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcRole.SelectedTabIndex = 0;
            this.tcRole.Size = new System.Drawing.Size(196, 665);
            this.tcRole.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcRole.TabIndex = 23;
            this.tcRole.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcRole.Tabs.Add(this.tabItemRoleList);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.cklstRole);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(196, 638);
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
            // cklstRole
            // 
            this.cklstRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklstRole.Enabled = false;
            this.cklstRole.FormattingEnabled = true;
            this.cklstRole.Location = new System.Drawing.Point(1, 1);
            this.cklstRole.Name = "cklstRole";
            this.cklstRole.Size = new System.Drawing.Size(194, 636);
            this.cklstRole.TabIndex = 1;
            this.cklstRole.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstRole_ItemCheck);
            // 
            // tabItemRoleList
            // 
            this.tabItemRoleList.AttachedControl = this.tabControlPanel1;
            this.tabItemRoleList.Name = "tabItemRoleList";
            this.tabItemRoleList.Text = "归属角色（用户组）";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(169, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 665);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(169, 665);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 20;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemUser);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lstUser);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(169, 638);
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
            // lstUser
            // 
            this.lstUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 14;
            this.lstUser.Location = new System.Drawing.Point(1, 1);
            this.lstUser.Name = "lstUser";
            this.lstUser.Size = new System.Drawing.Size(167, 636);
            this.lstUser.TabIndex = 1;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.lstUser_SelectedIndexChanged);
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
            this.lblUser,
            this.txtUserName,
            this.btnFilteringUser,
            this.toolStripSeparator2,
            this.btnClearPermission,
            this.toolStripSeparator5,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(1028, 25);
            this.tlsTool.TabIndex = 18;
            this.tlsTool.Text = "toolStrip1";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(76, 22);
            this.lblUser.Text = "用户(&U)：";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(150, 25);
            // 
            // btnFilteringUser
            // 
            this.btnFilteringUser.Image = global::RDIFramework.WinModule.Properties.Resources.filter;
            this.btnFilteringUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilteringUser.Name = "btnFilteringUser";
            this.btnFilteringUser.Size = new System.Drawing.Size(111, 22);
            this.btnFilteringUser.Text = "过滤用户(&F)";
            this.btnFilteringUser.Click += new System.EventHandler(this.btnFilteringUser_Click);
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
            // FrmUserPermissionBatchSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 690);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmUserPermissionBatchSet";
            this.Text = "用户权限批量设置";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcPermissionItem)).EndInit();
            this.tcPermissionItem.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).EndInit();
            this.tcModule.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcRole)).EndInit();
            this.tcRole.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.ListBox lstUser;
        private DevComponents.DotNetBar.TabItem tabItemUser;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tcRole;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.CheckedListBox cklstRole;
        private DevComponents.DotNetBar.TabItem tabItemRoleList;
        private System.Windows.Forms.Splitter splitter2;
        private DevComponents.DotNetBar.TabControl tcModule;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.TreeView tvModule;
        private DevComponents.DotNetBar.TabItem tabItemModuleAccessPermission;
        private System.Windows.Forms.Splitter splitter3;
        private DevComponents.DotNetBar.TabControl tcPermissionItem;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.TreeView tvPermissionItem;
        private System.Windows.Forms.TreeView treeView2;
        private DevComponents.DotNetBar.TabItem tabItemHavePermissionItem;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripLabel lblUser;
        private System.Windows.Forms.ToolStripTextBox txtUserName;
        private System.Windows.Forms.ToolStripButton btnFilteringUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClearPermission;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}