using System;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;

    public partial class FrmAddWorkFlow : BaseForm_Single
    {
        private string formState;//����״̬�����޸Ļ����½�
        private string InfoId; //��������
        private BaseTreeNode nowTreeNode;//��ǰ�ڵ�
        public string UserId="";
        public string UserName="";

        public FrmAddWorkFlow()
        {
            InitializeComponent();
        }

        public FrmAddWorkFlow(string userId,string userName,string state,string infoId,BaseTreeNode node)
        {
            InitializeComponent();
            formState = state;
            UserId = userId;
            UserName = userName;
            nowTreeNode = node;
            if (formState == WorkConst.STATE_ADD)
            {
                this.Text = "�½�";
                switch (nowTreeNode.NodeType)
                {
                    case WorkConst.WORKFLOW_CLASS:
                        this.tbxClassCaption.Text = nowTreeNode.Text;
                        InfoId = infoId;
                        break;
                    case WorkConst.WORKFLOW_FLOW:
                        this.tbxClassCaption.Text = nowTreeNode.Parent.Text;
                        InfoId = (nowTreeNode.Parent as BaseTreeNode).NodeId;
                        break;
                }
            }
            else //�϶���������̽ڵ�
            {
                this.Text = "�޸�";
                GetInfoById();
            }
        }

        private void GetInfoById()
        {          
            this.tbxWorkflowCaption.Text = nowTreeNode.Text;
            this.tbxClassCaption.Text = nowTreeNode.Parent.Text;
            tbxPath.Text = (nowTreeNode as WorkFlowTreeNode).MgrUrl;
            chkStatus.Checked = (nowTreeNode as WorkFlowTreeNode).Status == "1"; 
            this.tbxDescription.Text = (nowTreeNode as WorkFlowTreeNode).Description;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formState == WorkConst.STATE_ADD)
            {
                WorkFlowTreeNode tmpNodeInfo = new WorkFlowTreeNode
                {
                    WorkFlowClassId = InfoId,
                    NodeId = Guid.NewGuid().ToString(),
                    NodeType = WorkConst.WORKFLOW_FLOW,
                    Text = tbxWorkflowCaption.Text,
                    MgrUrl = tbxPath.Text,
                    Status = chkStatus.Checked ? "1" : "0",
                    Description = tbxDescription.Text
                };
                tmpNodeInfo.InsertWorkflowNode();
                switch (nowTreeNode.NodeType)
                {
                    case WorkConst.WORKFLOW_CLASS:
                        nowTreeNode.Nodes.Add(tmpNodeInfo);
                        break;
                    case WorkConst.WORKFLOW_FLOW:
                        nowTreeNode.Parent.Nodes.Add(tmpNodeInfo);
                        break;
                }
            }
            else //�϶���������̽ڵ�
            {
                nowTreeNode.Text = tbxWorkflowCaption.Text;
                (nowTreeNode as WorkFlowTreeNode).MgrUrl = tbxPath.Text;
                nowTreeNode.NodeType = WorkConst.WORKFLOW_FLOW;
                (nowTreeNode as WorkFlowTreeNode).Description = tbxDescription.Text;
                (nowTreeNode as WorkFlowTreeNode).Status = chkStatus.Checked ? "1" : "0";
                (nowTreeNode as WorkFlowTreeNode).UpdateWorkflowNode();
            }
            this.Close();
        }

        private void cmbxNodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnBussWebPage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdb = new OpenFileDialog
            {
                Filter = "aspxҳ��|*.aspx|htmlҳ��|*.html|�����ļ�|*.*",
                FilterIndex = 1,
                RestoreDirectory = false,
                Multiselect = false
            };

            string fileName = "";
            string userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//�û��ؼ�·��
            if (DialogResult.OK == fdb.ShowDialog())
            {
                fileName = fdb.FileName;
                int index = fileName.ToUpper().IndexOf(userControlPath.ToUpper());
                tbxPath.Text = fileName.Substring(index, fileName.Length - index);
            }
        }
    }
}

