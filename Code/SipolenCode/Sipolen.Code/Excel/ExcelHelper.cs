/*******************************************************************************
 * Copyright © 2016 Sipolen.Framework 版权所有
 * Author: Sipolen
 * Description: Sipolen快速开发平台
 * Website：http://www.Sipolen.cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Sipolen.Code
{
    public class ExcelHelper
    {
        /// <summary>      
        /// DataTable导出到Excel文件      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>   
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (strSheetName == "")
            {
                strSheetName = "Sheet";
            }
            using (MemoryStream ms = Export(dtSource, strHeaderText, strSheetName, oldColumnNames, newColumnNames))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>      
        /// DataTable导出到Excel文件（无表头）另外的是有表头的
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>   
        /// <Author></Author>      
        public static void MyExport(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (strSheetName == "")
            {
                strSheetName = "Sheet";
            }
            MemoryStream getms = new MemoryStream();

            #region 为getms赋值
            if (oldColumnNames.Length != newColumnNames.Length)
            {
                getms = new MemoryStream();
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            //HSSFSheet sheet = workbook.CreateSheet();// workbook.CreateSheet();   
            ISheet sheet = workbook.CreateSheet(strSheetName);

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.Session["realname"] != null)
                {
                    si.Author = HttpContext.Current.Session["realname"].ToString();
                }
                else
                {
                    if (HttpContext.Current.Session["username"] != null)
                    {
                        si.Author = HttpContext.Current.Session["username"].ToString();
                    }
                }                                       //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "OA系统";           //填加xls文件最后保存者信息      
                si.Comments = "OA系统自动创建文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            #region 取得列宽
            int[] arrColWidth = new int[oldColumnNames.Length];
            for (int i = 0; i < oldColumnNames.Length; i++)
            {
                arrColWidth[i] = Encoding.GetEncoding(936).GetBytes(newColumnNames[i]).Length;
            }
            /* 
            foreach (DataColumn item in dtSource.Columns) 
            { 
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length; 
            } 
             * */

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < oldColumnNames.Length; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][oldColumnNames[j]].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
                /* 
                for (int j = 0; j < dtSource.Columns.Count; j++) 
                { 
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length; 
                    if (intTemp > arrColWidth[j]) 
                    { 
                        arrColWidth[j] = intTemp; 
                    } 
                } 
                 * */
            }
            #endregion
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet(strSheetName + ((int)rowIndex / 65535).ToString());
                    }


                    #region 列头及样式
                    {
                        //HSSFRow headerRow = sheet.CreateRow(1);   
                        IRow headerRow = sheet.CreateRow(0);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        for (int i = 0; i < oldColumnNames.Length; i++)
                        {
                            headerRow.CreateCell(i).SetCellValue(newColumnNames[i]);
                            headerRow.GetCell(i).CellStyle = headStyle;
                            //设置列宽   
                            sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 256);
                        }
                        /* 
                        foreach (DataColumn column in dtSource.Columns) 
                        { 
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName); 
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle; 
 
                            //设置列宽    
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256); 
                        } 
                         * */
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                //foreach (DataColumn column in dtSource.Columns)   
                for (int i = 0; i < oldColumnNames.Length; i++)
                {
                    ICell newCell = dataRow.CreateCell(i);

                    string drValue = row[oldColumnNames[i]].ToString();

                    switch (dtSource.Columns[oldColumnNames[i]].DataType.ToString())
                    {
                        case "System.String"://字符串类型      
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型      
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示      
                            break;
                        case "System.Boolean"://布尔型      
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型      
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
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

                }
                #endregion

                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();   
                sheet = null;
                workbook = null;
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet      
                getms = ms;
            }

            #endregion

            using (MemoryStream ms = getms)
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>      
        /// DataTable导出到Excel的MemoryStream      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strSheetName">工作表名称</param>   
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static MemoryStream Export(DataTable dtSource, string strHeaderText, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (oldColumnNames.Length != newColumnNames.Length)
            {
                return new MemoryStream();
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            //HSSFSheet sheet = workbook.CreateSheet();// workbook.CreateSheet();   
            ISheet sheet = workbook.CreateSheet(strSheetName);

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.Session["realname"] != null)
                {
                    si.Author = HttpContext.Current.Session["realname"].ToString();
                }
                else
                {
                    if (HttpContext.Current.Session["username"] != null)
                    {
                        si.Author = HttpContext.Current.Session["username"].ToString();
                    }
                }                                       //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "OA系统";           //填加xls文件最后保存者信息      
                si.Comments = "OA系统自动创建文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            #region 取得列宽
            int[] arrColWidth = new int[oldColumnNames.Length];
            for (int i = 0; i < oldColumnNames.Length; i++)
            {
                arrColWidth[i] = Encoding.GetEncoding(936).GetBytes(newColumnNames[i]).Length;
            }
            /* 
            foreach (DataColumn item in dtSource.Columns) 
            { 
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length; 
            } 
             * */

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < oldColumnNames.Length; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][oldColumnNames[j]].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
                /* 
                for (int j = 0; j < dtSource.Columns.Count; j++) 
                { 
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length; 
                    if (intTemp > arrColWidth[j]) 
                    { 
                        arrColWidth[j] = intTemp; 
                    } 
                } 
                 * */
            }
            #endregion
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet(strSheetName + ((int)rowIndex / 65535).ToString());
                    }

                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;
                        //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));   
                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion


                    #region 列头及样式
                    {
                        //HSSFRow headerRow = sheet.CreateRow(1);   
                        IRow headerRow = sheet.CreateRow(1);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        for (int i = 0; i < oldColumnNames.Length; i++)
                        {
                            headerRow.CreateCell(i).SetCellValue(newColumnNames[i]);
                            headerRow.GetCell(i).CellStyle = headStyle;
                            //设置列宽   
                            sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 256);
                        }
                        /* 
                        foreach (DataColumn column in dtSource.Columns) 
                        { 
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName); 
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle; 
 
                            //设置列宽    
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256); 
                        } 
                         * */
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                //foreach (DataColumn column in dtSource.Columns)   
                for (int i = 0; i < oldColumnNames.Length; i++)
                {
                    ICell newCell = dataRow.CreateCell(i);

                    string drValue = row[oldColumnNames[i]].ToString();

                    switch (dtSource.Columns[oldColumnNames[i]].DataType.ToString())
                    {
                        case "System.String"://字符串类型      
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型      
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示      
                            break;
                        case "System.Boolean"://布尔型      
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型      
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
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

                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();   
                sheet = null;
                workbook = null;
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet      
                return ms;
            }
        }


        /// <summary>      
        /// WEB导出DataTable到Excel      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">文件名</param>      
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            ExportByWeb(dtSource, strHeaderText, strFileName, "sheet");
        }

        /// <summary>   
        /// WEB导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">输出文件名，包含扩展名</param>   
        /// <param name="oldColumnNames">要导出的DataTable列数组</param>   
        /// <param name="newColumnNames">导出后的对应列名</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string[] oldColumnNames, string[] newColumnNames)
        {
            ExportByWeb(dtSource, strHeaderText, strFileName, "sheet", oldColumnNames, newColumnNames);
        }

        /// <summary>   
        /// WEB导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">输出文件名</param>   
        /// <param name="strSheetName">工作表名称</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式      
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            //生成列   
            string columns = "";
            for (int i = 0; i < dtSource.Columns.Count; i++)
            {
                if (i > 0)
                {
                    columns += ",";
                }
                columns += dtSource.Columns[i].ColumnName;
            }

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strSheetName, columns.Split(','), columns.Split(',')).GetBuffer());
            curContext.Response.End();

        }

        /// <summary>   
        /// 导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">要导出的DataTable</param>   
        /// <param name="strHeaderText">标题文字</param>   
        /// <param name="strFileName">文件名，包含扩展名</param>   
        /// <param name="strSheetName">工作表名</param>   
        /// <param name="oldColumnNames">要导出的DataTable列数组</param>   
        /// <param name="newColumnNames">导出后的对应列名</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式      
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strSheetName, oldColumnNames, newColumnNames).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>读取excel      
        /// 默认第一行为表头，导入第一个工作表   
        /// </summary>      
        /// <param name="strFileName">excel文档路径</param>      
        /// <param name="rowStartIndex">真实数据开始行数，默认0 为第一行</param>      
        /// <returns></returns>      
        public static DataTable Import(string strFileName, int rowStartIndex = 0)
        {
            DataTable dt = new DataTable();
            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(rowStartIndex);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + rowStartIndex + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(string strFileName, string SheetName, int HeaderRowIndex)
        {
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(SheetName);
                return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
            }
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetIndex">要获取数据的工作表序号(从0开始)</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(string strFileName, int SheetIndex, int HeaderRowIndex)
        {
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(file);
                string SheetName = workbook.GetSheetName(SheetIndex);
                return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
            }
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="ExcelFileStream">Excel文件流</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ExcelFileStream.Close();
            return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="ExcelFileStream">Excel文件流</param>   
        /// <param name="SheetIndex">要获取数据的工作表序号(从0开始)</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ExcelFileStream.Close();
            string SheetName = workbook.GetSheetName(SheetIndex);
            return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="workbook">要处理的工作薄</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(IWorkbook workbook, string SheetName, int HeaderRowIndex)
        {
            ISheet sheet = workbook.GetSheet(SheetName);
            DataTable table = new DataTable();
            try
            {
                IRow headerRow = sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                #region 循环各行各列,写入数据到DataTable
                for (int i = (HeaderRowIndex + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell == null)
                        {
                            dataRow[j] = null;
                        }
                        else
                        {
                            //dataRow[j] = cell.ToString();   
                            switch (cell.CellType)
                            {
                                case CellType.Blank:
                                    dataRow[j] = null;
                                    break;
                                case CellType.Boolean:
                                    dataRow[j] = cell.BooleanCellValue;
                                    break;
                                case CellType.Numeric:
                                    dataRow[j] = cell.ToString();
                                    break;
                                case CellType.String:
                                    dataRow[j] = cell.StringCellValue;
                                    break;
                                case CellType.Error:
                                    dataRow[j] = cell.ErrorCellValue;
                                    break;
                                case CellType.Formula:
                                default:
                                    dataRow[j] = "=" + cell.CellFormula;
                                    break;
                            }
                        }
                    }
                    table.Rows.Add(dataRow);
                    //dataRow[j] = row.GetCell(j).ToString();   
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                table.Clear();
                table.Columns.Clear();
                table.Columns.Add("出错了");
                DataRow dr = table.NewRow();
                dr[0] = ex.Message;
                table.Rows.Add(dr);
                return table;
            }
            finally
            {
                //sheet.Dispose();   
                workbook = null;
                sheet = null;
            }
            #region 清除最后的空行
            for (int i = table.Rows.Count - 1; i > 0; i--)
            {
                bool isnull = true;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Rows[i][j] != null)
                    {
                        if (table.Rows[i][j].ToString() != "")
                        {
                            isnull = false;
                            break;
                        }
                    }
                }
                if (isnull)
                {
                    table.Rows[i].Delete();
                }
            }
            #endregion
            return table;
        }
    }
}
