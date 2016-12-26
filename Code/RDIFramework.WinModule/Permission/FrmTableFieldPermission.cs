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
    /// FrmTableFieldPermission.cs
    /// 表字段权限批量设置
    /// 
    /// 修改记录
    ///     2012.10.15 创建表字段权限批量设置
    /// </summary>
    public partial class FrmTableFieldPermission : BaseForm
    {
        private string resourceCategory = string.Empty;
        ///<summary>
        /// 什么类型的
        ///</summary>
        public string ResourceCategory
        {
            get
            {
                return resourceCategory;
            }
            set
            {
                resourceCategory = value;
            }
        }

        private string resourceId = string.Empty;
        ///<summary>
        /// 什么资源
        ///</summary>
        public string ResourceId
        {
            get
            {
                return resourceId;
            }
            set
            {
                resourceId = value;
            }
        }

        private DataTable DataTableColumns = new DataTable(CiTableColumnsTable.TableName);

        // 资源访问权限
        public string PermissionItemId = "";
        public string PermissionItemCode = "Resource.AccessPermission";

        // 访问列
        public string ColumnAccessPermissionId = "";
        public string ColumnAccessPermissionCode = "Column.Access";

        // 编辑列
        public string ColumnEditPermissionId = "";
        public string ColumnEditPermissionCode = "Column.Edit";

        // 拒绝访问列
        public string ColumnDeneyPermissionId = "";
        public string ColumnDeneyPermissionCode = "Column.Deney";

        public FrmTableFieldPermission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceCategory">什么类型的</param>
        /// <param name="resourceId">什么资源</param>
        public FrmTableFieldPermission(string resourceCategory, string resourceId)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
            }
            if (string.IsNullOrEmpty(this.ColumnAccessPermissionId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.ColumnAccessPermissionCode);
                this.ColumnAccessPermissionId = permissionItemEntity.Id.ToString();
            }
            if (string.IsNullOrEmpty(this.ColumnEditPermissionId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.ColumnEditPermissionCode);
                this.ColumnEditPermissionId = permissionItemEntity.Id.ToString();
            }
            if (string.IsNullOrEmpty(this.ColumnDeneyPermissionId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.ColumnDeneyPermissionCode);
                this.ColumnDeneyPermissionId = permissionItemEntity.Id.ToString();
            }

            if (this.ResourceCategory == PiRoleTable.TableName)
            {
                this.txtUserOrRole.Text = RDIFrameworkService.Instance.RoleService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            if (this.ResourceCategory == PiUserTable.TableName)
            {
                this.txtUserOrRole.Text = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(this.dgvTableFieldList);
            // 获得列表
            this.GetList();
            this.GetTableColumnList();
        }
        #endregion

        #region public override void GetList() 获取数据表列表
        /// <summary>
        /// 获取数据表列表
        /// </summary>
        public override void GetList()
        {
            var dtTableList = RDIFrameworkService.Instance.TableColumnsService.GetAllTableScope(this.UserInfo);
            // this.grdTable.AutoGenerateColumns = false;
            this.cklbTable.DataSource = dtTableList.DefaultView;
            this.cklbTable.ValueMember = CiItemDetailsTable.FieldItemValue;
            this.cklbTable.DisplayMember = CiItemDetailsTable.FieldItemName;

            // 表的访问权限显示
            var selectIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", this.PermissionItemCode);
            if (selectIds == null || selectIds.Length <= 0) return;
            for (int i = 0; i < this.cklbTable.Items.Count; i++)
            {
                // this.cklbTable.SetItemChecked(i, true);
                this.cklbTable.SetItemChecked(i, StringHelper.Exists(selectIds, ((DataRowView)this.cklbTable.Items[i])[CiItemDetailsTable.FieldItemCode].ToString()));
            }
        }
        #endregion

        public override void SetControlState()
        {
            this.dgvTableFieldList.Columns[1].ReadOnly = !this.UserInfo.IsAdministrator;
        }

        private void GetTableColumnList()
        {
            if (this.cklbTable.Items.Count <= 0) return;
            this.cklbTable.SetSelected(0, true);
            string tableName = this.cklbTable.SelectedValue.ToString();
            this.GetTableColumnList(tableName);
        }

        private void GetTableColumnList(string tableName)
        {
            this.DataTableColumns = RDIFrameworkService.Instance.TableColumnsService.GetDTByTable(UserInfo, tableName);
            this.dgvTableFieldList.AutoGenerateColumns = false;
            this.DataTableColumns.DefaultView.Sort = CiTableColumnsTable.FieldSortCode;
            //this.dgvTableFieldList.DataSource = this.DataTableColumns.DefaultView;
            // 这里是列的访问权限处里
            // 表的访问权限显示
            var columns = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.ColumnAccessPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BusinessLogic.SetProperty(this.DataTableColumns, CiTableColumnsTable.FieldColumnCode, columns[i], "ColumnAccess", 1);
                }
            }
            columns = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.ColumnEditPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BusinessLogic.SetProperty(this.DataTableColumns, CiTableColumnsTable.FieldColumnCode, columns[i], "ColumnEdit", 1);
                }
            }
            columns = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.ColumnDeneyPermissionCode);
            if (columns != null && columns.Length > 0)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    BusinessLogic.SetProperty(this.DataTableColumns, CiTableColumnsTable.FieldColumnCode, columns[i], "ColumnDeney", 1);
                }
            }
            //this.DataTableColumns.AcceptChanges();
            this.dgvTableFieldList.DataSource = this.DataTableColumns.DefaultView;
        }

        private void cklbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.FormLoaded) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 防止反复触发事件
            this.FormLoaded = false;
            this.dgvTableFieldList.DataSource = null;
            if (this.cklbTable.SelectedItem != null)
            {
                string tableName = this.cklbTable.SelectedValue.ToString();
                this.GetTableColumnList(tableName);
            }
            this.FormLoaded = true;
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private void dgvTableFieldList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.FormLoaded)
            {
                return;
            }

            // 2: 若是可以编辑，那就需要能访问。
            // 3: 访问权限的设置
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                // 1: 若是拒绝的权限，那就不能把访问与可编辑权限赋予
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //bool checkBoxChecked = (int)checkBoxCell.Value > 0;
                bool checkBoxChecked = BusinessLogic.ConvertIntToBoolean(checkBoxCell.Value);
                if (e.ColumnIndex == 1)
                {
                    if (!this.UserInfo.IsAdministrator)
                    {
                        return;
                    }
                    // 修改字段的公开属性
                    string id = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem)[CiTableColumnsTable.FieldId].ToString();
                    string commandText = " UPDATE " + CiTableColumnsTable.TableName
                                       + "    SET " + CiTableColumnsTable.FieldIsPublic + " = ";
                    commandText += checkBoxChecked ? "1" : "0";
                    commandText += "  WHERE " + CiTableColumnsTable.FieldId + " = '" + id + "'";
                    RDIFrameworkService.Instance.RDIFrameworkDBProviderService.ExecuteNonQuery(this.UserInfo, commandText);
                    return;
                }
                string columnPermissionId = string.Empty;
                if (e.ColumnIndex == 2)
                {
                    columnPermissionId = this.ColumnAccessPermissionId;
                }
                if (e.ColumnIndex == 3)
                {
                    columnPermissionId = this.ColumnEditPermissionId;
                }
                if (e.ColumnIndex == 4)
                {
                    columnPermissionId = this.ColumnDeneyPermissionId;
                }
                // 表名
                string tableCode = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem)[CiTableColumnsTable.FieldTableCode].ToString();
                // 字段名
                string columnCode = ((DataRowView)dataGridView.Rows[e.RowIndex].DataBoundItem)[CiTableColumnsTable.FieldColumnCode].ToString();
                // e.ColumnIndex.ToString() + e.RowIndex.ToString();
                if (checkBoxChecked)
                {
                    // 被设置的权限
                    string grantResourceId = columnCode;
                    RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTarget(this.UserInfo, this.ResourceCategory, new string[] { this.ResourceId }, tableCode, grantResourceId, columnPermissionId);
                }
                else
                {
                    // 被取消的权限
                    string revokeResourceId = columnCode;
                    RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTarget(this.UserInfo, this.ResourceCategory, new string[] { this.ResourceId }, tableCode, revokeResourceId, columnPermissionId);
                }
            }
        }

        private void cklbTable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var tableName = ((System.Data.DataRowView)this.cklbTable.Items[e.Index])[CiItemDetailsTable.FieldItemCode].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                string[] grantResourceIds = new string[] { tableName };
                
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", grantResourceIds, this.PermissionItemId);
            }
            else
            {
                /* 过多的用户询问，反而为影响使用效果，2.0版本改进，吸取用户的建议。
                if (MessageBoxHelper.Show("取消对该表的访问权限，会同步取消对该表列的相关控制权限，确定取消吗？") == System.Windows.Forms.DialogResult.No)
                {
                    e.NewValue = CheckState.Checked;
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
                    return;
                }
                */
                //对表的权限进行回收了，相应的列的权限也应该予以回收才符合业务要求。
                string[] revokeResourceIds = new string[] { tableName };
                
                RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", revokeResourceIds, this.PermissionItemId);
                //回收列的相关权限
                RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.GetALlFieldIds(), this.ColumnAccessPermissionId);
                RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.GetALlFieldIds(), this.ColumnEditPermissionId);
                RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, tableName, this.GetALlFieldIds(), this.ColumnDeneyPermissionId);

            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        private string[] GetALlFieldIds()
        {
            var ids = new List<string>();
            for(int i = 0 ;i<dgvTableFieldList.Rows.Count;i++)
            {
                ids.Add(((DataRowView)dgvTableFieldList.Rows[i].DataBoundItem)[CiTableColumnsTable.FieldColumnCode].ToString());
            }
            return ids.ToArray();
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
            return cklbTable.CheckedItems.Cast<object>().Select((t, i) => ((System.Data.DataRowView) this.cklbTable.CheckedItems[i])[CiItemDetailsTable.FieldItemCode].ToString()).ToArray();
            //重构前代码 V2.5版本
            //var ids = new List<string>();
            //for (int i = 0; i < cklbTable.CheckedItems.Count; i++)
            //{
            //    ids.Add(((System.Data.DataRowView)this.cklbTable.CheckedItems[i])[CiItemDetailsTable.FieldItemCode].ToString());
            //}
            //return ids.ToArray();
        }
        #endregion

        #region private string[] GetUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUnSelectedIds()
        {
            var ids = new List<string>();
            for (int i = 0; i < cklbTable.Items.Count; i++)
            {
                if (!cklbTable.GetItemChecked(i))
                {
                    ids.Add(((System.Data.DataRowView)this.cklbTable.Items[i])[CiItemDetailsTable.FieldItemCode].ToString());
                }
            }
            return ids.ToArray();
        }
        #endregion

        #region private int BatchSaveTable() 批量保存表格访问权限
        /// <summary>
        /// 批量保存表格访问权限
        /// </summary>
        private int BatchSaveTable()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantResourceIds = this.GetSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", grantResourceIds, this.PermissionItemId);
            // 被取消的权限
            string[] revokeResourceIds = this.GetUnSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, "Table", revokeResourceIds, this.PermissionItemId);
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1：批量保存表格访问权限。
            this.BatchSaveTable();
            // 1：1 授权处理。
            // 1：2 取消授权处理。

            // 2：用户的列访问权限保存。
            // 2: 1 访问 权限处理
            // 2: 2 编辑 权限处理
            // 2: 3 拒绝访问 权限处理
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string exportFileName = this.Text + ".xls";
            this.ExportToExcel(this.dgvTableFieldList, @"\Modules\Export\", exportFileName);
        }
    }
}
