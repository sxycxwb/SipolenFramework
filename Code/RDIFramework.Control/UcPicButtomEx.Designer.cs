/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:37:03
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcPicButtomEx
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            base.SuspendLayout();
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(0xc0, 0xc0, 0xff);
            this.DoubleBuffered = true;
            base.Name = "UcPicbuttom";
            base.Size = new System.Drawing.Size(0x5d, 0x1b);
            base.Load += new System.EventHandler(this.UcPicbuttom_Load);
            base.Resize += new System.EventHandler(this.UcPicbuttom_Resize);
            base.MouseEnter += new System.EventHandler(this.UcPicbuttom_MouseEnter);
            base.Paint += new System.Windows.Forms.PaintEventHandler(this.UcPicbuttom_Paint);
            base.MouseLeave += new System.EventHandler(this.UcPicbuttom_MouseLeave);
            base.ResumeLayout(false);

        }

        #endregion
    }
}
