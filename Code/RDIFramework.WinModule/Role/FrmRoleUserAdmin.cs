/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:57:55
 ******************************************************************************/

using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmRoleUserAdmin
    /// 角色-用户关联窗体
    /// 
    /// 修改记录
    /// </summary>
    public partial class FrmRoleUserAdmin : BaseForm
    {
        private DataTable DTUser = new DataTable(PiUserTable.TableName);     // 用户列表 DataTable

        // 角色主键
        private string TargetRoleId
        {
            set
            {
                this.txtRoleName.Tag = value;
            }
            get
            {
                return this.txtRoleName.Tag.ToString();
            }
        }

        // 角色名称     
        private string TargetRoleName
        {
            set
            {
                this.txtRoleName.Text = value;
            }
            get
            {
                return this.txtRoleName.Text;
            }
        }

        public FrmRoleUserAdmin()
        {
            InitializeComponent();
        }

        public FrmRoleUserAdmin(string roleId, string roleName)
            : this()
        {
            this.TargetRoleId   = roleId;
            this.TargetRoleName = roleName;
        }

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            if (this.TargetRoleId.Length > 0)
            {
                this.txtRoleName.Tag           = this.TargetRoleId;
                this.txtRoleName.Text          = this.TargetRoleName;
            }
            // 加载员工数据主键
            // 往DataTable中添加选择列
            BasePageLogic.DataTableAddColumn(this.DTUser, "colSelected");
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.DataSource = this.DTUser.DefaultView;

        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.LoadUserParameters = false; //替换掉DataGridView的默认菜单
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvInfo);
            // 获得员工数据
            this.DTUser = RDIFrameworkService.Instance.UserService.GetDTByRole(UserInfo, this.TargetRoleId);
            // 绑定屏幕数据
            this.BindData();
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvInfo, PiUserTable.FieldId, "colSelected", true);
        }
        #endregion

        #region private int BatchRemove() 批量移出
        /// <summary>
        /// 批量移出
        /// </summary>
        /// <returns>影响行数</returns>
        private int BatchRemove()
        {
            int returnValue = 0;
            this.FormLoaded = false;
            returnValue = RDIFrameworkService.Instance.RoleService.RemoveUserFromRole(UserInfo, this.TargetRoleId, this.GetSelecteIds());
            // 绑定数据
            this.FormOnLoad();
            // 设置按钮状态
            this.SetControlState();
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frmUserSelect = new FrmUserSelect {MultiSelect = true};
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                RDIFrameworkService.Instance.RoleService.AddUserToRole(UserInfo, this.TargetRoleId, frmUserSelect.SelectedIds);
                this.Changed = true;
                // 加载窗体
                this.FormOnLoad();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.CheckInputSelectAnyOne(this.dgvInfo, "colSelected")) return;
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0075) != System.Windows.Forms.DialogResult.Yes) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.BatchRemove();
                this.Changed = true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = this.Changed ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void cmnuInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }
    }
}
