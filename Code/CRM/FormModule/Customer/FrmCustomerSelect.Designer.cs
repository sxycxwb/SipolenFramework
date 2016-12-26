namespace CRM
{
    partial class FrmCustomerSelect
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerSelect));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tabCustomerClass = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvCustomerClass = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnUpLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lvSizeImage = new System.Windows.Forms.ImageList(this.components);
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.tabItem5 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItemContactInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItemCustomerInfo = new DevComponents.DotNetBar.TabItem(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvCustomer = new RDIFramework.Controls.UcDataGridView();
            this.CustomerClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWebAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerClass)).BeginInit();
            this.tabCustomerClass.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tabCustomerClass);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(198, 459);
            this.pnlLeft.TabIndex = 0;
            // 
            // tabCustomerClass
            // 
            this.tabCustomerClass.BackColor = System.Drawing.SystemColors.Window;
            this.tabCustomerClass.CanReorderTabs = true;
            this.tabCustomerClass.Controls.Add(this.tabControlPanel4);
            this.tabCustomerClass.Controls.Add(this.tabControlPanel3);
            this.tabCustomerClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomerClass.Location = new System.Drawing.Point(0, 0);
            this.tabCustomerClass.Name = "tabCustomerClass";
            this.tabCustomerClass.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabCustomerClass.SelectedTabIndex = 0;
            this.tabCustomerClass.Size = new System.Drawing.Size(198, 459);
            this.tabCustomerClass.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabCustomerClass.TabIndex = 2;
            this.tabCustomerClass.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabCustomerClass.Tabs.Add(this.tabItem4);
            this.tabCustomerClass.Tabs.Add(this.tabItem3);
            this.tabCustomerClass.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.tvCustomerClass);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(198, 432);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // tvCustomerClass
            // 
            this.tvCustomerClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvCustomerClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCustomerClass.ImageIndex = 0;
            this.tvCustomerClass.ImageList = this.imageList;
            this.tvCustomerClass.Location = new System.Drawing.Point(1, 1);
            this.tvCustomerClass.Name = "tvCustomerClass";
            this.tvCustomerClass.SelectedImageIndex = 1;
            this.tvCustomerClass.Size = new System.Drawing.Size(196, 430);
            this.tvCustomerClass.TabIndex = 0;
            this.tvCustomerClass.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomerClass_AfterExpand);
            this.tvCustomerClass.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvCustomerClass_BeforeSelect);
            this.tvCustomerClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCustomerClass_AfterSelect);
            this.tvCustomerClass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCustomerClass_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.gif");
            this.imageList.Images.SetKeyName(1, "folderOpen.gif");
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "客户浏览";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 432);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItem3;
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
            this.splitter1.Size = new System.Drawing.Size(5, 459);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUpLevel,
            this.toolStripSeparator2,
            this.btnSelect,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(203, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(504, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnUpLevel
            // 
            this.btnUpLevel.Image = ((System.Drawing.Image)(resources.GetObject("btnUpLevel.Image")));
            this.btnUpLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpLevel.Name = "btnUpLevel";
            this.btnUpLevel.Size = new System.Drawing.Size(55, 22);
            this.btnUpLevel.Text = "上级";
            this.btnUpLevel.Click += new System.EventHandler(this.btnUpLevel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::CRM.Properties.Resources.rename;
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(55, 22);
            this.btnSelect.Text = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::CRM.Properties.Resources.reload;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(76, 22);
            this.btnRefresh.Text = "刷新(&R)";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.btnClose.Size = new System.Drawing.Size(55, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvSizeImage
            // 
            this.lvSizeImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.lvSizeImage.ImageSize = new System.Drawing.Size(1, 20);
            this.lvSizeImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(0, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(660, 25);
            this.miniToolStrip.TabIndex = 0;
            // 
            // tabItem5
            // 
            this.tabItem5.Name = "tabItem5";
            this.tabItem5.Text = "跟进人员";
            // 
            // tabItemContactInfo
            // 
            this.tabItemContactInfo.Name = "tabItemContactInfo";
            this.tabItemContactInfo.Text = "联系人";
            // 
            // tabItemCustomerInfo
            // 
            this.tabItemCustomerInfo.Name = "tabItemCustomerInfo";
            this.tabItemCustomerInfo.Text = "客户信息";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvCustomer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(203, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(504, 434);
            this.pnlMain.TabIndex = 3;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AllowUserToOrderColumns = true;
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.ColumnHeadersHeight = 26;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerClassID,
            this.Id,
            this.colShortName,
            this.colCompany,
            this.colCompanyPhone,
            this.colPostalCode,
            this.colCompanyFax,
            this.colWebAddress,
            this.colCompanyAddress});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.EnableHeadersVisualStyles = false;
            this.dgvCustomer.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomer.RowHeadersWidth = 30;
            this.dgvCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCustomer.RowTemplate.Height = 23;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(504, 434);
            this.dgvCustomer.TabIndex = 1;
            this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
            // 
            // CustomerClassID
            // 
            this.CustomerClassID.DataPropertyName = "CustomerClassID";
            this.CustomerClassID.HeaderText = "CustomerClassID";
            this.CustomerClassID.Name = "CustomerClassID";
            this.CustomerClassID.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // colShortName
            // 
            this.colShortName.DataPropertyName = "ShortName";
            this.colShortName.HeaderText = "客户简称";
            this.colShortName.Name = "colShortName";
            // 
            // colCompany
            // 
            this.colCompany.DataPropertyName = "CompanyName";
            this.colCompany.HeaderText = "公司名称";
            this.colCompany.Name = "colCompany";
            this.colCompany.Width = 130;
            // 
            // colCompanyPhone
            // 
            this.colCompanyPhone.DataPropertyName = "CompanyPhone";
            this.colCompanyPhone.HeaderText = "公司电话";
            this.colCompanyPhone.Name = "colCompanyPhone";
            // 
            // colPostalCode
            // 
            this.colPostalCode.DataPropertyName = "PostalCode";
            this.colPostalCode.HeaderText = "公司邮编";
            this.colPostalCode.Name = "colPostalCode";
            // 
            // colCompanyFax
            // 
            this.colCompanyFax.DataPropertyName = "CompanyFax";
            this.colCompanyFax.HeaderText = "公司传真";
            this.colCompanyFax.Name = "colCompanyFax";
            // 
            // colWebAddress
            // 
            this.colWebAddress.DataPropertyName = "WebAddress";
            this.colWebAddress.HeaderText = "网址";
            this.colWebAddress.Name = "colWebAddress";
            // 
            // colCompanyAddress
            // 
            this.colCompanyAddress.DataPropertyName = "CompanyAddress";
            this.colCompanyAddress.HeaderText = "公司地址";
            this.colCompanyAddress.Name = "colCompanyAddress";
            this.colCompanyAddress.Width = 200;
            // 
            // FrmCustomerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 459);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FrmCustomerSelect";
            this.Text = "我的客户";
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerClass)).EndInit();
            this.tabCustomerClass.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnUpLevel;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabControl tabCustomerClass;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private System.Windows.Forms.TreeView tvCustomerClass;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ImageList lvSizeImage;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private DevComponents.DotNetBar.TabItem tabItem5;
        private DevComponents.DotNetBar.TabItem tabItemContactInfo;
        private DevComponents.DotNetBar.TabItem tabItemCustomerInfo;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pnlMain;
        private RDIFramework.Controls.UcDataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWebAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyAddress;
    }
}

