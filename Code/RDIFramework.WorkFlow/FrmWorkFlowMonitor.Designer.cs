namespace RDIFramework.WorkFlow
{
    partial class FrmWorkFlowMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlowMonitor));
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvWorkFlowMonitor = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWorkFlowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlowInsCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblStatus3 = new System.Windows.Forms.Label();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbLikeSearch = new System.Windows.Forms.RadioButton();
            this.rbExactSearch = new System.Windows.Forms.RadioButton();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.gbWorkFlowStatus = new System.Windows.Forms.GroupBox();
            this.rbWFAll = new System.Windows.Forms.RadioButton();
            this.rbWFCompleted = new System.Windows.Forms.RadioButton();
            this.rbWFRunning = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtWFFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblBizName = new System.Windows.Forms.Label();
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnViewWFStatus = new System.Windows.Forms.ToolStripButton();
            this.btnProcessStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkFlowMonitor)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.gbWorkFlowStatus.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(100, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvWorkFlowMonitor);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(201, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 553);
            this.panel2.TabIndex = 13;
            // 
            // dgvWorkFlowMonitor
            // 
            this.dgvWorkFlowMonitor.AllowUserToAddRows = false;
            this.dgvWorkFlowMonitor.AllowUserToDeleteRows = false;
            this.dgvWorkFlowMonitor.AllowUserToOrderColumns = true;
            this.dgvWorkFlowMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkFlowMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkFlowMonitor.ColumnHeadersHeight = 26;
            this.dgvWorkFlowMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWorkFlowMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colWorkFlowNo,
            this.colFlowInsCaption,
            this.colStartTime,
            this.colEndTime,
            this.colStatus,
            this.colDescription});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkFlowMonitor.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkFlowMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkFlowMonitor.EnableHeadersVisualStyles = false;
            this.dgvWorkFlowMonitor.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvWorkFlowMonitor.Location = new System.Drawing.Point(0, 34);
            this.dgvWorkFlowMonitor.MultiSelect = false;
            this.dgvWorkFlowMonitor.Name = "dgvWorkFlowMonitor";
            this.dgvWorkFlowMonitor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkFlowMonitor.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvWorkFlowMonitor.RowHeadersWidth = 30;
            this.dgvWorkFlowMonitor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvWorkFlowMonitor.RowTemplate.Height = 23;
            this.dgvWorkFlowMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvWorkFlowMonitor.Size = new System.Drawing.Size(796, 488);
            this.dgvWorkFlowMonitor.TabIndex = 8;
            this.dgvWorkFlowMonitor.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvWorkFlowMonitor_CellFormatting);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 45;
            // 
            // colWorkFlowNo
            // 
            this.colWorkFlowNo.DataPropertyName = "WorkFlowNo";
            this.colWorkFlowNo.HeaderText = "流程编号";
            this.colWorkFlowNo.Name = "colWorkFlowNo";
            this.colWorkFlowNo.Width = 200;
            // 
            // colFlowInsCaption
            // 
            this.colFlowInsCaption.DataPropertyName = "FlowInsCaption";
            this.colFlowInsCaption.HeaderText = "流程实例名";
            this.colFlowInsCaption.Name = "colFlowInsCaption";
            this.colFlowInsCaption.Width = 260;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "StartTime";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.colStartTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colStartTime.HeaderText = "开始时间";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Width = 200;
            // 
            // colEndTime
            // 
            this.colEndTime.DataPropertyName = "EndTime";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.colEndTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colEndTime.HeaderText = "结束时间";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "STATUS";
            this.colStatus.HeaderText = "当前状态";
            this.colStatus.Name = "colStatus";
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "说明";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.lblStatus3);
            this.panel6.Controls.Add(this.lblStatus2);
            this.panel6.Controls.Add(this.lblStatus1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(796, 34);
            this.panel6.TabIndex = 10;
            // 
            // lblStatus3
            // 
            this.lblStatus3.AutoEllipsis = true;
            this.lblStatus3.BackColor = System.Drawing.Color.Green;
            this.lblStatus3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus3.ForeColor = System.Drawing.Color.White;
            this.lblStatus3.Location = new System.Drawing.Point(244, 10);
            this.lblStatus3.Name = "lblStatus3";
            this.lblStatus3.Size = new System.Drawing.Size(99, 14);
            this.lblStatus3.TabIndex = 2;
            this.lblStatus3.Text = "正常结束";
            this.lblStatus3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus2
            // 
            this.lblStatus2.AutoEllipsis = true;
            this.lblStatus2.BackColor = System.Drawing.Color.Red;
            this.lblStatus2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus2.ForeColor = System.Drawing.Color.White;
            this.lblStatus2.Location = new System.Drawing.Point(131, 10);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(99, 14);
            this.lblStatus2.TabIndex = 1;
            this.lblStatus2.Text = "正在办理";
            this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus1
            // 
            this.lblStatus1.AutoEllipsis = true;
            this.lblStatus1.BackColor = System.Drawing.Color.Orange;
            this.lblStatus1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStatus1.ForeColor = System.Drawing.Color.White;
            this.lblStatus1.Location = new System.Drawing.Point(20, 10);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(99, 14);
            this.lblStatus1.TabIndex = 0;
            this.lblStatus1.Text = "还未执行";
            this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ucPager);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 522);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(796, 31);
            this.panel5.TabIndex = 9;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(283, 5);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(507, 20);
            this.ucPager.TabIndex = 1;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.rbLikeSearch);
            this.panel3.Controls.Add(this.rbExactSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 256);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 65);
            this.panel3.TabIndex = 4;
            // 
            // rbLikeSearch
            // 
            this.rbLikeSearch.AutoSize = true;
            this.rbLikeSearch.Checked = true;
            this.rbLikeSearch.Location = new System.Drawing.Point(13, 36);
            this.rbLikeSearch.Name = "rbLikeSearch";
            this.rbLikeSearch.Size = new System.Drawing.Size(53, 18);
            this.rbLikeSearch.TabIndex = 12;
            this.rbLikeSearch.TabStop = true;
            this.rbLikeSearch.Text = "模糊";
            this.rbLikeSearch.UseVisualStyleBackColor = true;
            // 
            // rbExactSearch
            // 
            this.rbExactSearch.AutoSize = true;
            this.rbExactSearch.Location = new System.Drawing.Point(13, 12);
            this.rbExactSearch.Name = "rbExactSearch";
            this.rbExactSearch.Size = new System.Drawing.Size(53, 18);
            this.rbExactSearch.TabIndex = 11;
            this.rbExactSearch.Text = "精确";
            this.rbExactSearch.UseVisualStyleBackColor = true;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel3);
            this.gbCustomSearch.Controls.Add(this.gbWorkFlowStatus);
            this.gbCustomSearch.Controls.Add(this.panel4);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 542);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "常规搜索";
            // 
            // gbWorkFlowStatus
            // 
            this.gbWorkFlowStatus.Controls.Add(this.rbWFAll);
            this.gbWorkFlowStatus.Controls.Add(this.rbWFCompleted);
            this.gbWorkFlowStatus.Controls.Add(this.rbWFRunning);
            this.gbWorkFlowStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbWorkFlowStatus.Location = new System.Drawing.Point(3, 164);
            this.gbWorkFlowStatus.Name = "gbWorkFlowStatus";
            this.gbWorkFlowStatus.Size = new System.Drawing.Size(182, 92);
            this.gbWorkFlowStatus.TabIndex = 12;
            this.gbWorkFlowStatus.TabStop = false;
            this.gbWorkFlowStatus.Text = "流程状态";
            // 
            // rbWFAll
            // 
            this.rbWFAll.AutoSize = true;
            this.rbWFAll.Location = new System.Drawing.Point(23, 71);
            this.rbWFAll.Name = "rbWFAll";
            this.rbWFAll.Size = new System.Drawing.Size(71, 16);
            this.rbWFAll.TabIndex = 2;
            this.rbWFAll.TabStop = true;
            this.rbWFAll.Text = "所有状态";
            this.rbWFAll.UseVisualStyleBackColor = true;
            // 
            // rbWFCompleted
            // 
            this.rbWFCompleted.AutoSize = true;
            this.rbWFCompleted.Location = new System.Drawing.Point(23, 47);
            this.rbWFCompleted.Name = "rbWFCompleted";
            this.rbWFCompleted.Size = new System.Drawing.Size(71, 16);
            this.rbWFCompleted.TabIndex = 1;
            this.rbWFCompleted.TabStop = true;
            this.rbWFCompleted.Text = "已经完成";
            this.rbWFCompleted.UseVisualStyleBackColor = true;
            // 
            // rbWFRunning
            // 
            this.rbWFRunning.AutoSize = true;
            this.rbWFRunning.Location = new System.Drawing.Point(23, 23);
            this.rbWFRunning.Name = "rbWFRunning";
            this.rbWFRunning.Size = new System.Drawing.Size(71, 16);
            this.rbWFRunning.TabIndex = 0;
            this.rbWFRunning.TabStop = true;
            this.rbWFRunning.Text = "正在运行";
            this.rbWFRunning.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtEndTime);
            this.panel4.Controls.Add(this.dtStartTime);
            this.panel4.Controls.Add(this.lblTo);
            this.panel4.Controls.Add(this.lblStartTime);
            this.panel4.Controls.Add(this.txtWFFullName);
            this.panel4.Controls.Add(this.lblBizName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 145);
            this.panel4.TabIndex = 3;
            // 
            // dtEndTime
            // 
            this.dtEndTime.Location = new System.Drawing.Point(39, 111);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(136, 23);
            this.dtEndTime.TabIndex = 10;
            // 
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(39, 68);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(136, 23);
            this.dtStartTime.TabIndex = 9;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(4, 94);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(35, 14);
            this.lblTo.TabIndex = 8;
            this.lblTo.Text = "至：";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(3, 51);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(77, 14);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "发起时间：";
            // 
            // txtWFFullName
            // 
            // 
            // 
            // 
            this.txtWFFullName.Border.Class = "TextBoxBorder";
            this.txtWFFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWFFullName.FocusHighlightEnabled = true;
            this.txtWFFullName.Location = new System.Drawing.Point(9, 24);
            this.txtWFFullName.Name = "txtWFFullName";
            this.txtWFFullName.SelectedValue = null;
            this.txtWFFullName.Size = new System.Drawing.Size(166, 23);
            this.txtWFFullName.TabIndex = 4;
            // 
            // lblBizName
            // 
            this.lblBizName.AutoSize = true;
            this.lblBizName.Location = new System.Drawing.Point(9, 5);
            this.lblBizName.Name = "lblBizName";
            this.lblBizName.Size = new System.Drawing.Size(77, 14);
            this.lblBizName.TabIndex = 2;
            this.lblBizName.Text = "业务名称：";
            // 
            // tabItemSearch
            // 
            this.tabItemSearch.AttachedControl = this.tabControlPanel3;
            this.tabItemSearch.Name = "tabItemSearch";
            this.tabItemSearch.Text = "搜索";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 552);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItemSearch;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(201, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 26);
            this.panel1.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnViewWFStatus,
            this.btnProcessStep,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnViewWFStatus
            // 
            this.btnViewWFStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnViewWFStatus.Image")));
            this.btnViewWFStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewWFStatus.Name = "btnViewWFStatus";
            this.btnViewWFStatus.Size = new System.Drawing.Size(111, 22);
            this.btnViewWFStatus.Text = "查看流程状态";
            this.btnViewWFStatus.Click += new System.EventHandler(this.btnViewWFStatus_Click);
            // 
            // btnProcessStep
            // 
            this.btnProcessStep.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessStep.Image")));
            this.btnProcessStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcessStep.Name = "btnProcessStep";
            this.btnProcessStep.Size = new System.Drawing.Size(83, 22);
            this.btnProcessStep.Text = "处理记录";
            this.btnProcessStep.Click += new System.EventHandler(this.btnProcessStep_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControlStaffAdmin
            // 
            this.tabControlStaffAdmin.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlStaffAdmin.CanReorderTabs = true;
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel3);
            this.tabControlStaffAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlStaffAdmin.Location = new System.Drawing.Point(3, 0);
            this.tabControlStaffAdmin.Name = "tabControlStaffAdmin";
            this.tabControlStaffAdmin.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlStaffAdmin.SelectedTabIndex = 0;
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(198, 579);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 14;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemSearch);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 579);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // FrmWorkFlowMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 579);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.Controls.Add(this.splitter1);
            this.Name = "FrmWorkFlowMonitor";
            this.Text = "流程监控";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkFlowMonitor)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.gbCustomSearch.ResumeLayout(false);
            this.gbWorkFlowStatus.ResumeLayout(false);
            this.gbWorkFlowStatus.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControlPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcButton btnSearch;
        private System.Windows.Forms.Panel panel2;
        private Controls.UcDataGridView dgvWorkFlowMonitor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbLikeSearch;
        private System.Windows.Forms.RadioButton rbExactSearch;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblStartTime;
        private Controls.UcTextBox txtWFFullName;
        private System.Windows.Forms.Label lblBizName;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnViewWFStatus;
        private System.Windows.Forms.ToolStripButton btnProcessStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox gbWorkFlowStatus;
        private System.Windows.Forms.RadioButton rbWFCompleted;
        private System.Windows.Forms.RadioButton rbWFRunning;
        private System.Windows.Forms.Panel panel5;
        private Controls.UcPagerEx ucPager;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkFlowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlowInsCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.RadioButton rbWFAll;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Label lblStatus3;
    }
}