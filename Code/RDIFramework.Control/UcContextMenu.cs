/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 14:13:49
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace RDIFramework.Controls
{
    /// <summary>
    /// UcContextMenu
    /// 右键菜单
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ContextMenuStrip))]
    public class UcContextMenu : ContextMenuStrip
    {
        #region 构造函数

        public UcContextMenu()
            : base()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);
            this.Renderer = new ConstomToolStripRenderer();
        }

        public UcContextMenu(IContainer container)
            : base(container)
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);
            this.Renderer = new ConstomToolStripRenderer();
        }
        #endregion
    }
}
