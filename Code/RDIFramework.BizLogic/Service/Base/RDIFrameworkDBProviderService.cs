//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu.
//-----------------------------------------------------------------

using System.ServiceModel;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// RDIFrameworkDBProviderService
    /// 
    /// 修改纪录
    /// 
    ///		2011.05.07 版本：1.0 EricHu 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2011.05.07</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class RDIFrameworkDBProviderService : DBProviderService
    {
        public RDIFrameworkDBProviderService()
        {
            ServiceDbConnection = SystemInfo.RDIFrameworkDbConection;
            ServiceDbType       = SystemInfo.RDIFrameworkDbType;
        }

        public RDIFrameworkDBProviderService(string dbConnection)
        {
            ServiceDbConnection = dbConnection;
        }

        public RDIFrameworkDBProviderService(string dbConnection, CurrentDbType dbType)
        {
            ServiceDbConnection = dbConnection;
            ServiceDbType       = dbType;
        }
    }
}