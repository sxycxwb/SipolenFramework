using System;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 产品编辑
    /// FrmProductEdit
    /// 
    /// </summary>
    public partial class FrmProductEdit : BaseForm
    {
        private ProductInfoEntity currentProductInfoEntity = null;
        IDbProvider dbProvider = null;

        public FrmProductEdit()
        {
            InitializeComponent();
        }

        public FrmProductEdit(string productId):this()
        {            
            this.EntityId = productId;
        }

        public override void FormOnLoad()
        {
            dbProvider = DbFactoryProvider.GetProvider(DbLinks["RDIFrameworkDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["RDIFrameworkDBLink"].DbLink));
            BindCategory();
            this.ProductCode.Text = BusinessLogic.NewGuid();
            //修改数据
            if (!string.IsNullOrEmpty(this.EntityId))
            {                
                BindEditData();
                this.Text = "编辑产品 - " + currentProductInfoEntity.ProductName;
                this.btnSaveContine.Visible = false;
            }
        }

        private void BindCategory()
        {
            BasePageLogic.BindCategory(base.UserInfo, ProductCategory, "ProductCategory");
        }
            
        #region private void BindEditData() 绑定待修改的数据
        private void BindEditData()
        {
            currentProductInfoEntity = new ProductInfoManager(dbProvider).GetEntity(this.EntityId);
            if (currentProductInfoEntity == null || string.IsNullOrEmpty(currentProductInfoEntity.ProductName)) return;
            //新方法，一句话就搞定了
            FormBinding.BindObjectToControls(currentProductInfoEntity, this);
            /*
            //General Information　常规信息
            this.ProductCode.Text = currentProductInfoEntity.ProductCode;
            this.ProductName.Text = currentProductInfoEntity.ProductName;
            this.ProductCategory.SelectedValue = currentProductInfoEntity.ProductCategory;
            this.ProductModel.Text = currentProductInfoEntity.ProductModel;
            this.ProductStandard.Text = currentProductInfoEntity.ProductStandard;
            this.ProductUnit.Text = currentProductInfoEntity.ProductUnit;
            this.ProductDescription.Text = currentProductInfoEntity.ProductDescription;
                
            //价格信息
            this.MiddleRate.Text = currentProductInfoEntity.MiddleRate.ToString();
            this.ReferenceCoefficient.Text = currentProductInfoEntity.ReferenceCoefficient.ToString();
            this.ProductPrice.Text = currentProductInfoEntity.ProductPrice.ToString();
            this.WholesalePrice.Text = currentProductInfoEntity.WholesalePrice.ToString();
            this.PromotionPrice.Text = currentProductInfoEntity.PromotionPrice.ToString();
            this.InternalPrice.Text = currentProductInfoEntity.InternalPrice.ToString();
            this.SpecialPrice.Text = currentProductInfoEntity.SpecialPrice.ToString();

            //功能描述
            this.Description.Text = currentProductInfoEntity.Description;
            this.Enabled.Checked = BusinessLogic.ConvertIntToBoolean(currentProductInfoEntity.Enabled);
            */
        }
        #endregion

        ProductInfoEntity productInfoEntity = null;
        private ProductInfoEntity GetDataEntity()
        {   
            /*
            productInfoEntity = new ProductInfoEntity
            {
                ProductCode = this.ProductCode.Text.Trim(),
                ProductName = this.ProductName.Text.Trim(),
                ProductCategory = BusinessLogic.ConvertToString(this.ProductCategory.SelectedValue),
                ProductModel = this.ProductModel.Text.Trim(),
                ProductStandard = this.ProductStandard.Text.Trim(),
                ProductUnit = this.ProductUnit.Text.Trim(),
                ProductDescription = this.ProductDescription.Text.Trim(),
                MiddleRate = BusinessLogic.ConvertToNullableDecimal(this.MiddleRate.Text),
                ReferenceCoefficient = BusinessLogic.ConvertToNullableDecimal(this.ReferenceCoefficient.Text),
                ProductPrice = BusinessLogic.ConvertToNullableDecimal(this.ProductPrice.Text),
                WholesalePrice = BusinessLogic.ConvertToNullableDecimal(this.WholesalePrice.Text),
                PromotionPrice = BusinessLogic.ConvertToNullableDecimal(this.PromotionPrice.Text),
                InternalPrice = BusinessLogic.ConvertToNullableDecimal(this.InternalPrice.Text),
                SpecialPrice = BusinessLogic.ConvertToNullableDecimal(this.SpecialPrice.Text),
                Description = this.Description.Text.Trim(),
                Enabled = Enabled.Checked ? 1:0
            };
            */
            //新方法，一句话就搞定了
            productInfoEntity = new ProductInfoEntity();
            FormBinding.BindControlsToObject(productInfoEntity, this);
            return productInfoEntity;
        }

        #region private void SaveData(bool close) 保存新增的数据
        private void SaveData(bool close)
        {            
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            //读取产品实体数据
            this.GetDataEntity();

            if (new ProductInfoManager(dbProvider, this.UserInfo).Exists(new[] { ProductInfoTable.FieldProductCode, ProductInfoTable.FieldProductName, ProductInfoTable.FieldDeleteMark }
                                                        , new object[] { productInfoEntity.ProductCode, productInfoEntity.ProductName, "0" }))
            {
                MessageBoxHelper.ShowWarningMsg("库中已经存在相同数据，请重新检查输入！");
                ProductName.Focus();
            }
            else
            {
                string returnValue = new ProductInfoManager(dbProvider,this.UserInfo).AddEntity(productInfoEntity);
                if (returnValue.Trim().Length > 0)
                {
                    this.Changed = true;
                    MessageBoxHelper.ShowSuccessMsg("新增成功！");
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg("新增数据失败!");
                }
            }

            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (this.Changed && close)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                if (OnFormClosedRefreash != null)
                {
                    OnFormClosedRefreash();
                }
            }
        }
        #endregion

        #region private bool SaveEditData() 保存修改的数据
        /// <summary>
        /// 保存修改的数据
        /// </summary>
        /// <returns></returns>
        private bool SaveEditData()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;   
            bool returnValue = false;
            //新方法，一句话就搞定了
            FormBinding.BindControlsToObject(currentProductInfoEntity, this);
            /*
            currentProductInfoEntity.ProductCode = this.ProductCode.Text.Trim();
            currentProductInfoEntity.ProductName = this.ProductName.Text.Trim();
            currentProductInfoEntity.ProductCategory = BusinessLogic.ConvertToString(this.ProductCategory.SelectedValue);
            currentProductInfoEntity.ProductModel = this.ProductModel.Text.Trim();
            currentProductInfoEntity.ProductStandard = this.ProductStandard.Text.Trim();
            currentProductInfoEntity.ProductUnit = this.ProductUnit.Text.Trim();
            currentProductInfoEntity.ProductDescription = this.ProductDescription.Text.Trim();
            currentProductInfoEntity.MiddleRate = BusinessLogic.ConvertToNullableDecimal(this.MiddleRate.Text);
            currentProductInfoEntity.ReferenceCoefficient = BusinessLogic.ConvertToNullableDecimal(this.ReferenceCoefficient.Text);
            currentProductInfoEntity.ProductPrice = BusinessLogic.ConvertToNullableDecimal(this.ProductPrice.Text);
            currentProductInfoEntity.WholesalePrice = BusinessLogic.ConvertToNullableDecimal(this.WholesalePrice.Text);
            currentProductInfoEntity.PromotionPrice = BusinessLogic.ConvertToNullableDecimal(this.PromotionPrice.Text);
            currentProductInfoEntity.InternalPrice = BusinessLogic.ConvertToNullableDecimal(this.InternalPrice.Text);
            currentProductInfoEntity.SpecialPrice = BusinessLogic.ConvertToNullableDecimal(this.SpecialPrice.Text);
            currentProductInfoEntity.Description = this.Description.Text.Trim();
            currentProductInfoEntity.Enabled = Enabled.Checked ? 1: 0;
            */
            string statusMessage = string.Empty;
            returnValue = new ProductInfoManager(dbProvider, this.UserInfo).Update(currentProductInfoEntity, out statusMessage) > 0;
            if (returnValue)
            {
                this.Changed = true;
                MessageBoxHelper.ShowSuccessMsg(statusMessage);
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
            }
           

            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return returnValue;
        }
        #endregion

        #region private bool CheckValueIsEmpty() 界面输入的可用性判断
        private bool CheckValueIsEmpty()
        {
            bool returnValue = true;
            if (string.IsNullOrEmpty(this.ProductCode.Text) || string.IsNullOrEmpty(this.ProductName.Text))
            {
                returnValue = false;
                MessageBoxHelper.ShowWarningMsg("名称或编号不能为空！");
            }
            return returnValue;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.EntityId))
            {
                SaveData(true);
            }
            else
            {
                if (SaveEditData())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close(); 
                    if (OnFormClosedRefreash != null)
                    {
                        OnFormClosedRefreash();
                    }
                }
            }
        }

        public event FormClosedRefreashEventHandler OnFormClosedRefreash;

        private void btnSaveContine_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(pnlMain))
            {
                SaveData(false);
                BasePageLogic.EmptyControlValue(pnlMain);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                if (MessageBoxHelper.Show("确定放弃操作？") == DialogResult.No)
                {
                    return;
                }

                if (OnFormClosedRefreash != null)
                {
                    OnFormClosedRefreash();
                }
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (this.Changed)
            {
                this.DialogResult = DialogResult.OK;
                if (OnFormClosedRefreash != null)
                {
                    OnFormClosedRefreash();
                }
            }
            this.Close();
        }

        //输入格式控制(主要是对KeyPress事件进行控制，只能输入数据和退格键和小数点)
        private void MiddleRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') //小数点的话再加 e.KeyChar != '.'
            {
                e.Handled = true; 
            }     
        }

        private void ProductPrice_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.MiddleRate.Text.Trim()) || string.IsNullOrEmpty(this.ReferenceCoefficient.Text)) return;
            Decimal? productPrice = BusinessLogic.ConvertToNullableDecimal(this.MiddleRate.Text) * BusinessLogic.ConvertToNullableDecimal(this.ReferenceCoefficient);
            this.ProductPrice.Text = BusinessLogic.ConvertToString(productPrice);
        }
    }
}
