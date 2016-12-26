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
    /// DataItemAdminHandler 的摘要说明
    /// </summary>
    public class DataItemAdminHandler : IHttpHandler, IRequiresSessionState
    {
        private string Action
        {
            get
            {
                return PublicMethod.GetString(getObj("action"));
            }
        }
        private object getObj(string key) { return RDIFramework.WebCommon.StringHelper.GetRequestObject(key); }

       

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var rpm = new RequestParamModel<CiItemDetailsEntity>(context) { CurrentContext = context, Action = context.Request["action"] };

            if (rpm.Action == "AddItemDetail")
            {
                var entity = rpm.Entity;
            }

            switch (Action)
            {
                case "GetCategory":  //根据字典分类代码得到相应的数据字典明细项
                    GetCategory(context);
                    break;
                case "GetItemsEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.ItemsService.GetEntity(Utils.UserInfo, PublicMethod.GetString(getObj("key")))));
                    break;
                case "AddDataItem":                   
                    this.AddDataItem(context);
                    break;
                case "EditDataItem":
                    this.EditDataItem(context);
                    break;
                case "GetDataItem":
                    GetDataItem(context);
                    break;
                case "GetDataItemTree":
                    GetDataItemTree(context);
                    break;
                case "DeleteDataItem":
                    DeleteDataItem(context);
                    break;
                case "AddItemDetail":
                    AddItemDetail(context);
                    break;
                case "EditItemDetail":
                    EditItemDetail(context);
                    break;
                case "DeleteItemDetail":
                    DeleteItemDetail(context);
                    break;
                default:
                    var categoryId = PublicMethod.GetString(getObj("categoryId")); //得到指定字典下的所有明细项
                    this.GetDataItemDetailById(context, categoryId);
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

        /// <summary>
        /// 根据字典分类代码得到相应的数据字典明细项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void GetCategory(HttpContext ctx)
        {
            var categorycode = PublicMethod.GetString(getObj("categorycode"));
            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(Utils.UserInfo, categorycode);
            var dataRow = dtItemDetail.NewRow();
            //dataRow[CiItemDetailsTable.FieldId] = 0;
            //dataRow[CiItemDetailsTable.FieldItemName] = "==请选择==";
            //dataRow[CiItemDetailsTable.FieldItemValue] = 0;
            dtItemDetail.Rows.InsertAt(dataRow, 0);
            ctx.Response.Write(JSONhelper.ToJson(dtItemDetail));   
        }
        
        private void GetDataItem(HttpContext ctx)
        {
            var json = "[]";
            var dtItems = RDIFrameworkService.Instance.ItemsService.GetDT(Utils.UserInfo);

            if (dtItems != null && dtItems.Rows.Count > 0)
            {
                json = "[";
                foreach (DataRow dRow in dtItems.Rows)
                {
                    json += "{\"id\":\"" + BusinessLogic.ConvertToString(dRow[CiItemsTable.FieldId]) + "\",";
                    json += "\"text\":\"" + BusinessLogic.ConvertToString(dRow[CiItemsTable.FieldFullName]) + " [" + BusinessLogic.ConvertToString(dRow[CiItemsTable.FieldCode]) + "]\",";
                    json += "\"iconCls\":\"icon-bullet_green\"";
                    json += "},";
                }
                json = json.TrimEnd(new char[] { ',' });
                json += "]";
            }
            ctx.Response.Write(json);
        }

        private void GetDataItemTree(HttpContext ctx)
        {
            var json = "[]";
            var dtItems = RDIFrameworkService.Instance.ItemsService.GetDT(Utils.UserInfo);
            Utils.CheckTreeParentId(dtItems, CiItemsTable.FieldId, CiItemsTable.FieldParentId);
            var list = (from DataRow drow in dtItems.Rows select BaseEntity.Create<CiItemsEntity>(drow)).ToList();
            json = "[" + GroupJSONdata(list, "#") + "]";
            json = json.Replace("Id", "id").Replace("FullName", "text");        
            ctx.Response.Write(json);
        }

        private CiItemsEntity GetPageItemEntity(CiItemsEntity entity)
        {
            entity.ParentId = PublicMethod.GetString(getObj("ParentId"));
            entity.ParentId = entity.ParentId == "0" ? null : entity.ParentId;
            entity.Code = PublicMethod.GetString(getObj("Code"));
            entity.FullName = PublicMethod.GetString(getObj("FullName"));
            entity.Category = PublicMethod.GetString(getObj("vcategory"));
            entity.Description = PublicMethod.GetString(getObj("Description"));
            entity.Enabled = PublicMethod.GetString(getObj("Enabled")) == "on" ? 1 : 0;
            return entity;
        }

        #region private void AddDataItem(HttpContext ctx) 添加数据字典类别
        /// <summary>
        /// 添加数据字典类别
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddDataItem(HttpContext ctx)
        {
            var entity = new CiItemsEntity();
            var vUser = Utils.UserInfo;
            entity = this.GetPageItemEntity(entity);
            entity.DeleteMark = 0;
            if (vUser != null)
            {
                entity.CreateBy = vUser.RealName;
                entity.CreateUserId = vUser.Id;
            }
            var statusMessage       = string.Empty;
            var statusCode          = string.Empty;

            try
            {
                RDIFrameworkService.Instance.ItemsService.Add(vUser, entity, out statusCode, out statusMessage);
                ctx.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "添加数据失败！" + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void EditDataItem(HttpContext ctx) 编辑数据字典类别
        /// <summary>
        /// 编辑数据字典类别
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void EditDataItem(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(getObj("KeyId"));
            var entity = RDIFrameworkService.Instance.ItemsService.GetEntity(vUser, vId);
            entity = this.GetPageItemEntity(entity);
            if (vUser != null)
            {
                entity.ModifiedBy = vUser.RealName;
                entity.ModifiedUserId = vUser.Id;
            }
            var statusMessage = string.Empty;
            var statusCode = string.Empty;
            try
            {
                RDIFrameworkService.Instance.ItemsService.Update(vUser, entity, out statusCode, out statusMessage);

                ctx.Response.Write(statusCode == StatusCode.OKUpdate.ToString()
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "更新数据失败！" + ex.Message }.ToString());
            }     
        }
        #endregion

        #region private void DeleteDataItem(HttpContext ctx) 删除数据字典类别
        /// <summary>
        /// 删除数据字典类别
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void DeleteDataItem(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(getObj("key"));
            var vUser = Utils.UserInfo;

            try
            {
                var returnValue = RDIFrameworkService.Instance.ItemsService.SetDeleted(Utils.UserInfo, new string[] { vId });

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage {Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }
        #endregion

        private CiItemDetailsEntity GetPageItemDetailEntity(CiItemDetailsEntity entity)
        {
            entity.ItemCode     = PublicMethod.GetString(getObj("ItemCode"));
            entity.ItemName     = PublicMethod.GetString(getObj("ItemName"));
            entity.ItemValue    = PublicMethod.GetString(getObj("ItemValue"));
            entity.Description  = PublicMethod.GetString(getObj("Description"));
            entity.ItemId       = PublicMethod.GetString(getObj("vitemId"));
            entity.ParentId     = PublicMethod.GetString(getObj("vparentId"));
            entity.Enabled      = PublicMethod.GetString(getObj("Enabled")) == "on" ? 1 : 0;
            entity.IsPublic     = PublicMethod.GetString(getObj("IsPublic")) == "on" ? 1 : 0;
            entity.AllowEdit    = PublicMethod.GetString(getObj("AllowEdit")) == "on" ? 1 : 0;
            entity.AllowDelete  = PublicMethod.GetString(getObj("AllowDelete")) == "on" ? 1 : 0;
            return entity;
        }

        #region private void AddItemDetail(HttpContext ctx) 增加字典明细项
        /// <summary>
        /// 增加字典明细项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void AddItemDetail(HttpContext ctx)
        {
            var entity = new CiItemDetailsEntity();
            var vUser = Utils.UserInfo;
            entity = this.GetPageItemDetailEntity(entity);
            entity.DeleteMark = 0;
            if (vUser != null)
            {
                entity.CreateBy = vUser.RealName;
                entity.CreateUserId = vUser.Id;
            }
            var statusMessage = string.Empty;         

            try
            {
                var returnValue = RDIFrameworkService.Instance.ItemDetailsService.Add(vUser, entity, out statusMessage);
                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void EditItemDetail(HttpContext ctx) 修改字典明细项
        /// <summary>
        /// 修改字典明细项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void EditItemDetail(HttpContext ctx)
        {
            var vUser = Utils.UserInfo;
            var vId = PublicMethod.GetString(getObj("KeyId"));
            var entity = RDIFrameworkService.Instance.ItemDetailsService.GetEntity(vUser, vId);
            entity = this.GetPageItemDetailEntity(entity);
            if (vUser != null)
            {
                entity.ModifiedBy = vUser.RealName;
                entity.ModifiedUserId = vUser.Id;
            }
            var statusMessage = string.Empty;
            try
            {
                var returnValue = RDIFrameworkService.Instance.ItemDetailsService.Update(vUser, entity, out statusMessage);
                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage {Success = true, Data = "1", Message = statusMessage}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = statusMessage}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }
        #endregion

        #region private void DeleteItemDetail(HttpContext ctx) 删除字典明细项
        /// <summary>
        /// 删除字典明细项
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void DeleteItemDetail(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(getObj("key"));
            var vUser = Utils.UserInfo;
           
            try
            {
                var returnValue = RDIFrameworkService.Instance.ItemDetailsService.SetDeleted(Utils.UserInfo, new string[] { vId });

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage {Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013}.ToString()
                    : new JsonMessage {Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020}.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }
        #endregion

        #region private void GetDataItem(HttpContext ctx) 得到指定字典的明细项
        private void GetDataItemDetailById(HttpContext ctx, string id)
        {
            var list = new List<CiItemDetailsEntity>();
            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByValues(Utils.UserInfo
               , new string[] { CiItemDetailsTable.FieldDeleteMark, CiItemDetailsTable.FieldItemId }
               , new string[] { "0", id });

            Utils.CheckTreeParentId(dtItemDetail, CiItemDetailsTable.FieldId, CiItemDetailsTable.FieldParentId);

            if (dtItemDetail != null && dtItemDetail.Rows.Count > 0)
            {
                list.AddRange(from DataRow drow in dtItemDetail.Rows select BaseEntity.Create<CiItemDetailsEntity>(drow));
                var jsonStr = "[" + GroupJSONdata(list, "#") + "]";
                //,\"SORTCODE\":5,\"DESCRIPTION\":NULL,\"CREATEON\":\"\\/DATE(1345174126000)\\/\",\"CREATEUSERID\":\"3\",\"CREATEBY\":\"超级管理员\",
                jsonStr = jsonStr.Replace("NULL", "\"\""); //针对Oracle做下特殊处理。
                ctx.Response.Write(jsonStr);
            }
            else
            {
                ctx.Response.Write("[]");
            }
        }

        private IEnumerable<CiItemDetailsEntity> GetGroups(List<CiItemDetailsEntity> groups, string parentid)
        {
            return groups.FindAll(delegate(CiItemDetailsEntity gm) { return gm.ParentId == parentid; });
        }

        private string GroupJSONdata(List<CiItemDetailsEntity> groups, string parentId)
        {
            var sb = new StringBuilder();
            var list = GetGroups(groups, parentId);
            var json = "";
            foreach (var gm in list)
            {
                json = JsonHelper.ObjectToJSON(gm);
                json = json.TrimEnd('}');
                sb.Append(json);
                sb.Append(",");
                sb.Append("\"children\":[");
                if (gm.Id != null) sb.Append(GroupJSONdata(groups, gm.Id));
                sb.Append("]},");
            }

            return sb.ToString().TrimEnd(',');
        }

        private IEnumerable<CiItemsEntity> GetGroups(List<CiItemsEntity> groups, string parentid)
        {
            return groups.FindAll(delegate(CiItemsEntity gm) { return gm.ParentId == parentid; });
        }

        private int treeLevel = 0;
        private string GroupJSONdata(List<CiItemsEntity> groups, string parentId)
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
                if (gm.Id != null) sb.Append(GroupJSONdata(groups, gm.Id));
                sb.Append("]},");
            }

            return sb.ToString().TrimEnd(',');
        }
        #endregion
        
    }
}