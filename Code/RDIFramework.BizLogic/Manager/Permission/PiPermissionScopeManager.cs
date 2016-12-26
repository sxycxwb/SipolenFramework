/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 14:28:55
 ******************************************************************************/

using System;
using System.Data;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;  

    /// <summary>
    /// PiPermissionScopeManager
    /// 数据集权限存储表
    ///
    /// 修改纪录
    ///
    ///     2016-03-20 版本：3.0 EricHu 修改public string[] GetTreeResourceScopeIds(string userId, string tableName, string permissionItemCode, bool childrens)对Mysql,Oracle下的异常。
    ///		2012-03-02 版本：1.0 EricHu 创建主键。
    ///
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-03-02</date>
    /// </author>
    /// </summary>
    public partial class PiPermissionScopeManager : DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PiPermissionScopeManager()
        {
            if (base.dbProvider == null)
            {
                base.dbProvider = DbFactoryProvider.GetProvider(SystemInfo.RDIFrameworkDbType, SystemInfo.RDIFrameworkDbConection);
            }
            base.CurrentTableName = PiPermissionScopeTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public PiPermissionScopeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        public PiPermissionScopeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public PiPermissionScopeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public PiPermissionScopeManager(IDbProvider dbProvider, UserInfo userInfo)
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
        public PiPermissionScopeManager(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>主键</returns>
        public string Add(PiPermissionScopeEntity entity)
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
        public string Add(PiPermissionScopeEntity entity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        public int Update(PiPermissionScopeEntity entity)
        {
            return this.UpdateEntity(entity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public PiPermissionScopeEntity GetEntity(string id)
        {
            //var entity = new PiPermissionScopeEntity(this.GetDT(PiPermissionScopeTable.FieldId, id));
            //return entity;
            return BaseEntity.Create<PiPermissionScopeEntity>(this.GetDT(PiPermissionScopeTable.FieldId, id));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(PiPermissionScopeEntity entity)
        {
            var sequence = string.Empty;
            this.Identity = false;
            entity.Id = null;
            var sqlBuilder = new SQLBuilder(DBProvider, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(PiPermissionScopeTable.TableName, PiPermissionScopeTable.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(entity.Id))
                {
                    sequence = BusinessLogic.NewGuid();
                    entity.Id = sequence;
                }
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldId, entity.Id);
            }
            else
            {
                if (!this.ReturnId && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(PiPermissionScopeTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DBProvider.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(PiPermissionScopeTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DBProvider.CurrentDbType == CurrentDbType.Oracle || DBProvider.CurrentDbType == CurrentDbType.DB2))
                    {
                        entity.Id = null; //这儿要手动指定为null，原因在于涉及到批量增加时，实体传参，会把ID带回去，下次的ID还是上次的ID，就会有误。
                        if (entity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                var sequenceManager = new CiSequenceManager(DBProvider, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            entity.Id =sequence;
                        }
                        sqlBuilder.SetValue(PiPermissionScopeTable.FieldId, entity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionScopeTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionScopeTable.FieldModifiedOn);
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
        public int UpdateEntity(PiPermissionScopeEntity entity)
        {
            var sqlBuilder = new SQLBuilder(DBProvider);
            sqlBuilder.BeginUpdate(PiPermissionScopeTable.TableName);
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(PiPermissionScopeTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(PiPermissionScopeTable.FieldModifiedOn);
            sqlBuilder.SetWhere(PiPermissionScopeTable.FieldId, entity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL语句生成器</param>
        /// <param name="entity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, PiPermissionScopeEntity entity)
        {
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldResourceCategory, entity.ResourceCategory);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldResourceId, entity.ResourceId);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldTargetCategory, entity.TargetCategory);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldTargetId, entity.TargetId);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldPermissionId, entity.PermissionId);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldPermissionConstraint, entity.PermissionConstraint);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldStartDate, entity.StartDate);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldEndDate, entity.EndDate);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldEnabled, entity.Enabled);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldDeleteMark, entity.DeleteMark);
            sqlBuilder.SetValue(PiPermissionScopeTable.FieldDescription, entity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(PiPermissionScopeTable.FieldId, id);
        }   
        
        /// <summary>
        /// 是否按编号获得子节点，SQL2005以上或者Oracle数据库按ParentId,Id进行关联 
        /// </summary>
        public static bool UseGetChildrensByCode = false;
        
        #region public bool PermissionScopeExists(string permissionItemId, string resourceCategory, string resourceId, string targetCategory, string targetId) 检查是否存在
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标分类</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>是否存在</returns>
        public bool PermissionScopeExists(string permissionItemId, string resourceCategory, string resourceId, string targetCategory, string targetId)
        {
            var returnValue = true;
            var names = new string[5];
            var values = new string[5];
            names[0] = PiPermissionScopeTable.FieldPermissionId;
            values[0] = permissionItemId;
            names[1] = PiPermissionScopeTable.FieldResourceCategory;
            values[1] = resourceCategory;
            names[2] = PiPermissionScopeTable.FieldResourceId;
            values[2] = resourceId;
            names[3] = PiPermissionScopeTable.FieldTargetCategory;
            values[3] = targetCategory;
            names[4] = PiPermissionScopeTable.FieldTargetId;
            values[4] = targetId;
            // 检查是否存在
            if (!this.Exists(names, values))
            {
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        public int PermissionScopeDelete(string permissionItemId, string resourceCategory, string resourceId, string targetCategory, string targetId)
        {
            var returnValue = 0;
            var names = new string[5];
            var values = new string[5];
            names[0] = PiPermissionScopeTable.FieldPermissionId;
            values[0] = permissionItemId;
            names[1] = PiPermissionScopeTable.FieldResourceCategory;
            values[1] = resourceCategory;
            names[2] = PiPermissionScopeTable.FieldResourceId;
            values[2] = resourceId;
            names[3] = PiPermissionScopeTable.FieldTargetCategory;
            values[3] = targetCategory;
            names[4] = PiPermissionScopeTable.FieldTargetId;
            values[4] = targetId;
            returnValue = this.Delete(names, values);
            return returnValue;
        }

        public string AddPermission(string resourceCategory, string resourceId, string targetCategory, string targetId)
        {
            var resourcePermissionScope = new PiPermissionScopeEntity
            {
                ResourceCategory = resourceCategory,
                ResourceId = resourceId,
                TargetCategory = targetCategory,
                TargetId = targetId,
                Enabled = 1,
                DeleteMark = 0
            };
            return this.AddPermission(resourcePermissionScope);
        }

        #region public string AddPermission(BasePermissionScopeEntity resourcePermissionScope)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resourcePermissionScope">对象</param>
        /// <returns>主键</returns>
        public string AddPermission(PiPermissionScopeEntity resourcePermissionScope)
        {
            var returnValue = string.Empty;
            // 检查记录是否重复
            if (!this.PermissionScopeExists(resourcePermissionScope.PermissionId.ToString(), resourcePermissionScope.ResourceCategory, resourcePermissionScope.ResourceId, resourcePermissionScope.TargetCategory, resourcePermissionScope.TargetId))
            {
                returnValue = this.AddEntity(resourcePermissionScope);
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 获得用户的权限范围设置
        /// </summary>
        /// <param name="managerUserId">用户主键</param>
        /// <param name="permissionItemCode">权限范围编号</param>
        /// <returns>用户的权限范围</returns>
        public PermissionScope GetUserPermissionScope(string managerUserId, string permissionItemCode)
        {
            var sqlQuery = this.GetOrganizeIdsSql(managerUserId, permissionItemCode);
            var dataTable = DBProvider.Fill(sqlQuery);
            var organizeIds = BusinessLogic.FieldToArray(dataTable, PiPermissionScopeTable.FieldTargetId);
            return BusinessLogic.GetPermissionScope(organizeIds);
        }

        // 权限范围的判断

        //
        // 获得被某个权限管理范围内 组织机构的 ID、SQL、List
        //

        #region public string GetOrganizeIdsSql(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 Sql
        /// <summary>
        /// 按某个权限获取组织机构 Sql
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetOrganizeIdsSql(string managerUserId, string permissionItemCode)
        {
            var permissionItemManager = new PiPermissionItemManager(DBProvider);
            var permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);

            var sqlQuery = string.Empty;
            sqlQuery = " SELECT " + PiPermissionScopeTable.FieldTargetId
                     + "   FROM " + PiPermissionScopeTable.TableName
                // 有效的，并且不为空的组织机构主键
                     + "  WHERE (" + PiPermissionScopeTable.FieldTargetCategory + " = '" + PiOrganizeTable.TableName + "') "
                     + "        AND ( " + PiPermissionScopeTable.TableName + "." + PiPermissionScopeTable.FieldDeleteMark + " = 0) "
                     + "        AND ( " + PiPermissionScopeTable.TableName + "." + PiPermissionScopeTable.FieldEnabled + " = 1) "
                     + "        AND ( " + PiPermissionScopeTable.TableName + "." + PiPermissionScopeTable.FieldTargetId + " IS NOT NULL) "
                // 自己直接由相应权限的组织机构
                     + "        AND ((" + PiPermissionScopeTable.FieldResourceCategory + " = '" + PiUserTable.TableName + "' "
                     + "        AND " + PiPermissionScopeTable.FieldResourceId + " = '" + managerUserId + "')"
                     + " OR (" + PiPermissionScopeTable.FieldResourceCategory + " = '" + PiRoleTable.TableName + "' "
                     + "       AND " + PiPermissionScopeTable.FieldResourceId + " IN ( "
                // 获得属于那些角色有相应权限的组织机构
                     + " SELECT " + PiUserRoleTable.FieldRoleId
                     + "   FROM " + PiUserRoleTable.TableName
                     + "  WHERE " + PiUserRoleTable.FieldUserId + " = '" + managerUserId + "'"
                     + "        AND " + PiUserRoleTable.FieldDeleteMark + " = 0 "
                     + "        AND " + PiUserRoleTable.FieldEnabled + " = 1 ))) "
                // 并且是指定的本权限
                     + " AND (" + PiPermissionScopeTable.FieldPermissionId + " = '" + permissionItemId + "') ";
            return sqlQuery;
        }
        #endregion

        #region public string GetOrganizeIdsSqlByParentId(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 Sql
        /// <summary>
        /// 按某个权限获取组织机构 Sql (按ParentId树形结构计算)
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetOrganizeIdsSqlByParentId(string managerUserId, string permissionItemCode)
        {
            var sqlQuery = string.Empty;
            sqlQuery = " SELECT ID "
                     + "   FROM " + PiOrganizeTable.TableName
                     + "  WHERE " + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldEnabled + " = 1 "
                     + "        AND " + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldDeleteMark + " = 0 "
                     + "  START WITH Id IN (" + this.GetOrganizeIdsSql(managerUserId, permissionItemCode) + ") "
                     + " CONNECT BY PRIOR " + PiOrganizeTable.FieldId + " = " + PiOrganizeTable.FieldParentId ;
            return sqlQuery;
        }
        #endregion

        #region public string GetOrganizeIdsSqlByCode(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 Sql
        /// <summary>
        /// 按某个权限获取组织机构 Sql (按Code编号进行计算)
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetOrganizeIdsSqlByCode(string managerUserId, string permissionItemCode)
        {
            var sqlQuery = string.Empty;
            sqlQuery = " SELECT " + PiOrganizeTable.FieldId + " AS " + BusinessLogic.FieldId
                     + "   FROM " + PiOrganizeTable.TableName
                     + "         , ( SELECT " + DBProvider.PlusSign(PiOrganizeTable.FieldCode, "'%'") + " AS " + PiOrganizeTable.FieldCode
                     + "      FROM " + PiOrganizeTable.TableName
                     + "     WHERE " + PiOrganizeTable.FieldId + " IN (" + this.GetOrganizeIdsSql(managerUserId, permissionItemCode) + ")) ManageOrganize "
                     + " WHERE (" + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldEnabled + " = 1 "
                     // 编号相似的所有组织机构获取出来
                     + "       AND " + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldCode + " LIKE ManageOrganize." + PiOrganizeTable.FieldCode + ")";
            return sqlQuery;
        }
        #endregion


        #region public string[] GetOrganizeIds(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 主键数组
        /// <summary>
        /// 按某个权限获取组织机构 主键数组
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIds(string managerUserId, string permissionItemCode)
        {
            // 这里应该考虑，当前用户的管理权限是，所在公司？所在部门？所以在工作组等情况
            var sqlQuery = string.Empty;
            if (PiPermissionScopeManager.UseGetChildrensByCode)
            {
                sqlQuery = this.GetOrganizeIdsSqlByCode(managerUserId, permissionItemCode);
            }
            else
            {
                if (this.DBProvider.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlQuery = this.GetOrganizeIdsSqlByParentId(managerUserId, permissionItemCode);
                }
                else
                {
                    
                    // string[] ids = this.GetTreeResourceScopeIds(managerUserId, PiOrganizeTable.TableName, permissionItemCode, true);
                    var ids = this.GetTreeResourceScopeIds(managerUserId, PiOrganizeTable.TableName, permissionItemCode, false);
                    // 这里是否应该整理，自己的公司、部门、工作组的事情？
                    
                    
                    // 这里列出只是有效地，没被删除的组织机构主键
                    if (ids != null && ids.Length > 0)
                    {
                        var organizeManager = new PiOrganizeManager(this.DBProvider, this.UserInfo);
                        string[] names = { PiOrganizeTable.FieldId, PiOrganizeTable.FieldEnabled, PiOrganizeTable.FieldDeleteMark };
                        Object[] values = { ids, 1, 0 };
                        ids = organizeManager.GetIds(names, values);
                    }
                    return ids;
                }
            }
            var dataTable = DBProvider.Fill(sqlQuery);
            return BusinessLogic.FieldToArray(dataTable, PiOrganizeTable.FieldId);
        }
        #endregion

        #region public DataTable GetOrganizeDT(string managerUserId, string permissionItemCode) 按某个权限获取组织机构数据表
        /// <summary>
        /// 按某个权限获取组织机构数据表
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetOrganizeDT(string managerUserId, string permissionItemCode)
        {
            var sqlQuery = string.Empty;
            if (PiPermissionScopeManager.UseGetChildrensByCode)
            {
                sqlQuery = this.GetOrganizeIdsSqlByCode(managerUserId, permissionItemCode);
            }
            else
            {
                if (this.DBProvider.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlQuery = this.GetOrganizeIdsSqlByParentId(managerUserId, permissionItemCode);
                }
                else
                {
                    //  不自动获取子部门
                    //  string[] ids = this.GetTreeResourceScopeIds(managerUserId, PiOrganizeTable.TableName, permissionItemCode, true);
                    var ids = this.GetTreeResourceScopeIds(managerUserId, PiOrganizeTable.TableName, permissionItemCode, false);
                    sqlQuery = BusinessLogic.ArrayToList(ids,"'");
                }
            }
            if (string.IsNullOrEmpty(sqlQuery))
            {
                sqlQuery = " NULL ";
            }
            sqlQuery = " SELECT * FROM " + PiOrganizeTable.TableName
                     + " WHERE " + PiOrganizeTable.TableName + "." + PiOrganizeTable.FieldId + " IN (" + sqlQuery + ") "
                     + " ORDER BY " + PiOrganizeTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion


        //
        // 获得被某个权限管理范围内 角色的 Id、SQL、List
        // 

        #region public string GetRoleIdsSql(string managerUserId, string permissionItemCode) 按某个权限获取角色 Sql
        /// <summary>
        /// 按某个权限获取角色 Sql
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetRoleIdsSql(string managerUserId, string permissionItemCode)
        {
            var permissionItemManager = new PiPermissionItemManager(DBProvider);
            var permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);

            var sqlQuery = string.Empty;            
            // 被管理的角色 
            sqlQuery += " SELECT PIPERMISSIONSCOPE.TARGETID AS " + BusinessLogic.FieldId
                      + "   FROM PIPERMISSIONSCOPE "
                      + "  WHERE (PIPERMISSIONSCOPE.TARGETID IS NOT NULL "
                      + "        AND PIPERMISSIONSCOPE.TARGETCATEGORY = '" + PiRoleTable.TableName + "' "
                      + "        AND ((PIPERMISSIONSCOPE.RESOURCECATEGORY = '" + PiUserTable.TableName + "' "
                      + "             AND PIPERMISSIONSCOPE.RESOURCEID = '" + managerUserId + "')"
                      // 以及 他所在的角色在管理的角色
                      + "        OR (PIPERMISSIONSCOPE.RESOURCECATEGORY = '" + PiRoleTable.TableName + "'"
                      + "            AND PIPERMISSIONSCOPE.RESOURCEID IN ( " 
                      +                             " SELECT ROLEID " 
                      +                             "   FROM " + PiUserRoleTable.TableName
                      + "  WHERE (" + PiUserRoleTable.FieldUserId + " = '" + managerUserId + "' "
                      + "        AND " + PiUserRoleTable.FieldEnabled + " = 1))))" 
                      // 并且是指定的本权限
                      + "        AND " + PiPermissionScopeTable.FieldPermissionId + " = '" + permissionItemId + "')";

            // 被管理部门的列表
            var organizeIds = this.GetOrganizeIds(managerUserId, permissionItemCode);
            if (organizeIds.Length > 0)
            {
                var organizes = BusinessLogic.ObjectsToList(organizeIds);
                if (!String.IsNullOrEmpty(organizes)) 
                {
                    // 被管理的组织机构包含的角色
                    sqlQuery += "  UNION "
                              + " SELECT " + PiRoleTable.TableName + "." + PiRoleTable.FieldId + " AS " + BusinessLogic.FieldId
                              + "   FROM " + PiRoleTable.TableName
                              + "  WHERE " + PiRoleTable.TableName + "." + PiRoleTable.FieldEnabled + " = 1 "
                              + "    AND " + PiRoleTable.TableName + "." + PiRoleTable.FieldDeleteMark + " = 0 "
                              + "    AND " + PiRoleTable.TableName + "." + PiRoleTable.FieldOrganizeId + " IN (" + organizes + ") ";
                }
            }
            return sqlQuery;
        }
        #endregion

        #region public string[] GetRoleIds(string managerUserId, string permissionItemCode) 按某个权限获取角色 主键数组
        /// <summary>
        /// 按某个权限获取角色 主键数组
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string managerUserId, string permissionItemCode)
        {
            var sqlQuery = this.GetRoleIdsSql(managerUserId, permissionItemCode);
            var dataTable = DBProvider.Fill(sqlQuery);
            var ids = BusinessLogic.FieldToArray(dataTable, BusinessLogic.FieldId);
            // 这里列出只是有效地，没被删除的角色主键
            if (ids != null && ids.Length > 0)
            {
                var roleManager = new PiRoleManager(this.DBProvider, this.UserInfo);
                string[] names = { PiRoleTable.FieldId, PiRoleTable.FieldEnabled, PiRoleTable.FieldDeleteMark };
                Object[] values = { ids, 1, 0 };
                ids = roleManager.GetIds(names, values);
            }
            return ids;
        }
        #endregion

        #region public DataTable GetRoleDT(string managerUserId, string permissionItemCode) 按某个权限获取角色 数据表
        /// <summary>
        /// 按某个权限获取角色 数据表
        /// </summary>
        /// <param name="userId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleDT(string userId, string permissionItemCode)
        {
            var returnValue = new DataTable(PiRoleTable.TableName);
            string[] names = null;
            object[] values = null;
            
            // 这里需要判断,是系统权限？
            var isRole = false;
            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo);
            // 用户管理员,这里需要判断,是业务权限？
            isRole = userRoleManager.UserInRole(userId, "UserAdmin") || userRoleManager.UserInRole(userId, "Admin");
            if (isRole)
            {
                var manager = new PiRoleManager(this.DBProvider, this.UserInfo);
                names = new string[] { PiRoleTable.FieldDeleteMark, PiRoleTable.FieldEnabled };
                values = new object[] { 0, 1 };
                returnValue = manager.GetDT(names, values, PiModuleTable.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            var sqlQuery = string.Empty;
            sqlQuery = " SELECT * "
                      + "  FROM " + PiRoleTable.TableName
                      + " WHERE " + PiRoleTable.TableName + "." + PiRoleTable.FieldId + " IN ("
                                + this.GetRoleIdsSql(userId, permissionItemCode)
                                + " ) AND (" + PiRoleTable.FieldDeleteMark + " = 0) "
                                //+ " AND (" + PiRoleTable.FieldIsVisible + " = 1) "
                   + " ORDER BY " + PiRoleTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        //
        // 获得被某个权限管理范围内 用户的 Id、SQL、List
        // 

        #region public string GetUserIdsSql(string managerUserId, string permissionItemCode) 按某个权限获取员工 Sql
        /// <summary>
        /// 按某个权限获取员工 Sql
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetUserIdsSql(string managerUserId, string permissionItemCode)
        {
            var permissionItemManager = new PiPermissionItemManager(DBProvider);
            var permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);

            var sqlQuery = string.Empty;
            
            // 直接管理的用户
            sqlQuery = " SELECT PIPERMISSIONSCOPE.TARGETID AS " + BusinessLogic.FieldId 
                     + "   FROM PIPERMISSIONSCOPE"
                     + "  WHERE (PIPERMISSIONSCOPE.TARGETCATEGORY = '" + PiUserTable.TableName + "'"
                     + "        AND PIPERMISSIONSCOPE.RESOURCEID = '" + managerUserId + "'"
                     + "        AND PIPERMISSIONSCOPE.RESOURCECATEGORY = '" + PiUserTable.TableName + "'"
                     + "        AND PIPERMISSIONSCOPE.PERMISSIONID = '" + permissionItemId + "'"
                     + "        AND PIPERMISSIONSCOPE.TARGETID IS NOT NULL) ";

            // 被管理部门的列表
            var organizeIds = this.GetOrganizeIds(managerUserId, permissionItemCode);
            if (organizeIds.Length > 0)
            {
                var organizes = BusinessLogic.ObjectsToList(organizeIds);
                if (!String.IsNullOrEmpty(organizes))
                {
                    // 被管理的组织机构包含的用户，公司、部门、工作组
                    // 同一公司、部门、工作组中的用户可管理。
                    // sqlQuery += " UNION "
                    //         + " SELECT " + PiStaffTable.TableName + "." + PiStaffTable.FieldUserId + " AS " + BusinessLogic.FieldId
                    //         + "   FROM " + PiStaffTable.TableName
                    //         + "  WHERE (" + PiStaffTable.TableName + "." + PiStaffTable.FieldCompanyId + " IN (" + organizes + ") "
                    //         + "     OR " + PiStaffTable.TableName + "." + PiStaffTable.FieldDepartmentId + " IN (" + organizes + ") "
                    //         + "     OR " + PiStaffTable.TableName + "." + PiStaffTable.FieldWorkgroupId + " IN (" + organizes + ")) ";
                    
                    sqlQuery += " UNION "
                             + " SELECT " + PiUserTable.TableName + "." + PiUserTable.FieldId + " AS " + BusinessLogic.FieldId
                             + "   FROM " + PiUserTable.TableName
                             + "  WHERE (" + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 ) "
                             + "        AND (" + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 ) "
                             + "        AND (" + PiUserTable.TableName + "." + PiUserTable.FieldCompanyId + " IN (" + organizes + ") "
                             + "            OR " + PiUserTable.TableName + "." + PiUserTable.FieldDepartmentId + " IN (" + organizes + ") "
                             + "            OR " + PiUserTable.TableName + "." + PiUserTable.FieldWorkgroupId + " IN (" + organizes + ")) ";
                }
            }            

            // 被管理部门的列表
            var roleIds = this.GetRoleIds(managerUserId, permissionItemCode);
            if (roleIds.Length > 0)
            {
                var roles = BusinessLogic.ObjectsToList(roleIds);
                if (!String.IsNullOrEmpty(roles))
                {
                    // 被管理的角色包含的员工
                    sqlQuery += " UNION "
                             + " SELECT " + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldUserId + " AS " + BusinessLogic.FieldId
                             + "   FROM " + PiUserRoleTable.TableName
                             + "  WHERE (" + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldEnabled + " = 1 "
                             + "        AND " + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldDeleteMark + " = 0 "
                             + "        AND " + PiUserRoleTable.TableName + "." + PiUserRoleTable.FieldRoleId + " IN (" + roles + ")) ";
                }
            }
            
            return sqlQuery;
        }
        #endregion

        #region public string[] GetUserIds(string managerUserId, string permissionItemCode) 按某个权限获取员工 主键数组
        /// <summary>
        /// 按某个权限获取员工 主键数组
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string managerUserId, string permissionItemCode)
        {
            var ids = this.GetTreeResourceScopeIds(managerUserId, PiOrganizeTable.TableName, permissionItemCode, true);
            // 是否为仅本人
            if (BusinessLogic.Exists(ids, ((int)PermissionScope.User).ToString()))
            {
                return new string[] { managerUserId };
            }

            var sqlQuery = this.GetUserIdsSql(managerUserId, permissionItemCode);
            var dataTable = DBProvider.Fill(sqlQuery);

            // 这里应该考虑，当前用户的管理权限是，所在公司？所在部门？所以在工作组等情况
            if (ids != null && ids.Length > 0)
            {
                var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
                var userEntity = userManager.GetEntity(managerUserId);
                for (var i = 0; i < ids.Length; i++)
                {
                    if (ids[i].Equals(((int)PermissionScope.User).ToString()))
                    {
                        ids[i] = userEntity.Id.ToString();
                        break;
                    }
                }
            }

            // 这里列出只是有效地，没被删除的角色主键
            if (ids != null && ids.Length > 0)
            {
                var userManager = new PiUserManager(this.DBProvider, this.UserInfo);
                string[] names = { PiUserTable.FieldId, PiUserTable.FieldEnabled, PiUserTable.FieldDeleteMark };
                Object[] values = { ids, 1, 0 };
                ids = userManager.GetIds(names, values);
            }

            return ids;
        }
        #endregion

        #region public DataTable GetUserDT(string userId, string permissionItemCode) 按某个权限获取员工 数据表
        /// <summary>
        /// 按某个权限获取员工 数据表
        /// </summary>
        /// <param name="userId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDT(string userId, string permissionItemCode)
        {
            string[] names = null;
            object[] values = null;
            var returnValue = new DataTable(PiRoleTable.TableName);
            // 这里需要判断,是系统权限？
            var isRole = false;
            var userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo);
            // 用户管理员,这里需要判断,是业务权限？
            isRole = userRoleManager.UserInRole(userId, "UserAdmin") || userRoleManager.UserInRole(userId, "Admin");
            if (isRole)
            {
                var manager = new PiUserManager(this.DBProvider, this.UserInfo);
                names = new string[] { PiUserTable.FieldIsVisible, PiUserTable.FieldDeleteMark, PiUserTable.FieldEnabled };
                values = new object[] { 1, 0, 1 };
                returnValue = manager.GetDT(names, values, PiModuleTable.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            var sqlQuery = string.Empty;
            sqlQuery = " SELECT * FROM " + PiUserTable.TableName;
            sqlQuery += " WHERE " + PiUserTable.TableName + "." + PiUserTable.FieldDeleteMark + " = 0 "
                     + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldIsVisible + " = 1 "
                     + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldEnabled + " = 1 "
                     + " AND " + PiUserTable.TableName + "." + PiUserTable.FieldId + " IN ("
                     + this.GetUserIdsSql(userId, permissionItemCode)
                     + " ) "
                     + " ORDER BY " + PiUserTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public string[] GetTargetIds(string userId, string targetCategory, string permissionItemId)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="targetCategory"></param>
        /// <param name="permissionItemId"></param>
        /// <returns>主键数组</returns>
        public string[] GetTargetIds(string userId, string targetCategory, string permissionItemId)
        {
            var returnValue = new string[0];
            var names = new string[5];
            var values = new string[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldPermissionId;
            values[2] = permissionItemId;
            names[3] = PiPermissionScopeTable.FieldTargetCategory;
            values[3] = targetCategory;
            var dataTable = this.GetDT(names, values);
            returnValue = BusinessLogic.FieldToArray(dataTable, PiPermissionScopeTable.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // ResourcePermissionScope 权限判断
        //

        /// <summary>
        /// 转换用户的权限范围
        /// </summary>
        /// <param name="userId">目标用户</param>
        /// <param name="resourceIds">权限范围</param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public PermissionScope TransformPermissionScope(string userId, ref string[] resourceIds, PiUserManager userManager = null)
        {
            var permissionScope = PermissionScope.None;
            if (resourceIds != null && resourceIds.Length > 0)
            {
                if (userManager == null)
                {
                    userManager = new PiUserManager(DBProvider, UserInfo);
                }
                var userEntity = userManager.GetEntity(userId);

                for (var i = 0; i < resourceIds.Length; i++)
                {
                    if (resourceIds[i].Equals(((int)PermissionScope.All).ToString()))
                    {
                        permissionScope = PermissionScope.All;
                        continue;
                    }
                    if (resourceIds[i].Equals(((int)PermissionScope.UserCompany).ToString()))
                    {
                        resourceIds[i] = BusinessLogic.ConvertToString(userEntity.CompanyId);
                        permissionScope = PermissionScope.UserCompany;
                        continue;
                    }
                   
                    if (resourceIds[i].Equals(((int)PermissionScope.UserDepartment).ToString()))
                    {
                        resourceIds[i] = BusinessLogic.ConvertToString(userEntity.DepartmentId);
                        permissionScope = PermissionScope.UserDepartment;
                        continue;
                    }
                    if (resourceIds[i].Equals(((int)PermissionScope.UserWorkgroup).ToString()))
                    {
                        resourceIds[i] = BusinessLogic.ConvertToString(userEntity.WorkgroupId);
                        permissionScope = PermissionScope.UserWorkgroup;
                        continue;
                    }
                }
            }
            return permissionScope;
        }

        #region public string[] GetResourceScopeIds(string userId, string targetCategory, string permissionItemCode) 获得用户的某个权限范围资源主键数组
        /// <summary>
        /// 获得用户的某个权限范围资源主键数组
        /// </summary>
        /// <param name="userId">用户</param>
        /// <param name="targetCategory">资源分类</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetResourceScopeIds(string userId, string targetCategory, string permissionItemCode)
        {
            var permissionItemManager = new PiPermissionItemManager(DBProvider, UserInfo,PiPermissionItemTable.TableName);
            var permissionItemId = permissionItemManager.GetId(PiPermissionItemTable.FieldCode, permissionItemCode);
            
            var userManager = new PiUserManager(DBProvider, UserInfo);
            var defaultRoleId = userManager.GetProperty(userId, PiUserTable.FieldRoleId);
            
            var sqlQuery = string.Empty;
            sqlQuery =  
                        // 用户的权限
                          " SELECT PIPERMISSIONSCOPE.TARGETID "
                        + "   FROM PIPERMISSIONSCOPE "
                        + "  WHERE (PIPERMISSIONSCOPE.RESOURCECATEGORY = '" + PiUserTable.TableName + "') "
                        + "        AND (PIPERMISSIONSCOPE.RESOURCEID = '" + userId + "') "
                        + "        AND (PIPERMISSIONSCOPE.TARGETCATEGORY = '" + targetCategory + "') "
                        + "        AND (PIPERMISSIONSCOPE.PERMISSIONID = '" + permissionItemId + "') "
                        + "        AND (PIPERMISSIONSCOPE.ENABLED = 1) "
                        + "        AND (PIPERMISSIONSCOPE.DELETEMARK = 0) "
                        //+ "        AND (dbo.PiPermissionScope.TargetId IN ( "
                        //+ "             SELECT PiModule.Id FROM PiModule WHERE DeleteMark = 0 AND Enabled = 1 )) "
                      
                        + " UNION "
               
                        // 用户归属的角色的权限                            
                        + " SELECT PIPERMISSIONSCOPE.TARGETID "
                        + "   FROM PIPERMISSIONSCOPE "
                        + "  WHERE (PIPERMISSIONSCOPE.RESOURCECATEGORY  = '" + PiRoleTable.TableName + "') "
                        + "        AND (PIPERMISSIONSCOPE.TARGETCATEGORY  = '" + targetCategory + "') "
                        + "        AND (PIPERMISSIONSCOPE.PERMISSIONID = '" + permissionItemId + "') "
                        + "        AND (PIPERMISSIONSCOPE.DELETEMARK = 0)"
                        + "        AND (PIPERMISSIONSCOPE.ENABLED = 1) "
                        + "        AND ((PIPERMISSIONSCOPE.RESOURCEID IN ( "
                        + "             SELECT PIUSERROLE.ROLEID "
                        + "               FROM PIUSERROLE "
                        + "              WHERE (PIUSERROLE.USERID  = '" + userId + "') "
                        + "                  AND (PIUSERROLE.ENABLED = 1) "
                        + "                  AND (PIUSERROLE.DELETEMARK = 0) ) ";
                        if (!string.IsNullOrEmpty(defaultRoleId))
                        {
                            // 用户的默认角色
                            sqlQuery += " OR (PIPERMISSIONSCOPE.RESOURCEID = '" + defaultRoleId + "')";
                        }
                        sqlQuery += " ) " 
                        + " ) ";

            var dataTable = DBProvider.Fill(sqlQuery);
            var resourceIds = BusinessLogic.FieldToArray(dataTable, PiPermissionScopeTable.FieldTargetId);

            // 按部门获取权限
            if (SystemInfo.EnableOrganizePermission)
            {
                sqlQuery = string.Empty;
                var userEntity = new PiUserManager(this.DBProvider).GetEntity(userId);
                sqlQuery = " SELECT TARGETID "
                           + "   FROM " + PiPermissionScopeTable.TableName
                           + "  WHERE (" + PiPermissionScopeTable.TableName + ".RESOURCECATEGORY = '" + PiOrganizeTable.TableName + "') "
                           + "        AND (RESOURCEID = '" + userEntity.CompanyId + "' OR "
                           + "              RESOURCEID = '" + userEntity.DepartmentId + "' OR "
                           + "              RESOURCEID = '" + userEntity.WorkgroupId + "') "
                           + "        AND (TARGETCATEGORY = '" + targetCategory + "') "
                           + "        AND (PERMISSIONID = '" + permissionItemId + "') "
                           + "        AND (ENABLED = 1) "
                           + "        AND (DELETEMARK = 0)";
                dataTable = DBProvider.Fill(sqlQuery);
                var resourceIdsByOrganize = BusinessLogic.FieldToArray(dataTable,PiPermissionScopeTable.FieldTargetId);
                resourceIds = BusinessLogic.Concat(resourceIds, resourceIdsByOrganize);
            }

            if (targetCategory.Equals(PiOrganizeTable.TableName))
            {
                TransformPermissionScope(userId, ref resourceIds, userManager);
            }
            return resourceIds;
        }
        #endregion

        #region public string[] GetTreeResourceScopeIds(string userId, string tableName, string permissionItemCode, bool childrens) 树型资源的权限范围
        /// <summary>
        /// 树型资源的权限范围      
        /// </summary>
        /// <param name="userId">用户</param>
        /// <param name="tableName">资源分类</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">是否含子节点</param>
        /// <returns>主键数组</returns>
        public string[] GetTreeResourceScopeIds(string userId, string tableName, string permissionItemCode, bool childrens)
        {
            string[] resourceScopeIds = null;
            resourceScopeIds = GetResourceScopeIds(userId, tableName, permissionItemCode);
            if (!childrens)
            {
                return resourceScopeIds;
            }
            var idList = BusinessLogic.ArrayToList(resourceScopeIds,"'");
            // 若本来就没管理部门啥的，那就没必要进行递归操作了
            if (!string.IsNullOrEmpty(idList))
            {
                var sqlQuery = @" WITH PermissionScopeTree AS (SELECT ID 
                                                                FROM " + tableName + @"
                                                                WHERE (Id IN (" + idList + @") )
                                                                UNION ALL
                                                               SELECT ResourceTree.Id
                                                                 FROM " + tableName + @"   ResourceTree INNER JOIN
                                                                      PiPermissionScope   A ON A.Id = ResourceTree.ParentId)
                                                   SELECT Id
                                                     FROM PermissionScopeTree ";
                //LogHelper.WriteLog(sqlQuery);
                //增加对MySQL的支持。
                if (DBProvider.CurrentDbType == CurrentDbType.MySql)
                {
                    sqlQuery = @" SELECT ID FROM (SELECT ID 
                                                        FROM " + tableName + @"
                                                        WHERE (Id IN (" + idList + @") )
                                                        UNION ALL
                                                        SELECT ResourceTree.Id AS ID
                                                            FROM " + tableName + @" AS ResourceTree INNER JOIN
                                                                PiPermissionScope AS A ON A.Id = ResourceTree.ParentId) AS PermissionScopeTree";
                }
                var dataTable = DBProvider.Fill(sqlQuery);
                var resourceIds = BusinessLogic.FieldToArray(dataTable, "ID");
                return BusinessLogic.Concat(resourceScopeIds, resourceIds);
            }
            return resourceScopeIds;
        }
        #endregion

        #region public bool IsModuleAuthorized(UserInfo userInfo, string moduleCode, string permissionItemCode) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleCode"></param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorized(UserInfo userInfo, string moduleCode, string permissionItemCode)
        {
            // 先判断用户类别
            if (userInfo.IsAdministrator)
            {
                return true;
            }
            return this.IsModuleAuthorized(userInfo.Id, moduleCode, permissionItemCode);
        }
        #endregion

        #region public bool IsModuleAuthorized(string userId, string moduleCode, string permissionItemCode) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleCode"></param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorized(string userId, string moduleCode, string permissionItemCode)
        {
            var moduleManager = new PiModuleManager(DBProvider);
            var moduleId = moduleManager.GetIdByCode(moduleCode);
            var permissionItemManager = new PiPermissionItemManager(DBProvider);
            var permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);
            // 判断员工权限
            if (this.CheckUserModulePermission(userId, moduleId, permissionItemId))
            {
                return true;
            }
            // 判断员工角色权限
            return this.CheckRoleModulePermission(userId, moduleId, permissionItemId);
        }
        #endregion

        #region private bool CheckUserModulePermission(string userId, string moduleId, string permissionItemId)
        /// <summary>
        /// 员工是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>是否有权限</returns>
        private bool CheckUserModulePermission(string userId, string moduleId, string permissionItemId)
        {
            return CheckResourcePermissionScope(PiModuleTable.TableName, userId, PiModuleTable.TableName, moduleId, permissionItemId);
        }
        #endregion

        #region private bool CheckResourcePermissionScope(string resourceCategory, string resourceId, string targetCategory, string targetId, string permissionItemId) 检查权限范围资源
        private bool CheckResourcePermissionScope(string resourceCategory, string resourceId, string targetCategory, string targetId, string permissionItemId)
        {
            var sqlQuery = " SELECT COUNT(*) "
                             + "  FROM PiPermissionScope "
                             + " WHERE (PiPermissionScope.ResourceCategory = '" + resourceCategory + "')"
                             + "       AND (PiPermissionScope.Enabled = 1) "
                             + "       AND (PiPermissionScope.DeleteMark = 0 )"
                             + "       AND (PiPermissionScope.ResourceId = '" + resourceId + "')"
                             + "       AND (PiPermissionScope.TargetCategory = '" + targetCategory + "')"
                             + "       AND (PiPermissionScope.TargetId = '" + targetId + "')"
                             + "       AND (PiPermissionScope.PermissionId = '" + permissionItemId + "'))";
            var rowCount = 0;

            var returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }
        #endregion

        #region private bool CheckRoleModulePermission(string userId, string moduleId, string permissionItemId)
        /// <summary>
        /// 员工角色关系是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>有角色权限</returns>
        private bool CheckRoleModulePermission(string userId, string moduleId, string permissionItemId)
        {
            return CheckRolePermissionScope(userId, PiModuleTable.TableName, moduleId, permissionItemId);
        }
        #endregion

        private bool CheckRolePermissionScope(string userId, string targetCategory, string targetId, string permissionItemId)
        {
            var sqlQuery = " SELECT COUNT(*) "
                            + "   FROM PIPERMISSIONSCOPE "
                            + "  WHERE (PIPERMISSIONSCOPE.RESOURCECATEGORY = '" + PiRoleTable.TableName + "') "
                            + "        AND (PIPERMISSIONSCOPE.ENABLED = 1 "
                            + "        AND (PIPERMISSIONSCOPE.DELETEMARK = 0 "
                            + "        AND (PIPERMISSIONSCOPE.RESOURCEID IN ( "
                                             + " SELECT PIUSERROLE.ROLEID "
                                             + "   FROM PIUSERROLE "
                                             + "  WHERE PIUSERROLE.USERID = '" + userId + "'"
                                             + "        AND PIUSERROLE.ENABLED = 1 "
                                             + "  UNION "
                                             + " SELECT " + PiUserTable.FieldRoleId
                                             + "   FROM " + PiUserTable.TableName
                                             + "  WHERE " + PiUserTable.FieldId + " = '" + userId + "'"
                                             + ")) "
                            + " AND (PIPERMISSIONSCOPE.TARGETCATEGORY = '" + targetCategory + "') "
                            + " AND (PIPERMISSIONSCOPE.TARGETID = '" + targetId + "') "
                            + " AND (PIPERMISSIONSCOPE.PERMISSIONID = '" + permissionItemId + "')) ";
            var rowCount = 0;

            var returnObject = DBProvider.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }

        public int GrantResourcePermissionScopeTarget(string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var returnValue = 0;

            var names = new string[7];
            var values = new object[7];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = resourceCategory;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = resourceId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = targetCategory;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = permissionItemId;
            names[5] = PiPermissionScopeTable.FieldEnabled;
            values[5] = 1;
            names[6] = PiPermissionScopeTable.FieldDeleteMark;
            values[6] = 0;

            var resourcePermissionScope = new PiPermissionScopeEntity
            {
                Id = null,
                ResourceCategory = resourceCategory,
                ResourceId = resourceId,
                TargetCategory = targetCategory,
                PermissionId = permissionItemId,
                StartDate = startDate,
                EndDate = endDate,
                Enabled = 1,
                DeleteMark = 0
            };

            for (var i = 0; i < grantTargetIds.Length; i++)
            {
                resourcePermissionScope.TargetId = grantTargetIds[i];
                values[3] = grantTargetIds[i];
                if (!this.Exists(names, values))
                {
                    this.Add(resourcePermissionScope);
                    returnValue++;
                }
            }
            return returnValue;
        }

        public int GrantResourcePermissionScopeTarget(string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId)
        {
            var returnValue = 0;

            var names = new string[7];
            var values = new object[7];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = resourceCategory;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            // values[1] = resourceId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = targetCategory;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = grantTargetId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = permissionItemId;
            names[5] = PiPermissionScopeTable.FieldEnabled;
            values[5] = 1;
            names[6] = PiPermissionScopeTable.FieldDeleteMark;
            values[6] = 0;

            var resourcePermissionScope = new PiPermissionScopeEntity
            {
                ResourceCategory = resourceCategory,
                TargetCategory = targetCategory,
                PermissionId = permissionItemId,
                TargetId = grantTargetId,
                Enabled = 1,
                DeleteMark = 0
            };
            // resourcePermissionScope.ResourceId = resourceId;

            for (var i = 0; i < resourceIds.Length; i++)
            {
                resourcePermissionScope.ResourceId = resourceIds[i];
                values[1] = resourceIds[i];
                if (!this.Exists(names, values))
                {
                    this.Add(resourcePermissionScope);
                    returnValue++;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 52.撤消资源的权限范围
        /// </summary>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeResourcePermissionScopeTarget(string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId)
        {
            var returnValue = 0;

            var names = new string[6];
            var values = new object[6];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = resourceCategory;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = resourceId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = targetCategory;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = permissionItemId;
            // names[5] = BasePermissionScopeEntity.FieldDeleteMark;
            // values[5] = 0;
            names[5] = PiPermissionScopeTable.FieldEnabled;
            values[5] = 1;
            for (var i = 0; i < revokeTargetIds.Length; i++)
            {
                values[3] = revokeTargetIds[i];
                // 逻辑删除
                //returnValue += this.SetDeleted(names, values);
                // 物理删除
                returnValue += this.Delete(names, values);
            }

            return returnValue;
        }

        /// <summary>
        /// 52.撤消资源的权限范围
        /// </summary>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeResourcePermissionScopeTarget(string resourceCategory, string resourceId, string targetCategory, string permissionItemId)
        {
            var names = new string[5];
            var values = new object[5];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = resourceCategory;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = resourceId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = targetCategory;
            names[3] = PiPermissionScopeTable.FieldPermissionId;
            values[3] = permissionItemId;
            names[4] = PiPermissionScopeTable.FieldEnabled;
            values[4] = 1;
            // 逻辑删除
            //return this.SetDeleted(names, values);
            // 物理删除
             return this.Delete(names,values);
        }

        public int RevokeResourcePermissionScopeTarget(string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId)
        {
            var returnValue = 0;
            var names = new string[6];
            var values = new object[6];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = resourceCategory;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            // values[1] = resourceId;
            names[2] = PiPermissionScopeTable.FieldTargetCategory;
            values[2] = targetCategory;
            names[3] = PiPermissionScopeTable.FieldTargetId;
            values[3] = revokeTargetId;
            names[4] = PiPermissionScopeTable.FieldPermissionId;
            values[4] = permissionItemId;
            // names[5] = BasePermissionScopeEntity.FieldDeleteMark;
            // values[5] = 0;
            names[5] = PiPermissionScopeTable.FieldEnabled;
            values[5] = 1;
            for (var i = 0; i < resourceIds.Length; i++)
            {
                values[1] = resourceIds[i];
                // 逻辑删除
                //returnValue += this.SetDeleted(names, values);
                // 物理删除
                returnValue += this.Delete(names, values);
            }
            return returnValue;
        }

        #region public bool HasAuthorized(string[] names, object[] values, string startDate, string endDate) 判断某个时间范围内是否存在
        /// <summary>
        /// 判断某个时间范围内是否存在
        /// </summary>
        /// <param name="names"></param>
        /// <param name="values"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool HasAuthorized(string[] names, object[] values, string startDate, string endDate)
        {
            var returnValue = false;
            var manager = new PiPermissionScopeManager(this.DBProvider, this.UserInfo);
            returnValue = manager.Exists(names, values);
            /*
            if (returnValue)
            {
                // 再去判断时间
                string minDate = "1900-01-01 00:00:00";
                string maxDate = "3000-12-31 00:00:00";
                // 不用设置的太大
                string srcStartDate = manager.GetProperty(names, values, PiPermissionScopeTable.FieldStartDate);
                string srcEndDate = manager.GetProperty(names, values, PiPermissionScopeTable.FieldEndDate);
                if (string.IsNullOrEmpty(srcStartDate))
                {
                    srcStartDate = minDate;
                }
                if (string.IsNullOrEmpty(startDate))
                {
                    startDate = minDate;
                }
                if (string.IsNullOrEmpty(srcEndDate))
                {
                    srcEndDate = maxDate;
                }
                if (string.IsNullOrEmpty(endDate))
                {
                    endDate = maxDate;
                }
                // 满足这样的条件
                // 时间A(Start1-End1)，   时间B(Start2-End2)
                // Start1 <Start2   &&   Start2 <End1
                // Start1 <End2   &&   End2 <End1
                // Start2 <Start1   &&   End1 <End2
                if ((CheckDateScope(srcStartDate, startDate) && CheckDateScope(startDate, srcEndDate)) 
                    || (CheckDateScope(srcStartDate, endDate) && CheckDateScope(endDate, srcEndDate)) 
                    || (CheckDateScope(startDate, srcStartDate) && CheckDateScope(srcEndDate, endDate)))
                {
                    returnValue = true;
                }
                else 
                {
                    returnValue = false;
                }                   
            }
            */
            return returnValue;
        }
        #endregion

        #region  public int CheckDateScope(string smallDate,string bigDate) 检查日期大小
        /// <summary>
        /// 检查日期大小
        /// </summary>
        /// <param name="smallDate">开始日期</param>
        /// <param name="bigDate">结束日期</param>
        /// <returns>0：小于等于 1：大于等于</returns>
        public bool CheckDateScope(string smallDate, string bigDate)
        {
            // 开始日期是无限大
            // 结束日期是无限大
            return DateTime.Parse(smallDate) < DateTime.Parse(bigDate);
        }
        #endregion

        public DataTable Search(string resourceId, string resourceCategory, string targetCategory)
        {
            var sqlQuery = string.Empty;
            sqlQuery = "SELECT * FROM " + this.CurrentTableName
                            + " WHERE " + PiPermissionScopeTable.FieldDeleteMark + " =0 "
                            + " AND " + PiPermissionScopeTable.FieldEnabled + " =1 ";
            var dbParameters = new List<IDbDataParameter>();
            if (!String.IsNullOrEmpty(resourceId))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldResourceId + " = '" + resourceId + "'";
            }
            if (!String.IsNullOrEmpty(resourceCategory))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldResourceCategory + " = '" + resourceCategory + "'";
            }
            if (!String.IsNullOrEmpty(targetCategory))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldTargetCategory + " = '" + targetCategory + "'";
            }
            sqlQuery += " ORDER BY " + PiPermissionScopeTable.FieldCreateOn + " DESC ";
            return DBProvider.Fill(sqlQuery);
            
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (!string.IsNullOrEmpty(dt.Rows[i][PiPermissionScopeTable.FieldEndDate].ToString()))
            //    {
            //        // 过期的不显示
            //        if (DateTime.Parse(dt.Rows[i][PiPermissionScopeTable.FieldEndDate].ToString()).Date < DateTime.Now.Date)
            //        {
            //            dt.Rows.RemoveAt(i);
            //        }
            //    }
            //}
        }

        #region public DataTable GetAuthoriedList(string resourceCategory, string permissionItemId, string targetCategory, string targetId) 获得有效的委托列表
        public DataTable GetAuthoriedList(string resourceCategory, string permissionItemId, string targetCategory, string targetId)
        {
            var sqlQuery = string.Empty;
            sqlQuery = "SELECT * FROM " + this.CurrentTableName
                            + " WHERE " + PiPermissionScopeTable.FieldDeleteMark + " =0 "
                            + " AND " + PiPermissionScopeTable.FieldEnabled + " =1 ";
            if (!String.IsNullOrEmpty(resourceCategory))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldResourceCategory + " = '" + resourceCategory + "'";
            }
            if (!String.IsNullOrEmpty(permissionItemId))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldPermissionId + " = '" + permissionItemId + "'";
            }
            if (!String.IsNullOrEmpty(targetCategory))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldTargetCategory + " = '" + targetCategory + "'";
            }
            if (!String.IsNullOrEmpty(targetId))
            {
                sqlQuery += " AND " + PiPermissionScopeTable.FieldTargetId + " = '" + targetId + "'";
            }
            // 时间在startDate或者endDate之间为有效
            if (SystemInfo.RDIFrameworkDbType.Equals(CurrentDbType.SqlServer))
            {
                sqlQuery += " AND ((SELECT DATEDIFF(day, " + PiPermissionScopeTable.FieldStartDate + ", GETDATE()))>=0"
                         + " OR (SELECT DATEDIFF(day, " + PiPermissionScopeTable.FieldStartDate + ", GETDATE())) IS NULL)";
                sqlQuery += " AND ((SELECT DATEDIFF(day, " + PiPermissionScopeTable.FieldEndDate + ", GETDATE()))<=0"
                         + " OR (SELECT DATEDIFF(day, " + PiPermissionScopeTable.FieldEndDate + ", GETDATE())) IS NULL)";
            }
            // TODO:其他数据库的兼容
            sqlQuery += " ORDER BY " + PiPermissionScopeTable.FieldCreateOn + " DESC ";
            return DBProvider.Fill(sqlQuery);
        }
        #endregion
    }
}
