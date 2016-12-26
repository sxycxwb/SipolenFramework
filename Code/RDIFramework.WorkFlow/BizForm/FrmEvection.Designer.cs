namespace RDIFramework.WorkFlow
{
    partial class FrmEvection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEvection));
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnSave = new RDIFramework.Controls.UcButton();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.dgvEvectionDetail = new RDIFramework.Controls.UcDataGridView();
            this.colStartAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCityCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLiveDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLivePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvectionDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOthers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCnTotal = new RDIFramework.Controls.UcTextBox(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.txtFactPrice = new RDIFramework.Controls.UcTextBox(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.txtLendPrice = new RDIFramework.Controls.UcTextBox(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.txtTotal = new RDIFramework.Controls.UcTextBox(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEdit = new RDIFramework.Controls.UcButton();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOthers = new RDIFramework.Controls.UcTextBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.txtAllowance = new RDIFramework.Controls.UcTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtEvectionDays = new RDIFramework.Controls.UcTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtLivePrice = new RDIFramework.Controls.UcTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtLiveDays = new RDIFramework.Controls.UcTextBox(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.txtCityCost = new RDIFramework.Controls.UcTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtVehicleCost = new RDIFramework.Controls.UcTextBox(this.components);
            this.cboVehicle = new RDIFramework.Controls.UcComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSubmitUser = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtReason = new RDIFramework.Controls.UcTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.dtSubmitDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDepartment = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtBillCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTool.SuspendLayout();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvectionDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtSubmitDate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlTool.Controls.Add(this.btnSave);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(839, 49);
            this.pnlTool.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存差旅报销单";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.dgvEvectionDetail);
            this.gbMain.Controls.Add(this.panel3);
            this.gbMain.Controls.Add(this.panel2);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 165);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(839, 435);
            this.gbMain.TabIndex = 5;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "报销明细";
            // 
            // dgvEvectionDetail
            // 
            this.dgvEvectionDetail.AllowUserToAddRows = false;
            this.dgvEvectionDetail.AllowUserToDeleteRows = false;
            this.dgvEvectionDetail.AllowUserToOrderColumns = true;
            this.dgvEvectionDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvectionDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEvectionDetail.ColumnHeadersHeight = 40;
            this.dgvEvectionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvectionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStartAddress,
            this.colEndAddress,
            this.colVehicle,
            this.colVehicleCost,
            this.colCityCost,
            this.colLiveDays,
            this.colLivePrice,
            this.colEvectionDays,
            this.colAllowance,
            this.colOthers});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEvectionDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEvectionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvectionDetail.EnableHeadersVisualStyles = false;
            this.dgvEvectionDetail.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvEvectionDetail.Location = new System.Drawing.Point(3, 137);
            this.dgvEvectionDetail.MultiSelect = false;
            this.dgvEvectionDetail.Name = "dgvEvectionDetail";
            this.dgvEvectionDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvectionDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEvectionDetail.RowHeadersWidth = 20;
            this.dgvEvectionDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEvectionDetail.RowTemplate.Height = 23;
            this.dgvEvectionDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEvectionDetail.Size = new System.Drawing.Size(833, 177);
            this.dgvEvectionDetail.TabIndex = 9;
            this.dgvEvectionDetail.CurrentCellChanged += new System.EventHandler(this.dgvEvectionDetail_CurrentCellChanged);
            // 
            // colStartAddress
            // 
            this.colStartAddress.DataPropertyName = "StartAddress";
            this.colStartAddress.HeaderText = "起点";
            this.colStartAddress.Name = "colStartAddress";
            // 
            // colEndAddress
            // 
            this.colEndAddress.DataPropertyName = "EndAddress";
            this.colEndAddress.HeaderText = "终点";
            this.colEndAddress.Name = "colEndAddress";
            // 
            // colVehicle
            // 
            this.colVehicle.DataPropertyName = "Vehicle";
            this.colVehicle.HeaderText = "交通工具";
            this.colVehicle.Name = "colVehicle";
            this.colVehicle.Width = 60;
            // 
            // colVehicleCost
            // 
            this.colVehicleCost.DataPropertyName = "VehicleCost";
            this.colVehicleCost.HeaderText = "车/船/机票费";
            this.colVehicleCost.Name = "colVehicleCost";
            // 
            // colCityCost
            // 
            this.colCityCost.DataPropertyName = "CityCost";
            this.colCityCost.HeaderText = "市内交通费";
            this.colCityCost.Name = "colCityCost";
            this.colCityCost.Width = 70;
            // 
            // colLiveDays
            // 
            this.colLiveDays.DataPropertyName = "LiveDays";
            this.colLiveDays.HeaderText = "住宿天数";
            this.colLiveDays.Name = "colLiveDays";
            this.colLiveDays.Width = 50;
            // 
            // colLivePrice
            // 
            this.colLivePrice.DataPropertyName = "LivePrice";
            this.colLivePrice.HeaderText = "住宿/房价(单价)";
            this.colLivePrice.Name = "colLivePrice";
            this.colLivePrice.Width = 80;
            // 
            // colEvectionDays
            // 
            this.colEvectionDays.DataPropertyName = "EvectionDays";
            this.colEvectionDays.HeaderText = "出差天数";
            this.colEvectionDays.Name = "colEvectionDays";
            this.colEvectionDays.Width = 50;
            // 
            // colAllowance
            // 
            this.colAllowance.DataPropertyName = "Allowance";
            this.colAllowance.HeaderText = "出差/津贴(每天)";
            this.colAllowance.Name = "colAllowance";
            this.colAllowance.Width = 80;
            // 
            // colOthers
            // 
            this.colOthers.DataPropertyName = "Others";
            this.colOthers.HeaderText = "其他费用";
            this.colOthers.Name = "colOthers";
            this.colOthers.Width = 70;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtDescription);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.txtCnTotal);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtFactPrice);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txtLendPrice);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.txtTotal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 314);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(833, 118);
            this.panel3.TabIndex = 10;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(76, 50);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedValue = ((object)(resources.GetObject("txtDescription.SelectedValue")));
            this.txtDescription.Size = new System.Drawing.Size(741, 59);
            this.txtDescription.TabIndex = 68;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 67;
            this.label16.Text = "备注：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(575, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(42, 14);
            this.label22.TabIndex = 66;
            this.label22.Text = "大写:";
            // 
            // txtCnTotal
            // 
            this.txtCnTotal.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtCnTotal.Border.Class = "TextBoxBorder";
            this.txtCnTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCnTotal.FocusHighlightEnabled = true;
            this.txtCnTotal.Location = new System.Drawing.Point(617, 17);
            this.txtCnTotal.Name = "txtCnTotal";
            this.txtCnTotal.ReadOnly = true;
            this.txtCnTotal.SelectedValue = ((object)(resources.GetObject("txtCnTotal.SelectedValue")));
            this.txtCnTotal.Size = new System.Drawing.Size(200, 23);
            this.txtCnTotal.TabIndex = 65;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(372, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 14);
            this.label19.TabIndex = 58;
            this.label19.Text = "支付金额:";
            // 
            // txtFactPrice
            // 
            this.txtFactPrice.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtFactPrice.Border.Class = "TextBoxBorder";
            this.txtFactPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFactPrice.FocusHighlightEnabled = true;
            this.txtFactPrice.Location = new System.Drawing.Point(443, 17);
            this.txtFactPrice.Name = "txtFactPrice";
            this.txtFactPrice.ReadOnly = true;
            this.txtFactPrice.SelectedValue = ((object)(resources.GetObject("txtFactPrice.SelectedValue")));
            this.txtFactPrice.Size = new System.Drawing.Size(132, 23);
            this.txtFactPrice.TabIndex = 57;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(208, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 14);
            this.label20.TabIndex = 56;
            this.label20.Text = "减:借款:";
            // 
            // txtLendPrice
            // 
            // 
            // 
            // 
            this.txtLendPrice.Border.Class = "TextBoxBorder";
            this.txtLendPrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLendPrice.FocusHighlightEnabled = true;
            this.txtLendPrice.Location = new System.Drawing.Point(271, 17);
            this.txtLendPrice.Name = "txtLendPrice";
            this.txtLendPrice.SelectedValue = ((object)(resources.GetObject("txtLendPrice.SelectedValue")));
            this.txtLendPrice.Size = new System.Drawing.Size(98, 23);
            this.txtLendPrice.TabIndex = 55;
            this.txtLendPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 14);
            this.label21.TabIndex = 54;
            this.label21.Text = "费用合计:";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtTotal.Border.Class = "TextBoxBorder";
            this.txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.FocusHighlightEnabled = true;
            this.txtTotal.Location = new System.Drawing.Point(76, 17);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.SelectedValue = ((object)(resources.GetObject("txtTotal.SelectedValue")));
            this.txtTotal.Size = new System.Drawing.Size(128, 23);
            this.txtTotal.TabIndex = 53;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtFactPrice_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtOthers);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtAllowance);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtEvectionDays);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtLivePrice);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtLiveDays);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtCityCost);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtVehicleCost);
            this.panel2.Controls.Add(this.cboVehicle);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtEndAddress);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtStartAddress);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 118);
            this.panel2.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Location = new System.Drawing.Point(747, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 23);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 66;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(747, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 65;
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(547, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 64;
            this.label15.Text = "其他费用:";
            // 
            // txtOthers
            // 
            // 
            // 
            // 
            this.txtOthers.Border.Class = "TextBoxBorder";
            this.txtOthers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOthers.FocusHighlightEnabled = true;
            this.txtOthers.Location = new System.Drawing.Point(617, 77);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.SelectedValue = ((object)(resources.GetObject("txtOthers.SelectedValue")));
            this.txtOthers.Size = new System.Drawing.Size(98, 23);
            this.txtOthers.TabIndex = 63;
            this.txtOthers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(310, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 14);
            this.label14.TabIndex = 62;
            this.label14.Text = "出差津贴/每天:";
            // 
            // txtAllowance
            // 
            // 
            // 
            // 
            this.txtAllowance.Border.Class = "TextBoxBorder";
            this.txtAllowance.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAllowance.FocusHighlightEnabled = true;
            this.txtAllowance.Location = new System.Drawing.Point(417, 77);
            this.txtAllowance.Name = "txtAllowance";
            this.txtAllowance.SelectedValue = ((object)(resources.GetObject("txtAllowance.SelectedValue")));
            this.txtAllowance.Size = new System.Drawing.Size(92, 23);
            this.txtAllowance.TabIndex = 61;
            this.txtAllowance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 14);
            this.label13.TabIndex = 60;
            this.label13.Text = "出差-天数:";
            // 
            // txtEvectionDays
            // 
            // 
            // 
            // 
            this.txtEvectionDays.Border.Class = "TextBoxBorder";
            this.txtEvectionDays.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEvectionDays.FocusHighlightEnabled = true;
            this.txtEvectionDays.Location = new System.Drawing.Point(91, 77);
            this.txtEvectionDays.Name = "txtEvectionDays";
            this.txtEvectionDays.SelectedValue = ((object)(resources.GetObject("txtEvectionDays.SelectedValue")));
            this.txtEvectionDays.Size = new System.Drawing.Size(209, 23);
            this.txtEvectionDays.TabIndex = 59;
            this.txtEvectionDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(512, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 14);
            this.label12.TabIndex = 58;
            this.label12.Text = "住宿房价/单价:";
            // 
            // txtLivePrice
            // 
            // 
            // 
            // 
            this.txtLivePrice.Border.Class = "TextBoxBorder";
            this.txtLivePrice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLivePrice.FocusHighlightEnabled = true;
            this.txtLivePrice.Location = new System.Drawing.Point(617, 46);
            this.txtLivePrice.Name = "txtLivePrice";
            this.txtLivePrice.SelectedValue = ((object)(resources.GetObject("txtLivePrice.SelectedValue")));
            this.txtLivePrice.Size = new System.Drawing.Size(98, 23);
            this.txtLivePrice.TabIndex = 57;
            this.txtLivePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(338, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 56;
            this.label11.Text = "住宿-天数:";
            // 
            // txtLiveDays
            // 
            // 
            // 
            // 
            this.txtLiveDays.Border.Class = "TextBoxBorder";
            this.txtLiveDays.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLiveDays.FocusHighlightEnabled = true;
            this.txtLiveDays.Location = new System.Drawing.Point(417, 46);
            this.txtLiveDays.Name = "txtLiveDays";
            this.txtLiveDays.SelectedValue = ((object)(resources.GetObject("txtLiveDays.SelectedValue")));
            this.txtLiveDays.Size = new System.Drawing.Size(92, 23);
            this.txtLiveDays.TabIndex = 55;
            this.txtLiveDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 14);
            this.label10.TabIndex = 54;
            this.label10.Text = "市内交通费:";
            // 
            // txtCityCost
            // 
            // 
            // 
            // 
            this.txtCityCost.Border.Class = "TextBoxBorder";
            this.txtCityCost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCityCost.FocusHighlightEnabled = true;
            this.txtCityCost.Location = new System.Drawing.Point(91, 46);
            this.txtCityCost.Name = "txtCityCost";
            this.txtCityCost.SelectedValue = ((object)(resources.GetObject("txtCityCost.SelectedValue")));
            this.txtCityCost.Size = new System.Drawing.Size(209, 23);
            this.txtCityCost.TabIndex = 53;
            this.txtCityCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(519, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 14);
            this.label8.TabIndex = 52;
            this.label8.Text = "车/船/机票费:";
            // 
            // txtVehicleCost
            // 
            // 
            // 
            // 
            this.txtVehicleCost.Border.Class = "TextBoxBorder";
            this.txtVehicleCost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVehicleCost.FocusHighlightEnabled = true;
            this.txtVehicleCost.Location = new System.Drawing.Point(617, 12);
            this.txtVehicleCost.Name = "txtVehicleCost";
            this.txtVehicleCost.SelectedValue = ((object)(resources.GetObject("txtVehicleCost.SelectedValue")));
            this.txtVehicleCost.Size = new System.Drawing.Size(98, 23);
            this.txtVehicleCost.TabIndex = 51;
            this.txtVehicleCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicleCost_KeyPress);
            // 
            // cboVehicle
            // 
            this.cboVehicle.DisplayMember = "Text";
            this.cboVehicle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboVehicle.FormattingEnabled = true;
            this.cboVehicle.ItemHeight = 17;
            this.cboVehicle.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cboVehicle.Location = new System.Drawing.Point(417, 12);
            this.cboVehicle.Name = "cboVehicle";
            this.cboVehicle.Size = new System.Drawing.Size(92, 23);
            this.cboVehicle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboVehicle.TabIndex = 50;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "飞机";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "火车";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "汽车";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "轮船";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 49;
            this.label7.Text = "交通工具:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 47;
            this.label6.Text = "终点:";
            // 
            // txtEndAddress
            // 
            // 
            // 
            // 
            this.txtEndAddress.Border.Class = "TextBoxBorder";
            this.txtEndAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEndAddress.FocusHighlightEnabled = true;
            this.txtEndAddress.Location = new System.Drawing.Point(218, 12);
            this.txtEndAddress.Name = "txtEndAddress";
            this.txtEndAddress.SelectedValue = ((object)(resources.GetObject("txtEndAddress.SelectedValue")));
            this.txtEndAddress.Size = new System.Drawing.Size(83, 23);
            this.txtEndAddress.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 45;
            this.label4.Text = "起点:";
            // 
            // txtStartAddress
            // 
            // 
            // 
            // 
            this.txtStartAddress.Border.Class = "TextBoxBorder";
            this.txtStartAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStartAddress.FocusHighlightEnabled = true;
            this.txtStartAddress.Location = new System.Drawing.Point(91, 12);
            this.txtStartAddress.Name = "txtStartAddress";
            this.txtStartAddress.SelectedValue = ((object)(resources.GetObject("txtStartAddress.SelectedValue")));
            this.txtStartAddress.Size = new System.Drawing.Size(80, 23);
            this.txtStartAddress.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSubmitUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtReason);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtSubmitDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDepartment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtBillCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 116);
            this.panel1.TabIndex = 6;
            // 
            // txtSubmitUser
            // 
            this.txtSubmitUser.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtSubmitUser.Border.Class = "TextBoxBorder";
            this.txtSubmitUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSubmitUser.FocusHighlightEnabled = true;
            this.txtSubmitUser.Location = new System.Drawing.Point(495, 12);
            this.txtSubmitUser.Name = "txtSubmitUser";
            this.txtSubmitUser.ReadOnly = true;
            this.txtSubmitUser.SelectedValue = ((object)(resources.GetObject("txtSubmitUser.SelectedValue")));
            this.txtSubmitUser.Size = new System.Drawing.Size(131, 23);
            this.txtSubmitUser.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(443, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 50;
            this.label2.Text = "报销人：";
            // 
            // txtReason
            // 
            // 
            // 
            // 
            this.txtReason.Border.Class = "TextBoxBorder";
            this.txtReason.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReason.FocusHighlightEnabled = true;
            this.txtReason.Location = new System.Drawing.Point(86, 46);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReason.SelectedValue = ((object)(resources.GetObject("txtReason.SelectedValue")));
            this.txtReason.Size = new System.Drawing.Size(741, 61);
            this.txtReason.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 48;
            this.label9.Text = "出差事由：";
            // 
            // dtSubmitDate
            // 
            // 
            // 
            // 
            this.dtSubmitDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtSubmitDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtSubmitDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtSubmitDate.ButtonDropDown.Visible = true;
            this.dtSubmitDate.IsPopupCalendarOpen = false;
            this.dtSubmitDate.Location = new System.Drawing.Point(323, 12);
            // 
            // 
            // 
            this.dtSubmitDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtSubmitDate.MonthCalendar.BackgroundStyle.Class = "";
            this.dtSubmitDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtSubmitDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtSubmitDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtSubmitDate.MonthCalendar.DisplayMonth = new System.DateTime(2014, 7, 1, 0, 0, 0, 0);
            this.dtSubmitDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtSubmitDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtSubmitDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtSubmitDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtSubmitDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtSubmitDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtSubmitDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtSubmitDate.MonthCalendar.TodayButtonVisible = true;
            this.dtSubmitDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtSubmitDate.Name = "dtSubmitDate";
            this.dtSubmitDate.Size = new System.Drawing.Size(111, 23);
            this.dtSubmitDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtSubmitDate.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 46;
            this.label5.Text = "提交日期：";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtDepartment.Border.Class = "TextBoxBorder";
            this.txtDepartment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDepartment.FocusHighlightEnabled = true;
            this.txtDepartment.Location = new System.Drawing.Point(693, 12);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.SelectedValue = ((object)(resources.GetObject("txtDepartment.SelectedValue")));
            this.txtDepartment.Size = new System.Drawing.Size(134, 23);
            this.txtDepartment.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 44;
            this.label3.Text = "所属部门：";
            // 
            // txtBillCode
            // 
            this.txtBillCode.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtBillCode.Border.Class = "TextBoxBorder";
            this.txtBillCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBillCode.FocusHighlightEnabled = true;
            this.txtBillCode.Location = new System.Drawing.Point(86, 12);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.ReadOnly = true;
            this.txtBillCode.SelectedValue = ((object)(resources.GetObject("txtBillCode.SelectedValue")));
            this.txtBillCode.Size = new System.Drawing.Size(160, 23);
            this.txtBillCode.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 42;
            this.label1.Text = "单据编号：";
            // 
            // FrmEvection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 600);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTool);
            this.Name = "FrmEvection";
            this.Text = "差旅报销";
            this.Load += new System.EventHandler(this.FrmEvection_Load);
            this.pnlTool.ResumeLayout(false);
            this.gbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvectionDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtSubmitDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTool;
        private Controls.UcButton btnSave;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcTextBox txtSubmitUser;
        private System.Windows.Forms.Label label2;
        private Controls.UcTextBox txtReason;
        private System.Windows.Forms.Label label9;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtSubmitDate;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtDepartment;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtBillCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox txtEndAddress;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox txtStartAddress;
        private Controls.UcComboBoxEx cboVehicle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private Controls.UcTextBox txtCityCost;
        private System.Windows.Forms.Label label8;
        private Controls.UcTextBox txtVehicleCost;
        private System.Windows.Forms.Label label12;
        private Controls.UcTextBox txtLivePrice;
        private System.Windows.Forms.Label label11;
        private Controls.UcTextBox txtLiveDays;
        private System.Windows.Forms.Label label14;
        private Controls.UcTextBox txtAllowance;
        private System.Windows.Forms.Label label13;
        private Controls.UcTextBox txtEvectionDays;
        private System.Windows.Forms.Label label15;
        private Controls.UcTextBox txtOthers;
        private Controls.UcButton btnEdit;
        private Controls.UcButton btnAdd;
        private Controls.UcDataGridView dgvEvectionDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label19;
        private Controls.UcTextBox txtFactPrice;
        private System.Windows.Forms.Label label20;
        private Controls.UcTextBox txtLendPrice;
        private System.Windows.Forms.Label label21;
        private Controls.UcTextBox txtTotal;
        private System.Windows.Forms.Label label22;
        private Controls.UcTextBox txtCnTotal;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label label16;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCityCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLiveDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLivePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvectionDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOthers;
    }
}