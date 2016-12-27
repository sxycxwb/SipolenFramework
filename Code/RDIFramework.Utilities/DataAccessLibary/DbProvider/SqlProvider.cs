//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// SqlProvider
	/// 有关数据库连接的方法。
	/// 
	/// 修改纪录
    ///     2014-05-23 版本：2.8 XuWangBin 增加ConvertToSqlDbType方法。
	///		2011.08.26 版本：1.2 XuWangBin 修改Open时的错误反馈。
	///		2010.06.01 版本：1.1 XuWangBin 数据库连接获得方式进行改进，构造函数获得调通。
	///		2010.05.07 版本：1.0 XuWangBin 创建。
	/// 
	/// 版本：3.0
	/// 
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2010.05.11</date>
	/// </author> 
	/// </summary>
    public class SqlProvider : BaseDbProvider, IDbProvider//, IDbProviderExpand
	{
		public override DbProviderFactory GetInstance()
		{
			return SqlClientFactory.Instance;
		}

		#region public override CurrentDbType CurrentDbType 当前数据库类型
		/// <summary>
		/// 当前数据库类型
		/// </summary>
		public override CurrentDbType CurrentDbType
		{
			get
			{
				return CurrentDbType.SqlServer;
			}
		}
		#endregion 

		#region public SqlProvider() 构造方法
		/// <summary>
		/// 构造方法
		/// </summary>
		public SqlProvider()
		{
			FileName = "SqlProvider.txt"; // sql查询句日志
		}

		/// <summary>
		/// 构造函数,设置数据库连接
		/// </summary>
		/// <param name="connectionString">数据连接</param>
		public SqlProvider(string connectionString)
		{
			this.ConnectionString = connectionString;
		}
		#endregion

		#region public string GetDBNow() 获得数据库当前日期时间
		/// <summary>
		/// 获得数据库当前日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public string GetDBNow()
		{
			return " Getdate() ";
		}
		#endregion

		#region public string GetDBDateTime() 获得数据库日期时间
		/// <summary>
		/// 获得数据库日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public string GetDBDateTime()
		{
			var commandText = " SELECT " + this.GetDBNow();
			this.Open();
            var dateTime = this.ExecuteScalar(commandText, null, CommandType.Text).ToString();
			this.Close();
			return dateTime;
		}
		#endregion

		#region string PlusSign(params string[] values) 获得Sql字符串相加符号
		/// <summary>
		///  获得Sql字符串相加符号
		/// </summary>
		/// <param name="values">参数值</param>
		/// <returns>字符加</returns>
		public override string PlusSign(params string[] values)
		{
			var returnValue = values.Aggregate(string.Empty, (current, t) => current + (t + " + "));
            //V2.5版本
            //string returnValue = string.Empty;
            //for (int i = 0; i < values.Length; i++)
            //{
            //    returnValue += values[i] + " + ";
            //}

		    returnValue = !String.IsNullOrEmpty(returnValue) ? returnValue.Substring(0, returnValue.Length - 3) : " + ";
			return returnValue;
		}
		#endregion

		#region public string GetParameter(string parameter) 获得参数Sql表达式
		/// <summary>
		/// 获得参数Sql表达式
		/// </summary>
		/// <param name="parameter">参数名称</param>
		/// <returns>字符串</returns>
		public string GetParameter(string parameter)
		{
			return " @" + parameter + " ";
		}
		#endregion

		#region public IDbDataParameter MakeInParam(string targetFiled, object targetValue) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		/// <param name="targetValue">值</param>
		/// <returns>参数</returns>
		public IDbDataParameter MakeInParam(string targetFiled, object targetValue)
		{
			return new SqlParameter("@" + targetFiled, targetValue);
		}
		#endregion

		#region public IDbDataParameter MakeParameter(string targetFiled, object targetValue) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		/// <param name="targetValue">值</param>
		/// <returns>参数集</returns>
		public IDbDataParameter MakeParameter(string targetFiled, object targetValue)
		{
			IDbDataParameter dbParameter = null;
            //if (targetFiled != null && targetValue != null)
            //{
            //    dbParameter = this.MakeInParam(targetFiled, targetValue);
            //}

            if (targetFiled != null)
            {
                dbParameter = this.MakeInParam(targetFiled, targetValue ?? DBNull.Value);
            }

		    return dbParameter;
		}
		#endregion

		#region public IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
        /// <param name="targetFileds">目标字段</param>
        /// <param name="targetValues">值</param>
		/// <returns>参数集</returns>
		public IDbDataParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
		{
			// 这里需要用泛型列表，因为有不合法的数组的时候
			var dbParameters = new List<IDbDataParameter>();
			if (targetFileds != null && targetValues != null)
			{
				for (var i = 0; i < targetFileds.Length; i++)
				{
					if (targetFileds[i] != null && targetValues[i] != null && (!(targetValues[i] is Array)))
					{
						dbParameters.Add(this.MakeInParam(targetFileds[i], targetValues[i]));
					}
				}
			}
			return dbParameters.ToArray();
		}
		#endregion

        #region public IDbDataParameter[] MakeParameters(List<KeyValuePair<string, object>> parameters) 获取参数泛型列表
        /// <summary>
        /// 获取参数泛型列表
        /// </summary>
        /// <param name="parameters">参数</param>
        /// <returns>参数集</returns>
        public IDbDataParameter[] MakeParameters(List<KeyValuePair<string, object>> parameters)
        {
            // 这里需要用泛型列表，因为有不合法的数组的时候
            var dbParameters = new List<IDbDataParameter>();
            if (parameters != null && parameters.Count > 0)
            {
                dbParameters.AddRange(from parameter in parameters where parameter.Key != null && parameter.Value != null && (!(parameter.Value is Array)) select MakeParameter(parameter.Key, parameter.Value));
            }
            //V2.5版本
            //foreach (var parameter in parameters)
            //{
            //    if (parameter.Key != null && parameter.Value != null && (!(parameter.Value is Array)))
            //    {
            //        dbParameters.Add(MakeParameter(parameter.Key, parameter.Value));
            //    }
            //}

            return dbParameters.ToArray();
        }
        #endregion

		#region public IDbDataParameter MakeOutParam(string paramName, DbType dbType, int size) 获取输出参数
		/// <summary>
		/// 获取输出参数
		/// </summary>
		/// <param name="paramName">参数</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="size">长度</param>
		/// <returns></returns>
		public IDbDataParameter MakeOutParam(string paramName, DbType dbType, int size)
		{
			return MakeParam(paramName, null, dbType, size, ParameterDirection.Output);
		}
		#endregion 

		#region public IDbDataParameter MakeInParam(string paramName, DbType dbType, int Size, object value) 获取输入参数
		/// <summary>
		/// 获取输入参数
		/// </summary>
		/// <param name="paramName">参数</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="Size">长度</param>
		/// <param name="value">值</param>
		/// <returns></returns>
		public IDbDataParameter MakeInParam(string paramName, DbType dbType, int Size, object value)
		{
			return MakeParam(paramName, value, dbType, Size, ParameterDirection.Input);
		}
		#endregion 

		#region public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="parameterName">参数名</param>
		/// <param name="parameterValue">值</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="parameterSize">长度</param>
		/// <param name="parameterDirection">参数类型</param>
		/// <returns>参数</returns>
		public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
		{
		    var parameter = parameterSize > 0 ? new SqlParameter(parameterName, ConvertToSqlDbType(dbType), parameterSize) : new SqlParameter(parameterName, ConvertToSqlDbType(dbType));

			parameter.Direction = parameterDirection;
			if (!(parameterDirection == ParameterDirection.Output && parameterValue == null))
			{
				parameter.Value = parameterValue;
			}

			return parameter;
		}
		#endregion 

        #region  private System.Data.SqlDbType ConvertToSqlDbType(System.Data.DbType dbType) 类型转换
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="dbType">数据类型</param>
        /// <returns>转换结果</returns>
        private System.Data.SqlDbType ConvertToSqlDbType(System.Data.DbType dbType)
        {
            var sqlParameter = new SqlParameter {DbType = dbType};
            return sqlParameter.SqlDbType;
        }
        #endregion

        #region public override void SqlBulkCopyData(DataTable dataTable) 利用Net SqlBulkCopy 批量导入数据库,速度超快
        /// <summary>
		/// 利用Net SqlBulkCopy 批量导入数据库,速度超快
		/// </summary>
		/// <param name="dataTable">源内存数据表</param>
		public override void SqlBulkCopyData(DataTable dataTable)
		{
			SqlConnection conn = null;
			this.Open();

			// 获取连接
			conn = (SqlConnection)GetDbConnection();

			using (var tran = conn.BeginTransaction())
			{
				// 批量保存数据，只能用于Sql
				var sqlbulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)
				{
				    DestinationTableName = dataTable.TableName,
				    BulkCopyTimeout = 1000
				};
				// 设置源表名称
			    // 设置超时限制

			    foreach (DataColumn dtColumn in dataTable.Columns)
				{
					sqlbulkCopy.ColumnMappings.Add(dtColumn.ColumnName, dtColumn.ColumnName);
				}

				try
				{
					// 写入
					sqlbulkCopy.WriteToServer(dataTable);
					// 提交事务
					tran.Commit();
				}
				catch
				{
					tran.Rollback();
					sqlbulkCopy.Close();
				}
				finally
				{
					sqlbulkCopy.Close();
					this.Close();
				}
			}
		}
		#endregion

        #region public override DataTable GetPageList(IDbDataParameter[] dbParameters):得到分页数据
        /// <summary>
        /// 用存储过程的方式得到分页数据
        /// </summary>
        /// <param name="dbParameters">参数</param>
        /// <returns></returns>
        public override DataTable GetPageList(IDbDataParameter[] dbParameters)
        {
            return base.ExecuteProcedureForDataTable("pGetPageData", "pageDataTable", dbParameters);
        }
        #endregion
    }
}