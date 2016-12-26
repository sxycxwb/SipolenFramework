namespace RDIFramework.WorkFlow
{
    partial class FrmCommTestAuditWF
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new RDIFramework.Controls.UcTextBox(this.components);
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBill_AuditFlag = new RDIFramework.Controls.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtBill_sMoney = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new RDIFramework.Controls.UcTextBox(this.components);
            this.textBox3 = new RDIFramework.Controls.UcTextBox(this.components);
            this.textBox2 = new RDIFramework.Controls.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucButton1 = new RDIFramework.Controls.UcButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(23, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 97);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "审批列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(442, 75);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "AuditUserId";
            this.Column1.HeaderText = "审批人Id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "AuditUserName";
            this.Column2.HeaderText = "审批人";
            this.Column2.Name = "Column2";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "AuditResult";
            this.Column5.HeaderText = "是否同意";
            this.Column5.Name = "Column5";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Message";
            this.Column3.HeaderText = "审批信息";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "AuditTime";
            this.Column4.HeaderText = "审批时间";
            this.Column4.Name = "Column4";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(23, 360);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 136);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "审核信息";
            // 
            // textBox5
            // 
            // 
            // 
            // 
            this.textBox5.Border.Class = "TextBoxBorder";
            this.textBox5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox5.FocusHighlightEnabled = true;
            this.textBox5.Location = new System.Drawing.Point(26, 48);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox5.SelectedValue = null;
            this.textBox5.Size = new System.Drawing.Size(398, 66);
            this.textBox5.TabIndex = 15;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(96, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "不同意";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(26, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "同意";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBill_AuditFlag);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBill_sMoney);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(23, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 121);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "业务信息";
            // 
            // txtBill_AuditFlag
            // 
            this.txtBill_AuditFlag.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtBill_AuditFlag.Border.Class = "TextBoxBorder";
            this.txtBill_AuditFlag.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBill_AuditFlag.FocusHighlightEnabled = true;
            this.txtBill_AuditFlag.Location = new System.Drawing.Point(112, 85);
            this.txtBill_AuditFlag.Name = "txtBill_AuditFlag";
            this.txtBill_AuditFlag.ReadOnly = true;
            this.txtBill_AuditFlag.SelectedValue = null;
            this.txtBill_AuditFlag.Size = new System.Drawing.Size(312, 23);
            this.txtBill_AuditFlag.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "销售出库方式：";
            // 
            // txtBill_sMoney
            // 
            this.txtBill_sMoney.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtBill_sMoney.Border.Class = "TextBoxBorder";
            this.txtBill_sMoney.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBill_sMoney.FocusHighlightEnabled = true;
            this.txtBill_sMoney.Location = new System.Drawing.Point(112, 48);
            this.txtBill_sMoney.Name = "txtBill_sMoney";
            this.txtBill_sMoney.ReadOnly = true;
            this.txtBill_sMoney.SelectedValue = null;
            this.txtBill_sMoney.Size = new System.Drawing.Size(312, 23);
            this.txtBill_sMoney.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "单据金额：";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBox1.Border.Class = "TextBoxBorder";
            this.textBox1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox1.FocusHighlightEnabled = true;
            this.textBox1.Location = new System.Drawing.Point(112, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.SelectedValue = null;
            this.textBox1.Size = new System.Drawing.Size(312, 23);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "单据名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 112);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "流程信息";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBox4.Border.Class = "TextBoxBorder";
            this.textBox4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox4.FocusHighlightEnabled = true;
            this.textBox4.Location = new System.Drawing.Point(113, 77);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.SelectedValue = null;
            this.textBox4.Size = new System.Drawing.Size(312, 23);
            this.textBox4.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBox3.Border.Class = "TextBoxBorder";
            this.textBox3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox3.FocusHighlightEnabled = true;
            this.textBox3.Location = new System.Drawing.Point(113, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.SelectedValue = null;
            this.textBox3.Size = new System.Drawing.Size(312, 23);
            this.textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBox2.Border.Class = "TextBoxBorder";
            this.textBox2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox2.FocusHighlightEnabled = true;
            this.textBox2.Location = new System.Drawing.Point(113, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.SelectedValue = null;
            this.textBox2.Size = new System.Drawing.Size(312, 23);
            this.textBox2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "流程实例名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "任务模板名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "流程模板名称：";
            // 
            // ucButton1
            // 
            this.ucButton1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ucButton1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ucButton1.Location = new System.Drawing.Point(372, 502);
            this.ucButton1.Name = "ucButton1";
            this.ucButton1.Size = new System.Drawing.Size(75, 23);
            this.ucButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ucButton1.TabIndex = 25;
            this.ucButton1.Text = "提交";
            this.ucButton1.Click += new System.EventHandler(this.ucButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 504);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCommTestAuditWF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 540);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ucButton1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "FrmCommTestAuditWF";
            this.Text = "审核单据";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox textBox1;
        private Controls.UcTextBox textBox2;
        private Controls.UcTextBox textBox4;
        private Controls.UcTextBox textBox3;
        private Controls.UcTextBox textBox5;
        private Controls.UcButton ucButton1;
        private Controls.UcTextBox txtBill_AuditFlag;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox txtBill_sMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}