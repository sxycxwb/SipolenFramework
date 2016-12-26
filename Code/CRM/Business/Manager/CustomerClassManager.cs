//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;

namespace CRM
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// CustomerClassManager
    /// 客户分类管理层
    /// 
    /// 修改纪录
    /// 
    ///	2012-08-15 版本：1.0 Edward 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///	<name>Edward</name>
    ///	<date>2012-08-15</date>
    /// </author> 
    /// </summary>
    public partial class CustomerClassManager
    {
        #region public DataTable GetDataTableByPage(string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        /// <summary>
        /// 按条件分页查询
        /// </summary>
        /// <param name="userId">查看用户</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = "CreateOn", string sortDire = "DESC")
        {
            string whereConditional = CustomerClassTable.FieldDeleteMark + " = 0 ";
            // 可以看自己公司的数据
            // whereConditional += " AND " + CustomerClassEntity.FieldCompanyId + " = '" + this.UserInfo.CompanyId + "'";
            // 用户在某个部门
            PiUserManager userManager = new PiUserManager(this.UserInfo);
            if (userManager.IsInOrganize(this.UserInfo.Id, "技术组") || userManager.IsInOrganize(this.UserInfo.Id, "管理组"))
            {
                // 可以看全部
            }
            else if (!string.IsNullOrEmpty(userId))
            {
                // 只能看自己的
                whereConditional += " AND (" + CustomerClassTable.FieldCreateUserId + " = '" + userId + "')";
            }
            else
            {
                // 可以看自己部门的数据
                // whereConditional += " AND " + CustomerClassEntity.FieldDepartmentId + " = '" + this.UserInfo.DepartmentId + "'";
            }

            //auditStatus = auditStatus.Trim();
            //if (!string.IsNullOrEmpty(auditStatus))
            //{
            //    auditStatus = this.DBProvider.SqlSafe(auditStatus);
            //    whereConditional += " AND (" + CustomerClassEntity.FieldAuditStatus + " = '" + auditStatus + "')";
            //}

            searchValue = searchValue.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = this.DBProvider.SqlSafe(searchValue);
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "'%" + searchValue + "%'";
                }
                whereConditional += " AND (" + CustomerClassTable.FieldCreateBy + " LIKE " + searchValue;

                whereConditional += " OR " + CustomerClassTable.FieldClassName + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerClassTable.FieldClassCode + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerClassTable.FieldDescription + " LIKE " + searchValue;

                whereConditional += " OR " + CustomerClassTable.FieldModifiedBy + " LIKE " + searchValue + ")";
            }
            return GetDTByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion
    }
}
