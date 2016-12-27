/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:12
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-8 16:05:03
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcImageList
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
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.pictureList = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureList)).BeginInit();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.Location = new System.Drawing.Point(152, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(16, 128);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // pictureList
            // 
            this.pictureList.BackColor = System.Drawing.Color.White;
            this.pictureList.Location = new System.Drawing.Point(0, -3);
            this.pictureList.Name = "pictureList";
            this.pictureList.Size = new System.Drawing.Size(152, 128);
            this.pictureList.TabIndex = 3;
            this.pictureList.TabStop = false;
            this.pictureList.Click += new System.EventHandler(this.pictureList_Click);
            this.pictureList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureList_MouseDown);
            this.pictureList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureList_MouseDoubleClick);
            // 
            // UcImageList
            // 
            this.Controls.Add(this.pictureList);
            this.Controls.Add(this.vScrollBar);
            this.Name = "UcImageList";
            this.Size = new System.Drawing.Size(168, 128);
            this.Load += new System.EventHandler(this.UcImageList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UcImageList_Paint);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.UcImageList_Layout);
            this.Resize += new System.EventHandler(this.UcImageList_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.PictureBox pictureList;
    }
}
