using System;
using System.Data;
using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// LogManager
    /// 系统日志表
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 XuWangBin 创建主键。
    ///
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class LogManager
    {
        public void AddWebLog(string urlReferrer, string adId, string webUrl)
        {
            string userId = string.Empty;
            if (!UserInfo.Id.Equals(UserInfo.IPAddress))
            {
                userId = UserInfo.Id;
            }
            string userName = string.Empty;
            if (!UserInfo.UserName.Equals(UserInfo.IPAddress))
            {
                userName = UserInfo.UserName;
            }
            this.AddWebLog(urlReferrer, adId, webUrl, UserInfo.IPAddress, userId, userName);
        }

        /// <summary>
        /// 写入网页访问日志
        /// </summary>
        /// <param name="urlReferrer">导入网址</param>
        /// <param name="adId">广告商ID</param>
        /// <param name="webUrl">访问的网址</param>
        /// <param name="ipAddress">网络地址</param>
        /// <param name="userId">用户主键</param>
        /// <param name="userName">用户名</param>
        public void AddWebLog(string urlReferrer, string adId, string webUrl, string ipAddress, string userId, string userName)
        {
            CiLogEntity logEntity = new CiLogEntity
            {
                ProcessId = "WebLog",
                WebUrl = webUrl,
                IPAddress = ipAddress,
                CreateUserId = userId,
                UserRealName = userName
            };
            if (!string.IsNullOrEmpty(adId))
            {
                logEntity.MethodName = "AD";
                logEntity.Parameters = adId;
            }
            this.AddEntity(logEntity);        
        }

        public DataTable GetDTByDateByUserIds(string[] userIds, string name, string value, string beginDate, string endDate)
        {
            string sqlQuery = this.GetDTSql(userIds, name, value, beginDate, endDate);
            return DBProvider.Fill(sqlQuery);
        }

        private string GetDTSql(string[] userIds, string name, string value, string beginDate, string endDate)
        {
            string sqlQuery = " SELECT * FROM " + CiLogTable.TableName + " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(value))
            {
                sqlQuery += " AND " + name + " = '" + value + "' ";
            }
            if (!string.IsNullOrEmpty(beginDate) && !string.IsNullOrEmpty(endDate))
            {
                beginDate = DateTime.Parse(beginDate.ToString()).ToShortDateString();
                endDate = DateTime.Parse(endDate.ToString()).AddDays(1).ToShortDateString();
            }
           

            if (userIds != null)
            {
                sqlQuery += " AND " + CiLogTable.FieldCreateUserId + " IN (" + BusinessLogic.ObjectsToList(userIds) + ") ";
            }
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                case CurrentDbType.MySql:
                    if (beginDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CREATEON >= '" + beginDate + "'";
                    }
                    if (endDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CREATEON <= '" + endDate + "'";
                    }
                    break;
                case CurrentDbType.Oracle:
                    if (beginDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CREATEON >= TO_DATE( '" + beginDate + "','yyyy-mm-dd hh24-mi-ss') ";
                    }
                    if (endDate.Trim().Length > 0)
                    {
                        sqlQuery += " AND CREATEON <= TO_DATE('" + endDate + "','yyyy-mm-dd hh24-mi-ss')";
                    }
                    break;
            }
            sqlQuery += " ORDER BY CREATEON DESC ";
            return sqlQuery;
        }

        #region public DataTable GetDTByDate(string name, string value, string beginDate, string endDate) 查询
        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByDate(string name, string value, string beginDate, string endDate)
        {
            string sqlQuery = this.GetDTSql(null, name, value, beginDate, endDate);
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetDTByDate(IDbProvider dbProvider, string createOn, string processId, string createUserId)
        /// <summary>
        /// 按日期查询
		/// </summary>
		/// <param name="dbProvider"></param>
        /// <param name="createOn">记录日期 yyyy/mm/dd</param>
        /// <param name="processId">模块主键</param>
		/// <param name="createUserId">用户主键</param>
		/// <returns>数据表</returns>
        public DataTable GetDTByDate(IDbProvider dbProvider, string createOn, string processId, string createUserId)
		{
            string sqlQuery = " SELECT * FROM " + CiLogTable.TableName
                    + " WHERE CONVERT(NVARCHAR, " + CiLogTable.FieldCreateOn + ", 111) = " + dbProvider.GetParameter(CiLogTable.FieldCreateOn)
                    + " AND " + CiLogTable.FieldProcessId + " = " + dbProvider.GetParameter(CiLogTable.FieldProcessId)
                    + " AND " + CiLogTable.FieldCreateUserId + " = " + dbProvider.GetParameter(CiLogTable.FieldCreateUserId);
            sqlQuery += " ORDER BY " + CiLogTable.FieldCreateOn;
			string[] names = new string[3];
            names[0] = CiLogTable.FieldCreateOn;
            names[1] = CiLogTable.FieldProcessName;
            names[2] = CiLogTable.FieldCreateUserId;
            Object[] values	= new Object[3];
			values[0]	= createOn;
            values[1]   = processId;
			values[2]	= createUserId;
            DataTable dataTable = new DataTable(CiLogTable.TableName);
            dbProvider.Fill(dataTable, sqlQuery, DBProvider.MakeParameters(names, values));
			return dataTable;
		}
		#endregion

        public void Add(UserInfo userInfo, MethodBase methodBase)
        {
            //DBProvider = dbProvider;
            UserInfo = userInfo;
            this.Add(UserInfo, methodBase.ReflectedType.FullName, methodBase.ReflectedType.Name, methodBase);
        }

        public void Add(UserInfo userInfo, string serviceName, MethodBase methodBase)
        {
            //DBProvider = dbProvider;
            UserInfo = userInfo;
            this.Add(UserInfo, serviceName, methodBase.ReflectedType.FullName, methodBase);
        }

        public void Add(IDbProvider dbProvider, UserInfo userInfo, string serviceName, string methodName, MethodBase methodBase)
        {
            DBProvider = dbProvider;
            UserInfo = userInfo;
            this.Add(userInfo, serviceName, methodName, methodBase.ReflectedType.Name, methodBase.Name, string.Empty);
        }

        public void Add(IDbProvider dbProvider, UserInfo userInfo, string serviceName, string methodName, MethodBase methodBase, string parameters)
        {
            DBProvider = dbProvider;
            UserInfo = userInfo;
            this.Add(userInfo, serviceName, methodName, methodBase.ReflectedType.Name, methodBase.Name, parameters);
        }

        public void Add(UserInfo userInfo, string serviceName, string methodName, MethodBase methodBase)
        {
            //DBProvider = dbProvider;
            UserInfo = userInfo;
            this.Add(userInfo, serviceName, methodName, methodBase.ReflectedType.Name, methodBase.Name, string.Empty);
        }

        public void Add(UserInfo userInfo, string serviceName, string methodName, MethodBase methodBase, string parameters)
        {
            //DBProvider = dbProvider;
            UserInfo = userInfo;
            this.Add(userInfo, serviceName, methodName, methodBase.ReflectedType.Name, methodBase.Name, parameters);
        }

        public void Add(UserInfo userInfo, string processName, string methodName, string processId, string methodEngName, string parameters)
        {
            //DBProvider = dbProvider;
            UserInfo = userInfo;
            if (!SystemInfo.EnableRecordLog)
            {
                return;
            }
            CiLogEntity logEntity = new CiLogEntity
            {
                CreateUserId = userInfo.Id,
                UserRealName = userInfo.RealName,
                ProcessId = processId,
                ProcessName = processName,
                MethodEngName = methodEngName,
                MethodName = methodName,
                Parameters = parameters,
                IPAddress = userInfo.IPAddress,
                CreateBy = userInfo.RealName
            };
            logEntity.CreateUserId = userInfo.Id;
            this.Add(dbProvider, logEntity);
        }

        #region public int Add(string userId, string realName, string processId, string processName, string methodName, string methodEngName, string parameters, string ipAddress, string description)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="realName">用户姓名</param>
        /// <param name="processId">模块ID</param>
        /// <param name="processName">模块名称</param>
        /// <param name="methodEngName">方法英语名称</param>
        /// <param name="methodName">对象ID</param>
        /// <param name="parameters">对象名称</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="description">描述</param>
        /// <returns>主键</returns>
        public void Add(string userId, string realName, string processId, string processName, string methodName, string methodEngName, string parameters, string ipAddress, string description)
        {
            CiLogEntity logEntity = new CiLogEntity
            {
                CreateUserId = userId,
                UserRealName = realName,
                ProcessId = processId,
                ProcessName = processName,
                MethodEngName = methodEngName,
                MethodName = methodName,
                Parameters = parameters,
                IPAddress = ipAddress,
                Description = description
            };
            this.AddEntity(logEntity);
        }
        #endregion

        #region public int Add(IDbProvider dbProvider, BaseLogEntity logEntity)
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="logEntity">日志对象</param>
        /// <returns>主键</returns>
        public void Add(IDbProvider dbProvider, CiLogEntity logEntity)
        {
            DBProvider = dbProvider;
            // 这里是出错了，才调试
            // return 0;
            AddEntity(logEntity);
        }
        #endregion
    }
}
