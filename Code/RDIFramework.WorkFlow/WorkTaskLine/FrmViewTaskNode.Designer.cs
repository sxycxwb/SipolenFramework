namespace RDIFramework.WorkFlow
{
    partial class FrmViewTaskNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewTaskNode));
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbArriveNotice = new System.Windows.Forms.GroupBox();
            this.lbxRmMsgToUsers = new System.Windows.Forms.ListBox();
            this.btnRmDelete = new RDIFramework.Controls.UcButton();
            this.btnRmAdd = new RDIFramework.Controls.UcButton();
            this.lblNoticeUsers = new System.Windows.Forms.Label();
            this.cbxRmMail = new System.Windows.Forms.CheckBox();
            this.cbxRmMessage = new System.Windows.Forms.CheckBox();
            this.cbxRmSms = new System.Windows.Forms.CheckBox();
            this.tabItemTaskNotice = new DevComponents.DotNetBar.TabItem(this.components);
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
            this.lblProcess = new System.Windows.Forms.Label();
            this.btnDeletecmd = new RDIFramework.Controls.UcButton();
            this.btnModifycmd = new RDIFramework.Controls.UcButton();
            this.btnAddcmd = new RDIFramework.Controls.UcButton();
            this.tbxTaskDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxFormName = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxTaskName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.lblFormName = new System.Windows.Forms.Label();
            this.btnSelectCtrls = new RDIFramework.Controls.UcButton();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.tabItemGeneral = new DevComponents.DotNetBar.TabItem(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbArriveNotice.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.gbOperatorStrategy.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tcUser);
            this.plclassFill.Location = new System.Drawing.Point(3, 3);
            this.plclassFill.Size = new System.Drawing.Size(478, 418);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(3, 372);
            this.plclassBottom.Size = new System.Drawing.Size(478, 49);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(370, 10);
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 10);
            this.btnSave.Size = new System.Drawing.Size(80, 27);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel3);
            this.tcUser.Controls.Add(this.tabControlPanel1);
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(478, 418);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 24;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemGeneral);
            this.tcUser.Tabs.Add(this.tabItemOperator);
            this.tcUser.Tabs.Add(this.tabItemTaskNotice);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbArriveNotice);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(478, 391);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItemTaskNotice;
            // 
            // gbArriveNotice
            // 
            this.gbArriveNotice.BackColor = System.Drawing.Color.Transparent;
            this.gbArriveNotice.Controls.Add(this.lbxRmMsgToUsers);
            this.gbArriveNotice.Controls.Add(this.btnRmDelete);
            this.gbArriveNotice.Controls.Add(this.btnRmAdd);
            this.gbArriveNotice.Controls.Add(this.lblNoticeUsers);
            this.gbArriveNotice.Controls.Add(this.cbxRmMail);
            this.gbArriveNotice.Controls.Add(this.cbxRmMessage);
            this.gbArriveNotice.Controls.Add(this.cbxRmSms);
            this.gbArriveNotice.Location = new System.Drawing.Point(10, 7);
            this.gbArriveNotice.Name = "gbArriveNotice";
            this.gbArriveNotice.Size = new System.Drawing.Size(441, 295);
            this.gbArriveNotice.TabIndex = 63;
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
            this.lbxRmMsgToUsers.Size = new System.Drawing.Size(341, 214);
            this.lbxRmMsgToUsers.TabIndex = 12;
            // 
            // btnRmDelete
            // 
            this.btnRmDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRmDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRmDelete.Location = new System.Drawing.Point(359, 115);
            this.btnRmDelete.Name = "btnRmDelete";
            this.btnRmDelete.Size = new System.Drawing.Size(74, 26);
            this.btnRmDelete.TabIndex = 11;
            this.btnRmDelete.Text = "删除";
            this.btnRmDelete.Click += new System.EventHandler(this.btnRmDelete_Click);
            // 
            // btnRmAdd
            // 
            this.btnRmAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRmAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRmAdd.Location = new System.Drawing.Point(359, 82);
            this.btnRmAdd.Name = "btnRmAdd";
            this.btnRmAdd.Size = new System.Drawing.Size(74, 27);
            this.btnRmAdd.TabIndex = 10;
            this.btnRmAdd.Text = "增加";
            this.btnRmAdd.Click += new System.EventHandler(this.btnRmAdd_Click);
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
            // cbxRmMail
            // 
            this.cbxRmMail.Location = new System.Drawing.Point(286, 25);
            this.cbxRmMail.Name = "cbxRmMail";
            this.cbxRmMail.Size = new System.Drawing.Size(147, 26);
            this.cbxRmMail.TabIndex = 7;
            this.cbxRmMail.Text = "邮件通知";
            // 
            // cbxRmMessage
            // 
            this.cbxRmMessage.Location = new System.Drawing.Point(14, 25);
            this.cbxRmMessage.Name = "cbxRmMessage";
            this.cbxRmMessage.Size = new System.Drawing.Size(131, 26);
            this.cbxRmMessage.TabIndex = 6;
            this.cbxRmMessage.Text = "即时消息通知";
            // 
            // cbxRmSms
            // 
            this.cbxRmSms.Location = new System.Drawing.Point(154, 25);
            this.cbxRmSms.Name = "cbxRmSms";
            this.cbxRmSms.Size = new System.Drawing.Size(131, 26);
            this.cbxRmSms.TabIndex = 5;
            this.cbxRmSms.Text = "手机短信通知";
            // 
            // tabItemTaskNotice
            // 
            this.tabItemTaskNotice.AttachedControl = this.tabControlPanel3;
            this.tabItemTaskNotice.Name = "tabItemTaskNotice";
            this.tabItemTaskNotice.Text = "任务通知";
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
            this.tabControlPanel1.Size = new System.Drawing.Size(478, 391);
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
            this.lvExOper.Location = new System.Drawing.Point(22, 110);
            this.lvExOper.Name = "lvExOper";
            this.lvExOper.Size = new System.Drawing.Size(433, 185);
            this.lvExOper.TabIndex = 144;
            this.lvExOper.UseCompatibleStateImageBehavior = false;
            this.lvExOper.View = System.Windows.Forms.View.Details;
            this.lvExOper.DoubleClick += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnDeleteOpr
            // 
            this.btnDeleteOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteOpr.Location = new System.Drawing.Point(202, 301);
            this.btnDeleteOpr.Name = "btnDeleteOpr";
            this.btnDeleteOpr.Size = new System.Drawing.Size(76, 26);
            this.btnDeleteOpr.TabIndex = 126;
            this.btnDeleteOpr.Text = "删除";
            this.btnDeleteOpr.Click += new System.EventHandler(this.btnDeleteOpr_Click);
            // 
            // btnModifyOpr
            // 
            this.btnModifyOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifyOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifyOpr.Location = new System.Drawing.Point(112, 301);
            this.btnModifyOpr.Name = "btnModifyOpr";
            this.btnModifyOpr.Size = new System.Drawing.Size(77, 26);
            this.btnModifyOpr.TabIndex = 125;
            this.btnModifyOpr.Text = "修改...";
            this.btnModifyOpr.Click += new System.EventHandler(this.btnModifyOpr_Click);
            // 
            // btnAddOpr
            // 
            this.btnAddOpr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddOpr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddOpr.Location = new System.Drawing.Point(22, 301);
            this.btnAddOpr.Name = "btnAddOpr";
            this.btnAddOpr.Size = new System.Drawing.Size(77, 26);
            this.btnAddOpr.TabIndex = 124;
            this.btnAddOpr.Text = "增加...";
            this.btnAddOpr.Click += new System.EventHandler(this.btnAddOpr_Click);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.BackColor = System.Drawing.Color.Transparent;
            this.lblOperator.Location = new System.Drawing.Point(22, 88);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(56, 14);
            this.lblOperator.TabIndex = 122;
            this.lblOperator.Text = "处理者:";
            // 
            // gbOperatorStrategy
            // 
            this.gbOperatorStrategy.BackColor = System.Drawing.Color.Transparent;
            this.gbOperatorStrategy.Controls.Add(this.rbtEveryUser);
            this.gbOperatorStrategy.Controls.Add(this.rbtShareUser);
            this.gbOperatorStrategy.Location = new System.Drawing.Point(7, 8);
            this.gbOperatorStrategy.Name = "gbOperatorStrategy";
            this.gbOperatorStrategy.Size = new System.Drawing.Size(454, 72);
            this.gbOperatorStrategy.TabIndex = 121;
            this.gbOperatorStrategy.TabStop = false;
            this.gbOperatorStrategy.Text = "处理者策略";
            // 
            // rbtEveryUser
            // 
            this.rbtEveryUser.AutoEllipsis = true;
            this.rbtEveryUser.Location = new System.Drawing.Point(222, 34);
            this.rbtEveryUser.Name = "rbtEveryUser";
            this.rbtEveryUser.Size = new System.Drawing.Size(226, 18);
            this.rbtEveryUser.TabIndex = 1;
            this.rbtEveryUser.Text = "所有用户处理(会签)";
            this.rbtEveryUser.UseVisualStyleBackColor = true;
            // 
            // rbtShareUser
            // 
            this.rbtShareUser.AutoEllipsis = true;
            this.rbtShareUser.Checked = true;
            this.rbtShareUser.Location = new System.Drawing.Point(29, 34);
            this.rbtShareUser.Name = "rbtShareUser";
            this.rbtShareUser.Size = new System.Drawing.Size(172, 18);
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
            this.tabControlPanel2.Controls.Add(this.lblProcess);
            this.tabControlPanel2.Controls.Add(this.btnDeletecmd);
            this.tabControlPanel2.Controls.Add(this.btnModifycmd);
            this.tabControlPanel2.Controls.Add(this.btnAddcmd);
            this.tabControlPanel2.Controls.Add(this.tbxTaskDes);
            this.tabControlPanel2.Controls.Add(this.tbxFormName);
            this.tabControlPanel2.Controls.Add(this.tbxTaskName);
            this.tabControlPanel2.Controls.Add(this.lblTaskDescription);
            this.tabControlPanel2.Controls.Add(this.lblFormName);
            this.tabControlPanel2.Controls.Add(this.btnSelectCtrls);
            this.tabControlPanel2.Controls.Add(this.lblTaskName);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(478, 391);
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
            this.lvExCommand.Location = new System.Drawing.Point(17, 129);
            this.lvExCommand.Name = "lvExCommand";
            this.lvExCommand.Size = new System.Drawing.Size(439, 163);
            this.lvExCommand.TabIndex = 145;
            this.lvExCommand.UseCompatibleStateImageBehavior = false;
            this.lvExCommand.View = System.Windows.Forms.View.Details;
            this.lvExCommand.DoubleClick += new System.EventHandler(this.btnModifyCmd_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Location = new System.Drawing.Point(14, 108);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(42, 14);
            this.lblProcess.TabIndex = 144;
            this.lblProcess.Text = "处理:";
            // 
            // btnDeletecmd
            // 
            this.btnDeletecmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeletecmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeletecmd.Location = new System.Drawing.Point(198, 303);
            this.btnDeletecmd.Name = "btnDeletecmd";
            this.btnDeletecmd.Size = new System.Drawing.Size(73, 26);
            this.btnDeletecmd.TabIndex = 142;
            this.btnDeletecmd.Text = "删除";
            this.btnDeletecmd.Click += new System.EventHandler(this.btnDeleteCmd_Click);
            // 
            // btnModifycmd
            // 
            this.btnModifycmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModifycmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModifycmd.Location = new System.Drawing.Point(108, 303);
            this.btnModifycmd.Name = "btnModifycmd";
            this.btnModifycmd.Size = new System.Drawing.Size(73, 26);
            this.btnModifycmd.TabIndex = 141;
            this.btnModifycmd.Text = "修改...";
            this.btnModifycmd.Click += new System.EventHandler(this.btnModifyCmd_Click);
            // 
            // btnAddcmd
            // 
            this.btnAddcmd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddcmd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddcmd.Location = new System.Drawing.Point(18, 303);
            this.btnAddcmd.Name = "btnAddcmd";
            this.btnAddcmd.Size = new System.Drawing.Size(73, 26);
            this.btnAddcmd.TabIndex = 140;
            this.btnAddcmd.Text = "增加...";
            this.btnAddcmd.Click += new System.EventHandler(this.btnAddCmd_Click);
            // 
            // tbxTaskDes
            // 
            // 
            // 
            // 
            this.tbxTaskDes.Border.Class = "TextBoxBorder";
            this.tbxTaskDes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTaskDes.FocusHighlightEnabled = true;
            this.tbxTaskDes.Location = new System.Drawing.Point(106, 77);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.SelectedValue = ((object)(resources.GetObject("tbxTaskDes.SelectedValue")));
            this.tbxTaskDes.Size = new System.Drawing.Size(302, 23);
            this.tbxTaskDes.TabIndex = 138;
            // 
            // tbxFormName
            // 
            // 
            // 
            // 
            this.tbxFormName.Border.Class = "TextBoxBorder";
            this.tbxFormName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxFormName.FocusHighlightEnabled = true;
            this.tbxFormName.Location = new System.Drawing.Point(106, 44);
            this.tbxFormName.Name = "tbxFormName";
            this.tbxFormName.ReadOnly = true;
            this.tbxFormName.SelectedValue = ((object)(resources.GetObject("tbxFormName.SelectedValue")));
            this.tbxFormName.Size = new System.Drawing.Size(247, 23);
            this.tbxFormName.TabIndex = 136;
            // 
            // tbxTaskName
            // 
            // 
            // 
            // 
            this.tbxTaskName.Border.Class = "TextBoxBorder";
            this.tbxTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxTaskName.FocusHighlightEnabled = true;
            this.tbxTaskName.Location = new System.Drawing.Point(106, 12);
            this.tbxTaskName.Name = "tbxTaskName";
            this.tbxTaskName.SelectedValue = ((object)(resources.GetObject("tbxTaskName.SelectedValue")));
            this.tbxTaskName.Size = new System.Drawing.Size(302, 23);
            this.tbxTaskName.TabIndex = 134;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoEllipsis = true;
            this.lblTaskDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskDescription.Location = new System.Drawing.Point(4, 81);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(101, 14);
            this.lblTaskDescription.TabIndex = 139;
            this.lblTaskDescription.Text = "任务描述:";
            this.lblTaskDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFormName
            // 
            this.lblFormName.AutoEllipsis = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Location = new System.Drawing.Point(4, 50);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(101, 14);
            this.lblFormName.TabIndex = 137;
            this.lblFormName.Text = "表单名:";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectCtrls
            // 
            this.btnSelectCtrls.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectCtrls.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectCtrls.Location = new System.Drawing.Point(360, 44);
            this.btnSelectCtrls.Name = "btnSelectCtrls";
            this.btnSelectCtrls.Size = new System.Drawing.Size(48, 27);
            this.btnSelectCtrls.TabIndex = 135;
            this.btnSelectCtrls.Text = "...";
            this.btnSelectCtrls.Click += new System.EventHandler(this.btnSelectCtrls_Click);
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoEllipsis = true;
            this.lblTaskName.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskName.Location = new System.Drawing.Point(4, 16);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(101, 14);
            this.lblTaskName.TabIndex = 133;
            this.lblTaskName.Text = "任务名称:";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabItemGeneral
            // 
            this.tabItemGeneral.AttachedControl = this.tabControlPanel2;
            this.tabItemGeneral.Name = "tabItemGeneral";
            this.tabItemGeneral.Text = "常规";
            // 
            // FrmViewTaskNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 424);
            this.Name = "FrmViewTaskNode";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "查看节点配置";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbArriveNotice.ResumeLayout(false);
            this.gbArriveNotice.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.gbOperatorStrategy.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.Label lblProcess;
        private Controls.UcButton btnDeletecmd;
        private Controls.UcButton btnModifycmd;
        private Controls.UcButton btnAddcmd;
        private Controls.UcTextBox tbxTaskDes;
        private Controls.UcTextBox tbxFormName;
        private Controls.UcTextBox tbxTaskName;
        private System.Windows.Forms.Label lblTaskDescription;
        private System.Windows.Forms.Label lblFormName;
        private Controls.UcButton btnSelectCtrls;
        private System.Windows.Forms.Label lblTaskName;
        private DevComponents.DotNetBar.TabItem tabItemGeneral;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbArriveNotice;
        private System.Windows.Forms.ListBox lbxRmMsgToUsers;
        private Controls.UcButton btnRmDelete;
        private Controls.UcButton btnRmAdd;
        private System.Windows.Forms.Label lblNoticeUsers;
        private System.Windows.Forms.CheckBox cbxRmMail;
        private System.Windows.Forms.CheckBox cbxRmMessage;
        private System.Windows.Forms.CheckBox cbxRmSms;
        private DevComponents.DotNetBar.TabItem tabItemTaskNotice;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private Controls.UcButton btnDeleteOpr;
        private Controls.UcButton btnModifyOpr;
        private Controls.UcButton btnAddOpr;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.GroupBox gbOperatorStrategy;
        private System.Windows.Forms.RadioButton rbtEveryUser;
        private System.Windows.Forms.RadioButton rbtShareUser;
        private DevComponents.DotNetBar.TabItem tabItemOperator;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExCommand;
        private DevComponents.DotNetBar.Controls.ListViewEx lvExOper;
    }
}