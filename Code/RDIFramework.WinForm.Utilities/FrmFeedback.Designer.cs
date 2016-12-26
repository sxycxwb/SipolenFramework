namespace RDIFramework.WinForm.Utilities
{
    partial class FrmFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeedback));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnSendEmail = new RDIFramework.Controls.UcButton();
            this.linkcnblogs = new System.Windows.Forms.LinkLabel();
            this.lblBlog = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.htmlEditorEmailContent = new RDIFramework.Controls.UcHtmlEditor();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.btnAddAttach = new RDIFramework.Controls.UcButton();
            this.btnAddAttachments = new RDIFramework.Controls.UcButton();
            this.txtAddAttachments = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFile = new System.Windows.Forms.Label();
            this.lblFeedbackContent = new System.Windows.Forms.Label();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblContractHint = new System.Windows.Forms.Label();
            this.txtContractInfo = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblContractInfo = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(646, 57);
            this.pnlTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::RDIFramework.WinForm.Utilities.Properties.Resources.feedback;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 57);
            this.panel1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 57);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(646, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.linkLabel1);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnSendEmail);
            this.pnlBottom.Controls.Add(this.linkcnblogs);
            this.pnlBottom.Controls.Add(this.lblBlog);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(646, 49);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(548, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendEmail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSendEmail.Location = new System.Drawing.Point(433, 11);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(100, 26);
            this.btnSendEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSendEmail.TabIndex = 9;
            this.btnSendEmail.Text = "确定提交";
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // linkcnblogs
            // 
            this.linkcnblogs.AutoSize = true;
            this.linkcnblogs.Location = new System.Drawing.Point(81, 10);
            this.linkcnblogs.Name = "linkcnblogs";
            this.linkcnblogs.Size = new System.Drawing.Size(210, 14);
            this.linkcnblogs.TabIndex = 3;
            this.linkcnblogs.TabStop = true;
            this.linkcnblogs.Text = "http://blog.rdiframework.net/";
            this.linkcnblogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTencentWeibo_LinkClicked);
            // 
            // lblBlog
            // 
            this.lblBlog.AutoSize = true;
            this.lblBlog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlog.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblBlog.Location = new System.Drawing.Point(6, 19);
            this.lblBlog.Name = "lblBlog";
            this.lblBlog.Size = new System.Drawing.Size(70, 12);
            this.lblBlog.TabIndex = 2;
            this.lblBlog.Text = "官方博客：";
            this.lblBlog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 510);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(646, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnl2);
            this.pnlMain.Controls.Add(this.pnl3);
            this.pnlMain.Controls.Add(this.lblFeedbackContent);
            this.pnlMain.Controls.Add(this.splitter3);
            this.pnlMain.Controls.Add(this.pnl1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(646, 450);
            this.pnlMain.TabIndex = 4;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.htmlEditorEmailContent);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl2.Location = new System.Drawing.Point(0, 73);
            this.pnl2.Name = "pnl2";
            this.pnl2.Padding = new System.Windows.Forms.Padding(5);
            this.pnl2.Size = new System.Drawing.Size(646, 342);
            this.pnl2.TabIndex = 2;
            // 
            // htmlEditorEmailContent
            // 
            this.htmlEditorEmailContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlEditorEmailContent.Html = resources.GetString("htmlEditorEmailContent.Html");
            this.htmlEditorEmailContent.Location = new System.Drawing.Point(5, 5);
            this.htmlEditorEmailContent.Name = "htmlEditorEmailContent";
            this.htmlEditorEmailContent.Size = new System.Drawing.Size(636, 332);
            this.htmlEditorEmailContent.TabIndex = 0;
            this.htmlEditorEmailContent.ToolBarVisible = true;
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.btnAddAttach);
            this.pnl3.Controls.Add(this.btnAddAttachments);
            this.pnl3.Controls.Add(this.txtAddAttachments);
            this.pnl3.Controls.Add(this.lblFile);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl3.Location = new System.Drawing.Point(0, 415);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(646, 35);
            this.pnl3.TabIndex = 5;
            // 
            // btnAddAttach
            // 
            this.btnAddAttach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddAttach.Location = new System.Drawing.Point(549, 4);
            this.btnAddAttach.Name = "btnAddAttach";
            this.btnAddAttach.Size = new System.Drawing.Size(85, 26);
            this.btnAddAttach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddAttach.TabIndex = 8;
            this.btnAddAttach.Text = "添加附件";
            this.btnAddAttach.Click += new System.EventHandler(this.btnAddAttachments_Click);
            // 
            // btnAddAttachments
            // 
            this.btnAddAttachments.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttachments.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddAttachments.Location = new System.Drawing.Point(1195, 7);
            this.btnAddAttachments.Name = "btnAddAttachments";
            this.btnAddAttachments.Size = new System.Drawing.Size(75, 22);
            this.btnAddAttachments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddAttachments.TabIndex = 7;
            this.btnAddAttachments.Text = "添加附件";
            this.btnAddAttachments.Click += new System.EventHandler(this.btnAddAttachments_Click);
            // 
            // txtAddAttachments
            // 
            this.txtAddAttachments.BackColor = System.Drawing.Color.SeaShell;
            // 
            // 
            // 
            this.txtAddAttachments.Border.Class = "TextBoxBorder";
            this.txtAddAttachments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddAttachments.FocusHighlightEnabled = true;
            this.txtAddAttachments.Location = new System.Drawing.Point(69, 5);
            this.txtAddAttachments.Name = "txtAddAttachments";
            this.txtAddAttachments.ReadOnly = true;
            this.txtAddAttachments.SelectedValue = null;
            this.txtAddAttachments.Size = new System.Drawing.Size(474, 23);
            this.txtAddAttachments.TabIndex = 6;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(3, 9);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(77, 14);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "附件位置：";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFeedbackContent
            // 
            this.lblFeedbackContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFeedbackContent.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFeedbackContent.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblFeedbackContent.Location = new System.Drawing.Point(0, 39);
            this.lblFeedbackContent.Name = "lblFeedbackContent";
            this.lblFeedbackContent.Padding = new System.Windows.Forms.Padding(5);
            this.lblFeedbackContent.Size = new System.Drawing.Size(646, 34);
            this.lblFeedbackContent.TabIndex = 3;
            this.lblFeedbackContent.Text = "反馈内容";
            this.lblFeedbackContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter3
            // 
            this.splitter3.BackColor = System.Drawing.Color.Black;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 37);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(646, 2);
            this.splitter3.TabIndex = 4;
            this.splitter3.TabStop = false;
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.lblContractHint);
            this.pnl1.Controls.Add(this.txtContractInfo);
            this.pnl1.Controls.Add(this.lblContractInfo);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(646, 37);
            this.pnl1.TabIndex = 1;
            // 
            // lblContractHint
            // 
            this.lblContractHint.AutoSize = true;
            this.lblContractHint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContractHint.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblContractHint.Location = new System.Drawing.Point(298, 14);
            this.lblContractHint.Name = "lblContractHint";
            this.lblContractHint.Size = new System.Drawing.Size(329, 12);
            this.lblContractHint.TabIndex = 2;
            this.lblContractHint.Text = "请留下你的联系方式(邮箱、电话等)，以便我们及时回复你。";
            // 
            // txtContractInfo
            // 
            // 
            // 
            // 
            this.txtContractInfo.Border.Class = "TextBoxBorder";
            this.txtContractInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtContractInfo.FocusHighlightEnabled = true;
            this.txtContractInfo.Location = new System.Drawing.Point(105, 8);
            this.txtContractInfo.Name = "txtContractInfo";
            this.txtContractInfo.SelectedValue = null;
            this.txtContractInfo.Size = new System.Drawing.Size(187, 23);
            this.txtContractInfo.TabIndex = 1;
            // 
            // lblContractInfo
            // 
            this.lblContractInfo.AutoEllipsis = true;
            this.lblContractInfo.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblContractInfo.Location = new System.Drawing.Point(4, 12);
            this.lblContractInfo.Name = "lblContractInfo";
            this.lblContractInfo.Size = new System.Drawing.Size(99, 14);
            this.lblContractInfo.TabIndex = 0;
            this.lblContractInfo.Text = "联系方式：";
            this.lblContractInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(81, 27);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(203, 14);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.rdiframework.net/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FrmFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 562);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmFeedback";
            this.Text = "意见反馈[提意见]";
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label lblFeedbackContent;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Label lblFile;
        private Controls.UcButton btnAddAttachments;
        private Controls.UcTextBox txtAddAttachments;
        private Controls.UcHtmlEditor htmlEditorEmailContent;
        private System.Windows.Forms.Label lblContractInfo;
        private Controls.UcTextBox txtContractInfo;
        private System.Windows.Forms.Label lblContractHint;
        private System.Windows.Forms.Label lblBlog;
        private System.Windows.Forms.LinkLabel linkcnblogs;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcButton btnAddAttach;
        private Controls.UcButton btnClose;
        private Controls.UcButton btnSendEmail;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}