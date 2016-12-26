using System;
using System.Collections;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// SelectedItems ��ժҪ˵����
	/// </summary>
	public class SelectedItems: ArrayList
	{
		public SelectedItems()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
