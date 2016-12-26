using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// 表示可通过索引或键名访问 <see cref="IniFileSection"/> 的强类型列表。提供用于对列表进行搜索、排序和操作的方法。
	/// </summary>
	[ComVisible(true)]
	[Serializable]
	public sealed class IniFileSectionCollection : List<IniFileSection>
	{
		/// <summary>
		/// 获取或设置具有指定名称的 <see cref="IniFileSection"/>。
		/// </summary>
		/// <param name="name">指定 <see cref="IniFileSection"/> 的名称。</param>
		/// <returns>返回具有指定名称的 <see cref="IniFileSection"/>。</returns>
		public IniFileSection this[string name]
		{
			get
			{
				int index;

				for (index = 0; index < this.Count; index++) if (String.Compare(this[index].Name, name, true) == 0) return this[index];

				return IniFileSection.None;
			}
			set
			{
				int index;

				for (index = 0; index < this.Count; index++) if (String.Compare(this[index].Name, name, true) == 0) this[index] = value;
			}
		}

		/// <summary>
		/// 将对象添加到列表。
		/// </summary>
		/// <param name="item">要添加到列表的对象。</param>
		public new void Add(IniFileSection item)
		{
			if (this.Contains(item)) this.Remove(item);
			base.Add(item);
		}

		/// <summary>
		/// 确定指定名称的配置节对象是否在列表中。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <returns>如果在列表中找到指定名称的配置节对象则返回 true，否则返回 false。</returns>
		public bool Contains(string sectionName) { return this[sectionName] != IniFileSection.None; }

		/// <summary>
		/// 移除指定名称的配置节对象。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		public void Remove(string sectionName) { this.RemoveAll(item => item.Name == sectionName); }

		/// <summary>
		/// 返回表示当前配置节数据的字符串。
		/// </summary>
		/// <returns>返回包含当前配置节数据的字符串。</returns>
		public override string ToString()
		{
			if (this.Count == 0) return String.Empty;

			var builder = new StringBuilder();

			foreach (var section in this) builder.Append(section.ToString());

			return builder.ToString();
		}
	}
}