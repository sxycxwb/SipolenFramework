using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 权限设置-角色用户批量设置
    /// FrmRoleUserBatchSet
    /// 
    /// </summary>
    public partial class FrmRoleUserBatchSet : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetRoleId
        {
            get
            {
                string roleId = string.Empty;
                if (this.lstRole.SelectedItem != null)
                {
                    roleId = this.lstRole.SelectedValue.ToString();
                }
                return roleId;
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmRoleUserBatchSet()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("userEntites");
            this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;

            // 获得用户列表
            this.GetUserList();

            // 获得角色列表
            this.GetRoleList();

            this.isUserClick = true;
        }
        #endregion

        #region private void GetRoleList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        private void GetRoleList()
        {
            // 是否启用了权限范围管理
            this.DTRole = this.GetRoleScope(this.PermissionItemScopeCode);
            this.DTRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.lstRole.ValueMember = PiRoleTable.FieldId;
            this.lstRole.DisplayMember = PiRoleTable.FieldRealName;
            this.lstRole.DataSource = this.DTRole.DefaultView;
        }
        #endregion

        #region private void GetUserList() 获取用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void GetUserList()
        {
            // 是否启用了权限范围管理
            this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[PiUserTable.FieldRealName] = dataRow[PiUserTable.FieldUserName] + " [" + dataRow[PiUserTable.FieldRealName] + "]";
            }
            this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            this.cklstUser.DataSource = this.DTUser.DefaultView;
            this.cklstUser.ValueMember = PiUserTable.FieldId;
            this.cklstUser.DisplayMember = PiUserTable.FieldRealName;
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;
            // 角色被选中状态取消
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                this.cklstUser.SetItemChecked(i, false);
            }
            // 这些空间可以用了
            this.cklstUser.Enabled = true;
            // 获取角色的权限
            this.GetRolePermission();
            this.isUserClick = true;
            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
        }

        private void lstRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.GetCurrentPermission();
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

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetRolePermission()
        {
            // 获取当权角色中的用户列表
            this.GetRoleUsers();
        }

        /// <summary>
        /// 获取当权角色中的用户列表
        /// </summary>
        private void GetRoleUsers()
        {
            // 获取当前角色中的用户
            var userIds = RDIFrameworkService.Instance.RoleService.GetRoleUserIds(this.UserInfo, this.TargetRoleId);
            // 把当前的用户设置为选中状态
            for (int i = 0; i < this.cklstUser.Items.Count; i++)
            {
                var userId = ((System.Data.DataRowView)this.cklstUser.Items[i])[PiUserTable.FieldId].ToString();
                if (Array.IndexOf(userIds, userId) >= 0)
                {
                    this.cklstUser.SetItemChecked(i, true);
                }
            }
        }

        private void cklstUser_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*
            if (this.isUserClick)
            {
                bool itemChecked = this.cklstUser.GetItemChecked(this.cklstUser.SelectedIndex);
                string userId = ((System.Data.DataRowView)this.cklstUser.Items[e.Index])[BaseUserEntity.FieldId].ToString();
                if (itemChecked)
                {
                    // 被撤销了
                    RDIFrameworkService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, this.TargetRoleId, new string[] { userId });
                }
                else
                {
                    RDIFrameworkService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, new string[] { userId });
                }
            }
            */
        }

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0200) != DialogResult.Yes) return;
            RDIFrameworkService.Instance.RoleService.ClearRoleUser(this.UserInfo, this.TargetRoleId);
            this.GetCurrentPermission();
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            var userEntites = (from object t in this.cklstUser.CheckedItems select BaseEntity.Create<PiUserEntity>(((System.Data.DataRowView) t).Row)).ToList();
            // 复制到剪切板
            Clipboard.SetData("userEntites", userEntites);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userEntites");
            if (clipboardData == null) return;
            var userEntites = (List<PiUserEntity>)clipboardData;
            string[] addUserIds = new string[userEntites.Count];
            for (int i = 0; i < userEntites.Count; i++)
            {
                addUserIds[i] = userEntites[i].Id.ToString();
            }
            // 添加用户到角色
            RDIFrameworkService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, addUserIds);
            // 获取当前的权限设置
            this.GetCurrentPermission();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void Save()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.btnSave.Enabled = false;
                // 将原来的角色移出，获取当前角色中的用户
                string[] userIds = RDIFrameworkService.Instance.RoleService.GetRoleUserIds(this.UserInfo, this.TargetRoleId);
                RDIFrameworkService.Instance.RoleService.RemoveUserFromRole(this.UserInfo, this.TargetRoleId, userIds);
                // 将新的角色添加到用户
                var userEntites = (from object t in this.cklstUser.CheckedItems select BaseEntity.Create<PiUserEntity>(((System.Data.DataRowView) t).Row)).ToList();
                string[] addUserIds = new string[userEntites.Count];
                for (int i = 0; i < userEntites.Count; i++)
                {
                    addUserIds[i] = userEntites[i].Id.ToString();
                }

                // 添加用户到角色
                if (RDIFrameworkService.Instance.RoleService.AddUserToRole(this.UserInfo, this.TargetRoleId, addUserIds) > 0)
                {
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
                }

                this.btnSave.Enabled = true;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
