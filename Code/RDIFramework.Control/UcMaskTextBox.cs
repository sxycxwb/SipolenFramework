/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:32:14
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:33
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:12
 ******************************************************************************/
//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// 自定义的TextBox控件
    /// </summary>
    [ToolboxItem(true)]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(System.Windows.Forms.MaskedTextBox))]
    [Description("自定义的TextBox控件")]
    public partial class UcMaskTextBox : UserControl
    {
        /// <summary>
        /// 自定义TextBox控件的默认实例化方法。使用本自定义Button控件前，请确保
        /// 应用程序的Properties.Resources资源文件中，包含了1张名为Input的图片。
        /// </summary>
        public UcMaskTextBox()
        {            
            InitializeComponent();
            txtInside.BackColor = Color.White;
            txtInside.Location = new Point(3, 6);
            txtInside.Width = PnlWhiteBG.Width - 6;
            txtInside.GotFocus += new EventHandler(TxtBox_GotFocus);
            txtInside.Leave += new EventHandler(TxtBox_Leave);
            txtInside.KeyDown += new KeyEventHandler(TxtInside_OnKeyDown);
        }


        /// <summary>
        /// 获取或用户控件属性文本框中的内容。
        /// </summary>
        [Category("用户控件属性")]
        [Description("获取或用户控件属性文本框中的内容。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return txtInside.Text;
            }
            set
            {
                txtInside.Text = value;
            }
        }

        /// <summary>
        /// 获取或用户控件属性是否为多行文本框。
        /// </summary>
        [Category("用户控件属性")]
        [Description("获取或用户控件属性是否为多行文本框。")]
        [Browsable(true)]
        public bool Multiline
        {
            get
            {
                return txtInside.Multiline;
            }
            set
            {
                txtInside.Multiline = value;

            }
        }

        /// <summary>
        /// 获取或用户控件属性文本框的滚动条显示方式。
        /// </summary>
        [Category("用户控件属性")]
        [Description("控制能否更改编辑器控件中的文本")]
        [Browsable(true)]
        public bool ReadOnly
        {
            get
            {
                return txtInside.ReadOnly;
            }
            set
            {
                txtInside.ReadOnly = value;
            }
        }

        /// <summary>
        /// 输入焦点丢失时，改变相关子控件的颜色。
        /// </summary>
        void TxtBox_Leave(object sender, EventArgs e)
        {
            BackColor = Color.White;
            PnlBorder.BackColor = Color.FromArgb(204, 204, 204);
            txtInside.ForeColor = Color.FromArgb(102, 102, 102);
        }

        /// <summary>
        /// 获得输入焦点时，改变相关子控件的颜色。
        /// </summary>
        void TxtBox_GotFocus(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(179, 221, 150);
            PnlBorder.BackColor = Color.FromArgb(87, 152, 43);
            txtInside.ForeColor = Color.FromArgb(51, 102, 0);
        }


        void TxtInside_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                SendKeys.Send("{TAB}");
            }
        }

        /// <summary>
        /// 可以手动通过该方法，使TextBox获得输入焦点。
        /// </summary>
        public new void Focus()
        {
            txtInside.Select();
        }

        /// <summary>
        /// TextBox控件大小改变时的事件处理。
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!Multiline)
            {
                this.Height = 27;
            }
            txtInside.Location = new Point(3, 5);
            txtInside.Width = PnlWhiteBG.Width - 6;
            txtInside.Height = PnlWhiteBG.Height - 10;
        }
    }
}
