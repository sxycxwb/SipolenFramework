using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmUserResourcePermission
    /// 用户资源权限设置（那个用户对那些资源有什么权限）
    /// 
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012.05.25</date>
    /// </author> 
    /// </summary>
    public partial class FrmUserResourcePermission : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 资源表
        /// </summary>
        public DataTable TargetResourceDT = null;
        
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        private string[] setSelectIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectIds
        {
            get
            {
                return this.setSelectIds;
            }
            set
            {
                this.setSelectIds = value;
            }
        }


        public string TargetResourceCategory = "CiItems";
        public string TargetResourceSQL = "SELECT Id,FullName AS RealName,Description FROM CiItems WHERE DeleteMark = 0 AND Enabled = 1 ORDER BY SortCode";

        public string PermissionItemId = "";
        public string PermissionItemCode = "Resource.ManagePermission";
        public string PermissionItemName = "资源管理范围权限（系统默认）";

        private string columnRealName = "RealName";
        /// <summary>
        /// 名称列字段名
        /// </summary>
        public string ColumnRealName
        {
            get
            {
                return columnRealName;
            }
            set
            {
                columnRealName = value;
            }
        }

        private string columnDescription = "Description";
        /// <summary>
        /// 描述列字段名
        /// </summary>
        public string ColumnDescription
        {
            get
            {
                return columnDescription;
            }
            set
            {
                columnDescription = value;
            }
        }

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetUserId
        {
            get
            {
                string userId = string.Empty;
                if (this.lstUser.SelectedItem != null)
                {
                    userId = this.lstUser.SelectedValue.ToString();
                }
                return userId;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmUserResourcePermission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permissionItemCode"></param>
        /// <param name="targetResourceCategory"></param>
        /// <param name="targetResourceSQL"></param>
        public FrmUserResourcePermission(string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
            : this()
        {
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceSQL = targetResourceSQL;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permissionItemCode"></param>
        /// <param name="targetResourceCategory"></param>
        /// <param name="targetResourceDT"></param>
        public FrmUserResourcePermission(string permissionItemCode, string targetResourceCategory, DataTable targetResourceDT)
            : this()
        {
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceDT = targetResourceDT;
        }

        public override void FormOnLoad()
        {
            this.LoadUserParameters = false;
            this.DataGridViewOnLoad(dgvTargetResource);

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 获得用户列表
            this.GetUserList();

            this.GetUserPermission();
        }


        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblPermissionItemName.Text ="操作权限：" + this.PermissionItemName;
            this.cmnuSelectAll.Enabled = false;
            this.cmnuInvertSelect.Enabled = false;
            this.btnSave.Enabled = false;
            if (this.TargetResourceDT.DefaultView.Count > 0)
            {
                this.cmnuSelectAll.Enabled = true;
                this.cmnuInvertSelect.Enabled = true;
                if (this.lstUser.Items.Count > 0)
                {
                    this.btnSave.Enabled = true;
                }
            }
            // 是否有数据被复制
            object clipboardData = Clipboard.GetData("clipboardData");
            this.btnPastePermission.Enabled = (clipboardData != null);
        }
        #endregion

        #region private void GetUserList() 获用户列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        private void GetUserList()
        {
            // 是否启用了权限范围管理
            if (SystemInfo.EnableUserAuthorizationScope && !this.UserInfo.IsAdministrator)
            {
                this.DTUser = RDIFrameworkService.Instance.PermissionService.GetUserDTByPermissionScope(this.UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            else
            {
                this.DTUser = RDIFrameworkService.Instance.UserService.GetDT(this.UserInfo);
            }
            // 超级管理员不用设置权限
            BusinessLogic.SetFilter(this.DTUser, PiUserTable.FieldCode, DefaultRole.Administrator.ToString(), true);
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[PiUserTable.FieldRealName] = dataRow[PiUserTable.FieldUserName] + " [" + dataRow[PiUserTable.FieldRealName] + "]";
            }
            this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            this.lstUser.ValueMember = PiUserTable.FieldId;
            this.lstUser.DisplayMember = PiUserTable.FieldRealName;
            this.lstUser.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        /// <summary>
        /// 获取用户的权限
        /// </summary>
        private void GetUserPermission()
        {
            // 当前用户对哪些资源有指定的权限（用户自己的权限 + 相应的角色拥有的权限）
            // string[] ids = RDIFrameworkService.Instance.PermissionService.GetResourceScopeIds(this.UserInfo, this.ResourceId, this.TargetCategory, this.PermissionItemCode);

            // 当前用户对哪些资源有指定的权限
            this.setSelectIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            if (this.TargetResourceDT == null && !string.IsNullOrEmpty(this.TargetResourceSQL))
            {
                this.TargetResourceDT = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(this.UserInfo, this.TargetResourceSQL);
            }
            this.TargetResourceDT.PrimaryKey = new DataColumn[] { this.TargetResourceDT.Columns[BusinessLogic.FieldId] };
            // 检查选中状态
            var dataGridViewColumn = this.dgvTargetResource.Columns["colRealName"];
            if (dataGridViewColumn != null)
                dataGridViewColumn.DataPropertyName = this.ColumnRealName;
            var gridViewColumn = this.dgvTargetResource.Columns["colDescription"];
            if (gridViewColumn != null)
                gridViewColumn.DataPropertyName = this.ColumnDescription;
            this.dgvTargetResource.AutoGenerateColumns = false;
            this.dgvTargetResource.DataSource = this.TargetResourceDT.DefaultView;
            if (this.SetSelectIds != null)
            {
                foreach (var dgvRow in from DataGridViewRow dgvRow in dgvTargetResource.Rows 
                                                   let dataRowView = dgvRow.DataBoundItem as DataRowView where dataRowView != null 
                                                   let dataRow = dataRowView.Row where Array.IndexOf(this.SetSelectIds, dataRow["Id"].ToString()) >= 0 select dgvRow)
                {
                    dgvRow.Cells["colSelected"].Value = true;
                }
            }
        }

        private void GetCurrentPermission()
        {
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetUserPermission();
            this.btnClearPermission.Enabled = true;
            this.btnCopyPermission.Enabled = true;
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvTargetResource, "Id", "colSelected", true);
        }
        #endregion

        #region private string[] GetUnSelectedIds() 获得未被选择的主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUnSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvTargetResource, "Id", "colSelected", false);
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {
            foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = false;
            }         
        }

        #region private int BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int BatchSave()
        {
            var returnValue = 0;
            // 被设置的权限
            var grantResourceIds = this.GetSelectedIds();
            if (grantResourceIds.Length > 0)
            {
                returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 被取消的权限
            var revokeResourceIds = this.GetUnSelectedIds();
            if (revokeResourceIds.Length > 0)
            {
                returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
            }
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvTargetResource.EndEdit();
                // 批量保存
                if (this.BatchSave() > 0)
                {
                    // 重新刷新数据
                    this.GetUserPermission();
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

        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                RDIFrameworkService.Instance.PermissionService.ClearPermissionScopeTarget(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, this.PermissionItemId);
                // 重新刷新数据
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

        private void btnCopyPermission_Click(object sender, EventArgs e)
        {
            // 读取数据
            var itemsEntites = (from DataGridViewRow dgvRow in dgvTargetResource.Rows
                where (System.Boolean) (dgvRow.Cells["colSelected"].Value ?? false)
                let dataRowView = dgvRow.DataBoundItem as DataRowView
                where dataRowView != null
                select new CiItemsEntity
                {
                    Id = BusinessLogic.ConvertToString(dataRowView.Row["id"])
                }).ToList();
            //V2.5版本的方法：
            //var itemsEntites = new List<CiItemsEntity>();
            //foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            //{
            //    if (!(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false)) continue;
            //    var itemsEntity = new CiItemsEntity
            //    {
            //        Id = int.Parse((dgvRow.DataBoundItem as DataRowView).Row["id"].ToString())
            //    };
            //    itemsEntites.Add(itemsEntity);
            //}
            // 复制到剪切板
            Clipboard.SetData("clipboardData", itemsEntites);
            this.btnPastePermission.Enabled = true;
        }

        private void btnPastePermission_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("clipboardData");
            if (clipboardData == null) return;
            var itemsEntites = (List<CiItemsEntity>)clipboardData;
            var grantResourceIds = new string[itemsEntites.Count];
            for (int i = 0; i < itemsEntites.Count; i++)
            {
                grantResourceIds[i] = itemsEntites[i].Id.ToString();
            }
            // 添加用户到角色
            if (grantResourceIds.Length > 0)
            {
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, CiItemsTable.TableName, this.TargetUserId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 加载窗体
            this.GetCurrentPermission();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmnuSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
        }

        private void cmnuInvertSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value ?? false);
            }
        }

        private void lstUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
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

    }
}
