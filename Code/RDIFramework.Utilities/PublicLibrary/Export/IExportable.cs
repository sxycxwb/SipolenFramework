namespace RDIFramework.Utilities
{
	/// <summary>
	/// 定义了一个可导出对象的规范
	/// </summary>
	public interface IExportable
	{
		/// <summary>
		/// 将行游标移动到下一个行.
		/// </summary>
		/// <param name="rowIndex">当前行的下标，从 0 开始，系统会自动计数，每成功获取一行会自动加一.</param>
		/// <returns>如果成功，返回 true，否则返回 false.</returns>
		bool NextRow(int rowIndex);

		/// <summary>
		/// 将游标移动到当前行的下一个单元格，并填充当前 context 的 CellValue 等属性.
		/// </summary>
		/// <param name="rowIndex">当前行的下标，从 0 开始，系统会自动计数，每成功获取一行会自动加一.</param>
		/// <param name="columnIndex">当前列的下标，从 0 开始，系统会自动计数，每成功获取一个单元格会自动加一.</param>
		/// <param name="context">导出上下文.</param>
		/// <returns>成功则返回 true, 否则返回 false.</returns>
		bool NextCell(int rowIndex, int columnIndex, ExportContext context);
	}
}
