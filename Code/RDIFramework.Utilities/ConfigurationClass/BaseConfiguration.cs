//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// BaseConfiguration
    /// 连接配置。
    /// 
    /// 修改纪录
    /// 
    ///     2013.09.29 版本：3.8 EricHu 删除一些多余的变量定义。
    ///     2013.07.06 版本：3.7 EricHu 增加 EnableCheckIPAddress。
    ///		2012.01.21 版本：3.6 EricHu 自动登录、加密数据库连接功能完善。
    ///		2011.06.08 版本：3.6 EricHu 将读取配置文件进行分离。
    ///		2010.09.29 版本：3.4 EricHu 获得不同的数据库连接字符串 OracleConnection、SqlConnection、OleDbConnection。
    /// 
    /// 版本：2.7
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.09.29</date>
    /// </author> 
    /// </summary>
    public class BaseConfiguration
    {
        #region public BaseConfiguration()
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseConfiguration()
        {
        }
        #endregion

        #region public BaseConfiguration(string softName)
        /// <summary>
        /// 设定当前软件Id
        /// </summary>
        /// <param name="softName">当前软件Id</param>
        public BaseConfiguration(string softName)
        {
            SystemInfo.SoftName = softName;
        }
        #endregion

        #region public static DbType GetDbType(string dbType)
        /// <summary>
        /// 数据库连接的类型判断
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns>数据库类型</returns>
        public static CurrentDbType GetDbType(string dbType)
        {
            CurrentDbType returnValue = CurrentDbType.SqlServer;
            foreach (CurrentDbType currentDbType in Enum.GetValues(typeof(CurrentDbType)))
            {
                if (currentDbType.ToString().Equals(dbType))
                {
                    returnValue = currentDbType;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static ConfigurationCategory GetConfiguration(string configuration)
        /// <summary>
        /// 配置信息的类型判断
        /// </summary>
        /// <param name="configuration">配置信息类型</param>
        /// <returns>配置信息类型</returns>
        public static ConfigurationCategory GetConfiguration(string configuration)
        {
            ConfigurationCategory returnValue = ConfigurationCategory.Configuration;
            foreach (ConfigurationCategory configurationCategory in Enum.GetValues(typeof(ConfigurationCategory)))
            {
                if (configurationCategory.ToString().Equals(configuration))
                {
                    returnValue = configurationCategory;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetSetting()
        /// <summary>
        /// 读取配置信息
        /// </summary>
        public static void GetSetting()
        {
            // 读取注册表
            if (SystemInfo.ConfigurationFrom == ConfigurationCategory.RegistryKey)
            {
                RegistryHelper.GetConfig();
            }
            // 读取配置文件
            if (SystemInfo.ConfigurationFrom == ConfigurationCategory.Configuration)
            {
                ConfigurationHelper.GetConfig();
            }
            // 读取个性化配置文件
            if (SystemInfo.ConfigurationFrom == ConfigurationCategory.UserConfig)
            {
                UserConfigHelper.GetConfig();
            }
        }
        #endregion
    }
}