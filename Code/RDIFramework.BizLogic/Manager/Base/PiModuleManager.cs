//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiModuleManager
    /// 管理层
    /// 
    /// 修改纪录
    /// 
    ///		2012-03-02 版本：1.0 XuWangBin 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-03-02</date>
    /// </author> 
    /// </summary>
    public partial class PiModuleManager
    {
        #region public DataTable GetRootList()
        /// <summary>
        /// GetRoot 的主键
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetRootList()
        {
            return this.GetDTByParent(string.Empty);
        }
        #endregion

        #region  public string[] GetIDsByUser(string userId) 获取用户有权限访问的模块主键
        /// <summary>
        /// 获取用户有权限访问的模块主键
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetIDsByUser(string userId)
        {
            // 公开的模块谁都可以访问
            string[] openModuleIds = null;

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiModuleTable.FieldIsPublic, 1),
                new KeyValuePair<string, object>(PiModuleTable.FieldEnabled, 1),
                new KeyValuePair<string, object>(PiModuleTable.FieldDeleteMark, 0)
            };

            openModuleIds = this.GetIds(parameters);

            string[] twoModuleIds = null;

            if (!string.IsNullOrEmpty(userId))
            {
                // 按第一个解决方案进行计算 （用户 ---> 权限 --- 权限 <--- 菜单）
                // 获取用户的所有权限ID数组
                // PiPermissionManager permissionManager = new PiPermissionManager(DBProvider, UserInfo);
                // DataTable dtPermission = permissionManager.GetPermissionByUser(UserInfo.Id);
                // string[] permissionItemIds = BusinessLogic.FieldToArray(dtPermission, BasePermissionItemEntity.FieldId);

                /*
                string[] oneModuleIds = new string[0];
                if ((permissionItemIds != null) && (permissionItemIds.Length > 0))
                {
                    // 获取所有跟这个权限有关联的模块ID数组
                    string sqlQuery = string.Empty;
                    sqlQuery = " SELECT " + PiPermissionTable.FieldResourceId
                                + "   FROM " + PiPermissionTable.TableName
                                + "  WHERE " + PiPermissionTable.FieldResourceCategory + " = '" + PiModuleTable.TableName + "' "
                                + "        AND " + PiPermissionTable.FieldPermissionId + " IN (" + BusinessLogic.ObjectsToList(permissionItemIds) + ")";

                    dtPermission = DBProvider.Fill(sqlQuery);
                    oneModuleIds = BusinessLogic.FieldToArray(dtPermission, PiPermissionTable.FieldResourceId);
                }
                */

                //按第二个解决方案进行计算 （用户 ---> 模块访问权限 ---> 菜单）
                string tableName = PiPermissionScopeTable.TableName;
                PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo,tableName);
                // 模块访问，连同用户本身的，还有角色的，全部获取出来
                string permissionItemCode = "Resource.AccessPermission";
                twoModuleIds = permissionScopeManager.GetResourceScopeIds(userId, PiModuleTable.TableName, permissionItemCode);

                // 这些模块是有效的才可以
                parameters = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>(PiModuleTable.FieldId, twoModuleIds),
                    new KeyValuePair<string, object>(PiModuleTable.FieldEnabled, 1),
                    new KeyValuePair<string, object>(PiModuleTable.FieldDeleteMark, 0)
                };
                twoModuleIds = this.GetProperties(parameters, PiModuleTable.FieldId);
              
            }
            // 返回相应的模块列表
            string[] moduleIds = BusinessLogic.Concat(openModuleIds, twoModuleIds);
            return moduleIds;
        }
        #endregion

        #region public DataTable GetDTByUser(string userId) 某个用户可以访问的所有菜单列表
        /// <summary>
        /// 某个用户可以访问的所有菜单列表
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByUser(string userId)
        {
            string[] moduleIds = this.GetIDsByUser(userId);
            return this.GetDT(PiModuleTable.FieldId, moduleIds, PiModuleTable.FieldDeleteMark, 0, PiModuleTable.FieldSortCode);
        }
        #endregion

        #region public DataTable GetDTByPermission(string userId, string permissionItemScopeCode) 获得用户授权范围
        /// <summary>
        /// 获得用户授权范围
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemScopeCode"></param>
        /// <returns>数据表</returns>
        public DataTable GetDTByPermission(string userId, string permissionItemScopeCode)
        {
            DataTable returnValue = new DataTable(this.CurrentTableName);
            string[] names = null;
            object[] values = null;

            // 这里需要判断,是系统权限？
            bool isRole = false;
            PiUserRoleManager userRoleManager = new PiUserRoleManager(this.DBProvider, this.UserInfo);
            // 用户管理员
            isRole = userRoleManager.UserInRole(userId, "UserAdmin");
            if (isRole)
            {
                names = new string[] { PiModuleTable.FieldCategory, PiModuleTable.FieldDeleteMark, PiModuleTable.FieldEnabled };
                values = new object[] { "System", 0, 1 };
                returnValue = this.GetDT(names, values, PiModuleTable.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            // 这里需要判断,是业务权限？
            isRole = userRoleManager.UserInRole(userId, "Admin");
            if (isRole)
            {
                names = new string[] { PiModuleTable.FieldCategory, PiModuleTable.FieldDeleteMark, PiModuleTable.FieldEnabled };
                values = new object[] { "Application", 0, 1 };
                returnValue = this.GetDT(names, values, PiModuleTable.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            string[] moduleIds = permissionScopeManager.GetTreeResourceScopeIds(userId, PiModuleTable.TableName, permissionItemScopeCode, true);
            //不加载子节点
            //string[] moduleIds = permissionScopeManager.GetTreeResourceScopeIds(userId, PiModuleTable.TableName, permissionItemScopeCode, false);
            //// 有效的，未被删除的
            names = new string[] { PiModuleTable.FieldId, PiModuleTable.FieldDeleteMark, PiModuleTable.FieldEnabled };
            values = new object[] { moduleIds, 0, 1 };
            returnValue = this.GetDT(names, values, PiModuleTable.FieldSortCode);
            returnValue.TableName = this.CurrentTableName;
            return returnValue;
        }
        #endregion

        #region public string Add(string fullName) 添加的主键
        /// <summary>
        /// Add 添加的主键
        /// </summary>
        /// <param name="fullName">对象</param>
        /// <returns>主键</returns>
        public string Add(string fullName)
        {
            string statusCode = string.Empty;
            PiModuleEntity moduleEntity = new PiModuleEntity();
            moduleEntity.FullName = fullName;
            return this.Add(moduleEntity, out statusCode);
        }
        #endregion

        #region public string Add(PiModuleEntity moduleEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>返回</returns>
        public string Add(PiModuleEntity moduleEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查名称是否重复
            string[] names = { PiModuleTable.FieldDeleteMark, PiModuleTable.FieldCode, PiModuleTable.FieldFullName };
            object[] values = { 0, moduleEntity.Code, moduleEntity.FullName };
            if (this.Exists(names, values))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(moduleEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Update(PiModuleEntity moduleEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>返回</returns>
        public int Update(PiModuleEntity moduleEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DBProvider, PiModuleTable.TableName, moduleEntity.Id, moduleEntity.ModifiedUserId, moduleEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
            string[] names = { PiModuleTable.FieldDeleteMark, PiModuleTable.FieldCode, PiModuleTable.FieldFullName };
            object[] values = { 0, moduleEntity.Code, moduleEntity.FullName };

            // 检查编号是否重复
            if ((moduleEntity.Code.Length > 0) && (this.Exists(names, values, moduleEntity.Id)))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.UpdateEntity(moduleEntity);
                statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            }
            //}
            return returnValue;
        }
        #endregion

        #region public override int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            PiModuleEntity moduleEntity = new PiModuleEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[PiModuleTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        if (dataRow[PiModuleTable.FieldAllowDelete, DataRowVersion.Original].ToString().Equals("1"))
                        {
                            returnValue += this.DeleteEntity(id);
                        }
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[PiModuleTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        moduleEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        if (moduleEntity.AllowEdit == 1)
                        {
                            returnValue += this.UpdateEntity(moduleEntity);
                        }
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    moduleEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(moduleEntity).Length > 0 ? 1 : 0;
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

        #region public int ResetSortCode(string parentId) 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        /// <param name="parentId">父节点主键</param>
        public int ResetSortCode(string parentId)
        {
            int returnValue = 0;
            DataTable dataTable = this.GetDTByParent(parentId);
            string id = string.Empty;
            CiSequenceManager sequenceManager = new CiSequenceManager(DBProvider);
            string[] sortCode = sequenceManager.GetBatchSequence(PiModuleTable.TableName, dataTable.Rows.Count);
            int i = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                id = dataRow[PiModuleTable.FieldId].ToString();
                returnValue += this.SetProperty(id, PiModuleTable.FieldSortCode, sortCode[i]);
                i++;
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 通过条件得到模块
        /// </summary>
        /// <param name="condition">条件表达式</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByCondition(string condition)
        {
            string sqlQuery = "SELECT * FROM " + PiModuleTable.TableName;
            if (!string.IsNullOrEmpty(condition))
            {
                sqlQuery += " WHERE " + condition;
            }
            return this.Fill(sqlQuery);
        }
    }
}
