/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-9-12 12:22:49
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmResourcePermission
    /// 资源权限设置（列表资源权限）
    /// 
    /// </summary>
    public partial class FrmResourcePermission : BaseForm
    {
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

        public string ResourceCategory = PiUserTable.TableName;
        public string ResourceId = string.Empty;
        public string ResourceName = string.Empty;

        public string TargetResourceCategory = "ProductInfo";
        public string TargetResourceSQL = "SELECT Id,ProductName AS RealName,Description FROM ProductInfo WHERE DeleteMark = 0 AND Enabled = 1";

        /// <summary>
        /// 资源表
        /// </summary>
        public DataTable TargetResourceDT = null;

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
        /// 构造函数
        /// </summary>
        public FrmResourcePermission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceCategory">资源类型</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="resourceName">资源名称</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="targetResourceCategory">目标资源类型</param>
        /// <param name="targetResourceSQL">目标资源SQL</param>
        public FrmResourcePermission(string resourceCategory, string resourceId, string resourceName, string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceSQL = targetResourceSQL;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceCategory">资源类型</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="resourceName">资源名称</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="targetResourceCategory">目标资源类型</param>
        /// <param name="targetResourceDT">目标资源数据表</param>
        public FrmResourcePermission(string resourceCategory, string resourceId, string resourceName, string permissionItemCode, string targetResourceCategory, DataTable targetResourceDT)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceDT = targetResourceDT;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblResourceName.Text = this.ResourceName;
            this.lblPermissionItemName.Text = this.PermissionItemName;
            
            this.cmnuSelectAll.Enabled = false;
            this.cmnuInvertSelect.Enabled = false;
            if (this.TargetResourceDT.DefaultView.Count == 0)
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
            this.DataGridViewOnLoad(dgvTargetResource);
            // 若没找到就默认为当前用户
            if (string.IsNullOrEmpty(ResourceId))
            {
                ResourceCategory = PiUserTable.TableName;
                ResourceId = this.UserInfo.Id;
                ResourceName = this.UserInfo.RealName;
            }

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                var permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 当前用户对哪些资源有权限（用户自己的权限 + 相应的角色拥有的权限）
            // string[] ids = RDIFrameworkService.Instance.PermissionService.GetResourceScopeIds(this.UserInfo, this.ResourceId, this.TargetCategory, this.PermissionItemCode);

            // 被选中的权限
            this.setSelectIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, this.PermissionItemCode);

            // 读取资源
            if (this.TargetResourceDT == null || !string.IsNullOrEmpty(this.TargetResourceSQL))
            {
                this.TargetResourceDT = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(this.UserInfo, this.TargetResourceSQL);
            }
            this.TargetResourceDT.PrimaryKey = new DataColumn[] { this.TargetResourceDT.Columns["Id"] };
            // 检查选中状态
            if (this.SetSelectIds != null)
            {
                for (int i = 0; i < this.SetSelectIds.Length; i++)
                {
                    DataRow dataRow = this.TargetResourceDT.Rows.Find(int.Parse(SetSelectIds[i]));
                    if (dataRow != null)
                    {
                        dataRow["colSelected"] = true;
                    }
                }
                this.TargetResourceDT.AcceptChanges();
            }
            this.dgvTargetResource.Columns["colRealName"].DataPropertyName = this.ColumnRealName;
            this.dgvTargetResource.Columns["colDescription"].DataPropertyName = this.ColumnDescription;
            this.dgvTargetResource.AutoGenerateColumns = false;
            this.dgvTargetResource.DataSource = this.TargetResourceDT.DefaultView;
        }
        #endregion

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

        #region private string[] GetUnSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得未被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetUnSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvTargetResource, "Id", "colSelected", false);
        }
        #endregion

        #region private int BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private int BatchSave()
        {
            int returnValue = 0;
            // 被设置的权限
            string[] grantResourceIds = this.GetSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            // 被取消的权限
            string[] revokeResourceIds = this.GetUnSelectedIds();
            returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
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
                // 批量保存
                if (this.BatchSave() > 0)
                {
                    // 关闭窗口
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
    }
}
