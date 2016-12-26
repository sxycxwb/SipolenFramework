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
    /// PermissionItemAdminHandler 的摘要说明
    /// </summary>
    public class PermissionItemAdminHandler : IHttpHandler, IRequiresSessionState
    {
        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据才可以，只能管理这个范围的数据)
        /// </summary>
        private const string PermissionItemScopeCode = "Resource.ManagePermission";

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
                case "Add":
                    AddPermissionItem(context);
                    break;
                case "Edit":
                    EditPermissionItem(context);
                    break;
                case "Delete":
                    DeletePermissionItem(context);
                    break;
                case "MoveTo":
                    MoveTo(context);
                    break;
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.PermissionItemService.GetEntity(Utils.UserInfo, PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")))));
                    break;
                case "GetPermissionItemTree":
                    DataTable dtPermissionItem =  GetPermissionItemScop(PermissionItemScopeCode);
                    string treeData = GetJsonData(dtPermissionItem);
                    treeData = treeData.Replace("Id", "id").Replace("FullName", "text").Replace("Expand", "state");//.Replace("\"state\":1", "\"state\":\"open\"").Replace("\"state\":0", "\"state\":\"closed\"");
                    context.Response.Write(treeData);
                    break;
                case "GetPermissionItemByParentId":
                    GetPermissionItemByParentId(context);
                    break;
                case "GetPermissionItemByIds":
                    GetPermissionItemByIds(context);
                    break;
                default:
                    dtPermissionItem =  GetPermissionItemScop(PermissionItemScopeCode);
                    treeData = GetJsonData(dtPermissionItem);
                    context.Response.Write(treeData);
                    break;
            }
        }

        private PiPermissionItemEntity GetPagePermissionItemEntity(PiPermissionItemEntity entity)
        {
            entity.Code = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Code"));
            entity.FullName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FullName"));
            entity.JsEvent = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("JsEvent"));
            entity.ParentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("vparentid"));
            entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            entity.IsSplit = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IsSplit")) == "on" ? 1 : 0;
            entity.IsScope = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IsScope")) == "on" ? 1 : 0;
            entity.IsPublic = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("IsPublic")) == "on" ? 1 : 0;
            entity.AllowEdit = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AllowEdit")) == "on" ? 1 : 0;
            entity.AllowDelete = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            return entity;
        }

        #region private void AddPermissionItem(HttpContext ctx) 新增操作权限项
        /// <summary>
        /// 新增操作权限项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddPermissionItem(HttpContext ctx)
        {
            var entity = new PiPermissionItemEntity();
            var vUser = Utils.UserInfo;
            entity = this.GetPagePermissionItemEntity(entity);
            entity.DeleteMark = 0;
            if (vUser != null)
            {
                entity.CreateBy = vUser.RealName;
                entity.CreateUserId = vUser.Id;
            }
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
               string keyId =  RDIFrameworkService.Instance.PermissionItemService.Add(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                    ? new JsonMessage { Success = true, Data = keyId, Message = statusMessage }.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void EditPermissionItem(HttpContext ctx) 编辑、修改操作权限项
        /// <summary>
        /// 编辑、修改操作权限项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void EditPermissionItem(HttpContext ctx)
        {
            UserInfo vUser = Utils.UserInfo;
            string vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            PiPermissionItemEntity entity = RDIFrameworkService.Instance.PermissionItemService.GetEntity(vUser, vId);
            entity = this.GetPagePermissionItemEntity(entity);
            if (vUser != null)
            {
                entity.ModifiedBy = vUser.RealName;
                entity.ModifiedUserId = vUser.Id;
            }

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                RDIFrameworkService.Instance.PermissionItemService.Update(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "0", Message = statusMessage + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void DeletePermissionItem(HttpContext ctx) 删除操作权限项
        /// <summary>
        /// 删除操作权限项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void DeletePermissionItem(HttpContext ctx)
        {
            string vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            UserInfo vUser = Utils.UserInfo;

            int successFlag = 0;
            try
            {
                int returnValue = RDIFrameworkService.Instance.PermissionItemService.SetDeleted(Utils.UserInfo, new string[] { vId });

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

        private void MoveTo(HttpContext ctx)
        {
            var parentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("parentId"));
            var id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
            try
            {
                var returnValue = RDIFrameworkService.Instance.PermissionItemService.MoveTo(Utils.UserInfo, id, parentId);
                ctx.Response.Write(returnValue > 0 ? "1" : "0");
            }
            catch (Exception ex)
            {
                ctx.Response.Write("-1");
            }
        }

        private void GetPermissionItemByParentId(HttpContext ctx)
        {
            var parentId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("permissionItemId"));
            DataTable dtPermissionItem = RDIFrameworkService.Instance.PermissionItemService.GetDTByParent(Utils.UserInfo, parentId);
            string treeData = GetJsonData(dtPermissionItem);
            ctx.Response.Write(treeData);
        }

        private void GetPermissionItemByIds(HttpContext ctx)
        {
            var ids = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("permissionItemIds"));
            DataTable dtPermissionItem = RDIFrameworkService.Instance.PermissionItemService.GetDTByIds(Utils.UserInfo, ids.Split(','));
            string treeData = GetJsonData(dtPermissionItem);
            ctx.Response.Write(treeData);
        }

            
        #region 绑定数据
        private string GetJsonData(DataTable dtPermissionItem)
        {
            var list = new List<PiPermissionItemEntity>();
            Utils.CheckTreeParentId(dtPermissionItem, PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldParentId);
            if (dtPermissionItem != null && dtPermissionItem.Rows.Count > 0)
            {
                list.AddRange(from DataRow drow in dtPermissionItem.Rows select BaseEntity.Create<PiPermissionItemEntity>(drow));
            }

            return "[" + GroupJSONdata(list, "#") + "]";
        }

        private int treeLevel = 0;
        private string GroupJSONdata(List<PiPermissionItemEntity> groups, string parentId)
        {
            var sb = new StringBuilder();
            IEnumerable<PiPermissionItemEntity> list = groups.FindAll(gm => gm.ParentId == parentId);
            foreach (PiPermissionItemEntity gm in list)
            {
                treeLevel++;
                string json = JsonHelper.ObjectToJSON(gm);
                json = json.TrimEnd('}');
                sb.Append(json);
                sb.Append(",");
                if (treeLevel >= 2 && groups.FindAll(permissionItem => permissionItem.ParentId == gm.Id).Count > 0 )
                {
                    sb.Append("\"state\":\"closed\",");
                }
                sb.Append("\"children\":[");
                if (gm.Id != null)
                {
                    sb.Append(GroupJSONdata(groups, gm.Id));
                }
                sb.Append("]},");
            }

            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 获取授权范围数据 （按道理，应该是在某个数据区域上起作用）
        /// </summary>
        private DataTable GetPermissionItemScop(string permissionItemScopeCode)
        {
            UserInfo vUser = Utils.UserInfo;

            // 获取操作权限数据
            DataTable dtPermissionItem = new DataTable(PiPermissionItemTable.TableName);

            if (vUser.IsAdministrator || (String.IsNullOrEmpty(permissionItemScopeCode) || (!SystemInfo.EnableUserAuthorizationScope)))
            {
                dtPermissionItem = RDIFrameworkService.Instance.PermissionItemService.GetDT(vUser);
                // 这里需要只把有效的操作权限显示出来
                // BusinessLogic.SetFilter(dtPermissionItem, PiPermissionItemTable.FieldEnabled, "1");
                // 未被打上删除标标志的
                // BusinessLogic.SetFilter(dtPermissionItem, PiPermissionItemTable.FieldDeleteMark, "0");

            }
            else
            {
                dtPermissionItem = RDIFrameworkService.Instance.PermissionService.GetPermissionItemDTByPermissionScope(vUser, vUser.Id, permissionItemScopeCode);
                //BasePageLogic.CheckTreeParentId(dtPermissionItem, PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldParentId);
            }
            return dtPermissionItem;
           
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