
namespace RDIFramework.Utilities
{
	public partial class RDIFrameworkMessage
	{
        // 重新重新登录时，登入窗口名称改变为重新登录”
        public static string MSGReLogOn = "重新登录";

        //PiUserManager登录服务讯息参数
        public static string UserManager = "登录服务";
        public static string UserManager_LogOn = "登录操作";
        public static string UserManager_LogOnSuccess = "登录成功";

        #region LogOnService登入系统服务及相关的方法名称定义
        // LogOnService登入系统服务及相关的方法名称定义
        public static string LogOnService = "登入系统服务";
        public static string LogOnService_GetEntity = "登入服务获取实体";
        public static string LogOnService_Update = "登入服务更新实体";
        public static string LogOnService_LogOnByOpenId = "按唯一识别码登录";
        public static string LogOnService_LogOnByUserName = "按用户名登录";
        public static string LogOnService_UserLogOn = "用户登录";
        public static string LogOnService_GetUserDT = "取得用户列表";
        public static string LogOnService_GetStaffUserDT = "取得内部员工列表";
        public static string LogOnService_AccountActivation = "激活用户";
        public static string LogOnService_OnLine = "用户在线";
        public static string LogOnService_OnExit = "用户退出应用程序";
        public static string LogOnService_ServerCheckOnLine = "检查在线状态(服务器专用)";
        public static string LogOnService_SetPassword = "设定用户密码";
        public static string LogOnService_ChangePassword = "用户变更密码";
        public static string LogOnService_LockUser = "锁定指定用户";
        public static string LogOnService_UnLockUser = "解锁指定用户";
        public static string LogOnService_UserDimission = "用户离职";
        #endregion

        #region UserService用户管理服务及相关的方法名称定义
        // UserService用户管理服务及相关的方法名称定义
        public static string UserService = "用户管理服务";
        public static string UserService_Exists = "用户名是否重复";
        public static string UserService_AddUser = "新增用户";
        public static string UserService_GetEntity = "取得用户实体";
        public static string UserService_GetDT = "取得用户列表";
        public static string UserService_GetDTByPage = "取得分页用户列表";
        public static string UserService_GetDTByIds = "依主键取得用户列表";
        public static string UserService_Search = "查询用户";
        public static string UserService_SetUserAuditStates = "设置用户审核状态";
        public static string UserService_Delete = "单个删除";
        public static string UserService_BatchDelete = "批量删除";
        public static string UserService_SetDeleted = "批量批删除标志";
        public static string UserService_UpdateUser = "更新用户";
        public static string UserService_BatchSave = "批量保存";
        public static string UserService_GetDTByRole = "依角色取得用户列表";
        public static string UserService_SetDefaultRole = "设置用户的默认角色";
        public static string UserService_BatchSetDefaultRole = "批量设置默认角色";
        public static string UserService_GetRoleDT = "取得用户的角色列表";
        public static string UserService_UserInRole = "判断用户是否在某个角色中";
        public static string UserService_GetUserRoleIds = "获取员工角色列表";
        public static string UserService_AddUserToRole = "用户添加到角色";
        public static string UserService_RemoveUserFromRole = "用户从角色中移除";
        public static string UserService_ClearUserRole = "清除用户归属的角色";
        public static string UserService_GetDTByDepartment = "依部门取得用户列表";
        public static string UserService_GetUserPageDTByDepartment = "根据部门查询用户分页列表";
        public static string UserService_GetUserOrganizeDT = "获得用户的组织机构兼职情况";
        public static string UserService_AddUserToOrganize = "用户帐户添加到组织机构";
        public static string UserService_Check = "请审核。";
        public static string UserService_Application = " 申请用户：";
        public static string UserService_UserIsInOrganize = "用户是否在某个组织架构里的判断";
        public static string UserService_BatchDeleteUserOrganize = "批量删除用户组织机构关联";
        public static string UserService_GetCompanyUser = "得到当前用户所在公司的用户列表";
        public static string UserService_GetDepartmentUser = "得到当前用户所在部门的用户列表";
        #endregion

