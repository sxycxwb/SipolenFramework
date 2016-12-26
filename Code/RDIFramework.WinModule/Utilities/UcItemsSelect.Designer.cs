namespace RDIFramework.WinModule
{
    partial class UcItemsSelect
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFullName = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFullName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 24);
            this.panel1.TabIndex = 0;
            // 
            // txtFullName
            // 
            // 
            // 
            // 
            this.txtFullName.BackgroundStyle.Class = "TextBoxBorder";
            this.txtFullName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.ButtonClear.Visible = true;
            this.txtFullName.ButtonCustom.Visible = true;
            this.txtFullName.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtFullName.Location = new System.Drawing.Point(0, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(254, 24);
            this.txtFullName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Text = "";
            this.txtFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFullName.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.txtFullName.ButtonClearClick += new System.ComponentModel.CancelEventHandler(this.txtFullName_ButtonClearClick);
            this.txtFullName.ButtonCustomClick += new System.EventHandler(this.txtFullName_ButtonCustomClick);
            // 
            // UcItemsSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UcItemsSelect";
            this.Size = new System.Drawing.Size(254, 24);
            this.Load += new System.EventHandler(this.UcItemsSelect_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.MaskedTextBoxAdv txtFullName;
    }
}
