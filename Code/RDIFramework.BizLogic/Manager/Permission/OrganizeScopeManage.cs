using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// OrganizeScopeManage
    /// 组织机构权限域
    /// 
    /// 
    /// </summary>
    public partial class OrganizeScopeManage : DbCommonManager, IDbCommonManager
    { 
        public OrganizeScopeManage()
        {
            base.CurrentTableName = PiPermissionScopeTable.TableName;
        }

        public OrganizeScopeManage(IDbProvider dbProvider)
            : this()
        {
            DBProvider = dbProvider;
        }

        public OrganizeScopeManage(UserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        public OrganizeScopeManage(IDbProvider dbProvider, UserInfo userInfo)
            : this(dbProvider)
        {
            UserInfo = userInfo;
        }

        public OrganizeScopeManage(IDbProvider dbProvider, UserInfo userInfo, string tableName)
            : this(dbProvider, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        public new string GetIdByCode(string permissionItemCode)
        {
            string tableName = PiPermissionItemTable.TableName;        
            PiModuleManager moduleManager = new PiModuleManager(dbProvider, UserInfo, tableName);
            return moduleManager.GetIdByCode(permissionItemCode);
            //PiPermissionItemManager permissionItemManager = new PiPermissionItemManager(DBProvider);
            //// 这里应该是若不存在就自动加一个操作权限
            //return permissionItemManager.GetIdByAdd(permissionItemCode);
        }

        public int ClearOrganizePermissionScope(string organizeId, string permissionItemCode)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceCategory, PiOrganizeTable.TableName),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceId, organizeId),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldPermissionId,this.GetIdByCode(permissionItemCode))
            };

            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            return permissionScopeManager.Delete(parameters);
        }

        public int RevokeAll(string organizeId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceCategory, PiOrganizeTable.TableName),
                new KeyValuePair<string, object>(PiPermissionScopeTable.FieldResourceId, organizeId)
            };
            PiPermissionScopeManager permissionScopeManager = new PiPermissionScopeManager(DBProvider, UserInfo, this.CurrentTableName);
            return permissionScopeManager.Delete(parameters);
        }
    }
}