        #region OrganizeService组织机构服务及相关的方法名称定义
        // OrganizeService组织机构服务及相关的方法名称定义
        public static string OrganizeService = "组织机构服务";
        public static string OrganizeService_Add = "新增组织机构";
        public static string OrganizeService_Update = "更新组织机构";
        public static string OrganizeService_GetDT = "取得组织机构列表";
        public static string OrganizeService_GetDTByParent = "依父节点取得组织机构列表";
        public static string OrganizeService_GetEntity = "取得组织机构实体";
        public static string OrganizeService_GetDTByIds = "取得指定主键组织机构列表";
        public static string OrganizeService_GetDTByValues = "按条件获取数据列表";
        public static string OrganizeService_BatchSave = "批量储存组织机构";
        public static string OrganizeService_Delete = "删除组织机构";
        public static string OrganizeService_BatchDelete = "批量删除组织机构";
        public static string OrganizeService_SetDeleted = "组织机构批量标示删除标志";
        public static string OrganizeService_MoveTo = "移动组织机构";
        public static string OrganizeService_BatchMoveTo = "批量移动组织机构";
        public static string OrganizeService_GetChildrensById = "根据组织机构主键获取其指定分类下的子节点列表";
        #endregion

        #region RoleService角色管理服务及相关的方法名称定义
        // RoleService角色管理服务及相关的方法名称定义
        public static string RoleService = "角色管理服务";
        public static string RoleService_Add = "新增角色";
        public static string RoleService_GetDT = "取得角色列表";
        public static string RoleService_GetDTByPage = "获取角色分页列表";
        public static string RoleService_GetDTByOrganize = "依组织机构取得角色列表";
        public static string RoleService_GetApplicationRole = "获取业务角色列表";
        public static string RoleService_GetEntity = "取得角色实体";
        public static string RoleService_Update = "更新角色";
        public static string RoleService_GetDTByIds = "依主键数组取得角色列表";
        public static string RoleService_GetDTByValues = "依据条件来取得角色列表";
        public static string RoleService_BatchSave = "批量储存角色";
        public static string RoleService_Delete = "删除角色";
        public static string RoleService_BatchDelete = "批量删除角色";
        public static string RoleService_SetDeleted = "批量标示角色删除标志";
        public static string RoleService_EliminateRoleUser = "清除角色用户关联";
        public static string RoleService_GetRoleUserIds = "取得角色中的用户主键";
        public static string RoleService_AddUserToRole = "用户新增至角色";
        public static string RoleService_RemoveUserFromRole = "将用户从角色中移除";
        public static string RoleService_ClearRoleUser = "清除角色用户关联";
        public static string RoleService_SetUsersToRole = "设置角色中的用户";
        public static string RoleService_ResetSortCode = "排序角色顺序";
        public static string RoleService_MoveTo = "移动角色数据";
        #endregion

        #region ModuleService模块(菜单)服务及相关的方法名称定义
        // ModuleService模块(菜单)服务及相关的方法名称定义
        public static string ModuleService = "模块(菜单)服务";
        public static string ModuleService_GetDT = "取得模块(菜单)列表";
        public static string ModuleService_GetDTByIds = "获取列表";
        public static string ModuleService_GetEntity = "取得模块(菜单)实体";
        public static string ModuleService_GetFullNameByCode = "通过编号取得模块(菜单)名称";
        public static string ModuleService_Add = "新增模块(菜单)";
        public static string ModuleService_Update = "更新模块(菜单)";
        public static string ModuleService_GetDTByParent = "依父节点取得模块(菜单)列表";
        public static string ModuleService_Delete = "删除模块(菜单)";
        public static string ModuleService_BatchDelete = "批量删除模块(菜单)";
        public static string ModuleService_SetDeleted = "批量标示模块(菜单)删除标志";
        public static string ModuleService_MoveTo = "移动模块(菜单)";
        public static string ModuleService_BatchMoveTo = "批量移动模块(菜单)";
        public static string ModuleService_BatchSave = "批量储存模块(菜单)";
        public static string ModuleService_SetSortCode = "储存模块(菜单)排序顺序";
        public static string ModuleService_GetPermissionDT = "取得模块(菜单)关联的权限项列表";
        public static string ModuleService_GetIdsByPermission = "依操作权限项取得关联的模块(菜单)主键";
        public static string ModuleService_BatchAddPermissions = "模块(菜单)批量新增关联操作权限项";
        public static string ModuleService_BatchAddModules = "新增操作权限项关联模块(菜单)";
        public static string ModuleService_BatchDletePermissions = "删除模块(菜单)与操作权限项的关联";
        public static string ModuleService_BatchDleteModules = "删除操作权限项与模块(菜单)的关联";
        #endregion

