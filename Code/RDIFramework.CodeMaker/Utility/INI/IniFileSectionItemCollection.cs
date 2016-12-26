using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// 表示可通过索引或键名访问 <see cref="IniFileSectionItem"/> 的强类型列表。提供用于对列表进行搜索、排序和操作的方法。
	/// </summary>
	[ComVisible(true)]
	[Serializable]
	public sealed class IniFileSectionItemCollection : List<IniFileSectionItem>
	{
		/// <summary>
		/// 获取或设置具有指定键名的 <see cref="IniFileSectionItem"/>。
		/// </summary>
		/// <param name="key">指定 <see cref="IniFileSectionItem"/> 的名称。</param>
		/// <returns>返回具有指定键名的 <see cref="IniFileSectionItem"/>。</returns>
		public IniFileSectionItem this[string key]
		{
			get
			{
				int index;

				for (index = 0; index < this.Count; index++) if (String.Compare(this[index].Key, key, true) == 0) return this[index];

				return IniFileSectionItem.None;
			}
			set
			{
				int index;

				for (index = 0; index < this.Count; index++) if (String.Compare(this[index].Key, key, true) == 0) this[index] = value;
			}
		}

		/// <summary>
		/// 将对象添加到列表。
		/// </summary>
		/// <param name="item">要添加到列表的对象。</param>
		public new void Add(IniFileSectionItem item)
		{
			if (this.Contains(item)) this.Remove(item);

			base.Add(item);
		}

		/// <summary>
		/// 确定指定键名的配置项对象是否在列表中。
		/// </summary>
		/// <param name="keyName">指定配置项名称。</param>
		/// <returns>如果在列表中找到指定键名的配置项对象则返回 true，否则返回 false。</returns>
		public bool Contains(string keyName) { return this[keyName] != IniFileSectionItem.None; }

		/// <summary>
		/// 移除指定键名的配置项对象。
		/// </summary>
		/// <param name="keyName">指定配置项名称。</param>
		public void Remove(string keyName) { this.RemoveAll(item => item.Key == keyName); }

		/// <summary>
		/// 返回表示当前配置节数据的字符串。
		/// </summary>
		/// <returns>返回包含当前配置节数据的字符串。</returns>
		public override string ToString()
		{
			if (this.Count == 0) return String.Empty;

			var builder = new StringBuilder();

			foreach (var item in this) builder.Append(item.ToString());

			return builder.ToString();
		}
	}
}