﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------
using System.Text;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// CurrentDbType
    /// 有关数据库连接类型定义。
    /// 
    /// 修改纪录
    /// 
    ///		2012.04.14 版本：2.5 XuWangBin 检查程序格式通过，不再进行修改主键操作。
    ///		2010.11.17 版本：2.1 XuWangBin 变量命规范化。
    ///		2010.04.18 版本：2.0 XuWangBin 重新调整主键的规范化。
    ///		
    /// 版本：2.5
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.04.14</date>
    /// </author> 
    /// </summary>
    public enum CurrentDbType
    {
        Oracle,
        SqlServer,
        Access,
        DB2,
        MySql,
        SQLite
    }
}