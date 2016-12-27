using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmTableFieldAdmin.cs
    /// 表字段综合管理
    /// 
    /// 修改记录：
    ///     2013-02-18 XuWangBin 版本2.0 新增FrmTableFieldAdmin。
    ///     
    /// </summary>
    public partial class FrmTableFieldAdmin : BaseForm
    {
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTTableColumns = new DataTable(CiTableColumnsTable.TableName);

        /// <summary>
        /// 目标数据表代码
        /// </summary>
        public string TargetTableCode
        {
            get
            {
                string tableCode = string.Empty;
                if (this.lbTableList.SelectedItem != null)
                {
                    tableCode = this.lbTableList.SelectedValue.ToString();
                }
                return tableCode;
            }
        }

        /// <summary>
        /// 本模块的保存权限
        /// </summary>
        private bool permissionBatchSave = false;

        /// <summary>
        /// 本模块的表字段权限控制权限
        /// </summary>
        private bool permissionSetTablePermission = false;

        /// <summary>
        /// 本模块的导出权限
        /// </summary>
        private bool permissionExport = false;

        public FrmTableFieldAdmin()
        {
            InitializeComponent();
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionBatchSave = this.IsAuthorized("TableFieldAdmin.BatchSave");
            this.permissionExport = this.IsAuthorized("TableFieldAdmin.Export");
            this.permissionSetTablePermission = this.IsAuthorized("TableFieldAdmin.SetTablePermission");
           
        }
        #endregion

        public override void SetControlState()
        {
            this.btnBatchSave.Enabled = false;
            this.btnSetTablePermission.Enabled = false;
            this.btnExport.Enabled = false;
            if (this.DTTableColumns.Rows.Count > 0)
            {
                this.btnBatchSave.Enabled = this.permissionBatchSave;
                this.btnExport.Enabled = this.permissionExport;
                this.btnSetTablePermission.Enabled = this.permissionSetTablePermission;
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(this.dgvTableFieldList);
            this.GetTableList();
        }
        #endregion

        /// <summary>
        /// 得到所有数据表
        /// </summary>
        private void GetTableList()
        {
            var DTTableList = RDIFrameworkService.Instance.TableColumnsService.GetTableNameAndCode(this.UserInfo);
            this.lbTableList.ValueMember = CiTableColumnsTable.FieldTableCode;
            this.lbTableList.DisplayMember =CiTableColumnsTable.FieldTableName;
            this.lbTableList.DataSource = DTTableList.DefaultView;
        }

        private void GetCurrentTableFieldList()
        {
            this.DTTableColumns = RDIFrameworkService.Instance.TableColumnsService.GetDTByTable(this.UserInfo, this.TargetTableCode);
            this.dgvTableFieldList.AutoGenerateColumns = false;
            this.DTTableColumns.DefaultView.Sort = CiTableColumnsTable.FieldSortCode;
            this.dgvTableFieldList.DataSource = this.DTTableColumns.DefaultView;
            this.SetControlState();
        }

        private void lbTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.GetCurrentTableFieldList();
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

        #region private void BatchSave() 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        private void BatchSave()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                RDIFrameworkService.Instance.TableColumnsService.BatchSave(UserInfo, this.DTTableColumns);                
                if (SystemInfo.ShowInformation)
                {
                    // 批量保存，进行提示
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0012);
                }
            }
            catch (System.Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
        }
        #endregion

        public void Save()
        {
            // 检查批量输入的有效性
            if (!BasePageLogic.CheckInputModifyAnyOne(this.DTTableColumns)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 批量保存
                this.BatchSave();
                // 更新datatable的状态，防止无法二次修改的问题
                this.DTTableColumns.AcceptChanges();
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

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string exportFileName = this.Text + ".xls";
            this.ExportToExcel(this.dgvTableFieldList, @"\Modules\Export\", exportFileName); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.IsModfiedAnyOne(DTTableColumns, false) &&
                MessageBoxHelper.Show(RDIFrameworkMessage.MSG0045) == System.Windows.Forms.DialogResult.Yes)
            {
                this.BatchSave();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //设置需要做表（字段）权限控制的数据表
        private void btnSetTablePermission_Click(object sender, EventArgs e)
        {
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmSetTablePermission";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmTableColumnPermission = (Form)Activator.CreateInstance(assemblyType);
            frmTableColumnPermission.ShowDialog(this);
        }
    }
}
