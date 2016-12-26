namespace RDIFramework.Test
{
    partial class FrmTest
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
            this.btnTest = new System.Windows.Forms.Button();
            this.btnTestMethod = new System.Windows.Forms.Button();
            this.rtfLog = new System.Windows.Forms.RichTextBox();
            this.btnTestDgvSummary = new System.Windows.Forms.Button();
            this.btnFormBinding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(39, 12);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(108, 44);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "调用测试界面";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTestMethod
            // 
            this.btnTestMethod.Location = new System.Drawing.Point(167, 23);
            this.btnTestMethod.Name = "btnTestMethod";
            this.btnTestMethod.Size = new System.Drawing.Size(226, 23);
            this.btnTestMethod.TabIndex = 1;
            this.btnTestMethod.Text = "多线程测试框架方法";
            this.btnTestMethod.UseVisualStyleBackColor = true;
            this.btnTestMethod.Click += new System.EventHandler(this.btnTestMethod_Click);
            // 
            // rtfLog
            // 
            this.rtfLog.Location = new System.Drawing.Point(27, 85);
            this.rtfLog.Name = "rtfLog";
            this.rtfLog.Size = new System.Drawing.Size(736, 484);
            this.rtfLog.TabIndex = 2;
            this.rtfLog.Text = "";
            // 
            // btnTestDgvSummary
            // 
            this.btnTestDgvSummary.Location = new System.Drawing.Point(460, 23);
            this.btnTestDgvSummary.Name = "btnTestDgvSummary";
            this.btnTestDgvSummary.Size = new System.Drawing.Size(75, 23);
            this.btnTestDgvSummary.TabIndex = 3;
            this.btnTestDgvSummary.Text = "测试汇总";
            this.btnTestDgvSummary.UseVisualStyleBackColor = true;
            this.btnTestDgvSummary.Click += new System.EventHandler(this.btnTestDgvSummary_Click);
            // 
            // btnFormBinding
            // 
            this.btnFormBinding.Location = new System.Drawing.Point(579, 23);
            this.btnFormBinding.Name = "btnFormBinding";
            this.btnFormBinding.Size = new System.Drawing.Size(170, 23);
            this.btnFormBinding.TabIndex = 4;
            this.btnFormBinding.Text = "实体到控件互绑定测试";
            this.btnFormBinding.UseVisualStyleBackColor = true;
            this.btnFormBinding.Click += new System.EventHandler(this.btnFormBinding_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 581);
            this.Controls.Add(this.btnFormBinding);
            this.Controls.Add(this.btnTestDgvSummary);
            this.Controls.Add(this.rtfLog);
            this.Controls.Add(this.btnTestMethod);
            this.Controls.Add(this.btnTest);
            this.Name = "FrmTest";
            this.ShowInTaskbar = true;
            this.Text = "测试";
            this.Shown += new System.EventHandler(this.FrmTest_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnTestMethod;
        private System.Windows.Forms.RichTextBox rtfLog;
        private System.Windows.Forms.Button btnTestDgvSummary;
        private System.Windows.Forms.Button btnFormBinding;
    }
}

