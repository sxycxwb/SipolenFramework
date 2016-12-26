namespace RDIFramework.WorkFlow
{
    partial class FrmAddWorkFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddWorkFlow));
            this.tbxClassCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxWorkflowCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblWorkFlowClass = new System.Windows.Forms.Label();
            this.lblWorkFlowCaption = new System.Windows.Forms.Label();
            this.gbBaseInfo = new System.Windows.Forms.GroupBox();
            this.tbxPath = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnBussWebPage = new RDIFramework.Controls.UcButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.tbxDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblWorkFlowDescription = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbBaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lblWorkFlowDescription);
            this.plclassFill.Controls.Add(this.tbxDescription);
            this.plclassFill.Controls.Add(this.gbBaseInfo);
            this.plclassFill.Size = new System.Drawing.Size(386, 287);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 240);
            this.plclassBottom.Size = new System.Drawing.Size(386, 47);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(279, 8);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 8);
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxClassCaption
            // 
            this.tbxClassCaption.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxClassCaption.Border.Class = "TextBoxBorder";
            this.tbxClassCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxClassCaption.FocusHighlightEnabled = true;
            this.tbxClassCaption.Location = new System.Drawing.Point(88, 19);
            this.tbxClassCaption.Name = "tbxClassCaption";
            this.tbxClassCaption.ReadOnly = true;
            this.tbxClassCaption.SelectedValue = ((object)(resources.GetObject("tbxClassCaption.SelectedValue")));
            this.tbxClassCaption.Size = new System.Drawing.Size(238, 23);
            this.tbxClassCaption.TabIndex = 0;
            // 
            // tbxWorkflowCaption
            // 
            // 
            // 
            // 
            this.tbxWorkflowCaption.Border.Class = "TextBoxBorder";
            this.tbxWorkflowCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxWorkflowCaption.FocusHighlightEnabled = true;
            this.tbxWorkflowCaption.Location = new System.Drawing.Point(88, 50);
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            this.tbxWorkflowCaption.SelectedValue = ((object)(resources.GetObject("tbxWorkflowCaption.SelectedValue")));
            this.tbxWorkflowCaption.Size = new System.Drawing.Size(238, 23);
            this.tbxWorkflowCaption.TabIndex = 1;
            // 
            // lblWorkFlowClass
            // 
            this.lblWorkFlowClass.AutoEllipsis = true;
            this.lblWorkFlowClass.Location = new System.Drawing.Point(3, 23);
            this.lblWorkFlowClass.Name = "lblWorkFlowClass";
            this.lblWorkFlowClass.Size = new System.Drawing.Size(84, 14);
            this.lblWorkFlowClass.TabIndex = 6;
            this.lblWorkFlowClass.Text = "流程分类:";
            this.lblWorkFlowClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkFlowCaption
            // 
            this.lblWorkFlowCaption.AutoEllipsis = true;
            this.lblWorkFlowCaption.Location = new System.Drawing.Point(3, 54);
            this.lblWorkFlowCaption.Name = "lblWorkFlowCaption";
            this.lblWorkFlowCaption.Size = new System.Drawing.Size(84, 14);
            this.lblWorkFlowCaption.TabIndex = 6;
            this.lblWorkFlowCaption.Text = "流程名称:";
            this.lblWorkFlowCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Controls.Add(this.tbxPath);
            this.gbBaseInfo.Controls.Add(this.btnBussWebPage);
            this.gbBaseInfo.Controls.Add(this.label2);
            this.gbBaseInfo.Controls.Add(this.chkStatus);
            this.gbBaseInfo.Controls.Add(this.lblWorkFlowClass);
            this.gbBaseInfo.Controls.Add(this.tbxWorkflowCaption);
            this.gbBaseInfo.Controls.Add(this.tbxClassCaption);
            this.gbBaseInfo.Controls.Add(this.lblWorkFlowCaption);
            this.gbBaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(386, 133);
            this.gbBaseInfo.TabIndex = 0;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "基本信息";
            // 
            // tbxPath
            // 
            // 
            // 
            // 
            this.tbxPath.Border.Class = "TextBoxBorder";
            this.tbxPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxPath.FocusHighlightEnabled = true;
            this.tbxPath.Location = new System.Drawing.Point(88, 82);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.SelectedValue = ((object)(resources.GetObject("tbxPath.SelectedValue")));
            this.tbxPath.Size = new System.Drawing.Size(238, 23);
            this.tbxPath.TabIndex = 2;
            // 
            // btnBussWebPage
            // 
            this.btnBussWebPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBussWebPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnBussWebPage.Location = new System.Drawing.Point(332, 82);
            this.btnBussWebPage.Name = "btnBussWebPage";
            this.btnBussWebPage.Size = new System.Drawing.Size(32, 23);
            this.btnBussWebPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBussWebPage.TabIndex = 123;
            this.btnBussWebPage.Text = "...";
            this.btnBussWebPage.Click += new System.EventHandler(this.btnBussWebPage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 122;
            this.label2.Text = "URL:";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(84, 111);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(54, 18);
            this.chkStatus.TabIndex = 3;
            this.chkStatus.Text = "启用";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // tbxDescription
            // 
            // 
            // 
            // 
            this.tbxDescription.Border.Class = "TextBoxBorder";
            this.tbxDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxDescription.FocusHighlightEnabled = true;
            this.tbxDescription.Location = new System.Drawing.Point(23, 160);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.SelectedValue = ((object)(resources.GetObject("tbxDescription.SelectedValue")));
            this.tbxDescription.Size = new System.Drawing.Size(343, 64);
            this.tbxDescription.TabIndex = 1;
            // 
            // lblWorkFlowDescription
            // 
            this.lblWorkFlowDescription.AutoSize = true;
            this.lblWorkFlowDescription.Location = new System.Drawing.Point(12, 136);
            this.lblWorkFlowDescription.Name = "lblWorkFlowDescription";
            this.lblWorkFlowDescription.Size = new System.Drawing.Size(70, 14);
            this.lblWorkFlowDescription.TabIndex = 16;
            this.lblWorkFlowDescription.Text = "流程描述:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmAddWorkFlow
            // 
            this.ClientSize = new System.Drawing.Size(386, 287);
            this.Name = "FrmAddWorkFlow";
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.gbBaseInfo.ResumeLayout(false);
            this.gbBaseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcTextBox tbxClassCaption;
        private Controls.UcTextBox tbxWorkflowCaption;
        private System.Windows.Forms.Label lblWorkFlowCaption;
        private System.Windows.Forms.Label lblWorkFlowClass;
        private System.Windows.Forms.GroupBox gbBaseInfo;
        private System.Windows.Forms.Label lblWorkFlowDescription;
        private Controls.UcTextBox tbxDescription;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Controls.UcButton btnBussWebPage;
        private Controls.UcTextBox tbxPath;
    }
}
