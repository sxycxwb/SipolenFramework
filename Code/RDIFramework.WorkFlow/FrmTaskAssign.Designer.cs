namespace RDIFramework.WorkFlow
{
    partial class FrmTaskAssign
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
            this.gbAssignInfo = new System.Windows.Forms.GroupBox();
            this.txtFullName = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.lblAssignUser = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.btnAssign = new RDIFramework.Controls.UcButton();
            this.gbAssignInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAssignInfo
            // 
            this.gbAssignInfo.Controls.Add(this.txtFullName);
            this.gbAssignInfo.Controls.Add(this.lblAssignUser);
            this.gbAssignInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAssignInfo.Location = new System.Drawing.Point(5, 5);
            this.gbAssignInfo.Name = "gbAssignInfo";
            this.gbAssignInfo.Size = new System.Drawing.Size(417, 101);
            this.gbAssignInfo.TabIndex = 3;
            this.gbAssignInfo.TabStop = false;
            this.gbAssignInfo.Text = "指派信息";
            // 
            // txtFullName
            // 
            // 
            // 
            // 
            this.txtFullName.BackgroundStyle.Class = "TextBoxBorder";
            this.txtFullName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.ButtonCustom.Visible = true;
            this.txtFullName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtFullName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtFullName.Location = new System.Drawing.Point(34, 54);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(366, 24);
            this.txtFullName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Text = "";
            this.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFullName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtFullName.ButtonCustomClick += new System.EventHandler(this.txtFullName_ButtonCustomClick);
            // 
            // lblAssignUser
            // 
            this.lblAssignUser.AutoSize = true;
            this.lblAssignUser.Location = new System.Drawing.Point(20, 27);
            this.lblAssignUser.Name = "lblAssignUser";
            this.lblAssignUser.Size = new System.Drawing.Size(119, 14);
            this.lblAssignUser.TabIndex = 0;
            this.lblAssignUser.Text = "选择要指派的人：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnAssign);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 44);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(325, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAssign.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAssign.Location = new System.Drawing.Point(231, 10);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAssign.TabIndex = 0;
            this.btnAssign.Text = "指派";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // FrmTaskAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 155);
            this.Controls.Add(this.gbAssignInfo);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaskAssign";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "任务指派";
            this.gbAssignInfo.ResumeLayout(false);
            this.gbAssignInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAssignInfo;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcButton btnCancel;
        private Controls.UcButton btnAssign;
        private System.Windows.Forms.Label lblAssignUser;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtFullName;
    }
}