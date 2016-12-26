using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.handler
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// ModuleAdminHandler 的摘要说明
    /// </summary>
    public class ModuleAdminHandler : IHttpHandler, IRequiresSessionState
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
                case "Add":
                    AddModule(context);
                    break;
                case "Edit":
                    EditModule(context);
                    break;
                case "Delete":
                    DeleteModule(context);
                    break;
                case "GetModuleTree":
                    var treeData = GetJsonData(GetModuleScope(PermissionItemScopeCode));
                    treeData = treeData.Replace("Id", "id").Replace("FullName", "text").Replace("Expand", "state").Replace("icon ", "").Replace("\"IconCss\"", "\"iconCls\"");//.Replace("\"state\":1", "\"state\":\"open\"").Replace("\"state\":0", "\"state
                    context.Response.Write(treeData);
                    break;
                case "GetModuleByParentId":
                    GetModuleByParentId(context);
                    break;
                case "GetModuleByIds":
                    GetModuleByIds(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(
                        RDIFrameworkService.Instance.ModuleService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")))));
                    break;
                default:
                    var jsonStr = GetJsonData(GetModuleScope(PermissionItemScopeCode));
                    jsonStr = jsonStr.Replace("icon ", "").Replace("\"IconCss\"", "\"iconCls\"");
                    context.Response.Write(jsonStr);
                    break;
            }
        }

        private PiModuleEntity GetPageModuleEntity(PiModuleEntity entity)
        {
            entity.Code = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Code"));
            entity.FullName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FullName"));
            entity.Category = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vcategory"));
            entity.ModuleType = BusinessLogic.ConvertToNullableInt(WebCommon.StringHelper.GetRequestObject("vmoduletype")) ?? 6;
            entity.ParentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vparentid"));
            if (string.IsNullOrEmpty(entity.ParentId))
            {
                entity.ParentId = null;
            }
            entity.NavigateUrl = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("NavigateUrl"));
            entity.MvcNavigateUrl = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("MvcNavigateUrl"));
            entity.IconCss = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IconCss"));
            entity.IconUrl = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IconUrl"));
            entity.AssemblyName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AssemblyName"));
            entity.FormName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FormName"));
            entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            entity.IsPublic = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IsPublic")) == "on" ? 1 : 0;
            entity.Expand = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Expand")) == "on" ? 1 : 0;
            entity.AllowEdit = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AllowEdit")) == "on" ? 1 : 0;
            entity.AllowDelete = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AllowDelete")) == "on" ? 1 : 0;
            entity.IsMenu = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IsMenu")) == "on" ? 1 : 0;
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            if (string.IsNullOrEmpty(entity.NavigateUrl))
            {
                entity.NavigateUrl = @"#";
            }
            return entity;
        }

        #region private void AddModule(HttpContext ctx) 增加模块（菜单）
        /// <summary>
        /// 增加模块（菜单）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddModule(HttpContext ctx)
        {
            var entity = new PiModuleEntity {DeleteMark = 0};
            var vUser = Utils.UserInfo;
            entity = GetPageModuleEntity(entity);
            if (vUser != null)
            {
                entity.CreateBy = vUser.RealName;
                entity.CreateUserId = vUser.Id;
            }
            var statusCode = string.Empty;
            var statusMessage = string.Empty;
            try
            {
                string keyId = RDIFrameworkService.Instance.ModuleService.Add(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                    ? new JsonMessage { Success = true, Data = keyId, Message = statusMessage }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage + ex.Message}.ToString());
            }
        }
        #endregion

        #region private void EditModule(HttpContext ctx) 编辑、修改模块（菜单）
        /// <summary>
        /// 编辑、修改模块（菜单）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void EditModule(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var entity = RDIFrameworkService.Instance.ModuleService.GetEntity(vUser, vId);
            entity = this.GetPageModuleEntity(entity);
            if (vUser != null)
            {
                entity.ModifiedBy = vUser.RealName;
                entity.ModifiedUserId = vUser.Id;
            }

            var statusCode = string.Empty;
            var statusMessage = string.Empty;
            try
            {
                RDIFrameworkService.Instance.ModuleService.Update(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage {Success = true, Data = vId, Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage + ex.Message}.ToString());
            }
        }
        #endregion

        #region private void DeleteModule(HttpContext ctx) 删除模块（菜单）
        /// <summary>
        /// 删除模块（菜单）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void DeleteModule(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var vUser = Utils.UserInfo;

            var successFlag = 0;
            try
            {
                var returnValue = RDIFrameworkService.Instance.ModuleService.SetDeleted(Utils.UserInfo, new string[] { vId });

                if (returnValue > 0)
                {
                    successFlag = 1;
                    ctx.Response.Write(new JsonMessage { Success = true, Data = successFlag.ToString(), Message = RDIFrameworkMessage.MSG0013 }.ToString());
                }
                else
                {
                    ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = RDIFrameworkMessage.MSG3020 }.ToString());
                }
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = successFlag.ToString(), Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }
        #endregion

        #region 得到数据
        private string GetJsonData(DataTable dtModule)
        {
            Utils.CheckTreeParentId(dtModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId);
            var list = (from DataRow drow in dtModule.Rows select BaseEntity.Create<PiModuleEntity>(drow)).ToList();
            return "[" + GroupJsoNdata(list, "#") + "]";
        }

        private int treeLevel = 0;
        private string GroupJsoNdata(List<PiModuleEntity> groups, string parentId)
        {
            var sb = new StringBuilder();
            var list = groups.FindAll(gm => gm.ParentId == parentId);
            foreach (var gm in list)
            {
                treeLevel++;
                var json = JsonHelper.ObjectToJSON(gm);
                json = json.TrimEnd('}');
                sb.Append(json);
                sb.Append(",");
                if (treeLevel >= 2 && groups.FindAll(permissionItem => permissionItem.ParentId == gm.Id).Count > 0)
                {
                    sb.Append("\"state\":\"closed\",");
                }
                sb.Append("\"children\":[");
                if (gm.Id != null) sb.Append(GroupJsoNdata(groups, gm.Id));
                sb.Append("]},");
            }

            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 获取模块菜单限域数据
        /// </summary>
        private DataTable GetModuleScope(string permissionItemScopeCode)
        {
            var vUser = Utils.UserInfo;
            // 获取部门数据
            if ((vUser.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                var dtModule = RDIFrameworkService.Instance.ModuleService.GetDT(vUser);                
                // 这里需要只把有效的模块显示出来
                // BusinessLogic.SetFilter(dtModule, PiModuleTable.FieldEnabled, "1");
                // 未被打上删除标标志的
                // BusinessLogic.SetFilter(dtModule, PiModuleTable.FieldDeleteMark, "0");
                return dtModule;
            }
            else
            {
                var dataTable = RDIFrameworkService.Instance.PermissionService.GetModuleDTByPermissionScope(vUser, vUser.Id, permissionItemScopeCode);               
                return dataTable;
            }
        }
        #endregion

        /// <summary>
        /// 按父节点得到对应的子节点
        /// </summary>
        /// <param name="ctx"></param>
        private void GetModuleByParentId(HttpContext ctx)
        {
            var parentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("moduleId"));
            DataTable dtPermissionItem = RDIFrameworkService.Instance.ModuleService.GetDTByParent(Utils.UserInfo, parentId);
            string treeData = GetJsonData(dtPermissionItem);
            treeData = treeData.Replace("icon ", "").Replace("\"IconCss\"", "\"iconCls\"");
            ctx.Response.Write(treeData);
        }

        /// <summary>
        /// 按主键列表得到对应的子节点
        /// </summary>
        /// <param name="ctx"></param>
        private void GetModuleByIds(HttpContext ctx)
        {
            var Ids = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("moduleIds"));
            DataTable dtPermissionItem = RDIFrameworkService.Instance.ModuleService.GetDTByIds(Utils.UserInfo, Ids.Split(','));
            string treeData = GetJsonData(dtPermissionItem);
            treeData = treeData.Replace("icon ", "").Replace("\"IconCss\"", "\"iconCls\"");
            ctx.Response.Write(treeData);
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