using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmParameterEdit : BaseForm
    {
        /// <summary>
        /// 参数实体
        /// </summary>
        private CiParameterEntity parameterEntity = null;

        public FrmParameterEdit()
        {
            InitializeComponent();
        }

        public FrmParameterEdit(string id)
            : this()
        {
            this.EntityId = id;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.parameterEntity = RDIFrameworkService.Instance.ParameterService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 焦点定位
            this.ActiveControl = this.txtCategoryKey;
            this.txtCategoryKey.SelectAll();
            this.txtCategoryKey.Focus();
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtCategoryKey.Text = parameterEntity.CategoryKey;
            this.txtParameterId.Text = parameterEntity.ParameterId;
            this.txtParameterCode.Text = parameterEntity.ParameterCode;
            this.txtParameterContent.Text = parameterEntity.ParameterContent;
            this.chkEnabled.Checked = BusinessLogic.ConvertIntToBoolean(parameterEntity.Enabled);
            this.chkAllowEdit.Checked = BusinessLogic.ConvertIntToBoolean(parameterEntity.AllowEdit);
            this.chkAllowDelete.Checked = BusinessLogic.ConvertIntToBoolean(parameterEntity.AllowDelete);
            this.txtDescription.Text = parameterEntity.Description;
        }
        #endregion

        #region private CiParameterEntity GetObject()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>参数实体</returns>
        private CiParameterEntity GetObject()
        {
            parameterEntity.CategoryKey = this.txtCategoryKey.Text;
            parameterEntity.ParameterId = this.txtParameterId.Text;
            parameterEntity.ParameterCode = this.txtParameterCode.Text;
            parameterEntity.ParameterContent = this.txtParameterContent.Text;
            parameterEntity.Enabled = this.chkEnabled.Checked ? 1 : 0;
            parameterEntity.AllowEdit = this.chkAllowEdit.Checked ? 1 : 0;
            parameterEntity.AllowDelete = this.chkAllowDelete.Checked ? 1 : 0;
            parameterEntity.Description = this.txtDescription.Text;

            return parameterEntity;
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
            int returnInt = RDIFrameworkService.Instance.ParameterService.SetParameter(UserInfo, parameterEntity.CategoryKey, parameterEntity.ParameterId, parameterEntity.ParameterCode, parameterEntity.ParameterContent, parameterEntity.AllowEdit ?? 0, parameterEntity.AllowDelete ?? 0);

            if (returnInt > 0)
            {
                if (SystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0010);
                }
                this.DialogResult = DialogResult.OK;
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

        private void btnSave_Click(object sender, EventArgs e)
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
                    // 关闭窗口
                    this.Close();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
