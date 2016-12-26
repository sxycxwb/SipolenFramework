using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    public partial class PiUserManager : DbCommonManager,IDbCommonManager
    {
        public UserInfo ConvertToUserInfo(PiUserEntity userEntity, PiUserLogOnEntity userLogOnEntity = null)
        {
            var userInfo = new UserInfo();
            return ConvertToUserInfo(userInfo, userEntity, userLogOnEntity);
        }

        public UserInfo ConvertToUserInfo(UserInfo userInfo,PiUserEntity userEntity, PiUserLogOnEntity userLogOnEntity = null)
        {
            userInfo.Id = userEntity.Id;
            userInfo.Code = userEntity.Code;
            userInfo.UserName = userEntity.UserName;
            userInfo.RealName = userEntity.RealName;
            userInfo.CompanyId = userEntity.CompanyId;
            userInfo.CompanyName = userEntity.CompanyName;
            userInfo.DepartmentId = userEntity.DepartmentId;
            userInfo.DepartmentName = userEntity.DepartmentName;
            userInfo.WorkgroupId = userEntity.WorkgroupId;
            userInfo.WorkgroupName = userEntity.WorkgroupName;

            if (userLogOnEntity != null)
            {
                userInfo.OpenId = userLogOnEntity.OpenId;
            }

            if (userEntity.SecurityLevel == null)
            {
                userEntity.SecurityLevel = 0;
            }
            else
            {
                userInfo.SecurityLevel = (int)userEntity.SecurityLevel;
            }

            if (!string.IsNullOrEmpty(userEntity.RoleId))
            {
                // 获取角色名称
                var roleManager = new PiRoleManager(DBProvider, UserInfo);
                PiRoleEntity roleEntity = roleManager.GetEntity(userEntity.RoleId);
                if (!string.IsNullOrEmpty(roleEntity.Id))
                {
                    userInfo.RoleName = roleEntity.RealName;
                    userInfo.RoleId = roleEntity.Id;
                }
            }
            return userInfo;
        }

        /// <summary>
        /// 判断用户是否已经登录了？
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>是否已经登录了</returns>
        public bool UserIsLogOn(UserInfo userInfo)
        {
            string[] names = { PiUserTable.FieldId, PiUserTable.FieldDeleteMark, PiUserTable.FieldEnabled};
            Object[] values = { userInfo.Id, 0, 1};
            string id = this.GetId(names, values);
            return !string.IsNullOrEmpty(id) && userInfo.Id.Equals(id);
        }

         public bool IsAdministrator(string userId)
         {
             PiUserEntity entity = this.GetEntity(userId);
             return IsAdministrator(entity);
         }

        public bool IsAdministrator(PiUserEntity entity)
        {
            // 用户是超级管理员
            if (entity.Id.Equals("Administrator"))
            {
                return true;
            }
            if (entity.Code != null && entity.Code.Equals("Administrator"))
            {
                return true;
            }
            if (entity.UserName != null && entity.UserName.Equals("Administrator"))
            {
                return true;
            }

             if (this.UserInfo == null) return false;

             // 用户的默认角色是超级管理员
             var roleManager = new PiRoleManager(this.DBProvider, this.UserInfo);
             // 用户默认角色是否为超级管理员
             PiRoleEntity roleEntity = null;
             if (entity.RoleId != null)
             {
                 // 用户在超级管理员群里
                 string[] roleIds = this.GetRoleIds(entity.Id);
                 foreach (string tmpid in roleIds)
                 {
                     if (tmpid.Equals(DefaultRole.Administrators.ToString()))
                     {
                         return true;
                     }
                     roleEntity = roleManager.GetEntity(tmpid);
                     if (roleEntity.Code != null && roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
                     {
                         return true;
                     }
                 }
             }
             return false;
        }

        #region public DataTable GetDTByDepartment(string departmentId)
        /// <summary>
        /// 按部门获取部门用户
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByDepartment(string departmentId)
        {
            string sqlQuery = " SELECT " + PiUserTable.TableName + ".* "
                // + " ,(SELECT " + PiOrganizeTable.FieldCode + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiUserTable.TableName + ".CompanyId) AS CompanyCode"
                // + " ,(SELECT " + PiOrganizeTable.FieldFullName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiUserTable.TableName + ".CompanyId) AS CompanyFullname "
                // + " ,(SELECT " + PiOrganizeTable.FieldCode + " From " + PiOrganizeTable.TableName + " WHERE Id = " + PiUserTable.TableName + ".DepartmentId) AS DepartmentCode"
                // + " ,(SELECT " + PiOrganizeTable.FieldFullName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = " + PiUserTable.TableName + ".DepartmentId) AS DepartmentName "
                // + " ,(SELECT " + PiOrganizeTable.FieldRealName + " FROM " + PiOrganizeTable.TableName + " WHERE Id = RoleId) AS RoleName "
                + " FROM " + PiUserTable.TableName;

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

        #region public DataTable GetDTByOrganizes(string[] organizeIds) 按工作组、部门、公司获用户列表
        /// <summary>
        /// 按工作组、部门、公司获用户列表
        /// </summary>
        /// <param name="organizeIds">主键数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByOrganizes(string[] organizeIds)
        {
            string organizeList = BusinessLogic.ObjectsToList(organizeIds);
            string sqlQuery = " SELECT .* "
                + " FROM " + PiUserTable.TableName
                // 从用户表里去找
                + " WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 ) "
                + "       AND (" + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                + "       OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + organizeList + ") "
                + "       OR " + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + organizeList + ")) "
                // 从用户兼职表里去取用户
                + " OR " + PiUserTable.FieldId + " IN ("
                        + " SELECT " + PiUserOrganizeTable.FieldUserId
                        + "   FROM " + PiUserOrganizeTable.TableName
                        + "  WHERE (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDeleteMark + " = 0 ) "
                        + "       AND (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldWorkgroupId + " IN ( " + organizeList + ") "
                        + "       OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDepartmentId + " IN (" + organizeList + ") "
                        + "       OR " + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldCompanyId + " IN (" + organizeList + "))) "
                + " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public UserInfo AccountActivation(string openId, out string statusCode)
        /// <summary>
        /// 激活帐户
        /// </summary>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>用户实体</returns>
        public UserInfo AccountActivation(string openId, out string statusCode)
        {
            // 1.用户是否存在？
            UserInfo userInfo = null;
            // 用户没有找到状态
            statusCode = StatusCode.UserNotFound.ToString();
            // 检查是否有效的合法的参数
            if (!String.IsNullOrEmpty(openId))
            {
                PiUserManager userManager = new PiUserManager(DBProvider);
               // DataTable dataTable = userManager.GetDT(PiUserTable.FieldOpenId, openId, PiUserTable.FieldDeleteMark, 0);
                DataTable dataTable = userManager.GetDT(PiUserTable.FieldDeleteMark, 0);
                if (dataTable.Rows.Count == 1)
                {
                    //PiUserEntity userEntity = new PiUserEntity(dataTable);
                    PiUserEntity userEntity = BaseEntity.Create<PiUserEntity>(dataTable);
                    // 3.用户是否被锁定？
                    if (userEntity.Enabled == 0)
                    {
                        statusCode = StatusCode.UserLocked.ToString();
                        return userInfo;
                    }
                    if (userEntity.Enabled == 1)
                    {
                        // 2.用户是否已经被激活？
                        statusCode = StatusCode.UserIsActivate.ToString();
                        return userInfo;
                    }
                    if (userEntity.Enabled == -1)
                    {
                        // 4.成功激活用户
                        statusCode = StatusCode.OK.ToString();
                        userManager.SetProperty(PiUserTable.FieldId, userEntity.Id, PiUserTable.FieldEnabled, 1);
                        return userInfo;
                    }
                }
            }
            return userInfo;
        }
        #endregion

        #region public UserInfo Impersonation(string id) 扮演用户
        /// <summary>
        /// 扮演用户
        /// </summary>
        /// <param name="id">用户主键</param>
        /// <returns>用户类</returns>
        public UserInfo Impersonation(string id, out string statusCode)
        {
            UserInfo userInfo = null;
            // 获得登录信息
            PiUserLogOnEntity entity = new PiUserLogOnManager(this.DBProvider, this.UserInfo).GetEntity(id);
            // 只允许登录一次，需要检查是否自己重新登录了，或者自己扮演自己了
            if (!UserInfo.Id.Equals(id))
            {
                if (SystemInfo.CheckOnLine)
                {
                    if (entity.UserOnLine > 0)
                    {
                        statusCode = StatusCode.ErrorOnLine.ToString();
                        return userInfo;
                    }
                }
            }

            PiUserEntity userEntity = this.GetEntity(id);
            userInfo = this.ConvertToUserInfo(userEntity);
            if (userEntity.IsStaff.Equals("1"))
            {
                // 获得员工的信息
                PiStaffEntity staffEntity = new PiStaffEntity();
                PiStaffManager staffManager = new PiStaffManager(DBProvider, UserInfo);
                DataTable dataTableStaff = staffManager.GetDTById(id);
                staffEntity.GetFrom(dataTableStaff);
                userInfo = staffManager.ConvertToUserInfo(staffEntity,userInfo);
            }
            statusCode = StatusCode.OK.ToString();
            // 登录、重新登录、扮演时的在线状态进行更新
            PiUserLogOnManager userLogOnManager = new PiUserLogOnManager(this.DBProvider, this.UserInfo);
            userLogOnManager.ChangeOnLine(id);
            return userInfo;
        }
        #endregion       

        public DataTable GetDTByIds(string[] userIds)
        {
            string sqlQuery = " SELECT " + PiUserTable.TableName + ".* "
                            + "        , ( SELECT " + PiRoleTable.FieldRealName
                                        + "  FROM " + PiRoleTable.TableName
                                        + " WHERE " + PiRoleTable.FieldId + " = " + PiUserTable.TableName + "." + PiUserTable.FieldRoleId + ") AS RoleName "
                            + "   FROM " + PiUserTable.TableName;
            // 是否需要过滤数据，要考虑安全性
            //if (userIds != null && userIds.Length > 0)
            //{
            sqlQuery += " WHERE ID IN (" + BusinessLogic.ObjectsToList(userIds) + ")";
            //}
            sqlQuery += " ORDER BY " + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }

        #region private int ResetData() 重置数据
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <returns>影响行数</returns>
        private int ResetData()
        {
            // 删除不存在的数据，进行数据同步
            int returnValue = 0;
            string sqlQuery = " DELETE FROM " + PiUserTable.TableName
                            + " WHERE Id NOT IN (SELECT Id FROM " + PiStaffTable.TableName + ") ";
            returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
            // 更新排序顺序情况
            sqlQuery = " UPDATE " + PiUserTable.TableName
                     + " SET SortCode = " + PiStaffTable.TableName + "." + PiStaffTable.FieldSortCode
                     + " FROM " + PiStaffTable.TableName
                     + " WHERE " + PiUserTable.TableName + "." + PiUserTable.FieldId + " = " + PiStaffTable.TableName + "." + PiStaffTable.FieldId;
            returnValue += DBProvider.ExecuteNonQuery(sqlQuery);
            return returnValue;
        }
        #endregion

        #region public int Reset() 重新设置数据
        /// <summary>
        /// 重新设置数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int Reset()
        {
            int returnValue = 0;
            returnValue += this.ResetData();
            PiUserLogOnManager manager = new PiUserLogOnManager(this.DBProvider, this.UserInfo);
            returnValue += manager.ResetVisitInfo();
            return returnValue;
        }
        #endregion

        #region public int CheckUserStaff()
        /// <summary>
        /// 用户已经被删除的员工的UserId设置为Null
        /// </summary>
        /// <returns>影响行数</returns>
        public int CheckUserStaff()
        {
            string sqlQuery = " UPDATE " + PiStaffTable.TableName
                            + " SET " + PiStaffTable.FieldUserId + " = null " 
                            + "WHERE " + PiStaffTable.FieldUserId 
                            + " NOT IN ( SELECT "+ PiUserTable.FieldId +" FROM " + PiUserTable.TableName 
                            +" WHERE " + PiUserTable.FieldDeleteMark + " = 0 ) ";
            return DBProvider.ExecuteNonQuery(sqlQuery);
        }
        #endregion

        #region public string GetCount() 获取用户数
        /// <summary>
        /// 获取用户数
        /// </summary>
        public string GetCount()
        {
            string sqlQuery = " SELECT COUNT(ID) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE DELETEMARK = 0";
            return DBProvider.ExecuteScalar(sqlQuery).ToString();
        }

        public string GetRegistrationCount(int days)
        {
            string sqlQuery = " SELECT COUNT(ID) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE ENABLED = 1 AND (DATEADD(d, " + days.ToString() + ", " + PiUserTable.FieldCreateOn + ") > " + DBProvider.GetDBNow() + ")";
            return DBProvider.ExecuteScalar(sqlQuery).ToString();
        }
        #endregion

        #region public override int BatchSave(DataTable dataTable) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            PiUserEntity userEntity = new PiUserEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[PiUserTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.Delete(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[PiUserTable.FieldId, DataRowVersion.Original].ToString();
                    if (!String.IsNullOrEmpty(id))
                    {
                        userEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(userEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    userEntity.GetFrom(dataRow);
                    returnValue += BusinessLogic.ConvertToNullableInt(this.AddEntity(userEntity)) > 0 ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }
        #endregion

        private string GetSearchConditional(string permissionScopeCode, string search, string[] roleIds, bool? enabled, string auditStates, string departmentId)
        {
            search = StringHelper.GetSearchString(search);
            string whereConditional = PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 "
                            + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldIsVisible + " = 1 ";
            if (enabled != null)
            {
                whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = " + ((bool)enabled ? 1 : 0) + ")";
            }
            if (!String.IsNullOrEmpty(search))
            {
                whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldUserName + " LIKE '" + search + "'"
                            + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldCode + " LIKE '" + search + "'"
                            + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldRealName + " LIKE '" + search + "'"
                            + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldQuickQuery + " LIKE '" + search + "'"
                            + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentName + " LIKE '" + search + "'"
                            + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldDescription + " LIKE '" + search + "')";
            }
            if (!string.IsNullOrEmpty(departmentId))
            {
                var organizeManager = new PiOrganizeManager(this.DBProvider, this.UserInfo);
                string[] organizeIds = organizeManager.GetChildrensId(PiOrganizeTable.FieldId, departmentId, PiOrganizeTable.FieldParentId);
                if (organizeIds != null && organizeIds.Length > 0)
                {
                    whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + StringHelper.ArrayToList(organizeIds,"'") + ")"
                     + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldSubCompanyId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + ")"
                     + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + ")"
                     + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldSubDepartmentId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + ")"
                     + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + "))";

                    // 从兼职表读取用户 
                    whereConditional += " OR " + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN ("
                            + " SELECT " + PiUserOrganizeTable.FieldUserId
                            + "   FROM " + PiUserOrganizeTable.TableName
                            + "  WHERE (" + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDeleteMark + " = 0 ) "
                            + "       AND (" 
                            + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldCompanyId + " = '" + departmentId + "' OR "
                            + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldSubCompanyId + " = '" + departmentId + "' OR "
                            + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldDepartmentId + " = '" + departmentId + "' OR "
                            + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldSubDepartmentId + " = '" + departmentId + "' OR "
                            + PiUserOrganizeTable.TableName + "." + PiUserOrganizeTable.FieldWorkgroupId + " = '" + departmentId + "')) ";
                }
            }
            if (!String.IsNullOrEmpty(auditStates))
            {
                whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldAuditStatus + " = '" + auditStates + "')";
            }
            
            if ((roleIds != null) && (roleIds.Length > 0))
            {
                string roles = StringHelper.ArrayToList(roleIds, "'");
                whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN (" + "SELECT " + PiUserRoleTable.FieldUserId + " FROM " + PiUserRoleTable.TableName + " WHERE " + PiUserRoleTable.FieldRoleId + " IN (" + roles + ")" + "))";
            }

            // 是否过滤用户， 获得组织机构列表
            if ((!UserInfo.IsAdministrator) && (SystemInfo.EnableUserAuthorizationScope))
            {
                // string permissionScopeCode = "Resource.ManagePermission";
                var permissionItemManager = new PiPermissionItemManager(this.DBProvider, this.UserInfo);
                string permissionScopeItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(PiPermissionItemTable.FieldCode, permissionScopeCode));
                if (!string.IsNullOrEmpty(permissionScopeItemId))
                {
                    // 从小到大的顺序进行显示，防止错误发生
                    var userPermissionScopeManager = new UserScopeManager(this.DBProvider, this.UserInfo);
                    string[] organizeIds = userPermissionScopeManager.GetOrganizeIds(this.UserInfo.Id, permissionScopeCode);

                    // 没有任何数据权限
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.None).ToString()))
                    {
                        whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldId + " = NULL ) ";
                    }
                    // 按详细设定的数据
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.Detail).ToString()))
                    {
                        var permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
                        string[] userIds = permissionScopeManager.GetUserIds(UserInfo.Id, permissionScopeCode);
                        whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN (" + BusinessLogic.ObjectsToList(userIds) + ")) ";
                    }
                    // 自己的数据，仅本人
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.User).ToString()))
                    {
                        whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldId + " = '" + this.UserInfo.Id + "') ";
                    }
                    // 用户所在工作组数据
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.UserWorkgroup).ToString()))
                    {
                        whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " = '" + this.UserInfo.WorkgroupId + "') ";
                    }
                    // 用户所在部门数据
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.UserDepartment).ToString()))
                    {
                        whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " = '" + this.UserInfo.DepartmentId + "') ";
                    }
                    // 用户所在公司数据
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.UserCompany).ToString()))
                    {
                        whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " = '" + this.UserInfo.CompanyId + "') ";
                    }
                    // 全部数据，这里就不用设置过滤条件了
                    if (StringHelper.Exists(organizeIds, ((int)PermissionScope.All).ToString()))
                    {
                    }
                }
            }
            return whereConditional;
        }

        public DataTable Search(string permissionScopeCode, string search, string[] roleIds, bool? enabled, string auditStates, string departmentId)
        {
            string sqlQuery = "SELECT " + PiUserTable.TableName + ".* " 
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldFirstVisit
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldPreviousVisit
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLastVisit
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldIPAddress
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldMACAddress
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLogOnCount
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldUserOnLine
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldCheckIPAddress
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldMultiUserLogin
                                     + " FROM PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID ";
            string whereConditional = GetSearchConditional(permissionScopeCode, search, roleIds, enabled, auditStates, departmentId);
            sqlQuery += " WHERE " + whereConditional;
            sqlQuery += " ORDER BY " + PiUserTable.TableName + "." + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }

        public DataTable SearchByPage(string permissionScopeCode, string search, string[] roleIds, bool? enabled, string auditStates, string departmentId, bool showRole, bool userAllInformation, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null)
        {
            string whereConditional = GetSearchConditional(permissionScopeCode, search, roleIds, enabled, auditStates, departmentId);
            this.CurrentTableName = @"(SELECT PIUSER.*, PIUSERLOGON.FIRSTVISIT, PIUSERLOGON.PREVIOUSVISIT, PIUSERLOGON.LASTVISIT, PIUSERLOGON.IPADDRESS, PIUSERLOGON.MACADDRESS, PIUSERLOGON.LOGONCOUNT, PIUSERLOGON.USERONLINE, PIUSERLOGON.CHECKIPADDRESS, PIUSERLOGON.MULTIUSERLOGIN 
                                        FROM PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID 
                                       WHERE PIUSER.DELETEMARK = 0  AND PIUSER.ISVISIBLE = 1 AND (PIUSER.ENABLED = 1) ORDER BY PIUSER.SORTCODE) PIUSER";
            this.SelectField = "*";

            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                case CurrentDbType.Access:
                    this.CurrentTableName = "PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID ";
                    this.SelectField = PiUserTable.TableName + ".* "
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldFirstVisit
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldPreviousVisit
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLastVisit
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldIPAddress
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldMACAddress
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLogOnCount
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldUserOnLine
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldCheckIPAddress
                                                + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldMultiUserLogin;
                    break;
                case CurrentDbType.Oracle:
                case CurrentDbType.MySql:
                case CurrentDbType.DB2:
                    break;
            }
            return GetDTByPage(out recordCount, pageIndex, pageSize, whereConditional, order);
        }

        #region public DataTable GetDTByPage(string searchValue, string departmentId, string roleId, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null) 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="searchValue">查询字段</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="order">排序</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPage(string searchValue, string departmentId, string roleId, out int recordCount, int pageIndex = 0, int pageSize = 20, string order = null)
        {
            string whereConditional = PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 "
                 + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 "
                 + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldIsVisible + " = 1 ";

            if (!String.IsNullOrEmpty(departmentId))
            {
                /*
                用非递归调用的建议方法
                sqlQuery += " AND " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId 
                    + " IN ( SELECT " + PiOrganizeTable.FieldId 
                    + " FROM " + BaseOrganizeEntity.TableName 
                    + " WHERE " + PiOrganizeTable.FieldId + " = " + departmentId + " OR " + PiOrganizeTable.FieldParentId + " = " + departmentId + ")";
                */
                PiOrganizeManager organizeManager = new PiOrganizeManager(this.DBProvider,this.UserInfo);
                string[] organizeIds = organizeManager.GetChildrensId(PiOrganizeTable.FieldId, departmentId, PiOrganizeTable.FieldParentId);
                if (organizeIds != null && organizeIds.Length > 0)
                {
                    whereConditional += " AND (" + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + StringHelper.ArrayToList(organizeIds,"'") + ")"
                         + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldSubCompanyId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + ")"
                         + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + ")"
                         + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldSubDepartmentId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + ")"
                         + " OR " + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN (" + StringHelper.ArrayToList(organizeIds, "'") + "))";
                }
            }
            if (!string.IsNullOrEmpty(roleId))
            {
                string tableNameUserRole = PiUserRoleTable.TableName;
                whereConditional += " AND ( " + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN "
                            + "           (SELECT + " + PiUserRoleTable.FieldUserId
                            + "              FROM " + tableNameUserRole
                            + "             WHERE " + PiUserRoleTable.FieldRoleId + " = '" + roleId + "'"
                            + "               AND " + PiUserRoleTable.FieldEnabled + " = 1"
                            + "                AND " + PiUserRoleTable.FieldDeleteMark + " = 0)) ";
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = "'" + StringHelper.GetSearchString(searchValue) + "'";
                whereConditional += " AND (" + PiUserTable.FieldRealName + " LIKE " + searchValue;
                whereConditional += " OR " + PiUserTable.FieldUserName + " LIKE " + searchValue + ")";
                //whereConditional += " AND (" + searchValue + ")"; ;
            }
            recordCount = DbCommonLibary.GetCount(DBProvider, this.CurrentTableName, whereConditional);
            this.CurrentTableName = "PIUSER LEFT OUTER JOIN PIUSERLOGON ON PIUSER.ID = PIUSERLOGON.ID ";

            switch (DBProvider.CurrentDbType)
            {
                case CurrentDbType.SqlServer:
                case CurrentDbType.Access:
                case CurrentDbType.Oracle:
                case CurrentDbType.MySql:
                    this.SelectField = PiUserTable.TableName + ".* "
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldFirstVisit
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldPreviousVisit
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLastVisit
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldIPAddress
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldMACAddress
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldLogOnCount
                                        + "," + PiUserLogOnTable.TableName + "." + PiUserLogOnTable.FieldUserOnLine;
                    break;
                case CurrentDbType.DB2:
                    break;
            }
            return DbCommonLibary.GetDTByPage(DBProvider, this.CurrentTableName, this.SelectField, pageIndex, pageSize, whereConditional, order);
        }
        #endregion
    }
}
