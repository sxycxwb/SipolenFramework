namespace RDIFramework.CodeMaker
{
	partial class FindAndReplaceForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblReplaceWith = new System.Windows.Forms.Label();
			this.txtLookFor = new System.Windows.Forms.TextBox();
			this.txtReplaceWith = new System.Windows.Forms.TextBox();
			this.btnFindNext = new System.Windows.Forms.Button();
			this.btnReplace = new System.Windows.Forms.Button();
			this.btnReplaceAll = new System.Windows.Forms.Button();
			this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
			this.chkMatchCase = new System.Windows.Forms.CheckBox();
			this.btnFindAllHighlightAll = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFindPrevious = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "查找内容(&N):";
			// 
			// lblReplaceWith
			// 
			this.lblReplaceWith.AutoSize = true;
			this.lblReplaceWith.Location = new System.Drawing.Point(12, 39);
			this.lblReplaceWith.Name = "lblReplaceWith";
			this.lblReplaceWith.Size = new System.Drawing.Size(59, 13);
			this.lblReplaceWith.TabIndex = 2;
			this.lblReplaceWith.Text = "替换为(&P):";
			// 
			// txtLookFor
			// 
			this.txtLookFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLookFor.Location = new System.Drawing.Point(95, 7);
			this.txtLookFor.Name = "txtLookFor";
			this.txtLookFor.Size = new System.Drawing.Size(232, 20);
			this.txtLookFor.TabIndex = 1;
			// 
			// txtReplaceWith
			// 
			this.txtReplaceWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtReplaceWith.Location = new System.Drawing.Point(95, 36);
			this.txtReplaceWith.Name = "txtReplaceWith";
			this.txtReplaceWith.Size = new System.Drawing.Size(232, 20);
			this.txtReplaceWith.TabIndex = 3;
			// 
			// btnFindNext
			// 
			this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindNext.Location = new System.Drawing.Point(228, 148);
			this.btnFindNext.Name = "btnFindNext";
			this.btnFindNext.Size = new System.Drawing.Size(100, 33);
			this.btnFindNext.TabIndex = 6;
			this.btnFindNext.Text = "查找下一个(&F)";
			this.btnFindNext.UseVisualStyleBackColor = true;
			this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
			// 
			// btnReplace
			// 
			this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplace.Location = new System.Drawing.Point(16, 187);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(100, 33);
			this.btnReplace.TabIndex = 7;
			this.btnReplace.Text = "替换(&R)";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// btnReplaceAll
			// 
			this.btnReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReplaceAll.Location = new System.Drawing.Point(122, 187);
			this.btnReplaceAll.Name = "btnReplaceAll";
			this.btnReplaceAll.Size = new System.Drawing.Size(100, 33);
			this.btnReplaceAll.TabIndex = 9;
			this.btnReplaceAll.Text = "全部替换(&A)";
			this.btnReplaceAll.UseVisualStyleBackColor = true;
			this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
			// 
			// chkMatchWholeWord
			// 
			this.chkMatchWholeWord.AutoSize = true;
			this.chkMatchWholeWord.Location = new System.Drawing.Point(145, 29);
			this.chkMatchWholeWord.Name = "chkMatchWholeWord";
			this.chkMatchWholeWord.Size = new System.Drawing.Size(91, 17);
			this.chkMatchWholeWord.TabIndex = 5;
			this.chkMatchWholeWord.Text = "全字匹配(&W)";
			this.chkMatchWholeWord.UseVisualStyleBackColor = true;
			// 
			// chkMatchCase
			// 
			this.chkMatchCase.AutoSize = true;
			this.chkMatchCase.Location = new System.Drawing.Point(22, 29);
			this.chkMatchCase.Name = "chkMatchCase";
			this.chkMatchCase.Size = new System.Drawing.Size(99, 17);
			this.chkMatchCase.TabIndex = 4;
			this.chkMatchCase.Text = "大小写匹配(&C)";
			this.chkMatchCase.UseVisualStyleBackColor = true;
			// 
			// btnFindAllHighlightAll
			// 
			this.btnFindAllHighlightAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindAllHighlightAll.Location = new System.Drawing.Point(72, 187);
			this.btnFindAllHighlightAll.Name = "btnFindAllHighlightAll";
			this.btnFindAllHighlightAll.Size = new System.Drawing.Size(150, 33);
			this.btnFindAllHighlightAll.TabIndex = 8;
			this.btnFindAllHighlightAll.Text = "查找全部并高亮显示(&H)";
			this.btnFindAllHighlightAll.UseVisualStyleBackColor = true;
			this.btnFindAllHighlightAll.Visible = false;
			this.btnFindAllHighlightAll.Click += new System.EventHandler(this.btnHighlightAll_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(228, 187);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 33);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnFindPrevious
			// 
			this.btnFindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFindPrevious.Location = new System.Drawing.Point(122, 148);
			this.btnFindPrevious.Name = "btnFindPrevious";
			this.btnFindPrevious.Size = new System.Drawing.Size(100, 33);
			this.btnFindPrevious.TabIndex = 6;
			this.btnFindPrevious.Text = "查找上一个(&P)";
			this.btnFindPrevious.UseVisualStyleBackColor = true;
			this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.chkMatchCase);
			this.groupBox1.Controls.Add(this.chkMatchWholeWord);
			this.groupBox1.Location = new System.Drawing.Point(14, 69);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(313, 68);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查找选项";
			// 
			// FindAndReplaceForm
			// 
			this.AcceptButton = this.btnReplace;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(339, 233);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnReplaceAll);
			this.Controls.Add(this.btnReplace);
			this.Controls.Add(this.btnFindAllHighlightAll);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnFindPrevious);
			this.Controls.Add(this.btnFindNext);
			this.Controls.Add(this.txtReplaceWith);
			this.Controls.Add(this.txtLookFor);
			this.Controls.Add(this.lblReplaceWith);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FindAndReplaceForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "查找和替换";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindAndReplaceForm_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblReplaceWith;
		private System.Windows.Forms.TextBox txtLookFor;
		private System.Windows.Forms.TextBox txtReplaceWith;
		private System.Windows.Forms.Button btnFindNext;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.Button btnReplaceAll;
		private System.Windows.Forms.CheckBox chkMatchWholeWord;
		private System.Windows.Forms.CheckBox chkMatchCase;
		private System.Windows.Forms.Button btnFindAllHighlightAll;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnFindPrevious;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}