namespace RDIFramework.NET
{
    partial class FrmGroupMsgRead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupMsgRead));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.webMsg = new System.Windows.Forms.WebBrowser();
            this.txtMsgContent = new RDIFramework.Controls.UcRichTextBoxEx();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.splitter1);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(670, 539);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.splitContainer2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(489, 539);
            this.panel6.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.webMsg);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtMsgContent);
            this.splitContainer2.Panel2.Controls.Add(this.panel8);
            this.splitContainer2.Size = new System.Drawing.Size(489, 539);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 0;
            // 
            // webMsg
            // 
            this.webMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webMsg.Location = new System.Drawing.Point(0, 0);
            this.webMsg.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMsg.Name = "webMsg";
            this.webMsg.Size = new System.Drawing.Size(489, 300);
            this.webMsg.TabIndex = 1;
            this.webMsg.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBMsg_DocumentCompleted);
            // 
            // txtMsgContent
            // 
            this.txtMsgContent.AlignCenterVisible = true;
            this.txtMsgContent.AlignLeftVisible = true;
            this.txtMsgContent.AlignRightVisible = true;
            this.txtMsgContent.BoldVisible = true;
            this.txtMsgContent.BulletsVisible = false;
            this.txtMsgContent.ChooseFontVisible = false;
            this.txtMsgContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsgContent.FindReplaceVisible = false;
            this.txtMsgContent.FontColorVisible = false;
            this.txtMsgContent.FontFamilyVisible = false;
            this.txtMsgContent.FontSizeVisible = false;
            this.txtMsgContent.GroupAlignmentVisible = true;
            this.txtMsgContent.GroupBoldUnderlineItalicVisible = true;
            this.txtMsgContent.GroupFontColorVisible = false;
            this.txtMsgContent.GroupFontNameAndSizeVisible = false;
            this.txtMsgContent.GroupIndentationAndBulletsVisible = false;
            this.txtMsgContent.GroupInsertVisible = false;
            this.txtMsgContent.GroupSaveAndLoadVisible = false;
            this.txtMsgContent.GroupZoomVisible = false;
            this.txtMsgContent.INDENT = 10;
            this.txtMsgContent.IndentVisible = false;
            this.txtMsgContent.InsertPictureVisible = false;
            this.txtMsgContent.ItalicVisible = true;
            this.txtMsgContent.LoadVisible = false;
            this.txtMsgContent.Location = new System.Drawing.Point(0, 0);
            this.txtMsgContent.Name = "txtMsgContent";
            this.txtMsgContent.OutdentVisible = false;
            this.txtMsgContent.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs21\\par\r\n}\r\n";
            this.txtMsgContent.SaveVisible = false;
            this.txtMsgContent.SelectionColor = System.Drawing.Color.Black;
            this.txtMsgContent.SelectionLength = 0;
            this.txtMsgContent.SelectionStart = 0;
            this.txtMsgContent.SeparatorAlignVisible = true;
            this.txtMsgContent.SeparatorBoldUnderlineItalicVisible = true;
            this.txtMsgContent.SeparatorFontColorVisible = false;
            this.txtMsgContent.SeparatorFontVisible = true;
            this.txtMsgContent.SeparatorIndentAndBulletsVisible = false;
            this.txtMsgContent.SeparatorInsertVisible = false;
            this.txtMsgContent.SeparatorSaveLoadVisible = false;
            this.txtMsgContent.Size = new System.Drawing.Size(489, 196);
            this.txtMsgContent.TabIndex = 0;
            this.txtMsgContent.ToolStripVisible = true;
            this.txtMsgContent.UnderlineVisible = true;
            this.txtMsgContent.WordWrapVisible = false;
            this.txtMsgContent.ZoomFactorTextVisible = false;
            this.txtMsgContent.ZoomInVisible = false;
            this.txtMsgContent.ZoomOutVisible = false;
            this.txtMsgContent.OnRichTextBoxTextChanged += new System.EventHandler(this.txtMsgContent_OnRichTextBoxTextChanged);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSend);
            this.panel8.Controls.Add(this.btnClose);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 196);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(489, 39);
            this.panel8.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(390, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(309, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(489, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 539);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Azure;
            this.panel7.Controls.Add(this.splitter2);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.pic);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(492, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(178, 539);
            this.panel7.TabIndex = 1;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.splitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 277);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(178, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 280);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(178, 259);
            this.panel9.TabIndex = 1;
            // 
            // pic
            // 
            this.pic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic.BackgroundImage")));
            this.pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic.Location = new System.Drawing.Point(18, 18);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(139, 153);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // FrmGroupMsgRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 539);
            this.Controls.Add(this.panel5);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGroupMsgRead";
            this.Text = "即时通讯";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMsgRead_FormClosing);
            this.Load += new System.EventHandler(this.FrmMsgRead_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcRichTextBoxEx ucRichTextBoxEx1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controls.UcRichTextBoxEx txtMsgContent;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.WebBrowser webMsg;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel9;
    }
}