/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-17 16:29:49
 ******************************************************************************/

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;
    /// <summary>
    /// RoleScopeManager
    /// 角色权限域
    /// 
    /// </summary>
    public partial class  RoleScopeManager : DbCommonManager, IDbCommonManager
    {
        public RoleScopeManager()
        {
            base.CurrentTableName = PiPermissionScopeTable.TableName;
        }

        public RoleScopeManager(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        public RoleScopeManager(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        public RoleScopeManager(IDbProvider dbProvider, UserInfo userInfo)
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

        public int ClearRolePermissionScope(string roleId, string permissionItemCode)
        {
            string[] names = new string[3];
            string[] values = new string[3];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            names[2] = PiPermissionScopeTable.FieldPermissionId;
            values[2] = this.GetIdByCode(permissionItemCode);

            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return permissionScopeManager.Delete(names, values);
        }

        public int RevokeAll(string roleId)
        {
            string[] names = new string[2];
            string[] values = new string[2];
            names[0] = PiPermissionScopeTable.FieldResourceCategory;
            values[0] = PiRoleTable.TableName;
            names[1] = PiPermissionScopeTable.FieldResourceId;
            values[1] = roleId;
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo);
            return permissionScopeManager.Delete(names, values);
        }
    }
}
