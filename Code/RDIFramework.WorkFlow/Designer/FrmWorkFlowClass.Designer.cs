namespace RDIFramework.WorkFlow
{
    partial class FrmWorkFlowClass
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlowClass));
            this.gbBaseInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPath = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnBussWebPage = new RDIFramework.Controls.UcButton();
            this.lblClassLevel = new System.Windows.Forms.Label();
            this.tbxCllevel = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblSuperClass = new System.Windows.Forms.Label();
            this.tbxClassCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxFatherClassCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblClassName = new System.Windows.Forms.Label();
            this.gbOtherInfo = new System.Windows.Forms.GroupBox();
            this.tbxDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblClassDescription = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbBaseInfo.SuspendLayout();
            this.gbOtherInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.gbOtherInfo);
            this.plclassFill.Controls.Add(this.gbBaseInfo);
            this.plclassFill.Size = new System.Drawing.Size(395, 312);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 249);
            this.plclassBottom.Size = new System.Drawing.Size(395, 63);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(280, 24);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(168, 24);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Controls.Add(this.label5);
            this.gbBaseInfo.Controls.Add(this.tbxPath);
            this.gbBaseInfo.Controls.Add(this.btnBussWebPage);
            this.gbBaseInfo.Controls.Add(this.lblClassLevel);
            this.gbBaseInfo.Controls.Add(this.tbxCllevel);
            this.gbBaseInfo.Controls.Add(this.lblSuperClass);
            this.gbBaseInfo.Controls.Add(this.tbxClassCaption);
            this.gbBaseInfo.Controls.Add(this.tbxFatherClassCaption);
            this.gbBaseInfo.Controls.Add(this.lblClassName);
            this.gbBaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(395, 133);
            this.gbBaseInfo.TabIndex = 15;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "基本信息";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 125;
            this.label5.Text = "URL:";
            // 
            // tbxPath
            // 
            // 
            // 
            // 
            this.tbxPath.Border.Class = "TextBoxBorder";
            this.tbxPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxPath.FocusHighlightEnabled = true;
            this.tbxPath.Location = new System.Drawing.Point(84, 99);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.SelectedValue = ((object)(resources.GetObject("tbxPath.SelectedValue")));
            this.tbxPath.Size = new System.Drawing.Size(237, 23);
            this.tbxPath.TabIndex = 124;
            // 
            // btnBussWebPage
            // 
            this.btnBussWebPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBussWebPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBussWebPage.Location = new System.Drawing.Point(325, 99);
            this.btnBussWebPage.Name = "btnBussWebPage";
            this.btnBussWebPage.Size = new System.Drawing.Size(41, 23);
            this.btnBussWebPage.TabIndex = 123;
            this.btnBussWebPage.Text = "...";
            this.btnBussWebPage.Click += new System.EventHandler(this.btnBussWebPage_Click);
            // 
            // lblClassLevel
            // 
            this.lblClassLevel.AutoEllipsis = true;
            this.lblClassLevel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblClassLevel.Location = new System.Drawing.Point(3, 75);
            this.lblClassLevel.Name = "lblClassLevel";
            this.lblClassLevel.Size = new System.Drawing.Size(79, 14);
            this.lblClassLevel.TabIndex = 11;
            this.lblClassLevel.Text = "分类级别:";
            this.lblClassLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCllevel
            // 
            this.tbxCllevel.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxCllevel.Border.Class = "TextBoxBorder";
            this.tbxCllevel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxCllevel.FocusHighlightEnabled = true;
            this.tbxCllevel.Location = new System.Drawing.Point(84, 72);
            this.tbxCllevel.Name = "tbxCllevel";
            this.tbxCllevel.ReadOnly = true;
            this.tbxCllevel.SelectedValue = ((object)(resources.GetObject("tbxCllevel.SelectedValue")));
            this.tbxCllevel.Size = new System.Drawing.Size(65, 23);
            this.tbxCllevel.TabIndex = 10;
            // 
            // lblSuperClass
            // 
            this.lblSuperClass.AutoEllipsis = true;
            this.lblSuperClass.Location = new System.Drawing.Point(3, 22);
            this.lblSuperClass.Name = "lblSuperClass";
            this.lblSuperClass.Size = new System.Drawing.Size(79, 14);
            this.lblSuperClass.TabIndex = 6;
            this.lblSuperClass.Text = "上级分类:";
            this.lblSuperClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxClassCaption
            // 
            // 
            // 
            // 
            this.tbxClassCaption.Border.Class = "TextBoxBorder";
            this.tbxClassCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxClassCaption.FocusHighlightEnabled = true;
            this.tbxClassCaption.Location = new System.Drawing.Point(84, 45);
            this.tbxClassCaption.Name = "tbxClassCaption";
            this.tbxClassCaption.SelectedValue = ((object)(resources.GetObject("tbxClassCaption.SelectedValue")));
            this.tbxClassCaption.Size = new System.Drawing.Size(284, 23);
            this.tbxClassCaption.TabIndex = 5;
            // 
            // tbxFatherClassCaption
            // 
            this.tbxFatherClassCaption.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxFatherClassCaption.Border.Class = "TextBoxBorder";
            this.tbxFatherClassCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxFatherClassCaption.FocusHighlightEnabled = true;
            this.tbxFatherClassCaption.Location = new System.Drawing.Point(85, 15);
            this.tbxFatherClassCaption.Name = "tbxFatherClassCaption";
            this.tbxFatherClassCaption.ReadOnly = true;
            this.tbxFatherClassCaption.SelectedValue = ((object)(resources.GetObject("tbxFatherClassCaption.SelectedValue")));
            this.tbxFatherClassCaption.Size = new System.Drawing.Size(284, 23);
            this.tbxFatherClassCaption.TabIndex = 2;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoEllipsis = true;
            this.lblClassName.Location = new System.Drawing.Point(3, 49);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(79, 14);
            this.lblClassName.TabIndex = 6;
            this.lblClassName.Text = "本级分类:";
            this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbOtherInfo
            // 
            this.gbOtherInfo.Controls.Add(this.tbxDescription);
            this.gbOtherInfo.Controls.Add(this.lblClassDescription);
            this.gbOtherInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOtherInfo.Location = new System.Drawing.Point(0, 133);
            this.gbOtherInfo.Name = "gbOtherInfo";
            this.gbOtherInfo.Size = new System.Drawing.Size(395, 104);
            this.gbOtherInfo.TabIndex = 16;
            this.gbOtherInfo.TabStop = false;
            this.gbOtherInfo.Text = "其他信息";
            // 
            // tbxDescription
            // 
            // 
            // 
            // 
            this.tbxDescription.Border.Class = "TextBoxBorder";
            this.tbxDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDescription.FocusHighlightEnabled = true;
            this.tbxDescription.Location = new System.Drawing.Point(36, 41);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.SelectedValue = ((object)(resources.GetObject("tbxDescription.SelectedValue")));
            this.tbxDescription.Size = new System.Drawing.Size(343, 51);
            this.tbxDescription.TabIndex = 16;
            // 
            // lblClassDescription
            // 
            this.lblClassDescription.AutoSize = true;
            this.lblClassDescription.Location = new System.Drawing.Point(33, 22);
            this.lblClassDescription.Name = "lblClassDescription";
            this.lblClassDescription.Size = new System.Drawing.Size(70, 14);
            this.lblClassDescription.TabIndex = 6;
            this.lblClassDescription.Text = "分类描述:";
            // 
            // FrmWorkFlowClass
            // 
            this.ClientSize = new System.Drawing.Size(395, 312);
            this.Name = "FrmWorkFlowClass";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.gbBaseInfo.ResumeLayout(false);
            this.gbBaseInfo.PerformLayout();
            this.gbOtherInfo.ResumeLayout(false);
            this.gbOtherInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBaseInfo;
        private System.Windows.Forms.Label lblSuperClass;
        private Controls.UcTextBox tbxClassCaption;
        private Controls.UcTextBox tbxFatherClassCaption;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.GroupBox gbOtherInfo;
        private System.Windows.Forms.Label lblClassDescription;
        private Controls.UcTextBox tbxDescription;
        private System.Windows.Forms.Label lblClassLevel;
        private Controls.UcTextBox tbxCllevel;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox tbxPath;
        private Controls.UcButton btnBussWebPage;
    }
}
