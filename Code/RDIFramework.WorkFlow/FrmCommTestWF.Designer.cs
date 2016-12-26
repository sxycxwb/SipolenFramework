namespace RDIFramework.WorkFlow
{
    partial class FrmCommTestWF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommTestWF));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWFInstanceName = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtTaskTemplateName = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtWFTemplateName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBillName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new RDIFramework.Controls.UcButton();
            this.btnAudit = new RDIFramework.Controls.UcButton();
            this.txtBill_sMoney = new RDIFramework.Controls.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBill_AuditFlag = new RDIFramework.Controls.UcComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWFInstanceName);
            this.groupBox1.Controls.Add(this.txtTaskTemplateName);
            this.groupBox1.Controls.Add(this.txtWFTemplateName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "流程信息";
            // 
            // txtWFInstanceName
            // 
            // 
            // 
            // 
            this.txtWFInstanceName.Border.Class = "TextBoxBorder";
            this.txtWFInstanceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWFInstanceName.FocusHighlightEnabled = true;
            this.txtWFInstanceName.Location = new System.Drawing.Point(122, 122);
            this.txtWFInstanceName.Name = "txtWFInstanceName";
            this.txtWFInstanceName.SelectedValue = ((object)(resources.GetObject("txtWFInstanceName.SelectedValue")));
            this.txtWFInstanceName.Size = new System.Drawing.Size(379, 23);
            this.txtWFInstanceName.TabIndex = 5;
            // 
            // txtTaskTemplateName
            // 
            this.txtTaskTemplateName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtTaskTemplateName.Border.Class = "TextBoxBorder";
            this.txtTaskTemplateName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTaskTemplateName.FocusHighlightEnabled = true;
            this.txtTaskTemplateName.Location = new System.Drawing.Point(122, 74);
            this.txtTaskTemplateName.Name = "txtTaskTemplateName";
            this.txtTaskTemplateName.ReadOnly = true;
            this.txtTaskTemplateName.SelectedValue = ((object)(resources.GetObject("txtTaskTemplateName.SelectedValue")));
            this.txtTaskTemplateName.Size = new System.Drawing.Size(379, 23);
            this.txtTaskTemplateName.TabIndex = 4;
            // 
            // txtWFTemplateName
            // 
            this.txtWFTemplateName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtWFTemplateName.Border.Class = "TextBoxBorder";
            this.txtWFTemplateName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWFTemplateName.FocusHighlightEnabled = true;
            this.txtWFTemplateName.Location = new System.Drawing.Point(122, 33);
            this.txtWFTemplateName.Name = "txtWFTemplateName";
            this.txtWFTemplateName.ReadOnly = true;
            this.txtWFTemplateName.SelectedValue = ((object)(resources.GetObject("txtWFTemplateName.SelectedValue")));
            this.txtWFTemplateName.Size = new System.Drawing.Size(379, 23);
            this.txtWFTemplateName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "流程实例名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "任务模版名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "流程模版名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboBill_AuditFlag);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBill_sMoney);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBillName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "业务信息";
            // 
            // txtBillName
            // 
            // 
            // 
            // 
            this.txtBillName.Border.Class = "TextBoxBorder";
            this.txtBillName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBillName.FocusHighlightEnabled = true;
            this.txtBillName.Location = new System.Drawing.Point(122, 22);
            this.txtBillName.Name = "txtBillName";
            this.txtBillName.SelectedValue = ((object)(resources.GetObject("txtBillName.SelectedValue")));
            this.txtBillName.Size = new System.Drawing.Size(344, 23);
            this.txtBillName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "单据名称：";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(343, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAudit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAudit.Location = new System.Drawing.Point(439, 375);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(75, 23);
            this.btnAudit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAudit.TabIndex = 3;
            this.btnAudit.Text = "审核";
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // txtBill_sMoney
            // 
            // 
            // 
            // 
            this.txtBill_sMoney.Border.Class = "TextBoxBorder";
            this.txtBill_sMoney.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBill_sMoney.FocusHighlightEnabled = true;
            this.txtBill_sMoney.Location = new System.Drawing.Point(122, 52);
            this.txtBill_sMoney.Name = "txtBill_sMoney";
            this.txtBill_sMoney.SelectedValue = ((object)(resources.GetObject("txtBill_sMoney.SelectedValue")));
            this.txtBill_sMoney.Size = new System.Drawing.Size(344, 23);
            this.txtBill_sMoney.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "单据金额：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "销售出库方式：";
            // 
            // cboBill_AuditFlag
            // 
            this.cboBill_AuditFlag.DisplayMember = "Text";
            this.cboBill_AuditFlag.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBill_AuditFlag.FormattingEnabled = true;
            this.cboBill_AuditFlag.ItemHeight = 17;
            this.cboBill_AuditFlag.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cboBill_AuditFlag.Location = new System.Drawing.Point(122, 85);
            this.cboBill_AuditFlag.Name = "cboBill_AuditFlag";
            this.cboBill_AuditFlag.Size = new System.Drawing.Size(344, 23);
            this.cboBill_AuditFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboBill_AuditFlag.TabIndex = 11;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "出库确认";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "直接出库";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "不同意出库";
            // 
            // FrmCommTestWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 420);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmCommTestWF";
            this.Text = "工作流业务处理实例窗体";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.UcTextBox txtWFTemplateName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.UcButton btnSave;
        private Controls.UcButton btnAudit;
        private Controls.UcTextBox txtWFInstanceName;
        private Controls.UcTextBox txtTaskTemplateName;
        private Controls.UcTextBox txtBillName;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox txtBill_sMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controls.UcComboBoxEx cboBill_AuditFlag;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
    }
}