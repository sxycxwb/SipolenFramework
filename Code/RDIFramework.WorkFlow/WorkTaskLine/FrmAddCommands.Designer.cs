namespace RDIFramework.WorkFlow
{
    partial class FrmAddCommands
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddCommands));
            this.gbProcessCommand = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCommandName = new System.Windows.Forms.Label();
            this.tbxCommandName = new RDIFramework.Controls.UcTextBox(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbProcessCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.gbProcessCommand);
            this.plclassFill.Size = new System.Drawing.Size(317, 169);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 125);
            this.plclassBottom.Size = new System.Drawing.Size(317, 44);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(200, 10);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(98, 10);
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbProcessCommand
            // 
            this.gbProcessCommand.Controls.Add(this.lblDescription);
            this.gbProcessCommand.Controls.Add(this.tbxDes);
            this.gbProcessCommand.Controls.Add(this.lblCommandName);
            this.gbProcessCommand.Controls.Add(this.tbxCommandName);
            this.gbProcessCommand.Location = new System.Drawing.Point(12, 12);
            this.gbProcessCommand.Name = "gbProcessCommand";
            this.gbProcessCommand.Size = new System.Drawing.Size(290, 104);
            this.gbProcessCommand.TabIndex = 0;
            this.gbProcessCommand.TabStop = false;
            this.gbProcessCommand.Text = "处理命令";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 58);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(87, 14);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "描述:";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxDes
            // 
            // 
            // 
            // 
            this.tbxDes.Border.Class = "TextBoxBorder";
            this.tbxDes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDes.FocusHighlightEnabled = true;
            this.tbxDes.Location = new System.Drawing.Point(96, 55);
            this.tbxDes.Name = "tbxDes";
            this.tbxDes.SelectedValue = ((object)(resources.GetObject("tbxDes.SelectedValue")));
            this.tbxDes.Size = new System.Drawing.Size(177, 23);
            this.tbxDes.TabIndex = 2;
            // 
            // lblCommandName
            // 
            this.lblCommandName.AutoEllipsis = true;
            this.lblCommandName.Location = new System.Drawing.Point(6, 31);
            this.lblCommandName.Name = "lblCommandName";
            this.lblCommandName.Size = new System.Drawing.Size(87, 14);
            this.lblCommandName.TabIndex = 1;
            this.lblCommandName.Text = "命令名:";
            this.lblCommandName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCommandName
            // 
            // 
            // 
            // 
            this.tbxCommandName.Border.Class = "TextBoxBorder";
            this.tbxCommandName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxCommandName.FocusHighlightEnabled = true;
            this.tbxCommandName.Location = new System.Drawing.Point(96, 27);
            this.tbxCommandName.Name = "tbxCommandName";
            this.tbxCommandName.SelectedValue = ((object)(resources.GetObject("tbxCommandName.SelectedValue")));
            this.tbxCommandName.Size = new System.Drawing.Size(177, 23);
            this.tbxCommandName.TabIndex = 0;
            // 
            // FrmAddCommands
            // 
            this.ClientSize = new System.Drawing.Size(317, 169);
            this.Name = "FrmAddCommands";
            this.Text = "任务命令";
            this.Load += new System.EventHandler(this.FrmAddCommands_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.gbProcessCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProcessCommand;
        private System.Windows.Forms.Label lblCommandName;
        private System.Windows.Forms.Label lblDescription;
        public Controls.UcTextBox tbxCommandName;
        public Controls.UcTextBox tbxDes;
    }
}
