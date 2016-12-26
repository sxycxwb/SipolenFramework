//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd.
//--------------------------------------------------------------------
using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// CiTableColumnsManager
    /// 表字段结构定义说明
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
    public partial class TableColumnsManager
    {
        #region public DataTable GetSearchFields(string tableCode) 得到查询字段项
        /// <summary>
        /// 得到查询字段项
        /// </summary>
        /// <param name="tableCode">TableCode（指定的表名）</param>
        /// <returns>DataTable</returns>
        public DataTable GetSearchFields(string tableCode)
        {
            string sqlQuery = "SELECT " + CiTableColumnsTable.FieldColumnCode + ","
                            + CiTableColumnsTable.FieldColumnName + ","
                            + CiTableColumnsTable.FieldDataType
                            + " FROM " + CiTableColumnsTable.TableName
                            + " WHERE " + CiTableColumnsTable.FieldTableCode + "='" + tableCode + "' AND "
                            + CiTableColumnsTable.FieldIsSearchColumn + "= 1 AND "
                            + CiTableColumnsTable.FieldDeleteMark + "= 0"
                            + " ORDER BY " + CiTableColumnsTable.FieldSortCode;
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetAllTableScope() 得到所有数据表（用于表字段权限的控制，主要针对PiTablePermissionScope数据表的数据）
        /// <summary>
        /// 得到所有数据表（用于表字段权限的控制，主要针对PiTablePermissionScope数据表的数据）
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllTableScope()
        {
            string sqlQuery = "SELECT ID,PARENTID,ITEMCODE,ITEMNAME,ITEMVALUE,ENABLED,ISPUBLIC,ALLOWEDIT,ALLOWDELETE,DELETEMARK"
                            + ",SORTCODE,DESCRIPTION,CREATEON,CREATEUSERID,CREATEBY,MODIFIEDON,MODIFIEDUSERID,MODIFIEDBY"
                            + " FROM PITABLEPERMISSIONSCOPE"
                            + " WHERE DELETEMARK = 0 "
                            + " ORDER BY SORTCODE";
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetTableNameAndCode() 得到所有数据表（表的中文名称与英文名称）
        /// <summary>
        /// 得到所有数据表（表的中文名称与英文名称）
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableNameAndCode()
        {
            //SQLSERVER:SELECT DISTINCT TableCode,TableCode + ' ' +TableName AS TableName FROM dbo.CiTableColumns ORDER BY TableCode
            //ORACEL: SELECT DISTINCT TableCode,TableCode || ' ' || NVL(TableName,'') AS TableName FROM CiTableColumns ORDER BY TableCode
            //string sqlQuery = string.Format("SELECT DISTINCT {0},{1} + ' ' + {2}  AS TABLENAME FROM {3}  ORDER BY {4}", CiTableColumnsTable.FieldTableCode, CiTableColumnsTable.FieldTableCode, CiTableColumnsTable.FieldTableName, CiTableColumnsTable.TableName, CiTableColumnsTable.FieldTableCode);
            string sqlQuery = "SELECT DISTINCT TABLECODE,TABLECODE AS TABLENAME FROM CITABLECOLUMNS ORDER BY TABLECODE";
            if (DBProvider.CurrentDbType == CurrentDbType.Oracle)
            {
                //sqlQuery = string.Format(@"SELECT DISTINCT {0},{1} || ' ' NVL({2},'')'  AS TABLENAME FROM {3}  ORDER BY {4}", CiTableColumnsTable.FieldTableCode, CiTableColumnsTable.FieldTableCode, CiTableColumnsTable.FieldTableName, CiTableColumnsTable.TableName, CiTableColumnsTable.FieldTableCode);
                sqlQuery = "SELECT DISTINCT TABLECODE,TABLECODE AS TABLENAME FROM CITABLECOLUMNS ORDER BY TABLECODE";
            }
            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public string[] GetColumns(string tableCode, string permissionCode = "Column.Access") 获取用户的列权限
        /// <summary>
        /// 获取用户的列权限
        /// </summary>
        /// <param name="tableCode">表名</param>
        /// <param name="permissionCode">操作权限</param>
        /// <returns>有权限的列数组</returns>
        public string[] GetColumns(string tableCode, string permissionCode = "Column.Access")
        {
            return GetColumns(this.UserInfo.Id, tableCode, permissionCode);
        }
        #endregion

        #region public string[] GetColumns(string userId, string tableCode, string permissionCode = "Column.Access") 获取用户的列权限
        /// <summary>
        /// 获取用户的列权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="tableCode">表名</param>
        /// <param name="permissionCode">操作权限</param>
        /// <returns>有权限的列数组</returns>
        public string[] GetColumns(string userId, string tableCode, string permissionCode = "Column.Access")
        {
            // Column.Edit
            string[] returnValue = null;
            if (permissionCode.Equals("Column.Deney") || permissionCode.Equals("Column.Edit"))
            {
                // 按数据权限来过滤数据
                PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
                returnValue = permissionScopeManager.GetResourceScopeIds(userId, tableCode, permissionCode);
            }
            else if (permissionCode.Equals("Column.Access"))
            {
                // 1: 用户有权限的列名
                PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
                returnValue = permissionScopeManager.GetResourceScopeIds(userId, tableCode, permissionCode);
                // 2: 先获取公开的列名
                string[] publicIds = this.GetIds(CiTableColumnsTable.FieldTableCode, tableCode, CiTableColumnsTable.FieldIsPublic, 1, CiTableColumnsTable.FieldColumnCode);
                returnValue = BusinessLogic.Concat(returnValue, publicIds);
            }
            return returnValue;
        }
        #endregion

        #region public DataTable GetTableColumns(string tableCode) 获取能访问的字段列表
        /// <summary>
        /// 获取能访问的字段列表
        /// </summary>
        /// <param name="userId">用户代码</param>
        /// <param name="tableCode">表名</param>
        /// <returns>数据表</returns>
        public DataTable GetTableColumns(string userId,string tableCode)
        {
            // 当前用户对哪些资源有权限（用户自己的权限 + 相应的角色拥有的权限）
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            string[] ids = permissionScopeManager.GetResourceScopeIds(userId, "TableColumns", "ColumnAccess");

            // 获取有效的，没删除标志的
            string sqlQuery = " SELECT * FROM " + CiTableColumnsTable.TableName + " WHERE (" + CiTableColumnsTable.FieldDeleteMark +" = 0 AND " + CiTableColumnsTable.FieldEnabled + " = 1) ";

            // 是否指定了表名
            if (!string.IsNullOrEmpty(tableCode))
            {
                sqlQuery += " AND (" +CiTableColumnsTable.FieldTableCode + "= '" + tableCode + "') ";
            }

            // 公开的或者按权限来过滤字段
            sqlQuery += " AND (" + CiTableColumnsTable.FieldIsPublic +" = 1 ";
            if (ids != null && ids.Length > 0)
            {
                string idList = BusinessLogic.ArrayToList(ids,"'");
                sqlQuery += " OR " + CiTableColumnsTable.FieldId +" IN (" + idList + ")";
            }
            sqlQuery += ") ORDER BY " + CiTableColumnsTable.FieldSortCode;

            return DBProvider.Fill(sqlQuery);
        }
        #endregion

        #region public int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[CiTableColumnsTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.DeleteEntity(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[CiTableColumnsTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        CiTableColumnsEntity entity = BaseEntity.Create<CiTableColumnsEntity>(dataRow); 
                        returnValue += this.UpdateEntity(entity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    CiTableColumnsEntity staffEntity = BaseEntity.Create<CiTableColumnsEntity>(dataRow); 
                    returnValue += this.AddEntity(staffEntity).Length > 0 ? 1 : 0;
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
            this.ReturnStatusCode = StatusCode.OK.ToString();
            return returnValue;
        }
        #endregion

        #region public DataTable GetConstraintDT(string resourceCategory, string resourceId, string permissionCode = "Resource.AccessPermission")  获取约束条件（所有的约束）
        /// <summary>
        /// 获取约束条件（所有的约束）
        /// </summary>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="permissionCode">权限代码</param>
        /// <returns>数据表</returns>
        public DataTable GetConstraintDT(string resourceCategory, string resourceId, string permissionCode = "Resource.AccessPermission")
        {
            DataTable dataTable = new DataTable(CiTableColumnsTable.TableName);

            /*
            -- 这里是都有哪些表？
            SELECT ItemValue, ItemName
            FROM PiTablePermissionScope
            WHERE (DeleteMark = 0) 
            AND (Enabled = 1)
            ORDER BY PiTablePermissionScope.SortCode
             */

            /*
            -- 这里是都有有哪些表达式
            SELECT     Id, TargetId, PermissionConstraint   -- 对什么表有什么表达式？
            FROM         PiPermissionScope
            WHERE (ResourceId = 10000000) 
            AND (ResourceCategory = 'PiRole')   -- 什么角色？
            AND (TargetId = 'PiUser') 
            AND (TargetCategory = 'Table') 
            AND (PermissionId = 10000001)  -- 有什么权限？（资源访问权限）
            AND (DeleteMark = 0) 
            AND (Enabled = 1)
             */

            string permissionId = string.Empty;
            PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(this.UserInfo);
            permissionId = permissionItemManager.GetIdByAdd(permissionCode);

            string sqlQuery = @" SELECT PIPERMISSIONSCOPE.ID
		                                    , PITABLEPERMISSIONSCOPE.ITEMVALUE  TABLECODE
		                                    , PITABLEPERMISSIONSCOPE.ITEMNAME  TABLENAME
		                                    , PIPERMISSIONSCOPE.PERMISSIONCONSTRAINT
		                                    , PITABLEPERMISSIONSCOPE.SORTCODE
                                    FROM  (
	                                    SELECT ITEMVALUE
		                                     , ITEMNAME
		                                     , SORTCODE
	                                    FROM PITABLEPERMISSIONSCOPE
                                       WHERE (DELETEMARK = 0) 
		                                      AND (ENABLED = 1)                                              
                                        )  PITABLEPERMISSIONSCOPE LEFT OUTER JOIN
                                        (SELECT ID
			                                    , TARGETID
			                                    , PERMISSIONCONSTRAINT  
                                           FROM PIPERMISSIONSCOPE
                                         WHERE (RESOURCECATEGORY = '" + resourceCategory + @"') 
			                                    AND (RESOURCEID = '" + resourceId + @"') 
			                                    AND (TARGETCATEGORY = 'Table') 
			                                    AND (PERMISSIONID = '" + permissionId + @"') 
			                                    AND (DELETEMARK = 0) 
			                                    AND (ENABLED = 1)
	                                     )  PIPERMISSIONSCOPE 
                                    ON PITABLEPERMISSIONSCOPE.ITEMVALUE = PIPERMISSIONSCOPE.TARGETID
                                    ORDER BY PITABLEPERMISSIONSCOPE.SORTCODE ";

            dataTable = this.Fill(sqlQuery);
            dataTable.TableName = CiTableColumnsTable.TableName;

            return dataTable;
        }
        #endregion

        #region public string GetUserConstraint(string tableName, string permissionCode = "Resource.AccessPermission") 获取用户的条件约束表达式
        /// <summary>
        /// 获取用户的条件约束表达式
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="permissionCode">权限代码</param>
        /// <returns>主键</returns>
        public string GetUserConstraint(string tableName, string permissionCode = "Resource.AccessPermission")
        {
            string returnValue = string.Empty;
            // 这里是获取用户的条件表达式
            // 1: 首先用户在哪些角色里是有效的？
            // 2: 这些角色都有哪些哪些条件约束？
            // 3: 组合约束条件？
            // 4：用户本身的约束条件？
            string permissionId = string.Empty;
            PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(this.UserInfo);
            permissionId = permissionItemManager.GetIdByAdd(permissionCode);

            PiUserRoleManager manager = new PiUserRoleManager(this.DBProvider, this.UserInfo);
            string[] roleIds = manager.GetAllRoleIds(UserInfo.Id);
            if (roleIds == null || roleIds.Length == 0)
            {
                return returnValue;
            }
            PiPermissionScopeManager scopeManager = new PiPermissionScopeManager(this.DBProvider, this.UserInfo);

            string[] names =
            { 
                PiPermissionScopeTable.FieldResourceCategory
                , PiPermissionScopeTable.FieldResourceId
                , PiPermissionScopeTable.FieldTargetCategory
                , PiPermissionScopeTable.FieldTargetId
                , PiPermissionScopeTable.FieldPermissionId
                , PiPermissionScopeTable.FieldEnabled
                , PiPermissionScopeTable.FieldDeleteMark };
            Object[] values =
            { 
                PiRoleTable.TableName
                , roleIds
                , "Table"
                , tableName
                , permissionId
                , 1
                , 0 };

            DataTable dtPermissionScope = scopeManager.GetDT(names, values);
            string permissionConstraint = string.Empty;
            foreach (DataRow dataRow in dtPermissionScope.Rows)
            {
                permissionConstraint = dataRow[PiPermissionScopeTable.FieldPermissionConstraint].ToString();
                permissionConstraint = permissionConstraint.Trim();
                if (!string.IsNullOrEmpty(permissionConstraint))
                {
                    returnValue += " AND " + permissionConstraint;
                }
            }

            //得到当前用户的约束条件
            string userConstraint = this.GetConstraint(PiUserTable.TableName, this.UserInfo.Id, tableName) ?? "";
            if (!string.IsNullOrEmpty(userConstraint))
            {
                returnValue += " AND " + userConstraint;
            }

            if (!string.IsNullOrEmpty(returnValue))
            {
                returnValue = returnValue.Substring(5);
                // 解析替换约束表达式标准函数
                returnValue = ConstraintUtil.PrepareParameter(this.UserInfo, returnValue);
            }

            return returnValue;
        }
        #endregion

        #region public string SetConstraint(string resourceCategory, string resourceId, string tableName, string permissionCode, string constraint, bool enabled = true) 设置约束条件
        /// <summary>
        /// 设置约束条件
        /// </summary>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <param name="constraint">约束</param>
        /// <param name="enabled">有效</param>
        /// <param name="permissionCode">操作权限项</param>
        /// <returns>主键</returns>
        public string SetConstraint(string resourceCategory, string resourceId, string tableName, string permissionCode, string constraint, bool enabled = true)
        {
            string returnValue = string.Empty;

            string permissionId = string.Empty;
            PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(this.UserInfo);
            permissionId = permissionItemManager.GetIdByAdd(permissionCode);

            PiPermissionScopeManager manager = new PiPermissionScopeManager(this.DBProvider, this.UserInfo);
            string[] names =
            { 
                PiPermissionScopeTable.FieldResourceCategory
                , PiPermissionScopeTable.FieldResourceId
                , PiPermissionScopeTable.FieldTargetCategory
                , PiPermissionScopeTable.FieldTargetId
                , PiPermissionScopeTable.FieldPermissionId
                , PiPermissionScopeTable.FieldDeleteMark };
            Object[] values =
            { 
                resourceCategory
                , resourceId
                , "Table"
                , tableName
                , permissionId
                , 0 };

            // 1:先获取是否有这样的主键，若有进行更新操作。
            // 2:若没有进行添加操作。
            returnValue = manager.GetId(names, values);
            if (!string.IsNullOrEmpty(returnValue))
            {
                string[] targetFields = { PiPermissionScopeTable.FieldPermissionConstraint, PiPermissionScopeTable.FieldEnabled };
                Object[] targetValues = { constraint, enabled ? 1 : 0 };
                manager.SetProperty(PiPermissionScopeTable.FieldId, returnValue, targetFields, targetValues);
            }
            else
            {
                PiPermissionScopeEntity entity = new PiPermissionScopeEntity
                {
                    ResourceCategory = resourceCategory,
                    ResourceId = resourceId,
                    TargetCategory = "Table",
                    TargetId = tableName,
                    PermissionConstraint = constraint,
                    PermissionId = permissionId,
                    DeleteMark = 0,
                    Enabled = enabled ? 1 : 0
                };
                returnValue = manager.Add(entity);
            }
            return returnValue;
        }
        #endregion

        #region public string GetConstraint(string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission") 获取约束条件
        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        public string GetConstraint(string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission")
        {
            string returnValue = string.Empty;
            PiPermissionScopeEntity entity = GetConstraintEntity(resourceCategory, resourceId, tableName, permissionCode);
            if (entity != null && entity.Enabled == 1)
            {
                returnValue = entity.PermissionConstraint;
            }
            return returnValue;
        }
        #endregion 

        #region public PiPermissionScopeEntity GetConstraintEntity(string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission")
        public PiPermissionScopeEntity GetConstraintEntity(string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission")
        {
            PiPermissionScopeEntity entity = null;

            string permissionId = string.Empty;
            PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(this.UserInfo);
            permissionId = permissionItemManager.GetIdByAdd(permissionCode);

            PiPermissionScopeManager manager = new PiPermissionScopeManager(this.DBProvider, this.UserInfo);
            string[] names =
            { 
                PiPermissionScopeTable.FieldResourceCategory
                , PiPermissionScopeTable.FieldResourceId
                , PiPermissionScopeTable.FieldTargetCategory
                , PiPermissionScopeTable.FieldTargetId
                , PiPermissionScopeTable.FieldPermissionId
                , PiPermissionScopeTable.FieldDeleteMark };
            Object[] values =
            { 
                resourceCategory
                , resourceId
                , "Table"
                , tableName
                , permissionId
                , 0 };

            // 1:先获取是否有这样的主键，若有进行更新操作。
            DataTable dt = manager.GetDT(names, values);
            if (dt.Rows.Count > 0)
            {
                entity = BaseEntity.Create<PiPermissionScopeEntity>(dt); 
            }
            return entity;
        }
        #endregion
    }
}
