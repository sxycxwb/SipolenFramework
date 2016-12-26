namespace RDIFramework.WorkFlow
{
    partial class FrmProcessingTaskCommon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcessingTaskCommon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.epanelBizInfo = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtBizUser = new RDIFramework.Controls.UcTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtBizTime = new RDIFramework.Controls.UcTextBox(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtBizTaskCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBizWorkFlowDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtBizWorkFlowNo = new RDIFramework.Controls.UcTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtBizWorkFlowName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.epanelBackCause = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgvBackCause = new RDIFramework.Controls.UcDataGridView();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbackyy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbacktime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epanelWFHistory = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgvAuditHistory = new RDIFramework.Controls.UcDataGridView();
            this.colTaskCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperatedDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTASKENDTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epanelWFInfo = new DevComponents.DotNetBar.ExpandablePanel();
            this.txtTaskName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtWorkFlowName = new RDIFramework.Controls.UcTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtBizPriority = new RDIFramework.Controls.UcTextBox(this.components);
            this.panel1.SuspendLayout();
            this.epanelBizInfo.SuspendLayout();
            this.epanelBackCause.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackCause)).BeginInit();
            this.epanelWFHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditHistory)).BeginInit();
            this.epanelWFInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.epanelBizInfo);
            this.panel1.Controls.Add(this.epanelBackCause);
            this.panel1.Controls.Add(this.epanelWFHistory);
            this.panel1.Controls.Add(this.epanelWFInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 585);
            this.panel1.TabIndex = 0;
            // 
            // epanelBizInfo
            // 
            this.epanelBizInfo.AutoScroll = true;
            this.epanelBizInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.epanelBizInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.epanelBizInfo.Controls.Add(this.txtBizPriority);
            this.epanelBizInfo.Controls.Add(this.txtBizUser);
            this.epanelBizInfo.Controls.Add(this.label9);
            this.epanelBizInfo.Controls.Add(this.txtBizTime);
            this.epanelBizInfo.Controls.Add(this.label8);
            this.epanelBizInfo.Controls.Add(this.txtBizTaskCaption);
            this.epanelBizInfo.Controls.Add(this.label7);
            this.epanelBizInfo.Controls.Add(this.label5);
            this.epanelBizInfo.Controls.Add(this.txtBizWorkFlowDescription);
            this.epanelBizInfo.Controls.Add(this.label6);
            this.epanelBizInfo.Controls.Add(this.txtBizWorkFlowNo);
            this.epanelBizInfo.Controls.Add(this.label3);
            this.epanelBizInfo.Controls.Add(this.txtBizWorkFlowName);
            this.epanelBizInfo.Controls.Add(this.label4);
            this.epanelBizInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.epanelBizInfo.ExpandOnTitleClick = true;
            this.epanelBizInfo.Location = new System.Drawing.Point(0, 455);
            this.epanelBizInfo.Name = "epanelBizInfo";
            this.epanelBizInfo.Size = new System.Drawing.Size(846, 130);
            this.epanelBizInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.epanelBizInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelBizInfo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelBizInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.epanelBizInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.epanelBizInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.epanelBizInfo.Style.GradientAngle = 90;
            this.epanelBizInfo.TabIndex = 3;
            this.epanelBizInfo.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelBizInfo.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelBizInfo.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.epanelBizInfo.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epanelBizInfo.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epanelBizInfo.TitleStyle.GradientAngle = 90;
            this.epanelBizInfo.TitleText = "业务信息";
            // 
            // txtBizUser
            // 
            // 
            // 
            // 
            this.txtBizUser.Border.Class = "TextBoxBorder";
            this.txtBizUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizUser.FocusHighlightEnabled = true;
            this.txtBizUser.Location = new System.Drawing.Point(101, 66);
            this.txtBizUser.Name = "txtBizUser";
            this.txtBizUser.SelectedValue = ((object)(resources.GetObject("txtBizUser.SelectedValue")));
            this.txtBizUser.Size = new System.Drawing.Size(213, 23);
            this.txtBizUser.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "提交人：";
            // 
            // txtBizTime
            // 
            // 
            // 
            // 
            this.txtBizTime.Border.Class = "TextBoxBorder";
            this.txtBizTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizTime.FocusHighlightEnabled = true;
            this.txtBizTime.Location = new System.Drawing.Point(657, 37);
            this.txtBizTime.Name = "txtBizTime";
            this.txtBizTime.SelectedValue = ((object)(resources.GetObject("txtBizTime.SelectedValue")));
            this.txtBizTime.Size = new System.Drawing.Size(177, 23);
            this.txtBizTime.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(585, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 22;
            this.label8.Text = "到达时间：";
            // 
            // txtBizTaskCaption
            // 
            // 
            // 
            // 
            this.txtBizTaskCaption.Border.Class = "TextBoxBorder";
            this.txtBizTaskCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizTaskCaption.FocusHighlightEnabled = true;
            this.txtBizTaskCaption.Location = new System.Drawing.Point(396, 37);
            this.txtBizTaskCaption.Name = "txtBizTaskCaption";
            this.txtBizTaskCaption.SelectedValue = ((object)(resources.GetObject("txtBizTaskCaption.SelectedValue")));
            this.txtBizTaskCaption.Size = new System.Drawing.Size(177, 23);
            this.txtBizTaskCaption.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "任务名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(585, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "紧急程度：";
            // 
            // txtBizWorkFlowDescription
            // 
            // 
            // 
            // 
            this.txtBizWorkFlowDescription.Border.Class = "TextBoxBorder";
            this.txtBizWorkFlowDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizWorkFlowDescription.FocusHighlightEnabled = true;
            this.txtBizWorkFlowDescription.Location = new System.Drawing.Point(101, 94);
            this.txtBizWorkFlowDescription.Name = "txtBizWorkFlowDescription";
            this.txtBizWorkFlowDescription.SelectedValue = ((object)(resources.GetObject("txtBizWorkFlowDescription.SelectedValue")));
            this.txtBizWorkFlowDescription.Size = new System.Drawing.Size(733, 23);
            this.txtBizWorkFlowDescription.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "流程说明：";
            // 
            // txtBizWorkFlowNo
            // 
            // 
            // 
            // 
            this.txtBizWorkFlowNo.Border.Class = "TextBoxBorder";
            this.txtBizWorkFlowNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizWorkFlowNo.FocusHighlightEnabled = true;
            this.txtBizWorkFlowNo.Location = new System.Drawing.Point(396, 66);
            this.txtBizWorkFlowNo.Name = "txtBizWorkFlowNo";
            this.txtBizWorkFlowNo.SelectedValue = ((object)(resources.GetObject("txtBizWorkFlowNo.SelectedValue")));
            this.txtBizWorkFlowNo.Size = new System.Drawing.Size(177, 23);
            this.txtBizWorkFlowNo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "流程编号：";
            // 
            // txtBizWorkFlowName
            // 
            // 
            // 
            // 
            this.txtBizWorkFlowName.Border.Class = "TextBoxBorder";
            this.txtBizWorkFlowName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizWorkFlowName.FocusHighlightEnabled = true;
            this.txtBizWorkFlowName.Location = new System.Drawing.Point(101, 37);
            this.txtBizWorkFlowName.Name = "txtBizWorkFlowName";
            this.txtBizWorkFlowName.SelectedValue = ((object)(resources.GetObject("txtBizWorkFlowName.SelectedValue")));
            this.txtBizWorkFlowName.Size = new System.Drawing.Size(213, 23);
            this.txtBizWorkFlowName.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "流程业务名：";
            // 
            // epanelBackCause
            // 
            this.epanelBackCause.AutoScroll = true;
            this.epanelBackCause.CanvasColor = System.Drawing.SystemColors.Control;
            this.epanelBackCause.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.epanelBackCause.Controls.Add(this.dgvBackCause);
            this.epanelBackCause.Dock = System.Windows.Forms.DockStyle.Top;
            this.epanelBackCause.ExpandOnTitleClick = true;
            this.epanelBackCause.Location = new System.Drawing.Point(0, 260);
            this.epanelBackCause.Name = "epanelBackCause";
            this.epanelBackCause.Size = new System.Drawing.Size(846, 195);
            this.epanelBackCause.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.epanelBackCause.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelBackCause.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelBackCause.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.epanelBackCause.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.epanelBackCause.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.epanelBackCause.Style.GradientAngle = 90;
            this.epanelBackCause.TabIndex = 2;
            this.epanelBackCause.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelBackCause.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelBackCause.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.epanelBackCause.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epanelBackCause.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epanelBackCause.TitleStyle.GradientAngle = 90;
            this.epanelBackCause.TitleText = "退回原因";
            // 
            // dgvBackCause
            // 
            this.dgvBackCause.AllowUserToAddRows = false;
            this.dgvBackCause.AllowUserToDeleteRows = false;
            this.dgvBackCause.AllowUserToOrderColumns = true;
            this.dgvBackCause.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBackCause.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBackCause.ColumnHeadersHeight = 26;
            this.dgvBackCause.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBackCause.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserId,
            this.colbackyy,
            this.colbacktime});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBackCause.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvBackCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBackCause.EnableHeadersVisualStyles = false;
            this.dgvBackCause.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvBackCause.Location = new System.Drawing.Point(0, 26);
            this.dgvBackCause.Name = "dgvBackCause";
            this.dgvBackCause.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBackCause.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvBackCause.RowHeadersWidth = 30;
            this.dgvBackCause.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBackCause.RowTemplate.Height = 23;
            this.dgvBackCause.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBackCause.Size = new System.Drawing.Size(846, 169);
            this.dgvBackCause.TabIndex = 8;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "UserId";
            this.colUserId.HeaderText = "退回人";
            this.colUserId.Name = "colUserId";
            this.colUserId.Width = 300;
            // 
            // colbackyy
            // 
            this.colbackyy.DataPropertyName = "backyy";
            this.colbackyy.HeaderText = "退回原因";
            this.colbackyy.Name = "colbackyy";
            this.colbackyy.Width = 300;
            // 
            // colbacktime
            // 
            this.colbacktime.DataPropertyName = "backtime";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colbacktime.DefaultCellStyle = dataGridViewCellStyle10;
            this.colbacktime.HeaderText = "退回时间";
            this.colbacktime.Name = "colbacktime";
            this.colbacktime.Width = 200;
            // 
            // epanelWFHistory
            // 
            this.epanelWFHistory.AutoScroll = true;
            this.epanelWFHistory.CanvasColor = System.Drawing.SystemColors.Control;
            this.epanelWFHistory.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.epanelWFHistory.Controls.Add(this.dgvAuditHistory);
            this.epanelWFHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.epanelWFHistory.ExpandOnTitleClick = true;
            this.epanelWFHistory.Location = new System.Drawing.Point(0, 65);
            this.epanelWFHistory.Name = "epanelWFHistory";
            this.epanelWFHistory.Size = new System.Drawing.Size(846, 195);
            this.epanelWFHistory.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.epanelWFHistory.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelWFHistory.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelWFHistory.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.epanelWFHistory.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.epanelWFHistory.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.epanelWFHistory.Style.GradientAngle = 90;
            this.epanelWFHistory.TabIndex = 1;
            this.epanelWFHistory.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelWFHistory.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelWFHistory.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.epanelWFHistory.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epanelWFHistory.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epanelWFHistory.TitleStyle.GradientAngle = 90;
            this.epanelWFHistory.TitleText = "流程历史";
            // 
            // dgvAuditHistory
            // 
            this.dgvAuditHistory.AllowUserToAddRows = false;
            this.dgvAuditHistory.AllowUserToDeleteRows = false;
            this.dgvAuditHistory.AllowUserToOrderColumns = true;
            this.dgvAuditHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvAuditHistory.ColumnHeadersHeight = 26;
            this.dgvAuditHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAuditHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaskCaption,
            this.colOperatedDes,
            this.colTASKENDTIME});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditHistory.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvAuditHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditHistory.EnableHeadersVisualStyles = false;
            this.dgvAuditHistory.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvAuditHistory.Location = new System.Drawing.Point(0, 26);
            this.dgvAuditHistory.Name = "dgvAuditHistory";
            this.dgvAuditHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvAuditHistory.RowHeadersWidth = 30;
            this.dgvAuditHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAuditHistory.RowTemplate.Height = 23;
            this.dgvAuditHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAuditHistory.Size = new System.Drawing.Size(846, 169);
            this.dgvAuditHistory.TabIndex = 8;
            // 
            // colTaskCaption
            // 
            this.colTaskCaption.DataPropertyName = "TaskCaption";
            this.colTaskCaption.HeaderText = "任务名";
            this.colTaskCaption.Name = "colTaskCaption";
            this.colTaskCaption.Width = 300;
            // 
            // colOperatedDes
            // 
            this.colOperatedDes.DataPropertyName = "OperatedDes";
            this.colOperatedDes.HeaderText = "处理人";
            this.colOperatedDes.Name = "colOperatedDes";
            this.colOperatedDes.Width = 300;
            // 
            // colTASKENDTIME
            // 
            this.colTASKENDTIME.DataPropertyName = "TASKENDTIME";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colTASKENDTIME.DefaultCellStyle = dataGridViewCellStyle14;
            this.colTASKENDTIME.HeaderText = "处理时间";
            this.colTASKENDTIME.Name = "colTASKENDTIME";
            this.colTASKENDTIME.Width = 200;
            // 
            // epanelWFInfo
            // 
            this.epanelWFInfo.AutoScroll = true;
            this.epanelWFInfo.CanvasColor = System.Drawing.SystemColors.Control;
            this.epanelWFInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.epanelWFInfo.Controls.Add(this.txtTaskName);
            this.epanelWFInfo.Controls.Add(this.label2);
            this.epanelWFInfo.Controls.Add(this.txtWorkFlowName);
            this.epanelWFInfo.Controls.Add(this.label1);
            this.epanelWFInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.epanelWFInfo.ExpandOnTitleClick = true;
            this.epanelWFInfo.Location = new System.Drawing.Point(0, 0);
            this.epanelWFInfo.Name = "epanelWFInfo";
            this.epanelWFInfo.Size = new System.Drawing.Size(846, 65);
            this.epanelWFInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.epanelWFInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelWFInfo.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelWFInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.epanelWFInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.epanelWFInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.epanelWFInfo.Style.GradientAngle = 90;
            this.epanelWFInfo.TabIndex = 0;
            this.epanelWFInfo.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.epanelWFInfo.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.epanelWFInfo.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.epanelWFInfo.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.epanelWFInfo.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.epanelWFInfo.TitleStyle.GradientAngle = 90;
            this.epanelWFInfo.TitleText = "流程信息";
            // 
            // txtTaskName
            // 
            // 
            // 
            // 
            this.txtTaskName.Border.Class = "TextBoxBorder";
            this.txtTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTaskName.FocusHighlightEnabled = true;
            this.txtTaskName.Location = new System.Drawing.Point(479, 36);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.SelectedValue = ((object)(resources.GetObject("txtTaskName.SelectedValue")));
            this.txtTaskName.Size = new System.Drawing.Size(319, 23);
            this.txtTaskName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "任务模版：";
            // 
            // txtWorkFlowName
            // 
            // 
            // 
            // 
            this.txtWorkFlowName.Border.Class = "TextBoxBorder";
            this.txtWorkFlowName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWorkFlowName.FocusHighlightEnabled = true;
            this.txtWorkFlowName.Location = new System.Drawing.Point(101, 36);
            this.txtWorkFlowName.Name = "txtWorkFlowName";
            this.txtWorkFlowName.SelectedValue = ((object)(resources.GetObject("txtWorkFlowName.SelectedValue")));
            this.txtWorkFlowName.Size = new System.Drawing.Size(300, 23);
            this.txtWorkFlowName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "流程模版：";
            // 
            // txtBizPriority
            // 
            // 
            // 
            // 
            this.txtBizPriority.Border.Class = "TextBoxBorder";
            this.txtBizPriority.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBizPriority.FocusHighlightEnabled = true;
            this.txtBizPriority.Location = new System.Drawing.Point(657, 65);
            this.txtBizPriority.Name = "txtBizPriority";
            this.txtBizPriority.SelectedValue = ((object)(resources.GetObject("txtBizPriority.SelectedValue")));
            this.txtBizPriority.Size = new System.Drawing.Size(177, 23);
            this.txtBizPriority.TabIndex = 26;
            // 
            // FrmProcessingTaskCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 585);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProcessingTaskCommon";
            this.Text = "FrmProcessingTaskCommon";
            this.panel1.ResumeLayout(false);
            this.epanelBizInfo.ResumeLayout(false);
            this.epanelBizInfo.PerformLayout();
            this.epanelBackCause.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackCause)).EndInit();
            this.epanelWFHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditHistory)).EndInit();
            this.epanelWFInfo.ResumeLayout(false);
            this.epanelWFInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ExpandablePanel epanelWFInfo;
        private Controls.UcTextBox txtTaskName;
        private System.Windows.Forms.Label label2;
        private Controls.UcTextBox txtWorkFlowName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ExpandablePanel epanelWFHistory;
        private Controls.UcDataGridView dgvAuditHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaskCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperatedDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTASKENDTIME;
        private DevComponents.DotNetBar.ExpandablePanel epanelBackCause;
        private Controls.UcDataGridView dgvBackCause;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbackyy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbacktime;
        private DevComponents.DotNetBar.ExpandablePanel epanelBizInfo;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtBizWorkFlowDescription;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox txtBizWorkFlowNo;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox txtBizWorkFlowName;
        private System.Windows.Forms.Label label4;
        private Controls.UcTextBox txtBizTaskCaption;
        private System.Windows.Forms.Label label7;
        private Controls.UcTextBox txtBizTime;
        private System.Windows.Forms.Label label8;
        private Controls.UcTextBox txtBizUser;
        private System.Windows.Forms.Label label9;
        private Controls.UcTextBox txtBizPriority;
    }
}