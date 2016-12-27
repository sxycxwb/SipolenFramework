/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:57:55
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePassword));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtNewPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtOriginalPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblOriginalPassword = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnConfirm = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.pnlMain.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.MistyRose;
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(345, 67);
            this.pnlTop.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 67);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(345, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gbDetail);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMain.Size = new System.Drawing.Size(345, 162);
            this.pnlMain.TabIndex = 2;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.label20);
            this.gbDetail.Controls.Add(this.txtConfirmPassword);
            this.gbDetail.Controls.Add(this.txtNewPassword);
            this.gbDetail.Controls.Add(this.lblConfirmPassword);
            this.gbDetail.Controls.Add(this.lblNewPassword);
            this.gbDetail.Controls.Add(this.txtOriginalPassword);
            this.gbDetail.Controls.Add(this.lblOriginalPassword);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(5, 5);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(335, 152);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "当前用户[无]";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(309, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 46;
            this.label4.Text = "*";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(309, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 14);
            this.label20.TabIndex = 45;
            this.label20.Text = "*";
            // 
            // txtConfirmPassword
            // 
            // 
            // 
            // 
            this.txtConfirmPassword.Border.Class = "TextBoxBorder";
            this.txtConfirmPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfirmPassword.FocusHighlightEnabled = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(110, 111);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.SelectedValue = null;
            this.txtConfirmPassword.Size = new System.Drawing.Size(193, 23);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // txtNewPassword
            // 
            // 
            // 
            // 
            this.txtNewPassword.Border.Class = "TextBoxBorder";
            this.txtNewPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPassword.FocusHighlightEnabled = true;
            this.txtNewPassword.Location = new System.Drawing.Point(110, 73);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.SelectedValue = null;
            this.txtNewPassword.Size = new System.Drawing.Size(193, 23);
            this.txtNewPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoEllipsis = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(3, 116);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(112, 14);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "确认密码：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoEllipsis = true;
            this.lblNewPassword.Location = new System.Drawing.Point(7, 78);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(108, 14);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "新密码：";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOriginalPassword
            // 
            // 
            // 
            // 
            this.txtOriginalPassword.Border.Class = "TextBoxBorder";
            this.txtOriginalPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOriginalPassword.FocusHighlightEnabled = true;
            this.txtOriginalPassword.Location = new System.Drawing.Point(110, 31);
            this.txtOriginalPassword.Name = "txtOriginalPassword";
            this.txtOriginalPassword.PasswordChar = '*';
            this.txtOriginalPassword.SelectedValue = null;
            this.txtOriginalPassword.Size = new System.Drawing.Size(193, 23);
            this.txtOriginalPassword.TabIndex = 1;
            // 
            // lblOriginalPassword
            // 
            this.lblOriginalPassword.AutoEllipsis = true;
            this.lblOriginalPassword.Location = new System.Drawing.Point(3, 36);
            this.lblOriginalPassword.Name = "lblOriginalPassword";
            this.lblOriginalPassword.Size = new System.Drawing.Size(112, 14);
            this.lblOriginalPassword.TabIndex = 0;
            this.lblOriginalPassword.Text = "原密码：";
            this.lblOriginalPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 53);
            this.panel2.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(196, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(1);
            this.btnConfirm.Size = new System.Drawing.Size(58, 26);
            this.btnConfirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConfirm.TabIndex = 3;
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
            this.btnCancel.Location = new System.Drawing.Point(261, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btnCancel.Size = new System.Drawing.Size(58, 26);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 285);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.Name = "FrmChangePassword";
            this.Text = "修改密码";
            this.pnlMain.ResumeLayout(false);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label lblOriginalPassword;
        private Controls.UcTextBox txtOriginalPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private Controls.UcTextBox txtConfirmPassword;
        private Controls.UcTextBox txtNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private Controls.UcButton btnConfirm;
        private Controls.UcButton btnCancel;
    }
}