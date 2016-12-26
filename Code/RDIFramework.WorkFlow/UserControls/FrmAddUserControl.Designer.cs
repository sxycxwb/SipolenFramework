namespace RDIFramework.WorkFlow
{
    partial class FrmAddUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddUserControl));
            this.txtPath = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.gbBaseInfo = new System.Windows.Forms.GroupBox();
            this.rbType3 = new System.Windows.Forms.RadioButton();
            this.rbType2 = new System.Windows.Forms.RadioButton();
            this.rbType1 = new System.Windows.Forms.RadioButton();
            this.lblFormType = new System.Windows.Forms.Label();
            this.txtAssemblyName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblAssemblyName = new System.Windows.Forms.Label();
            this.txtFormName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFormName = new System.Windows.Forms.Label();
            this.txtControlId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblControlId = new System.Windows.Forms.Label();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbBaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lblDescription);
            this.plclassFill.Controls.Add(this.txtDescription);
            this.plclassFill.Controls.Add(this.gbBaseInfo);
            this.plclassFill.Size = new System.Drawing.Size(391, 335);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 288);
            this.plclassBottom.Size = new System.Drawing.Size(391, 47);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(280, 12);
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(176, 12);
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.Border.Class = "TextBoxBorder";
            this.txtPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPath.FocusHighlightEnabled = true;
            this.txtPath.Location = new System.Drawing.Point(110, 75);
            this.txtPath.Name = "txtPath";
            this.txtPath.SelectedValue = ((object)(resources.GetObject("txtPath.SelectedValue")));
            this.txtPath.Size = new System.Drawing.Size(234, 23);
            this.txtPath.TabIndex = 4;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.Location = new System.Drawing.Point(3, 27);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(104, 14);
            this.lblFullName.TabIndex = 6;
            this.lblFullName.Text = "子表单名:";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.Location = new System.Drawing.Point(3, 79);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(104, 14);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "位置:";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbBaseInfo
            // 
            this.gbBaseInfo.Controls.Add(this.rbType3);
            this.gbBaseInfo.Controls.Add(this.rbType2);
            this.gbBaseInfo.Controls.Add(this.rbType1);
            this.gbBaseInfo.Controls.Add(this.lblFormType);
            this.gbBaseInfo.Controls.Add(this.txtAssemblyName);
            this.gbBaseInfo.Controls.Add(this.lblAssemblyName);
            this.gbBaseInfo.Controls.Add(this.txtFormName);
            this.gbBaseInfo.Controls.Add(this.lblFormName);
            this.gbBaseInfo.Controls.Add(this.txtControlId);
            this.gbBaseInfo.Controls.Add(this.lblControlId);
            this.gbBaseInfo.Controls.Add(this.txtFullName);
            this.gbBaseInfo.Controls.Add(this.btnSearch);
            this.gbBaseInfo.Controls.Add(this.lblFullName);
            this.gbBaseInfo.Controls.Add(this.txtPath);
            this.gbBaseInfo.Controls.Add(this.lblPath);
            this.gbBaseInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBaseInfo.Location = new System.Drawing.Point(0, 0);
            this.gbBaseInfo.Name = "gbBaseInfo";
            this.gbBaseInfo.Size = new System.Drawing.Size(391, 196);
            this.gbBaseInfo.TabIndex = 0;
            this.gbBaseInfo.TabStop = false;
            this.gbBaseInfo.Text = "基本信息";
            // 
            // rbType3
            // 
            this.rbType3.AutoSize = true;
            this.rbType3.BackColor = System.Drawing.Color.Transparent;
            this.rbType3.Location = new System.Drawing.Point(245, 53);
            this.rbType3.Name = "rbType3";
            this.rbType3.Size = new System.Drawing.Size(102, 18);
            this.rbType3.TabIndex = 3;
            this.rbType3.TabStop = true;
            this.rbType3.Text = "WinForm/Web";
            this.rbType3.UseVisualStyleBackColor = false;
            // 
            // rbType2
            // 
            this.rbType2.AutoSize = true;
            this.rbType2.BackColor = System.Drawing.Color.Transparent;
            this.rbType2.Location = new System.Drawing.Point(193, 52);
            this.rbType2.Name = "rbType2";
            this.rbType2.Size = new System.Drawing.Size(46, 18);
            this.rbType2.TabIndex = 2;
            this.rbType2.TabStop = true;
            this.rbType2.Text = "Web";
            this.rbType2.UseVisualStyleBackColor = false;
            // 
            // rbType1
            // 
            this.rbType1.AutoSize = true;
            this.rbType1.BackColor = System.Drawing.Color.Transparent;
            this.rbType1.Location = new System.Drawing.Point(113, 52);
            this.rbType1.Name = "rbType1";
            this.rbType1.Size = new System.Drawing.Size(74, 18);
            this.rbType1.TabIndex = 1;
            this.rbType1.TabStop = true;
            this.rbType1.Text = "WinForm";
            this.rbType1.UseVisualStyleBackColor = false;
            // 
            // lblFormType
            // 
            this.lblFormType.AutoEllipsis = true;
            this.lblFormType.BackColor = System.Drawing.Color.Transparent;
            this.lblFormType.Location = new System.Drawing.Point(3, 52);
            this.lblFormType.Name = "lblFormType";
            this.lblFormType.Size = new System.Drawing.Size(104, 14);
            this.lblFormType.TabIndex = 128;
            this.lblFormType.Text = "表单类型:";
            this.lblFormType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.BackColor = System.Drawing.Color.Lavender;
            // 
            // 
            // 
            this.txtAssemblyName.Border.Class = "TextBoxBorder";
            this.txtAssemblyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAssemblyName.FocusHighlightEnabled = true;
            this.txtAssemblyName.Location = new System.Drawing.Point(110, 160);
            this.txtAssemblyName.MaxLength = 100;
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.SelectedValue = ((object)(resources.GetObject("txtAssemblyName.SelectedValue")));
            this.txtAssemblyName.Size = new System.Drawing.Size(234, 23);
            this.txtAssemblyName.TabIndex = 7;
            // 
            // lblAssemblyName
            // 
            this.lblAssemblyName.AutoEllipsis = true;
            this.lblAssemblyName.BackColor = System.Drawing.Color.Transparent;
            this.lblAssemblyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAssemblyName.ForeColor = System.Drawing.Color.Blue;
            this.lblAssemblyName.Location = new System.Drawing.Point(3, 163);
            this.lblAssemblyName.Name = "lblAssemblyName";
            this.lblAssemblyName.Size = new System.Drawing.Size(104, 14);
            this.lblAssemblyName.TabIndex = 124;
            this.lblAssemblyName.Text = "所在程序集:";
            this.lblAssemblyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFormName
            // 
            this.txtFormName.BackColor = System.Drawing.Color.Lavender;
            // 
            // 
            // 
            this.txtFormName.Border.Class = "TextBoxBorder";
            this.txtFormName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFormName.FocusHighlightEnabled = true;
            this.txtFormName.Location = new System.Drawing.Point(110, 131);
            this.txtFormName.MaxLength = 100;
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.SelectedValue = ((object)(resources.GetObject("txtFormName.SelectedValue")));
            this.txtFormName.Size = new System.Drawing.Size(234, 23);
            this.txtFormName.TabIndex = 6;
            // 
            // lblFormName
            // 
            this.lblFormName.AutoEllipsis = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFormName.ForeColor = System.Drawing.Color.Blue;
            this.lblFormName.Location = new System.Drawing.Point(3, 134);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(104, 14);
            this.lblFormName.TabIndex = 123;
            this.lblFormName.Text = "表单名称:";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtControlId
            // 
            // 
            // 
            // 
            this.txtControlId.Border.Class = "TextBoxBorder";
            this.txtControlId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtControlId.FocusHighlightEnabled = true;
            this.txtControlId.Location = new System.Drawing.Point(110, 102);
            this.txtControlId.Name = "txtControlId";
            this.txtControlId.SelectedValue = ((object)(resources.GetObject("txtControlId.SelectedValue")));
            this.txtControlId.Size = new System.Drawing.Size(234, 23);
            this.txtControlId.TabIndex = 5;
            // 
            // lblControlId
            // 
            this.lblControlId.AutoEllipsis = true;
            this.lblControlId.Location = new System.Drawing.Point(3, 106);
            this.lblControlId.Name = "lblControlId";
            this.lblControlId.Size = new System.Drawing.Size(104, 14);
            this.lblControlId.TabIndex = 9;
            this.lblControlId.Text = "控件ID:";
            this.lblControlId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(111, 23);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = ((object)(resources.GetObject("txtFullName.SelectedValue")));
            this.txtFullName.Size = new System.Drawing.Size(233, 23);
            this.txtFullName.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(351, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "...";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(24, 220);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.SelectedValue = ((object)(resources.GetObject("txtDescription.SelectedValue")));
            this.txtDescription.Size = new System.Drawing.Size(343, 64);
            this.txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(21, 199);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(150, 14);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "描述:";
            // 
            // FrmAddUserControl
            // 
            this.ClientSize = new System.Drawing.Size(391, 335);
            this.Name = "FrmAddUserControl";
            this.Text = "子表单维护";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.gbBaseInfo.ResumeLayout(false);
            this.gbBaseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcTextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.GroupBox gbBaseInfo;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcTextBox txtDescription;
        private Controls.UcButton btnSearch;
        private Controls.UcTextBox txtFullName;
        private Controls.UcTextBox txtControlId;
        private System.Windows.Forms.Label lblControlId;
        private Controls.UcTextBox txtAssemblyName;
        private System.Windows.Forms.Label lblAssemblyName;
        private Controls.UcTextBox txtFormName;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.RadioButton rbType3;
        private System.Windows.Forms.RadioButton rbType2;
        private System.Windows.Forms.RadioButton rbType1;
        private System.Windows.Forms.Label lblFormType;
    }
}
