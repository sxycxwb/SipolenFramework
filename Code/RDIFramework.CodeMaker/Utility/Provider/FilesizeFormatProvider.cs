using System;
using System.Text.RegularExpressions;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// 提供一种方法，它支持对表示文件尺寸的数字的格式化。
	/// </summary>
	public sealed class FileSizeFormatProvider : IFormatProvider, ICustomFormatter
	{
		#region 私有字段

		private const string _FORMAT = "FS";

		#endregion

		#region 私有方法

		private static string _DefaultFormat(string format, object arg, IFormatProvider formatProvider)
		{
			var formattableArg = arg as IFormattable;

			return formattableArg != null ? formattableArg.ToString(format, formatProvider) : arg.ToString();
		}

		private static string _FormatFileSize(decimal size, string format)
		{
			var u = new[] {"B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "NB", "DB"};

			var i = size;
			var n = 0;

			while (i > 1024)
			{
				i = i / 1024.0M;

				if (n++ == 10) break;
			}

			return i.ToString(format) + u[n];
		}

		#endregion

		#region IFormatProvider 成员

		/// <summary>
		/// 返回一个对象，该对象为指定类型提供格式设置服务。
		/// </summary>
		/// <param name="formatType">一个对象，该对象指定要返回的格式对象的类型。</param>
		/// <returns>如果 <see cref="System.IFormatProvider"/> 实现能够提供该类型的对象，则为 formatType 所指定对象的实例；否则为 null。</returns>
		public object GetFormat(Type formatType)
		{
			if (formatType != null) if (formatType == typeof(ICustomFormatter)) return this;

			return null;
		}

		#endregion

		#region ICustomFormatter 成员

		/// <summary>
		/// 使用指定的格式和区域性特定格式设置信息将指定对象的值转换为等效的字符串表示形式。
		/// </summary>
		/// <param name="format">包含格式规范的格式字符串。</param>
		/// <param name="arg">要格式化的对象。</param>
		/// <param name="formatProvider">一个 System.IFormatProvider 对象，它提供有关当前实例的格式信息。</param>
		/// <returns>arg 的值的字符串表示形式，按照 format 和 formatProvider 的指定来进行格式设置。</returns>
		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			var iformat = format;

			if (iformat == null || !iformat.StartsWith(_FORMAT, StringComparison.OrdinalIgnoreCase) || arg is string) return _DefaultFormat(iformat, arg, formatProvider);

			decimal size;

			try
			{
				size = Convert.ToDecimal(arg);
			}
			catch (InvalidCastException)
			{
				return _DefaultFormat(iformat, arg, formatProvider);
			}

			iformat = iformat.Substring(2);

			var precision = Regex.Match(iformat, @"^\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline).Value;

			if (String.IsNullOrEmpty(precision)) precision = "2";

			var other = iformat.Replace(precision, String.Empty);

			return _FormatFileSize(size, "N" + precision) + other;
		}

		#endregion
	}
}