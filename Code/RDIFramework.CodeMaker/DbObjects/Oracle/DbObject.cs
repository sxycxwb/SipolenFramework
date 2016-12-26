using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.OracleClient;

namespace RDIFramework.CodeMaker.DbObjects.Oracle
{
	/// <summary>
	/// DbObject 的摘要说明。
	/// </summary>
	public class DbObject:IDbObject
	{
		#region  属性
        public string DbType
        {
            get { return "Oracle"; }
        }
		private string _dbconnectStr;	
		public string DbConnectStr
		{
			set{_dbconnectStr=value;}
			get{return _dbconnectStr;}
		}
		OracleConnection connect = new OracleConnection();
		
		#endregion		

		#region 构造函数，构造基本信息
		public DbObject()
		{			
		}

		/// <summary>
		/// 构造一个数据库连接
		/// </summary>
        /// <param name="dbConnectStr">Db连接字符串</param>
		public DbObject(string dbConnectStr)
		{			
			_dbconnectStr=dbConnectStr;
			connect.ConnectionString=dbConnectStr;
		}		
		/// <summary>
		/// 构造一个连接字符串
		/// </summary>
		/// <param name="sspi">是否windows集成认证</param>
        /// <param name="server">服务器IP</param>
		/// <param name="user">用户名</param>
		/// <param name="pass">密码</param>
		public DbObject(bool sspi,string server,string user,string pass)
		{		
			connect = new OracleConnection();							
			_dbconnectStr="Data Source="+server+"; user id="+user+";password="+pass;			
			connect.ConnectionString=_dbconnectStr;
		}
		#endregion

		#region 打开连接OpenDB()
		/// <summary>
		/// 打开数据库
		/// </summary>
		/// <returns></returns>
		public void OpenDB()
		{
			try
			{
				if(connect.ConnectionString=="")
				{
					connect.ConnectionString=_dbconnectStr;
				}
				if(connect.ConnectionString!=_dbconnectStr)
				{
					connect.Close();
					connect.ConnectionString=_dbconnectStr;
				}
				if(connect.State==System.Data.ConnectionState.Closed)
				{
					connect.Open();
				}					

			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;	
				//return null;
			}
			
		}
		#endregion

		#region ADO.NET 操作

		public int ExecuteSql(string dbName,string sqlString)
		{
			OpenDB();
			OracleCommand dbCommand = new OracleCommand(sqlString,connect) {CommandText = sqlString};
		    int rows=dbCommand.ExecuteNonQuery();
			return rows;
		}
		
		public DataSet Query(string dbName,string sqlString)
		{			
			DataSet ds = new DataSet();
			try
			{		
				OpenDB();
				OracleDataAdapter command = new OracleDataAdapter(sqlString,connect);				
				command.Fill(ds,"ds");
			}
			catch(System.Data.OracleClient.OracleException ex)
			{				
				throw new Exception(ex.Message);
			}			
			return ds;				
		}	

		public OracleDataReader ExecuteReader(string strSQL)
		{				
			try
			{
				OpenDB();
				OracleCommand cmd = new OracleCommand(strSQL,connect);
				OracleDataReader myReader = cmd.ExecuteReader();
				return myReader;
			}
			catch(System.Data.OracleClient.OracleException ex)
			{								
				throw new Exception(ex.Message);
			}			
		}
        public object GetSingle(string dbName, string sqlString)
        {
            try
            {
                OpenDB();
                OracleCommand dbCommand = new OracleCommand(sqlString, connect);
                object obj = dbCommand.ExecuteScalar();
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
            catch
            {
                return null;
            }
        }
		#endregion

		#region 得到数据库的名字列表 GetDBList()
		/// <summary>
		/// 得到数据库的名字列表
		/// </summary>
		/// <returns></returns>
        public List<string> GetDBList()
		{
			// TODO:  添加 DbObject.GetDBList 实现
			return null;
		}
		#endregion

		#region  得到数据库的 所有用户 表名 GetTables(string dbName)
		/// <summary>
		/// 得到数据库的所有表名
		/// </summary>
		/// <param name="dbName"></param>
		/// <returns></returns>
        public List<string> GetTables(string dbName)
		{
			string strSql="SELECT TNAME name from tab where TABTYPE='TABLE'";
            List<string> tabNames = new List<string>();
            OracleDataReader reader = ExecuteReader(strSql);
            while (reader.Read())
            {
                tabNames.Add(reader.GetString(0));
            }
            reader.Close();
            return tabNames;
		}

