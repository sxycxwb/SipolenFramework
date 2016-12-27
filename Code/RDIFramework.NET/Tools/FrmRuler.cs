using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace RDIFramework.NET
{
    /// <summary>
    /// FrmRuler
    /// 屏幕尺
    /// 
    /// <author>XuWangBin</author>
    /// <create>2012-09-26</create>
    /// </summary>
    public partial class FrmRuler : Form
    {
        public FrmRuler()
        {
            InitializeComponent();
            this.size = new Size(this.Width, this.Height);
            this.pen = new Pen(Color.Black, float.Epsilon);
            this.format = new StringFormat(StringFormat.GenericTypographic);
            this.format.FormatFlags = StringFormatFlags.NoWrap;
            this.format.Trimming = StringTrimming.Character;
        }

        private void FrmRuler_Load(object sender, EventArgs e)
        {
            this.ContextMenuStrip = this.contextMenu;
            this.Horizontal = true;
        }

        private Size size;

        private void EnsureVisible()
        {
            Rectangle screen = Screen.FromControl(this).Bounds;
            Rectangle ruler = this.Bounds;
            Rectangle r = Rectangle.Intersect(screen, ruler);
            int w = this.MinimumSize.Width / 2;
            if (r.Width < w)
            {
                this.Location = new Point(
                    Math.Max(screen.X - ruler.Width + w, Math.Min(ruler.X, screen.Right - w)),
                    this.Location.Y
                );
            }
            int h = this.MinimumSize.Height / 2;
            if (r.Height < h)
            {
                this.Location = new Point(
                    this.Location.X,
                    Math.Max(screen.Y - ruler.Height + h, Math.Min(ruler.Y, screen.Bottom - h))
                );
            }
        }

        private bool horizontal;
        private bool Horizontal
        {
            get { return this.horizontal; }
            set
            {
                this.horizontal = value;
                if (this.horizontal)
                {
                    this.Size = new Size(this.size.Width, this.MinimumSize.Height);
                }
                else
                {
                    this.Size = new Size(this.MinimumSize.Width, this.size.Height);
                }
                this.EnsureVisible();
            }
        }

        //---------------------------------------------------------------------

        private Point movePoint;
        private bool isMoving = false;
        private bool isLeftSizing = false;
        private bool isRightSizing = false;
        private bool isTopSizing = false;
        private bool isBottomSizing = false;

        private void FrmRuler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks <= 1 && e.Button == MouseButtons.Left)
            {
                if (this.Horizontal)
                {
                    if (e.X <= 3)
                    {
                        this.isLeftSizing = this.Capture = true;
                    }
                    else if (e.X >= this.Width - 3)
                    {
                        this.isRightSizing = this.Capture = true;
                    }
                    else
                    {
                        this.isMoving = this.Capture = true;
                    }
                }
                else
                {
                    if (e.Y <= 3)
                    {
                        this.isTopSizing = this.Capture = true;
                    }
                    else if (e.Y >= this.Height - 3)
                    {
                        this.isBottomSizing = this.Capture = true;
                    }
                    else
                    {
                        this.isMoving = this.Capture = true;
                    }
                }
                this.movePoint = this.PointToScreen(new Point(e.X, e.Y));
            }
        }

        private void FrmRuler_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Capture && e.Button == MouseButtons.Left)
            {
                this.isMoving =
                this.isLeftSizing =
                this.isRightSizing =
                this.isTopSizing =
                this.isBottomSizing =
                this.Capture = false;
                this.EnsureVisible();
                this.Invalidate();
            }
        }

        private void FrmRuler_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Capture)
            {
                Point p = this.PointToScreen(new Point(e.X, e.Y));
                Rectangle ruler = this.Bounds;
                Size min = this.MinimumSize;
                if (this.isMoving)
                {
                    this.Location = new Point(
                        ruler.X + p.X - this.movePoint.X,
                        ruler.Y + p.Y - this.movePoint.Y
                    );
                }
                else if (this.isLeftSizing)
                {
                    this.Bounds = new Rectangle(
                        ruler.X + p.X - this.movePoint.X,
                        ruler.Y,
                        ruler.Width - p.X + this.movePoint.X,
                        min.Height
                    );
                    this.size.Width = this.Width;
                }
                else if (this.isRightSizing)
                {
                    this.Size = new Size(ruler.Width + p.X - this.movePoint.X, ruler.Height);
                    this.size.Width = this.Width;
                }
                else if (this.isTopSizing)
                {
                    this.Bounds = new Rectangle(
                        ruler.X,
                        ruler.Y + p.Y - this.movePoint.Y,
                        min.Width,
                        ruler.Height - p.Y + this.movePoint.Y
                    );
                    this.size.Height = this.Height;
                }
                else if (this.isBottomSizing)
                {
                    this.Size = new Size(min.Width, ruler.Height + p.Y - this.movePoint.Y);
                    this.size.Height = this.Height;
                }
                this.movePoint = p;
                //this.Invalidate();
            }
            else
            {
                if (this.Horizontal)
                {
                    if (e.X <= 3 || e.X >= this.Width - 3)
                    {
                        this.Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (e.Y <= 3 || e.Y >= this.Height - 3)
                    {
                        this.Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void FrmRuler_KeyDown(object sender, KeyEventArgs e)
        {
            int step = e.Shift ? 10 : 1;
            if (e.KeyCode == Keys.Left)
            {
                if (e.Control && this.Horizontal)
                {
                    this.Width -= step;
                    this.size.Width = this.Width;
                }
                else
                {
                    this.Location = new Point(this.Location.X - step, this.Location.Y);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (e.Control && this.Horizontal)
                {
                    this.Width += step;
                    this.size.Width = this.Width;
                }
                else
                {
                    this.Location = new Point(this.Location.X + step, this.Location.Y);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (e.Control && !this.Horizontal)
                {
                    this.Height -= step;
                    this.size.Height = this.Height;
                }
                else
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - step);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (e.Control && !this.Horizontal)
                {
                    this.Height += step;
                    this.size.Height = this.Height;
                }
                else
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + step);
                }
                this.EnsureVisible();
                this.Invalidate();
            }
        }

        private void mnuItemFlipRuler_Click(object sender, EventArgs e)
        {
            this.Horizontal = !this.Horizontal;
            this.Invalidate();
        }

        private void mnuItemPixels_Click(object sender, EventArgs e)
        {
            this.mnuItemPixels.Checked = true;
            this.mnuItemInches.Checked = false;
            this.mnuItemCentimeters.Checked = false;
            this.Invalidate();
        }

        private void mnuItemInches_Click(object sender, EventArgs e)
        {
            this.mnuItemPixels.Checked = false;
            this.mnuItemInches.Checked = true;
            this.mnuItemCentimeters.Checked = false;
            this.Invalidate();
        }

        private void mnuItemCentimeters_Click(object sender, EventArgs e)
        {
            this.mnuItemPixels.Checked = false;
            this.mnuItemInches.Checked = false;
            this.mnuItemCentimeters.Checked = true;
            this.Invalidate();
        }

        private void mnuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Pen pen;
        private StringFormat format;

        private void FrmRuler_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int scale;
            int step;
            int small;
            int big;
            int number;
            string unit;
            if (this.mnuItemPixels.Checked)
            {
                step = 5;
                small = 10;
                big = 50;
                number = 100;
                scale = 1;
                unit = " Pixels";
            }
            else if (this.mnuItemInches.Checked)
            {
                g.PageUnit = GraphicsUnit.Inch;
                g.PageScale = 1f / 12f;
                step = 1;
                small = 2;
                big = 6;
                number = 12;
                scale = 12;
                unit = "\"";
            }
            else
            { //Cm.
                g.PageUnit = GraphicsUnit.Millimeter;
                g.PageScale = 1f;
                step = 1;
                small = 5;
                big = 10;
                number = 10;
                scale = 10;
                unit = " Cm.";
            }
            PointF[] point = new PointF[] {
				new PointF(2, 2), new PointF(5, 5), new Point(this.Size), this.Location
			};
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, point);
            float infoDelta = this.Horizontal ? point[0].Y : point[0].X;
            float stroke = this.Horizontal ? point[1].Y : point[1].X;
            int length = (int)(point[2].X + point[2].Y);

            if (!this.Horizontal)
            {
                g.RotateTransform(90, MatrixOrder.Prepend);
                g.TranslateTransform(point[2].X, 0, MatrixOrder.Append);
            }

            for (int i = 0; i < length; i += step)
            {
                float d = 1;
                if (i % small == 0)
                {
                    if (i % big == 0)
                    {
                        d = 3;
                    }
                    else
                    {
                        d = 2;
                    }
                }
                g.DrawLine(this.pen, i, 0f, i, d * stroke);
                if ((i % number) == 0)
                {
                    string text = (i / scale).ToString(CultureInfo.InvariantCulture);
                    SizeF size = g.MeasureString(text, this.Font, length, this.format);
                    g.DrawString(text, this.Font, Brushes.Black, i - size.Width / 2, d * stroke, this.format);
                }
            }
            string info = string.Format(CultureInfo.InvariantCulture,
                "X={0} Y={1} Length={2}{3}",
                Math.Round(point[3].X / scale, 1),
                Math.Round(point[3].Y / scale, 1),
                Math.Round((float)(this.Horizontal ? point[2].X : point[2].Y) / scale, 1),
                unit
            );
            SizeF infoSize = g.MeasureString(info, this.Font, length, this.format);
            float y = (float)(this.Horizontal ? point[2].Y : point[2].X);
            g.DrawString(info, this.Font, Brushes.Black,
                (y - infoSize.Height) / 2, y - infoSize.Height - infoDelta, this.format
            );
        }
    }
}
