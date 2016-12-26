namespace RDIFramework.WinModule
{
    partial class FrmItemsSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemsSelect));
            this.tcOrganize = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvItems = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.tabItemOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlTool = new System.Windows.Forms.ToolStrip();
            this.btnSetNull = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentTvPath = new System.Windows.Forms.Label();
            this.lblCurrentOrganize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tcOrganize)).BeginInit();
            this.tcOrganize.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tlTool.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOrganize
            // 
            this.tcOrganize.BackColor = System.Drawing.SystemColors.Window;
            this.tcOrganize.CanReorderTabs = true;
            this.tcOrganize.Controls.Add(this.tabControlPanel1);
            this.tcOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOrganize.Location = new System.Drawing.Point(5, 65);
            this.tcOrganize.Name = "tcOrganize";
            this.tcOrganize.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcOrganize.SelectedTabIndex = 0;
            this.tcOrganize.Size = new System.Drawing.Size(445, 413);
            this.tcOrganize.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcOrganize.TabIndex = 17;
            this.tcOrganize.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcOrganize.Tabs.Add(this.tabItemOrganize);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.tvItems);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(445, 386);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(242)))), ((int)(((byte)(232)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemOrganize;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // tvItems
            // 
            this.tvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvItems.HotTracking = true;
            this.tvItems.ImageIndex = 0;
            this.tvItems.ImageList = this.imgList;
            this.tvItems.Location = new System.Drawing.Point(1, 1);
            this.tvItems.Name = "tvItems";
            this.tvItems.SelectedImageIndex = 1;
            this.tvItems.Size = new System.Drawing.Size(443, 384);
            this.tvItems.TabIndex = 2;
            this.tvItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvItems_AfterSelect);
            this.tvItems.DoubleClick += new System.EventHandler(this.tvItems_DoubleClick);
            this.tvItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvItems_MouseDown);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "fieldPermission.gif");
            this.imgList.Images.SetKeyName(1, "ok.png");
            // 
            // tabItemOrganize
            // 
            this.tabItemOrganize.AttachedControl = this.tabControlPanel1;
            this.tabItemOrganize.Name = "tabItemOrganize";
            this.tabItemOrganize.Text = "数据字典";
            // 
            // tlTool
            // 
            this.tlTool.AutoSize = false;
            this.tlTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetNull,
            this.btnSelect,
            this.toolStripSeparator6,
            this.btnClose});
            this.tlTool.Location = new System.Drawing.Point(5, 5);
            this.tlTool.Name = "tlTool";
            this.tlTool.Size = new System.Drawing.Size(445, 25);
            this.tlTool.TabIndex = 57;
            this.tlTool.Text = "toolStrip1";
            // 
            // btnSetNull
            // 
            this.btnSetNull.Image = ((System.Drawing.Image)(resources.GetObject("btnSetNull.Image")));
            this.btnSetNull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(81, 22);
            this.btnSetNull.Text = "置空(&R)";
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 22);
            this.btnSelect.Text = "选择(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblCurrentTvPath);
            this.panel1.Controls.Add(this.lblCurrentOrganize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 30);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(445, 35);
            this.panel1.TabIndex = 59;
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
            // lblCurrentOrganize
            // 
            this.lblCurrentOrganize.AutoSize = true;
            this.lblCurrentOrganize.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentOrganize.Font = new System.Drawing.Font("新宋体", 11F);
            this.lblCurrentOrganize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCurrentOrganize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurrentOrganize.Location = new System.Drawing.Point(10, 10);
            this.lblCurrentOrganize.Name = "lblCurrentOrganize";
            this.lblCurrentOrganize.Size = new System.Drawing.Size(111, 15);
            this.lblCurrentOrganize.TabIndex = 0;
            this.lblCurrentOrganize.Text = "   当前所选：";
            // 
            // FrmItemsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 483);
            this.Controls.Add(this.tcOrganize);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlTool);
            this.Name = "FrmItemsSelect";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "选择数据字典";
            ((System.ComponentModel.ISupportInitialize)(this.tcOrganize)).EndInit();
            this.tcOrganize.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tlTool.ResumeLayout(false);
            this.tlTool.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tcOrganize;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItemOrganize;
        private System.Windows.Forms.TreeView tvItems;
        private System.Windows.Forms.ToolStrip tlTool;
        private System.Windows.Forms.ToolStripButton btnSetNull;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCurrentTvPath;
        private System.Windows.Forms.Label lblCurrentOrganize;
        private System.Windows.Forms.ImageList imgList;
    }
}