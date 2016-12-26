namespace RDIFramework.WorkFlow
{
    partial class FrmProcessingTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcessingTask));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsToolButton = new System.Windows.Forms.ToolStrip();
            this.btnBackUp = new System.Windows.Forms.ToolStripButton();
            this.btnTaskAnyBack = new System.Windows.Forms.ToolStripButton();
            this.btnTaskAssign = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClaimTask = new System.Windows.Forms.ToolStripButton();
            this.btnDraft = new System.Windows.Forms.ToolStripButton();
            this.btnTaskAbnegate = new System.Windows.Forms.ToolStripButton();
            this.tsSeparatorTaskRevoke = new System.Windows.Forms.ToolStripSeparator();
            this.btnTaskRevoke = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panMain = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlMainArea = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.sideBarList = new DevComponents.DotNetBar.SideBar();
            this.sideBarPanelItemDefault = new DevComponents.DotNetBar.SideBarPanelItem();
            this.btnDyAssignNextOper = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tsToolButton.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panMain.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsToolButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 25);
            this.panel1.TabIndex = 0;
            // 
            // tsToolButton
            // 
            this.tsToolButton.Font = new System.Drawing.Font("宋体", 10.5F);
            this.tsToolButton.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBackUp,
            this.btnTaskAnyBack,
            this.btnTaskAssign,
            this.btnDyAssignNextOper,
            this.tsSeparator1,
            this.btnClaimTask,
            this.btnDraft,
            this.btnTaskAbnegate,
            this.tsSeparatorTaskRevoke,
            this.btnTaskRevoke});
            this.tsToolButton.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsToolButton.Location = new System.Drawing.Point(0, 0);
            this.tsToolButton.Name = "tsToolButton";
            this.tsToolButton.Size = new System.Drawing.Size(1122, 25);
            this.tsToolButton.TabIndex = 0;
            // 
            // btnBackUp
            // 
            this.btnBackUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBackUp.Image = ((System.Drawing.Image)(resources.GetObject("btnBackUp.Image")));
            this.btnBackUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(81, 22);
            this.btnBackUp.Text = "退回上一人";
            this.btnBackUp.Visible = false;
            // 
            // btnTaskAnyBack
            // 
            this.btnTaskAnyBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaskAnyBack.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskAnyBack.Image")));
            this.btnTaskAnyBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaskAnyBack.Name = "btnTaskAnyBack";
            this.btnTaskAnyBack.Size = new System.Drawing.Size(67, 22);
            this.btnTaskAnyBack.Text = "任意退回";
            this.btnTaskAnyBack.Visible = false;
            // 
            // btnTaskAssign
            // 
            this.btnTaskAssign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaskAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskAssign.Image")));
            this.btnTaskAssign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaskAssign.Name = "btnTaskAssign";
            this.btnTaskAssign.Size = new System.Drawing.Size(39, 22);
            this.btnTaskAssign.Text = "指派";
            this.btnTaskAssign.Visible = false;
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClaimTask
            // 
            this.btnClaimTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClaimTask.Image = ((System.Drawing.Image)(resources.GetObject("btnClaimTask.Image")));
            this.btnClaimTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClaimTask.Name = "btnClaimTask";
            this.btnClaimTask.Size = new System.Drawing.Size(39, 22);
            this.btnClaimTask.Text = "认领";
            // 
            // btnDraft
            // 
            this.btnDraft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDraft.Image = ((System.Drawing.Image)(resources.GetObject("btnDraft.Image")));
            this.btnDraft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(39, 22);
            this.btnDraft.Text = "草稿";
            // 
            // btnTaskAbnegate
            // 
            this.btnTaskAbnegate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaskAbnegate.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskAbnegate.Image")));
            this.btnTaskAbnegate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaskAbnegate.Name = "btnTaskAbnegate";
            this.btnTaskAbnegate.Size = new System.Drawing.Size(67, 22);
            this.btnTaskAbnegate.Text = "放弃认领";
            // 
            // tsSeparatorTaskRevoke
            // 
            this.tsSeparatorTaskRevoke.Name = "tsSeparatorTaskRevoke";
            this.tsSeparatorTaskRevoke.Size = new System.Drawing.Size(6, 25);
            this.tsSeparatorTaskRevoke.Visible = false;
            // 
            // btnTaskRevoke
            // 
            this.btnTaskRevoke.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTaskRevoke.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnTaskRevoke.ForeColor = System.Drawing.Color.Blue;
            this.btnTaskRevoke.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskRevoke.Image")));
            this.btnTaskRevoke.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaskRevoke.Name = "btnTaskRevoke";
            this.btnTaskRevoke.Size = new System.Drawing.Size(71, 22);
            this.btnTaskRevoke.Text = "撤回修改";
            this.btnTaskRevoke.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panMain);
            this.panel2.Controls.Add(this.sideBarList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1122, 648);
            this.panel2.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(262, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 648);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // panMain
            // 
            this.panMain.AutoScroll = true;
            this.panMain.Controls.Add(this.panel4);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(262, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(860, 648);
            this.panMain.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnlMainArea);
            this.panel4.Controls.Add(this.lblTitle);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(860, 648);
            this.panel4.TabIndex = 0;
            // 
            // pnlMainArea
            // 
            this.pnlMainArea.AutoScroll = true;
            this.pnlMainArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainArea.Location = new System.Drawing.Point(0, 49);
            this.pnlMainArea.Name = "pnlMainArea";
            this.pnlMainArea.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMainArea.Size = new System.Drawing.Size(860, 599);
            this.pnlMainArea.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.YellowGreen;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(860, 49);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sideBarList
            // 
            this.sideBarList.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.sideBarList.BackColor = System.Drawing.SystemColors.Window;
            this.sideBarList.BorderStyle = DevComponents.DotNetBar.eBorderType.None;
            this.sideBarList.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarList.ExpandedPanel = this.sideBarPanelItemDefault;
            this.sideBarList.Location = new System.Drawing.Point(0, 0);
            this.sideBarList.Name = "sideBarList";
            this.sideBarList.Panels.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sideBarPanelItemDefault});
            this.sideBarList.Size = new System.Drawing.Size(262, 648);
            this.sideBarList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sideBarList.TabIndex = 6;
            // 
            // sideBarPanelItemDefault
            // 
            this.sideBarPanelItemDefault.BackgroundStyle.BackColor1.Color = System.Drawing.Color.FloralWhite;
            this.sideBarPanelItemDefault.FontBold = true;
            this.sideBarPanelItemDefault.Name = "sideBarPanelItemDefault";
            this.sideBarPanelItemDefault.Text = "表单列表";
            // 
            // btnDyAssignNextOper
            // 
            this.btnDyAssignNextOper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDyAssignNextOper.Image = ((System.Drawing.Image)(resources.GetObject("btnDyAssignNextOper.Image")));
            this.btnDyAssignNextOper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDyAssignNextOper.Name = "btnDyAssignNextOper";
            this.btnDyAssignNextOper.Size = new System.Drawing.Size(67, 22);
            this.btnDyAssignNextOper.Text = "动态指派";
            this.btnDyAssignNextOper.Visible = false;
            // 
            // FrmProcessingTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1122, 673);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProcessingTask";
            this.Text = "处理任务";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsToolButton.ResumeLayout(false);
            this.tsToolButton.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panMain.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panMain;
        private DevComponents.DotNetBar.SideBar sideBarList;
        private DevComponents.DotNetBar.SideBarPanelItem sideBarPanelItemDefault;
        private System.Windows.Forms.ToolStrip tsToolButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMainArea;
        private System.Windows.Forms.ToolStripButton btnBackUp;
        private System.Windows.Forms.ToolStripButton btnTaskAssign;
        private System.Windows.Forms.ToolStripButton btnClaimTask;
        private System.Windows.Forms.ToolStripButton btnDraft;
        private System.Windows.Forms.ToolStripButton btnTaskAbnegate;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;
        private System.Windows.Forms.ToolStripSeparator tsSeparatorTaskRevoke;
        private System.Windows.Forms.ToolStripButton btnTaskRevoke;
        private System.Windows.Forms.ToolStripButton btnTaskAnyBack;
        private System.Windows.Forms.ToolStripButton btnDyAssignNextOper;

    }
}