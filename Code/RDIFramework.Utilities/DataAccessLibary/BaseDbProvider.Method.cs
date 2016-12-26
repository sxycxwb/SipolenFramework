//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// BaseDbProvider
    /// 数据库访问层基础类。
    /// 
    /// 修改纪录
    ///     2015.10.20 版本：3.0 EricHu 新增分页支持。
    ///     2014.06.06 版本：2.8 EricHu 拆分为partial类。
    ///     2013.02.20 版本：2.7 EricHu 重新排版代码。
    ///     2012.01.29 版本：2.5 EricHu 实现IDisposable接口。
    ///     2011.01.13 版本：2.2 EricHu 改进为支持静态方法，不用数据库Open、Close的方式，AutoOpenClose开关。
    ///		2010.06.12 版本：2.0 EricHu 无法彻底释放、并发时出现异常问题解决。
    ///		2010.03.14 版本：1.0 EricHu 改进ConnectionString。
    /// 
    /// 版本：2.8
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.03.14</date>
    /// </author> 
    /// </summary>
    public abstract partial class BaseDbProvider
	{
		#region public virtual IDataReader ExecuteReader(string commandText) 执行查询
		/// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <returns>结果集流</returns>
		public virtual IDataReader ExecuteReader(string commandText)
		{
            return ExecuteReader(commandText, (IDbDataParameter[])null, CommandType.Text);
		}
		#endregion

		#region public virtual IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters); 执行查询
		/// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>结果集流</returns>
		public virtual IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters)
		{
            return this.ExecuteReader(commandText, dbParameters, CommandType.Text);
		}
		#endregion

        #region public virtual IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 执行查询
        /// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>结果集流</returns>
        public virtual IDataReader ExecuteReader(string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            // 自动打开
            if (this.DbConnection == null || this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
                this.AutoOpenClose = true;
            }    

			this.dbCommand = this.DbConnection.CreateCommand();
            this.DbCommand.CommandTimeout = this.DbConnection.ConnectionTimeout;
			this.dbCommand.CommandText = commandText;
			this.dbCommand.CommandType = commandType;
			if (this.dbTransaction != null)
			{
				this.dbCommand.Transaction = this.dbTransaction;
			}

			if (dbParameters != null)
			{
				this.dbCommand.Parameters.Clear();
				for (int i = 0; i < dbParameters.Length; i++)
				{
					if (dbParameters[i] != null)
					{
						//this.dbCommand.Parameters.Add(dbParameters[i]);
                        this.dbCommand.Parameters.Add(((ICloneable)dbParameters[i]).Clone());
					}
				}
			}

			// 这里要关闭数据库才可以的
			DbDataReader dbDataReader = null;
			dbDataReader = this.AutoOpenClose ? this.dbCommand.ExecuteReader(CommandBehavior.CloseConnection) : this.dbCommand.ExecuteReader();

			// 写入日志
			this.WriteLog(commandText);

			return dbDataReader;
		}
		#endregion


		#region public virtual int ExecuteNonQuery(string commandText) 执行查询, SQL BUILDER 用了这个东西？参数需要保存, 不能丢失.
		/// <summary>
		/// 执行查询, SQL BUILDER 用了这个东西？参数需要保存, 不能丢失.
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <returns>影响行数</returns>
		public virtual int ExecuteNonQuery(string commandText)
		{
            return this.ExecuteNonQuery(this.dbTransaction, commandText, (IDbDataParameter[])null, CommandType.Text);
		}
		#endregion

		#region public virtual int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters) 执行查询
		/// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>影响行数</returns>
		public virtual int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters)
		{
            return this.ExecuteNonQuery(commandText, dbParameters, CommandType.Text);
		}
		#endregion

        #region public virtual int ExecuteNonQuery(string commandText, CommandType commandType) 执行查询
        /// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>影响行数</returns>
        public virtual int ExecuteNonQuery(string commandText, CommandType commandType)
		{
            return this.ExecuteNonQuery(this.dbTransaction, commandText, (IDbDataParameter[])null, commandType);
		}
		#endregion

        #region public virtual int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 执行查询
        /// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>影响行数</returns>
        public virtual int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            return this.ExecuteNonQuery(this.dbTransaction, commandText, dbParameters, commandType);
		}
		#endregion

        #region public virtual int ExecuteNonQuery(IDbTransaction transaction, string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 执行查询
        /// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="transaction">数据库事务</param>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>影响行数</returns>
        public virtual int ExecuteNonQuery(IDbTransaction transaction, string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            if (this.DbConnection == null || this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
                this.AutoOpenClose = true;
            }    

			this.dbCommand = this.DbConnection.CreateCommand();
            this.dbCommand.CommandTimeout = this.DbConnection.ConnectionTimeout;
			this.dbCommand.CommandText = commandText;
			this.dbCommand.CommandType = commandType;
			if (this.dbTransaction != null)
			{
				this.dbCommand.Transaction = this.dbTransaction;
			}
			if (dbParameters != null)
			{
			    this.dbCommand.Parameters.Clear();
                
                if (commandType == CommandType.StoredProcedure)
                {                    
                    foreach (IDbDataParameter t in dbParameters)
                    {
                        this.dbCommand.Parameters.Add(t);
                    }
                }
                else
                {  
                    foreach (DbParameter parameter in dbParameters) 
                    {
                        this.dbCommand.Parameters.Add(((ICloneable)parameter).Clone());
                    }
                }			   
			}

            int returnValue = this.dbCommand.ExecuteNonQuery();
            
			// 自动关闭
			if (this.AutoOpenClose)
			{
				this.Close();
			}
			else
			{
				this.dbCommand.Parameters.Clear();
			}
			
			// 写入日志
			this.WriteLog(commandText);

			return returnValue;
		}
		#endregion

     
        #region private void SetBackParamValue(IDbDataParameter[] dbParameters)
        /// <summary>
        /// 设置返回值
        /// </summary>
        /// <param name="dbParameters"></param>
        private void SetBackParamValue(IDbDataParameter[] dbParameters)
        {
            for (int i = 0; dbParameters != null && i <= dbParameters.Length - 1; i++)
            {
                if (dbParameters[i].Direction != ParameterDirection.Input)
                {
                    dbParameters[i].Value = dbCommand.Parameters[i].Value;
                }
            }
        }
        #endregion

		#region public virtual object ExecuteScalar(string commandText) 执行查询
		/// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <returns>object</returns>
		public virtual object ExecuteScalar(string commandText)
		{
            return this.ExecuteScalar(commandText, null, CommandType.Text);
		}
		#endregion

		#region public virtual object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters) 执行查询
		/// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>Object</returns>
		public virtual object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters)
		{
            return this.ExecuteScalar(commandText, dbParameters, CommandType.Text);
		}
		#endregion

        #region public virtual object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 执行查询
        /// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>Object</returns>
        public virtual object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            return this.ExecuteScalar(this.dbTransaction, commandText, dbParameters, commandType);
		}
		#endregion

        #region public virtual object ExecuteScalar(IDbTransaction transaction, string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 执行查询
        /// <summary>
		/// 执行查询
		/// </summary>
		/// <param name="transaction">数据库事务</param>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>Object</returns>
        public virtual object ExecuteScalar(IDbTransaction transaction, string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            if (this.DbConnection == null || this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
                this.AutoOpenClose = true;
            }

			this.dbCommand = this.DbConnection.CreateCommand();
            this.dbCommand.CommandTimeout = this.DbConnection.ConnectionTimeout;
			this.dbCommand.CommandText = commandText;
			this.dbCommand.CommandType = commandType;
			if (this.dbTransaction != null)
			{
				this.dbCommand.Transaction = this.dbTransaction;
			}
			if (dbParameters != null)
			{
				this.dbCommand.Parameters.Clear();
				for (int i = 0; i < dbParameters.Length; i++)
				{
					if (dbParameters[i] != null)
					{
						//this.dbCommand.Parameters.Add(dbParameters[i]);
                        this.dbCommand.Parameters.Add(((ICloneable)dbParameters[i]).Clone());
					}
				}
			}
			object returnValue = this.dbCommand.ExecuteScalar();
            SetBackParamValue(dbParameters);
			// 自动关闭
			if (this.AutoOpenClose)
			{
				this.Close();
			}
			else
			{
				this.dbCommand.Parameters.Clear();
			}

			// 写入日志
			this.WriteLog(commandText);
			return returnValue;
		}
		#endregion


		#region public virtual DataTable Fill(string commandText) 填充数据表
		/// <summary>
		/// 填充数据表
		/// </summary>
		/// <param name="commandText">查询</param>
		/// <returns>数据表</returns>
		public virtual DataTable Fill(string commandText)
		{
            DataTable dataTable = new DataTable("RDIFramework");
            return this.Fill(dataTable, commandText, (IDbDataParameter[])null, CommandType.Text);
		}
		#endregion

		#region public virtual DataTable Fill(DataTable dataTable, string commandText) 填充数据表
		/// <summary>
		/// 填充数据表
		/// </summary>
		/// <param name="dataTable">目标数据表</param>
		/// <param name="commandText">查询</param>
		/// <returns>数据表</returns>
		public virtual DataTable Fill(DataTable dataTable, string commandText)
		{
            return this.Fill(dataTable, commandText, (IDbDataParameter[])null, CommandType.Text);
		}
		#endregion

		#region public virtual DataTable Fill(string commandText, IDbDataParameter[] dbParameters) 填充数据表
		/// <summary>
		/// 填充数据表
		/// </summary>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>数据表</returns>
		public virtual DataTable Fill(string commandText, IDbDataParameter[] dbParameters)
		{
            DataTable dataTable = new DataTable("RDIFramework");
            return this.Fill(dataTable, commandText, dbParameters, CommandType.Text);
		}
		#endregion

		#region public virtual DataTable Fill(DataTable dataTable, string commandText, IDbDataParameter[] dbParameters) 填充数据表
		/// <summary>
		/// 填充数据表
		/// </summary>
		/// <param name="dataTable">目标数据表</param>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>数据表</returns>
		public virtual DataTable Fill(DataTable dataTable, string commandText, IDbDataParameter[] dbParameters)
		{
            return this.Fill(dataTable, commandText, dbParameters, CommandType.Text);
		}
		#endregion

        #region public virtual DataTable Fill(string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 填充数据表
        /// <summary>
		/// 填充数据表
		/// </summary>
		/// <param name="commandText">sql查询</param>
        /// <param name="commandType">命令分类</param>
        /// <param name="dbParameters">参数集</param>
		/// <returns>数据表</returns>
        public virtual DataTable Fill(string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            DataTable dataTable = new DataTable("RDIFramework");
            return this.Fill(dataTable, commandText, dbParameters, commandType);
		}
		#endregion

        #region public virtual DataTable Fill(DataTable dataTable, string commandText, IDbDataParameter[] dbParameters, CommandType commandType) 填充数据表
        /// <summary>
		/// 填充数据表
		/// </summary>
		/// <param name="dataTable">目标数据表</param>
		/// <param name="commandText">sql查询</param>
		/// <param name="dbParameters">参数集</param>
        /// <param name="commandType">命令分类</param>
        /// <returns>数据表</returns>
        public virtual DataTable Fill(DataTable dataTable, string commandText, IDbDataParameter[] dbParameters, CommandType commandType)
		{
            if (this.DbConnection == null || this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
                this.AutoOpenClose = true;
            }       

			using (this.dbCommand = this.DbConnection.CreateCommand())
			{
				this.dbCommand.CommandTimeout = this.DbConnection.ConnectionTimeout;
				this.dbCommand.CommandText = commandText;
				this.dbCommand.CommandType = commandType;
				if (this.InTransaction)
				{
					// 这个不这么写，也不行，否则运行不能通过的
					this.dbCommand.Transaction = this.dbTransaction;
				}
				this.dbDataAdapter = this.GetInstance().CreateDataAdapter();
				this.dbDataAdapter.SelectCommand = this.dbCommand;
				if ((dbParameters != null) && (dbParameters.Length > 0))
				{
                    for (int i = 0; i < dbParameters.Length; i++)
                    {
                        if (dbParameters[i] != null)
                        {
                            this.dbCommand.Parameters.Add(((ICloneable)dbParameters[i]).Clone());
                        }
                    }
				}
				this.dbDataAdapter.Fill(dataTable);
                SetBackParamValue(dbParameters);
				this.dbDataAdapter.SelectCommand.Parameters.Clear();
			}

			// 自动关闭
			if (this.AutoOpenClose)
			{
				this.Close();
			}

			// 写入日志
			//this.WriteLog(commandText);
			return dataTable;
		}
		#endregion

	
        #region public virtual DataSet Fill(DataSet dataSet, string commandText, string tableName) 填充数据权限
		/// <summary>
		/// 填充数据权限
		/// </summary>
		/// <param name="dataSet">目标数据权限</param>
		/// <param name="commandText">查询</param>
		/// <param name="tableName">填充表</param>
		/// <returns>数据权限</returns>
		public virtual DataSet Fill(DataSet dataSet, string commandText, string tableName)
		{
			return this.Fill(dataSet, CommandType.Text, commandText, tableName, null);
		}
		#endregion

		#region public virtual DataSet Fill(DataSet dataSet, string commandText, string tableName, IDbDataParameter[] dbParameters) 填充数据权限
		/// <summary>
		/// 填充数据权限
		/// </summary>
		/// <param name="dataSet">数据权限</param>
		/// <param name="commandText">sql查询</param>
		/// <param name="tableName">填充表</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>数据权限</returns>
		public virtual DataSet Fill(DataSet dataSet, string commandText, string tableName, IDbDataParameter[] dbParameters)
		{
			return this.Fill(dataSet, CommandType.Text, commandText, tableName, dbParameters);
		}
		#endregion

		#region public virtual DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, IDbDataParameter[] dbParameters) 填充数据权限
		/// <summary>
		/// 填充数据权限
		/// </summary>
		/// <param name="dataSet">数据权限</param>
		/// <param name="commandType">命令分类</param>
		/// <param name="commandText">sql查询</param>
		/// <param name="tableName">填充表</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>数据权限</returns>
		public virtual DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, IDbDataParameter[] dbParameters)
		{
            if (this.DbConnection == null || this.DbConnection.State == ConnectionState.Closed)
            {
                this.Open();
                this.AutoOpenClose = true;
            }
            
			using (this.dbCommand = this.DbConnection.CreateCommand())
			{
                this.dbCommand.CommandTimeout = this.DbConnection.ConnectionTimeout;
				this.dbCommand.CommandText = commandText;
				this.dbCommand.CommandType = commandType;
                if (this.dbTransaction != null)
                {
                    this.dbCommand.Transaction = this.dbTransaction;
                }

				if ((dbParameters != null) && (dbParameters.Length > 0))
				{
                    for (int i = 0; i < dbParameters.Length; i++)
                    {
                        if (dbParameters[i] != null)
                        {
                            this.dbCommand.Parameters.Add(((ICloneable)dbParameters[i]).Clone());
                        }
                    }
				}

				this.dbDataAdapter = this.GetInstance().CreateDataAdapter();
				this.dbDataAdapter.SelectCommand = this.dbCommand;
				this.dbDataAdapter.Fill(dataSet, tableName);
                SetBackParamValue(dbParameters);
				if (this.AutoOpenClose)
				{
					this.Close();
				}
				else
				{
					this.dbDataAdapter.SelectCommand.Parameters.Clear();
				}
			}
			
			// 写入日志
			//this.WriteLog(commandText);
			return dataSet;
		}
		#endregion


		#region public virtual int ExecuteProcedure(string procedureName) 执行存储过程
		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="procedureName">存储过程</param>
		/// <returns>int</returns>
		public virtual int ExecuteProcedure(string procedureName)
		{
            return this.ExecuteNonQuery(procedureName, null, CommandType.StoredProcedure);
		}
		#endregion

		#region public virtual int ExecuteProcedure(string procedureName, IDbDataParameter[] dbParameters) 执行代参数的存储过程
		/// <summary>
		/// 执行代参数的存储过程
		/// </summary>
		/// <param name="procedureName">存储过程名</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>影响行数</returns>
		public virtual int ExecuteProcedure(string procedureName, IDbDataParameter[] dbParameters)
		{
            return this.ExecuteNonQuery(procedureName, dbParameters, CommandType.StoredProcedure);
		}
		#endregion

		#region public virtual DataTable ExecuteProcedureForDataTable(string procedureName, string tableName, IDbDataParameter[] dbParameters) 执行存储过程返回数据表
		/// <summary>
		/// 执行存储过程返回数据表
		/// </summary>
		/// <param name="procedureName">存储过程</param>
		/// <param name="tableName">填充表</param>
		/// <param name="dbParameters">参数集</param>
		/// <returns>数据权限</returns>
		public virtual DataTable ExecuteProcedureForDataTable(string procedureName, string tableName, IDbDataParameter[] dbParameters)
		{
			DataTable dataTable = new DataTable(tableName);
            this.Fill(dataTable, procedureName, dbParameters, CommandType.StoredProcedure);
			return dataTable;
		}
		#endregion	

        #region public virtual DataTable GetDTByPage(out int recordCount,string tableName, int pageIndex, int pageSize, string conditions, string orderby) Oracle/SqlServer 获取分页数据
        /// <summary>
        /// Oracle/SqlServer 获取分页数据
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="tableName">数据来源表名</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示多少条</param>
        /// <param name="conditions">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns>数据表</returns>
        public virtual DataTable GetDTByPage(out int recordCount, string tableName, int pageIndex, int pageSize, string conditions, string orderby)
        {
            recordCount = 0;

            string sqlQuery = " SELECT COUNT(*) " + " FROM " + tableName; 
            if (tableName.IndexOf("SELECT", System.StringComparison.OrdinalIgnoreCase) >= 0)
            {
                if (tableName.IndexOf("ORDER BY", System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    tableName = tableName.Substring(0, tableName.IndexOf("ORDER BY", System.StringComparison.OrdinalIgnoreCase) - 1);
                }
                tableName = "(" + tableName + ") AS T ";
                sqlQuery = " SELECT COUNT(*) " + " FROM " + tableName;
            }            

            if (!string.IsNullOrEmpty(conditions))
            {
                sqlQuery += " WHERE " + conditions;
            }
            object returnObject = this.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                recordCount =int.Parse(returnObject.ToString());
            }

            var sqlStart = ((pageIndex - 1) * pageSize + 1).ToString();
            var sqlEnd = (pageIndex * pageSize).ToString();

            if (!string.IsNullOrEmpty(conditions))
            {
                conditions = "WHERE " + conditions;
            }

            sqlQuery = string.Empty;

            if (this.CurrentDbType == CurrentDbType.Oracle)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT T.*, ROWNUM RN FROM (SELECT * FROM {0} {1} ORDER BY {2}) T WHERE ROWNUM <= {3}) WHERE RN > {4}"
                    , tableName, conditions, orderby, sqlEnd, sqlStart);
            }
            if (this.CurrentDbType == CurrentDbType.SqlServer)
            {
                sqlQuery = string.Format("SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {0}) AS RowIndex, * FROM {1} {2}) AS PageTable WHERE RowIndex BETWEEN {3} AND {4} ORDER BY {5}"
                    , orderby, tableName, conditions, sqlStart, sqlEnd, orderby);
            }
            var dataTable = new DataTable(tableName);
            dataTable = this.Fill(sqlQuery);
            return dataTable;
        }
        #endregion

        /// <summary>
        /// 利用Net SqlBulkCopy 批量导入数据库,速度超快
        /// </summary>
        /// <param name="dataTable">源内存数据表</param>
        public virtual void SqlBulkCopyData(DataTable dataTable)
        { 
            
        }

        /// <summary>
        /// 得到分页数据(用存储过程实现)
        /// </summary>
        /// <param name="dbParameters">存储过程的相关参数</param>
        /// <returns>分页后的数据（DataTable）</returns>
        public virtual DataTable GetPageList(IDbDataParameter[] dbParameters)
        {
            return ExecuteProcedureForDataTable("pGetPageData", "pageDataTable", dbParameters);
        }
	}
}