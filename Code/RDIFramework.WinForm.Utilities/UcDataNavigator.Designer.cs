namespace RDIFramework.WinForm.Utilities
{
    partial class UcDataNavigator
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLast = new RDIFramework.Controls.UcButton();
            this.btnNext = new RDIFramework.Controls.UcButton();
            this.txtNavInfo = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnPrevious = new RDIFramework.Controls.UcButton();
            this.btnFirst = new RDIFramework.Controls.UcButton();
            this.SuspendLayout();
            // 
            // btnLast
            // 
            this.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLast.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLast.Location = new System.Drawing.Point(138, 2);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(25, 24);
            this.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLast.TabIndex = 5;
            this.btnLast.Text = ">|";
            this.btnLast.Tooltip = "移动到最后一条数据";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNext.Location = new System.Drawing.Point(113, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 24);
            this.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = ">";
            this.btnNext.Tooltip = "移动到下一条数据";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtNavInfo
            // 
            // 
            // 
            // 
            this.txtNavInfo.Border.Class = "TextBoxBorder";
            this.txtNavInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNavInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNavInfo.FocusHighlightEnabled = true;
            this.txtNavInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNavInfo.Location = new System.Drawing.Point(52, 2);
            this.txtNavInfo.Multiline = true;
            this.txtNavInfo.Name = "txtNavInfo";
            this.txtNavInfo.ReadOnly = true;
            this.txtNavInfo.SelectedValue = null;
            this.txtNavInfo.Size = new System.Drawing.Size(61, 24);
            this.txtNavInfo.TabIndex = 3;
            // 
            // btnPrevious
            // 
            this.btnPrevious.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrevious.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrevious.Location = new System.Drawing.Point(27, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Padding = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Size = new System.Drawing.Size(25, 24);
            this.btnPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Tooltip = "移动到上一条数据";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFirst.Location = new System.Drawing.Point(2, 2);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnFirst.Size = new System.Drawing.Size(25, 24);
            this.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFirst.TabIndex = 1;
            this.btnFirst.Text = "|<";
            this.btnFirst.Tooltip = "移动到第一条数据";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // UcDataNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtNavInfo);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UcDataNavigator";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(171, 28);
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.UcButton btnFirst;
        protected Controls.UcButton btnPrevious;
        protected Controls.UcTextBox txtNavInfo;
        protected Controls.UcButton btnNext;
        protected Controls.UcButton btnLast;

    }
}
