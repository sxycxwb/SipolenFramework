using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

	/// <summary>
	/// Link 的摘要说明。
	/// </summary>
	public class Link
	{
		public string linkGuid;
		public string flowGuid;
		public BaseComponent startTask;
		public BaseComponent endTask;
        public string Condition = "";
        public string CommandName = "";
        public int Priority;

		/// <summary>
		/// 连接线起点
		/// </summary>
		public Point startPoint;	
		
		/// <summary>
		/// 连接线终点
		/// </summary>
		public Point endPoint;
			
		/// <summary>
		/// 选定标志
		/// </summary>
		public bool selected;	

		/// <summary>
		/// 锚点的x坐标，包括开始点和结束点，开始点索引号是0，结束点索引号是breakPointX.Count-1;
		/// </summary>			
		public ArrayList breakPointX;

		/// <summary>
        /// 锚点的y坐标，包括开始点和结束点，开始点索引号是0，结束点索引号是breakPointY.Count-1;
		/// </summary>
		public ArrayList breakPointY;

		/// <summary>
		/// 说明
		/// </summary>
		public string Des;
		/// <summary>
		/// 与节点属性对话框关联的dll
		/// </summary>
		public string DllFileName="";

		public string DllClassName=""; 

		public int selectedAnchor;
       
		
		public Link(BaseComponent StartTask,BaseComponent EndTask)
		{
            DllFileName = Application.StartupPath + @"\RDIFramework.WorkFlow.dll";
            DllClassName = "RDIFramework.WorkFlow.FrmLinkConfig";
			selectedAnchor=-1;
			breakPointX=new ArrayList();
			breakPointY=new ArrayList();
			Des="";
			linkGuid = BusinessLogic.NewGuid();
			startTask = StartTask;
			endTask = EndTask;			
			Point[] po=SelectingPoint(StartTask,EndTask);
			if(po!=null)
			{
				this.startPoint=po[0];
				this.endPoint=po[1];
				if(this.startTask==this.endTask)//自连线
				{	
					breakPointX.Add(startPoint.X);
					breakPointX.Add(startPoint.X-35);
					breakPointX.Add(startPoint.X-35);
					breakPointX.Add(startPoint.X+16);
					breakPointX.Add(startPoint.X+16);

					breakPointY.Add(startPoint.Y);
					breakPointY.Add(startPoint.Y);
					breakPointY.Add(startPoint.Y-35);
					breakPointY.Add(startPoint.Y-35);				
					breakPointY.Add(startPoint.Y-16);	
				}
				else 
				{			
					//为了编程的方便,把开始和结束点也看成是锚点
					this.breakPointX.Add(startPoint.X);
					this.breakPointY.Add(startPoint.Y);
					this.breakPointX.Add(endPoint.X);
					this.breakPointY.Add(endPoint.Y);	
				}
			}
		}

		/// <summary>
		/// 给定点是否在连线上
		/// </summary>
		/// <param name="thePoint"></param>
		/// <returns>给定点在连线上的话返回true,否则false</returns>
		public bool Contains(Point thePoint)
		{
			bool result=false;
			for(int i=0;i<this.breakPointX.Count-1;i++)
			{
				Point bp=new Point(Convert.ToInt16(this.breakPointX[i]),Convert.ToInt16(this.breakPointY[i]));
				Point bp2=new Point(Convert.ToInt16(this.breakPointX[i+1]),Convert.ToInt16(this.breakPointY[i+1]));
				if(isContains(thePoint,bp,bp2))
				{
					result=true; 
					break;
				}
			}			
			return result;
		}

		/// <summary>
		/// 给定点thePoint是否在start和end两点的直线上
		/// </summary>
		/// <param name="thePoint"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		///<returns>给定点thePoint在start和end两点的直线上返回true,否则false</returns>
		public bool isContains(Point thePoint,Point start,Point end)
		{
			int dx;
			int dy;			
			GraphicsPath graphicsPath=new GraphicsPath();
			Point[] point=new Point[]{start,start,end,end,start};
			int width=1;
			if ( end.Y == start.Y )
			{
				dx = 0;
				dy = width;
			}
			else
			{
				dx = width;
				float k = ( start.X - end.X ) / ( end.Y - start.Y );
				dy = (int)(dx * k);
			}
			point[0].Offset(-dx,-dy);
			point[1].Offset(dx,dy);
			point[2].Offset(dx,dy);
			point[3].Offset(-dx,-dy);
			point[4]=point[0];			
			graphicsPath.AddLines(point);
			Region region=new Region(graphicsPath);
			return region.IsVisible(thePoint.X,thePoint.Y);
		}		

		public bool InDragHandle(Point thePoint)
		{
			return false;
		}		

		public Cursor GetCursor(Point thePoint)
		{
			return null;
		}	
		
		public void OnPaint(PaintEventArgs e)
		{
            //为了保证拖拽时,直线的画图位置仍然正确.在这里把开始点和终止点重新赋值
			Point[] po=SelectingPoint(startTask,endTask);
			if(po!=null)
			{
				this.startPoint=po[0];
				this.endPoint=po[1];
				if(this.startTask==this.endTask)//自连线
				{	
					breakPointX[0]=startPoint.X;
					breakPointX[1]=startPoint.X-35;
					breakPointX[2]=startPoint.X-35;
					breakPointX[3]=startPoint.X+16;
					breakPointX[4]=startPoint.X+16;

					breakPointY[0]=startPoint.Y;
					breakPointY[1]=startPoint.Y;
					breakPointY[2]=startPoint.Y-35;
					breakPointY[3]=startPoint.Y-35;				
					breakPointY[4]=startPoint.Y-16;	
				}
				else
				{						
					breakPointX[0]=startPoint.X;
					breakPointY[0]=startPoint.Y;
					breakPointY[this.breakPointY.Count-1]=endPoint.Y;		
					breakPointX[this.breakPointX.Count-1]=endPoint.X;			
				}
			}
			Pen pen;			
			if(!selected)
			{//没有选中的话用green表示			
				pen=new Pen(Color.Green,1);							
			}
			else
			{
				pen=new Pen(Color.Red,1);					
				for(int i=1;i<this.breakPointX.Count-1;i++)//开始和终止点不会锚点
				{
					Point bp=new Point (Convert.ToInt16(this.breakPointX[i]),Convert.ToInt16(this.breakPointY[i]));
					Rectangle rec=new Rectangle(bp.X-3,bp.Y-3,6,6);
					e.Graphics.DrawEllipse(pen,rec);
					SolidBrush brush;
					if(i!=this.selectedAnchor)
					{
						brush=new SolidBrush(Color.Green);
					}
					else
					{
						brush=new SolidBrush(Color.Red);
					}
					e.Graphics.FillEllipse(brush,rec);			
				}
				//this.selectedAnchor=-1;
			}
			
			for(int i=0;i<this.breakPointX.Count-2;i++)
			{
				Point bp=new Point (Convert.ToInt16(this.breakPointX[i]),Convert.ToInt16(this.breakPointY[i]));
				Point bp2=new Point (Convert.ToInt16(this.breakPointX[i+1]),Convert.ToInt16(this.breakPointY[i+1]));
				e.Graphics.DrawLine(pen,bp,bp2);							
			}
				//画最后一条带箭头的 
		    if (this.breakPointX.Count >= 2)
		    {
		        int ittX = Convert.ToInt16(this.breakPointX[this.breakPointX.Count - 2]);
		        int ittY = Convert.ToInt16(this.breakPointY[this.breakPointX.Count - 2]);
		        int itt2X = Convert.ToInt16(this.breakPointX[this.breakPointX.Count - 1]);
		        int itt2Y = Convert.ToInt16(this.breakPointY[this.breakPointX.Count - 1]);
		        Point tt = new Point(ittX, ittY);
		        Point tt2 = new Point(itt2X, itt2Y);
		        AdjustableArrowCap Arrow = new AdjustableArrowCap(3, 3);
		        pen.CustomEndCap = Arrow;
		        e.Graphics.DrawLine(pen, tt, tt2);


		        //画注释	
		        if (Des == "")
		            return;
		        Font font = new Font("Arial", 8);
		        StringFormat alignVertically = new StringFormat {LineAlignment = StringAlignment.Center};
		        SizeF sizeF = e.Graphics.MeasureString(Des, font);
		        int x = (Convert.ToInt16(this.breakPointX[0]) + Convert.ToInt16(breakPointX[1]) - (int) sizeF.Width)/2;
		        int y = (Convert.ToInt16(breakPointY[0]) + Convert.ToInt16(breakPointY[1]))/2;
		        e.Graphics.DrawString(Des, font, Brushes.Blue, x, y, alignVertically);
		    }
		}		

		public Point[] SelectingPoint(BaseComponent StartTask,BaseComponent EndTask)
		{
			if(StartTask==null||EndTask==null)
				return null;
			Point[] p;
			Point first;
			Point last;			
			if(StartTask.bounds.X<EndTask.bounds.X)
			{
				if(StartTask.bounds.Y>EndTask.bounds.Y+EndTask.bounds.Width*2)
				{
					first=new Point(StartTask.bounds.X+StartTask.bounds.Width/2,StartTask.bounds.Y);
					last=new Point(EndTask.bounds.X,EndTask.bounds.Y+EndTask.bounds.Width/2);
					return p=new Point[]{first,last};
				}
				else
				{
					if(StartTask.bounds.Y<EndTask.bounds.Y-EndTask.bounds.Width*2)
					{
						first=new Point(StartTask.bounds.X+StartTask.bounds.Width/2,StartTask.bounds.Y+StartTask.bounds.Width);
						last=new Point(EndTask.bounds.X+EndTask.bounds.Width/2,EndTask.bounds.Y);
						return p=new Point[]{first,last};
					}
					else
					{
						first=new Point(StartTask.bounds.X+StartTask.bounds.Width,StartTask.bounds.Y+StartTask.bounds.Width/2);
						last=new Point(EndTask.bounds.X,EndTask.bounds.Y+EndTask.bounds.Width/2);
						return p=new Point[]{first,last};
					}
				}

			}
			else
			{
				if(StartTask.bounds.Y>EndTask.bounds.Y+EndTask.bounds.Width*2)
				{
					first=new Point(StartTask.bounds.X+StartTask.bounds.Width/2,StartTask.bounds.Y);
					last=new Point(EndTask.bounds.X+EndTask.bounds.Width,EndTask.bounds.Y+EndTask.bounds.Width/2);
					return p=new Point[]{first,last};
				}
				else
				{
					if(StartTask.bounds.Y<EndTask.bounds.Y-EndTask.bounds.Width*2)
					{
						first=new Point(StartTask.bounds.X+StartTask.bounds.Width/2,StartTask.bounds.Y+StartTask.bounds.Width);
						last=new Point(EndTask.bounds.X+EndTask.bounds.Width/2,EndTask.bounds.Y);
						return p=new Point[]{first,last};
					}
					else
					{
						first=new Point(StartTask.bounds.X,StartTask.bounds.Y+StartTask.bounds.Width/2);
						last=new Point(EndTask.bounds.X+EndTask.bounds.Width,EndTask.bounds.Y+EndTask.bounds.Width/2);
						return p=new Point[]{first,last};
					}
				}
			}
			//return null;
		}	

		/// <summary>
		/// 获得新锚点的索引，结果是从1到this.breakPointX.Count-1;
		/// </summary>
		/// <param name="thePoint"></param>
		/// <returns></returns>
		public int BreakIndex(Point thePoint)
		{
			int result=-1;			
			for(int i=0;i<this.breakPointX.Count-1;i++)
			{
				Point bp=new Point(Convert.ToInt16(this.breakPointX[i]),Convert.ToInt16(this.breakPointY[i]));
				Point bp2=new Point(Convert.ToInt16(this.breakPointX[i+1]),Convert.ToInt16(this.breakPointY[i+1]));
				if(isContains(thePoint,bp,bp2))
				{
					result=i+1;
					break;
				}
			}			
			return result;//			
		}
   
		/// <summary>
		/// 判断连线是否存在
		/// </summary>
		/// <returns></returns>
        public bool LinkExist()
        {
            if (linkGuid.Trim().Length == 0 || linkGuid == null)
                throw new Exception("LinkExist方法错误，linkGuid 不能为空！");

		    return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistsWorkLink(SystemInfo.UserInfo, linkGuid);
        }

		public void SaveInsertLink()
		{
			if (linkGuid.Trim().Length==0||linkGuid==null)
				throw new Exception("SaveInsertLink方法错误，linkGuid 不能为空！");
			if (flowGuid.Trim().Length==0||flowGuid==null)
				throw new Exception("SaveInsertLink方法错误，flowGuid 不能为空！");
			if (startTask==null)
				throw new Exception("SaveInsertLink方法错误，startTask 不能为空！");
			if (endTask==null)
				throw new Exception("SaveInsertLink方法错误，endTask 不能为空！");
			
			try
			{
                WorkLinkEntity entity = new WorkLinkEntity
                {
                    WorkLinkId = linkGuid,
                    WorkFlowId = flowGuid,
                    StartTaskId = startTask.TaskId,
                    EndTaskId = endTask.TaskId,
                    BreakX = breakPointX.Count <= 2 ? null : BusinessLogic.ArrayToList(breakPointX),
                    BreakY = breakPointY.Count <= 2 ? null : BusinessLogic.ArrayToList(breakPointY),
                    Description = Des,
                    Condition = Condition,
                    CommandName = CommandName,
                    Priority = Priority
                };
			    RDIFrameworkService.Instance.WorkFlowTemplateService.InsertWorkLink(SystemInfo.UserInfo, entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void SaveUpdateLink()
		{
			if (linkGuid.Trim().Length==0||linkGuid==null)
				throw new Exception("SaveUpdateLink方法错误，linkGuid 不能为空！");
			if (flowGuid.Trim().Length==0||flowGuid==null)
				throw new Exception("SaveUpdateLink方法错误，flowGuid 不能为空！");
			if (startTask==null)
				throw new Exception("SaveUpdateLink方法错误，startTask 不能为空！");
			if (endTask==null)
				throw new Exception("SaveUpdateLink方法错误，endTask 不能为空！");
			try
			{
                WorkLinkEntity entity = new WorkLinkEntity
                {
                    WorkLinkId = linkGuid,
                    WorkFlowId = flowGuid,
                    StartTaskId = startTask.TaskId,
                    EndTaskId = endTask.TaskId,
                    BreakX = breakPointX.Count<= 2 ? null: BusinessLogic.ArrayToList(breakPointX),
                    BreakY = breakPointY.Count <= 2 ? null : BusinessLogic.ArrayToList(breakPointY),
                    Description = Des,
                    Condition = Condition,
                    CommandName = CommandName,
                    Priority = Priority
                };
			    RDIFrameworkService.Instance.WorkFlowTemplateService.UpdateWorkLink(SystemInfo.UserInfo, entity);
			}
            catch (Exception ex)
            {
                throw ex;
            }
		}
	}
}
