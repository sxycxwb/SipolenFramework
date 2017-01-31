namespace RDIFramework.NET
{
    partial class FrmLogOn
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogOn));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.linkLblForgetPwd = new System.Windows.Forms.LinkLabel();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLoginUser = new System.Windows.Forms.Label();
            this.txtPassword = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.btnExit = new RDIFramework.Controls.UcButton();
            this.btnConfirm = new RDIFramework.Controls.UcButton();
            this.gbMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.linkLblForgetPwd);
            this.gbMain.Controls.Add(this.chkRememberPassword);
            this.gbMain.Controls.Add(this.lblPassword);
            this.gbMain.Controls.Add(this.lblLoginUser);
            this.gbMain.Controls.Add(this.txtPassword);
            this.gbMain.Controls.Add(this.txtUserName);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 76);
            this.gbMain.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.gbMain.Name = "gbMain";
            this.gbMain.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gbMain.Size = new System.Drawing.Size(539, 184);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "登录";
            // 
            // linkLblForgetPwd
            // 
            this.linkLblForgetPwd.AutoSize = true;
            this.linkLblForgetPwd.Font = new System.Drawing.Font("宋体", 10F);
            this.linkLblForgetPwd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLblForgetPwd.Location = new System.Drawing.Point(426, 105);
            this.linkLblForgetPwd.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.linkLblForgetPwd.Name = "linkLblForgetPwd";
            this.linkLblForgetPwd.Size = new System.Drawing.Size(89, 20);
            this.linkLblForgetPwd.TabIndex = 5;
            this.linkLblForgetPwd.TabStop = true;
            this.linkLblForgetPwd.Text = "忘记密码";
            this.linkLblForgetPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblForgetPwd_LinkClicked);
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberPassword.Location = new System.Drawing.Point(138, 136);
            this.chkRememberPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(151, 40);
            this.chkRememberPassword.TabIndex = 4;
            this.chkRememberPassword.Text = "记住密码";
            this.chkRememberPassword.UseVisualStyleBackColor = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(28, 106);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(105, 21);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "密　　码:";
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.AutoSize = true;
            this.lblLoginUser.Location = new System.Drawing.Point(28, 50);
            this.lblLoginUser.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(105, 21);
            this.lblLoginUser.TabIndex = 2;
            this.lblLoginUser.Text = "登录帐号:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.ButtonCustom2.Image = global::RDIFramework.NET.Properties.Resources.key;
            this.txtPassword.ButtonCustom2.Visible = true;
            this.txtPassword.FocusHighlightEnabled = true;
            this.txtPassword.Location = new System.Drawing.Point(138, 100);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SelectedValue = null;
            this.txtPassword.Size = new System.Drawing.Size(280, 43);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.ButtonCustom.Image = global::RDIFramework.NET.Properties.Resources.male;
            this.txtUserName.ButtonCustom.Visible = true;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(138, 44);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.SelectedValue = null;
            this.txtUserName.Size = new System.Drawing.Size(280, 43);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.WatermarkImage = global::RDIFramework.NET.Properties.Resources.UserNameBG;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 76);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 260);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 62);
            this.panel2.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(303, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Size = new System.Drawing.Size(85, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnExit.Location = new System.Drawing.Point(303, 10);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Size = new System.Drawing.Size(89, 33);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出(&E)";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.AutoSize = true;
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnConfirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConfirm.Location = new System.Drawing.Point(145, 10);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfirm.Size = new System.Drawing.Size(89, 33);
            this.btnConfirm.TabIndex = 8;
            this.btnConfirm.Text = "登录(&L)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FrmLogOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(539, 322);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogOn";
            this.ShowInTaskbar = true;
            this.Text = "思普林国际贸易->系统登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogOn_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogOn_Load);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private Controls.UcTextBox txtUserName;
        private Controls.UcTextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLoginUser;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Controls.UcButton btnCancel;
        private Controls.UcButton btnExit;
        private Controls.UcButton btnConfirm;
        private System.Windows.Forms.LinkLabel linkLblForgetPwd;


    }
}

