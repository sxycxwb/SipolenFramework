namespace RDIFramework.WorkFlow
{
    partial class FrmWorkFlowImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlowImport));
            this.rdbtNewWorkFlow = new System.Windows.Forms.RadioButton();
            this.btnFilePath = new RDIFramework.Controls.UcButton();
            this.tbxFilePath = new RDIFramework.Controls.UcTextBox(this.components);
            this.rbtnWorkFlow = new System.Windows.Forms.RadioButton();
            this.gbxReult = new System.Windows.Forms.GroupBox();
            this.lbStep = new System.Windows.Forms.Label();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnInput = new RDIFramework.Controls.UcButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.gbxOne = new System.Windows.Forms.GroupBox();
            this.gbxReult.SuspendLayout();
            this.gbxOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbtNewWorkFlow
            // 
            this.rdbtNewWorkFlow.Location = new System.Drawing.Point(16, 124);
            this.rdbtNewWorkFlow.Name = "rdbtNewWorkFlow";
            this.rdbtNewWorkFlow.Size = new System.Drawing.Size(350, 24);
            this.rdbtNewWorkFlow.TabIndex = 6;
            this.rdbtNewWorkFlow.Text = "只导入原形(&N新建)";
            // 
            // btnFilePath
            // 
            this.btnFilePath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFilePath.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFilePath.Location = new System.Drawing.Point(352, 32);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(88, 23);
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
            this.tbxFilePath.Location = new System.Drawing.Point(16, 32);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.ReadOnly = true;
            this.tbxFilePath.SelectedValue = ((object)(resources.GetObject("tbxFilePath.SelectedValue")));
            this.tbxFilePath.Size = new System.Drawing.Size(328, 23);
            this.tbxFilePath.TabIndex = 0;
            // 
            // rbtnWorkFlow
            // 
            this.rbtnWorkFlow.Location = new System.Drawing.Point(16, 94);
            this.rbtnWorkFlow.Name = "rbtnWorkFlow";
            this.rbtnWorkFlow.Size = new System.Drawing.Size(350, 24);
            this.rbtnWorkFlow.TabIndex = 4;
            this.rbtnWorkFlow.Text = "只导入原形(&A不含表单)";
            this.rbtnWorkFlow.UseCompatibleTextRendering = true;
            // 
            // gbxReult
            // 
            this.gbxReult.Controls.Add(this.lbStep);
            this.gbxReult.Controls.Add(this.btnClose);
            this.gbxReult.Controls.Add(this.btnInput);
            this.gbxReult.Controls.Add(this.progressBar1);
            this.gbxReult.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxReult.Location = new System.Drawing.Point(3, 174);
            this.gbxReult.Name = "gbxReult";
            this.gbxReult.Size = new System.Drawing.Size(482, 100);
            this.gbxReult.TabIndex = 6;
            this.gbxReult.TabStop = false;
            this.gbxReult.Text = "第二步：执行导入";
            // 
            // lbStep
            // 
            this.lbStep.Location = new System.Drawing.Point(8, 56);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(440, 16);
            this.lbStep.TabIndex = 3;
            this.lbStep.Text = "导入进度...";
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
            // btnInput
            // 
            this.btnInput.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInput.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInput.Location = new System.Drawing.Point(251, 24);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(88, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "导入(&E)";
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(476, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 0;
            // 
            // rbtnAll
            // 
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(16, 64);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(350, 24);
            this.rbtnAll.TabIndex = 5;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "导入全部(&B包含表单)";
            // 
            // gbxOne
            // 
            this.gbxOne.Controls.Add(this.rdbtNewWorkFlow);
            this.gbxOne.Controls.Add(this.btnFilePath);
            this.gbxOne.Controls.Add(this.tbxFilePath);
            this.gbxOne.Controls.Add(this.rbtnWorkFlow);
            this.gbxOne.Controls.Add(this.rbtnAll);
            this.gbxOne.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxOne.Location = new System.Drawing.Point(3, 3);
            this.gbxOne.Name = "gbxOne";
            this.gbxOne.Size = new System.Drawing.Size(482, 171);
            this.gbxOne.TabIndex = 5;
            this.gbxOne.TabStop = false;
            this.gbxOne.Text = "第一步：从文件中导入";
            // 
            // FrmWorkFlowImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 283);
            this.Controls.Add(this.gbxReult);
            this.Controls.Add(this.gbxOne);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowImport";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "流程导入";
            this.gbxReult.ResumeLayout(false);
            this.gbxOne.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbtNewWorkFlow;
        private Controls.UcButton btnFilePath;
        private Controls.UcTextBox tbxFilePath;
        private System.Windows.Forms.RadioButton rbtnWorkFlow;
        private System.Windows.Forms.GroupBox gbxReult;
        private System.Windows.Forms.Label lbStep;
        private Controls.UcButton btnClose;
        private Controls.UcButton btnInput;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.GroupBox gbxOne;
    }
}