using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.WorkFlow.handler
{
    using RDIFramework.WebCommon;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// WorkFlowCommonBizHandler 的摘要说明
    /// </summary>
    public class UserFormAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "GetUserControlClass": //得到用户表单分类
                    GetUserControlClass(context);
                    break;
                case "GetMainUserControlByPage":  //得到主表单分页列表
                    GetMainUserControlByPage(context);
                    break;
                case "GetUserControlByPage":  //得到用户表单分页列表
                    GetUserControlByPage(context);
                    break;
                case "GetAllUserControl":  //得到所有用户表单列表
                    GetAllUserControl(context);
                    break;
                case "GetMainUserControlEntity": //得到主表单实体
                    GetMainUserControlEntity(context);
                    break; 
                case "GetAllChildUserControlsById":  //得到指定主表单的所有子表单
                    GetAllChildUserControlsById(context);
                    break;
                case "AddMainForm":  //增加主表单
                    AddMainForm(context);
                    break;
                case "EditMainForm":  //修改主表单
                    EditMainForm(context);
                    break;
                case "DelMainForm": //删除主表单
                    DelMainForm(context);
                    break;
                case "AddUserControlToMain": //增加子表单到主表单中
                    AddUserControlToMain(context);
                    break;
                case "RemoveUserControlFromMain": //移除子表单从主表单中
                    RemoveUserControlFromMain(context);
                    break;
                case "EditMainUserControlsState":  //修改主表单下指定子表单的状态
                    EditMainUserControlsState(context);
                    break;
                    //子表单相关操作

                case "AddChildForm": //增加子表单
                    AddChildForm(context);
                    break;
                case "EditChildForm": //修改子表单
                    EditChildForm(context);
                    break;
                case "DelChildForm": //删除子表单
                    DelChildForm(context);
                    break;
                case "GetChildUserControlEntity": //得到子表单实体
                    GetChildUserControlEntity(context);
                    break; 
            }
        }

        /// <summary>
        /// 得到用户表单分类
        /// </summary>
        /// <param name="ctx"></param>
        public void GetUserControlClass(HttpContext ctx)
        {
            string treeJson =@"[{""id"":""0"",""text"":""表单管理"",""iconCls"":""icon16_table_format"",""state"":""open"",""children"":[{""id"":""1"",""text"":""主表单管理"",""iconCls"":""icon16_page_white_text"",""state"":""open""},{""id"":""2"",""text"":""子表单管理"",""iconCls"":""icon16_page_white_text"",""state"":""open""}]}]";
            ctx.Response.Write(treeJson);
        }

        /// <summary>
        /// 得到主表单分页列表
        /// </summary>
        /// <param name="ctx"></param>
        public void GetMainUserControlByPage(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            }
            var pageParam = new PageParam(ctx);
            int recordCount;
            var dt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetMainUserControlByPage(Utils.UserInfo, where, out recordCount, pageParam.PageIndex, pageParam.PageSize);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dt);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 得到用户表单分页列表
        /// </summary>
        /// <param name="ctx"></param>
        public void GetUserControlByPage(HttpContext ctx)
        {
            string where = "";
            string filters = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("filter"));
            if (filters != "")
            {
                where = FilterTranslator.ToSql(filters);
            }

            var pageParam = new PageParam(ctx);
            int recordCount;
            var dt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetUserControlByPage(Utils.UserInfo, where, out recordCount, pageParam.PageIndex, pageParam.PageSize);
            var json = JSONhelper.FormatJSONForEasyuiDataGrid(recordCount, dt);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 得到所有用户表单列表
        /// </summary>
        /// <param name="ctx"></param>
        public void GetAllUserControl(HttpContext ctx)
        {
            var dt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllChildUserControls(Utils.UserInfo);
            var json = JSONhelper.ToJson(dt);
            ctx.Response.Write(json);
        }

        /// <summary>
        /// 得到主表单实体Json
        /// </summary>
        /// <param name="cxt"></param>
        public void GetMainUserControlEntity(HttpContext cxt)
        {
            string outputJson = string.Empty;
            string id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
            if (!string.IsNullOrEmpty(id))
            {
                var dtTemp = RDIFrameworkService.Instance.WorkFlowUserControlService.GetMainUserControl(Utils.UserInfo, id);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    var entity = BaseEntity.Create<MainUserControlEntity>(dtTemp);
                    outputJson = JSONhelper.ToJson(entity);
                }
            }
            cxt.Response.Write(outputJson);
        }

        /// <summary>
        /// 得到指定主表单所有子表单列表
        /// </summary>
        /// <param name="cxt"></param>
        public void GetAllChildUserControlsById(HttpContext cxt)
        {
            string outputJson = string.Empty;
            string id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("mainId"));
            if (!string.IsNullOrEmpty(id))
            {
                var dtTemp = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllChildUserControlsById(Utils.UserInfo, id);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    outputJson = JSONhelper.ToJson(dtTemp);
                }
            }
            cxt.Response.Write(outputJson);
        }

        private MainUserControlEntity GetPageMainUserControlEntity(MainUserControlEntity entity)
        {
            entity.FullName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FullName"));
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            return entity;
        }

        /// <summary>
        /// 增加主表单
        /// </summary>
        /// <param name="ctx"></param>
        private void AddMainForm(HttpContext ctx)
        {
            var entity = new MainUserControlEntity();
            var vUser = Utils.UserInfo;
            entity = this.GetPageMainUserControlEntity(entity);
            entity.Id = BusinessLogic.NewGuid();
            entity.DeleteMark = 0;
        
            try
            {
                var statusMessage = RDIFrameworkService.Instance.WorkFlowUserControlService.InsertMainUserCtrl(vUser, entity);
                ctx.Response.Write(!string.IsNullOrEmpty(statusMessage)
                    ? new JsonMessage { Success = true, Data = "1", Message = statusMessage }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "增加失败！" + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 修改主表单
        /// </summary>
        /// <param name="ctx"></param>
        private void EditMainForm(HttpContext ctx)
        {
            try
            {
                var returnValue = -1;
                var vUser = Utils.UserInfo;
                string id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
                MainUserControlEntity entity = null;
                if (!string.IsNullOrEmpty(id))
                {
                    var dtTemp = RDIFrameworkService.Instance.WorkFlowUserControlService.GetMainUserControl(Utils.UserInfo, id);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        entity = BaseEntity.Create<MainUserControlEntity>(dtTemp);
                        entity = this.GetPageMainUserControlEntity(entity);
                    }
                }
                returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.UpdateMainUserCtrl(vUser, entity);

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "修改成功！" }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = "修改失败" }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "操作失败！" + ex.Message }.ToString());
            }     
        }

        /// <summary>
        /// 删除主表单
        /// </summary>
        /// <param name="ctx"></param>
        private void DelMainForm(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
            try
            {
                var returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.SetDeletedMainUserCtrl(Utils.UserInfo, vId);

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }

        /// <summary>
        /// 增加子表单到主表单中
        /// </summary>
        /// <param name="ctx"></param>
        private void AddUserControlToMain(HttpContext ctx)
        {   
            try
            {
                string mainUserControlId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("mainId"));
                string userControlId  = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userControlId"));
                var returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.AddUserControls(Utils.UserInfo, mainUserControlId, userControlId, -1, "查看");
                ctx.Response.Write(!string.IsNullOrEmpty(returnValue) && returnValue.Length > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0009 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }

        /// <summary>
        /// 移除子表单从主表单中
        /// </summary>
        /// <param name="ctx"></param>
        private void RemoveUserControlFromMain(HttpContext ctx)
        {
            try
            {
                string mainUserControlId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("mainId"));
                string userControlId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userControlId"));
                var returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.MoveUserControls(Utils.UserInfo, mainUserControlId, userControlId);
                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 修改主表单下指定子表单的状态
        /// </summary>
        /// <param name="ctx"></param>
        private void EditMainUserControlsState(HttpContext ctx)
        {
            try
            {
                string mainUserControlId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("mainId"));
                string userControlId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("userControlId"));
                string controlState = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("controlState"));
                var returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.EditMainUserControlsState(Utils.UserInfo, mainUserControlId, userControlId, controlState);
                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "设置成功" }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            }
        }

        private UserControlsEntity GetPageUserControlEntity(UserControlsEntity entity)
        {
            entity.FullName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FullName"));
            entity.Type = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Type"));
            entity.Path = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Path"));
            entity.ControlId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("ControlId"));
            entity.FormName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("FormName"));
            entity.AssemblyName = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("AssemblyName"));
            entity.Enabled = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Enabled")) == "on" ? 1 : 0;
            entity.Description = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("Description"));
            return entity;
        }

        /// <summary>
        /// 增加子表单
        /// </summary>
        /// <param name="ctx"></param>
        private void AddChildForm(HttpContext ctx)
        {
            var entity = new UserControlsEntity();
            var vUser = Utils.UserInfo;
            entity = this.GetPageUserControlEntity(entity);
            entity.Id = BusinessLogic.NewGuid();
            entity.DeleteMark = 0;

            try
            {
                var statusMessage = RDIFrameworkService.Instance.WorkFlowUserControlService.InsertUserControl(vUser, entity);
                ctx.Response.Write(!string.IsNullOrEmpty(statusMessage)
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0009 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "增加失败！" + ex.Message }.ToString());
            }
        }

        /// <summary>
        /// 修改子表单
        /// </summary>
        /// <param name="ctx"></param>
        private void EditChildForm(HttpContext ctx)
        {
            try
            {
                var returnValue = -1;
                var vUser = Utils.UserInfo;
                string id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
                UserControlsEntity entity = null;
                if (!string.IsNullOrEmpty(id))
                {
                    var dtTemp = RDIFrameworkService.Instance.WorkFlowUserControlService.GetChildUserControl(Utils.UserInfo, id);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        entity = BaseEntity.Create<UserControlsEntity>(dtTemp);
                        entity = this.GetPageUserControlEntity(entity);
                    }
                }
                returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.UpdateUserControl(vUser, entity);

                ctx.Response.Write(returnValue> 0
                    ? new JsonMessage { Success = true, Data = "1", Message = "修改成功!" }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = "修改失败！" }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = "操作失败！" + ex.Message }.ToString());
            }     
        }

        /// <summary>
        /// 删除指定子表单
        /// </summary>
        /// <param name="ctx"></param>
        private void DelChildForm(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
            try
            {
                var returnValue = RDIFrameworkService.Instance.WorkFlowUserControlService.SetDeletedUserControl(Utils.UserInfo, vId);

                ctx.Response.Write(returnValue > 0
                    ? new JsonMessage { Success = true, Data = "1", Message = RDIFrameworkMessage.MSG0013 }.ToString()
                    : new JsonMessage { Success = false, Data = "0", Message = RDIFrameworkMessage.MSG3020 }.ToString());
            }
            catch (Exception ex)
            {
                ctx.Response.Write(new JsonMessage { Success = false, Data = "-1", Message = RDIFrameworkMessage.MSG3020 + ex.Message }.ToString());
            } 
        }

        /// <summary>
        /// 得到子表单实体Json
        /// </summary>
        /// <param name="cxt"></param>
        public void GetChildUserControlEntity(HttpContext cxt)
        {
            string outputJson = string.Empty;
            string id = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("keyId"));
            if (!string.IsNullOrEmpty(id))
            {
                var dtTemp = RDIFrameworkService.Instance.WorkFlowUserControlService.GetChildUserControl(Utils.UserInfo, id);
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    var entity = BaseEntity.Create<UserControlsEntity>(dtTemp);
                    outputJson = JSONhelper.ToJson(entity);
                }
            }
            cxt.Response.Write(outputJson);
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