		public DataTable GetVIEWs(string dbName)
		{
			string strSql="SELECT TNAME name from tab where TABTYPE='VIEW'";
			return Query("",strSql).Tables[0];
		}
		/// <summary>
		/// 得到数据库的所有表和视图名
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
		public DataTable GetTabViews(string dbName)
		{
			string strSql="SELECT TNAME name,TABTYPE type from tab ";
			return Query("",strSql).Tables[0];
		}
        /// <summary>
        /// 得到数据库的所有存储过程名
        /// </summary>
        /// <param name="dbName">数据库</param>
        /// <returns></returns>
        public DataTable GetProcs(string dbName)
        {
            string strSql = "SELECT * FROM ALL_SOURCE  where TYPE='PROCEDURE'  ";
            return Query(dbName, strSql).Tables[0];
            //return null;
        }

		#endregion       

        #region  得到数据库的所有 表的详细信息 GetTablesInfo(string dbName)

        /// <summary>
		/// 得到数据库的所有表的详细信息
		/// </summary>
		/// <param name="dbName"></param>
		/// <returns></returns>
        public List<TableInfo> GetTablesInfo(string dbName)
		{
			string strSql="SELECT TNAME name,'dbo' cuser,TABTYPE type,'' dates from tab where TABTYPE='TABLE'";
            //return Query("",strSql).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            OracleDataReader reader = ExecuteReader(strSql);
            while (reader.Read())
            {
                tab = new TableInfo
                {
                    TabName = reader.GetString(0),
                    TabDate = reader.GetValue(3).ToString(),
                    TabType = reader.GetString(2),
                    TabUser = reader.GetString(1)
                };
                tablist.Add(tab);
            }
            reader.Close();
            return tablist;
		}

        public List<TableInfo> GetVIEWsInfo(string dbName)
		{
			string strSql="SELECT TNAME name,'dbo' cuser,TABTYPE type,'' dates FROM tab WHERE TABTYPE='VIEW'";
            //return Query("",strSql).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            OracleDataReader reader = ExecuteReader(strSql);
            while (reader.Read())
            {
                tab = new TableInfo
                {
                    TabName = reader.GetString(0),
                    TabDate = reader.GetValue(3).ToString(),
                    TabType = reader.GetString(2),
                    TabUser = reader.GetString(1)
                };
                tablist.Add(tab);
            }
            reader.Close();
            return tablist;
		}
		/// <summary>
		/// 得到数据库的所有表和视图的详细信息
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
        public List<TableInfo> GetTabViewsInfo(string dbName)
		{
			string strSql="SELECT TNAME name,'dbo' cuser,TABTYPE type,'' dates from tab ";
            //return Query("",strSql).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            OracleDataReader reader = ExecuteReader(strSql);
            while (reader.Read())
            {
                tab = new TableInfo();
                tab.TabName = reader.GetString(0);
                tab.TabDate = reader.GetValue(3).ToString();
                tab.TabType = reader.GetString(2);
                tab.TabUser = reader.GetString(1);
                tablist.Add(tab);
            }
            reader.Close();
            return tablist;
		}
        /// <summary>
        /// 得到数据库的所有存储过程的详细信息
        /// </summary>
        /// <param name="dbName">数据库</param>
        /// <returns></returns>
        public List<TableInfo> GetProcInfo(string dbName)
        {
            string strSql = "SELECT * FROM ALL_SOURCE  where TYPE='PROCEDURE'  ";

            //return Query(dbName, strSql).Tables[0];
           
            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            OracleDataReader reader = ExecuteReader(strSql);
            while (reader.Read())
            {
                tab = new TableInfo();
                tab.TabName = reader.GetString(0);
                tab.TabDate = reader.GetValue(3).ToString();
                tab.TabType = reader.GetString(2);
                tab.TabUser = reader.GetString(1);
                tablist.Add(tab);
            }
            reader.Close();
            return tablist;

            //return null;
        }
		#endregion

