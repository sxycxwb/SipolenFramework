/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:08
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RDIFramework.Controls
{
    public class ConstomToolStripRenderer : ToolStripRenderer
    {
        #region 构造函数

        public ConstomToolStripRenderer()
            : base()
        {

        }

        #endregion

        #region Override Methods

        /// <summary>
        /// 绘制菜单背景
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.AffectedBounds;
            g.SmoothingMode = SmoothingMode.HighQuality;

            int Rgn = Win32.CreateRoundRectRgn(1, 1, rect.Width, rect.Height, 2, 2);
            Win32.SetWindowRgn(e.ToolStrip.Handle, Rgn, true);

            Image bgk = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("RDIFramework.WinForm.Utilities.Images.menu_bkg.png"));
            Image board = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("RDIFramework.WinForm.Utilities.Images.menu_bkg_board.png"));
            //Image bgk = AssemblyHelper.GetAssemblyImage("menu_bkg.png");
            //Image board = AssemblyHelper.GetAssemblyImage("menu_bkg_board.png");

            //左侧
            g.DrawImage(bgk, new Rectangle(0, 0, 28, 5), new Rectangle(4, 4, 28, 5), GraphicsUnit.Pixel);//左上角
            g.DrawImage(bgk, new Rectangle(0, 5, 28, rect.Height - 10), new Rectangle(4, 8, bgk.Height - 2, 14), GraphicsUnit.Pixel);//左边
            g.DrawImage(bgk, new Rectangle(0, rect.Height - 5, 28, 5), new Rectangle(4, bgk.Height - 9, 28, 5), GraphicsUnit.Pixel);//左下角
            //右侧
            g.DrawImage(board, new Rectangle(28, 0, rect.Width - 32, 5), new Rectangle(10, 4, board.Width - 35, 5), GraphicsUnit.Pixel);//上边
            g.DrawImage(board, new Rectangle(rect.Width - 4, 0, 8, 5), new Rectangle(board.Width - 8, 4, 8, 5), GraphicsUnit.Pixel);//右上角
            g.DrawImage(board, new Rectangle(rect.Width - 4, 5, 8, rect.Height - 10), new Rectangle(board.Width - 8, 10, 8, 12), GraphicsUnit.Pixel);//右边
            g.DrawImage(board, new Rectangle(rect.Width - 4, rect.Height - 5, 8, 5), new Rectangle(board.Width - 8, board.Height - 9, 8, 5), GraphicsUnit.Pixel);//右下角
            g.DrawImage(board, new Rectangle(28, rect.Height - 4, rect.Width - 32, 5), new Rectangle(10, board.Height - 8, board.Width - 35, 5), GraphicsUnit.Pixel);//下边
            g.DrawImage(board, new Rectangle(28, 5, rect.Width - 32, rect.Height - 9), new Rectangle(10, 10, 32, 12), GraphicsUnit.Pixel);//填充

            base.OnRenderToolStripBackground(e);

        }

        /// <summary>
        /// 绘制 ToolStripItem 上的箭头。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            Image arrow = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("RDIFramework.WinForm.Utilities.Images.menu_arrow.png"));//AssemblyHelper.GetAssemblyImage("menu_arrow.png");
            Rectangle imgPoint = new Rectangle(
                e.ArrowRectangle.X + 4,
                (e.ArrowRectangle.Height - arrow.Height) / 2,
                arrow.Width,
                arrow.Height);//图片的位置和显示的大小
            Rectangle imgRect = new Rectangle(0, 0, arrow.Width, arrow.Height);
            g.DrawImage(arrow, imgPoint, imgRect, GraphicsUnit.Pixel);
        }

        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderItemBackground(e);
            e.Graphics.FillRectangle(Brushes.Yellow, e.Item.ContentRectangle);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            ToolStripItem item = e.Item;
            ToolStrip toolstrip = e.ToolStrip;
            
            if (toolstrip is ToolStripDropDown)
            {
                g.SmoothingMode = SmoothingMode.HighQuality; 
                if (item.Selected)
                {
                    item.ForeColor = Color.White;
                    e.Graphics.FillRectangle(Brushes.Green, e.Item.ContentRectangle);
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
        #endregion
    }
}
