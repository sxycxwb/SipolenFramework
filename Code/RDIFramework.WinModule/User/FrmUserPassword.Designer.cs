/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:57
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmUserPassword
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
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.btnDeletePassword = new RDIFramework.Controls.UcButton();
            this.btnSetDefaultPwd = new RDIFramework.Controls.UcButton();
            this.gbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.lblNewPassword);
            this.gbDetail.Controls.Add(this.label20);
            this.gbDetail.Controls.Add(this.lblUserNameReq);
            this.gbDetail.Controls.Add(this.txtConfirmPassword);
            this.gbDetail.Controls.Add(this.lblConfirmPassword);
            this.gbDetail.Controls.Add(this.txtNewPassword);
            this.gbDetail.Location = new System.Drawing.Point(14, 12);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(371, 129);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "设置密码";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoEllipsis = true;
            this.lblNewPassword.Location = new System.Drawing.Point(6, 42);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(103, 14);
            this.lblNewPassword.TabIndex = 45;
            this.lblNewPassword.Text = "新密码：";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(325, 83);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 14);
            this.label20.TabIndex = 44;
            this.label20.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(325, 44);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 43;
            this.lblUserNameReq.Text = "*";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.AccessibleName = "EmptyValue|NotNull";
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtConfirmPassword.Border.Class = "TextBoxBorder";
            this.txtConfirmPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfirmPassword.FocusHighlightEnabled = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(111, 78);
            this.txtConfirmPassword.MaxLength = 15;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.SelectedValue = null;
            this.txtConfirmPassword.Size = new System.Drawing.Size(209, 23);
            this.txtConfirmPassword.TabIndex = 1;
            this.txtConfirmPassword.Tag = "确认密码";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoEllipsis = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(6, 83);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(104, 14);
            this.lblConfirmPassword.TabIndex = 41;
            this.lblConfirmPassword.Text = "确认密码：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.AccessibleName = "EmptyValue|NotNull";
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNewPassword.Border.Class = "TextBoxBorder";
            this.txtNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPassword.FocusHighlightEnabled = true;
            this.txtNewPassword.Location = new System.Drawing.Point(111, 37);
            this.txtNewPassword.MaxLength = 20;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.SelectedValue = null;
            this.txtNewPassword.Size = new System.Drawing.Size(209, 23);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.Tag = "新密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 39;
            this.label1.Text = "新：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(253, 147);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(1);
            this.btnConfirm.Size = new System.Drawing.Size(58, 26);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(324, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btnCancel.Size = new System.Drawing.Size(58, 26);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeletePassword
            // 
            this.btnDeletePassword.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeletePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletePassword.AutoSize = true;
            this.btnDeletePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnDeletePassword.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeletePassword.Location = new System.Drawing.Point(12, 147);
            this.btnDeletePassword.Name = "btnDeletePassword";
            this.btnDeletePassword.Padding = new System.Windows.Forms.Padding(1);
            this.btnDeletePassword.Size = new System.Drawing.Size(77, 26);
            this.btnDeletePassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeletePassword.TabIndex = 2;
            this.btnDeletePassword.Text = "删除密码";
            this.btnDeletePassword.Click += new System.EventHandler(this.btnDeletePassword_Click);
            // 
            // btnSetDefaultPwd
            // 
            this.btnSetDefaultPwd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetDefaultPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetDefaultPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSetDefaultPwd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetDefaultPwd.Location = new System.Drawing.Point(102, 147);
            this.btnSetDefaultPwd.Name = "btnSetDefaultPwd";
            this.btnSetDefaultPwd.Padding = new System.Windows.Forms.Padding(1);
            this.btnSetDefaultPwd.Size = new System.Drawing.Size(127, 26);
            this.btnSetDefaultPwd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetDefaultPwd.TabIndex = 3;
            this.btnSetDefaultPwd.Text = "设为默认密码";
            this.btnSetDefaultPwd.Click += new System.EventHandler(this.btnSetDefaultPwd_Click);
            // 
            // FrmUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 183);
            this.Controls.Add(this.btnSetDefaultPwd);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnDeletePassword);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserPassword";
            this.Text = "设置用户密码";
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDetail;
        private Controls.UcTextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private Controls.UcTextBox txtNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.Label lblNewPassword;
        private Controls.UcButton btnConfirm;
        private Controls.UcButton btnCancel;
        private Controls.UcButton btnDeletePassword;
        private Controls.UcButton btnSetDefaultPwd;
    }
}