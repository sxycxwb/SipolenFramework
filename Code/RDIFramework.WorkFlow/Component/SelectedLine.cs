using System.Collections;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// SelectedLine 的摘要说明。
	/// </summary>
	public class SelectedLine:ArrayList
	{
		public SelectedLine()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public override void Clear() 
		{
			foreach (Link c in this)
				c.selected = false;
			base.Clear();
		}
		public void Add(Link theLine) 
		{
			base.Add(theLine);
			theLine.selected = true;
		}
	}
}
