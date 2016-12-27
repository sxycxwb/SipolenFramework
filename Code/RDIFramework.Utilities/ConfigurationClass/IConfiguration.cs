//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin.  
//-----------------------------------------------------------------

using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// IConfiguration
    /// 读取配置文件接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2010.09.29 版本：1.0 XuWangBin 创建代码。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.09.29</date>
    /// </author> 
    /// </summary>
    public interface IConfiguration
    {
        String GetValue(String key);
    }
}
