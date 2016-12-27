//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin.
//-----------------------------------------------------------------

using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// BusinessDBProviderService
    /// 业务数据库服务
    /// 
    /// 修改纪录
    /// 
    ///		2012.05.07 版本：1.0 XuWangBin 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.05.07</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BusinessDBProviderService : DBProviderService
    {
        public BusinessDBProviderService()
        {
            ServiceDbConnection = SystemInfo.BusinessDbConnection;
            ServiceDbType = SystemInfo.BusinessDbType;
        }

        public BusinessDBProviderService(string dbConnection)
        {
            ServiceDbConnection = dbConnection;
        }

        public BusinessDBProviderService(string dbConnection, CurrentDbType dbType)
        {
            ServiceDbConnection = dbConnection;
            ServiceDbType = dbType;
        }
    }
}