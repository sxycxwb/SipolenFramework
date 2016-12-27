/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:28
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:08
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RDIFramework.Controls
{
    internal class RenderHelper
    {
        internal static void RenderBackgroundInternal(
            Graphics g,
            Rectangle rect,
            Color baseColor,
            Color borderColor,
            Color innerBorderColor,
            RoundStyle style,
            bool drawBorder,
            bool drawGlass,
            LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                g,
                rect,
                baseColor,
                borderColor,
                innerBorderColor,
                style,
                8,
                drawBorder,
                drawGlass,
                mode);
        }

        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
            RenderBackgroundInternal(
                 g,
                 rect,
                 baseColor,
                 borderColor,
                 innerBorderColor,
                 style,
                 8,
                 0.45f,
                 drawBorder,
                 drawGlass,
                 mode);
        }

        internal static void RenderBackgroundInternal(
           Graphics g,
           Rectangle rect,
           Color baseColor,
           Color borderColor,
           Color innerBorderColor,
           RoundStyle style,
           int roundWidth,
           float basePosition,
           bool drawBorder,
           bool drawGlass,
           LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, Color.Transparent, Color.Transparent, mode))
            {
                Color[] colors = new Color[4];
                colors[0] = GetColor(baseColor, 0, 35, 24, 9);
                colors[1] = GetColor(baseColor, 0, 13, 8, 3);
                colors[2] = baseColor;
                colors[3] = GetColor(baseColor, 0, 35, 24, 9);

                ColorBlend blend = new ColorBlend();
                blend.Positions = new float[] { 0.0f, basePosition, basePosition + 0.05f, 1.0f };
                blend.Colors = colors;
                brush.InterpolationColors = blend;
                if (style != RoundStyle.None)
                {
                    using (GraphicsPath path =
                        GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                    {
                        g.FillPath(brush, path);
                    }

                    if (baseColor.A > 80)
                    {
                        Rectangle rectTop = rect;

                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectTop.Height = (int)(rectTop.Height * basePosition);
                        }
                        else
                        {
                            rectTop.Width = (int)(rect.Width * basePosition);
                        }
                        using (GraphicsPath pathTop = GraphicsPathHelper.CreatePath(
                            rectTop, roundWidth, RoundStyle.Top, false))
                        {
                            using (SolidBrush brushAlpha =
                                new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                            {
                                g.FillPath(brushAlpha, pathTop);
                            }
                        }
                    }

                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        ControlPaintEx.DrawGlass(g, glassRect, 170, 0);
                    }

                    if (drawBorder)
                    {
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(borderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }

                        rect.Inflate(-1, -1);
                        using (GraphicsPath path =
                            GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            using (Pen pen = new Pen(innerBorderColor))
                            {
                                g.DrawPath(pen, path);
                            }
                        }
                    }
                }
                else
                {
                    g.FillRectangle(brush, rect);
                    if (baseColor.A > 80)
                    {
                        Rectangle rectTop = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            rectTop.Height = (int)(rectTop.Height * basePosition);
                        }
                        else
                        {
                            rectTop.Width = (int)(rect.Width * basePosition);
                        }
                        using (SolidBrush brushAlpha =
                            new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
                        {
                            g.FillRectangle(brushAlpha, rectTop);
                        }
                    }

                    if (drawGlass)
                    {
                        RectangleF glassRect = rect;
                        if (mode == LinearGradientMode.Vertical)
                        {
                            glassRect.Y = rect.Y + rect.Height * basePosition;
                            glassRect.Height = (rect.Height - rect.Height * basePosition) * 2;
                        }
                        else
                        {
                            glassRect.X = rect.X + rect.Width * basePosition;
                            glassRect.Width = (rect.Width - rect.Width * basePosition) * 2;
                        }
                        ControlPaintEx.DrawGlass(g, glassRect, 200, 0);
                    }

                    if (drawBorder)
                    {
                        using (Pen pen = new Pen(borderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }

                        rect.Inflate(-1, -1);
                        using (Pen pen = new Pen(innerBorderColor))
                        {
                            g.DrawRectangle(pen, rect);
                        }
                    }
                }
            }
        }

        internal static Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(0, a + a0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(0, r + r0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(0, g + g0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(0, b + b0); }

            return Color.FromArgb(a, r, g, b);
        }
    }


    public static class GraphicsPathHelper
    {
        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="_radius">圆角的大小。</param>
        /// <param name="style">圆角的样式。</param>
        /// <param name="correction">是否把矩形长宽减 1,以便画出边框。</param>
        /// <returns>建立的路径。</returns>
        public static GraphicsPath CreatePath(
            Rectangle rect, int radius, RoundStyle style, bool correction)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = correction ? 1 : 0;
            switch (style)
            {
                case RoundStyle.None:
                    path.AddRectangle(rect);
                    break;
                case RoundStyle.All:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius, 0, 90);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    break;
                case RoundStyle.Left:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Y,
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    break;
                case RoundStyle.Right:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddArc(
                       rect.Right - radius - radiusCorrection,
                       rect.Bottom - radius - radiusCorrection,
                       radius,
                       radius,
                       0,
                       90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    break;
                case RoundStyle.Top:
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Y,
                        radius,
                        radius,
                        270,
                        90);
                    path.AddLine(
                        rect.Right - radiusCorrection, rect.Bottom - radiusCorrection,
                        rect.X, rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.Bottom:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        0,
                        90);
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
                case RoundStyle.BottomLeft:
                    path.AddArc(
                        rect.X,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        90,
                        90);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    path.AddLine(
                        rect.Right - radiusCorrection,
                        rect.Y,
                        rect.Right - radiusCorrection,
                        rect.Bottom - radiusCorrection);
                    break;
                case RoundStyle.BottomRight:
                    path.AddArc(
                        rect.Right - radius - radiusCorrection,
                        rect.Bottom - radius - radiusCorrection,
                        radius,
                        radius,
                        0,
                        90);
                    path.AddLine(rect.X, rect.Bottom - radiusCorrection, rect.X, rect.Y);
                    path.AddLine(rect.X, rect.Y, rect.Right - radiusCorrection, rect.Y);
                    break;
            }
            path.CloseFigure();

            return path;
        }
    }
}
