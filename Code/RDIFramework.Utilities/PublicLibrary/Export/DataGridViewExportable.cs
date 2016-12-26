using System;
using System.Windows.Forms;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 将 DataGridView 封装成 Exportable
	/// </summary>
	public class DataGridViewExportable : Exportable
	{
		private DataGridView _dataGridView;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataGridViewExportable"/> class.
		/// </summary>
		/// <param name="dataGridView">The data grid view.</param>
		public DataGridViewExportable(DataGridView dataGridView)
		{
			if (dataGridView == null) throw new ArgumentNullException("dataGridView");

			this._dataGridView = dataGridView;
			base.SetRowAndColumnCount(
				dataGridView.RowCount - (dataGridView.AllowUserToAddRows ? 1 : 0),
				dataGridView.ColumnCount);
		}

		/// <summary>
		/// 获取指定位置单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">行下标.</param>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetValue(int rowIndex, int columnIndex, ExportContext context)
		{
			context.CellValue = this._dataGridView.Rows[rowIndex].Cells[columnIndex].FormattedValue;
		}

		/// <summary>
		/// 获取指定表头单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetHeaderValue(int columnIndex, ExportContext context)
		{
			context.CellValue = this._dataGridView.Columns[columnIndex].HeaderText;
		}
	}
}
