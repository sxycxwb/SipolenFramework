namespace RDIFramework.WinModule
{
    partial class FrmDBLinkEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDBLinkEdit));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblTip = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbLinks = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDbLinks = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.cboLinkType = new RDIFramework.Controls.UcComboBoxEx();
            this.label21 = new System.Windows.Forms.Label();
            this.lblLinkType = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.txtLinkName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblLinkName = new System.Windows.Forms.Label();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain.SuspendLayout();
            this.tlsUserAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.linkLabel1);
            this.pnlMain.Controls.Add(this.lblTip);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtDbLinks);
            this.pnlMain.Controls.Add(this.lblDbLinks);
            this.pnlMain.Controls.Add(this.chkEnabled);
            this.pnlMain.Controls.Add(this.cboLinkType);
            this.pnlMain.Controls.Add(this.label21);
            this.pnlMain.Controls.Add(this.lblLinkType);
            this.pnlMain.Controls.Add(this.lblUserNameReq);
            this.pnlMain.Controls.Add(this.txtLinkName);
            this.pnlMain.Controls.Add(this.lblLinkName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(752, 439);
            this.pnlMain.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(21, 254);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(716, 1);
            this.label10.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(97, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(645, 134);
            this.label7.TabIndex = 63;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Location = new System.Drawing.Point(297, 413);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(238, 14);
            this.linkLabel1.TabIndex = 62;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.connectionstrings.com/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblTip
            // 
            this.lblTip.AutoEllipsis = true;
            this.lblTip.Location = new System.Drawing.Point(3, 414);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(297, 14);
            this.lblTip.TabIndex = 60;
            this.lblTip.Text = "其他更多类型详细配置可参考：";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(98, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(40, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 58;
            this.label4.Text = "Tips：";
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(101, 172);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(626, 71);
            this.txtDescription.TabIndex = 57;
            this.txtDescription.Tag = "描述";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(0, 178);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(101, 14);
            this.lblDescription.TabIndex = 56;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(731, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 14);
            this.label3.TabIndex = 48;
            this.label3.Text = "*";
            // 
            // txtDbLinks
            // 
            this.txtDbLinks.AccessibleName = "EmptyValue|NotNull";
            // 
            // 
            // 
            this.txtDbLinks.Border.Class = "TextBoxBorder";
            this.txtDbLinks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDbLinks.FocusHighlightEnabled = true;
            this.txtDbLinks.Location = new System.Drawing.Point(101, 86);
            this.txtDbLinks.Multiline = true;
            this.txtDbLinks.Name = "txtDbLinks";
            this.txtDbLinks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDbLinks.SelectedValue = null;
            this.txtDbLinks.Size = new System.Drawing.Size(626, 70);
            this.txtDbLinks.TabIndex = 47;
            this.txtDbLinks.Tag = "服务器地址";
            // 
            // lblDbLinks
            // 
            this.lblDbLinks.AutoEllipsis = true;
            this.lblDbLinks.Location = new System.Drawing.Point(3, 88);
            this.lblDbLinks.Name = "lblDbLinks";
            this.lblDbLinks.Size = new System.Drawing.Size(98, 14);
            this.lblDbLinks.TabIndex = 46;
            this.lblDbLinks.Text = "连接字符串：";
            this.lblDbLinks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(319, 54);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(54, 18);
            this.chkEnabled.TabIndex = 45;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // cboLinkType
            // 
            this.cboLinkType.AccessibleName = "EmptyValue|NotNull";
            this.cboLinkType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLinkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinkType.FormattingEnabled = true;
            this.cboLinkType.Location = new System.Drawing.Point(101, 51);
            this.cboLinkType.Name = "cboLinkType";
            this.cboLinkType.Size = new System.Drawing.Size(181, 24);
            this.cboLinkType.TabIndex = 44;
            this.cboLinkType.Tag = "连接类型";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(283, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 14);
            this.label21.TabIndex = 43;
            this.label21.Text = "*";
            // 
            // lblLinkType
            // 
            this.lblLinkType.AutoEllipsis = true;
            this.lblLinkType.Location = new System.Drawing.Point(3, 55);
            this.lblLinkType.Name = "lblLinkType";
            this.lblLinkType.Size = new System.Drawing.Size(98, 14);
            this.lblLinkType.TabIndex = 42;
            this.lblLinkType.Text = "连接类型：";
            this.lblLinkType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(731, 26);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 38;
            this.lblUserNameReq.Text = "*";
            // 
            // txtLinkName
            // 
            this.txtLinkName.AccessibleName = "EmptyValue|NotNull";
            // 
            // 
            // 
            this.txtLinkName.Border.Class = "TextBoxBorder";
            this.txtLinkName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLinkName.FocusHighlightEnabled = true;
            this.txtLinkName.Location = new System.Drawing.Point(101, 21);
            this.txtLinkName.Name = "txtLinkName";
            this.txtLinkName.SelectedValue = null;
            this.txtLinkName.Size = new System.Drawing.Size(626, 23);
            this.txtLinkName.TabIndex = 1;
            this.txtLinkName.Tag = "连接名称";
            // 
            // lblLinkName
            // 
            this.lblLinkName.AutoEllipsis = true;
            this.lblLinkName.Location = new System.Drawing.Point(0, 25);
            this.lblLinkName.Name = "lblLinkName";
            this.lblLinkName.Size = new System.Drawing.Size(101, 14);
            this.lblLinkName.TabIndex = 0;
            this.lblLinkName.Text = "连接名称：";
            this.lblLinkName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlsUserAdd
            // 
            this.tlsUserAdd.AutoSize = false;
            this.tlsUserAdd.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsUserAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSaveContinue,
            this.toolStripSeparator5,
            this.btnClose});
            this.tlsUserAdd.Location = new System.Drawing.Point(0, 0);
            this.tlsUserAdd.Name = "tlsUserAdd";
            this.tlsUserAdd.Size = new System.Drawing.Size(752, 25);
            this.tlsUserAdd.TabIndex = 14;
            this.tlsUserAdd.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveContinue.Image")));
            this.btnSaveContinue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(57, 22);
            this.btnSaveContinue.Text = "继续";
            this.btnSaveContinue.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmDBLinkEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 464);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsUserAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDBLinkEdit";
            this.Text = "新增数据库连接";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblLinkName;
        private Controls.UcTextBox txtLinkName;
        private System.Windows.Forms.Label lblUserNameReq;
        private Controls.UcComboBoxEx cboLinkType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblLinkType;
        private System.Windows.Forms.CheckBox chkEnabled;
        private Controls.UcTextBox txtDbLinks;
        private System.Windows.Forms.Label lblDbLinks;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveContinue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
    }
}