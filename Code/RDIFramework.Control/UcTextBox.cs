/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:42:22
 ******************************************************************************/

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
    [ToolboxBitmap(typeof(UcTextBox), "Images.UcTextBox.png")]
    [Description("自定义的TextBox控件[DotNetBar样式]")]
    public partial class UcTextBox : DevComponents.DotNetBar.Controls.TextBoxX//UserControl
    {
        /// <summary>
        /// 自定义TextBox控件的默认实例化方法。使用本自定义Button控件前，请确保
        /// 应用程序的Properties.Resources资源文件中，包含了1张名为Input的图片。
        /// </summary>
        public UcTextBox():base()
        {
        //    SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
             InitializeComponent();
             this.Border.Class = "TextBoxBorder";
             this.FocusHighlightEnabled = true;
             
        //    txtInside.BackColor = Color.White;
        //    txtInside.Location = new Point(3, 6);
        //    txtInside.Width = PnlWhiteBG.Width - 6;
        //    txtInside.GotFocus += new EventHandler(TxtBox_GotFocus);
        //    txtInside.Leave += new EventHandler(TxtBox_Leave);
        //    txtInside.KeyDown += new System.Windows.Forms.KeyEventHandler(TxtBox_OnKeyKown);
        }

        public UcTextBox(IContainer container)
            : base()
        {
            container.Add(this);
            InitializeComponent();        
            this.Border.Class =  "TextBoxBorder";
            this.FocusHighlightEnabled = true;           
        }

        ///// <summary>
        ///// 获取或用户控件属性文本框中的内容。
        ///// </summary>
        //[Category("用户控件属性")]
        //[Description("获取或用户控件属性文本框中的内容。")]
        //[Browsable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public override string Text
        //{
        //    get
        //    {
        //        return txtInside.Text;
        //    }
        //    set
        //    {
        //        txtInside.Text = value;
        //    }
        //}

        //object selectedValue = DBNull.Value;
        object selectedValue = "";
        /// <summary>
        /// 选定的值(主要用于得到绑定值)
        /// </summary>
        [Browsable(false)]
        public object SelectedValue
        {
            set
            {
                selectedValue = value;
            }
            get
            {
                return selectedValue;
            }
        }      
 

        /// <summary>
        /// 获取或设置是否为多行文本框。
        /// </summary>
        //[Category("用户控件属性")]
        //[Description("获取或用户控件属性是否为多行文本框。")]
        //[Browsable(true)]
        //public bool Multiline
        //{
        //    get
        //    {
        //        return txtInside.Multiline;
        //    }
        //    set
        //    {
        //        txtInside.Multiline = value;

        //    }
        //}

        /// <summary>
        /// 获取或设置控件属性允许的最多字符数。
        /// </summary>
        //[Category("用户控件属性")]
        //[Description("获取或设置控件属性允许的最多字符数。")]
        //[Browsable(true)]
        //public int MaxLength
        //{
        //    get
        //    {
        //        return txtInside.MaxLength;
        //    }
        //    set
        //    {
        //        txtInside.MaxLength = value;
        //    }
        //}

        /// <summary>
        /// 获取或用户控件属性文本框的滚动条显示方式。
        /// </summary>
        //[Category("用户控件属性")]
        //[Description("获取或用户控件属性文本框的滚动条显示方式。")]
        //[Browsable(true)]
        //public ScrollBars ScrollBars
        //{
        //    get
        //    {
        //        return txtInside.ScrollBars;
        //    }
        //    set
        //    {
        //        txtInside.ScrollBars = value;

        //    }
        //}

        ///// <summary>
        ///// 获取或用户控件属性文本框的滚动条显示方式。
        ///// </summary>
        //[Category("用户控件属性")]
        //[Description("控制能否更改编辑器控件中的文本")]
        //[Browsable(true)]
        //public bool ReadOnly
        //{
        //    get
        //    {
        //        return txtInside.ReadOnly;
        //    }
        //    set
        //    {
        //        if (value)
        //        {
        //            txtInside.BackColor = SystemColors.Info;
        //        }
        //        else
        //        {
        //            txtInside.BackColor = Color.White;
        //        }
        //        txtInside.ReadOnly = value;
        //    }
        //}

        ///// <summary>
        ///// 获取或用户控件属性密码字符。
        ///// </summary>
        //[Category("用户控件属性")]
        //[Description("获取或用户控件属性密码字符。")]
        //[Browsable(true)]
        //public char PasswordChar
        //{
        //    get
        //    {
        //        return txtInside.PasswordChar;
        //    }
        //    set
        //    {
        //        txtInside.PasswordChar = value;

        //    }
        //}

        ///// <summary>
        ///// 选择文本框中的所有文本
        ///// </summary>
        //public void SelectAll()
        //{
        //    txtInside.SelectAll();
        //}

        ///// <summary>
        ///// 输入焦点丢失时，改变相关子控件的颜色。
        ///// </summary>
        //void TxtBox_Leave(object sender, EventArgs e)
        //{
        //    BackColor = Color.White;
        //    PnlBorder.BackColor = Color.FromArgb(204, 204, 204);
        //    txtInside.ForeColor = Color.FromArgb(102, 102, 102);
        //}

        ///// <summary>
        ///// 获得输入焦点时，改变相关子控件的颜色。
        ///// </summary>
        //void TxtBox_GotFocus(object sender, EventArgs e)
        //{
        //    BackColor = Color.FromArgb(179, 221, 150);
        //    PnlBorder.BackColor = Color.FromArgb(87, 152, 43);
        //    txtInside.ForeColor = Color.FromArgb(51, 102, 0);
        //}

        //void TxtBox_OnKeyKown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        //    {
        //        SendKeys.Send("{TAB}");
        //    }
        //}

        ///// <summary>
        ///// 可以手动通过该方法，使TextBox获得输入焦点。
        ///// </summary>
        //public new void Focus()
        //{
        //    txtInside.Select();
        //}

        ///// <summary>
        ///// TextBox控件大小改变时的事件处理。
        ///// </summary>
        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    if (!Multiline)
        //    {
        //        this.Height = 27;
        //    }
        //    txtInside.Location = new Point(3, 5);
        //    txtInside.Width = PnlWhiteBG.Width - 6;
        //    txtInside.Height = PnlWhiteBG.Height - 10;
        //}      
    }
}
