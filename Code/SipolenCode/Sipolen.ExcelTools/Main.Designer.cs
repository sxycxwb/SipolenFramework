﻿namespace Sipolen.ExcelTools
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
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.browse_nodes2 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.btnKeyWordStatistics = new System.Windows.Forms.Button();
            this.cmbKeyWordStyle = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtKeyWordPath = new System.Windows.Forms.Label();
            this.txtKeyWordInfo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectSourceExcel
            // 
            this.btnSelectSourceExcel.Location = new System.Drawing.Point(832, 17);
            this.btnSelectSourceExcel.Name = "btnSelectSourceExcel";
            this.btnSelectSourceExcel.Size = new System.Drawing.Size(115, 27);
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
            this.lbSourceExcelPath.Location = new System.Drawing.Point(43, 50);
            this.lbSourceExcelPath.Name = "lbSourceExcelPath";
            this.lbSourceExcelPath.Size = new System.Drawing.Size(0, 10);
            this.lbSourceExcelPath.TabIndex = 1;
            this.lbSourceExcelPath.Tag = "";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(339, 77);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(92, 22);
            this.cbCountry.TabIndex = 2;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // cbCountryTemplate
            // 
            this.cbCountryTemplate.FormattingEnabled = true;
            this.cbCountryTemplate.Location = new System.Drawing.Point(517, 77);
            this.cbCountryTemplate.Name = "cbCountryTemplate";
            this.cbCountryTemplate.Size = new System.Drawing.Size(141, 22);
            this.cbCountryTemplate.TabIndex = 3;
            this.cbCountryTemplate.SelectedIndexChanged += new System.EventHandler(this.cbCountryTemplate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(266, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 4;
            this.label2.Tag = "";
            this.label2.Text = "选择国家";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(447, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Tag = "";
            this.label3.Text = "选择模板";
            // 
            // btnBeginMove
            // 
            this.btnBeginMove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBeginMove.ForeColor = System.Drawing.Color.Red;
            this.btnBeginMove.Location = new System.Drawing.Point(860, 387);
            this.btnBeginMove.Name = "btnBeginMove";
            this.btnBeginMove.Size = new System.Drawing.Size(87, 60);
            this.btnBeginMove.TabIndex = 6;
            this.btnBeginMove.Text = "开始移表";
            this.btnBeginMove.UseVisualStyleBackColor = true;
            this.btnBeginMove.Click += new System.EventHandler(this.btnBeginMove_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(36, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 14);
            this.label4.TabIndex = 7;
            this.label4.Tag = "";
            this.label4.Text = "我的工作目录 -->";
            // 
            // txtWorkPath
            // 
            this.txtWorkPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtWorkPath.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtWorkPath.Location = new System.Drawing.Point(193, 20);
            this.txtWorkPath.Name = "txtWorkPath";
            this.txtWorkPath.Size = new System.Drawing.Size(372, 23);
            this.txtWorkPath.TabIndex = 8;
            this.txtWorkPath.Text = "D:\\work\\excel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(36, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 10;
            this.label5.Tag = "";
            this.label5.Text = "选择站点";
            // 
            // rbEuropeSite
            // 
            this.rbEuropeSite.AutoSize = true;
            this.rbEuropeSite.Checked = true;
            this.rbEuropeSite.Location = new System.Drawing.Point(105, 80);
            this.rbEuropeSite.Name = "rbEuropeSite";
            this.rbEuropeSite.Size = new System.Drawing.Size(67, 18);
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
            this.rbAmericaSite.Location = new System.Drawing.Point(171, 80);
            this.rbAmericaSite.Name = "rbAmericaSite";
            this.rbAmericaSite.Size = new System.Drawing.Size(67, 18);
            this.rbAmericaSite.TabIndex = 12;
            this.rbAmericaSite.Tag = "America";
            this.rbAmericaSite.Text = "美洲站";
            this.rbAmericaSite.UseVisualStyleBackColor = true;
            // 
            // lbCurrencyUnit
            // 
            this.lbCurrencyUnit.AutoSize = true;
            this.lbCurrencyUnit.ForeColor = System.Drawing.Color.Blue;
            this.lbCurrencyUnit.Location = new System.Drawing.Point(14, 13);
            this.lbCurrencyUnit.Name = "lbCurrencyUnit";
            this.lbCurrencyUnit.Size = new System.Drawing.Size(77, 14);
            this.lbCurrencyUnit.TabIndex = 13;
            this.lbCurrencyUnit.Tag = "";
            this.lbCurrencyUnit.Text = "货币单位：";
            // 
            // lbCurrencyExchangeRate
            // 
            this.lbCurrencyExchangeRate.AutoSize = true;
            this.lbCurrencyExchangeRate.ForeColor = System.Drawing.Color.Blue;
            this.lbCurrencyExchangeRate.Location = new System.Drawing.Point(14, 38);
            this.lbCurrencyExchangeRate.Name = "lbCurrencyExchangeRate";
            this.lbCurrencyExchangeRate.Size = new System.Drawing.Size(77, 14);
            this.lbCurrencyExchangeRate.TabIndex = 14;
            this.lbCurrencyExchangeRate.Tag = "";
            this.lbCurrencyExchangeRate.Text = "货币汇率：";
            // 
            // btnSureConturyTemplate
            // 
            this.btnSureConturyTemplate.Location = new System.Drawing.Point(671, 75);
            this.btnSureConturyTemplate.Name = "btnSureConturyTemplate";
            this.btnSureConturyTemplate.Size = new System.Drawing.Size(115, 27);
            this.btnSureConturyTemplate.TabIndex = 15;
            this.btnSureConturyTemplate.Text = "确定国家及模板";
            this.btnSureConturyTemplate.UseVisualStyleBackColor = true;
            this.btnSureConturyTemplate.Click += new System.EventHandler(this.btnSureConturyTemplate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 16;
            this.label1.Tag = "";
            this.label1.Text = "品牌名";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Location = new System.Drawing.Point(71, 27);
            this.txtBrandName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(108, 23);
            this.txtBrandName.TabIndex = 17;
            this.txtBrandName.Text = "sinldo";
            // 
            // txtEANCountryCode
            // 
            this.txtEANCountryCode.Location = new System.Drawing.Point(74, 29);
            this.txtEANCountryCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEANCountryCode.Name = "txtEANCountryCode";
            this.txtEANCountryCode.Size = new System.Drawing.Size(47, 23);
            this.txtEANCountryCode.TabIndex = 19;
            this.txtEANCountryCode.Text = "485";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(7, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 18;
            this.label6.Tag = "";
            this.label6.Text = "EAN13位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(7, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 20;
            this.label7.Tag = "";
            this.label7.Text = "国家代码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(134, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 22;
            this.label8.Tag = "";
            this.label8.Text = "厂商代码";
            // 
            // txtEANFactoryCode
            // 
            this.txtEANFactoryCode.Location = new System.Drawing.Point(197, 29);
            this.txtEANFactoryCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEANFactoryCode.Name = "txtEANFactoryCode";
            this.txtEANFactoryCode.Size = new System.Drawing.Size(75, 23);
            this.txtEANFactoryCode.TabIndex = 21;
            this.txtEANFactoryCode.Text = "3222";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label9.Location = new System.Drawing.Point(277, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 24;
            this.label9.Tag = "";
            this.label9.Text = "商品代码";
            // 
            // txtEANProductCode
            // 
            this.txtEANProductCode.Location = new System.Drawing.Point(343, 27);
            this.txtEANProductCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEANProductCode.Name = "txtEANProductCode";
            this.txtEANProductCode.Size = new System.Drawing.Size(101, 23);
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
            this.panel1.Location = new System.Drawing.Point(39, 123);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 65);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.txtBrandName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(526, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 65);
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
            this.panel3.Location = new System.Drawing.Point(39, 195);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 51);
            this.panel3.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label15.Location = new System.Drawing.Point(429, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 26;
            this.label15.Tag = "";
            this.label15.Text = "KG";
            // 
            // txtShippingWeight
            // 
            this.txtShippingWeight.Location = new System.Drawing.Point(384, 19);
            this.txtShippingWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShippingWeight.Name = "txtShippingWeight";
            this.txtShippingWeight.Size = new System.Drawing.Size(40, 23);
            this.txtShippingWeight.TabIndex = 25;
            this.txtShippingWeight.Text = "0.5";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(317, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 24;
            this.label14.Tag = "";
            this.label14.Text = "商品重量";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(272, 19);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(40, 23);
            this.txtQuantity.TabIndex = 23;
            this.txtQuantity.Text = "30";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label13.Location = new System.Drawing.Point(205, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 22;
            this.label13.Tag = "";
            this.label13.Text = "库存数量";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label12.Location = new System.Drawing.Point(178, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 21;
            this.label12.Tag = "";
            this.label12.Text = "天";
            // 
            // txtDeliveryTimeMin
            // 
            this.txtDeliveryTimeMin.Location = new System.Drawing.Point(78, 19);
            this.txtDeliveryTimeMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeliveryTimeMin.Name = "txtDeliveryTimeMin";
            this.txtDeliveryTimeMin.Size = new System.Drawing.Size(40, 23);
            this.txtDeliveryTimeMin.TabIndex = 20;
            this.txtDeliveryTimeMin.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label11.Location = new System.Drawing.Point(116, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 19;
            this.label11.Tag = "";
            this.label11.Text = "-";
            // 
            // txtDeliveryTimeMax
            // 
            this.txtDeliveryTimeMax.Location = new System.Drawing.Point(132, 19);
            this.txtDeliveryTimeMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeliveryTimeMax.Name = "txtDeliveryTimeMax";
            this.txtDeliveryTimeMax.Size = new System.Drawing.Size(40, 23);
            this.txtDeliveryTimeMax.TabIndex = 18;
            this.txtDeliveryTimeMax.Text = "20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label10.Location = new System.Drawing.Point(8, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 16;
            this.label10.Tag = "";
            this.label10.Text = "到货时长";
            // 
            // btnSetWorkPath
            // 
            this.btnSetWorkPath.Location = new System.Drawing.Point(671, 17);
            this.btnSetWorkPath.Name = "btnSetWorkPath";
            this.btnSetWorkPath.Size = new System.Drawing.Size(115, 27);
            this.btnSetWorkPath.TabIndex = 28;
            this.btnSetWorkPath.Text = "设置工作目录";
            this.btnSetWorkPath.UseVisualStyleBackColor = true;
            this.btnSetWorkPath.Click += new System.EventHandler(this.btnSetWorkPath_Click);
            // 
            // browse_nodes1
            // 
            this.browse_nodes1.Location = new System.Drawing.Point(125, 258);
            this.browse_nodes1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browse_nodes1.Name = "browse_nodes1";
            this.browse_nodes1.Size = new System.Drawing.Size(184, 23);
            this.browse_nodes1.TabIndex = 18;
            this.browse_nodes1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.browse_nodes1_MouseClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(38, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 14);
            this.label16.TabIndex = 31;
            this.label16.Tag = "";
            this.label16.Text = "推荐节点1：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label17.Location = new System.Drawing.Point(324, 263);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 14);
            this.label17.TabIndex = 33;
            this.label17.Tag = "";
            this.label17.Text = "推荐节点2：";
            // 
            // browse_nodes2
            // 
            this.browse_nodes2.Location = new System.Drawing.Point(410, 258);
            this.browse_nodes2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browse_nodes2.Name = "browse_nodes2";
            this.browse_nodes2.Size = new System.Drawing.Size(184, 23);
            this.browse_nodes2.TabIndex = 32;
            this.browse_nodes2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.browse_nodes2_MouseClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.lbCurrencyUnit);
            this.panel4.Controls.Add(this.lbCurrencyExchangeRate);
            this.panel4.Location = new System.Drawing.Point(739, 123);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 65);
            this.panel4.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Info;
            this.panel5.Controls.Add(this.cbProductType);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(526, 195);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(418, 51);
            this.panel5.TabIndex = 27;
            // 
            // cbProductType
            // 
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(158, 19);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(169, 22);
            this.cbProductType.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label18.Location = new System.Drawing.Point(18, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(133, 14);
            this.label18.TabIndex = 16;
            this.label18.Tag = "";
            this.label18.Text = "产品类别（有效值）";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label19.Location = new System.Drawing.Point(38, 301);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 14);
            this.label19.TabIndex = 34;
            this.label19.Tag = "";
            this.label19.Text = "关键词模式：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.AllowDrop = true;
            this.txtKeyWords.Location = new System.Drawing.Point(38, 328);
            this.txtKeyWords.Margin = new System.Windows.Forms.Padding(2);
            this.txtKeyWords.Multiline = true;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(667, 215);
            this.txtKeyWords.TabIndex = 35;
            this.txtKeyWords.Text = "【请拖入导出的关键词文件或直接复制文件数据】";
            this.txtKeyWords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtKeyWords_MouseClick);
            this.txtKeyWords.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtKeyWords_DragDrop);
            this.txtKeyWords.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtKeyWords_DragEnter);
            // 
            // btnKeyWordStatistics
            // 
            this.btnKeyWordStatistics.Location = new System.Drawing.Point(860, 329);
            this.btnKeyWordStatistics.Margin = new System.Windows.Forms.Padding(2);
            this.btnKeyWordStatistics.Name = "btnKeyWordStatistics";
            this.btnKeyWordStatistics.Size = new System.Drawing.Size(87, 29);
            this.btnKeyWordStatistics.TabIndex = 36;
            this.btnKeyWordStatistics.Text = "关键词统计";
            this.btnKeyWordStatistics.UseVisualStyleBackColor = true;
            this.btnKeyWordStatistics.Click += new System.EventHandler(this.btnKeyWordStatistics_Click);
            // 
            // cmbKeyWordStyle
            // 
            this.cmbKeyWordStyle.FormattingEnabled = true;
            this.cmbKeyWordStyle.Location = new System.Drawing.Point(125, 299);
            this.cmbKeyWordStyle.Name = "cmbKeyWordStyle";
            this.cmbKeyWordStyle.Size = new System.Drawing.Size(128, 22);
            this.cmbKeyWordStyle.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.SeaGreen;
            this.label20.Location = new System.Drawing.Point(262, 301);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 14);
            this.label20.TabIndex = 37;
            this.label20.Tag = "";
            this.label20.Text = "关键词文件->";
            // 
            // txtKeyWordPath
            // 
            this.txtKeyWordPath.AutoSize = true;
            this.txtKeyWordPath.ForeColor = System.Drawing.Color.SeaGreen;
            this.txtKeyWordPath.Location = new System.Drawing.Point(356, 301);
            this.txtKeyWordPath.Name = "txtKeyWordPath";
            this.txtKeyWordPath.Size = new System.Drawing.Size(0, 14);
            this.txtKeyWordPath.TabIndex = 38;
            this.txtKeyWordPath.Tag = "";
            // 
            // txtKeyWordInfo
            // 
            this.txtKeyWordInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyWordInfo.Location = new System.Drawing.Point(708, 328);
            this.txtKeyWordInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKeyWordInfo.Multiline = true;
            this.txtKeyWordInfo.Name = "txtKeyWordInfo";
            this.txtKeyWordInfo.Size = new System.Drawing.Size(145, 215);
            this.txtKeyWordInfo.TabIndex = 39;
            this.txtKeyWordInfo.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 549);
            this.Controls.Add(this.txtKeyWordInfo);
            this.Controls.Add(this.txtKeyWordPath);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbKeyWordStyle);
            this.Controls.Add(this.btnKeyWordStatistics);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.browse_nodes2);
            this.Controls.Add(this.label16);
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
            this.Name = "Main";
            this.Text = "思普林国际贸易Excel操作";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox browse_nodes2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.Button btnKeyWordStatistics;
        private System.Windows.Forms.ComboBox cmbKeyWordStyle;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label txtKeyWordPath;
        private System.Windows.Forms.TextBox txtKeyWordInfo;
    }
}

