namespace RDIFramework.WinModule
{
    partial class FrmSequenceEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSequenceEdit));
            this.txtStep = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblStep = new System.Windows.Forms.Label();
            this.txtReduction = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblReduction = new System.Windows.Forms.Label();
            this.txtSequence = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSequence = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPrefix = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtSeparate = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSeparate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.gbDetail.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStep
            // 
            this.txtStep.AccessibleName = "EmptyValue|NotNull";
            this.txtStep.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtStep.Border.Class = "TextBoxBorder";
            this.txtStep.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStep.FocusHighlightEnabled = true;
            this.txtStep.Location = new System.Drawing.Point(95, 169);
            this.txtStep.MaxLength = 15;
            this.txtStep.Name = "txtStep";
            this.txtStep.SelectedValue = null;
            this.txtStep.Size = new System.Drawing.Size(356, 23);
            this.txtStep.TabIndex = 5;
            this.txtStep.Tag = "姓名";
            // 
            // lblStep
            // 
            this.lblStep.AutoEllipsis = true;
            this.lblStep.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblStep.Location = new System.Drawing.Point(6, 174);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(89, 14);
            this.lblStep.TabIndex = 55;
            this.lblStep.Text = "步  骤：";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReduction
            // 
            this.txtReduction.AccessibleName = "EmptyValue|NotNull";
            this.txtReduction.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtReduction.Border.Class = "TextBoxBorder";
            this.txtReduction.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReduction.FocusHighlightEnabled = true;
            this.txtReduction.Location = new System.Drawing.Point(95, 140);
            this.txtReduction.MaxLength = 15;
            this.txtReduction.Name = "txtReduction";
            this.txtReduction.SelectedValue = null;
            this.txtReduction.Size = new System.Drawing.Size(356, 23);
            this.txtReduction.TabIndex = 4;
            this.txtReduction.Tag = "姓名";
            // 
            // lblReduction
            // 
            this.lblReduction.AutoEllipsis = true;
            this.lblReduction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReduction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblReduction.Location = new System.Drawing.Point(6, 145);
            this.lblReduction.Name = "lblReduction";
            this.lblReduction.Size = new System.Drawing.Size(89, 14);
            this.lblReduction.TabIndex = 53;
            this.lblReduction.Text = "减序列：";
            this.lblReduction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSequence
            // 
            this.txtSequence.AccessibleName = "EmptyValue|NotNull";
            this.txtSequence.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSequence.Border.Class = "TextBoxBorder";
            this.txtSequence.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSequence.FocusHighlightEnabled = true;
            this.txtSequence.Location = new System.Drawing.Point(95, 111);
            this.txtSequence.MaxLength = 15;
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.SelectedValue = null;
            this.txtSequence.Size = new System.Drawing.Size(356, 23);
            this.txtSequence.TabIndex = 3;
            this.txtSequence.Tag = "姓名";
            // 
            // lblSequence
            // 
            this.lblSequence.AutoEllipsis = true;
            this.lblSequence.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSequence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblSequence.Location = new System.Drawing.Point(6, 116);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(89, 14);
            this.lblSequence.TabIndex = 51;
            this.lblSequence.Text = "增序列：";
            this.lblSequence.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.txtFullName);
            this.gbDetail.Controls.Add(this.txtStep);
            this.gbDetail.Controls.Add(this.lblStep);
            this.gbDetail.Controls.Add(this.txtReduction);
            this.gbDetail.Controls.Add(this.lblReduction);
            this.gbDetail.Controls.Add(this.txtSequence);
            this.gbDetail.Controls.Add(this.lblSequence);
            this.gbDetail.Controls.Add(this.lblFullName);
            this.gbDetail.Controls.Add(this.txtDescription);
            this.gbDetail.Controls.Add(this.lblDescription);
            this.gbDetail.Controls.Add(this.txtPrefix);
            this.gbDetail.Controls.Add(this.lblPrefix);
            this.gbDetail.Controls.Add(this.txtSeparate);
            this.gbDetail.Controls.Add(this.lblSeparate);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(0, 25);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(466, 295);
            this.gbDetail.TabIndex = 4;
            this.gbDetail.TabStop = false;
            this.gbDetail.Tag = "";
            this.gbDetail.Text = "基本信息";
            // 
            // txtFullName
            // 
            this.txtFullName.AccessibleName = "EmptyValue|NotNull";
            this.txtFullName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(95, 20);
            this.txtFullName.MaxLength = 15;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = null;
            this.txtFullName.Size = new System.Drawing.Size(356, 23);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Tag = "姓名";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblFullName.Location = new System.Drawing.Point(9, 25);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(86, 14);
            this.lblFullName.TabIndex = 47;
            this.lblFullName.Text = "名  称：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(95, 198);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = null;
            this.txtDescription.Size = new System.Drawing.Size(356, 86);
            this.txtDescription.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 203);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 14);
            this.lblDescription.TabIndex = 35;
            this.lblDescription.Text = "描  述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrefix
            // 
            this.txtPrefix.AccessibleName = "EmptyValue";
            this.txtPrefix.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPrefix.Border.Class = "TextBoxBorder";
            this.txtPrefix.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrefix.FocusHighlightEnabled = true;
            this.txtPrefix.Location = new System.Drawing.Point(95, 50);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.SelectedValue = null;
            this.txtPrefix.Size = new System.Drawing.Size(356, 23);
            this.txtPrefix.TabIndex = 1;
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoEllipsis = true;
            this.lblPrefix.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrefix.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrefix.Location = new System.Drawing.Point(6, 55);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(89, 14);
            this.lblPrefix.TabIndex = 4;
            this.lblPrefix.Text = "前  缀：";
            this.lblPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeparate
            // 
            this.txtSeparate.AccessibleName = "EmptyValue";
            this.txtSeparate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSeparate.Border.Class = "TextBoxBorder";
            this.txtSeparate.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSeparate.FocusHighlightEnabled = true;
            this.txtSeparate.Location = new System.Drawing.Point(95, 81);
            this.txtSeparate.MaxLength = 15;
            this.txtSeparate.Name = "txtSeparate";
            this.txtSeparate.SelectedValue = null;
            this.txtSeparate.Size = new System.Drawing.Size(356, 23);
            this.txtSeparate.TabIndex = 2;
            this.txtSeparate.Tag = "姓名";
            // 
            // lblSeparate
            // 
            this.lblSeparate.AutoEllipsis = true;
            this.lblSeparate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSeparate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSeparate.Location = new System.Drawing.Point(6, 86);
            this.lblSeparate.Name = "lblSeparate";
            this.lblSeparate.Size = new System.Drawing.Size(89, 14);
            this.lblSeparate.TabIndex = 2;
            this.lblSeparate.Text = "分隔符：";
            this.lblSeparate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(466, 25);
            this.tlsTool.TabIndex = 3;
            this.tlsTool.Text = "toolStrip1";
            // 
            // FrmSequenceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 320);
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.tlsTool);
            this.MaximizeBox = false;
            this.Name = "FrmSequenceEdit";
            this.Text = "编辑序列";
            this.gbDetail.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcTextBox txtStep;
        private System.Windows.Forms.Label lblStep;
        private Controls.UcTextBox txtReduction;
        private System.Windows.Forms.Label lblReduction;
        private Controls.UcTextBox txtSequence;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcTextBox txtPrefix;
        private System.Windows.Forms.Label lblPrefix;
        private Controls.UcTextBox txtSeparate;
        private System.Windows.Forms.Label lblSeparate;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStrip tlsTool;
        private Controls.UcTextBox txtFullName;
    }
}