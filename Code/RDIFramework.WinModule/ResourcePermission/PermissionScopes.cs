using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDIFramework.WinModule
{
    /// <summary>
    /// PermissionScopes
    /// 权限范围
    /// 
    /// </summary>
    [Serializable]
    public class PermissionScopes
    {
        public string[] GrantUserIds = null;
        public string[] GrantRoleIds = null;
        public string[] GrantOrganizeIds = null;
        public string[] GrantModuleIds = null;
        public string[] GrantPermissionIds = null;
    }
}
