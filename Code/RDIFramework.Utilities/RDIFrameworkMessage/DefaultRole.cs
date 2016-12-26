//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------


namespace RDIFramework.Utilities
{
    /// <summary>
    /// DefaultRole
    /// 默认角色。
    /// 
    /// 这个应该是角色类别才对，不应该是用户类别
    /// 
    /// 修改纪录
    ///
    /// 版本：1.1
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.09.18</date>
    /// </author> 
    /// </summary>
    public enum DefaultRole
    {
        Config,                 // 系统配置员
        Administrator,          // 系统管理员
        Administrators,         // 系统管理组
        ChairmanOfTheBoard,     // 董事长
        VicePrecident,          // 副总裁
        GeneralManager,         // 总经理
        ViceManager,            // 副经理
        Minister,               // 部长
        ViceMinsiter,           // 副部长
        HumanResourceManager,   // 人力资源主管
        HumanResource,          // 人力资源
        FinanceManager,         // 财务人员
        Finance,                // 财务人员
        EquipmentManager,       // 设备管理主管
        Equipment,              // 设备管理人员
        Staff,                  // 普通员工
        User                    // 普通用户
    }
}  