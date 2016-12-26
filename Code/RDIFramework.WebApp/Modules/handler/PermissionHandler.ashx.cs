using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using RDIFramework.Utilities;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;

    /// <summary>
    /// PermissionHandler 的摘要说明
    /// </summary>
    public class PermissionHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        private const string PermissionItemCodeManger = "Resource.ManagePermission";

        private const string PermissionItemCodeAccess = "Resource.AccessPermission";

        // 访问列
        private string ColumnAccessPermissionId = "";
        private string ColumnAccessPermissionCode = "Column.Access";

        // 编辑列
        private string ColumnEditPermissionId = "";
        private string ColumnEditPermissionCode = "Column.Edit";

        // 拒绝访问列
        private string ColumnDeneyPermissionId = "";
        private string ColumnDeneyPermissionCode = "Column.Deney";

        private string Action
        {
            get
            {
                return PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action"));
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (Action)
            {
                case "GetModuleByUserId": //得到指定用户可以访问的模块
                    GetModuleByUserId(context);
                    break;
                case "GetModuleByRoleId": //得到指定角色可以访问的模块
                    GetModuleByRoleId(context);
                    break;
                case "GetPermissionItemsByUserId": //得到指定用户可以访问的操作权限项
                    GetPermissionItemsByUserId(context);
                    break;
                case "GetPermissionItemsByRoleId": //得到指定角色可以访问的操作权限项
                    GetPermissionItemsByRoleId(context);
                    break;
                case "GetPermissionScopeTargetIds": //得到指定用户可以访问的资源权限主键列表
                    GetPermissionScopeTargetIds(context);
                    break;
                case "GetUserRoleIds": //得到指定用户所拥有的角色主键列表
                    GetUserRoleIds(context);
                    break;
                case "GetRoleUserIds":  //获得角色中的用户主键
                    GetRoleUserIds(context);
                    break;
                case "SetUserModulePermission":  //设置用户模块权限（授予或回收）
                    SetUserModulePermission(context);
                    break;
                case "SetRoleModulePermission":  //设置角色模块权限（授予或回收）
                    SetRoleModulePermission(context);
                    break;
                case "SetUserPermissionItem":  //设置用户操作权限项权限（授予或回收）
                    SetUserPermissionItem(context);
                    break;
                case "SetRolePermissionItem":  // 设置角色操作权限项权限（授予或回收）
                    SetRolePermissionItem(context);
                    break;
                case "GrantRevokePermissionScopeTargets": //授予或回收资源的权限范围
                    GrantRevokePermissionScopeTargets(context);
                    break;
                case "RemoveUserFromRole":  //批量移除角色
                    RemoveUserFromRole(context);
                    break;
                case "AddUserToRole": //批量增加用户到角色
                    AddUserToRole(context);
                    break;
                case "RemoveRoleUser"://批量移除当前角色指定的用户
                    RemoveRoleUser(context); 
                    break;
                case "AddRoleUser": //批量添加指定的用户到当前角色
                    AddRoleUser(context);
                    break;
                case "GetConstraintDT":  //获取约束条件
                    GetConstraintDT(context);
                    break;
                case "SetConstraint": //设置约束条件
                    SetConstraint(context);
                    break;
                case "DeleteConstraint": //删除约束条件
                    DeleteConstraint(context);
                    break;
                case "GetAllTableScope":
                    GetAllTableScope(context);
                    break;
                case "GetDTByTable": //按表名获取表的列详细列表
                    GetDTByTable(context);
                    break;
                case "GrantOrRevokeFieldPermission"://回收或授予表字段操作权限
                    GrantOrRevokeFieldPermission(context);
                    break;
                case "GrantOrRevokeTablePermission": //回收或授予表访问权限
                    GrantOrRevokeTablePermission(context);
                    break;

            }
        }

        /// <summary>
        /// 得到指定用户可以访问的模块
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetModuleByUserId(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var moduleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByUserId(Utils.UserInfo, userId, "Resource.AccessPermission");
            ctx.Response.Write(this.GetSpitString(moduleIds));
        }

        /// <summary>
        /// 得到指定角色可以访问的模块
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetModuleByRoleId(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var moduleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByRoleId(Utils.UserInfo, roleId, "Resource.AccessPermission");
            ctx.Response.Write(this.GetSpitString(moduleIds));
        }

        /// <summary>
        /// 得到指定用户可以访问的操作权限项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetPermissionItemsByUserId(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var ids = RDIFrameworkService.Instance.PermissionService.GetUserPermissionItemIds(Utils.UserInfo, userId);
            ctx.Response.Write(this.GetSpitString(ids));
        }

        /// <summary>
        /// 得到指定角色可以访问的操作权限项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetPermissionItemsByRoleId(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var ids = RDIFrameworkService.Instance.PermissionService.GetRolePermissionItemIds(Utils.UserInfo, roleId);
            ctx.Response.Write(this.GetSpitString(ids));
        }

        /// <summary>
        /// 获取资源权限范围主键数组
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetPermissionScopeTargetIds(HttpContext ctx)
        {
            var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory")); //资源分类
            var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId")); //资源主键
            var targetCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetCategory")); //目标类别
            var ids = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(Utils.UserInfo, resourceCategory, resourceId, targetCategory, PermissionItemCodeManger);
            ctx.Response.Write(this.GetSpitString(ids));
        }

        /// <summary>
        /// 得到指定用户所拥有的角色主键列表
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetUserRoleIds(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var ids = RDIFrameworkService.Instance.UserService.GetUserRoleIds(Utils.UserInfo,userId);
            ctx.Response.Write(this.GetSpitString(ids));
        }

        /// <summary>
        /// 获得角色中的用户主键
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetRoleUserIds(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var userIds = RDIFrameworkService.Instance.RoleService.GetRoleUserIds(Utils.UserInfo, roleId);
            ctx.Response.Write(this.GetSpitString(userIds));
        }

        #region private void GrantRevokePermissionScopeTargets(HttpContext ctx) 授予或回收资源的权限范围
        /// <summary>
        /// 授予或回收资源的权限范围
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GrantRevokePermissionScopeTargets(HttpContext ctx)
        {
            var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory")); //资源分类
            var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId")); //资源主键
            var targetCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetCategory")); //目标类别
            var grantTargetIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("grantTargetIds")); //授予目标主键数组
            var revokeTargetIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("revokeTargetIds")); //回收的目标主键数组
            var permissionItemId = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(Utils.UserInfo, PermissionItemCodeManger).Id.ToString();
            if (string.IsNullOrEmpty(resourceId))
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "请选择相应的资源！" }.ToString());
                return;
            }
            var successFlag = 0;

            if (!string.IsNullOrEmpty(grantTargetIds.Trim()) && !string.IsNullOrEmpty(grantTargetIds) && grantTargetIds != ",")
            {
                var arrayGrantIds =RDIFramework.Utilities.StringHelper.RemoveFinalComma(grantTargetIds).TrimEnd(new char[] {','}).Split(',');
                successFlag += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(Utils.UserInfo, resourceCategory, resourceId, targetCategory, arrayGrantIds, permissionItemId);
            }

            if (!string.IsNullOrEmpty(revokeTargetIds.Trim()))
            {
                var arrayRevokeIds = RDIFramework.Utilities.StringHelper.RemoveFinalComma(revokeTargetIds).TrimEnd(new char[] { ',' }).Split(',');
                successFlag += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(Utils.UserInfo, resourceCategory, resourceId, targetCategory, arrayRevokeIds, permissionItemId);
            }

            if (successFlag > 0)
            {
                successFlag = 1;
                ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = "操作成功！" }.ToString());
            }
            else
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = "操作失败！" }.ToString());
            }
        }
        #endregion

        #region private void SetUserModulePermission(HttpContext ctx) 设置用户模块权限（授予或回收）
        /// <summary>
        /// 设置用户模块权限（授予或回收）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void SetUserModulePermission(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var grantModuleIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("grantIds"));
            var revokeModuleids = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("revokeIds"));
            var vUser = Utils.UserInfo;

            if (string.IsNullOrEmpty(userId))
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "请选择相应的用户！"}.ToString());
                return;
            }
            var successFlag = 0;
            if (!string.IsNullOrEmpty(grantModuleIds) && grantModuleIds != ",")
            {
                var grantIds = grantModuleIds.TrimEnd(new char[] { ',' }).Split(',');
                if (grantIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.GrantUserModuleScope(vUser, userId, PermissionItemCodeAccess, grantIds);
                }
                else 
                {
                    successFlag = 1;
                }
            }

            if (!string.IsNullOrEmpty(revokeModuleids) && revokeModuleids != ",")
            {
                var revokeIds = revokeModuleids.TrimEnd(new char[] { ',' }).Split(',');
                if (revokeIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.RevokeUserModuleScope(vUser, userId, PermissionItemCodeAccess, revokeIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (successFlag > 0)
            {
                successFlag = 1;
                ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = "操作成功！" }.ToString());
            }
            else
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = "操作失败！" }.ToString());
            }
        }
        #endregion

        #region private void SetRoleModulePermission(HttpContext ctx) 设置角色模块权限（授予或回收）
        /// <summary>
        /// 设置角色模块权限（授予或回收）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void SetRoleModulePermission(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var grantModuleIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("grantIds"));
            var revokeModuleids = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("revokeIds"));
            var vUser = Utils.UserInfo;

            if (string.IsNullOrEmpty(roleId))
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "请选择相应的角色！" }.ToString());
                return;
            }
            var successFlag = 0;
            if (!string.IsNullOrEmpty(grantModuleIds) && grantModuleIds != ",")
            {
                var grantIds = grantModuleIds.TrimEnd(new char[] { ',' }).Split(',');
                if (grantIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.GrantRoleModuleScope(vUser, roleId, PermissionItemCodeAccess, grantIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (!string.IsNullOrEmpty(revokeModuleids) && revokeModuleids != ",")
            {
                var revokeIds = revokeModuleids.TrimEnd(new char[] { ',' }).Split(',');
                if (revokeIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.RevokeRoleModuleScope(vUser, roleId, PermissionItemCodeAccess, revokeIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (successFlag > 0)
            {
                successFlag = 1;
                ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = "操作成功！" }.ToString());
            }
            else
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = "操作失败！" }.ToString());
            }
        }
        #endregion

        #region private void SetUserPermissionItem(HttpContext ctx) 设置用户操作权限项权限（授予或回收）
        /// <summary>
        /// 设置用户操作权限项权限（授予或回收）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void SetUserPermissionItem(HttpContext ctx)
        {
            var userid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var grantIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("grantIds"));
            var revokeIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("revokeIds"));
            var vUser = Utils.UserInfo;

            if (string.IsNullOrEmpty(userid))
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "请选择相应的用户！" }.ToString());
                return;
            }
            var successFlag = 0;

            if (!string.IsNullOrEmpty(grantIds) && grantIds != ",")
            {
                var arrayGrantIds = grantIds.TrimEnd(new char[] { ',' }).Split(',');
                if (arrayGrantIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.GrantUserPermissions(vUser, new string[] { userid },arrayGrantIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (!string.IsNullOrEmpty(revokeIds) && revokeIds != ",")
            {
                var arrayRevokeIds = revokeIds.TrimEnd(new char[] { ',' }).Split(',');
                if (arrayRevokeIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.RevokeUserPermissions(vUser, new string[] { userid }, arrayRevokeIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (successFlag > 0)
            {
                successFlag = 1;
                ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = "操作成功！" }.ToString());
            }
            else
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = "操作失败！" }.ToString());
            }
        }
        #endregion

        #region private void SetRolePermissionItem(HttpContext ctx) 设置角色操作权限项权限（授予或回收）
        /// <summary>
        /// 设置角色操作权限项权限（授予或回收）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void SetRolePermissionItem(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var grantIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("grantIds"));
            var revokeIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("revokeIds"));
            var vUser = Utils.UserInfo;

            if (string.IsNullOrEmpty(roleId))
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "请选择相应的角色！" }.ToString());
                return;
            }
            var successFlag = 0;
            if (!string.IsNullOrEmpty(grantIds) && grantIds != ",")
            {
                var arrayGrantIds = grantIds.TrimEnd(new char[] { ',' }).Split(',');
                if (arrayGrantIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.GrantRolePermissions(vUser, new string[]{ roleId }, arrayGrantIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (!string.IsNullOrEmpty(revokeIds) && revokeIds != ",")
            {
                var arrayRevokeIds = revokeIds.TrimEnd(new char[] { ',' }).Split(',');
                if (arrayRevokeIds.Length > 0)
                {
                    successFlag += RDIFrameworkService.Instance.PermissionService.RevokeRolePermissions(vUser, new string[] { roleId }, arrayRevokeIds);
                }
                else
                {
                    successFlag = 1;
                }
            }

            if (successFlag > 0)
            {
                successFlag = 1;
                ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = "操作成功！" }.ToString());
            }
            else
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = "操作失败！" }.ToString());
            }
        }
        #endregion

        #region 增加或移除用户到角色（UserService）
        /// <summary>
        /// 批量移除角色
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void RemoveUserFromRole(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var targetIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetIds"));
            var returnValue =  RDIFrameworkService.Instance.UserService.RemoveUserFromRole(Utils.UserInfo, userId,targetIds.TrimEnd(new char[] { ',' }).Split(','));
            ctx.Response.Write(returnValue > 0
                ? new JsonMessage {Success = true, Data = "1", Message = "操作成功！"}.ToString()
                : new JsonMessage {Success = false, Data = "0", Message = "操作失败！"}.ToString());
        }

        /// <summary>
        /// 批量增加用户到角色
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddUserToRole(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userid"));
            var targetIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetIds"));
            var returnValue = RDIFrameworkService.Instance.UserService.AddUserToRole(Utils.UserInfo, userId, targetIds.TrimEnd(new char[] { ',' }).Split(','));
            ctx.Response.Write(returnValue > 0
                ? new JsonMessage {Success = true, Data = "1", Message = "操作成功！"}.ToString()
                : new JsonMessage {Success = false, Data = "0", Message = "操作失败！"}.ToString());
        }
        #endregion

        #region 批量添加或移除指定角色的用户（RoleService）
        /// <summary>
        /// 批量添加指定的用户到当前角色
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddRoleUser(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var targetIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetIds"));
            var returnValue = RDIFrameworkService.Instance.RoleService.AddUserToRole(Utils.UserInfo, roleId, targetIds.TrimEnd(new char[] { ',' }).Split(','));
            ctx.Response.Write(returnValue > 0
                ? new JsonMessage {Success = true, Data = "1", Message = "操作成功！"}.ToString()
                : new JsonMessage {Success = false, Data = "0", Message = "操作失败！"}.ToString());
        }

        /// <summary>
        /// 批量移除当前角色指定的用户
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void RemoveRoleUser(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var targetIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetIds"));
            var returnValue = RDIFrameworkService.Instance.RoleService.RemoveUserFromRole(Utils.UserInfo, roleId, targetIds.TrimEnd(new char[] { ',' }).Split(','));
            ctx.Response.Write(returnValue > 0
                ? new JsonMessage {Success = true, Data = "1", Message = "操作成功！"}.ToString()
                : new JsonMessage {Success = false, Data = "0", Message = "操作失败！"}.ToString());
        }
        #endregion

        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="ctx"></param>
        private void GetConstraintDT(HttpContext ctx)
        {
            var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory"));
            var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId"));
            var dtScope = RDIFrameworkService.Instance.TableColumnsService.GetConstraintDT(Utils.UserInfo, resourceCategory, resourceId);
            var json = JSONhelper.ToJson(dtScope);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 设置约束条件
        /// </summary>
        /// <param name="ctx"></param>
        private void SetConstraint(HttpContext ctx)
        {
            var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory"));
            var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId"));
            var tableName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableName"));
            var tableConstraint = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableConstraint"));
            var returnValue  = RDIFrameworkService.Instance.TableColumnsService.SetConstraint(Utils.UserInfo, resourceCategory, resourceId,tableName,PermissionItemCodeAccess,tableConstraint,true);
            try
            {
                ctx.Response.Write(!string.IsNullOrEmpty(returnValue)
                     ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG3010 }.ToString()
                     : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 删除约束条件
        /// </summary>
        /// <param name="ctx"></param>
        private void DeleteConstraint(HttpContext ctx)
        {
            var keyId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
            var returnValue = RDIFrameworkService.Instance.TableColumnsService.BatchDeleteConstraint(Utils.UserInfo, new string[]{keyId});
            try
            {
                ctx.Response.Write(returnValue > 0
                     ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG3010 }.ToString()
                     : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        private void GetAllTableScope(HttpContext ctx)
        {
            UserInfo curUser = Utils.UserInfo;
            var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory"));
            var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId"));
            var dtTableScope = RDIFrameworkService.Instance.TableColumnsService.GetAllTableScope(curUser);
            if (dtTableScope != null)
            {
                dtTableScope.Columns.Add("PermissionValue", typeof(int));
                var selectIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(curUser, resourceCategory, resourceId, "Table", "Resource.AccessPermission");
                foreach (DataRow dr in dtTableScope.Rows)
                {
                    dr["PermissionValue"] = 0;
                }

                if (selectIds != null && selectIds.Length > 0)
                {
                    foreach (DataRow dr in dtTableScope.Rows)
                    {
                        if (selectIds.Any(t => dr["ITEMCODE"].ToString() == t))
                        {
                            dr["PermissionValue"] = 1;
                        }
                    }
                }

                dtTableScope.AcceptChanges();
            }
            
            var json = JSONhelper.ToJson(dtTableScope);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 按表名获取表的详细列表
        /// </summary>
        /// <param name="ctx"></param>
        private void GetDTByTable(HttpContext ctx)
        {
            UserInfo curUser = Utils.UserInfo;
            var tableName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableName"));
            var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory"));
            var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId"));
            var dtColumns = RDIFrameworkService.Instance.TableColumnsService.GetDTByTable(curUser, tableName);
            var columns = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(curUser, resourceCategory, resourceId, tableName, ColumnAccessPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BusinessLogic.SetProperty(dtColumns, CiTableColumnsTable.FieldColumnCode, columns[i], "COLUMNACCESS", 1);
                }
            }

            columns = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(curUser, resourceCategory, resourceId, tableName, ColumnEditPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BusinessLogic.SetProperty(dtColumns, CiTableColumnsTable.FieldColumnCode, columns[i], "COLUMNEDIT", 1);
                }
            }
            columns = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(curUser, resourceCategory, resourceId, tableName, ColumnDeneyPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BusinessLogic.SetProperty(dtColumns, CiTableColumnsTable.FieldColumnCode, columns[i], "ColumnDeney", 1);
                }
            }
            dtColumns.AcceptChanges();
            var json = JSONhelper.ToJson(dtColumns);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 回收或授予表字段操作权限
        /// </summary>
        /// <param name="ctx"></param>
        private void GrantOrRevokeFieldPermission(HttpContext ctx)
        {
            var returnValue = 0;
            try
            {
                UserInfo curUser = Utils.UserInfo;
                var tableName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableName"));
                var fieldName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("fieldName"));
                var operType = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operType"));
                var operValue = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operValue"));
                var operId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operId"));
                var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory"));
                var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId"));
                string columnPermissionId = string.Empty;
                if (!string.IsNullOrEmpty(operType))
                {
                    switch (operType.ToUpper().Trim())
                    {
                        case "ISPUBLIC":
                        {
                            string commandText = " UPDATE " + CiTableColumnsTable.TableName + "    SET " + CiTableColumnsTable.FieldIsPublic + " = ";
                            commandText += operValue == "1" ? "0" : "1";
                            commandText += "  WHERE " + CiTableColumnsTable.FieldId + " = '" + operId + "'";
                            returnValue = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.ExecuteNonQuery(curUser,commandText);
                        }
                            break;
                        case "COLUMNACCESS":
                        {
                            columnPermissionId = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(curUser,this.ColumnAccessPermissionCode).Id;
                        }
                            break;
                        case "COLUMNEDIT":
                        {
                            columnPermissionId = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(curUser,this.ColumnEditPermissionCode).Id;
                        }
                            break;
                        case "COLUMNDENEY":
                        {
                            columnPermissionId = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(curUser,this.ColumnDeneyPermissionCode).Id;
                        }
                            break;
                    }

                    if (!string.IsNullOrEmpty(columnPermissionId))
                    {
                        if (operValue == "1")
                        {
                            string revokeResourceId = fieldName;
                            returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTarget(curUser,resourceCategory, new string[] {resourceId}, tableName, revokeResourceId,columnPermissionId);
                        }
                        else
                        {
                            string grantResourceId = fieldName;
                            returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTarget(curUser,resourceCategory, new string[] {resourceId}, tableName, grantResourceId,columnPermissionId);
                        }
                    }
                }

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage {Success = true, Data = "1", Message = RDIFrameworkMessage.MSG3010}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }


        /// <summary>
        /// 回收或授予表访问权限
        /// </summary>
        /// <param name="ctx"></param>
        private void GrantOrRevokeTablePermission(HttpContext ctx)
        {
            var returnValue = 0;
            try
            {
                UserInfo curUser = Utils.UserInfo;
                var resourceCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceCategory"));
                var resourceId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("resourceId"));
                var tableName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("tableName"));
                var operValue = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("operValue"));
                if (!string.IsNullOrEmpty(operValue))
                {
                    string permissionItemId = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(curUser, "Resource.AccessPermission").Id;
                    if (operValue == "1")
                    {
                        string[] revokeResourceIds = new string[] { tableName };

                        returnValue = RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(curUser, resourceCategory, resourceId, "Table", revokeResourceIds, permissionItemId);
                        //回收列的相关权限
                        //RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(curUser, resourceCategory, resourceId, tableName, this.GetALlFieldIds(), this.ColumnAccessPermissionId);
                        //RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(curUser, resourceCategory, resourceId, tableName, this.GetALlFieldIds(), this.ColumnEditPermissionId);
                        //RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(curUser, resourceCategory, resourceId, tableName, this.GetALlFieldIds(), this.ColumnDeneyPermissionId);
                    }
                    else
                    {
                        string[] grantResourceIds = new string[] { tableName };
                        returnValue = RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(curUser, resourceCategory, resourceId, "Table", grantResourceIds, permissionItemId);
                    }
                }

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG3010 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        private string GetSpitString(string[] sArrary)
        {
            var returnValue = "";
            if (sArrary == null || sArrary.Length <= 0) return returnValue;
            //foreach (string value in sArrary)
            //{
            //    returnValue += value + ",";
            //}
            //改为以下的方式
            returnValue = sArrary.Aggregate(returnValue, (current, value) => current + (value + ","));
            returnValue = returnValue.Remove(returnValue.Length - 1, 1);

            return returnValue;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}