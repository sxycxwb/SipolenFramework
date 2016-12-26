using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmTaskAssign.cs
    /// 任务指派
    /// 
    /// </summary>
    public partial class FrmTaskAssign : BaseForm
    {
        public FrmTaskAssign()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择的用户主键
        /// </summary>
        private string SelectedId { set; get; }

        /// <summary>
        /// 操作者实例主键
        /// </summary>
        public string OperatorInstanceId { set; get; }

        private void SelectAct(string[] userIds, string organizeId, string roleId)
        {
            var frmUserSelect = new FrmUserSelect
            {
                MultiSelect = false,
                UserIds = userIds,
                OrganizeId = organizeId,
                RoleId = roleId,
                AllowNull = true,
                PermissionScopeCode = "Resource.ManagePermission"
            };

            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = frmUserSelect.SelectedId;
                this.txtFullName.Text = frmUserSelect.SelectedFullName;
            }
        }

        private void txtFullName_ButtonCustomClick(object sender, EventArgs e)
        {
            this.SelectAct(null, null, null);
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SelectedId))
            {
                MessageBoxHelper.ShowWarningMsg("请选择待指派的用户！");
                return;
            }

            try
            {
                var wfRuntime = new WorkFlowRuntime
                {
                    UserId = this.UserInfo.Id,
                    AssignUserId = this.SelectedId,
                    OperatorInstanceId = OperatorInstanceId,
                    CurrentUser = this.UserInfo
                };
                string statusCode = wfRuntime.TaskAssign();
                if (statusCode == WorkFlowConst.SuccessCode)
                {
                    MessageBoxHelper.ShowSuccessMsg("指派成功!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBoxHelper.ShowErrorMsg("指派失败，请检查传递的参数是否正确!");
                }
            }
            catch(Exception ex)
            {
                this.ProcessException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
