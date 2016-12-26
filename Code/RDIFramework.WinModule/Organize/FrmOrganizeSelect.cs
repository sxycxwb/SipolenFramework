/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-12 9:56:12
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
    /// FrmOrganizeSelect
    /// 
    /// 组织机构选择
    /// </summary>
    public partial class FrmOrganizeSelect : BaseForm
    {
        private DataTable DTOrganize = new DataTable(PiOrganizeTable.TableName); // 组织机构

        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull { get; set; }

        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        /// 检查移动
        /// </summary>
        public bool CheckMove { get; set; }

        /// <summary>
        /// 按什么权限域获取组织列表
        /// </summary>
        public string PermissionScopeCode { get; set; }

        /// <summary>
        /// 被选中的组织主键
        /// </summary>
        public string SelectedId { get; set; }

        /// <summary>
        /// 被选中的组织全名
        /// </summary>
        public string SelectedFullName { get; set; }

        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId { get; set; }

        public event BusinessLogic.CheckMoveEventHandler OnButtonConfirmClick;

        private string currentEntityId = string.Empty;

        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.currentEntityId = ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }
        /// <summary>
        /// 通过本窗体调用另外窗体(gwb)
        /// </summary>
        private FrmOrganizeAdmin parentForm;

        public FrmOrganizeSelect(FrmOrganizeAdmin parent)
        {
            PermissionScopeCode = string.Empty;
            SelectedId = string.Empty;
            SelectedFullName = string.Empty;
            OpenId = string.Empty;
            AllowNull = false;
            MultiSelect = false;
            CheckMove = false;
            parentForm = parent;
        }

        #region public FrmOrganizeSelect() 构造函数
        public FrmOrganizeSelect()
        {
            PermissionScopeCode = string.Empty;
            SelectedId = string.Empty;
            SelectedFullName = string.Empty;
            OpenId = string.Empty;
            AllowNull = false;
            MultiSelect = false;
            CheckMove = false;
            InitializeComponent();
        }

        public FrmOrganizeSelect(string currentId)
            : this()
        {
            this.CurrentEntityId = currentId;
            this.OpenId = currentId;
        }

        public FrmOrganizeSelect(string currentId, bool isInnerOrganize)
            : this(currentId)
        {
            this.chkInnerOrganize.Checked = isInnerOrganize;
        }

        public FrmOrganizeSelect(string currentId, string parentId)
            : this()
        {
            this.OpenId = currentId;
            this.CurrentEntityId = parentId;
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.DTOrganize = this.GetOrganizeScope(this.PermissionScopeCode, this.chkInnerOrganize.Checked);
            
            //this.DataTableAddColumn();
            // 只要有效的数据
            BusinessLogic.SetFilter(this.DTOrganize, PiOrganizeTable.FieldEnabled, "1");
            this.DTOrganize.DefaultView.Sort = PiOrganizeTable.FieldSortCode;           
            // 加载树
            this.BindData(true);
        }
        #endregion

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加部门载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                this.LoadTree();
            }
            if (this.tvOrganize.SelectedNode != null) return;
            if (this.tvOrganize.Nodes.Count > 0)
            {
                if (this.CurrentEntityId.Length == 0)
                {
                    this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                }
                else
                {
                    BasePageLogic.FindTreeNode(this.tvOrganize, this.CurrentEntityId);
                    if (BasePageLogic.TargetNode != null)
                    {
                        this.tvOrganize.SelectedNode = BasePageLogic.TargetNode;
                        // 展开当前选中节点的所有父节点
                        BasePageLogic.ExpandTreeNode(this.tvOrganize);
                    }
                }
            }
            if (this.tvOrganize.SelectedNode == null) return;
            // 让选中的节点可视，并用展开方式
            this.tvOrganize.SelectedNode.Expand();
            this.tvOrganize.SelectedNode.EnsureVisible();
            // 防止只有一个父节点的情况下，无法展开情况发生
            this.GetOrganizeList();
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            var treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
            BasePageLogic.FindTreeNode(this.tvOrganize, this.OpenId);
            if (BasePageLogic.TargetNode != null)
            {
                this.tvOrganize.SelectedNode = BasePageLogic.TargetNode;
                BasePageLogic.ExpandTreeNode(this.tvOrganize);
                this.tvOrganize.SelectedNode.EnsureVisible();
                this.tvOrganize.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode)
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
            //BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode,true,2);
            BasePageLogic.LoadTreeNodes(this.DTOrganize, PiOrganizeTable.FieldId, PiOrganizeTable.FieldParentId, PiOrganizeTable.FieldFullName, this.tvOrganize, treeNode, !SystemInfo.OrganizeDynamicLoading);
        }
        #endregion

        private void chkInnerOrganize_CheckedChanged(object sender, EventArgs e)
        {
            this.OnLoad(e);
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSelect.Enabled = this.DTOrganize.Rows.Count != 0;
        }

        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            var returnValue = false || this.tvOrganize.SelectedNode != null;

            if (!returnValue)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
            }
            
            return returnValue;
        }
        #endregion

        #region private bool CheckInputMove() 检查能否移动
        /// <summary>
        /// 检查能否移动
        /// </summary>
        /// <returns>能否移动到目标位置</returns>
        private bool CheckInputMove()
        {
            var returnValue = true;
            // 单个移动检查
            BasePageLogic.FindTreeNode(this.tvOrganize, this.OpenId);
            var treeNode = BasePageLogic.TargetNode;
            BasePageLogic.FindTreeNode(this.tvOrganize, this.CurrentEntityId);
            TreeNode targetTreeNode = BasePageLogic.TargetNode;
            if (BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode)) return returnValue;
            MessageBox.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text), RDIFrameworkMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            returnValue = false;
            return returnValue;
        }
        #endregion       

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    tvOrganize.PathSeparator = ">";
                    lblCurrentTvPath.Text = tvOrganize.SelectedNode.FullPath;
                    this.GetOrganizeList();
                }
            }
        }

        private void tvOrganize_Click(object sender, EventArgs e)
        {
            /*            
            if (this.FormLoaded)
            {
                if (this.tvOrganize.SelectedNode != null)
                {
                    this.GetOrganizeList();
                }
            }
            */
        }

        #region private void GetOrganizeList() 获得子部门列表
        /// <summary>
        /// 获得子部门列表
        /// </summary>
        private void GetOrganizeList()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 动态加载树形结构
            if (this.tvOrganize.SelectedNode.Nodes.Count == 0)
            {
                var DTOrganizeList = RDIFrameworkService.Instance.OrganizeService.GetDTByParent(UserInfo, ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString());
                DTOrganizeList.DefaultView.Sort = PiOrganizeTable.FieldSortCode;
                foreach (DataRow dataRow in DTOrganizeList.Rows)
                {
                    var treeNode = new TreeNode
                    {
                        Text = dataRow[PiOrganizeTable.FieldFullName].ToString(),
                        //Tag = dataRow[PiOrganizeTable.FieldId].ToString()
                        Tag = dataRow
                    };
                    this.tvOrganize.SelectedNode.Nodes.Add(treeNode);
                }
                this.tvOrganize.SelectedNode.Expand();
                // 设置按钮状态
                this.SetControlState();
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }
        #endregion

        private void tvOrganize_DoubleClick(object sender, EventArgs e)
        {
            //if (!SystemInfo.OrganizeDynamicLoading)
            //{
            this.btnSelect.PerformClick();
            //}
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!this.CheckInput()) return;
            this.SelectedId = ((DataRow)this.tvOrganize.SelectedNode.Tag)[PiOrganizeTable.FieldId].ToString();
            this.SelectedFullName = this.tvOrganize.SelectedNode.Text;
              
            // 检查移动的有效性
            if (this.CheckMove && !this.CheckInputMove())
            {
                return;
            }
            if (this.OnButtonConfirmClick != null)
            {
                if (!this.OnButtonConfirmClick(this.SelectedId)) return;
                this.DialogResult = DialogResult.OK;
                this.Close();
                // 调用FrmOrganizeAdmin的窗体加载事件(gwb)
                parentForm = new FrmOrganizeAdmin();
                parentForm.FormOnLoad();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }
    }
}
