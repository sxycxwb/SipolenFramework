namespace RDIFramework.NET
{
    partial class FrmMsgRemind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMsgRemind));
            this.grbMessage = new System.Windows.Forms.GroupBox();
            this.txtMsgContent = new System.Windows.Forms.TextBox();
            this.grbMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMessage
            // 
            this.grbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbMessage.Controls.Add(this.txtMsgContent);
            this.grbMessage.Location = new System.Drawing.Point(10, 10);
            this.grbMessage.Name = "grbMessage";
            this.grbMessage.Size = new System.Drawing.Size(334, 178);
            this.grbMessage.TabIndex = 1;
            this.grbMessage.TabStop = false;
            this.grbMessage.Text = "消息";
            // 
            // txtMsgContent
            // 
            this.txtMsgContent.AllowDrop = true;
            this.txtMsgContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsgContent.Location = new System.Drawing.Point(12, 17);
            this.txtMsgContent.MaxLength = 800;
            this.txtMsgContent.Multiline = true;
            this.txtMsgContent.Name = "txtMsgContent";
            this.txtMsgContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsgContent.Size = new System.Drawing.Size(309, 152);
            this.txtMsgContent.TabIndex = 15;
            // 
            // FrmMsgRemind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 198);
            this.Controls.Add(this.grbMessage);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMsgRemind";
            this.ShowInTaskbar = true;
            this.Text = "消息提醒";
            this.TopMost = true;
            this.grbMessage.ResumeLayout(false);
            this.grbMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMessage;
        private System.Windows.Forms.TextBox txtMsgContent;
    }
}