using System;
using System.Drawing;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
	public class GrabHandles
	{
		public GrabHandle[] handles;

		public GrabHandles(BaseComponent parent)
		{
			handles = new GrabHandle[]  
				{
					new GrabHandleNW(parent),
					new GrabHandleN(parent),
					new GrabHandleNE(parent),
					new GrabHandleE(parent),
					new GrabHandleSE(parent),
					new GrabHandleS(parent),
					new GrabHandleSW(parent),
					new GrabHandleW(parent)
				};
		}

		/// <summary>
		/// 用于绘制鼠标指针的图像
		/// </summary>
		/// <param name="thePoint"></param>
		/// <returns></returns>

		public Cursor GetCursor(Point thePoint)
		{
			GrabHandle gh = GrabHandleContaining(thePoint);
			if (gh != null)
				return gh.Cursor();
			return Cursors.Default;
		}

		/// <summary>
		/// 判断鼠标是否在抓取句柄上（指全部的八个句柄），调用GrabHandleContaining(thePoint)方法。
		/// </summary>
		/// <param name="thePoint"></param>
		/// <returns></returns>
		public bool Contains(Point thePoint)
		{
			return GrabHandleContaining(thePoint) != null ? true : false;
		}

		public GrabHandle GrabHandleContaining(Point thePoint)
		{
			foreach (GrabHandle gh in handles)
				if (gh.Contains(thePoint) )
					return gh;
			return null;
		}

		/// <summary>
		/// 绘制八个抓取句柄。
		/// </summary>
		/// <param name="e"></param>
		public void OnPaint(PaintEventArgs e) 
		{
			// paint the grab handles
			foreach (GrabHandle gh in handles)
				gh.OnPaint(e);
		}
	}
	
	public abstract class GrabHandle
	{
		protected BaseComponent parent;
		
		public GrabHandle(BaseComponent theParent)
		{
			parent = theParent;
		}

		public abstract Point GetPosition();

		protected Rectangle GetBounds()
		{
			Rectangle rect = new Rectangle {Location = parent.bounds.Location};
		    // get the location of this handle
			Point p = GetPosition();
			rect.Offset(p.X, p.Y);
			rect.Inflate(SystemInformation.FixedFrameBorderSize);
			rect.Inflate(0, 0);
			return rect;
		}
		/// <summary>
		/// 判断鼠标是否在抓取句柄上（指具体的一个）
		/// </summary>
		/// <param name="thePoint"></param>
		/// <returns></returns>
		public virtual bool Contains(Point thePoint) 
		{
			return GetBounds().Contains(thePoint);
		}
			
		public Cursor Cursor()
		{
			return Cursors.SizeAll;
		}

		public virtual void OnPaint(PaintEventArgs e) 
		{
			ControlPaint.DrawGrabHandle(e.Graphics, GetBounds(), true, true);
		}
		//public abstract Rectangle ResizedTo(Rectangle theRectangleToResize, Size theChange);
	}
    
    // GrabHandleNW ,GrabHandleN ,GrabHandleNE ,GrabHandleE ,GrabHandleSE ,GrabHandleS,GrabHandleSW 
    // ,GrabHandleW都是继承于GrabHandle类。他们是八个方位的句柄，重载了父类的GetPosition()方法。
    
	public class GrabHandleNW: GrabHandle
	{
		public GrabHandleNW(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(0, 0);
		}
	}
    
	public class GrabHandleN: GrabHandle
	{
		public GrabHandleN(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(parent.bounds.Size.Width/2, 0);
		}
	}
    
	public class GrabHandleNE: GrabHandle
	{
		public GrabHandleNE(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(parent.bounds.Size.Width, 0);
		}
	}
    
	public class GrabHandleE: GrabHandle
	{
		public GrabHandleE(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(parent.bounds.Size.Width, parent.bounds.Size.Height/2);
		}
	}
    
	public class GrabHandleSE: GrabHandle
	{
		public GrabHandleSE(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(parent.bounds.Size.Width, parent.bounds.Size.Height);
		}
	}
    
	public class GrabHandleS: GrabHandle
	{
		public GrabHandleS(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(parent.bounds.Size.Width/2, parent.bounds.Size.Height);
		}
	}
    
	public class GrabHandleSW: GrabHandle
	{
		public GrabHandleSW(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(0, parent.bounds.Size.Height);
		}
	}
    
	public class GrabHandleW: GrabHandle
	{
		public GrabHandleW(BaseComponent theParent): base(theParent) { }

		public override Point GetPosition()
		{
			return new Point(0, parent.bounds.Size.Height/2);
		}
	}
}
