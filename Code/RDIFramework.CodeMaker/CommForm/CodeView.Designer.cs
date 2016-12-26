namespace RDIFramework.CodeMaker
{
    partial class CodeView
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
            this.codeContent = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.SuspendLayout();
            // 
            // codeContent
            // 
            this.codeContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeContent.Location = new System.Drawing.Point(0, 0);
            this.codeContent.Name = "codeContent";            
            this.codeContent.Size = new System.Drawing.Size(647, 502);
            this.codeContent.TabIndex = 0;
            // 
            // CodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 502);
            this.Controls.Add(this.codeContent);
            this.Name = "CodeView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeView";
            this.ResumeLayout(false);

        }

        #endregion

        public CodeEditorControlEx codeContent;

    }
}