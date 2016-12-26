namespace RDIFramework.WorkFlow
{
    partial class FrmAlterNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlterNode));
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbTimeOutProcess = new System.Windows.Forms.GroupBox();
            this.rbOver = new System.Windows.Forms.RadioButton();
            this.rbRemain = new System.Windows.Forms.RadioButton();
            this.gbTimeOutSet = new System.Windows.Forms.GroupBox();
            this.lblExtraurgent = new System.Windows.Forms.Label();
            this.lblEmergency = new System.Windows.Forms.Label();
            this.lblOrdinary = new System.Windows.Forms.Label();
            this.tbxMinute3 = new System.Windows.Forms.NumericUpDown();
            this.tbxHour3 = new System.Windows.Forms.NumericUpDown();
            this.tbxDay3 = new System.Windows.Forms.NumericUpDown();
            this.tbxMinute2 = new System.Windows.Forms.NumericUpDown();
            this.tbxHour2 = new System.Windows.Forms.NumericUpDown();
            this.tbxDay2 = new System.Windows.Forms.NumericUpDown();
            this.tbxMinute1 = new System.Windows.Forms.NumericUpDown();
            this.tbxHour1 = new System.Windows.Forms.NumericUpDown();
            this.tbxDay1 = new System.Windows.Forms.NumericUpDown();
            this.lblNotice = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEnableTimeOut = new System.Windows.Forms.CheckBox();
            this.tabItemTimeOut = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.cbxReturnry = new System.Windows.Forms.CheckBox();
            this.cbxDyAssignNext = new System.Windows.Forms.CheckBox();
            this.cbxAssign = new System.Windows.Forms.CheckBox();
            this.cbxReturn = new System.Windows.Forms.CheckBox();
            this.tabItemControlPermission = new DevComponents.DotNetBar.TabItem(this.components);
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
            this.cbxJumpSelf = new System.Windows.Forms.CheckBox();
            this.chkJumpNoOperator = new System.Windows.Forms.CheckBox();
            this.tabItemOperator = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lvExCommand = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.tbxTaskDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeletecmd = new RDIFramework.Controls.UcButton();
            this.btnModifycmd = new RDIFramework.Controls.UcButton();
            this.btnAddcmd = new RDIFramework.Controls.UcButton();
            this.lblFormName = new System.Windows.Forms.Label();
            this.tbxFormName = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxTaskName = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSelectCtrls = new RDIFramework.Controls.UcButton();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.tabItemGeneral = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbArriveNotice = new System.Windows.Forms.GroupBox();
            this.lbxRmMsgToUsers = new System.Windows.Forms.ListBox();
            this.btnRmDelete = new RDIFramework.Controls.UcButton();
            this.btnRmAdd = new RDIFramework.Controls.UcButton();
            this.lblArriveNoticeUsers = new System.Windows.Forms.Label();
            this.cbxRmMail = new System.Windows.Forms.CheckBox();
            this.cbxRmMessage = new System.Windows.Forms.CheckBox();
            this.cbxRmSms = new System.Windows.Forms.CheckBox();
            this.gbTimeoutNotice = new System.Windows.Forms.GroupBox();
            this.lbxOtMsgToUsers = new System.Windows.Forms.ListBox();
            this.btnOtDelete = new RDIFramework.Controls.UcButton();
            this.btnOtAdd = new RDIFramework.Controls.UcButton();
            this.lblNoticeUsers = new System.Windows.Forms.Label();
            this.cbxOtMail = new System.Windows.Forms.CheckBox();
            this.cbxOtMessage = new System.Windows.Forms.CheckBox();
            this.cbxOtSms = new System.Windows.Forms.CheckBox();
            this.tabItemTaskNotice = new DevComponents.DotNetBar.TabItem(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            this.gbTimeOutProcess.SuspendLayout();
            this.gbTimeOutSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay1)).BeginInit();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.gbOperatorStrategy.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel6.SuspendLayout();
            this.gbArriveNotice.SuspendLayout();
            this.gbTimeoutNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tcUser);
            this.plclassFill.Location = new System.Drawing.Point(3, 3);
            this.plclassFill.Size = new System.Drawing.Size(478, 520);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(3, 472);
            this.plclassBottom.Size = new System.Drawing.Size(478, 51);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(366, 14);
            this.btnClose.Size = new System.Drawing.Size(89, 27);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 14);
            this.btnSave.Size = new System.Drawing.Size(89, 27);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel5);
            this.tcUser.Controls.Add(this.tabControlPanel6);
            this.tcUser.Controls.Add(this.tabControlPanel4);
            this.tcUser.Controls.Add(this.tabControlPanel3);
            this.tcUser.Controls.Add(this.tabControlPanel1);
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(478, 520);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 22;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemGeneral);
            this.tcUser.Tabs.Add(this.tabItemOperator);
            this.tcUser.Tabs.Add(this.tabItemTaskVariable);
            this.tcUser.Tabs.Add(this.tabItemControlPermission);
            this.tcUser.Tabs.Add(this.tabItemTimeOut);
            this.tcUser.Tabs.Add(this.tabItemTaskNotice);
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.gbTimeOutProcess);
            this.tabControlPanel5.Controls.Add(this.gbTimeOutSet);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(478, 493);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 5;
            this.tabControlPanel5.TabItem = this.tabItemTimeOut;
            // 
            // gbTimeOutProcess
            // 
            this.gbTimeOutProcess.BackColor = System.Drawing.Color.Transparent;
            this.gbTimeOutProcess.Controls.Add(this.rbOver);
            this.gbTimeOutProcess.Controls.Add(this.rbRemain);
            this.gbTimeOutProcess.Location = new System.Drawing.Point(4, 212);
            this.gbTimeOutProcess.Name = "gbTimeOutProcess";
            this.gbTimeOutProcess.Size = new System.Drawing.Size(440, 56);
            this.gbTimeOutProcess.TabIndex = 63;
            this.gbTimeOutProcess.TabStop = false;
            this.gbTimeOutProcess.Text = "超时处理";
            // 
            // rbOver
            // 
            this.rbOver.Enabled = false;
            this.rbOver.Location = new System.Drawing.Point(219, 26);
            this.rbOver.Name = "rbOver";
            this.rbOver.Size = new System.Drawing.Size(131, 27);
            this.rbOver.TabIndex = 2;
            this.rbOver.Text = "跳过本节点处理";
            // 
            // rbRemain
            // 
            this.rbRemain.Enabled = false;
            this.rbRemain.Location = new System.Drawing.Point(14, 23);
            this.rbRemain.Name = "rbRemain";
            this.rbRemain.Size = new System.Drawing.Size(131, 26);
            this.rbRemain.TabIndex = 1;
            this.rbRemain.Text = "保留本节点处理";
            // 
            // gbTimeOutSet
            // 
            this.gbTimeOutSet.BackColor = System.Drawing.Color.Transparent;
            this.gbTimeOutSet.Controls.Add(this.lblExtraurgent);
            this.gbTimeOutSet.Controls.Add(this.lblEmergency);
            this.gbTimeOutSet.Controls.Add(this.lblOrdinary);
            this.gbTimeOutSet.Controls.Add(this.tbxMinute3);
            this.gbTimeOutSet.Controls.Add(this.tbxHour3);
            this.gbTimeOutSet.Controls.Add(this.tbxDay3);
            this.gbTimeOutSet.Controls.Add(this.tbxMinute2);
            this.gbTimeOutSet.Controls.Add(this.tbxHour2);
            this.gbTimeOutSet.Controls.Add(this.tbxDay2);
            this.gbTimeOutSet.Controls.Add(this.tbxMinute1);
            this.gbTimeOutSet.Controls.Add(this.tbxHour1);
            this.gbTimeOutSet.Controls.Add(this.tbxDay1);
            this.gbTimeOutSet.Controls.Add(this.lblNotice);
            this.gbTimeOutSet.Controls.Add(this.label15);
            this.gbTimeOutSet.Controls.Add(this.label16);
            this.gbTimeOutSet.Controls.Add(this.label17);
            this.gbTimeOutSet.Controls.Add(this.label11);
            this.gbTimeOutSet.Controls.Add(this.label12);
            this.gbTimeOutSet.Controls.Add(this.label13);
            this.gbTimeOutSet.Controls.Add(this.label8);
            this.gbTimeOutSet.Controls.Add(this.label7);
            this.gbTimeOutSet.Controls.Add(this.label6);
            this.gbTimeOutSet.Controls.Add(this.chkEnableTimeOut);
            this.gbTimeOutSet.Location = new System.Drawing.Point(4, 19);
            this.gbTimeOutSet.Name = "gbTimeOutSet";
            this.gbTimeOutSet.Size = new System.Drawing.Size(440, 167);
            this.gbTimeOutSet.TabIndex = 62;
            this.gbTimeOutSet.TabStop = false;
            this.gbTimeOutSet.Text = "超时设置";
            // 
            // lblExtraurgent
            // 
            this.lblExtraurgent.AutoSize = true;
            this.lblExtraurgent.Location = new System.Drawing.Point(90, 96);
            this.lblExtraurgent.Name = "lblExtraurgent";
            this.lblExtraurgent.Size = new System.Drawing.Size(35, 14);
            this.lblExtraurgent.TabIndex = 43;
            this.lblExtraurgent.Text = "特急";
            // 
            // lblEmergency
            // 
            this.lblEmergency.AutoSize = true;
            this.lblEmergency.Location = new System.Drawing.Point(90, 65);
            this.lblEmergency.Name = "lblEmergency";
            this.lblEmergency.Size = new System.Drawing.Size(35, 14);
            this.lblEmergency.TabIndex = 42;
            this.lblEmergency.Text = "紧急";
            // 
            // lblOrdinary
            // 
            this.lblOrdinary.AutoSize = true;
            this.lblOrdinary.Location = new System.Drawing.Point(90, 34);
            this.lblOrdinary.Name = "lblOrdinary";
            this.lblOrdinary.Size = new System.Drawing.Size(35, 14);
            this.lblOrdinary.TabIndex = 41;
            this.lblOrdinary.Text = "普通";
            // 
            // tbxMinute3
            // 
            this.tbxMinute3.Location = new System.Drawing.Point(310, 96);
            this.tbxMinute3.Name = "tbxMinute3";
            this.tbxMinute3.Size = new System.Drawing.Size(59, 23);
            this.tbxMinute3.TabIndex = 40;
            // 
            // tbxHour3
            // 
            this.tbxHour3.Location = new System.Drawing.Point(226, 96);
            this.tbxHour3.Name = "tbxHour3";
            this.tbxHour3.Size = new System.Drawing.Size(59, 23);
            this.tbxHour3.TabIndex = 39;
            // 
            // tbxDay3
            // 
            this.tbxDay3.Location = new System.Drawing.Point(135, 96);
            this.tbxDay3.Name = "tbxDay3";
            this.tbxDay3.Size = new System.Drawing.Size(59, 23);
            this.tbxDay3.TabIndex = 38;
            // 
            // tbxMinute2
            // 
            this.tbxMinute2.Location = new System.Drawing.Point(310, 64);
            this.tbxMinute2.Name = "tbxMinute2";
            this.tbxMinute2.Size = new System.Drawing.Size(59, 23);
            this.tbxMinute2.TabIndex = 37;
            // 
            // tbxHour2
            // 
            this.tbxHour2.Location = new System.Drawing.Point(226, 64);
            this.tbxHour2.Name = "tbxHour2";
            this.tbxHour2.Size = new System.Drawing.Size(59, 23);
            this.tbxHour2.TabIndex = 36;
            // 
            // tbxDay2
            // 
            this.tbxDay2.Location = new System.Drawing.Point(135, 64);
            this.tbxDay2.Name = "tbxDay2";
            this.tbxDay2.Size = new System.Drawing.Size(59, 23);
            this.tbxDay2.TabIndex = 35;
            // 
            // tbxMinute1
            // 
            this.tbxMinute1.Location = new System.Drawing.Point(310, 29);
            this.tbxMinute1.Name = "tbxMinute1";
            this.tbxMinute1.Size = new System.Drawing.Size(59, 23);
            this.tbxMinute1.TabIndex = 34;
            // 
            // tbxHour1
            // 
            this.tbxHour1.Location = new System.Drawing.Point(226, 29);
            this.tbxHour1.Name = "tbxHour1";
            this.tbxHour1.Size = new System.Drawing.Size(59, 23);
            this.tbxHour1.TabIndex = 33;
            // 
            // tbxDay1
            // 
            this.tbxDay1.Location = new System.Drawing.Point(135, 29);
            this.tbxDay1.Name = "tbxDay1";
            this.tbxDay1.Size = new System.Drawing.Size(59, 23);
            this.tbxDay1.TabIndex = 32;
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(11, 138);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(224, 14);
            this.lblNotice.TabIndex = 31;
            this.lblNotice.Text = "说明:设置完成任务所需要的时间。";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(373, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "分";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(289, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 14);
            this.label16.TabIndex = 26;
            this.label16.Text = "时";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(203, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 14);
            this.label17.TabIndex = 24;
            this.label17.Text = "天";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(373, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 19;
            this.label11.Text = "分";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(289, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 14);
            this.label12.TabIndex = 17;
            this.label12.Text = "时";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(203, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 14);
            this.label13.TabIndex = 15;
            this.label13.Text = "天";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "时";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "天";
            // 
            // chkEnableTimeOut
            // 
            this.chkEnableTimeOut.AutoEllipsis = true;
            this.chkEnableTimeOut.AutoSize = true;
            this.chkEnableTimeOut.Location = new System.Drawing.Point(7, 43);
            this.chkEnableTimeOut.Name = "chkEnableTimeOut";
            this.chkEnableTimeOut.Size = new System.Drawing.Size(82, 18);
            this.chkEnableTimeOut.TabIndex = 0;
            this.chkEnableTimeOut.Text = "启用超时";
            this.chkEnableTimeOut.UseVisualStyleBackColor = true;
            // 
            // tabItemTimeOut
            // 
            this.tabItemTimeOut.AttachedControl = this.tabControlPanel5;
            this.tabItemTimeOut.Name = "tabItemTimeOut";
            this.tabItemTimeOut.Text = "超时设置";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.cbxReturnry);
            this.tabControlPanel4.Controls.Add(this.cbxDyAssignNext);
            this.tabControlPanel4.Controls.Add(this.cbxAssign);
            this.tabControlPanel4.Controls.Add(this.cbxReturn);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(478, 493);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tabItemControlPermission;
            // 
            // cbxReturnry
            // 
            this.cbxReturnry.AutoSize = true;
            this.cbxReturnry.BackColor = System.Drawing.Color.Transparent;
            this.cbxReturnry.Location = new System.Drawing.Point(24, 92);
            this.cbxReturnry.Name = "cbxReturnry";
            this.cbxReturnry.Size = new System.Drawing.Size(110, 18);
            this.cbxReturnry.TabIndex = 7;
            this.cbxReturnry.Text = "允许任意退回";
            this.cbxReturnry.UseVisualStyleBackColor = false;
            // 
            // cbxDyAssignNext
            // 
            this.cbxDyAssignNext.AutoSize = true;
            this.cbxDyAssignNext.BackColor = System.Drawing.Color.Transparent;
            this.cbxDyAssignNext.Location = new System.Drawing.Point(24, 67);
            this.cbxDyAssignNext.Name = "cbxDyAssignNext";
            this.cbxDyAssignNext.Size = new System.Drawing.Size(208, 18);
            this.cbxDyAssignNext.TabIndex = 6;
            this.cbxDyAssignNext.Text = "允许动态指定下一任务处理人";
            this.cbxDyAssignNext.UseVisualStyleBackColor = false;
            // 
            // cbxAssign
            // 
            this.cbxAssign.AutoSize = true;
            this.cbxAssign.BackColor = System.Drawing.Color.Transparent;
            this.cbxAssign.Location = new System.Drawing.Point(24, 41);
            this.cbxAssign.Name = "cbxAssign";
            this.cbxAssign.Size = new System.Drawing.Size(138, 18);
            this.cbxAssign.TabIndex = 5;
            this.cbxAssign.Text = "允许指派他人处理";
            this.cbxAssign.UseVisualStyleBackColor = false;
            // 
            // cbxReturn
            // 
            this.cbxReturn.AutoSize = true;
            this.cbxReturn.BackColor = System.Drawing.Color.Transparent;
            this.cbxReturn.Location = new System.Drawing.Point(24, 14);
            this.cbxReturn.Name = "cbxReturn";
            this.cbxReturn.Size = new System.Drawing.Size(82, 18);
            this.cbxReturn.TabIndex = 4;
            this.cbxReturn.Text = "允许退回";
            this.cbxReturn.UseVisualStyleBackColor = false;
            // 
            // tabItemControlPermission
            // 
            this.tabItemControlPermission.AttachedControl = this.tabControlPanel4;
            this.tabItemControlPermission.Name = "tabItemControlPermission";
            this.tabItemControlPermission.Text = "控制权限";
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
            this.tabControlPanel3.Size = new System.Drawing.Size(478, 493);
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
            this.lvExVar.Location = new System.Drawing.Point(15, 14);
            this.lvExVar.Name = "lvExVar";
            this.lvExVar.Size = new System.Drawing.Size(447, 361);
            this.lvExVar.TabIndex = 144;
            this.lvExVar.UseCompatibleStateImageBehavior = false;
            this.lvExVar.View = System.Windows.Forms.View.Details;
            this.lvExVar.DoubleClick += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnDeleteVar
            // 
            this.btnDeleteVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteVar.Location = new System.Drawing.Point(191, 394);
            this.btnDeleteVar.Name = "btnDeleteVar";
            this.btnDeleteVar.Size = new System.Drawing.Size(77, 26);
            this.btnDeleteVar.TabIndex = 10;
            this.btnDeleteVar.Text = "删除";
            this.btnDeleteVar.Click += new System.EventHandler(this.btnDeleteVar_Click);
            // 
            // btnModifyVar
            // 
            this.btnModifyVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifyVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifyVar.Location = new System.Drawing.Point(105, 393);
            this.btnModifyVar.Name = "btnModifyVar";
            this.btnModifyVar.Size = new System.Drawing.Size(77, 26);
            this.btnModifyVar.TabIndex = 9;
            this.btnModifyVar.Text = "修改...";
            this.btnModifyVar.Click += new System.EventHandler(this.btnModifyVar_Click);
            // 
            // btnAddVar
            // 
            this.btnAddVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddVar.Location = new System.Drawing.Point(15, 394);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(77, 26);
            this.btnAddVar.TabIndex = 8;
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
            this.tabControlPanel1.Controls.Add(this.cbxJumpSelf);
            this.tabControlPanel1.Controls.Add(this.chkJumpNoOperator);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(478, 493);
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
            this.lvExOper.Location = new System.Drawing.Point(21, 115);
            this.lvExOper.Name = "lvExOper";
            this.lvExOper.Size = new System.Drawing.Size(433, 217);
            this.lvExOper.TabIndex = 143;
            this.lvExOper.UseCompatibleStateImageBehavior = false;
            this.lvExOper.View = System.Windows.Forms.View.Details;
            this.lvExOper.DoubleClick += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteOpr.Location = new System.Drawing.Point(204, 344);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(83, 26);
            this.btnDeleteOpr.TabIndex = 128;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifyOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifyOpr.Location = new System.Drawing.Point(113, 344);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(83, 26);
            this.btnModifyOpr.TabIndex = 127;
            this.btnModifyOpr.Text = "修改...";
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddOpr.Location = new System.Drawing.Point(18, 344);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(83, 26);
            this.btnAddOpr.TabIndex = 126;
            this.btnAddOpr.Text = "增加...";
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.BackColor = System.Drawing.Color.Transparent;
            this.lblOperator.Location = new System.Drawing.Point(16, 94);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(56, 14);
            this.lblOperator.TabIndex = 124;
            this.lblOperator.Text = "处理者:";
            // 
            // gbOperatorStrategy
            // 
            this.gbOperatorStrategy.BackColor = System.Drawing.Color.Transparent;
            this.gbOperatorStrategy.Controls.Add(this.rbtEveryUser);
            this.gbOperatorStrategy.Controls.Add(this.rbtShareUser);
            this.gbOperatorStrategy.Location = new System.Drawing.Point(16, 12);
            this.gbOperatorStrategy.Name = "gbOperatorStrategy";
            this.gbOperatorStrategy.Size = new System.Drawing.Size(435, 69);
            this.gbOperatorStrategy.TabIndex = 123;
            this.gbOperatorStrategy.TabStop = false;
            this.gbOperatorStrategy.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoSize = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(170, 34);
            this.rbtEveryUser.Name = "rbtEveryUser";
            this.rbtEveryUser.Size = new System.Drawing.Size(151, 18);
            this.rbtEveryUser.TabIndex = 1;
            this.rbtEveryUser.Text = "所有用户处理(会签)";
            this.rbtEveryUser.UseVisualStyleBackColor = true;
            // 
            // rbtShareUser
            // 
            this.rbtShareUser.AutoSize = true;
            this.rbtShareUser.Checked = true;
            this.rbtShareUser.Location = new System.Drawing.Point(29, 34);
            this.rbtShareUser.Name = "rbtShareUser";
            this.rbtShareUser.Size = new System.Drawing.Size(109, 18);
            this.rbtShareUser.TabIndex = 0;
            this.rbtShareUser.TabStop = true;
            this.rbtShareUser.Text = "任意用户处理";
            this.rbtShareUser.UseVisualStyleBackColor = true;
            // 
            // cbxJumpSelf
            // 
            this.cbxJumpSelf.AutoSize = true;
            this.cbxJumpSelf.BackColor = System.Drawing.Color.Transparent;
            this.cbxJumpSelf.Location = new System.Drawing.Point(18, 380);
            this.cbxJumpSelf.Name = "cbxJumpSelf";
            this.cbxJumpSelf.Size = new System.Drawing.Size(208, 18);
            this.cbxJumpSelf.TabIndex = 122;
            this.cbxJumpSelf.Text = "处理者是提交人则跳过本处理";
            this.cbxJumpSelf.UseVisualStyleBackColor = false;
            // 
            // chkJumpNoOperator
            // 
            this.chkJumpNoOperator.AutoSize = true;
            this.chkJumpNoOperator.BackColor = System.Drawing.Color.Transparent;
            this.chkJumpNoOperator.Location = new System.Drawing.Point(18, 405);
            this.chkJumpNoOperator.Name = "chkJumpNoOperator";
            this.chkJumpNoOperator.Size = new System.Drawing.Size(194, 18);
            this.chkJumpNoOperator.TabIndex = 121;
            this.chkJumpNoOperator.Text = "无对应处理人则跳过本处理";
            this.chkJumpNoOperator.UseVisualStyleBackColor = false;
            this.chkJumpNoOperator.Visible = false;
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
            this.tabControlPanel2.Controls.Add(this.lblProcess);
            this.tabControlPanel2.Controls.Add(this.lblTaskDescription);
            this.tabControlPanel2.Controls.Add(this.tbxTaskDes);
            this.tabControlPanel2.Controls.Add(this.groupBox2);
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
            this.tabControlPanel2.Size = new System.Drawing.Size(478, 493);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemGeneral;
            // 
            // lvExCommand
            // 
            // 
            // 
            // 
            this.lvExCommand.Border.Class = "ListViewBorder";
            this.lvExCommand.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvExCommand.FullRowSelect = true;
            this.lvExCommand.Location = new System.Drawing.Point(16, 151);
            this.lvExCommand.Name = "lvExCommand";
            this.lvExCommand.Size = new System.Drawing.Size(439, 239);
            this.lvExCommand.TabIndex = 142;
            this.lvExCommand.UseCompatibleStateImageBehavior = false;
            this.lvExCommand.View = System.Windows.Forms.View.Details;
            this.lvExCommand.DoubleClick += new System.EventHandler(this.btnModifyCmd_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Location = new System.Drawing.Point(17, 130);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(42, 14);
            this.lblProcess.TabIndex = 141;
            this.lblProcess.Text = "处理:";
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskDescription.Location = new System.Drawing.Point(3, 75);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(96, 26);
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
            this.tbxTaskDes.Location = new System.Drawing.Point(100, 77);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.SelectedValue = ((object)(resources.GetObject("tbxTaskDes.SelectedValue")));
            this.tbxTaskDes.Size = new System.Drawing.Size(352, 23);
            this.tbxTaskDes.TabIndex = 138;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(15, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 2);
            this.groupBox2.TabIndex = 137;
            this.groupBox2.TabStop = false;
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeletecmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeletecmd.Location = new System.Drawing.Point(185, 400);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(74, 26);
            this.btnDeletecmd.TabIndex = 136;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeleteCmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifycmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifycmd.Location = new System.Drawing.Point(100, 400);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(74, 26);
            this.btnModifycmd.TabIndex = 135;
            this.btnModifycmd.Text = "修改...";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifyCmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddcmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddcmd.Location = new System.Drawing.Point(13, 400);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(74, 26);
            this.btnAddcmd.TabIndex = 132;
            this.btnAddcmd.Text = "增加...";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddCmd_Click);
            // 
            // lblFormName
            // 
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Location = new System.Drawing.Point(3, 44);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(96, 26);
            this.lblFormName.TabIndex = 134;
            this.lblFormName.Text = "表单名:";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxFormName
            // 
            this.tbxFormName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.tbxFormName.Border.Class = "TextBoxBorder";
            this.tbxFormName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxFormName.FocusHighlightEnabled = true;
            this.tbxFormName.Location = new System.Drawing.Point(100, 44);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.SelectedValue = ((object)(resources.GetObject("tbxFormName.SelectedValue")));
            this.tbxFormName.Size = new System.Drawing.Size(297, 23);
            this.tbxFormName.TabIndex = 133;
            // 
            // tbxTaskName
            // 
            // 
            // 
            // 
            this.tbxTaskName.Border.Class = "TextBoxBorder";
            this.tbxTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTaskName.FocusHighlightEnabled = true;
            this.tbxTaskName.Location = new System.Drawing.Point(100, 12);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.SelectedValue = ((object)(resources.GetObject("tbxTaskName.SelectedValue")));
            this.tbxTaskName.Size = new System.Drawing.Size(352, 23);
            this.tbxTaskName.TabIndex = 130;
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectCtrls.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectCtrls.Location = new System.Drawing.Point(409, 44);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(43, 27);
            this.btnSelectCtrls.TabIndex = 131;
            this.btnSelectCtrls.Text = "...";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // lblTaskName
            // 
            this.lblTaskName.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskName.Location = new System.Drawing.Point(3, 12);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(96, 26);
            this.lblTaskName.TabIndex = 129;
            this.lblTaskName.Text = "任务名称:";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabItemGeneral
            // 
            this.tabItemGeneral.AttachedControl = this.tabControlPanel2;
            this.tabItemGeneral.Name = "tabItemGeneral";
            this.tabItemGeneral.Text = "常规";
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.Controls.Add(this.gbArriveNotice);
            this.tabControlPanel6.Controls.Add(this.gbTimeoutNotice);
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel6.Size = new System.Drawing.Size(478, 493);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 6;
            this.tabControlPanel6.TabItem = this.tabItemTaskNotice;
            // 
            // gbArriveNotice
            // 
            this.gbArriveNotice.BackColor = System.Drawing.Color.Transparent;
            this.gbArriveNotice.Controls.Add(this.lbxRmMsgToUsers);
            this.gbArriveNotice.Controls.Add(this.btnRmDelete);
            this.gbArriveNotice.Controls.Add(this.btnRmAdd);
            this.gbArriveNotice.Controls.Add(this.lblArriveNoticeUsers);
            this.gbArriveNotice.Controls.Add(this.cbxRmMail);
            this.gbArriveNotice.Controls.Add(this.cbxRmMessage);
            this.gbArriveNotice.Controls.Add(this.cbxRmSms);
            this.gbArriveNotice.Location = new System.Drawing.Point(14, 215);
            this.gbArriveNotice.Name = "gbArriveNotice";
            this.gbArriveNotice.Size = new System.Drawing.Size(439, 189);
            this.gbArriveNotice.TabIndex = 64;
            this.gbArriveNotice.TabStop = false;
            this.gbArriveNotice.Text = "到达通知";
            // 
            // lbxRmMsgToUsers
            // 
            this.lbxRmMsgToUsers.FormattingEnabled = true;
            this.lbxRmMsgToUsers.ItemHeight = 14;
            this.lbxRmMsgToUsers.Location = new System.Drawing.Point(14, 72);
            this.lbxRmMsgToUsers.Name = "lbxRmMsgToUsers";
            this.lbxRmMsgToUsers.ScrollAlwaysVisible = true;
            this.lbxRmMsgToUsers.Size = new System.Drawing.Size(334, 88);
            this.lbxRmMsgToUsers.TabIndex = 12;
            // 
            // btnRmDelete
            // 
            this.btnRmDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRmDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRmDelete.Location = new System.Drawing.Point(363, 129);
            this.btnRmDelete.Name = "btnRmDelete";
            this.btnRmDelete.Size = new System.Drawing.Size(66, 26);
            this.btnRmDelete.TabIndex = 11;
            this.btnRmDelete.Text = "删除";
            this.btnRmDelete.Click += new System.EventHandler(this.btnRmDelete_Click);
            // 
            // btnRmAdd
            // 
            this.btnRmAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRmAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRmAdd.Location = new System.Drawing.Point(363, 82);
            this.btnRmAdd.Name = "btnRmAdd";
            this.btnRmAdd.Size = new System.Drawing.Size(66, 27);
            this.btnRmAdd.TabIndex = 10;
            this.btnRmAdd.Text = "增加";
            this.btnRmAdd.Click += new System.EventHandler(this.btnRmAdd_Click);
            // 
            // lblArriveNoticeUsers
            // 
            this.lblArriveNoticeUsers.AutoSize = true;
            this.lblArriveNoticeUsers.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblArriveNoticeUsers.Location = new System.Drawing.Point(12, 55);
            this.lblArriveNoticeUsers.Name = "lblArriveNoticeUsers";
            this.lblArriveNoticeUsers.Size = new System.Drawing.Size(126, 14);
            this.lblArriveNoticeUsers.TabIndex = 8;
            this.lblArriveNoticeUsers.Text = "同时通知下列人员:";
            // 
            // cbxRmMail
            // 
            this.cbxRmMail.BackColor = System.Drawing.Color.Transparent;
            this.cbxRmMail.Location = new System.Drawing.Point(286, 25);
            this.cbxRmMail.Name = "cbxRmMail";
            this.cbxRmMail.Size = new System.Drawing.Size(130, 26);
            this.cbxRmMail.TabIndex = 7;
            this.cbxRmMail.Text = "邮件通知";
            this.cbxRmMail.UseVisualStyleBackColor = false;
            // 
            // cbxRmMessage
            // 
            this.cbxRmMessage.BackColor = System.Drawing.Color.Transparent;
            this.cbxRmMessage.Location = new System.Drawing.Point(14, 25);
            this.cbxRmMessage.Name = "cbxRmMessage";
            this.cbxRmMessage.Size = new System.Drawing.Size(131, 26);
            this.cbxRmMessage.TabIndex = 6;
            this.cbxRmMessage.Text = "即时消息通知";
            this.cbxRmMessage.UseVisualStyleBackColor = false;
            // 
            // cbxRmSms
            // 
            this.cbxRmSms.BackColor = System.Drawing.Color.Transparent;
            this.cbxRmSms.Location = new System.Drawing.Point(154, 25);
            this.cbxRmSms.Name = "cbxRmSms";
            this.cbxRmSms.Size = new System.Drawing.Size(131, 26);
            this.cbxRmSms.TabIndex = 5;
            this.cbxRmSms.Text = "手机短信通知";
            this.cbxRmSms.UseVisualStyleBackColor = false;
            // 
            // gbTimeoutNotice
            // 
            this.gbTimeoutNotice.BackColor = System.Drawing.Color.Transparent;
            this.gbTimeoutNotice.Controls.Add(this.lbxOtMsgToUsers);
            this.gbTimeoutNotice.Controls.Add(this.btnOtDelete);
            this.gbTimeoutNotice.Controls.Add(this.btnOtAdd);
            this.gbTimeoutNotice.Controls.Add(this.lblNoticeUsers);
            this.gbTimeoutNotice.Controls.Add(this.cbxOtMail);
            this.gbTimeoutNotice.Controls.Add(this.cbxOtMessage);
            this.gbTimeoutNotice.Controls.Add(this.cbxOtSms);
            this.gbTimeoutNotice.Location = new System.Drawing.Point(14, 11);
            this.gbTimeoutNotice.Name = "gbTimeoutNotice";
            this.gbTimeoutNotice.Size = new System.Drawing.Size(439, 179);
            this.gbTimeoutNotice.TabIndex = 63;
            this.gbTimeoutNotice.TabStop = false;
            this.gbTimeoutNotice.Text = "超时通知";
            // 
            // lbxOtMsgToUsers
            // 
            this.lbxOtMsgToUsers.FormattingEnabled = true;
            this.lbxOtMsgToUsers.ItemHeight = 14;
            this.lbxOtMsgToUsers.Location = new System.Drawing.Point(14, 72);
            this.lbxOtMsgToUsers.Name = "lbxOtMsgToUsers";
            this.lbxOtMsgToUsers.ScrollAlwaysVisible = true;
            this.lbxOtMsgToUsers.Size = new System.Drawing.Size(334, 88);
            this.lbxOtMsgToUsers.TabIndex = 12;
            // 
            // btnOtDelete
            // 
            this.btnOtDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOtDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOtDelete.Location = new System.Drawing.Point(363, 128);
            this.btnOtDelete.Name = "btnOtDelete";
            this.btnOtDelete.Size = new System.Drawing.Size(65, 26);
            this.btnOtDelete.TabIndex = 11;
            this.btnOtDelete.Text = "删除";
            this.btnOtDelete.Click += new System.EventHandler(this.btnOtDelete_Click);
            // 
            // btnOtAdd
            // 
            this.btnOtAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOtAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOtAdd.Location = new System.Drawing.Point(363, 82);
            this.btnOtAdd.Name = "btnOtAdd";
            this.btnOtAdd.Size = new System.Drawing.Size(65, 27);
            this.btnOtAdd.TabIndex = 10;
            this.btnOtAdd.Text = "增加";
            this.btnOtAdd.Click += new System.EventHandler(this.btnOtAdd_Click);
            // 
            // lblNoticeUsers
            // 
            this.lblNoticeUsers.AutoSize = true;
            this.lblNoticeUsers.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNoticeUsers.Location = new System.Drawing.Point(12, 55);
            this.lblNoticeUsers.Name = "lblNoticeUsers";
            this.lblNoticeUsers.Size = new System.Drawing.Size(126, 14);
            this.lblNoticeUsers.TabIndex = 8;
            this.lblNoticeUsers.Text = "同时通知下列人员:";
            // 
            // cbxOtMail
            // 
            this.cbxOtMail.BackColor = System.Drawing.Color.Transparent;
            this.cbxOtMail.Location = new System.Drawing.Point(286, 25);
            this.cbxOtMail.Name = "cbxOtMail";
            this.cbxOtMail.Size = new System.Drawing.Size(130, 26);
            this.cbxOtMail.TabIndex = 7;
            this.cbxOtMail.Text = "邮件通知";
            this.cbxOtMail.UseVisualStyleBackColor = false;
            // 
            // cbxOtMessage
            // 
            this.cbxOtMessage.BackColor = System.Drawing.Color.Transparent;
            this.cbxOtMessage.Location = new System.Drawing.Point(14, 25);
            this.cbxOtMessage.Name = "cbxOtMessage";
            this.cbxOtMessage.Size = new System.Drawing.Size(131, 26);
            this.cbxOtMessage.TabIndex = 6;
            this.cbxOtMessage.Text = "即时消息通知";
            this.cbxOtMessage.UseVisualStyleBackColor = false;
            // 
            // cbxOtSms
            // 
            this.cbxOtSms.BackColor = System.Drawing.Color.Transparent;
            this.cbxOtSms.Location = new System.Drawing.Point(154, 25);
            this.cbxOtSms.Name = "cbxOtSms";
            this.cbxOtSms.Size = new System.Drawing.Size(131, 26);
            this.cbxOtSms.TabIndex = 5;
            this.cbxOtSms.Text = "手机短信通知";
            this.cbxOtSms.UseVisualStyleBackColor = false;
            // 
            // tabItemTaskNotice
            // 
            this.tabItemTaskNotice.AttachedControl = this.tabControlPanel6;
            this.tabItemTaskNotice.Name = "tabItemTaskNotice";
            this.tabItemTaskNotice.Text = "任务通知";
            // 
            // FrmAlterNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 526);
            this.Name = "FrmAlterNode";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "交互节点配置";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel5.ResumeLayout(false);
            this.gbTimeOutProcess.ResumeLayout(false);
            this.gbTimeOutSet.ResumeLayout(false);
            this.gbTimeOutSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxMinute1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHour1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxDay1)).EndInit();
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel4.PerformLayout();
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.gbOperatorStrategy.ResumeLayout(false);
            this.gbOperatorStrategy.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.tabControlPanel6.ResumeLayout(false);
            this.gbArriveNotice.ResumeLayout(false);
            this.gbArriveNotice.PerformLayout();
            this.gbTimeoutNotice.ResumeLayout(false);
            this.gbTimeoutNotice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblTaskDescription;
        private Controls.UcTextBox tbxTaskDes;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.UcButton btnDeletecmd;
        private Controls.UcButton btnModifycmd;
        private Controls.UcButton btnAddcmd;
        private System.Windows.Forms.Label lblFormName;
        private Controls.UcTextBox tbxFormName;
        private Controls.UcTextBox tbxTaskName;
        private Controls.UcButton btnSelectCtrls;
        private System.Windows.Forms.Label lblTaskName;
        private DevComponents.DotNetBar.TabItem tabItemGeneral;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel6;
        private System.Windows.Forms.GroupBox gbArriveNotice;
        private System.Windows.Forms.ListBox lbxRmMsgToUsers;
        private Controls.UcButton btnRmDelete;
        private Controls.UcButton btnRmAdd;
        private System.Windows.Forms.Label lblArriveNoticeUsers;
        private System.Windows.Forms.CheckBox cbxRmMail;
        private System.Windows.Forms.CheckBox cbxRmMessage;
        private System.Windows.Forms.CheckBox cbxRmSms;
        private System.Windows.Forms.GroupBox gbTimeoutNotice;
        private System.Windows.Forms.ListBox lbxOtMsgToUsers;
        private Controls.UcButton btnOtDelete;
        private Controls.UcButton btnOtAdd;
        private System.Windows.Forms.Label lblNoticeUsers;
        private System.Windows.Forms.CheckBox cbxOtMail;
        private System.Windows.Forms.CheckBox cbxOtMessage;
        private System.Windows.Forms.CheckBox cbxOtSms;
        private DevComponents.DotNetBar.TabItem tabItemTaskNotice;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private System.Windows.Forms.GroupBox gbTimeOutProcess;
        private System.Windows.Forms.RadioButton rbRemain;
        private System.Windows.Forms.GroupBox gbTimeOutSet;
        private System.Windows.Forms.Label lblExtraurgent;
        private System.Windows.Forms.Label lblEmergency;
        private System.Windows.Forms.Label lblOrdinary;
        private System.Windows.Forms.NumericUpDown tbxMinute3;
        private System.Windows.Forms.NumericUpDown tbxHour3;
        private System.Windows.Forms.NumericUpDown tbxDay3;
        private System.Windows.Forms.NumericUpDown tbxMinute2;
        private System.Windows.Forms.NumericUpDown tbxHour2;
        private System.Windows.Forms.NumericUpDown tbxDay2;
        private System.Windows.Forms.NumericUpDown tbxMinute1;
        private System.Windows.Forms.NumericUpDown tbxHour1;
        private System.Windows.Forms.NumericUpDown tbxDay1;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEnableTimeOut;
        private DevComponents.DotNetBar.TabItem tabItemTimeOut;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private System.Windows.Forms.CheckBox cbxReturnry;
        private System.Windows.Forms.CheckBox cbxDyAssignNext;
        private System.Windows.Forms.CheckBox cbxAssign;
        private System.Windows.Forms.CheckBox cbxReturn;
        private DevComponents.DotNetBar.TabItem tabItemControlPermission;
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
        private System.Windows.Forms.CheckBox cbxJumpSelf;
        private System.Windows.Forms.CheckBox chkJumpNoOperator;
        private DevComponents.DotNetBar.TabItem tabItemOperator;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExCommand;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExOper;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExVar;
        private System.Windows.Forms.RadioButton rbOver;
    }
}