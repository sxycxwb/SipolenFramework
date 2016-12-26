namespace RDIFramework.WinModule
{
    partial class FrmTableFieldPermission
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableFieldPermission));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblUserOrRole = new System.Windows.Forms.ToolStripLabel();
            this.txtUserOrRole = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcModule = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvTableFieldList = new RDIFramework.Controls.UcDataGridView();
            this.tabItemTableFieldList = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.cklbTable = new System.Windows.Forms.CheckedListBox();
            this.tabItemTableList = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabTableList = new DevComponents.DotNetBar.TabItem(this.components);
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.colColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnDeney = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).BeginInit();
            this.tcModule.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserOrRole
            // 
            this.lblUserOrRole.Name = "lblUserOrRole";
            this.lblUserOrRole.Size = new System.Drawing.Size(114, 22);
            this.lblUserOrRole.Text = "用户/角色(&U)：";
            // 
            // txtUserOrRole
            // 
            this.txtUserOrRole.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserOrRole.Name = "txtUserOrRole";
            this.txtUserOrRole.ReadOnly = true;
            this.txtUserOrRole.Size = new System.Drawing.Size(150, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Panel1Collapsed = true;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcModule);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(806, 541);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 17;
            // 
            // tcModule
            // 
            this.tcModule.BackColor = System.Drawing.SystemColors.Window;
            this.tcModule.CanReorderTabs = true;
            this.tcModule.Controls.Add(this.tabControlPanel2);
            this.tcModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModule.Location = new System.Drawing.Point(258, 0);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcModule.SelectedTabIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(548, 541);
            this.tcModule.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcModule.TabIndex = 18;
            this.tcModule.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcModule.Tabs.Add(this.tabItemTableFieldList);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvTableFieldList);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(548, 514);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemTableFieldList;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // dgvTableFieldList
            // 
            this.dgvTableFieldList.AllowUserToAddRows = false;
            this.dgvTableFieldList.AllowUserToDeleteRows = false;
            this.dgvTableFieldList.AllowUserToOrderColumns = true;
            this.dgvTableFieldList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableFieldList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTableFieldList.ColumnHeadersHeight = 26;
            this.dgvTableFieldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTableFieldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColumnName,
            this.colIsPublic,
            this.colColumnAccess,
            this.colColumnEdit,
            this.colColumnDeney});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTableFieldList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTableFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableFieldList.EnableHeadersVisualStyles = false;
            this.dgvTableFieldList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTableFieldList.Location = new System.Drawing.Point(1, 1);
            this.dgvTableFieldList.MultiSelect = false;
            this.dgvTableFieldList.Name = "dgvTableFieldList";
            this.dgvTableFieldList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableFieldList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTableFieldList.RowHeadersWidth = 35;
            this.dgvTableFieldList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTableFieldList.RowTemplate.Height = 23;
            this.dgvTableFieldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableFieldList.Size = new System.Drawing.Size(546, 512);
            this.dgvTableFieldList.TabIndex = 9;
            this.dgvTableFieldList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTableFieldList_CellValueChanged);
            // 
            // tabItemTableFieldList
            // 
            this.tabItemTableFieldList.AttachedControl = this.tabControlPanel2;
            this.tabItemTableFieldList.Name = "tabItemTableFieldList";
            this.tabItemTableFieldList.Text = "表字段明细";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(255, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 541);
            this.splitter1.TabIndex = 22;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.Window;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(255, 541);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControl1.TabIndex = 21;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItemTableList);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.cklbTable);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(255, 514);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 1;
            this.tabControlPanel3.TabItem = this.tabItemTableList;
            this.tabControlPanel3.Text = "归属角色";
            // 
            // cklbTable
            // 
            this.cklbTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklbTable.FormattingEnabled = true;
            this.cklbTable.Location = new System.Drawing.Point(1, 1);
            this.cklbTable.Name = "cklbTable";
            this.cklbTable.Size = new System.Drawing.Size(253, 512);
            this.cklbTable.TabIndex = 3;
            this.cklbTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklbTable_ItemCheck);
            this.cklbTable.SelectedIndexChanged += new System.EventHandler(this.cklbTable_SelectedIndexChanged);
            // 
            // tabItemTableList
            // 
            this.tabItemTableList.AttachedControl = this.tabControlPanel3;
            this.tabItemTableList.Name = "tabItemTableList";
            this.tabItemTableList.Text = "数据表（选中具有访问权限）";
            // 
            // tabTableList
            // 
            this.tabTableList.AttachedControl = this.tabControlPanel2;
            this.tabTableList.Name = "tabTableList";
            this.tabTableList.Text = "数据表（选中则有访问权限）";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "folder.ico");
            this.imgList.Images.SetKeyName(1, "folder_open.ico");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserOrRole,
            this.txtUserOrRole,
            this.toolStripSeparator5,
            this.btnSave,
            this.btnExport,
            this.toolStripSeparator2,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(806, 25);
            this.tlsTool.TabIndex = 18;
            this.tlsTool.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::RDIFramework.WinModule.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.ToolTipText = "保存";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 22);
            this.btnExport.Text = "导出(&E)";
            this.btnExport.ToolTipText = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // colColumnName
            // 
            this.colColumnName.DataPropertyName = "ColumnName";
            this.colColumnName.Frozen = true;
            this.colColumnName.HeaderText = "字段名称";
            this.colColumnName.Name = "colColumnName";
            this.colColumnName.ReadOnly = true;
            this.colColumnName.Width = 150;
            // 
            // colIsPublic
            // 
            this.colIsPublic.DataPropertyName = "IsPublic";
            this.colIsPublic.Frozen = true;
            this.colIsPublic.HeaderText = "公开";
            this.colIsPublic.Name = "colIsPublic";
            this.colIsPublic.ReadOnly = true;
            this.colIsPublic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsPublic.Width = 48;
            // 
            // colColumnAccess
            // 
            this.colColumnAccess.DataPropertyName = "ColumnAccess";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.NullValue = false;
            this.colColumnAccess.DefaultCellStyle = dataGridViewCellStyle2;
            this.colColumnAccess.HeaderText = "列访问权限";
            this.colColumnAccess.Name = "colColumnAccess";
            this.colColumnAccess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colColumnAccess.ToolTipText = "Column.Access";
            this.colColumnAccess.TrueValue = "1";
            // 
            // colColumnEdit
            // 
            this.colColumnEdit.DataPropertyName = "ColumnEdit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.NullValue = false;
            this.colColumnEdit.DefaultCellStyle = dataGridViewCellStyle3;
            this.colColumnEdit.HeaderText = "列编辑权限";
            this.colColumnEdit.Name = "colColumnEdit";
            this.colColumnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colColumnEdit.ToolTipText = "Column.Edit";
            this.colColumnEdit.TrueValue = "1";
            // 
            // colColumnDeney
            // 
            this.colColumnDeney.DataPropertyName = "ColumnDeney";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.NullValue = false;
            this.colColumnDeney.DefaultCellStyle = dataGridViewCellStyle4;
            this.colColumnDeney.HeaderText = "列拒绝访问";
            this.colColumnDeney.Name = "colColumnDeney";
            this.colColumnDeney.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colColumnDeney.ToolTipText = "Column.Deney";
            this.colColumnDeney.TrueValue = "1";
            // 
            // FrmTableFieldPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmTableFieldPermission";
            this.Text = "表字段权限设置";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcModule)).EndInit();
            this.tcModule.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripLabel lblUserOrRole;
        private System.Windows.Forms.ToolStripTextBox txtUserOrRole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.TabControl tcModule;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.ImageList imgList;
        private DevComponents.DotNetBar.TabItem tabItemTableFieldList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabItem tabTableList;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItemTableList;
        private System.Windows.Forms.Splitter splitter1;
        private Controls.UcDataGridView dgvTableFieldList;
        private System.Windows.Forms.CheckedListBox cklbTable;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnDeney;
    }
}