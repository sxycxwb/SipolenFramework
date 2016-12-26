namespace RDIFramework.WorkFlow
{
    partial class FrmToDoTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToDoTask));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHandleTask = new System.Windows.Forms.ToolStripButton();
            this.btnUnClaim = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewWFChart = new System.Windows.Forms.ToolStripButton();
            this.btnProcessStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.dgvToDoTask = new RDIFramework.Controls.UcDataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWorkFlowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFlowInsCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltaskStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaskInsCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpOperatedDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.tabControlStaffAdmin = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.gbCustomSearch = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.rbLikeSearch = new System.Windows.Forms.RadioButton();
            this.rbExactSearch = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtToStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblTaskTime = new System.Windows.Forms.Label();
            this.txtWFInsFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblBizName = new System.Windows.Forms.Label();
            this.tabItemSearch = new DevComponents.DotNetBar.TabItem(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToDoTask)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).BeginInit();
            this.tabControlStaffAdmin.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.gbCustomSearch.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(201, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 26);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHandleTask,
            this.btnUnClaim,
            this.toolStripSeparator2,
            this.btnViewWFChart,
            this.btnProcessStep,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(746, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnHandleTask
            // 
            this.btnHandleTask.Image = ((System.Drawing.Image)(resources.GetObject("btnHandleTask.Image")));
            this.btnHandleTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHandleTask.Name = "btnHandleTask";
            this.btnHandleTask.Size = new System.Drawing.Size(83, 22);
            this.btnHandleTask.Text = "处理任务";
            this.btnHandleTask.Click += new System.EventHandler(this.btnHandleTask_Click);
            // 
            // btnUnClaim
            // 
            this.btnUnClaim.Image = ((System.Drawing.Image)(resources.GetObject("btnUnClaim.Image")));
            this.btnUnClaim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnClaim.Name = "btnUnClaim";
            this.btnUnClaim.Size = new System.Drawing.Size(83, 22);
            this.btnUnClaim.Text = "放弃认领";
            this.btnUnClaim.Click += new System.EventHandler(this.btnUnClaim_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewWFChart
            // 
            this.btnViewWFChart.Image = ((System.Drawing.Image)(resources.GetObject("btnViewWFChart.Image")));
            this.btnViewWFChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewWFChart.Name = "btnViewWFChart";
            this.btnViewWFChart.Size = new System.Drawing.Size(97, 22);
            this.btnViewWFChart.Text = "查看流程图";
            this.btnViewWFChart.Click += new System.EventHandler(this.btnViewWFChart_Click);
            // 
            // btnProcessStep
            // 
            this.btnProcessStep.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessStep.Image")));
            this.btnProcessStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcessStep.Name = "btnProcessStep";
            this.btnProcessStep.Size = new System.Drawing.Size(83, 22);
            this.btnProcessStep.Text = "处理记录";
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
            // dgvToDoTask
            // 
            this.dgvToDoTask.AllowUserToAddRows = false;
            this.dgvToDoTask.AllowUserToDeleteRows = false;
            this.dgvToDoTask.AllowUserToOrderColumns = true;
            this.dgvToDoTask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToDoTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvToDoTask.ColumnHeadersHeight = 26;
            this.dgvToDoTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvToDoTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colWorkFlowNo,
            this.colFlowInsCaption,
            this.coltaskStartTime,
            this.colTaskInsCaption,
            this.colpOperatedDes,
            this.colStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvToDoTask.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvToDoTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvToDoTask.EnableHeadersVisualStyles = false;
            this.dgvToDoTask.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvToDoTask.Location = new System.Drawing.Point(0, 0);
            this.dgvToDoTask.Name = "dgvToDoTask";
            this.dgvToDoTask.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToDoTask.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvToDoTask.RowHeadersWidth = 30;
            this.dgvToDoTask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvToDoTask.RowTemplate.Height = 23;
            this.dgvToDoTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToDoTask.Size = new System.Drawing.Size(746, 473);
            this.dgvToDoTask.TabIndex = 8;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "colSelected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Visible = false;
            this.colSelected.Width = 45;
            // 
            // colWorkFlowNo
            // 
            this.colWorkFlowNo.DataPropertyName = "WorkFlowNo";
            this.colWorkFlowNo.HeaderText = "流程编号";
            this.colWorkFlowNo.Name = "colWorkFlowNo";
            this.colWorkFlowNo.Width = 150;
            // 
            // colFlowInsCaption
            // 
            this.colFlowInsCaption.DataPropertyName = "FlowInsCaption";
            this.colFlowInsCaption.HeaderText = "流程实例名";
            this.colFlowInsCaption.Name = "colFlowInsCaption";
            this.colFlowInsCaption.Width = 260;
            // 
            // coltaskStartTime
            // 
            this.coltaskStartTime.DataPropertyName = "taskStartTime";
            this.coltaskStartTime.HeaderText = "任务到达时间";
            this.coltaskStartTime.Name = "coltaskStartTime";
            this.coltaskStartTime.Width = 200;
            // 
            // colTaskInsCaption
            // 
            this.colTaskInsCaption.DataPropertyName = "TaskInsCaption";
            this.colTaskInsCaption.HeaderText = "任务名称";
            this.colTaskInsCaption.Name = "colTaskInsCaption";
            this.colTaskInsCaption.Width = 200;
            // 
            // colpOperatedDes
            // 
            this.colpOperatedDes.DataPropertyName = "pOperatedDes";
            this.colpOperatedDes.HeaderText = "任务提交人";
            this.colpOperatedDes.Name = "colpOperatedDes";
            this.colpOperatedDes.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "任务类型";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvToDoTask);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(201, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 504);
            this.panel2.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ucPager);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 473);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(746, 31);
            this.panel5.TabIndex = 11;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(233, 5);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(507, 20);
            this.ucPager.TabIndex = 1;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // tabControlStaffAdmin
            // 
            this.tabControlStaffAdmin.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlStaffAdmin.CanReorderTabs = true;
            this.tabControlStaffAdmin.Controls.Add(this.tabControlPanel3);
            this.tabControlStaffAdmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControlStaffAdmin.Location = new System.Drawing.Point(0, 0);
            this.tabControlStaffAdmin.Name = "tabControlStaffAdmin";
            this.tabControlStaffAdmin.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlStaffAdmin.SelectedTabIndex = 0;
            this.tabControlStaffAdmin.Size = new System.Drawing.Size(198, 530);
            this.tabControlStaffAdmin.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tabControlStaffAdmin.TabIndex = 10;
            this.tabControlStaffAdmin.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControlStaffAdmin.Tabs.Add(this.tabItemSearch);
            this.tabControlStaffAdmin.Text = "tabControl2";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.gbCustomSearch);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tabControlPanel3.Size = new System.Drawing.Size(198, 503);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 2;
            this.tabControlPanel3.TabItem = this.tabItemSearch;
            // 
            // gbCustomSearch
            // 
            this.gbCustomSearch.BackColor = System.Drawing.Color.White;
            this.gbCustomSearch.Controls.Add(this.panel3);
            this.gbCustomSearch.Controls.Add(this.panel4);
            this.gbCustomSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomSearch.Location = new System.Drawing.Point(5, 5);
            this.gbCustomSearch.Name = "gbCustomSearch";
            this.gbCustomSearch.Size = new System.Drawing.Size(188, 493);
            this.gbCustomSearch.TabIndex = 0;
            this.gbCustomSearch.TabStop = false;
            this.gbCustomSearch.Text = "常规搜索";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.rbLikeSearch);
            this.panel3.Controls.Add(this.rbExactSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 65);
            this.panel3.TabIndex = 4;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.dtToStartDate);
            this.panel4.Controls.Add(this.dtFromStartDate);
            this.panel4.Controls.Add(this.lblTo);
            this.panel4.Controls.Add(this.lblTaskTime);
            this.panel4.Controls.Add(this.txtWFInsFullName);
            this.panel4.Controls.Add(this.lblBizName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 147);
            this.panel4.TabIndex = 3;
            // 
            // dtToStartDate
            // 
            this.dtToStartDate.Location = new System.Drawing.Point(39, 111);
            this.dtToStartDate.Name = "dtToStartDate";
            this.dtToStartDate.Size = new System.Drawing.Size(136, 23);
            this.dtToStartDate.TabIndex = 10;
            // 
            // dtFromStartDate
            // 
            this.dtFromStartDate.Location = new System.Drawing.Point(39, 68);
            this.dtFromStartDate.Name = "dtFromStartDate";
            this.dtFromStartDate.Size = new System.Drawing.Size(136, 23);
            this.dtFromStartDate.TabIndex = 9;
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
            // lblTaskTime
            // 
            this.lblTaskTime.AutoSize = true;
            this.lblTaskTime.Location = new System.Drawing.Point(3, 51);
            this.lblTaskTime.Name = "lblTaskTime";
            this.lblTaskTime.Size = new System.Drawing.Size(77, 14);
            this.lblTaskTime.TabIndex = 6;
            this.lblTaskTime.Text = "任务时间：";
            // 
            // txtWFInsFullName
            // 
            // 
            // 
            // 
            this.txtWFInsFullName.Border.Class = "TextBoxBorder";
            this.txtWFInsFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWFInsFullName.FocusHighlightEnabled = true;
            this.txtWFInsFullName.Location = new System.Drawing.Point(9, 24);
            this.txtWFInsFullName.Name = "txtWFInsFullName";
            this.txtWFInsFullName.SelectedValue = null;
            this.txtWFInsFullName.Size = new System.Drawing.Size(166, 23);
            this.txtWFInsFullName.TabIndex = 4;
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 530);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // FrmToDoTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControlStaffAdmin);
            this.Name = "FrmToDoTask";
            this.Text = "待办任务";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToDoTask)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlStaffAdmin)).EndInit();
            this.tabControlStaffAdmin.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.gbCustomSearch.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.UcDataGridView dgvToDoTask;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkFlowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFlowInsCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltaskStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskInsCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpOperatedDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private DevComponents.DotNetBar.TabControl tabControlStaffAdmin;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.GroupBox gbCustomSearch;
        private System.Windows.Forms.Panel panel3;
        private Controls.UcButton btnSearch;
        private System.Windows.Forms.RadioButton rbLikeSearch;
        private System.Windows.Forms.RadioButton rbExactSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblBizName;
        private DevComponents.DotNetBar.TabItem tabItemSearch;
        private Controls.UcTextBox txtWFInsFullName;
        private System.Windows.Forms.DateTimePicker dtToStartDate;
        private System.Windows.Forms.DateTimePicker dtFromStartDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblTaskTime;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHandleTask;
        private System.Windows.Forms.ToolStripButton btnViewWFChart;
        private System.Windows.Forms.ToolStripButton btnProcessStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel panel5;
        private Controls.UcPagerEx ucPager;
        private System.Windows.Forms.ToolStripButton btnUnClaim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}