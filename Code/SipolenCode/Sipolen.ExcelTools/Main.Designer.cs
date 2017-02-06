namespace Sipolen.ExcelTools
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSelectSourceExcel = new System.Windows.Forms.Button();
            this.lbSourceExcelPath = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.cbCountryTemplate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBeginMove = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbEuropeSite = new System.Windows.Forms.RadioButton();
            this.rbAmericaSite = new System.Windows.Forms.RadioButton();
            this.lbCurrencyUnit = new System.Windows.Forms.Label();
            this.lbCurrencyExchangeRate = new System.Windows.Forms.Label();
            this.btnSureConturyTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.txtEANCountryCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEANFactoryCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEANProductCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtShippingWeight = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDeliveryTimeMin = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDeliveryTimeMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSetWorkPath = new System.Windows.Forms.Button();
            this.browse_nodes1 = new System.Windows.Forms.TextBox();
            this.nodeGridView = new RDIFramework.Controls.UcDataGridView();
            this.NodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.browse_nodes2 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectSourceExcel
            // 
            this.btnSelectSourceExcel.Location = new System.Drawing.Point(1307, 25);
            this.btnSelectSourceExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelectSourceExcel.Name = "btnSelectSourceExcel";
            this.btnSelectSourceExcel.Size = new System.Drawing.Size(181, 40);
            this.btnSelectSourceExcel.TabIndex = 0;
            this.btnSelectSourceExcel.Text = "选择平台导出表";
            this.btnSelectSourceExcel.UseVisualStyleBackColor = true;
            this.btnSelectSourceExcel.Click += new System.EventHandler(this.btnSelectSourceExcel_Click);
            // 
            // lbSourceExcelPath
            // 
            this.lbSourceExcelPath.AutoSize = true;
            this.lbSourceExcelPath.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSourceExcelPath.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbSourceExcelPath.Location = new System.Drawing.Point(67, 75);
            this.lbSourceExcelPath.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbSourceExcelPath.Name = "lbSourceExcelPath";
            this.lbSourceExcelPath.Size = new System.Drawing.Size(0, 15);
            this.lbSourceExcelPath.TabIndex = 1;
            this.lbSourceExcelPath.Tag = "";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(533, 116);
            this.cbCountry.Margin = new System.Windows.Forms.Padding(5);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(143, 29);
            this.cbCountry.TabIndex = 2;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // cbCountryTemplate
            // 
            this.cbCountryTemplate.FormattingEnabled = true;
            this.cbCountryTemplate.Location = new System.Drawing.Point(812, 116);
            this.cbCountryTemplate.Margin = new System.Windows.Forms.Padding(5);
            this.cbCountryTemplate.Name = "cbCountryTemplate";
            this.cbCountryTemplate.Size = new System.Drawing.Size(219, 29);
            this.cbCountryTemplate.TabIndex = 3;
            this.cbCountryTemplate.SelectedIndexChanged += new System.EventHandler(this.cbCountryTemplate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(418, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 4;
            this.label2.Tag = "";
            this.label2.Text = "选择国家";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(702, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 5;
            this.label3.Tag = "";
            this.label3.Text = "选择模板";
            // 
            // btnBeginMove
            // 
            this.btnBeginMove.Location = new System.Drawing.Point(60, 699);
            this.btnBeginMove.Margin = new System.Windows.Forms.Padding(5);
            this.btnBeginMove.Name = "btnBeginMove";
            this.btnBeginMove.Size = new System.Drawing.Size(137, 40);
            this.btnBeginMove.TabIndex = 6;
            this.btnBeginMove.Text = "开始移表";
            this.btnBeginMove.UseVisualStyleBackColor = true;
            this.btnBeginMove.Click += new System.EventHandler(this.btnBeginMove_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(56, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 21);
            this.label4.TabIndex = 7;
            this.label4.Tag = "";
            this.label4.Text = "我的工作目录 -->";
            // 
            // txtWorkPath
            // 
            this.txtWorkPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtWorkPath.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtWorkPath.Location = new System.Drawing.Point(304, 30);
            this.txtWorkPath.Margin = new System.Windows.Forms.Padding(5);
            this.txtWorkPath.Name = "txtWorkPath";
            this.txtWorkPath.Size = new System.Drawing.Size(583, 31);
            this.txtWorkPath.TabIndex = 8;
            this.txtWorkPath.Text = "D:\\work\\excel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(56, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 10;
            this.label5.Tag = "";
            this.label5.Text = "选择站点";
            // 
            // rbEuropeSite
            // 
            this.rbEuropeSite.AutoSize = true;
            this.rbEuropeSite.Checked = true;
            this.rbEuropeSite.Location = new System.Drawing.Point(165, 120);
            this.rbEuropeSite.Margin = new System.Windows.Forms.Padding(5);
            this.rbEuropeSite.Name = "rbEuropeSite";
            this.rbEuropeSite.Size = new System.Drawing.Size(98, 25);
            this.rbEuropeSite.TabIndex = 11;
            this.rbEuropeSite.TabStop = true;
            this.rbEuropeSite.Tag = "Europe";
            this.rbEuropeSite.Text = "欧洲站";
            this.rbEuropeSite.UseVisualStyleBackColor = true;
            this.rbEuropeSite.CheckedChanged += new System.EventHandler(this.rbEuropeSite_CheckedChanged);
            // 
            // rbAmericaSite
            // 
            this.rbAmericaSite.AutoSize = true;
            this.rbAmericaSite.Location = new System.Drawing.Point(268, 120);
            this.rbAmericaSite.Margin = new System.Windows.Forms.Padding(5);
            this.rbAmericaSite.Name = "rbAmericaSite";
            this.rbAmericaSite.Size = new System.Drawing.Size(98, 25);
            this.rbAmericaSite.TabIndex = 12;
            this.rbAmericaSite.Tag = "America";
            this.rbAmericaSite.Text = "美洲站";
            this.rbAmericaSite.UseVisualStyleBackColor = true;
            // 
            // lbCurrencyUnit
            // 
            this.lbCurrencyUnit.AutoSize = true;
            this.lbCurrencyUnit.ForeColor = System.Drawing.Color.Blue;
            this.lbCurrencyUnit.Location = new System.Drawing.Point(22, 20);
            this.lbCurrencyUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCurrencyUnit.Name = "lbCurrencyUnit";
            this.lbCurrencyUnit.Size = new System.Drawing.Size(115, 21);
            this.lbCurrencyUnit.TabIndex = 13;
            this.lbCurrencyUnit.Tag = "";
            this.lbCurrencyUnit.Text = "货币单位：";
            // 
            // lbCurrencyExchangeRate
            // 
            this.lbCurrencyExchangeRate.AutoSize = true;
            this.lbCurrencyExchangeRate.ForeColor = System.Drawing.Color.Blue;
            this.lbCurrencyExchangeRate.Location = new System.Drawing.Point(22, 57);
            this.lbCurrencyExchangeRate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCurrencyExchangeRate.Name = "lbCurrencyExchangeRate";
            this.lbCurrencyExchangeRate.Size = new System.Drawing.Size(115, 21);
            this.lbCurrencyExchangeRate.TabIndex = 14;
            this.lbCurrencyExchangeRate.Tag = "";
            this.lbCurrencyExchangeRate.Text = "货币汇率：";
            // 
            // btnSureConturyTemplate
            // 
            this.btnSureConturyTemplate.Location = new System.Drawing.Point(1055, 112);
            this.btnSureConturyTemplate.Margin = new System.Windows.Forms.Padding(5);
            this.btnSureConturyTemplate.Name = "btnSureConturyTemplate";
            this.btnSureConturyTemplate.Size = new System.Drawing.Size(181, 40);
            this.btnSureConturyTemplate.TabIndex = 15;
            this.btnSureConturyTemplate.Text = "确定国家及模板";
            this.btnSureConturyTemplate.UseVisualStyleBackColor = true;
            this.btnSureConturyTemplate.Click += new System.EventHandler(this.btnSureConturyTemplate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(28, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 16;
            this.label1.Tag = "";
            this.label1.Text = "品牌名";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Location = new System.Drawing.Point(112, 41);
            this.txtBrandName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(167, 31);
            this.txtBrandName.TabIndex = 17;
            this.txtBrandName.Text = "sinldo";
            // 
            // txtEANCountryCode
            // 
            this.txtEANCountryCode.Location = new System.Drawing.Point(117, 43);
            this.txtEANCountryCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEANCountryCode.Name = "txtEANCountryCode";
            this.txtEANCountryCode.Size = new System.Drawing.Size(72, 31);
            this.txtEANCountryCode.TabIndex = 19;
            this.txtEANCountryCode.Text = "485";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(11, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 18;
            this.label6.Tag = "";
            this.label6.Text = "EAN13位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(11, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 20;
            this.label7.Tag = "";
            this.label7.Text = "国家代码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(211, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 21);
            this.label8.TabIndex = 22;
            this.label8.Tag = "";
            this.label8.Text = "厂商代码";
            // 
            // txtEANFactoryCode
            // 
            this.txtEANFactoryCode.Location = new System.Drawing.Point(310, 43);
            this.txtEANFactoryCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEANFactoryCode.Name = "txtEANFactoryCode";
            this.txtEANFactoryCode.Size = new System.Drawing.Size(116, 31);
            this.txtEANFactoryCode.TabIndex = 21;
            this.txtEANFactoryCode.Text = "3222";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label9.Location = new System.Drawing.Point(436, 47);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 21);
            this.label9.TabIndex = 24;
            this.label9.Tag = "";
            this.label9.Text = "商品代码";
            // 
            // txtEANProductCode
            // 
            this.txtEANProductCode.Location = new System.Drawing.Point(539, 40);
            this.txtEANProductCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEANProductCode.Name = "txtEANProductCode";
            this.txtEANProductCode.Size = new System.Drawing.Size(156, 31);
            this.txtEANProductCode.TabIndex = 23;
            this.txtEANProductCode.Text = "32221";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtEANCountryCode);
            this.panel1.Controls.Add(this.txtEANProductCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtEANFactoryCode);
            this.panel1.Location = new System.Drawing.Point(61, 184);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 98);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.txtBrandName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(827, 184);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 98);
            this.panel2.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Info;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtShippingWeight);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtDeliveryTimeMin);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtDeliveryTimeMax);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(61, 292);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(738, 77);
            this.panel3.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label15.Location = new System.Drawing.Point(674, 33);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 21);
            this.label15.TabIndex = 26;
            this.label15.Tag = "";
            this.label15.Text = "KG";
            // 
            // txtShippingWeight
            // 
            this.txtShippingWeight.Location = new System.Drawing.Point(604, 29);
            this.txtShippingWeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtShippingWeight.Name = "txtShippingWeight";
            this.txtShippingWeight.Size = new System.Drawing.Size(60, 31);
            this.txtShippingWeight.TabIndex = 25;
            this.txtShippingWeight.Text = "0.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(498, 33);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 21);
            this.label14.TabIndex = 24;
            this.label14.Tag = "";
            this.label14.Text = "商品重量";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(428, 29);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(60, 31);
            this.txtQuantity.TabIndex = 23;
            this.txtQuantity.Text = "30";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label13.Location = new System.Drawing.Point(322, 33);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 21);
            this.label13.TabIndex = 22;
            this.label13.Tag = "";
            this.label13.Text = "库存数量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label12.Location = new System.Drawing.Point(280, 33);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 21);
            this.label12.TabIndex = 21;
            this.label12.Tag = "";
            this.label12.Text = "天";
            // 
            // txtDeliveryTimeMin
            // 
            this.txtDeliveryTimeMin.Location = new System.Drawing.Point(122, 29);
            this.txtDeliveryTimeMin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeliveryTimeMin.Name = "txtDeliveryTimeMin";
            this.txtDeliveryTimeMin.Size = new System.Drawing.Size(60, 31);
            this.txtDeliveryTimeMin.TabIndex = 20;
            this.txtDeliveryTimeMin.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(183, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 21);
            this.label11.TabIndex = 19;
            this.label11.Tag = "";
            this.label11.Text = "-";
            // 
            // txtDeliveryTimeMax
            // 
            this.txtDeliveryTimeMax.Location = new System.Drawing.Point(207, 29);
            this.txtDeliveryTimeMax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeliveryTimeMax.Name = "txtDeliveryTimeMax";
            this.txtDeliveryTimeMax.Size = new System.Drawing.Size(60, 31);
            this.txtDeliveryTimeMax.TabIndex = 18;
            this.txtDeliveryTimeMax.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Location = new System.Drawing.Point(12, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 21);
            this.label10.TabIndex = 16;
            this.label10.Tag = "";
            this.label10.Text = "到货时长";
            // 
            // btnSetWorkPath
            // 
            this.btnSetWorkPath.Location = new System.Drawing.Point(1055, 25);
            this.btnSetWorkPath.Margin = new System.Windows.Forms.Padding(5);
            this.btnSetWorkPath.Name = "btnSetWorkPath";
            this.btnSetWorkPath.Size = new System.Drawing.Size(181, 40);
            this.btnSetWorkPath.TabIndex = 28;
            this.btnSetWorkPath.Text = "设置工作目录";
            this.btnSetWorkPath.UseVisualStyleBackColor = true;
            this.btnSetWorkPath.Click += new System.EventHandler(this.btnSetWorkPath_Click);
            // 
            // browse_nodes1
            // 
            this.browse_nodes1.Location = new System.Drawing.Point(196, 387);
            this.browse_nodes1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browse_nodes1.Name = "browse_nodes1";
            this.browse_nodes1.Size = new System.Drawing.Size(287, 31);
            this.browse_nodes1.TabIndex = 18;
            this.browse_nodes1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.browse_nodes1_KeyUp);
            // 
            // nodeGridView
            // 
            this.nodeGridView.AllowUserToOrderColumns = true;
            this.nodeGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeGridView.CheckboxFieldName = "colSelected";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nodeGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.nodeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.nodeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeId,
            this.NodeDesc,
            this.NodeName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nodeGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.nodeGridView.EnableHeadersVisualStyles = false;
            this.nodeGridView.Location = new System.Drawing.Point(60, 422);
            this.nodeGridView.Name = "nodeGridView";
            this.nodeGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nodeGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.nodeGridView.RowHeadersWidth = 25;
            this.nodeGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.nodeGridView.RowTemplate.Height = 30;
            this.nodeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nodeGridView.Size = new System.Drawing.Size(1428, 263);
            this.nodeGridView.TabIndex = 30;
            this.nodeGridView.DoubleClick += new System.EventHandler(this.nodeGridView_DoubleClick);
            // 
            // NodeId
            // 
            this.NodeId.DataPropertyName = "NODEID";
            this.NodeId.HeaderText = "节点ID";
            this.NodeId.Name = "NodeId";
            this.NodeId.Width = 120;
            // 
            // NodeDesc
            // 
            this.NodeDesc.DataPropertyName = "NODEDESC";
            this.NodeDesc.HeaderText = "类别名称";
            this.NodeDesc.Name = "NodeDesc";
            this.NodeDesc.Width = 800;
            // 
            // NodeName
            // 
            this.NodeName.DataPropertyName = "NODENAME";
            this.NodeName.HeaderText = "类别英文";
            this.NodeName.Name = "NodeName";
            this.NodeName.Width = 360;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(60, 394);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 21);
            this.label16.TabIndex = 31;
            this.label16.Tag = "";
            this.label16.Text = "推荐节点1：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label17.Location = new System.Drawing.Point(509, 394);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 21);
            this.label17.TabIndex = 33;
            this.label17.Tag = "";
            this.label17.Text = "推荐节点2：";
            // 
            // browse_nodes2
            // 
            this.browse_nodes2.Location = new System.Drawing.Point(644, 387);
            this.browse_nodes2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browse_nodes2.Name = "browse_nodes2";
            this.browse_nodes2.Size = new System.Drawing.Size(287, 31);
            this.browse_nodes2.TabIndex = 32;
            this.browse_nodes2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.browse_nodes2_KeyUp);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.lbCurrencyUnit);
            this.panel4.Controls.Add(this.lbCurrencyExchangeRate);
            this.panel4.Location = new System.Drawing.Point(1161, 184);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(323, 98);
            this.panel4.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Info;
            this.panel5.Controls.Add(this.cbProductType);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(827, 292);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(657, 77);
            this.panel5.TabIndex = 27;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label18.Location = new System.Drawing.Point(28, 32);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(199, 21);
            this.label18.TabIndex = 16;
            this.label18.Tag = "";
            this.label18.Text = "产品类别（有效值）";
            // 
            // cbProductType
            // 
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(249, 29);
            this.cbProductType.Margin = new System.Windows.Forms.Padding(5);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(263, 29);
            this.cbProductType.TabIndex = 34;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 744);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.browse_nodes2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nodeGridView);
            this.Controls.Add(this.browse_nodes1);
            this.Controls.Add(this.btnSetWorkPath);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSureConturyTemplate);
            this.Controls.Add(this.rbAmericaSite);
            this.Controls.Add(this.rbEuropeSite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWorkPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBeginMove);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCountryTemplate);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.lbSourceExcelPath);
            this.Controls.Add(this.btnSelectSourceExcel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Main";
            this.Text = "思普林国际贸易Excel操作";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSourceExcel;
        private System.Windows.Forms.Label lbSourceExcelPath;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.ComboBox cbCountryTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBeginMove;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWorkPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbEuropeSite;
        private System.Windows.Forms.RadioButton rbAmericaSite;
        private System.Windows.Forms.Label lbCurrencyUnit;
        private System.Windows.Forms.Label lbCurrencyExchangeRate;
        private System.Windows.Forms.Button btnSureConturyTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.TextBox txtEANCountryCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEANFactoryCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEANProductCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDeliveryTimeMax;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDeliveryTimeMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtShippingWeight;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSetWorkPath;
        private System.Windows.Forms.TextBox browse_nodes1;
        private RDIFramework.Controls.UcDataGridView nodeGridView;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox browse_nodes2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.Label label18;
    }
}

