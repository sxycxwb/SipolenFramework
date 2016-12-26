namespace RDIFramework.WorkFlow
{
    partial class FrmWorkFlowExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlowExport));
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.btnExport = new RDIFramework.Controls.UcButton();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.rbtnWorkFlow = new System.Windows.Forms.RadioButton();
            this.lbStep = new System.Windows.Forms.Label();
            this.gbxReult = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnFilePath = new RDIFramework.Controls.UcButton();
            this.tbxFilePath = new RDIFramework.Controls.UcTextBox(this.components);
            this.gbOne = new System.Windows.Forms.GroupBox();
            this.gbxReult.SuspendLayout();
            this.gbOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnAll
            // 
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(12, 71);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(428, 24);
            this.rbtnAll.TabIndex = 3;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "导出全部(&B包含表单)";
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(256, 24);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(88, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(352, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbtnWorkFlow
            // 
            this.rbtnWorkFlow.Location = new System.Drawing.Point(12, 102);
            this.rbtnWorkFlow.Name = "rbtnWorkFlow";
            this.rbtnWorkFlow.Size = new System.Drawing.Size(428, 24);
            this.rbtnWorkFlow.TabIndex = 2;
            this.rbtnWorkFlow.Text = "只导出原形(&A不含表单)";
            // 
            // lbStep
            // 
            this.lbStep.Location = new System.Drawing.Point(8, 56);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(440, 16);
            this.lbStep.TabIndex = 3;
            this.lbStep.Text = "导出进度...";
            // 
            // gbxReult
            // 
            this.gbxReult.Controls.Add(this.lbStep);
            this.gbxReult.Controls.Add(this.btnClose);
            this.gbxReult.Controls.Add(this.btnExport);
            this.gbxReult.Controls.Add(this.progressBar1);
            this.gbxReult.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxReult.Location = new System.Drawing.Point(3, 147);
            this.gbxReult.Name = "gbxReult";
            this.gbxReult.Size = new System.Drawing.Size(472, 100);
            this.gbxReult.TabIndex = 4;
            this.gbxReult.TabStop = false;
            this.gbxReult.Text = "第二步：执行导出";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(466, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // btnFilePath
            // 
            this.btnFilePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFilePath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFilePath.Location = new System.Drawing.Point(362, 32);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(86, 23);
            this.btnFilePath.TabIndex = 1;
            this.btnFilePath.Text = "浏览(&B)";
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxFilePath.Border.Class = "TextBoxBorder";
            this.tbxFilePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxFilePath.FocusHighlightEnabled = true;
            this.tbxFilePath.Location = new System.Drawing.Point(12, 32);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.ReadOnly = true;
            this.tbxFilePath.SelectedValue = ((object)(resources.GetObject("tbxFilePath.SelectedValue")));
            this.tbxFilePath.Size = new System.Drawing.Size(344, 23);
            this.tbxFilePath.TabIndex = 0;
            // 
            // gbOne
            // 
            this.gbOne.Controls.Add(this.rbtnAll);
            this.gbOne.Controls.Add(this.rbtnWorkFlow);
            this.gbOne.Controls.Add(this.btnFilePath);
            this.gbOne.Controls.Add(this.tbxFilePath);
            this.gbOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOne.Location = new System.Drawing.Point(3, 3);
            this.gbOne.Name = "gbOne";
            this.gbOne.Size = new System.Drawing.Size(472, 144);
            this.gbOne.TabIndex = 3;
            this.gbOne.TabStop = false;
            this.gbOne.Text = "第一步：导出到文件";
            // 
            // FrmWorkFlowExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 247);
            this.Controls.Add(this.gbxReult);
            this.Controls.Add(this.gbOne);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowExport";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "流程导出";
            this.gbxReult.ResumeLayout(false);
            this.gbOne.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnAll;
        private Controls.UcButton btnExport;
        private Controls.UcButton btnClose;
        private System.Windows.Forms.RadioButton rbtnWorkFlow;
        private System.Windows.Forms.Label lbStep;
        private System.Windows.Forms.GroupBox gbxReult;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Controls.UcButton btnFilePath;
        private Controls.UcTextBox tbxFilePath;
        private System.Windows.Forms.GroupBox gbOne;
    }
}