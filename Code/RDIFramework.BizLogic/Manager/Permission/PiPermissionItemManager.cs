/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-17 14:29:02
 ******************************************************************************/
using System;
using System.Data;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
  

    /// <summary>
    /// PiPermissionItemManager
    /// 操作权限项定义
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
    public partial class PiPermissionItemManager
    {
        private static readonly object PermissionItemLock = new object();
        /// <summary>
        /// 获取一个操作权限的主键
        /// 若不存在就自动增加一个
        /// </summary>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="permissionItemName">操作权限名称</param>
        /// <returns>主键</returns>
        public string GetIdByAdd(string permissionItemCode, string permissionItemName = null)
        {
            // 判断当前判断的权限是否存在，否则很容易出现前台设置了权限，后台没此项权限
            // 需要自动的能把前台判断过的权限，都记录到后台来

            string[] names = { PiPermissionItemTable.FieldDeleteMark, PiPermissionItemTable.FieldEnabled, PiPermissionItemTable.FieldCode };
            object[] values = { 0, 1, permissionItemCode };

            var permissionItemEntity = new PiPermissionItemEntity();
            permissionItemEntity = BaseEntity.Create<PiPermissionItemEntity>(this.GetDT(names, values, PiPermissionItemTable.FieldId));
            string permissionItemId = string.Empty;
            if (permissionItemEntity.Id != null)
            {
                permissionItemId = permissionItemEntity.Id;
            }

            // 不存在的权限就自动加入。
            if (String.IsNullOrEmpty(permissionItemId))
            {
                // 这里需要进行一次加锁，方式并发冲突发生
                lock (PermissionItemLock)
                {
                    permissionItemEntity.Code = permissionItemCode;
                    permissionItemEntity.FullName = string.IsNullOrEmpty(permissionItemName) ? permissionItemCode : permissionItemName;
                    permissionItemEntity.CategoryCode = "Application";
                    permissionItemEntity.ParentId = null;
                    permissionItemEntity.ModuleId = null;
                    permissionItemEntity.IsScope = 0;
                    permissionItemEntity.IsPublic = 0;
                    permissionItemEntity.AllowDelete = 1;
                    permissionItemEntity.AllowEdit = 1;
                    permissionItemEntity.Enabled = 1;
                    permissionItemEntity.DeleteMark = 0;
                    // 这里是防止主键重复？
                    permissionItemEntity.Id = BusinessLogic.NewGuid();
                    permissionItemId = this.AddEntity(permissionItemEntity);
                }
            }
            else
            {
                // 更新最后一次访问日期，设置为当前服务器日期
                var sqlBuilder = new SQLBuilder(DBProvider);
                sqlBuilder.BeginUpdate(PiPermissionItemTable.TableName);
                sqlBuilder.SetDBNow(PiPermissionItemTable.FieldLastCall);
                sqlBuilder.SetWhere(PiPermissionItemTable.FieldId, permissionItemId);
                sqlBuilder.EndUpdate();
            }

            return permissionItemId;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string AddByDetail(string code, string fullName, out string statusCode)
        {
            PiPermissionItemEntity permissionItemEntity = new PiPermissionItemEntity {Code = code, FullName = fullName};
            return this.Add(permissionItemEntity, out statusCode);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(PiPermissionItemEntity permissionItemEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查编号是否重复
            if (this.Exists(PiPermissionItemTable.FieldDeleteMark, 0, PiPermissionItemTable.FieldCode, permissionItemEntity.Code))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(permissionItemEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 获取一个
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns>数据表</returns>
        public DataTable GetDTByCode(string code)
        {
            return this.GetDT(PiPermissionItemTable.FieldCode, code);
        }

        /// <summary>
        /// 获取一个
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="permissionItemEntity">实体</param>
        /// <returns>数据表</returns>
        public DataTable GetByCode(string code, PiPermissionItemEntity permissionItemEntity)
        {
            DataTable dataTable = this.GetDT(PiPermissionItemTable.FieldCode, code);
            permissionItemEntity.GetFrom(dataTable);
            return dataTable;
        }

        /// <summary>
        /// 更新一个
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(PiPermissionItemEntity permissionItemEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DBProvider, PiPermissionTable.TableName, permissionEntity.Id, permissionEntity.ModifiedUserId, permissionEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
            // 检查编号是否重复
            if (this.Exists(PiPermissionItemTable.FieldDeleteMark, 0, PiPermissionItemTable.FieldCode, permissionItemEntity.Code, permissionItemEntity.Id))
            {
                // 文件夹名已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                // 进行更新操作
                returnValue = this.UpdateEntity(permissionItemEntity);
                statusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
            }
            //}
            return returnValue;
        }

        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            // 删除关联数据
            int returnValue = 0;
            returnValue = this.DeleteEntity(id);          
            return returnValue;
        }


        /// <summary>
        /// 获得用户授权范围
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemCode"></param>
        /// <returns>数据表</returns>
        public DataTable GetDTByUser(string userId, string permissionItemCode)
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
                names = new string[] { PiPermissionItemTable.FieldCategoryCode, PiPermissionItemTable.FieldDeleteMark, PiPermissionItemTable.FieldEnabled };
                values = new object[] { "System", 0, 1 };
                returnValue = this.GetDT(names, values, PiPermissionItemTable.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            // 这里需要判断,是业务权限？
            isRole = userRoleManager.UserInRole(userId, "Admin");
            if (isRole)
            {
                names = new string[] { PiPermissionItemTable.FieldCategoryCode, PiPermissionItemTable.FieldDeleteMark, PiPermissionItemTable.FieldEnabled };
                values = new object[] { "Application", 0, 1 };
                returnValue = this.GetDT(names, values, PiPermissionItemTable.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            string[] permissionItemIds = permissionScopeManager.GetTreeResourceScopeIds(userId, PiPermissionItemTable.TableName, permissionItemCode, true);
            // 有效的，未被删除的
            names = new string[] { PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldDeleteMark, PiPermissionItemTable.FieldEnabled };
            values = new object[] { permissionItemIds, 0, 1 };
            returnValue = this.GetDT(names, values, PiPermissionItemTable.FieldSortCode);
            returnValue.TableName = this.CurrentTableName;
            return returnValue;
        }


        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            PiPermissionItemEntity permissionItemEntity = new PiPermissionItemEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[PiPermissionItemTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        if (dataRow[PiPermissionItemTable.FieldAllowDelete, DataRowVersion.Original].ToString().Equals("1"))
                        {
                            returnValue += this.DeleteEntity(id);
                        }
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[PiPermissionItemTable.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        permissionItemEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        returnValue += permissionItemEntity.AllowEdit == 1
                            ? this.UpdateEntity(permissionItemEntity)
                            : this.SetProperty(PiPermissionItemTable.FieldId, id, PiPermissionItemTable.FieldSortCode, permissionItemEntity.SortCode); // 不允许编辑，但是排序还是允许的
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    permissionItemEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(permissionItemEntity).Length > 0 ? 1 : 0;
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

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, PiOrganizeTable.FieldParentId, parentId);
        }
    }
}
