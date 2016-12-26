using System;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 一个用于分页的 Exportable
	/// </summary>
	public class PagedExportable : IExportable, IExportHeader
	{
		private readonly IExportable _target;
		private readonly IExportHeader _header;
		private readonly int _pageSize;

		private int _startIndex;

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedExportable"/> class.
		/// </summary>
		/// <param name="target">包含要导出数据的 Exportable.</param>
		/// <param name="pageSize">分页大小.</param>
		public PagedExportable(IExportable target, int pageSize)
			: this(null, target, pageSize) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedExportable"/> class.
		/// </summary>
		/// <param name="header">导出头.</param>
		/// <param name="target">包含要导出数据的 Exportable.</param>
		/// <param name="pageSize">分页大小.</param>
		public PagedExportable(IExportHeader header, IExportable target, int pageSize)
		{
			if (target == null) throw new ArgumentNullException("target");
			if (pageSize < 1 || pageSize > 65536) throw new ArgumentOutOfRangeException("pageSize");

			this._header = header;
			this._target = target;
			this._pageSize = pageSize;

			this._startIndex = 0;
		}

		#region IExportable 成员

		/// <summary>
		/// 下翻一页.
		/// </summary>
		/// <param name="pageIndex">当前页的下标.</param>
		public void NextPage(int pageIndex)
		{
			this._startIndex += this._pageSize;
		}

		/// <summary>
		/// 将行游标移动到下一个行.
		/// </summary>
		/// <param name="rowIndex">当前行的下标，从 0 开始，系统会自动计数，每成功获取一行会自动加一.</param>
		/// <returns>
		/// 如果成功，返回 true，否则返回 false.
		/// </returns>
		public bool NextRow(int rowIndex)
		{
			if (rowIndex < this._pageSize)
			{
				return this._target.NextRow(rowIndex + this._startIndex);
			}

			return false;
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
			return this._target.NextCell(rowIndex + this._startIndex, columnIndex, context);
		}

		#endregion

		#region IExportHeader 成员

		/// <summary>
		/// 将单元格游标移动到下一个单元格.
		/// </summary>
		/// <param name="columnIndex">当前列的下标，从 0 开始，系统会自动计数，每成功获取一个单元格会自动加一.</param>
		/// <param name="context">导出上下文.</param>
		/// <returns>
		/// 成功则返回 true, 否则返回 false.
		/// </returns>
		public bool NextHeaderCell(int columnIndex, ExportContext context)
		{
			if (this._header == null) return false;
			return this._header.NextHeaderCell(columnIndex, context);
		}

		#endregion
	}
}
