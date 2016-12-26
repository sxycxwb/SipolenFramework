namespace RDIFramework.WorkFlow
{
    partial class FrmLinkConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLinkConfig));
            this.gbCommandPriority = new System.Windows.Forms.GroupBox();
            this.cboCommandName = new System.Windows.Forms.ComboBox();
            this.ndPriority = new System.Windows.Forms.NumericUpDown();
            this.lblCommandPriorityTip = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.GroupBox();
            this.tbxDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.gbExpressConfig = new System.Windows.Forms.GroupBox();
            this.tbxCondition = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnVarChoose = new RDIFramework.Controls.UcButton();
            this.lblExpress = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbCommandPriority.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndPriority)).BeginInit();
            this.lblDescription.SuspendLayout();
            this.gbExpressConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.gbCommandPriority);
            this.plclassFill.Controls.Add(this.lblDescription);
            this.plclassFill.Controls.Add(this.gbExpressConfig);
            this.plclassFill.Size = new System.Drawing.Size(431, 402);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 349);
            this.plclassBottom.Size = new System.Drawing.Size(431, 53);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(315, 16);
            this.btnClose.Size = new System.Drawing.Size(73, 23);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(223, 16);
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbCommandPriority
            // 
            this.gbCommandPriority.Controls.Add(this.cboCommandName);
            this.gbCommandPriority.Controls.Add(this.ndPriority);
            this.gbCommandPriority.Controls.Add(this.lblCommandPriorityTip);
            this.gbCommandPriority.Location = new System.Drawing.Point(10, 9);
            this.gbCommandPriority.Name = "gbCommandPriority";
            this.gbCommandPriority.Size = new System.Drawing.Size(411, 51);
            this.gbCommandPriority.TabIndex = 9;
            this.gbCommandPriority.TabStop = false;
            this.gbCommandPriority.Text = "命令优先级";
            // 
            // cboCommandName
            // 
            this.cboCommandName.FormattingEnabled = true;
            this.cboCommandName.Location = new System.Drawing.Point(13, 19);
            this.cboCommandName.Name = "cboCommandName";
            this.cboCommandName.Size = new System.Drawing.Size(108, 22);
            this.cboCommandName.TabIndex = 8;
            this.cboCommandName.SelectedIndexChanged += new System.EventHandler(this.cboCommandName_SelectedIndexChanged);
            // 
            // ndPriority
            // 
            this.ndPriority.Location = new System.Drawing.Point(128, 18);
            this.ndPriority.Name = "ndPriority";
            this.ndPriority.Size = new System.Drawing.Size(52, 23);
            this.ndPriority.TabIndex = 7;
            // 
            // lblCommandPriorityTip
            // 
            this.lblCommandPriorityTip.AutoEllipsis = true;
            this.lblCommandPriorityTip.Location = new System.Drawing.Point(187, 18);
            this.lblCommandPriorityTip.Name = "lblCommandPriorityTip";
            this.lblCommandPriorityTip.Size = new System.Drawing.Size(203, 27);
            this.lblCommandPriorityTip.TabIndex = 6;
            this.lblCommandPriorityTip.Text = "(优先级由高到低0,1,2,3...)";
            this.lblCommandPriorityTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.Controls.Add(this.tbxDes);
            this.lblDescription.Location = new System.Drawing.Point(0, 245);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(422, 99);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.TabStop = false;
            this.lblDescription.Text = "备注说明";
            // 
            // tbxDes
            // 
            // 
            // 
            // 
            this.tbxDes.Border.Class = "TextBoxBorder";
            this.tbxDes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDes.FocusHighlightEnabled = true;
            this.tbxDes.Location = new System.Drawing.Point(23, 24);
            this.tbxDes.Multiline = true;
            this.tbxDes.Name = "tbxDes";
            this.tbxDes.SelectedValue = ((object)(resources.GetObject("tbxDes.SelectedValue")));
            this.tbxDes.Size = new System.Drawing.Size(377, 69);
            this.tbxDes.TabIndex = 0;
            // 
            // gbExpressConfig
            // 
            this.gbExpressConfig.Controls.Add(this.tbxCondition);
            this.gbExpressConfig.Controls.Add(this.btnVarChoose);
            this.gbExpressConfig.Controls.Add(this.lblExpress);
            this.gbExpressConfig.Controls.Add(this.cboOperator);
            this.gbExpressConfig.Controls.Add(this.lblOperator);
            this.gbExpressConfig.Location = new System.Drawing.Point(9, 66);
            this.gbExpressConfig.Name = "gbExpressConfig";
            this.gbExpressConfig.Size = new System.Drawing.Size(412, 172);
            this.gbExpressConfig.TabIndex = 7;
            this.gbExpressConfig.TabStop = false;
            this.gbExpressConfig.Text = "表达式配置";
            // 
            // tbxCondition
            // 
            // 
            // 
            // 
            this.tbxCondition.Border.Class = "TextBoxBorder";
            this.tbxCondition.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxCondition.FocusHighlightEnabled = true;
            this.tbxCondition.Location = new System.Drawing.Point(14, 82);
            this.tbxCondition.Multiline = true;
            this.tbxCondition.Name = "tbxCondition";
            this.tbxCondition.SelectedValue = ((object)(resources.GetObject("tbxCondition.SelectedValue")));
            this.tbxCondition.Size = new System.Drawing.Size(377, 83);
            this.tbxCondition.TabIndex = 12;
            // 
            // btnVarChoose
            // 
            this.btnVarChoose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVarChoose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVarChoose.Location = new System.Drawing.Point(14, 23);
            this.btnVarChoose.Name = "btnVarChoose";
            this.btnVarChoose.Size = new System.Drawing.Size(87, 26);
            this.btnVarChoose.TabIndex = 11;
            this.btnVarChoose.Text = "变量选择";
            this.btnVarChoose.Click += new System.EventHandler(this.btnVarChoose_Click);
            // 
            // lblExpress
            // 
            this.lblExpress.AutoSize = true;
            this.lblExpress.Location = new System.Drawing.Point(12, 60);
            this.lblExpress.Name = "lblExpress";
            this.lblExpress.Size = new System.Drawing.Size(49, 14);
            this.lblExpress.TabIndex = 9;
            this.lblExpress.Text = "表达式";
            this.lblExpress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboOperator
            // 
            this.cboOperator.Items.AddRange(new object[] {
            "<",
            ">",
            "=",
            ">=",
            "<=",
            "!=",
            "(",
            ")",
            "And",
            "Or",
            ""});
            this.cboOperator.Location = new System.Drawing.Point(196, 25);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(83, 22);
            this.cboOperator.TabIndex = 6;
            this.cboOperator.SelectedIndexChanged += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoEllipsis = true;
            this.lblOperator.Location = new System.Drawing.Point(107, 23);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(83, 26);
            this.lblOperator.TabIndex = 5;
            this.lblOperator.Text = "运算符";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmLinkConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 402);
            this.Name = "FrmLinkConfig";
            this.Text = "连线配置";
            this.Load += new System.EventHandler(this.LinkConfig_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.gbCommandPriority.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ndPriority)).EndInit();
            this.lblDescription.ResumeLayout(false);
            this.gbExpressConfig.ResumeLayout(false);
            this.gbExpressConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCommandPriority;
        private System.Windows.Forms.ComboBox cboCommandName;
        private System.Windows.Forms.NumericUpDown ndPriority;
        private System.Windows.Forms.Label lblCommandPriorityTip;
        private System.Windows.Forms.GroupBox lblDescription;
        private Controls.UcTextBox tbxDes;
        private System.Windows.Forms.GroupBox gbExpressConfig;
        private Controls.UcTextBox tbxCondition;
        private Controls.UcButton btnVarChoose;
        private System.Windows.Forms.Label lblExpress;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.Label lblOperator;
    }
}