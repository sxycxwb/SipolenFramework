namespace RDIFramework.WinModule
{
    partial class FrmSetTablePermission
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
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnAddAll = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbTableListLeft = new System.Windows.Forms.ListBox();
            this.tabItemToSetTable = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemove = new RDIFramework.Controls.UcButton();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbTableListRight = new System.Windows.Forms.ListBox();
            this.tabItemTheSelectedTable = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAll,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(642, 25);
            this.tlsTool.TabIndex = 20;
            this.tlsTool.Text = "toolStrip1";
            // 
            // btnAddAll
            // 
            this.btnAddAll.Image = global::RDIFramework.WinModule.Properties.Resources.add;
            this.btnAddAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(87, 22);
            this.btnAddAll.Text = "添加全部";
            this.btnAddAll.ToolTipText = "保存";
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
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
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.Window;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(258, 330);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControl1.TabIndex = 22;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItemToSetTable);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.lbTableListLeft);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(258, 303);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 1;
            this.tabControlPanel3.TabItem = this.tabItemToSetTable;
            this.tabControlPanel3.Text = "归属角色";
            // 
            // lbTableListLeft
            // 
            this.lbTableListLeft.BackColor = System.Drawing.SystemColors.Info;
            this.lbTableListLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTableListLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTableListLeft.FormattingEnabled = true;
            this.lbTableListLeft.HorizontalScrollbar = true;
            this.lbTableListLeft.ItemHeight = 14;
            this.lbTableListLeft.Location = new System.Drawing.Point(1, 1);
            this.lbTableListLeft.Name = "lbTableListLeft";
            this.lbTableListLeft.Size = new System.Drawing.Size(256, 301);
            this.lbTableListLeft.TabIndex = 3;
            this.lbTableListLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTableListLeft_MouseDoubleClick);
            // 
            // tabItemToSetTable
            // 
            this.tabItemToSetTable.AttachedControl = this.tabControlPanel3;
            this.tabItemToSetTable.Name = "tabItemToSetTable";
            this.tabItemToSetTable.Text = "待设数据表";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(258, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 330);
            this.splitter1.TabIndex = 23;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(261, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(104, 330);
            this.panel1.TabIndex = 24;
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemove.Location = new System.Drawing.Point(6, 171);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(92, 28);
            this.btnRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "<--删除(&R)";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(6, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 28);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加(&A)-->";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(365, 25);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 330);
            this.splitter2.TabIndex = 25;
            this.splitter2.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.SystemColors.Window;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(368, 25);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(274, 330);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControl2.TabIndex = 26;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItemTheSelectedTable);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lbTableListRight);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(274, 303);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemTheSelectedTable;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // lbTableListRight
            // 
            this.lbTableListRight.BackColor = System.Drawing.SystemColors.Info;
            this.lbTableListRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTableListRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTableListRight.FormattingEnabled = true;
            this.lbTableListRight.HorizontalScrollbar = true;
            this.lbTableListRight.ItemHeight = 14;
            this.lbTableListRight.Location = new System.Drawing.Point(1, 1);
            this.lbTableListRight.Name = "lbTableListRight";
            this.lbTableListRight.Size = new System.Drawing.Size(272, 301);
            this.lbTableListRight.TabIndex = 3;
            this.lbTableListRight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTableListRight_MouseDoubleClick);
            // 
            // tabItemTheSelectedTable
            // 
            this.tabItemTheSelectedTable.AttachedControl = this.tabControlPanel1;
            this.tabItemTheSelectedTable.Name = "tabItemTheSelectedTable";
            this.tabItemTheSelectedTable.Text = "已选数据表";
            // 
            // FrmSetTablePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 355);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmSetTablePermission";
            this.Text = "设置需要做表权限控制的数据表";
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnAddAll;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.ListBox lbTableListLeft;
        private DevComponents.DotNetBar.TabItem tabItemToSetTable;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter2;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.ListBox lbTableListRight;
        private DevComponents.DotNetBar.TabItem tabItemTheSelectedTable;
        private Controls.UcButton btnAdd;
        private Controls.UcButton btnRemove;

    }
}