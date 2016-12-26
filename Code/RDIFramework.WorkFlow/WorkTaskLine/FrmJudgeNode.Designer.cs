namespace RDIFramework.WorkFlow
{
    partial class FrmJudgeNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJudgeNode));
            this.lblTaskName = new System.Windows.Forms.Label();
            this.tbxTaskName = new RDIFramework.Controls.UcTextBox(this.components);
            this.gbJudgeType = new System.Windows.Forms.GroupBox();
            this.rbtOr = new System.Windows.Forms.RadioButton();
            this.rbtAnd = new System.Windows.Forms.RadioButton();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbJudgeType.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lblTaskName);
            this.plclassFill.Controls.Add(this.tbxTaskName);
            this.plclassFill.Controls.Add(this.gbJudgeType);
            this.plclassFill.Size = new System.Drawing.Size(323, 157);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 117);
            this.plclassBottom.Size = new System.Drawing.Size(323, 40);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(229, 9);
            this.btnClose.Size = new System.Drawing.Size(79, 23);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(144, 9);
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoEllipsis = true;
            this.lblTaskName.Location = new System.Drawing.Point(6, 16);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(70, 14);
            this.lblTaskName.TabIndex = 5;
            this.lblTaskName.Text = "名称:";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTaskName
            // 
            // 
            // 
            // 
            this.tbxTaskName.Border.Class = "TextBoxBorder";
            this.tbxTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTaskName.FocusHighlightEnabled = true;
            this.tbxTaskName.Location = new System.Drawing.Point(77, 12);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.SelectedValue = ((object)(resources.GetObject("tbxTaskName.SelectedValue")));
            this.tbxTaskName.Size = new System.Drawing.Size(236, 23);
            this.tbxTaskName.TabIndex = 4;
            // 
            // gbJudgeType
            // 
            this.gbJudgeType.Controls.Add(this.rbtOr);
            this.gbJudgeType.Controls.Add(this.rbtAnd);
            this.gbJudgeType.Location = new System.Drawing.Point(12, 46);
            this.gbJudgeType.Name = "gbJudgeType";
            this.gbJudgeType.Size = new System.Drawing.Size(303, 62);
            this.gbJudgeType.TabIndex = 3;
            this.gbJudgeType.TabStop = false;
            this.gbJudgeType.Text = "判断类型";
            // 
            // rbtOr
            // 
            this.rbtOr.AutoSize = true;
            this.rbtOr.Location = new System.Drawing.Point(167, 27);
            this.rbtOr.Name = "rbtOr";
            this.rbtOr.Size = new System.Drawing.Size(67, 18);
            this.rbtOr.TabIndex = 1;
            this.rbtOr.TabStop = true;
            this.rbtOr.Text = "或(or)";
            this.rbtOr.UseVisualStyleBackColor = true;
            // 
            // rbtAnd
            // 
            this.rbtAnd.AutoSize = true;
            this.rbtAnd.Location = new System.Drawing.Point(45, 27);
            this.rbtAnd.Name = "rbtAnd";
            this.rbtAnd.Size = new System.Drawing.Size(74, 18);
            this.rbtAnd.TabIndex = 0;
            this.rbtAnd.TabStop = true;
            this.rbtAnd.Text = "与(and)";
            this.rbtAnd.UseVisualStyleBackColor = true;
            // 
            // FrmJudgeNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 157);
            this.Name = "FrmJudgeNode";
            this.Text = "控制节点配置";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.gbJudgeType.ResumeLayout(false);
            this.gbJudgeType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTaskName;
        private Controls.UcTextBox tbxTaskName;
        private System.Windows.Forms.GroupBox gbJudgeType;
        private System.Windows.Forms.RadioButton rbtOr;
        private System.Windows.Forms.RadioButton rbtAnd;
    }
}