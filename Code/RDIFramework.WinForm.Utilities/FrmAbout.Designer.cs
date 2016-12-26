/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-6 13:03:21
 ******************************************************************************/
namespace RDIFramework.WinForm.Utilities
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCopyRight = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblCopyRight = new System.Windows.Forms.Label();
            this.lblCustomerCompanyName = new System.Windows.Forms.Label();
            this.lblSoftFullName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picQQ = new System.Windows.Forms.PictureBox();
            this.linklblcnblogs = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCofirm = new RDIFramework.Controls.UcButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQQ)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 67);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(430, 2);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.lblCopyRight);
            this.pnlMain.Controls.Add(this.lblCustomerCompanyName);
            this.pnlMain.Controls.Add(this.lblSoftFullName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 69);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(430, 252);
            this.pnlMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCopyRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(430, 197);
            this.panel1.TabIndex = 3;
            // 
            // txtCopyRight
            // 
            this.txtCopyRight.AcceptsTab = true;
            // 
            // 
            // 
            this.txtCopyRight.Border.Class = "TextBoxBorder";
            this.txtCopyRight.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCopyRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCopyRight.FocusHighlightEnabled = true;
            this.txtCopyRight.Location = new System.Drawing.Point(10, 10);
            this.txtCopyRight.Multiline = true;
            this.txtCopyRight.Name = "txtCopyRight";
            this.txtCopyRight.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCopyRight.SelectedValue = null;
            this.txtCopyRight.Size = new System.Drawing.Size(410, 177);
            this.txtCopyRight.TabIndex = 4;
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.AutoSize = true;
            this.lblCopyRight.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyRight.Location = new System.Drawing.Point(12, 43);
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Size = new System.Drawing.Size(329, 13);
            this.lblCopyRight.TabIndex = 2;
            this.lblCopyRight.Text = "Copyright (C) 2010-2016.  All Rights Reserved.";
            // 
            // lblCustomerCompanyName
            // 
            this.lblCustomerCompanyName.AutoSize = true;
            this.lblCustomerCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerCompanyName.Location = new System.Drawing.Point(12, 27);
            this.lblCustomerCompanyName.Name = "lblCustomerCompanyName";
            this.lblCustomerCompanyName.Size = new System.Drawing.Size(126, 13);
            this.lblCustomerCompanyName.TabIndex = 1;
            this.lblCustomerCompanyName.Text = "艾特科技 版权所有";
            // 
            // lblSoftFullName
            // 
            this.lblSoftFullName.AutoSize = true;
            this.lblSoftFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblSoftFullName.Location = new System.Drawing.Point(12, 9);
            this.lblSoftFullName.Name = "lblSoftFullName";
            this.lblSoftFullName.Size = new System.Drawing.Size(301, 13);
            this.lblSoftFullName.TabIndex = 0;
            this.lblSoftFullName.Text = "快速信息化系统开发框架（RDIFramework.NET）";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picQQ);
            this.panel2.Controls.Add(this.linklblcnblogs);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCofirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 72);
            this.panel2.TabIndex = 4;
            // 
            // picQQ
            // 
            this.picQQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQQ.Image = global::RDIFramework.WinForm.Utilities.Properties.Resources.qqcallme;
            this.picQQ.Location = new System.Drawing.Point(256, 27);
            this.picQQ.Name = "picQQ";
            this.picQQ.Size = new System.Drawing.Size(77, 22);
            this.picQQ.TabIndex = 8;
            this.picQQ.TabStop = false;
            this.picQQ.Click += new System.EventHandler(this.picQQ_Click);
            // 
            // linklblcnblogs
            // 
            this.linklblcnblogs.AutoSize = true;
            this.linklblcnblogs.BackColor = System.Drawing.Color.Transparent;
            this.linklblcnblogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblcnblogs.Location = new System.Drawing.Point(13, 28);
            this.linklblcnblogs.Name = "linklblcnblogs";
            this.linklblcnblogs.Size = new System.Drawing.Size(203, 13);
            this.linklblcnblogs.TabIndex = 7;
            this.linklblcnblogs.TabStop = true;
            this.linklblcnblogs.Text = "http://www.rdiframework.net/";
            this.linklblcnblogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblcnblogs_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Location = new System.Drawing.Point(12, 47);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(210, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://blog.rdiframework.net/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "想了解更多信息？请访问：";
            // 
            // btnCofirm
            // 
            this.btnCofirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCofirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCofirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCofirm.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCofirm.Location = new System.Drawing.Point(344, 27);
            this.btnCofirm.Name = "btnCofirm";
            this.btnCofirm.Size = new System.Drawing.Size(75, 23);
            this.btnCofirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCofirm.TabIndex = 0;
            this.btnCofirm.Text = "确定(O)";
            this.btnCofirm.Click += new System.EventHandler(this.btnCofirm_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(228)))), ((int)(((byte)(163)))));
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(430, 67);
            this.pnlTop.TabIndex = 0;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnCofirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 393);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.Text = "关于本软件";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSoftFullName;
        private System.Windows.Forms.Label lblCustomerCompanyName;
        private System.Windows.Forms.Label lblCopyRight;
        private Controls.UcButton btnCofirm;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcTextBox txtCopyRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linklblcnblogs;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox picQQ;
    }
}