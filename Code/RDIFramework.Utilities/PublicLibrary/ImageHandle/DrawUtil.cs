using System.Drawing;
using System.Drawing.Drawing2D;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// DrawUtil
    /// 
    /// 
    /// </summary>
    public class DrawUtil
    {
        /// <summary>
        /// 拷贝控件背景图像
        /// </summary>
        private Bitmap GetScreenImage(System.Windows.Forms.Control c)
        {
            c.Visible = false;

            Bitmap bmp = new Bitmap(c.Width, c.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(c.Location, new Point(0, 0), c.Size);
            g.Dispose();

            c.Visible = true;

            return bmp;
        }

        //返回一个圆角图形
        public Region SetControlRegion(System.Windows.Forms.Control ctrol, int iMax)
        {
            GraphicsPath grap = new GraphicsPath();
            int j = iMax;
            for (int i = 0; i < ctrol.Height; i++)
            {
                if (i < iMax)
                    grap.AddRectangle(new Rectangle(j, i, ctrol.Width - 2 * j--, 1));
                else if (i > ctrol.Height - iMax)
                    grap.AddRectangle(new Rectangle(j, i, ctrol.Width - 2 * j++, 1));
                else
                    grap.AddRectangle(new Rectangle(0, i, ctrol.Width, 1));
            }

            return new Region(grap);
        }
    }
}
