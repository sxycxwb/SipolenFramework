/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-9-13 10:22:49
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmResourcePermissionScope
    /// 资源权限设置
    /// 
    /// </summary>
    public partial class FrmResourcePermissionScope : BaseForm
    {
        /// <summary>
        /// 用户表
        /// </summary>
        DataTable dtUser = new DataTable();

        /// <summary>
        /// 角色表
        /// </summary>
        DataTable dtRole = new DataTable();

        private string[] setSelectUserIds = null;
        /// <summary>
        /// 选中的用户主键数组
        /// </summary>
        public string[] SetSelectUserIds
        {
            get
            {
                return this.setSelectUserIds;
            }
            set
            {
                this.setSelectUserIds = value;
            }
        }

        private string[] setSelectRoleIds = null;
        /// <summary>
        /// 选中的角色主键数组
        /// </summary>
        public string[] SetSelectRoleIds
        {
            get
            {
                return this.setSelectRoleIds;
            }
            set
            {
                this.setSelectRoleIds = value;
            }
        }

        public string PermissionItemId = "";
        public string PermissionItemCode = "Resource.ManagePermission";
        public string PermissionItemName = "资源管理范围权限（系统默认）";

        public string TargetResourceCategory = "ProductInfo";
        public string TargetResourceId = "1";
        public string TargetResourceName = "产品管理";

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmResourcePermissionScope()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="targetResourceCategory">目标资源类型</param>
        /// <param name="targetResourceId">目标资源主键</param>
        /// <param name="targetResourceName">目标资源名称</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        public FrmResourcePermissionScope(string targetResourceCategory, string targetResourceId, string targetResourceName, string permissionItemCode)
            : this()
        {
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceId = targetResourceId;
            this.TargetResourceName = targetResourceName;
            this.PermissionItemCode = permissionItemCode;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblTargetResourceName.Text = this.TargetResourceName;
            this.lblPermissionItemName.Text = this.PermissionItemName;
            
            this.cmnuSelectAll.Enabled = false;
            this.cmnuInvertSelect.Enabled = false;
            if (this.dtUser.DefaultView.Count == 0)
            {
                this.btnSave.Enabled = false;
            }
            else
            {
                this.cmnuSelectAll.Enabled = true;
                this.cmnuInvertSelect.Enabled = true;
                this.btnSave.Enabled = true;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvRole);
            this.DataGridViewOnLoad(dgvUser);

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 被选中的权限
            this.tcResource.SelectedTabIndex = 0;
            this.SetSelectUserIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeResourceIds(this.UserInfo, PiUserTable.TableName, this.TargetResourceId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            this.dtUser = RDIFrameworkService.Instance.UserService.GetDT(this.UserInfo);
            this.dtUser.PrimaryKey = new DataColumn[] { this.dtUser.Columns["Id"] };
            // 检查选中状态
            this.dgvUser.AutoGenerateColumns = false;
            this.dgvUser.DataSource = this.dtUser.DefaultView;
            if (this.SetSelectUserIds != null)
            {
                foreach (DataGridViewRow dgvRow in dgvUser.Rows)
                {
                    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                    if (Array.IndexOf(this.SetSelectUserIds, dataRow["Id"].ToString()) >= 0)
                        dgvRow.Cells["colUserSelected"].Value = true;
                }            
            }

            // 被选中的权限
            this.tcResource.SelectedTabIndex = 1;
            this.SetSelectRoleIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeResourceIds(this.UserInfo, PiRoleTable.TableName, this.TargetResourceId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            this.dtRole = RDIFrameworkService.Instance.RoleService.GetDT(this.UserInfo);
            this.dtRole.PrimaryKey = new DataColumn[] { this.dtRole.Columns["Id"] };
            // 检查选中状态
            this.dgvRole.AutoGenerateColumns = false;
            this.dgvRole.DataSource = this.dtRole.DefaultView;
            if (this.SetSelectRoleIds != null)
            {
                foreach (DataGridViewRow dgvRow in dgvRole.Rows)
                {
                    DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                    if (Array.IndexOf(this.SetSelectRoleIds, dataRow["Id"].ToString()) >= 0)
                        dgvRow.Cells["colRoleSelected"].Value = true;
                }
            }
        }
        #endregion

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            if (this.tcResource.SelectedTabIndex == 1)
            {
                foreach (DataGridViewRow dgvRow in dgvRole.Rows)
                {
                    dgvRow.Cells["colRoleSelected"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow dgvRow in dgvUser.Rows)
                {
                    dgvRow.Cells["colUserSelected"].Value = true;
                }
            }
        }

        private void cmnuInvertSelect_Click(object sender, EventArgs e)
        {
            if (this.tcResource.SelectedTabIndex == 1)
            {
                foreach (DataGridViewRow dgvRow in dgvRole.Rows)
                {
                    dgvRow.Cells["colRoleSelected"].Value = !(System.Boolean)(dgvRow.Cells["colRoleSelected"].Value??false);
                }
            }
            else
            {
                foreach (DataGridViewRow dgvRow in dgvUser.Rows)
                {
                    dgvRow.Cells["colUserSelected"].Value = !(System.Boolean)(dgvRow.Cells["colUserSelected"].Value??false);
                }
            }            
        }

        #region private string[] GetUserSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUserSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvUser, "Id", "colUserSelected", true);
        }
        #endregion

        #region private string[] GetUserUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUserUnSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvUser, "Id", "colUserSelected", false);
        }
        #endregion

        #region private string[] GetRoleSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetRoleSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvRole, "Id", "colRoleSelected", true);
        }
        #endregion

        #region private string[] GetRoleUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetRoleUnSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvRole, "Id", "colRoleSelected", false);
        }
        #endregion

        #region private int UserBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int UserBatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantUserResourceIds = this.GetUserSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTarget(this.UserInfo, PiUserTable.TableName, grantUserResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            // 被取消的权限
            string[] revokeUserResourceIds = this.GetUserUnSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTarget(this.UserInfo, PiUserTable.TableName, revokeUserResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            return returnValue;
        }
        #endregion

        #region private int RoleBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int RoleBatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantRoleResourceIds = this.GetRoleSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTarget(this.UserInfo, PiRoleTable.TableName, grantRoleResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            // 被取消的权限
            string[] revokeRoleResourceIds = this.GetRoleUnSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTarget(this.UserInfo, PiRoleTable.TableName, revokeRoleResourceIds, this.TargetResourceCategory, this.TargetResourceId, this.PermissionItemId);
            return returnValue;
        }
        #endregion

        private int BatchSave()
        {
            return UserBatchSave() + RoleBatchSave();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvUser.EndEdit();
                dgvRole.EndEdit();
                // 批量保存
                if (this.BatchSave() > 0)
                {
                    if (RDIFramework.Utilities.SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(RDIFramework.Utilities.RDIFrameworkMessage.MSG0012);
                    }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPermissionItem_Click(object sender, EventArgs e)
        {

        }
    }
}
