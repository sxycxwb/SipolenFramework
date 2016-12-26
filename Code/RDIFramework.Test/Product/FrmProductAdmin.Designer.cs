namespace RDIFramework.Test
{
    partial class FrmProductAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tsProductAdmin = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboProductCategory = new System.Windows.Forms.ToolStripComboBox();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnAddToTab = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDisannul = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnRefreash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvProductInfo = new RDIFramework.Controls.UcDataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProductModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WholesalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromotionPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceCoefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditToTab = new System.Windows.Forms.ToolStripButton();
            this.pnlTop.SuspendLayout();
            this.tsProductAdmin.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Info;
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(991, 49);
            this.pnlTop.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(206, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "产品管理";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "RDIFramework.NET【实例】 ";
            // 
            // tsProductAdmin
            // 
            this.tsProductAdmin.Font = new System.Drawing.Font("宋体", 10.5F);
            this.tsProductAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboProductCategory,
            this.btnAdd,
            this.btnAddToTab,
            this.btnEditToTab,
            this.btnEdit,
            this.btnDisannul,
            this.btnPrint,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnFind,
            this.btnRefreash,
            this.toolStripSeparator2,
            this.btnClose,
            this.toolStripButton1,
            this.toolStripButton2});
            this.tsProductAdmin.Location = new System.Drawing.Point(0, 49);
            this.tsProductAdmin.Name = "tsProductAdmin";
            this.tsProductAdmin.Size = new System.Drawing.Size(991, 25);
            this.tsProductAdmin.TabIndex = 1;
            this.tsProductAdmin.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel1.Text = "产品类别：";
            // 
            // cboProductCategory
            // 
            this.cboProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductCategory.Name = "cboProductCategory";
            this.cboProductCategory.Size = new System.Drawing.Size(121, 25);
            this.cboProductCategory.SelectedIndexChanged += new System.EventHandler(this.cboProductCategory_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 22);
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.ToolTipText = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddToTab
            // 
            this.btnAddToTab.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToTab.Image")));
            this.btnAddToTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddToTab.Name = "btnAddToTab";
            this.btnAddToTab.Size = new System.Drawing.Size(90, 22);
            this.btnAddToTab.Text = "Tab中增加";
            this.btnAddToTab.Click += new System.EventHandler(this.btnAddToTab_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(76, 22);
            this.btnEdit.Text = "编辑(&E)";
            this.btnEdit.ToolTipText = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDisannul
            // 
            this.btnDisannul.Image = ((System.Drawing.Image)(resources.GetObject("btnDisannul.Image")));
            this.btnDisannul.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisannul.Name = "btnDisannul";
            this.btnDisannul.Size = new System.Drawing.Size(55, 22);
            this.btnDisannul.Text = "作废";
            this.btnDisannul.Click += new System.EventHandler(this.btnDisannul_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(55, 22);
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.ToolTipText = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFind
            // 
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(76, 22);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.ToolTipText = "查找";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnRefreash
            // 
            this.btnRefreash.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreash.Image")));
            this.btnRefreash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Size = new System.Drawing.Size(76, 22);
            this.btnRefreash.Text = "刷新(&R)";
            this.btnRefreash.ToolTipText = "刷新";
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.ToolTipText = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(67, 18);
            this.toolStripButton2.Text = "事务测试";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.ucPager);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 468);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(991, 31);
            this.pnlBottom.TabIndex = 2;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(474, 3);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(514, 23);
            this.ucPager.TabIndex = 2;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvProductInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 74);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(991, 394);
            this.pnlMain.TabIndex = 3;
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.AllowUserToAddRows = false;
            this.dgvProductInfo.AllowUserToDeleteRows = false;
            this.dgvProductInfo.AllowUserToOrderColumns = true;
            this.dgvProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvProductInfo.ColumnHeadersHeight = 26;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ProductCode,
            this.ProductName,
            this.ProductCategory,
            this.Enabled,
            this.ProductModel,
            this.ProductStandard,
            this.ProductUnit,
            this.ProductPrice,
            this.WholesalePrice,
            this.PromotionPrice,
            this.InternalPrice,
            this.SpecialPrice,
            this.MiddleRate,
            this.ReferenceCoefficient,
            this.ProductDescription});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductInfo.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductInfo.EnableHeadersVisualStyles = false;
            this.dgvProductInfo.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvProductInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvProductInfo.RowHeadersWidth = 30;
            this.dgvProductInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductInfo.Size = new System.Drawing.Size(991, 394);
            this.dgvProductInfo.TabIndex = 5;
            this.dgvProductInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvProductInfo_KeyPress);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // ProductCode
            // 
            this.ProductCode.DataPropertyName = "ProductCode";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ProductCode.DefaultCellStyle = dataGridViewCellStyle13;
            this.ProductCode.Frozen = true;
            this.ProductCode.HeaderText = "商品编码";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.Frozen = true;
            this.ProductName.HeaderText = "名称";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 120;
            // 
            // ProductCategory
            // 
            this.ProductCategory.DataPropertyName = "ProductCategory";
            this.ProductCategory.Frozen = true;
            this.ProductCategory.HeaderText = "类别";
            this.ProductCategory.Name = "ProductCategory";
            // 
            // Enabled
            // 
            this.Enabled.DataPropertyName = "Enabled";
            this.Enabled.Frozen = true;
            this.Enabled.HeaderText = "作废";
            this.Enabled.Name = "Enabled";
            this.Enabled.Width = 45;
            // 
            // ProductModel
            // 
            this.ProductModel.DataPropertyName = "ProductModel";
            this.ProductModel.HeaderText = "型号";
            this.ProductModel.Name = "ProductModel";
            this.ProductModel.Width = 150;
            // 
            // ProductStandard
            // 
            this.ProductStandard.DataPropertyName = "ProductStandard";
            this.ProductStandard.HeaderText = "规格";
            this.ProductStandard.Name = "ProductStandard";
            // 
            // ProductUnit
            // 
            this.ProductUnit.DataPropertyName = "ProductUnit";
            this.ProductUnit.HeaderText = "单位";
            this.ProductUnit.Name = "ProductUnit";
            // 
            // ProductPrice
            // 
            this.ProductPrice.DataPropertyName = "ProductPrice";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "C2";
            dataGridViewCellStyle14.NullValue = null;
            this.ProductPrice.DefaultCellStyle = dataGridViewCellStyle14;
            this.ProductPrice.HeaderText = "单价";
            this.ProductPrice.Name = "ProductPrice";
            // 
            // WholesalePrice
            // 
            this.WholesalePrice.DataPropertyName = "WholesalePrice";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "C2";
            dataGridViewCellStyle15.NullValue = null;
            this.WholesalePrice.DefaultCellStyle = dataGridViewCellStyle15;
            this.WholesalePrice.HeaderText = "批发价";
            this.WholesalePrice.Name = "WholesalePrice";
            // 
            // PromotionPrice
            // 
            this.PromotionPrice.DataPropertyName = "PromotionPrice";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "C2";
            dataGridViewCellStyle16.NullValue = null;
            this.PromotionPrice.DefaultCellStyle = dataGridViewCellStyle16;
            this.PromotionPrice.HeaderText = "促销价";
            this.PromotionPrice.Name = "PromotionPrice";
            // 
            // InternalPrice
            // 
            this.InternalPrice.DataPropertyName = "InternalPrice";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C2";
            dataGridViewCellStyle17.NullValue = null;
            this.InternalPrice.DefaultCellStyle = dataGridViewCellStyle17;
            this.InternalPrice.HeaderText = "内部价";
            this.InternalPrice.Name = "InternalPrice";
            // 
            // SpecialPrice
            // 
            this.SpecialPrice.DataPropertyName = "SpecialPrice";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = null;
            this.SpecialPrice.DefaultCellStyle = dataGridViewCellStyle18;
            this.SpecialPrice.HeaderText = "特别价";
            this.SpecialPrice.Name = "SpecialPrice";
            // 
            // MiddleRate
            // 
            this.MiddleRate.DataPropertyName = "MiddleRate";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "C2";
            dataGridViewCellStyle19.NullValue = null;
            this.MiddleRate.DefaultCellStyle = dataGridViewCellStyle19;
            this.MiddleRate.HeaderText = "基准价";
            this.MiddleRate.Name = "MiddleRate";
            // 
            // ReferenceCoefficient
            // 
            this.ReferenceCoefficient.DataPropertyName = "ReferenceCoefficient";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ReferenceCoefficient.DefaultCellStyle = dataGridViewCellStyle20;
            this.ReferenceCoefficient.HeaderText = "基准系数";
            this.ReferenceCoefficient.Name = "ReferenceCoefficient";
            // 
            // ProductDescription
            // 
            this.ProductDescription.DataPropertyName = "ProductDescription";
            this.ProductDescription.HeaderText = "产品描述";
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.Width = 230;
            // 
            // btnEditToTab
            // 
            this.btnEditToTab.Image = ((System.Drawing.Image)(resources.GetObject("btnEditToTab.Image")));
            this.btnEditToTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditToTab.Name = "btnEditToTab";
            this.btnEditToTab.Size = new System.Drawing.Size(90, 22);
            this.btnEditToTab.Text = "Tab中修改";
            this.btnEditToTab.Click += new System.EventHandler(this.btnEditToTab_Click);
            // 
            // FrmProductAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 499);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.tsProductAdmin);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Name = "FrmProductAdmin";
            this.Text = "产品管理";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tsProductAdmin.ResumeLayout(false);
            this.tsProductAdmin.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStrip tsProductAdmin;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDisannul;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboProductCategory;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnRefreash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private Controls.UcDataGridView dgvProductInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private Controls.UcPagerEx ucPager;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Enabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WholesalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromotionPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceCoefficient;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
        private System.Windows.Forms.ToolStripButton btnAddToTab;
        private System.Windows.Forms.ToolStripButton btnEditToTab;
    }
}