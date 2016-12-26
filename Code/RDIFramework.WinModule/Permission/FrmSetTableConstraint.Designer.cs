namespace RDIFramework.WinModule
{
    partial class FrmSetTableConstraint
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
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.lblUserOrRole = new System.Windows.Forms.ToolStripLabel();
            this.txtUserOrRole = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTestConstraint = new System.Windows.Forms.ToolStripButton();
            this.btnClearConstraint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnShowConstraintData = new RDIFramework.Controls.UcButton();
            this.txtTableConstraint = new System.Windows.Forms.RichTextBox();
            this.tlsTool.SuspendLayout();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserOrRole,
            this.txtUserOrRole,
            this.toolStripSeparator5,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnTestConstraint,
            this.btnClearConstraint,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(695, 25);
            this.tlsTool.TabIndex = 20;
            this.tlsTool.Text = "toolStrip1";
            // 
            // lblUserOrRole
            // 
            this.lblUserOrRole.Name = "lblUserOrRole";
            this.lblUserOrRole.Size = new System.Drawing.Size(114, 22);
            this.lblUserOrRole.Text = "用户/角色(&U)：";
            // 
            // txtUserOrRole
            // 
            this.txtUserOrRole.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserOrRole.Name = "txtUserOrRole";
            this.txtUserOrRole.ReadOnly = true;
            this.txtUserOrRole.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::RDIFramework.WinModule.Properties.Resources.btnSave_Image;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTestConstraint
            // 
            this.btnTestConstraint.Image = global::RDIFramework.WinModule.Properties.Resources.menu_check;
            this.btnTestConstraint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestConstraint.Name = "btnTestConstraint";
            this.btnTestConstraint.Size = new System.Drawing.Size(102, 22);
            this.btnTestConstraint.Text = "验证表达式";
            this.btnTestConstraint.Click += new System.EventHandler(this.btnTestConstraint_Click);
            // 
            // btnClearConstraint
            // 
            this.btnClearConstraint.Image = global::RDIFramework.WinModule.Properties.Resources.清除查询条件;
            this.btnClearConstraint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearConstraint.Name = "btnClearConstraint";
            this.btnClearConstraint.Size = new System.Drawing.Size(102, 22);
            this.btnClearConstraint.Text = "清除表达式";
            this.btnClearConstraint.Click += new System.EventHandler(this.btnClearConstraint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.chkEnabled);
            this.gbMain.Controls.Add(this.btnShowConstraintData);
            this.gbMain.Controls.Add(this.txtTableConstraint);
            this.gbMain.Location = new System.Drawing.Point(12, 39);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(663, 195);
            this.gbMain.TabIndex = 21;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "设置约束条件";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoEllipsis = true;
            this.chkEnabled.Location = new System.Drawing.Point(44, 27);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(104, 18);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // btnShowConstraintData
            // 
            this.btnShowConstraintData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowConstraintData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowConstraintData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowConstraintData.Location = new System.Drawing.Point(499, 20);
            this.btnShowConstraintData.Name = "btnShowConstraintData";
            this.btnShowConstraintData.Size = new System.Drawing.Size(139, 23);
            this.btnShowConstraintData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnShowConstraintData.TabIndex = 2;
            this.btnShowConstraintData.Text = "查看约束数据集";
            this.btnShowConstraintData.Click += new System.EventHandler(this.btnShowConstraintData_Click);
            // 
            // txtTableConstraint
            // 
            this.txtTableConstraint.Location = new System.Drawing.Point(44, 58);
            this.txtTableConstraint.Name = "txtTableConstraint";
            this.txtTableConstraint.Size = new System.Drawing.Size(594, 114);
            this.txtTableConstraint.TabIndex = 1;
            this.txtTableConstraint.Text = "";
            // 
            // FrmSetTableConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 256);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlsTool);
            this.MaximizeBox = false;
            this.Name = "FrmSetTableConstraint";
            this.Text = "设置约束条件";
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripLabel lblUserOrRole;
        private System.Windows.Forms.ToolStripTextBox txtUserOrRole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTestConstraint;
        private System.Windows.Forms.ToolStripButton btnClearConstraint;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.RichTextBox txtTableConstraint;
        private Controls.UcButton btnShowConstraintData;
        private System.Windows.Forms.CheckBox chkEnabled;
    }
}