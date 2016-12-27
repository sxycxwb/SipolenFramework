/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:42:15
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// UcQueryControl
    /// 多条件组合查询控件
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("EventPaging")]
    [ToolboxBitmap(typeof(UcQueryControl), "Images.UcQueryControl.png")]
    [Description("多条件组合查询控件")]
    public partial class UcQueryControl : UserControl
    {
        public UcQueryControl()
        {
            InitializeComponent();
            DataGridViewCellStyle s = new DataGridViewCellStyle();            
        }
    }
}
