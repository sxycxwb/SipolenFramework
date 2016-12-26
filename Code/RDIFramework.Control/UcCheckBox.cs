/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:28
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:09
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace RDIFramework.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.CheckBox))]
    public class  UcCheckBox : CheckBox
    {
        #region 声明
        private State state = State.Normal;
        private Bitmap _BackImg = ImageObject.GetResBitmap("RDIFramework.Controls.Properties.Resources.Checkbox");
        //枚鼠标状态
        private enum State
        {
            Normal = 1,
            MouseOver = 2,
            MouseDown = 3,
            Disable = 4
        }
        #endregion

        #region 构造函数
        public UcCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);//设置控件自行绘制
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);//背景透明     
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            this.BackColor = System.Drawing.Color.Transparent;//背景设为透明
        
        }
        #endregion
      
        #region 属性
        [CategoryAttribute("阿龙自定义属性"), Description("CheckBox图片")]
        public Bitmap BackImg
        {
            get { return this._BackImg; }
            set
            {
                _BackImg = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 方法
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaintBackground(e);
            if (_BackImg == null)
            {
                base.OnPaint(e);
                return;
            }

            int i = (int)state;
            if (!this.Enabled) i = 4;
            if (this.CheckState == CheckState.Checked) i += 4;
            if (this.CheckState == CheckState.Indeterminate) i += 8;

            Rectangle rc = this.ClientRectangle;
            Rectangle r1 = rc;
            Rectangle textRect;
            Graphics g = e.Graphics;

            if (this.CheckAlign == ContentAlignment.MiddleLeft)//对齐状态
            {
                r1 = new Rectangle(0, (rc.Height - 15) / 2, 16, 15);
                textRect = new Rectangle(16, 0, rc.Width - 16, rc.Height);
            }
            else
            {
                r1 = new Rectangle(r1.Right - 16, (rc.Height - 16) / 2, 16, 15);
                textRect = new Rectangle(0, 0, rc.Width - 16, rc.Height);
            }
            ImageDrawRect.DrawRect(g, _BackImg, r1, Rectangle.FromLTRB(0, 0, 0, 0), i, 12);
            Color textColor = Enabled ? ForeColor : SystemColors.GrayText;
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textRect, textColor);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            state = State.MouseOver;
            this.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            state = State.Normal;
            this.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
            state = State.MouseOver;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                state = State.MouseOver;
            this.Invalidate();
            base.OnMouseUp(e);
        }
        #endregion
    }
}
