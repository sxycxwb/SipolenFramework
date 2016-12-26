//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// UserConfigHelper
    /// 访问用户配置文件的类
    /// 
    /// 修改纪录
    ///     2013.02.06 版本: 2.0 EricHu 新增平台博客、微博地址。
    ///     2012.07.06 版本：1.4 EricHu 增加对 EnableCheckIPAddress 的操作
    ///		2012.06.08 版本：1.3 EricHu 命名修改为 ConfigHelper。
    ///		2012.04.22 版本：1.2 EricHu 从指定的文件读取配置项。
    ///		2011.07.31 版本：1.1 EricHu 规范化 FielName 变量。
    ///		2010.09.29 版本：1.0 EricHu 专门读取注册表的类，主键书写格式改进。
    ///		
    ///	版本：2.0
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.09.29</date>
    /// </author> 
    /// </summary>
    public class UserConfigHelper
    {
        public static string LogOnTo = "Config";

        public static string FileName
        {
            get
            {
                return LogOnTo + ".xml";
            }
        }

        public static string SelectPath = "//appSettings/add";

        public static string ConfigFielName
        {
            get
            {
                //return FileName;
                return SystemInfo.StartupPath + "\\" + FileName;
            }
        }

        #region public static Dictionary<String, String> GetLogOnTo() 获取配置文件选项
        /// <summary>
        /// 获取配置文件选项
        /// </summary>
        /// <returns>配置文件设置</returns>
        public static Dictionary<String, String> GetLogOnTo()
        {
            var returnValue = new Dictionary<String, String>();
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);
            var xmlNodeList = xmlDocument.SelectNodes(SelectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals("LogOnTo".ToUpper()))
                {
                    returnValue.Add(xmlNode.Attributes["value"].Value, xmlNode.Attributes["dispaly"].Value);
                }
            }
            return returnValue;
        }
        #endregion      

        public static bool Exists(string key)
        {
            return !string.IsNullOrEmpty(GetValue(key));
        }

        public static string[] GetOptions(string key)
        {
            var option = string.Empty;
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);
            option = GetOption(xmlDocument, SelectPath, key);
            return option.Split(',');
        }

        #region public static string GetOption(XmlDocument xmlDocument, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetOption(XmlDocument xmlDocument, string selectPath, string key)
        {
            var returnValue = string.Empty;
            var xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    if (xmlNode.Attributes["Options"] != null)
                    {
                        returnValue = xmlNode.Attributes["Options"].Value;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region public static string GetValue(string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            return GetValue(ConfigFielName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string fileName, string key)
        {
            return GetValue(fileName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string fileName, string selectPath, string key)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return GetValue(xmlDocument, selectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(XmlDocument xmlDocument, string key)
        {
            return GetValue(xmlDocument, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(XmlDocument xmlDocument, string selectPath, string key)
        {
            var returnValue = string.Empty;
            var xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    returnValue = xmlNode.Attributes["value"].Value;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetConfig() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static void GetConfig()
        {
            GetConfig(ConfigFielName);
        }
        #endregion

        #region public static void GetConfig(string fileName) 从指定的文件读取配置项
        /// <summary>
        /// 从指定的文件读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        public static void GetConfig(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            SystemInfo.ConfigFile = Exists("ConfigFile") ? GetValue(xmlDocument, "ConfigFile") : SystemInfo.ConfigFile;
            SystemInfo.Host = Exists("Host") ? GetValue(xmlDocument, "Host") : SystemInfo.Host;

            if (Exists("Port"))
            {
                int.TryParse(GetValue(xmlDocument, "Port"), out SystemInfo.Port);
            }

            // 客户信息配置
            SystemInfo.CurrentUserName = Exists("CurrentUserName") ? GetValue(xmlDocument, "CurrentUserName") : SystemInfo.CurrentUserName;
            SystemInfo.CurrentPassword = Exists("CurrentPassword") ? GetValue(xmlDocument, "CurrentPassword") : SystemInfo.CurrentPassword;

            if (Exists("MultiLanguage"))
            {
                SystemInfo.MultiLanguage = (String.Compare(GetValue(xmlDocument, "MultiLanguage"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            SystemInfo.CurrentLanguage = Exists("CurrentLanguage") ? GetValue(xmlDocument, "CurrentLanguage") : SystemInfo.CurrentLanguage;

            if (Exists("RememberPassword"))
            {
                SystemInfo.RememberPassword = (String.Compare(GetValue(xmlDocument, "RememberPassword"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            if (Exists("AutoLogOn"))
            {
                SystemInfo.AutoLogOn = (String.Compare(GetValue(xmlDocument, "AutoLogOn"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            if (Exists("EnableCheckPasswordStrength"))
            {
                SystemInfo.EnableCheckPasswordStrength = (String.Compare(GetValue(xmlDocument, "EnableCheckPasswordStrength"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            if (Exists("EncryptClientPassword"))
            {
                SystemInfo.EncryptClientPassword = (String.Compare(GetValue(xmlDocument, "EncryptClientPassword"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableEncryptServerPassword"))
            {
                SystemInfo.EnableEncryptServerPassword = (String.Compare(GetValue(xmlDocument, "EnableEncryptServerPassword"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            SystemInfo.CurrentStyle = Exists("CurrentStyle") ? GetValue(xmlDocument, "CurrentStyle") : SystemInfo.CurrentStyle;
            SystemInfo.CurrentThemeColor = Exists("CurrentThemeColor") ? GetValue(xmlDocument, "CurrentThemeColor") : SystemInfo.CurrentThemeColor;

            if (Exists("OnLineTime0ut"))
            {
                var valueOnLineTimeOut = GetValue(xmlDocument, "OnLineTime0ut");
                if (!string.IsNullOrEmpty(valueOnLineTimeOut) && MathHelper.IsInteger(valueOnLineTimeOut))
                {
                    SystemInfo.OnLineTime0ut = Convert.ToInt16(valueOnLineTimeOut);
                }
            }

            if (Exists("EnableCheckIPAddress"))
            {
                SystemInfo.EnableCheckIPAddress = (String.Compare(GetValue(xmlDocument, "EnableCheckIPAddress"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("CheckOnLine"))
            {
                SystemInfo.CheckOnLine = (String.Compare(GetValue(xmlDocument, "CheckOnLine"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("UseMessage"))
            {
                SystemInfo.UseMessage = (String.Compare(GetValue(xmlDocument, "UseMessage"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("AllowUserToRegister"))
            {
                SystemInfo.AllowUserToRegister = (String.Compare(GetValue(xmlDocument, "AllowUserToRegister"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableRecordLog"))
            {
                SystemInfo.EnableRecordLog = (String.Compare(GetValue(xmlDocument, "EnableRecordLog"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            SystemInfo.CustomerCompanyName = GetValue(xmlDocument, "CustomerCompanyName");
            SystemInfo.ConfigurationFrom = BaseConfiguration.GetConfiguration(GetValue(xmlDocument, "ConfigurationFrom"));
            SystemInfo.SoftName = GetValue(xmlDocument, "SoftName");
            SystemInfo.SoftFullName = GetValue(xmlDocument, "SoftFullName");
            SystemInfo.RootMenuCode = GetValue(xmlDocument, "RootMenuCode");
            SystemInfo.Version = GetValue(xmlDocument, "Version");

            if (Exists("EnableUserAuthorization"))
            {
                SystemInfo.EnableUserAuthorization = (String.Compare(GetValue(xmlDocument, "EnableUserAuthorization"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableModulePermission"))
            {
                SystemInfo.EnableModulePermission = (String.Compare(GetValue(xmlDocument, "EnableModulePermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnablePermissionItem"))
            {
                SystemInfo.EnablePermissionItem = (String.Compare(GetValue(xmlDocument, "EnablePermissionItem"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableTableFieldPermission"))
            {
                SystemInfo.EnableTableFieldPermission = (String.Compare(GetValue(xmlDocument, "EnableTableFieldPermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableTableConstraintPermission"))
            {
                SystemInfo.EnableTableConstraintPermission = (String.Compare(GetValue(xmlDocument, "EnableTableConstraintPermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableUserAuthorizationScope"))
            {
                SystemInfo.EnableUserAuthorizationScope = (String.Compare(GetValue(xmlDocument, "EnableUserAuthorizationScope"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableHandWrittenSignature"))
            {
                SystemInfo.EnableHandWrittenSignature = (String.Compare(GetValue(xmlDocument, "EnableHandWrittenSignature"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }
            if (Exists("EnableOrganizePermission"))
            {
                SystemInfo.EnableOrganizePermission = (String.Compare(GetValue(xmlDocument, "EnableOrganizePermission"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            if (Exists("DefaultPassword"))
            {
                SystemInfo.DefaultPassword = GetValue(xmlDocument, "DefaultPassword");
                SystemInfo.DefaultPassword = SecretHelper.AESDecrypt(SystemInfo.DefaultPassword);
            }

            if (Exists("LoadAllUser"))
            {
                SystemInfo.LoadAllUser = (String.Compare(GetValue(xmlDocument, "LoadAllUser"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            }

            SystemInfo.Service = GetValue(xmlDocument, "Service");
            SystemInfo.LogOnAssembly = Exists("LogOnAssembly") ? GetValue(xmlDocument, "LogOnAssembly") : SystemInfo.LogOnAssembly;
            SystemInfo.LogOnForm = Exists("LogOnForm") ? GetValue(xmlDocument, "LogOnForm") : SystemInfo.LogOnForm;
            SystemInfo.MainForm = Exists("MainForm") ? GetValue(xmlDocument, "MainForm") : SystemInfo.MainForm;
            int.TryParse(GetValue(xmlDocument, "OnLineLimit"), out SystemInfo.OnLineLimit);

            // 打开数据库连接
            SystemInfo.RDIFrameworkDbType = Exists("RDIFrameworkDbType") ? BaseConfiguration.GetDbType(GetValue(xmlDocument, "RDIFrameworkDbType")) : SystemInfo.RDIFrameworkDbType;
            SystemInfo.BusinessDbType = Exists("BusinessDbType") ? BaseConfiguration.GetDbType(GetValue(xmlDocument, "BusinessDbType")) : SystemInfo.BusinessDbType;
            SystemInfo.WorkFlowDbType = Exists("WorkFlowDbType") ? BaseConfiguration.GetDbType(GetValue(xmlDocument, "WorkFlowDbType")) : SystemInfo.WorkFlowDbType;
            SystemInfo.EncryptDbConnection           = (String.Compare(GetValue(xmlDocument, "EncryptDbConnection"), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            SystemInfo.BusinessDbConnectionString    = GetValue(xmlDocument, "BusinessDbConnection");
            SystemInfo.WorkFlowDbConnectionString    = GetValue(xmlDocument, "WorkFlowDbConnection");
            SystemInfo.RDIFrameworkDbConectionString   = GetValue(xmlDocument, "RDIFrameworkDbConection");

            if (SystemInfo.EncryptDbConnection)
            {
                SystemInfo.WorkFlowDbConnection      = SecretHelper.AESDecrypt(SystemInfo.WorkFlowDbConnectionString);
                SystemInfo.BusinessDbConnection      = SecretHelper.AESDecrypt(SystemInfo.BusinessDbConnectionString);
                SystemInfo.RDIFrameworkDbConection     = SecretHelper.AESDecrypt(SystemInfo.RDIFrameworkDbConectionString);
            }
            else
            {
                SystemInfo.WorkFlowDbConnection      = SystemInfo.WorkFlowDbConnectionString;
                SystemInfo.BusinessDbConnection      = SystemInfo.BusinessDbConnectionString;
                SystemInfo.RDIFrameworkDbConection     = SystemInfo.RDIFrameworkDbConectionString;
            }

            SystemInfo.ServiceUserName               = GetValue(xmlDocument, "ServiceUserName");
            SystemInfo.ServicePassword               = GetValue(xmlDocument, "ServicePassword");
            SystemInfo.ServicePassword               = SecretHelper.AESDecrypt(SystemInfo.ServicePassword);            

            SystemInfo.RegisterKey                   = GetValue(xmlDocument, "RegisterKey");
            SystemInfo.NodeTimeout                   = GetValue(xmlDocument, "NodeTimeout");

            // 错误报告相关
            SystemInfo.ErrorReportFrom                 = GetValue(xmlDocument, "ErrorReportFrom");
            SystemInfo.ErrorReportMailUserName       = GetValue(xmlDocument, "ErrorReportMailUserName");
            SystemInfo.ErrorReportMailPassword       = GetValue(xmlDocument, "ErrorReportMailPassword");
            //SMTP服务器，如：smtp.126.com
            SystemInfo.ErrorReportMailServer         = GetValue(xmlDocument, "ErrorReportMailServer");
            SystemInfo.ErrorReportMailPassword       = SecretHelper.AESDecrypt(SystemInfo.ErrorReportMailPassword);
            var blog = GetValue(xmlDocument, "RDIFrameworkBlog");
            if (!string.IsNullOrEmpty(blog))
            {
                SystemInfo.RDIFrameworkBlog = blog;
            }
            var weibo = GetValue(xmlDocument, "RDIFrameworkWeibo");
            if (!string.IsNullOrEmpty(weibo))
            {
                SystemInfo.RDIFrameworkWeibo = weibo;
            }
        }
        #endregion

        public static bool SetValue(XmlDocument xmlDocument, string key, string keyValue)
        {
            return SetValue(xmlDocument, SelectPath, key, keyValue);
        }

        public static bool SetValue(XmlDocument xmlDocument, string selectPath, string key, string keyValue)
        {
            var returnValue = false;
            var xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    xmlNode.Attributes["value"].Value = keyValue;
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region public static void SaveConfig() 保存配置文件
        /// <summary>
        /// 保存配置文件
        /// </summary>
        public static void SaveConfig()
        {
            SaveConfig(ConfigFielName);
        }
        #endregion

        #region public static void SaveConfig(string fileName) 保存到指定的文件
        /// <summary>
        /// 保存到指定的文件
        /// </summary>
        /// <param name="fileName">配置文件</param>
        public static void SaveConfig(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            SetValue(xmlDocument, "CurrentUserName", SystemInfo.CurrentUserName);
            SetValue(xmlDocument, "CurrentPassword", SystemInfo.CurrentPassword);
            SetValue(xmlDocument, "MultiLanguage", SystemInfo.MultiLanguage.ToString());
            SetValue(xmlDocument, "CurrentLanguage", SystemInfo.CurrentLanguage);
            SetValue(xmlDocument, "RememberPassword", SystemInfo.RememberPassword.ToString());
            SetValue(xmlDocument, "EncryptClientPassword", SystemInfo.EncryptClientPassword.ToString());
            SetValue(xmlDocument, "EnableCheckIPAddress", SystemInfo.EnableCheckIPAddress.ToString());
            SetValue(xmlDocument, "CurrentStyle", SystemInfo.CurrentStyle.ToString());
            SetValue(xmlDocument, "CurrentThemeColor", SystemInfo.CurrentThemeColor.ToString());

            SetValue(xmlDocument, "EnableCheckPasswordStrength", SystemInfo.EnableCheckPasswordStrength.ToString());
            SetValue(xmlDocument, "EnableEncryptServerPassword", SystemInfo.EnableEncryptServerPassword.ToString());
            SetValue(xmlDocument, "PasswordMiniLength", SystemInfo.PasswordMiniLength.ToString());
            SetValue(xmlDocument, "NumericCharacters", SystemInfo.NumericCharacters.ToString());
            SetValue(xmlDocument, "PasswordChangeCycle", SystemInfo.PasswordChangeCycle.ToString());
            SetValue(xmlDocument, "CheckOnLine", SystemInfo.CheckOnLine.ToString());
            SetValue(xmlDocument, "OnLineTime0ut", SystemInfo.OnLineTime0ut.ToString());
            SetValue(xmlDocument, "AccountMinimumLength", SystemInfo.AccountMinimumLength.ToString());
            SetValue(xmlDocument, "PasswordErrorLockLimit", SystemInfo.PasswordErrorLockLimit.ToString());
            SetValue(xmlDocument, "PasswordErrorLockCycle", SystemInfo.PasswordErrorLockCycle.ToString());
            SetValue(xmlDocument, "DefaultPassword", SecretHelper.AESEncrypt(SystemInfo.DefaultPassword.ToString()));

            SetValue(xmlDocument, "UseMessage", SystemInfo.UseMessage.ToString());
            SetValue(xmlDocument, "AutoLogOn", SystemInfo.AutoLogOn.ToString());
            SetValue(xmlDocument, "AllowUserToRegister", SystemInfo.AllowUserToRegister.ToString());
            SetValue(xmlDocument, "EnableRecordLog", SystemInfo.EnableRecordLog.ToString());

            // 客户信息配置
            SetValue(xmlDocument, "CustomerCompanyName", SystemInfo.CustomerCompanyName);
            SetValue(xmlDocument, "ConfigurationFrom", SystemInfo.ConfigurationFrom.ToString());
            SetValue(xmlDocument, "SoftName", SystemInfo.SoftName);
            SetValue(xmlDocument, "SoftFullName", SystemInfo.SoftFullName);

            SetValue(xmlDocument, "RootMenuCode", SystemInfo.RootMenuCode);
            SetValue(xmlDocument, "Version", SystemInfo.Version);

            SetValue(xmlDocument, "EnableUserAuthorization", SystemInfo.EnableUserAuthorization.ToString());
            SetValue(xmlDocument, "EnableModulePermission", SystemInfo.EnableModulePermission.ToString());
            SetValue(xmlDocument, "EnableTableFieldPermission", SystemInfo.EnableTableFieldPermission.ToString());
            SetValue(xmlDocument, "EnableTableConstraintPermission", SystemInfo.EnableTableConstraintPermission.ToString());
            SetValue(xmlDocument, "LoadAllUser", SystemInfo.LoadAllUser.ToString());

            SetValue(xmlDocument, "Service", SystemInfo.Service);
            SetValue(xmlDocument, "ServiceUserName", SystemInfo.ServiceUserName);
            SetValue(xmlDocument, "ServicePassword", SecretHelper.AESEncrypt(SystemInfo.ServicePassword));
  


            SetValue(xmlDocument, "LogOnAssembly", SystemInfo.LogOnAssembly);
            SetValue(xmlDocument, "LogOnForm", SystemInfo.LogOnForm);
            SetValue(xmlDocument, "MainForm", SystemInfo.MainForm);

            SetValue(xmlDocument, "OnLineLimit", SystemInfo.OnLineLimit.ToString());
            //SetValue(xmlDocument, "DbType", SystemInfo.BusinessDbType.ToString());

            // 保存数据库配置
            SetValue(xmlDocument, "BusinessDbType", SystemInfo.BusinessDbType.ToString());
            SetValue(xmlDocument, "RDIFrameworkDbType", SystemInfo.RDIFrameworkDbType.ToString());
            SetValue(xmlDocument, "WorkFlowDbType", SystemInfo.WorkFlowDbType.ToString());

            SetValue(xmlDocument, "EncryptDbConnection", SystemInfo.EncryptDbConnection.ToString());
            SetValue(xmlDocument, "RDIFrameworkDbConection", SystemInfo.RDIFrameworkDbConectionString);            
            SetValue(xmlDocument, "BusinessDbConnection", SystemInfo.BusinessDbConnectionString);
            SetValue(xmlDocument, "WorkFlowDbConnection", SystemInfo.WorkFlowDbConnectionString);          
            
            SetValue(xmlDocument, "RegisterKey", SystemInfo.RegisterKey);
            SetValue(xmlDocument, "NodeTimeout", SystemInfo.NodeTimeout);

            //错误报告反馈配置
            SetValue(xmlDocument, "ErrorReportFrom", SystemInfo.ErrorReportFrom);
            SetValue(xmlDocument, "ErrorReportMailServer", SystemInfo.ErrorReportMailServer);
            SetValue(xmlDocument, "ErrorReportMailUserName", SystemInfo.ErrorReportMailUserName);
            SetValue(xmlDocument, "ErrorReportMailPassword", SecretHelper.AESEncrypt(SystemInfo.ErrorReportMailPassword));
            SetValue(xmlDocument, "RDIFrameworkBlog", SystemInfo.RDIFrameworkBlog);
            SetValue(xmlDocument, "RDIFrameworkWeibo", SystemInfo.RDIFrameworkWeibo);
            xmlDocument.Save(fileName);
        }
        #endregion
    }
}