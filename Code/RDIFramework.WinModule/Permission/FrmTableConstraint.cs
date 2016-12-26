using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmTableConstraint
    /// 表的约束条件综合设置
    /// 
    /// </summary>
    public partial class FrmTableConstraint : BaseForm
    {
        public FrmTableConstraint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="resourceCategory">什么类型的</param>
        /// <param name="resourceId">什么资源</param>
        public FrmTableConstraint(string resourceCategory, string resourceId)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
        }

        private DataTable DataTableScope = new DataTable(PiTablePermissionScopeTable.TableName);

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

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnDeleteCondition.Enabled = false;
            this.btnSetCondition.Enabled = false;
            this.btnExport.Enabled = false;
            if (this.DataTableScope.Rows.Count > 0)
            {
                this.btnDeleteCondition.Enabled = true;
                this.btnSetCondition.Enabled = true;
                this.btnExport.Enabled = true;
            }
        }
        #endregion

        private void GetResourceInfo()
        {
            if (this.ResourceCategory == PiRoleTable.TableName)
            {
                this.txtUserOrRole.Text = RDIFrameworkService.Instance.RoleService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            if (this.ResourceCategory == PiUserTable.TableName)
            {
                this.txtUserOrRole.Text = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetResourceInfo();
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(this.dgvTable);
            // 获得列表
            this.GetList();
            // 测试表达式是否正确
            //this.Text = RDIFrameworkService.Instance.TableColumnsService.GetUserConstraint(this.UserInfo, "ProductInfo");
        }
        #endregion

        #region public override void GetList() 获取角色列表
        /// <summary>
        /// 获取角色列表
        /// </summary>
        public override void GetList()
        {
            this.DataTableScope = RDIFrameworkService.Instance.TableColumnsService.GetConstraintDT(this.UserInfo, this.ResourceCategory, this.ResourceId);
            this.dgvTable.AutoGenerateColumns = false;
            this.DataTableScope.DefaultView.Sort = PiTablePermissionScopeTable.FieldSortCode;
            this.dgvTable.DataSource = this.DataTableScope.DefaultView;
        }
        #endregion

        private void dgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnSetCondition.PerformClick();
        }

        private int DeleteCondition()
        {
            int iResult = 0;
            // 检查至少要选择一个？
            if (!BasePageLogic.CheckInputSelectAnyOne(this.dgvTable, "colSelected"))
            {
                return iResult;
            }
            // 是否确认删除了？
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) != DialogResult.Yes)
            {
                return iResult;
            }
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string[] ids = BasePageLogic.GetSelecteIds(this.dgvTable, PiPermissionScopeTable.FieldId, "colSelected", true);
                
                iResult = RDIFrameworkService.Instance.TableColumnsService.BatchDeleteConstraint(this.UserInfo, ids);
                // 重新加载数据，先刷新屏幕，再显示提示信息
                this.FormOnLoad();
                // 是否需要有提示信息？
                if (SystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0077, iResult.ToString()));
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
            return iResult;
        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            this.DeleteCondition();
        }

        private void SetCondition()
        {
            DataRow dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvTable);
            string tableName = dataRow[CiTableColumnsTable.FieldTableCode].ToString();
            var frmTableScopeCondition = new FrmSetTableConstraint(this.ResourceCategory, this.ResourceId, tableName);
            if (frmTableScopeCondition.ShowDialog(this) == DialogResult.OK)
            {
                this.FormOnLoad();
            }
        }

        private void btnSetCondition_Click(object sender, EventArgs e)
        {
            this.SetCondition();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string exportFileName = this.Text + ".xls";
            this.ExportToExcel(this.dgvTable, @"\Modules\Export\", exportFileName);
        }
    }
}
