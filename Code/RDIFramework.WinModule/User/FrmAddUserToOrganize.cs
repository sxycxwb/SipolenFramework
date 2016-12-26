using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmAddUserToOrganize.cs
    /// 添加用户到组织机构（用户-组织机构关系设置）
    /// 
    /// </summary>
    public partial class FrmAddUserToOrganize : BaseForm
    {
        private string userId = string.Empty;
        /// <summary>
        /// 目标用户主键
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public FrmAddUserToOrganize(string userId)
            : this()
        {
            this.UserId = userId;
        }

        public FrmAddUserToOrganize()
        {
            InitializeComponent();
        }

        public override void SetControlState()
        {
            this.txtCompany.AllowNull = false;
            this.txtCompany.MultiSelect = false;
            this.txtDepartment.AllowNull = true;
            this.txtDepartment.MultiSelect = false;
            this.txtWorkGroup.AllowNull = true;
            this.txtWorkGroup.MultiSelect = false;
            this.chkEnabled.Enabled = this.chkEnabled.Checked = this.UserInfo.IsAdministrator;
        }

        public override void FormOnLoad()
        {
            // 获取用户信息
            this.ShwoEntity();
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <returns>用户实体</returns>
        private PiUserEntity ShwoEntity()
        {
            var userEntity = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.UserId);
            this.txtUserName.Text = userEntity.UserName;
            this.txtRealName.Text = userEntity.RealName;
            return userEntity;
        }

        public override bool CheckInput()
        {
            if (this.txtCompany.SelectedFullName.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0229);
                this.txtCompany.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取用户组织机构数据
        /// </summary>
        /// <returns>用户组织机构实体</returns>
        private PiUserOrganizeEntity GetUserOrganizeEntity()
        {
            var userOrganizeEntity = new PiUserOrganizeEntity
            {
                UserId = !string.IsNullOrEmpty(this.UserId) ? this.UserId : null,
                CompanyId = !string.IsNullOrEmpty(this.txtCompany.SelectedId) ? this.txtCompany.SelectedId : null,
                SubCompanyId =!string.IsNullOrEmpty(this.txtSubCompany.SelectedId) ? this.txtSubCompany.SelectedId : null,
                DepartmentId =!string.IsNullOrEmpty(this.txtDepartment.SelectedId) ? this.txtDepartment.SelectedId : null,
                SubDepartmentId =!string.IsNullOrEmpty(this.txtSubDepartment.SelectedId) ? this.txtSubDepartment.SelectedId : null,
                WorkgroupId = !string.IsNullOrEmpty(this.txtWorkGroup.SelectedId) ? this.txtWorkGroup.SelectedId : null,
                Enabled = this.chkEnabled.Checked ? 1 : 0,
                Description = this.txtDescription.Text,
                DeleteMark = 0
            };
            return userOrganizeEntity;
        }

        private bool AddToOrganize()
        {
            bool result = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            PiUserOrganizeEntity userOrganizeEntity = this.GetUserOrganizeEntity();
            this.EntityId = RDIFrameworkService.Instance.UserService.AddUserToOrganize(this.UserInfo, userOrganizeEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 没审核通过的，才可以有提示信息
                if (SystemInfo.ShowInformation && !this.chkEnabled.Checked)
                {
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0235);
                }
                result = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (statusCode == StatusCode.Exist.ToString())
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0008, RDIFrameworkMessage.MSG9971));
                }
            }
            return result;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                this.AddToOrganize();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
