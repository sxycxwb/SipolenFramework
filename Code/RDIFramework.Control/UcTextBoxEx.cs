/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:42:26
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
    /// 
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TextBox))]
    [Description("自定义的TextBox控件[传统样式]")]
    public partial class UcTextBoxEx : UserControl
    {
        #region 声明
        private Bitmap _TextBoxBackImg = ImageObject.GetResBitmap("RDIFramework.WinForm.Utilities.Images.Textbox.png");
        private State state = State.Normal;
        private bool _Isico = false;
        private Bitmap _Ico;
        private Padding _IcoPadding=new Padding(3,3,0,0);
        //枚鼠标状态
        private enum State
        {
            Normal = 1,
            MouseOver = 2,
            MouseDown = 3,
            Disable = 4,
            Default = 5
        }
        #endregion

        #region 构造
        public UcTextBoxEx()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            this.SetStyle(ControlStyles.Selectable, true);
            this.BackColor = Color.Transparent;
        }
        #endregion

        #region 属性
        [Category("用户控件属性"), Description("与控件关联的文本")]
        public string text
        {
            get
            {
                return BaseText.Text;
            }
            set
            {
                BaseText.Text = value;
            }
        }
       
        [Category("用户控件属性"), Description("输入最大字符数")]
        public int MaxLength
        {
            get { return BaseText.MaxLength; }
            set { BaseText.MaxLength = value; }       
        
        }
      
        [Category("用户控件属性"), Description("与控件关联的文本")]
        public new string Text
        {
            get
            {
                return BaseText.Text;
            }
            set
            {
                BaseText.Text = value;
            }
        }

        [Category("用户控件属性"), Description("将控件设为密码显示")]
        public bool IsPass
        {
            get
            {
                return BaseText.UseSystemPasswordChar;
            }
            set
            {
                BaseText.UseSystemPasswordChar = value;
            }
        }

        [Category("用户控件属性"), Description("密码显示字符")]
        public char PassChar
        {
            get
            {
                return BaseText.PasswordChar;
            }
            set
            {
                BaseText.PasswordChar = value;
            }
        }

        [Category("用户控件属性"), Description("将控件设为多行文本显示")]
        public bool Multiline
        {
            get
            {
                return BaseText.Multiline;
            }
            set
            {
                BaseText.Multiline = value;
                if (value)
                { BaseText.Height = this.Height - 6; }
                else
                {
                    base.Height = 22;
                    BaseText.Height = 16;
                    this.Invalidate();
                }

            }
        }

        [Category("用户控件属性"), Description("将控件设为多行文本显示")]
        public Font font
        {
            get
            {
                return BaseText.Font;
            }
            set
            {
                BaseText.Font = value;
            }
        }

        [Category("用户控件属性"), Description("将控件设为只读")]
        public bool ReadOnly
        {
            get
            {
                return BaseText.ReadOnly;
            }
            set
            {
                BaseText.ReadOnly = value;
            }
        }

        [Category("用户控件属性"), Description("多行文本的编辑行")]
        public String[] lines
        {
            get
            {
                return BaseText.Lines;
            }
            set
            {
                BaseText.Lines = value;
            }
        }

        [Category("用户控件属性"), Description("是否显示图标")]
        public bool Isico
        {
            get
            {
                return _Isico;
            }
            set
            {
                _Isico = value;
                if (value)
                {
                    if (_Ico != null)
                    {
                        BaseText.Location = new Point(_IcoPadding.Left + _Ico.Width, 3);
                        BaseText.Width = BaseText.Width - _IcoPadding.Left - _Ico.Width;
                    }
                    else
                    {
                        BaseText.Location = new Point(25, 3);
                        BaseText.Width = BaseText.Width - 25;
                    }
                }
                this.Invalidate();
            }
        }

        [Category("用户控件属性"), Description("图标文件")]
        public Bitmap Ico
        {
            get
            {
                return _Ico;
            }
            set
            {
                _Ico = value;
            }
        }

        [Category("用户控件属性"), Description("图标文件Padding")]
        public Padding IcoPadding
        {
            get { return _IcoPadding; }
            set {
                _IcoPadding = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 委托
        public event EventHandler IcoOnclick;
        #endregion

        #region 方法
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = this.ClientRectangle;
            Graphics g = e.Graphics;
            ImageDrawRect.DrawRect(g, _TextBoxBackImg, rc, Rectangle.FromLTRB(10, 10, 10, 10), (int)state, 5);
            if (_Isico)
            {
                if (_Ico != null)
                {
                    g.DrawImage(_Ico,new Point(_IcoPadding.Left,_IcoPadding.Top));
                }                            
            }            
            base.OnPaint(e);
        }

        private void AlTextBox_Resize(object sender, EventArgs e)
        {
            if (this.Height > 22)
            {
                Multiline = true;
            }
            else
            {
                this.Height = 22;
                Multiline = false;
            }
        }

        private void NotifyIcoOnclick()
        {
            if (IcoOnclick != null)
            {
                IcoOnclick(this, EventArgs.Empty);
            }
        }

        public void AppendText(string ss)
        {
            BaseText.AppendText(ss);
        }

        private void BaseText_MouseEnter(object sender, EventArgs e)
        {
            state = State.MouseOver;
            this.Invalidate();
        }

        private void BaseText_MouseLeave(object sender, EventArgs e)
        {
            state = State.Normal;
            this.Invalidate();
        }

        private void AlTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_Ico != null)
            {
                if (new Rectangle(_IcoPadding.Left, _IcoPadding.Top, _Ico.Width, _Ico.Height).Contains(e.X,e.Y))
                {
                    NotifyIcoOnclick();
                }
            }
        }

        private void AlTextBox_MouseEnter(object sender, EventArgs e)
        {
            state = State.MouseOver;
            this.Invalidate();
        }

        private void AlTextBox_MouseLeave(object sender, EventArgs e)
        {
            state = State.Normal;
            this.Invalidate();
        }
        #endregion
    }
}
