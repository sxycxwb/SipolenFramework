namespace RDIFramework.WinModule
{
    partial class FrmUserResourcePermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserResourcePermission));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClearPermission = new System.Windows.Forms.ToolStripButton();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.tabItemUser = new DevComponents.DotNetBar.TabItem(this.components);
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyPermission = new System.Windows.Forms.ToolStripButton();
            this.btnPastePermission = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabItemTargetResource = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvTargetResource = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuInvertSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tcTargetResource = new DevComponents.DotNetBar.TabControl();
            this.lblPermissionItemName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControlPanel2.SuspendLayout();
            this.tlsTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetResource)).BeginInit();
            this.dgvCMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcTargetResource)).BeginInit();
            this.tcTargetResource.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearPermission
            // 
            this.btnClearPermission.Image = ((System.Drawing.Image)(resources.GetObject("btnClearPermission.Image")));
            this.btnClearPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearPermission.Name = "btnClearPermission";
            this.btnClearPermission.Size = new System.Drawing.Size(111, 22);
            this.btnClearPermission.Text = "清除权限(&C)";
            this.btnClearPermission.ToolTipText = "清除权限";
            this.btnClearPermission.Click += new System.EventHandler(this.btnClearPermission_Click);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lstUser);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(270, 476);
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
            this.lstUser.Size = new System.Drawing.Size(268, 474);
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
            this.btnSave,
            this.toolStripSeparator2,
            this.btnClearPermission,
            this.toolStripSeparator5,
            this.btnCopyPermission,
            this.btnPastePermission,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(773, 25);
            this.tlsTool.TabIndex = 24;
            this.tlsTool.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopyPermission
            // 
            this.btnCopyPermission.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyPermission.Image")));
            this.btnCopyPermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyPermission.Name = "btnCopyPermission";
            this.btnCopyPermission.Size = new System.Drawing.Size(87, 22);
            this.btnCopyPermission.Text = "复制权限";
            this.btnCopyPermission.Click += new System.EventHandler(this.btnCopyPermission_Click);
            // 
            // btnPastePermission
            // 
            this.btnPastePermission.Image = ((System.Drawing.Image)(resources.GetObject("btnPastePermission.Image")));
            this.btnPastePermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPastePermission.Name = "btnPastePermission";
            this.btnPastePermission.Size = new System.Drawing.Size(87, 22);
            this.btnPastePermission.Text = "粘贴权限";
            this.btnPastePermission.Click += new System.EventHandler(this.btnPastePermission_Click);
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
            this.tcUser.Size = new System.Drawing.Size(270, 503);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 19;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemUser);
            // 
            // tabItemTargetResource
            // 
            this.tabItemTargetResource.AttachedControl = this.tabControlPanel1;
            this.tabItemTargetResource.Name = "tabItemTargetResource";
            this.tabItemTargetResource.Text = "目标资源";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.dgvTargetResource);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(503, 476);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemTargetResource;
            this.tabControlPanel1.Text = "归属角色";
            // 
            // dgvTargetResource
            // 
            this.dgvTargetResource.AllowUserToAddRows = false;
            this.dgvTargetResource.AllowUserToDeleteRows = false;
            this.dgvTargetResource.AllowUserToOrderColumns = true;
            this.dgvTargetResource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTargetResource.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTargetResource.ColumnHeadersHeight = 26;
            this.dgvTargetResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTargetResource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colRealName,
            this.colDescription});
            this.dgvTargetResource.ContextMenuStrip = this.dgvCMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTargetResource.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTargetResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTargetResource.EnableHeadersVisualStyles = false;
            this.dgvTargetResource.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTargetResource.Location = new System.Drawing.Point(1, 1);
            this.dgvTargetResource.Name = "dgvTargetResource";
            this.dgvTargetResource.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTargetResource.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTargetResource.RowHeadersWidth = 40;
            this.dgvTargetResource.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTargetResource.RowTemplate.Height = 23;
            this.dgvTargetResource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTargetResource.Size = new System.Drawing.Size(501, 474);
            this.dgvTargetResource.TabIndex = 4;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colRealName
            // 
            this.colRealName.DataPropertyName = "RealName";
            this.colRealName.HeaderText = "名称";
            this.colRealName.Name = "colRealName";
            this.colRealName.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 205;
            // 
            // dgvCMenu
            // 
            this.dgvCMenu.Font = new System.Drawing.Font("宋体", 10F);
            this.dgvCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuSelectAll,
            this.cmnuInvertSelect});
            this.dgvCMenu.Name = "dgvCMenu";
            this.dgvCMenu.Size = new System.Drawing.Size(103, 48);
            // 
            // cmnuSelectAll
            // 
            this.cmnuSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("cmnuSelectAll.Image")));
            this.cmnuSelectAll.Name = "cmnuSelectAll";
            this.cmnuSelectAll.Size = new System.Drawing.Size(102, 22);
            this.cmnuSelectAll.Text = "全选";
            this.cmnuSelectAll.Click += new System.EventHandler(this.cmnuSelectAll_Click);
            // 
            // cmnuInvertSelect
            // 
            this.cmnuInvertSelect.Image = ((System.Drawing.Image)(resources.GetObject("cmnuInvertSelect.Image")));
            this.cmnuInvertSelect.Name = "cmnuInvertSelect";
            this.cmnuInvertSelect.Size = new System.Drawing.Size(152, 22);
            this.cmnuInvertSelect.Text = "反选";
            this.cmnuInvertSelect.Click += new System.EventHandler(this.cmnuInvertSelect_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 35);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(773, 503);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.tcTargetResource);
            this.panel1.Controls.Add(this.tcUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 503);
            this.panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(270, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 503);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // tcTargetResource
            // 
            this.tcTargetResource.BackColor = System.Drawing.SystemColors.Window;
            this.tcTargetResource.CanReorderTabs = true;
            this.tcTargetResource.Controls.Add(this.tabControlPanel1);
            this.tcTargetResource.Controls.Add(this.lblPermissionItemName);
            this.tcTargetResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTargetResource.Location = new System.Drawing.Point(270, 0);
            this.tcTargetResource.Name = "tcTargetResource";
            this.tcTargetResource.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcTargetResource.SelectedTabIndex = 0;
            this.tcTargetResource.Size = new System.Drawing.Size(503, 503);
            this.tcTargetResource.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcTargetResource.TabIndex = 20;
            this.tcTargetResource.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcTargetResource.Tabs.Add(this.tabItemTargetResource);
            // 
            // lblPermissionItemName
            // 
            this.lblPermissionItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPermissionItemName.AutoSize = true;
            this.lblPermissionItemName.Location = new System.Drawing.Point(319, 6);
            this.lblPermissionItemName.Name = "lblPermissionItemName";
            this.lblPermissionItemName.Size = new System.Drawing.Size(161, 14);
            this.lblPermissionItemName.TabIndex = 2;
            this.lblPermissionItemName.Text = "操作权限：资源管理权限";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(773, 10);
            this.panel2.TabIndex = 25;
            // 
            // FrmUserResourcePermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmUserResourcePermission";
            this.Text = "用户资源权限设置";
            this.tabControlPanel2.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetResource)).EndInit();
            this.dgvCMenu.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcTargetResource)).EndInit();
            this.tcTargetResource.ResumeLayout(false);
            this.tcTargetResource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnClearPermission;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.ListBox lstUser;
        private DevComponents.DotNetBar.TabItem tabItemUser;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCopyPermission;
        private System.Windows.Forms.ToolStripButton btnPastePermission;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabItem tabItemTargetResource;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tcTargetResource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblPermissionItemName;
        private Controls.UcDataGridView dgvTargetResource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ContextMenuStrip dgvCMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuInvertSelect;

    }
}