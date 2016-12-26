using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// DataGridView 带统计行以及分页测试
    /// </summary>
    public partial class FrmTestDgvSummary : BaseForm
    {
        private DataTable DTProductInfo = new DataTable(ProductInfoTable.TableName);
        IDbProvider dbProvider = null;

        public FrmTestDgvSummary()
        {
            InitializeComponent();
        }

        private void FrmTestDgvSummary_Load(object sender, EventArgs e)
        {
            dbProvider = DbFactoryProvider.GetProvider(DbLinks["ProductDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["ProductDBLink"].DbLink));
            BindData();
        }

        private void BindData()
        {
            var recordCount = 0;
            this.DTProductInfo = GetData(out recordCount, ucPager.PageIndex, ucPager.PageSize,"");
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            // 加载绑定数据
            this.GetList();
        }
      
        public override void GetList()
        {
            if (this.DTProductInfo.Columns.Count > 0)
            {
                this.DTProductInfo.DefaultView.Sort = ProductInfoTable.FieldCreateOn;
            }

            this.dgvProductInfo.DataSource = this.DTProductInfo.DefaultView;
        }

        private DataTable GetData(out int recordCount, int pageIndex, int pageSize,string search)
        {
            string selectField = "ID,PRODUCTCODE,PRODUCTNAME,PRODUCTMODEL,PRODUCTSTANDARD,PRODUCTCATEGORY,PRODUCTUNIT,MIDDLERATE,REFERENCECOEFFICIENT,PRODUCTPRICE,WHOLESALEPRICE,PROMOTIONPRICE,PRODUCTDESCRIPTION,CREATEON";
            return new ProductInfoManager(dbProvider).GetDTByPage(out recordCount, pageIndex, pageSize,ProductInfoTable.FieldCreateOn, "desc", ProductInfoTable.TableName, search, selectField);
            //return new ProductInfoManager(dbProvider).GetDTByPage(out recordCount, pageIndex, pageSize, search,ProductInfoTable.FieldCreateOn + " DESC ");
        }

        private void ucPagerEx1_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            BindData();
            this.Cursor = holdCursor;
        }
    }
}