        #region PermissionItemService操作权限项定义服务及相关的方法名称定义
        // PermissionItemService操作权限项定义服务及相关的方法名称定义
        public static string PermissionItemService = "操作权限项定义服务";
        public static string PermissionItemService_GetDT = "取得操作权限项列表";
        public static string PermissionItemService_GetDTByParent = "依父节点取得操作权限项列表";
        public static string PermissionItemService_Add = "新增操作权限项";
        public static string PermissionItemService_AddByDetail = "按明细添加一个操作权限";
        public static string PermissionItemService_GetEntity = "取得操作权限项实体";
        public static string PermissionItemService_GetEntityByCode = "依编号取得操作权限项实体";
        public static string PermissionItemService_GetDTByIds = "依主键数组取得操作权限项列表";
        public static string PermissionItemService_Update = "更新操作权限项";
        public static string PermissionItemService_MoveTo = "移动操作权限项";
        public static string PermissionItemService_BatchMoveTo = "批量移动操作权限项";
        public static string PermissionItemService_Delete = "删除操作权限项";
        public static string PermissionItemService_BatchDelete = "批量删除操作权限项";
        public static string PermissionItemService_SetDeleted = "批量标示操作权限项删除标志";
        public static string PermissionItemService_BatchSave = "批量储存操作权限项";
        public static string PermissionItemService_BatchSetSortCode = "重新产生操作权限项排序码";
        public static string PermissionItemService_GetIdsByModule = "按模块主键获取操作权限项主键数组";
        #endregion

