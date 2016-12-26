using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    partial class FrmDailyBiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDailyBiz));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcMain = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvNavigateTree = new System.Windows.Forms.TreeView();
            this.imglistMain = new System.Windows.Forms.ImageList(this.components);
            this.tabItemMyBusiness = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvData = new System.Windows.Forms.ListView();
            this.colTmp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowCaption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkTaskId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWorkFlowId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStartTask = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tcMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 573);
            this.panel1.TabIndex = 0;
            // 
            // tcMain
            // 
            this.tcMain.BackColor = System.Drawing.SystemColors.Window;
            this.tcMain.CanReorderTabs = true;
            this.tcMain.Controls.Add(this.tabControlPanel2);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcMain.SelectedTabIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(257, 573);
            this.tcMain.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcMain.TabIndex = 22;
            this.tcMain.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcMain.Tabs.Add(this.tabItemMyBusiness);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.tvNavigateTree);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(257, 546);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemMyBusiness;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // tvNavigateTree
            // 
            this.tvNavigateTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNavigateTree.ImageIndex = 6;
            this.tvNavigateTree.ImageList = this.imglistMain;
            this.tvNavigateTree.Location = new System.Drawing.Point(1, 1);
            this.tvNavigateTree.Name = "tvNavigateTree";
            this.tvNavigateTree.SelectedImageIndex = 5;
            this.tvNavigateTree.Size = new System.Drawing.Size(255, 544);
            this.tvNavigateTree.TabIndex = 0;
            this.tvNavigateTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNavigateTree_AfterSelect);
            // 
            // imglistMain
            // 
            this.imglistMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistMain.ImageStream")));
            this.imglistMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistMain.Images.SetKeyName(0, "folder.bmp");
            this.imglistMain.Images.SetKeyName(1, "arch.bmp");
            this.imglistMain.Images.SetKeyName(2, "12.bmp");
            this.imglistMain.Images.SetKeyName(3, "workflow1.bmp");
            this.imglistMain.Images.SetKeyName(4, "表单.bmp");
            this.imglistMain.Images.SetKeyName(5, "03982.ico");
            this.imglistMain.Images.SetKeyName(6, "04367.ico");
            this.imglistMain.Images.SetKeyName(7, "duty.bmp");
            // 
            // tabItemMyBusiness
            // 
            this.tabItemMyBusiness.AttachedControl = this.tabControlPanel2;
            this.tabItemMyBusiness.Name = "tabItemMyBusiness";
            this.tabItemMyBusiness.Text = "可用业务";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(260, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 548);
            this.panel2.TabIndex = 1;
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTmp,
            this.colFlowCaption,
            this.colWorkTaskId,
            this.colWorkFlowId});
            this.lvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvData.FullRowSelect = true;
            this.lvData.GridLines = true;
            this.lvData.Location = new System.Drawing.Point(0, 0);
            this.lvData.MultiSelect = false;
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(772, 548);
            this.lvData.SmallImageList = this.imglistMain;
            this.lvData.StateImageList = this.imglistMain;
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // colTmp
            // 
            this.colTmp.Text = "";
            this.colTmp.Width = 50;
            // 
            // colFlowCaption
            // 
            this.colFlowCaption.Text = StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmProcessStep_colflowcaption"), "流程名称");
            this.colFlowCaption.Width = 260;
            // 
            // colWorkTaskId
            // 
            this.colWorkTaskId.DisplayIndex = 3;
            this.colWorkTaskId.Text = "Task Id"; 
            this.colWorkTaskId.Width = 130;
            // 
            // colWorkFlowId
            // 
            this.colWorkFlowId.DisplayIndex = 2;
            this.colWorkFlowId.Text ="WorkFlow Id";
            this.colWorkFlowId.Width = 300;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(257, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 573);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartTask,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(260, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnStartTask
            // 
            this.btnStartTask.Enabled = false;
            this.btnStartTask.Image = ((System.Drawing.Image)(resources.GetObject("btnStartTask.Image")));
            this.btnStartTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(73, 22);
            this.btnStartTask.Text = "开始任务";
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmDailyBiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDailyBiz";
            this.Text = "日常业务";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevComponents.DotNetBar.TabControl tcMain;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemMyBusiness;
        private System.Windows.Forms.TreeView tvNavigateTree;
        private System.Windows.Forms.ImageList imglistMain;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader colTmp;
        private System.Windows.Forms.ColumnHeader colFlowCaption;
        private System.Windows.Forms.ColumnHeader colWorkFlowId;
        private System.Windows.Forms.ToolStripButton btnStartTask;
        private System.Windows.Forms.ColumnHeader colWorkTaskId;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}