        #region 得到对象定义语句
        /// <summary>
        /// 得到视图或存储过程的定义语句
        /// </summary>
        /// <param name="dbName">数据库</param>
        /// <returns></returns>
        public string GetObjectInfo(string dbName, string objName)
        {
            //string strSql = "SELECT DBMS_METADATA.GET_DDL('PROCEDURE',u.object_name) from user_objects u where object_type = 'PROCEDURE'";
            //string strSql = String.Format("SELECT dbms_metadata.get_ddl('PROCEDURE','{0}','{1}') from dual;", objName, dbName);            
            //return GetSingle(dbName, strSql.ToString()).ToString();
            return "";
        }
        #endregion

		#region 得到(快速)数据库里表的列名和类型 GetColumnList(string dbName,string tableName)

		/// <summary>
		/// 得到数据库里表的列名和类型
		/// </summary>
		/// <param name="dbName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
        public List<ColumnInfo> GetColumnList(string dbName, string tableName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT ");
            strSql.Append("COLUMN_ID as colorder,");
			strSql.Append("COLUMN_NAME as ColumnName,");
			strSql.Append("DATA_TYPE as TypeName ");		
			strSql.Append(" from USER_TAB_COLUMNS ");
			strSql.Append(" where TABLE_NAME='"+tableName+"'");
			strSql.Append(" order by COLUMN_ID");					
            //return Query("",strSql.ToString()).Tables[0];

            List<ColumnInfo> collist = new List<ColumnInfo>();
            ColumnInfo col;
            OracleDataReader reader = ExecuteReader(strSql.ToString());
            while (reader.Read())
            {
                col = new ColumnInfo
                {
                    ColOrder = reader.GetValue(0).ToString(),
                    ColumnName = reader.GetString(1),
                    TypeName = reader.GetString(2),
                    Length = "",
                    Preci = "",
                    Scale = "",
                    IsPK = false,
                    IsNull = false,
                    DefaultVal = "",
                    IsIdentity = false,
                    ColDescription = ""
                };
                collist.Add(col);
            }
            reader.Close();
            return collist;
		}

		#endregion

		#region 得到数据库里表的 列的详细信息 GetColumnInfoList(string dbName,string tableName)

