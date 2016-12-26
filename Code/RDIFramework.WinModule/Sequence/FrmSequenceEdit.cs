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

    public partial class FrmSequenceEdit : BaseForm
    {
        /// <summary>
        /// 序列实体
        /// </summary>
        private CiSequenceEntity sequenceEntity = null;

        public FrmSequenceEdit()
        {
            InitializeComponent();
        }

        public FrmSequenceEdit(string id)
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
            this.sequenceEntity = RDIFrameworkService.Instance.SequenceService.GetEntity(UserInfo, this.EntityId);
            // 显示内容
            this.ShowEntity();
            // 焦点定位
            this.ActiveControl = this.txtFullName;
            this.txtFullName.SelectAll();
            this.txtFullName.Focus();
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            // 将类转显示到页面
            this.txtFullName.Text = sequenceEntity.FullName;
            this.txtPrefix.Text = sequenceEntity.Prefix;
            this.txtSeparate.Text = sequenceEntity.Separate;
            this.txtSequence.Text = BusinessLogic.ConvertToString(sequenceEntity.Sequence) ?? "";
            this.txtReduction.Text = BusinessLogic.ConvertToString(sequenceEntity.Reduction) ?? "";
            this.txtStep.Text = BusinessLogic.ConvertToString(sequenceEntity.Step) ?? "";
            this.txtDescription.Text = sequenceEntity.Description;
        }
        #endregion

        #region private CiSequenceEntity GetObject()
        /// <summary>
        /// 读取屏幕数据
        /// </summary>
        /// <returns>序列实体</returns>
        private CiSequenceEntity GetObject()
        {
            sequenceEntity.FullName = this.txtFullName.Text;
            sequenceEntity.Prefix = this.txtPrefix.Text;
            sequenceEntity.Separate = this.txtSeparate.Text;
            sequenceEntity.Sequence = BusinessLogic.ConvertToNullableInt(this.txtSequence.Text);
            sequenceEntity.Reduction = BusinessLogic.ConvertToNullableInt(this.txtReduction.Text);
            sequenceEntity.Step = BusinessLogic.ConvertToNullableInt(this.txtStep.Text);
            sequenceEntity.Description = this.txtDescription.Text;
            return sequenceEntity;
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
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            RDIFrameworkService.Instance.SequenceService.Update(UserInfo, this.sequenceEntity, out statusCode, out statusMessage);

            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                if (SystemInfo.ShowInformation)
                {
                    // 更新成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                this.DialogResult = DialogResult.OK;
                result = true;
            }
            else
            {
                MessageBoxHelper.ShowInformationMsg(statusMessage);
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
