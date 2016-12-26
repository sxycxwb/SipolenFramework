namespace RDIFramework.WorkFlow
{
    partial class FrmQingJia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQingJia));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQingJia = new RDIFramework.Controls.UcTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtDays = new RDIFramework.Controls.UcTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cboQingJiaType = new RDIFramework.Controls.UcComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label6 = new System.Windows.Forms.Label();
            this.dtBeginTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDuty = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartment = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnSave = new RDIFramework.Controls.UcButton();
            this.gbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginTime)).BeginInit();
            this.pnlTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.label10);
            this.gbMain.Controls.Add(this.txtQingJia);
            this.gbMain.Controls.Add(this.label9);
            this.gbMain.Controls.Add(this.txtDays);
            this.gbMain.Controls.Add(this.label8);
            this.gbMain.Controls.Add(this.cboQingJiaType);
            this.gbMain.Controls.Add(this.label7);
            this.gbMain.Controls.Add(this.dtEndTime);
            this.gbMain.Controls.Add(this.label6);
            this.gbMain.Controls.Add(this.dtBeginTime);
            this.gbMain.Controls.Add(this.label5);
            this.gbMain.Controls.Add(this.txtDuty);
            this.gbMain.Controls.Add(this.label4);
            this.gbMain.Controls.Add(this.txtDepartment);
            this.gbMain.Controls.Add(this.label3);
            this.gbMain.Controls.Add(this.txtUserName);
            this.gbMain.Controls.Add(this.label2);
            this.gbMain.Controls.Add(this.txtUserId);
            this.gbMain.Controls.Add(this.label1);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 49);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(839, 302);
            this.gbMain.TabIndex = 1;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "详细信息";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(91, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(238, 14);
            this.label10.TabIndex = 38;
            this.label10.Text = "请假天数超过10天的必须由副总审批!";
            // 
            // txtQingJia
            // 
            // 
            // 
            // 
            this.txtQingJia.Border.Class = "TextBoxBorder";
            this.txtQingJia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQingJia.FocusHighlightEnabled = true;
            this.txtQingJia.Location = new System.Drawing.Point(94, 169);
            this.txtQingJia.Multiline = true;
            this.txtQingJia.Name = "txtQingJia";
            this.txtQingJia.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQingJia.SelectedValue = ((object)(resources.GetObject("txtQingJia.SelectedValue")));
            this.txtQingJia.Size = new System.Drawing.Size(714, 122);
            this.txtQingJia.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 36;
            this.label9.Text = "事由说明：";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.txtDays.Border.Class = "TextBoxBorder";
            this.txtDays.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDays.FocusHighlightEnabled = true;
            this.txtDays.Location = new System.Drawing.Point(489, 113);
            this.txtDays.Name = "txtDays";
            this.txtDays.SelectedValue = ((object)(resources.GetObject("txtDays.SelectedValue")));
            this.txtDays.Size = new System.Drawing.Size(319, 23);
            this.txtDays.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 34;
            this.label8.Text = "请假天数：";
            // 
            // cboQingJiaType
            // 
            this.cboQingJiaType.DisplayMember = "Text";
            this.cboQingJiaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQingJiaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQingJiaType.FormattingEnabled = true;
            this.cboQingJiaType.ItemHeight = 17;
            this.cboQingJiaType.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9});
            this.cboQingJiaType.Location = new System.Drawing.Point(94, 116);
            this.cboQingJiaType.Name = "cboQingJiaType";
            this.cboQingJiaType.Size = new System.Drawing.Size(319, 23);
            this.cboQingJiaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboQingJiaType.TabIndex = 33;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "事假";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "病假";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "工伤假";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "婚假";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "丧假";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "产假";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "探亲假";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "公假";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "年休假";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 32;
            this.label7.Text = "类型：";
            // 
            // dtEndTime
            // 
            // 
            // 
            // 
            this.dtEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtEndTime.ButtonDropDown.Visible = true;
            this.dtEndTime.IsPopupCalendarOpen = false;
            this.dtEndTime.Location = new System.Drawing.Point(489, 81);
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.BackgroundStyle.Class = "";
            this.dtEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2014, 7, 1, 0, 0, 0, 0);
            this.dtEndTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtEndTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtEndTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(319, 23);
            this.dtEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtEndTime.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "结束时间：";
            // 
            // dtBeginTime
            // 
            // 
            // 
            // 
            this.dtBeginTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtBeginTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBeginTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtBeginTime.ButtonDropDown.Visible = true;
            this.dtBeginTime.IsPopupCalendarOpen = false;
            this.dtBeginTime.Location = new System.Drawing.Point(94, 85);
            // 
            // 
            // 
            this.dtBeginTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtBeginTime.MonthCalendar.BackgroundStyle.Class = "";
            this.dtBeginTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBeginTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtBeginTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBeginTime.MonthCalendar.DisplayMonth = new System.DateTime(2014, 7, 1, 0, 0, 0, 0);
            this.dtBeginTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtBeginTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtBeginTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtBeginTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtBeginTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtBeginTime.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtBeginTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtBeginTime.MonthCalendar.TodayButtonVisible = true;
            this.dtBeginTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtBeginTime.Name = "dtBeginTime";
            this.dtBeginTime.Size = new System.Drawing.Size(319, 23);
            this.dtBeginTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtBeginTime.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "开始时间：";
            // 
            // txtDuty
            // 
            this.txtDuty.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtDuty.Border.Class = "TextBoxBorder";
            this.txtDuty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDuty.FocusHighlightEnabled = true;
            this.txtDuty.Location = new System.Drawing.Point(489, 50);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.ReadOnly = true;
            this.txtDuty.SelectedValue = ((object)(resources.GetObject("txtDuty.SelectedValue")));
            this.txtDuty.Size = new System.Drawing.Size(319, 23);
            this.txtDuty.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "岗位：";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtDepartment.Border.Class = "TextBoxBorder";
            this.txtDepartment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDepartment.FocusHighlightEnabled = true;
            this.txtDepartment.Location = new System.Drawing.Point(94, 54);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.SelectedValue = ((object)(resources.GetObject("txtDepartment.SelectedValue")));
            this.txtDepartment.Size = new System.Drawing.Size(319, 23);
            this.txtDepartment.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "部门：";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.FocusHighlightEnabled = true;
            this.txtUserName.Location = new System.Drawing.Point(489, 20);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.SelectedValue = ((object)(resources.GetObject("txtUserName.SelectedValue")));
            this.txtUserName.Size = new System.Drawing.Size(319, 23);
            this.txtUserName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "姓名：";
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.txtUserId.Border.Class = "TextBoxBorder";
            this.txtUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserId.FocusHighlightEnabled = true;
            this.txtUserId.Location = new System.Drawing.Point(94, 23);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.SelectedValue = ((object)(resources.GetObject("txtUserId.SelectedValue")));
            this.txtUserId.Size = new System.Drawing.Size(319, 23);
            this.txtUserId.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "请假人：";
            // 
            // pnlTool
            // 
            this.pnlTool.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlTool.Controls.Add(this.btnSave);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(839, 49);
            this.pnlTool.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存请假信息";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmQingJia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 351);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.pnlTool);
            this.Name = "FrmQingJia";
            this.Text = "请假单";
            this.Load += new System.EventHandler(this.FrmQingJia_Load);
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBeginTime)).EndInit();
            this.pnlTool.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label label10;
        private Controls.UcTextBox txtQingJia;
        private System.Windows.Forms.Label label9;
        private Controls.UcTextBox txtDays;
        private System.Windows.Forms.Label label8;
        private Controls.UcComboBoxEx cboQingJiaType;
        private System.Windows.Forms.Label label7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEndTime;
        private System.Windows.Forms.Label label6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtBeginTime;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtDuty;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox txtDepartment;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private Controls.UcTextBox txtUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTool;
        private Controls.UcButton btnSave;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
    }
}