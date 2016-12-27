/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:52:00
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcNavBarEx
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
            this.cmddown = new RDIFramework.Controls.UcPicButtomEx();
            this.cmdup = new RDIFramework.Controls.UcPicButtomEx();
            this.SuspendLayout();
            // 
            // cmddown
            // 
            this.cmddown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmddown.backImage = null;
            this.cmddown.BntText = "";
            this.cmddown.BorderColor = System.Drawing.Color.Black;
            this.cmddown.BorderWidth = 1F;
            this.cmddown.classname = "";
            this.cmddown.dllfile = "";
            this.cmddown.frmopenmode = RDIFramework.Controls.FormOpenMode.Normal;
            this.cmddown.Image = RDIFramework.Controls.Properties.Resources.down;
            this.cmddown.ImgAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmddown.imgnuminAll = 100;
            this.cmddown.imgnuminImg = 100;
            this.cmddown.Location = new System.Drawing.Point(122, 228);
            this.cmddown.MoveBackImage = null;
            this.cmddown.MoveTextColor = System.Drawing.Color.Red;
            this.cmddown.Name = "cmddown";
            this.cmddown.Size = new System.Drawing.Size(22, 20);
            this.cmddown.TabIndex = 3;
            this.cmddown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmddown.TextColor = System.Drawing.Color.Black;
            this.cmddown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmddown.type = 2;
            this.cmddown.Visible = false;
            this.cmddown.Click += new System.EventHandler(this.cmddown_Click);
            // 
            // cmdup
            // 
            this.cmdup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmdup.backImage = null;
            this.cmdup.BntText = "";
            this.cmdup.BorderColor = System.Drawing.Color.Black;
            this.cmdup.BorderWidth = 1F;
            this.cmdup.classname = "";
            this.cmdup.dllfile = "";
            this.cmdup.frmopenmode = RDIFramework.Controls.FormOpenMode.Normal;
            this.cmdup.Image = RDIFramework.Controls.Properties.Resources.up;
            this.cmdup.ImgAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmdup.imgnuminAll = 100;
            this.cmdup.imgnuminImg = 100;
            this.cmdup.Location = new System.Drawing.Point(122, 45);
            this.cmdup.MoveBackImage = null;
            this.cmdup.MoveTextColor = System.Drawing.Color.Red;
            this.cmdup.Name = "cmdup";
            this.cmdup.Size = new System.Drawing.Size(22, 20);
            this.cmdup.TabIndex = 2;
            this.cmdup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cmdup.TextColor = System.Drawing.Color.Black;
            this.cmdup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdup.type = 2;
            this.cmdup.Visible = false;
            this.cmdup.Load += new System.EventHandler(this.cmdup_Load);
            this.cmdup.Click += new System.EventHandler(this.cmdup_Click);
            // 
            // UcNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cmddown);
            this.Controls.Add(this.cmdup);
            this.DoubleBuffered = true;
            this.Name = "UcNavBar";
            this.Size = new System.Drawing.Size(163, 278);
            this.Load += new System.EventHandler(this.UcNavBar_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UcNavBar_Paint);
            this.Resize += new System.EventHandler(this.UcNavBar_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
