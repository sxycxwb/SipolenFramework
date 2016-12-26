using System;
using System.Data;
using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// DBProviderService
    /// 数据库服务
    /// 
    /// 修改纪录
    /// 
    ///		2011.05.07 版本：2.3 EricHu 改进为虚类。
    ///		2010.08.15 版本：2.2 EricHu 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2010.08.14 版本：2.1 EricHu 改进运行速度采用 Instance 方式处理数据。
    ///		2010.07.10 版本：1.0 EricHu 数据库访问类。
    ///		
    /// 版本：2.3
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.07.10</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public abstract class DBProviderService : System.MarshalByRefObject,IDBProviderService
    {
        public string ServiceDbConnection    = SystemInfo.BusinessDbConnection;
        public CurrentDbType ServiceDbType   = SystemInfo.BusinessDbType;

        public DBProviderService()
        {
        }

        public DBProviderService(string dbConnection)
        {
            ServiceDbConnection = dbConnection;
        }

        public DBProviderService(string dbConnection,CurrentDbType dbType)
        {
            ServiceDbConnection = dbConnection;
            ServiceDbType       = dbType;
        }

        public int ExecuteNonQuery(UserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbProvider dbProvider = DbFactoryProvider.GetProvider(ServiceDbType, ServiceDbConnection);
            return dbProvider.ExecuteNonQuery(commandText);
        }

        public int ExecuteNonQuery(UserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbProvider dbProvider = DbFactoryProvider.GetProvider(ServiceDbType, ServiceDbConnection);
            return dbProvider.ExecuteNonQuery(commandText, dbParameters);
        }

        public object ExecuteScalar(UserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbProvider dbProvider = DbFactoryProvider.GetProvider(ServiceDbType, ServiceDbConnection);
            return dbProvider.ExecuteScalar(commandText);
        }

        public object ExecuteScalar(UserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbProvider dbProvider = DbFactoryProvider.GetProvider(ServiceDbType, ServiceDbConnection);
            return dbProvider.ExecuteScalar(commandText, dbParameters);
        }

        public DataTable Fill(UserInfo userInfo, string commandText)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbProvider dbProvider = DbFactoryProvider.GetProvider(ServiceDbType, ServiceDbConnection);
            return dbProvider.Fill(commandText);
        }

        public DataTable Fill(UserInfo userInfo, string commandText, System.Data.Common.DbParameter[] dbParameters)
        {
            // 写入调试信息
            #if (DEBUG)
                Console.WriteLine(" User: " + userInfo.RealName + " commandText: " + commandText);
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            IDbProvider dbProvider = DbFactoryProvider.GetProvider(ServiceDbType, ServiceDbConnection);
            return dbProvider.Fill(commandText, dbParameters);
        }
    }
}