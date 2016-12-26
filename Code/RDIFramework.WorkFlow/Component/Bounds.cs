using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// 被选定状态下的任务节点边框类，在拖拽时显示边框。
	/// </summary>
	public class Bounds
	{
		/// <summary>
		/// 选定任务节点边框列表
		/// </summary>
		public ArrayList boundsList = new ArrayList();

		public Bounds()
		{			
		}

		/// <summary>
		/// 将选定任务节点列表selectedItems中的任务节点边框添加到选定任务节点边框列表
		/// </summary>
		/// <param name="selectedItems"></param>
		public void AddList(SelectedItems selectedItems)
		{
			foreach(BaseComponent c in selectedItems)
				boundsList.Add(c.bounds);
		}
		/// <summary>
		/// 绘制boundsList中的任务节点边框
		/// </summary>
		/// <param name="e"></param>
		public void OnPaint(PaintEventArgs e)
		{			
			for(int i=boundsList.Count-1;i>=0;i--)
			{
				Rectangle outerRect=(Rectangle)boundsList[i];
				Pen pen=new Pen(Color.DarkGray,1) {DashStyle = DashStyle.Dash};
			    e.Graphics.DrawRectangle(pen,outerRect);
			}
		}
	}
}
