namespace RDIFramework.Test
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
            this.components = new System.ComponentModel.Container();
            this.ucAutoTextBox2 = new RDIFramework.Controls.UcAutoTextBox();
            this.ucAutoTextBox1 = new RDIFramework.Controls.UcAutoTextBox();
            this.SuspendLayout();
            // 
            // ucAutoTextBox2
            // 
            this.ucAutoTextBox2.Col = null;
            this.ucAutoTextBox2.ControlColumn = null;
            this.ucAutoTextBox2.DisplayMember = "";
            this.ucAutoTextBox2.Dr = null;
            this.ucAutoTextBox2.IsEmpty = false;
            this.ucAutoTextBox2.Location = new System.Drawing.Point(220, 57);
            this.ucAutoTextBox2.Name = "ucAutoTextBox2";
            this.ucAutoTextBox2.NextControl = null;
            this.ucAutoTextBox2.PyOrWb = RDIFramework.Controls.UcAutoTextBox.NameByType.py;
            this.ucAutoTextBox2.ReViewCount = RDIFramework.Controls.UcAutoTextBox.RuseltAmount.R10;
            this.ucAutoTextBox2.Size = new System.Drawing.Size(192, 21);
            this.ucAutoTextBox2.TabIndex = 1;
            this.ucAutoTextBox2.Tag = "";
            this.ucAutoTextBox2.TagSql = 0;
            this.ucAutoTextBox2.Txttype = 0;
            this.ucAutoTextBox2.ValueMember = "";
            // 
            // ucAutoTextBox1
            // 
            this.ucAutoTextBox1.Col = null;
            this.ucAutoTextBox1.ControlColumn = null;
            this.ucAutoTextBox1.DisplayMember = "";
            this.ucAutoTextBox1.Dr = null;
            this.ucAutoTextBox1.IsEmpty = false;
            this.ucAutoTextBox1.Location = new System.Drawing.Point(22, 57);
            this.ucAutoTextBox1.Name = "ucAutoTextBox1";
            this.ucAutoTextBox1.NextControl = null;
            this.ucAutoTextBox1.PyOrWb = RDIFramework.Controls.UcAutoTextBox.NameByType.py;
            this.ucAutoTextBox1.ReViewCount = RDIFramework.Controls.UcAutoTextBox.RuseltAmount.R10;
            this.ucAutoTextBox1.Size = new System.Drawing.Size(192, 21);
            this.ucAutoTextBox1.TabIndex = 0;
            this.ucAutoTextBox1.Tag = "";
            this.ucAutoTextBox1.TagSql = 0;
            this.ucAutoTextBox1.Txttype = 0;
            this.ucAutoTextBox1.ValueMember = "";
            // 
            // FrmTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 262);
            this.Controls.Add(this.ucAutoTextBox2);
            this.Controls.Add(this.ucAutoTextBox1);
            this.Name = "FrmTestForm";
            this.Text = "自动完成控件测试";
            this.Load += new System.EventHandler(this.FrmTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UcAutoTextBox ucAutoTextBox1;
        private Controls.UcAutoTextBox ucAutoTextBox2;
    }
}