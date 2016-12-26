/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:28
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
    /// UcButton
    /// 自定义的Button控件
    /// 
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(UcButton), "Images.UcButton.png")]
    [Description("自定义的Button控件(DotNetBar样式)")]
    public partial class UcButton : DevComponents.DotNetBar.ButtonX//UserControl
    {
        public UcButton()
            : base()
        {
            //this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom)| System.Windows.Forms.AnchorStyles.Right)));
        }
        /*
        #region - 属性 -

        /// <summary>
        /// 获取或用户控件属性按钮上的文字。
        /// </summary>
        [Category("用户控件属性")]
        [Description("获取或用户控件属性按钮上的文字。")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return button.Text;
            }
            set
            {
                button.Text = value;
            }
        }

        #endregion

        #region - 构造函数 -

        /// <summary>
        /// 自定义Button控件的默认实例化方法。使用本自定义Button控件前，请确保应用程序的
        /// Properties.Resources资源文件中，包含了2张分别名为：ButtonBG01、ButtonBG02的图片。
        /// </summary>
        public UcButton()
        {
            InitializeComponent();

            button.MouseMove += new MouseEventHandler(button_MouseMove);
            button.MouseLeave += new EventHandler(button_MouseLeave);
            button.Click += new EventHandler(button_Click);
        }

        #endregion

        #region - 事件 -

        /// <summary>
        /// 用户单击按钮上的文字时，触发按钮的单击事件。
        /// </summary>
        void button_Click(object sender, EventArgs e)
        {
            this.OnClick(e);

        }

        /// <summary>
        /// 鼠标从按钮上移开时，改变相关子控件的颜色。
        /// </summary>
        void button_MouseLeave(object sender, EventArgs e)
        {
            button.BackgroundImage = Resources.ButtonBG01;
            button.ForeColor = Color.FromArgb(102, 102, 102);
            BackColor = Color.FromArgb(135, 163, 193);
        }

        /// <summary>
        /// 鼠标移动到按钮上时，改变相关子控件的颜色。
        /// </summary>
        void button_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(162, 144, 77);
            button.BackgroundImage = RDIFramework.Controls.Properties.Resources.ButtonBG02;
            button.ForeColor = Color.FromArgb(102, 51, 0);           
        }

        /// <summary>
        /// Button控件大小改变时的事件处理。
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Height = 26;
        }

        #endregion
         */
    }
}