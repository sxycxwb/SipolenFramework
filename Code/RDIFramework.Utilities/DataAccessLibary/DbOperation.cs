//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

namespace RDIFramework.Utilities
{
    /// <summary>
    /// DbOperation
    /// 有关数据库操作的定义。
    /// 
    /// 修改纪录
    /// 
    /// 	2012.03.19 版本：3.2 XuWangBin 增加 ExecProcedure方法，用于执行存储过程。
    ///		2012.02.04 版本：3.2 XuWangBin 修改为 DbOperation。
    ///		2011.07.30 版本：3.1 XuWangBin 增加 Truncate 方法。
    ///		2011.04.14 版本：3.0 XuWangBin 检查程序格式通过，不再进行修改主键操作。
    ///		2011.04.18 版本：2.0 XuWangBin 重新调整主键的规范化。
    ///		
    /// 版本：3.0
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2010.04.14</date>
    /// </author> 
    /// </summary>
    public enum DbOperation
    {
        Select,
        Insert,
        Update,
        Delete,
        Truncate,
        ExecProcedure
    }

    public enum DbOperationType
    {
        SELECT,
        ADD,
        UPDATE,
        DELETE,
        SETDELMARK,
        NOACTION
    }
}