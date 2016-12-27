//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , XuWangBin. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// OleDbProvider
	/// 有关数据库连接的方法。
	/// 
	/// 修改纪录
	///
	///		2011.01.22 版本：5.6 XuWangBin 参数首字母大小写规范化。
	///		2008.08.26 版本：5.5 XuWangBin 修改 Open 时的错误反馈。
	///		2008.06.01 版本：5.4 XuWangBin 数据库连接获得方式进行改进，构造函数获得调通。
	///		2008.05.31 版本：5.3 XuWangBin 参数命名 param 前缀替换为小写字母开始。
	///		2008.05.09 版本：5.2 XuWangBin InTransaction 命名改进。
	///		2008.05.07 版本：5.1 XuWangBin AddParameter 方法改进。
	///		2008.03.27 版本：5.1 XuWangBin 完善写日志功能。
	/// 版本：2.0
	/// 
	/// <author>
	///		<name>XuWangBin</name>
	///		<date>2008.03.27</date>
	/// </author> 
	/// </summary>
    public class OleDbProvider : BaseDbProvider, IDbProvider
	{
		public override DbProviderFactory GetInstance()
		{
			return OleDbFactory.Instance;
		}

		#region 当前数据库类型
		/// <summary>
		/// 当前数据库类型
		/// </summary>
		public override CurrentDbType CurrentDbType
		{
			get
			{
				return CurrentDbType.Access;
			}
		}
		#endregion 

		#region public OleDbProvider() 构造方法
		/// <summary>
		/// 构造方法
		/// </summary>
        public OleDbProvider()
		{
			FileName = "OleDBProvider.txt";   // sql查询句日志
		}
		#endregion

        #region public OleDbProvider(string connectionString) 构造方法
        /// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="connectionString">数据连接</param>
        public OleDbProvider(string connectionString)
            : this()
		{
			this.ConnectionString = connectionString;
		}
		#endregion

		#region public string GetDBNow() 获得数据库日期时间
		/// <summary>
		/// 获得数据库日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public string GetDBNow()
		{
			string returnValue = " Getdate() ";
			switch (this.CurrentDbType)
			{
				case CurrentDbType.Access:
					returnValue = "'" + DateTime.Now.ToString() + "'";
					break;
				case CurrentDbType.SqlServer:
					returnValue = " GetDate() ";
					break;
				case CurrentDbType.Oracle:
					returnValue = " SYSDATE ";
					break;
				case CurrentDbType.MySql:
					returnValue = " NOW() ";
					break;
			}
			return returnValue;
		}
		#endregion

		#region public string GetDBDateTime() 获得数据库日期时间
		/// <summary>
		/// 获得数据库日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public string GetDBDateTime()
		{
			string commandText = " SELECT " + this.GetDBNow();
			if (this.CurrentDbType.Equals(CurrentDbType.Oracle))
			{
				commandText += " FROM DUAL ";
			}
			this.Open();
			string dateTime = this.ExecuteScalar(commandText, null, CommandType.Text).ToString();
			this.Close();
			return dateTime;
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
			return new OleDbParameter(targetFiled, targetValue);
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
			List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
			if (targetFileds != null && targetValues != null)
			{
				for (int i = 0; i < targetFileds.Length; i++)
				{
					if (targetFileds[i] != null && targetValues[i] != null)
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

		#region public IDbDataParameter MakeOutParam(string paramName, DbType dbType, int size)  获取输出参数
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

		#region public IDbDataParameter MakeInParam(string paramName, DbType dbType, int size, object value) 获取输入参数
		/// <summary>
		/// 获取输入参数
		/// </summary>
		/// <param name="paramName">参数名</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="size">长度</param>
		/// <param name="value">值</param>
		/// <returns></returns>
		public IDbDataParameter MakeInParam(string paramName, DbType dbType, int size, object value)
		{
			return MakeParam(paramName, value, dbType, size, ParameterDirection.Input);
		}
		#endregion 

		#region public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="parameterName">参数</param>
		/// <param name="parameterValue">值</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="parameterSize">长度</param>
		/// <param name="parameterDirection">参数类型</param>
		/// <returns></returns>
		public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
		{
			OleDbParameter parameter;

			parameter = parameterSize > 0 ? new OleDbParameter(parameterName, (OleDbType)dbType, parameterSize) : new OleDbParameter(parameterName, (OleDbType)dbType);

			parameter.Direction = parameterDirection;
			if (!(parameterDirection == ParameterDirection.Output && parameterValue == null))
			{
				parameter.Value = parameterValue;
			}

			return parameter;
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
			return " ? ";
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
			string returnValue = string.Empty;
			switch (this.CurrentDbType)
			{
				case CurrentDbType.Access:
				case CurrentDbType.SqlServer:
					returnValue = !String.IsNullOrEmpty(returnValue) ? returnValue.Substring(0, returnValue.Length - 3) : " + ";
					break;
				case CurrentDbType.MySql:
					returnValue = " CONCAT(";
					for (int i = 0; i < values.Length; i++)
					{
						returnValue += values[i] + " ,";
					}
					returnValue = returnValue.Substring(0, returnValue.Length - 2);
					returnValue += ")";
					break;
				case CurrentDbType.Oracle:
					for (int i = 0; i < values.Length; i++)
					{
						returnValue += values[i] + " || ";
					}
					returnValue = !String.IsNullOrEmpty(returnValue) ? returnValue.Substring(0, returnValue.Length - 4) : " || ";
					break;
			}
			return returnValue;
		}
		#endregion

		#region public string PlusSign() 字符串相加符号
		/// <summary>
		/// 字符串相加符号
		/// </summary>
		/// <returns>字符加</returns>
        public override string PlusSign()
		{
			string returnValue = " + ";
			
			return returnValue;
		}
		#endregion
	}
}