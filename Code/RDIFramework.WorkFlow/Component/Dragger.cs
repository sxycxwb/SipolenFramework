using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// 拖拽处理类。完成任务节点的拖拽功能，另外，当节点位置改变时，与它连接的连线的位置会随之改变，
	/// 但是连线类并不记录自己的位置而是根据起止节点的位置计算得出自己的位置。
	/// 还有左对齐，右对齐，上对齐；
	/// </summary>
	public class Dragger
	{
		/// <summary>
		/// 父控件
		/// </summary>
		Control parent;

		/// <summary>
		/// 选定节点列表
		/// </summary>
		public SelectedItems items;

		/// <summary>
		/// 节点拖拽起始位置
		///  </summary>
		public Point location;

		/// <summary>
		/// 拖拽过程中边框位置
		/// </summary>		
		Point myLocation;

		/// <summary>
		/// 刷新区域列表
		/// </summary>
		ArrayList refreshList=new ArrayList();

		/// <summary>
		/// 节点边框列表
		/// </summary>
		Bounds bounds;

		/// <summary>
		/// 为了撤销时用的.由在MoveTo中把location=thepoint了,所以用desPoint来记录location得值.
		/// </summary>
		public Point desPoint;

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="theParent">父控件</param>
		/// <param name="theItemsToDrag">选中的任务节点</param>
		/// <param name="theStartingPoint">拖拽的参照点</param>
		/// <param name="myBounds">边框</param>
		public Dragger(Control theParent, SelectedItems theItemsToDrag, Point theStartingPoint,Bounds myBounds)
		{		
			parent = theParent;
			items = theItemsToDrag;
			location = theStartingPoint;			
			myLocation=theStartingPoint;
			bounds=myBounds;			
			parent.Capture = true;
//			Cursor.Clip = parent.RectangleToScreen(parent.ClientRectangle);		
		}

		/// <summary>
		/// 对齐方式时用的构造函数
		/// </summary>
		/// <param name="theParent">父控件</param>
		/// <param name="theItemsToDrag">选中的任务节点</param>
		public Dragger(Control theParent, SelectedItems theItemsToDrag)
		{		
			parent = theParent;
			items = theItemsToDrag;						
			parent.Capture = true;			
		}

		/// <summary>
		/// 完成任务节点的对齐功能
		/// </summary>
		/// <param name="type">1－－上对齐；2－左对齐；3－右对齐</param>
		public void Align(int type)//左对齐＝＝例子
		{	
			switch(type)
			{
				case 1://上对齐
					for(int i=0;i<this.items.Count;i++)
					{
						BaseComponent bc=(BaseComponent)items[i];
						int yDelta=((BaseComponent)items[0]).Y-bc.Y;
						bc.bounds.Offset(0, yDelta);				
						bc.Y += yDelta;				
					}
					break;
				case 2://左对齐
					for(int i=1;i<this.items.Count;i++)
					{
						BaseComponent bc=(BaseComponent)items[i];
						int xDelta=((BaseComponent)items[0]).X-bc.X;
						bc.bounds.Offset(xDelta,0);				
						bc.X += xDelta;				
					}
					break;
				case 3://右对齐
					int num=items.Count-1;
					for(int i=0;i<this.items.Count-1;i++)
					{
						BaseComponent bc=(BaseComponent)items[i];
						int xDelta=((BaseComponent)items[num]).X-bc.X;
						bc.bounds.Offset(xDelta,0);				
						bc.X+= xDelta;				
					}
					break;
                case 4://下对齐
                    int num1 = items.Count - 1;
                    for (int i = 0; i < this.items.Count; i++)
                    {
                        BaseComponent bc = (BaseComponent)items[i];
                        int yDelta = ((BaseComponent)items[num1]).Y - bc.Y;
                        bc.bounds.Offset(0, yDelta);
                        bc.Y += yDelta;
                    }
                    break;
			}
			parent.Invalidate();			
		}

		/// <summary>
		/// 将选定任务节点中的全部任务节点移动到thePoint指定的位置上。
		/// </summary>
		/// <param name="thePoint"></param>
		public void DragTo(Point thePoint)
		{
			int xDelta = thePoint.X - location.X;
			int yDelta = thePoint.Y - location.Y;
			foreach (BaseComponent c in items)
			{
				c.bounds.Offset(xDelta, yDelta);
				c.X += xDelta;
				c.Y += yDelta;
			}
			parent.Invalidate();
			desPoint=location;//为了撤销用的
			location = thePoint;
		}

		/// <summary>
		/// 在thePoint指定的位置上显示拖拽过程中的节点边框
		/// </summary>
		/// <param name="thePoint"></param>
		public void DragT(Point thePoint)
		{
			refreshList.Clear();
			int xDelta = thePoint.X - myLocation.X;
			int yDelta = thePoint.Y - myLocation.Y;
			for(int i=bounds.boundsList.Count-1;i>=0;i--)
			{
				Rectangle rtPre = ((Rectangle)bounds.boundsList[i]);
				Rectangle rt = rtPre;
				rt.Offset(xDelta, yDelta);
				bounds.boundsList[i] = rt;
				//计算刷新区域
				int x, y, w, h;
				x = Math.Min(rtPre.X, rt.X);
				y = Math.Min(rtPre.Y, rt.Y);
				w = rt.Width + Math.Abs(xDelta) + 5;
				h = rt.Height + Math.Abs(yDelta) + 5;
				rt = new Rectangle(x + ((WorkPlace)parent).AutoScrollPosition.X, y + ((WorkPlace)parent).AutoScrollPosition.Y, w, h);
				refreshList.Add(rt);
			}			
			myLocation=thePoint;
			for(int j=refreshList.Count-1;j>=0;j--)
			{
				Rectangle rect = ((Rectangle)refreshList[j]);
				parent.Invalidate(rect);				
			}
		}

		public void End()
		{
//			Cursor.Clip = Rectangle.Empty;
			parent.Capture = false;
		}
	}
}
