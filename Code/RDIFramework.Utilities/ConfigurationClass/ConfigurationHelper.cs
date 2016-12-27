//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System.Configuration;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// ConfigurationHelper
    /// 连接配置。
    /// 
    /// 修改纪录
    ///     2011.07.05 版本：1.1 XuWangBin 增加  SystemInfo.EnableCheckIPAddress 
    ///		2010.09.29 版本：1.0 XuWangBin 将程序从 BaseConfiguration 进行了分离。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.09.29</date>
    /// </author> 
    /// </summary>
    public class ConfigurationHelper
    {
        #region public static void GetConfig()
        /// <summary>
        /// 从配置信息获取配置信息
        /// </summary>
        /// <param name="configuration">配置</param>
        public static void GetConfig()
        {
            // 客户信息配置
            SystemInfo.CustomerCompanyName = ConfigurationManager.AppSettings["CustomerCompanyName"];
            SystemInfo.ConfigurationFrom = BaseConfiguration.GetConfiguration(ConfigurationManager.AppSettings["ConfigurationFrom"]);
            SystemInfo.SoftName = ConfigurationManager.AppSettings["SoftName"];
            SystemInfo.SoftFullName = ConfigurationManager.AppSettings["SoftFullName"];
            SystemInfo.Version = ConfigurationManager.AppSettings["Version"];
            SystemInfo.RootMenuCode = ConfigurationManager.AppSettings["RootMenuCode"];
            SystemInfo.ServiceUserName = ConfigurationManager.AppSettings["ServiceUserName"];
            SystemInfo.ServicePassword = ConfigurationManager.AppSettings["ServicePassword"];
            SystemInfo.ServicePassword = SecretHelper.AESDecrypt(SystemInfo.ServicePassword);
            SystemInfo.RootMenuCode = ConfigurationManager.AppSettings["RootMenuCode"];

            //SystemInfo.CurrentLanguage = ConfigurationManager.AppSettings["CurrentLanguage"];
            // SystemInfo.Service = ConfigurationManager.AppSettings["Service"];
            // SystemInfo.EnableRecordLog = (ConfigurationManager.AppSettings["EnableRecordLog"].ToUpper(), true.ToString().ToUpper(), true);

            if (ConfigurationManager.AppSettings["EnableEncryptServerPassword"] != null)
            {
                SystemInfo.EnableEncryptServerPassword = ConfigurationManager.AppSettings["EnableEncryptServerPassword"].ToUpper().Equals(true.ToString().ToUpper());
            }
            if (ConfigurationManager.AppSettings["EncryptClientPassword"] != null)
            {
                SystemInfo.EncryptClientPassword = ConfigurationManager.AppSettings["EncryptClientPassword"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if(ConfigurationManager.AppSettings["EnableCheckIPAddress"]!=null)
            {
                SystemInfo.EnableCheckIPAddress = ConfigurationManager.AppSettings["EnableCheckIPAddress"].ToUpper().Equals(true.ToString().ToUpper());
            }

            // SystemInfo.AutoLogOn = (ConfigurationManager.AppSettings["AutoLogOn"].ToUpper(), true.ToString().ToUpper(), true);
            // SystemInfo.LogOnAssembly = ConfigurationManager.AppSettings["LogOnAssembly"];
            // SystemInfo.LogOnForm = ConfigurationManager.AppSettings["LogOnAssembly"];
            // SystemInfo.MainForm = ConfigurationManager.AppSettings["MainForm"];

            if (ConfigurationManager.AppSettings["CheckOnLine"] != null)
            {
                SystemInfo.CheckOnLine = ConfigurationManager.AppSettings["CheckOnLine"].ToUpper().Equals(true.ToString().ToUpper());
            }
            // SystemInfo.LoadAllUser = (ConfigurationManager.AppSettings["LoadAllUser"].ToUpper(), true.ToString().ToUpper(), true);
            // SystemInfo.AllowUserToRegister = (ConfigurationManager.AppSettings["AllowUserToRegister"].ToUpper(), true.ToString().ToUpper(), true); 
            // SystemInfo.EnableUserAuthorizationScope = (ConfigurationManager.AppSettings["EnableUserAuthorizationScope"].ToUpper(), true.ToString().ToUpper(), true);
            // SystemInfo.EnableTableFieldPermission = (ConfigurationManager.AppSettings["EnableTableFieldPermission"].ToUpper(), true.ToString().ToUpper(), true);
            // SystemInfo.EnableTableConstraintPermission = (ConfigurationManager.AppSettings["EnableTableConstraintPermission"].ToUpper(), true.ToString().ToUpper(), true);

            if (ConfigurationManager.AppSettings["EnableUserAuthorization"] != null)
            {
                SystemInfo.EnableUserAuthorization = ConfigurationManager.AppSettings["EnableUserAuthorization"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if (ConfigurationManager.AppSettings["EnableUserAuthorizationScope"] != null)
            {
                SystemInfo.EnableUserAuthorizationScope = ConfigurationManager.AppSettings["EnableUserAuthorizationScope"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if (ConfigurationManager.AppSettings["EnableModulePermission"] != null)
            {
                SystemInfo.EnableModulePermission = ConfigurationManager.AppSettings["EnableModulePermission"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if (ConfigurationManager.AppSettings["EnablePermissionItem"] != null)
            {
                SystemInfo.EnablePermissionItem = ConfigurationManager.AppSettings["EnablePermissionItem"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if (ConfigurationManager.AppSettings["EnableOrganizePermission"] != null)
            {
                SystemInfo.EnableOrganizePermission = ConfigurationManager.AppSettings["EnableOrganizePermission"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if (ConfigurationManager.AppSettings["EnableTableFieldPermission"] != null)
            {
                SystemInfo.EnableTableFieldPermission = ConfigurationManager.AppSettings["EnableTableFieldPermission"].ToUpper().Equals(true.ToString().ToUpper());
            }

            if (ConfigurationManager.AppSettings["EnableTableConstraintPermission"] != null)
            {
                SystemInfo.EnableTableConstraintPermission = ConfigurationManager.AppSettings["EnableTableConstraintPermission"].ToUpper().Equals(true.ToString().ToUpper());
            }

            // 数据库连接
            if (ConfigurationManager.AppSettings["RDIFrameworkDbType"] != null)
            {
                SystemInfo.RDIFrameworkDbType = BaseConfiguration.GetDbType(ConfigurationManager.AppSettings["RDIFrameworkDbType"]);
            }
            if (ConfigurationManager.AppSettings["BusinessDbType"] != null)
            {
                SystemInfo.BusinessDbType = BaseConfiguration.GetDbType(ConfigurationManager.AppSettings["BusinessDbType"]);
            }
            if (ConfigurationManager.AppSettings["WorkFlowDbType"] != null)
            {
                SystemInfo.WorkFlowDbType = BaseConfiguration.GetDbType(ConfigurationManager.AppSettings["WorkFlowDbType"]);
            }            
            if (ConfigurationManager.AppSettings["EncryptDbConnection"] != null)
            {
                SystemInfo.EncryptDbConnection = ConfigurationManager.AppSettings["EncryptDbConnection"].ToUpper().Equals(true.ToString().ToUpper());
            }

            SystemInfo.BusinessDbConnectionString = ConfigurationManager.AppSettings["BusinessDbConnection"];
            SystemInfo.RDIFrameworkDbConectionString = ConfigurationManager.AppSettings["RDIFrameworkDbConection"];
            SystemInfo.WorkFlowDbConnectionString = ConfigurationManager.AppSettings["WorkFlowDbConnection"];
            // 对加密的数据库连接进行解密操作
            if (SystemInfo.EncryptDbConnection)
            {
                SystemInfo.BusinessDbConnection = SecretHelper.AESDecrypt(SystemInfo.BusinessDbConnectionString);
                SystemInfo.RDIFrameworkDbConection = SecretHelper.AESDecrypt(SystemInfo.RDIFrameworkDbConectionString);
                SystemInfo.WorkFlowDbConnection = SecretHelper.AESDecrypt(SystemInfo.WorkFlowDbConnectionString);
            }
            else
            {
                SystemInfo.BusinessDbConnection = ConfigurationManager.AppSettings["BusinessDbConnection"];
                SystemInfo.RDIFrameworkDbConection = ConfigurationManager.AppSettings["RDIFrameworkDbConection"];
                SystemInfo.WorkFlowDbConnection = ConfigurationManager.AppSettings["WorkFlowDbConnection"];
            }

            SystemInfo.RegisterKey = ConfigurationManager.AppSettings["RegisterKey"];
        }
        #endregion
    }
}