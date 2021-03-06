using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// 包含一组方法和属性，提供对 ini 文件的基本操作。
	/// </summary>
	[ComVisible(true)]
	[Serializable]
	public sealed class IniFile
	{
		#region 私有字段

		private readonly SimpleTimerProvider<IniFile> _saveTimerProvider;

		#endregion

		#region 公有字段

		/// <summary>
		/// 数据保存完成时发生。
		/// </summary>
		public event EventHandler Saved;

		#endregion

		#region 构造函数

		/// <summary>
		/// 使用默认字符编码从指定文件初始化 <see cref="IniFile"/> 类的新实例。
		/// </summary>
		/// <param name="fileName">指定 ini 文件的完整路径。</param>
		public IniFile(string fileName) : this(fileName, Encoding.Default) { }

		/// <summary>
		/// 从指定文件初始化 <see cref="IniFile"/> 类的新实例。
		/// </summary>
		/// <param name="fileName">指定 ini 文件的完整路径。</param>
		/// <param name="encoding">指定 ini 文件的字符编码。</param>
		public IniFile(string fileName, Encoding encoding) : this(fileName, encoding, 0) { }

		/// <summary>
		/// 使用默认字符编码从指定文件从指定文件初始化 <see cref="IniFile"/> 类的新实例。
		/// </summary>
		/// <param name="fileName">指定 ini 文件的完整路径。</param>
		/// <param name="interval">指定自动保存的时间间隔。</param>
		public IniFile(string fileName, double interval) : this(fileName, Encoding.Default, interval) { }

		/// <summary>
		/// 从指定文件初始化 <see cref="IniFile"/> 类的新实例。
		/// </summary>
		/// <param name="fileName">指定 ini 文件的完整路径。</param>
		/// <param name="encoding">指定 ini 文件的字符编码。</param>
		/// <param name="interval">指定自动保存的时间间隔。</param>
		public IniFile(string fileName, Encoding encoding, double interval)
		{
			if (fileName == null) throw new ArgumentNullException("fileName");
			if (fileName.Length == 0) throw new ArgumentOutOfRangeException("fileName");
			if (File.Exists(fileName) == false) File.WriteAllText(fileName, String.Empty, encoding);

			this.FileName = Path.GetFullPath(fileName);
			this.Encoding = encoding;
			this.Comment = new List<string>();
			this.Sections = new IniFileSectionCollection();

			this.Refresh();

			if (interval <= 0) return;

			this._saveTimerProvider = new SimpleTimerProvider<IniFile>(this, interval);
			this._saveTimerProvider.Run(ini => ini.Save());
		}

		#endregion

		#region 私有方法

		/// <summary>
		/// 将该字符串文本转换为 <see cref="System.Boolean"/> 类型。
		/// </summary>
		/// <param name="str">表示文本，即一系列 Unicode 字符。</param>
		/// <returns><see cref="System.Boolean"/></returns>
		private static bool _ToBoolean(string str)
		{
			if (String.IsNullOrEmpty(str)) return false;
			if (String.Compare(str, "true", true) == 0) return true;
			if (String.Compare(str, "yes", true) == 0) return true;

			return str == "1";
		}

		#endregion

		#region 公有方法

		#region 读取

		/// <summary>
		/// 从指定配置节读取 <see cref="System.String"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.String"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public string Read(string sectionName, string keyName, string defaultValue)
		{
			if (sectionName == null) throw new ArgumentNullException("sectionName");
			if (sectionName.Length == 0) throw new ArgumentOutOfRangeException("sectionName");

			if (keyName == null) throw new ArgumentNullException("keyName");
			if (keyName.Length == 0) throw new ArgumentOutOfRangeException("keyName");

			if (this.Sections.Contains(sectionName) == false) return defaultValue;

			return this[sectionName].Items.Contains(keyName) == false ? defaultValue : this[sectionName][keyName].Value;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Int32"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Int32"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public int Read(string sectionName, string keyName, int defaultValue)
		{
			int result;

			if (int.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Boolean"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Boolean"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public bool Read(string sectionName, string keyName, bool defaultValue) { return _ToBoolean(this.Read(sectionName, keyName, defaultValue.ToString())); }

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Byte"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Byte"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public byte Read(string sectionName, string keyName, byte defaultValue)
		{
			byte result;

			if (byte.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Char"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Char"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public char Read(string sectionName, string keyName, char defaultValue)
		{
			char result;

			if (char.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.DateTime"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.DateTime"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public DateTime Read(string sectionName, string keyName, DateTime defaultValue) { return new DateTime(this.Read(sectionName, keyName, defaultValue.Ticks)); }

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Decimal"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Decimal"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public decimal Read(string sectionName, string keyName, decimal defaultValue)
		{
			decimal result;

			if (decimal.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Double"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Double"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public double Read(string sectionName, string keyName, double defaultValue)
		{
			double result;

			if (double.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Single"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Single"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public float Read(string sectionName, string keyName, float defaultValue)
		{
			float result;

			if (float.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Guid"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Guid"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public Guid Read(string sectionName, string keyName, Guid defaultValue)
		{
			Guid result;

			try
			{
				result = new Guid(this.Read(sectionName, keyName, defaultValue.ToString()));
			}
			catch
			{
				result = defaultValue;
			}

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Int16"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Int16"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public short Read(string sectionName, string keyName, short defaultValue)
		{
			short result;

			if (short.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.Int64"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.Int64"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public long Read(string sectionName, string keyName, long defaultValue)
		{
			long result;

			if (long.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.UInt16"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.UInt16"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public UInt16 Read(string sectionName, string keyName, UInt16 defaultValue)
		{
			UInt16 result;

			if (UInt16.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.UInt32"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.UInt32"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public UInt32 Read(string sectionName, string keyName, UInt32 defaultValue)
		{
			UInt32 result;

			if (UInt32.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		/// <summary>
		/// 从指定配置节读取 <see cref="System.UInt64"/>。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="defaultValue">指定默认值。</param>
		/// <returns>当成功获取指定配置节的指定键值时则返回一个 <see cref="System.UInt64"/> 值，否则返回 <paramref name="defaultValue"/>。</returns>
		public UInt64 Read(string sectionName, string keyName, UInt64 defaultValue)
		{
			UInt64 result;

			if (UInt64.TryParse(this.Read(sectionName, keyName, defaultValue.ToString()), NumberStyles.Any, CultureInfo.InvariantCulture, out result) == false) result = defaultValue;

			return result;
		}

		#endregion

		#region 集合读写

		/// <summary>
		/// 从指定配置节读取指定键的以指定分隔符分隔的字符串的集合。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="separator">指定分隔符。</param>
		/// <param name="options">指定 <see cref="System.StringSplitOptions.RemoveEmptyEntries"/> 以省略返回的数组中的空数组元素，或指定 <see cref="System.StringSplitOptions.None"/> 以包含返回的数组中的空数组元素。</param>
		/// <returns>返回指定配置节读取指定键的以指定分隔符分隔的字符串的集合。如果读取失败将返回空集合，而不是返回 null。</returns>
		public List<string> Read(string sectionName, string keyName, string separator, StringSplitOptions options) { return this.Read(sectionName, keyName, new[] {separator}, options); }

		/// <summary>
		/// 从指定配置节读取指定键的以指定分隔符分隔的字符串的集合。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="separator">指定分隔字符串中子字符串的字符串数组、不包含分隔符的空数组或 null。</param>
		/// <param name="options">指定 <see cref="System.StringSplitOptions.RemoveEmptyEntries"/> 以省略返回的数组中的空数组元素，或指定 <see cref="System.StringSplitOptions.None"/> 以包含返回的数组中的空数组元素。</param>
		/// <returns>返回指定配置节读取指定键的以指定分隔符分隔的字符串的集合。如果读取失败将返回空集合，而不是返回 null。</returns>
		public List<string> Read(string sectionName, string keyName, string[] separator, StringSplitOptions options)
		{
			if (separator == null || separator.Length == 0) separator = new[] {", "};

			return this.Read(sectionName, keyName, String.Empty).Trim().Split(separator, options).ToList();
		}

		/// <summary>
		/// 从指定配置节读取指定键的以指定分隔符分隔的类型为 <typeparamref name="T"/> 的集合。
		/// </summary>
		/// <typeparam name="T">表示集合中的值的类型。</typeparam>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="separator">指定分隔符。</param>
		/// <param name="options">指定 <see cref="System.StringSplitOptions.RemoveEmptyEntries"/> 以省略返回的数组中的空数组元素，或指定 <see cref="System.StringSplitOptions.None"/> 以包含返回的数组中的空数组元素。</param>
		/// <param name="converter">指定将集合中的字符串型的值转换为 <typeparamref name="T"/> 的方法。</param>
		/// <returns>返回指定配置节读取指定键的以指定分隔符分隔的类型为 <typeparamref name="T"/> 的集合。如果读取失败将返回空集合，而不是返回 null。</returns>
		public List<T> Read<T>(string sectionName, string keyName, string separator, StringSplitOptions options, Converter<string, T> converter) { return this.Read(sectionName, keyName, new[] {separator}, options, converter); }

		/// <summary>
		/// 从指定配置节读取指定键的以指定分隔符分隔的类型为 <typeparamref name="T"/> 的集合。
		/// </summary>
		/// <typeparam name="T">表示集合中的值的类型。</typeparam>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="separator">指定分隔字符串中子字符串的字符串数组、不包含分隔符的空数组或 null。</param>
		/// <param name="options">指定 <see cref="System.StringSplitOptions.RemoveEmptyEntries"/> 以省略返回的数组中的空数组元素，或指定 <see cref="System.StringSplitOptions.None"/> 以包含返回的数组中的空数组元素。</param>
		/// <param name="converter">指定将集合中的字符串型的值转换为 <typeparamref name="T"/> 的方法。</param>
		/// <returns>返回指定配置节读取指定键的以指定分隔符分隔的类型为 <typeparamref name="T"/> 的集合。如果读取失败将返回空集合，而不是返回 null。</returns>
		public List<T> Read<T>(string sectionName, string keyName, string[] separator, StringSplitOptions options, Converter<string, T> converter) { return this.Read(sectionName, keyName, separator, options).ConvertAll(converter); }

		/// <summary>
		/// 将指定的字符串集合以指定的分隔符串联后写入到指定的配置节的键。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定要写入的字符串集合。</param>
		/// <param name="separator">指定分隔字符串中子字符串的字符串数组、不包含分隔符的空数组或 null。</param>
		/// <param name="removeEmptyEntries">指定 true 以省略返回的数组中的空数组元素，或指定 false 以包含返回的数组中的空数组元素。</param>
		public void Write(string sectionName, string keyName, List<string> value, string separator, bool removeEmptyEntries)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (value.Count == 0) return;

			var builder = new StringBuilder();

			foreach (var item in value)
			{
				if (removeEmptyEntries && String.IsNullOrEmpty(item)) continue;

				if (builder.Length == 0) builder.Append(item);
				else builder.Append(separator).Append(item);
			}

			this.Write(sectionName, keyName, builder.ToString());
		}

		/// <summary>
		/// 将指定的集合转换为字符串集合后以指定的分隔符串联后写入到指定的配置节的键。
		/// </summary>
		/// <typeparam name="T">表示集合中的值的类型。</typeparam>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定要写入的集合。</param>
		/// <param name="separator">指定分隔字符串中子字符串的字符串数组、不包含分隔符的空数组或 null。</param>
		/// <param name="removeEmptyEntries">指定 true 以省略返回的数组中的空数组元素，或指定 false 以包含返回的数组中的空数组元素。</param>
		/// <param name="converter">指定将集合中的 <typeparamref name="T"/> 的值转换为 <typeparamref name="T"/> 的方法。</param>
		public void Write<T>(string sectionName, string keyName, List<T> value, string separator, bool removeEmptyEntries, Converter<T, string> converter)
		{
			if (value == null) throw new ArgumentNullException("value");
			if (value.Count == 0) return;

			if (converter == null) throw new ArgumentNullException("converter");

			this.Write(sectionName, keyName, value.ConvertAll(converter), separator, removeEmptyEntries);
		}

		#endregion

		#region 写入

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, string value)
		{
			if (sectionName == null) throw new ArgumentNullException("sectionName");
			if (sectionName.Length == 0) throw new ArgumentOutOfRangeException("sectionName");

			if (keyName == null) throw new ArgumentNullException("keyName");
			if (keyName.Length == 0) throw new ArgumentOutOfRangeException("keyName");

			if (value == null) throw new ArgumentNullException("value");
			if (value.Length == 0) throw new ArgumentOutOfRangeException("value");

			if (this.Sections.Contains(sectionName))
			{
				if (this[sectionName].Items.Contains(keyName))
				{
                    var item = this[sectionName][keyName];
                    item.Value = value;
                    this[sectionName].Items[keyName] = item;
				}
				else
				{
					this[sectionName].Items.Add(new IniFileSectionItem {
						Key = keyName,
						Value = value,
						Comment = new List<string>()
					});
				}
			}
			else
			{
				var section = new IniFileSection(sectionName);
				section.Items.Add(new IniFileSectionItem {
					Key = keyName,
					Value = value,
					Comment = new List<string>()
				});

				this.Sections.Add(section);
			}
		}

        /// <summary>
        /// 更新键值的值
        /// </summary>
        /// <param name="sectionName">指定配置节名称。</param>
        /// <param name="keyName">指定键名。</param>
        /// <param name="value">指定键值。</param>
        public void UpdateWrite(string sectionName, string keyName, string value)
        {
            if (sectionName == null) throw new ArgumentNullException("sectionName");
            if (sectionName.Length == 0) throw new ArgumentOutOfRangeException("sectionName");

            if (keyName == null) throw new ArgumentNullException("keyName");
            if (keyName.Length == 0) throw new ArgumentOutOfRangeException("keyName");

            if (value == null) throw new ArgumentNullException("value");
            if (value.Length == 0) throw new ArgumentOutOfRangeException("value");

            if (this.Sections.Contains(sectionName))
            {
                if (this[sectionName].Items.Contains(keyName))
                {
                    var item = this[sectionName][keyName];
                    item.Value = value;
                    this[sectionName].Items[keyName] = item;
                }
                else
                {
                    //this[sectionName].Items.Add(new IniFileSectionItem
                    //{
                    //    Key = keyName,
                    //    Value = value,
                    //    Comment = new List<string>()
                    //});
                }
            }
            else
            {
                //    var section = new IniFileSection(sectionName);

                //    section.Items.Add(new IniFileSectionItem
                //    {
                //        Key = keyName,
                //        Value = value,
                //        Comment = new List<string>()
                //    });

                //    this.Sections.Add(section);
            }
        }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, int value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, bool value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, byte value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, char value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, DateTime value) { this.Write(sectionName, keyName, value.Ticks); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, decimal value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, double value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, float value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, Guid value) { this.Write(sectionName, keyName, value.ToString()); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, short value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, long value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, UInt16 value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, UInt32 value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>
		/// 在指定配置节写入键值对。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		/// <param name="value">指定键值。</param>
		public void Write(string sectionName, string keyName, UInt64 value) { this.Write(sectionName, keyName, value.ToString(CultureInfo.InvariantCulture)); }

		#endregion

		#region 删除

		/// <summary>
		/// 从 ini 文件删除指定的键。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		/// <param name="keyName">指定键名。</param>
		public void DeleteKey(string sectionName, string keyName)
		{
			if (sectionName == null) throw new ArgumentNullException("sectionName");
			if (sectionName.Length == 0) throw new ArgumentOutOfRangeException("sectionName");

			if (keyName == null) throw new ArgumentNullException("keyName");
			if (keyName.Length == 0) throw new ArgumentOutOfRangeException("keyName");

			if (!this.Sections.Contains(sectionName)) return;
            if (this[sectionName].Items.Contains(keyName)) this[sectionName].Items.Remove(keyName);
		}

		/// <summary>
		/// 从 ini 文件删除指定名称的配置节。
		/// </summary>
		/// <param name="sectionName">指定配置节名称。</param>
		public void DeleteSection(string sectionName)
		{
			if (sectionName == null) throw new ArgumentNullException("sectionName");
			if (sectionName.Length == 0) throw new ArgumentOutOfRangeException("sectionName");

			if (this.Sections.Contains(sectionName)) this.Sections.Remove(sectionName);
		}

		#endregion

		#region 常规操作

		/// <summary>
		/// 保存配置信息。
		/// </summary>
		public void Save() { this.Save(this.FileName); }

		/// <summary>
		/// 保存配置信息到指定的文件。
		/// </summary>
		/// <param name="fileName">指定要保存到的文件的完整路径。</param>
		public void Save(string fileName) { this.Save(fileName, this.Encoding); }

		/// <summary>
		/// 保存配置信息到指定的文件。
		/// </summary>
		/// <param name="fileName">指定要保存到的文件的完整路径。</param>
		/// <param name="encoding">指定字符编码。</param>
		public void Save(string fileName, Encoding encoding)
		{
			if (fileName == null) throw new ArgumentNullException("fileName");
			if (fileName.Length == 0) throw new ArgumentOutOfRangeException("fileName");

			var builder = new StringBuilder();

			// 文档注释
			foreach (var comment in this.Comment)
			{
				var textBuffer = comment.Trim();

				if (builder.Length == 0 && String.IsNullOrEmpty(textBuffer)) continue;

				builder.AppendFormat("; {0}{1}", textBuffer, Environment.NewLine);
			}

			if (this.Comment.Count > 0) builder.AppendLine();

			// 文档内容
			foreach (var section in this.Sections) builder.AppendLine(section.ToString());

			File.WriteAllText(fileName, builder.ToString().Trim(), encoding);

			if (this.Saved == null) return;

			this.Saved(this, EventArgs.Empty);
		}

		/// <summary>
		/// 刷新配置信息。
		/// </summary>
		public void Refresh()
		{
			var iniData = File.ReadAllLines(this.FileName, this.Encoding);

			if (iniData.Length == 0) return;

			var nextItemComment = new List<string>();
			var section = IniFileSection.None;
			string dataBuffer;

			foreach (var data in iniData)
			{
				dataBuffer = data.Trim();

				// 空行
				if (String.IsNullOrEmpty(dataBuffer))
				{
					// 作为文档注释
					if (nextItemComment.Count > 0 && this.Sections.Count == 0)
					{
						this.Comment.AddRange(nextItemComment);

						nextItemComment.Clear();
					}

					continue;
				}

				// 非法格式
				if (dataBuffer.StartsWith("="))
				{
					nextItemComment.Clear();

					continue;
				}

				// 注释格式，作为下一行的注释
				if (dataBuffer.StartsWith(";") || dataBuffer.StartsWith("#"))
				{
					nextItemComment.Add(dataBuffer.Remove(0, 1).Trim());

					if (nextItemComment.Count > 0) continue;
				}

				// 配置节名称
				if (dataBuffer.StartsWith("[") && dataBuffer.EndsWith("]"))
				{
					if (section != IniFileSection.None) this.Sections.Add(section);

					section = new IniFileSection(dataBuffer.Trim('[', ']'));

					if (nextItemComment.Count > 0)
					{
						section.Comment.AddRange(nextItemComment);

						nextItemComment.Clear();
					}

					continue;
				}

				// 无键值的项
				IniFileSectionItem item;
				var index = dataBuffer.IndexOf('=');

				if (index == -1)
				{
					if (section != IniFileSection.None)
					{
						item = new IniFileSectionItem {
							Key = dataBuffer,
							Value = String.Empty,
							Comment = new List<string>()
						};

						if (nextItemComment.Count > 0)
						{
							item.Comment.AddRange(nextItemComment);

							nextItemComment.Clear();
						}

						section.Items.Add(item);
					}

					continue;
				}

				// 键值对
				if (section == IniFileSection.None) continue;

				var key = dataBuffer.Substring(0, index).Trim();
				var value = dataBuffer.Substring(index + 1).Trim();

				item = new IniFileSectionItem {
					Key = key,
					Value = value,
					Comment = new List<string>()
				};

				if (nextItemComment.Count > 0)
				{
					item.Comment.AddRange(nextItemComment);

					nextItemComment.Clear();
				}

				section.Items.Add(item);
			}

			// 最后一项
			if (section == IniFileSection.None) return;

			if (nextItemComment.Count > 0)
			{
				section.Comment.AddRange(nextItemComment);

				nextItemComment.Clear();
			}

			this.Sections.Add(section);
		}

		#endregion

		#endregion

		#region 公有属性

		/// <summary>
		/// 获取或设置具有指定键的 <see cref="IniFileSection"/> 的实例。
		/// </summary>
		/// <param name="sectionname">指定键名。</param>
		/// <returns>返回具有指定键名的 <see cref="IniFileSection"/>。</returns>
		public IniFileSection this[string sectionname] { get { return this.Sections[sectionname]; } set { this.Sections[sectionname] = value; } }

		/// <summary>
		/// 获取 ini 文件的完整路径。
		/// </summary>
		public string FileName { get; private set; }

		/// <summary>
		/// 获取 ini 文件的编码类型。
		/// </summary>
		public Encoding Encoding { get; private set; }

		/// <summary>
		/// 获取或设置 ini 文件文档注释。
		/// </summary>
		public List<string> Comment { get; set; }

		/// <summary>
		/// 获取 ini 文件包含的配置节的集合。
		/// </summary>
		public IniFileSectionCollection Sections { get; private set; }

		#endregion
	}
}