        #region PermissionService权限判断服务及相关的方法名称定义
        // PermissionService权限判断服务及相关的方法名称定义
        public static string PermissionService = "权限判断服务";
        public static string PermissionService_Add = "添加实体";
        public static string PermissionService_GetDT = "获取列表";
        public static string PermissionService_GetEntity = "获取实体";
        public static string PermissionService_Update = "更新实体";
        public static string PermissionService_GetDTByIds = "按主键数组获取数据列表";
        public static string PermissionService_GetDTByValues = "按条件获取数据列表";
        public static string PermissionService_BatchSave = "批量保存数据";
        public static string PermissionService_Delete = "删除数据";
        public static string PermissionService_BatchDelete = "批量删除数据";
        public static string PermissionService_SetDeleted = "批量打删除标志";		
        public static string PermissionService_IsInRole = "指定用户是否在指定的角色里";
        public static string PermissionService_IsAuthorized = "当前用户是否有相应的操作权限";
        public static string PermissionService_IsAuthorizedByUserId = "指定用户是否有相应的权限";
        public static string PermissionService_IsAuthorizedByRoleId = "指定角色是否有相应的权限";
        public static string PermissionService_IsAdministrator = "当前用户是否为超级管理员";
        public static string PermissionService_IsAdministratorByUserId = "指定用户是否超级管理员";
        public static string PermissionService_GetPermissionDT = "获得当前用户的所有权限列表";
        public static string PermissionService_GetPermissionDTByUserId = "获得指定用户的所有权限列表";
        public static string PermissionService_IsModuleAuthorized = "当前用户是否对某个模块有相应的权限";
        public static string PermissionService_IsModuleAuthorizedByUserId = "指定用户是否对某个模块有相应的权限";
        public static string PermissionService_GetPermissionScopeByUserId = "获得指定用户的数据权限范围";				
        public static string PermissionService_GetScopeModuleIdsByOrganizeId = "获取指定组织机构在某个权限域下所有模块主键数组";
        public static string PermissionService_GrantOrganizeModuleScope = "授予组织机构某个权限域的模块授权范围";
        public static string PermissionService_RevokeOrganizeModuleScope = "撤消指定组织机构某个权限域的模块授权范围";
        public static string PermissionService_GetOrganizePermissionItemIds = "获取指定组织机构操作权限主键数组";
        public static string PermissionService_GetOrganizeIdsByPermissionItemId = "获取组织机构主键数组通过指定操作权限";
        public static string PermissionService_GrantOrganizePermissionById = "授予指定组织机构指定的操作权限";
        public static string PermissionService_GrantOrganizePermissions = "授予组织机构权限";
        public static string PermissionService_RevokeOrganizePermissions = "撤消组织机构权限";
        public static string PermissionService_RevokeOrganizePermissionById = "撤消指定组织机构指定的操作权限";
        public static string PermissionService_ClearOrganizePermission = "清除组织机构权限";		
        public static string PermissionService_GetResourcePermissionItemIds = "获取资源权限主键数组";
        public static string PermissionService_GrantResourcePermission = "授予资源的权限";
        public static string PermissionService_RevokeResourcePermission = "撤消资源的权限";
        public static string PermissionService_GetPermissionScopeTargetIds = "获取资源权限范围主键数组";
        public static string PermissionService_GetPermissionScopeResourceIds = "获取数据权限目标主键";
        public static string PermissionService_GrantPermissionScopeTargets = "授予资源的权限范围";
        public static string PermissionService_GrantPermissionScopeTarget = "授予数据权限";
        public static string PermissionService_RevokePermissionScopeTargets = "撤消资源的权限范围";
        public static string PermissionService_RevokePermissionScopeTarget = "撤销数据权限";
        public static string PermissionService_ClearPermissionScopeTarget = "清除数据权限";
        public static string PermissionService_GetResourceScopeIds = "获取用户的某个资源的权限范围";
        public static string PermissionService_GetTreeResourceScopeIds = "获取用户的某个资源的权限范围";
        public static string PermissionService_GetRolePermissionItemIds = "获取指定角色操作权限主键数组";
        public static string PermissionService_GetRoleIdsByPermissionItemId = "获取角色主键数组通过指定操作权限";
        public static string PermissionService_GrantRolePermissions = "批量授予角色的操作权限";
        public static string PermissionService_GrantRolePermission = "授予指定角色指定的操作权限";
        public static string PermissionService_GrantRolePermissionById = "授予指定角色特定的操作权限";
        public static string PermissionService_RevokeRolePermissions = "批量撤消指定角色的操作权限";
        public static string PermissionService_RevokeRolePermission = "撤消指定角色的操作权限";
        public static string PermissionService_RevokeRolePermissionById = "撤消指定角色的指定操作权限";
        public static string PermissionService_GetScopeUserIdsByRoleId = "获取指定角色在某个权限域下所拥有的用户主键数组";
        public static string PermissionService_GetScopeRoleIdsByRoleId = "获取指定角色在某个权限域下所拥有的角色主键数组";
        public static string PermissionService_GetScopeOrganizeIdsByRoleId = "获取指定角色在某个权限域下所拥有的组织机构主键数组";
        public static string PermissionService_GrantRoleUserScope = "授予角色某个权限域的用户范围";
        public static string PermissionService_RevokeRoleUserScope = "撤消角色的某个权限域的用户范围";
        public static string PermissionService_GrantRoleRoleScope = "授予角色的某个权限域的角色范围";
        public static string PermissionService_RevokeRoleRoleScope = "撤消角色的某个权限域的组织范围";
        public static string PermissionService_GrantRoleOrganizeScope = "授予角色的某个权限域的组织机构范围";
        public static string PermissionService_RevokeRoleOrganizeScope = "撤消角色的某个权限域的组织机构范围";
        public static string PermissionService_GetScopePermissionItemIdsByRoleId = "获取指定角色在某个权限域下所有操作（功能）权限主键数组";
        public static string PermissionService_GrantRolePermissionItemScope = "授予角色某个权限域的操作权限授权范围";
        public static string PermissionService_RevokeRolePermissionItemScope = "撤消指定角色某个权限域的操作权限授权范围";
        public static string PermissionService_ClearRolePermissionByRoleId = "清除指定角色的所有权限";
        public static string PermissionService_ClearRolePermissionScope = "清除指定角色所有权限范围";
        public static string PermissionService_GetScopeModuleIdsByRoleId = "获取指定角色在某个权限域下所有模块主键数组";
        public static string PermissionService_GrantRoleModuleScope = "授予角色某个权限域的模块授权范围";
        public static string PermissionService_RevokeRoleModuleScope = "撤消指定角色某个权限域的模块授权范围";		
        public static string PermissionService_GetUserDTByPermissionScope = "按某个权限范围获取特定用户可访问的用户列表";
        public static string PermissionService_GetUserIdsByPermissionScope = "按某个权限范围获取特定用户可访问的用户主键数组";
        public static string PermissionService_GetRoleDTByPermissionScope = "按某个权限范围获取特定用户可访问的取角色列表";
        public static string PermissionService_GetRoleIdsByPermissionScope = "按某个权限范围获取特定用户可访问的角色主键数组";
        public static string PermissionService_GetModuleDTByPermissionScope = "按某个权限范围获取特定用户可访问的模块列表";
        public static string PermissionService_GetPermissionItemDTByPermissionScope = "按某个权限范围获取特定用户可访问的操作权限列表";
        public static string PermissionService_GetOrganizeDTByPermissionScope = "按某个权限范围获取特定用户可访问的组织机构列表";
        public static string PermissionService_GetOrganizeIdsByPermissionScope = "按某个权限范围获取特定用户可访问的组织机构主键数组";		
        public static string PermissionService_GetUserPermissionItemIds = "获取指定用户操作权限主键数组";
        public static string PermissionService_GetUserIdsByPermissionItemId = "获取用户主键数组通过指定操作权限";
        public static string PermissionService_GrantUserPermissions = "批量授予用户操作权限";
        public static string PermissionService_GrantUserPermissionById = "授予指定用户指定的操作权限";
        public static string PermissionService_RevokeUserPermissions = "批量撤消用户的操作权限";
        public static string PermissionService_RevokeUserPermissionById = "撤消指定用户指定的操作权限";
        public static string PermissionService_GetScopeOrganizeIdsByUserId = "获取指定用户在某个权限域下所拥有的组织机构主键数组";
        public static string PermissionService_GrantUserOrganizeScope = "授予用户某个权限域的组织机构授权范围";
        public static string PermissionService_RevokeUserOrganizeScope = "撤消用户某个权限域的组织组织授权范围";
        public static string PermissionService_GetScopeUserIdsByUserId = "获取指定用户在某个权限域下所有用户主键数组";
        public static string PermissionService_GrantUserUserScope = "授予用户某个权限域的用户授权范围";
        public static string PermissionService_RevokeUserUserScope = "撤消用户某个权限域的用户授权范围";
        public static string PermissionService_GetScopeRoleIdsByUserId = "获取指定用户在某个权限域下所有角色主键数组";
        public static string PermissionService_GrantUserRoleScope = "授予用户某个权限域的角色授权范围";
        public static string PermissionService_RevokeUserRoleScope = "撤消用户某个权限域的角色授权范围";
        public static string PermissionService_GetScopePermissionItemIdsByUserId = "获取指定用户在某个权限域下所有操作（功能）权限主键数组";
        public static string PermissionService_GrantUserPermissionItemScope = "授予用户某个权限域的操作权限授权范围";
        public static string PermissionService_RevokeUserPermissionItemScope = "撤消指定用户某个权限域的操作权限授权范围";
        public static string PermissionService_ClearUserPermissionByUserId = "清除指定用户的所有权限";
        public static string PermissionService_ClearUserPermissionScope = "清除指定用户所有权限范围";
        public static string PermissionService_GetModuleDT = "获得当前用户有访问权限的模块";
        public static string PermissionService_GetModuleIdsByUserId = "获取指定用户有权限访问的模块";
        public static string PermissionService_GetModuleDTByUserId = "获得指定用户有权限访问的模块";
        public static string PermissionService_GetScopeModuleIdsByUserId = "获取指定用户在某个权限域下所有模块主键数组";  
        public static string PermissionService_GrantUserModuleScope = "授予用户某个权限域的模块授权范围";
        public static string PermissionService_RevokeUserModuleScope = "撤消指定用户某个权限域的模块授权范围";

