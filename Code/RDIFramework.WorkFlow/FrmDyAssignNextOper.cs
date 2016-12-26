using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.WinForm.Utilities;
    using RDIFramework.BizLogic;

    /// <summary>
    /// FrmDyAssignNextOper
    /// 动态指定下一处理人
    /// 
    /// </summary>
    public partial class FrmDyAssignNextOper : FrmBaseBizeForm
    { 
        private string selectedId = null;
        /// <summary>
        /// 被选中的用户主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
                this.txtFullName.Text = string.Empty;
                if (!string.IsNullOrEmpty(this.selectedId))
                {
                    var Service = new RDIFrameworkService();
                    PiUserEntity entity = Service.UserService.GetEntity(UserInfo, this.selectedId);
                    if (Service.OrganizeService is ICommunicationObject)
                    {
                        ((ICommunicationObject)Service.UserService).Close();
                    }
                    this.txtFullName.Text = entity != null ? entity.RealName : string.Empty;
                }
            }
        }

        public delegate void DyAssignSuccessEventHandler(Object sender, EventArgs e);
       
        /// <summary>
        /// 动态指定成功执行的代码
        /// </summary>
        public event DyAssignSuccessEventHandler DyAssignSuccess;

        public FrmDyAssignNextOper()
        {
            InitializeComponent();
        }

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
                MessageBoxHelper.ShowWarningMsg("请至少选择一个用户！");
                return;
            }

            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
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
