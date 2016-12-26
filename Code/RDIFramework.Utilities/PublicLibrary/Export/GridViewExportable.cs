using System;
using System.Web.UI.WebControls;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 将 GridView 封装成 Exportable
	/// </summary>
	public class GridViewExportable : Exportable
	{
		private GridView _gridView;

		/// <summary>
		/// Initializes a new instance of the <see cref="GridViewExportable"/> class.
		/// </summary>
		/// <param name="gridView">The grid view.</param>
		public GridViewExportable(GridView gridView)
		{
			if (gridView == null) throw new ArgumentNullException("gridView");

			this._gridView = gridView;
			base.SetRowAndColumnCount(gridView.Rows.Count, gridView.Columns.Count);
		}

		/// <summary>
		/// 获取指定位置单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">行下标.</param>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetValue(int rowIndex, int columnIndex, ExportContext context)
		{
			context.CellValue = this._gridView.Rows[rowIndex].Cells[columnIndex].Text;
		}

		/// <summary>
		/// 获取指定表头单元格的值，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="columnIndex">列下标.</param>
		/// <param name="context">导出上下文.</param>
		protected override void GetHeaderValue(int columnIndex, ExportContext context)
		{
			context.CellValue = this._gridView.Columns[columnIndex].HeaderText;
		}
	}
}
