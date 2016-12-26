//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , EricHu. 
//-----------------------------------------------------------------

namespace RDIFramework.Utilities
{
    /// <summary>
    /// OrganizeCategory
    /// 组织机构类别。
    /// 
    /// 修改纪录
    ///     2014-05-28 v2.8 EricHu 取消Group与Area枚举值。
    ///     2010.03.16 版本：1.0 EricHu 结构优化整理。
    ///		
    /// 版本：1.1
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2010.03.16</date>
    /// </author> 
    /// </summary>
    public enum OrganizeCategory
    {
        //Group,          // 集团
        //Area,           // 区域
        Company,        // 公司
        SubCompany,     // 子公司
        Department,     // 部门
        SubDepartment,  // 子部门
        Workgroup       // 工作组
    }
}