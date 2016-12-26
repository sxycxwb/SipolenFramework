using System;
using System.Collections;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// SelectedItems 的摘要说明。
	/// </summary>
	public class SelectedItems: ArrayList
	{
		public SelectedItems()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public override void Clear() 
		{
			foreach (BaseComponent c in this)
				c.Selected = false;
			base.Clear();
		}

		public void Add(BaseComponent theComponent) 
		{
			base.Add(theComponent);
			theComponent.Selected = true;
		}
	}
}
