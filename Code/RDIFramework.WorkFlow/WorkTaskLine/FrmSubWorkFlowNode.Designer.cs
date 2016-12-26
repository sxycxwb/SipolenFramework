namespace RDIFramework.WorkFlow
{
    partial class FrmSubWorkFlowNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubWorkFlowNode));
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.lblStartNode = new System.Windows.Forms.Label();
            this.cbxStartTasks = new System.Windows.Forms.ComboBox();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.tbxTaskDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxWorkflowCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSelectWf = new RDIFramework.Controls.UcButton();
            this.lblSubFlowName = new System.Windows.Forms.Label();
            this.tabItemGeneral = new DevComponents.DotNetBar.TabItem(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tcUser);
            this.plclassFill.Location = new System.Drawing.Point(3, 3);
            this.plclassFill.Size = new System.Drawing.Size(442, 210);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(3, 151);
            this.plclassBottom.Size = new System.Drawing.Size(442, 62);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(340, 18);
            this.btnClose.Size = new System.Drawing.Size(85, 27);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(247, 18);
            this.btnSave.Size = new System.Drawing.Size(85, 27);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUser.Location = new System.Drawing.Point(0, 0);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(442, 210);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 23;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemGeneral);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lblStartNode);
            this.tabControlPanel2.Controls.Add(this.cbxStartTasks);
            this.tabControlPanel2.Controls.Add(this.lblTaskDescription);
            this.tabControlPanel2.Controls.Add(this.tbxTaskDes);
            this.tabControlPanel2.Controls.Add(this.tbxWorkflowCaption);
            this.tabControlPanel2.Controls.Add(this.btnSelectWf);
            this.tabControlPanel2.Controls.Add(this.lblSubFlowName);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(442, 183);
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
            // lblStartNode
            // 
            this.lblStartNode.AutoEllipsis = true;
            this.lblStartNode.BackColor = System.Drawing.Color.Transparent;
            this.lblStartNode.Location = new System.Drawing.Point(5, 45);
            this.lblStartNode.Name = "lblStartNode";
            this.lblStartNode.Size = new System.Drawing.Size(104, 14);
            this.lblStartNode.TabIndex = 134;
            this.lblStartNode.Text = "启动节点:";
            this.lblStartNode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxStartTasks
            // 
            this.cbxStartTasks.FormattingEnabled = true;
            this.cbxStartTasks.Location = new System.Drawing.Point(110, 41);
            this.cbxStartTasks.Name = "cbxStartTasks";
            this.cbxStartTasks.Size = new System.Drawing.Size(239, 22);
            this.cbxStartTasks.TabIndex = 133;
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoEllipsis = true;
            this.lblTaskDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskDescription.Location = new System.Drawing.Point(5, 79);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(104, 14);
            this.lblTaskDescription.TabIndex = 132;
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
            this.tbxTaskDes.Location = new System.Drawing.Point(110, 76);
            this.tbxTaskDes.Name = "tbxTaskDes";
            this.tbxTaskDes.SelectedValue = ((object)(resources.GetObject("tbxTaskDes.SelectedValue")));
            this.tbxTaskDes.Size = new System.Drawing.Size(239, 23);
            this.tbxTaskDes.TabIndex = 131;
            // 
            // tbxWorkflowCaption
            // 
            // 
            // 
            // 
            this.tbxWorkflowCaption.Border.Class = "TextBoxBorder";
            this.tbxWorkflowCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxWorkflowCaption.FocusHighlightEnabled = true;
            this.tbxWorkflowCaption.Location = new System.Drawing.Point(110, 8);
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            this.tbxWorkflowCaption.SelectedValue = ((object)(resources.GetObject("tbxWorkflowCaption.SelectedValue")));
            this.tbxWorkflowCaption.Size = new System.Drawing.Size(239, 23);
            this.tbxWorkflowCaption.TabIndex = 129;
            // 
            // btnSelectWf
            // 
            this.btnSelectWf.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelectWf.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelectWf.Location = new System.Drawing.Point(358, 6);
            this.btnSelectWf.Name = "btnSelectWf";
            this.btnSelectWf.Size = new System.Drawing.Size(48, 27);
            this.btnSelectWf.TabIndex = 130;
            this.btnSelectWf.Text = "...";
            this.btnSelectWf.Click += new System.EventHandler(this.btnSelectWf_Click);
            // 
            // lblSubFlowName
            // 
            this.lblSubFlowName.AutoEllipsis = true;
            this.lblSubFlowName.BackColor = System.Drawing.Color.Transparent;
            this.lblSubFlowName.Location = new System.Drawing.Point(5, 13);
            this.lblSubFlowName.Name = "lblSubFlowName";
            this.lblSubFlowName.Size = new System.Drawing.Size(104, 14);
            this.lblSubFlowName.TabIndex = 128;
            this.lblSubFlowName.Text = "子流程名称:";
            this.lblSubFlowName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabItemGeneral
            // 
            this.tabItemGeneral.AttachedControl = this.tabControlPanel2;
            this.tabItemGeneral.Name = "tabItemGeneral";
            this.tabItemGeneral.Text = "常规";
            // 
            // FrmSubWorkFlowNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 216);
            this.Name = "FrmSubWorkFlowNode";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "子流程节点配置";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.Label lblStartNode;
        private System.Windows.Forms.ComboBox cbxStartTasks;
        private System.Windows.Forms.Label lblTaskDescription;
        private Controls.UcTextBox tbxTaskDes;
        private Controls.UcTextBox tbxWorkflowCaption;
        private Controls.UcButton btnSelectWf;
        private System.Windows.Forms.Label lblSubFlowName;
        private DevComponents.DotNetBar.TabItem tabItemGeneral;
    }
}