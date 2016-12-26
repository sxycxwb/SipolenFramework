using System;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;

    /// <summary>
    /// ResourcePermission
    /// </summary>
    public class ResourcePermission : IHttpHandler, IRequiresSessionState
    {
        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        private const string PermissionItemScopeCode = "Resource.ManagePermission";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                #region 用户授权范围相关
                case "GetScopeUserIdsByUserId":
                    GetScopeUserIdsByUserId(context);
                    break;
                case "GetScopeRoleIdsByUserId":
                    GetScopeRoleIdsByUserId(context);
                    break;
                case "GetScopeOrganizeIdsByUserId":
                    GetScopeOrganizeIdsByUserId(context);
                    break;
                case "GetScopeModuleIdsByUserId":
                    GetScopeModuleIdsByUserId(context);
                    break;
                case "GetScopePermissionItemIdsByUserId":
                    GetScopePermissionItemIdsByUserId(context);
                    break;
                case "SaveUserUserScope": 
                    SaveUserUserScope(context);
                    break;
                case "SaveUserRoleScope":
                    SaveUserRoleScope(context);
                    break;
                case "SaveOrganizeScope":
                    SaveOrganizeScope(context);
                    break;
                case "SaveModuleScope":
                    SaveModuleScope(context);
                    break;
                case "SavePermissionItemScope":
                    SavePermissionItemScope(context);
                    break;
                #endregion

                #region 角色授权范围相关
                case "GetScopeUserIdsByRoleId":
                    GetScopeUserIdsByRoleId(context);
                    break;
                case "GetScopeRoleIdsByRoleId":
                    GetScopeRoleIdsByRoleId(context);
                    break;
                case "GetScopeOrganizeIdsByRoleId":
                    GetScopeOrganizeIdsByRoleId(context);
                    break;
                case "GetScopeModuleIdsByRoleId":
                    GetScopeModuleIdsByRoleId(context);
                    break;
                case "GetScopePermissionItemIdsByRoleId":
                    GetScopePermissionItemIdsByRoleId(context);
                    break;
                case "SaveRoleUserScope":
                    SaveRoleUserScope(context);
                    break;
                case "SaveRoleRoleScope":
                    SaveRoleRoleScope(context);
                    break;
                case "SaveRoleOrganizeScope":
                    SaveRoleOrganizeScope(context);
                    break;
                case "SaveRoleModuleScope":
                    SaveRoleModuleScope(context);
                    break;
                case "SaveRolePermissionItemScope":
                    SaveRolePermissionItemScope(context);
                    break;

                #endregion
            }
        }

        #region 用户授权范围相关

        #region private void GetScopeUserIdsByUserId(HttpContext ctx) 
        /// <summary>
        /// 获取指定用户在某个权限域下所有用户主键数组
        /// 指定用户对那些用户有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeUserIdsByUserId(HttpContext ctx)
        {
            var userid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var userIds = RDIFrameworkService.Instance.PermissionService.GetScopeUserIdsByUserId(Utils.UserInfo,userid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(userIds));
        }
        #endregion

        #region private void GetScopeRoleIdsByUserId(HttpContext ctx)
        /// <summary>
        /// 获取指定用户在某个权限域下所有角色主键数组
        /// 指定用户对那些角色有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeRoleIdsByUserId(HttpContext ctx)
        {
            var userid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var roleIds = RDIFrameworkService.Instance.PermissionService.GetScopeRoleIdsByUserId(Utils.UserInfo, userid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(roleIds));
        }
        #endregion

        #region private void GetScopeOrganizeIdsByUserId(HttpContext ctx)
        /// <summary>
        /// 获取指定用户在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// 指定用户对那些组织机构有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeOrganizeIdsByUserId(HttpContext ctx)
        {
            var userid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var orgIds = RDIFrameworkService.Instance.PermissionService.GetScopeOrganizeIdsByUserId(Utils.UserInfo, userid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(orgIds));
        }
        #endregion

        #region private void GetScopeModuleIdsByUserId(HttpContext ctx)
        /// <summary>
        /// 获取指定用户在某个权限域下所有模块主键数组
        /// 指定用户对那些模块有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeModuleIdsByUserId(HttpContext ctx)
        {
            var userid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var moduleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByUserId(Utils.UserInfo, userid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(moduleIds));
        }
        #endregion

        #region private void GetScopePermissionItemIdsByUserId(HttpContext ctx)
        /// <summary>
        /// 获取指定用户在某个权限域下所有操作（功能）权限主键数组
        /// 指定用户对那些操作（功能）权限有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopePermissionItemIdsByUserId(HttpContext ctx)
        {
            var userid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var permissionItemIds = RDIFrameworkService.Instance.PermissionService.GetScopePermissionItemIdsByUserId(Utils.UserInfo, userid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(permissionItemIds));
        }
        #endregion

        #region private void SaveUserUserScope(HttpContext ctx)
        /// <summary>
        /// 批量保存用户某个权限域内的用户授权范围
        /// </summary>
        private void SaveUserUserScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetUid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetUserId"));
            var uIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userIds"));
            if (string.IsNullOrEmpty(targetUid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "用户主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpUserids = RDIFrameworkService.Instance.PermissionService.GetScopeUserIdsByUserId(Utils.UserInfo,targetUid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(uIds))
                {
                    if (tmpUserids != null && tmpUserids.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserUserScope(vUser, targetUid,PermissionItemScopeCode, tmpUserids);
                    }
                }
                else
                {
                    var revokeIds = tmpUserids.Except(uIds.Split(',')).ToArray();
                    var grantIds = uIds.Split(',').Except(tmpUserids).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantUserUserScope(vUser, targetUid,PermissionItemScopeCode, grantIds);
                    }

                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserUserScope(vUser, targetUid,PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());
               
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SaveUserRoleScope(HttpContext ctx)
        /// <summary>
        /// 批量保存用户某个权限域内的角色授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveUserRoleScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetUid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetUserId"));
            var rIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleIds"));
            if (string.IsNullOrEmpty(targetUid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "用户主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpRoleIds = RDIFrameworkService.Instance.PermissionService.GetScopeRoleIdsByUserId(Utils.UserInfo, targetUid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(rIds))
                {
                    if (tmpRoleIds != null && tmpRoleIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserRoleScope(vUser, targetUid, PermissionItemScopeCode, tmpRoleIds);
                    }
                }
                else
                {
                    var revokeIds = tmpRoleIds.Except(rIds.Split(',')).ToArray();
                    var grantIds = rIds.Split(',').Except(tmpRoleIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantUserRoleScope(vUser, targetUid,PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserRoleScope(vUser, targetUid,PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SaveOrganizeScope(HttpContext ctx)
        /// <summary>
        /// 批量保存用户某个权限域内的组织机构授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveOrganizeScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetUid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetUserId"));
            var orgIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeIds"));
            if (string.IsNullOrEmpty(targetUid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "用户主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpOrgIds = RDIFrameworkService.Instance.PermissionService.GetScopeOrganizeIdsByUserId(Utils.UserInfo, targetUid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(orgIds))
                {
                    if (tmpOrgIds != null && tmpOrgIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserOrganizeScope(vUser, targetUid, PermissionItemScopeCode, tmpOrgIds);
                    }
                }
                else
                {
                    var revokeIds = tmpOrgIds.Except(orgIds.Split(',')).ToArray();
                    var grantIds = orgIds.Split(',').Except(tmpOrgIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantUserOrganizeScope(vUser, targetUid,PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserOrganizeScope(vUser, targetUid,PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SaveModuleScope(HttpContext ctx)
        /// <summary>
        /// 批量保存用户某个权限域内的模块（菜单）授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveModuleScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetUid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetUserId"));
            var mIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("moduleIds"));
            if (string.IsNullOrEmpty(targetUid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "用户主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpModuleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByUserId(Utils.UserInfo, targetUid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(mIds))
                {
                    if (tmpModuleIds != null && tmpModuleIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserModuleScope(vUser, targetUid, PermissionItemScopeCode, tmpModuleIds);
                    }
                }
                else
                {
                    var revokeIds = tmpModuleIds.Except(mIds.Split(',')).ToArray();
                    var grantIds = mIds.Split(',').Except(tmpModuleIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantUserModuleScope(vUser, targetUid,PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserModuleScope(vUser, targetUid,PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SavePermissionItemScope(HttpContext ctx)
        /// <summary>
        /// 批量保存用户某个权限域内的操作权限项授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SavePermissionItemScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetUid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetUserId"));
            var pIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("permissionItemIds"));
            if (string.IsNullOrEmpty(targetUid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "用户主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpPItemIds = RDIFrameworkService.Instance.PermissionService.GetScopePermissionItemIdsByUserId(Utils.UserInfo, targetUid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(pIds))
                {
                    if (tmpPItemIds != null && tmpPItemIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserPermissionItemScope(vUser, targetUid, PermissionItemScopeCode, tmpPItemIds);
                    }
                }
                else
                {
                    var revokeIds = tmpPItemIds.Except(pIds.Split(',')).ToArray();
                    var grantIds = pIds.Split(',').Except(tmpPItemIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantUserPermissionItemScope(vUser, targetUid,PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeUserPermissionItemScope(vUser, targetUid,PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #endregion

        #region 角色授权范围相关

        #region private void GetScopeUserIdsByRoleId(HttpContext ctx)
        /// <summary>
        /// 获取指定角色在某个权限域(或操作权限编号)下所拥有的用户主键数组
        /// 得到角色对那些用户有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeUserIdsByRoleId(HttpContext ctx)
        {
            var roleid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var roleIds = RDIFrameworkService.Instance.PermissionService.GetScopeUserIdsByRoleId(Utils.UserInfo, roleid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(roleIds));
        }
        #endregion

        #region private void GetScopeRoleIdsByRoleId(HttpContext ctx)
        /// <summary>
        /// 获取指定角色在某个权限域(或操作权限编号)下所拥有的角色主键数组
        /// 得到角色对那些角色有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeRoleIdsByRoleId(HttpContext ctx)
        {
            var roleid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var roleIds = RDIFrameworkService.Instance.PermissionService.GetScopeRoleIdsByRoleId(Utils.UserInfo, roleid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(roleIds));
        }
        #endregion

        #region private void GetScopeOrganizeIdsByRoleId(HttpContext ctx)
        /// <summary>
        /// 获取指定角色在某个权限域(或操作权限编号)下所拥有的组织机构主键数组
        /// 指定角色对那些组织机构有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeOrganizeIdsByRoleId(HttpContext ctx)
        {
            var roleid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var orgIds = RDIFrameworkService.Instance.PermissionService.GetScopeOrganizeIdsByRoleId(Utils.UserInfo, roleid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(orgIds));
        }
        #endregion

        #region private void GetScopeModuleIdsByRoleId(HttpContext ctx)
        /// <summary>
        /// 获取指定角色在某个权限域下所有模块主键数组
        /// 指定角色对那些模块有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopeModuleIdsByRoleId(HttpContext ctx)
        {
            var roleid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var moduleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByRoleId(Utils.UserInfo, roleid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(moduleIds));
        }
        #endregion

        #region private void GetScopePermissionItemIdsByRoleId(HttpContext ctx)
        /// <summary>
        /// 获取指定角色在某个权限域下所有操作（功能）权限主键数组
        /// 指定角色对那些操作（功能）权限有什么权限（什么权限通过操作权限编号指定）
        /// </summary>
        /// <param name="ctx"></param>
        private void GetScopePermissionItemIdsByRoleId(HttpContext ctx)
        {
            var roleid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var permissionItemIds = RDIFrameworkService.Instance.PermissionService.GetScopePermissionItemIdsByRoleId(Utils.UserInfo, roleid, PermissionItemScopeCode);
            ctx.Response.Write(JSONhelper.ToJson(permissionItemIds));
        }
        #endregion

        #region private void SaveRoleUserScope(HttpContext ctx) 批量保存角色某个权限域内的用户授权范围
        /// <summary>
        /// 批量保存角色某个权限域内的用户授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveRoleUserScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetRid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetRoleId"));
            var uIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userIds"));
            if (string.IsNullOrEmpty(targetRid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "角色主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpUserids = RDIFrameworkService.Instance.PermissionService.GetScopeUserIdsByRoleId(Utils.UserInfo, targetRid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(uIds))
                {
                    if (tmpUserids != null && tmpUserids.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleUserScope(vUser, targetRid, PermissionItemScopeCode, tmpUserids);
                    }
                }
                else
                {
                    var revokeIds = tmpUserids.Except(uIds.Split(',')).ToArray();
                    var grantIds = uIds.Split(',').Except(tmpUserids).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantRoleUserScope(vUser, targetRid, PermissionItemScopeCode, grantIds);
                    }

                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleUserScope(vUser, targetRid, PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SaveRoleRoleScope(HttpContext ctx) 批量保存角色某个权限域内的角色授权范围
        /// <summary>
        /// 批量保存角色某个权限域内的角色授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveRoleRoleScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetRid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetRoleId"));
            var rIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleIds"));
            if (string.IsNullOrEmpty(targetRid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "角色主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpRoleIds = RDIFrameworkService.Instance.PermissionService.GetScopeRoleIdsByRoleId(Utils.UserInfo, targetRid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(rIds))
                {
                    if (tmpRoleIds != null && tmpRoleIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleRoleScope(vUser, targetRid, PermissionItemScopeCode, tmpRoleIds);
                    }
                }
                else
                {
                    var revokeIds = tmpRoleIds.Except(rIds.Split(',')).ToArray();
                    var grantIds = rIds.Split(',').Except(tmpRoleIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantRoleRoleScope(vUser, targetRid, PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleRoleScope(vUser, targetRid, PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SaveRoleOrganizeScope(HttpContext ctx) 批量保存角色某个权限域内的组织机构授权范围
        /// <summary>
        /// 批量保存角色某个权限域内的组织机构授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveRoleOrganizeScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetRid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetRoleId"));
            var orgIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeIds"));
            if (string.IsNullOrEmpty(targetRid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "角色主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpOrgIds = RDIFrameworkService.Instance.PermissionService.GetScopeOrganizeIdsByRoleId(Utils.UserInfo, targetRid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(orgIds))
                {
                    if (tmpOrgIds != null && tmpOrgIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleOrganizeScope(vUser, targetRid, PermissionItemScopeCode, tmpOrgIds);
                    }
                }
                else
                {
                    var revokeIds = tmpOrgIds.Except(orgIds.Split(',')).ToArray();
                    var grantIds = orgIds.Split(',').Except(tmpOrgIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantRoleOrganizeScope(vUser, targetRid, PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleOrganizeScope(vUser, targetRid, PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void SaveRoleModuleScope(HttpContext ctx) 批量保存角色某个权限域内的模块（菜单）授权范围
        /// <summary>
        /// 批量保存角色某个权限域内的模块（菜单）授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveRoleModuleScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetRid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetRoleId"));
            var mIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("moduleIds"));
            if (string.IsNullOrEmpty(targetRid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "角色主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpModuleIds = RDIFrameworkService.Instance.PermissionService.GetScopeModuleIdsByRoleId(Utils.UserInfo, targetRid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(mIds))
                {
                    if (tmpModuleIds != null && tmpModuleIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleModuleScope(vUser, targetRid, PermissionItemScopeCode, tmpModuleIds);
                    }
                }
                else
                {
                    var revokeIds = tmpModuleIds.Except(mIds.Split(',')).ToArray();
                    var grantIds = mIds.Split(',').Except(tmpModuleIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantRoleModuleScope(vUser, targetRid, PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRoleModuleScope(vUser, targetRid, PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region  private void SaveRolePermissionItemScope(HttpContext ctx) 批量保存角色某个权限域内的操作权限项授权范围
        /// <summary>
        /// 批量保存角色某个权限域内的操作权限项授权范围
        /// </summary>
        /// <param name="ctx"></param>
        private void SaveRolePermissionItemScope(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var targetRid = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("targetRoleId"));
            var pIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("permissionItemIds"));
            if (string.IsNullOrEmpty(targetRid))
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-1", Message = "角色主键为空！" }.ToString());
                return;
            }

            try
            {
                var tmpPItemIds = RDIFrameworkService.Instance.PermissionService.GetScopePermissionItemIdsByRoleId(Utils.UserInfo, targetRid, PermissionItemScopeCode);
                if (string.IsNullOrEmpty(pIds))
                {
                    if (tmpPItemIds != null && tmpPItemIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRolePermissionItemScope(vUser, targetRid, PermissionItemScopeCode, tmpPItemIds);
                    }
                }
                else
                {
                    var revokeIds = tmpPItemIds.Except(pIds.Split(',')).ToArray();
                    var grantIds = pIds.Split(',').Except(tmpPItemIds).ToArray();
                    if (grantIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.GrantRolePermissionItemScope(vUser, targetRid, PermissionItemScopeCode, grantIds);
                    }
                    if (revokeIds.Length > 0)
                    {
                        RDIFrameworkService.Instance.PermissionService.RevokeRolePermissionItemScope(vUser, targetRid, PermissionItemScopeCode, revokeIds);
                    }
                }
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = "授权成功！" }.ToString());

            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "-2", Message = "异常信息：" + ex.Message }.ToString());
            }
        }
        #endregion

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}