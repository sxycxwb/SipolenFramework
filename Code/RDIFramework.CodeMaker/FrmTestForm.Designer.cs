namespace RDIFramework.CodeMaker
{
    partial class FrmTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.codeEditorControlEx1 = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.textEditorControlWrapper1 = new TextEditor.Editor.TextEditorControlWrapper();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.codeEditorControlEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textEditorControlWrapper1);
            this.splitContainer1.Size = new System.Drawing.Size(615, 513);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // codeEditorControlEx1
            // 
            this.codeEditorControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorControlEx1.Location = new System.Drawing.Point(0, 0);
            this.codeEditorControlEx1.Name = "codeEditorControlEx1";
            this.codeEditorControlEx1.SaveFileName = "";
            this.codeEditorControlEx1.Size = new System.Drawing.Size(615, 205);
            this.codeEditorControlEx1.TabIndex = 1;
            // 
            // textEditorControlWrapper1
            // 
            this.textEditorControlWrapper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControlWrapper1.Encoding = ((System.Text.Encoding)(resources.GetObject("textEditorControlWrapper1.Encoding")));
            this.textEditorControlWrapper1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControlWrapper1.Name = "textEditorControlWrapper1";
            this.textEditorControlWrapper1.SelectedText = "";
            this.textEditorControlWrapper1.SelectionStart = 0;
            this.textEditorControlWrapper1.ShowEOLMarkers = true;
            this.textEditorControlWrapper1.ShowSpaces = true;
            this.textEditorControlWrapper1.ShowTabs = true;
            this.textEditorControlWrapper1.ShowVRuler = true;
            this.textEditorControlWrapper1.Size = new System.Drawing.Size(615, 304);
            this.textEditorControlWrapper1.TabIndex = 0;
            this.textEditorControlWrapper1.KeyPressEvent += new TextEditor.Editor.TextEditorControlWrapper.KeyPressEventHandler(this.textEditorControlWrapper1_KeyPressEvent);
            this.textEditorControlWrapper1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditorControlWrapper1_KeyPress);
            // 
            // FrmTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 513);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmTestForm";
            this.Text = "FrmTestForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CodeEditorControlEx codeEditorControlEx1;
        private TextEditor.Editor.TextEditorControlWrapper textEditorControlWrapper1;


    }
}