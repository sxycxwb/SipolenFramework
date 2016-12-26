namespace CRM
{
    partial class FrmIncomingCallEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIncomingCallEdit));
            this.txtCustomerName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.expandablePanel4 = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.dtCallDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.rbNotHandled = new System.Windows.Forms.RadioButton();
            this.rbHandled = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbCallType5 = new System.Windows.Forms.RadioButton();
            this.rbCallType3 = new System.Windows.Forms.RadioButton();
            this.rbCallType4 = new System.Windows.Forms.RadioButton();
            this.rbCallType2 = new System.Windows.Forms.RadioButton();
            this.rbCallType1 = new System.Windows.Forms.RadioButton();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.btnSelectCustomer = new RDIFramework.Controls.UcButton();
            this.txtCallRecord = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtCallNumber = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveContine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain.SuspendLayout();
            this.expandablePanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCallDate)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.AccessibleName = "EmptyValue|NotNull";
            // 
            // 
            // 
            this.txtCustomerName.Border.Class = "TextBoxBorder";
            this.txtCustomerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustomerName.FocusHighlightEnabled = true;
            this.txtCustomerName.Location = new System.Drawing.Point(104, 226);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.SelectedValue = ((object)(resources.GetObject("txtCustomerName.SelectedValue")));
            this.txtCustomerName.Size = new System.Drawing.Size(368, 23);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.Tag = "来电客户";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(25, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 14);
            this.label7.TabIndex = 71;
            this.label7.Text = "来电客户：";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.expandablePanel4);
            this.pnlMain.Controls.Add(this.expandablePanel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(567, 566);
            this.pnlMain.TabIndex = 2;
            // 
            // expandablePanel4
            // 
            this.expandablePanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel4.Controls.Add(this.txtDescription);
            this.expandablePanel4.Controls.Add(this.dtCallDate);
            this.expandablePanel4.Controls.Add(this.rbNotHandled);
            this.expandablePanel4.Controls.Add(this.rbHandled);
            this.expandablePanel4.Controls.Add(this.groupBox2);
            this.expandablePanel4.Controls.Add(this.label22);
            this.expandablePanel4.Controls.Add(this.label20);
            this.expandablePanel4.Controls.Add(this.label19);
            this.expandablePanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel4.ExpandOnTitleClick = true;
            this.expandablePanel4.Location = new System.Drawing.Point(0, 266);
            this.expandablePanel4.Name = "expandablePanel4";
            this.expandablePanel4.Size = new System.Drawing.Size(567, 260);
            this.expandablePanel4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel4.Style.GradientAngle = 90;
            this.expandablePanel4.TabIndex = 1;
            this.expandablePanel4.TabStop = true;
            this.expandablePanel4.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel4.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel4.TitleStyle.BackgroundImage = global::CRM.Properties.Resources.memo1;
            this.expandablePanel4.TitleStyle.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.TopLeft;
            this.expandablePanel4.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel4.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel4.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel4.TitleStyle.GradientAngle = 90;
            this.expandablePanel4.TitleText = "  其他资料";
            // 
            // txtDescription
            // 
            this.txtDescription.AccessibleName = "EmptyValue";
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(29, 168);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.SelectedValue = ((object)(resources.GetObject("txtDescription.SelectedValue")));
            this.txtDescription.Size = new System.Drawing.Size(511, 85);
            this.txtDescription.TabIndex = 3;
            // 
            // dtCallDate
            // 
            this.dtCallDate.AccessibleName = "EmptyValue";
            // 
            // 
            // 
            this.dtCallDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtCallDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtCallDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtCallDate.ButtonDropDown.Visible = true;
            this.dtCallDate.IsPopupCalendarOpen = false;
            this.dtCallDate.Location = new System.Drawing.Point(266, 119);
            // 
            // 
            // 
            this.dtCallDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtCallDate.MonthCalendar.BackgroundStyle.Class = "";
            this.dtCallDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtCallDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtCallDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtCallDate.MonthCalendar.DisplayMonth = new System.DateTime(2012, 8, 1, 0, 0, 0, 0);
            this.dtCallDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtCallDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtCallDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtCallDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtCallDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtCallDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtCallDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtCallDate.MonthCalendar.TodayButtonVisible = true;
            this.dtCallDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtCallDate.Name = "dtCallDate";
            this.dtCallDate.Size = new System.Drawing.Size(142, 23);
            this.dtCallDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtCallDate.TabIndex = 2;
            // 
            // rbNotHandled
            // 
            this.rbNotHandled.AutoSize = true;
            this.rbNotHandled.Checked = true;
            this.rbNotHandled.Location = new System.Drawing.Point(103, 121);
            this.rbNotHandled.Name = "rbNotHandled";
            this.rbNotHandled.Size = new System.Drawing.Size(39, 18);
            this.rbNotHandled.TabIndex = 0;
            this.rbNotHandled.TabStop = true;
            this.rbNotHandled.Text = "否";
            this.rbNotHandled.UseVisualStyleBackColor = true;
            // 
            // rbHandled
            // 
            this.rbHandled.AutoSize = true;
            this.rbHandled.Location = new System.Drawing.Point(143, 121);
            this.rbHandled.Name = "rbHandled";
            this.rbHandled.Size = new System.Drawing.Size(39, 18);
            this.rbHandled.TabIndex = 1;
            this.rbHandled.Text = "是";
            this.rbHandled.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbCallType5);
            this.groupBox2.Controls.Add(this.rbCallType3);
            this.groupBox2.Controls.Add(this.rbCallType4);
            this.groupBox2.Controls.Add(this.rbCallType2);
            this.groupBox2.Controls.Add(this.rbCallType1);
            this.groupBox2.Location = new System.Drawing.Point(25, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 63);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "来电类型";
            // 
            // rbCallType5
            // 
            this.rbCallType5.AutoSize = true;
            this.rbCallType5.Location = new System.Drawing.Point(340, 32);
            this.rbCallType5.Name = "rbCallType5";
            this.rbCallType5.Size = new System.Drawing.Size(53, 18);
            this.rbCallType5.TabIndex = 4;
            this.rbCallType5.Text = "其他";
            this.rbCallType5.UseVisualStyleBackColor = true;
            // 
            // rbCallType3
            // 
            this.rbCallType3.AutoSize = true;
            this.rbCallType3.Location = new System.Drawing.Point(208, 32);
            this.rbCallType3.Name = "rbCallType3";
            this.rbCallType3.Size = new System.Drawing.Size(53, 18);
            this.rbCallType3.TabIndex = 2;
            this.rbCallType3.Text = "投诉";
            this.rbCallType3.UseVisualStyleBackColor = true;
            // 
            // rbCallType4
            // 
            this.rbCallType4.AutoSize = true;
            this.rbCallType4.Location = new System.Drawing.Point(274, 32);
            this.rbCallType4.Name = "rbCallType4";
            this.rbCallType4.Size = new System.Drawing.Size(53, 18);
            this.rbCallType4.TabIndex = 3;
            this.rbCallType4.Text = "合作";
            this.rbCallType4.UseVisualStyleBackColor = true;
            // 
            // rbCallType2
            // 
            this.rbCallType2.AutoSize = true;
            this.rbCallType2.Location = new System.Drawing.Point(114, 32);
            this.rbCallType2.Name = "rbCallType2";
            this.rbCallType2.Size = new System.Drawing.Size(81, 18);
            this.rbCallType2.TabIndex = 1;
            this.rbCallType2.Text = "售后服务";
            this.rbCallType2.UseVisualStyleBackColor = true;
            // 
            // rbCallType1
            // 
            this.rbCallType1.AutoSize = true;
            this.rbCallType1.Checked = true;
            this.rbCallType1.Location = new System.Drawing.Point(20, 32);
            this.rbCallType1.Name = "rbCallType1";
            this.rbCallType1.Size = new System.Drawing.Size(81, 18);
            this.rbCallType1.TabIndex = 0;
            this.rbCallType1.TabStop = true;
            this.rbCallType1.Text = "销售机会";
            this.rbCallType1.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(25, 151);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 14);
            this.label22.TabIndex = 70;
            this.label22.Text = "备注/描述：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(194, 123);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 14);
            this.label20.TabIndex = 66;
            this.label20.Text = "登记日期：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 14);
            this.label19.TabIndex = 62;
            this.label19.Text = "是否处理：";
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.btnSelectCustomer);
            this.expandablePanel1.Controls.Add(this.txtCallRecord);
            this.expandablePanel1.Controls.Add(this.txtCustomerName);
            this.expandablePanel1.Controls.Add(this.label7);
            this.expandablePanel1.Controls.Add(this.txtCallNumber);
            this.expandablePanel1.Controls.Add(this.label4);
            this.expandablePanel1.Controls.Add(this.label1);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.ExpandOnTitleClick = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(567, 266);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 0;
            this.expandablePanel1.TabStop = true;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.BackgroundImage = global::CRM.Properties.Resources.customer;
            this.expandablePanel1.TitleStyle.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.TopLeft;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "  基本信息";
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSelectCustomer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectCustomer.Location = new System.Drawing.Point(478, 226);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(58, 23);
            this.btnSelectCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelectCustomer.TabIndex = 3;
            this.btnSelectCustomer.Text = "...";
            this.btnSelectCustomer.Tooltip = "单击到【我的客户】选择来电客户...";
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // txtCallRecord
            // 
            this.txtCallRecord.AccessibleName = "EmptyValue|NotNull";
            this.txtCallRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCallRecord.Border.Class = "TextBoxBorder";
            this.txtCallRecord.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCallRecord.FocusHighlightEnabled = true;
            this.txtCallRecord.Location = new System.Drawing.Point(25, 56);
            this.txtCallRecord.Multiline = true;
            this.txtCallRecord.Name = "txtCallRecord";
            this.txtCallRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCallRecord.SelectedValue = ((object)(resources.GetObject("txtCallRecord.SelectedValue")));
            this.txtCallRecord.Size = new System.Drawing.Size(511, 135);
            this.txtCallRecord.TabIndex = 0;
            this.txtCallRecord.Tag = "来电内容";
            // 
            // txtCallNumber
            // 
            this.txtCallNumber.AccessibleName = "EmptyValue";
            this.txtCallNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCallNumber.Border.Class = "TextBoxBorder";
            this.txtCallNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCallNumber.FocusHighlightEnabled = true;
            this.txtCallNumber.Location = new System.Drawing.Point(103, 197);
            this.txtCallNumber.Name = "txtCallNumber";
            this.txtCallNumber.SelectedValue = ((object)(resources.GetObject("txtCallNumber.SelectedValue")));
            this.txtCallNumber.Size = new System.Drawing.Size(433, 23);
            this.txtCallNumber.TabIndex = 1;
            this.txtCallNumber.Tag = "来电号码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 14);
            this.label4.TabIndex = 67;
            this.label4.Text = "来电号码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 14);
            this.label1.TabIndex = 60;
            this.label1.Text = "来电快速记录（*必填）：";
            // 
            // tlsTool
            // 
            this.tlsTool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnSaveContine,
            this.toolStripSeparator3,
            this.btnCancel,
            this.btnClose});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(567, 25);
            this.tlsTool.TabIndex = 1;
            this.tlsTool.TabStop = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.ToolTipText = "保存联系人信息";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveContine
            // 
            this.btnSaveContine.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveContine.Image")));
            this.btnSaveContine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveContine.Name = "btnSaveContine";
            this.btnSaveContine.Size = new System.Drawing.Size(55, 22);
            this.btnSaveContine.Text = "继续";
            this.btnSaveContine.ToolTipText = "保存并继续添加";
            this.btnSaveContine.Click += new System.EventHandler(this.btnSaveContine_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::CRM.Properties.Resources.cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 22);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.ToolTipText = "放弃保存并退出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 22);
            this.btnClose.Text = "关闭(&Q)";
            this.btnClose.ToolTipText = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmIncomingCallEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 550);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsTool);
            this.MaximizeBox = false;
            this.Name = "FrmIncomingCallEdit";
            this.Text = "来电登记";
            this.pnlMain.ResumeLayout(false);
            this.expandablePanel4.ResumeLayout(false);
            this.expandablePanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCallDate)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.expandablePanel1.ResumeLayout(false);
            this.expandablePanel1.PerformLayout();
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RDIFramework.Controls.UcTextBox txtCustomerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlMain;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private RDIFramework.Controls.UcTextBox txtCallRecord;
        private RDIFramework.Controls.UcTextBox txtCallNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveContine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnClose;
        private RDIFramework.Controls.UcButton btnSelectCustomer;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtCallDate;
        private System.Windows.Forms.RadioButton rbNotHandled;
        private System.Windows.Forms.RadioButton rbHandled;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbCallType5;
        private System.Windows.Forms.RadioButton rbCallType3;
        private System.Windows.Forms.RadioButton rbCallType4;
        private System.Windows.Forms.RadioButton rbCallType2;
        private System.Windows.Forms.RadioButton rbCallType1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private RDIFramework.Controls.UcTextBox txtDescription;

    }
}