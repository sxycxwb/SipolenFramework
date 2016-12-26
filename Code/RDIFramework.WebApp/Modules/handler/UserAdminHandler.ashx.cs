using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using BizLogic;
    using WebCommon;
    using Utilities;

    /// <summary>
    /// UserAdminHandler 的摘要说明
    /// </summary>
    public class UserAdminHandler : IHttpHandler, IRequiresSessionState
    {
        private const string PermissionItemScopeCode = "Resource.ManagePermission";

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {    
                case "edit":
                    EditUser(context);
                    break;
                case "delete":
                    DeleteUser(context);
                    break;
                case "add":
                    AddUser(context);
                    break;
                case "setpassword":
                    SetUserPassword(context);
                    break;
                case "SetUserEnabled":
                    SetUserEnabled(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.UserService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")))));
                    break;
                case "GetCurrentUserEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.UserService.GetEntity(Utils.UserInfo, Utils.UserInfo.Id)));
                    break;
                case "GetCurrentUserLogOnEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.LogOnService.GetEntity(Utils.UserInfo, Utils.UserInfo.Id)));
                    break;
                case "GetUserListByPage":
                    GetUserListByPage(context);
                    break;
                case "GetDTByRole": //按角色获取用户列表
                    GetDTByRole(context);
                    break;
                case "AddUserToRole":
                    AddUserToRole(context); //为指定用户批量添加角色
                    break;
                case "RemoveRoleByUserId": //批量移除角色
                    RemoveRoleByUserId(context);
                    break;
                case "GetUserPageDTByDepartmentId": //以组织机构主键得到用户分页数据
                    this.GetUserPageDTByDepartmentId(context);
                    break;
                case "SetUserDimission": //用户离职
                    this.SetUserDimission(context);
                    break;
                default:
                    var jsonStr = JSONhelper.ToJson(GetUserScopeList(PermissionItemScopeCode));
                    context.Response.Write(jsonStr);                    
                    break;
            }
        }

        #region private bool IsAuthorized(string permissionItemCode, string permissionItemName = null) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="permissionItemName">权限名称</param>
        /// <returns>是否有权限</returns>
        private bool IsAuthorized(string permissionItemCode, string permissionItemName = null)
        {
            var user = Utils.UserInfo;
            return RDIFrameworkService.Instance.PermissionService.IsAuthorizedByUserId(user, user.Id, permissionItemCode, permissionItemName);
        }
        #endregion

        #region private void GetUserListByPage(HttpContext ctx) 得到分页用户列表
        /// <summary>
        /// 得到分页用户列表
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void GetUserListByPage(HttpContext ctx)
        {
            int recordCount;
            var pageParam = new PageParam(ctx);
            var dtUser = RDIFrameworkService.Instance.UserService.GetDTByPage(Utils.UserInfo, pageParam.Filter, string.Empty, string.Empty, out recordCount, pageParam.PageIndex, pageParam.PageSize, (pageParam.SortField + " " + pageParam.Order));
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount,dtUser);
            ctx.Response.Write(json);
        }
        #endregion

        #region private DataTable GetUserScopeList(string permissionItemScopeCode) 获取用户权限域数据
        /// <summary>
        /// 获取用户权限域数据
        /// </summary>
        private DataTable GetUserScopeList(string permissionItemScopeCode)
        {
            // 是否有用户管理权限，若有用户管理权限就有所有的用户类表，这个应该是内置的操作权限
            //var userAdmin = false;
            //userAdmin = IsAuthorized("UserAdmin");
            var returnValue = new DataTable(PiUserTable.TableName);
            var user = Utils.UserInfo;
            // 获取用户数据
           // if (!userAdmin) return returnValue;
            returnValue = user.IsAdministrator || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope))
                        ? RDIFrameworkService.Instance.UserService.GetDT(user)
                        : RDIFrameworkService.Instance.PermissionService.GetUserDTByPermissionScope(user, user.Id,permissionItemScopeCode);
            return returnValue;
        }
        #endregion

        #region private void GetDTByRole(HttpContext ctx) 按角色获取用户列表
        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void GetDTByRole(HttpContext ctx)
        {
            var roleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("roleId"));
            var writeJson = "[]";
            if (!string.IsNullOrEmpty(roleId))
            {
                writeJson = JSONhelper.ToJson(RDIFrameworkService.Instance.UserService.GetDTByRole(Utils.UserInfo, roleId));
            }
            ctx.Response.Write(writeJson);
        }
        #endregion

        #region private void AddUserToRole(HttpContext ctx) 为指定用户批量添加角色
        /// <summary>
        /// 为指定用户批量添加角色
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void AddUserToRole(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var addRoleIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("addRoleIds"));
            if (!string.IsNullOrEmpty(addRoleIds) && addRoleIds.Trim().Length > 0)
            {
                var returnValue = RDIFrameworkService.Instance.UserService.AddUserToRole(Utils.UserInfo, userId, addRoleIds.Split(','));
                ctx.Response.Write(returnValue > 0 ? "1" : "添加角色失败！");
            }
        }
        #endregion

        #region private void RemoveRoleByUserId(HttpContext ctx) 批量移除角色
        /// <summary>
        /// 批量移除角色
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void RemoveRoleByUserId(HttpContext ctx)
        {
            var userId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userId"));
            var removeRoleIds = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("removeRoleIds"));
            if (!string.IsNullOrEmpty(removeRoleIds) && removeRoleIds.Trim().Length > 0)
            {
                var returnValue = RDIFrameworkService.Instance.UserService.RemoveUserFromRole(Utils.UserInfo, userId, removeRoleIds.Split(','));
                ctx.Response.Write(returnValue > 0 ? "1" : "移除角色失败！");
            }
        }
        #endregion 

        #region private void GetUserPageDTByDepartmentId(HttpContext context) 以组织机构主键得到用户分页数据
        /// <summary>
        /// 以组织机构主键得到用户分页数据
        /// </summary>
        /// <param name="context">HTTP请求</param>
        private void GetUserPageDTByDepartmentId(HttpContext context)
        {
            var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeId"));
            var where = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("searchValue"));
            if (where != "")
            {
                where = HttpUtility.UrlDecode(where); 
            }

            var pageParam = new PageParam(context);
            var json = "[]";
            if (!string.IsNullOrEmpty(organizeId))
            {
                int recordCount;
                var dtUser = RDIFrameworkService.Instance.UserService.GetUserPageDTByDepartment(Utils.UserInfo, PermissionItemScopeCode, where, null, string.Empty, null, true, true, out recordCount, pageParam.PageIndex, pageParam.PageSize, PiUserTable.FieldSortCode, organizeId);
                json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dtUser);
            }
            context.Response.Write(json);
        }
        #endregion

        #region private void AddUser(HttpContext ctx) 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void AddUser(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var entity = new PiUserEntity
            {
                Code = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Code")),
                UserName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("UserName")),
                RealName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("RealName")),
                Gender = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Gender")),
                Mobile = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Mobile")),
                Birthday = PublicMethod.GetDateTime(WebCommon.StringHelper.GetRequestObject("Birthday")),
                Telephone = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Telephone")),
                Title = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Title")),
                Duty = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Duty")),
                QICQ = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("QICQ")),
                Email = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Email")),
                HomeAddress = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("HomeAddress")),
                Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0,
                Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description")),
                RoleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vRoleId")),
                CompanyId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vCompanyId")),
                SubCompanyId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubCompanyId")),
                DepartmentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vDepartmentId")),
                SubDepartmentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubDepartmentId")),
                WorkgroupId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vWorkgroupId"))
            };
            var pwd = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("UserPassword"));
            entity.UserPassword = pwd == string.Empty ? string.Empty : pwd;
            var vCompanyName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vCompanyName"));
            var vSubCompanyName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubCompanyName"));
            var vDepartmentName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vDepartmentName"));
            var vSubDepartmentName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubDepartmentName"));
            var vWorkgroupName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vWorkgroupName"));
            entity.CompanyName = vCompanyName == "请选择" ? string.Empty : vCompanyName;
            entity.SubCompanyName = vSubCompanyName == "请选择" ? string.Empty : vSubCompanyName;
            entity.DepartmentName = vDepartmentName == "请选择" ? string.Empty : vDepartmentName;
            entity.SubDepartmentName = vSubDepartmentName == "请选择" ? string.Empty : vSubDepartmentName;
            entity.WorkgroupName = vWorkgroupName == "请选择" ? string.Empty : vWorkgroupName;

            if (vUser != null)
            {
                entity.CreateBy = vUser.RealName;
                entity.CreateUserId = vUser.Id;
            }

                string statusCode;
                string statusMessage;
                //增加用户
                var vReturnValue = RDIFrameworkService.Instance.UserService.AddUser(vUser, entity, out statusCode, out statusMessage);
                ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
        }
        #endregion


        public void SetUserDimission(HttpContext context)
        {
            try
            {
                string msg = RDIFrameworkMessage.MSG3020;
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                var entity = JsonHelper.JSONToObject<PiUserEntity>(json);
                UserInfo curUser = Utils.UserInfo;
                if (string.IsNullOrEmpty(entity.UserName) && !string.IsNullOrEmpty(entity.Id))
                {
                    entity.UserName = RDIFrameworkService.Instance.UserService.GetEntity(curUser, entity.Id).UserName;
                }
                int returnValue = RDIFrameworkService.Instance.LogOnService.UserDimission(curUser, entity.UserName, entity.DimissionCause, entity.DimissionDate, entity.DimissionWhither);
                msg = returnValue > 0 ? RDIFrameworkMessage.MSG3010 : RDIFrameworkMessage.MSG3020;
                context.Response.Write(new JsonMessage { Success = returnValue > 0, Data = returnValue.ToString(), Message = msg }.ToString());
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 + "：" + ex.Message }.ToString());
            }
        }

        #region private void EditUser(HttpContext ctx) 修改用户
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void EditUser(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("id"));
            var entity = RDIFrameworkService.Instance.UserService.GetEntity(vUser, vId);
            if (entity == null)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "更新失败，无更新的数据！"}.ToString());
                return;
            }
            entity.UserName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("UserName"));
            entity.RealName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("RealName"));
            entity.Code = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Code"));
            entity.Gender = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Gender"));
            entity.Mobile = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Mobile"));
            entity.Birthday = PublicMethod.GetDateTime(WebCommon.StringHelper.GetRequestObject("Birthday"));
            entity.Telephone = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Telephone"));
            entity.Title = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Title"));
            entity.Duty = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Duty"));
            entity.QICQ = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("QICQ"));
            entity.Email = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Email"));
            var vCompanyName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vCompanyName"));
            var vSubCompanyName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubCompanyName"));
            var vDepartmentName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vDepartmentName"));
            var vSubDepartmentName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubDepartmentName"));
            var vWorkgroupName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vWorkgroupName"));
            entity.CompanyName = vCompanyName == "请选择" ? string.Empty : vCompanyName;
            entity.SubCompanyName = vSubCompanyName == "请选择" ? string.Empty : vSubCompanyName;
            entity.DepartmentName = vDepartmentName == "请选择" ? string.Empty : vDepartmentName;
            entity.SubDepartmentName = vSubDepartmentName == "请选择" ? string.Empty : vSubDepartmentName;
            entity.WorkgroupName = vWorkgroupName == "请选择" ? string.Empty : vWorkgroupName;
            entity.HomeAddress = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("HomeAddress"));
            entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            entity.RoleId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vRoleId"));
            entity.CompanyId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vCompanyId"));
            entity.SubCompanyId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubCompanyId"));
            entity.DepartmentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vDepartmentId"));
            entity.SubDepartmentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vSubDepartmentId"));
            entity.WorkgroupId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vWorkgroupId"));          
            if (vUser != null)
            {
                entity.ModifiedBy = vUser.RealName;
                entity.ModifiedUserId = vUser.Id;
            }

            try
            {
                string statusCode;
                string statusMessage;
                RDIFrameworkService.Instance.UserService.UpdateUser(vUser, entity, out statusCode, out statusMessage);
                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "更新失败，错误信息为：" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void DeleteUser(HttpContext ctx) 删除指定用户
        /// <summary>
        /// 删除指定用户
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void DeleteUser(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("id"));
            var vReturnValue = RDIFrameworkService.Instance.UserService.SetDeleted(vUser,new string[]{vId});
            ctx.Response.Write(vReturnValue > 0
                ? new JsonMessage {Success = true, Data = "1", Message = "成功删除用户！"}.ToString()
                : new JsonMessage {Success = false, Data = "0", Message = "删除用户失败！"}.ToString());
        }
        #endregion

        #region private void SetUserPassword(HttpContext ctx) 设置用户密码
        /// <summary>
        /// 设置用户密码
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void SetUserPassword(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("id"));
            var vNewPwd = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("password"));
            
            string statusCode;
            string statusMessage;
            RDIFrameworkService.Instance.LogOnService.SetPassword(vUser, new string[] { vId }, vNewPwd, out statusCode, out statusMessage);
          
            if (statusCode != null && statusCode == StatusCode.SetPasswordOK.ToString())
            {
                ctx.Response.Write(new JsonMessage { Success = true, Data = "1", Message = statusMessage }.ToString());
            }
            else
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
            }
        }
        #endregion

        #region private void SetUserEnabled(HttpContext ctx) 设置用户的可用性
        /// <summary>
        /// 设置用户的可用性
        /// </summary>
        /// <param name="ctx">HTTP请求</param>
        private void SetUserEnabled(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var vValue = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("isenabled"));
            vValue = vValue == "1" ? "0" : "1";
            try
            {
                var vUser = Utils.UserInfo;
                var entity = RDIFrameworkService.Instance.UserService.GetEntity(vUser, vId);
                entity.Enabled = PublicMethod.GetInt(vValue);
                string statusMessage;
                string statusCode;
                RDIFrameworkService.Instance.UserService.UpdateUser(Utils.UserInfo, entity, out statusCode, out statusMessage);
                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch(Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message ="发生异常信息：" + ex.Message }.ToString());
            }
        }
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