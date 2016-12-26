using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmParameterAdd : BaseForm
    {
        private CiParameterEntity enitty = null;

        public FrmParameterAdd()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 焦点定位
            this.ActiveControl = this.txtCategoryKey;
            this.txtCategoryKey.Focus();
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool result = true;
            if (string.IsNullOrEmpty(txtCategoryKey.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9978));
                this.txtCategoryKey.Focus();
                return false;
            }
            return result;
        }
        #endregion

        #region public override void SaveEntity() 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>保存成功</returns>
        public override bool SaveEntity()
        {
            bool result = false;
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.GetObject();
            int returnInteger = RDIFrameworkService.Instance.ParameterService.SetParameter(UserInfo, this.enitty.CategoryKey, this.enitty.ParameterId, this.enitty.ParameterCode, this.enitty.ParameterContent, this.enitty.AllowEdit ?? 0,this.enitty.AllowDelete ?? 0);
            if (returnInteger > 0 )
            {
                // 有数据被改变过
                this.Changed = true;
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0009);
                }
                result = true;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG3020);
                this.txtCategoryKey.SelectAll();
                this.txtCategoryKey.Focus();
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return result;
        }
        #endregion

        #region private CiParameterEntity GetObject()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>参数实体</returns>
        private CiParameterEntity GetObject()
        {
            enitty = new CiParameterEntity
            {
                CategoryKey = this.txtCategoryKey.Text,
                ParameterId = this.txtParameterId.Text,
                ParameterCode = this.txtParameterCode.Text,
                ParameterContent = this.txtParameterContent.Text,
                Enabled = this.chkEnabled.Checked ? 1 : 0,
                AllowEdit = this.chkAllowEdit.Checked ? 1 : 0,
                AllowDelete = this.chkAllowDelete.Checked ? 1 : 0,
                Description = this.txtDescription.Text,
            };
            return enitty;
        }
        #endregion

        #region private void AddParameter(bool close = true)
        /// <summary>
        /// 保存参数
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void AddParameter(bool close = true)
        {
            // 检查输入的有效性
            if (!BasePageLogic.ControlValueIsEmpty(gbDetail))
            {
                return;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.SaveEntity())
                {
                    if (close)
                    {
                        this.DialogResult = DialogResult.OK;
                        // 关闭窗口
                        this.Close();
                    }
                    else
                    {
                        BasePageLogic.EmptyControlValue(gbDetail);
                    }
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
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AddParameter(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
