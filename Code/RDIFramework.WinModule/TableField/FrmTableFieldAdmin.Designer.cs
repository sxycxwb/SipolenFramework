namespace RDIFramework.WinModule
{
    partial class FrmTableFieldAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableFieldAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.lblSearch = new System.Windows.Forms.ToolStripLabel();
            this.txtUserOrRole = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBatchSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetTablePermission = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcModule = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.dgvTableFieldList = new RDIFramework.Controls.UcDataGridView();
            this.tabTableFieldList = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.lbTableList = new System.Windows.Forms.ListBox();
            this.tabItemTableList = new DevComponents.DotNetBar.TabItem(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPublic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colColumnDeney = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUseConstraint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsSearchColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsExhibitColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAllowEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAllowDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsTool.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSearch,
            this.txtUserOrRole,
            this.toolStripSeparator5,
            this.btnBatchSave,
            this.toolStripSeparator1,
            this.btnSetTablePermission,
            this.btnExport,
            this.toolStripSeparator2,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(1111, 25);
            this.tlsTool.TabIndex = 19;
            this.tlsTool.Text = "toolStrip1";
            // 
            // lblSearch
            // 
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 22);
            this.lblSearch.Text = "查询：";
            // 
            // txtUserOrRole
            // 
            this.txtUserOrRole.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserOrRole.Name = "txtUserOrRole";
            this.txtUserOrRole.ReadOnly = true;
            this.txtUserOrRole.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Image = global::RDIFramework.WinModule.Properties.Resources.save;
            this.btnBatchSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(81, 22);
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.ToolTipText = "保存";
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSetTablePermission
            // 
            this.btnSetTablePermission.Image = global::RDIFramework.WinModule.Properties.Resources.tableConstraint;
            this.btnSetTablePermission.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetTablePermission.Name = "btnSetTablePermission";
            this.btnSetTablePermission.Size = new System.Drawing.Size(132, 22);
            this.btnSetTablePermission.Text = "设置权限控制表";
            this.btnSetTablePermission.ToolTipText = "设置需要做表（字段）权限控制的数据表";
            this.btnSetTablePermission.Click += new System.EventHandler(this.btnSetTablePermission_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1111, 595);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 20;
            // 
            // tcModule
            // 
            this.tcModule.BackColor = System.Drawing.SystemColors.Window;
            this.tcModule.CanReorderTabs = true;
            this.tcModule.Controls.Add(this.tabControlPanel2);
            this.tcModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModule.Location = new System.Drawing.Point(197, 0);
            this.tcModule.Name = "tcModule";
            this.tcModule.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcModule.SelectedTabIndex = 0;
            this.tcModule.Size = new System.Drawing.Size(914, 595);
            this.tcModule.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcModule.TabIndex = 18;
            this.tcModule.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcModule.Tabs.Add(this.tabTableFieldList);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.dgvTableFieldList);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(914, 568);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabTableFieldList;
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
            this.Id,
            this.colColumnCode,
            this.colDataType,
            this.colColumnName,
            this.colIsPublic,
            this.colColumnAccess,
            this.colColumnEdit,
            this.colColumnDeney,
            this.colUseConstraint,
            this.colIsSearchColumn,
            this.colIsExhibitColumn,
            this.colAllowEdit,
            this.colAllowDelete,
            this.colEnabled,
            this.colDescription});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTableFieldList.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvTableFieldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableFieldList.EnableHeadersVisualStyles = false;
            this.dgvTableFieldList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvTableFieldList.Location = new System.Drawing.Point(1, 1);
            this.dgvTableFieldList.MultiSelect = false;
            this.dgvTableFieldList.Name = "dgvTableFieldList";
            this.dgvTableFieldList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTableFieldList.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTableFieldList.RowHeadersWidth = 35;
            this.dgvTableFieldList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTableFieldList.RowTemplate.Height = 23;
            this.dgvTableFieldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTableFieldList.Size = new System.Drawing.Size(912, 566);
            this.dgvTableFieldList.TabIndex = 9;
            // 
            // tabTableFieldList
            // 
            this.tabTableFieldList.AttachedControl = this.tabControlPanel2;
            this.tabTableFieldList.Name = "tabTableFieldList";
            this.tabTableFieldList.Text = "表字段明细";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(194, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 595);
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
            this.tabControl1.Size = new System.Drawing.Size(194, 595);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControl1.TabIndex = 21;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItemTableList);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.lbTableList);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(194, 568);
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
            // lbTableList
            // 
            this.lbTableList.BackColor = System.Drawing.SystemColors.Info;
            this.lbTableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTableList.FormattingEnabled = true;
            this.lbTableList.HorizontalScrollbar = true;
            this.lbTableList.ItemHeight = 14;
            this.lbTableList.Location = new System.Drawing.Point(1, 1);
            this.lbTableList.Name = "lbTableList";
            this.lbTableList.Size = new System.Drawing.Size(192, 566);
            this.lbTableList.TabIndex = 3;
            this.lbTableList.SelectedIndexChanged += new System.EventHandler(this.lbTableList_SelectedIndexChanged);
            // 
            // tabItemTableList
            // 
            this.tabItemTableList.AttachedControl = this.tabControlPanel3;
            this.tabItemTableList.Name = "tabItemTableList";
            this.tabItemTableList.Text = "数据表";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // colColumnCode
            // 
            this.colColumnCode.DataPropertyName = "ColumnCode";
            this.colColumnCode.Frozen = true;
            this.colColumnCode.HeaderText = "英文名称";
            this.colColumnCode.Name = "colColumnCode";
            this.colColumnCode.ReadOnly = true;
            this.colColumnCode.Width = 130;
            // 
            // colDataType
            // 
            this.colDataType.DataPropertyName = "DataType";
            this.colDataType.Frozen = true;
            this.colDataType.HeaderText = "数据类型";
            this.colDataType.Name = "colDataType";
            this.colDataType.ReadOnly = true;
            this.colDataType.Width = 70;
            // 
            // colColumnName
            // 
            this.colColumnName.DataPropertyName = "ColumnName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colColumnName.Frozen = true;
            this.colColumnName.HeaderText = "中文名称";
            this.colColumnName.Name = "colColumnName";
            this.colColumnName.Width = 130;
            // 
            // colIsPublic
            // 
            this.colIsPublic.DataPropertyName = "IsPublic";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.NullValue = false;
            this.colIsPublic.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIsPublic.FalseValue = "0";
            this.colIsPublic.HeaderText = "公开";
            this.colIsPublic.IndeterminateValue = "0";
            this.colIsPublic.Name = "colIsPublic";
            this.colIsPublic.TrueValue = "1";
            this.colIsPublic.Width = 48;
            // 
            // colColumnAccess
            // 
            this.colColumnAccess.DataPropertyName = "ColumnAccess";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.NullValue = false;
            this.colColumnAccess.DefaultCellStyle = dataGridViewCellStyle4;
            this.colColumnAccess.FalseValue = "0";
            this.colColumnAccess.HeaderText = "访问权限";
            this.colColumnAccess.IndeterminateValue = "0";
            this.colColumnAccess.Name = "colColumnAccess";
            this.colColumnAccess.TrueValue = "1";
            this.colColumnAccess.Width = 70;
            // 
            // colColumnEdit
            // 
            this.colColumnEdit.DataPropertyName = "ColumnEdit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.NullValue = false;
            this.colColumnEdit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colColumnEdit.FalseValue = "0";
            this.colColumnEdit.HeaderText = "编辑权限";
            this.colColumnEdit.IndeterminateValue = "0";
            this.colColumnEdit.Name = "colColumnEdit";
            this.colColumnEdit.TrueValue = "1";
            this.colColumnEdit.Width = 70;
            // 
            // colColumnDeney
            // 
            this.colColumnDeney.DataPropertyName = "ColumnDeney";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.NullValue = false;
            this.colColumnDeney.DefaultCellStyle = dataGridViewCellStyle6;
            this.colColumnDeney.FalseValue = "0";
            this.colColumnDeney.HeaderText = "拒绝访问";
            this.colColumnDeney.IndeterminateValue = "0";
            this.colColumnDeney.Name = "colColumnDeney";
            this.colColumnDeney.TrueValue = "1";
            this.colColumnDeney.Width = 70;
            // 
            // colUseConstraint
            // 
            this.colUseConstraint.DataPropertyName = "UseConstraint";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.NullValue = false;
            this.colUseConstraint.DefaultCellStyle = dataGridViewCellStyle7;
            this.colUseConstraint.FalseValue = "0";
            this.colUseConstraint.HeaderText = "启用约束";
            this.colUseConstraint.IndeterminateValue = "0";
            this.colUseConstraint.Name = "colUseConstraint";
            this.colUseConstraint.TrueValue = "1";
            this.colUseConstraint.Width = 70;
            // 
            // colIsSearchColumn
            // 
            this.colIsSearchColumn.DataPropertyName = "IsSearchColumn";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.NullValue = false;
            this.colIsSearchColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.colIsSearchColumn.FalseValue = "0";
            this.colIsSearchColumn.HeaderText = "查询列";
            this.colIsSearchColumn.IndeterminateValue = "0";
            this.colIsSearchColumn.Name = "colIsSearchColumn";
            this.colIsSearchColumn.TrueValue = "1";
            this.colIsSearchColumn.Width = 55;
            // 
            // colIsExhibitColumn
            // 
            this.colIsExhibitColumn.DataPropertyName = "IsExhibitColumn";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle9.NullValue = false;
            this.colIsExhibitColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.colIsExhibitColumn.FalseValue = "0";
            this.colIsExhibitColumn.HeaderText = "展示列";
            this.colIsExhibitColumn.IndeterminateValue = "0";
            this.colIsExhibitColumn.Name = "colIsExhibitColumn";
            this.colIsExhibitColumn.TrueValue = "1";
            this.colIsExhibitColumn.Width = 55;
            // 
            // colAllowEdit
            // 
            this.colAllowEdit.DataPropertyName = "AllowEdit";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle10.NullValue = false;
            this.colAllowEdit.DefaultCellStyle = dataGridViewCellStyle10;
            this.colAllowEdit.FalseValue = "0";
            this.colAllowEdit.HeaderText = "允许编辑";
            this.colAllowEdit.IndeterminateValue = "0";
            this.colAllowEdit.Name = "colAllowEdit";
            this.colAllowEdit.TrueValue = "1";
            this.colAllowEdit.Width = 70;
            // 
            // colAllowDelete
            // 
            this.colAllowDelete.DataPropertyName = "AllowDelete";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle11.NullValue = false;
            this.colAllowDelete.DefaultCellStyle = dataGridViewCellStyle11;
            this.colAllowDelete.FalseValue = "0";
            this.colAllowDelete.HeaderText = "允许删除";
            this.colAllowDelete.IndeterminateValue = "0";
            this.colAllowDelete.Name = "colAllowDelete";
            this.colAllowDelete.TrueValue = "1";
            this.colAllowDelete.Width = 70;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle12.NullValue = false;
            this.colEnabled.DefaultCellStyle = dataGridViewCellStyle12;
            this.colEnabled.FalseValue = "0";
            this.colEnabled.HeaderText = "可用";
            this.colEnabled.IndeterminateValue = "0";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.TrueValue = "1";
            this.colEnabled.Width = 48;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle13;
            this.colDescription.HeaderText = "描述";
            this.colDescription.Name = "colDescription";
            // 
            // FrmTableFieldAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 620);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tlsTool);
            this.Name = "FrmTableFieldAdmin";
            this.Text = "表（字段）综合管理";
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripLabel lblSearch;
        private System.Windows.Forms.ToolStripTextBox txtUserOrRole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnBatchSave;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.TabControl tcModule;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabTableFieldList;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItemTableList;
        private Controls.UcDataGridView dgvTableFieldList;
        private System.Windows.Forms.ListBox lbTableList;
        private System.Windows.Forms.ToolStripButton btnSetTablePermission;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPublic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colColumnDeney;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colUseConstraint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsSearchColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsExhibitColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAllowEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAllowDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}