/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-20 16:35:54
 ******************************************************************************/

using System;

namespace RDIFramework.BizLogic
{
  using RDIFramework.Utilities;

    /// <summary>
    /// PiUserOrganizeEntity
    /// 用户账户组织关系表
    ///
    /// 修改纪录
    ///
    ///     2014-07-30 版本: 2.8 EricHu 以自动属性进行重新组织。
    ///		2012-03-02 版本：3.0 EricHu 创建主键。
    ///
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class PiUserOrganizeEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 用户账户主键
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        public String CompanyId { get; set; }

        /// <summary>
        /// 子公司代码
        /// </summary>
        public String SubCompanyId { get; set; }

        /// <summary>
        /// 部门代码
        /// </summary>
        public String DepartmentId { get; set; }

        /// <summary>
        /// 子部门代码
        /// </summary>
        public String SubDepartmentId { get; set; }

        /// <summary>
        /// 工作组代码
        /// </summary>
        public String WorkgroupId { get; set; }

        /// <summary>
        /// 角色[职位]主键
        /// </summary>
        public String RoleId { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeleteMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PiUserOrganizeEntity()
        {
            this.Enabled = 1;
            this.DeleteMark = 0;
            this.CreateOn = DateTime.Now;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        protected override BaseEntity GetFrom(IDataRow dataRow)
        {
            this.Id = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldId]);
            this.UserId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldUserId]);
            this.CompanyId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldCompanyId]);
            this.SubCompanyId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldSubCompanyId]);
            this.DepartmentId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldDepartmentId]);
            this.SubDepartmentId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldSubDepartmentId]);
            this.WorkgroupId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldWorkgroupId]);
            this.RoleId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldRoleId]);
            this.Enabled = BusinessLogic.ConvertToNullableInt(dataRow[PiUserOrganizeTable.FieldEnabled]);
            this.Description = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldDescription]);
            this.DeleteMark = BusinessLogic.ConvertToNullableInt(dataRow[PiUserOrganizeTable.FieldDeleteMark]);
            this.CreateOn = BusinessLogic.ConvertToNullableDateTime(dataRow[PiUserOrganizeTable.FieldCreateOn]);
            this.CreateUserId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldCreateUserId]);
            this.CreateBy = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldCreateBy]);
            this.ModifiedOn = BusinessLogic.ConvertToNullableDateTime(dataRow[PiUserOrganizeTable.FieldModifiedOn]);
            this.ModifiedUserId = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldModifiedUserId]);
            this.ModifiedBy = BusinessLogic.ConvertToString(dataRow[PiUserOrganizeTable.FieldModifiedBy]);
            return this;
        }
    }
}
