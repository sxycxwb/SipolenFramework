using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmParameterAdmin
    /// 系统参数配置管理
    /// 
    /// 修改记录
    ///    2015-08-08 XuWangBin V3.0 增加FrmParameterAdmin.cs
    /// 
    /// </summary>
    public partial class FrmParameterAdmin : BaseForm
    {
        /// <summary>
        /// 数据表
        /// </summary>
        private DataTable DTSequence = new DataTable(CiSequenceTable.TableName);

        ///<summary>
        /// 表格中的岗位主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvData, CiSequenceTable.FieldId);
            }
        }
        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 本模块的导出权限
        /// </summary>
        private bool permissionExport = false;

        public FrmParameterAdmin()
        {
            InitializeComponent();
        }

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAdd = this.IsAuthorized("SequenceAdmin.Add");
            this.permissionEdit = this.IsAuthorized("SequenceAdmin.Edit");
            this.permissionDelete = this.IsAuthorized("SequenceAdmin.Delete");
            this.permissionExport = this.IsAuthorized("SequenceAdmin.Export");
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdd.Enabled = this.permissionAdd;
            this.btnEdit.Enabled = false;
            this.btnExport.Enabled = false;
            this.btnDelete.Enabled = false;
            if ((this.DTSequence.DefaultView.Count >= 1))
            {
                this.btnAdd.Enabled = this.permissionAdd;
                this.btnEdit.Enabled = this.permissionEdit;
                this.btnExport.Enabled = this.permissionExport;
                this.btnDelete.Enabled = this.permissionDelete;
            }
        }
        #endregion

        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvData);
            this.GetList();
        }

        public override void GetList()
        {
            int recordCount = 0;
            this.DTSequence = RDIFrameworkService.Instance.ParameterService.GetDTByPage(UserInfo, out recordCount, ucPager.PageIndex, ucPager.PageSize, "", CiSequenceTable.FieldCreateOn);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.DataSource = this.DTSequence;
            this.SetControlState();
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            this.GetList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmParameterAdd frmParameterAdd = new FrmParameterAdd();
            if (frmParameterAdd.ShowDialog(this) == DialogResult.OK)
            {
                this.GetList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvData, CiSequenceTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }

            if (!BusinessLogic.ConvertIntToBoolean(RDIFrameworkService.Instance.ParameterService.GetEntity(UserInfo, tmpId).AllowEdit))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0019);
                return;
            }

            FrmParameterEdit frmParameterEdit = new FrmParameterEdit(tmpId);
            if (frmParameterEdit.ShowDialog(this) == DialogResult.OK)
            {
                this.GetList();
            }
        }

        #region public int Delete() 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int Delete()
        {
            int result = 0;
            if (BasePageLogic.CheckInputSelectAnyOne(dgvData, "colSelected"))
            {
                if (!BusinessLogic.ConvertIntToBoolean(RDIFrameworkService.Instance.ParameterService.GetEntity(UserInfo, this.EntityId).AllowDelete))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG0017);
                    return 0;
                }

                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        result = RDIFrameworkService.Instance.ParameterService.SetDeleted(UserInfo, this.EntityId);
                        // 加载窗体
                        this.GetList();
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
            }
            return result;
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.DTSequence == null || this.DTSequence.Rows.Count <= 0)
            {
                MessageBoxHelper.ShowInformationMsg("温馨提示：没有要导出的数据！");
                return;
            }

            var dtHeaderText = new Dictionary<string, string>
            {
                {"CATEGORYKEY", "分类键值"},
                {"PARAMETERID", "参数主键"},
                {"PARAMETERCODE", "参数编号"},
                {"PARAMETERCONTENT", "参数内容"},
                {"ENABLED", "有效"},
                {"ALLOWEDIT", "允许编辑"},
                {"ALLOWDELETE", "允许删除"},
                {"DESCRIPTION", "描述"},
            };
            var filename = this.Text;
            var savePath = SystemInfo.StartupPath + @"\Modules\Export\" + this.Text + ".xls";
            if (MessageBoxHelper.Show("确定导出当前所显示的数据到：" + savePath) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    NPOIHelper.ExportByWinform(DTSequence, dtHeaderText, savePath);
                    MessageBoxHelper.ShowSuccessMsg("恭喜你，导出成功！");
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
