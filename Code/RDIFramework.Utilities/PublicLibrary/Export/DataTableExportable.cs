using System;
using System.Data;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 将 DataTable 封装成 IExportable
	/// </summary>
	public class DataTableExportable : Exportable
	{
		private DataTable _table;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataTableExportable"/> class.
		/// </summary>
		/// <param name="table">The table.</param>
		public DataTableExportable(DataTable table)
		{
			if (table == null) throw new ArgumentNullException("table");

			this._table = table;
			base.SetRowAndColumnCount(table.Rows.Count, table.Columns.Count);
		}

		/// <summary>
		/// 获取指定位置单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">行下标.</param>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetValue(int rowIndex, int columnIndex, ExportContext context)
		{
			context.CellValue = this._table.Rows[rowIndex][columnIndex];
		}

		/// <summary>
		/// 获取指定表头单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetHeaderValue(int columnIndex, ExportContext context)
		{
			context.CellValue = this._table.Columns[columnIndex].ColumnName;
		}
	}
}
