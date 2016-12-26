using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.WorkFlow.Common
{
    using RDIFramework.BizLogic;

    public partial class DyAssignNext : BaseUserControl
    {
        string currentUserIds = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load();
        }

        public override void InitUserControl()
        {
            base.InitUserControl();
            DataTable tmpDt = RDIFrameworkService.Instance.WorkFlowInstanceService.GetTaskInsNextOperTable(Utils.UserInfo, WorkFlowId, WorkTaskId, WorkFlowInsId, WorkTaskInsId);
            if (tmpDt != null & tmpDt.Rows.Count > 0)
            {
                if (tmpDt.Rows.Count == 1)
                {
                    currentUserIds = tmpDt.Rows[0]["USERID"].ToString();
                }
                else
                {
                    for (int i = 0; i < tmpDt.Rows.Count - 1; i++)
                    {
                        currentUserIds += tmpDt.Rows[i]["USERID"].ToString() + ",";
                    }
                    currentUserIds = currentUserIds + tmpDt.Rows[tmpDt.Rows.Count - 1]["USERID"].ToString();
                }
            }
        }

        public override void SaveUserControl(bool IsDraft)
        {
            base.SaveUserControl(IsDraft);
            if (PageState == "查看")
            {
                return;
            }
            string selectedUsers = Request["Users"].ToString(CultureInfo.InvariantCulture);
            if (string.IsNullOrEmpty(selectedUsers))
            {
                return;
            }

            string[] users = selectedUsers.Split(',');
            foreach (string user in users)
            {
                var taskInsNextOperEntity = new WorkTaskInsNextOperEntity
                {
                    UserId = user,
                    UserName = RDIFrameworkService.Instance.UserService.GetEntity(Utils.UserInfo, user).RealName,
                    WorkFlowId = WorkFlowId,
                    WorkTaskId = WorkTaskId,
                    WorkFlowInsId = WorkFlowInsId,
                    WorkTaskInsId = WorkTaskInsId
                };
                string returnMessage = RDIFrameworkService.Instance.WorkFlowInstanceService.CreateWorkTaskInsNextOper(Utils.UserInfo,taskInsNextOperEntity);
            }
        }
    }
}