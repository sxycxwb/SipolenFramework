namespace RDIFramework.WorkFlow
{
    partial class FrmOperator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperator));
            this.gbOperator = new System.Windows.Forms.GroupBox();
            this.btnSelectTask = new RDIFramework.Controls.UcButton();
            this.btnSelectVar = new RDIFramework.Controls.UcButton();
            this.btnSelectDuty = new RDIFramework.Controls.UcButton();
            this.btnSelectArch = new RDIFramework.Controls.UcButton();
            this.tbxOpr8 = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxOpr7 = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxOpr5 = new RDIFramework.Controls.UcTextBox(this.components);
            this.rbtOpr9 = new System.Windows.Forms.RadioButton();
            this.rbtOpr8 = new System.Windows.Forms.RadioButton();
            this.rbtOpr7 = new System.Windows.Forms.RadioButton();
            this.rbtOpr6 = new System.Windows.Forms.RadioButton();
            this.rbtOpr5 = new System.Windows.Forms.RadioButton();
            this.btnSelectRole = new RDIFramework.Controls.UcButton();
            this.tbxOpr4 = new RDIFramework.Controls.UcTextBox(this.components);
            this.rbtOpr4 = new System.Windows.Forms.RadioButton();
            this.tbxOpr6 = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSelectUser = new RDIFramework.Controls.UcButton();
            this.tbxOpr3 = new RDIFramework.Controls.UcTextBox(this.components);
            this.rbtOpr3 = new System.Windows.Forms.RadioButton();
            this.btnSelectOpr = new RDIFramework.Controls.UcButton();
            this.tbxOpr2 = new RDIFramework.Controls.UcTextBox(this.components);
            this.rbtOpr2 = new System.Windows.Forms.RadioButton();
            this.rbtOpr1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxRelation = new System.Windows.Forms.CheckBox();
            this.rbtRlt6 = new System.Windows.Forms.RadioButton();
            this.rbtRlt5 = new System.Windows.Forms.RadioButton();
            this.rbtRlt4 = new System.Windows.Forms.RadioButton();
            this.rbtRlt3 = new System.Windows.Forms.RadioButton();
            this.rbtRlt2 = new System.Windows.Forms.RadioButton();
            this.rbtRlt1 = new System.Windows.Forms.RadioButton();
            this.gbIncludeOrExclude = new System.Windows.Forms.GroupBox();
            this.rbtExclude = new System.Windows.Forms.RadioButton();
            this.rbtInclude = new System.Windows.Forms.RadioButton();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.gbOperator.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbIncludeOrExclude.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.gbIncludeOrExclude);
            this.plclassFill.Controls.Add(this.groupBox2);
            this.plclassFill.Controls.Add(this.gbOperator);
            this.plclassFill.Size = new System.Drawing.Size(495, 522);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 480);
            this.plclassBottom.Size = new System.Drawing.Size(495, 42);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(386, 10);
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(297, 10);
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbOperator
            // 
            this.gbOperator.Controls.Add(this.btnSelectTask);
            this.gbOperator.Controls.Add(this.btnSelectVar);
            this.gbOperator.Controls.Add(this.btnSelectDuty);
            this.gbOperator.Controls.Add(this.btnSelectArch);
            this.gbOperator.Controls.Add(this.tbxOpr8);
            this.gbOperator.Controls.Add(this.tbxOpr7);
            this.gbOperator.Controls.Add(this.tbxOpr5);
            this.gbOperator.Controls.Add(this.rbtOpr9);
            this.gbOperator.Controls.Add(this.rbtOpr8);
            this.gbOperator.Controls.Add(this.rbtOpr7);
            this.gbOperator.Controls.Add(this.rbtOpr6);
            this.gbOperator.Controls.Add(this.rbtOpr5);
            this.gbOperator.Controls.Add(this.btnSelectRole);
            this.gbOperator.Controls.Add(this.tbxOpr4);
            this.gbOperator.Controls.Add(this.rbtOpr4);
            this.gbOperator.Controls.Add(this.tbxOpr6);
            this.gbOperator.Controls.Add(this.btnSelectUser);
            this.gbOperator.Controls.Add(this.tbxOpr3);
            this.gbOperator.Controls.Add(this.rbtOpr3);
            this.gbOperator.Controls.Add(this.btnSelectOpr);
            this.gbOperator.Controls.Add(this.tbxOpr2);
            this.gbOperator.Controls.Add(this.rbtOpr2);
            this.gbOperator.Controls.Add(this.rbtOpr1);
            this.gbOperator.Location = new System.Drawing.Point(14, 14);
            this.gbOperator.Name = "gbOperator";
            this.gbOperator.Size = new System.Drawing.Size(461, 299);
            this.gbOperator.TabIndex = 0;
            this.gbOperator.TabStop = false;
            this.gbOperator.Text = "人员";
            // 
            // btnSelectTask
            // 
            this.btnSelectTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectTask.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectTask.Enabled = false;
            this.btnSelectTask.Location = new System.Drawing.Point(391, 263);
            this.btnSelectTask.Name = "btnSelectTask";
            this.btnSelectTask.Size = new System.Drawing.Size(32, 20);
            this.btnSelectTask.TabIndex = 22;
            this.btnSelectTask.Text = "...";
            this.btnSelectTask.Visible = false;
            this.btnSelectTask.Click += new System.EventHandler(this.btnSelectTask_Click);
            // 
            // btnSelectVar
            // 
            this.btnSelectVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectVar.Enabled = false;
            this.btnSelectVar.Location = new System.Drawing.Point(391, 208);
            this.btnSelectVar.Name = "btnSelectVar";
            this.btnSelectVar.Size = new System.Drawing.Size(32, 20);
            this.btnSelectVar.TabIndex = 21;
            this.btnSelectVar.Text = "...";
            this.btnSelectVar.Click += new System.EventHandler(this.btnSelectVar_Click);
            // 
            // btnSelectDuty
            // 
            this.btnSelectDuty.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectDuty.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectDuty.Enabled = false;
            this.btnSelectDuty.Location = new System.Drawing.Point(391, 176);
            this.btnSelectDuty.Name = "btnSelectDuty";
            this.btnSelectDuty.Size = new System.Drawing.Size(32, 20);
            this.btnSelectDuty.TabIndex = 20;
            this.btnSelectDuty.Text = "...";
            this.btnSelectDuty.Click += new System.EventHandler(this.btnSelectDuty_Click);
            // 
            // btnSelectArch
            // 
            this.btnSelectArch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectArch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectArch.Enabled = false;
            this.btnSelectArch.Location = new System.Drawing.Point(391, 115);
            this.btnSelectArch.Name = "btnSelectArch";
            this.btnSelectArch.Size = new System.Drawing.Size(32, 20);
            this.btnSelectArch.TabIndex = 19;
            this.btnSelectArch.Text = "...";
            this.btnSelectArch.Click += new System.EventHandler(this.btnSelectArch_Click);
            // 
            // tbxOpr8
            // 
            this.tbxOpr8.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr8.Border.Class = "TextBoxBorder";
            this.tbxOpr8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr8.FocusHighlightEnabled = true;
            this.tbxOpr8.Location = new System.Drawing.Point(187, 261);
            this.tbxOpr8.Name = "tbxOpr8";
            this.tbxOpr8.ReadOnly = true;
            this.tbxOpr8.SelectedValue = ((object)(resources.GetObject("tbxOpr8.SelectedValue")));
            this.tbxOpr8.Size = new System.Drawing.Size(196, 23);
            this.tbxOpr8.TabIndex = 18;
            this.tbxOpr8.Visible = false;
            // 
            // tbxOpr7
            // 
            this.tbxOpr7.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr7.Border.Class = "TextBoxBorder";
            this.tbxOpr7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr7.FocusHighlightEnabled = true;
            this.tbxOpr7.Location = new System.Drawing.Point(139, 208);
            this.tbxOpr7.Name = "tbxOpr7";
            this.tbxOpr7.ReadOnly = true;
            this.tbxOpr7.SelectedValue = ((object)(resources.GetObject("tbxOpr7.SelectedValue")));
            this.tbxOpr7.Size = new System.Drawing.Size(244, 23);
            this.tbxOpr7.TabIndex = 17;
            // 
            // tbxOpr5
            // 
            this.tbxOpr5.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr5.Border.Class = "TextBoxBorder";
            this.tbxOpr5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr5.FocusHighlightEnabled = true;
            this.tbxOpr5.Location = new System.Drawing.Point(105, 143);
            this.tbxOpr5.Name = "tbxOpr5";
            this.tbxOpr5.ReadOnly = true;
            this.tbxOpr5.SelectedValue = ((object)(resources.GetObject("tbxOpr5.SelectedValue")));
            this.tbxOpr5.Size = new System.Drawing.Size(277, 23);
            this.tbxOpr5.TabIndex = 16;
            // 
            // rbtOpr9
            // 
            this.rbtOpr9.AutoEllipsis = true;
            this.rbtOpr9.Location = new System.Drawing.Point(13, 236);
            this.rbtOpr9.Name = "rbtOpr9";
            this.rbtOpr9.Size = new System.Drawing.Size(228, 18);
            this.rbtOpr9.TabIndex = 15;
            this.rbtOpr9.TabStop = true;
            this.rbtOpr9.Text = "所有人";
            this.rbtOpr9.UseVisualStyleBackColor = true;
            this.rbtOpr9.CheckedChanged += new System.EventHandler(this.rbtOpr9_CheckedChanged);
            // 
            // rbtOpr8
            // 
            this.rbtOpr8.AutoEllipsis = true;
            this.rbtOpr8.Location = new System.Drawing.Point(13, 263);
            this.rbtOpr8.Name = "rbtOpr8";
            this.rbtOpr8.Size = new System.Drawing.Size(170, 18);
            this.rbtOpr8.TabIndex = 14;
            this.rbtOpr8.TabStop = true;
            this.rbtOpr8.Text = "某一任务选择的处理者";
            this.rbtOpr8.UseVisualStyleBackColor = true;
            this.rbtOpr8.Visible = false;
            this.rbtOpr8.CheckedChanged += new System.EventHandler(this.rbtOpr8_CheckedChanged);
            // 
            // rbtOpr7
            // 
            this.rbtOpr7.AutoEllipsis = true;
            this.rbtOpr7.Location = new System.Drawing.Point(13, 210);
            this.rbtOpr7.Name = "rbtOpr7";
            this.rbtOpr7.Size = new System.Drawing.Size(122, 18);
            this.rbtOpr7.TabIndex = 13;
            this.rbtOpr7.TabStop = true;
            this.rbtOpr7.Text = "从变量中获取";
            this.rbtOpr7.UseVisualStyleBackColor = true;
            this.rbtOpr7.CheckedChanged += new System.EventHandler(this.rbtOpr7_CheckedChanged);
            // 
            // rbtOpr6
            // 
            this.rbtOpr6.AutoEllipsis = true;
            this.rbtOpr6.Location = new System.Drawing.Point(13, 179);
            this.rbtOpr6.Name = "rbtOpr6";
            this.rbtOpr6.Size = new System.Drawing.Size(88, 18);
            this.rbtOpr6.TabIndex = 12;
            this.rbtOpr6.TabStop = true;
            this.rbtOpr6.Text = "岗位";
            this.rbtOpr6.UseVisualStyleBackColor = true;
            this.rbtOpr6.CheckedChanged += new System.EventHandler(this.rbtOpr6_CheckedChanged);
            // 
            // rbtOpr5
            // 
            this.rbtOpr5.AutoEllipsis = true;
            this.rbtOpr5.Location = new System.Drawing.Point(13, 145);
            this.rbtOpr5.Name = "rbtOpr5";
            this.rbtOpr5.Size = new System.Drawing.Size(89, 18);
            this.rbtOpr5.TabIndex = 11;
            this.rbtOpr5.TabStop = true;
            this.rbtOpr5.Text = "角色";
            this.rbtOpr5.UseVisualStyleBackColor = true;
            this.rbtOpr5.CheckedChanged += new System.EventHandler(this.rbtOpr5_CheckedChanged);
            // 
            // btnSelectRole
            // 
            this.btnSelectRole.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectRole.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectRole.Enabled = false;
            this.btnSelectRole.Location = new System.Drawing.Point(391, 145);
            this.btnSelectRole.Name = "btnSelectRole";
            this.btnSelectRole.Size = new System.Drawing.Size(32, 20);
            this.btnSelectRole.TabIndex = 10;
            this.btnSelectRole.Text = "...";
            this.btnSelectRole.Click += new System.EventHandler(this.btnSelectRole_Click);
            // 
            // tbxOpr4
            // 
            this.tbxOpr4.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr4.Border.Class = "TextBoxBorder";
            this.tbxOpr4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr4.FocusHighlightEnabled = true;
            this.tbxOpr4.Location = new System.Drawing.Point(106, 114);
            this.tbxOpr4.Name = "tbxOpr4";
            this.tbxOpr4.ReadOnly = true;
            this.tbxOpr4.SelectedValue = ((object)(resources.GetObject("tbxOpr4.SelectedValue")));
            this.tbxOpr4.Size = new System.Drawing.Size(277, 23);
            this.tbxOpr4.TabIndex = 9;
            // 
            // rbtOpr4
            // 
            this.rbtOpr4.AutoEllipsis = true;
            this.rbtOpr4.Location = new System.Drawing.Point(13, 119);
            this.rbtOpr4.Name = "rbtOpr4";
            this.rbtOpr4.Size = new System.Drawing.Size(91, 18);
            this.rbtOpr4.TabIndex = 8;
            this.rbtOpr4.TabStop = true;
            this.rbtOpr4.Text = "部门";
            this.rbtOpr4.UseVisualStyleBackColor = true;
            this.rbtOpr4.CheckedChanged += new System.EventHandler(this.rbtOpr4_CheckedChanged);
            // 
            // tbxOpr6
            // 
            this.tbxOpr6.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr6.Border.Class = "TextBoxBorder";
            this.tbxOpr6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr6.FocusHighlightEnabled = true;
            this.tbxOpr6.Location = new System.Drawing.Point(106, 176);
            this.tbxOpr6.Name = "tbxOpr6";
            this.tbxOpr6.ReadOnly = true;
            this.tbxOpr6.SelectedValue = ((object)(resources.GetObject("tbxOpr6.SelectedValue")));
            this.tbxOpr6.Size = new System.Drawing.Size(277, 23);
            this.tbxOpr6.TabIndex = 7;
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectUser.Enabled = false;
            this.btnSelectUser.Location = new System.Drawing.Point(391, 85);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(32, 20);
            this.btnSelectUser.TabIndex = 6;
            this.btnSelectUser.Text = "...";
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // tbxOpr3
            // 
            this.tbxOpr3.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr3.Border.Class = "TextBoxBorder";
            this.tbxOpr3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr3.FocusHighlightEnabled = true;
            this.tbxOpr3.Location = new System.Drawing.Point(106, 84);
            this.tbxOpr3.Name = "tbxOpr3";
            this.tbxOpr3.ReadOnly = true;
            this.tbxOpr3.SelectedValue = ((object)(resources.GetObject("tbxOpr3.SelectedValue")));
            this.tbxOpr3.Size = new System.Drawing.Size(277, 23);
            this.tbxOpr3.TabIndex = 5;
            // 
            // rbtOpr3
            // 
            this.rbtOpr3.AutoEllipsis = true;
            this.rbtOpr3.Location = new System.Drawing.Point(13, 85);
            this.rbtOpr3.Name = "rbtOpr3";
            this.rbtOpr3.Size = new System.Drawing.Size(95, 18);
            this.rbtOpr3.TabIndex = 4;
            this.rbtOpr3.TabStop = true;
            this.rbtOpr3.Text = "指定人员";
            this.rbtOpr3.UseVisualStyleBackColor = true;
            this.rbtOpr3.CheckedChanged += new System.EventHandler(this.rbtOpr3_CheckedChanged);
            // 
            // btnSelectOpr
            // 
            this.btnSelectOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectOpr.Enabled = false;
            this.btnSelectOpr.Location = new System.Drawing.Point(391, 52);
            this.btnSelectOpr.Name = "btnSelectOpr";
            this.btnSelectOpr.Size = new System.Drawing.Size(32, 20);
            this.btnSelectOpr.TabIndex = 3;
            this.btnSelectOpr.Text = "...";
            this.btnSelectOpr.Click += new System.EventHandler(this.btnSelectOpr_Click);
            // 
            // tbxOpr2
            // 
            this.tbxOpr2.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxOpr2.Border.Class = "TextBoxBorder";
            this.tbxOpr2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxOpr2.FocusHighlightEnabled = true;
            this.tbxOpr2.Location = new System.Drawing.Point(174, 52);
            this.tbxOpr2.Name = "tbxOpr2";
            this.tbxOpr2.ReadOnly = true;
            this.tbxOpr2.SelectedValue = ((object)(resources.GetObject("tbxOpr2.SelectedValue")));
            this.tbxOpr2.Size = new System.Drawing.Size(209, 23);
            this.tbxOpr2.TabIndex = 2;
            // 
            // rbtOpr2
            // 
            this.rbtOpr2.AutoEllipsis = true;
            this.rbtOpr2.Location = new System.Drawing.Point(13, 55);
            this.rbtOpr2.Name = "rbtOpr2";
            this.rbtOpr2.Size = new System.Drawing.Size(157, 18);
            this.rbtOpr2.TabIndex = 1;
            this.rbtOpr2.TabStop = true;
            this.rbtOpr2.Text = "某一任务实际执行者";
            this.rbtOpr2.UseVisualStyleBackColor = true;
            this.rbtOpr2.CheckedChanged += new System.EventHandler(this.rbtOpr2_CheckedChanged);
            // 
            // rbtOpr1
            // 
            this.rbtOpr1.AutoEllipsis = true;
            this.rbtOpr1.Location = new System.Drawing.Point(13, 29);
            this.rbtOpr1.Name = "rbtOpr1";
            this.rbtOpr1.Size = new System.Drawing.Size(257, 18);
            this.rbtOpr1.TabIndex = 0;
            this.rbtOpr1.TabStop = true;
            this.rbtOpr1.Text = "流程启动者";
            this.rbtOpr1.UseVisualStyleBackColor = true;
            this.rbtOpr1.CheckedChanged += new System.EventHandler(this.rbtOpr1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxRelation);
            this.groupBox2.Controls.Add(this.rbtRlt6);
            this.groupBox2.Controls.Add(this.rbtRlt5);
            this.groupBox2.Controls.Add(this.rbtRlt4);
            this.groupBox2.Controls.Add(this.rbtRlt3);
            this.groupBox2.Controls.Add(this.rbtRlt2);
            this.groupBox2.Controls.Add(this.rbtRlt1);
            this.groupBox2.Location = new System.Drawing.Point(14, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbxRelation
            // 
            this.cbxRelation.AutoSize = true;
            this.cbxRelation.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cbxRelation.Location = new System.Drawing.Point(1, 0);
            this.cbxRelation.Name = "cbxRelation";
            this.cbxRelation.Size = new System.Drawing.Size(166, 18);
            this.cbxRelation.TabIndex = 6;
            this.cbxRelation.Text = "与处理者的关系和筛选";
            this.cbxRelation.UseVisualStyleBackColor = true;
            this.cbxRelation.CheckedChanged += new System.EventHandler(this.cbxRelation_CheckedChanged);
            // 
            // rbtRlt6
            // 
            this.rbtRlt6.AutoEllipsis = true;
            this.rbtRlt6.Enabled = false;
            this.rbtRlt6.Location = new System.Drawing.Point(144, 47);
            this.rbtRlt6.Name = "rbtRlt6";
            this.rbtRlt6.Size = new System.Drawing.Size(175, 18);
            this.rbtRlt6.TabIndex = 5;
            this.rbtRlt6.TabStop = true;
            this.rbtRlt6.Text = "下级领导";
            this.rbtRlt6.UseVisualStyleBackColor = true;
            // 
            // rbtRlt5
            // 
            this.rbtRlt5.AutoEllipsis = true;
            this.rbtRlt5.Enabled = false;
            this.rbtRlt5.Location = new System.Drawing.Point(13, 47);
            this.rbtRlt5.Name = "rbtRlt5";
            this.rbtRlt5.Size = new System.Drawing.Size(127, 18);
            this.rbtRlt5.TabIndex = 4;
            this.rbtRlt5.TabStop = true;
            this.rbtRlt5.Text = "上级领导";
            this.rbtRlt5.UseVisualStyleBackColor = true;
            // 
            // rbtRlt4
            // 
            this.rbtRlt4.AutoEllipsis = true;
            this.rbtRlt4.Enabled = false;
            this.rbtRlt4.Location = new System.Drawing.Point(352, 23);
            this.rbtRlt4.Name = "rbtRlt4";
            this.rbtRlt4.Size = new System.Drawing.Size(98, 18);
            this.rbtRlt4.TabIndex = 3;
            this.rbtRlt4.TabStop = true;
            this.rbtRlt4.Text = "下级部门";
            this.rbtRlt4.UseVisualStyleBackColor = true;
            // 
            // rbtRlt3
            // 
            this.rbtRlt3.AutoEllipsis = true;
            this.rbtRlt3.Enabled = false;
            this.rbtRlt3.Location = new System.Drawing.Point(247, 24);
            this.rbtRlt3.Name = "rbtRlt3";
            this.rbtRlt3.Size = new System.Drawing.Size(99, 18);
            this.rbtRlt3.TabIndex = 2;
            this.rbtRlt3.TabStop = true;
            this.rbtRlt3.Text = "上级部门";
            this.rbtRlt3.UseVisualStyleBackColor = true;
            // 
            // rbtRlt2
            // 
            this.rbtRlt2.AutoEllipsis = true;
            this.rbtRlt2.Enabled = false;
            this.rbtRlt2.Location = new System.Drawing.Point(144, 24);
            this.rbtRlt2.Name = "rbtRlt2";
            this.rbtRlt2.Size = new System.Drawing.Size(97, 18);
            this.rbtRlt2.TabIndex = 1;
            this.rbtRlt2.TabStop = true;
            this.rbtRlt2.Text = "所在部门";
            this.rbtRlt2.UseVisualStyleBackColor = true;
            // 
            // rbtRlt1
            // 
            this.rbtRlt1.AutoEllipsis = true;
            this.rbtRlt1.Enabled = false;
            this.rbtRlt1.Location = new System.Drawing.Point(13, 24);
            this.rbtRlt1.Name = "rbtRlt1";
            this.rbtRlt1.Size = new System.Drawing.Size(127, 18);
            this.rbtRlt1.TabIndex = 0;
            this.rbtRlt1.TabStop = true;
            this.rbtRlt1.Text = "本部门领导";
            this.rbtRlt1.UseVisualStyleBackColor = true;
            // 
            // gbIncludeOrExclude
            // 
            this.gbIncludeOrExclude.Controls.Add(this.rbtExclude);
            this.gbIncludeOrExclude.Controls.Add(this.rbtInclude);
            this.gbIncludeOrExclude.Location = new System.Drawing.Point(14, 411);
            this.gbIncludeOrExclude.Name = "gbIncludeOrExclude";
            this.gbIncludeOrExclude.Size = new System.Drawing.Size(461, 65);
            this.gbIncludeOrExclude.TabIndex = 2;
            this.gbIncludeOrExclude.TabStop = false;
            this.gbIncludeOrExclude.Text = "包含或排除";
            // 
            // rbtExclude
            // 
            this.rbtExclude.AutoSize = true;
            this.rbtExclude.Location = new System.Drawing.Point(117, 28);
            this.rbtExclude.Name = "rbtExclude";
            this.rbtExclude.Size = new System.Drawing.Size(53, 18);
            this.rbtExclude.TabIndex = 1;
            this.rbtExclude.Text = "排除";
            this.rbtExclude.UseVisualStyleBackColor = true;
            this.rbtExclude.CheckedChanged += new System.EventHandler(this.rbtExclude_CheckedChanged);
            // 
            // rbtInclude
            // 
            this.rbtInclude.AutoSize = true;
            this.rbtInclude.Checked = true;
            this.rbtInclude.Location = new System.Drawing.Point(14, 28);
            this.rbtInclude.Name = "rbtInclude";
            this.rbtInclude.Size = new System.Drawing.Size(53, 18);
            this.rbtInclude.TabIndex = 0;
            this.rbtInclude.TabStop = true;
            this.rbtInclude.Text = "包含";
            this.rbtInclude.UseVisualStyleBackColor = true;
            this.rbtInclude.CheckedChanged += new System.EventHandler(this.rbtInclude_CheckedChanged);
            // 
            // FrmOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 522);
            this.Name = "FrmOperator";
            this.Text = "增加处理者";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.gbOperator.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbIncludeOrExclude.ResumeLayout(false);
            this.gbIncludeOrExclude.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOperator;
        private System.Windows.Forms.RadioButton rbtOpr1;
        private Controls.UcButton btnSelectOpr;
        private Controls.UcTextBox tbxOpr2;
        private System.Windows.Forms.RadioButton rbtOpr2;
        private Controls.UcButton btnSelectUser;
        private Controls.UcTextBox tbxOpr3;
        private System.Windows.Forms.RadioButton rbtOpr3;
        private Controls.UcTextBox tbxOpr6;
        private Controls.UcButton btnSelectRole;
        private Controls.UcTextBox tbxOpr4;
        private System.Windows.Forms.RadioButton rbtOpr4;
        private System.Windows.Forms.RadioButton rbtOpr5;
        private System.Windows.Forms.RadioButton rbtOpr9;
        private System.Windows.Forms.RadioButton rbtOpr8;
        private System.Windows.Forms.RadioButton rbtOpr7;
        private System.Windows.Forms.RadioButton rbtOpr6;
        private Controls.UcTextBox tbxOpr8;
        private Controls.UcTextBox tbxOpr7;
        private Controls.UcTextBox tbxOpr5;
        private Controls.UcButton btnSelectTask;
        private Controls.UcButton btnSelectVar;
        private Controls.UcButton btnSelectDuty;
        private Controls.UcButton btnSelectArch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtRlt1;
        private System.Windows.Forms.RadioButton rbtRlt3;
        private System.Windows.Forms.RadioButton rbtRlt2;
        private System.Windows.Forms.RadioButton rbtRlt4;
        private System.Windows.Forms.GroupBox gbIncludeOrExclude;
        private System.Windows.Forms.RadioButton rbtRlt6;
        private System.Windows.Forms.RadioButton rbtRlt5;
        private System.Windows.Forms.CheckBox cbxRelation;
        private System.Windows.Forms.RadioButton rbtExclude;
        private System.Windows.Forms.RadioButton rbtInclude;

    }
}