using System;
using System.IO;
using System.Data;

using ICSharpCode.SharpZipLib.Zip;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace RDIFramework.Utilities
{
	/// <summary>
    /// 导出工具（用于批量导出数据到 Excel）
	/// </summary>
	public class Exporter
	{
		#region Fields
		private ExportContext _context;
		//private DocumentSummaryInformation _dsi;
		//private SummaryInformation _si;
		#endregion

		#region Ctors
		/// <summary>
		/// Initializes a new instance of the <see cref="Exporter"/> class.
		/// </summary>
		public Exporter()
		{

		}
		#endregion

		#region Properties
		private string _company;

		/// <summary>
		/// 公司信息
		/// </summary>
		public string Company
		{
			get { return _company; }
			set { _company = value; }
		}

		private string _subject;

		/// <summary>
		/// 标题信息
		/// </summary>
		public string Subject
		{
			get { return _subject; }
			set { _subject = value; }
		}

		#endregion

		#region Flow
		/// <summary>
		/// 创建新的 excel 文档.
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter NewExcel()
		{
			CloseExcel();

			var context = new ExportContext();
			var workbook = new HSSFWorkbook();
			var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
			var si = PropertySetFactory.CreateSummaryInformation();

			if (this.Company != null) dsi.Company = this.Company;
			if (this.Subject != null) si.Subject = this.Subject;

			workbook.DocumentSummaryInformation = dsi;
			workbook.SummaryInformation = si;
			context.Workbook = workbook;

			this._context = context;
			//this._dsi = dsi;
			//this._si = si;

			return this;
		}

		///// <summary>
		///// 设置公司信息.
		///// </summary>
		///// <param name="company">公司信息.</param>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter SetCompany(string company)
		//{
		//    ExportContext context = this._context;
		//    if (context == null) throw new Exception("请先调用 NewExcel()");
		//    if (company == null) company = string.Empty;

		//    this._dsi.Company = company;
		//    return this;
		//}

		///// <summary>
		///// 设置 subject.
		///// </summary>
		///// <param name="subject">subject.</param>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter SetSubject(string subject)
		//{
		//    ExportContext context = this._context;
		//    if (context == null) throw new Exception("请先调用 NewExcel()");
		//    if (subject == null) subject = string.Empty;

		//    this._si.Subject = subject;
		//    return this;
		//}

		/// <summary>
		/// 设置列数（是一个参考值，如果指定准确的值，则在使用 ColumnTag 时，效率会高）.
		/// </summary>
		/// <param name="columnCount">列数目.</param>
		/// <returns>this, 以支持链式操作</returns>
		public Exporter SetInitColumnCount(int columnCount)
		{
			if (columnCount < 1 || columnCount > 65536) throw new ArgumentOutOfRangeException("columnCount");
			var context = this._context;
			if (context == null) throw new Exception("请先调用 NewExcel()");

			context.ColumnTags = new object[columnCount];
			return this;
		}

		/// <summary>
		/// 在当前 excel 文档中创建一个 sheet
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="name">sheet 名称.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter NewSheet(string name)
		{
			var context = this._context;
			if (context == null) throw new Exception("请先调用 NewExcel()");

			var sheet = context.Workbook.CreateSheet(name);
			context.Sheet = sheet;
			context.StartRowIndex = 0;

			return this;
		}

		/// <summary>
		/// 将 exportable 中的数据连接到当前 sheet 中
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="rowCount">行数.</param>
		/// <param name="columnCount">列数.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter Union(int rowCount, int columnCount, ExportCallback callback)
		{
			//ExportCallback exportCallback = callback;
			var context = this._context;
			if (context == null) throw new Exception("请先调用 NewExcel()");
			var sheet = context.Sheet;
			if (sheet == null) throw new Exception("请先调用 NewSheet()");

			int rowIndex = 0, y = context.StartRowIndex;
			context.CellType = CellType.DataCell;
			while (rowIndex < rowCount)
			{
				IRow row = null;
				int columnIndex = 0, x = 0;

				context.RowIndex = rowIndex;
				while (true)
				{
					context.Reset();
					context.ColumnIndex = columnIndex;

					if (columnIndex < columnCount)
					{
						if (callback != null) callback(context);
						if (context.IsValid)
						{
							// 创建单元格
							if (row == null) row = sheet.CreateRow(y++);
							var cell = row.CreateCell(x++);

							// 设置单元格
							SetCell(cell, context);
						}

						++columnIndex;
					}
					else break;
				}

				++rowIndex;
			}
			context.StartRowIndex = y;

			return this;
		}

		/// <summary>
		/// 将 exportable 中的数据连接到当前 sheet 中
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="header">导出对象头.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>
		/// this, 以支持链式操作.
		/// </returns>
		public Exporter UnionHeader(IExportHeader header, ExportCallback callback)
		{
			//ExportCallback exportCallback = callback;
			var context = this._context;
			if (context == null) throw new Exception("请先调用 NewExcel()");
			var sheet = context.Sheet;
			if (sheet == null) throw new Exception("请先调用 NewSheet()");

			var y = context.StartRowIndex;
			IRow row = null;
			int columnIndex = 0, x = 0;

			context.RowIndex = 0;
			context.CellType = CellType.HeaderCell;
			while (true)
			{
				context.Reset();
				context.ColumnIndex = columnIndex;

				if (header.NextHeaderCell(columnIndex, context))
				{
					if (callback != null) callback(context);
					if (context.IsValid)
					{
						// 创建单元格
						if (row == null) row = sheet.CreateRow(y++);
						var cell = row.CreateCell(x++);

						// 设置单元格
						SetCell(cell, context);
					}

					++columnIndex;
				}
				else break;
			}

			context.StartRowIndex = y;

			return this;
		}

		///// <summary>
		///// 将 exportable 中的数据连接到当前 sheet 中
		///// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="callback">导出回调.</param>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter Union(Exportable exportable, ExportCallback callback)
		//{
		//    return this
		//        .UnionHeader((IExportHeader)exportable, callback)
		//        .Union((IExportable)exportable, callback);
		//}

		/// <summary>
		/// 将 exportable 中的数据连接到当前 sheet 中
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="exportable">可导出对象.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter Union(IExportable exportable, ExportCallback callback)
		{
			//ExportContext context = this._context;
			//if (context == null) throw new Exception("请先调用 NewExcel()");
			//ISheet sheet = context.Sheet;
			//if (sheet == null) throw new Exception("请先调用 NewSheet()");

			if (exportable.NextRow(0))
			{
				return this.DoUnion(exportable, callback);
			}

			return this;
		}

		/// <summary>
		/// 将 exportable 中的数据连接到当前 sheet 中
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="exportable">可导出对象.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter DoUnion(IExportable exportable, ExportCallback callback)
		{
			//ExportCallback exportCallback = callback;
			var context = this._context;
			if (context == null) throw new Exception("请先调用 NewExcel()");
			var sheet = context.Sheet;
			if (sheet == null) throw new Exception("请先调用 NewSheet()");

			int rowIndex = 0, y = context.StartRowIndex;
			context.CellType = CellType.DataCell;
			do
			{
				IRow row = null;
				int columnIndex = 0, x = 0;

				context.RowIndex = rowIndex;
				while (true)
				{
					context.Reset();
					context.ColumnIndex = columnIndex;

					if (exportable.NextCell(rowIndex, columnIndex, context))
					{
						if (callback != null) callback(context);
						if (context.IsValid)
						{
							// 创建单元格
							if (row == null) row = sheet.CreateRow(y++);
							var cell = row.CreateCell(x++);

							// 设置单元格
							SetCell(cell, context);
						}

						++columnIndex;
					}
					else break;
				}

				++rowIndex;
			} while (exportable.NextRow(rowIndex));
			context.StartRowIndex = y;

			return this;
		}

		/// <summary>
		/// 将当前 excel 文档写入到目标中
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="output">目标流.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter WriteTo(Stream output)
		{
			var context = this._context;
			if (context == null) throw new Exception("请先调用 NewExcel()");

			context.Workbook.Write(output);

			return this;
		}

		/// <summary>
		/// 将当前 excel 文档写入到目标中
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <param name="fileName">目标文件.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter WriteTo(string fileName)
		{
			using (var fs = new FileStream(fileName, FileMode.Create))
			{
				return WriteTo(fs);
			}
		}

		/// <summary>
		/// 关闭当前 excel 文档，释放资源
		/// 调用顺序: NewExcel() -&gt; NewSheet() -&gt; Union() -&gt; WriteTo() -&gt; CloseExcel().
		/// </summary>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter CloseExcel()
		{
			//this._dsi = null;
			//this._si = null;

			var context = this._context;
			if (context != null)
			{
				context.Sheet = null;
				var workbook = context.Workbook;
				if (workbook != null)
				{
					workbook.Dispose();
					context.Workbook = null;
				}

				this._context = null;
			}

			return this;
		}

		#endregion

		#region ExportToExcel

		#region Extend Overloads
		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="dataGridView">是导出的 DataGridView.</param>
		///// <param name="name">导出目标 sheet 的名称.</param>
		///// <param name="fileName">输出文件.</param>
		///// <param name="callback">导出回调.</param>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter ExportToExcel(DataGridView dataGridView, string name, string fileName, ExportCallback callback)
		//{
		//    IExportable exportable = new DataGridViewExportable(dataGridView);
		//    return ExportToExcel(exportable, name, fileName, callback);
		//}

		/// <summary>
		/// 导出到 Excel.
		/// </summary>
		/// <param name="view">是导出的 DataView.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="fileName">输出文件.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcel(DataView view, string name, string fileName, ExportCallback callback)
		{
			IExportable exportable = new DataViewExportable(view);
			return ExportToExcel(exportable, name, fileName, callback);
		}

		/// <summary>
		/// 导出到 Excel.
		/// </summary>
		/// <param name="table">是导出的 DataTable.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="fileName">输出文件.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcel(DataTable table, string name, string fileName, ExportCallback callback)
		{
			IExportable exportable = new DataTableExportable(table);
			return ExportToExcel(exportable, name, fileName, callback);
		}

		/// <summary>
		/// 导出到 Excel.
		/// </summary>
		/// <param name="exportable">可导出对象.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="fileName">输出文件.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcel(IExportable exportable, string name, string fileName, ExportCallback callback)
		{
			using (var fs = new FileStream(fileName, FileMode.Create))
			{
				return this.ExportToExcel(exportable, name, fs, callback);
			}
		}
		#endregion

		/// <summary>
		/// 导出到 Excel.
		/// </summary>
		/// <param name="exportable">可导出对象.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="output">输出流.</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcel(IExportable exportable, string name, Stream output, ExportCallback callback)
		{
			try
			{
				this.NewExcel().NewSheet(name);

				var header = exportable as IExportHeader;
				if (header != null) this.UnionHeader(header, callback);
				this.Union(exportable, callback)
					.WriteTo(output);
			}
			finally
			{
				this.CloseExcel();
			}

			return this;
		}
		
		#endregion

		#region ExportToExcelByPage

		#region Extend Overloads
		/// <summary>
		/// 分页导出到 Excel.
		/// </summary>
		/// <param name="exportable">可导出对象.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="pageSize">每页的大小.</param>
		/// <param name="zip">导出目标流.</param>
		/// <param name="partNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突..</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcelByPage(IExportable exportable, string name, int pageSize, ZipOutputStream zip, string partNameFormat, ExportCallback callback)
		{
			var paged = new PagedExportable(exportable as IExportHeader, exportable, pageSize);

			return ExportToExcelByPage(paged, name, zip, partNameFormat, callback);
		}

		/// <summary>
		/// 分页导出到 Excel.
		/// </summary>
		/// <param name="exportable">可导出对象.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="pageSize">每页的大小.</param>
		/// <param name="fileName">导出目标流.</param>
		/// <param name="partNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突..</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcelByPage(IExportable exportable, string name, int pageSize, string fileName, string partNameFormat, ExportCallback callback)
		{
			using (var zos = new ZipOutputStream(new FileStream(fileName, FileMode.OpenOrCreate)))
			{
				return this.ExportToExcelByPage(exportable, name, pageSize, zos, partNameFormat, callback);
			}
		}
		#endregion

		/// <summary>
		/// 分页导出到 Excel.
		/// </summary>
		/// <param name="paged">分页的 Exportable.</param>
		/// <param name="name">导出目标 sheet 的名称.</param>
		/// <param name="zip">导出目标流.</param>
		/// <param name="partNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突..</param>
		/// <param name="callback">导出回调.</param>
		/// <returns>this, 以支持链式操作.</returns>
		public Exporter ExportToExcelByPage(PagedExportable paged, string name,ZipOutputStream zip, string partNameFormat, ExportCallback callback)
		{
			var pageIndex = 0;
			while (paged.NextRow(0))
			{
				var fileName = string.Format(partNameFormat, ++pageIndex);
				var entry = new ZipEntry(fileName);
				entry.DateTime = DateTime.Now;
				zip.PutNextEntry(entry);

				try
				{
					this.NewExcel()
						.NewSheet(name)
						.UnionHeader(paged, callback)
						.DoUnion(paged, callback)
						.WriteTo(zip);
				}
				finally
				{
					this.CloseExcel();
				}

				paged.NextPage(pageIndex);
			}

			return this;
		}
		
		#endregion

		#region Private Methods
		/// <summary>
		/// 设置单元格
		/// </summary>
		/// <param name="cell"></param>
		/// <param name="context"></param>
		private static void SetCell(ICell cell, ExportContext context)
		{
			if (context.CellStyle != null)
			{
				cell.CellStyle = context.CellStyle;
			}

			var value = context.CellValue;
			var type = context.CellValueType;
			switch (type)
			{
				case CellValueType.StringDenotable:
					cell.SetCellValue(value == null ? string.Empty : value.ToString());
					break;

				case CellValueType.String:
					cell.SetCellValue((string)value);
					break;

				case CellValueType.DateTime:
					cell.SetCellValue((DateTime)value);
					break;

				case CellValueType.Boolean:
					cell.SetCellValue((bool)value);
					break;

				case CellValueType.Double:
					cell.SetCellValue((double)value);
					break;

				case CellValueType.RichText:
					cell.SetCellValue((IRichTextString)value);
					break;

				case CellValueType.Other:
					#region
					if (value == null) cell.SetCellValue(string.Empty);
					var t = value.GetType();

					if (t == typeof(string))
					{
						cell.SetCellValue((string)value);
					}
					else if (t == typeof(DateTime))
					{
						cell.SetCellValue((DateTime)value);
					}
					else if (t == typeof(bool))
					{
						cell.SetCellValue((bool)value);
					}
					else if (t == typeof(IRichTextString))
					{
						cell.SetCellValue((IRichTextString)t);
					}
					else if (t == typeof(byte) || t == typeof(short) || t == typeof(int) || t == typeof(long) || t == typeof(float) || t == typeof(double))
					{
						cell.SetCellValue(Convert.ToDouble(value));
					}
					else
					{
						cell.SetCellValue(value.ToString());
					}
					#endregion
					break;
			}
		}
		#endregion

		#region deleted
		//#region Properties
		//private string _company;

		///// <summary>
		///// 公司信息
		///// </summary>
		//public string Company
		//{
		//    get { return _company; }
		//    set { _company = value; }
		//}

		//private string _subject;

		///// <summary>
		///// 标题
		///// </summary>
		//public string Subject
		//{
		//    get { return _subject; }
		//    set { _subject = value; }
		//}

		//#endregion

		//#region Ctors
		///// <summary>
		///// Initializes a new instance of the <see cref="Exporter"/> class.
		///// </summary>
		//public Exporter()
		//{
		//    this._company = string.Empty;
		//    this._subject = string.Empty;
		//}
		//#endregion

		//#region ExportToExcelByPage

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="fileName">导出文件(zip).</param>
		///// <param name="pageSize">每页的大小.</param>
		///// <param name="partFileNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcelByPage(IExportable exportable, string fileName, int pageSize, string partFileNameFormat, ExportCallback callback)
		//{
		//    if (fileName == null) throw new ArgumentNullException("fileName");

		//    using (ZipOutputStream zip = new ZipOutputStream(fileName))
		//    {
		//        ExportToExcelByPage(exportable, zip, pageSize, partFileNameFormat, callback);
		//    }
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="zip">导出目标流.</param>
		///// <param name="pageSize">每页的大小.</param>
		///// <param name="partFileNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcelByPage(IExportable exportable, ZipOutputStream zip, int pageSize, string partFileNameFormat, ExportCallback callback)
		//{
		//    ExportToExcelByPage(exportable, zip, pageSize, true, partFileNameFormat, callback);
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="fileName">导出文件(zip).</param>
		///// <param name="pageSize">每页的大小.</param>
		///// <param name="showHeader">是否将第一行作为表头显示.</param>
		///// <param name="partFileNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcelByPage(IExportable exportable, string fileName, int pageSize, bool showHeader, string partFileNameFormat, ExportCallback callback)
		//{
		//    if (fileName == null) throw new ArgumentNullException("fileName");

		//    using (ZipOutputStream zip = new ZipOutputStream(fileName))
		//    {
		//        ExportToExcelByPage(exportable, zip, pageSize, showHeader, partFileNameFormat, callback);
		//    }
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="zip">导出目标流.</param>
		///// <param name="pageSize">每页的大小.</param>
		///// <param name="showHeader">是否将第一行作为表头显示.</param>
		///// <param name="partFileNameFormat">分页文件命名格式 {0} 代表编号，必须至少包含一个 {0}，否则会出现命名冲突.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcelByPage(IExportable exportable, ZipOutputStream zip, int pageSize, bool showHeader, string partFileNameFormat, ExportCallback callback)
		//{
		//    if (exportable == null) throw new ArgumentNullException("exportable");
		//    if (zip == null) throw new ArgumentNullException("zip");
		//    if (partFileNameFormat == null) throw new ArgumentNullException("partFileNameFormat");
		//    if (pageSize < 1 || pageSize > 65536) throw new ArgumentOutOfRangeException("pageSize", "必须在 1 到 65536 之间");

		//    int index = 0;
		//    PagedExportable pe = new PagedExportable(exportable, 0, pageSize, showHeader);

		//    while (pe.NextPage())
		//    {
		//        string fileName = string.Format(partFileNameFormat, ++index);
		//        ZipEntry entry = zip.PutNextEntry(fileName);
		//        entry.CreationTime = DateTime.Now;

		//        ExportToExcel(pe, zip, callback);
		//    }
		//}

		//#endregion

		//#region ExportToExcel
		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="dataGridView">是导出的 DataGridView.</param>
		///// <param name="name">导出目标 sheet 的名称.</param>
		///// <param name="fileName">输出文件.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcel(DataGridView dataGridView, string name, string fileName, ExportCallback callback)
		//{
		//    IExportable exportable = new DataGridViewExportable(dataGridView, name);
		//    ExportToExcel(exportable, fileName, callback);
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="view">是导出的 DataView.</param>
		///// <param name="name">导出目标 sheet 的名称.</param>
		///// <param name="fileName">输出文件.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcel(DataView view, string name, string fileName, ExportCallback callback)
		//{
		//    IExportable exportable = new DataViewExportable(view, name);
		//    ExportToExcel(exportable, fileName, callback);
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="table">是导出的 DataTable.</param>
		///// <param name="fileName">输出文件.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcel(DataTable table, string fileName, ExportCallback callback)
		//{
		//    IExportable exportable = new DataTableExportable(table);
		//    ExportToExcel(exportable, fileName, callback);
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="fileName">输出文件.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcel(IExportable exportable, string fileName, ExportCallback callback)
		//{
		//    using (FileStream fs = new FileStream(fileName, FileMode.Create))
		//    {
		//        ExportToExcel(exportable, fs, callback);
		//    }
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="output">导出目标流.</param>
		//public void ExportToExcel(IExportable exportable, Stream output)
		//{
		//    if (exportable == null) throw new ArgumentNullException("exportable");
		//    if (output == null) throw new ArgumentNullException("output");

		//    ExportContext context = new ExportContext();

		//    using (HSSFWorkbook hssfWorkbook = CreateHSSFWorkbook())
		//    {
		//        //
		//        context.Workbook = hssfWorkbook;
		//        do
		//        {
		//            ISheet sheet = CreateSheet(hssfWorkbook, exportable);
		//            //
		//            context.Sheet = sheet;
		//            int rowCount = exportable.GetRowCount();

		//            for (int rowIndex = 0, y = 0; rowIndex < rowCount; ++rowIndex)
		//            {
		//                //
		//                context.RowIndex = rowIndex;
		//                int colCount = exportable.GetColumnCount(rowIndex);
		//                IRow row = null;

		//                for (int colIndex = 0, x = 0; colIndex < colCount; ++colIndex)
		//                {
		//                    //
		//                    context.ColumnIndex = colIndex;
		//                    // 重设 CellValueType, CellStyle, IsValid 属性.
		//                    context.Reset();

		//                    exportable.GetValue(rowIndex, colIndex, context);
		//                    if (context.IsValid)
		//                    {
		//                        // 创建单元格
		//                        if (row == null) row = sheet.CreateRow(y++);
		//                        ICell cell = row.CreateCell(x++);

		//                        // 设置单元格
		//                        SetCell(cell, context);
		//                    }
		//                }
		//            }
		//        } while (exportable.NextSheet());

		//        hssfWorkbook.Write(output);
		//    }
		//}

		///// <summary>
		///// 导出到 Excel.
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="output">导出目标流.</param>
		///// <param name="callback">导出回调.</param>
		//public void ExportToExcel(IExportable exportable, Stream output, ExportCallback callback)
		//{
		//    if (exportable == null) throw new ArgumentNullException("exportable");
		//    if (output == null) throw new ArgumentNullException("output");

		//    ExportCallback exportCellCallback = callback;
		//    if (exportCellCallback == null)
		//    {
		//        ExportToExcel(exportable, output);
		//        return;
		//    }

		//    ExportContext context = new ExportContext();

		//    using (HSSFWorkbook hssfWorkbook = CreateHSSFWorkbook())
		//    {
		//        //
		//        context.Workbook = hssfWorkbook;
		//        do
		//        {
		//            context.Exportable = exportable;
		//            ISheet sheet = CreateSheet(hssfWorkbook, exportable);
		//            //
		//            context.Sheet = sheet;
		//            int rowCount = exportable.GetRowCount();

		//            for (int rowIndex = 0, y = 0; rowIndex < rowCount; ++rowIndex)
		//            {
		//                //
		//                context.RowIndex = rowIndex;
		//                int colCount = exportable.GetColumnCount(rowIndex);
		//                IRow row = null;

		//                for (int colIndex = 0, x = 0; colIndex < colCount; ++colIndex)
		//                {
		//                    //
		//                    context.ColumnIndex = colIndex;
		//                    // 重设 CellValueType, CellStyle, IsValid 属性.
		//                    context.Reset();

		//                    exportable.GetValue(rowIndex, colIndex, context);
		//                    if (context.IsValid)
		//                    {
		//                        exportCellCallback(context);
		//                        if (context.IsValid)
		//                        {
		//                            // 创建单元格
		//                            if (row == null) row = sheet.CreateRow(y++);
		//                            ICell cell = row.CreateCell(x++);

		//                            // 设置单元格
		//                            SetCell(cell, context);
		//                        }
		//                    }
		//                }
		//            }
		//        } while (exportable.NextSheet());

		//        hssfWorkbook.Write(output);
		//    }
		//}
		//#endregion

		//#region Export
		//private HSSFWorkbook _workbook;
		//private ISheet _sheet;
		//private int y;

		///// <summary>
		///// 创建新的 excel 文档.
		///// 调用流程: NewExcel() -&gt; NewSheet () -&gt; AppendExportable () -&gt; WriteTo () -&gt; CloseExcel().
		///// </summary>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter NewExcel()
		//{
		//    _workbook = CreateHSSFWorkbook();
		//    return this;
		//}

		///// <summary>
		///// 创建新的 sheet.
		///// 调用流程: NewExcel() -&gt; NewSheet () -&gt; AppendExportable () -&gt; WriteTo () -&gt; CloseExcel().
		///// </summary>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter NewSheet(string name)
		//{
		//    this._sheet = _workbook.CreateSheet(name);
		//    this.y = 0;
		//    return this;
		//}

		///// <summary>
		///// 将数据追加到 sheet（如果有多个 Exportable 需要导出到当前 sheet，可以多次调用）.
		///// 调用流程: NewExcel() -&gt; NewSheet () -&gt; AppendExportable () -&gt; WriteTo () -&gt; CloseExcel().
		///// </summary>
		///// <param name="exportable">可导出对象.</param>
		///// <param name="callback">导出回调.</param>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter AppendExportable(IExportable exportable, ExportCallback callback)
		//{
		//    if (exportable == null) throw new ArgumentNullException("exportable");

		//    ExportCallback exportCellCallback = callback;
		//    if (exportCellCallback == null)
		//    {
		//        //ExportToExcel(exportable, output);
		//        //return ;
		//    }

		//    ExportContext context = new ExportContext();
		//    ISheet sheet = this._sheet;
		//    int rowCount = exportable.GetRowCount();

		//    //
		//    context.Workbook = this._workbook;
		//    context.Exportable = exportable;
		//    context.Sheet = sheet;

		//    for (int rowIndex = 0/*, y = 0*/; rowIndex < rowCount; ++rowIndex)
		//    {
		//        //
		//        context.RowIndex = rowIndex;
		//        int colCount = exportable.GetColumnCount(rowIndex);
		//        IRow row = null;

		//        for (int colIndex = 0, x = 0; colIndex < colCount; ++colIndex)
		//        {
		//            //
		//            context.ColumnIndex = colIndex;
		//            // 重设 CellValueType, CellStyle, IsValid 属性.
		//            context.Reset();

		//            exportable.GetValue(rowIndex, colIndex, context);
		//            if (context.IsValid)
		//            {
		//                exportCellCallback(context);
		//                if (context.IsValid)
		//                {
		//                    // 创建单元格
		//                    if (row == null) row = sheet.CreateRow(y++);
		//                    ICell cell = row.CreateCell(x++);

		//                    // 设置单元格
		//                    SetCell(cell, context);
		//                }
		//            }
		//        }
		//    }

		//    return this;
		//}

		///// <summary>
		///// 将 excel 保存到目标流.
		///// 调用流程: NewExcel() -&gt; NewSheet () -&gt; AppendExportable () -&gt; WriteTo () -&gt; CloseExcel().
		///// </summary>
		///// <param name="output">目标流.</param>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter WriteTo(Stream output)
		//{
		//    this._workbook.Write(output);
		//    return this;
		//}

		///// <summary>
		///// 关闭创建的 excel 文档.
		///// 调用流程: NewExcel() -&gt; NewSheet () -&gt; AppendExportable () -&gt; WriteTo () -&gt; CloseExcel().
		///// </summary>
		///// <returns>this, 以支持链式操作.</returns>
		//public Exporter CloseExcel()
		//{
		//    this._sheet = null;
		//    HSSFWorkbook workbook = this._workbook;

		//    if (workbook != null)
		//    {
		//        workbook.Dispose();
		//        this._workbook = null;
		//    }

		//    return this;
		//}

		//#endregion

		//#region Private Methods
		///// <summary>
		///// 设置单元格
		///// </summary>
		///// <param name="cell"></param>
		///// <param name="context"></param>
		//private static void SetCell(ICell cell, ExportContext context)
		//{
		//    if (context.CellStyle != null)
		//    {
		//        cell.CellStyle = context.CellStyle;
		//    }

		//    object value = context.CellValue;
		//    CellValueType type = context.CellValueType;
		//    switch (type)
		//    {
		//        case CellValueType.StringDenotable:
		//            cell.SetCellValue(value == null ? string.Empty : value.ToString());
		//            break;

		//        case CellValueType.String:
		//            cell.SetCellValue((string)value);
		//            break;

		//        case CellValueType.DateTime:
		//            cell.SetCellValue((DateTime)value);
		//            break;

		//        case CellValueType.Boolean:
		//            cell.SetCellValue((bool)value);
		//            break;

		//        case CellValueType.Double:
		//            cell.SetCellValue((double)value);
		//            break;

		//        case CellValueType.RichText:
		//            cell.SetCellValue((IRichTextString)value);
		//            break;

		//        case CellValueType.Other:
		//            #region
		//            if (value == null) cell.SetCellValue(string.Empty);
		//            Type t = value.GetType();

		//            if (t == typeof(string))
		//            {
		//                cell.SetCellValue((string)value);
		//            }
		//            else if (t == typeof(DateTime))
		//            {
		//                cell.SetCellValue((DateTime)value);
		//            }
		//            else if (t == typeof(bool))
		//            {
		//                cell.SetCellValue((bool)value);
		//            }
		//            else if (t == typeof(IRichTextString))
		//            {
		//                cell.SetCellValue((IRichTextString)t);
		//            }
		//            else if (t == typeof(byte) || t == typeof(short) || t == typeof(int) || t == typeof(long) || t == typeof(float) || t == typeof(double))
		//            {
		//                cell.SetCellValue(Convert.ToDouble(value));
		//            }
		//            else
		//            {
		//                cell.SetCellValue(value.ToString());
		//            }
		//            #endregion
		//            break;
		//    }

		//    #region deleted
		//    //if (context.CellStyle != null)
		//    //{
		//    //    cell.CellStyle = context.CellStyle;
		//    //}

		//    //object value = context.CellValue;
		//    //CellValueType type = context.CellValueType;
		//    //switch (type)
		//    //{
		//    //    case CellValueType.StringDenotable:
		//    //        cell.SetCellValue(value == null ? string.Empty : value.ToString());
		//    //        break;

		//    //    case CellValueType.String:
		//    //        cell.SetCellValue((string)value);
		//    //        break;

		//    //    case CellValueType.DateTime:
		//    //        cell.SetCellValue((DateTime)value);
		//    //        break;

		//    //    case CellValueType.Boolean:
		//    //        cell.SetCellValue((bool)value);
		//    //        break;

		//    //    case CellValueType.Double:
		//    //        cell.SetCellValue((double)value);
		//    //        break;

		//    //    case CellValueType.RichText:
		//    //        cell.SetCellValue((IRichTextString)value);
		//    //        break;

		//    //    case CellValueType.Other:
		//    //        #region
		//    //        string s = value as string;
		//    //        if (s == null)
		//    //        {
		//    //            IRichTextString r = value as IRichTextString;
		//    //            if (r == null)
		//    //            {
		//    //                if (value is DateTime)
		//    //                {
		//    //                    cell.SetCellValue((DateTime)value);
		//    //                }
		//    //                else if (value is bool)
		//    //                {
		//    //                    cell.SetCellValue((bool)value);
		//    //                }
		//    //                else if (value is double)
		//    //                {
		//    //                    cell.SetCellValue((double)value);
		//    //                }
		//    //                else
		//    //                {
		//    //                    cell.SetCellValue(value == null ? string.Empty : value.ToString());
		//    //                }
		//    //            }
		//    //            else
		//    //            {
		//    //                cell.SetCellValue(r);
		//    //            }
		//    //        }
		//    //        else
		//    //        {
		//    //            cell.SetCellValue(s);
		//    //        }
		//    //        #endregion
		//    //        break;
		//    //}
		//    #endregion
		//}

		///// <summary>
		///// Creates the sheet.
		///// </summary>
		///// <param name="hssfWorkbook">The HSSF workbook.</param>
		///// <param name="exportable">The exportable.</param>
		///// <returns></returns>
		//private static ISheet CreateSheet(HSSFWorkbook hssfWorkbook, IExportable exportable)
		//{
		//    ISheet sheet = hssfWorkbook.CreateSheet(exportable.Name);
		//    return sheet;
		//}

		///// <summary>
		///// 创建工作表
		///// </summary>
		///// <returns></returns>
		//private HSSFWorkbook CreateHSSFWorkbook()
		//{
		//    HSSFWorkbook hssfWorkbook = new HSSFWorkbook();

		//    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
		//    dsi.Company = this.Company;
		//    hssfWorkbook.DocumentSummaryInformation = dsi;

		//    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
		//    si.Subject = this.Subject;
		//    hssfWorkbook.SummaryInformation = si;

		//    return hssfWorkbook;
		//}
		//#endregion
		#endregion
	}
}
