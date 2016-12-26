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
    /// FrmCommonQueryAdmin.cs
    /// 通用查询
    /// 
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2015-12-07</date>
    /// </author> 
    /// </summary>
    public partial class FrmCommonQueryAdmin : BaseForm
    {
        /// <summary>
        /// 查询引擎宝DataTable
        /// </summary>
        private DataTable DTQueryEngineDefine = new DataTable(QueryEngineDefineTable.TableName);

        /// <summary>
        /// 查询引擎宝列表DataTable
        /// </summary>
        private DataTable DTQueryEngineDefineList = new DataTable(QueryEngineDefineTable.TableName);
      
        /// <summary>
        /// 记录最后点击的控件
        /// </summary>
        private System.Windows.Forms.Control LastControl = null;

        /// <summary>
        /// 查询引擎定义主键，作为dgvList 中记录的父主键
        /// </summary>
        private string parentEntityId = string.Empty;

        /// <summary>
        /// 查询引擎定义主键，作为dgvList 中记录的查询引擎主键
        /// </summary>
        public string ParentEntityId
        {
            get
            {
                if ((this.tvList.SelectedNode != null) && (this.tvList.SelectedNode.Tag != null))
                {
                    this.parentEntityId = ((DataRow)this.tvList.SelectedNode.Tag)[QueryEngineDefineTable.FieldId].ToString();
                }
                else
                {
                    this.parentEntityId = string.Empty;
                }
                return this.parentEntityId;
            }
            set
            {
                this.parentEntityId = value;
            }
        }

        /// <summary>
        /// 权限项主键，dgvList中的选择项Id
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvList, QueryEngineDefineTable.FieldId);
            }
        }

        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        private string currentEntityId = string.Empty;
        /// <summary>
        /// 当前选中的节点，树或者表格上
        /// </summary>
        public string CurrentEntityId
        {
            get
            {
                this.currentEntityId = this.LastControl == this.tvList ? this.ParentEntityId : this.EntityId;
                return this.currentEntityId;
            }
            set { this.currentEntityId = value; }
        }

        public FrmCommonQueryAdmin()
        {
            InitializeComponent();
        }

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树的主键
            if (reloadTree)
            {
                this.LoadTree();
                if (this.tvList.SelectedNode == null && this.tvList.Nodes.Count > 0)
                {
                    if (this.parentEntityId.Length == 0)
                    {
                        this.tvList.SelectedNode = this.tvList.Nodes[0];
                    }
                    else
                    {
                        BasePageLogic.FindTreeNode(this.tvList, this.parentEntityId);
                        if (BasePageLogic.TargetNode != null)
                        {
                            this.tvList.SelectedNode = BasePageLogic.TargetNode;
                            // 展开当前选中节点的所有父节点
                            BasePageLogic.ExpandTreeNode(this.tvList);
                        }
                    }
                    if (this.tvList.SelectedNode != null)
                    {
                        // 让选中的节点可视，并用展开方式
                        this.tvList.SelectedNode.Expand();
                        this.tvList.SelectedNode.EnsureVisible();
                    }
                }
            }
            if (this.ParentEntityId.Length > 0 && reloadTree)
            {
                this.GetQueryEngineList();
            }

            this.SetControlState();
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvList);
            this.DTQueryEngineDefine = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDT(this.UserInfo);
            this.DTQueryEngineDefine.DefaultView.Sort = QueryEngineDefineTable.FieldSortCode;
            // 绑定屏幕数据
            this.BindData(true);
        }
        #endregion

        private void GetQueryEngineList()
        {
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var recordCount = 0;
            var where = QueryEngineDefineTable.FieldQueryEngineId + "='" + this.ParentEntityId + "'";

            this.DTQueryEngineDefineList = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineDTByPage(this.UserInfo, where, out recordCount, ucPager.PageIndex, ucPager.PageSize, (QueryEngineDefineTable.FieldSortCode + " desc"));
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvList.AutoGenerateColumns = false;
            this.DTQueryEngineDefineList.DefaultView.Sort = QueryEngineDefineTable.FieldSortCode;
            this.dgvList.DataSource = this.DTQueryEngineDefineList.DefaultView;
            this.SetControlState();
            this.Cursor = holdCursor;
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetQueryEngineList();
            this.Cursor = holdCursor;
        }

        #region private void LoadTree() 加载树的主键
        /// <summary>
        /// 加载树的主键
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvList.BeginUpdate();
            this.tvList.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeQueryEngine(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvList.EndUpdate();
        }
        #endregion

        #region private void LoadTreeQueryEngine(TreeNode treeNode) 加载查询引擎树
        /// <summary>
        /// 加载查询引擎树
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeQueryEngine(TreeNode treeNode)
        {
            BasePageLogic.LoadTreeNodes(this.DTQueryEngineDefine, QueryEngineTable.FieldId, QueryEngineTable.FieldParentId, QueryEngineTable.FieldFullName, this.tvList, treeNode, true, 2);
        }
        #endregion

        private void tvList_Click(object sender, EventArgs e)
        {
            this.LastControl = this.tvList;
            tvList.PathSeparator = ">";
            lblCurrentTvPath.Text = tvList.SelectedNode.FullPath;
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!this.FormLoaded) return;
            if (this.LastControl == this.tvList)
            {
                this.parentEntityId = ((DataRow)this.tvList.SelectedNode.Tag)[QueryEngineDefineTable.FieldId].ToString();
                if (this.ParentEntityId.Length > 0)
                {
                    this.GetQueryEngineList();
                }
            }
        }

        private void dgvList_Click(object sender, EventArgs e)
        {
            this.LastControl = this.dgvList;
        }

        private void GetPreviewData()
        {
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var recordCount = 0;
            QueryEngineDefineEntity queryEngineDefineEntity = RDIFrameworkService.Instance.QueryEngineService.GetQueryEngineDefineEntity(this.UserInfo, this.EntityId);
            CiDbLinkDefineEntity dblinkEntity = null;
            IDbProvider dbProvider = null;
            if (queryEngineDefineEntity != null && !string.IsNullOrEmpty(queryEngineDefineEntity.DataBaseLinkName))
            {
                dblinkEntity = RDIFrameworkService.Instance.DbLinkDefineService.GetEntity(this.UserInfo, queryEngineDefineEntity.DataBaseLinkName);
            }

            if (dblinkEntity != null)
            {
                var DbDefine = RDIFrameworkService.Instance.DbLinkDefineService.GetEntityByLinkName(this.UserInfo, dblinkEntity.LinkName);
                dbProvider = DbDefine != null ? DbFactoryProvider.GetProvider((CurrentDbType)Enum.Parse(typeof(CurrentDbType), DbDefine.LinkType, true), SecretHelper.AESDecrypt(DbDefine.LinkData))
                                        : DbFactoryProvider.GetProvider(SystemInfo.BusinessDbType, SystemInfo.BusinessDbConnectionString);

                var dtDynamicJsonDt = dbProvider.GetDTByPage(out recordCount, queryEngineDefineEntity.QueryString, ucPagerEx1.PageIndex, ucPagerEx1.PageSize, string.Empty, queryEngineDefineEntity.OrderByField);
                ucPagerEx1.RecordCount = recordCount;
                ucPagerEx1.InitPageInfo();
                this.dgvListSample.AutoGenerateColumns = true;
                this.dgvListSample.DataSource = dtDynamicJsonDt.DefaultView;
            }
            else
            {
                ucPagerEx1.RecordCount = 0;
                ucPagerEx1.InitPageInfo();
                this.dgvListSample.AutoGenerateColumns = true;
                this.dgvListSample.DataSource = null;
            }

            this.Cursor = holdCursor;
        }

        private void btnPreviewData_Click(object sender, EventArgs e)
        {
            this.ucPagerEx1.PageIndex = 1;
            GetPreviewData();
        }

        private void ucPagerEx1_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetPreviewData();
            this.Cursor = holdCursor;
        }

        private void mnuShoEngineList_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void mnuShowDataSampleList_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
        }

        private void mnuShoAll_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
