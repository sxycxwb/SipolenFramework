using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmProcessStep
    /// 流程处理记录(流程轨迹)
    /// 
    /// </summary>
    public partial class FrmProcessStep : BaseForm
    {
        private DataTable DTTempData = new DataTable("DTTempData");

        /// <summary>
        /// 工作流程实例主键
        /// </summary>
        public string WorkFlowInsId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="wfInsId">工作流程实例主键</param>
        public FrmProcessStep(string wfInsId)
        {
            InitializeComponent();
            this.WorkFlowInsId = wfInsId;
        }

        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvInfo);
            this.dgvInfo.AutoGenerateColumns = false;
            this.GetList();
        }

        public override void GetList()
        {
            if (string.IsNullOrEmpty(this.WorkFlowInsId))
            {
                MessageBoxHelper.ShowWarningMsg("请选择一条流程数据!");
                return;
            }

            this.DTTempData = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowHistory(this.UserInfo,this.WorkFlowInsId);
            this.dgvInfo.DataSource = this.DTTempData.DefaultView;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
