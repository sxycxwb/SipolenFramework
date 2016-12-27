/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-6 13:03:21
 ******************************************************************************/
namespace RDIFramework.CodeMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCopyRight = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linklblcnblogs = new System.Windows.Forms.LinkLabel();
            this.picQQ = new System.Windows.Forms.PictureBox();
            this.linkLblURL = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCofirm = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQQ)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(228)))), ((int)(((byte)(163)))));
            this.pnlTop.BackgroundImage = global::RDIFramework.CodeMaker.Properties.Resources.GRDIFrameworkHeader;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(517, 67);
            this.pnlTop.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 67);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(517, 2);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 69);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(517, 266);
            this.pnlMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCopyRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(517, 244);
            this.panel1.TabIndex = 3;
            // 
            // txtCopyRight
            // 
            this.txtCopyRight.AcceptsTab = true;
            this.txtCopyRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCopyRight.Location = new System.Drawing.Point(10, 10);
            this.txtCopyRight.Multiline = true;
            this.txtCopyRight.Name = "txtCopyRight";
            this.txtCopyRight.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCopyRight.Size = new System.Drawing.Size(497, 224);
            this.txtCopyRight.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.linklblcnblogs);
            this.panel2.Controls.Add(this.picQQ);
            this.panel2.Controls.Add(this.linkLblURL);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCofirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 335);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 69);
            this.panel2.TabIndex = 4;
            // 
            // linklblcnblogs
            // 
            this.linklblcnblogs.AutoSize = true;
            this.linklblcnblogs.BackColor = System.Drawing.Color.Transparent;
            this.linklblcnblogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklblcnblogs.Location = new System.Drawing.Point(12, 28);
            this.linklblcnblogs.Name = "linklblcnblogs";
            this.linklblcnblogs.Size = new System.Drawing.Size(203, 13);
            this.linklblcnblogs.TabIndex = 5;
            this.linklblcnblogs.TabStop = true;
            this.linklblcnblogs.Text = "http://www.rdiframework.net/";
            this.linklblcnblogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblcnblogs_LinkClicked);
            // 
            // picQQ
            // 
            this.picQQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQQ.Image = global::RDIFramework.CodeMaker.Properties.Resources.qqcallme;
            this.picQQ.Location = new System.Drawing.Point(248, 31);
            this.picQQ.Name = "picQQ";
            this.picQQ.Size = new System.Drawing.Size(77, 22);
            this.picQQ.TabIndex = 4;
            this.picQQ.TabStop = false;
            this.picQQ.Click += new System.EventHandler(this.picQQ_Click);
            // 
            // linkLblURL
            // 
            this.linkLblURL.AutoSize = true;
            this.linkLblURL.BackColor = System.Drawing.Color.Transparent;
            this.linkLblURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLblURL.Location = new System.Drawing.Point(11, 47);
            this.linkLblURL.Name = "linkLblURL";
            this.linkLblURL.Size = new System.Drawing.Size(217, 13);
            this.linkLblURL.TabIndex = 3;
            this.linkLblURL.TabStop = true;
            this.linkLblURL.Text = "http://www.cnblogs.com/huyong/";
            this.linkLblURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblURL_LinkClicked);
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
            this.btnCofirm.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCofirm.Location = new System.Drawing.Point(427, 30);
            this.btnCofirm.Name = "btnCofirm";
            this.btnCofirm.Size = new System.Drawing.Size(75, 23);
            this.btnCofirm.TabIndex = 0;
            this.btnCofirm.Text = "确定(O)";
            this.btnCofirm.Click += new System.EventHandler(this.btnCofirm_Click);
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnCofirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 404);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于本软件";
            this.Shown += new System.EventHandler(this.FrmAbout_Shown);
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button btnCofirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCopyRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLblURL;
        private System.Windows.Forms.PictureBox picQQ;
        private System.Windows.Forms.LinkLabel linklblcnblogs;
    }
}