		/// <summary>
		/// 得到数据库里表的列的详细信息
		/// </summary>
		/// <param name="dbName">数据库名称</param>
		/// <param name="tableName">表名</param>
		/// <returns></returns>
        public List<ColumnInfo> GetColumnInfoList(string dbName, string tableName)
		{
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append("COL.COLUMN_ID as colorder,");
                strSql.Append("COL.COLUMN_NAME as ColumnName,");
                strSql.Append("COL.DATA_TYPE as TypeName, ");
                //strSql.Append("COL.DATA_LENGTH as Length,");
                strSql.Append("DECODE(COL.DATA_TYPE, 'NUMBER',COL.DATA_PRECISION, COL.DATA_LENGTH) as Length,");
                strSql.Append("COL.DATA_PRECISION as Preci,");
                strSql.Append("COL.DATA_SCALE as Scale,");
                strSql.Append("'' as IsIdentity,");
                //strSql.Append("PKCOL.COLUMN_POSITION as isPK,");//就是这儿，如果有多个主键，就会以1,2,3。。。这样的顺序下去
                strSql.Append("case when PKCOL.COLUMN_POSITION >0  then '√'else '' end as isPK,");
                //strSql.Append("COL.NULLABLE as isNull,");
                strSql.Append("case when COL.NULLABLE='Y'  then '√'else '' end as isNull, ");
                strSql.Append("COL.DATA_DEFAULT as defaultVal, ");
                strSql.Append("CCOM.COMMENTS as deText,");
                strSql.Append("COL.NUM_DISTINCT as NUM_DISTINCT ");
                strSql.Append(" FROM USER_TAB_COLUMNS COL,USER_COL_COMMENTS CCOM, ");
                strSql.Append(" ( SELECT AA.TABLE_NAME, AA.INDEX_NAME, AA.COLUMN_NAME, AA.COLUMN_POSITION");
                strSql.Append(" FROM USER_IND_COLUMNS AA, USER_CONSTRAINTS BB");
                strSql.Append(" WHERE BB.CONSTRAINT_TYPE = 'P'");
                strSql.Append(" AND AA.TABLE_NAME = BB.TABLE_NAME");
                strSql.Append(" AND AA.INDEX_NAME = BB.CONSTRAINT_NAME");
                strSql.Append(" AND AA.TABLE_NAME IN ('" + tableName + "')");
                strSql.Append(") PKCOL");
                strSql.Append(" WHERE COL.TABLE_NAME = CCOM.TABLE_NAME");
                strSql.Append(" AND COL.COLUMN_NAME = CCOM.COLUMN_NAME");
                strSql.Append(" AND COL.TABLE_NAME ='" + tableName + "'");
                strSql.Append(" AND COL.COLUMN_NAME = PKCOL.COLUMN_NAME(+)");
                strSql.Append(" AND COL.TABLE_NAME = PKCOL.TABLE_NAME(+)");
                strSql.Append(" ORDER BY COL.COLUMN_ID ");

                //return Query("",strSql.ToString()).Tables[0];

                List<ColumnInfo> collist = new List<ColumnInfo>();
                ColumnInfo col;
                OracleDataReader reader = ExecuteReader(strSql.ToString());
                while (reader.Read())
                {
                    col = new ColumnInfo
                    {
                        ColOrder = reader.GetValue(0).ToString(),
                        ColumnName = reader.GetValue(1).ToString(),
                        TypeName = reader.GetValue(2).ToString(),
                        Length = reader.GetValue(3).ToString(),
                        Preci = reader.GetValue(4).ToString(),
                        Scale = reader.GetValue(5).ToString(),
                        IsIdentity = (reader.GetValue(6).ToString() == "√") ? true : false,
                        IsPK = (reader.GetValue(7).ToString() == "√") ? true : false,
                        IsNull = (reader.GetValue(8).ToString() == "√") ? true : false,
                        DefaultVal = reader.GetValue(9).ToString(),
                        ColDescription = reader.GetValue(10).ToString()
                    };
                    collist.Add(col);
                }
                reader.Close();
                return collist;

            }
            catch (System.Exception ex)
            {
                throw new Exception("获取列数据失败" + ex.Message);
            }

            #region
            //SELECT COL.TABLE_NAME as TNAME, 
            //TCOM.COMMENTS as TCMT,
            //COL.COLUMN_NAME as COL_NM, 
            //CCOM.COMMENTS as COL_CMT,
            //COL.COLUMN_ID ID,
            //PKCOL.COLUMN_POSITION AS PK,  --就是这儿，如果有多个主键，就会以1,2,3。。。这样的顺序下去
            //COL.DATA_TYPE as TYPE_CD, 
            //DECODE(COL.DATA_TYPE, 'NUMBER',COL.DATA_PRECISION ||'.'||COL.DATA_SCALE, COL.DATA_LENGTH) as LENGTH,
            //COL.NULLABLE as NULL_YN,
            //COL.DATA_DEFAULT as D_DEFAULT,
            //COL.NUM_DISTINCT as NUM_DISTINCT
            //FROM USER_TAB_COLUMNS COL,
            //USER_TAB_COMMENTS TCOM,
            //USER_COL_COMMENTS CCOM,
            //( SELECT AA.TABLE_NAME, AA.INDEX_NAME, AA.COLUMN_NAME, AA.COLUMN_POSITION
            //FROM USER_IND_COLUMNS AA, USER_CONSTRAINTS BB
            //WHERE BB.CONSTRAINT_TYPE = 'P'
            //AND AA.TABLE_NAME = BB.TABLE_NAME
            //AND AA.INDEX_NAME = BB.CONSTRAINT_NAME
            //-- AND AA.TABLE_NAME IN ('ACCOUNTMONEY') 
            //) PKCOL
            //WHERE COL.TABLE_NAME = TCOM.TABLE_NAME 
            //AND COL.TABLE_NAME = CCOM.TABLE_NAME 
            //AND COL.COLUMN_NAME = CCOM.COLUMN_NAME
            //AND COL.TABLE_NAME = 'ACCOUNTMONEY' 
            //AND COL.COLUMN_NAME = PKCOL.COLUMN_NAME(+)
            //AND COL.TABLE_NAME = PKCOL.TABLE_NAME(+)
            //ORDER BY COL.TABLE_NAME ,
            //COL.COLUMN_ID 
            #endregion

        }

