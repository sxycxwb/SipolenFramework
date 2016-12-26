using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Text;

namespace RDIFramework.WebApp.Modules.hander
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.WebCommon;

    /// <summary>
    /// OrganizeAdminHander 的摘要说明
    /// </summary>
    public class OrganizeAdminHander : IHttpHandler, IRequiresSessionState
    {
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
                case "SubmitForm":
                    SubmitForm(context);
                    break;
                case "GetEntity":
                    GetEntity(context);
                    break;
                case "DeleteOrganize":
                    DeleteOrganize(context);
                    break;
                case "GetOrganizeEntity":
                    GetOrganizeEntity(context);
                    break;
                case "treedata":
                    var ss = GetJsonData();
                    ss = ss.Replace("FullName", "text").Replace("Id","id");
                    context.Response.Write(ss);
                    break;
                case "GetOrganizeTree":
                    var jsonData = GetJsonData();
                    jsonData = jsonData.Replace("FullName", "text").Replace("Id", "id");
                    context.Response.Write(jsonData);
                    break;
                case "GetOrganizeByCategory":
                    GetOrganizeByCategory(context);
                    break;
                case "MoveTo":
                    MoveTo(context);
                    break;
                default:                  
                    ss = GetJsonData();                    
                    context.Response.Write(ss);
                    break;
            }
        }

        private void SubmitForm(HttpContext context)
        {
            try
            {
                int IsOk = 1;
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                string Message = key == "" ? "新增成功。" : "修改成功。";
                RDIFramework.Utilities.UserInfo curUser = Utils.UserInfo;
                PiOrganizeEntity entity = JsonHelper.JSONToObject<PiOrganizeEntity>(json);
                if (string.IsNullOrEmpty(key))
                {
                    //增加
                    if (!string.IsNullOrEmpty(entity.ManagerId))
                    {
                        entity.Manager = RDIFrameworkService.Instance.UserService.GetEntity(curUser, entity.ManagerId).RealName;
                    }
                    if (!string.IsNullOrEmpty(entity.AssistantManagerId))
                    {
                        entity.AssistantManager = RDIFrameworkService.Instance.UserService.GetEntity(curUser, entity.AssistantManagerId).RealName;
                    }
                    entity.CreateBy = curUser.RealName;
                    entity.CreateUserId = curUser.Id;
                    string statusCode, statusMessage, returnKey;
                    returnKey = RDIFrameworkService.Instance.OrganizeService.Add(curUser, entity, out statusCode, out statusMessage);
                    context.Response.Write(statusCode == RDIFramework.Utilities.StatusCode.OKAdd.ToString()
                        ? new JsonMessage { Success = true, Data = returnKey, Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
                else
                {
                    var updateEntity = RDIFrameworkService.Instance.OrganizeService.GetEntity(curUser, key);
                    if (updateEntity != null)
                    {
                        updateEntity.ParentId = entity.ParentId;
                        updateEntity.FullName = entity.FullName;
                        updateEntity.ShortName = entity.ShortName;
                        updateEntity.Code = entity.Code;
                        updateEntity.Category = entity.Category;
                        updateEntity.ManagerId = entity.ManagerId;
                        updateEntity.AssistantManagerId = entity.AssistantManagerId;
                        if (!string.IsNullOrEmpty(updateEntity.ManagerId))
                        {
                            updateEntity.Manager = RDIFrameworkService.Instance.UserService.GetEntity(curUser, updateEntity.ManagerId).RealName;
                        }
                        if (!string.IsNullOrEmpty(updateEntity.AssistantManagerId))
                        {
                            updateEntity.AssistantManager = RDIFrameworkService.Instance.UserService.GetEntity(curUser, updateEntity.AssistantManagerId).RealName;
                        }
                        updateEntity.OuterPhone = entity.OuterPhone;
                        updateEntity.InnerPhone = entity.InnerPhone;
                        updateEntity.Fax = entity.Fax;
                        updateEntity.Postalcode = entity.Postalcode;
                        updateEntity.Web = entity.Web;
                        updateEntity.Address = entity.Address;
                        updateEntity.Enabled = entity.Enabled;
                        updateEntity.IsInnerOrganize = entity.IsInnerOrganize;
                        updateEntity.Description = entity.Description;
                    }

                    if (curUser != null)
                    {
                        updateEntity.ModifiedBy = curUser.RealName;
                        updateEntity.ModifiedUserId = curUser.Id;
                    }
                    string statusCode;
                    string statusMessage;
                    var returnValue = RDIFrameworkService.Instance.OrganizeService.Update(curUser, updateEntity, out statusMessage);
                    context.Response.Write(returnValue > 0
                        ? new JsonMessage { Success = true, Data = IsOk.ToString(), Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(new JsonMessage { Success = false, Data = "0", Message = "操作失败：" + ex.Message }.ToString());
            }
        }

        private void GetEntity(HttpContext ctx)
        {
            var entity = RDIFrameworkService.Instance.OrganizeService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key")));
            ctx.Response.Write(JSONhelper.ToJson(entity));
        }

        #region private void DeleteOrganize(HttpContext ctx) 删除组织机构
        /// <summary>
        /// 删除组织机构
        /// </summary>
        /// <param name="ctx"></param>
        private void DeleteOrganize(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            
            try
            {
                var returnValue = RDIFrameworkService.Instance.OrganizeService.SetDeleted(Utils.UserInfo, new string[] { vId });

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage {Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }
        #endregion 

        private void GetOrganizeEntity(HttpContext ctx)
        {
            var entity = RDIFrameworkService.Instance.OrganizeService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")));
            ctx.Response.Write(JSONhelper.ToJson(entity));
        }

        /// <summary>
        /// 通过组织机构分类代码（Company、Department、SubDepartment、Workgroup）得到组织机构列表
        /// </summary>
        /// <param name="ctx"></param>
        private void GetOrganizeByCategory(HttpContext ctx)
        {
            //var d = JSON.stringify($('body').data('depData'));
            //d = '[{"id":0,"text":"请选择组织机构"},' + d.substr(1);

            //Company、Department、SubDepartment、Workgroup
            var returnJson = "[]";
            string[] names = { PiOrganizeTable.FieldCategory, PiOrganizeTable.FieldEnabled, PiOrganizeTable.FieldDeleteMark };
            var organizeCategory = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("OrganizeCategory"));
            string[] values = { organizeCategory, "1", "0" };
            var dtOrganize = RDIFrameworkService.Instance.OrganizeService.GetDTByValues(Utils.UserInfo, names, values);

            if (dtOrganize != null && dtOrganize.Rows.Count > 0)
            {
                returnJson = JSONhelper.ToJson(dtOrganize);
                returnJson = @"[{""ID"":0,""FULLNAME"":""请选择""}," + returnJson.Substring(1);
            }    

            ctx.Response.Write(returnJson);
        }

        private void MoveTo(HttpContext ctx)
        {
            var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeId"));
            var parentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("parentId"));
            try
            {
                var returnValue = RDIFrameworkService.Instance.OrganizeService.MoveTo(Utils.UserInfo, organizeId, parentId);
                ctx.Response.Write(returnValue > 0 ? "1" : "0");
            }
            catch (Exception ex)
            {
                ctx.Response.Write("-1");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据，只能管理这个范围的数据)
        /// </summary>
        private const string PermissionItemScopeCode = "Resource.ManagePermission";

        private string GetJsonData()
        {
            var dtOrganize = new DataTable();
            dtOrganize = GetOrganizeScope(PermissionItemScopeCode, false);
            Utils.CheckTreeParentId(dtOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
            var list = (from DataRow drow in dtOrganize.Rows select BaseEntity.Create<PiOrganizeEntity>(drow)).ToList();

            return "[" + GroupJsondata(list, "#") + "]";
        }

        private int treeLevel = 0;
        private string GroupJsondata(List<PiOrganizeEntity> groups, string parentId)
        {
            var sb = new StringBuilder();
            var list = groups.FindAll(gm => gm.ParentId == parentId);
            foreach (var gm in list)
            {
                treeLevel++;
                var json = JsonHelper.ObjectToJSON(gm);               
                json = json.TrimEnd('}');
                sb.Append(json);
                if (gm.Category.ToLower() == OrganizeCategory.Company.ToDescription().ToLower())
                {
                    sb.Append(",\"iconCls\":\"icon16_sitemap\"");
                }
                else if (gm.Category.ToLower() == OrganizeCategory.SubCompany.ToDescription().ToLower())
                {
                    sb.Append(",\"iconCls\":\"icon16_server\"");
                }
                else if (gm.Category.ToLower() == OrganizeCategory.Department.ToDescription().ToLower())
                {
                    sb.Append(",\"iconCls\":\"icon16_building\"");
                }
                else if (gm.Category.ToLower() == OrganizeCategory.SubDepartment.ToDescription().ToLower())
                {
                    sb.Append(",\"iconCls\":\"icon16_ipod\"");
                }
                else if (gm.Category.ToLower() == OrganizeCategory.Workgroup.ToDescription().ToLower())
                {
                    sb.Append(",\"iconCls\":\"icon16_envelopes\"");
                }

                //sb.Append(",\"state\":\"open\",");
                sb.Append(",");
                if (treeLevel >= 2 && groups.FindAll(organizeList => organizeList.ParentId == gm.Id).Count > 0)
                {
                    sb.Append("\"state\":\"closed\",");
                }
                sb.Append("\"children\":[");
                if (gm.Id != null)
                {
                    sb.Append(GroupJsondata(groups, gm.Id));
                }
                sb.Append("]},");
            }
            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 获取组织机构权限域数据
        /// </summary>
        private DataTable GetOrganizeScope(string permissionItemScopeCode, bool isInnerOrganize)
        {
            var user = Utils.UserInfo;
            // 获取部门数据，不启用权限域
            var dataTable = new DataTable(PiOrganizeTable.TableName);
            if ((user.IsAdministrator) || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                dataTable = RDIFrameworkService.Instance.OrganizeService.GetDT(user);
            }
            else
            {
                dataTable = RDIFrameworkService.Instance.PermissionService.GetOrganizeDTByPermissionScope(user, user.Id, permissionItemScopeCode);
            }

            if (isInnerOrganize)
            {
                BusinessLogic.SetFilter(dataTable, PiOrganizeTable.FieldIsInnerOrganize, "1");
            }
            dataTable.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
            return dataTable;
        }
    }
}