namespace CRM
{
    partial class FrmIncomingCallAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIncomingCallAdmin));
            this.tabCustomerClass = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.rbCustomerLikeSearch = new System.Windows.Forms.RadioButton();
            this.rbCustomerExactSearch = new System.Windows.Forms.RadioButton();
            this.expandablePanel2 = new DevComponents.DotNetBar.ExpandablePanel();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.rbCooperate = new System.Windows.Forms.RadioButton();
            this.rbComplain = new System.Windows.Forms.RadioButton();
            this.rbAfterService = new System.Windows.Forms.RadioButton();
            this.rbSalesOpp = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvInfo = new RDIFramework.Controls.UcDataGridView();
            this.colLinkManId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Handled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbHandled = new System.Windows.Forms.RadioButton();
            this.rbNotHandled = new System.Windows.Forms.RadioButton();
            this.txtCustomSearchValue = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerClass)).BeginInit();
            this.tabCustomerClass.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.expandablePanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCustomerClass
            // 
            this.tabCustomerClass.BackColor = System.Drawing.SystemColors.Window;
            this.tabCustomerClass.CanReorderTabs = true;
            this.tabCustomerClass.Controls.Add(this.tabControlPanel3);
            this.tabCustomerClass.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabCustomerClass.Location = new System.Drawing.Point(0, 0);
            this.tabCustomerClass.Name = "tabCustomerClass";
            this.tabCustomerClass.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabCustomerClass.SelectedTabIndex = 0;
            this.tabCustomerClass.Size = new System.Drawing.Size(198, 526);
            this.tabCustomerClass.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabCustomerClass.TabIndex = 3;
            this.tabCustomerClass.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabCustomerClass.Tabs.Add(this.tabItem3);
            this.tabCustomerClass.Text = "tabControl2";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 499);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel3);
            this.gbCustomSearch.Controls.Add(this.expandablePanel2);
            this.gbCustomSearch.Controls.Add(this.panel2);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 489);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "来电常规搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.rbCustomerLikeSearch);
            this.panel3.Controls.Add(this.rbCustomerExactSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 65);
            this.panel3.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::CRM.Properties.Resources.find;
            this.btnSearch.Location = new System.Drawing.Point(84, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rbCustomerLikeSearch
            // 
            this.rbCustomerLikeSearch.AutoSize = true;
            this.rbCustomerLikeSearch.Checked = true;
            this.rbCustomerLikeSearch.Location = new System.Drawing.Point(12, 36);
            this.rbCustomerLikeSearch.Name = "rbCustomerLikeSearch";
            this.rbCustomerLikeSearch.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerLikeSearch.TabIndex = 12;
            this.rbCustomerLikeSearch.TabStop = true;
            this.rbCustomerLikeSearch.Text = "模糊";
            this.rbCustomerLikeSearch.UseVisualStyleBackColor = true;
            // 
            // rbCustomerExactSearch
            // 
            this.rbCustomerExactSearch.AutoSize = true;
            this.rbCustomerExactSearch.Location = new System.Drawing.Point(12, 12);
            this.rbCustomerExactSearch.Name = "rbCustomerExactSearch";
            this.rbCustomerExactSearch.Size = new System.Drawing.Size(53, 18);
            this.rbCustomerExactSearch.TabIndex = 11;
            this.rbCustomerExactSearch.Text = "精确";
            this.rbCustomerExactSearch.UseVisualStyleBackColor = true;
            // 
            // expandablePanel2
            // 
            this.expandablePanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel2.Controls.Add(this.rbOther);
            this.expandablePanel2.Controls.Add(this.rbCooperate);
            this.expandablePanel2.Controls.Add(this.rbComplain);
            this.expandablePanel2.Controls.Add(this.rbAfterService);
            this.expandablePanel2.Controls.Add(this.rbSalesOpp);
            this.expandablePanel2.Controls.Add(this.rbAll);
            this.expandablePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel2.ExpandOnTitleClick = true;
            this.expandablePanel2.Location = new System.Drawing.Point(3, 107);
            this.expandablePanel2.Name = "expandablePanel2";
            this.expandablePanel2.Size = new System.Drawing.Size(182, 172);
            this.expandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel2.Style.GradientAngle = 90;
            this.expandablePanel2.TabIndex = 2;
            this.expandablePanel2.TabStop = true;
            this.expandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel2.TitleStyle.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.TopLeft;
            this.expandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel2.TitleStyle.GradientAngle = 90;
            this.expandablePanel2.TitleText = " 选择搜索范围";
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(16, 144);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(81, 18);
            this.rbOther.TabIndex = 10;
            this.rbOther.Text = "其    他";
            this.rbOther.UseVisualStyleBackColor = true;
            // 
            // rbCooperate
            // 
            this.rbCooperate.AutoSize = true;
            this.rbCooperate.Location = new System.Drawing.Point(16, 120);
            this.rbCooperate.Name = "rbCooperate";
            this.rbCooperate.Size = new System.Drawing.Size(81, 18);
            this.rbCooperate.TabIndex = 5;
            this.rbCooperate.Text = "合    作";
            this.rbCooperate.UseVisualStyleBackColor = true;
            // 
            // rbComplain
            // 
            this.rbComplain.AutoSize = true;
            this.rbComplain.Location = new System.Drawing.Point(16, 99);
            this.rbComplain.Name = "rbComplain";
            this.rbComplain.Size = new System.Drawing.Size(81, 18);
            this.rbComplain.TabIndex = 4;
            this.rbComplain.Text = "投    诉";
            this.rbComplain.UseVisualStyleBackColor = true;
            // 
            // rbAfterService
            // 
            this.rbAfterService.AutoSize = true;
            this.rbAfterService.Location = new System.Drawing.Point(16, 78);
            this.rbAfterService.Name = "rbAfterService";
            this.rbAfterService.Size = new System.Drawing.Size(81, 18);
            this.rbAfterService.TabIndex = 3;
            this.rbAfterService.Text = "售后服务";
            this.rbAfterService.UseVisualStyleBackColor = true;
            // 
            // rbSalesOpp
            // 
            this.rbSalesOpp.AutoSize = true;
            this.rbSalesOpp.Location = new System.Drawing.Point(16, 57);
            this.rbSalesOpp.Name = "rbSalesOpp";
            this.rbSalesOpp.Size = new System.Drawing.Size(81, 18);
            this.rbSalesOpp.TabIndex = 2;
            this.rbSalesOpp.Text = "销售机会";
            this.rbSalesOpp.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(16, 36);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(81, 18);
            this.rbAll.TabIndex = 1;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "所有来电";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbHandled);
            this.panel2.Controls.Add(this.rbNotHandled);
            this.panel2.Controls.Add(this.txtCustomSearchValue);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 88);
            this.panel2.TabIndex = 3;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "搜索";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 526);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator3,
            this.btnExport,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip2.Location = new System.Drawing.Point(203, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(645, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::CRM.Properties.Resources.add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 22);
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.ToolTipText = "来电登记";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::CRM.Properties.Resources.edit;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(67, 22);
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.ToolTipText = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CRM.Properties.Resources.del;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(67, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.ToolTipText = "删除来电";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(49, 22);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CRM.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(203, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(645, 501);
            this.pnlMain.TabIndex = 6;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToOrderColumns = true;
            this.dgvInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInfo.ColumnHeadersHeight = 26;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLinkManId,
            this.CustomerId,
            this.Handled,
            this.CustomerName,
            this.CallDate,
            this.CallType,
            this.CallNumber,
            this.CallRecord});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EnableHeadersVisualStyles = false;
            this.dgvInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInfo.RowHeadersWidth = 30;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.RowTemplate.Height = 23;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInfo.Size = new System.Drawing.Size(645, 501);
            this.dgvInfo.TabIndex = 2;
            // 
            // colLinkManId
            // 
            this.colLinkManId.DataPropertyName = "Id";
            this.colLinkManId.Frozen = true;
            this.colLinkManId.HeaderText = "Id";
            this.colLinkManId.Name = "colLinkManId";
            this.colLinkManId.ReadOnly = true;
            this.colLinkManId.Visible = false;
            this.colLinkManId.Width = 75;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.Frozen = true;
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            // 
            // Handled
            // 
            this.Handled.DataPropertyName = "Handled";
            this.Handled.Frozen = true;
            this.Handled.HeaderText = "是否处理";
            this.Handled.Name = "Handled";
            this.Handled.ReadOnly = true;
            this.Handled.Width = 70;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.Frozen = true;
            this.CustomerName.HeaderText = "客户名称";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 170;
            // 
            // CallDate
            // 
            this.CallDate.DataPropertyName = "CallDate";
            this.CallDate.Frozen = true;
            this.CallDate.HeaderText = "登记日期";
            this.CallDate.Name = "CallDate";
            this.CallDate.ReadOnly = true;
            // 
            // CallType
            // 
            this.CallType.DataPropertyName = "CallType";
            this.CallType.HeaderText = "来电类型";
            this.CallType.Name = "CallType";
            this.CallType.ReadOnly = true;
            this.CallType.Width = 120;
            // 
            // CallNumber
            // 
            this.CallNumber.DataPropertyName = "CallNumber";
            this.CallNumber.HeaderText = "来电号码";
            this.CallNumber.Name = "CallNumber";
            this.CallNumber.ReadOnly = true;
            // 
            // CallRecord
            // 
            this.CallRecord.DataPropertyName = "CallRecord";
            this.CallRecord.HeaderText = "来电内容";
            this.CallRecord.Name = "CallRecord";
            this.CallRecord.ReadOnly = true;
            this.CallRecord.Width = 300;
            // 
            // rbHandled
            // 
            this.rbHandled.AutoSize = true;
            this.rbHandled.Location = new System.Drawing.Point(88, 60);
            this.rbHandled.Name = "rbHandled";
            this.rbHandled.Size = new System.Drawing.Size(67, 18);
            this.rbHandled.TabIndex = 5;
            this.rbHandled.Text = "已处理";
            this.rbHandled.UseVisualStyleBackColor = true;
            // 
            // rbNotHandled
            // 
            this.rbNotHandled.AutoSize = true;
            this.rbNotHandled.Checked = true;
            this.rbNotHandled.Location = new System.Drawing.Point(12, 60);
            this.rbNotHandled.Name = "rbNotHandled";
            this.rbNotHandled.Size = new System.Drawing.Size(67, 18);
            this.rbNotHandled.TabIndex = 4;
            this.rbNotHandled.TabStop = true;
            this.rbNotHandled.Text = "未处理";
            this.rbNotHandled.UseVisualStyleBackColor = true;
            // 
            // txtCustomSearchValue
            // 
            // 
            // 
            // 
            this.txtCustomSearchValue.Border.Class = "TextBoxBorder";
            this.txtCustomSearchValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomSearchValue.FocusHighlightEnabled = true;
            this.txtCustomSearchValue.Location = new System.Drawing.Point(9, 22);
            this.txtCustomSearchValue.Name = "txtCustomSearchValue";
            this.txtCustomSearchValue.SelectedValue = ((object)(resources.GetObject("txtCustomSearchValue.SelectedValue")));
            this.txtCustomSearchValue.Size = new System.Drawing.Size(160, 23);
            this.txtCustomSearchValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "搜索内容：";
            // 
            // FrmIncomingCallAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 526);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabCustomerClass);
            this.Name = "FrmIncomingCallAdmin";
            this.Text = "来电处理";
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerClass)).EndInit();
            this.tabCustomerClass.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.expandablePanel2.ResumeLayout(false);
            this.expandablePanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabCustomerClass;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel3;
        private RDIFramework.Controls.UcButton btnSearch;
        private System.Windows.Forms.RadioButton rbCustomerLikeSearch;
        private System.Windows.Forms.RadioButton rbCustomerExactSearch;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel2;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.RadioButton rbCooperate;
        private System.Windows.Forms.RadioButton rbComplain;
        private System.Windows.Forms.RadioButton rbAfterService;
        private System.Windows.Forms.RadioButton rbSalesOpp;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.Panel pnlMain;
        private RDIFramework.Controls.UcDataGridView dgvInfo;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkManId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Handled;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallRecord;
        private System.Windows.Forms.RadioButton rbHandled;
        private System.Windows.Forms.RadioButton rbNotHandled;
        private RDIFramework.Controls.UcTextBox txtCustomSearchValue;
        private System.Windows.Forms.Label label1;
    }
}