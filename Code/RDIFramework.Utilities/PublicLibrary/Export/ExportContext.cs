using System;

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// 表示导出上下文
	/// </summary>
	public class ExportContext : ICloneable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExportContext"/> class.
		/// </summary>
		public ExportContext()
		{
			this._startRowIndex = 0;
		}

		private Exporter _exporter;

		/// <summary>
		/// 关联的导出工具
		/// </summary>
		public Exporter Exporter
		{
			get { return _exporter; }
			internal set { _exporter = value; }
		}

		private IExportable _exportable;

		/// <summary>
		/// 获取导出上下文相关的 Exportable.
		/// </summary>
		public IExportable Exportable
		{
			get { return _exportable; }
			internal set { _exportable = value; }
		}

		private HSSFWorkbook _workbook;

		/// <summary>
		/// 获取导出上下文相关的 Workbook
		/// </summary>
		public HSSFWorkbook Workbook
		{
			get { return _workbook; }
			internal set { _workbook = value; }
		}

		private ISheet _sheet;

		/// <summary>
		/// 获取导出上下文相关的 Sheet
		/// </summary>
		public ISheet Sheet
		{
			get { return _sheet; }
			internal set { _sheet = value; }
		}

		private int _startRowIndex;

		/// <summary>
		/// 当前导出的开始行下标（此值受之前使用 Union 的影响）.
		/// </summary>
		public int StartRowIndex
		{
			get { return _startRowIndex; }
			set { _startRowIndex = value; }
		}

		/// <summary>
		/// 获取总的行下标（ = StartRowIndex + RowIndex，如果仅有一个导出对象，则此值与 RowIndex 相同，否则不同）.
		/// </summary>
		public int TotalRowIndex
		{
			get { return this._startRowIndex + this._rowIndex; }
		}

		private int _rowIndex;

		/// <summary>
		/// 获取导出上下文相关的 RowIndex
		/// </summary>
		public int RowIndex
		{
			get { return _rowIndex; }
			internal set { _rowIndex = value; }
		}

		private int _columnIndex;

		/// <summary>
		/// 获取导出上下文相关的 ColumnIndex
		/// </summary>
		public int ColumnIndex
		{
			get { return _columnIndex; }
			internal set { _columnIndex = value; }
		}

		private CellType _cellType;

		/// <summary>
		/// 单元格类型.
		/// </summary>
		public CellType CellType
		{
			get { return _cellType; }
			set { _cellType = value; }
		}

		private object _cellValue;

		/// <summary>
		/// 获取或设置当前单元格的导出值
		/// </summary>
		public object CellValue
		{
			get { return _cellValue; }
			set { _cellValue = value; }
		}

		/// <summary>
		/// 获取字符串值
		/// </summary>
		public string StringValue
		{
			get
			{
				object value = _cellValue;
				if (value == null) return string.Empty;
				return value.ToString();
			}
		}

		private CellValueType _cellValueType;

		/// <summary>
		/// 单元格值的类型
		/// </summary>
		public CellValueType CellValueType
		{
			get { return _cellValueType; }
			set { _cellValueType = value; }
		}

		private ICellStyle _cellStyle;

		/// <summary>
		/// 获取或设置当前单元格的样式，为空表示不引用样式
		/// </summary>
		public ICellStyle CellStyle
		{
			get { return _cellStyle; }
			set { _cellStyle = value; }
		}

		private bool _isValid;

		/// <summary>
		/// 获取或设置当前单元格的有效性
		/// </summary>
		public bool IsValid
		{
			get { return _isValid; }
			set { _isValid = value; }
		}

		private object _tag;

		/// <summary>
		/// 获取或设置包含有关导出上下文的数据的对象.
		/// </summary>
		public object Tag
		{
			get { return _tag; }
			set { _tag = value; }
		}

		private object[] _columnTags;

		/// <summary>
		/// 获取或设置包含有关当前单元格所在的列的数据的对象的数组.
		/// </summary>
		public object[] ColumnTags
		{
			get { return _columnTags; }
			internal set { _columnTags = value; }
		}

		/// <summary>
		/// 获取或设置包含有关当前单元格所在的列的数据的对象.
		/// </summary>
		public object ColumnTag
		{
			get
			{
				object[] columnTags = this._columnTags;
				int columnIndex = this._columnIndex;

				if (columnTags == null || columnIndex >= columnTags.Length) return null;
				return columnTags[columnIndex];
			}
			set
			{
				int columnIndex = this._columnIndex;

				if (this._columnTags == null)
				{
					this._columnTags = new object[7];
				}
				else if(columnIndex >= this._columnTags.Length)
				{
					Array.Resize(ref this._columnTags, this._columnTags.Length * 2);
				}

				this._columnTags[columnIndex] = value;
			}
		}

		/// <summary>
		/// 重设 CellValueType, CellStyle, IsValid 属性.
		/// </summary>
		public void Reset()
		{
			//this._cellValue = null;
			this._cellValueType = CellValueType.StringDenotable;
			this._cellStyle = null;
			this._isValid = true;
		}

		/// <summary>
		/// 创建作为当前实例副本的新对象。
		/// </summary>
		/// <returns>
		/// 作为此实例副本的新对象。
		/// </returns>
		public object Clone()
		{
			object clone = base.MemberwiseClone();
			return clone;
		}

		//public ExportCell NewWorkbook()
		//{
		//    HSSFWorkbook workbook = this.Workbook;
		//    if (workbook != null)
		//    {
		//        workbook.Dispose();
		//    }

		//    this.Workbook = Exporter.CreateHSSFWorkbook();
		//    return this;
		//}

		//public ExportCell NewSheet(string name)
		//{
		//    if (this.Sheet != null)
		//    {
		//        this.Sheet.Dispose();
		//    }
		//    this.Sheet = this.Workbook.CreateSheet(name);

		//    return this;
		//}
	}
}
