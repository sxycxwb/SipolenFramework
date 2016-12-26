using System;
using System.Windows.Forms;
using System.Drawing;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	///�����ṩȦѡһ����������ڵ�Ĺ���
	/// </summary>
	public class Rubberband
	{
		/// <summary>
		/// ���ؼ�
		/// </summary>
		protected WorkPlace parent;

		/// <summary>
		/// ��ƤȦ��Χ
		/// </summary>
		protected Rectangle	rect = Rectangle.Empty;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="theParent">���ؼ�</param>
		/// <param name="theStartingPoint"></param>
		public Rubberband(WorkPlace theParent, Point theStartingPoint)
		{	
			parent = theParent;
			parent.Capture = true;//����Captureָʾ�Ƿ��ȡ���
            //Cursor.Clip = parent.RectangleToScreen(parent.ClientRectangle);//������귶Χ
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
		/// ��thePointָ����λ����Ϊ��ƤȦ�����½����꣬������ƤȦ���εĴ�С�������»�����ƤȦ
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
		/// ��rect�����������ľ��Σ�����߽�����С���ұ߽����꣬�ϱ߽�����С���±߽����ꡣ
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
