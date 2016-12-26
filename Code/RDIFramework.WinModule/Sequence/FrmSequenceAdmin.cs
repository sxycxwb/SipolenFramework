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

    /// <summary>
    /// FrmSequenceAdmin
    /// 系统序列管理
    /// 
    /// 修改记录
    ///    2015-08-08 EricHu V3.0 增加FrmSequenceAdmin.cs
    /// 
    /// </summary>
    public partial class FrmSequenceAdmin : BaseForm
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

        public FrmSequenceAdmin()
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
            this.DTSequence = RDIFrameworkService.Instance.SequenceService.GetDTByPage(UserInfo, out recordCount, ucPager.PageIndex, ucPager.PageSize,"", CiSequenceTable.FieldCreateOn);
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
            FrmSequenceAdd frmSequenceAdd = new FrmSequenceAdd();
            if (frmSequenceAdd.ShowDialog(this) == DialogResult.OK)
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

            FrmSequenceEdit frmSequenceEdit = new FrmSequenceEdit(tmpId);
            if (frmSequenceEdit.ShowDialog(this) == DialogResult.OK)
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
                if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.Yes)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        result = RDIFrameworkService.Instance.SequenceService.SetDeleted(UserInfo, this.EntityId);
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
                {"ID", "主键"},
                {"FULLNAME", "名称"},
                {"PREFIX", "前缀"},
                {"SEPARATE", "分隔符"},
                {"SEQUENCE", "增序列"},
                {"REDUCTION", "减序列"},
                {"STEP", "步骤"},
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
