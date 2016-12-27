//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System.Data;
using System.IO;
using System.Text;
using System.Web;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// ExportCSV
    /// 导出CSV格式数据
    /// 
    /// 修改纪录
    /// 
    ///     2009.07.08 版本：3.0 XuWangBin	更新完善程序，将方法修改为静态方法。
    ///     2007.08.11 版本：2.0 XuWangBin	更新完善程序。
    ///     2006.12.01 版本：1.0 XuWangBin	新创建。
    /// 
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2009.07.08</date>
    /// </author> 
    /// </summary>
    public class ExportCSVHelper
    {
        #region public static StringBuilder GetCSVFormatData(DataTable dataTable) 通过DataTable获得CSV格式数据
        /// <summary>
        /// 通过DataTable获得CSV格式数据
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>CSV字符串数据</returns>
        public static StringBuilder GetCSVFormatData(DataTable dataTable)
        {
            var stringBuilder = new StringBuilder();
            // 写出表头
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                stringBuilder.Append(dataColumn.ColumnName.ToString() + ",");
            }
            stringBuilder.Append("\n");
            // 写出数据
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    stringBuilder.Append(dataRowView[dataColumn.ColumnName].ToString() + ",");
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder;
        }
        #endregion

        #region public static StringBuilder GetCSVFormatData(DataSet dataSet) 通过DataSet获得CSV格式数据
        /// <summary>
        /// 通过DataSet获得CSV格式数据
        /// </summary>
        /// <param name="dataSet">数据权限</param>
        /// <returns>CSV字符串数据</returns>
        public static StringBuilder GetCSVFormatData(DataSet dataSet)
        {
            var stringBuilder = new StringBuilder();
            foreach (DataTable dataTable in dataSet.Tables)
            {
                stringBuilder.Append(GetCSVFormatData(dataTable));
            }
            return stringBuilder;
        }
        #endregion

        #region public static void ExportCSV(DataTable dataTable, string fileName) 导出CSV格式文件
        /// <summary>
        /// 导出CSV格式文件
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fileName">文件名</param>
        public static void ExportCSV(DataTable dataTable, string fileName)
        {
            StreamWriter streamWriter = null;
            streamWriter = SystemInfo.CurrentLanguage.Equals("zh-CN") ? new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("gb2312")) : new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("utf-8"));
            streamWriter.WriteLine(GetCSVFormatData(dataTable).ToString());
            streamWriter.Flush();
            streamWriter.Close();
        }
        #endregion

        #region public static void ExportCSV(DataSet dataSet, string fileName) 导出CSV格式文件
        /// <summary>
        /// 导出CSV格式文件
        /// </summary>
        /// <param name="dataSet">数据权限</param>
        /// <param name="fileName">文件名</param>
        public static void ExportCSV(DataSet dataSet, string fileName)
        {
            StreamWriter streamWriter = null;
            streamWriter = SystemInfo.CurrentLanguage.Equals("zh-CN") ? new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("gb2312")) : new StreamWriter(fileName, false, System.Text.Encoding.GetEncoding("utf-8"));
            streamWriter.WriteLine(GetCSVFormatData(dataSet).ToString());
            streamWriter.Flush();
            streamWriter.Close();
        }
        #endregion

        #region public static void GetResponseCSV(DataTable dataTable, string fileName) 在浏览器中获得CSV格式文件
        /// <summary>
        /// 在浏览器中获得CSV格式文件
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fileName">输出文件名</param>
        public static void GetResponseCSV(DataTable dataTable, string fileName)
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(GetCSVFormatData(dataTable).ToString());
            HttpContext.Current.Response.End();
        }
        #endregion

        #region public static void GetResponseCSV(DataSet dataSet, string fileName) 在浏览器中获得CSV格式文件
        /// <summary>
        /// 在浏览器中获得CSV格式文件
        /// </summary>
        /// <param name="dataSet">数据权限</param>
        /// <param name="fileName">输出文件名</param>
        public static void GetResponseCSV(DataSet dataSet, string fileName)
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            HttpContext.Current.Response.AppendHeader("Content-disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(GetCSVFormatData(dataSet).ToString());
            HttpContext.Current.Response.End();
            // 读取文件下载
            //String OutTemplateCSV = Server.MapPath("~/DownLoadFiles/ExcelExport/Common/Log/LogGeneral.csv");
            //StreamWriter StreamWriter = new StreamWriter(OutTemplateCSV, false, System.Text.Encoding.GetEncoding("gb2312"));
            //StreamWriter.WriteLine(this.GetCSVFormatData(dataSet).ToString());
            //StreamWriter.Flush();
            //StreamWriter.Close();
            //Response.Redirect("../../../DownLoadFiles/ExcelExport/Common/Log/LogGeneral.csv");
        }
        #endregion 
    }
}