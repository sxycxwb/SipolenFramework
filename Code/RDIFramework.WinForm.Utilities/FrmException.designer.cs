namespace RDIFramework.WinForm.Utilities
{
    partial class FrmException
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

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnReport = new RDIFramework.Controls.UcButton();
            this.btnPrint = new RDIFramework.Controls.UcButton();
            this.txtOccurTime = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtUser = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtSoft = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtCustomer = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtException = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblOperator = new System.Windows.Forms.Label();
            this.lblExceptionInfo = new System.Windows.Forms.Label();
            this.lblOccurTime = new System.Windows.Forms.Label();
            this.lblSoftFullName = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.btnReport);
            this.pnlMain.Controls.Add(this.btnPrint);
            this.pnlMain.Controls.Add(this.txtOccurTime);
            this.pnlMain.Controls.Add(this.txtUser);
            this.pnlMain.Controls.Add(this.txtSoft);
            this.pnlMain.Controls.Add(this.txtCustomer);
            this.pnlMain.Controls.Add(this.txtException);
            this.pnlMain.Controls.Add(this.lblOperator);
            this.pnlMain.Controls.Add(this.lblExceptionInfo);
            this.pnlMain.Controls.Add(this.lblOccurTime);
            this.pnlMain.Controls.Add(this.lblSoftFullName);
            this.pnlMain.Controls.Add(this.lblCustomer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(684, 417);
            this.pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(579, 374);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(1);
            this.btnClose.Size = new System.Drawing.Size(82, 26);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.AutoSize = true;
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReport.Location = new System.Drawing.Point(422, 374);
            this.btnReport.Name = "btnReport";
            this.btnReport.Padding = new System.Windows.Forms.Padding(1);
            this.btnReport.Size = new System.Drawing.Size(119, 26);
            this.btnReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "反馈异常信息(&R)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.AutoSize = true;
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrint.Location = new System.Drawing.Point(297, 374);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(1);
            this.btnPrint.Size = new System.Drawing.Size(119, 26);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "打印异常信息(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtOccurTime
            // 
            this.txtOccurTime.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOccurTime.Border.Class = "TextBoxBorder";
            this.txtOccurTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOccurTime.FocusHighlightEnabled = true;
            this.txtOccurTime.Location = new System.Drawing.Point(433, 38);
            this.txtOccurTime.Name = "txtOccurTime";
            this.txtOccurTime.SelectedValue = null;
            this.txtOccurTime.Size = new System.Drawing.Size(226, 21);
            this.txtOccurTime.TabIndex = 20;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.FocusHighlightEnabled = true;
            this.txtUser.Location = new System.Drawing.Point(117, 38);
            this.txtUser.Name = "txtUser";
            this.txtUser.SelectedValue = null;
            this.txtUser.Size = new System.Drawing.Size(207, 21);
            this.txtUser.TabIndex = 18;
            // 
            // txtSoft
            // 
            this.txtSoft.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSoft.Border.Class = "TextBoxBorder";
            this.txtSoft.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSoft.FocusHighlightEnabled = true;
            this.txtSoft.Location = new System.Drawing.Point(433, 9);
            this.txtSoft.Name = "txtSoft";
            this.txtSoft.SelectedValue = null;
            this.txtSoft.Size = new System.Drawing.Size(226, 21);
            this.txtSoft.TabIndex = 16;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCustomer.Border.Class = "TextBoxBorder";
            this.txtCustomer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomer.FocusHighlightEnabled = true;
            this.txtCustomer.Location = new System.Drawing.Point(117, 9);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.SelectedValue = null;
            this.txtCustomer.Size = new System.Drawing.Size(207, 21);
            this.txtCustomer.TabIndex = 15;
            // 
            // txtException
            // 
            this.txtException.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtException.Border.Class = "TextBoxBorder";
            this.txtException.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtException.FocusHighlightEnabled = true;
            this.txtException.Location = new System.Drawing.Point(117, 71);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtException.SelectedValue = null;
            this.txtException.Size = new System.Drawing.Size(544, 284);
            this.txtException.TabIndex = 21;
            // 
            // lblOperator
            // 
            this.lblOperator.Location = new System.Drawing.Point(2, 43);
            this.lblOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(113, 12);
            this.lblOperator.TabIndex = 19;
            this.lblOperator.Text = "用户：";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExceptionInfo
            // 
            this.lblExceptionInfo.Location = new System.Drawing.Point(2, 75);
            this.lblExceptionInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExceptionInfo.Name = "lblExceptionInfo";
            this.lblExceptionInfo.Size = new System.Drawing.Size(113, 12);
            this.lblExceptionInfo.TabIndex = 23;
            this.lblExceptionInfo.Text = "错误信息：";
            this.lblExceptionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOccurTime
            // 
            this.lblOccurTime.Location = new System.Drawing.Point(328, 42);
            this.lblOccurTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOccurTime.Name = "lblOccurTime";
            this.lblOccurTime.Size = new System.Drawing.Size(104, 12);
            this.lblOccurTime.TabIndex = 22;
            this.lblOccurTime.Text = "发生时间：";
            this.lblOccurTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoftFullName
            // 
            this.lblSoftFullName.Location = new System.Drawing.Point(328, 14);
            this.lblSoftFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftFullName.Name = "lblSoftFullName";
            this.lblSoftFullName.Size = new System.Drawing.Size(104, 12);
            this.lblSoftFullName.TabIndex = 17;
            this.lblSoftFullName.Text = "软件名称：";
            this.lblSoftFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(2, 14);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(113, 12);
            this.lblCustomer.TabIndex = 14;
            this.lblCustomer.Text = "公司：";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmException
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(684, 417);
            this.Controls.Add(this.pnlMain);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(346, 209);
            this.Name = "FrmException";
            this.Text = "系统异常情况记录";
            this.TopMost = true;
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Controls.UcButton btnClose;
        private Controls.UcButton btnReport;
        private Controls.UcButton btnPrint;
        private Controls.UcTextBox txtOccurTime;
        private Controls.UcTextBox txtUser;
        private Controls.UcTextBox txtSoft;
        private Controls.UcTextBox txtCustomer;
        private Controls.UcTextBox txtException;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblExceptionInfo;
        private System.Windows.Forms.Label lblOccurTime;
        private System.Windows.Forms.Label lblSoftFullName;
        private System.Windows.Forms.Label lblCustomer;

    }
}