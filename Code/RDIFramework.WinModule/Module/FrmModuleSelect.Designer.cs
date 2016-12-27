﻿/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:51:20
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmModuleSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuleSelect));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.tlTool = new System.Windows.Forms.ToolStrip();
            this.btnSetNull = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.dgvCMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuInvertSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.gbMain.SuspendLayout();
            this.tlTool.SuspendLayout();
            this.dgvCMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.tvModule);
            this.gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMain.Location = new System.Drawing.Point(0, 25);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(572, 533);
            this.gbMain.TabIndex = 7;
            this.gbMain.TabStop = false;
            // 
            // tvModule
            // 
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.ImageIndex = 0;
            this.tvModule.ImageList = this.imgList;
            this.tvModule.Location = new System.Drawing.Point(3, 19);
            this.tvModule.Name = "tvModule";
            this.tvModule.SelectedImageIndex = 1;
            this.tvModule.Size = new System.Drawing.Size(566, 511);
            this.tvModule.TabIndex = 0;
            this.tvModule.DoubleClick += new System.EventHandler(this.tvModule_DoubleClick);
            this.tvModule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvModule_MouseDown);
            // 
            // tlTool
            // 
            this.tlTool.AutoSize = false;
            this.tlTool.Font = new System.Drawing.Font("宋体", 11F);
            this.tlTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetNull,
            this.btnSelect,
            this.toolStripSeparator6,
            this.btnClose});
            this.tlTool.Location = new System.Drawing.Point(0, 0);
            this.tlTool.Name = "tlTool";
            this.tlTool.Size = new System.Drawing.Size(572, 25);
            this.tlTool.TabIndex = 58;
            this.tlTool.Text = "toolStrip1";
            // 
            // btnSetNull
            // 
            this.btnSetNull.Image = global::RDIFramework.WinModule.Properties.Resources.清除查询条件;
            this.btnSetNull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetNull.Name = "btnSetNull";
            this.btnSetNull.Size = new System.Drawing.Size(81, 22);
            this.btnSetNull.Text = "置空(&R)";
            this.btnSetNull.Click += new System.EventHandler(this.btnSetNull_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::RDIFramework.WinModule.Properties.Resources.save;
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(81, 22);
            this.btnSelect.Text = "选择(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnConfirm_Click);
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
            // 
            // cmnuInvertSelect
            // 
            this.cmnuInvertSelect.Image = global::RDIFramework.WinModule.Properties.Resources.反选;
            this.cmnuInvertSelect.Name = "cmnuInvertSelect";
            this.cmnuInvertSelect.Size = new System.Drawing.Size(102, 22);
            this.cmnuInvertSelect.Text = "反选";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "menu1.png");
            this.imgList.Images.SetKeyName(1, "menu2.png");
            // 
            // FrmModuleSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 558);
            this.Controls.Add(this.gbMain);
            this.Controls.Add(this.tlTool);
            this.Name = "FrmModuleSelect";
            this.Text = "选择模块";
            this.gbMain.ResumeLayout(false);
            this.tlTool.ResumeLayout(false);
            this.tlTool.PerformLayout();
            this.dgvCMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.ToolStrip tlTool;
        private System.Windows.Forms.ToolStripButton btnSetNull;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ContextMenuStrip dgvCMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuInvertSelect;
        private System.Windows.Forms.ImageList imgList;
    }
}