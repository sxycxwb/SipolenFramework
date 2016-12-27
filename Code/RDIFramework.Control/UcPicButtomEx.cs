/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:42:10
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
    /// UcPicButtomEx
    /// </summary>
    [ToolboxItem(true)]
    [Description("UcPicButtomEx")]
    public partial class UcPicButtomEx : UserControl
    {
        public UcPicButtomEx()
        {
            InitializeComponent();
        }
        // Fields
        private Image _backImage = null;
        private int _barindex = 0;
        private int _bntindex = 0;
        private Color _BorderColor = Color.Black;
        private BorderStyle _BorderStyle = BorderStyle.None;
        private float _BorderWidth = 1f;
        private string _classname = "";
        private string _dllfile = "";
        private Font _Font = new Font("宋体", 11f);
        private FormOpenMode _frmopenmode = FormOpenMode.Normal;
        private Image _Image = null;
        private ContentAlignment _ImgAlign = ContentAlignment.MiddleCenter;
        private int _imgnuminAll = 0;
        private int _imgnuminImg = 100;
        private Image _MoveBackImage = null;
        private Color _MoveTextColor = Color.Red;
        private string _Text = "UcPicbuttom";
        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        private Color _TextColor = Color.Black;
        private Color _TextColorF = Color.Black;
        private TextImageRelation _TextImageRelation = TextImageRelation.ImageBeforeText;
        private StringFormat _TextStyle = new StringFormat();
        private int _type = 0;
        //private IContainer components = null;
        private float imgH;
        private float imgW;
        public Parameters pars = new Parameters();
        private RectangleF rectTEXT = new RectangleF();
        private float zsmX;
        private float zsmY;

        private void setInit()
        {
            ContentAlignment alignment;
            float width = 0f;
            float height = 0f;
            switch (this._TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    width = (base.Width * this._imgnuminAll) / 100;
                    height = (base.Height * this._imgnuminAll) / 100;
                    this.imgW = (width * this._imgnuminImg) / 100f;
                    this.imgH = (height * this._imgnuminImg) / 100f;
                    this.rectTEXT.Width = base.Width;
                    this.rectTEXT.Height = base.Height;
                    this.rectTEXT.X = 0f;
                    this.rectTEXT.Y = 0f;
                    alignment = this._ImgAlign;
                    if (alignment > ContentAlignment.MiddleCenter)
                    {
                        if (alignment <= ContentAlignment.BottomLeft)
                        {
                            switch (alignment)
                            {
                                case ContentAlignment.MiddleRight:
                                    this.zsmX = (base.Width - width) + (width - this.imgW);
                                    this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                                    break;

                                case ContentAlignment.BottomLeft:
                                    this.zsmX = (base.Width - width) / 2f;
                                    this.zsmY = ((base.Height - height) / 2f) + (height - this.imgH);
                                    break;
                            }
                        }
                        else if (alignment == ContentAlignment.BottomCenter)
                        {
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = ((base.Height - height) / 2f) + (height - this.imgH);
                        }
                        else if (alignment == ContentAlignment.BottomRight)
                        {
                            this.zsmX = (base.Width - width) + (width - this.imgW);
                            this.zsmY = (((base.Height - height) / 2f) + height) - this.imgH;
                            break;
                        }
                        break;
                    }
                    switch (alignment)
                    {
                        case ContentAlignment.TopLeft:
                            this.zsmX = (base.Width - width) / 2f;
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.TopCenter:
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.TopRight:
                            this.zsmX = (base.Width - width) + (width - this.imgW);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.MiddleLeft:
                            this.zsmX = (base.Width - width) / 2f;
                            this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                            break;

                        case ContentAlignment.MiddleCenter:
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                            break;
                    }
                    break;

                case TextImageRelation.ImageAboveText:
                    width = base.Width;
                    height = (base.Height * this._imgnuminAll) / 100;
                    this.imgW = (width * this._imgnuminImg) / 100f;
                    this.imgH = (height * this._imgnuminImg) / 100f;
                    this.rectTEXT.Width = base.Width;
                    this.rectTEXT.Height = base.Height - height;
                    this.rectTEXT.X = 0f;
                    this.rectTEXT.Y = height;
                    alignment = this._ImgAlign;
                    if (alignment > ContentAlignment.MiddleCenter)
                    {
                        if (alignment <= ContentAlignment.BottomLeft)
                        {
                            switch (alignment)
                            {
                                case ContentAlignment.MiddleRight:
                                    this.zsmX = (base.Width - width) + (width - this.imgW);
                                    this.zsmY = (((base.Height - this.rectTEXT.Height) - height) / 2f) + ((height - this.imgH) / 2f);
                                    break;

                                case ContentAlignment.BottomLeft:
                                    this.zsmX = (base.Width - width) / 2f;
                                    this.zsmY = (((base.Height - this.rectTEXT.Height) - height) / 2f) + (height - this.imgH);
                                    break;
                            }
                        }
                        else if (alignment == ContentAlignment.BottomCenter)
                        {
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = (((base.Height - this.rectTEXT.Height) - height) / 2f) + (height - this.imgH);
                        }
                        else if (alignment == ContentAlignment.BottomRight)
                        {
                            this.zsmX = (base.Width - width) + (width - this.imgW);
                            this.zsmY = ((((base.Height - this.rectTEXT.Height) - height) / 2f) + height) - this.imgH;
                            break;
                        }
                        break;
                    }
                    switch (alignment)
                    {
                        case ContentAlignment.TopLeft:
                            this.zsmX = (base.Width - width) / 2f;
                            this.zsmY = ((base.Height - this.rectTEXT.Height) - height) / 2f;
                            break;

                        case ContentAlignment.TopCenter:
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = ((base.Height - this.rectTEXT.Height) - height) / 2f;
                            break;

                        case ContentAlignment.TopRight:
                            this.zsmX = (base.Width - width) + (width - this.imgW);
                            this.zsmY = ((base.Height - this.rectTEXT.Height) - height) / 2f;
                            break;

                        case ContentAlignment.MiddleLeft:
                            this.zsmX = (base.Width - width) / 2f;
                            this.zsmY = (((base.Height - this.rectTEXT.Height) - height) / 2f) + ((height - this.imgH) / 2f);
                            break;

                        case ContentAlignment.MiddleCenter:
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = (((base.Height - this.rectTEXT.Height) - height) / 2f) + ((height - this.imgH) / 2f);
                            break;
                    }
                    break;

                case TextImageRelation.TextAboveImage:
                    width = base.Width;
                    height = (base.Height * this._imgnuminAll) / 100;
                    this.imgW = (width * this._imgnuminImg) / 100f;
                    this.imgH = (height * this._imgnuminImg) / 100f;
                    this.rectTEXT.Width = base.Width;
                    this.rectTEXT.Height = base.Height - height;
                    this.rectTEXT.X = 0f;
                    this.rectTEXT.Y = 0f;
                    alignment = this._ImgAlign;
                    if (alignment > ContentAlignment.MiddleCenter)
                    {
                        if (alignment <= ContentAlignment.BottomLeft)
                        {
                            switch (alignment)
                            {
                                case ContentAlignment.MiddleRight:
                                    this.zsmX = (base.Width - width) + (width - this.imgW);
                                    this.zsmY = (this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f)) + ((height - this.imgH) / 2f);
                                    break;

                                case ContentAlignment.BottomLeft:
                                    this.zsmX = (base.Width - width) / 2f;
                                    this.zsmY = (this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f)) + (height - this.imgH);
                                    break;
                            }
                        }
                        else if (alignment == ContentAlignment.BottomCenter)
                        {
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = (this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f)) + (height - this.imgH);
                        }
                        else if (alignment == ContentAlignment.BottomRight)
                        {
                            this.zsmX = (base.Width - width) + (width - this.imgW);
                            this.zsmY = ((this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f)) + height) - this.imgH;
                            break;
                        }
                        break;
                    }
                    switch (alignment)
                    {
                        case ContentAlignment.TopLeft:
                            this.zsmX = (base.Width - width) / 2f;
                            this.zsmY = this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f);
                            break;

                        case ContentAlignment.TopCenter:
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f);
                            break;

                        case ContentAlignment.TopRight:
                            this.zsmX = (base.Width - width) + (width - this.imgW);
                            this.zsmY = this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f);
                            break;

                        case ContentAlignment.MiddleLeft:
                            this.zsmX = (base.Width - width) / 2f;
                            this.zsmY = (this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f)) + ((height - this.imgH) / 2f);
                            break;

                        case ContentAlignment.MiddleCenter:
                            this.zsmX = ((base.Width - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = (this.rectTEXT.Height + (((base.Height - this.rectTEXT.Height) - height) / 2f)) + ((height - this.imgH) / 2f);
                            break;
                    }
                    break;

                case TextImageRelation.ImageBeforeText:
                    width = (base.Width * this._imgnuminAll) / 100;
                    height = base.Height;
                    this.imgW = (width * this._imgnuminImg) / 100f;
                    this.imgH = (height * this._imgnuminImg) / 100f;
                    this.rectTEXT.Width = base.Width - width;
                    this.rectTEXT.Height = base.Height;
                    this.rectTEXT.X = width;
                    this.rectTEXT.Y = 0f;
                    alignment = this._ImgAlign;
                    if (alignment > ContentAlignment.MiddleCenter)
                    {
                        if (alignment <= ContentAlignment.BottomLeft)
                        {
                            switch (alignment)
                            {
                                case ContentAlignment.MiddleRight:
                                    this.zsmX = ((base.Width - this.rectTEXT.Width) - width) + (width - this.imgW);
                                    this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                                    break;

                                case ContentAlignment.BottomLeft:
                                    this.zsmX = ((base.Width - this.rectTEXT.Width) - width) / 2f;
                                    this.zsmY = ((base.Height - height) / 2f) + (height - this.imgH);
                                    break;
                            }
                        }
                        else if (alignment == ContentAlignment.BottomCenter)
                        {
                            this.zsmX = (((base.Width - this.rectTEXT.Width) - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = ((base.Height - height) / 2f) + (height - this.imgH);
                        }
                        else if (alignment == ContentAlignment.BottomRight)
                        {
                            this.zsmX = ((base.Width - this.rectTEXT.Width) - width) + (width - this.imgW);
                            this.zsmY = (((base.Height - height) / 2f) + height) - this.imgH;
                            break;
                        }
                        break;
                    }
                    switch (alignment)
                    {
                        case ContentAlignment.TopLeft:
                            this.zsmX = ((base.Width - this.rectTEXT.Width) - width) / 2f;
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.TopCenter:
                            this.zsmX = (((base.Width - this.rectTEXT.Width) - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.TopRight:
                            this.zsmX = ((base.Width - this.rectTEXT.Width) - width) + (width - this.imgW);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.MiddleLeft:
                            this.zsmX = ((base.Width - this.rectTEXT.Width) - width) / 2f;
                            this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                            break;

                        case ContentAlignment.MiddleCenter:
                            this.zsmX = (((base.Width - this.rectTEXT.Width) - width) / 2f) + ((width - this.imgW) / 2f);
                            this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                            break;
                    }
                    break;

                case TextImageRelation.TextBeforeImage:
                    width = (base.Width * this._imgnuminAll) / 100;
                    height = base.Height;
                    this.imgW = (width * this._imgnuminImg) / 100f;
                    this.imgH = (height * this._imgnuminImg) / 100f;
                    this.rectTEXT.Width = base.Width - width;
                    this.rectTEXT.Height = base.Height;
                    this.rectTEXT.X = 0f;
                    this.rectTEXT.Y = 0f;
                    alignment = this._ImgAlign;
                    if (alignment > ContentAlignment.MiddleCenter)
                    {
                        switch (alignment)
                        {
                            case ContentAlignment.MiddleRight:
                                this.zsmX = (this.rectTEXT.Width + ((base.Width - this.rectTEXT.Width) - width)) + (width - this.imgW);
                                this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                                break;

                            case ContentAlignment.BottomLeft:
                                this.zsmX = this.rectTEXT.Width + (((base.Width - this.rectTEXT.Width) - width) / 2f);
                                this.zsmY = ((base.Height - height) / 2f) + (height - this.imgH);
                                break;

                            case ContentAlignment.BottomCenter:
                                this.zsmX = (this.rectTEXT.Width + (((base.Width - this.rectTEXT.Width) - width) / 2f)) + ((width - this.imgW) / 2f);
                                this.zsmY = ((base.Height - height) / 2f) + (height - this.imgH);
                                break;

                            case ContentAlignment.BottomRight:
                                this.zsmX = (this.rectTEXT.Width + ((base.Width - this.rectTEXT.Width) - width)) + (width - this.imgW);
                                this.zsmY = (((base.Height - height) / 2f) + height) - this.imgH;
                                break;
                        }
                        break;
                    }
                    switch (alignment)
                    {
                        case ContentAlignment.TopLeft:
                            this.zsmX = this.rectTEXT.Width + (((base.Width - this.rectTEXT.Width) - width) / 2f);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.TopCenter:
                            this.zsmX = (this.rectTEXT.Width + (((base.Width - this.rectTEXT.Width) - width) / 2f)) + ((width - this.imgW) / 2f);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.TopRight:
                            this.zsmX = (this.rectTEXT.Width + ((base.Width - this.rectTEXT.Width) - width)) + (width - this.imgW);
                            this.zsmY = (base.Height - height) / 2f;
                            break;

                        case ContentAlignment.MiddleLeft:
                            this.zsmX = this.rectTEXT.Width + (((base.Width - this.rectTEXT.Width) - width) / 2f);
                            this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                            break;

                        case ContentAlignment.MiddleCenter:
                            this.zsmX = (this.rectTEXT.Width + (((base.Width - this.rectTEXT.Width) - width) / 2f)) + ((width - this.imgW) / 2f);
                            this.zsmY = ((base.Height - height) / 2f) + ((height - this.imgH) / 2f);
                            break;
                    }
                    break;
            }
        }

        private void UcPicbuttom_Load(object sender, EventArgs e)
        {
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.setInit();
            base.Invalidate();
        }

        private void UcPicbuttom_MouseEnter(object sender, EventArgs e)
        {
            this._TextColor = this._MoveTextColor;
            base.Invalidate();
            if (this._MoveBackImage != null)
            {
                this._backImage = this.BackgroundImage;
                this.BackgroundImage = this._MoveBackImage;
            }
        }

        private void UcPicbuttom_MouseLeave(object sender, EventArgs e)
        {
            this._TextColor = this._TextColorF;
            this.BackgroundImage = this._backImage;
            base.Invalidate();
        }

        private void UcPicbuttom_Paint(object sender, PaintEventArgs e)
        {
            if (this._Image != null)
            {
                e.Graphics.DrawImage(this._Image, this.zsmX, this.zsmY, this.imgW, this.imgH);
            }
            if (this._BorderStyle == BorderStyle.FixedSingle)
            {
                Pen pen = new Pen(this._BorderColor, this._BorderWidth);
                e.Graphics.DrawRectangle(pen, 0, 0, base.Width - 1, base.Height - 1);
            }
            if (this._Text.Length > 0)
            {
                SolidBrush brush = new SolidBrush(this._TextColor);
                e.Graphics.DrawString(this._Text, this._Font, brush, this.rectTEXT, this._TextStyle);
            }
        }

        private void UcPicbuttom_Resize(object sender, EventArgs e)
        {
            this.setInit();
            base.Invalidate();
        }

        // Properties
        [Description("设置或控件的背景图片"), Category("用户控件属性")]
        public Image backImage
        {
            get
            {
                return this._backImage;
            }
            set
            {
                this._backImage = value;
            }
        }

        [DefaultValue(0), Description("设置或返回面板索引"), Category("用户控件属性")]
        public int barindex
        {
            get
            {
                return this._barindex;
            }
            set
            {
                if ((value >= 0) || (value <= 0x3e8))
                {
                    this._barindex = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue(0), Category("用户控件属性"), Description("设置或返回按钮索引")]
        public int bntindex
        {
            get
            {
                return this._bntindex;
            }
            set
            {
                if ((value >= 0) || (value <= 0x3e8))
                {
                    this._bntindex = value;
                    base.Invalidate();
                }
            }
        }

        [Category("用户控件属性"), DefaultValue("UcPicbuttom"), Description("设置或返回按钮文本")]
        public string BntText
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
                base.Invalidate();
            }
        }

        [Category("用户控件属性"), Description("设置或返回边框的颜色")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
                base.Invalidate();
            }
        }

        public BorderStyle BorderStyle
        {
            get
            {
                return this._BorderStyle;
            }
            set
            {
                this._BorderStyle = value;
                base.Invalidate();
            }
        }

        [DefaultValue((double)1.0), Category("用户控件属性"), Description("设置或返回边框的宽度")]
        public float BorderWidth
        {
            get
            {
                return this._BorderWidth;
            }
            set
            {
                if (value >= 0f)
                {
                    this._BorderWidth = value;
                    base.Invalidate();
                }
            }
        }

        public string classname
        {
            get
            {
                return this._classname;
            }
            set
            {
                this._classname = value;
            }
        }

        public string dllfile
        {
            get
            {
                return this._dllfile;
            }
            set
            {
                this._dllfile = value;
            }
        }

        public Font Font
        {
            get
            {
                return this._Font;
            }
            set
            {
                this._Font = value;
                base.Invalidate();
            }
        }

        public FormOpenMode frmopenmode
        {
            get
            {
                return this._frmopenmode;
            }
            set
            {
                this._frmopenmode = value;
            }
        }

        [Category("用户控件属性"), DefaultValue((string)null), Description("设置或返回图像")]
        public Image Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                this._Image = value;
                base.Invalidate();
            }
        }

        [DefaultValue(0x20), Category("用户控件属性"), Description("设置或返回图片的位置")]
        public ContentAlignment ImgAlign
        {
            get
            {
                return this._ImgAlign;
            }
            set
            {
                this._ImgAlign = value;
                this.setInit();
                base.Invalidate();
            }
        }

        [Category("用户控件属性"), DefaultValue(40), Description("设置图片框占控件大小的比率")]
        public int imgnuminAll
        {
            get
            {
                return this._imgnuminAll;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    this._imgnuminAll = value;
                    this.setInit();
                    base.Invalidate();
                }
            }
        }

        [Category("用户控件属性"), Description("设置图片占图片框大小的比率"), DefaultValue(40)]
        public int imgnuminImg
        {
            get
            {
                return this._imgnuminImg;
            }
            set
            {
                if ((value >= 0) && (value <= 100))
                {
                    this._imgnuminImg = value;
                    this.setInit();
                    base.Invalidate();
                }
            }
        }

        [Description("设置或返回鼠标进入控件区域的背景图片"), Category("用户控件属性")]
        public Image MoveBackImage
        {
            get
            {
                return this._MoveBackImage;
            }
            set
            {
                this._MoveBackImage = value;
            }
        }

        [Category("用户控件属性"), Description("设置或返回鼠标进入控件区域的文本颜色")]
        public Color MoveTextColor
        {
            get
            {
                return this._MoveTextColor;
            }
            set
            {
                this._MoveTextColor = value;
            }
        }

        [DefaultValue(0x20), Description("设置或返回文本的对齐风格"), Category("用户控件属性")]
        public ContentAlignment TextAlign
        {
            get
            {
                return this._TextAlign;
            }
            set
            {
                this._TextAlign = value;
                switch (this._TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        this._TextStyle.Alignment = StringAlignment.Near;
                        this._TextStyle.LineAlignment = StringAlignment.Near;
                        goto Label_017D;

                    case ContentAlignment.TopCenter:
                        this._TextStyle.Alignment = StringAlignment.Center;
                        this._TextStyle.LineAlignment = StringAlignment.Near;
                        goto Label_017D;

                    case (ContentAlignment.TopCenter | ContentAlignment.TopLeft):
                        goto Label_017D;

                    case ContentAlignment.TopRight:
                        this._TextStyle.Alignment = StringAlignment.Far;
                        this._TextStyle.LineAlignment = StringAlignment.Near;
                        goto Label_017D;

                    case ContentAlignment.MiddleLeft:
                        this._TextStyle.Alignment = StringAlignment.Near;
                        this._TextStyle.LineAlignment = StringAlignment.Center;
                        goto Label_017D;

                    case ContentAlignment.MiddleCenter:
                        this._TextStyle.Alignment = StringAlignment.Center;
                        this._TextStyle.LineAlignment = StringAlignment.Center;
                        goto Label_017D;

                    case ContentAlignment.MiddleRight:
                        this._TextStyle.Alignment = StringAlignment.Far;
                        this._TextStyle.LineAlignment = StringAlignment.Center;
                        goto Label_017D;

                    case ContentAlignment.BottomLeft:
                        this._TextStyle.Alignment = StringAlignment.Near;
                        this._TextStyle.LineAlignment = StringAlignment.Far;
                        goto Label_017D;

                    case ContentAlignment.BottomCenter:
                        this._TextStyle.Alignment = StringAlignment.Center;
                        this._TextStyle.LineAlignment = StringAlignment.Far;
                        break;

                    case ContentAlignment.BottomRight:
                        this._TextStyle.Alignment = StringAlignment.Far;
                        this._TextStyle.LineAlignment = StringAlignment.Far;
                        goto Label_017D;
                }
            Label_017D:
                this.setInit();
                base.Invalidate();
            }
        }

        [Description("设置或返回文本颜色"), Category("用户控件属性")]
        public Color TextColor
        {
            get
            {
                return this._TextColor;
            }
            set
            {
                this._TextColor = value;
                this._TextColorF = value;
                base.Invalidate();
            }
        }

        [DefaultValue(4), Description("设置或返回文本与图片的相对位置"), Category("用户控件属性")]
        public TextImageRelation TextImageRelation
        {
            get
            {
                return this._TextImageRelation;
            }
            set
            {
                this._TextImageRelation = value;
                this.setInit();
                base.Invalidate();
            }
        }

        [Description("设置或返回控件类型，0表示按钮，1表示面板"), DefaultValue(0), Category("用户控件属性")]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                if ((value >= 0) && (value <= 2))
                {
                    this._type = value;
                    base.Invalidate();
                }
            }
        }
    }

    public class Parameter
    {
        // Fields
        private string _name;
        private parFlag _nFlag;
        private string _Parvalue;

        // Methods
        public Parameter()
        {
            this._name = "";
            this._Parvalue = "";
            this._nFlag = parFlag.other;
            this._name = "";
            this._Parvalue = "";
        }

        public Parameter(string name, parFlag flag, string parvalue)
        {
            this._name = "";
            this._Parvalue = "";
            this._nFlag = flag;
            this._name = name;
            this._Parvalue = parvalue;
        }

        // Properties
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public parFlag nFlag
        {
            get
            {
                return this._nFlag;
            }
            set
            {
                this._nFlag = value;
            }
        }

        public string Parvalue
        {
            get
            {
                return this._Parvalue;
            }
            set
            {
                this._Parvalue = value;
            }
        }
    }

    public class Parameters : List<Parameter>
    {
        // Properties
        public Parameter this[parFlag flag, string name]
        {
            get
            {
                foreach (Parameter par in this)
                {
                    if ((par.nFlag == flag) && (par.Name == name))
                    {
                        return par;
                    }
                }
                return null;
            }
        }

        public Parameter this[string name]
        {
            get
            {
                foreach (Parameter par in this)
                {
                    if (par.Name == name)
                    {
                        return par;
                    }
                }
                return null;
            }
        }
    }

    public enum parFlag
    {
        cnnstr = 2,
        other = 1
    }

    public enum FormOpenMode
    {
        Normal,
        Child,
        ModeDialog,
        exefile
    }
}
