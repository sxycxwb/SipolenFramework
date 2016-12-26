namespace RDIFramework.WinModule
{
    partial class FrmSendMessage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtUserIdList = new RDIFramework.WinModule.UcUserSelect();
            this.lblSender = new System.Windows.Forms.Label();
            this.txtTitle = new RDIFramework.Controls.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtxtMSGContent = new RDIFramework.Controls.UcRichTextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnSend = new RDIFramework.Controls.UcButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.txtUserIdList);
            this.panel1.Controls.Add(this.lblSender);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rtxtMSGContent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 377);
            this.panel1.TabIndex = 0;
            // 
            // txtUserIdList
            // 
            this.txtUserIdList.AllowNull = true;
            this.txtUserIdList.AllowSelect = true;
            this.txtUserIdList.Location = new System.Drawing.Point(85, 7);
            this.txtUserIdList.MultiSelect = true;
            this.txtUserIdList.Name = "txtUserIdList";
            this.txtUserIdList.OrganizeId = "";
            this.txtUserIdList.PermissionScopeCode = "";
            this.txtUserIdList.RemoveIds = null;
            this.txtUserIdList.RoleId = "";
            this.txtUserIdList.SelectedFullName = "";
            this.txtUserIdList.SelectedId = null;
            this.txtUserIdList.SelectedIds = null;
            this.txtUserIdList.SetSelectedIds = null;
            this.txtUserIdList.Size = new System.Drawing.Size(530, 24);
            this.txtUserIdList.TabIndex = 11;
            this.txtUserIdList.UserIds = null;
            // 
            // lblSender
            // 
            this.lblSender.AutoSize = true;
            this.lblSender.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSender.Location = new System.Drawing.Point(82, 353);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(31, 14);
            this.lblSender.TabIndex = 10;
            this.lblSender.Text = "...";
            // 
            // txtTitle
            // 
            // 
            // 
            // 
            this.txtTitle.Border.Class = "TextBoxBorder";
            this.txtTitle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTitle.FocusHighlightEnabled = true;
            this.txtTitle.Location = new System.Drawing.Point(85, 43);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.SelectedValue = "";
            this.txtTitle.Size = new System.Drawing.Size(530, 23);
            this.txtTitle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "发件人：";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(15, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(600, 2);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // rtxtMSGContent
            // 
            this.rtxtMSGContent.AlignCenterVisible = true;
            this.rtxtMSGContent.AlignLeftVisible = true;
            this.rtxtMSGContent.AlignRightVisible = true;
            this.rtxtMSGContent.BoldVisible = true;
            this.rtxtMSGContent.BulletsVisible = false;
            this.rtxtMSGContent.ChooseFontVisible = true;
            this.rtxtMSGContent.FindReplaceVisible = false;
            this.rtxtMSGContent.FontColorVisible = true;
            this.rtxtMSGContent.FontFamilyVisible = true;
            this.rtxtMSGContent.FontSizeVisible = true;
            this.rtxtMSGContent.GroupAlignmentVisible = true;
            this.rtxtMSGContent.GroupBoldUnderlineItalicVisible = true;
            this.rtxtMSGContent.GroupFontColorVisible = true;
            this.rtxtMSGContent.GroupFontNameAndSizeVisible = true;
            this.rtxtMSGContent.GroupIndentationAndBulletsVisible = false;
            this.rtxtMSGContent.GroupInsertVisible = false;
            this.rtxtMSGContent.GroupSaveAndLoadVisible = false;
            this.rtxtMSGContent.GroupZoomVisible = false;
            this.rtxtMSGContent.INDENT = 10;
            this.rtxtMSGContent.IndentVisible = true;
            this.rtxtMSGContent.InsertPictureVisible = false;
            this.rtxtMSGContent.ItalicVisible = true;
            this.rtxtMSGContent.LoadVisible = false;
            this.rtxtMSGContent.Location = new System.Drawing.Point(15, 84);
            this.rtxtMSGContent.Name = "rtxtMSGContent";
            this.rtxtMSGContent.OutdentVisible = true;
            this.rtxtMSGContent.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs21\\par\r\n}\r\n";
            this.rtxtMSGContent.SaveVisible = false;
            this.rtxtMSGContent.SelectionColor = System.Drawing.Color.Black;
            this.rtxtMSGContent.SelectionLength = 0;
            this.rtxtMSGContent.SelectionStart = 0;
            this.rtxtMSGContent.SeparatorAlignVisible = true;
            this.rtxtMSGContent.SeparatorBoldUnderlineItalicVisible = true;
            this.rtxtMSGContent.SeparatorFontColorVisible = true;
            this.rtxtMSGContent.SeparatorFontVisible = true;
            this.rtxtMSGContent.SeparatorIndentAndBulletsVisible = false;
            this.rtxtMSGContent.SeparatorInsertVisible = true;
            this.rtxtMSGContent.SeparatorSaveLoadVisible = false;
            this.rtxtMSGContent.Size = new System.Drawing.Size(600, 251);
            this.rtxtMSGContent.TabIndex = 4;
            this.rtxtMSGContent.ToolStripVisible = true;
            this.rtxtMSGContent.UnderlineVisible = true;
            this.rtxtMSGContent.WordWrapVisible = true;
            this.rtxtMSGContent.ZoomFactorTextVisible = false;
            this.rtxtMSGContent.ZoomInVisible = false;
            this.rtxtMSGContent.ZoomOutVisible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "主  题：";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(15, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(600, 2);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "收件人：";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 2);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 382);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 38);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(530, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSend.Location = new System.Drawing.Point(440, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // FrmSendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSendMessage";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "发送消息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controls.UcRichTextBoxEx rtxtMSGContent;
        private Controls.UcButton btnClose;
        private Controls.UcButton btnSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox txtTitle;
        private System.Windows.Forms.Label lblSender;
        private UcUserSelect txtUserIdList;
    }
}