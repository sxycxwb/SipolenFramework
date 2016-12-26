using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// ��ק�����ࡣ�������ڵ����ק���ܣ����⣬���ڵ�λ�øı�ʱ���������ӵ����ߵ�λ�û���֮�ı䣬
	/// ���������ಢ����¼�Լ���λ�ö��Ǹ�����ֹ�ڵ��λ�ü���ó��Լ���λ�á�
	/// ��������룬�Ҷ��룬�϶��룻
	/// </summary>
	public class Dragger
	{
		/// <summary>
		/// ���ؼ�
		/// </summary>
		Control parent;

		/// <summary>
		/// ѡ���ڵ��б�
		/// </summary>
		public SelectedItems items;

		/// <summary>
		/// �ڵ���ק��ʼλ��
		///  </summary>
		public Point location;

		/// <summary>
		/// ��ק�����б߿�λ��
		/// </summary>		
		Point myLocation;

		/// <summary>
		/// ˢ�������б�
		/// </summary>
		ArrayList refreshList=new ArrayList();

		/// <summary>
		/// �ڵ�߿��б�
		/// </summary>
		Bounds bounds;

		/// <summary>
		/// Ϊ�˳���ʱ�õ�.����MoveTo�а�location=thepoint��,������desPoint����¼location��ֵ.
		/// </summary>
		public Point desPoint;

		/// <summary>
		/// ���캯��
		/// </summary>
		/// <param name="theParent">���ؼ�</param>
		/// <param name="theItemsToDrag">ѡ�е�����ڵ�</param>
		/// <param name="theStartingPoint">��ק�Ĳ��յ�</param>
		/// <param name="myBounds">�߿�</param>
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
		/// ���뷽ʽʱ�õĹ��캯��
		/// </summary>
		/// <param name="theParent">���ؼ�</param>
		/// <param name="theItemsToDrag">ѡ�е�����ڵ�</param>
		public Dragger(Control theParent, SelectedItems theItemsToDrag)
		{		
			parent = theParent;
			items = theItemsToDrag;						
			parent.Capture = true;			
		}

		/// <summary>
		/// �������ڵ�Ķ��빦��
		/// </summary>
		/// <param name="type">1�����϶��룻2������룻3���Ҷ���</param>
		public void Align(int type)//����룽������
		{	
			switch(type)
			{
				case 1://�϶���
					for(int i=0;i<this.items.Count;i++)
					{
						BaseComponent bc=(BaseComponent)items[i];
						int yDelta=((BaseComponent)items[0]).Y-bc.Y;
						bc.bounds.Offset(0, yDelta);				
						bc.Y += yDelta;				
					}
					break;
				case 2://�����
					for(int i=1;i<this.items.Count;i++)
					{
						BaseComponent bc=(BaseComponent)items[i];
						int xDelta=((BaseComponent)items[0]).X-bc.X;
						bc.bounds.Offset(xDelta,0);				
						bc.X += xDelta;				
					}
					break;
				case 3://�Ҷ���
					int num=items.Count-1;
					for(int i=0;i<this.items.Count-1;i++)
					{
						BaseComponent bc=(BaseComponent)items[i];
						int xDelta=((BaseComponent)items[num]).X-bc.X;
						bc.bounds.Offset(xDelta,0);				
						bc.X+= xDelta;				
					}
					break;
                case 4://�¶���
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
		/// ��ѡ������ڵ��е�ȫ������ڵ��ƶ���thePointָ����λ���ϡ�
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
			desPoint=location;//Ϊ�˳����õ�
			location = thePoint;
		}

		/// <summary>
		/// ��thePointָ����λ������ʾ��ק�����еĽڵ�߿�
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
				//����ˢ������
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
