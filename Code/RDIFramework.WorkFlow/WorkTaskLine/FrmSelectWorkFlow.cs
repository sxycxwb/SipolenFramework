using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmSelectWorkFlow : BaseForm_Single
    {
        public FrmSelectWorkFlow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitializeUIData()
        {

            //列出所有用户

            lvWorkflow.Columns.Add("流程名", 100, HorizontalAlignment.Left);
            lvWorkflow.Columns.Add("WorkflowId", 100, HorizontalAlignment.Left);
            lvWorkflow.Columns.Add("描述", 200, HorizontalAlignment.Left);

        }

        private void FrmSelectWorkFlow_Load(object sender, EventArgs e)
        {
            InitializeUIData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbxWorkflowCaption.Text.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg("请输入流程名!");
                tbxWorkflowCaption.Focus();
                return;

            }
            lvWorkflow.Clear();
            InitializeUIData();
            DataTable dtSearch = null;

            dtSearch = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowsByCaption(SystemInfo.UserInfo, tbxWorkflowCaption.Text);
            foreach (DataRow dr in dtSearch.Rows)
            {
                var lvi1 = new ListViewItem(dr[WorkFlowTemplateTable.FieldFlowCaption].ToString(), 0);
                lvi1.SubItems.Add(dr[WorkFlowTemplateTable.FieldWorkFlowId].ToString());
                lvi1.SubItems.Add(dr[WorkFlowTemplateTable.FieldDescription].ToString());
                lvWorkflow.Items.Add(lvi1);

            }
        }
    }
}

