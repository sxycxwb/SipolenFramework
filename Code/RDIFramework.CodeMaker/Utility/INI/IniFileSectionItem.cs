using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// 定义 ini 文件配置项的基本信息。
	/// </summary>
	[ComVisible(true)]
	[Serializable]
	public struct IniFileSectionItem
	{
		#region 公有字段

		/// <summary>
		/// 表示键名、键值和注释全部为空的 <see cref="IniFileSectionItem"/> 的常量值。
		/// </summary>
		public static readonly IniFileSectionItem None = new IniFileSectionItem {
			Key = String.Empty,
			Value = String.Empty,
			Comment = new List<string>()
		};

		#endregion

		#region 构造函数

		/// <summary>
		/// 使用指定键名初始化 <see cref="IniFileSectionItem"/> 类的新实例。
		/// </summary>
		/// <param name="key">指定键名。</param>
		public IniFileSectionItem(string key) : this(key, String.Empty) { }

		/// <summary>
		/// 使用指定键名和键值初始化 <see cref="IniFileSectionItem"/> 类的新实例。
		/// </summary>
		/// <param name="key">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public IniFileSectionItem(string key, string value) : this()
		{
			if (key == null) throw new ArgumentNullException("key");
			if (key.Length == 0) throw new ArgumentOutOfRangeException("key");

			if (value == null) throw new ArgumentNullException("value");

			this.Key = key;
			this.Value = value;
			this.Comment = new List<string>();
		}

		#endregion

		#region 公有方法

		/// <summary>
		/// 比较两个 <see cref="IniFileSectionItem"/> 对象。此结果指定两个 MLngLat 对象的 <see cref="IniFileSectionItem.Key"/> 属性的值是否不等。
		/// </summary>
		/// <param name="left">要比较的 <see cref="IniFileSectionItem"/>。</param>
		/// <param name="right">要比较的 <see cref="IniFileSectionItem"/>。</param>
		/// <returns>如果 <paramref name="left"/> 和 <paramref name="right"/> 的 <see cref="IniFileSectionItem.Key"/> 属性值不等，则为 true；否则为 false。</returns>
		public static bool operator !=(IniFileSectionItem left, IniFileSectionItem right) { return !(left == right); }

		/// <summary>
		/// 比较两个 <see cref="IniFileSectionItem"/> 对象。此结果指定两个 <see cref="IniFileSectionItem"/> 对象的 <see cref="IniFileSectionItem.Key"/> 属性的值是否相等。
		/// </summary>
		/// <param name="left">要比较的 <see cref="IniFileSectionItem"/>。</param>
		/// <param name="right">要比较的 <see cref="IniFileSectionItem"/>。</param>
		/// <returns>如果 <paramref name="left"/> 和 <paramref name="right"/> 的 <see cref="IniFileSectionItem.Key"/> 值相等，则为 true；否则为 false。</returns>
		public static bool operator ==(IniFileSectionItem left, IniFileSectionItem right) { return String.Compare(left.Key, right.Key, true) == 0; }

		/// <summary>
		/// 确定此 <see cref="IniFileSectionItem"/> 实例是否与指定的对象（也必须是 <see cref="IniFileSectionItem"/>）具有相同的名称。
		/// </summary>
		/// <param name="obj">一个 <see cref="System.Object"/>。</param>
		/// <returns>如果 <paramref name="obj"/> 为 <see cref="IniFileSectionItem"/> 并且它的值与此实例相同，则为 true；否则为 false。</returns>
		public override bool Equals(object obj)
		{
			if ((obj is IniFileSectionItem) == false) return false;

			var m = (IniFileSectionItem)obj;

			return this.Key == m.Key;
		}

		/// <summary>
		/// 返回该 <see cref="IniFileSectionItem"/> 的哈希代码。
		/// </summary>
		/// <returns>32 位有符号整数哈希代码。</returns>
		public override int GetHashCode() { return this.Key.GetHashCode() ^ this.Value.GetHashCode() ^ this.Comment.GetHashCode(); }

		/// <summary>
		/// 返回表示当前配置项数据的字符串。
		/// </summary>
		/// <returns>返回包含当前配置项数据的字符串。</returns>
		public override string ToString()
		{
			if (String.IsNullOrEmpty(this.Key)) return String.Empty;

			var builder = new StringBuilder();

			foreach (var comment in this.Comment) builder.AppendFormat("; {0}{1}", comment.Trim(), Environment.NewLine);

			if (String.IsNullOrEmpty(this.Value)) builder.AppendFormat("{0}{1}", this.Key, Environment.NewLine);
			else builder.AppendFormat("{0} = {1}{2}", this.Key, this.Value, Environment.NewLine);

			return builder.ToString();
		}

		#endregion

		#region 公有属性

		/// <summary>
		/// 获取或设置当前配置项的键。
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// 获取或设置当前配置项的值。
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// 获取或设置当前配置项的注释。
		/// </summary>
		public List<string> Comment { get; set; }

		#endregion
	}
}