using System;
using System.Data;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 将 DataView 封装成 Exportable
	/// </summary>
	public class DataViewExportable : Exportable
	{
		private DataView _view;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataViewExportable"/> class.
		/// </summary>
		/// <param name="view">The view.</param>
		public DataViewExportable(DataView view)
		{
			if (view == null) throw new ArgumentNullException("view");

			this._view = view;
			base.SetRowAndColumnCount(view.Count, view.Table.Columns.Count);
		}

		/// <summary>
		/// 获取指定位置单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">行下标.</param>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetValue(int rowIndex, int columnIndex, ExportContext context)
		{
			context.CellValue = this._view[rowIndex][columnIndex];
		}

		/// <summary>
		/// 获取指定表头单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetHeaderValue(int columnIndex, ExportContext context)
		{
			context.CellValue = this._view.Table.Columns[columnIndex].ColumnName;
		}
	}
}
