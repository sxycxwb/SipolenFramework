using System;
using System.Windows.Forms;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    /// <summary>
    /// FrmSelectClass.cs
    /// ѡ�����
    /// 
    /// </summary>
    public partial class FrmSelectClass : BaseForm_Single
    {
        public string workflowClassId = "";
        public FrmSelectClass()
        {
            InitializeComponent();
        }

        private void SelectDutyFm_Load(object sender, EventArgs e)
        {
            WorkFlowClassTreeNode.LoadWorkFlowClass("####", tvWorkClass.Nodes);
            tvWorkClass.ExpandAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tvWorkClass.SelectedNode != null)
            {
                workflowClassId = (tvWorkClass.SelectedNode as WorkFlowClassTreeNode).NodeId;
                Close();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("��ѡ�����̷���!");
            }
        }

        private void tvArch_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

