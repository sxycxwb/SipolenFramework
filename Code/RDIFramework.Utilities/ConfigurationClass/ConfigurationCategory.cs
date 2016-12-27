//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

namespace RDIFramework.Utilities
{
    /// <summary>
    /// ConfigurationCategory
    /// 系统配置信息读取。
    /// 
    /// 修改纪录
    /// 
    ///		2013.06.08 版本：2.4 XuWangBin 将命名修改为 ConfigurationCategory。 
    ///		2012.04.14 版本：2.1 XuWangBin 检查程序格式通过，不再进行修改主键操作。 
    ///		2011.11.17 版本：2.0 XuWangBin 变量命规范化。
    ///		2010.09.29 版本：1.0 XuWangBin 重新调整主键的规范化。
    ///		
    /// 版本：2.7
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.09.29</date>
    /// </author> 
    /// </summary>  
    public enum ConfigurationCategory
    {
        RegistryKey,    // 从注册表读取
        Configuration,  // 从配置文件读取
        UserConfig      // 用户的配置文件
    }
}