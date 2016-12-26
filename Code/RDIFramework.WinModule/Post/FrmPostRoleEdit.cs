using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmPostRoleEdit.cs
    /// 岗位管理-编辑岗位窗体
    /// 
    /// 
    /// </summary>
    public partial class FrmPostRoleEdit : BaseForm
    {
        /// <summary>
        /// 岗位实体
        /// </summary>
        private PiRoleEntity  roleEntity = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private string PermissionScopeCode = "Resource.ManagePermission";

        public FrmPostRoleEdit()
        {
            InitializeComponent();
        }

        public FrmPostRoleEdit(string id)
            : this()
        {
            this.EntityId = id;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 按组织机构管理来增加员工
            this.ucOrganize.PermissionScopeCode = this.PermissionScopeCode;
            this.ucOrganize.AllowNull = false;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.roleEntity = RDIFrameworkService.Instance.RoleService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            this.ucUserSelect.OrganizeId = this.roleEntity.OrganizeId;
            // 焦点定位
            this.ActiveControl = this.txtRealName;
            this.txtRealName.SelectAll();
            this.txtRealName.Focus();
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtRealName.Text = roleEntity.RealName;
            this.ucOrganize.SelectedId = roleEntity.OrganizeId;
            this.txtCode.Text = roleEntity.Code;
            this.chkEnabled.Checked = roleEntity.Enabled.ToString().Equals("1");
            this.txtDescription.Text = roleEntity.Description;
            // 获取用户中的角色
            this.ucUserSelect.SelectedIds = RDIFrameworkService.Instance.RoleService.GetRoleUserIds(UserInfo, this.EntityId);
            // 这里需要进行判断，数据是否被其他人已经删除
            if (string.IsNullOrEmpty(roleEntity.Id))
            {
                MessageBoxHelper.ShowInformationMsg(RDIFrameworkMessage.MSG0005);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool result = true;
            if (this.ucOrganize.SelectedFullName == null)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9978));
                this.ucOrganize.Focus();
                return false;
            }
            this.txtRealName.Text = this.txtRealName.Text.TrimEnd();
            if (this.txtRealName.Text.Trim().Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9978));
                this.txtRealName.Focus();
                return false;
            }
            return result;
        }
        #endregion

        #region private BaseRoleEntity GetObject()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>岗位实体</returns>
        private PiRoleEntity GetObject()
        {
            roleEntity.OrganizeId = this.ucOrganize.SelectedId;
            roleEntity.Code = this.txtCode.Text;
            roleEntity.RealName = this.txtRealName.Text;
            roleEntity.Description = this.txtDescription.Text;
            roleEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            return roleEntity;
        }
        #endregion

        #region private void ClearForm()
        /// <summary>
        /// 清除窗体
        /// </summary>
        private void ClearForm()
        {
            this.txtCode.Text = string.Empty;
            this.txtRealName.Text = string.Empty;
            this.txtDescription.Text = string.Empty;
            this.txtRealName.Focus();
        }
        #endregion

        #region public override void SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool result = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.GetObject();
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            RDIFrameworkService.Instance.RoleService.Update(UserInfo, this.roleEntity, out statusCode, out statusMessage);
            RDIFrameworkService.Instance.RoleService.ClearRoleUser(UserInfo, this.EntityId);
            if (this.ucUserSelect.SelectedIds != null && this.ucUserSelect.SelectedIds.Length > 0)
            {
                RDIFrameworkService.Instance.RoleService.SetUsersToRole(UserInfo, this.EntityId, this.ucUserSelect.SelectedIds);
            }
            
            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (SystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                this.DialogResult = DialogResult.OK;
                result = true;
            }
            else
            {
                MessageBoxHelper.ShowInformationMsg(statusMessage);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtRealName.SelectAll();
                    this.txtRealName.Focus();
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return result;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态，并保留原先的状态
                Cursor holdCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        // 关闭窗口
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
