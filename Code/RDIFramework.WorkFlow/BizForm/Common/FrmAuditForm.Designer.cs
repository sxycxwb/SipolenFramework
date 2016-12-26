namespace RDIFramework.WorkFlow
{
    partial class FrmAuditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuditForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAuditMessage = new RDIFramework.Controls.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.rbDisAggree = new System.Windows.Forms.RadioButton();
            this.rbAggree = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDuty = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDepartment = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnSave = new RDIFramework.Controls.UcButton();
            this.groupBox1.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAuditMessage);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rbDisAggree);
            this.groupBox1.Controls.Add(this.rbAggree);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDuty);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 359);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "审批信息";
            // 
            // txtAuditMessage
            // 
            // 
            // 
            // 
            this.txtAuditMessage.Border.Class = "TextBoxBorder";
            this.txtAuditMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAuditMessage.FocusHighlightEnabled = true;
            this.txtAuditMessage.Location = new System.Drawing.Point(106, 122);
            this.txtAuditMessage.Multiline = true;
            this.txtAuditMessage.Name = "txtAuditMessage";
            this.txtAuditMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAuditMessage.SelectedValue = ((object)(resources.GetObject("txtAuditMessage.SelectedValue")));
            this.txtAuditMessage.Size = new System.Drawing.Size(603, 190);
            this.txtAuditMessage.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "审批意见：";
            // 
            // rbDisAggree
            // 
            this.rbDisAggree.AutoSize = true;
            this.rbDisAggree.Location = new System.Drawing.Point(221, 92);
            this.rbDisAggree.Name = "rbDisAggree";
            this.rbDisAggree.Size = new System.Drawing.Size(67, 18);
            this.rbDisAggree.TabIndex = 10;
            this.rbDisAggree.TabStop = true;
            this.rbDisAggree.Text = "不同意";
            this.rbDisAggree.UseVisualStyleBackColor = true;
            // 
            // rbAggree
            // 
            this.rbAggree.AutoSize = true;
            this.rbAggree.Location = new System.Drawing.Point(106, 90);
            this.rbAggree.Name = "rbAggree";
            this.rbAggree.Size = new System.Drawing.Size(53, 18);
            this.rbAggree.TabIndex = 9;
            this.rbAggree.TabStop = true;
            this.rbAggree.Text = "同意";
            this.rbAggree.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "审批结果：";
            // 
            // txtDuty
            // 
            // 
            // 
            // 
            this.txtDuty.Border.Class = "TextBoxBorder";
            this.txtDuty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDuty.FocusHighlightEnabled = true;
            this.txtDuty.Location = new System.Drawing.Point(455, 57);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.SelectedValue = ((object)(resources.GetObject("txtDuty.SelectedValue")));
            this.txtDuty.Size = new System.Drawing.Size(254, 23);
            this.txtDuty.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "职务：";
            // 
            // txtDepartment
            // 
            // 
            // 
            // 
            this.txtDepartment.Border.Class = "TextBoxBorder";
            this.txtDepartment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDepartment.FocusHighlightEnabled = true;
            this.txtDepartment.Location = new System.Drawing.Point(106, 55);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.SelectedValue = ((object)(resources.GetObject("txtDepartment.SelectedValue")));
            this.txtDepartment.Size = new System.Drawing.Size(254, 23);
            this.txtDepartment.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "部门：";
            // 
            // txtUserName
            // 
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(455, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = ((object)(resources.GetObject("txtUserName.SelectedValue")));
            this.txtUserName.Size = new System.Drawing.Size(254, 23);
            this.txtUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "审批人：";
            // 
            // txtUserId
            // 
            // 
            // 
            // 
            this.txtUserId.Border.Class = "TextBoxBorder";
            this.txtUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserId.FocusHighlightEnabled = true;
            this.txtUserId.Location = new System.Drawing.Point(106, 26);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.SelectedValue = ((object)(resources.GetObject("txtUserId.SelectedValue")));
            this.txtUserId.Size = new System.Drawing.Size(254, 23);
            this.txtUserId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "审批人Id：";
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlTool.Controls.Add(this.btnSave);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(786, 49);
            this.pnlTool.TabIndex = 1;
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
            this.btnSave.Text = "保存审批信息";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmAuditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(786, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlTool);
            this.Name = "FrmAuditForm";
            this.Text = "审批信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.UcTextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private Controls.UcTextBox txtDuty;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtDepartment;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbDisAggree;
        private System.Windows.Forms.RadioButton rbAggree;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox txtAuditMessage;
        private System.Windows.Forms.Panel pnlTool;
        private Controls.UcButton btnSave;
    }
}