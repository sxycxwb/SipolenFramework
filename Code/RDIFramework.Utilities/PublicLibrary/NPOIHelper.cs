using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// Excel导入\导出辅助类
    /// </summary>
    public class NPOIHelper
    {
        #region public
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="headerTextDic">头文本</param>
        /// <param name="fileName">文件名</param>
        public static void ExportByWinform(DataTable dtSource, Dictionary<string, string> headerTextDic, string fileName)
        {
            using (var ms = Export(dtSource, headerTextDic, fileName, false))
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    var data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="headerTextDic">头文本</param>
        /// <param name="fileName">文件名</param>
        public static void ExportByWeb(DataTable dtSource, Dictionary<string, string> headerTextDic, string fileName)
        {
            var curContext = HttpContext.Current;

            // 设置编码和附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition","attachment;filename=" + HttpUtility.UrlEncode(fileName + ".xls", Encoding.UTF8));

            curContext.Response.BinaryWrite(Export(dtSource, headerTextDic, fileName, false).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>读取excel
        /// 默认第一行为标头
        /// </summary>
        /// <param name="fileName">excel文档路径</param>
        /// <returns></returns>
        public static DataTable Import(string fileName)
        {
            var dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            var sheet = hssfworkbook.GetSheetAt(0) as HSSFSheet;
            var rows = sheet.GetRowEnumerator();

            var headerRow = sheet.GetRow(0) as HSSFRow;
            var cellCount = headerRow.LastCellNum;

            for (var j = 0; j < cellCount; j++)
            {
                var cell = headerRow.GetCell(j) as HSSFCell;
                dt.Columns.Add(cell.ToString());
            }

            for (var i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i) as HSSFRow;
                var dataRow = dt.NewRow();

                for (var j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        #endregion

        #region private

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="headerTextDic">头文本</param>
        /// <param name="fileName">文件名</param>
        /// <param name="isShowTitle">是否显示表头</param>
        /// <returns></returns>
        private static MemoryStream Export(DataTable dtSource, Dictionary<string, string> headerTextDic, string fileName, bool isShowTitle)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet() as HSSFSheet;

            SetSummaryInformation(workbook);

            var dateStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            var format = workbook.CreateDataFormat() as HSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            var arrColWidth = GetColWidth(dtSource, headerTextDic);

            var rowIndex = 0;


            var colHeaderStyle = GetColHeaderStyle(workbook);
            var contentDataStyle = GetContentDataStyle(workbook);

            foreach (DataRow row in dtSource.Rows)
            {
                if (rowIndex == 65536 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet() as HSSFSheet;
                    }
                    SetDataTitle(headerTextDic, fileName, isShowTitle, workbook, sheet);
                    SetColHeader(dtSource, headerTextDic, isShowTitle, workbook, sheet, arrColWidth, colHeaderStyle);
                    if (isShowTitle)
                    {
                        rowIndex = 2;
                    }
                    else
                    {
                        rowIndex = 1;
                    }
                }

                var dataRow = sheet.CreateRow(rowIndex) as HSSFRow;
                SetContentData(dtSource, headerTextDic, dateStyle, row, dataRow, workbook, contentDataStyle);

                rowIndex++;
            }
            using (var ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet.Dispose();
                workbook.Dispose();
                return ms;
            }
        }

        /// <summary>
        /// 右击文件/属性信息
        /// </summary>
        /// <param name="workbook"></param>
        private static void SetSummaryInformation(HSSFWorkbook workbook)
        {
            var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI";
            workbook.DocumentSummaryInformation = dsi;

            var si = PropertySetFactory.CreateSummaryInformation();
            si.Author = "文件作者信息"; //填加xls文件作者信息
            si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
            si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
            si.Comments = "RDIFramework.NET，基于.NET的快速信息化系统开发、整合框架，给用户和开发者最佳的.Net框架部署方案。http://www.cnblogs.com/huyong"; //填加xls文件作者信息
            si.Title = "标题信息"; //填加xls文件标题信息
            si.Subject = "主题信息";//填加文件主题信息
            si.CreateDateTime = DateTime.Now;
            workbook.SummaryInformation = si;
        }

        /// <summary>
        /// 取得列宽
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="headerTextDic"></param>
        /// <returns></returns>
        private static int[] GetColWidth(DataTable dtSource, Dictionary<string, string> headerTextDic)
        {
            var arrColWidth = new int[headerTextDic.Count];
            var index = 0;
            foreach (var item in headerTextDic)
            {
                arrColWidth[index] = Encoding.GetEncoding(936).GetBytes(item.Value).Length;
                index++;
            }


            index = 0;
            foreach (var item in headerTextDic)
            {
                for (var i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (var j = 0; j < dtSource.Columns.Count; j++)
                    {
                        if (item.Key.ToLower() == dtSource.Columns[j].ColumnName.ToLower())
                        {
                            var intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                            if (intTemp > arrColWidth[index])
                            {
                                arrColWidth[index] = intTemp;
                            }
                            break;
                        }
                    }
                }
                index++;
            }

            return arrColWidth;
        }

        /// <summary>
        /// 表头及样式
        /// </summary>
        /// <param name="headerTextDic"></param>
        /// <param name="fileName"></param>
        /// <param name="isShowTitle"></param>
        /// <param name="workbook"></param>
        /// <param name="sheet"></param>
        private static void SetDataTitle(Dictionary<string, string> headerTextDic, string fileName, bool isShowTitle, HSSFWorkbook workbook, HSSFSheet sheet)
        {
            if (isShowTitle)
            {
                var headerRow = sheet.CreateRow(0) as HSSFRow;
                headerRow.HeightInPoints = 25;
                headerRow.CreateCell(0).SetCellValue(fileName);

                var headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
                headStyle.Alignment = HorizontalAlignment.CENTER;
                var font = workbook.CreateFont() as HSSFFont;
                font.FontHeightInPoints = 20;
                font.Boldweight = 700;
                headStyle.SetFont(font);
                headerRow.GetCell(0).CellStyle = headStyle;
                sheet.AddMergedRegion(new Region(0, 0, 0, headerTextDic.Count - 1));
            }
        }

        /// <summary>
        /// 列头數據
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="headerTextDic"></param>
        /// <param name="isShowTitle"></param>
        /// <param name="workbook"></param>
        /// <param name="sheet"></param>
        /// <param name="arrColWidth"></param>
        private static void SetColHeader(DataTable dtSource, Dictionary<string, string> headerTextDic, bool isShowTitle, HSSFWorkbook workbook, HSSFSheet sheet, int[] arrColWidth, HSSFCellStyle colHeaderStyle)
        {
            HSSFRow headerRow = null;
            if (isShowTitle)
            {
                headerRow = sheet.CreateRow(1) as HSSFRow;
            }
            else
            {
                headerRow = sheet.CreateRow(0) as HSSFRow;
            }

            var index = 0;

            foreach (var item in headerTextDic)
            {
                foreach (DataColumn column in dtSource.Columns)
                {
                    if (column.ColumnName.ToLower() == item.Key.ToLower())
                    {
                        headerRow.CreateCell(index).SetCellValue(item.Value);
                        headerRow.GetCell(index).CellStyle = colHeaderStyle;

                        var colWidth = arrColWidth[index];
                        if (colWidth > 254)
                        {
                            colWidth = 254;
                        }

                        sheet.SetColumnWidth(index, (colWidth + 1) * 256);
                        index++;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 填充内容
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="headerTextDic"></param>
        /// <param name="dateStyle"></param>
        /// <param name="row"></param>
        /// <param name="dataRow"></param>
        private static void SetContentData(DataTable dtSource, Dictionary<string, string> headerTextDic, HSSFCellStyle dateStyle, DataRow row, HSSFRow dataRow, HSSFWorkbook workbook, HSSFCellStyle contentDataStyle)
        {
            var index = 0;
            foreach (var item in headerTextDic)
            {
                foreach (DataColumn column in dtSource.Columns)
                {
                    if (item.Key.ToLower() == column.ColumnName.ToLower())
                    {
                        var newCell = dataRow.CreateCell(index) as HSSFCell;
                        var drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                if (drValue.Contains("上午 12:00:00"))
                                {
                                    drValue = dateV.ToString("yyyy/MM/dd");
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(drValue))
                                    {
                                        drValue = dateV.ToString();
                                    }
                                }
                                newCell.SetCellValue(drValue);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                var boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                var intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                        dataRow.GetCell(index).CellStyle = contentDataStyle;

                        index++;
                        break;
                    }
                }
            }
        }

        #region 樣式

        /// <summary>
        /// 列头樣式
        /// </summary>
        /// <param name="workbook"></param>
        /// <returns></returns>
        private static HSSFCellStyle GetColHeaderStyle(HSSFWorkbook workbook)
        {
            var headStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            headStyle.Alignment = HorizontalAlignment.CENTER;
            var font = workbook.CreateFont() as HSSFFont;
            font.FontHeightInPoints = 10;
            font.Boldweight = 700;
            headStyle.SetFont(font);


            var palette = workbook.GetCustomPalette();
            palette.SetColorAtIndex((short)10, (byte)0, (byte)176, (byte)240);
            headStyle.FillForegroundColor = (short)10;
            headStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;

            headStyle.BorderBottom = CellBorderType.THIN;
            headStyle.BorderLeft = CellBorderType.THIN;
            headStyle.BorderTop = CellBorderType.THIN;
            headStyle.BorderRight = CellBorderType.THIN;
            return headStyle;

        }

        /// <summary>
        /// 填充内容樣式
        /// </summary>
        /// <param name="workbook"></param>
        /// <returns></returns>
        private static HSSFCellStyle GetContentDataStyle(HSSFWorkbook workbook)
        {
            var headStyle = workbook.CreateCellStyle() as HSSFCellStyle;

            headStyle.BorderBottom = CellBorderType.THIN;
            headStyle.BorderLeft = CellBorderType.THIN;
            headStyle.BorderTop = CellBorderType.THIN;
            headStyle.BorderRight = CellBorderType.THIN;
            return headStyle;
        }

        #endregion

        #endregion
    }

    /*
    调用方法
    DataTable dt = GetData();
    Dictionary<string, string> dtHeaderText = new Dictionary<string, string>();
    dtHeaderText.Add("cOde", "代码");
    dtHeaderText.Add("Name", "姓名");
    dtHeaderText.Add("Age", "年龄");
    dtHeaderText.Add("Sex", "性別");
    dtHeaderText.Add("Param5", "參數5");
    dtHeaderText.Add("Param1", "參數1");
    dtHeaderText.Add("Param3", "參數3");
            
    string filename = "RDIFramework导出文件";
    NPOIHelper.ExportByWeb(dt, dtHeaderText, filename);
    */
}
