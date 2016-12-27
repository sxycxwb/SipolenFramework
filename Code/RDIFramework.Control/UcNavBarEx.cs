/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:39:02
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// UcNavBarEx
    /// 
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(UcNavBarEx), "Images.UcNavBarEx.png")]
    [Description("NavBar")]
    public partial class UcNavBarEx : UserControl
    {     
        // Fields
        private int _actbarindex = 1;
        private Image _barbackImg = null;
        private Image _barbackmoveImg = null;
        private int _barH = 40;
        private int _barLeft = 0;
        private zsmpictbnts _bars = new zsmpictbnts();
        private int _barW = 0;
        private int _bntH = 50;
        private int _bntJL = 30;
        private zsmpictbnts _bnts = new zsmpictbnts();
        private int _bntW = 50;
        private ImageList _ImageList = null;
        private int barmaxID = 0;
        private int bntmaxID = 0;
        private UcPicButtomEx cmddown;
        private UcPicButtomEx cmdup;
        private int topcount = 0;

        // Events
        public event EventHandler bntclick;
     

     

        // Methods
        public UcNavBarEx()
        {
            InitializeComponent();
        }

        public void Addbar(UcPicButtomEx bar)
        {
            this.barmaxID++;
            bar.barindex = this.barmaxID;
            bar.type = 1;
            bar.Click += new EventHandler(this.bar_Click);
            base.Controls.Add(bar);
        }

        public UcPicButtomEx Addbar(string _name, string _text, int _imgindex)
        {
            UcPicButtomEx zsmpictbnt = new UcPicButtomEx();
            zsmpictbnt.Visible = true;
            zsmpictbnt.Name = _name;
            zsmpictbnt.BntText = _text;
            this.barmaxID++;
            zsmpictbnt.barindex = this.barmaxID;
            zsmpictbnt.type = 1;
            zsmpictbnt.Click += new EventHandler(this.bar_Click);
            base.Controls.Add(zsmpictbnt);
            return zsmpictbnt;
        }

        public void Addbnt(int _barindex, UcPicButtomEx bnt)
        {
            this.bntmaxID++;
            bnt.bntindex = this.bntmaxID;
            bnt.barindex = _barindex;
            bnt.type = 0;
            bnt.Click += new EventHandler(this.bnt_Click);
            base.Controls.Add(bnt);
        }

        private void bar_Click(object sender, EventArgs e)
        {
            UcPicButtomEx zsmpictbnt = (UcPicButtomEx)sender;
            if ((zsmpictbnt.type == 1) && (this.actbarindex != zsmpictbnt.barindex))
            {
                this.actbarindex = zsmpictbnt.barindex;
                this.topcount = 0;
                this.setscroll();
            }
        }

        private void bnt_Click(object sender, EventArgs e)
        {
            if (this.bntclick != null)
            {
                this.bntclick(sender, new EventArgs());
            }
        }

        private void cmdup_Load(object sender, EventArgs e)
        {

        }

        private void cmddown_Click(object sender, EventArgs e)
        {
            this.topcount--;
            this.setscroll();
        }

        private void cmdup_Click(object sender, EventArgs e)
        {
            this.topcount++;
            this.setscroll();
        }
       
        public void setBL()
        {
            foreach (UcPicButtomEx zsmpictbnt in base.Controls)
            {
                if (zsmpictbnt.type == 1)
                {
                    zsmpictbnt.BackgroundImage = this._barbackImg;
                    zsmpictbnt.MoveBackImage = this._barbackmoveImg;
                    zsmpictbnt.Height = this._barH;
                    if (this._barW > 0)
                    {
                        zsmpictbnt.Width = this._barW;
                        zsmpictbnt.Left = this._barLeft;
                    }
                    else
                    {
                        zsmpictbnt.Width = base.Width;
                        zsmpictbnt.Left = 0;
                    }
                }
                else if (zsmpictbnt.type == 0)
                {
                    zsmpictbnt.Width = this._bntW;
                    zsmpictbnt.Height = this._bntH;
                    zsmpictbnt.Left = (base.Width - zsmpictbnt.Width) / 2;
                }
            }
        }

        public void setscroll()
        {
            if (this.barmaxID > 0)
            {
                UcPicButtomEx zsmpictbnt = null;
                int num = (this.actbarindex * this._barH) - (this.topcount * (this._bntH + this._bntJL));
                int num2 = 0;
                int num3 = 0;
                for (int i = 0; i < base.Controls.Count; i++)
                {
                    zsmpictbnt = (UcPicButtomEx)base.Controls[i];
                    if ((zsmpictbnt.type == 0) && zsmpictbnt.Visible)
                    {
                        num2++;
                        zsmpictbnt.Top = (num + (this._bntJL * num2)) + (this._bntH * (num2 - 1));
                        num3 = zsmpictbnt.Top + this._bntH;
                    }
                }
                this.cmddown.Top = (this.actbarindex * this._barH) + 5;
                this.cmddown.Left = (base.Width - this.cmddown.Width) - 10;
                if (this.topcount > 0)
                {
                    this.cmddown.Visible = true;
                }
                else
                {
                    this.cmddown.Visible = false;
                }
                int num5 = base.Height - ((this.barmaxID - this.actbarindex) * this._barH);
                this.cmdup.Left = (base.Width - this.cmdup.Width) - 10;
                this.cmdup.Top = (num5 - 5) - this.cmdup.Height;
                if (num3 >= num5)
                {
                    this.cmdup.Visible = true;
                }
                else
                {
                    this.cmdup.Visible = false;
                }
            }
        }

        private void UcNavBar_Load(object sender, EventArgs e)
        {
        }

        private void UcNavBar_Paint(object sender, PaintEventArgs e)
        {
            UcPicButtomEx zsmpictbnt = null;
            int num;
            for (num = 0; num < base.Controls.Count; num++)
            {
                zsmpictbnt = (UcPicButtomEx)base.Controls[num];
                if (zsmpictbnt.type == 1)
                {
                    if (zsmpictbnt.barindex > this.actbarindex)
                    {
                        break;
                    }
                    zsmpictbnt.Top = this._barH * (zsmpictbnt.barindex - 1);
                }
            }

            for (num = base.Controls.Count - 1; num > 0; num--)
            {
                zsmpictbnt = (UcPicButtomEx)base.Controls[num];
                if (zsmpictbnt.type == 1)
                {
                    if (zsmpictbnt.barindex <= this.actbarindex)
                    {
                        break;
                    }
                    zsmpictbnt.Top = base.Height - (((this.barmaxID - zsmpictbnt.barindex) + 1) * this._barH);
                }
            }
        }

        private void UcNavBar_Resize(object sender, EventArgs e)
        {
            this.setBL();
            this.setscroll();
        }

        // Properties
        [Description("设置或返回活动面板的索引"), Category("用户控件属性")]
        public int actbarindex
        {
            get
            {
                return this._actbarindex;
            }
            set
            {
                if ((value > 0) && (value <= this.barmaxID))
                {
                    this._actbarindex = value;
                    foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                    {
                        if (zsmpictbnt.type == 0)
                        {
                            if (zsmpictbnt.barindex == this._actbarindex)
                            {
                                zsmpictbnt.Visible = true;
                            }
                            else
                            {
                                zsmpictbnt.Visible = false;
                            }
                        }
                    }
                    base.Invalidate();
                }
            }
        }

        [Category("用户控件属性"), Description("设置或返回面板背景图片")]
        public Image barbackImg
        {
            get
            {
                return this._barbackImg;
            }
            set
            {
                this._barbackImg = value;
                foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                {
                    if (zsmpictbnt.type == 1)
                    {
                        zsmpictbnt.BackgroundImage = this._barbackImg;
                    }
                }
                base.Invalidate();
            }
        }

        [Category("用户控件属性"), Description("设置或返回面板鼠标移动的背景图片")]
        public Image barbackmoveImg
        {
            get
            {
                return this._barbackmoveImg;
            }
            set
            {
                this._barbackmoveImg = value;
                foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                {
                    if (zsmpictbnt.type == 1)
                    {
                        zsmpictbnt.MoveBackImage = this._barbackmoveImg;
                    }
                }
                base.Invalidate();
            }
        }

        [Description("设置或返回面板高度"), Category("用户控件属性")]
        public int barH
        {
            get
            {
                return this._barH;
            }
            set
            {
                this._barH = value;
                foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                {
                    if (zsmpictbnt.type == 1)
                    {
                        zsmpictbnt.Height = this._barH;
                    }
                }
                base.Invalidate();
            }
        }

        [Description("设置或返回面板左边距"), Category("用户控件属性")]
        public int barLeft
        {
            get
            {
                return this._barLeft;
            }
            set
            {
                this._barLeft = value;
                foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                {
                    if (zsmpictbnt.type == 1)
                    {
                        zsmpictbnt.Left = this._barLeft;
                    }
                }
                base.Invalidate();
            }
        }

        [Description("设置或返回面板列表"), Category("用户控件属性")]
        public zsmpictbnts bars
        {
            get
            {
                return this._bars;
            }
            set
            {
                this._bars = value;
                base.Invalidate();
            }
        }

        [Category("用户控件属性"), Description("设置或返回面板宽")]
        public int barW
        {
            get
            {
                return this._barW;
            }
            set
            {
                if (value >= 0)
                {
                    this._barW = value;
                    foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                    {
                        if (zsmpictbnt.type == 1)
                        {
                            zsmpictbnt.Width = this._barW;
                        }
                    }
                    base.Invalidate();
                }
            }
        }

        [Description("设置或返回按钮高度"), Category("用户控件属性")]
        public int bntH
        {
            get
            {
                return this._bntH;
            }
            set
            {
                if (value >= 0)
                {
                    this._bntH = value;
                    foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                    {
                        if (zsmpictbnt.type == 0)
                        {
                            zsmpictbnt.Height = this._bntH;
                        }
                    }
                    base.Invalidate();
                }
            }
        }

        [Category("用户控件属性"), Description("设置或返回按钮与按钮之间的距离")]
        public int bntJL
        {
            get
            {
                return this._bntJL;
            }
            set
            {
                this._bntJL = value;
                base.Invalidate();
            }
        }

        [Description("设置或返回按钮列表"), Category("用户控件属性")]
        public zsmpictbnts bnts
        {
            get
            {
                return this._bnts;
            }
            set
            {
                this._bnts = value;
                base.Invalidate();
            }
        }

        [Category("用户控件属性"), Description("设置或返回按钮宽度")]
        public int bntW
        {
            get
            {
                return this._bntW;
            }
            set
            {
                this._bntW = value;
                foreach (UcPicButtomEx zsmpictbnt in base.Controls)
                {
                    if (zsmpictbnt.type == 0)
                    {
                        zsmpictbnt.Width = this._bntW;
                    }
                }
                base.Invalidate();
            }
        }

        [Description("设置或返回图片列表"), Category("用户控件属性")]
        public ImageList ImageList
        {
            get
            {
                return this._ImageList;
            }
            set
            {
                this._ImageList = value;
                base.Invalidate();
            }
        }

    }

    public class zsmpictbnts : List<UcPicButtomEx>
    {
    }

}
