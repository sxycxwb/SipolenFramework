using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using DevComponents.Editors.DateTimeAdv;
    using RDIFramework.BizLogic;
    using RDIFramework.Controls;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmBaseBizeForm : BaseForm
    {
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

        /// <summary>
        /// 流程错误提示
        /// </summary>
        public virtual string WFErrorHint { get; set; }


        private bool wfIsOk = true;
        /// <summary>
        /// 流程是否正常
        /// </summary>
        public virtual bool WFIsOk
        {
            get { return this.wfIsOk; }
            set { this.wfIsOk = value; }
        }


        public FrmBaseBizeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化流程信息
        /// </summary>
        public virtual void Form_Load()
        {
            UserId = this.UserInfo.Id;
            PiUserEntity userEntity = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo,UserId);
            if (userEntity != null)
            {
                UserName = userEntity.RealName;
                DutyCaption = userEntity.Duty;
                ArchCaption = userEntity.DepartmentName;
            }
        }

        public void SetReadOnly(Control ctrl)
        {
            if (CtrlState == WorkConst.STATE_VIEW)
            {
                foreach (Control c in ctrl.Controls)
                {
                    if (c == null)
                    {
                        break;
                    }

                    string ctrlTypeName = c.GetType().Name;
                    switch (ctrlTypeName)
                    {
                        case "Button":
                            (c as Button).Enabled = false;
                            break;
                        case "TextBox":
                            (c as TextBox).ReadOnly = true;
                            break;
                        case "DateTimeInput":
                            (c as DateTimeInput).Enabled = false;
                            break;
                        case "UcTextBox":
                            (c as UcTextBox).ReadOnly = true;
                            break;
                        case "UcComboBoxEx":
                            (c as UcComboBoxEx).Enabled = false;
                            break;
                    }

                    if (c.Controls.Count > 0)
                    {
                        SetReadOnly(c);
                    }
                }
            }
        }

        public virtual void InitUserControl()
        {
            SetReadOnly(this);
        }

        public virtual void SaveFormData(bool isDraft)
        {
            this.IsDraft = isDraft;
        }
    }
}
