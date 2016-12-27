/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-4 10:26:40
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserRoleAdmin
    /// 
    /// 角色－员工管理窗体
    /// </summary>
    public partial class FrmUserRoleAdmin : BaseForm
    {
        /// <summary>
        /// 访问权限
        /// </summary>
        //private bool permissionAccess = false;


        /// <summary>
        /// 用户授权
        /// </summary>
        //private bool permissionAccredit = false;

        // 角色列表 DataTable
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);
        private string[] roleIds = null;

        /// <summary>
        /// 权限域编号
        /// </summary>
       // private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户主键
        /// </summary>
        private string TargetUserId
        {
            set
            {
                txtUser.SelectedValue = value;
            }
            get
            {
                return txtUser.SelectedValue.ToString();
            }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>    
        private string TargetUserRealName
        {
            set
            {
                this.txtUser.Text = value;
            }
            get
            {
                return this.txtUser.Text;
            }
        }

        public FrmUserRoleAdmin()
        {
            InitializeComponent();
        }

        public FrmUserRoleAdmin(string userId)
            : this()
        {
            this.TargetUserId = userId;
        }

        public FrmUserRoleAdmin(string userId, string realName)
            : this()
        {
            this.TargetUserId = userId;
            this.TargetUserRealName = realName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {        
            //this.btnRemove.Enabled = false;
            //this.btnSelectAll.Enabled = false;
            //this.btnInvertSelect.Enabled = false;
            //this.btnRolePermission.Enabled = false;
            //this.btnAddToRole.Enabled = this.permissionEdit;

            //if (this.DTRole.Rows.Count > 0)
            //{
            //    this.btnSelectAll.Enabled = this.permissionEdit;
            //    this.btnInvertSelect.Enabled = this.permissionEdit;
            //    this.btnRemove.Enabled = this.permissionDelete;
            //    this.btnRolePermission.Enabled = this.permissionAccredit;
            //}
            
            //// 这里判断是否有数据被复制
            //this.btnCopy.Enabled = this.dgvInfo.RowCount > 0;
            //object clipboardData = Clipboard.GetData("roleEntites");
            //this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region private void BindData() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        private void BindData()
        {
            // 加载员工数据主键

            // 往DataTable中添加选择列
            //BasePageLogic.DataTableAddColumn(this.DTRole, "colSelected");
            this.dgvInfo.AutoGenerateColumns = false;
            this.dgvInfo.DataSource          = null;
            this.dgvInfo.DataSource          = this.DTRole.DefaultView;
            // 设定选中状态
            // foreach (DataRowView dataRowView in this.DTRole.DefaultView)
            // {
            //     bool selected = Array.IndexOf(this.RoleIds, dataRowView.Row[PiRoleTable.FieldId].ToString()) >= 0;
            //     dataRowView.Row[BusinessLogic.SelectedColumn] = selected.ToString();
            // }
            // this.DTRole.AcceptChanges();
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            //this.permissionAccess   = this.IsModuleAuthorized("RoleAdmin");
            //this.permissionAdd      = this.IsAuthorized("RoleAdmin.Add");
            //this.permissionEdit     = this.IsAuthorized("RoleAdmin.Edit");
            //this.permissionDelete   = this.IsAuthorized("RoleAdmin.Delete");
            //this.permissionAccredit = this.IsAuthorized("UserManagement.Accredit");
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.LoadUserParameters = false;
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvInfo);
            // 获得角色数据
            // this.DTRole = RDIFrameworkService.Instance.RoleService.GetList(UserInfo);
            this.roleIds = RDIFrameworkService.Instance.UserService.GetUserRoleIds(UserInfo, this.TargetUserId);
            this.DTRole = RDIFrameworkService.Instance.RoleService.GetDTByIds(UserInfo, this.roleIds);
            // 获得角色列表
            this.GetRoles();           
            this.BindData();
        }
        #endregion

        private void ucUser_SelectedIndexChanged(string parentId)
        {
            this.FormOnLoad();
        }

        #region private void GetRoles() 获得角色列表
        /// <summary>
        /// 获得角色列表
        /// </summary>
        private void GetRoles()
        {
            // 绑定类型数据
            DataTable dataTable = RDIFrameworkService.Instance.UserService.GetRoleDT(UserInfo);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            this.cboRole.DisplayMember = PiRoleTable.FieldRealName;
            this.cboRole.ValueMember = PiRoleTable.FieldId;
            this.cboRole.DataSource = dataTable;
           
            // 加载用户，显示用户的默认角色
            PiUserEntity userEntity = RDIFrameworkService.Instance.UserService.GetEntity(UserInfo, this.txtUser.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(userEntity.RoleId))
            {
                this.cboRole.SelectedValue = userEntity.RoleId;
            }
            else
            {
                this.cboRole.Text = string.Empty;
            }
        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }

        #region private bool BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool BatchSave()
        {
            var returnValue = true;
            string addToRoles = string.Empty;
            string removeFormRoles = string.Empty;

            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)
            {
                var rowView = dgvRow.DataBoundItem as DataRowView;
                if (rowView == null) continue;
                DataRow dataRow = rowView.Row;
                if (dataRow.RowState == DataRowState.Modified)
                {
                    if ((System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false))
                    {
                        // 添加了权限
                        addToRoles += dataRow[PiRoleTable.FieldId].ToString() + ";";
                    }
                    else
                    {
                        // 删除了权限
                        removeFormRoles += dataRow[PiRoleTable.FieldId].ToString() + ";";
                    }
                }
            }

            // 设定选中状态
            //foreach (DataRow dataRow in this.DTRole.Rows)
            //{
            //    if (dataRow.RowState == DataRowState.Modified)
            //    {
            //        if (dataRow["colSelected"].ToString().Equals(true.ToString()))
            //        {
            //            // 添加了权限
            //            addToRoles += dataRow[PiRoleTable.FieldId].ToString() + ";";
            //        }
            //        else
            //        {
            //            // 删除了权限
            //            removeFormRoles += dataRow[PiRoleTable.FieldId].ToString() + ";";
            //        }
            //    }
            //}

            string[] addToRoleIds = null;
            string[] removeFormRoleIds = null;
            if (addToRoles.Length > 0)
            {
                addToRoles = addToRoles.Substring(0, addToRoles.Length - 1);
                addToRoleIds = addToRoles.Split(';');
            }
            if (removeFormRoles.Length > 0)
            {
                removeFormRoles = removeFormRoles.Substring(0, removeFormRoles.Length - 1);
                removeFormRoleIds = removeFormRoles.Split(';');
            }
            // RDIFrameworkService.Instance.StaffService.RoleBatchSave(UserInfo, this.TargetStaffId, addToRoleIds, removeFormRoleIds);
            if (SystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0012);
            }
            return returnValue;
        }
        #endregion

        #region private string[] GetIds() 获得所有主键数组
        /// <summary>
        /// 获得所有主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetIds()
        {
            return BusinessLogic.FieldToArray(this.DTRole, PiRoleTable.FieldId);
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmRoleSelect";
            Form frmRoleSelect = CacheManager.Instance.GetForm(assemblyName, formName);
            ((IBaseSelectRoleForm)frmRoleSelect).AllowNull = false;
            ((IBaseSelectRoleForm)frmRoleSelect).MultiSelect = true;
            ((IBaseSelectRoleForm)frmRoleSelect).ShowRoleOnly = true;
            ((IBaseSelectRoleForm)frmRoleSelect).RemoveIds = this.GetIds();
            if (frmRoleSelect.ShowDialog() != DialogResult.OK) return;
            RDIFrameworkService.Instance.UserService.AddUserToRole(UserInfo, this.TargetUserId, ((IBaseSelectRoleForm)frmRoleSelect).SelectedIds);
            // 重新加载窗体
            this.Form_Load(sender, e);
        }

        #region private string[] GetSelecteIds() 获得已被选中主键数组
        /// <summary>
        /// 获得已被选中主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelecteIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvInfo, PiRoleTable.FieldId, "colSelected", true);
        }
        #endregion

        #region private int BatchRemove() 批量移出
        /// <summary>
        /// 批量移出
        /// </summary>
        /// <returns>影响行数</returns>
        private int BatchRemove()
        {
            var returnValue = 0;
            this.FormLoaded = false;
            returnValue = RDIFrameworkService.Instance.UserService.RemoveUserFromRole(UserInfo, this.TargetUserId, this.GetSelecteIds());
            this.FormLoaded = true;
            return returnValue;
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!BasePageLogic.CheckInputSelectAnyOne(this.dgvInfo, "colSelected") ||
                MessageBoxHelper.Show(RDIFrameworkMessage.MSG0075) != System.Windows.Forms.DialogResult.Yes) return;
            
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.BatchRemove();
                // 重新加载窗体
                this.Form_Load(sender, e);
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

        private void btnRolePermission_Click(object sender, EventArgs e)
        {
            var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
            var id = dataRow[PiRoleTable.FieldId].ToString();
            var realName = dataRow[PiRoleTable.FieldRealName].ToString();

            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmRoleModulePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmRolePermission = (Form)Activator.CreateInstance(assemblyType, id, realName, true);
            frmRolePermission.ShowDialog(this);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // 读取数据
            var roleEntites = new List<PiRoleEntity>();

            for (int i = 0; i < this.DTRole.Rows.Count; i++)
            {
                var roleEntity = BaseEntity.Create<PiRoleEntity>(this.DTRole.Rows[i]);
                roleEntites.Add(roleEntity);
            }
            // 复制到剪切板
            Clipboard.SetData("roleEntites", roleEntites);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("roleEntites");
            if (clipboardData == null) return;
            var roleEntites = (List<PiRoleEntity>)clipboardData;
            var addRoleIds = new string[roleEntites.Count];
            for (int i = 0; i < roleEntites.Count; i++)
            {
                addRoleIds[i] = roleEntites[i].Id.ToString();
            }
            // 添加用户到角色
            RDIFrameworkService.Instance.UserService.AddUserToRole(this.UserInfo, this.TargetUserId, addRoleIds);
            // 加载窗体
            this.OnLoad(e);
        }

        public override bool SaveEntity()
        {
            if (this.FormLoaded)
            {
                string roleId = string.Empty;
                if (this.cboRole.SelectedValue != null && this.cboRole.SelectedValue.ToString().Length > 0)
                {
                    roleId = this.cboRole.SelectedValue.ToString();
                }
                RDIFrameworkService.Instance.UserService.SetDefaultRole(UserInfo, this.txtUser.SelectedValue.ToString(), roleId);
                this.Changed = true;
            }
            return true;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (!this.CheckInput()) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.SaveEntity())
                {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = this.Changed ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
    }
}
