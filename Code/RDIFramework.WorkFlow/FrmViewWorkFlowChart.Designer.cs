namespace RDIFramework.WorkFlow
{
    partial class FrmViewWorkFlowChart
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
            this.ucImageView = new RDIFramework.Controls.UcImageView();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.panel1.SuspendLayout();
            this.pnlTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucImageView);
            this.panel1.Controls.Add(this.pnlTool);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 662);
            this.panel1.TabIndex = 0;
            // 
            // ucImageView
            // 
            this.ucImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageView.Location = new System.Drawing.Point(0, 49);
            this.ucImageView.MnuMoveImageChecked = false;
            this.ucImageView.MnuPrintVisible = true;
            this.ucImageView.Name = "ucImageView";
            this.ucImageView.Size = new System.Drawing.Size(971, 613);
            this.ucImageView.TabIndex = 0;
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlTool.Controls.Add(this.btnClose);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(971, 49);
            this.pnlTool.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmViewWorkFlowChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(971, 662);
            this.Controls.Add(this.panel1);
            this.Name = "FrmViewWorkFlowChart";
            this.Text = "流程执行状态图";
            this.panel1.ResumeLayout(false);
            this.pnlTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.UcImageView ucImageView;
        private System.Windows.Forms.Panel pnlTool;
        private Controls.UcButton btnClose;
    }
}