﻿/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-24 14:07:09
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
    /// 权限设置-用户权限批量设置
    /// FrmUserPermissionItem
    /// 
    /// </summary>
    public partial class FrmUserPermissionItem : BaseForm
    {
        /// <summary>
        /// 权限域（范围权限、数据权限）
        /// </summary>
        private string PermissionItemScopeCode = "Resource.ManagePermission";

        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(PiUserTable.TableName);

        /// <summary>
        /// 操作权限项数据
        /// </summary>
        public DataTable DTPermissionItem = new DataTable(PiPermissionItemTable.TableName);

        private string[] PermissionItemIds = null;

        /// <summary>
        /// 目标角色主键
        /// </summary>
        public string TargetUserId
        {
            get
            {
                string userId = string.Empty;
                if (this.lbUserList.SelectedItem != null)
                {
                    userId = this.lbUserList.SelectedValue.ToString();
                }
                return userId;
            }
        }

        /// <summary>
        /// 是否是用户点击了复选框
        /// </summary>
        private bool isUserClick = true;

        public FrmUserPermissionItem()
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
            object clipboardData = Clipboard.GetData("userPermissionItem");
            //this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;

            this.DTPermissionItem = this.GetPermissionItemScop(this.PermissionItemScopeCode);
            // 这里需要只把有效的模块显示出来
            BusinessLogic.SetFilter(this.DTPermissionItem, PiPermissionItemTable.FieldEnabled, "1");
            // 未被打上删除标标志的
            // BusinessLogic.SetFilter(this.DTPermissionItem, BasePermissionItemEntity.FieldDeletionStateCode, "0");

            this.LoadTree();

            // 获得用户列表
            this.GetUserList();

            // 获取用户的权限
            this.GetUserPermission();

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
            this.DTUser = this.GetUserScope(this.PermissionItemScopeCode);
            // 对超级管理员不用设置权限
            BusinessLogic.SetFilter(this.DTUser, PiUserTable.FieldCode, DefaultRole.Administrator.ToString(), true);
            foreach (DataRow dataRow in this.DTUser.Rows)
            {
                dataRow[PiUserTable.FieldRealName] = dataRow[PiUserTable.FieldUserName] + " [" + dataRow[PiUserTable.FieldRealName] + "]";
            }
            if (this.DTUser.Columns.Count > 0)
            {
                this.DTUser.DefaultView.Sort = PiUserTable.FieldSortCode;
            }
            this.lbUserList.ValueMember = PiUserTable.FieldId;
            this.lbUserList.DisplayMember = PiUserTable.FieldRealName;
            this.lbUserList.DataSource = this.DTUser.DefaultView;
        }
        #endregion

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvPermissionItem.BeginUpdate();
            this.tvPermissionItem.Nodes.Clear();
            this.LoadTreePermissionItem();
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvPermissionItem.EndUpdate();
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
            BasePageLogic.LoadTreeNodes(this.DTPermissionItem, PiPermissionItemTable.FieldId, PiPermissionItemTable.FieldParentId, PiPermissionItemTable.FieldFullName, this.tvPermissionItem, treeNode, true, 2, PiPermissionItemTable.FieldCode);
        }
        #endregion

        private void GetCurrentPermission()
        {
            this.isUserClick = false;

            // 这些空间可以用了
            this.tvPermissionItem.Enabled = true;

            // 当前选中的角色被改变
            // 初始化权限设置页面
            this.ClearCheck();
            // 获取用户的权限
            this.GetUserPermission();
            this.isUserClick = true;

            this.btnClearPermission.Enabled = true;
            //this.btnCopy.Enabled = true;
        }

        private void lbUserList_SelectedIndexChanged(object sender, EventArgs e)
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
        private void GetUserPermission()
        {
            // 获得用户的权限主键数组
            this.PermissionItemIds = RDIFrameworkService.Instance.PermissionService.GetUserPermissionItemIds(UserInfo, this.TargetUserId);
            if (this.PermissionItemIds == null || this.PermissionItemIds.Length <= 0) return;
            this.tvPermissionItem.BeginUpdate();
            this.PermissionItemCheck();
            this.tvPermissionItem.EndUpdate();
        }

        #region private void ClearCheck(TreeNode treeNode)
        /// <summary>
        /// 取消选中状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void ClearCheck(TreeNode treeNode)
        {
            if (treeNode != null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                treeNode.Checked = false;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.ClearCheck(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        /// <summary>
        /// 初始化权限设置页面
        /// </summary>
        private void ClearCheck()
        {
            // 操作权限项被选中状态取消
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.ClearCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void PermissionItemCheck()
        {
            // 递归调用到所有的子节点 
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionItemCheck(this.tvPermissionItem.Nodes[i]);
            }
        }

        private void PermissionItemCheck(TreeNode treeNode)
        {
            if (treeNode != null && treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                string permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                treeNode.Checked = Array.IndexOf(this.PermissionItemIds, permissionItemId) >= 0;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.PermissionItemCheck(treeNode.Nodes[i]);
                }
            }
        }

        private void tvPermissionItem_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 点击节点实现保存时，使用下面的方法。 comment by XuWangBin
            //if (this.isUserClick)
            //{
            //    if (e.Node.Checked)
            //    {
            //         授予操作权限
            //        RDIFrameworkService.Instance.PermissionService.GrantUserPermissionById(this.UserInfo, this.TargetUserId, (e.Node.Tag as DataRow)[PiPermissionItemTable.FieldId].ToString());
            //    }
            //    else
            //    {
            //         撤销操作权限
            //        RDIFrameworkService.Instance.PermissionService.RevokeUserPermissionById(this.UserInfo, this.TargetUserId, (e.Node.Tag as DataRow)[PiPermissionItemTable.FieldId].ToString());
            //    }

            //}
        }


        private void btnClearPermission_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0600) != System.Windows.Forms.DialogResult.OK) return;
            // 清除权限
            RDIFrameworkService.Instance.PermissionService.ClearUserPermissionByUserId(UserInfo, this.TargetUserId);
            this.GetCurrentPermission();
        }

        [Serializable]
        private class UserPermissionItem
        {
            public string[] GrantPermissionIds = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            UserPermissionItem userPermission = new UserPermissionItem();
            // 操作权限复制到剪切板
            string[] grantPermissionIds = this.GetGrantPermissionIds();
            userPermission.GrantPermissionIds = grantPermissionIds;

            Clipboard.SetData("userPermissionItem", userPermission);
            //this.btnPaste.Enabled = true;
        }

        /// <summary>
        /// 授权的操作权限
        /// </summary>
        private string GrantPermissions = string.Empty;

        private void PermissionEntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                // 提高运行速度
                string permissionItemId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    this.GrantPermissions += permissionItemId + ";";
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.PermissionEntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private string[] GetGrantPermissionIds() 批量获取操作权限选中状态
        /// <summary>
        /// 批量获取操作权限选中状态
        /// </summary>
        private string[] GetGrantPermissionIds()
        {
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.PermissionEntityToArray(this.tvPermissionItem.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            return grantPermissionIds;
        }
        #endregion

        private void btnPaste_Click(object sender, EventArgs e)
        {
            object clipboardData = Clipboard.GetData("userPermissionItem");
            if (clipboardData != null)
            {
                UserPermissionItem userPermission = (UserPermissionItem)clipboardData;

                string[] grantPermissionIds = userPermission.GrantPermissionIds;
                RDIFrameworkService.Instance.PermissionService.GrantUserPermissions(UserInfo, new string[] { this.TargetUserId }, grantPermissionIds);

                this.GetCurrentPermission();
            }
        }

        private void tvPermissionItem_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BasePageLogic.CheckChild(e.Node);
            BasePageLogic.CheckParent(e.Node);
        }

        /// <summary>
        /// 撤销的权限
        /// </summary>
        string RevokePermissions = string.Empty;

        private void EntityToArray(TreeNode treeNode)
        {
            if (treeNode.Tag != null && (treeNode.Tag as DataRow) != null)
            {
                // 提高运行速度
                string moduleId = (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString();
                if (treeNode.Checked)
                {
                    // 这里是授权的权限
                    if (Array.IndexOf(this.PermissionItemIds, moduleId) < 0)
                    {
                        this.GrantPermissions += moduleId + ";";
                    }
                }
                else
                {
                    // 这里是撤销的权限
                    if (Array.IndexOf(this.PermissionItemIds, moduleId) >= 0)
                    {
                        this.RevokePermissions += moduleId + ";";
                    }
                }
            }
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToArray(treeNode.Nodes[i]);
            }
        }

        #region private bool DoBatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private bool DoBatchSave()
        {
            bool returnValue = true;
            for (int i = 0; i < this.tvPermissionItem.Nodes.Count; i++)
            {
                this.EntityToArray(this.tvPermissionItem.Nodes[i]);
            }
            string[] grantPermissionIds = null;
            string[] revokePermissionIds = null;
            if (this.GrantPermissions.Length > 2)
            {
                this.GrantPermissions = this.GrantPermissions.Substring(0, this.GrantPermissions.Length - 1);
                grantPermissionIds = this.GrantPermissions.Split(';');
            }
            if (this.RevokePermissions.Length > 1)
            {
                this.RevokePermissions = this.RevokePermissions.Substring(0, this.RevokePermissions.Length - 1);
                revokePermissionIds = this.RevokePermissions.Split(';');
            }
            this.GrantPermissions = string.Empty;
            this.RevokePermissions = string.Empty;
            RDIFrameworkService.Instance.PermissionService.GrantUserPermissions(UserInfo, new string[] { this.TargetUserId }, grantPermissionIds);
            RDIFrameworkService.Instance.PermissionService.RevokeUserPermissions(UserInfo, new string[] { this.TargetUserId }, revokePermissionIds);
            if (SystemInfo.ShowInformation)
            {
                // 更新成功，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0012);
            }
            return returnValue;
        }
        #endregion

        public void BatchSave()
        {
            // 批量保存
            // this.CheckParentChecked();
            if (this.DoBatchSave())
            {
                // 关闭窗口
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.BatchSave();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