        #endregion

        #region SequenceService序列管理服务及相关的方法名称定义
        // SequenceService序列管理服务及相关的方法名称定义
        public static string SequenceService = "序列管理服务";
        public static string SequenceService_GetEntity = "取得序列实体";
        public static string SequenceService_Add = "新增序列";
        public static string SequenceService_Update = "更新序列";
        public static string SequenceService_GetDT = "取得序列列表";
        public static string SequenceService_GetSequence = "获取序列号";
        public static string SequenceService_GetOldSequence = "获取原序列号";
        public static string SequenceService_GetNewSequence = "获取新序列号";
        public static string SequenceService_GetBatchSequence = "获取序列号";
        public static string SequenceService_GetReduction = "获取倒序序列号";
        public static string SequenceService_Reset = "批量重置序列";
        public static string SequenceService_Delete = "删除序列";
        public static string SequenceService_BatchDelete = "批量删除序列";
        #endregion

        #region StaffService 职员管理服务及相关的方法名称定义
        // StaffService职员管理服务及相关的方法名称定义
        public static string StaffService = "职员管理服务";
        public static string StaffService_AddStaff = "新增职员";
        public static string StaffService_UpdateStaff = "更新职员";
        public static string StaffService_GetDT = "取得职员列表";
        public static string StaffService_GetDTByPage = "获取员工分页列表";
        public static string StaffService_GetEntity = "取得职员实体";
        public static string StaffService_GetDTByIds = "取得职员列表";
        public static string StaffService_GetDTByOrganize = "依组织机构取得职员列表";
        public static string StaffService_GetDTNotOrganize = "获得未设置组织机构的员工列表";
        public static string StaffService_SetStaffUser = "职员关联用户";
        public static string StaffService_DeleteUser = "删除员工关联的用户";
        public static string StaffService_Delete = "删除员工";
        public static string StaffService_BatchDelete = "批量删除员工";
        public static string StaffService_SetDeleted = "批量打删除标志";
        public static string StaffService_MoveTo = "移动员工数据到指定组织机构";
        public static string StaffService_BatchMoveTo = "批量移动数据";
        public static string StaffService_GetId = "获取主键";
        #endregion

