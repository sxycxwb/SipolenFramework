using System;
using System.Web;
using System.Web.SessionState;

namespace RDIFramework.WebApp.Modules.hander
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WebCommon;

    /// <summary>
    /// StaffAdminHandler 的摘要说明
    /// </summary>
    public class StaffAdminHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("action")))
            {
                case "SubmitForm":
                    SubmitForm(context);
                    break;
                case "DeleteStaff":
                    DeleteStaff(context);
                    break;               
                case "GetEntity":
                    context.Response.Write(JSONhelper.ToJson(RDIFrameworkService.Instance.StaffService.GetEntity(Utils.UserInfo,PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId")))));
                    break;
                case "MoveTo":
                    MoveTo(context);
                    break;
                default:
                    GetDataList(context);
                    break;
            }
        }

        /// <summary>
        /// 提交表单（增加或修改）
        /// </summary>
        /// <param name="context"></param>
        private void SubmitForm(HttpContext context)
        {
            try
            {
                int IsOk = 1;
                var key = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("key"));
                var json = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("json"));
                UserInfo curUser = Utils.UserInfo;
                var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("OrganizeId"));
                var entity = JsonHelper.JSONToObject<PiStaffEntity>(json);
                if (string.IsNullOrEmpty(key))
                {
                    //增加
                    entity.CreateBy = curUser.RealName;
                    entity.CreateUserId = curUser.Id;
                    string statusCode, statusMessage;
                    string returnKey = string.IsNullOrEmpty(organizeId) ? RDIFrameworkService.Instance.StaffService.Add(curUser, entity, out statusCode, out statusMessage) : RDIFrameworkService.Instance.StaffService.Add(curUser, entity, out statusCode, out statusMessage, organizeId);
                    context.Response.Write(statusCode == StatusCode.OKAdd.ToString()
                        ? new JsonMessage { Success = true, Data = returnKey, Message = statusMessage }.ToString()
                        : new JsonMessage { Success = false, Data = "0", Message = statusMessage }.ToString());
                }
                else
                {
                    var updateEntity = RDIFrameworkService.Instance.StaffService.GetEntity(curUser, key);
                    if (updateEntity != null)
                    {
                        updateEntity.RealName = entity.RealName;
                        updateEntity.UserName = RDIFramework.Utilities.StringHelper.ToChineseSpell(updateEntity.RealName);
                        updateEntity.Code = entity.Code;
                        updateEntity.Gender = entity.Gender;
                        updateEntity.Birthday = entity.Birthday;
                        updateEntity.Age = entity.Age;
                        updateEntity.Major = entity.Major;
                        updateEntity.School = entity.School;
                        updateEntity.Education = entity.Education;
                        updateEntity.Degree = entity.Degree;
                        updateEntity.Title = entity.Title;
                        updateEntity.TitleLevel = entity.TitleLevel;
                        updateEntity.TitleDate = entity.TitleDate;
                        updateEntity.WorkingProperty = entity.WorkingProperty;
                        updateEntity.WorkingDate = entity.WorkingDate;
                        updateEntity.IdentificationCode = entity.IdentificationCode;
                        updateEntity.BankCode = entity.BankCode;
                        updateEntity.JoinInDate = entity.JoinInDate;
                        updateEntity.Email = entity.Email;
                        updateEntity.Mobile = entity.Mobile;
                        updateEntity.ShortNumber = entity.ShortNumber;
                        updateEntity.QICQ = entity.QICQ;
                        updateEntity.OfficeZipCode = entity.OfficeZipCode;
                        updateEntity.OfficePhone = entity.OfficePhone;
                        updateEntity.OfficeFax = entity.OfficeFax;
                        updateEntity.OfficeAddress = entity.OfficeAddress;
                        updateEntity.NativePlace = entity.NativePlace;
                        updateEntity.HomeZipCode = entity.HomeZipCode;
                        updateEntity.HomeFax = entity.HomeFax;
                        updateEntity.Party = entity.Party;
                        updateEntity.Nation = entity.Nation;
                        updateEntity.Nationality = entity.Nationality;
                        updateEntity.HomePhone = entity.HomePhone;
                        updateEntity.Telephone = entity.Telephone;
                        updateEntity.HomeAddress = entity.HomeAddress;
                        updateEntity.DimissionDate = entity.DimissionDate;
                        updateEntity.DimissionWhither = entity.DimissionWhither;
                        updateEntity.DimissionCause = entity.DimissionCause;
                        updateEntity.IsDimission = entity.IsDimission;
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
                    RDIFrameworkService.Instance.StaffService.UpdateStaff(curUser, updateEntity, out statusCode, out statusMessage);
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

        #region private void DeleteStaff(HttpContext ctx) 删除员工（职员）
        /// <summary>
        /// 删除员工（职员）
        /// </summary>
        /// <param name="ctx">http请求信息</param>
        private void DeleteStaff(HttpContext ctx)
        {
            var vId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("KeyId"));
            var vUser = Utils.UserInfo;

            var successFlag = 0;
            try
            {
                var returnValue = RDIFrameworkService.Instance.StaffService.SetDeleted(Utils.UserInfo, new string[] { vId });

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

        private void GetDataList(HttpContext context)
        {      
            var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeId"));
            var json = "[]";
            if(!string.IsNullOrEmpty(organizeId))
            {
                var dtStaff = RDIFrameworkService.Instance.StaffService.GetDTByOrganize(Utils.UserInfo, organizeId, true);
                json = JSONhelper.ToJson(dtStaff);
            }
            context.Response.Write(json);
        }

        private void MoveTo(HttpContext ctx)
        {
            var organizeId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("organizeId"));
            var staffId = PublicMethod.GetString(WebCommon.StringHelper.GetRequestObject("staffId"));
            try
            {
                var returnValue = RDIFrameworkService.Instance.StaffService.MoveTo(Utils.UserInfo, staffId, organizeId);
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
    }
}