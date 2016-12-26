namespace RDIFramework.WinModule
{
    partial class FrmGenerateUpdaterConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenerateUpdaterConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtURLAddress = new RDIFramework.Controls.UcTextBox(this.components);
            this.chkNeedReStart = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSigleUpdateFilePath = new RDIFramework.Controls.UcButton();
            this.txtUpdateFiles = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectSavePath = new RDIFramework.Controls.UcButton();
            this.txtSaveTo = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfigFileName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new RDIFramework.Controls.UcButton();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtURLAddress);
            this.groupBox1.Controls.Add(this.chkNeedReStart);
            this.groupBox1.Controls.Add(this.btnSigleUpdateFilePath);
            this.groupBox1.Controls.Add(this.txtUpdateFiles);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSelectSavePath);
            this.groupBox1.Controls.Add(this.txtSaveTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtConfigFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 194);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "URL地址[前缀]:";
            // 
            // txtURLAddress
            // 
            this.txtURLAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtURLAddress.Border.Class = "TextBoxBorder";
            this.txtURLAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtURLAddress.FocusHighlightEnabled = true;
            this.txtURLAddress.Location = new System.Drawing.Point(137, 125);
            this.txtURLAddress.Name = "txtURLAddress";
            this.txtURLAddress.SelectedValue = ((object)(resources.GetObject("txtURLAddress.SelectedValue")));
            this.txtURLAddress.Size = new System.Drawing.Size(412, 23);
            this.txtURLAddress.TabIndex = 21;
            this.txtURLAddress.Text = "http://localhost/RDIFrameworkUpdater/";
            // 
            // chkNeedReStart
            // 
            this.chkNeedReStart.AutoSize = true;
            // 
            // 
            // 
            this.chkNeedReStart.BackgroundStyle.Class = "";
            this.chkNeedReStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkNeedReStart.Checked = true;
            this.chkNeedReStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNeedReStart.CheckValue = "Y";
            this.chkNeedReStart.Location = new System.Drawing.Point(138, 159);
            this.chkNeedReStart.Name = "chkNeedReStart";
            this.chkNeedReStart.Size = new System.Drawing.Size(215, 20);
            this.chkNeedReStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkNeedReStart.TabIndex = 20;
            this.chkNeedReStart.Text = "更新后是否需要重启应用程序";
            // 
            // btnSigleUpdateFilePath
            // 
            this.btnSigleUpdateFilePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSigleUpdateFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSigleUpdateFilePath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSigleUpdateFilePath.Location = new System.Drawing.Point(429, 96);
            this.btnSigleUpdateFilePath.Name = "btnSigleUpdateFilePath";
            this.btnSigleUpdateFilePath.Size = new System.Drawing.Size(120, 23);
            this.btnSigleUpdateFilePath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSigleUpdateFilePath.TabIndex = 18;
            this.btnSigleUpdateFilePath.Text = "选择更新文件...";
            this.btnSigleUpdateFilePath.Click += new System.EventHandler(this.btnSigleUpdateFilePath_Click);
            // 
            // txtUpdateFiles
            // 
            this.txtUpdateFiles.BackColor = System.Drawing.Color.AntiqueWhite;
            // 
            // 
            // 
            this.txtUpdateFiles.Border.Class = "TextBoxBorder";
            this.txtUpdateFiles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUpdateFiles.FocusHighlightEnabled = true;
            this.txtUpdateFiles.Location = new System.Drawing.Point(138, 96);
            this.txtUpdateFiles.Name = "txtUpdateFiles";
            this.txtUpdateFiles.ReadOnly = true;
            this.txtUpdateFiles.SelectedValue = ((object)(resources.GetObject("txtUpdateFiles.SelectedValue")));
            this.txtUpdateFiles.Size = new System.Drawing.Size(281, 23);
            this.txtUpdateFiles.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 15;
            this.label4.Text = "选择待更新的文件：";
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectSavePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectSavePath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectSavePath.Location = new System.Drawing.Point(429, 63);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(123, 27);
            this.btnSelectSavePath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectSavePath.TabIndex = 14;
            this.btnSelectSavePath.Text = "选择路径...";
            this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.BackColor = System.Drawing.Color.AntiqueWhite;
            // 
            // 
            // 
            this.txtSaveTo.Border.Class = "TextBoxBorder";
            this.txtSaveTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSaveTo.FocusHighlightEnabled = true;
            this.txtSaveTo.Location = new System.Drawing.Point(138, 65);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.ReadOnly = true;
            this.txtSaveTo.SelectedValue = ((object)(resources.GetObject("txtSaveTo.SelectedValue")));
            this.txtSaveTo.Size = new System.Drawing.Size(281, 23);
            this.txtSaveTo.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "保存到：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(424, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "注：建议不要修改，使用默认的名称。";
            // 
            // txtConfigFileName
            // 
            this.txtConfigFileName.BackColor = System.Drawing.Color.AntiqueWhite;
            // 
            // 
            // 
            this.txtConfigFileName.Border.Class = "TextBoxBorder";
            this.txtConfigFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtConfigFileName.FocusHighlightEnabled = true;
            this.txtConfigFileName.Location = new System.Drawing.Point(138, 28);
            this.txtConfigFileName.Name = "txtConfigFileName";
            this.txtConfigFileName.ReadOnly = true;
            this.txtConfigFileName.SelectedValue = ((object)(resources.GetObject("txtConfigFileName.SelectedValue")));
            this.txtConfigFileName.Size = new System.Drawing.Size(281, 23);
            this.txtConfigFileName.TabIndex = 10;
            this.txtConfigFileName.Text = "AutoupdateService.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "配置文件名称：";
            // 
            // btnGenerate
            // 
            this.btnGenerate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGenerate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerate.Location = new System.Drawing.Point(490, 207);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(71, 23);
            this.btnGenerate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "生成(&G)";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(579, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmGenerateUpdaterConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 239);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "FrmGenerateUpdaterConfig";
            this.Text = "生成自动升级配置文件【服务端】";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.UcTextBox txtUpdateFiles;
        private System.Windows.Forms.Label label4;
        private Controls.UcButton btnSelectSavePath;
        private Controls.UcTextBox txtSaveTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Controls.UcTextBox txtConfigFileName;
        private System.Windows.Forms.Label label1;
        private Controls.UcButton btnGenerate;
        private Controls.UcButton btnCancel;
        private Controls.UcButton btnSigleUpdateFilePath;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkNeedReStart;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtURLAddress;

    }
}