        #region TableColumnsService表字段权限服务及相关的方法名称定义
        // TableColumnsService表字段权限服务及相关的方法名称定义
        public static string TableColumnsService = "表字段权限服务";
        public static string TableColumnsService_Add = "新增表字段";
        public static string TableColumnsService_GetDTByTable = "根据表名取得字段列表";
        public static string TableColumnsService_GetTablePermissionScope = "得到所有可做表字段控制权限的数据";
        public static string TableColumnsService_GetTableNameAndCode = "得到所有数据表（表的中文名称与英文名称）";
        public static string TableColumnsService_GetAllTableScope = "得到所有数据表（用于表字段权限的控制，主要针对PiTablePermissionScope数据表的数据）";
        public static string TableColumnsService_GetConstraintDT = "取得约束条件(所有的约束)";
        public static string TableColumnsService_GetUserConstraint = "取得当前用户的约束条件";
        public static string TableColumnsService_SetConstraint = "设置约束条件";
        public static string TableColumnsService_GetConstraint = "获取约束条件";
        public static string TableColumnsService_GetConstraintEntity = "获取约束条件";
        public static string TableColumnsService_BatchDeleteConstraint = "批量删除表字段";
        public static string TableColumnsService_GetDT = "获取所有表字段列表";
        public static string TableColumnsService_GetEntity = "获取实体";
        public static string TableColumnsService_Delete = "删除表字段";
        public static string TableColumnsService_SetDeleted = "批量标示表字段删除标志";
        public static string TableColumnsService_Update = "更新实体";
        public static string TableColumnsService_BatchDelete = "批量删除表字段";
        public static string TableColumnsService_GetDTByIds = "按主键数组获取数据列表";
        public static string TableColumnsService_GetDTByValues = "按条件获取数据列表";
        public static string TableColumnsService_GetColumns = "获取用户的列权限";
        public static string TableColumnsService_BatchSave = "批量储存表字段";
        public static string TableColumnsService_GetTablePermissionScopeEntity = "取得表权限控制数据表实体";
        public static string TableColumnsService_GetSearchFields = "根据表名称得到查询项";
        public static string TableColumnsService_AddTablePermissionScope = "新增可做表权限控制的数据表";
        public static string TableColumnsService_DeleteTablePermissionScope = "删除表权限控制表中指定数据";
        public static string TableColumnsService_SetTablePermissionScopeDeleted = "批量设置表权限控制数据表的刪除标志";
        #endregion

        #region DbLinkDefineService数据库连接定义服务
        //DbLinkDefineService数据库连接定义服务
        public static string DbLinkDefineService = "数据库连接管理服务";
        public static string DbLinkDefineService_Add = "新增数据库连接";
        public static string DbLinkDefineService_GetDT = "取得数据库连接列表";
        public static string DbLinkDefineService_GetEntity = "取得数据库连接";
        public static string DbLinkDefineService_Update = "更新数据库连接定义";
        public static string DbLinkDefineService_GetDTByIds = "依主键取得数据库连接定义列表";
        public static string DbLinkDefineService_GetDTByValues = "按条件获取数据库连接定义列表";
        public static string DbLinkDefineService_Delete = "单个删除数据库连接定义";
        public static string DbLinkDefineService_BatchDelete = "批量删除数据库连接定义";
        public static string DbLinkDefineService_SetDeleted = "逻辑删除数据库连接定义【打删除标志】";
        #endregion

