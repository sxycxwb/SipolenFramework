using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmPostRoleAdd.cs
    /// 岗位管理-添加岗位窗体
    /// 
    /// 
    /// </summary>
    public sealed partial class FrmPostRoleAdd : BaseForm
    {
        /// <summary>
        /// 岗位实体
        /// </summary>
        private PiRoleEntity  roleEntity = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
        private const string PermissionScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 被选中的组织机构主键
        /// </summary>
        public string OrganizeId
        {
            get
            {
                return this.ucOrganize.SelectedId;
            }
            set
            {
                this.ucOrganize.SelectedId = value;
            }
        }

        /// <summary>
        /// 被选中的组织机构全名
        /// </summary>
        public string OrganizeFullName
        {
            get
            {
                return this.ucOrganize.SelectedFullName;
            }
            set
            {
                this.ucOrganize.SelectedFullName = value;
            }
        }

        public FrmPostRoleAdd()
        {
            InitializeComponent();
        }

        public FrmPostRoleAdd(string id)
            : this()
        {
            this.EntityId = id;
        }

        public FrmPostRoleAdd(string organizeId, string organizeFullName)
            : this(string.Empty)
        {
            this.OrganizeId = organizeId;
            this.OrganizeFullName = organizeFullName;
            this.ucUserSelect.OrganizeId = organizeId;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 按组织机构管理来增加员工
            this.ucOrganize.PermissionScopeCode = PermissionScopeCode;
            this.ucOrganize.AllowNull = false;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 焦点定位
            this.ActiveControl = this.txtRealName;
            this.txtRealName.Focus();
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetObject();
            string roleId = RDIFrameworkService.Instance.RoleService.Add(UserInfo, this.roleEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                RDIFrameworkService.Instance.RoleService.ClearRoleUser(UserInfo, this.EntityId);
                if (this.ucUserSelect.SelectedIds != null && this.ucUserSelect.SelectedIds.Length > 0)
                {
                    RDIFrameworkService.Instance.RoleService.AddUserToRole(UserInfo, roleId, this.ucUserSelect.SelectedIds);
                }
                // 有数据被改变过
                this.Changed = true;
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                result = true;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
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

        #region private BaseRoleEntity GetObject()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>岗位实体</returns>
        private PiRoleEntity GetObject()
        {
            roleEntity = new PiRoleEntity
            {
                OrganizeId = this.ucOrganize.SelectedId,
                Code = this.txtCode.Text,
                RealName = this.txtRealName.Text,
                Category = "Duty",
                Description = this.txtDescription.Text,
                Enabled = 1,
                AllowDelete = 1,
                AllowEdit = 1,
                DeleteMark = 0
            };
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

        #region private void AddRole(bool close = true)
        /// <summary>
        /// 保存岗位
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void AddRole(bool close = true)
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
                        if (close)
                        {
                            this.DialogResult = DialogResult.OK;
                            // 关闭窗口
                            this.Close();
                        }
                        else
                        {
                            this.ClearForm();
                        }
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
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AddRole(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
