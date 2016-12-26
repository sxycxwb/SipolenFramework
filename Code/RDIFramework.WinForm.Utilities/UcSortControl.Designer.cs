/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-16 14:52:21
 ******************************************************************************/
namespace RDIFramework.WinForm.Utilities
{
    partial class UcSortControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcSortControl));
            this.btnSetTop = new RDIFramework.Controls.UcButton();
            this.btnSetUp = new RDIFramework.Controls.UcButton();
            this.btnSetBottom = new RDIFramework.Controls.UcButton();
            this.btnSetDown = new RDIFramework.Controls.UcButton();
            this.SuspendLayout();
            // 
            // btnSetTop
            // 
            this.btnSetTop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetTop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetTop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetTop.Image = ((System.Drawing.Image)(resources.GetObject("btnSetTop.Image")));
            this.btnSetTop.Location = new System.Drawing.Point(2, 2);
            this.btnSetTop.Name = "btnSetTop";
            this.btnSetTop.Size = new System.Drawing.Size(29, 23);
            this.btnSetTop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetTop.TabIndex = 1;
            this.btnSetTop.Click += new System.EventHandler(this.btnSetTop_Click);
            // 
            // btnSetUp
            // 
            this.btnSetUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSetUp.Image")));
            this.btnSetUp.Location = new System.Drawing.Point(31, 2);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(35, 23);
            this.btnSetUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetUp.TabIndex = 2;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // btnSetBottom
            // 
            this.btnSetBottom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetBottom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetBottom.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetBottom.Image = ((System.Drawing.Image)(resources.GetObject("btnSetBottom.Image")));
            this.btnSetBottom.Location = new System.Drawing.Point(101, 2);
            this.btnSetBottom.Name = "btnSetBottom";
            this.btnSetBottom.Size = new System.Drawing.Size(35, 23);
            this.btnSetBottom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetBottom.TabIndex = 4;
            this.btnSetBottom.Click += new System.EventHandler(this.btnSetBottom_Click);
            // 
            // btnSetDown
            // 
            this.btnSetDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSetDown.Image")));
            this.btnSetDown.Location = new System.Drawing.Point(66, 2);
            this.btnSetDown.Name = "btnSetDown";
            this.btnSetDown.Size = new System.Drawing.Size(35, 23);
            this.btnSetDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetDown.TabIndex = 3;
            this.btnSetDown.Click += new System.EventHandler(this.btnSetDown_Click);
            // 
            // UcSortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSetBottom);
            this.Controls.Add(this.btnSetDown);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.btnSetTop);
            this.Name = "UcSortControl";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(144, 27);
            this.Load += new System.EventHandler(this.UcSortControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcButton btnSetTop;
        private Controls.UcButton btnSetUp;
        private Controls.UcButton btnSetBottom;
        private Controls.UcButton btnSetDown;

    }
}
