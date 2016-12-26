namespace RDIFramework.CodeMaker
{
    partial class MakerMvcUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTableDescription = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPIndexCshtml = new System.Windows.Forms.TabPage();
            this.codeEditorIndexCshtml = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPFormCshtml = new System.Windows.Forms.TabPage();
            this.codeEditorFormCshtml = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPController = new System.Windows.Forms.TabPage();
            this.codeEditorController = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPJs = new System.Windows.Forms.TabPage();
            this.codeEditorJs = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.panel1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPIndexCshtml.SuspendLayout();
            this.tabPFormCshtml.SuspendLayout();
            this.tabPController.SuspendLayout();
            this.tabPJs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtTableDescription);
            this.panel1.Controls.Add(this.txtTableName);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 76);
            this.panel1.TabIndex = 0;
            // 
            // txtTableDescription
            // 
            this.txtTableDescription.Location = new System.Drawing.Point(388, 42);
            this.txtTableDescription.Name = "txtTableDescription";
            this.txtTableDescription.Size = new System.Drawing.Size(397, 21);
            this.txtTableDescription.TabIndex = 5;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(64, 43);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(218, 21);
            this.txtTableName.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(64, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 21);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "中文名称/说明：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据表：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名  称：";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPIndexCshtml);
            this.tabControlMain.Controls.Add(this.tabPFormCshtml);
            this.tabControlMain.Controls.Add(this.tabPController);
            this.tabControlMain.Controls.Add(this.tabPJs);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 76);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(932, 569);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPIndexCshtml
            // 
            this.tabPIndexCshtml.Controls.Add(this.codeEditorIndexCshtml);
            this.tabPIndexCshtml.Location = new System.Drawing.Point(4, 22);
            this.tabPIndexCshtml.Name = "tabPIndexCshtml";
            this.tabPIndexCshtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPIndexCshtml.Size = new System.Drawing.Size(924, 543);
            this.tabPIndexCshtml.TabIndex = 4;
            this.tabPIndexCshtml.Text = "Index.cshtml";
            this.tabPIndexCshtml.UseVisualStyleBackColor = true;
            // 
            // codeEditorIndexCshtml
            // 
            this.codeEditorIndexCshtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorIndexCshtml.Location = new System.Drawing.Point(3, 3);
            this.codeEditorIndexCshtml.Name = "codeEditorIndexCshtml";
            this.codeEditorIndexCshtml.SaveFileName = "";
            this.codeEditorIndexCshtml.Size = new System.Drawing.Size(918, 537);
            this.codeEditorIndexCshtml.TabIndex = 4;
            // 
            // tabPFormCshtml
            // 
            this.tabPFormCshtml.Controls.Add(this.codeEditorFormCshtml);
            this.tabPFormCshtml.Location = new System.Drawing.Point(4, 22);
            this.tabPFormCshtml.Name = "tabPFormCshtml";
            this.tabPFormCshtml.Padding = new System.Windows.Forms.Padding(3);
            this.tabPFormCshtml.Size = new System.Drawing.Size(924, 543);
            this.tabPFormCshtml.TabIndex = 1;
            this.tabPFormCshtml.Text = "Form.cshtml";
            this.tabPFormCshtml.UseVisualStyleBackColor = true;
            // 
            // codeEditorFormCshtml
            // 
            this.codeEditorFormCshtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorFormCshtml.Location = new System.Drawing.Point(3, 3);
            this.codeEditorFormCshtml.Name = "codeEditorFormCshtml";
            this.codeEditorFormCshtml.SaveFileName = "";
            this.codeEditorFormCshtml.Size = new System.Drawing.Size(918, 537);
            this.codeEditorFormCshtml.TabIndex = 3;
            // 
            // tabPController
            // 
            this.tabPController.Controls.Add(this.codeEditorController);
            this.tabPController.Location = new System.Drawing.Point(4, 22);
            this.tabPController.Name = "tabPController";
            this.tabPController.Padding = new System.Windows.Forms.Padding(3);
            this.tabPController.Size = new System.Drawing.Size(924, 543);
            this.tabPController.TabIndex = 8;
            this.tabPController.Text = "Controller（控制器）";
            this.tabPController.UseVisualStyleBackColor = true;
            // 
            // codeEditorController
            // 
            this.codeEditorController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorController.Location = new System.Drawing.Point(3, 3);
            this.codeEditorController.Name = "codeEditorController";
            this.codeEditorController.SaveFileName = "";
            this.codeEditorController.Size = new System.Drawing.Size(918, 537);
            this.codeEditorController.TabIndex = 4;
            // 
            // tabPJs
            // 
            this.tabPJs.Controls.Add(this.codeEditorJs);
            this.tabPJs.Location = new System.Drawing.Point(4, 22);
            this.tabPJs.Name = "tabPJs";
            this.tabPJs.Size = new System.Drawing.Size(924, 543);
            this.tabPJs.TabIndex = 6;
            this.tabPJs.Text = "BizJs（js文件）";
            this.tabPJs.UseVisualStyleBackColor = true;
            // 
            // codeEditorJs
            // 
            this.codeEditorJs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorJs.Location = new System.Drawing.Point(0, 0);
            this.codeEditorJs.Name = "codeEditorJs";
            this.codeEditorJs.SaveFileName = "";
            this.codeEditorJs.Size = new System.Drawing.Size(924, 543);
            this.codeEditorJs.TabIndex = 5;
            // 
            // MakerMvcUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 645);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "MakerMvcUI";
            this.Text = "生成MvcUI界面代码";
            this.Shown += new System.EventHandler(this.MakerWebUI_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPIndexCshtml.ResumeLayout(false);
            this.tabPFormCshtml.ResumeLayout(false);
            this.tabPController.ResumeLayout(false);
            this.tabPJs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPFormCshtml;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableDescription;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtName;
        public CodeEditorControlEx codeEditorFormCshtml;
        private System.Windows.Forms.TabPage tabPIndexCshtml;
        public CodeEditorControlEx codeEditorIndexCshtml;
        private System.Windows.Forms.TabPage tabPJs;
        public CodeEditorControlEx codeEditorJs;
        private System.Windows.Forms.TabPage tabPController;
        public CodeEditorControlEx codeEditorController;
    }
}