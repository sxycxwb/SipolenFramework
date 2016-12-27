/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:23:07
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:20:10
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcButton
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
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));

            this.button.BackgroundImage = RDIFramework.Controls.Properties.Resources.ButtonBG01;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button.FlatAppearance.BorderSize = 0;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.button.Location = new System.Drawing.Point(1, 1);
            this.button.Margin = new System.Windows.Forms.Padding(5);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(80, 24);
            this.button.TabIndex = 2;
            this.button.Text = "文本";
            this.button.UseVisualStyleBackColor = true;
            // 
            // UcButton
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(163)))), ((int)(((byte)(193)))));
            this.Controls.Add(this.button);
            //this.DoubleBuffered = true;
            this.Name = "UcButton";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(82, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;

    }
}
