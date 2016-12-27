using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmProductAdmin
    /// 商品管理
    /// 
    /// 修改记录
    ///     2016-03-16 XuWangBin V3.0 对产品新增与修改界面做到实体与界面控件的自动绑定与自动获取，减少大量代码。
    ///     2016-01-10 XuWangBin V3.0 新增在窗体中打开界面时可以在主界面的Tab页中打开（如：增加界面，修改界面等，参考产品管理实例）。
    ///     2014-12-26 王进 V2.8 新新对RDLC报表的打印支持。
    ///     2014-12-15 王进 V2.8 新增按“表约束条件”获取数据。
    ///     2014-09-17 XuWangBin V2.8 修改按新的分页方式（非存储过程）来进行分页。
    ///     2012-06-17 XuWangBin 创建“产品管理”。
    /// </summary>
    public partial class FrmProductAdmin : BaseForm
    {
        /// <summary>
        /// 产品信息
        /// </summary>
        private DataTable DTProductInfo = new DataTable(ProductInfoTable.TableName);
        IDbProvider dbProvider = null;
        private string searchValue = "";
        private string userConstraintExpress = ""; //表约束条件

        #region public override string EntityId 产品主键
        /// <summary>
        /// 产品主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvProductInfo, ProductInfoTable.FieldId);
            }
        }
        #endregion

        #region 权限控制部分
        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的修改权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 本模块的作废权限
        /// </summary>
        private bool permissionDisannul = false;

        /// <summary>
        /// 本模块的查找权限
        /// </summary>
        private bool permissionFind = false;
        

        #region public override void GetPermission() 获得权限
        /// <summary>
        /// 获得权限
        /// </summary>
        public override void GetPermission()
        {    
            this.permissionAccess   = this.IsModuleAuthorized("ProductAdmin");
            this.permissionAdd      = this.IsAuthorized("ProductAdmin.Add");
            this.permissionEdit     = this.IsAuthorized("ProductAdmin.Edit");
            this.permissionDisannul = this.IsAuthorized("ProductAdmin.Disannul");
            this.permissionDelete   = this.IsAuthorized("ProductAdmin.Delete");
            this.permissionFind     = this.IsAuthorized("ProductAdmin.Find");
        }
        #endregion

        #region public override void SetControlState() 按钮的状态设置
        /// <summary>
        /// 按钮的状态设置
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled = this.permissionAdd;
            // 是否有数据的判断
            if (this.DTProductInfo.DefaultView.Count <= 0)
            {                
                this.btnEdit.Enabled     = false;
                this.btnDelete.Enabled   = false;
                this.btnDisannul.Enabled = false;
                this.btnFind.Enabled     = false;
                
            }
            else
            {
                this.btnEdit.Enabled     = this.permissionEdit;
                this.btnDelete.Enabled   = this.permissionDelete;
                this.btnDisannul.Enabled = this.permissionDisannul;
                this.btnFind.Enabled     = this.permissionFind;
            }           
        }
        #endregion

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmProductAdmin()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            //得到数据提供者（指定数据库类型【默认为：MsSqlserver】与数据库连接字符串【解密后】）
            dbProvider = DbFactoryProvider.GetProvider(DbLinks["ProductDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["ProductDBLink"].DbLink));
            BindCategory();
            //userConstraintExpress = RDIFrameworkService.Instance.TableColumnsService.GetConstraint(this.UserInfo, PiUserTable.TableName, this.UserInfo.Id, ProductInfoTable.TableName); //按表约束条件获得数据（按当前用户）。
            userConstraintExpress = RDIFrameworkService.Instance.TableColumnsService.GetUserConstraint(this.UserInfo, ProductInfoTable.TableName); //按表约束条件获得数据(得到用户与角色的约束条件)。
            //绑定数据
            this.Search();
        }

        private void Search()
        {
            var recordCount = 0;
            if (!string.IsNullOrEmpty(userConstraintExpress))
            {
                if (!string.IsNullOrEmpty(this.searchValue))
                {
                    this.searchValue += " AND " + userConstraintExpress;
                }
                else
                {
                    this.searchValue = userConstraintExpress;
                }
            }
            this.DTProductInfo = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize, this.searchValue);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.GetList();
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize,string search)
        {
            return new ProductInfoManager(dbProvider, this.UserInfo).GetDTByPage(out recordCount, pageIndex, pageSize, search, ProductInfoTable.FieldCreateOn + " DESC ");
        }

        #region public override void GetList() 得到数据以绑定产品信息界面
        public override void GetList()
        {
            this.dgvProductInfo.AutoGenerateColumns = false;
            if (this.DTProductInfo.Columns.Count > 0)
            {
                this.DTProductInfo.DefaultView.Sort = ProductInfoTable.FieldCreateOn;
            }
            this.dgvProductInfo.DataSource = this.DTProductInfo.DefaultView;
            this.SetControlState();
        }
        #endregion

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            Search();
            this.Cursor = holdCursor;
        }

        #region  private void BindCategory() 绑定下拉框
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        private void BindCategory()
        {
            //如果下拉框类型为:ComboBox，同可以用：BasePageLogic.BindCategory方法进行绑定，如：
            //BasePageLogic.BindCategory(base.UserInfo, cboProductCategory, "ProductCategory");

            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(base.UserInfo, "ProductCategory");
            if (dtItemDetail != null && dtItemDetail.Rows.Count > 0)
            {
                cboProductCategory.Items.Clear();
                cboProductCategory.Items.Insert(0,string.Empty);
                cboProductCategory.Items.AddRange(BusinessLogic.FieldToArray(dtItemDetail, CiItemDetailsTable.FieldItemValue));
            }
        }
        #endregion

        private void cboProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            var search = this.cboProductCategory.Text;
            this.searchValue = !string.IsNullOrEmpty(search)
                ? ProductInfoTable.FieldProductCategory + " LIKE '" + BusinessLogic.GetSearchString(search) + "'"
                : "";
            this.Search();
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmProductEdit {DbLinks = this.DbLinks};
            if (frmProductEdit.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.Search();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmProductEdit(this.EntityId) {DbLinks = this.DbLinks};
            if (frmProductEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.Search();
            }
        }

        private void btnAddToTab_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmProductEdit { DbLinks = this.DbLinks };
            this.ShowFormInMainTab(frmProductEdit, "frmProductEdit", btnAdd.Image);
            frmProductEdit.OnFormClosedRefreash += new FormClosedRefreashEventHandler(OnFormClosedRefreash);
        }

        private void btnEditToTab_Click(object sender, EventArgs e)
        {
            var frmProductEdit = new FrmProductEdit(this.EntityId) { DbLinks = this.DbLinks };
            this.ShowFormInMainTab(frmProductEdit, "frmProductEdit", btnEdit.Image);
            frmProductEdit.OnFormClosedRefreash += new FormClosedRefreashEventHandler(OnFormClosedRefreash);
        }

        public void OnFormClosedRefreash()
        {
            this.Search();
        }

        private void btnDisannul_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.CurrentCell == null || dgvProductInfo.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBoxHelper.Show("确定作废当前所选产品信息？") != DialogResult.Yes) return;
            if (new ProductInfoManager(dbProvider).SetProductDisannul(this.EntityId) > 0)
            {
                this.Search();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("操作失败！");
            }
        }

        private bool DeleteData()
        {
            return new ProductInfoManager(dbProvider, this.UserInfo).DeleteProduct(this.EntityId) > 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.CurrentCell == null || dgvProductInfo.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBoxHelper.Show("确定删除当前所选产品信息？") != DialogResult.Yes) return;
            if (DeleteData())
            {
                MessageBoxHelper.ShowSuccessMsg("删除数据成功！");
                this.Search();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("删除数据失败！");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var frmProductSearch = new FrmProductSearch();
            if (frmProductSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.Search();
            }

            DataGridViewRow dRow = dgvProductInfo.CurrentRow;
            if (dRow != null)
            {
                for (int idx = 0; idx <= dRow.Cells.Count; idx++)
                {
                    string cellValue = BusinessLogic.ConvertToString(dRow.Cells["列名称"].Value);
                }
            }

        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            this.FormOnLoad();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("确定关闭吗？") != DialogResult.Yes)
            {
                return;
            }

            this.Close();    
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //调用Sqlserver存储过程增加数据测试
            var dbParameters = new List<IDbDataParameter>();
            string returnVar1 = string.Empty;
            object returnVar2 = -1;
            dbParameters.Add(DBProvider.MakeParameter("czlx", "Add"));   //操作类型            
            dbParameters.Add(DBProvider.MakeParameters("cgbz", returnVar2, DbType.Int64, 8, ParameterDirection.Output)); //返回的成功标志 1成功,2失败
            dbParameters.Add(DBProvider.MakeParameters("cgts", returnVar1, DbType.String, 100, ParameterDirection.Output)); //返回的提示信息
            dbParameters.Add(DBProvider.MakeParameter("ID", BusinessLogic.NewGuid()));
            dbParameters.Add(DBProvider.MakeParameter("PRODUCTCODE", "测试代码"));
            dbParameters.Add(DBProvider.MakeParameter("PRODUCTNAME", "测试名称" + DateTimeHelper.GetDate(DateTime.Now)));
            dbParameters.Add(DBProvider.MakeParameter("PRODUCTUNIT", "元"));
            dbParameters.Add(DBProvider.MakeParameter("PRODUCTDESCRIPTION", ""));
            dbParameters.Add(DBProvider.MakeParameter("PRODUCTPRICE", 86.04));
            dbParameters.Add(DBProvider.MakeParameter("ENABLED", 1));
            dbParameters.Add(DBProvider.MakeParameter("DELETEMARK", 0));
            dbParameters.Add(DBProvider.MakeParameter("CREATEUSERID", UserInfo.Id));
            dbParameters.Add(DBProvider.MakeParameter("CREATEBY", UserInfo.UserName));
            dbParameters.Add(DBProvider.MakeParameter("MODIFIEDUSERID", UserInfo.Id));
            dbParameters.Add(DBProvider.MakeParameter("MODIFIEDBY", UserInfo.UserName));           
            int returnValue = dbProvider.ExecuteProcedure("P_IN_CASE_PRODUCTINFO", dbParameters.ToArray());
            returnVar1 = BusinessLogic.ConvertToString(dbParameters[2].Value); 
            
            returnVar2 = dbParameters[1].Value;
            string aa = "";
        }

        //事务测试
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dbProvider.Open();
            dbProvider.BeginTransaction();
            try
            {
                string sql = "insert into test1(Id,Col1,Col2,Col3) values('" + BusinessLogic.NewGuid() +"','abcd',2,'kk')";
                int value1 = dbProvider.ExecuteNonQuery(sql);
                //sql = "insert into test2(Id,Col1,Col2) values('" + BusinessLogic.NewGuid() + "','4','kk')";
                sql = "insert into test2(Id,Col2) values('" + BusinessLogic.NewGuid() + "','kk')";
                int value2 = dbProvider.ExecuteNonQuery(sql); //插入失败，则第一条语句也失败。
                dbProvider.CommitTransaction();
            }
            catch (Exception ex)
            {
                dbProvider.RollbackTransaction();
                MessageBoxHelper.ShowErrorMsg(ex.Message);
            }
            finally
            {
                dbProvider.Close();
            }

        }

        private void dgvProductInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //按回车弹出提示、可以扩展为弹出窗体弹出数据。
            /*
            if (e.KeyChar == 'r')
            {
                DataGridView dgv = sender as DataGridView;
                DataGridViewCell cell = dgv.CurrentCell;
                if (cell.IsInEditMode)
                {
                    //限制单元格只能输入test 
                    if (cell.EditedFormattedValue != null && cell.EditedFormattedValue.ToString() != "test")
                    {
                        MessageBox.Show("输入内容不合格");
                    }
                    else
                    {
                        dgv.CurrentCell = dgv[cell.ColumnIndex, cell.RowIndex + 1];
                    }
                }
            }
            */
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportCommonTool fmReport = new ReportCommonTool(this.DTProductInfo);
                //显示该窗体
                fmReport.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("您还没有获得数据!");
            }
        }


    }
}
