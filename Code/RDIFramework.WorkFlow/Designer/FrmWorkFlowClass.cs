using System;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;

    public partial class FrmWorkFlowClass : BaseForm_Single
    {
        private string formState;//窗体状态，是修改还是新建
        private string InfoId; //操做主键
        private BaseTreeNode nowTreeNode;//当前节点
        public string UserId = "";
        public string UserName = "";

        public FrmWorkFlowClass()
        {
            InitializeComponent();
        }

        public FrmWorkFlowClass(string userId, string userName, string state, string infoId, BaseTreeNode node)
        {
            InitializeComponent();
            formState = state;
            UserId = userId;
            InfoId = infoId;
            UserName = userName;
            nowTreeNode = node;

            if (formState == WorkConst.STATE_ADD)
            {
                this.Text = "新建";
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//肯定点的是分类节点
                {
                    this.tbxFatherClassCaption.Text = nowTreeNode.Text;
                    this.tbxCllevel.Text = Convert.ToString(nowTreeNode.Level + 1);
                } 
            }
            else //肯定点的是流程节点
            {
                this.Text = "修改";
                getInfoById();
            }
        }

        private void getInfoById()
        {
            this.tbxClassCaption.Text = nowTreeNode.Text;
            if (nowTreeNode.Parent != null)
                this.tbxPath.Text = nowTreeNode.MgrUrl;
            this.tbxFatherClassCaption.Text = nowTreeNode.Parent.Text;
            this.tbxDescription.Text = (nowTreeNode as WorkFlowClassTreeNode).Description;
            this.tbxCllevel.Text = nowTreeNode.Level.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (formState == WorkConst.STATE_ADD)
            {
                var tmpNodeInfo = new WorkFlowClassTreeNode
                {
                    WorkflowFatherClassId = InfoId,
                    NodeId = Guid.NewGuid().ToString(),
                    NodeType = WorkConst.WORKFLOW_CLASS,
                    Text = tbxClassCaption.Text,
                    Description = tbxDescription.Text,
                    clLevel = Convert.ToInt16(tbxCllevel.Text)
                };
                tmpNodeInfo.InsertWorkflowClassNode();
                tmpNodeInfo.MgrUrl = tbxPath.Text;
                if (nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)//点击的是分类节点
                {
                    nowTreeNode.Nodes.Add(tmpNodeInfo);
                }
            }
            else ////肯定点的是流程节点
            {
                nowTreeNode.Text = tbxClassCaption.Text;
                nowTreeNode.NodeType = WorkConst.WORKFLOW_CLASS;
                nowTreeNode.MgrUrl = tbxPath.Text;
                (nowTreeNode as WorkFlowClassTreeNode).Description = tbxDescription.Text;
                (nowTreeNode as WorkFlowClassTreeNode).clLevel =Convert.ToInt16( tbxCllevel.Text);
                (nowTreeNode as WorkFlowClassTreeNode).UpdateWorkflowClassNode();
            }
            this.Close();
        }

        private void btnBussWebPage_Click(object sender, EventArgs e)
        {
            var fdb = new OpenFileDialog
            {
                Filter = "aspx页面|*.aspx|html页面|*.html|所以文件|*.*",
                FilterIndex = 1,
                RestoreDirectory = false,
                Multiselect = false
            };

            var fileName = "";
            var userControlPath = System.Configuration.ConfigurationSettings.AppSettings["ModulesPath"];//用户控件路径

            if (DialogResult.OK == fdb.ShowDialog())
            {
                fileName = fdb.FileName;
                var index = fileName.ToUpper().IndexOf(userControlPath.ToUpper());
                tbxPath.Text = fileName.Substring(index, fileName.Length - index);
            }
        }
    }
}

