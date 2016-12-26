using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace RDIFramework.WebApp
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// BaseUserControl 的摘要说明
    /// 每个用户控件必须处理好三种情况，1新建，2修改，3查看
    /// </summary>
    public class BaseUserControl : System.Web.UI.UserControl, IBaseUserControl
    {
        /// <summary>
        /// 流程错误提示
        /// </summary>
        public virtual string WorkFlowError { get; set; }

        /// <summary>
        /// 流程是否正常
        /// </summary>
        public virtual bool WorkFlowIsOk { get; set; }

        /// <summary>
        /// 工作流模板Id
        /// </summary>
        public virtual string WorkFlowId { get; set; }

        /// <summary>
        /// 任务模板Id
        /// </summary>
        public virtual string WorkTaskId { get; set; }

        /// <summary>
        /// 工作流实例Id
        /// </summary>
        public virtual string WorkFlowInsId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public virtual string WorkTaskInsId { get; set; }

        /// <summary>
        /// 操作实例Id
        /// </summary>
        public virtual string OperatorInsId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public virtual string UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public virtual string DutyCaption { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual string ArchCaption { get; set; }

        /// <summary>
        /// 用户控件的状态,新建，修改，查看
        /// </summary>
        public virtual string CtrlState { get; set; }

        /// <summary>
        /// 表单状态,新建，修改，查看
        /// </summary>
        public virtual string PageState { get; set; }

        /// <summary>
        /// 草稿
        /// </summary>
        public virtual bool IsDraft { get; set; }

        private IDbProvider workFlowdbProvider = null;
        /// <summary>
        /// 工作流数据库部分
        /// </summary>
        public IDbProvider WorkFlowDbProvider
        {
            get
            {
                return workFlowdbProvider ?? (workFlowdbProvider = DbFactoryProvider.GetProvider(SystemInfo.WorkFlowDbType, SystemInfo.WorkFlowDbConnection));
            }
        }

        public BaseUserControl()
        {
            this.IsDraft = false;
            this.WorkFlowIsOk = true;
        }
        /// <summary>
        /// 初始化流程信息
        /// </summary>
        public virtual void Page_Load()
        {
            UserInfo curUser = Utils.UserInfo;
            UserId = curUser.Id;

            /*
            PiUserEntity userEntity = RDIFrameworkService.Instance.UserService.GetEntity(curUser, UserId);
            if (userEntity != null)
            {
                UserName = userEntity.RealName;
                DutyCaption = userEntity.Duty;
                ArchCaption = userEntity.DepartmentName;
            }
            */

            UserName = curUser.RealName;
            DutyCaption = string.Empty;
            ArchCaption = curUser.DepartmentName;
        }

        public void SetReadOnly(Control ctrl)
        {
            if (CtrlState == WorkConst.STATE_VIEW)
            {
                foreach (Control c in ctrl.Controls)
                {
                    string ctrlTypeName = c.GetType().Name;
                    switch (ctrlTypeName)
                    {
                        case "Button": 
                            (c as Button).Enabled = false;
                            break;
                        case "DropDownList":
                            (c as DropDownList).Enabled = false;
                            break;
                        case "TextBox":
                            (c as TextBox).ReadOnly = true;
                            break;
                    }
                    if (c.HasControls())
                        SetReadOnly(c);
                }
            }
        }

        public virtual void InitUserControl()
        {
            SetReadOnly(this);
        }
        
        public virtual void SaveUserControl(bool isDraft)
        {
            this.IsDraft = isDraft;
        }
    }
}
