/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 16:46:37
 ******************************************************************************/
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmModuleConfig
    /// 模块配置(使模块是否可用，移动模块等)。
    /// 
    /// </summary>
    public partial class FrmModuleConfig : BaseForm
    {
        /// <summary>
        /// 模块菜单数据表
        /// </summary>
        private DataTable DTModule = new DataTable(PiModuleTable.TableName);

        /// <summary>
        /// 原先被选中的节点主键
        /// </summary>
        public string OldEntityId = string.Empty;

        private bool permissionAccess = false;   // 访问权限
        private bool permissionEdit = false;   // 编辑权限

        private bool isUserClick = false;    // 是否是用户点击了复选框

        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvModuleList.SelectedNode != null) && (this.tvModuleList.SelectedNode.Tag != null))
                {
                    this.currentEntityId = ((DataRow)this.tvModuleList.SelectedNode.Tag)[PiModuleTable.FieldId].ToString();                    
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }

        public FrmModuleConfig()
        {
            InitializeComponent();
        }

        public FrmModuleConfig(string currentId)
            : this()
        {
            this.CurrentEntityId = currentId;
            this.OldEntityId = currentId;
        }

        #region private void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.isUserClick = false;
            this.DTModule = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);
            // 有效性过滤，这个千万不能过滤的，这个过滤了，有效就设置不回来了
            // BusinessLogic.SetFilter(this.DSModule.Tables[PiModuleTable.TableName], PiModuleTable.FieldEnabled, "1");
            // this.DSModule.Tables[PiModuleTable.TableName].AcceptChanges();
            this.BindData(true);
            //this.tvModuleList.ExpandAll();
            this.isUserClick = true;
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载模块树</param>
        private void BindData(bool reloadTree)
        {
            // 加载模块树的主键
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvModuleList.SelectedNode == null)
            {
                if (this.tvModuleList.Nodes.Count > 0)
                {
                    if (this.CurrentEntityId.Length == 0)
                    {
                        this.tvModuleList.SelectedNode = this.tvModuleList.Nodes[0];
                    }
                    else
                    {
                        BasePageLogic.FindTreeNode(this.tvModuleList, this.CurrentEntityId);
                        if (BasePageLogic.TargetNode != null)
                        {
                            this.tvModuleList.SelectedNode = BasePageLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BasePageLogic.ExpandTreeNode(this.tvModuleList);
                        }
                    }
                    if (this.tvModuleList.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvModuleList.SelectedNode.Expand();
                        this.tvModuleList.SelectedNode.EnsureVisible();
                    }
                }
            }
        }
        #endregion

        #region private void LoadTree() 加载树形结构数据
        /// <summary>
        /// 加载树形结构数据
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModuleList.BeginUpdate();
            this.tvModuleList.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            BasePageLogic.FindTreeNode(this.tvModuleList, this.OldEntityId);
            if (BasePageLogic.TargetNode != null)
            {
                this.tvModuleList.SelectedNode = BasePageLogic.TargetNode;
                BasePageLogic.ExpandTreeNode(this.tvModuleList);
                this.tvModuleList.SelectedNode.EnsureVisible();
                this.tvModuleList.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModuleList.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            foreach (DataRow dataRow in this.DTModule.Rows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow) != null) && ((treeNode.Tag as DataRow)[PiModuleTable.FieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[PiModuleTable.FieldId].ToString().Equals(dataRow[PiModuleTable.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(PiModuleTable.FieldParentId) || (dataRow[PiModuleTable.FieldParentId].ToString().Length == 0) || (dataRow[PiModuleTable.FieldParentId].ToString().Equals("0")) || (dataRow[PiModuleTable.FieldParentId].ToString().Equals(SystemInfo.RootMenuCode)) || ((treeNode.Tag != null) && (treeNode.Tag as DataRow)[PiModuleTable.FieldId].ToString().Equals(dataRow[PiModuleTable.FieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();

                    // 写入调试信息
                    #if (DEBUG)
                        newTreeNode.Text = dataRow[PiModuleTable.FieldFullName].ToString() + " [" + dataRow[PiModuleTable.FieldCode].ToString() + "]";
                    #else
                        newTreeNode.Text = dataRow[PiModuleTable.FieldFullName].ToString();
                    #endif

                    newTreeNode.Tag = dataRow;
                    newTreeNode.Checked = (dataRow[PiModuleTable.FieldEnabled].ToString().Equals("1"));

                    if (dataRow[PiModuleTable.FieldExpand].ToString().Equals("1"))
                    {
                        newTreeNode.Expand();
                    }
                    else
                    {
                        newTreeNode.Collapse(true);
                    }
                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[PiModuleTable.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        this.tvModuleList.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                    }
                    // 递归调用本函数
                    this.LoadTreeModule(newTreeNode);
                }
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess = this.IsModuleAuthorized("ModuleManagement");    // 访问权限
            this.permissionEdit = this.IsAuthorized("ModuleManagement.Edit");      // 编辑权限
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            if (this.DTModule.DefaultView.Count == 0)
            {
                this.cmnuSelectAll.Enabled = false;
                this.cmnuInvertSelect.Enabled = false;
                this.btnSave.Enabled = false;
            }
            else
            {
                this.cmnuSelectAll.Enabled = this.permissionEdit;
                this.cmnuInvertSelect.Enabled = this.permissionEdit;
                this.btnSave.Enabled = this.permissionEdit;
            }
        }
        #endregion

        private void tvModuleList_DragDrop(object sender, DragEventArgs e)
        {
            // 定义一个中间变量
            TreeNode treeNode;
            //判断拖动的是否为TreeNode类型，不是的话不予处理
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                //定义一个位置点的变量，保存当前光标所处的坐标点
                Point Point;
                //拖放的目标节点
                TreeNode targetTreeNode;
                //获取当前光标所处的坐标
                Point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                //根据坐标点取得处于坐标点位置的节点
                targetTreeNode = ((TreeView)sender).GetNodeAt(Point);
                //获取被拖动的节点
                treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //判断拖动的节点与目标节点是否是同一个,同一个不予处理
                if (BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                {
                    if (SystemInfo.ShowInformation)
                    {
                        // 是否移动部门
                        if (MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0038, treeNode.Text, targetTreeNode.Text)) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }
                    RDIFrameworkService.Instance.ModuleService.MoveTo(UserInfo, (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(), (targetTreeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString());
                    // 往目标节点中加入被拖动节点的一份克隆
                    targetTreeNode.Nodes.Add((TreeNode)treeNode.Clone());
                    // 将被拖动的节点移除
                    treeNode.Remove();
                }
            }
        }

        private void tvModuleList_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvModuleList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (this.permissionEdit)
            {
                // 开始进行拖放操作，并将拖放的效果设置成移动。
                this.DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        #region private void SetTreeNodesSelected(TreeNode treeNode, bool selected) 递规设置树的选择状态
        /// <summary>
        /// 递规设置树的选择状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        /// <param name="selected">选择</param>
        private void SetTreeNodesSelected(TreeNode treeNode, bool selected)
        {
            if ((treeNode != null) && (treeNode.Tag != null) && (treeNode.Tag as DataRow) != null)
            {
                treeNode.Checked = selected;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.SetTreeNodesSelected(treeNode.Nodes[i], selected);
                }
            }
        }
        #endregion

        private void tvModuleList_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (this.isUserClick)
            {
                if (!this.permissionEdit)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tvModuleList_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModuleList.Nodes.Count; i++)
            {
                this.SetTreeNodesSelected(this.tvModuleList.Nodes[i], true);
            }
            this.isUserClick = true;
        }

        #region private void SetTreeNodesTurnSelected(TreeNode treeNode) 递规设置树的反选状态
        /// <summary>
        /// 递规设置树的反选状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void SetTreeNodesTurnSelected(TreeNode treeNode)
        {
            if ((treeNode != null) && (treeNode.Tag != null) && (treeNode.Tag as DataRow) != null)
            {
                treeNode.Checked = !treeNode.Checked;
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    // 这里进行递规操作
                    this.SetTreeNodesTurnSelected(treeNode.Nodes[i]);
                }
            }
        }
        #endregion

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            this.isUserClick = false;
            for (int i = 0; i < this.tvModuleList.Nodes.Count; i++)
            {
                this.SetTreeNodesTurnSelected(this.tvModuleList.Nodes[i]);
            }
            this.isUserClick = true;
        }

        private void EntityToDataTable(TreeNode treeNode)
        {
            // 提高运行速度
            DataRow[] dataRows = this.DTModule.Select(PiModuleTable.FieldId + "='" + (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString() + "'");
            foreach (DataRow dataRow in dataRows)
            {
                dataRow[PiModuleTable.FieldEnabled] = treeNode.Checked ? 1 : 0;
            }
            // BusinessLogic.SetProperty(this.DSModule.Tables[PiModuleTable.TableName], (treeNode.Tag as DataRow)[BusinessLogic.FieldId].ToString(), PiModuleTable.FieldEnabled, TreeNode.Checked ? 1 : 0);
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                // 这里进行递规操作
                this.EntityToDataTable(treeNode.Nodes[i]);
            }
        }

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            for (int i = 0; i < this.tvModuleList.Nodes.Count; i++)
            {
                this.EntityToDataTable(this.tvModuleList.Nodes[i]);
            }
            RDIFrameworkService.Instance.ModuleService.BatchSave(UserInfo, this.DTModule);
            if (SystemInfo.ShowInformation)
            {
                // 批量保存，进行提示
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
            }
        }
        #endregion

        private void ReSet()
        {
            // 重新获取客户端的缓存模块数据
            ClientCache.Instance.DTMoule = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);
            ClientCache.Instance.DTUserMoule = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                this.BatchSave();
                // 重新获取客户端的缓存模块数据
                this.ReSet();
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

        private void tvModuleList_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModuleList.GetNodeAt(e.X, e.Y) != null)
            {
                tvModuleList.SelectedNode = tvModuleList.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }
    }
}