		#endregion
        
		#region 得到数据库里表的主键 GetKeyName(string dbName,string tableName)

		public DataTable GetKeyName(string dbName, string tableName)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            strSql.Append("COL.COLUMN_ID as colorder,");
            strSql.Append("COL.COLUMN_NAME as ColumnName,");
            strSql.Append("COL.DATA_TYPE as TypeName, ");
            strSql.Append("COL.DATA_LENGTH as Length,");
            strSql.Append("COL.DATA_PRECISION as Preci,");
            strSql.Append("COL.DATA_SCALE as Scale,");
            strSql.Append("'' as IsIdentity,");
            //strSql.Append("PKCOL.COLUMN_POSITION as isPK,");//就是这儿，如果有多个主键，就会以1,2,3。。。这样的顺序下去
            strSql.Append("case when PKCOL.COLUMN_POSITION >0  then '√'else '' end as isPK,");

            //strSql.Append("COL.NULLABLE as isNull,");
            strSql.Append("case when COL.NULLABLE='Y'  then '√'else '' end as isNull, ");

            strSql.Append("COL.DATA_DEFAULT as defaultVal, ");
            strSql.Append("CCOM.COMMENTS as deText,");
            strSql.Append("COL.NUM_DISTINCT as NUM_DISTINCT ");
            strSql.Append(" FROM USER_TAB_COLUMNS COL,USER_COL_COMMENTS CCOM, ");
            strSql.Append(" ( SELECT AA.TABLE_NAME, AA.INDEX_NAME, AA.COLUMN_NAME, AA.COLUMN_POSITION");
            strSql.Append(" FROM USER_IND_COLUMNS AA, USER_CONSTRAINTS BB");
            strSql.Append(" WHERE BB.CONSTRAINT_TYPE = 'P'");
            strSql.Append(" AND AA.TABLE_NAME = BB.TABLE_NAME");
            strSql.Append(" AND AA.INDEX_NAME = BB.CONSTRAINT_NAME");
            strSql.Append(" AND AA.TABLE_NAME IN ('" + tableName + "')");
            strSql.Append(") PKCOL");
            strSql.Append(" WHERE COL.TABLE_NAME = CCOM.TABLE_NAME");
            strSql.Append(" AND PKCOL.COLUMN_POSITION >0");
            strSql.Append(" AND COL.COLUMN_NAME = CCOM.COLUMN_NAME");
            strSql.Append(" AND COL.TABLE_NAME ='" + tableName + "'");
            strSql.Append(" AND COL.COLUMN_NAME = PKCOL.COLUMN_NAME(+)");
            strSql.Append(" AND COL.TABLE_NAME = PKCOL.TABLE_NAME(+)");
            strSql.Append(" ORDER BY COL.COLUMN_ID ");	

            return Query("", strSql.ToString()).Tables[0];
		}
		#endregion

		#region 得到数据表里的数据 GetTabData(string dbName,string tableName)

		/// <summary>
		/// 得到数据表里的数据
		/// </summary>
		/// <param name="dbName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public DataTable GetTabData(string dbName, string tableName)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT * from " + tableName + "");
			return Query("",strSql.ToString()).Tables[0];
		}
        /// <summary>
        /// 根据SQL查询得到数据表里的数据
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataTable GetTabDataBySQL(string dbName, string strSql)
        {
            return Query("", strSql).Tables[0];
        }
		#endregion

		#region 数据库属性操作
        /// <summary>
        /// 数据表重命名
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
		public bool RenameTable(string dbName, string oldName, string newName)
		{
            try
            {
                string strsql = "RENAME " + oldName + " TO " + newName + "";
                ExecuteSql(dbName, strsql);
                return true;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;	
                return false;
            }		
		}

		public bool DeleteTable(string dbName, string tableName)
		{
			try
			{				
				string strsql="DROP TABLE "+tableName+"";
                ExecuteSql(dbName, strsql);
				return true;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;	
				return false;
			}			
		}
		/// <summary>
		/// 得到版本号
		/// </summary>
		/// <returns></returns>
		public string GetVersion()
		{			
			return "";				
		}
		#endregion
		
	}
}
