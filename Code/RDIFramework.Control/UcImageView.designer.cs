/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:52:10
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:51:58
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcImageView
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcImageView));
            this.PnlMain = new System.Windows.Forms.Panel();
            this.contextMnuImageView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFitSize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRightRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBarImageView = new System.Windows.Forms.VScrollBar();
            this.hScrollBarImageView = new System.Windows.Forms.HScrollBar();
            this.picView = new System.Windows.Forms.PictureBox();
            this.printDocImageView = new System.Drawing.Printing.PrintDocument();
            this.PnlMain.SuspendLayout();
            this.contextMnuImageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.AliceBlue;
            this.PnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlMain.ContextMenuStrip = this.contextMnuImageView;
            this.PnlMain.Controls.Add(this.vScrollBarImageView);
            this.PnlMain.Controls.Add(this.hScrollBarImageView);
            this.PnlMain.Controls.Add(this.picView);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(683, 636);
            this.PnlMain.TabIndex = 4;
            this.PnlMain.Resize += new System.EventHandler(this.PnlMain_Resize);
            // 
            // contextMnuImageView
            // 
            this.contextMnuImageView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuZoomIn,
            this.mnuZoomOut,
            this.mnuFitSize,
            this.toolStripMenuItem1,
            this.mnuMy,
            this.toolStripMenuItem2,
            this.mnuLeftRotate,
            this.mnuRightRotate,
            this.toolStripMenuItem3,
            this.mnuPrint});
            this.contextMnuImageView.Name = "contextMnuScanFile";
            this.contextMnuImageView.Size = new System.Drawing.Size(119, 176);
            // 
            // mnuZoomIn
            // 
            this.mnuZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("mnuZoomIn.Image")));
            this.mnuZoomIn.Name = "mnuZoomIn";
            this.mnuZoomIn.Size = new System.Drawing.Size(118, 22);
            this.mnuZoomIn.Text = "放大";
            this.mnuZoomIn.ToolTipText = "放大图片";
            this.mnuZoomIn.Click += new System.EventHandler(this.mnuZoomIn_Click);
            // 
            // mnuZoomOut
            // 
            this.mnuZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("mnuZoomOut.Image")));
            this.mnuZoomOut.Name = "mnuZoomOut";
            this.mnuZoomOut.Size = new System.Drawing.Size(118, 22);
            this.mnuZoomOut.Text = "缩小";
            this.mnuZoomOut.ToolTipText = "缩小图片";
            this.mnuZoomOut.Click += new System.EventHandler(this.mnuZoomOut_Click);
            // 
            // mnuFitSize
            // 
            this.mnuFitSize.Image = ((System.Drawing.Image)(resources.GetObject("mnuFitSize.Image")));
            this.mnuFitSize.Name = "mnuFitSize";
            this.mnuFitSize.Size = new System.Drawing.Size(118, 22);
            this.mnuFitSize.Text = "适应大小";
            this.mnuFitSize.ToolTipText = "适应图片大小";
            this.mnuFitSize.Click += new System.EventHandler(this.mnuFitSize_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 6);
            // 
            // mnuMy
            // 
            this.mnuMy.Image = ((System.Drawing.Image)(resources.GetObject("mnuMy.Image")));
            this.mnuMy.Name = "mnuMy";
            this.mnuMy.Size = new System.Drawing.Size(118, 22);
            this.mnuMy.Text = "漫游";
            this.mnuMy.ToolTipText = "漫游图片";
            this.mnuMy.CheckedChanged += new System.EventHandler(this.mnuMy_CheckedChanged);
            this.mnuMy.Click += new System.EventHandler(this.mnuMy_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(115, 6);
            // 
            // mnuLeftRotate
            // 
            this.mnuLeftRotate.Image = ((System.Drawing.Image)(resources.GetObject("mnuLeftRotate.Image")));
            this.mnuLeftRotate.Name = "mnuLeftRotate";
            this.mnuLeftRotate.Size = new System.Drawing.Size(118, 22);
            this.mnuLeftRotate.Text = "左旋转";
            this.mnuLeftRotate.ToolTipText = "对图片左旋转90度";
            this.mnuLeftRotate.Click += new System.EventHandler(this.mnuLeftRotate_Click);
            // 
            // mnuRightRotate
            // 
            this.mnuRightRotate.Image = ((System.Drawing.Image)(resources.GetObject("mnuRightRotate.Image")));
            this.mnuRightRotate.Name = "mnuRightRotate";
            this.mnuRightRotate.Size = new System.Drawing.Size(118, 22);
            this.mnuRightRotate.Text = "右旋转";
            this.mnuRightRotate.ToolTipText = "对图片右旋转90度";
            this.mnuRightRotate.Click += new System.EventHandler(this.mnuRightRotate_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(115, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrint.Image")));
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(118, 22);
            this.mnuPrint.Text = "打印";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // vScrollBarImageView
            // 
            this.vScrollBarImageView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBarImageView.Location = new System.Drawing.Point(663, 0);
            this.vScrollBarImageView.Name = "vScrollBarImageView";
            this.vScrollBarImageView.Size = new System.Drawing.Size(18, 634);
            this.vScrollBarImageView.TabIndex = 2;
            this.vScrollBarImageView.Visible = false;
            this.vScrollBarImageView.ValueChanged += new System.EventHandler(this.vScrollBarImageView_ValueChanged);
            // 
            // hScrollBarImageView
            // 
            this.hScrollBarImageView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBarImageView.Location = new System.Drawing.Point(0, 616);
            this.hScrollBarImageView.Name = "hScrollBarImageView";
            this.hScrollBarImageView.Size = new System.Drawing.Size(665, 18);
            this.hScrollBarImageView.TabIndex = 1;
            this.hScrollBarImageView.Visible = false;
            this.hScrollBarImageView.ValueChanged += new System.EventHandler(this.hScrollBarImageView_ValueChanged);
            // 
            // picView
            // 
            this.picView.Location = new System.Drawing.Point(227, 184);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(147, 143);
            this.picView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picView.TabIndex = 0;
            this.picView.TabStop = false;
            this.picView.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.picView_LoadCompleted);
            this.picView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.picView_KeyUp);
            this.picView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.picView_KeyDown);
            this.picView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picView_MouseDown);
            this.picView.MouseEnter += new System.EventHandler(this.picView_MouseEnter);
            this.picView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picView_MouseMove);
            this.picView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picView_MouseUp);
            this.picView.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picView_MouseWheel);
            // 
            // printDocImageView
            // 
            this.printDocImageView.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocImageView_PrintPage);
            // 
            // UcImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlMain);
            this.Name = "UcImageView";
            this.Size = new System.Drawing.Size(683, 636);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UcImageView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UcImageView_KeyUp);
            this.PnlMain.ResumeLayout(false);
            this.contextMnuImageView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.VScrollBar vScrollBarImageView;
        private System.Windows.Forms.HScrollBar hScrollBarImageView;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.ContextMenuStrip contextMnuImageView;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomIn;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomOut;
        private System.Windows.Forms.ToolStripMenuItem mnuFitSize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuMy;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftRotate;
        private System.Windows.Forms.ToolStripMenuItem mnuRightRotate;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Drawing.Printing.PrintDocument printDocImageView;

    }
}
