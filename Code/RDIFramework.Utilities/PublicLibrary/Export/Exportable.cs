using System;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 固定行数和列数的 Exportable
	/// </summary>
	public abstract class Exportable : IExportable, IExportHeader
	{
		private int _rowCount;
		private int _columnCount;

		/// <summary>
		/// Initializes a new instance of the <see cref="Exportable"/> class.
		/// </summary>
		/// <param name="rowCount">行数.</param>
		/// <param name="columnCount">列数.</param>
		public Exportable(int rowCount, int columnCount)
		{
			SetRowAndColumnCount(rowCount, columnCount);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Exportable"/> class.
		/// </summary>
		public Exportable()
		{

		}

		/// <summary>
		/// Sets the row and column count.
		/// </summary>
		/// <param name="rowCount">行数.</param>
		/// <param name="columnCount">列数.</param>
		protected void SetRowAndColumnCount(int rowCount, int columnCount)
		{
			if (rowCount < 0) throw new ArgumentOutOfRangeException("rowCount");
			if (columnCount < 0) throw new ArgumentOutOfRangeException("columnCount");

			this._rowCount = rowCount;
			this._columnCount = columnCount;
		}

		/// <summary>
		/// 获取行数.
		/// </summary>
		/// <returns>行数</returns>
		public int GetRowCount()
		{
			return this._rowCount;
		}

		/// <summary>
		/// 获取列数.
		/// </summary>
		/// <returns>列数</returns>
		public int GetColumnCount()
		{
			return this._columnCount;
		}

		#region IExportable 成员

		/// <summary>
		/// 将行游标移动到下一个行.
		/// </summary>
		/// <param name="rowIndex">当前行的下标，从 0 开始，系统会自动计数，每成功获取一行会自动加一.</param>
		/// <returns>
		/// 如果成功，返回 true，否则返回 false.
		/// </returns>
		public bool NextRow(int rowIndex)
		{
			return rowIndex < this._rowCount;
		}

		/// <summary>
		/// 将游标移动到当前行的下一个单元格，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">当前行的下标，从 0 开始，系统会自动计数，每成功获取一行会自动加一.</param>
		/// <param name="columnIndex">当前列的下标，从 0 开始，系统会自动计数，每成功获取一个单元格会自动加一.</param>
		/// <param name="context">导出上下文.</param>
		/// <returns>
		/// 成功则返回 true, 否则返回 false.
		/// </returns>
		public bool NextCell(int rowIndex, int columnIndex, ExportContext context)
		{
			if (columnIndex < this._columnCount)
			{
				this.GetValue(rowIndex, columnIndex, context);
				return true;
			}

			return false;
		}

		/// <summary>
		/// 获取指定位置单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">行下标.</param>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected abstract void GetValue(int rowIndex, int columnIndex, ExportContext context);

		#endregion

		#region IExportHeader 成员

		/// <summary>
		/// 将单元格游标移动到下一个单元格，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">当前列的下标，从 0 开始，系统会自动计数，每成功获取一个单元格会自动加一.</param>
		/// <param name="context">导出上下文.</param>
		/// <returns>
		/// 成功则返回 true, 否则返回 false.
		/// </returns>
		public bool NextHeaderCell(int columnIndex, ExportContext context)
		{
			if (columnIndex < this._columnCount)
			{
				this.GetHeaderValue(columnIndex, context);
				return true;
			}

			return false;
		}

		/// <summary>
		/// 获取指定表头单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected abstract void GetHeaderValue(int columnIndex, ExportContext context);

		#endregion
	}
}
