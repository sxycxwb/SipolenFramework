//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// LinkManManager
    /// 客户联系人管理层
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
    public partial class LinkManManager
    {
        #region public DataTable GetDataTableByPage(string userId,string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
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
        public DataTable GetDataTableByPage(string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = "CreateOn", string sortDire = "DESC")
        {
            string whereConditional = LinkManTable.FieldDeleteMark + " = 0 ";
            // 可以看自己公司的数据
            // whereConditional += " AND " + LinkManTable.FieldCompanyId + " = '" + this.UserInfo.CompanyId + "'";
            // 用户在某个部门
            PiUserManager userManager = new PiUserManager(this.UserInfo);
            if (userManager.IsInOrganize(this.UserInfo.Id, "技术组") || userManager.IsInOrganize(this.UserInfo.Id, "管理组"))
            {
                // 可以看全部
            }
            else if (!string.IsNullOrEmpty(userId))
            {
                // 只能看自己的
            	whereConditional += " AND (" + LinkManTable.FieldCreateUserId + " = '" + userId + "')";
            }
            else
            {
                // 可以看自己部门的数据
                // whereConditional += " AND " + LinkManEntity.FieldDepartmentId + " = '" + this.UserInfo.DepartmentId + "'";
            }

            //auditStatus = auditStatus.Trim();
            //if (!string.IsNullOrEmpty(auditStatus))
            //{
            //    auditStatus = this.DBProvider.SqlSafe(auditStatus);
            //    whereConditional += " AND (" + LinkManTable.FieldAuditStatus + " = '" + auditStatus + "')";
            //}

            searchValue = searchValue.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = this.DBProvider.SqlSafe(searchValue);
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "'%" + searchValue + "%'";
                }
                whereConditional += " AND (" + LinkManTable.FieldCreateBy + " LIKE " + searchValue;

                whereConditional += " OR " + LinkManTable.FieldName + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldSex + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldPostion + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldDepartment + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldMobilePhone + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldTelephone + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldShortNumber + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldIDCard + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldOfficeAddress + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldOfficeFax + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldHomePhone + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldEducation + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldSchool + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldDegree + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldHomeZipCode + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldHomeAddress + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldHomeFax + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldNativePlace + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldParty + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldNation + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldNationality + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldMajor + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldEducationalBackground + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldBloodType + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldQQ + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldEmail + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldInterest + " LIKE " + searchValue;
                whereConditional += " OR " + LinkManTable.FieldDescription + " LIKE " + searchValue;

				whereConditional += " OR " + LinkManTable.FieldModifiedBy + " LIKE " + searchValue + ")";
            }

            return GetDTByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion

        /// <summary>
        ///  得到指定客户Id的主联系人
        /// </summary>
        /// <param name="customerId">客户Id</param>
        /// <returns>联系人实体</returns>
        public LinkManEntity GetMainByCustomerId(string customerId)
        {
            string[] names = {LinkManTable.FieldCustomerId,LinkManTable.FieldMainLinkMan,LinkManTable.FieldDeleteMark,LinkManTable.FieldEnabled};
            string[] values = {customerId,"1","0","1"};
            LinkManEntity linkManEntity = BaseEntity.Create<LinkManEntity>(this.GetDT(names,values));
            return linkManEntity;
        }


        public DataTable GetDataTable()
        {
            DataTable dtLinkMan = new DataTable(LinkManTable.TableName);
            string sqlQuery  = "SELECT B." + CustomerTable.FieldShortName + ",B." + CustomerTable.FieldCompanyName
                             + ",A.* FROM " + LinkManTable.TableName
                             + " A JOIN " + CustomerTable.TableName + " B ON A." + LinkManTable.FieldCustomerId
                             + " = B." + CustomerTable.FieldId
                             + " WHERE A." + LinkManTable.FieldDeleteMark + " = 0 AND B." + CustomerTable.FieldDeleteMark + " = 0 "
                             + " ORDER BY A." + LinkManTable.FieldSortCode;
            DBProvider.Fill(dtLinkMan, sqlQuery);
            return dtLinkMan;
        }
    }
}

