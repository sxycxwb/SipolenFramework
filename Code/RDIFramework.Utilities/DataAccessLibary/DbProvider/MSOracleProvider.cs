using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;

namespace RDIFramework.Utilities
{
	/// <summary>
	/// OracleHelper
	/// 有关数据库连接的方法。
	/// 
	/// 修改纪录
	///     
    ///     2014-10-13 版本：2.8 EricHu 修改"public IDbDataParameter MakeInParam(string targetFiled, object targetValue)"方法，取消生成参数时添加的冒号“:”。
	///		2008.08.26 版本：1.3 EricHu 修改Open时的错误反馈。
	///		2008.06.01 版本：1.2 EricHu 数据库连接获得方式进行改进，构造函数获得调通。
	///		2008.05.08 版本：1.1 EricHu 调试通过，修改一些 有关参数的 Bug。
	///		2008.05.07 版本：1.0 EricHu 创建。
	/// 
	/// 版本：1.3
	/// 
	/// <author>
	///		<name>EricHu</name>
	///		<date>2010.08.26</date>
	/// </author> 
	/// </summary>
    public class MSOracleProvider : BaseDbProvider, IDbProvider
	{
		public override DbProviderFactory GetInstance()
		{
			return OracleClientFactory.Instance;
		}

		#region public override DataBaseType CurrentDataBaseType  当前数据库类型
		/// <summary> 
		/// 当前数据库类型
		/// </summary>
		public override CurrentDbType CurrentDbType
		{
			get
			{
				return CurrentDbType.Oracle;
			}
		}
		#endregion 

		#region public OracleHelper() 构造方法
		/// <summary>
		/// 构造方法
		/// </summary>
		public MSOracleProvider()
		{
			FileName = "OracleHelper.txt";    // sql查询句日志
		}
		#endregion

		#region public OracleHelper(string connectionString) 构造方法
		/// <summary>
		/// 构造方法
		/// </summary>
		/// <param name="connectionString">数据连接</param>
		public MSOracleProvider(string connectionString)
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
			return " SYSDATE ";
		}
		#endregion

		#region public string GetDBDateTime() 获得数据库日期时间
		/// <summary>
		/// 获得数据库日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public string GetDBDateTime()
		{
			string commandText = " SELECT " + this.GetDBNow() + " FROM DUAL ";
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

		#region public IDbDataParameter MakeInParam(string targetFiled, object targetValue) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="targetFiled">目标字段</param>
		/// <param name="targetValue">值</param>
		/// <returns>参数</returns>
    		public IDbDataParameter MakeInParam(string targetFiled, object targetValue)
		{
            //return new OracleParameter(":" + targetFiled, targetValue);
            return new OracleParameter(targetFiled, targetValue);
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
			    if (targetValue.ToString().ToUpper().Contains("TO_DATE('")) //Oracle日期类型处理
			    {
			        targetValue = targetValue.ToString()
			            .ToUpper()
			            .Replace("TO_DATE('", "");
                    targetValue = targetValue.ToString().Substring(0, targetValue.ToString().IndexOf("'")); 
			        dbParameter = this.MakeInParam(targetFiled, DbType.DateTime, 0, targetValue);
			    }
			    else
			    {
			        dbParameter = this.MakeInParam(targetFiled, targetValue);
			    }
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

		#region public IDbDataParameter MakeOutParam(string paramName, DbType dbType, int size) 获取输出参数
		/// <summary>
		/// 获取输出参数
		/// </summary>
		/// <param name="paramName">目标字段</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="size">长度</param>
		/// <returns>参数</returns>
		public IDbDataParameter MakeOutParam(string paramName, DbType dbType, int size)
		{
			return MakeParam(paramName, null, dbType, size, ParameterDirection.Output);
		}
		#endregion 

		#region public IDbDataParameter MakeInParam(string paramName, DbType dbType, int size, object value) 获取输入参数
		/// <summary>
		/// 获取输入参数
		/// </summary>
		/// <param name="paramName">目标字段</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="size">值</param>
		/// <param name="value"></param>
		/// <returns>参数</returns>
		public IDbDataParameter MakeInParam(string paramName, DbType dbType, int size, object value)
		{
			return MakeParam(paramName, value, dbType, size, ParameterDirection.Input);
		}
		#endregion 

		#region public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection) 获取参数
		/// <summary>
		/// 获取参数
		/// </summary>
		/// <param name="parameterName">目标字段</param>
		/// <param name="parameterValue">值</param>
		/// <param name="dbType">数据类型</param>
		/// <param name="parameterSize">长度</param>
		/// <param name="parameterDirection">参数类型</param>
		/// <returns>参数</returns>
		public IDbDataParameter MakeParam(string parameterName, object parameterValue, DbType dbType, Int32 parameterSize, ParameterDirection parameterDirection)
		{
			OracleParameter parameter;

			parameter = parameterSize > 0 ? new OracleParameter(parameterName, (OracleType)dbType, parameterSize) : new OracleParameter(parameterName, (OracleType)dbType);

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
			return " :" + parameter + " ";
		}
		#endregion

		#region string PlusSign(params string[] values) 获得Sql字符串相加符号
		/// <summary>
		///  获得Sql字符串相加符号
		/// </summary>
		/// <param name="values">参数值</param>
		/// <returns>字符加</returns>
		public string PlusSign(params string[] values)
		{
			string returnValue = string.Empty;
			for (int i = 0; i < values.Length; i++)
			{
				returnValue += values[i] + " || ";
			}
			returnValue = !String.IsNullOrEmpty(returnValue) ? returnValue.Substring(0, returnValue.Length - 4) : " || ";
			return returnValue;
		}
		#endregion
	}
}