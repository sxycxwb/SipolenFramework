namespace RDIFramework.WinModule
{
    partial class FrmPlatFormAddInAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlatFormAddInAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAssemblyName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeveloper = new RDIFramework.Controls.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtVersion = new RDIFramework.Controls.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtGUID = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectAddIn = new RDIFramework.Controls.UcButton();
            this.txtAddInPath = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtAssemblyName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDeveloper);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtVersion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGUID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSelectAddIn);
            this.groupBox1.Controls.Add(this.txtAddInPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "插件明细";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(410, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 14);
            this.label13.TabIndex = 53;
            this.label13.Text = "*";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(410, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 51;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(410, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 14);
            this.label10.TabIndex = 50;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(410, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 49;
            this.label9.Text = "*";
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.AccessibleName = "EmptyValue|NotNull";
            this.txtAssemblyName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtAssemblyName.Border.Class = "TextBoxBorder";
            this.txtAssemblyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAssemblyName.FocusHighlightEnabled = true;
            this.txtAssemblyName.Location = new System.Drawing.Point(113, 116);
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.ReadOnly = true;
            this.txtAssemblyName.SelectedValue = ((object)(resources.GetObject("txtAssemblyName.SelectedValue")));
            this.txtAssemblyName.Size = new System.Drawing.Size(291, 23);
            this.txtAssemblyName.TabIndex = 20;
            this.txtAssemblyName.Tag = "程序集名称";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "程序集名称:";
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(113, 204);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.SelectedValue = ((object)(resources.GetObject("txtDescription.SelectedValue")));
            this.txtDescription.Size = new System.Drawing.Size(291, 147);
            this.txtDescription.TabIndex = 18;
            this.txtDescription.Tag = "描述";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "描述:";
            // 
            // txtDeveloper
            // 
            this.txtDeveloper.AccessibleName = "EmptyValue";
            // 
            // 
            // 
            this.txtDeveloper.Border.Class = "TextBoxBorder";
            this.txtDeveloper.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDeveloper.FocusHighlightEnabled = true;
            this.txtDeveloper.Location = new System.Drawing.Point(113, 175);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.SelectedValue = ((object)(resources.GetObject("txtDeveloper.SelectedValue")));
            this.txtDeveloper.Size = new System.Drawing.Size(291, 23);
            this.txtDeveloper.TabIndex = 16;
            this.txtDeveloper.Tag = "插件开发人员";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "插件开发人员:";
            // 
            // txtVersion
            // 
            this.txtVersion.AccessibleName = "EmptyValue|NotNull";
            this.txtVersion.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtVersion.Border.Class = "TextBoxBorder";
            this.txtVersion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVersion.FocusHighlightEnabled = true;
            this.txtVersion.Location = new System.Drawing.Point(113, 146);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.SelectedValue = ((object)(resources.GetObject("txtVersion.SelectedValue")));
            this.txtVersion.Size = new System.Drawing.Size(291, 23);
            this.txtVersion.TabIndex = 14;
            this.txtVersion.Tag = "插件版本";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "插件版本:";
            // 
            // txtName
            // 
            this.txtName.AccessibleName = "EmptyValue|NotNull";
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.FocusHighlightEnabled = true;
            this.txtName.Location = new System.Drawing.Point(113, 86);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.SelectedValue = ((object)(resources.GetObject("txtName.SelectedValue")));
            this.txtName.Size = new System.Drawing.Size(291, 23);
            this.txtName.TabIndex = 10;
            this.txtName.Tag = "名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "名称:";
            // 
            // txtGUID
            // 
            this.txtGUID.AccessibleName = "EmptyValue|NotNull";
            this.txtGUID.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtGUID.Border.Class = "TextBoxBorder";
            this.txtGUID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGUID.FocusHighlightEnabled = true;
            this.txtGUID.Location = new System.Drawing.Point(113, 57);
            this.txtGUID.Name = "txtGUID";
            this.txtGUID.ReadOnly = true;
            this.txtGUID.SelectedValue = ((object)(resources.GetObject("txtGUID.SelectedValue")));
            this.txtGUID.Size = new System.Drawing.Size(291, 23);
            this.txtGUID.TabIndex = 8;
            this.txtGUID.Tag = "GUID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "GUID:";
            // 
            // btnSelectAddIn
            // 
            this.btnSelectAddIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectAddIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAddIn.AutoSize = true;
            this.btnSelectAddIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnSelectAddIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectAddIn.Location = new System.Drawing.Point(407, 25);
            this.btnSelectAddIn.Name = "btnSelectAddIn";
            this.btnSelectAddIn.Padding = new System.Windows.Forms.Padding(1);
            this.btnSelectAddIn.Size = new System.Drawing.Size(73, 26);
            this.btnSelectAddIn.TabIndex = 6;
            this.btnSelectAddIn.Text = "选择...";
            this.btnSelectAddIn.Click += new System.EventHandler(this.btnSelectAddIn_Click);
            // 
            // txtAddInPath
            // 
            this.txtAddInPath.AccessibleName = "EmptyValue|NotNull";
            this.txtAddInPath.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtAddInPath.Border.Class = "TextBoxBorder";
            this.txtAddInPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddInPath.FocusHighlightEnabled = true;
            this.txtAddInPath.Location = new System.Drawing.Point(113, 26);
            this.txtAddInPath.Name = "txtAddInPath";
            this.txtAddInPath.ReadOnly = true;
            this.txtAddInPath.SelectedValue = ((object)(resources.GetObject("txtAddInPath.SelectedValue")));
            this.txtAddInPath.Size = new System.Drawing.Size(291, 23);
            this.txtAddInPath.TabIndex = 1;
            this.txtAddInPath.Tag = "插件路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "插件路径:";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(340, 383);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(1);
            this.btnAdd.Size = new System.Drawing.Size(73, 26);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(419, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(1);
            this.btnCancel.Size = new System.Drawing.Size(73, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "插件文件|*.dll|所有文件|*.*";
            // 
            // FrmPlatFormAddInAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 414);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmPlatFormAddInAdd";
            this.Text = "新增插件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.UcButton btnAdd;
        private Controls.UcButton btnCancel;
        private System.Windows.Forms.Label label1;
        private Controls.UcButton btnSelectAddIn;
        private Controls.UcTextBox txtAddInPath;
        private System.Windows.Forms.Label label2;
        private Controls.UcTextBox txtGUID;
        private Controls.UcTextBox txtName;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private Controls.UcTextBox txtDeveloper;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox txtVersion;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtAssemblyName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}