        #region PlatFormAddInService平台插件服务
        //PlatFormAddInService平台插件服务
        public static string PlatFormAddInService = "平台插件服务";
        public static string PlatFormAddInService_Add = "新增平台插件";
        public static string PlatFormAddInService_GetDT = "取得平台插件列表";
        public static string PlatFormAddInService_GetEntity = "取得平台插件实体";
        public static string PlatFormAddInService_Update = "更新平台插件";
        public static string PlatFormAddInService_GetDTByIds = "依主键取得平台插件列表";
        public static string PlatFormAddInService_GetDTByValues = "按条件获取平台插件数据列表";
        public static string PlatFormAddInService_Delete = "单个删除平台插件";
        public static string PlatFormAddInService_BatchDelete = "批量删除平台插件";
        #endregion

        #region ItemsService、ItemDetailsService选项、数据字典管理服务及相关的方法名称定义
        // ItemsService数据字典服务及相关的方法名称定义
        public static string ItemsService = "数据字典服务";
        public static string ItemsService_Add = "新增数据字典管";
        public static string ItemsService_GetDT = "取得数据字典管列表";
        public static string ItemsService_GetDTByParent = "依父节点取得数据字典管列表";
        public static string ItemsService_GetEntity = "取得数据字典管实体";
        public static string ItemsService_Update = "更新数据字典管";
        public static string ItemsService_Delete = "删除数据字典管";
        public static string ItemsService_SetDeleted = "批量删除标志";
        public static string ItemsService_CreateTable = "新增数据表";

        // ItemDetailsService选项明细管理服务及相关的方法名称定义
        public static string ItemDetailsService = "数据字典管明细服务";
        public static string ItemDetailsService_Add = "新增实体";
        public static string ItemDetailsService_GetDT = "取得列表";
        public static string ItemDetailsService_GetEntity = "取得实体";
        public static string ItemDetailsService_Update = "更新实体";
        public static string ItemDetailsService_GetDTByIds = "按主键数组获取数据列表";
        public static string ItemDetailsService_GetDTByValues = "按条件获取数据列表";
        public static string ItemDetailsService_BatchSave = "批量储存";
        public static string ItemDetailsService_Delete = "删除实体";
        public static string ItemDetailsService_BatchDelete = "批量删除";
        public static string ItemDetailsService_SetDeleted = "批量打删除标志";
        public static string ItemDetailsService_GetDTByCode = "依编号取得列表";
        #endregion

        #region ParameterService参数服务及相关的方法名称定义
        // ParameterService参数服务及相关的方法名称定义
        public static string ParameterService = "参数服务";
        public static string ParameterService_GetServiceConfig = "获取服务器上的配置信息";
        public static string ParameterService_GetParameter = "取得参数值";
        public static string ParameterService_SetParameter = "设置参数值";
        public static string ParameterService_GetDTByParameter = "取得参数服务列表";
        public static string ParameterService_GetDTByParameterCode = "依编号取得参数服务列表";
        public static string ParameterService_DeleteByParameter = "删除参数";
        public static string ParameterService_DeleteByParameterCode = "依参数编号删除";
        public static string ParameterService_Delete = "删除参数";
        public static string ParameterService_BatchDelete = "批量删除参数";
        #endregion

        #region  FileService文件服务、FolderService文件夹服务及相关的方法名称定义
        // FileService文件服务及相关的方法名称定义
        public static string FileService = "文件服务";
        public static string FileService_Exists = "判断文件是否存在";
        public static string FileService_Download = "下载文件";
        public static string FileService_Upload = "上传文件";
        public static string FileService_GetEntity = "取得文件实体";
        public static string FileService_GetDTByFolder = "依文件夹取得档文件列表";
        public static string FileService_DeleteByFolder = "依文件夹删除文件";
        public static string FileService_Add = "添加";
        public static string FileService_Update = "更新";
        public static string FileService_UpdateFile = "更新";
        public static string FileService_Rename = "重命名";
        public static string FileService_Search = "查询";
        public static string FileService_MoveTo = "移动数据";
        public static string FileService_BatchMoveTo = "批量移动数据";
        public static string FileService_Delete = "删除";
        public static string FileService_BatchDelete = "批量删除";
        public static string FileService_BatchSave = "批量保存";

        // FolderService文件夹服务及相关的方法名称定义
        public static string FolderService = "文件夹服务";
        public static string FolderService_GetEntity = "获取一条";
        public static string FolderService_GetDT = "获取数据表";
        public static string FolderService_GetDTByParent = "按目录获取列表";
        public static string FolderService_Add = "添加";
        public static string FolderService_AddByFolderName = "添加";
        public static string FolderService_Update = "更新文件夹";
        public static string FolderService_Rename = "重命名";
        public static string FolderService_Search = "查询";
        public static string FolderService_Delete = "删除";
        public static string FolderService_BatchDelete = "批量删除";
        public static string FolderService_MoveTo = "移动";
        public static string FolderService_BatchMoveTo = "批量移动";
        public static string FolderService_BatchSave = "批量保存";
        #endregion

