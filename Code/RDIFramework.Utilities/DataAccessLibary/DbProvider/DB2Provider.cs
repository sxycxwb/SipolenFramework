﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace RDIFramework.Utilities
{
	using IBM.Data.DB2;

	/// <summary>
	/// DB2Provider
	/// 有关数据库连接的方法。
	/// 
	/// 修改纪录
	/// 
	///		2011.07.19 版本：1.0 XuWangBin 创建。
	/// 
	/// 版本：1.0
	/// 
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2011.07.19</date>
	/// </author> 
	/// </summary>
    public class DB2Provider : BaseDbProvider, IDbProvider
	{
		public override DbProviderFactory GetInstance()
		{
			return DB2Factory.Instance;
		}

		#region public override DataBaseType CurrentDataBaseType 当前数据库类型
		/// <summary>
		/// 当前数据库类型
	   /// </summary>
		public override CurrentDbType CurrentDbType
		{
			get
			{
				return CurrentDbType.DB2;
			}
		}
		#endregion 

		#region public DB2Provider() 构造方法
		/// <summary>
		/// 构造方法
		/// </summary>
		public DB2Provider()
		{
			// sql查询句日志
			FileName = "DB2Provider.txt";
		}
		#endregion

		#region public DB2Provider(string connectionString) 构造函数,设置数据库连接
		/// <summary>
		/// 构造函数,设置数据库连接
		/// </summary>
		/// <param name="connectionString">数据连接</param>
        public DB2Provider(string connectionString)
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
			return " current timestamp ";
		}
		#endregion

		#region public string GetDBDateTime() 获得数据库日期时间
		/// <summary>
		/// 获得数据库日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public string GetDBDateTime()
		{
			string commandText = " SELECT current timestamp FROM sysibm.sysdummy1 ";
			this.Open();
			string dateTime = this.ExecuteScalar(commandText, null, CommandType.Text).ToString();
			this.Close();
			return dateTime;
		}
		#endregion

		#region public override string PlusSign() 获得Sql字符串相加符号
		/// <summary>
		///  获得Sql字符串相加符号
		/// </summary>
		/// <returns>字符加</returns>
		public override string PlusSign()
		{
			return " || ";
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
			return new DB2Parameter("@" + targetFiled, targetValue);
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
			if (targetFiled != null && targetValue != null)
			{
				dbParameter = this.MakeInParam(targetFiled, targetValue);
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
			List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
			if (targetFileds != null && targetValues != null)
			{
				for (int i = 0; i < targetFileds.Length; i++)
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

        #region public IDbDataParameter[] MakeParameters(List<KeyValuePair<string, object>> parameters) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="parameters">参数</param>
        /// <returns>参数集</returns>
        public IDbDataParameter[] MakeParameters(List<KeyValuePair<string, object>> parameters)
        {
            // 这里需要用泛型列表，因为有不合法的数组的时候
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (parameters != null && parameters.Count > 0)
            {
                dbParameters.AddRange(from parameter in parameters where parameter.Key != null && parameter.Value != null && (!(parameter.Value is Array)) select MakeParameter(parameter.Key, parameter.Value));
            }
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
        /// <param name="parameterValue">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="parameterSize">长度</param>
        /// <param name="parameterDirection">参数方向</param>
		/// <returns></returns>
		public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
		{
			DB2Parameter parameter;

			parameter = parameterSize > 0 ? new DB2Parameter(parameterName, (DB2Type)dbType, parameterSize) : new DB2Parameter(parameterName, (DB2Type)dbType);
			
			parameter.Direction = parameterDirection;
			if (!(parameterDirection == ParameterDirection.Output && parameterValue == null))
			{
				parameter.Value = parameterValue;
			}

			return parameter;
		}
		#endregion 
	}
}