namespace RDIFramework.Utilities
{
	/// <summary>
	/// 导出对象的表头
	/// </summary>
	public interface IExportHeader
	{
		/// <summary>
		/// 将单元格游标移动到下一个单元格.
		/// </summary>
		/// <param name="columnIndex">当前列的下标，从 0 开始，系统会自动计数，每成功获取一个单元格会自动加一.</param>
		/// <param name="context">导出上下文.</param>
		/// <returns>成功则返回 true, 否则返回 false.</returns>
		bool NextHeaderCell(int columnIndex, ExportContext context);
	}
}
