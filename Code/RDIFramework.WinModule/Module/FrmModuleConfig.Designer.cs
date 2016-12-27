/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:51:19
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmModuleConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleConfig));
            this.tvModuleList = new System.Windows.Forms.TreeView();
            this.dgvCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuInvertSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTipDetail = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.tlTool = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.dgvCMenu.SuspendLayout();
            this.gbMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tlTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvModuleList
            // 
            this.tvModuleList.AllowDrop = true;
            this.tvModuleList.CheckBoxes = true;
            this.tvModuleList.ContextMenuStrip = this.dgvCMenu;
            this.tvModuleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModuleList.ImageIndex = 0;
            this.tvModuleList.ImageList = this.imgList;
            this.tvModuleList.Location = new System.Drawing.Point(3, 19);
            this.tvModuleList.Name = "tvModuleList";
            this.tvModuleList.SelectedImageIndex = 1;
            this.tvModuleList.Size = new System.Drawing.Size(490, 415);
            this.tvModuleList.TabIndex = 1;
            this.tvModuleList.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvModuleList_BeforeCheck);
            this.tvModuleList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvModuleList_AfterCheck);
            this.tvModuleList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvModuleList_ItemDrag);
            this.tvModuleList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvModuleList_DragDrop);
            this.tvModuleList.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvModuleList_DragEnter);
            this.tvModuleList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvModuleList_MouseDown);
            // 
            // dgvCMenu
            // 
            this.dgvCMenu.Font = new System.Drawing.Font("宋体", 10F);
            this.dgvCMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuSelectAll,
            this.cmnuInvertSelect});
            this.dgvCMenu.Name = "dgvCMenu";
            this.dgvCMenu.Size = new System.Drawing.Size(103, 48);
            // 
            // cmnuSelectAll
            // 
            this.cmnuSelectAll.Image = global::RDIFramework.WinModule.Properties.Resources.全选;
            this.cmnuSelectAll.Name = "cmnuSelectAll";
            this.cmnuSelectAll.Size = new System.Drawing.Size(102, 22);
            this.cmnuSelectAll.Text = "全选";
            this.cmnuSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // cmnuInvertSelect
            // 
            this.cmnuInvertSelect.Image = global::RDIFramework.WinModule.Properties.Resources.反选;
            this.cmnuInvertSelect.Name = "cmnuInvertSelect";
            this.cmnuInvertSelect.Size = new System.Drawing.Size(102, 22);
            this.cmnuInvertSelect.Text = "反选";
            this.cmnuInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "menu1.png");
            this.imgList.Images.SetKeyName(1, "menu2.png");
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tvModuleList);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 68);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(496, 437);
            this.gbMain.TabIndex = 7;
            this.gbMain.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Info;
            this.pnlTop.Controls.Add(this.lblTipDetail);
            this.pnlTop.Controls.Add(this.lblTip);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 25);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(496, 43);
            this.pnlTop.TabIndex = 19;
            // 
            // lblTipDetail
            // 
            this.lblTipDetail.AutoSize = true;
            this.lblTipDetail.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipDetail.Location = new System.Drawing.Point(83, 16);
            this.lblTipDetail.Name = "lblTipDetail";
            this.lblTipDetail.Size = new System.Drawing.Size(353, 12);
            this.lblTipDetail.TabIndex = 1;
            this.lblTipDetail.Text = "模块配置主要用于设置模块的可见性，不可见的模块用户不可见。";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.Location = new System.Drawing.Point(12, 14);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(82, 14);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "温馨提示：";
            // 
            // tlTool
            // 
            this.tlTool.AutoSize = false;
            this.tlTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator6,
            this.btnClose});
            this.tlTool.Location = new System.Drawing.Point(0, 0);
            this.tlTool.Name = "tlTool";
            this.tlTool.Size = new System.Drawing.Size(496, 25);
            this.tlTool.TabIndex = 58;
            this.tlTool.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::RDIFramework.WinModule.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::RDIFramework.WinModule.Properties.Resources.btnClose_Image;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmModuleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 505);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.tlTool);
            this.Name = "FrmModuleConfig";
            this.Text = "模块配置";
            this.dgvCMenu.ResumeLayout(false);
            this.gbMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tlTool.ResumeLayout(false);
            this.tlTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvModuleList;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblTipDetail;
        private System.Windows.Forms.ToolStrip tlTool;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ContextMenuStrip dgvCMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuInvertSelect;
        private System.Windows.Forms.ImageList imgList;

    }
}