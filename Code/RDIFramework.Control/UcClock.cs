/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-4 15:41:52
 ******************************************************************************/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// UcClock
    /// 时钟控件
    /// 
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(UcClock), "Images.UcClockControl.png")]
    public partial class UcClock : UserControl
    {
        public UcClock()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            myTimer = new Timer();
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.Tick += new EventHandler(myTimer_Tick);
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private Timer myTimer;//定义时钟，定时重新绘制
        private Graphics g;//创建画布
        private Pen pen;//创建画笔       
        private int width;//画布高度
        private int height;//画布宽度
        Color hourColor = Color.Red;

        /// <summary>
        /// 时钟颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("时钟颜色")]
        public Color HourColor
        {
            get { return hourColor; }
            set { hourColor = value; }
        }

        Color minuteColor = Color.Green;
        /// <summary>
        /// 分钟颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("分钟颜色")]
        public Color MinuteColor
        {
            get { return minuteColor; }
            set { minuteColor = value; }
        }

        Color secondColor = Color.Blue;
        /// <summary>
        /// 秒钟颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("秒钟颜色")]
        public Color SecondColor
        {
            get { return secondColor; }
            set { secondColor = value; }
        }

        Color bigScaleColor = Color.DarkGreen;
        /// <summary>
        /// 大刻度颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("大刻度颜色")]
        public Color BigScaleColor
        {
            get { return bigScaleColor; }
            set { bigScaleColor = value; }
        }

        Color litterScaleColor = Color.Olive;
        /// <summary>
        /// 小刻度颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("小刻度颜色")]
        public Color LitterScaleColor
        {
            get { return litterScaleColor; }
            set { litterScaleColor = value; }
        }

        Color textColor = Color.White;
        /// <summary>
        /// 刻度值颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("刻度值颜色")]
        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        Color bigBackColor = Color.Black;
        /// <summary>
        /// 外圆背景色
        /// </summary>
        [CategoryAttribute("颜色"), Description("外圆背景颜色")]
        public Color BigBackColor
        {
            get { return bigBackColor; }
            set { bigBackColor = value; }
        }

        Color litterBackColor = Color.White;
        /// <summary>
        /// 内圆颜色
        /// </summary>
        [CategoryAttribute("颜色"), Description("内圆颜色")]
        public Color LitterBackColor
        {
            get { return litterBackColor; }
            set { litterBackColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; //
            g.SmoothingMode = SmoothingMode.HighQuality;//绘图模式 默认为粗糙模式，将会出现锯齿！
            width = this.Width;//时钟宽度
            height = this.Height;//时钟高度
            int x1 = 0;//开始绘制时钟起点X坐标
            int y1 = 0;//开始绘制时钟起点Y坐标
            /*------------------------------------------------------------------------------
            计算：整点刻度12个，每个刻度偏移角度为360/12 = 30 度 及为小时偏移角度
                  分秒刻度为60个，每个刻度偏移角度为360/60 = 6 度 及为分、秒偏移角度
            --------------------------------------------------------------------------------*/
            g.FillEllipse(new SolidBrush(bigBackColor), x1 + 2, y1 + 2, width - 4, height - 4);  //外圆
            pen = new Pen(new SolidBrush(litterBackColor), 2);
            g.DrawEllipse(pen, x1 + 7, y1 + 7, width - 13, height - 13);// 内圆
            g.TranslateTransform(x1 + (width / 2), y1 + (height / 2));//重新设置坐标原点
            g.FillEllipse(Brushes.White, -5, -5, 10, 10);//绘制表盘中心

            for (int x = 0; x < 60; x++)  //小刻度
            {
                g.FillRectangle(new SolidBrush(litterScaleColor), new Rectangle(-2, (System.Convert.ToInt16(height - 8) / 2 - 2) * (-1), 3, 10));
                g.RotateTransform(6);//偏移角度
            }
            for (int i = 12; i > 0; i--)  //大刻度
            {
                string myString = i.ToString();
                //绘制整点刻度
                g.FillRectangle(new SolidBrush(bigScaleColor), new Rectangle(-3, (System.Convert.ToInt16(height - 8) / 2 - 2) * (-1), 6, 20));
                //绘制数值
                g.DrawString(myString, new Font(new FontFamily("Times New Roman"), 14, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(textColor), new PointF(myString.Length * (-6), (height - 8) / -2 + 26));
                //顺时针旋转30度
                g.RotateTransform(-30);//偏移角度
            }
            //获得系统时间值
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            /*------------------------------------------------------------------------------------
            每秒偏移6度，秒针偏移=当前秒*6
            每分偏移6读，分针偏移 = 当前分*6+当前秒*（6/60）
            每小时偏移60读，时针偏移 = 当前时*30+当前分*（6/60）+当前秒*（6/60/60）
            --------------------------------------------------------------------------------------*/
            //绘秒针
            pen = new Pen(secondColor, 1);
            pen.EndCap = LineCap.ArrowAnchor;
            g.RotateTransform(6 * second);
            float y = (float)((-1) * (height / 2.75));
            g.DrawLine(pen, new PointF(0, 0), new PointF((float)0, y));
            ////绘分针
            pen = new Pen(minuteColor, 4);
            pen.EndCap = LineCap.ArrowAnchor;
            g.RotateTransform(-6 * second);  //恢复系统偏移量，再计算下次偏移
            g.RotateTransform((float)(second * 0.1 + minute * 6));
            y = (float)((-1) * ((height - 30) / 2.75));
            g.DrawLine(pen, new PointF(0, 0), new PointF((float)0, y));
            ////绘时针
            pen = new Pen(hourColor, 6);
            pen.EndCap = LineCap.ArrowAnchor;
            g.RotateTransform((float)(-second * 0.1 - minute * 6));//恢复系统偏移量，再计算下次偏移
            g.RotateTransform((float)(second * 0.01 + minute * 0.1 + hour * 30));
            y = (float)((-1) * ((height - 45) / 2.75));
            g.DrawLine(pen, new PointF(0, 0), new PointF((float)0, y));
        }  
    }
}
