using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace RDIFramework.WinForm.Utilities
{
    using grproLib;
    using RDIFramework.Utilities;

    /// <summary>
    /// 
    /// Grid++Report报表操作 公共辅助类
    /// 
    /// 修改记录：
    /// 
    ///     2014-03-10 XuWangBin V2.8  增加报表操作公共辅助类。
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2014-03-10</date>
    /// </author> 
    /// </summary>
    public class GrdReportUtil
    {
        /// <summary>
        /// GrdReportUtil
        /// </summary>
        public GrdReportUtil(GridppReport nReport)
        {
            this.Report = nReport;
        }
       
       private string _DBConn;

       /// <summary>
       /// 数据库连接字符串
       /// </summary>
       public string DBConn 
       {
           get{ return _DBConn;}
           set{ _DBConn = value;}
       }

       private string _DBSql;
       /// <summary>
       /// SQL语句
       /// </summary>
       public string DBSql
       {
           get{ return _DBSql;}
           set{ _DBSql = value;}
       }

       private GridppReport _Report;
       /// <summary>
       /// Report
       /// </summary>
       public GridppReport Report 
       {
           get{ return _Report;}
           set{ _Report = value;}
       }

       private DataTable _dt;
       /// <summary>
       /// DTReport(DataTable)
       /// </summary>
       public DataTable DTReport
       {
           get{ return _dt; }
           set{ _dt = value; }
       }

        #region 公共方法
       /// <summary>
       /// 为GridReport添加链接字符串
       /// </summary>
       /// <param name="conn">DB连接字符串</param>
       public  void FillConnstring(string conn)
       {
           if (this.Report != null)
           {
               this.DBConn = conn;
               this.Report.DetailGrid.Recordset.ConnectionString = conn;
           }
           else
           {
               DialogHelper.ShowErrorMsg("变量Report为NULL!");
           }
       }

       /// <summary>
       /// 载入GridReport报表模板
       /// </summary>
       /// <param name="grdFilePath">GridReport文件的路径</param>
       /// <returns>返回载入的结果</returns>
       public  bool LoadReportFromFile(string grdFilePath)
       {
           if (!File.Exists(grdFilePath))
           {
               DialogHelper.ShowErrorMsg(grdFilePath + " 报表文件不存在!");
               return false;
           }
           return this.Report.LoadFromFile(grdFilePath);
       }

       public void FillRecordSet()
       {
           this.Report.FetchRecord += ReportFetchRecord;
       }

       public void FillRecordSetByDT()
       {           
           this.Report.FetchRecord += ReportFetchRecordByDataTable;
       }    

       /// <summary>
       ///  private  void ReportFetchRecord()
       /// </summary>
       private  void ReportFetchRecord()
       {
           SqlConnection cn = new SqlConnection(this.DBConn);
           SqlCommand cmd = new SqlCommand(this.DBSql, cn);
           cn.Open();
           SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           FillRecordToReport(this.Report, dr);
           dr.Close();
           cn.Close();
           cn.Dispose();
       }

       private void ReportFetchRecordByDataTable()
       {
           FillRecordToReport(this.Report, this.DTReport);
       }

       private void FillRecordToReport(GridppReport reprot, DataTable dt)
       {
           MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

           //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
           int MatchFieldCount = 0;
           for (int i = 0; i < dt.Columns.Count; ++i)
           {
               foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
               {
                   if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                   {
                       MatchFieldPairs[MatchFieldCount].grField = fld;
                       MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                       ++MatchFieldCount;
                       break;
                   }
               }
           }


           // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
           foreach (DataRow dr in dt.Rows)
           {
               Report.DetailGrid.Recordset.Append();

               for (int i = 0; i < MatchFieldCount; ++i)
               {
                   if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                       MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
               }

               Report.DetailGrid.Recordset.Post();
           }
       }
    
       private void FillRecordToReport(GridppReport report, IDataReader dr)
       {
           MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dr.FieldCount)];
           int MatchFieldCount = 0;
           for (int i = 0; i < dr.FieldCount; ++i)
           {
               foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
               {
                   if (String.Compare(fld.RunningDBField, dr.GetName(i), true) == 0)
                   {
                       MatchFieldPairs[MatchFieldCount].grField = fld;
                       MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                       ++MatchFieldCount;
                       break;
                   }
               }
           }
           while (dr.Read())
           {
               Report.DetailGrid.Recordset.Append();

               for (int i = 0; i < MatchFieldCount; ++i)
               {
                   if (!dr.IsDBNull(MatchFieldPairs[i].MatchColumnIndex))
                   {
                       
                       MatchFieldPairs[i].grField.Value = dr.GetValue(MatchFieldPairs[i].MatchColumnIndex);
                   }
                       
               }

               Report.DetailGrid.Recordset.Post();
           }
       }

       /// <summary>
       /// 打印预览
       /// </summary>
       /// <param name="bFalg"></param>
       public void PrintPreview(bool bFalg)
       {
           try
           {
               this.Report.PrintPreview(bFalg);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       /// <summary>
       /// 直接打印
       /// </summary>
       /// <param name="showPrintDialog">是否显示打印对话框</param>
       public void PrintDirec(bool showPrintDialog)
       {
           this.Report.Print(showPrintDialog);
       }

       /// <summary>
       ///  为GridReport中的参数赋值
       /// </summary>
       /// <param name="sParaName">参数名</param>
       /// <param name="sParaVaule">参数值</param>
       public void FillParaValue(string sParaName , string sParaVaule)
       {
           this.Report.Parameters[sParaName].AsString = sParaVaule;
       }

       /// <summary>
       /// 为GridReport中的参数赋值
       /// </summary>
       /// <param name="paraName">参数名</param>
       /// <param name="value">参数值</param>
       public void FillParaValue(string paraName, object value)
       {
           this.Report.Parameters[paraName].Value = value;
       }

        #endregion 方法
  
        #region 结构体

       private struct MatchFieldPairType
       {
           public IGRField grField;
           public int MatchColumnIndex;
       }

       #endregion 结构体

        #region "Rpt"

            
       private void ReportProcessBegin()
       {
          
       }

       private void ReportProcessEnd()
       {
          
       }

       private void sReportFetchRecord(ref bool Eof)
       {
          
       }

       private void sReportProcessBegin()
       {
         
       }
       #endregion     
    }
}
