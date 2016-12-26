namespace RDIFramework.WorkFlow
{
    partial class FrmTaskReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskReturn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.btnConfirm = new RDIFramework.Controls.UcButton();
            this.gbReturnInfo = new System.Windows.Forms.GroupBox();
            this.lblBackStep = new System.Windows.Forms.Label();
            this.cboWorkStep = new RDIFramework.Controls.UcComboBoxEx();
            this.txtBackCause = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblBackCause = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbReturnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(363, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(273, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // gbReturnInfo
            // 
            this.gbReturnInfo.Controls.Add(this.lblBackStep);
            this.gbReturnInfo.Controls.Add(this.cboWorkStep);
            this.gbReturnInfo.Controls.Add(this.txtBackCause);
            this.gbReturnInfo.Controls.Add(this.lblBackCause);
            this.gbReturnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReturnInfo.Location = new System.Drawing.Point(5, 5);
            this.gbReturnInfo.Name = "gbReturnInfo";
            this.gbReturnInfo.Size = new System.Drawing.Size(448, 208);
            this.gbReturnInfo.TabIndex = 1;
            this.gbReturnInfo.TabStop = false;
            this.gbReturnInfo.Text = "退回信息";
            // 
            // lblBackStep
            // 
            this.lblBackStep.AutoSize = true;
            this.lblBackStep.Location = new System.Drawing.Point(12, 174);
            this.lblBackStep.Name = "lblBackStep";
            this.lblBackStep.Size = new System.Drawing.Size(105, 14);
            this.lblBackStep.TabIndex = 3;
            this.lblBackStep.Text = "退回到那一步：";
            // 
            // cboWorkStep
            // 
            this.cboWorkStep.DisplayMember = "Text";
            this.cboWorkStep.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboWorkStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkStep.FormattingEnabled = true;
            this.cboWorkStep.ItemHeight = 17;
            this.cboWorkStep.Location = new System.Drawing.Point(117, 170);
            this.cboWorkStep.Name = "cboWorkStep";
            this.cboWorkStep.Size = new System.Drawing.Size(317, 23);
            this.cboWorkStep.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboWorkStep.TabIndex = 2;
            // 
            // txtBackCause
            // 
            // 
            // 
            // 
            this.txtBackCause.Border.Class = "TextBoxBorder";
            this.txtBackCause.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBackCause.FocusHighlightEnabled = true;
            this.txtBackCause.Location = new System.Drawing.Point(55, 48);
            this.txtBackCause.Multiline = true;
            this.txtBackCause.Name = "txtBackCause";
            this.txtBackCause.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBackCause.SelectedValue = ((object)(resources.GetObject("txtBackCause.SelectedValue")));
            this.txtBackCause.Size = new System.Drawing.Size(380, 112);
            this.txtBackCause.TabIndex = 1;
            // 
            // lblBackCause
            // 
            this.lblBackCause.AutoSize = true;
            this.lblBackCause.Location = new System.Drawing.Point(15, 25);
            this.lblBackCause.Name = "lblBackCause";
            this.lblBackCause.Size = new System.Drawing.Size(77, 14);
            this.lblBackCause.TabIndex = 0;
            this.lblBackCause.Text = "退回原因：";
            // 
            // FrmTaskReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 262);
            this.Controls.Add(this.gbReturnInfo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaskReturn";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "任务退回";
            this.panel1.ResumeLayout(false);
            this.gbReturnInfo.ResumeLayout(false);
            this.gbReturnInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbReturnInfo;
        private Controls.UcTextBox txtBackCause;
        private System.Windows.Forms.Label lblBackCause;
        private Controls.UcButton btnConfirm;
        private Controls.UcComboBoxEx cboWorkStep;
        private System.Windows.Forms.Label lblBackStep;
        private Controls.UcButton btnCancel;
    }
}