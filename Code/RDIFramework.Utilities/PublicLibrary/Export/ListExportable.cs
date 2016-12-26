using System;
using System.Collections;
using System.Reflection;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 将 List 封装成 Exportable
	/// </summary>
	public class ListExportable : Exportable
	{
		private IList _list;
		private PropertyInfo[] _props;

		/// <summary>
		/// Initializes a new instance of the <see cref="ListExportable"/> class.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="type">The type.</param>
		/// <param name="props">The props.</param>
		public ListExportable(IList list, Type type, params string[] props)
		{
			if (type == null) throw new ArgumentNullException("type");
			if (props.Length < 1) throw new ArgumentException("props");

			PropertyInfo[] properties = new PropertyInfo[props.Length];
			for (int index = 0; index < props.Length; ++index)
			{
				string propName = props[index];
				properties[index] = type.GetProperty(propName);
			}
			Init(list, properties);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ListExportable"/> class.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="type">The type.</param>
		public ListExportable(IList list, Type type)
		{
			if (type == null) throw new ArgumentNullException("type");
			Init(list, type.GetProperties());
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ListExportable"/> class.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="props">The props.</param>
		public ListExportable(IList list, PropertyInfo[] props)
		{
			Init(list, props);
		}

		/// <summary>
		/// Inits the specified list.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <param name="props">The props.</param>
		private void Init(IList list, PropertyInfo[] props)
		{
			if (list == null) throw new ArgumentNullException("list");
			if (props == null || props.Length < 1) throw new ArgumentNullException("props");

			this._list = list;
			this._props = props;
			base.SetRowAndColumnCount(list.Count, props.Length);
		}

		/// <summary>
		/// 获取指定位置单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">行下标.</param>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetValue(int rowIndex, int columnIndex, ExportContext context)
		{
			object obj = this._list[rowIndex];
			PropertyInfo property = this._props[columnIndex];
			context.CellValue = property.GetValue(obj, null);
		}

		/// <summary>
		/// 获取指定表头单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetHeaderValue(int columnIndex, ExportContext context)
		{
			context.CellValue = this._props[columnIndex].Name;
		}
	}
}
