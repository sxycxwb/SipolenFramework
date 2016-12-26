using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// ��ѡ��״̬�µ�����ڵ�߿��࣬����קʱ��ʾ�߿�
	/// </summary>
	public class Bounds
	{
		/// <summary>
		/// ѡ������ڵ�߿��б�
		/// </summary>
		public ArrayList boundsList = new ArrayList();

		public Bounds()
		{			
		}

		/// <summary>
		/// ��ѡ������ڵ��б�selectedItems�е�����ڵ�߿���ӵ�ѡ������ڵ�߿��б�
		/// </summary>
		/// <param name="selectedItems"></param>
		public void AddList(SelectedItems selectedItems)
		{
			foreach(BaseComponent c in selectedItems)
				boundsList.Add(c.bounds);
		}
		/// <summary>
		/// ����boundsList�е�����ڵ�߿�
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
