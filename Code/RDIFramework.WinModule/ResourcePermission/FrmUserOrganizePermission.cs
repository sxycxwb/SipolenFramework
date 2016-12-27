/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-7-12 13:00:49
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
    /// FrmUserOrganizePermission
    /// 用户权限批量设置(用户-组织机构)
    /// 
    /// </summary>
    public partial class FrmUserOrganizePermission : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        private string[] TargetResourceIds = null;

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

        private string columnParentId = "PARENTID";
        /// <summary>
        /// 主键列字段名
        /// </summary>
        public string FieldParentId
        {
            get
            {
                return columnParentId;
            }
            set
            {
                columnParentId = value;
            }
        }

        private string columnRealName = "RealName";
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

        public FrmUserOrganizePermission()
        {
            InitializeComponent();
        }

        public FrmUserOrganizePermission(string permissionItemCode, string targetResourceCategory, string targetResourceSQL)
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
            object clipboardData = Clipboard.GetData("userTreeResourcePermission");
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
                var permissionItemEntity = RDIFrameworkService.Instance.PermissionItemService.GetEntityByCode(this.UserInfo, this.PermissionItemCode);
                this.PermissionItemId   = permissionItemEntity.Id.ToString(CultureInfo.InvariantCulture);
                this.PermissionItemName = permissionItemEntity.FullName;
            }

            this.DTTargetResource = RDIFrameworkService.Instance.RDIFrameworkDBProviderService.Fill(this.UserInfo, this.TargetResourceSQL);
            this.DTTargetResource.PrimaryKey = new DataColumn[] { this.DTTargetResource.Columns[this.FieldId] };
            BasePageLogic.CheckTreeParentId(this.DTTargetResource, this.FieldId, this.FieldParentId);
            
            this.LoadTree();

            // 获得用户列表
            this.GetUserList();

            this.isUserClick = true;
        }
        #endregion

        #region private void GetUserList() 获取用户列表
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
            // 对超级管理员不用设置权限
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

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvTargetTreeResource.BeginUpdate();
            this.tvTargetTreeResource.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvTargetTreeResource.EndUpdate();
        }
        #endregion

        private void LoadTreePermissionItem()
        {
            var treeNode = new TreeNode();
            this.LoadTreePermissionItem(treeNode);
        }

        #region private void LoadTreePermissionItem(TreeNode treeNode) 加载组织机构树的主键
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreePermissionItem(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTTargetResource, this.FieldId, this.FieldParentId, this.FieldRealName, this.tvTargetTreeResource, treeNode, true, 2);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 这些空间可以用了
            this.tvTargetTreeResource.Enabled = true;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取用户的权限
            this.GetUserPermission();
            this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            this.btnCopy.Enabled = true;
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

        /// <summary>
        /// 获取用户的权限
        /// </summary>
        private void GetUserPermission()
        {
            // 获得用户的权限主键数组
            this.TargetResourceIds = RDIFrameworkService.Instance.PermissionService.GetPermissionScopeTargetIds(UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, this.PermissionItemCode);
            if (this.TargetResourceIds != null && this.TargetResourceIds.Length > 0)
            {
                this.tvTargetTreeResource.BeginUpdate();
                this.LoadTreeResource();
                this.tvTargetTreeResource.EndUpdate();
            }
        }

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
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

        private void LoadTreeResource()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvTargetTreeResource.Nodes.Count; i++)
            {
                this.LoadTreeResource(this.tvTargetTreeResource.Nodes[i]);
            }
        }

        private void LoadTreeResource(TreeNode treeNode)
        {
            if ((treeNode == null) || (treeNode.Tag == null)) return;
            string targetResourceId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
            treeNode.Checked = Array.IndexOf(this.TargetResourceIds, targetResourceId) >= 0;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.LoadTreeResource(treeNode.Nodes[i]);
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
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            else
            {
                string[] revokeResourceIds = { (e.Node.Tag as DataRow)[BusinessLogic.FieldId].ToString() };
                RDIFrameworkService.Instance.PermissionService.RevokePermissionScopeTargets(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, revokeResourceIds, this.PermissionItemId);
            }
        }

        private void chkExpandAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkExpandAll.Checked)
            {
                tvTargetTreeResource.ExpandAll();
            }
            else
            {
                tvTargetTreeResource.CollapseAll();
            }            
        }   

        #region 清除、复制、粘贴权限
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

        [Serializable]
        private class UserTreeResourcePermission
        {
            public string[] GrantResourceIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var userTreeResourcePermission = new UserTreeResourcePermission();
            // 操作权限复制到剪切板
            var grantResourceIds = this.GetGrantResourceIds();
            userTreeResourcePermission.GrantResourceIds = grantResourceIds;

            Clipboard.SetData("userTreeResourcePermission", userTreeResourcePermission);
            this.btnPaste.Enabled = true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userTreeResourcePermission");
            if (clipboardData == null) return;
            var userTreeResourcePermission = (UserTreeResourcePermission)clipboardData;
            var grantResourceIds = userTreeResourcePermission.GrantResourceIds;

            // 添加权限范围
            if (grantResourceIds.Length > 0)
            {
                RDIFrameworkService.Instance.PermissionService.GrantPermissionScopeTargets(this.UserInfo, PiUserTable.TableName, this.TargetUserId, this.TargetResourceCategory, grantResourceIds, this.PermissionItemId);
            }
            // 加载窗体
            this.GetCurrentPermission();
        }
        #endregion

        #region private void ResourceEntityToArray(TreeNode treeNode):授权的操作权限
        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantResources = string.Empty;

        private void ResourceEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null)
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
        #endregion

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
