//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
//-----------------------------------------------------------------

using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// AuditStatus
    /// 审核状态。
    /// 
    /// 修改纪录
    /// 
    ///     2013.10.13 版本：1.0 XuWangBin 改进枚举类型的说明。
    ///		2012.09.04 版本：1.0 XuWangBin 重新调整主键的规范化。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2009.09.04</date>
    /// </author> 
    /// </summary>    
    #region public enum AuditStatus 审核状态
    public enum AuditStatus
    {
        /// <summary>
        /// 00 草稿状态
        /// </summary>
        [EnumDescription("草稿")]
        Draft = 0,

        /// <summary>
        /// 01 开始审核
        /// </summary>
        [EnumDescription("送审")]
        StartAudit = 1,

        /// <summary>
        /// 02 审核通过
        /// </summary>
        [EnumDescription("通过")]
        AuditPass = 2, 
        
        /// <summary>
        /// 03 待审核
        /// </summary>
        [EnumDescription("待审")]
        WaitForAudit = 3,  

        /// <summary>
        /// 04 转发
        /// </summary>
        [EnumDescription("转发")]
        Transmit = 4,  
        
        /// <summary>
        /// 05 已退回
        /// </summary>
        [EnumDescription("退回")]
        AuditReject = 5,
        
        /// <summary>
        /// 06 审核结束
        /// </summary>
        [EnumDescription("完成")]
        AuditComplete = 6,

        /// <summary>
        /// 07 撤销,废弃
        /// </summary>
        [EnumDescription("废弃")]
        AuditQuash = 7
    }
    #endregion
}