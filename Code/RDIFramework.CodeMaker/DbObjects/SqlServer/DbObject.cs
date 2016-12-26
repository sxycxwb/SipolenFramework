using System;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RDIFramework.CodeMaker.DbObjects.SqlServer
{
	/// <summary>
	/// 数据库信息类。
	/// </summary>
	public class DbObject:IDbObject
	{
        string cmcfgfile = Application.StartupPath + @"\Config\cmcfg.ini";
        IniFileHelper cfgfile;
        bool isdbosp = false;

		#region  属性
        public string DbType
        {
            get { return "SQL2008"; }            
        }
		private string _dbconnectStr;	
		public string DbConnectStr
		{
			set{_dbconnectStr=value;}
			get{return _dbconnectStr;}
		}
		SqlConnection connect = new SqlConnection();
		
		#endregion

		#region 构造函数，构造基本信息
		public DbObject()
		{
            IsDboSp();
		}

		/// <summary>
		/// 构造一个数据库连接
		/// </summary>
        /// <param name="dbConnectStr">数据库连接字符串</param>
		public DbObject(string dbConnectStr)
		{			
			_dbconnectStr=dbConnectStr;
			connect.ConnectionString=dbConnectStr;
		}	
	
		/// <summary>
		/// 构造一个连接字符串
		/// </summary>
		/// <param name="sspi">是否windows集成认证</param>
		/// <param name="ip">服务器IP</param>
		/// <param name="user">用户名</param>
		/// <param name="pass">密码</param>
		public DbObject(bool sspi,string ip,string user,string pass)
		{		
			connect = new SqlConnection();
			if(sspi)
			{
				_dbconnectStr="Integrated Security=SSPI;Data Source="+ip+";Initial Catalog=master";
				//constr="Provider=SQLOLEDB;Data Source="+ip+";Initial Catalog=master;Integrated Security=SSPI";//这是OleDbConnection连接的字符串
			}
			else
			{
			    _dbconnectStr = pass == ""
			        ? "user id=" + user + ";initial catalog=master;data source=" + ip + ";Connect Timeout=30"
			        : "user id=" + user + ";password=" + pass + ";initial catalog=master;data source=" + ip + ";Connect Timeout=30";
			}
			connect.ConnectionString=_dbconnectStr;
		}
		
		#endregion

        #region  是否采用sp(存储过程)的方式获取数据结构信息
        /// <summary>
        /// 是否采用sp的方式获取数据结构信息
        /// </summary>
        /// <returns></returns>
        private bool IsDboSp()
        {            
            if (File.Exists(cmcfgfile))
            {
                cfgfile = new IniFileHelper(cmcfgfile);
                string val = cfgfile.ReadString("dbo", "dbosp","");
                if (val.Trim() == "1")
                {
                    isdbosp = true;
                }
            }
            return isdbosp;
        }

        #endregion

        #region 打开数据库 OpenDB(string DbName)

        /// <summary>
		/// 打开数据库
		/// </summary>
		/// <param name="dbName">要打开的数据库</param>
		/// <returns></returns>
		private SqlCommand OpenDB(string dbName)
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
				SqlCommand dbCommand = new SqlCommand {Connection = connect};
			    if(connect.State==System.Data.ConnectionState.Closed)
				{
					connect.Open();
				}	
				dbCommand.CommandText="use ["+dbName+"]";
				dbCommand.ExecuteNonQuery();
				return dbCommand;

			}
			catch(System.Exception ex)
			{
				string str=ex.Message;	
				return null;
			}
		}
		#endregion

		#region ADO.NET 操作

		public int ExecuteSql(string dbName,string sqlString)
		{
            using (SqlCommand dbCommand = OpenDB(dbName))
            {
                dbCommand.CommandText = sqlString;
                int rows = dbCommand.ExecuteNonQuery();
                return rows;
            }
		}

		public DataSet Query(string dbName,string sqlString)
		{			
			DataSet ds = new DataSet();
			try
			{		
				OpenDB(dbName);
                using (SqlDataAdapter command = new SqlDataAdapter(sqlString, connect))
                {
                    command.Fill(ds, "ds");
                }
			}
			catch(System.Data.SqlClient.SqlException ex)
			{				
				throw new Exception(ex.Message);
			}			
			return ds;				
		}

        public SqlDataReader ExecuteReader(string dbName, string strSql)
        {
            try
            {
                OpenDB(dbName);
                using(SqlCommand cmd = new SqlCommand(strSql, connect))
                {
                    SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return myReader;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }       

        public object GetSingle(string dbName, string sqlString)
        {
            try
            {
                using (SqlCommand dbCommand = OpenDB(dbName))
                {
                    dbCommand.CommandText = sqlString;
                    object obj = dbCommand.ExecuteScalar();
                    return (Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) ? null : obj;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string DbName, string storedProcName, IDataParameter[] parameters, string tableName)
        {

            OpenDB(DbName);
            DataSet dataSet = new DataSet();
            using (SqlDataAdapter sqlDA = new SqlDataAdapter())
            {
                sqlDA.SelectCommand = BuildQueryCommand(connect, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                return dataSet;
            }
        }

        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter == null) continue;
                // 检查未分配值的输出参数,将其分配以DBNull.Value.
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                command.Parameters.Add(parameter);
            }

            return command;
        }
		#endregion

		#region 得到数据库的名字列表 GetDBList()

		/// <summary>
		/// 得到数据库的名字列表
		/// </summary>
		/// <returns></returns>
		public List<string> GetDBList()
		{					
            List<string> dblist=new List<string>();
            string strSql = "select name from sysdatabases order by name";
            //return Query("master",strSql).Tables[0];
            SqlDataReader reader = ExecuteReader("master", strSql);
            while (reader.Read())
            {
                dblist.Add(reader.GetString(0));
            }
            reader.Close();
            return dblist;
		}
		#endregion

        #region  得到数据库的所有表和视图 的名字
        /// <summary>
		/// 得到数据库的所有表名
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
        public List<string> GetTables(string dbName)
		{
            if (isdbosp)
            {
                return GetTablesSP(dbName);
            }
			//string strSql="select [name] from sysobjects where xtype='U'and [name]<>'dtproperties' order by [name]";//order by id
            StringBuilder sbSql = new StringBuilder();
            //sbSql.Append("select sch.name + '.' + so.[name] name from sysobjects so,sys.schemas sch ");
            //sbSql.Append("where so.xtype='U'and so.[name]<>'dtproperties'  AND so.uid = sch.schema_id ");
            //sbSql.Append("order by sch.name,so.[name] ");
            sbSql.Append("select [name] from sysobjects where xtype='U'and [name]<>'dtproperties' order by [name]");
            //return Query(DbName,strSql).Tables[0];
            List<string> tabNames = new List<string>();
            SqlDataReader reader = ExecuteReader(dbName, sbSql.ToString());
            while (reader.Read())
            {
                tabNames.Add(reader.GetString(0));
            }
            reader.Close();
            return tabNames;
		}

        public List<string> GetTablesSP(string dbName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@table_name", SqlDbType.NVarChar,384),
					new SqlParameter("@table_owner", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_qualifier", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_type", SqlDbType.VarChar,100)
            };
            parameters[0].Value = null;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = "'TABLE'";

            DataSet ds = RunProcedure(dbName, "sp_tables", parameters, "ds");
            List<string> tabNames = new List<string>();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                //dt.Columns["TABLE_QUALIFIER"].ColumnName = "db";
                //dt.Columns["TABLE_OWNER"].ColumnName = "cuser";
                //dt.Columns["TABLE_NAME"].ColumnName = "name";
                //dt.Columns["TABLE_TYPE"].ColumnName = "type";
                //dt.Columns["REMARKS"].ColumnName = "remarks";
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    tabNames.Add(dt.Rows[n]["TABLE_NAME"].ToString());
                }
                return tabNames;
            }
            else
            {
                return null;
            }
        }
    
		/// <summary>
		/// 得到数据库的所有视图名
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
		public DataTable GetVIEWs(string dbName)
		{
            if (isdbosp)
            {
                return GetVIEWsSP(dbName);
            }
			//string strSql="select [name] from sysobjects where xtype='V' and [name]<>'syssegments' and [name]<>'sysconstraints' order by [name]";//order by id
            StringBuilder sbSql = new StringBuilder();
            //sbSql.Append("select sch.name + '.' + so.[name] name from sysobjects so,sys.schemas sch ");
            //sbSql.Append("where so.xtype='V' and so.[name]<>'syssegments' and so.[name]<>'sysconstraints' AND so.uid = sch.schema_id ");
            //sbSql.Append("order by sch.name,so.[name] ");
            sbSql.Append("select [name] from sysobjects where xtype='V' and [name]<>'syssegments' and [name]<>'sysconstraints' order by [name]");
            return Query(dbName, sbSql.ToString()).Tables[0];
		}
        /// <summary>
        /// 得到数据库的所有视图名
        /// </summary>
        /// <param name="DbName">数据库</param>
        /// <returns></returns>
        public DataTable GetVIEWsSP(string DbName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@table_name", SqlDbType.NVarChar,384),
					new SqlParameter("@table_owner", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_qualifier", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_type", SqlDbType.VarChar,100)
            };
            parameters[0].Value = null;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = "'VIEW'";

            DataSet ds = RunProcedure(DbName, "sp_tables", parameters, "ds");
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                dt.Columns["TABLE_QUALIFIER"].ColumnName = "db";
                dt.Columns["TABLE_OWNER"].ColumnName = "cuser";
                dt.Columns["TABLE_NAME"].ColumnName = "name";
                dt.Columns["TABLE_TYPE"].ColumnName = "type";
                dt.Columns["REMARKS"].ColumnName = "remarks";
                return dt;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 得到数据库的所有表和视图名
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
		public DataTable GetTabViews(string dbName)
		{
            if (isdbosp)
            {
                return GetTabViewsSP(dbName);
            }
			StringBuilder strSql=new StringBuilder();            
			strSql.Append("select [name],sysobjects.xtype type from sysobjects ");
            strSql.Append("where (xtype='U' or xtype='V' or xtype='P') ");
			strSql.Append("and [name]<>'dtproperties' and [name]<>'syssegments' and [name]<>'sysconstraints' ");
			strSql.Append("order by xtype,[name]");
            /*
            strSql.Append("select sch.name + '.' + so.[name] name,so.xtype TYPE from sysobjects so,sys.schemas sch ");
            strSql.Append("where (so.xtype='U' or so.xtype='V' or so.xtype='P') and so.[name]<>'dtproperties' ");
            strSql.Append("and so.[name]<>'syssegments' and so.[name]<>'sysconstraints' AND so.uid = sch.schema_id ");
            strSql.Append("order by sch.name,so.xtype,so.[name] ");
             */
            return Query(dbName,strSql.ToString()).Tables[0];
		}
        /// <summary>
        /// 得到数据库的所有表和视图名
        /// </summary>
        /// <param name="DbName">数据库</param>
        /// <returns></returns>
        public DataTable GetTabViewsSP(string DbName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@table_name", SqlDbType.NVarChar,384),
					new SqlParameter("@table_owner", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_qualifier", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_type", SqlDbType.VarChar,100)
            };
            parameters[0].Value = null;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = "'TABLE','VIEW'";

            DataSet ds = RunProcedure(DbName, "sp_tables", parameters, "ds");
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                dt.Columns["TABLE_QUALIFIER"].ColumnName = "db";
                dt.Columns["TABLE_OWNER"].ColumnName = "cuser";
                dt.Columns["TABLE_NAME"].ColumnName = "name";
                dt.Columns["TABLE_TYPE"].ColumnName = "type";
                dt.Columns["REMARKS"].ColumnName = "remarks";
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到数据库的所有存储过程名
        /// </summary>
        /// <param name="dbName">数据库</param>
        /// <returns></returns>
        public DataTable GetProcs(string dbName)
        {
            //string strSql = "select [name] from sysobjects where xtype='P'and [name]<>'dtproperties' order by [name]";//order by id

            StringBuilder sbSql = new StringBuilder();
            //sbSql.Append("select sch.name + '.' + so.[name] name from sysobjects so,sys.schemas sch ");
            //sbSql.Append("where so.xtype='P' and so.[name]<>'syssegments' and so.[name]<>'sysconstraints' AND so.uid = sch.schema_id ");
            //sbSql.Append("order by sch.name,so.[name] ");
            sbSql.Append("select [name] from sysobjects where xtype='P'and [name]<>'dtproperties' order by [name]");
            return Query(dbName, sbSql.ToString()).Tables[0];
        }
		#endregion

		#region  得到数据库的所有表和视图 的列表信息 
		/// <summary>
		/// 得到数据库的所有表的详细信息
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
        public List<TableInfo> GetTablesInfo(string dbName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sysobjects.[name] name,sysusers.name cuser,");
			strSql.Append("sysobjects.xtype type,sysobjects.crdate dates ");
			strSql.Append("from sysobjects,sysusers ");
			strSql.Append("where sysusers.uid=sysobjects.uid ");
			strSql.Append("and sysobjects.xtype='U' ");
			strSql.Append("and  sysobjects.[name]<>'dtproperties' ");
            strSql.Append("order by sysobjects.[name] ");
            //strSql.Append("order by sysobjects.id");
            //return Query(DbName,strSql.ToString()).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            SqlDataReader reader = ExecuteReader(dbName, strSql.ToString());
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
		/// 得到数据库的所有视图的详细信息
		/// </summary>
		/// <param name="dbName">数据库</param>
		/// <returns></returns>
        public List<TableInfo> GetVIEWsInfo(string dbName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sysobjects.[name] name,sysusers.name cuser,");
			strSql.Append("sysobjects.xtype type,sysobjects.crdate dates ");
			strSql.Append("from sysobjects,sysusers ");
			strSql.Append("where sysusers.uid=sysobjects.uid ");
			strSql.Append("and sysobjects.xtype='V' ");
			strSql.Append("and sysobjects.[name]<>'syssegments' and sysobjects.[name]<>'sysconstraints'  ");
            //strSql.Append("order by sysobjects.id");
            strSql.Append("order by sysobjects.[name] ");
            //return Query(DbName,strSql.ToString()).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            SqlDataReader reader = ExecuteReader(dbName, strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select sysobjects.[name] name,sysusers.name cuser,");
			strSql.Append("sysobjects.xtype type,sysobjects.crdate dates ");
			strSql.Append("from sysobjects,sysusers ");
			strSql.Append("where sysusers.uid=sysobjects.uid ");
            strSql.Append("and (sysobjects.xtype='U' or sysobjects.xtype='V' or sysobjects.xtype='P') ");
			strSql.Append("and sysobjects.[name]<>'dtproperties' and sysobjects.[name]<>'syssegments' and sysobjects.[name]<>'sysconstraints'  ");
            //strSql.Append("order by sysobjects.id");
            strSql.Append("order by sysobjects.xtype,sysobjects.[name] ");
            //return Query(DbName,strSql.ToString()).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            SqlDataReader reader = ExecuteReader(dbName, strSql.ToString());
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
        /// 得到数据库的所有存储过程的详细信息
        /// </summary>
        /// <param name="dbName">数据库</param>
        /// <returns></returns>
        public List<TableInfo> GetProcInfo(string dbName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sysobjects.[name] name,sysusers.name cuser,");
            strSql.Append("sysobjects.xtype type,sysobjects.crdate dates ");
            strSql.Append("from sysobjects,sysusers ");
            strSql.Append("where sysusers.uid=sysobjects.uid ");
            strSql.Append("and sysobjects.xtype='P' ");
            //strSql.Append("and  sysobjects.[name]<>'dtproperties' ");
            //strSql.Append("order by sysobjects.id");
            strSql.Append("order by sysobjects.[name] ");
            //return Query(DbName, strSql.ToString()).Tables[0];

            List<TableInfo> tablist = new List<TableInfo>();
            TableInfo tab;
            SqlDataReader reader = ExecuteReader(dbName, strSql.ToString());
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
		#endregion

        #region 得到对象定义语句
        /// <summary>
        /// 得到视图或存储过程的定义语句
        /// </summary>
        /// <param name="dbName">数据库</param>
        /// <returns></returns>
        public string GetObjectInfo(string dbName, string objName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.text ");
            strSql.Append("from sysobjects a, syscomments b  ");
            strSql.Append("where a.xtype IN ('v','p')  and a.id = b.id   ");
            strSql.Append(" and a.name= '" + objName + "'");
            object oObjectInfo = GetSingle(dbName, strSql.ToString());
            return oObjectInfo == null ? string.Empty : oObjectInfo.ToString();
        }
        #endregion
		
		#region 得到(快速)数据库里表的列名和类型 GetColumnList(string DbName,string TableName)

		/// <summary>
		/// 得到数据库里表或视图的列名和类型
		/// </summary>
		/// <param name="dbName">库</param>
		/// <param name="tableName">表</param>
		/// <returns></returns>
        public List<ColumnInfo> GetColumnList(string dbName, string tableName)
		{
			try
			{
                if (isdbosp)
                {
                    return GetColumnListSP(dbName, tableName);
                }
				StringBuilder strSql=new StringBuilder();
				strSql.Append("Select ");
                strSql.Append("a.colorder as colorder,");
				strSql.Append("a.name as ColumnName,");
				strSql.Append("b.name as TypeName ");
				strSql.Append(" from syscolumns a, systypes b, sysobjects c ");
				strSql.Append(" where a.xtype = b.xusertype ");
				strSql.Append("and a.id = c.id ");
//				strSql.Append("and c.xtype='U' ");
				strSql.Append("and c.name ='"+tableName+"'");
				strSql.Append(" order by a.colorder");
			
                //return Query(DbName,strSql.ToString()).Tables[0];
                ArrayList colexist = new ArrayList();//是否已经存在
                List<ColumnInfo> collist = new List<ColumnInfo>();
                ColumnInfo col;
                SqlDataReader reader = ExecuteReader(dbName,strSql.ToString());
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
                    if (colexist.Contains(col.ColumnName)) continue;
                    collist.Add(col);
                    colexist.Add(col.ColumnName);
                }
                reader.Close();
                return collist;

			}
			catch(System.Exception ex)
			{
                LogHelper.WriteException(ex);
				return null;
			}
		}

        public List<ColumnInfo> GetColumnListSP(string dbName, string tableName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@table_name", SqlDbType.NVarChar,384),
					new SqlParameter("@table_owner", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_qualifier", SqlDbType.NVarChar,384),
                    new SqlParameter("@column_name", SqlDbType.VarChar,100)
            };
            parameters[0].Value = tableName;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = null;

            DataSet ds = RunProcedure(dbName, "sp_columns", parameters, "ds");
            int n = ds.Tables.Count;
            if (n > 0)
            {
                DataTable dt = ds.Tables[0];
                int r = dt.Rows.Count;
                DataTable dtkey = CreateColumnTable();
                for (int m = 0; m < r; m++)
                {
                    DataRow nrow = dtkey.NewRow();
                    nrow["colorder"] = dt.Rows[m]["ORDINAL_POSITION"];
                    nrow["ColumnName"] = dt.Rows[m]["COLUMN_NAME"];
                    string tn = dt.Rows[m]["TYPE_NAME"].ToString().Trim();
                    nrow["TypeName"] = (tn == "int identity") ? "int" : tn;
                    nrow["Length"] = dt.Rows[m]["LENGTH"];
                    nrow["Preci"] = dt.Rows[m]["PRECISION"];
                    nrow["Scale"] = dt.Rows[m]["SCALE"];
                    nrow["IsIdentity"] = (tn == "int identity") ? "√" : "";
                    nrow["isPK"] = "";
                    nrow["IsNull"] = (dt.Rows[m]["NULLABLE"].ToString().Trim() == "1") ? "√" : "";
                    nrow["defaultVal"] = dt.Rows[m]["COLUMN_DEF"];
                    nrow["deText"] = dt.Rows[m]["REMARKS"];
                    dtkey.Rows.Add(nrow);
                }
                return CodeCommon.GetColumnInfos(dtkey);
            }
            else
            {
                return null;
            }   

        }
		#endregion

		#region 得到表的列的详细信息 GetColumnInfoList(string DbName,string TableName)
		/// <summary>
		/// 得到数据库里表或视图的列的详细信息
		/// </summary>
		/// <param name="dbName">库</param>
		/// <param name="tableName">表</param>
		/// <returns></returns>
        public List<ColumnInfo> GetColumnInfoList(string dbName, string tableName)
		{
            if (isdbosp)
            {               
               return GetColumnInfoListSP(dbName, tableName);                
            }            
			StringBuilder strSql=new StringBuilder();					            
			strSql.Append("SELECT ");
			strSql.Append("colorder=C.column_id,");
			strSql.Append("ColumnName=C.name,");
			strSql.Append("TypeName=T.name, ");
            //strSql.Append("Length=C.max_length, ");
            strSql.Append("Length=CASE WHEN T.name='nchar' THEN C.max_length/2 WHEN T.name='nvarchar' THEN C.max_length/2 ELSE C.max_length END,");
			strSql.Append("Preci=C.precision, ");
			strSql.Append("Scale=C.scale, ");
			strSql.Append("IsIdentity=CASE WHEN C.is_identity=1 THEN N'√'ELSE N'' END,");
			strSql.Append("isPK=ISNULL(IDX.PrimaryKey,N''),");			
			
			strSql.Append("Computed=CASE WHEN C.is_computed=1 THEN N'√'ELSE N'' END, ");
			strSql.Append("IndexName=ISNULL(IDX.IndexName,N''), ");
			strSql.Append("IndexSort=ISNULL(IDX.Sort,N''), ");
			strSql.Append("Create_Date=O.Create_Date, ");
			strSql.Append("Modify_Date=O.Modify_date, ");

			strSql.Append("IsNull=CASE WHEN C.is_nullable=1 THEN N'√'ELSE N'' END, ");
			strSql.Append("defaultVal=ISNULL(D.definition,N''), ");
			strSql.Append("deText=ISNULL(PFD.[value],N'') ");
			
			strSql.Append("FROM sys.columns C ");
			strSql.Append("INNER JOIN sys.objects O ");
			strSql.Append("ON C.[object_id]=O.[object_id] ");
            strSql.Append("AND (O.type='U' or O.type='V') ");
			strSql.Append("AND O.is_ms_shipped=0 ");
			strSql.Append("INNER JOIN sys.types T ");
			strSql.Append("ON C.user_type_id=T.user_type_id ");
			strSql.Append("LEFT JOIN sys.default_constraints D ");
			strSql.Append("ON C.[object_id]=D.parent_object_id ");
			strSql.Append("AND C.column_id=D.parent_column_id ");
			strSql.Append("AND C.default_object_id=D.[object_id] ");
			strSql.Append("LEFT JOIN sys.extended_properties PFD ");
			strSql.Append("ON PFD.class=1  ");
			strSql.Append("AND C.[object_id]=PFD.major_id  ");
			strSql.Append("AND C.column_id=PFD.minor_id ");
//			strSql.Append("--AND PFD.name='Caption'  -- 字段说明对应的描述名称(一个字段可以添加多个不同name的描述) ");
			strSql.Append("LEFT JOIN sys.extended_properties PTB ");
			strSql.Append("ON PTB.class=1 ");
			strSql.Append("AND PTB.minor_id=0  ");
			strSql.Append("AND C.[object_id]=PTB.major_id ");
//			strSql.Append("-- AND PFD.name='Caption'  -- 表说明对应的描述名称(一个表可以添加多个不同name的描述)   ");
			strSql.Append("LEFT JOIN ");// -- 索引及主键信息
			strSql.Append("( ");
			strSql.Append("SELECT  ");
			strSql.Append("IDXC.[object_id], ");
			strSql.Append("IDXC.column_id, ");
			strSql.Append("Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending') ");
			strSql.Append("WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END, ");
			strSql.Append("PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END, ");
			strSql.Append("IndexName=IDX.Name ");
			strSql.Append("FROM sys.indexes IDX ");
			strSql.Append("INNER JOIN sys.index_columns IDXC ");
			strSql.Append("ON IDX.[object_id]=IDXC.[object_id] ");
			strSql.Append("AND IDX.index_id=IDXC.index_id ");
			strSql.Append("LEFT JOIN sys.key_constraints KC ");
			strSql.Append("ON IDX.[object_id]=KC.[parent_object_id] ");
			strSql.Append("AND IDX.index_id=KC.unique_index_id ");
			strSql.Append("INNER JOIN  ");// 对于一个列包含多个索引的情况,只显示第1个索引信息
			strSql.Append("( ");
			strSql.Append("SELECT [object_id], Column_id, index_id=MIN(index_id) ");
			strSql.Append("FROM sys.index_columns ");
			strSql.Append("GROUP BY [object_id], Column_id ");
			strSql.Append(") IDXCUQ ");
			strSql.Append("ON IDXC.[object_id]=IDXCUQ.[object_id] ");
			strSql.Append("AND IDXC.Column_id=IDXCUQ.Column_id ");
			strSql.Append("AND IDXC.index_id=IDXCUQ.index_id ");
			strSql.Append(") IDX ");
			strSql.Append("ON C.[object_id]=IDX.[object_id] ");
			strSql.Append("AND C.column_id=IDX.column_id  ");
		
			strSql.Append("WHERE O.name=N'"+tableName+"' ");
			strSql.Append("ORDER BY O.name,C.column_id  ");
            

            //return Query(DbName,strSql.ToString()).Tables[0];

            ArrayList colexist = new ArrayList();//是否已经存在

            List<ColumnInfo> collist = new List<ColumnInfo>();
            ColumnInfo col;
            SqlDataReader reader = ExecuteReader(dbName, strSql.ToString()); 
            while (reader.Read())
            {
                col = new ColumnInfo
                {
                    ColOrder = reader.GetValue(0).ToString(),
                    ColumnName = reader.GetString(1),
                    TypeName = reader.GetString(2),
                    Length = reader.GetValue(3).ToString(),
                    Preci = reader.GetValue(4).ToString(),
                    Scale = reader.GetValue(5).ToString(),
                    IsIdentity = (reader.GetString(6) == "√") ? true : false,
                    IsPK = (reader.GetString(7) == "√") ? true : false,
                    IsNull = (reader.GetString(13) == "√") ? true : false,
                    DefaultVal = reader.GetString(14),
                    ColDescription = reader.GetString(15)
                };
                if (colexist.Contains(col.ColumnName)) continue;
                collist.Add(col);
                colexist.Add(col.ColumnName);
            }
            reader.Close();
            return collist;
		}

        public List<ColumnInfo> GetColumnInfoListSP(string DbName, string TableName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@table_name", SqlDbType.NVarChar,384),
					new SqlParameter("@table_owner", SqlDbType.NVarChar,384),
                    new SqlParameter("@table_qualifier", SqlDbType.NVarChar,384),
                    new SqlParameter("@column_name", SqlDbType.VarChar,100)
            };
            parameters[0].Value = TableName;
            parameters[1].Value = null;
            parameters[2].Value = null;
            parameters[3].Value = null;

            DataSet ds = RunProcedure(DbName, "sp_columns", parameters, "ds");
            int n = ds.Tables.Count;
            if (n > 0)
            {
                DataTable dt = ds.Tables[0];
                int r = dt.Rows.Count;
                DataTable dtkey = CreateColumnTable();
                for (int m = 0; m < r; m++)
                {
                    DataRow nrow = dtkey.NewRow();
                    nrow["colorder"] = dt.Rows[m]["ORDINAL_POSITION"];
                    nrow["ColumnName"] = dt.Rows[m]["COLUMN_NAME"];
                    string tn = dt.Rows[m]["TYPE_NAME"].ToString().Trim();
                    nrow["TypeName"] = (tn == "int identity") ? "int" : tn;
                    nrow["Length"] = dt.Rows[m]["LENGTH"];
                    nrow["Preci"] = dt.Rows[m]["PRECISION"];
                    nrow["Scale"] = dt.Rows[m]["SCALE"];
                    nrow["IsIdentity"] = (tn == "int identity") ? "√" : "";
                    nrow["isPK"] = "";
                    nrow["IsNull"] = (dt.Rows[m]["NULLABLE"].ToString().Trim() == "1") ? "√" : "";
                    nrow["defaultVal"] = dt.Rows[m]["COLUMN_DEF"];
                    nrow["deText"] = dt.Rows[m]["REMARKS"];
                    dtkey.Rows.Add(nrow);
                }
                return CodeCommon.GetColumnInfos(dtkey);
            }
            else
            {
                return null;
            }           
        }

        #endregion

        #region 得到数据库里表的主键 GetKeyName(string DbName,string TableName)

        //创建列信息表
        public DataTable CreateColumnTable()
        {            
            DataTable table = new DataTable();
            DataColumn col;

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "colorder"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "ColumnName"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "TypeName"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "Length"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "Preci"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "Scale"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "IsIdentity"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "isPK"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "IsNull"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "defaultVal"};
            table.Columns.Add(col);

            col = new DataColumn {DataType = Type.GetType("System.String"), ColumnName = "deText"};
            table.Columns.Add(col);

            return table;
        }

        /// <summary>
		/// 得到数据库里表的主键
		/// </summary>
		/// <param name="dbName">库</param>
		/// <param name="tableName">表</param>
		/// <returns></returns>
		public DataTable GetKeyName(string dbName,string tableName)
		{
            DataTable dtkey = CreateColumnTable();
            //DataTable dt = GetColumnInfoList(DbName, TableName);

            List<ColumnInfo> collist = GetColumnInfoList(dbName, tableName);
            DataTable dt = CodeCommon.GetColumnInfoDt(collist);
            DataRow[] rows = dt.Select(" isPK='√' or IsIdentity='√' ");
            foreach (DataRow row in rows)
            {
                DataRow nrow = dtkey.NewRow();
                nrow["colorder"] = row["colorder"];
                nrow["ColumnName"] = row["ColumnName"];
                nrow["TypeName"] = row["TypeName"];
                nrow["Length"] = row["Length"];
                nrow["Preci"] = row["Preci"];
                nrow["Scale"] = row["Scale"];
                nrow["IsIdentity"] = row["IsIdentity"];
                nrow["isPK"] = row["isPK"];
                nrow["IsNull"] = row["IsNull"];
                nrow["defaultVal"] = row["defaultVal"];
                nrow["deText"] = row["deText"];
                dtkey.Rows.Add(nrow);
            }
            return dtkey;

            #region 
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * from ");
            //strSql.Append("( ");

            //strSql.Append("SELECT ");
            //strSql.Append("colorder=C.column_id,");
            //strSql.Append("ColumnName=C.name,");
            //strSql.Append("TypeName=T.name, ");
            //strSql.Append("Length=C.max_length, ");
            //strSql.Append("Preci=C.precision, ");
            //strSql.Append("Scale=C.scale, ");
            //strSql.Append("IsIdentity=CASE WHEN C.is_identity=1 THEN N'√'ELSE N'' END,");
            //strSql.Append("isPK=ISNULL(IDX.PrimaryKey,N''),");

            //strSql.Append("Computed=CASE WHEN C.is_computed=1 THEN N'√'ELSE N'' END, ");
            //strSql.Append("IndexName=ISNULL(IDX.IndexName,N''), ");
            //strSql.Append("IndexSort=ISNULL(IDX.Sort,N''), ");
            //strSql.Append("Create_Date=O.Create_Date, ");
            //strSql.Append("Modify_Date=O.Modify_date, ");

            //strSql.Append("IsNull=CASE WHEN C.is_nullable=1 THEN N'√'ELSE N'' END, ");
            //strSql.Append("defaultVal=ISNULL(D.definition,N''), ");
            //strSql.Append("deText=ISNULL(PFD.[value],N'') ");

            //strSql.Append("FROM sys.columns C ");
            //strSql.Append("INNER JOIN sys.objects O ");
            //strSql.Append("ON C.[object_id]=O.[object_id] ");
            //strSql.Append("AND O.type='U' ");
            //strSql.Append("AND O.is_ms_shipped=0 ");
            //strSql.Append("INNER JOIN sys.types T ");
            //strSql.Append("ON C.user_type_id=T.user_type_id ");
            //strSql.Append("LEFT JOIN sys.default_constraints D ");
            //strSql.Append("ON C.[object_id]=D.parent_object_id ");
            //strSql.Append("AND C.column_id=D.parent_column_id ");
            //strSql.Append("AND C.default_object_id=D.[object_id] ");
            //strSql.Append("LEFT JOIN sys.extended_properties PFD ");
            //strSql.Append("ON PFD.class=1  ");
            //strSql.Append("AND C.[object_id]=PFD.major_id  ");
            //strSql.Append("AND C.column_id=PFD.minor_id ");
            ////strSql.Append("--AND PFD.name='Caption'  -- 字段说明对应的描述名称(一个字段可以添加多个不同name的描述) ");
            //strSql.Append("LEFT JOIN sys.extended_properties PTB ");
            //strSql.Append("ON PTB.class=1 ");
            //strSql.Append("AND PTB.minor_id=0  ");
            //strSql.Append("AND C.[object_id]=PTB.major_id ");
            ////strSql.Append("-- AND PFD.name='Caption'  -- 表说明对应的描述名称(一个表可以添加多个不同name的描述)   ");
            //strSql.Append("LEFT JOIN ");// -- 索引及主键信息
            //strSql.Append("( ");
            //strSql.Append("SELECT  ");
            //strSql.Append("IDXC.[object_id], ");
            //strSql.Append("IDXC.column_id, ");
            //strSql.Append("Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending') ");
            //strSql.Append("WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END, ");
            //strSql.Append("PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END, ");
            //strSql.Append("IndexName=IDX.Name ");
            //strSql.Append("FROM sys.indexes IDX ");
            //strSql.Append("INNER JOIN sys.index_columns IDXC ");
            //strSql.Append("ON IDX.[object_id]=IDXC.[object_id] ");
            //strSql.Append("AND IDX.index_id=IDXC.index_id ");
            //strSql.Append("LEFT JOIN sys.key_constraints KC ");
            //strSql.Append("ON IDX.[object_id]=KC.[parent_object_id] ");
            //strSql.Append("AND IDX.index_id=KC.unique_index_id ");
            //strSql.Append("INNER JOIN  ");// 对于一个列包含多个索引的情况,只显示第1个索引信息
            //strSql.Append("( ");
            //strSql.Append("SELECT [object_id], Column_id, index_id=MIN(index_id) ");
            //strSql.Append("FROM sys.index_columns ");
            //strSql.Append("GROUP BY [object_id], Column_id ");
            //strSql.Append(") IDXCUQ ");
            //strSql.Append("ON IDXC.[object_id]=IDXCUQ.[object_id] ");
            //strSql.Append("AND IDXC.Column_id=IDXCUQ.Column_id ");
            //strSql.Append("AND IDXC.index_id=IDXCUQ.index_id ");
            //strSql.Append(") IDX ");
            //strSql.Append("ON C.[object_id]=IDX.[object_id] ");
            //strSql.Append("AND C.column_id=IDX.column_id  ");
            //strSql.Append("WHERE O.name=N'" + TableName + "' ");
            
            //strSql.Append(") Keyname ");
            //strSql.Append(" where isPK='√' or (IsIdentity='√' or colorder=1)");
            //return Query(DbName, strSql.ToString()).Tables[0];
            #endregion

        }
		#endregion

		#region 得到数据表里的数据 GetTabData(string DbName,string TableName)

		/// <summary>
		/// 得到数据表里的数据
		/// </summary>
		/// <param name="dbName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public DataTable GetTabData(string dbName,string tableName)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select * from [" + tableName + "]");
			return Query(dbName,strSql.ToString()).Tables[0];
		}

        /// <summary>
        /// 根据SQL查询得到数据表里的数据
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public DataTable GetTabDataBySQL(string dbName, string strSQL)
        {
            return Query(dbName, strSQL).Tables[0];
        }
		#endregion

		#region 数据库属性操作
		/// <summary>
		/// 修改表名称
		/// </summary>
		/// <param name="oldName"></param>
		/// <param name="newName"></param>
		/// <returns></returns>
		public bool RenameTable(string dbName,string oldName,string newName)
		{
			try
			{				
				SqlCommand dbCommand =OpenDB(dbName);				
				dbCommand.CommandText="EXEC sp_rename '"+oldName+"', '"+newName+"'";
				dbCommand.ExecuteNonQuery();
				return true;
			}
			catch(System.Exception ex)
			{
                LogHelper.WriteException(ex);	
				return false;
			}			
		}
		
		/// <summary>
		/// 删除表
		/// </summary>	
		public bool DeleteTable(string dbName,string tableName)
		{
			try
			{				
				SqlCommand dbCommand =OpenDB(dbName);				
				dbCommand.CommandText="DROP TABLE ["+tableName+"]";
				dbCommand.ExecuteNonQuery();
				return true;
			}
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                return false;
            }	
		}

		/// <summary>
		/// 得到版本号
		/// </summary>
		/// <returns></returns>
		public string GetVersion()
		{
			try
			{				
				string strSql="execute master..sp_msgetversion ";//select @@version
				return Query("master",strSql).Tables[0].Rows[0][0].ToString();
			}
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);	
				return "";
			}	
		}

		#endregion       
    }
}
