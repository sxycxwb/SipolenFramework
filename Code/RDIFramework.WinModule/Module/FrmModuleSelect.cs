/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-18 9:14:32
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmModuleSelect : BaseForm
    {
        private DataTable DTModule = new DataTable(PiModuleTable.TableName);  // 模块 DataTable

        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull { get; set; }

        private bool allowSelect = true;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
            }
        }

        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        /// 检查移动
        /// </summary>
        public bool CheckMove { get; set; }

        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的组织主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
            }
        }

        private string selectedCode = string.Empty;
        /// <summary>
        /// 被选中的编号
        /// </summary>
        public string SelectedCode
        {
            get
            {
                return this.selectedCode;
            }
            set
            {
                this.selectedCode = value;
            }
        }

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的选项的全名
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        public delegate bool ButtonConfirmEventHandler();
        public event ButtonConfirmEventHandler OnButtonConfirmClick;

        private string currentEntityId = string.Empty;

        /// <summary>
        /// 当前选中的节点，树上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                if ((this.tvModule.SelectedNode != null) && (this.tvModule.SelectedNode.Tag != null))
                {
                    this.currentEntityId = ((DataRow)this.tvModule.SelectedNode.Tag)[PiModuleTable.FieldId].ToString();
                }
                return this.currentEntityId;
            }
            set
            {
                this.currentEntityId = value;
            }
        }

        public FrmModuleSelect()
        {
            AllowNull = false;
            CheckMove = false;
            MultiSelect = false;
            InitializeComponent();
        }

        public FrmModuleSelect(string currentId)
            : this()
        {
            this.CurrentEntityId = currentId;
            this.OpenId = currentId;
        }

        public FrmModuleSelect(string currentId, string parentId)
            : this()
        {
            this.OpenId = currentId;
            this.CurrentEntityId = parentId;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 权限信息
            this.DTModule = RDIFrameworkService.Instance.ModuleService.GetDT(UserInfo);
            // 有效性过滤
            BusinessLogic.SetFilter(this.DTModule, PiModuleTable.FieldEnabled, "1");
            this.DTModule.AcceptChanges();
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

            if (this.tvModule.SelectedNode == null && this.tvModule.Nodes.Count > 0)
            {
                if (this.CurrentEntityId.Length == 0)
                {
                    this.tvModule.SelectedNode = this.tvModule.Nodes[0];
                }
                else
                {
                    BasePageLogic.FindTreeNode(this.tvModule, this.CurrentEntityId);
                    if (BasePageLogic.TargetNode != null)
                    {
                        this.tvModule.SelectedNode = BasePageLogic.TargetNode;
                        // 展开当前选中节点的所有父节点
                        BasePageLogic.ExpandTreeNode(this.tvModule);
                    }
                }

                if (this.tvModule.SelectedNode != null)
                {
                    // 让选中的节点可视，并用展开方式
                    this.tvModule.SelectedNode.Expand();
                    this.tvModule.SelectedNode.EnsureVisible();
                }
            }
        }

        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            var treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            BasePageLogic.FindTreeNode(this.tvModule, this.OpenId);
            if (BasePageLogic.TargetNode != null)
            {
                this.tvModule.SelectedNode = BasePageLogic.TargetNode;
                BasePageLogic.ExpandTreeNode(this.tvModule);
                this.tvModule.SelectedNode.EnsureVisible();
                this.tvModule.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载模块树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTModule, PiModuleTable.FieldId, PiModuleTable.FieldParentId, PiModuleTable.FieldFullName, this.tvModule, treeNode);
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSelect.Enabled = this.DTModule.Rows.Count != 0;
        }

        #endregion

        private void tvModule_DoubleClick(object sender, EventArgs e)
        {
            btnConfirm_Click(sender, e);
        }

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            var returnValue = false || this.tvModule.SelectedNode != null;
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
            BasePageLogic.FindTreeNode(this.tvModule, this.OpenId);
            TreeNode treeNode = BasePageLogic.TargetNode;
            BasePageLogic.FindTreeNode(this.tvModule, this.CurrentEntityId);
            TreeNode targetTreeNode = BasePageLogic.TargetNode;
            if (!BasePageLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0036, treeNode.Text, targetTreeNode.Text));
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 当前选择的部门
                this.SelectedId = ((DataRow)this.tvModule.SelectedNode.Tag)[PiModuleTable.FieldId].ToString();
                this.SelectedCode = BusinessLogic.GetProperty(this.DTModule, this.SelectedId, PiModuleTable.FieldCode);
                this.SelectedFullName = this.tvModule.SelectedNode.Text;
                // 检查移动的有效性
                if (this.CheckMove)
                {
                    if (!this.CheckInputMove())
                    {
                        return;
                    }
                }
                if (this.OnButtonConfirmClick != null)
                {
                    if (!this.OnButtonConfirmClick())
                    {
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tvModule_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvModule.GetNodeAt(e.X, e.Y) != null)
            {
                tvModule.SelectedNode = tvModule.GetNodeAt(e.X, e.Y);
            }
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = string.Empty;
            this.SelectedFullName = string.Empty;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
