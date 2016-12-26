namespace RDIFramework.WorkFlow
{
    partial class FrmStartNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStartNode));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.lvExVar = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.btnDeleteVar = new RDIFramework.Controls.UcButton();
            this.btnModifyVar = new RDIFramework.Controls.UcButton();
            this.btnAddVar = new RDIFramework.Controls.UcButton();
            this.tabItemTaskVariable = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lvExOper = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.btnDeleteOpr = new RDIFramework.Controls.UcButton();
            this.btnModifyOpr = new RDIFramework.Controls.UcButton();
            this.btnAddOpr = new RDIFramework.Controls.UcButton();
            this.lblOperator = new System.Windows.Forms.Label();
            this.gbOperatorStrategy = new System.Windows.Forms.GroupBox();
            this.rbtEveryUser = new System.Windows.Forms.RadioButton();
            this.rbtShareUser = new System.Windows.Forms.RadioButton();
            this.tabItemOperator = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lvExCommand = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.tbxTaskDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblProcess = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeletecmd = new RDIFramework.Controls.UcButton();
            this.btnModifycmd = new RDIFramework.Controls.UcButton();
            this.btnAddcmd = new RDIFramework.Controls.UcButton();
            this.lblFormName = new System.Windows.Forms.Label();
            this.tbxFormName = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxTaskName = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSelectCtrls = new RDIFramework.Controls.UcButton();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.tabItemGeneral = new DevComponents.DotNetBar.TabItem(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.gbOperatorStrategy.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tcUser);
            this.plclassFill.Location = new System.Drawing.Point(3, 3);
            this.plclassFill.Size = new System.Drawing.Size(502, 509);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(3, 459);
            this.plclassBottom.Size = new System.Drawing.Size(502, 53);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(401, 15);
            this.btnClose.Size = new System.Drawing.Size(79, 23);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(306, 15);
            this.btnSave.Size = new System.Drawing.Size(83, 23);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Controls.Add(this.tabControlPanel3);
            this.tcUser.Controls.Add(this.tabControlPanel1);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(502, 509);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 23;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemGeneral);
            this.tcUser.Tabs.Add(this.tabItemOperator);
            this.tcUser.Tabs.Add(this.tabItemTaskVariable);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.lvExVar);
            this.tabControlPanel3.Controls.Add(this.btnDeleteVar);
            this.tabControlPanel3.Controls.Add(this.btnModifyVar);
            this.tabControlPanel3.Controls.Add(this.btnAddVar);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(502, 482);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItemTaskVariable;
            // 
            // lvExVar
            // 
            // 
            // 
            // 
            this.lvExVar.Border.Class = "ListViewBorder";
            this.lvExVar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvExVar.FullRowSelect = true;
            this.lvExVar.Location = new System.Drawing.Point(16, 14);
            this.lvExVar.Name = "lvExVar";
            this.lvExVar.Size = new System.Drawing.Size(468, 361);
            this.lvExVar.TabIndex = 143;
            this.lvExVar.UseCompatibleStateImageBehavior = false;
            this.lvExVar.View = System.Windows.Forms.View.Details;
            this.lvExVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteVar.Location = new System.Drawing.Point(187, 391);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(72, 26);
            this.btnDeleteVar.TabIndex = 7;
            this.btnDeleteVar.Text = "删除";
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifyVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifyVar.Location = new System.Drawing.Point(100, 390);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(73, 26);
            this.btnModifyVar.TabIndex = 6;
            this.btnModifyVar.Text = "修改...";
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddVar.Location = new System.Drawing.Point(14, 391);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(72, 26);
            this.btnAddVar.TabIndex = 5;
            this.btnAddVar.Text = "增加...";
            this.btnAddVar.Click += new System.EventHandler(this.btnAddVar_Click);
            // 
            // tabItemTaskVariable
            // 
            this.tabItemTaskVariable.AttachedControl = this.tabControlPanel3;
            this.tabItemTaskVariable.Name = "tabItemTaskVariable";
            this.tabItemTaskVariable.Text = "任务变量";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lvExOper);
            this.tabControlPanel1.Controls.Add(this.btnDeleteOpr);
            this.tabControlPanel1.Controls.Add(this.btnModifyOpr);
            this.tabControlPanel1.Controls.Add(this.btnAddOpr);
            this.tabControlPanel1.Controls.Add(this.lblOperator);
            this.tabControlPanel1.Controls.Add(this.gbOperatorStrategy);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(502, 482);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 2;
            this.tabControlPanel1.TabItem = this.tabItemOperator;
            // 
            // lvExOper
            // 
            // 
            // 
            // 
            this.lvExOper.Border.Class = "ListViewBorder";
            this.lvExOper.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvExOper.FullRowSelect = true;
            this.lvExOper.Location = new System.Drawing.Point(20, 124);
            this.lvExOper.Name = "lvExOper";
            this.lvExOper.Size = new System.Drawing.Size(459, 249);
            this.lvExOper.TabIndex = 142;
            this.lvExOper.UseCompatibleStateImageBehavior = false;
            this.lvExOper.View = System.Windows.Forms.View.Details;
            this.lvExOper.DoubleClick += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteOpr.Location = new System.Drawing.Point(203, 387);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(81, 26);
            this.btnDeleteOpr.TabIndex = 107;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifyOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifyOpr.Location = new System.Drawing.Point(111, 387);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(82, 26);
            this.btnModifyOpr.TabIndex = 106;
            this.btnModifyOpr.Text = "修改...";
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddOpr.Location = new System.Drawing.Point(20, 387);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(81, 26);
            this.btnAddOpr.TabIndex = 105;
            this.btnAddOpr.Text = "增加...";
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.BackColor = System.Drawing.Color.Transparent;
            this.lblOperator.Location = new System.Drawing.Point(16, 96);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(56, 14);
            this.lblOperator.TabIndex = 104;
            this.lblOperator.Text = "处理者:";
            // 
            // gbOperatorStrategy
            // 
            this.gbOperatorStrategy.BackColor = System.Drawing.Color.Transparent;
            this.gbOperatorStrategy.Controls.Add(this.rbtEveryUser);
            this.gbOperatorStrategy.Controls.Add(this.rbtShareUser);
            this.gbOperatorStrategy.Location = new System.Drawing.Point(18, 15);
            this.gbOperatorStrategy.Name = "gbOperatorStrategy";
            this.gbOperatorStrategy.Size = new System.Drawing.Size(441, 68);
            this.gbOperatorStrategy.TabIndex = 103;
            this.gbOperatorStrategy.TabStop = false;
            this.gbOperatorStrategy.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.Location = new System.Drawing.Point(198, 34);
            this.rbtEveryUser.Name = "rbtEveryUser";
            this.rbtEveryUser.Size = new System.Drawing.Size(225, 18);
            this.rbtEveryUser.TabIndex = 1;
            this.rbtEveryUser.Text = "所有用户处理(会签)";
            this.rbtEveryUser.UseVisualStyleBackColor = true;
            // 
            // rbtShareUser
            // 
            this.rbtShareUser.Checked = true;
            this.rbtShareUser.Location = new System.Drawing.Point(29, 34);
            this.rbtShareUser.Name = "rbtShareUser";
            this.rbtShareUser.Size = new System.Drawing.Size(163, 18);
            this.rbtShareUser.TabIndex = 0;
            this.rbtShareUser.TabStop = true;
            this.rbtShareUser.Text = "任意用户处理";
            this.rbtShareUser.UseVisualStyleBackColor = true;
            // 
            // tabItemOperator
            // 
            this.tabItemOperator.AttachedControl = this.tabControlPanel1;
            this.tabItemOperator.Name = "tabItemOperator";
            this.tabItemOperator.Text = "处理者";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lvExCommand);
            this.tabControlPanel2.Controls.Add(this.lblTaskDescription);
            this.tabControlPanel2.Controls.Add(this.tbxTaskDes);
            this.tabControlPanel2.Controls.Add(this.lblProcess);
            this.tabControlPanel2.Controls.Add(this.groupBox1);
            this.tabControlPanel2.Controls.Add(this.btnDeletecmd);
            this.tabControlPanel2.Controls.Add(this.btnModifycmd);
            this.tabControlPanel2.Controls.Add(this.btnAddcmd);
            this.tabControlPanel2.Controls.Add(this.lblFormName);
            this.tabControlPanel2.Controls.Add(this.tbxFormName);
            this.tabControlPanel2.Controls.Add(this.tbxTaskName);
            this.tabControlPanel2.Controls.Add(this.btnSelectCtrls);
            this.tabControlPanel2.Controls.Add(this.lblTaskName);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(502, 482);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemGeneral;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // lvExCommand
            // 
            // 
            // 
            // 
            this.lvExCommand.Border.Class = "ListViewBorder";
            this.lvExCommand.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvExCommand.FullRowSelect = true;
            this.lvExCommand.Location = new System.Drawing.Point(22, 170);
            this.lvExCommand.Name = "lvExCommand";
            this.lvExCommand.Size = new System.Drawing.Size(439, 204);
            this.lvExCommand.SmallImageList = this.imgListSmall;
            this.lvExCommand.TabIndex = 141;
            this.lvExCommand.UseCompatibleStateImageBehavior = false;
            this.lvExCommand.View = System.Windows.Forms.View.Details;
            this.lvExCommand.DoubleClick += new System.EventHandler(this.btnModifyCmd_Click);
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoEllipsis = true;
            this.lblTaskDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskDescription.Location = new System.Drawing.Point(2, 89);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(97, 14);
            this.lblTaskDescription.TabIndex = 139;
            this.lblTaskDescription.Text = "任务描述:";
            this.lblTaskDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxTaskDes
            // 
            // 
            // 
            // 
            this.tbxTaskDes.Border.Class = "TextBoxBorder";
            this.tbxTaskDes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTaskDes.FocusHighlightEnabled = true;
            this.tbxTaskDes.Location = new System.Drawing.Point(100, 87);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.SelectedValue = ((object)(resources.GetObject("tbxTaskDes.SelectedValue")));
            this.tbxTaskDes.Size = new System.Drawing.Size(357, 23);
            this.tbxTaskDes.TabIndex = 138;
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Location = new System.Drawing.Point(18, 141);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(42, 14);
            this.lblProcess.TabIndex = 137;
            this.lblProcess.Text = "处理:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(15, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 2);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeletecmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeletecmd.Location = new System.Drawing.Point(188, 390);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(76, 26);
            this.btnDeletecmd.TabIndex = 135;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeleteCmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifycmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifycmd.Location = new System.Drawing.Point(98, 390);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(77, 26);
            this.btnModifycmd.TabIndex = 134;
            this.btnModifycmd.Text = "修改...";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifyCmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddcmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddcmd.Location = new System.Drawing.Point(12, 390);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(76, 26);
            this.btnAddcmd.TabIndex = 131;
            this.btnAddcmd.Text = "增加...";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddCmd_Click);
            // 
            // lblFormName
            // 
            this.lblFormName.AutoEllipsis = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Location = new System.Drawing.Point(2, 57);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(97, 14);
            this.lblFormName.TabIndex = 133;
            this.lblFormName.Text = "表单名:";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFormName
            // 
            // 
            // 
            // 
            this.tbxFormName.Border.Class = "TextBoxBorder";
            this.tbxFormName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxFormName.FocusHighlightEnabled = true;
            this.tbxFormName.Location = new System.Drawing.Point(100, 54);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.SelectedValue = ((object)(resources.GetObject("tbxFormName.SelectedValue")));
            this.tbxFormName.Size = new System.Drawing.Size(293, 23);
            this.tbxFormName.TabIndex = 132;
            // 
            // tbxTaskName
            // 
            // 
            // 
            // 
            this.tbxTaskName.Border.Class = "TextBoxBorder";
            this.tbxTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTaskName.FocusHighlightEnabled = true;
            this.tbxTaskName.Location = new System.Drawing.Point(100, 22);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.SelectedValue = ((object)(resources.GetObject("tbxTaskName.SelectedValue")));
            this.tbxTaskName.Size = new System.Drawing.Size(357, 23);
            this.tbxTaskName.TabIndex = 129;
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectCtrls.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectCtrls.Location = new System.Drawing.Point(409, 54);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(48, 27);
            this.btnSelectCtrls.TabIndex = 130;
            this.btnSelectCtrls.Text = "...";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoEllipsis = true;
            this.lblTaskName.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskName.Location = new System.Drawing.Point(2, 25);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(97, 14);
            this.lblTaskName.TabIndex = 128;
            this.lblTaskName.Text = "任务名称:";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabItemGeneral
            // 
            this.tabItemGeneral.AttachedControl = this.tabControlPanel2;
            this.tabItemGeneral.Name = "tabItemGeneral";
            this.tabItemGeneral.Text = "常规";
            // 
            // FrmStartNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 515);
            this.Name = "FrmStartNode";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "启动节点";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.gbOperatorStrategy.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private Controls.UcButton btnDeleteVar;
        private Controls.UcButton btnModifyVar;
        private Controls.UcButton btnAddVar;
        private DevComponents.DotNetBar.TabItem tabItemTaskVariable;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private Controls.UcButton btnDeleteOpr;
        private Controls.UcButton btnModifyOpr;
        private Controls.UcButton btnAddOpr;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.GroupBox gbOperatorStrategy;
        private System.Windows.Forms.RadioButton rbtEveryUser;
        private System.Windows.Forms.RadioButton rbtShareUser;
        private DevComponents.DotNetBar.TabItem tabItemOperator;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExCommand;
        private System.Windows.Forms.Label lblTaskDescription;
        private Controls.UcTextBox tbxTaskDes;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.UcButton btnDeletecmd;
        private Controls.UcButton btnModifycmd;
        private Controls.UcButton btnAddcmd;
        private System.Windows.Forms.Label lblFormName;
        private Controls.UcTextBox tbxFormName;
        private Controls.UcTextBox tbxTaskName;
        private Controls.UcButton btnSelectCtrls;
        private System.Windows.Forms.Label lblTaskName;
        private DevComponents.DotNetBar.TabItem tabItemGeneral;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExOper;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExVar;
    }
}