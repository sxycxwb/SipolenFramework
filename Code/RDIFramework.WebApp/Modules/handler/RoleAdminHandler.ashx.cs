using System;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// RoleAdminHandler 的摘要说明
    /// 
    /// 修改说明：    
    ///     1、2013-07-25 EricHu 新增：GetRoleListByPage。
    ///     2、 2015-10-27 EricHu V3.0版本 重新设计增加与修改代码，直接序列化页面的json，减少大量代码。
    ///     3、 2015-10-29 EricHu V3.0版本 重构分页部分的代码使用通用分页参数代替，减少重复大量代码。 
    /// </summary>
    public class RoleAdminHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private const string PermissionItemScopeCode = "Resource.ManagePermission";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {               
                case "SubmitForm":
                    SubmitForm(context);
                    break;
                case "delete":
                    DeleteRole(context);
                    break;
                case "GetRoleEntity":
                    GetRoleEntity(context);
                    break;
                case "usersinrole":
                    UserInRole(context);
                    break;
                case "setusers":
                    SetUsers(context);
                    break;
                case "removeuserfromrole": //将用户从角色中移除
                    RemoveUserFromRole(context);
                    break;
                case "AddUserToRole": //用户添加到角色
                    AddUserToRole(context);
                    break;
                case "getrolelist":
                    GetRoleList(context);
                    break;
                case "GetEnabledRoleList":  //得到有效的角色列表
                    GetEnabledRoleList(context);
                    break;
                case "GetRoleListByPage":
                    GetRoleListByPage(context);
                    break;
                case "GetRoleListByUserId": //得到当前用户所拥有的角色列表
                    GetRoleListByUserId(context);
                    break;
                case "GetRoleCategory": //得到角色分类
                    GetRoleCategory(context);
                    break;
                case "GetRoleListByOrganize": //按组织机构获取角色列表
                    GetRoleListByOrganize(context);
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void SubmitForm(HttpContext context)
        {
            try
            {
                int IsOk = 1;
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                UserInfo curUser = Utils.UserInfo;
                var entity = JsonHelper.JSONToObject<PiRoleEntity>(json);
                if (string.IsNullOrEmpty(key))
                {
                    //增加
                    entity.CreateBy = curUser.RealName;
                    entity.CreateUserId = curUser.Id;
                    string statusCode, statusMessage, returnKey;
                    returnKey = RDIFrameworkService.Instance.RoleService.Add(curUser, entity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                        ? new JsonMessage { Success = true, Data = returnKey, Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
                else
                {
                    var updateEntity = RDIFrameworkService.Instance.RoleService.GetEntity(curUser, key);
                    if (updateEntity != null)
                    {
                        updateEntity.Code = entity.Code;
                        updateEntity.RealName = entity.RealName;
                        updateEntity.Category = entity.Category;
                        updateEntity.Enabled = entity.Enabled;
                        updateEntity.Description = entity.Description;
                    }

                    if (curUser != null)
                    {
                        updateEntity.ModifiedBy = curUser.RealName;
                        updateEntity.ModifiedUserId = curUser.Id;
                    }
                    string statusCode;
                    string statusMessage;
                    RDIFrameworkService.Instance.RoleService.Update(curUser, updateEntity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                        ? new JsonMessage { Success = true, Data = IsOk.ToString(), Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        #region private void DeleteRole(HttpContext ctx) 删除角色
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void DeleteRole(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var vReturnValue = RDIFrameworkService.Instance.RoleService.SetDeleted(vUser, new string[] { vId });
            ctx.Response.Write(vReturnValue > 0
                ? new JsonMessage {Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013}.ToString()
                : new JsonMessage {Success = true, Data = "0", Message = "删除角色失败！"}.ToString());
        }
        #endregion

        #region private void UserInRole(HttpContext ctx) 按角色获取用户
        /// <summary>
        /// 按角色获取用户
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void UserInRole(HttpContext ctx)
        {
            var dtUser = new DataTable(PiUserTable.TableName);
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            dtUser = RDIFrameworkService.Instance.UserService.GetDTByRole(Utils.UserInfo, vId);
            ctx.Response.Write(JSONhelper.ToJson(dtUser));
        }
        #endregion

        #region private void SetUsers(HttpContext ctx) 用户添加到角色
        private void SetUsers(HttpContext ctx)
        {
            var vRoleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var userIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("users"));
            if (string.IsNullOrEmpty(userIds) || userIds.Length <= 0)
            {
                ctx.Response.Write("无选择的用户～！");
                return;
            }

            var iReturnValue = RDIFrameworkService.Instance.RoleService.AddUserToRole(Utils.UserInfo, vRoleId, userIds.Split(','));
            ctx.Response.Write(iReturnValue > 0 ? "1" : "添加用户到角色失败！");
        }
        #endregion

        #region private void RemoveUserFromRole(HttpContext ctx) 将用户从角色中移除
        /// <summary>
        /// 将用户从角色中移除
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void RemoveUserFromRole(HttpContext ctx)
        {
            var vRoleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleid"));
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("uid"));

            if (string.IsNullOrEmpty(userId) || userId.Length <= 0)
            {
                ctx.Response.Write("无选择的用户～！");
                return;
            }
            var iReturnValue = RDIFrameworkService.Instance.RoleService.RemoveUserFromRole(Utils.UserInfo, vRoleId, new string[] { userId });
            ctx.Response.Write(iReturnValue > 0 ? "1" : "用户移除角色失败！");
        }
        #endregion

        #region private void AddUserToRole(HttpContext ctx) 用户添加到角色
        /// <summary>
        /// 用户添加到角色
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddUserToRole(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var addUserIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("addUserIds"));

            if (!string.IsNullOrEmpty(addUserIds) && addUserIds.Trim().Length > 0)
            {
                var returnValue = RDIFrameworkService.Instance.RoleService.AddUserToRole(Utils.UserInfo, roleId, addUserIds.Split(','));
                ctx.Response.Write(returnValue > 0 ? "1" : "添加角色失败！");
            }
        }
        #endregion

        #region private void GetRoleList(HttpContext ctx) 得到角色列表
        /// <summary>
        /// 得到角色Json列表
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetRoleList(HttpContext ctx)
        {
            ctx.Response.Write(JSONhelper.ToJson(GetRoleScope(PermissionItemScopeCode)));
        }
        #endregion

        private void GetRoleEntity(HttpContext ctx)
        {
            var entity = RDIFrameworkService.Instance.RoleService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key")));
            ctx.Response.Write(JSONhelper.ToJson(entity));
        }

        /// <summary>
        /// 得到有效的角色列表
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetEnabledRoleList(HttpContext ctx)
        {
            var returnJson = "[]";
            var dtRole = RDIFrameworkService.Instance.RoleService.GetDTByValues(Utils.UserInfo, 
                                new string[] { "DeleteMark", "Enabled" }, new string[] { "0", "1" });
            if(dtRole != null && dtRole.Rows.Count >0)
            {
                returnJson = JSONhelper.ToJson(dtRole);
            }
            ctx.Response.Write(returnJson);

        }

        /// <summary>
        /// 得到指定用户所拥有的角色列表
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetRoleListByUserId(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var roleIds = RDIFrameworkService.Instance.UserService.GetUserRoleIds(vUser, userId);
            var writeJson = "[]";
            if (roleIds != null && roleIds.Length > 0)
            {
                writeJson = JSONhelper.ToJson(RDIFrameworkService.Instance.RoleService.GetDTByIds(vUser, roleIds));
            }
            ctx.Response.Write(writeJson);
        }

        /// <summary>
        /// 按组织机构获取角色列表
        /// </summary>
        /// <param name="ctx"></param>
        private void GetRoleListByOrganize(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeId"));
            var roles = RDIFrameworkService.Instance.RoleService.GetDTByOrganize(vUser, organizeId);
            var writeJson = "[]";
            if (roles != null && roles.Rows.Count > 0)
            {
                writeJson = JSONhelper.ToJson(roles);
            }
            ctx.Response.Write(writeJson);
        }

        /// <summary>
        /// 获取角色权限域数据
        /// </summary>
        private DataTable GetRoleScope(string permissionItemScopeCode)
        {
            var vUser = Utils.UserInfo;
            // 获取部门数据
            var returnValue = new DataTable(PiRoleTable.TableName);
            if ((vUser.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                returnValue = RDIFrameworkService.Instance.RoleService.GetDT(vUser);
            }
            else
            {
                returnValue = RDIFrameworkService.Instance.PermissionService.GetRoleDTByPermissionScope(vUser, vUser.Id, permissionItemScopeCode);
            }
            return returnValue;
        }

        /// <summary>
        /// 得到分页角色列表
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetRoleListByPage(HttpContext ctx)
        {
            var pageParam = new PageParam(ctx);
            var recordCount = 0;
            var dtRole = RDIFrameworkService.Instance.RoleService.GetDTByPage(Utils.UserInfo, out recordCount, pageParam.PageIndex, pageParam.PageSize, pageParam.Filter, (pageParam.SortField + " " + pageParam.Order));
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtRole);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 得到角色分类
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetRoleCategory(HttpContext ctx)
        {
            var categorycode = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("categorycode"));
            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(Utils.UserInfo, categorycode);
            var dataRow = dtItemDetail.NewRow();            
            dataRow[CiItemDetailsTable.FieldItemName] = "==选择所有分类==";
            dataRow[CiItemDetailsTable.FieldItemValue] = 0;
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            ctx.Response.Write(JSONhelper.ToJson(dtItemDetail));            
        }
    }
}