        #region LogService日志服务、ExceptionService异常记录服务及相关的方法名称定义
        // LogService日志服务及相关的方法名称定义
        public static string LogService = "日志服务";
	    public static string LogService_WriteLog = "写入日志";
        public static string LogService_GetLogGeneral = "取得用户访问情况日志";
        public static string LogService_ResetVisitInfo = "重置用户访问情况";
        public static string LogService_GetDTByDate = "根据日期取得日志";
        public static string LogService_GetDTByModule = "根据模块取得日志";
        public static string LogService_GetDTByUser = "根据用户取得日志";
        public static string LogService_GetDTByPage = "获取系统操作日志分页列表";
        public static string LogService_Delete = "删除日志";
        public static string LogService_BatchDelete = "批量删除日志";
        public static string LogService_Truncate = "清除全部日志";
        public static string LogService_GetDTApplicationByDate = "根据日期取得应用日志";
        public static string LogService_BatchDeleteApplication = "批量删除应用日志";
        public static string LogService_TruncateApplication = "清除全部应用日志";

        // ExceptionService异常记录服务及相关的方法名称定义
        public static string ExceptionService = "异常记录服务";
        public static string ExceptionService_Add = "添加异常";
        public static string ExceptionService_GetDT = "取得异常列表";
        public static string ExceptionService_GetDTByPage = "取得分页异常列表";
        public static string ExceptionService_Delete = "删除异常";
        public static string ExceptionService_BatchDelete = "批量删除异常";
        public static string ExceptionService_Truncate = "清除全部异常";
        #endregion

        #region MessageService讯息服务及相关的方法名称定义
        // MessageService讯息服务及相关的方法名称定义
        public static string MessageService = "消息服务";
        public static string MessageService_GetInnerOrganize = "取得内部组织机构";
        public static string MessageService_GetUserDTByOrganize = "按组织机构获取用户列表";
        public static string MessageService_GetUserDTByRole = "按角色获取用户列表";
        public static string MessageService_BatchSend = "批量发送站内消息";
        public static string MessageService_Send = "发送消息";
        public static string MessageService_MessageChek = "取得消息状态";
        public static string MessageService_SendGroupMessage = "发送组消息";
        public static string MessageService_Remind = "发送系统提示消息";
        public static string MessageService_ReadFromReceiver = "取得特定用户的新消息";
        public static string MessageService_Read = "阅读消息";
        public static string MessageService_Broadcast = "广播消息";
        public static string MessageService_GetDTNew = "获取用户的新信息";
	    public static string MessageService_CheckOnLine = "检查在线状态";
        public static string MessageService_GetOnLineState = "获取在线用户列表";
        public static string MessageService_GetMySentMessagesByPage = "得到指定用户已发送的消息";
        public static string MessageService_GetUserReceivedMessagesByPage = "得到指定用户收到的消息";
        public static string MessageService_GetMessagesByConditional = "通过指定条件得到消息";
        public static string MessageService_SetDeleted = "逻辑删除通过指定消息";
	    #endregion

        #region QueryEnginService 查询引擎服务及相关的方法名称定义
        // RoleService角色管理服务及相关的方法名称定义
        public static string QueryEnginService = "查询引擎服务";
        public static string QueryEnginService_Add = "新增查询引擎";
        public static string QueryEnginService_GetDT = "取得查询引擎列表";
        public static string QueryEnginService_GetDTByPage = "获取查询引擎分页列表";
        public static string QueryEnginService_GetEntity = "取得查询引擎实体";
        public static string QueryEnginService_Update = "更新查询引擎";
        public static string QueryEnginService_GetDTByIds = "依主键数组取得查询引擎列表";
        public static string QueryEnginService_GetDTByValues = "依据条件来取得查询引擎列表";
        public static string QueryEnginService_GetDTByParent = "依父节点取得查询引擎列表";
        public static string QueryEnginService_BatchSave = "批量储存查询引擎";
        public static string QueryEnginService_Delete = "删除查询引擎";
        public static string QueryEnginService_BatchDelete = "批量删除查询引擎";
        public static string QueryEnginService_SetDeleted = "批量标示查询引擎删除标志";
        public static string QueryEnginService_MoveTo = "移动查询引擎数据";
        #endregion
	}
}
