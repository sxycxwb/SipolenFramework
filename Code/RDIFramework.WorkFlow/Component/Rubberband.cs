using System;
using System.Windows.Forms;
using System.Drawing;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	///此类提供圈选一个或多个任务节点的功能
	/// </summary>
	public class Rubberband
	{
		/// <summary>
		/// 父控件
		/// </summary>
		protected WorkPlace parent;

		/// <summary>
		/// 橡皮圈范围
		/// </summary>
		protected Rectangle	rect = Rectangle.Empty;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="theParent">父控件</param>
		/// <param name="theStartingPoint"></param>
		public Rubberband(WorkPlace theParent, Point theStartingPoint)
		{	
			parent = theParent;
			parent.Capture = true;//属性Capture指示是否获取鼠标
            //Cursor.Clip = parent.RectangleToScreen(parent.ClientRectangle);//控制鼠标范围
			rect = new Rectangle(theStartingPoint.X, theStartingPoint.Y, 0, 0);
		}

		public void End()
		{
            //Cursor.Clip = Rectangle.Empty;
			parent.Capture = false;
			// erase the rubberband
			Draw();			
			rect = Rectangle.Empty;
		}

		/// <summary>
		/// 用thePoint指定的位置作为橡皮圈的右下角坐标，调整橡皮圈矩形的大小，并重新绘制橡皮圈
		/// </summary>
		/// <param name="thePoint"></param>
		public void ResizeTo(Point thePoint)
		{
			// erase the old rubberband
			Draw();			
			// get the new size of the rubberband
			rect.Width =  thePoint.X - rect.Left;
			rect.Height = thePoint.Y - rect.Top;
			// draw the new rubberband
			Draw();			
		}

		/// <summary> 
		/// 将rect调整成正常的矩形，即左边界坐标小于右边界坐标，上边界坐标小于下边界坐标。
		/// </summary>
		/// <returns></returns>
		public Rectangle Bounds()
		{
			// return a normalized rectangle, i.e. a rect
			// where (left <= right) and (top <= bottom)
			if ( (rect.Left > rect.Right) || (rect.Top > rect.Bottom) )
			{
				int left = Math.Min(rect.Left, rect.Right);
				int right = Math.Max(rect.Left, rect.Right);
				int top = Math.Min(rect.Top, rect.Bottom);
				int bottom = Math.Max(rect.Top, rect.Bottom);
				return Rectangle.FromLTRB(left, top, right, bottom);
			}
			return rect;
		}

		/// <summary> 
		/// // Reversible drawing method
		/// / Calling this method the first time draws the rubberband.
		/// Calling it a second time with the same rect erases the rubberband
		///  Reversible drawing method  
		/// </summary>		
		protected void Draw()
		{
			Rectangle rect2 = new Rectangle(rect.Left + parent.AutoScrollPosition.X, rect.Top + parent.AutoScrollPosition.Y, rect.Width, rect.Height);
			Rectangle r = parent.RectangleToScreen(rect2);
			ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed);
		}
	}
}
