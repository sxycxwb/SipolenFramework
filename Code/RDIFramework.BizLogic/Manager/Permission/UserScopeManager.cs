/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 16:40:33
 ******************************************************************************/

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
    /// <summary>
    /// UserScopeManager
    /// 用户权限域
    /// 
    /// </summary>
    public partial class UserScopeManager: DbCommonManager, IDbCommonManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserScopeManager()
        {
            base.CurrentTableName = PiPermissionScopeTable.TableName;
        }

        /// <summary>
         /// 构造函数
        /// </summary>
         /// <param name="dbProvider">数据库服务提供者</param>
        public UserScopeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户</param>
        public UserScopeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbProvider">数据库服务提供者</param>
        /// <param name="userInfo">用户</param>
        public UserScopeManager(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        public override string GetIdByCode(string permissionItemCode)
        {
            PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(DBProvider);
            // 这里应该是若不存在就自动加一个操作权限
            return permissionItemManager.GetIdByAdd(permissionItemCode);
        }

        /// <summary>
        /// 清除用户权限范围
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <returns>受影响的行数</returns>
        public int ClearUserPermissionScope(string userId, string permissionItemCode)
        {
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            names[2] = PiPermissionScopeTable.FieldPermissionId;
            values[2] = this.GetIdByCode(permissionItemCode);

            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return permissionScopeManager.Delete(names, values);
        }

        public int RevokeAll(string userId)
        {
            string[] names = new string[2];
            string[] values = new string[2];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiUserTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = userId;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return permissionScopeManager.Delete(names, values);
        }
    }
}
