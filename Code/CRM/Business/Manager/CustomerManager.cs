//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , HuaSi TECH, Ltd. 
//--------------------------------------------------------------------

using System.Data;

namespace CRM
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// CustomerManager
    /// 客户信息管理层
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
    public partial class CustomerManager
    {
        #region public DataTable GetDataTableByPage(string userId, string auditStatus, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        /// <summary>
        /// 按条件分页查询
        /// </summary>
        /// <param name="userId">查看用户</param>
		/// <param name="auditStatus">审核状态</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(string userId,string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = "CreateOn", string sortDire = "DESC")
        {
            string whereConditional = CustomerTable.FieldDeleteMark + " = 0 ";
            // 可以看自己公司的数据
            // whereConditional += " AND " + CustomerEntity.FieldCompanyId + " = '" + this.UserInfo.CompanyId + "'";
            // 用户在某个部门
            PiUserManager userManager = new PiUserManager(this.UserInfo);
            if (userManager.IsInOrganize(this.UserInfo.Id, "技术组") || userManager.IsInOrganize(this.UserInfo.Id, "管理组"))
            {
                // 可以看全部
            }
            else if (!string.IsNullOrEmpty(userId))
            {
                // 只能看自己的
            	whereConditional += " AND (" + CustomerTable.FieldCreateUserId + " = '" + userId + "')";
            }
            else
            {
                // 可以看自己部门的数据
                // whereConditional += " AND " + CustomerEntity.FieldDepartmentId + " = '" + this.UserInfo.DepartmentId + "'";
            }

            //auditStatus = auditStatus.Trim();
            //if (!string.IsNullOrEmpty(auditStatus))
            //{
            //    auditStatus = this.DBProvider.SqlSafe(auditStatus);
            //    whereConditional += " AND (" + CustomerTable.FieldAuditStatus + " = '" + auditStatus + "')";
            //}

            searchValue = searchValue.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = this.DBProvider.SqlSafe(searchValue);
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "'%" + searchValue + "%'";
                }
                whereConditional += " AND (" + CustomerTable.FieldCreateBy + " LIKE " + searchValue;
                
                whereConditional += " OR " + CustomerTable.FieldFullName + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldShortName + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldCompanyName + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldCompanyAddress + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldPostalCode + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldCompanyPhone + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldCompanyFax + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldWebAddress + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldLicenceNo + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldChieftain + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldBank + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldBankAccount + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldLocalTaxNo + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldNationalTaxNo + " LIKE " + searchValue;
                whereConditional += " OR " + CustomerTable.FieldDescription + " LIKE " + searchValue;

				whereConditional += " OR " + CustomerTable.FieldModifiedBy + " LIKE " + searchValue + ")";
            }
            return GetDTByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion

        /// <summary>
        /// 得到数据通过分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns>DataTable</returns>
        public DataTable GetDTByCategory(string category)
        {
            DataTable dtCustomer = new DataTable();
            string[] categoryIds = {};
            if (!string.IsNullOrEmpty(category.Trim()))
            {
                string sqlQuery = " WITH Tree AS (SELECT Id "
                        + "       FROM " + CustomerClassTable.TableName
                        + "       WHERE Id IN ('" + category + "') "
                        + "       UNION ALL "
                        + "      SELECT ResourceTree.Id "
                        + "        FROM " + CustomerClassTable.TableName + " AS ResourceTree INNER JOIN "
                        + "             Tree AS A ON A." + CustomerClassTable.FieldId + " = ResourceTree." + CustomerClassTable.FieldParentId
                        + "        AND ResourceTree." + CustomerClassTable.FieldDeleteMark + "=0 ) "
                        + " SELECT * "
                        + "   FROM Tree ";
                DataTable dataTable = new DataTable(CustomerClassTable.TableName);
                DBProvider.Fill(dataTable,sqlQuery);
                categoryIds = BusinessLogic.FieldToArray(dataTable, BusinessLogic.FieldId);
                //CustomerClassManager customerManager = new CustomerClassManager();                
                //DataTable dt = GetDT(CustomerTable.FieldCustomerClassID, categoryIds);                
            }

            string sqlString = "SELECT * FROM " + CustomerTable.TableName + " WHERE " + CustomerTable.FieldDeleteMark + " =0 ";

            if (categoryIds != null & categoryIds.Length > 0)
            {
                sqlString += " AND " + CustomerTable.FieldCustomerClassID + " IN (" + BusinessLogic.ArrayToList(categoryIds) + ")";  
            }

            return DBProvider.Fill(dtCustomer, sqlString);
        }

        /// <summary>
        /// 得到客户-主联系人信息
        /// </summary>
        /// <param name="customerId">客户主键</param>
        /// <returns>DataTable</returns>
        public DataTable GetCustomerContactInfo(string customerId)
        {
            /*
             SELECT tab1.FullName,tab1.ShortName,tab1.CompanyName,tab1.PostalCode,tab1.CompanyPhone,tab1.CompanyFax,tab1.CompanyAddress, 
		     tab2.Name,tab2.Sex,tab2.Postion,tab2.Department,tab2.MobilePhone,tab2.Telephone,tab2.OfficeAddress,tab2.OfficeFax,tab2.QQ,tab2.Email
             FROM dbo.Customer tab1 JOIN dbo.LinkMan tab2
             ON tab1.Id = tab2.CustomerId 
             WHERE tab1.Id = 2 AND tab1.DeleteMark = 0 AND tab2.DeleteMark = 0 AND tab2.MainLinkMan = 1
             */
            DataTable dtCustomerContactInfo = new DataTable();
            string sqlQuery = " SELECT tab1." + CustomerTable.FieldFullName + " AS 客户名称,tab1." + CustomerTable.FieldShortName + " AS 客户简称,tab1." + CustomerTable.FieldCompanyName
                            + " AS 公司名称,tab1." + CustomerTable.FieldPostalCode + " AS 公司邮编,tab1." + CustomerTable.FieldCompanyPhone + " AS 公司电话,tab1." + CustomerTable.FieldCompanyFax
                            + " AS 公司传真,tab1." + CustomerTable.FieldCompanyAddress + " AS 公司地址,tab2." + LinkManTable.FieldName + " AS 联系人名称,tab2." + LinkManTable.FieldSex
                            + " AS 联系人性别,tab2." + LinkManTable.FieldPostion + " AS 联系人职位,tab2." + LinkManTable.FieldDepartment + " AS 联系人所在部门,tab2." + LinkManTable.FieldMobilePhone
                            + " AS 联系人手机号码,tab2." + LinkManTable.FieldTelephone + " AS 联系人电话,tab2." + LinkManTable.FieldOfficeAddress + " AS 联系人办公地址,tab2." + LinkManTable.FieldOfficeFax
                            + " AS 联系人办公传真,tab2." + LinkManTable.FieldQQ + " AS 联系人QQ号,tab2." + LinkManTable.FieldEmail + " AS 联系人邮箱 "
                            + " FROM "         + CustomerTable.TableName + " tab1 JOIN " + LinkManTable.TableName + " tab2 "
                            + " ON tab1."      + CustomerTable.FieldId + " = tab2." + LinkManTable.FieldCustomerId
                            + " WHERE tab1."   + CustomerTable.FieldDeleteMark + " = 0 AND tab2." + LinkManTable.FieldDeleteMark
                            + " = 0 AND tab2." + LinkManTable.FieldMainLinkMan + " = 1 AND tab1." + CustomerTable.FieldId + " = " + customerId;                            
            
            return DBProvider.Fill(dtCustomerContactInfo, sqlQuery);
        }
    }
}
