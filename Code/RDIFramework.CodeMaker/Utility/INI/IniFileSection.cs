using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// 表示 ini 文件的一个配置节。
	/// </summary>
	[ComVisible(true)]
	[Serializable]
	public struct IniFileSection
	{
		#region 公有字段

		/// <summary>
		/// 表示键名、键值和注释全部为空的 <see cref="IniFileSectionItem"/> 的常量值。
		/// </summary>
		public static readonly IniFileSection None = new IniFileSection {
			Name = String.Empty
		};

		#endregion

		#region 构造函数

		/// <summary>
		/// 初始化 <see cref="IniFileSection"/> 类的新实例。
		/// </summary>
		/// <param name="name">指定配置节的名称。</param>
		public IniFileSection(string name) : this()
		{
			if (name == null) throw new ArgumentNullException("name");
			if (name.Length == 0) throw new ArgumentOutOfRangeException("name");

			this.Name = name;
			this.Items = new IniFileSectionItemCollection();
			this.Comment = new List<string>();
		}

		#endregion

		#region 公有方法

		/// <summary>
		/// 返回指定键的值。
		/// </summary>
		/// <param name="keyName">指定键名。</param>
		/// <returns>如果找到指定名称的键值对，则返回其键值，否则返回 <see cref="String.Empty"/>。</returns>
		public string GetValue(string keyName)
		{
			if (keyName == null) throw new ArgumentNullException("keyName");
			if (keyName.Length == 0) throw new ArgumentOutOfRangeException("keyName");

			var value = this.Items.Where(item => item.Key == keyName).Select(item => item.Value).FirstOrDefault();

			return String.IsNullOrEmpty(value) ? String.Empty : value;
		}

		/// <summary>
		/// 比较两个 <see cref="IniFileSection"/> 对象。此结果指定两个 MLngLat 对象的 <see cref="IniFileSection.Name"/> 属性的值是否不等。
		/// </summary>
		/// <param name="left">要比较的 <see cref="IniFileSection"/>。</param>
		/// <param name="right">要比较的 <see cref="IniFileSection"/>。</param>
		/// <returns>如果 <paramref name="left"/> 和 <paramref name="right"/> 的 <see cref="IniFileSection.Name"/> 属性值不等，则为 true；否则为 false。</returns>
		public static bool operator !=(IniFileSection left, IniFileSection right) { return !(left == right); }

		/// <summary>
		/// 比较两个 <see cref="IniFileSection"/> 对象。此结果指定两个 <see cref="IniFileSection"/> 对象的 <see cref="IniFileSection.Name"/> 属性的值是否相等。
		/// </summary>
		/// <param name="left">要比较的 <see cref="IniFileSection"/>。</param>
		/// <param name="right">要比较的 <see cref="IniFileSection"/>。</param>
		/// <returns>如果 <paramref name="left"/> 和 <paramref name="right"/> 的 <see cref="IniFileSection.Name"/> 值相等，则为 true；否则为 false。</returns>
		public static bool operator ==(IniFileSection left, IniFileSection right) { return String.Compare(left.Name, right.Name, true) == 0; }

		/// <summary>
		/// 确定此 <see cref="IniFileSection"/> 实例是否与指定的对象（也必须是 <see cref="IniFileSection"/>）具有相同的名称。
		/// </summary>
		/// <param name="obj">一个 <see cref="System.Object"/>。</param>
		/// <returns>如果 <paramref name="obj"/> 为 <see cref="IniFileSection"/> 并且它的值与此实例相同，则为 true；否则为 false。</returns>
		public override bool Equals(object obj)
		{
			if ((obj is IniFileSection) == false) return false;

			var m = (IniFileSection)obj;

			return this.Name == m.Name;
		}

		/// <summary>
		/// 返回该 <see cref="IniFileSection"/> 的哈希代码。
		/// </summary>
		/// <returns>32 位有符号整数哈希代码。</returns>
		public override int GetHashCode() { return this.Name.GetHashCode() ^ this.Items.GetHashCode() ^ this.Comment.GetHashCode(); }

		/// <summary>
		/// 返回表示当前配置节数据的字符串。
		/// </summary>
		/// <returns>返回包含当前配置节数据的字符串。</returns>
		public override string ToString()
		{
			if (String.IsNullOrEmpty(this.Name)) return String.Empty;

			var builder = new StringBuilder();

			foreach (var comment in this.Comment) builder.AppendFormat("; {0}{1}", comment.Trim(), Environment.NewLine);

			builder.AppendFormat("[{0}]{1}", this.Name, Environment.NewLine);

			foreach (var item in this.Items) builder.Append(item.ToString());

			return builder.ToString();
		}

		#endregion

		#region 公有属性

		/// <summary>
		/// 获取或设置具有指定键的 <see cref="IniFileSectionItem"/> 的实例。
		/// </summary>
		/// <param name="keyName">指定键名。</param>
		/// <returns>返回具有指定键名的 <see cref="IniFileSectionItem"/>。</returns>
		public IniFileSectionItem this[string keyName]
		{
			get
			{
				if (keyName == null) throw new ArgumentNullException("keyName");
				if (keyName.Length == 0) throw new ArgumentOutOfRangeException("keyName");

				return this.Items[keyName];
			}
			set { this.Items[keyName] = value; }
		}

		/// <summary>
		/// 获取配置节名称。
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 获取或设置当前配置节的注释。
		/// </summary>
		public List<string> Comment { get; set; }

		/// <summary>
		/// 获取配置节包含的键值对的集合。
		/// </summary>
		public IniFileSectionItemCollection Items { get; private set; }

		#endregion

        public void Add(string item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(string item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }

       
    }
}