using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class PiUserManager : DbCommonManager
    {
        /// <summary>
        /// 用户是否在某部门
        /// </summary>
        /// <param name="organizeName">部门名称</param>
        /// <returns>存在</returns>
        public bool IsInOrganize(string organizeName)
        {
            return IsInOrganize(this.UserInfo.Id, organizeName);
        }

        /// <summary>
        /// 用户是否在某部门
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="organizeName">部门名称</param>
        /// <returns>存在</returns>
        public bool IsInOrganize(string userId, string organizeName)
        {
            var returnValue = false;
            // 把部门的主键找出来
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiOrganizeTable.FieldFullName, organizeName),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldEnabled, 1),
                new KeyValuePair<string, object>(PiOrganizeTable.FieldDeleteMark, 0)
            };
            var organizeManager = new PiOrganizeManager(this.UserInfo);
            var organizeId = organizeManager.GetId(parameters);
            if (string.IsNullOrEmpty(organizeId))
            {
                return returnValue;
            }
            // 用户组织机构关联关系
            var organizeIds = GetAllOrganizeIds(userId);
            if (organizeIds == null || organizeIds.Length <= 0)
            {
                return returnValue;
            }
            // 用户的部门是否存在这些部门里
            returnValue = StringHelper.Exists(organizeIds, organizeId);
            return returnValue;
        }

        #region public DataTable GetDataTableByDepartment(string departmentId)
        /// <summary>
        /// 按部门获取部门用户
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByDepartment(string departmentId)
        {
            var sqlQuery = " SELECT " + PiUserTable.TableName + ".*  FROM " + PiUserTable.TableName;

            sqlQuery += " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 ";
            sqlQuery += " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 ) ";

            if (!String.IsNullOrEmpty(departmentId))
            {
                // 从用户表
                sqlQuery += " AND ((" + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " = '" + departmentId + "') ";
                // 从兼职表读取用户 
                sqlQuery += " OR " + PiUserTable.FieldId + " IN ("
                        + " SELECT " + PiUserOrganizeTable.FieldUserId
                        + "   FROM " + PiUserOrganizeTable.TableName
                        + "  WHERE (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDeleteMark + " = 0 ) "
                        + "       AND (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDepartmentId + " = '" + departmentId + "'))) ";

            }
            sqlQuery += " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetDataTableByOrganizes(string[] organizeIds) 按工作组、部门、公司获用户列表
        /// <summary>
        /// 按工作组、部门、公司获用户列表
        /// </summary>
        /// <param name="organizeIds">主键数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByOrganizes(string[] organizeIds)
        {
            var organizeList = BusinessLogic.ObjectsToList(organizeIds);
            var sqlQuery = " SELECT * "
                + " FROM " + PiUserTable.TableName
                // 从用户表里去找
                + " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 ) "
                + "       AND (" + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                + "       OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + organizeList + ") "
                + "       OR " + PiUserTable.TableName + "." + PiUserTable.FieldSubCompanyId + " IN (" + organizeList + ") "
                + "       OR " + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + organizeList + ")) "
                // 从用户兼职表里去取用户
                + " OR " + PiUserTable.FieldId + " IN ("
                        + " SELECT " + PiUserOrganizeTable.FieldUserId
                        + "   FROM " + PiUserOrganizeTable.TableName
                        + "  WHERE (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDeleteMark + " = 0 ) "
                        + "       AND (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                        + "       OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDepartmentId + " IN (" + organizeList + ") "
                         + "       OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldSubDepartmentId + " IN (" + organizeList + ") "
                        + "       OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldCompanyId + " IN (" + organizeList + "))) "
                + " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        public DataTable GetChildrenUsers(string organizeId)
        {
            string[] organizeIds = null;
            var organizeManager = new PiOrganizeManager(this.DBProvider, this.UserInfo);
            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    var organizeCode = this.GetCodeById(organizeId);
                    organizeIds = organizeManager.GetChildrensIdByCode(PiOrganizeTable.FieldCode, organizeCode);
                    break;
                case CurrentDbType.Oracle:
                    organizeIds = organizeManager.GetChildrensId(PiOrganizeTable.FieldId, organizeId, PiOrganizeTable.FieldParentId);
                    break;
            }
            return this.GetDTByOrganizes(organizeIds);
        }

        public List<PiUserEntity> GetListByDepartment(string departmentId)
        {
            string str2 = "SELECT " + PiUserTable.TableName + ".*  FROM " + PiUserTable.TableName;
            string str3 = str2 + " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 ";
            string commandText = str3 + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 ) ";
            if (!string.IsNullOrEmpty(departmentId))
            {
                string str4 = commandText;
                commandText = str4 + " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " = '" + departmentId + "') ";
            }
            string str5 = commandText;
            commandText = str5 + " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            IDataReader dr = base.DBProvider.ExecuteReader(commandText);
            return base.GetList<PiUserEntity>(dr);
        }

        public List<PiUserEntity> GetChildrenUserList(string organizeId)
        {
            string[] organizeIds = null;
            var manager = new PiOrganizeManager(base.DBProvider, base.UserInfo);
            switch (base.DBProvider.CurrentDbType)
            {
                case CurrentDbType.Oracle:
                    organizeIds = manager.GetChildrensId(PiOrganizeTable.FieldId, organizeId, PiOrganizeTable.FieldParentId);
                    break;

                case CurrentDbType.SqlServer:
                case CurrentDbType.Access:
                    {
                        string codeById = manager.GetCodeById(organizeId);
                        organizeIds = manager.GetChildrensIdByCode(PiOrganizeTable.FieldCode, codeById);
                        break;
                    }
            }
            return this.GetListByOrganizes(organizeIds);
        }

        public List<PiUserEntity> GetListByOrganizes(string[] organizeIds)
        {
            string commandText = this.GetUserSQL(organizeIds, false);
            IDataReader dr = base.DBProvider.ExecuteReader(commandText);
            return base.GetList<PiUserEntity>(dr);
        }

        private string GetUserSQL(string[] organizeIds, bool idOnly = false)
        {
            var field = idOnly ? PiUserTable.FieldId : "*";
            var organizeList = BusinessLogic.ObjectsToList(organizeIds);
            var sqlQuery = "SELECT " + field
                + " FROM " + PiUserTable.TableName
                // 从用户表里去找
                + " WHERE " + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 "
                + "       AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 "
                + "       AND (" + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                + "             OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + organizeList + ") "
                + "             OR " + PiUserTable.TableName + "." + PiUserTable.FieldSubCompanyId + " IN (" + organizeList + ") "
                + "             OR " + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + organizeList + ")) "
                // 从用户兼职表里去取用户
                + " OR " + PiUserTable.FieldId + " IN ("
                        + "SELECT " + PiUserOrganizeTable.FieldUserId
                        + "   FROM " + PiUserOrganizeTable.TableName
                        + "  WHERE (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDeleteMark + " = 0 ) "
                        + "       AND (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                        + "             OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDepartmentId + " IN (" + organizeList + ") "
                        + "             OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldSubCompanyId + " IN (" + organizeList + ") "
                        + "             OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldCompanyId + " IN (" + organizeList + "))) "
                + " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            return sqlQuery;
        }

        public string[] GetUserIds(string organizeId)
        {
            string[] userIds = null;
            if (!String.IsNullOrEmpty(organizeId))
            {
                var sqlQuery = this.GetUserSQL(new string[] { organizeId }, true);
                var dt = DBProvider.Fill(sqlQuery);
                userIds = BusinessLogic.FieldToArray(dt, PiUserTable.FieldId);
            }
            return userIds;
        }

        public string[] GetUserIds(string[] organizeIds, string[] roleIds)
        {
            string[] companyUsers = null;
            if (organizeIds != null)
            {
                var sqlQuery = this.GetUserSQL(organizeIds, true);
                var dt = DBProvider.Fill(sqlQuery);
                companyUsers = BusinessLogic.FieldToArray(dt, PiUserTable.FieldId);
            }

            string[] roleUsers = null;
            if (roleIds != null)
            {
                roleUsers = this.GetUserIds(roleIds);
            }
            var userIds = BusinessLogic.Concat(companyUsers, companyUsers, roleUsers);
            return userIds;
        }

        public string[] GetUserIds(string[] userIds, string[] organizeIds, string[] roleIds)
        {
            return BusinessLogic.Concat(userIds, this.GetUserIds(organizeIds, roleIds));
        }

        #region public DataTable SearchByDepartment(string departmentId, string searchValue)  按部门获取部门用户,包括子部门的用户
        /// <summary>
        /// 按部门获取部门用户,包括子部门的用户
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <param name="searchValue"></param>
        /// <returns>数据表</returns>
        public DataTable SearchByDepartment(string departmentId, string searchValue)
        {
            var sqlQuery = " SELECT " + PiUserTable.TableName + ".* "
                            + " FROM " + PiUserTable.TableName;
            sqlQuery += " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 ";
            sqlQuery += " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 ) ";
            if (!String.IsNullOrEmpty(departmentId))
            {
                /*
                用非递归调用的建议方法
                sqlQuery += " AND " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId 
                    + " IN ( SELECT " + PiOrganizeTable.FieldId 
                    + " FROM " + PiOrganizeTable.TableName 
                    + " WHERE " + PiOrganizeTable.FieldId + " = " + departmentId + " OR " + PiOrganizeTable.FieldParentId + " = " + departmentId + ")";
                */
                var organizeManager = new PiOrganizeManager(this.DBProvider, this.UserInfo);
                var organizeIds = organizeManager.GetChildrensId(PiOrganizeTable.FieldId, departmentId, PiOrganizeTable.FieldParentId);
                if (organizeIds != null && organizeIds.Length > 0)
                {
                    sqlQuery += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + BusinessLogic.ArrayToList(organizeIds,"'") + ")"
                     + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + BusinessLogic.ArrayToList(organizeIds, "'") + ")"
                     + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN (" + BusinessLogic.ArrayToList(organizeIds, "'") + "))";
                }
            }
            var dbParameters = new List<IDbDataParameter>();
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                sqlQuery += " AND (" + PiUserTable.FieldUserName + " LIKE " + DBProvider.GetParameter(PiUserTable.FieldUserName);
                sqlQuery += " OR " + PiUserTable.FieldCode + " LIKE " + DBProvider.GetParameter(PiUserTable.FieldCode);
                sqlQuery += " OR " + PiUserTable.FieldRealName + " LIKE " + DBProvider.GetParameter(PiUserTable.FieldRealName);
                sqlQuery += " OR " + PiUserTable.FieldDepartmentName + " LIKE " + DBProvider.GetParameter(PiUserTable.FieldDepartmentName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DBProvider.MakeParameter(PiUserTable.FieldUserName, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(PiUserTable.FieldCode, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(PiUserTable.FieldRealName, searchValue));
                dbParameters.Add(DBProvider.MakeParameter(PiUserTable.FieldDepartmentName, searchValue));
            }
            sqlQuery += " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery, dbParameters.ToArray());
        }
        #endregion

        #region public string[] GetAllOrganizeIds(string userId) 获取用户的所有所在部门主键数组
        /// <summary>
        /// 获取用户的所有所在部门主键数组（包括兼职的部门）
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetAllOrganizeIds(string userId)
        {
            // 被删除的不应该显示出来            
            var sqlQuery = string.Format(@"SELECT COMPANYID AS ID FROM PIUSER
                                WHERE DELETEMARK = 0 AND ENABLED =1 AND COMPANYID IS NOT NULL  AND (ID = '{0}')
                                UNION
                                SELECT SUBCOMPANYID AS ID FROM PIUSER
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND SUBCOMPANYID IS NOT NULL AND (ID = '{0}')
                                UNION
                                SELECT DEPARTMENTID AS ID FROM PIUSER
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND DEPARTMENTID IS NOT NULL AND (ID = '{0}')
                                UNION
                                SELECT SUBDEPARTMENTID AS ID FROM PIUSER
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND SUBDEPARTMENTID IS NOT NULL AND (ID = '{0}')
                                UNION
                                SELECT WORKGROUPID AS ID FROM PIUSER
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND WORKGROUPID IS NOT NULL AND (ID = '{0}')

                                UNION
                                SELECT COMPANYID AS ID FROM PIUSERORGANIZE
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND COMPANYID IS NOT NULL AND (USERID = '{0}')
                                UNION
                                SELECT SUBCOMPANYID AS ID FROM PIUSERORGANIZE
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND SUBCOMPANYID IS NOT NULL AND (USERID = '{0}')
                                UNION
                                SELECT DEPARTMENTID AS ID FROM PIUSERORGANIZE
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND DEPARTMENTID IS NOT NULL AND (USERID = '{0}')
                                UNION
                                SELECT SUBDEPARTMENTID AS ID FROM PIUSERORGANIZE
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND SUBDEPARTMENTID IS NOT NULL AND (USERID = '{0}')
                                UNION
                                SELECT WORKGROUPID AS ID FROM PIUSERORGANIZE
                                WHERE DELETEMARK = 0 AND ENABLED =1  AND WORKGROUPID IS NOT NULL AND (USERID = '{0}')", userId);           
            var dataTable = DBProvider.Fill(sqlQuery);
            return BusinessLogic.FieldToArray(dataTable, PiUserTable.FieldId);
        }
        #endregion
    }
}
