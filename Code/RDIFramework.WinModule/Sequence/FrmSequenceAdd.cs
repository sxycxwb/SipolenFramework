using System;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmSequenceAdd.cs
    /// 添加序列
    /// 
    /// </summary>
    public partial class FrmSequenceAdd : BaseForm
    {
        private CiSequenceEntity sequenceEntity = null;

        public FrmSequenceAdd()
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
            this.ActiveControl = this.txtFullName;
            this.txtFullName.Focus();
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
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0007, RDIFrameworkMessage.MSG9978));
                this.txtFullName.Focus();
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.GetObject();
             RDIFrameworkService.Instance.SequenceService.Add(UserInfo, this.sequenceEntity, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                // 有数据被改变过
                this.Changed = true;
                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                result = true;
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                // 是否名称重复了，提高友善性
                if (statusCode == StatusCode.ErrorNameExist.ToString())
                {
                    this.txtFullName.SelectAll();
                    this.txtFullName.Focus();
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
            return result;
        }
        #endregion

        #region private CiSequenceEntity GetObject()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>序列实体</returns>
        private CiSequenceEntity GetObject()
        {
            sequenceEntity = new CiSequenceEntity
            {
                FullName = this.txtFullName.Text,
                Prefix = this.txtPrefix.Text,
                Separate = this.txtSeparate.Text,
                Sequence = BusinessLogic.ConvertToNullableInt(this.txtSequence.Text),
                Reduction = BusinessLogic.ConvertToNullableInt(this.txtReduction.Text),
                Step = BusinessLogic.ConvertToNullableInt(this.txtStep.Text),
                Description = this.txtDescription.Text,
            };
            return sequenceEntity;
        }
        #endregion

        #region private void AddSequence(bool close = true)
        /// <summary>
        /// 保存序列
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void AddSequence(bool close = true)
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
            this.AddSequence(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
