/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 14:28:48
 ******************************************************************************/

using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
    

    /// <summary>
    /// PiPermissionManager
    /// 操作权限存储表
    ///
    /// 修改纪录
    ///
    ///		2012-03-02 版本：1.0 EricHu 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class PiPermissionManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiPermissionManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = PiPermissionTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiPermissionManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiPermissionManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiPermissionManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiPermissionManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public PiPermissionManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiPermissionEntity entity)
        {
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(PiPermissionEntity entity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update(PiPermissionEntity entity)
        {
            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiPermissionEntity GetEntity(string id)
        {
            //var entity = new PiPermissionEntity(this.GetDT(PiPermissionTable.FieldId, id));
            //return entity;
            return BaseEntity.Create<PiPermissionEntity>(this.GetDT(PiPermissionTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(PiPermissionEntity entity)
        {
            var sequence = string.Empty;
            this.Identity = false;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(PiPermissionTable.TableName, PiPermissionTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(entity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    entity.Id = sequence;
                }
                sqlBuilder.SetValue(PiPermissionTable.FieldId, entity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiPermissionTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiPermissionTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (entity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            entity.Id = sequence;
                        }
                        sqlBuilder.SetValue(PiPermissionTable.FieldId, entity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionTable.FieldModifiedOn);
            if (DBProvider.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        public int UpdateEntity(PiPermissionEntity entity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(PiPermissionTable.TableName);
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiPermissionTable.FieldId, entity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="entity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiPermissionEntity entity)
        {
            sqlBuilder.SetValue(PiPermissionTable.FieldResourceId, entity.ResourceId);
            sqlBuilder.SetValue(PiPermissionTable.FieldResourceCategory, entity.ResourceCategory);
            sqlBuilder.SetValue(PiPermissionTable.FieldPermissionId, entity.PermissionId);
            sqlBuilder.SetValue(PiPermissionTable.FieldPermissionConstraint, entity.PermissionConstraint);
            sqlBuilder.SetValue(PiPermissionTable.FieldEnabled, entity.Enabled);
            sqlBuilder.SetValue(PiPermissionTable.FieldDeleteMark, entity.DeleteMark);
            sqlBuilder.SetValue(PiPermissionTable.FieldDescription, entity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiPermissionTable.FieldId, id);
        }    

        #region public bool PermissionExists(string permissionItemId, string resourceCategory, string resourceId) 检查是否存在
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>是否存在</returns>      
        public bool PermissionExists(string permissionItemId, string resourceCategory, string resourceId)
        {
            var returnValue = true;
            var names = new string[3];
            var values = new string[3];
            names[0] = PiPermissionTable.FieldResourceCategory;
            values[0] = resourceCategory;
            names[1] = PiPermissionTable.FieldResourceId;
            values[1] = resourceId;
            names[2] = PiPermissionTable.FieldPermissionId;
            values[2] = permissionItemId;
            // 检查是否存在
            if (!this.Exists(names, values))
            {
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public string AddPermission(BasePermissionEntity entity) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string AddPermission(PiPermissionEntity entity)
        {
            var returnValue = string.Empty;
            // 检查记录是否重复
            if (!this.PermissionExists(entity.PermissionId.ToString(), entity.ResourceCategory, entity.ResourceId.ToString()))
            {
                returnValue = this.AddEntity(entity);
            }
            return returnValue;
        }
        #endregion


        //
        // ResourcePermission 权限判断
        // 

        #region public bool CheckPermissionByUser(string userId, string permissionItemCode, string permissionItemName = null) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限</returns>
        public bool CheckPermissionByUser(string userId, string permissionItemCode, string permissionItemName = null)
        {
            // 若不存在就需要自动能增加一个操作权限项
            var permissionItemManager = new PiPermissionItemManager(DBProvider, UserInfo,PiPermissionItemTable.TableName);
            var permissionItemId = permissionItemManager.GetIdByAdd(permissionItemCode, permissionItemName);
            var permissionItemEntity = permissionItemManager.GetEntity(permissionItemId);
            
            // 先判断用户类别
            if (UserInfo.IsAdministrator)
            {
                return true;
            }
            
            // 没有找到相应的权限
            if (String.IsNullOrEmpty(permissionItemId))
            {
                return false;
            }

            // 这里需要判断,是系统权限？
            var returnValue = false;
            var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
            
            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo);
            if (!string.IsNullOrEmpty(permissionItemEntity.CategoryCode) && permissionItemEntity.CategoryCode.Equals("System"))
            {
                // 用户管理员拥有所有的系统权限，不需要授予。
                returnValue = userRoleManager.UserInRole(userId, "UserAdmin");
                if (returnValue)
                {
                    return returnValue;
                }
            }

            // 这里需要判断,是业务（应用）权限？
            if (!string.IsNullOrEmpty(permissionItemEntity.CategoryCode) && permissionItemEntity.CategoryCode.Equals("Application"))
            {
                //业务管理员拥有所有的业务(应用）权限，不需要授予。
                returnValue = userRoleManager.UserInRole(userId, "Admin");
                if (returnValue)
                {
                    return returnValue;
                }
            }

            // 判断用户权限
            if (this.CheckUserPermission(userId, permissionItemId))
            {
                return true;
            }
            // 判断用户角色权限
            if (this.CheckUserRolePermission(userId, permissionItemId))
            {
                return true;
            }

            // 判断用户组织机构权限，这里有开关是为了提高性能用的，
            // 下面的函数接着还可以提高性能，可以进行一次判断就可以了，其实不用执行4次判断，浪费I/O，浪费性能。
            if (SystemInfo.EnableOrganizePermission)
            {
                //得到用户所有所在的部门（以公司、分支机构、部门、子部门、工作组），包括兼职部门
                var organizeIds = userManager.GetAllOrganizeIds(userId);
                if (this.CheckUserOrganizePermission(userId, permissionItemId, organizeIds))
                {
                    return true;
                }              
            }

            return false;
        }
        #endregion

        private bool CheckUserOrganizePermission(string userId, string permissionItemId, string[] organizeIds)
        {
            if (organizeIds == null || organizeIds.Length <= 0)
            {
                return false;
            }

            var tableName = PiPermissionTable.TableName;
            var organizeId = "(" + BusinessLogic.ObjectsToList(organizeIds) + ")";
            var sqlQuery = " SELECT COUNT(1) "
                             + "   FROM " + tableName
                             + "  WHERE (" + PiPermissionTable.FieldResourceCategory + " = '" + PiOrganizeTable.TableName + "') "
                             + "        AND (" + PiPermissionTable.FieldResourceId + " IN " + organizeId + ") "
                             + "        AND (" + PiPermissionTable.FieldEnabled + " = 1) "
                             + "        AND (" + PiPermissionTable.FieldDeleteMark + " = 0) "
                             + "        AND (" + PiPermissionTable.FieldPermissionId + " = '" + permissionItemId + "')";
            var rowCount = 0;
            var returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }

        #region private bool CheckUserPermission(string userId, string permissionItemId)
        /// <summary>
        /// 员工是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>是否有权限</returns>
        private bool CheckUserPermission(string userId, string permissionItemId)
        {
            return CheckResourcePermission(PiUserTable.TableName, userId, permissionItemId);
        }
        #endregion

        private bool CheckResourcePermission(string resourceCategory, string resourceId, string permissionItemId)
        {
            var sqlQuery = " SELECT COUNT(1) "
                             + "   FROM " + PiPermissionTable.TableName
                             + "  WHERE (" + PiPermissionTable.FieldResourceCategory + " = '" + resourceCategory + "') "
                             + "        AND (" + PiPermissionTable.FieldEnabled + " = 1) "
                             + "        AND (" + PiPermissionTable.FieldDeleteMark + " = 0) "
                             + "        AND (" + PiPermissionTable.FieldResourceId + " = '" + resourceId + "') "
                             + "        AND (" + PiPermissionTable.FieldPermissionId + " = '" + permissionItemId + "')";
            var rowCount = 0;
            var returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }

        #region private bool CheckUserRolePermission(string userId, string permissionItemId)
        /// <summary>
        /// 用户角色关系是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>有角色权限</returns>
        private bool CheckUserRolePermission(string userId, string permissionItemId)
        {
            var sqlQuery = " SELECT COUNT(1) "
                            + "   FROM " + PiPermissionTable.TableName
                            + "  WHERE " + "(" + PiPermissionTable.FieldResourceCategory + " = '" + PiRoleTable.TableName + "') " 
                            + "        AND (" + PiPermissionTable.FieldEnabled + " = 1 "
                            + "        AND  " + PiPermissionTable.FieldDeleteMark + " = 0) "
                            + "        AND (" + PiPermissionTable.FieldResourceId + " IN ( "
                                                + " SELECT " + PiUserRoleTable.FieldRoleId
                                                + "   FROM " + PiUserRoleTable.TableName
                                                + "  WHERE " + PiUserRoleTable.FieldUserId + " = '" + userId + "' "
                                                + "        AND " + PiUserRoleTable.FieldEnabled + " = 1 "
                                                + "        AND " + PiUserRoleTable.FieldDeleteMark + " = 0 "
                                                + "  UNION ALL "
                                                + " SELECT " + PiUserTable.FieldRoleId
                                                + "   FROM " + PiUserTable.TableName
                                                + "  WHERE " + PiUserTable.FieldId + " = '" + userId + "'"
                                                + ") ) "
                            + "        AND (" + PiPermissionTable.FieldPermissionId + " = '" + permissionItemId + "') ";
            var rowCount = 0;
            var returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }
        #endregion

        //
        // 从数据库获取权限
        //

        #region public DataTable GetPermission(UserInfo userInfo)
        /// <summary>
        /// 获得一个员工的某一模块的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetPermission(UserInfo userInfo)
        {
            var permissionItemManager = new PiPermissionItemManager(DBProvider, userInfo);
            return userInfo.IsAdministrator ? permissionItemManager.GetDT(PiPermissionItemTable.FieldEnabled, "1", PiPermissionItemTable.FieldSortCode) : this.GetPermissionByUser(userInfo.Id);
        }
        #endregion

        public DataTable GetPermissionByUser(string userId)
        {
            var sqlQuery = " SELECT * "
                             + "   FROM " + PiPermissionItemTable.TableName
                             + "  WHERE " + PiPermissionItemTable.FieldEnabled + " = 1 "
                             + "        AND " + PiPermissionItemTable.FieldId + " IN ( "

                             // 用户的权限
                             + " SELECT " + PiPermissionTable.FieldPermissionId
                             + "   FROM " + PiPermissionTable.TableName
                             + "  WHERE (" + PiPermissionTable.FieldResourceCategory + " = '" + PiUserTable.TableName + "') "
                             + "        AND (" + PiPermissionTable.FieldEnabled + " = 1) "
                             + "        AND (" + PiPermissionTable.FieldResourceId + " = '" + userId + "')"

                            + " UNION "

                            // 角色的权限                            
                            + " SELECT " + PiPermissionTable.FieldPermissionId
                            + "   FROM " + PiPermissionTable.TableName
                            + "  WHERE " + "(" + PiPermissionTable.FieldResourceCategory + " = '" + PiRoleTable.TableName + "') "
                            + "        AND (" + PiPermissionTable.FieldEnabled + " = 1) "
                            + "        AND (" + PiPermissionTable.FieldResourceId + " IN ( "
                                                + " SELECT " + PiUserRoleTable.FieldRoleId
                                                + "   FROM " + PiUserRoleTable.TableName
                                                + "  WHERE " + PiUserRoleTable.FieldUserId + " = '" + userId + "' "
                                                + "        AND " + PiUserRoleTable.FieldEnabled + " = 1"
                                                + "  UNION "
                                                + " SELECT " + PiUserTable.FieldRoleId
                                                + "   FROM " + PiUserTable.TableName
                                                + "  WHERE " + PiUserTable.FieldId + " = '" + userId + "'"
                                                + ")) "
                            + ") "
                            + " ORDER BY " + PiPermissionItemTable.FieldSortCode;

            return DBProvider.Fill(sqlQuery);
        }

        #region private bool CheckPermissionByRole(string roleId, string permissionItemCode)
        /// <summary>
        /// 用户角色关系是否有模块权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>有角色权限</returns>
        public bool CheckPermissionByRole(string roleId, string permissionItemCode)
        {
            var permissionItemManager = new PiPermissionItemManager(DBProvider, UserInfo);
            var permissionItemId = permissionItemManager.GetProperty(PiPermissionItemTable.FieldCode, permissionItemCode, PiPermissionItemTable.FieldId);
            // 判断当前判断的权限是否存在，否则很容易出现前台设置了权限，后台没此项权限
            // 需要自动的能把前台判断过的权限，都记录到后台来
            #if (DEBUG)
                if (String.IsNullOrEmpty(permissionItemId))
                {
                    PiPermissionItemEntity permissionItemEntity = new PiPermissionItemEntity
                    {
                        Code = permissionItemCode,
                        FullName = permissionItemCode,
                        ParentId = "",
                        IsScope = 0,
                        AllowDelete = 1,
                        AllowEdit = 1,
                        DeleteMark = 0,
                        Enabled = 1
                    };
                    // 这里是防止主键重复？
                    // permissionEntity.ID = BusinessLogic.NewGuid();
                    permissionItemManager.AddEntity(permissionItemEntity);
                }
                else
                {
                    // 更新最后一次访问日期，设置为当前服务器日期
                    SQLBuilder sqlBuilder = new SQLBuilder(DBProvider);
                    sqlBuilder.BeginUpdate(PiPermissionItemTable.TableName);
                    sqlBuilder.SetDBNow(PiPermissionItemTable.FieldLastCall);
                    sqlBuilder.SetWhere(PiPermissionItemTable.FieldId, permissionItemId);
                    sqlBuilder.EndUpdate();
                }
            #endif

            if (string.IsNullOrEmpty(permissionItemId))
            {
                return false;
            }
            var sqlQuery = " SELECT COUNT(*) "
                            + "   FROM " + PiPermissionTable.TableName
                            + "  WHERE " + "(" + PiPermissionTable.FieldResourceCategory + " = '" + PiRoleTable.TableName + "') "
                            + "        AND (" + PiPermissionTable.FieldEnabled + " = 1) "
                            + "        AND (" + PiPermissionTable.FieldResourceId + " = '" + roleId + "' ) "
                            + "        AND (" + PiPermissionTable.FieldPermissionId + " = '" + permissionItemId + "') ";
            var rowCount = 0;
            var returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }
        #endregion
    }
}
