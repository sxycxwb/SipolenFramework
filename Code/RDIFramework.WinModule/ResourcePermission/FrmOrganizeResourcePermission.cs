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
    /// FrmOrganizeResourcePermission
    /// 组织机构资源权限设置（那个组织机构对那些资源有什么权限）
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012.05.28</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeResourcePermission : BaseForm
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
        private DataTable DTOrganize = new DataTable(PiOrganizeTable.TableName);

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
        public string TargetResourceSQL = "SELECT ID,FULLNAME AS RealName,DESCRIPTION FROM CIITEMS WHERE DELETEMARK = 0 AND ENABLED = 1 ORDER BY SORTCODE";

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
        /// 目标组织机构主键
        /// </summary>
        public string TargetOrganizeId
        {
            get
            {
                string organizeId = string.Empty;
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    organizeId = ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString();
                }
                else
                {
                    organizeId = string.Empty;
                }            
                return organizeId;
            }
        }

        public FrmOrganizeResourcePermission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="permissionItemCode"></param>
        /// <param name="targetResourceCategory"></param>
        /// <param name="targetResourceSQL"></param>
        public FrmOrganizeResourcePermission(string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
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
        public FrmOrganizeResourcePermission(string permissionItemCode, string targetResourceCategory, DataTable targetResourceDT)
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
                var permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString();
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            // 获得组织机构列表
            this.GetOrganizeList();

            this.GetOrganizePermission();
        }

        #region private void LoadTree()  加载组织机构到树
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            this.LoadTreeOrganize();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }

        private void LoadTreeOrganize()
        {
            var treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            if ((SystemInfo.EnableUserAuthorizationScope) && !UserInfo.IsAdministrator)
            {
                BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
            }
            BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode, !SystemInfo.OrganizeDynamicLoading);
        }
        #endregion

        private void GetOrganizeList()
        {
            // 获取部门数据，这里是按权限范围进行获取
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);//organizationService.GetDT(this.UserInfo);
            if (!this.UserInfo.IsAdministrator)
            {
                BasePageLogic.CheckTreeParentId(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId);
            }
            this.LoadTree();
            if (this.tvOrganize.SelectedNode == null && this.tvOrganize.Nodes.Count > 0)
            {
                if (this.TargetOrganizeId.Length == 0)
                {
                    this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                }
                else
                {
                    BasePageLogic.FindTreeNode(this.tvOrganize, this.TargetOrganizeId);
                    if (BasePageLogic.TargetNode != null)
                    {
                        this.tvOrganize.SelectedNode = BasePageLogic.TargetNode;
                        // 展开当前选中节点的所有父节点
                        BasePageLogic.ExpandTreeNode(this.tvOrganize);
                    }
                }
                if (this.tvOrganize.SelectedNode != null)
                {
                    // 让选中的节点可视，并用展开方式
                    this.tvOrganize.SelectedNode.Expand();
                    this.tvOrganize.SelectedNode.EnsureVisible();
                }
            }
        }

        private void GetOrganizePermission()
        {
            // 被选中的权限
            this.setSelectIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(this.UserInfo,PiOrganizeTable.TableName, this.TargetOrganizeId, this.TargetResourceCategory, this.PermissionItemCode);
            // 读取资源
            if (this.TargetResourceDT == null && !string.IsNullOrEmpty(this.TargetResourceSQL))
            {
                this.TargetResourceDT = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(this.UserInfo, this.TargetResourceSQL);
            }
            this.TargetResourceDT.PrimaryKey = new DataColumn[] { this.TargetResourceDT.Columns["Id"] };
            // 检查选中状态
            this.dgvTargetResource.Columns["colRealName"].DataPropertyName = this.ColumnRealName;
            this.dgvTargetResource.Columns["colDescription"].DataPropertyName = this.ColumnDescription;
            this.dgvTargetResource.AutoGenerateColumns = false;
            this.dgvTargetResource.DataSource = this.TargetResourceDT.DefaultView;
            if (this.SetSelectIds != null)
            {
                foreach (DataGridViewRow dgvRow in from DataGridViewRow dgvRow in dgvTargetResource.Rows 
                                                   let dataRowView = dgvRow.DataBoundItem as DataRowView 
                                                   where dataRowView != null 
                                                   let dataRow = dataRowView.Row 
                                                   where Array.IndexOf(this.SetSelectIds, dataRow["Id"].ToString()) >= 0 select dgvRow)
                {
                    dgvRow.Cells["colSelected"].Value = true;
                }

                //V2.5版本写法
                //foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
                //{
                //    var dataRowView = dgvRow.DataBoundItem as DataRowView;
                //    if (dataRowView == null) continue;
                //    var dataRow = dataRowView.Row;
                //    if (Array.IndexOf(this.SetSelectIds, dataRow["Id"].ToString()) >= 0)
                //        dgvRow.Cells["colSelected"].Value = true;
                //}
            }
        }

        private void GetCurrentPermission()
        {
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetOrganizePermission();
            this.btnClearPermission.Enabled = true;
            this.btnCopyPermission.Enabled = true;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.lblPermissionItemName.Text = "操作权限：" + this.PermissionItemName;

            this.cmnuSelectAll.Enabled = false;
            this.cmnuInvertSelect.Enabled = false;
            this.btnSave.Enabled = false;
            if (this.TargetResourceDT.DefaultView.Count > 0)
            {
                this.cmnuSelectAll.Enabled = true;
                this.cmnuInvertSelect.Enabled = true;
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    this.btnSave.Enabled = true;
                }
            }
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("clipboardData");
            this.btnPastePermission.Enabled = (clipboardData != null);
        }
        #endregion

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
                returnValue += RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiOrganizeTable.TableName, this.TargetOrganizeId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 被取消的权限
            var revokeResourceIds = this.GetUnSelectedIds();
            if (revokeResourceIds.Length > 0)
            {
                returnValue += RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, PiOrganizeTable.TableName, this.TargetOrganizeId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
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
                    this.GetOrganizePermission();
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
                RDIFrameworkService.Instance.PermissionService.ClearPermissionScopeTarget(this.UserInfo, PiOrganizeTable.TableName, this.TargetOrganizeId, this.TargetResourceCategory, this.PermissionItemId);
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
            var itemsEntites = new List<CiItemsEntity>();

            foreach (DataGridViewRow dgvRow in dgvTargetResource.Rows)
            {
                if (!(System.Boolean) (dgvRow.Cells["colSelected"].Value ?? false)) continue;
                var itemsEntity = new CiItemsEntity();
                var dataRowView = dgvRow.DataBoundItem as DataRowView;
                if (dataRowView != null)
                    itemsEntity.Id = BusinessLogic.ConvertToString(dataRowView.Row["id"]);
                itemsEntites.Add(itemsEntity);
            }

            // 复制到剪切板
            Clipboard.SetData("itemsEntites", itemsEntites);
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
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiOrganizeTable.TableName, this.TargetOrganizeId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
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

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
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
    }
}
