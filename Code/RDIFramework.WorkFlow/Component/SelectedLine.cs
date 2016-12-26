using System.Collections;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// SelectedLine ��ժҪ˵����
	/// </summary>
	public class SelectedLine:ArrayList
	{
		public SelectedLine()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
