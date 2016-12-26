namespace RDIFramework.WorkFlow
{
    partial class FrmTaskVar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskVar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCurrentDataBase = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDataBase = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.comboBoxbx = new System.Windows.Forms.ComboBox();
            this.lblSortField = new System.Windows.Forms.Label();
            this.cbxTableColumns = new System.Windows.Forms.ComboBox();
            this.cbxDataTable = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVarName = new System.Windows.Forms.Label();
            this.cbxAccessType = new System.Windows.Forms.ComboBox();
            this.lblAccessType = new System.Windows.Forms.Label();
            this.cbxVarType = new System.Windows.Forms.ComboBox();
            this.cbxVarModule = new System.Windows.Forms.ComboBox();
            this.tbxIniValue = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxVarName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblInitValue = new System.Windows.Forms.Label();
            this.lblVarModel = new System.Windows.Forms.Label();
            this.lblTableField = new System.Windows.Forms.Label();
            this.lblVarType = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.btnTest = new RDIFramework.Controls.UcButton();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.groupBox1);
            this.plclassFill.Size = new System.Drawing.Size(473, 292);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Controls.Add(this.btnTest);
            this.plclassBottom.Location = new System.Drawing.Point(0, 244);
            this.plclassBottom.Size = new System.Drawing.Size(473, 48);
            this.plclassBottom.Controls.SetChildIndex(this.btnTest, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnSave, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(376, 15);
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(275, 15);
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurrentDataBase);
            this.groupBox1.Controls.Add(this.lblDataBase);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.comboBoxbx);
            this.groupBox1.Controls.Add(this.lblSortField);
            this.groupBox1.Controls.Add(this.cbxTableColumns);
            this.groupBox1.Controls.Add(this.cbxDataTable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblVarName);
            this.groupBox1.Controls.Add(this.cbxAccessType);
            this.groupBox1.Controls.Add(this.lblAccessType);
            this.groupBox1.Controls.Add(this.cbxVarType);
            this.groupBox1.Controls.Add(this.cbxVarModule);
            this.groupBox1.Controls.Add(this.tbxIniValue);
            this.groupBox1.Controls.Add(this.tbxVarName);
            this.groupBox1.Controls.Add(this.lblInitValue);
            this.groupBox1.Controls.Add(this.lblVarModel);
            this.groupBox1.Controls.Add(this.lblTableField);
            this.groupBox1.Controls.Add(this.lblVarType);
            this.groupBox1.Controls.Add(this.lblTableName);
            this.groupBox1.Location = new System.Drawing.Point(7, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 226);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // txtCurrentDataBase
            // 
            // 
            // 
            // 
            this.txtCurrentDataBase.Border.Class = "TextBoxBorder";
            this.txtCurrentDataBase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCurrentDataBase.FocusHighlightEnabled = true;
            this.txtCurrentDataBase.Location = new System.Drawing.Point(90, 107);
            this.txtCurrentDataBase.Name = "txtCurrentDataBase";
            this.txtCurrentDataBase.SelectedValue = ((object)(resources.GetObject("txtCurrentDataBase.SelectedValue")));
            this.txtCurrentDataBase.Size = new System.Drawing.Size(300, 23);
            this.txtCurrentDataBase.TabIndex = 33;
            // 
            // lblDataBase
            // 
            this.lblDataBase.AutoEllipsis = true;
            this.lblDataBase.Location = new System.Drawing.Point(3, 109);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(86, 14);
            this.lblDataBase.TabIndex = 32;
            this.lblDataBase.Text = "数据库:";
            this.lblDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoEllipsis = true;
            this.lblDesc.Location = new System.Drawing.Point(394, 191);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(57, 14);
            this.lblDesc.TabIndex = 31;
            this.lblDesc.Text = "--倒序";
            // 
            // comboBoxbx
            // 
            this.comboBoxbx.FormattingEnabled = true;
            this.comboBoxbx.Location = new System.Drawing.Point(90, 188);
            this.comboBoxbx.Name = "comboBoxbx";
            this.comboBoxbx.Size = new System.Drawing.Size(304, 22);
            this.comboBoxbx.TabIndex = 30;
            // 
            // lblSortField
            // 
            this.lblSortField.AutoEllipsis = true;
            this.lblSortField.Location = new System.Drawing.Point(3, 191);
            this.lblSortField.Name = "lblSortField";
            this.lblSortField.Size = new System.Drawing.Size(86, 14);
            this.lblSortField.TabIndex = 29;
            this.lblSortField.Text = "排序字段:";
            this.lblSortField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxTableColumns
            // 
            this.cbxTableColumns.FormattingEnabled = true;
            this.cbxTableColumns.Location = new System.Drawing.Point(90, 162);
            this.cbxTableColumns.Name = "cbxTableColumns";
            this.cbxTableColumns.Size = new System.Drawing.Size(304, 22);
            this.cbxTableColumns.TabIndex = 28;
            // 
            // cbxDataTable
            // 
            this.cbxDataTable.FormattingEnabled = true;
            this.cbxDataTable.Location = new System.Drawing.Point(90, 137);
            this.cbxDataTable.Name = "cbxDataTable";
            this.cbxDataTable.Size = new System.Drawing.Size(304, 22);
            this.cbxDataTable.TabIndex = 27;
            this.cbxDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxDatatable_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(213, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVarName
            // 
            this.lblVarName.AutoEllipsis = true;
            this.lblVarName.Location = new System.Drawing.Point(3, 23);
            this.lblVarName.Name = "lblVarName";
            this.lblVarName.Size = new System.Drawing.Size(86, 14);
            this.lblVarName.TabIndex = 0;
            this.lblVarName.Text = "变量名称:";
            this.lblVarName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxAccessType
            // 
            this.cbxAccessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccessType.Items.AddRange(new object[] {
            "请选择",
            "流程变量",
            "任务变量"});
            this.cbxAccessType.Location = new System.Drawing.Point(90, 71);
            this.cbxAccessType.Name = "cbxAccessType";
            this.cbxAccessType.Size = new System.Drawing.Size(120, 22);
            this.cbxAccessType.TabIndex = 17;
            // 
            // lblAccessType
            // 
            this.lblAccessType.AutoEllipsis = true;
            this.lblAccessType.Location = new System.Drawing.Point(3, 74);
            this.lblAccessType.Name = "lblAccessType";
            this.lblAccessType.Size = new System.Drawing.Size(86, 14);
            this.lblAccessType.TabIndex = 16;
            this.lblAccessType.Text = "访问类型:";
            this.lblAccessType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxVarType
            // 
            this.cbxVarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVarType.Items.AddRange(new object[] {
            "int",
            "float",
            "double",
            "string",
            "datetime",
            "bool"});
            this.cbxVarType.Location = new System.Drawing.Point(317, 19);
            this.cbxVarType.Name = "cbxVarType";
            this.cbxVarType.Size = new System.Drawing.Size(120, 22);
            this.cbxVarType.TabIndex = 10;
            // 
            // cbxVarModule
            // 
            this.cbxVarModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVarModule.Items.AddRange(new object[] {
            "in",
            "out"});
            this.cbxVarModule.Location = new System.Drawing.Point(317, 46);
            this.cbxVarModule.Name = "cbxVarModule";
            this.cbxVarModule.Size = new System.Drawing.Size(120, 22);
            this.cbxVarModule.TabIndex = 9;
            // 
            // tbxIniValue
            // 
            // 
            // 
            // 
            this.tbxIniValue.Border.Class = "TextBoxBorder";
            this.tbxIniValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxIniValue.FocusHighlightEnabled = true;
            this.tbxIniValue.Location = new System.Drawing.Point(90, 46);
            this.tbxIniValue.Name = "tbxIniValue";
            this.tbxIniValue.SelectedValue = ((object)(resources.GetObject("tbxIniValue.SelectedValue")));
            this.tbxIniValue.Size = new System.Drawing.Size(120, 23);
            this.tbxIniValue.TabIndex = 8;
            // 
            // tbxVarName
            // 
            // 
            // 
            // 
            this.tbxVarName.Border.Class = "TextBoxBorder";
            this.tbxVarName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxVarName.FocusHighlightEnabled = true;
            this.tbxVarName.Location = new System.Drawing.Point(90, 19);
            this.tbxVarName.Name = "tbxVarName";
            this.tbxVarName.SelectedValue = ((object)(resources.GetObject("tbxVarName.SelectedValue")));
            this.tbxVarName.Size = new System.Drawing.Size(120, 23);
            this.tbxVarName.TabIndex = 7;
            // 
            // lblInitValue
            // 
            this.lblInitValue.AutoEllipsis = true;
            this.lblInitValue.Location = new System.Drawing.Point(3, 50);
            this.lblInitValue.Name = "lblInitValue";
            this.lblInitValue.Size = new System.Drawing.Size(86, 14);
            this.lblInitValue.TabIndex = 6;
            this.lblInitValue.Text = "初始值:";
            this.lblInitValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVarModel
            // 
            this.lblVarModel.AutoEllipsis = true;
            this.lblVarModel.Location = new System.Drawing.Point(228, 49);
            this.lblVarModel.Name = "lblVarModel";
            this.lblVarModel.Size = new System.Drawing.Size(88, 14);
            this.lblVarModel.TabIndex = 4;
            this.lblVarModel.Text = "变量模式:";
            this.lblVarModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTableField
            // 
            this.lblTableField.AutoEllipsis = true;
            this.lblTableField.Location = new System.Drawing.Point(3, 165);
            this.lblTableField.Name = "lblTableField";
            this.lblTableField.Size = new System.Drawing.Size(86, 14);
            this.lblTableField.TabIndex = 3;
            this.lblTableField.Text = "表字段:";
            this.lblTableField.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVarType
            // 
            this.lblVarType.AutoEllipsis = true;
            this.lblVarType.Location = new System.Drawing.Point(228, 23);
            this.lblVarType.Name = "lblVarType";
            this.lblVarType.Size = new System.Drawing.Size(88, 14);
            this.lblVarType.TabIndex = 2;
            this.lblVarType.Text = "变量类型:";
            this.lblVarType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoEllipsis = true;
            this.lblTableName.Location = new System.Drawing.Point(3, 140);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(86, 14);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "表名:";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTest
            // 
            this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTest.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTest.Location = new System.Drawing.Point(179, 15);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(83, 23);
            this.btnTest.TabIndex = 25;
            this.btnTest.Text = "测试连接";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // FrmTaskVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 292);
            this.Name = "FrmTaskVar";
            this.Text = "任务变量";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDesc;
        public System.Windows.Forms.ComboBox comboBoxbx;
        private System.Windows.Forms.Label lblSortField;
        public System.Windows.Forms.ComboBox cbxTableColumns;
        public System.Windows.Forms.ComboBox cbxDataTable;
        private Controls.UcButton btnTest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVarName;
        public System.Windows.Forms.ComboBox cbxAccessType;
        private System.Windows.Forms.Label lblAccessType;
        public System.Windows.Forms.ComboBox cbxVarType;
        public System.Windows.Forms.ComboBox cbxVarModule;
        public Controls.UcTextBox tbxIniValue;
        public Controls.UcTextBox tbxVarName;
        private System.Windows.Forms.Label lblInitValue;
        private System.Windows.Forms.Label lblVarModel;
        private System.Windows.Forms.Label lblTableField;
        private System.Windows.Forms.Label lblVarType;
        private System.Windows.Forms.Label lblTableName;
        public Controls.UcTextBox txtCurrentDataBase;
        private System.Windows.Forms.Label lblDataBase;
    }
}