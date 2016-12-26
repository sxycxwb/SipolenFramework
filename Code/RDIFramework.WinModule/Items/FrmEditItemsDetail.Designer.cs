namespace RDIFramework.WinModule
{
    partial class FrmEditItemsDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditItemsDetail));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtItemValue = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblItemValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtItemName = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtItemCode = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.tlsUserAdd = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain.SuspendLayout();
            this.tlsUserAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.txtItemValue);
            this.pnlMain.Controls.Add(this.lblItemValue);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.lblUserNameReq);
            this.pnlMain.Controls.Add(this.chkEnabled);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.txtItemName);
            this.pnlMain.Controls.Add(this.txtItemCode);
            this.pnlMain.Controls.Add(this.lblDescription);
            this.pnlMain.Controls.Add(this.lblItemName);
            this.pnlMain.Controls.Add(this.lblItemCode);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(422, 237);
            this.pnlMain.TabIndex = 16;
            // 
            // txtItemValue
            // 
            this.txtItemValue.AccessibleName = "EmptyValue|NotNull";
            this.txtItemValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemValue.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtItemValue.Border.Class = "TextBoxBorder";
            this.txtItemValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtItemValue.FocusHighlightEnabled = true;
            this.txtItemValue.Location = new System.Drawing.Point(90, 75);
            this.txtItemValue.MaxLength = 30;
            this.txtItemValue.Name = "txtItemValue";
            this.txtItemValue.SelectedValue = null;
            this.txtItemValue.Size = new System.Drawing.Size(292, 23);
            this.txtItemValue.TabIndex = 42;
            this.txtItemValue.Tag = "值";
            // 
            // lblItemValue
            // 
            this.lblItemValue.AutoEllipsis = true;
            this.lblItemValue.Location = new System.Drawing.Point(11, 76);
            this.lblItemValue.Name = "lblItemValue";
            this.lblItemValue.Size = new System.Drawing.Size(81, 14);
            this.lblItemValue.TabIndex = 43;
            this.lblItemValue.Text = "值：";
            this.lblItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(393, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(391, 19);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(14, 14);
            this.lblUserNameReq.TabIndex = 38;
            this.lblUserNameReq.Text = "*";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(90, 207);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(54, 18);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Tag = "有效";
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(90, 104);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(292, 97);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Tag = "描述";
            // 
            // txtItemName
            // 
            this.txtItemName.AccessibleName = "EmptyValue|NotNull";
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtItemName.Border.Class = "TextBoxBorder";
            this.txtItemName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtItemName.FocusHighlightEnabled = true;
            this.txtItemName.Location = new System.Drawing.Point(90, 46);
            this.txtItemName.MaxLength = 30;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.SelectedValue = null;
            this.txtItemName.Size = new System.Drawing.Size(292, 23);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.Tag = "名称";
            // 
            // txtItemCode
            // 
            this.txtItemCode.AccessibleName = "EmptyValue|NotNull";
            this.txtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtItemCode.Border.Class = "TextBoxBorder";
            this.txtItemCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtItemCode.FocusHighlightEnabled = true;
            this.txtItemCode.Location = new System.Drawing.Point(90, 17);
            this.txtItemCode.MaxLength = 25;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.SelectedValue = null;
            this.txtItemCode.Size = new System.Drawing.Size(292, 23);
            this.txtItemCode.TabIndex = 0;
            this.txtItemCode.Tag = "编号";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 109);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(91, 14);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoEllipsis = true;
            this.lblItemName.Location = new System.Drawing.Point(3, 50);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(91, 14);
            this.lblItemName.TabIndex = 7;
            this.lblItemName.Text = "名称：";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoEllipsis = true;
            this.lblItemCode.Location = new System.Drawing.Point(3, 21);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(91, 14);
            this.lblItemCode.TabIndex = 6;
            this.lblItemCode.Text = "编号：";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 22);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlsUserAdd
            // 
            this.tlsUserAdd.AutoSize = false;
            this.tlsUserAdd.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsUserAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator5,
            this.btnClose});
            this.tlsUserAdd.Location = new System.Drawing.Point(0, 0);
            this.tlsUserAdd.Name = "tlsUserAdd";
            this.tlsUserAdd.Size = new System.Drawing.Size(422, 25);
            this.tlsUserAdd.TabIndex = 17;
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
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmEditItemsDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 262);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsUserAdd);
            this.Name = "FrmEditItemsDetail";
            this.Text = "编辑字典明细";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.tlsUserAdd.ResumeLayout(false);
            this.tlsUserAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.CheckBox chkEnabled;
        private Controls.UcTextBox txtDescription;
        private Controls.UcTextBox txtItemName;
        private Controls.UcTextBox txtItemCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStrip tlsUserAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private Controls.UcTextBox txtItemValue;
        private System.Windows.Forms.Label lblItemValue;
    }
}