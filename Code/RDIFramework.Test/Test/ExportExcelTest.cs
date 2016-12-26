using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.Test
{
    /// <summary>
    /// RDIFramework.NET公共类型中的导出到Excel类的测试
    /// </summary>
	public partial class ExportExcelTest : Form
	{
		private DataTable _table;
		private DataSet _dataSet;
		private Exporter _exporter;

		public ExportExcelTest()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_exporter = new Exporter()
			{
				Company = "CSST",
				Subject = "books"
			};

			LoadData();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			if (_table != null) return;
			_table = CreateTable(1000);
			DataTable table2 = new DataTable("Category");
			table2.Columns.Add("id");
			table2.Columns.Add("name");
			table2.Columns.Add("description");

			for (int i = 0; i < 11; ++i)
			{
				table2.Rows.Add(i, "类型" + i.ToString(), "描述" + i.ToString());
			}

			_dataSet = new DataSet();
			_dataSet.Tables.Add(_table);
			_dataSet.Tables.Add(table2);

			this.dataGridView1.DataSource = this._table;
		}
		private DataTable CreateTable(int count)
		{
			DataTable table = new DataTable("books");

			table.Columns.Add("id", typeof(int));
			table.Columns.Add("title", typeof(string));
			table.Columns.Add("author", typeof(string));
			table.Columns.Add("publishDate", typeof(DateTime));
			table.Columns.Add("quantity", typeof(int));
			table.Columns.Add("unitPrice", typeof(decimal));
			table.Columns.Add("isbn", typeof(string));

			for (int i = 0; i < count; ++i)
			{
				table.Rows.Add(i, "图书" + i.ToString(), "作者" + i.ToString(), DateTime.Now, 99, 158, "XXXXXXXXX");
			}

			return table;
		}

		private string GetFileName()
		{
			using (SaveFileDialog sfg = new SaveFileDialog())
			{
				if (DialogResult.OK == sfg.ShowDialog(this))
				{
					return sfg.FileName;
				}
			}

			return null;
		}

		// 导出 DataSet
		private void button2_Click(object sender, EventArgs e)
		{
			string fileName = GetFileName();
			if (fileName != null)
			{
				try
				{
					this._exporter.NewExcel();
					foreach (DataTable table in _dataSet.Tables)
					{
						DataTableExportable det = new DataTableExportable(table);
						this._exporter.NewSheet(table.TableName)
							.UnionHeader(det, null)
							.Union(det, null);
					}

					this._exporter.WriteTo(fileName);
				}
				finally
				{
					this._exporter.CloseExcel();
				}
			}
		}

		// 导出 DataTable
		private void button3_Click(object sender, EventArgs e)
		{
			string fileName = GetFileName();
			if (fileName != null)
			{
				this._exporter.ExportToExcel(_table, "books", fileName, null);
			}
		}

		// 导出 DataView
		private void button4_Click(object sender, EventArgs e)
		{
			string fileName = GetFileName();
			if (fileName != null)
			{
				DataView dv = new DataView(_table);
				dv.RowFilter = "id % 2 <> 0";
				this._exporter.ExportToExcel(dv, "books", fileName, null);
			}
		}

		// 过滤
		private void button5_Click(object sender, EventArgs e)
		{
			string fileName = GetFileName();
			if (fileName != null)
			{
				this._exporter.ExportToExcel(_table, "books", fileName, (ExportContext ctx) =>
				{
					if (ctx.CellType == CellType.HeaderCell)
					{
						ctx.ColumnTag = ctx.StringValue;
					}

					if (ctx.ColumnTag as string == "publishDate") ctx.IsValid = false;
				});
			}
		}

		// 改变表头
		private void button6_Click(object sender, EventArgs e)
		{
			string fileName = GetFileName();
			if (fileName != null)
			{
				this._exporter.ExportToExcel(_table, "books", fileName, (ExportContext ctx) =>
				{
					if (ctx.CellType == CellType.HeaderCell)
					{
						switch (ctx.StringValue)
						{
							case "id":
								ctx.CellValue = "编号";
								break;
							case "title":
								ctx.CellValue = "他说没错";
								break;
							case "publishDate":
								ctx.CellValue = "出版日期";
								break;
							default:
								break;
						}
					}
				});
			}
		}

		// 分页
		private void button7_Click(object sender, EventArgs e)
		{
			string fileName = GetFileName();
			if (fileName != null)
			{
				this._exporter.ExportToExcelByPage(new DataGridViewExportable(this.dataGridView1),
					"books", 100, fileName, "分卷{0}.xls", null);
			}
		}

		// 导出 DataGridView
		private void button8_Click(object sender, EventArgs e)
		{

			string fileName = GetFileName();
			if (fileName != null)
			{
				this._exporter.ExportToExcel(new DataGridViewExportable(this.dataGridView1),
					"books", fileName, (ExportContext ctx) =>
					{
						if (ctx.CellType == CellType.DataCell && ctx.RowIndex % 2 == 0) ctx.IsValid = false;
					});
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this._exporter.NewExcel()
				.NewSheet("generited")
				.Union(1, 10, (ExportContext ctx) =>
				{
					ctx.CellValue = "一二三四五六七八九十"[ctx.ColumnIndex];
				}).Union(10, 10, (ExportContext ctx)=>{
					if (ctx.ColumnIndex > ctx.RowIndex)
					{
						ctx.IsValid = false;
						return;
					}
					ctx.CellValue = string.Format("{0,3} *{1,3} ={2,3}", ctx.RowIndex, ctx.ColumnIndex, ctx.RowIndex * ctx.ColumnIndex);
				}).WriteTo("d:\\rand.xls").CloseExcel();
		}
	}
}
