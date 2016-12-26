/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-12 13:22:49
 ******************************************************************************/
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmRoleOrganizePermission
    /// 角色权限批量设置(角色-组织机构)
    /// </summary>
    public partial class FrmRoleOrganizePermission : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private const string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

        private string[] TargetResourceIds = null;

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
        /// 资源表
        /// </summary>
        DataTable DTTargetResource = new DataTable(PiOrganizeTable.TableName);
        
        public string TargetResourceCategory = PiOrganizeTable.TableName;
        public string TargetResourceSQL = "SELECT ID, PARENTID, FULLNAME AS REALNAME, DESCRIPTION, SORTCODE FROM PIORGANIZE WHERE DELETEMARK = 0 AND ENABLED = 1 ORDER BY SORTCODE";

        public string PermissionItemId = "";
        public string PermissionItemCode = "Resource.AccessPermission";
        public string PermissionItemName = "资源访问范围权限（系统默认）";

        private string fieldId = "ID";
        /// <summary>
        /// 主键列字段名
        /// </summary>
        public string FieldId
        {
            get
            {
                return fieldId;
            }
            set
            {
                fieldId = value;
            }
        }

        private string fieldParentId = "PARENTID";
        /// <summary>
        /// 主键列字段名
        /// </summary>
        public string FieldParentId
        {
            get
            {
                return fieldParentId;
            }
            set
            {
                fieldParentId = value;
            }
        }

        private string columnRealName = "REALNAME";
        /// <summary>
        /// 名称列字段名
        /// </summary>
        public string FieldRealName
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

        private string columnDescription = "DESCRIPTION";
        /// <summary>
        /// 描述列字段名
        /// </summary>
        public string FieldDescription
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
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = false;

        public FrmRoleOrganizePermission()
        {
            InitializeComponent();
        }

        public FrmRoleOrganizePermission(string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
            : this()
        {
            this.PermissionItemCode = permissionItemCode;
            this.TargetResourceCategory = targetResourceCategory;
            this.TargetResourceSQL = targetResourceSQL;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            object clipboardData = Clipboard.GetData("roleTreeResourcePermission");
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

            if (string.IsNullOrEmpty(this.PermissionItemId))
            {
                PiPermissionItemEntity permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, PermissionItemScopeCode);
                this.PermissionItemId = permissionItemEntity.Id.ToString(CultureInfo.InvariantCulture);
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            this.DTTargetResource = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(this.UserInfo, this.TargetResourceSQL);
            this.DTTargetResource.PrimaryKey = new DataColumn[] { this.DTTargetResource.Columns[this.FieldId] };
            BasePageLogic.CheckTreeParentId(this.DTTargetResource, this.FieldId, this.FieldParentId);

            this.LoadTree();

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
            this.DTRole = SystemInfo.EnableUserAuthorizationScope && !this.UserInfo.IsAdministrator
                ? RDIFrameworkService.Instance.PermissionService.GetRoleDTByPermissionScope(this.UserInfo, UserInfo.Id,this.PermissionItemCode)
                : RDIFrameworkService.Instance.RoleService.GetDT(this.UserInfo);
            // 对超级管理员不用设置权限
            BusinessLogic.SetFilter(this.DTRole, PiUserTable.FieldCode, DefaultRole.Administrators.ToString(), true);
            
            this.DTRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.lstRole.ValueMember = PiRoleTable.FieldId;
            this.lstRole.DisplayMember = PiRoleTable.FieldRealName;
            this.lstRole.DataSource = this.DTRole.DefaultView;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvTargetTreeResource.BeginUpdate();
            this.tvTargetTreeResource.Nodes.Clear();
            this.LoadTreeResource();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvTargetTreeResource.EndUpdate();
        }
        #endregion

        private void LoadTreeResource()
        {
            var treeNode = new TreeNode();
            this.LoadTreeResource(treeNode);
        }

        #region private void LoadTreeResource(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeResource(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTTargetResource, this.FieldId, this.FieldParentId, this.FieldRealName, this.tvTargetTreeResource, treeNode, true, 2);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;
            // 这些空间可以用了
            this.tvTargetTreeResource.Enabled = true;
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取角色的权限
            this.GetRolePermission();
            this.btnClearPermission.Enabled = true;
            this.isUserClick = true;
            this.btnCopy.Enabled = true;
        }

        private void lstRole_SelectedIndexChanged(object sender, EventArgs e)
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

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null) || (treeNode.Tag as DataRow) == null) return;
            treeNode.Checked = false;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ClearCheck(treeNode.Nodes[i]);
            }
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {
            // 操作权限项被选中状态取消
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvTargetTreeResource.Nodes[i]);
            }
        }

        private void TargetResourceCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.TargetResourceCheck(this.tvTargetTreeResource.Nodes[i]);
            }
        }

        private void TargetResourceCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null) || (treeNode.Tag as DataRow) == null) return;
            string targetResourceId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            treeNode.Checked = Array.IndexOf(this.TargetResourceIds, targetResourceId) >= 0;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.TargetResourceCheck(treeNode.Nodes[i]);
            }
        }

        /// <summary>
        /// 获取角色的权限
        /// </summary>
        private void GetRolePermission()
        {
            // 获得角色的权限主键数组
            this.TargetResourceIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(UserInfo, PiRoleTable.TableName, this.TargetRoleId, this.TargetResourceCategory, this.PermissionItemCode);
            if (this.TargetResourceIds != null && this.TargetResourceIds.Length > 0)
            {
                this.tvTargetTreeResource.BeginUpdate();
                this.TargetResourceCheck();
                this.tvTargetTreeResource.EndUpdate();
            }
        }

        private void tvTargetTreeResource_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BasePageLogic.CheckChild(e.Node);
            BasePageLogic.CheckParent(e.Node);
        }

        private void tvTargetTreeResource_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.isUserClick) return;
            if (e.Node.Checked)
            {
                string[] grantResourceIds = { (e.Node.Tag as DataRow)[BusinessLogic.FieldId].ToString() };
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiRoleTable.TableName, this.TargetRoleId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            else
            {
                string[] revokeResourceIds = { (e.Node.Tag as DataRow)[BusinessLogic.FieldId].ToString() };
                RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, PiRoleTable.TableName, this.TargetRoleId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
            }
        }


        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                RDIFrameworkService.Instance.PermissionService.ClearPermissionScopeTarget(this.UserInfo, PiRoleTable.TableName, this.TargetRoleId, this.TargetResourceCategory, this.PermissionItemId);
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

        [Serializable]
        private class RoleTreeResourcePermission
        {
            public string[] GrantResourceIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var roleTreeResourcePermission = new RoleTreeResourcePermission();
            // 操作权限复制到剪切板
            var grantResourceIds = this.GetGrantResourceIds();
            roleTreeResourcePermission.GrantResourceIds = grantResourceIds;

            Clipboard.SetData("roleTreeResourcePermission", roleTreeResourcePermission);
            this.btnPaste.Enabled = true;
        }

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantResources = string.Empty;

        private void ResourceEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                // 提高运行速度
                string pesourceId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantResources += pesourceId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.ResourceEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantResourceIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantResourceIds()
        {
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.ResourceEntityToArray(this.tvTargetTreeResource.Nodes[i]);
            }
            string[] grantResourceIds = null;
            if (this.GrantResources.Length > 2)
            {
                this.GrantResources = this.GrantResources.Substring(0, this.GrantResources.Length - 1);
                grantResourceIds = this.GrantResources.Split(';');
            }
            this.GrantResources = string.Empty;
            return grantResourceIds;
        }
        #endregion

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("roleTreeResourcePermission");
            if (clipboardData == null) return;
            var roleTreeResourcePermission = (RoleTreeResourcePermission)clipboardData;
            var grantResourceIds = roleTreeResourcePermission.GrantResourceIds;

            // 添加权限范围
            if (grantResourceIds.Length > 0)
            {
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiRoleTable.TableName, this.TargetRoleId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 加载窗体
            this.GetCurrentPermission();
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpandAll.Checked)
            {
                tvTargetTreeResource.ExpandAll();
            }
            else
            {
                tvTargetTreeResource.CollapseAll();
            }        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
