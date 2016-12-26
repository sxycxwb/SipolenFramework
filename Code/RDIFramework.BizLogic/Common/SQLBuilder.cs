//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2009 ,EricHu. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RDIFramework.BizLogic
{
	using RDIFramework.Utilities;

	/// <summary>
	/// SQLBuilder
	/// SQL语句生成器（适合简单的添加、删除、更新等语句，可以写出编译时强类型检查的效果）
	/// 
	/// 修改记录
    ///     
	///     2014.03.20 版本: 2.8 EricHu 增加对TopN、OrderBy的支持。
	///     2013.06.20 版本：3.7 EricHu	支持Oracle序列功能改进。
	///     2012.06.13 版本：2.5 EricHu	改进为支持静态方法，不用数据库Open、Close的方式，AutoOpenClose开关。
	///     2011.08.30 版本：2.3 EricHu	确认 BeginSelect 方法的正确性。
	///     2011.08.29 版本：2.2 EricHu	改进 public string SetWhere(string targetFiled, Object[] targetValue) 方法。
	///     2011.06.29 版本：2.1 EricHu	修正 BeginSelect、BeginInsert、BeginUpdate、BeginDelete。
	///     2010.05.07 版本：2.0 EricHu	改进为多种数据库的支持类型。
	///     2010.05.20 版本：1.8 EricHu	改进了OleDbCommand使其可以在多个事件穿插使用。
	///     2010.02.22 版本：1.7 EricHu	改进了OleDbCommand使其可以在多个事件穿插使用。
	///		2010.02.05 版本：1.6 EricHu	重新调整主键的规范化。
	///		2010.01.20 版本：1.5 EricHu   修改主键,货币型的插入。
	///		2009.12.29 版本：1.4 EricHu   修改主键,将公式的功能完善,提高效率。
	///		2009.12.29 版本：1.3 EricHu   修改主键,将公式的功能完善,提高效率。
	///		2009.08.08 版本：1.2 EricHu   修改主键，修改格式。
	///		2009.12.30 版本：1.1 EricHu   数据库连接进行优化。
	///		2009.12.29 版本：1.0 EricHu   主键创建。
	///		
	/// 版本：3.0
	///
	/// <author>
	///		<name>EricHu</name>
    ///		<date>2009.12.29</date>
	/// </author> 
	/// </summary>
	public partial class SQLBuilder
	{
		// 是否采用自增量的方式
		private bool Identity = false;
		// 是否需要返回主键
		private bool ReturnId = true;

		private string PrimaryKey = "ID";

		private DbOperation sqlOperation = DbOperation.Update;
		
		private string CommandText       = string.Empty;
		
		private string TableName	    = string.Empty;
		private string InsertValue	    = string.Empty;
		private string InsertField	    = string.Empty;
		private string UpdateSql	    = string.Empty;
		private string SelectSql        = string.Empty;
		private string WhereSql		    = string.Empty;
        private string ProcedureName    = string.Empty;//存储过程名称

        /// <summary>
        /// 获取前几条数据
        /// </summary>
        private int? TopN = null;

        /// <summary>
        /// 排序字段
        /// </summary>
        private string OrderBy = string.Empty;

        private DbOperationType OperationType = DbOperationType.NOACTION;//操作类型
		private IDbProvider DBProvider = null;

		private Dictionary<String, Object> parameters = new Dictionary<String, Object>();
		
		private SQLBuilder()
		{
			this.parameters = new Dictionary<String, Object>();
		}

		public SQLBuilder(IDbProvider dbProvider): this()
		{
			DBProvider = dbProvider;
		}

		public SQLBuilder(IDbProvider dbProvider, bool identity)
			: this(dbProvider)
		{
			Identity = identity;
		}

		public SQLBuilder(IDbProvider dbProvider, bool identity, bool returnId)
			: this(dbProvider)
		{
			Identity = identity;
			ReturnId = returnId;
		}

		#region private void PrepareCommand()
		/// <summary>
		/// 获得数据库连接
		/// </summary>
		private void PrepareCommand()
		{
			// 写入调试信息
			#if (DEBUG)
				int milliStart = Environment.TickCount;
				Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
			#endif

			this.sqlOperation       = DbOperation.Update;
			this.CommandText        = string.Empty;
			this.TableName			= string.Empty;
			this.InsertValue		= string.Empty;
			this.InsertField		= string.Empty;
			this.UpdateSql			= string.Empty;
			this.WhereSql			= string.Empty;
            this.ProcedureName      = string.Empty;
            this.OperationType = DbOperationType.NOACTION;
			// 判断是否为空，要区别静态方法与动态调用方法
			if (!DBProvider.AutoOpenClose)
			{
				DBProvider.GetDbCommand().Parameters.Clear();
			}
			
			// 写入调试信息
			#if (DEBUG)
				int milliEnd = Environment.TickCount;
				Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
			#endif
		}
		#endregion

		#region public void BeginSelect(string tableName)
		/// <summary>
		/// 开始查询
		/// </summary>
		/// <param name="tableName">目标表</param>
		public void BeginSelect(string tableName)
		{
			Begin(tableName, DbOperation.Select);
		}
		#endregion

        #region public void SelectTop(int? topN) 
        /// <summary>
        /// 获取前几条数据
        /// </summary>
        /// <param name="topN">几条</param>
        public void SelectTop(int? topN)
        {
            this.TopN = topN;
        }
        #endregion

        #region public void BeginInsert(string tableName)
        /// <summary>
		/// 开始插入
		/// </summary>
		/// <param name="tableName">目标表</param>
		public void BeginInsert(string tableName)
		{
			Begin(tableName, DbOperation.Insert);
		}
		#endregion

		#region public void BeginInsert(string tableName, bool identity)
		/// <summary>
		/// 开始插入
		/// </summary>
		/// <param name="tableName">目标表</param>
		/// <param name="identity">自增量方式</param>
		public void BeginInsert(string tableName, bool identity)
		{
			Identity = identity;
			Begin(tableName, DbOperation.Insert);
		}
		#endregion

		#region public void BeginInsert(string tableName, string primaryKey)
		/// <summary>
		/// 开始插入
		/// </summary>
		/// <param name="tableName">目标表</param>
		/// <param name="primaryKey">主键</param>
		public void BeginInsert(string tableName, string primaryKey)
		{
			PrimaryKey = primaryKey;
			Begin(tableName, DbOperation.Insert);
		}
		#endregion

		#region public BeginUpdate(string tableName)
		/// <summary>
		/// 开始更新
		/// </summary>
		/// <param name="tableName">目标表</param>
		public void BeginUpdate(string tableName)
		{
			Begin(tableName, DbOperation.Update);
		}
		#endregion

		#region public void BeginDelete(string tableName)
		/// <summary>
		/// 开始删除
		/// </summary>
		/// <param name="tableName">目标表</param>
		public void BeginDelete(string tableName)
		{
			Begin(tableName, DbOperation.Delete);
		}
		#endregion

        #region public void BeginExecProcedure(string procedureName,DbOperationType operationType)
        /// <summary>
        /// 开始存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="operationType">操作类型</param>
        public void BeginExecProcedure(string procedureName,DbOperationType operationType)
        {
            this.OperationType = operationType;
            Begin(procedureName, DbOperation.ExecProcedure);
        }
        #endregion

        #region public string SetOrderBy(string orderBy) 设置排序顺序
        /// <summary>
        /// 设置排序顺序
        /// </summary>
        /// <param name="orderBy">排序顺序</param>
        /// <returns>排序</returns>
        public string SetOrderBy(string orderBy)
        {
            if (string.IsNullOrEmpty(OrderBy))
            {
                OrderBy = " ORDER BY ";
            }
            this.OrderBy += orderBy;
            return this.OrderBy;
        }

        /// <summary>
        /// 随机设置排序顺序
        /// </summary>
        /// <returns>排序语句</returns>
        public string SetOrderByRandom()
        {
            if (string.IsNullOrEmpty(OrderBy))
            {
                OrderBy = " ORDER BY ";
            }
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.Oracle:
                    this.OrderBy += " DBMS_RANDOM.VALUE()";
                    break;
                case CurrentDbType.SqlServer:
                case CurrentDbType.Access:
                    this.OrderBy += " NEWID()";
                    break;
                case CurrentDbType.MySql:
                    this.OrderBy += " NEWID()";
                    break;
            }
            return this.OrderBy;
        }
        #endregion

        #region public DataTable EndSelect()
        /// <summary>
        /// 结束查询
        /// </summary>
        /// <returns>影响行数</returns>
        public DataTable EndSelect()
        {
            var dt = new DataTable(this.TableName);
            if (this.TopN != null)
            {
                switch (DBProvider.CurrentDbType)
                {
                    case CurrentDbType.Oracle:
                        // 这里还需要把条件进行优化
                        this.CommandText = "SELECT * FROM " + this.TableName + " WHERE ROWNUM <= " + this.TopN.ToString() + this.OrderBy;
                        break;
                    case CurrentDbType.SqlServer:
                    case CurrentDbType.Access:
                        this.CommandText = "SELECT TOP " + this.TopN.ToString() + " * FROM " + this.TableName + this.WhereSql + this.OrderBy;
                        break;
                    case CurrentDbType.MySql:
                        this.OrderBy += " NEWID()";
                        break;
                }
            }
            else
            {
                this.CommandText = "SELECT * FROM " + this.TableName + this.WhereSql + this.OrderBy;
            }

            // 参数进行规范化
            DBProvider.Fill(dt, this.CommandText, this.parameters.Keys.Select(key => DBProvider.MakeParameter(key, this.parameters[key])).ToArray());
            // 清除查询参数
            this.parameters.Clear();
            return dt;
        }
        #endregion

		#region public int EndInsert()
		/// <summary>
		/// 结束插入
		/// </summary>
		/// <returns>影响行数</returns>
		public int EndInsert()
		{
			return this.Execute();
		}
		#endregion

		#region public int EndUpdate()
		/// <summary>
		/// 结束更新
		/// </summary>
		/// <returns>影响行数</returns>
		public int EndUpdate()
		{
			return this.Execute();
		}
		#endregion

		#region public int EndDelete()
		/// <summary>
		/// 结束删除
		/// </summary>
		/// <returns>影响行数</returns>
		public int EndDelete()
		{
			return this.Execute();
		}
		#endregion

        #region public object EndExecProcedure()
        /// <summary>
        /// 结束存储过程
        /// </summary>
        /// <returns></returns>
        public object EndExecProcedure()
        { 
            return this.ExecuteProcedure();
        }
        #endregion

        #region private void Begin(string tableName, DbOperation dbOperation)
        /// <summary>
		/// 开始查询语句
		/// </summary>
		/// <param name="tableName">目标表</param>
		/// <param name="dbOperation">语句操作类别</param>
		private void Begin(string tableName, DbOperation dbOperation)
		{
			// 写入调试信息
			#if (DEBUG)
				int milliStart = Environment.TickCount;
				Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
			#endif
			
			this.PrepareCommand();
            if (dbOperation == DbOperation.ExecProcedure)
            {
                this.ProcedureName = tableName;
            }
            else
            {
                this.TableName = tableName;
            }
			this.sqlOperation = dbOperation;

			// 写入调试信息
			#if (DEBUG)
				int milliEnd = Environment.TickCount;
				Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
			#endif
		}
		#endregion

		#region public void SetFormula(string targetFiled, string formula)
		/// <summary>
		/// 设置公式
		/// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="formula">公式</param>
		public void SetFormula(string targetFiled, string formula)
		{
			string relation = " = ";
			this.SetFormula(targetFiled, formula, relation);
		}
		#endregion

		#region public void SetFormula(string targetFiled, string formula, string relation)
		/// <summary>
		/// 设置公式
		/// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="formula">公式</param>
        /// <param name="relation">关系</param>
		public void SetFormula(string targetFiled, string formula, string relation)
		{
			if (sqlOperation == DbOperation.Insert)
			{
				InsertField += targetFiled + ", ";
				InsertValue += formula + ", ";
			}
			if (sqlOperation == DbOperation.Update)
			{
				UpdateSql += targetFiled + relation + formula + ", ";
			}
		}
		#endregion

		#region public void SetDBNow(string targetFiled)
		/// <summary>
		/// 设置为当前时间
		/// </summary>
        /// <param name="targetFiled">目标字段</param>
		public void SetDBNow(string targetFiled)
		{
			if (sqlOperation == DbOperation.Insert)
			{
				InsertField += targetFiled + ", ";
				InsertValue += DBProvider.GetDBNow() + ", ";
			}
			if (sqlOperation == DbOperation.Update)
			{
				UpdateSql += targetFiled + " = " + DBProvider.GetDBNow() + ", ";
			}
            //if (sqlOperation == DbOperation.ExecProcedure)
            //{
            //    this.AddParameter(targetFiled, DBProvider.GetDBNow());
            //}
		}
		#endregion

		#region public void SetNull(string targetFiled)
		/// <summary>
		/// 设置为Null值
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		public void SetNull(string targetFiled)
		{
			this.SetValue(targetFiled, null);
		}
		#endregion

		#region public void SetValue(string targetFiled, object targetValue)

	    /// <summary>
	    /// 设置值
	    /// </summary>
	    /// <param name="targetFiled">目标字段</param>
	    /// <param name="targetValue">值</param>
	    /// <param name="targetFiledName"></param>
	    public void SetValue(string targetFiled, object targetValue, string targetFiledName = null)
		{
			if (targetFiledName == null)
			{
				targetFiledName = targetFiled;
			}
			switch (this.sqlOperation)
			{
				case DbOperation.Update:
					if (targetValue == null)
					{
						this.UpdateSql += targetFiled + " = Null, ";
					}
					else
					{
						if (targetValue.ToString().Length > 0)
						{
							// 判断数据库连接类型
							this.UpdateSql += targetFiled + " = " + DBProvider.GetParameter(targetFiledName) + ", ";
						    this.AddParameter(targetFiledName, targetValue);
						}
						else
						{
							this.UpdateSql += targetFiled + " = '', ";
						}
					}
					break;
				case DbOperation.Insert:
					if (DBProvider.CurrentDbType == CurrentDbType.SqlServer)
					{
						if (this.Identity && targetFiled == this.PrimaryKey)
						{
							// 自增量，不需要赋值
						}
						else
						{
							this.InsertField += targetFiled + ", ";
						}
					}
					else
					{
						this.InsertField += targetFiled + ", ";
					}
					if (targetValue == null)
					{
						if (DBProvider.CurrentDbType == CurrentDbType.SqlServer)
						{
							if (this.Identity && targetFiled == this.PrimaryKey)
							{
								// 自增量，不需要赋值
							}
							else
							{
								this.InsertValue += " Null, ";
							}
						}
						else
						{
							this.InsertValue += " Null, ";
						}
					}
					else
					{
						if (this.Identity && targetFiled == this.PrimaryKey && DBProvider.CurrentDbType == CurrentDbType.SqlServer)
						{
							// 自增量，不需要赋值
						}
						else
						{
							this.InsertValue += DBProvider.GetParameter(targetFiledName) + ", ";
							this.AddParameter(targetFiledName, targetValue);
						}
					}
					break;
                case DbOperation.ExecProcedure:
                    this.AddParameter(targetFiledName, targetValue);
                    break;
			}
		}
		#endregion

        #region SetValue public void SetValue(KeyValuePair<string, object> parameter)
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="parameter">目标字段，值</param>
        public void SetValue(KeyValuePair<string, object> parameter)
        {
            this.SetValue(parameter.Key, parameter.Value, parameter.Key);
        }
        #endregion

		#region private void AddParameter(string targetFiled, object targetValue)
		/// <summary>
		/// 添加参数
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		/// <param name="targetValue">值</param>
		private void AddParameter(string targetFiled, object targetValue)
		{
			this.parameters.Add(targetFiled, targetValue);
		}
		#endregion

		#region public string SetWhere(string targetFiled, object targetValue)
		/// <summary>
		/// 设置条件
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		/// <param name="targetValue">值</param>
		/// <returns>条件语句</returns>
		public string SetWhere(string targetFiled, object targetValue)
		{
			string relation = " AND ";
			return this.SetWhere(targetFiled, targetValue, null, relation);
		}
		#endregion

		#region public string SetWhere(string targetFiled, object targetValue, string relation)
		/// <summary>
		/// 设置条件
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		/// <param name="targetValue">值</param>
		/// <param name="targetFiledName"></param>
		/// <param name="relation">条件 AND OR</param>
		/// <returns>条件语句</returns>
		public string SetWhere(string targetFiled, object targetValue, string targetFiledName = null, string relation = " AND ")
		{
			if (string.IsNullOrEmpty(targetFiledName))
			{
				targetFiledName = targetFiled;
			}
			if (WhereSql.Length == 0)
			{
				WhereSql = " WHERE ";
			}
			else
			{
				WhereSql += relation;
			}
			// 这里需要对 null 进行处理
			if ((targetValue == null) || ((targetValue is string) && string.IsNullOrEmpty((string)targetValue)))
			{
				this.WhereSql += targetFiled + " IS NULL ";
			}
			else
			{
				this.WhereSql += targetFiled + " = " + DBProvider.GetParameter(targetFiledName);
				this.AddParameter(targetFiledName, targetValue);
			}
			return this.WhereSql;
		}
		#endregion

		#region public string SetWhere(string targetFiled, Object[] targetValues)
		/// <summary>
		/// 设置条件
		/// </summary>
		/// <param name="targetFiled">字段名</param>
		/// <param name="targetValues">字段值</param>
		/// <returns>条件语句</returns>
		public string SetWhere(string targetFiled, Object[] targetValues)
		{
			if (WhereSql.Length == 0)
			{
				WhereSql = " WHERE ";
			}
			this.WhereSql += targetFiled + " IN (" + BusinessLogic.ObjectsToList(targetValues) + ")";
			return this.WhereSql;
		}
		#endregion

		#region public string SetWhere(string[] targetFileds, Object[] targetValues)
		/// <summary>
		/// 设置条件
		/// </summary>
		/// <param name="targetFileds">目标字段</param>
		/// <param name="targetValues">值</param>
		/// <returns>条件语句</returns>
		public string SetWhere(string[] targetFileds, Object[] targetValues)
		{
			string relation = " AND ";
			return this.SetWhere(targetFileds, targetValues, relation);
		}
		#endregion

		#region public string SetWhere(string[] targetFileds, Object[] targetValues, string relation)
		/// <summary>
		/// 设置条件
		/// </summary>
		/// <param name="targetFileds">目标字段</param>
		/// <param name="targetValues">值</param>
		/// <param name="relation">条件 AND OR</param>
		/// <returns>条件语句</returns>
		public string SetWhere(string[] targetFileds, Object[] targetValues, string relation = " AND ")
		{
			for (int i = 0; i < targetFileds.Length; i++)
			{
				this.SetWhere(targetFileds[i], targetValues[i], targetFileds[i], relation);
			}
			string returnValue = this.WhereSql;
			return returnValue;
		}
		#endregion

		#region private int Execute()
		/// <summary>
		/// 执行语句
		/// </summary>
		/// <returns>影响行数</returns>
		private int Execute()
		{
            // 处理返回值
            int returnValue = 0;

			// 写入调试信息
			#if (DEBUG)
				int milliStart = Environment.TickCount;
				Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
			#endif
			
			if (this.sqlOperation == DbOperation.Insert)
			{
				this.InsertField = this.InsertField.Substring(0, InsertField.Length - 2);
				this.InsertValue = this.InsertValue.Substring(0, InsertValue.Length - 2);
				this.CommandText = " INSERT INTO " + this.TableName + "(" + InsertField + ") VALUES(" + InsertValue + ") ";
				// 采用了自增量的方式
				if (this.Identity)
				{
					switch (DBProvider.CurrentDbType)
					{
                        case CurrentDbType.SqlServer: // 需要返回主键
							if (this.ReturnId)
							{
								this.CommandText += "; SELECT SCOPE_IDENTITY(); ";
							}
							break;
                        case CurrentDbType.MySql: // Mysql 返回自增主键
                            if (this.ReturnId)
                            {
                                this.CommandText += "; SELECT LAST_INSERT_ID(); ";
                            }
                            break;
					}
				}
			}
			if (this.sqlOperation == DbOperation.Update)
			{
				this.UpdateSql = this.UpdateSql.Substring(0, UpdateSql.Length-2);
				this.CommandText = " UPDATE " + this.TableName + " SET " + this.UpdateSql + this.WhereSql;
			}
			if (this.sqlOperation == DbOperation.Delete)
			{
				this.CommandText = " DELETE FROM " + this.TableName + this.WhereSql;
			}

			// 参数进行规范化
			List<IDbDataParameter> dbParameters = this.parameters.Keys.Select(key => DBProvider.MakeParameter(key, this.parameters[key])).ToList();

            if (this.Identity && this.sqlOperation == DbOperation.Insert && (DBProvider.CurrentDbType == CurrentDbType.SqlServer || DBProvider.CurrentDbType == CurrentDbType.MySql))
			{
				returnValue = this.ReturnId
                    ? int.Parse(DBProvider.ExecuteScalar(this.CommandText, dbParameters.ToArray()).ToString()) // 读取返回值
                    : DBProvider.ExecuteNonQuery(this.CommandText, dbParameters.ToArray()); // 执行语句
			}           
            else
            {
                // 执行语句
                returnValue = DBProvider.ExecuteNonQuery(this.CommandText, dbParameters.ToArray());
            }

			if (this.Identity)
			{
				switch (DBProvider.CurrentDbType)
				{
					case CurrentDbType.Access:
						// 需要返回主键
						if (this.ReturnId)
						{
							this.CommandText = " SELECT @@identity AS ID FROM " + this.TableName + "; ";
							returnValue = int.Parse(DBProvider.ExecuteScalar(this.CommandText).ToString());
						}
						break;
				}
			}

			if (!DBProvider.AutoOpenClose)
			{
			}
			// 清除查询参数
			this.parameters.Clear();
			DBProvider.GetDbCommand().Parameters.Clear();
			
			// 写入调试信息
			#if (DEBUG)
				int milliEnd = Environment.TickCount;
				Trace.WriteLine(DateTime.Now.ToString(SystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
			#endif

			return returnValue;
		}
		#endregion

        #region public object ExecuteProcedure()
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <returns></returns>
        public object ExecuteProcedure()
        {
            // 参数进行规范化
            List<IDbDataParameter> dbParameters = this.parameters.Keys.Select(key => DBProvider.MakeParameter(key, this.parameters[key])).ToList();
            //V2.5版本代码
            //List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            //foreach (string key in this.parameters.Keys)
            //{
            //    dbParameters.Add(DBProvider.MakeParameter(key, this.parameters[key]));
            //}

            // 处理返回值
            object returnValue = 0;

            dbParameters.Add(DBProvider.MakeParameter("OperationType", this.OperationType.ToString()));
            dbParameters.Add(DBProvider.MakeParam("@ReturnInfo", "", DbType.String, 500, ParameterDirection.Output));
            if (this.OperationType == DbOperationType.SELECT)
            {
                returnValue = DBProvider.ExecuteProcedureForDataTable(this.ProcedureName, this.TableName, dbParameters.ToArray());
            }
            else
            {
                returnValue = DBProvider.ExecuteProcedure(this.ProcedureName, dbParameters.ToArray());
            }

            return returnValue;
        }
        #endregion
    }
}