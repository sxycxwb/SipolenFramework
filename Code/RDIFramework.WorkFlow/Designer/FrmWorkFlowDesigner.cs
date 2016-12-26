using System;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmWorkFlowDesigner.cs
    /// 流程设计主界面
    /// 
    /// </summary>
    public partial class FrmWorkFlowDesigner : BaseForm
    {
        public WorkPlace WpClient;
        public string WorkFlowId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        BaseTreeNode _nowTreeNode;
        string _nowTreeNodeId;  //当前节点的Id

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmWorkFlowDesigner()
        {
            InitializeComponent();
            UserId = UserInfo.Id;
            UserName = UserInfo.UserName;
        }

        public FrmWorkFlowDesigner(string workFlowId, string userId, string userName)
		{
			InitializeComponent();
			WorkFlowId = workFlowId;
			UserId = userId;
			UserName = userName;
		}

        public override void FormOnLoad()
        {
            WorkFlowClassTreeNode.LoadWorkFlowClass("####", treeWorkflow.Nodes);
            treeWorkflow.ExpandAll();
        }

        private void MenuEnable(string state)
        {
            switch (state)
            {
                case WorkConst.WORKFLOW_CLASS:
                    newWftoolStripMenuItem1.Enabled = true;
                    updateWftoolStripMenuItem2.Enabled = false;
                    delWftoolStripMenuItem3.Enabled = false;
                    newclassToolStripMenuItem.Enabled = true;
                    updateclassToolStripMenuItem.Enabled = true;
                    delclassToolStripMenuItem.Enabled = true;
                    wfinputToolStripMenuItem.Enabled = true;
                    wfExportToolStripMenuItem.Enabled = false;
                    UsedToolStripMenuItem.Enabled = false;
                    unUsedToolStripMenuItem.Enabled = false;
                    moveWfclsToolStripMenuItem.Enabled = false;
                    break;
                case WorkConst.WORKFLOW_FLOW:
                    newWftoolStripMenuItem1.Enabled = true;
                    updateWftoolStripMenuItem2.Enabled = true;
                    delWftoolStripMenuItem3.Enabled = true;
                    newclassToolStripMenuItem.Enabled = false;
                    updateclassToolStripMenuItem.Enabled = false;
                    delclassToolStripMenuItem.Enabled = false;
                    wfinputToolStripMenuItem.Enabled = false;
                    wfExportToolStripMenuItem.Enabled = true;
                    moveWfclsToolStripMenuItem.Enabled = true;
                    UsedToolStripMenuItem.Enabled = (_nowTreeNode as WorkFlowTreeNode).Status == "0";
                    unUsedToolStripMenuItem.Enabled = (_nowTreeNode as WorkFlowTreeNode).Status == "1";
                    break;
            }
        }

        private void treeWorkflow_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _nowTreeNode = (BaseTreeNode)treeWorkflow.SelectedNode;
            _nowTreeNodeId = _nowTreeNode.NodeId;
            MenuEnable(_nowTreeNode.NodeType);

            if (_nowTreeNode.NodeType == WorkConst.WORKFLOW_CLASS)
            {
                _nowTreeNode.Nodes.Clear();
                WorkFlowClassTreeNode.LoadWorkFlowClassSelectNode(_nowTreeNodeId, _nowTreeNode.Nodes);
                WorkFlowTreeNode.LoadWorkFlowSelectNode(_nowTreeNodeId, _nowTreeNode.Nodes);
            }

            if (_nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)
            {
                if (WpClient != null)
                {
                    WpClient.closeFlow();
                }

                this.plClient.Controls.Clear();
                WpClient = new WorkPlace(_nowTreeNodeId, UserId, UserName)
                {
                    WorkFlowCaption = _nowTreeNode.Text,
                    CanEdit = true,
                    State = WorkConst.STATE_MOD
                };
                this.plClient.Controls.Add(WpClient);
                toolStrip1.Enabled = true;
            }
        }

        #region 快捷菜单各事件代码
        private void newClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmpWorkFlowClassFm = new FrmWorkFlowClass(UserId, UserName, WorkConst.STATE_ADD, _nowTreeNodeId, _nowTreeNode);
            tmpWorkFlowClassFm.ShowDialog();
        }

        private void newWftoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var tmpWorkFlowFm = new FrmAddWorkFlow(UserId, UserName, WorkConst.STATE_ADD, _nowTreeNodeId, _nowTreeNode);
            tmpWorkFlowFm.ShowDialog();
        }

        private void updateWftoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var tmpWorkFlowFm = new FrmAddWorkFlow(UserId, UserName, WorkConst.STATE_MOD, _nowTreeNodeId, _nowTreeNode);
            tmpWorkFlowFm.ShowDialog();
        }

        private void updateclassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmpWorkFlowClassFm = new FrmWorkFlowClass(UserId, UserName, WorkConst.STATE_MOD, _nowTreeNodeId, _nowTreeNode);
            tmpWorkFlowClassFm.ShowDialog();
        }

        private void delclassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DesignerHelper.IsPower(UserId, (sender as ToolStripMenuItem).Tag.ToString()) == false) return;
            if (_nowTreeNode.Nodes.Count > 0)
            {
                MessageBoxHelper.ShowWarningMsg("删除失败,流程分类下面有子分类或者流程不能删除!");
                return;
            }

            if (MessageBoxHelper.Show("是否删除分类[" + _nowTreeNode.Text + "]?删除后不能恢复。") == DialogResult.Yes)
            {
                WorkFlowClassTreeNode.DeleteSelectClassNode(_nowTreeNodeId);
                _nowTreeNode.Remove();
            }
        }

        private void delWftoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (DesignerHelper.IsPower(UserId, (sender as ToolStripMenuItem).Tag.ToString()) == false) return;
            if (MessageBoxHelper.Show("是否删除流程[" + _nowTreeNode.Text + "]? 删除后不能恢复。") == DialogResult.Yes)
            {
                WorkFlowTreeNode.DeleteSelectWorkflowNode(_nowTreeNodeId);
                _nowTreeNode.Remove();
            }
        }

        private void wfExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmWorkFlowExport(_nowTreeNodeId, _nowTreeNode.Text);
            f.ShowDialog();
        }

        private void wfinputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmWorkFlowImport(_nowTreeNodeId, _nowTreeNode.Text);
            f.ShowDialog();
        }

        private void UsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkFlowStatus(this.UserInfo, _nowTreeNodeId, "1");
            (_nowTreeNode as WorkFlowTreeNode).Status = "1";
        }

        private void unUsedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkFlowStatus(this.UserInfo, _nowTreeNodeId, "0");
            (_nowTreeNode as WorkFlowTreeNode).Status = "0";
        }

        private void moveWfclsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmSelectClass();
            var dlg = f.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                RDIFrameworkService.Instance.WorkFlowTemplateService.SetWorkFlowClass(this.UserInfo, _nowTreeNodeId, f.workflowClassId);
                _nowTreeNode.Remove();
            }
        }
        #endregion

        private void SetTsbButton(bool b)
        {
            foreach (ToolStripItem button in toolStrip1.Items)
            {
                if (button is ToolStripButton)
                {
                    (button as ToolStripButton).Checked = b;
                }
            }
        }

        private void SetTaskState(string buttonText)
        {
            switch (buttonText)
            {
                case "-1":
                    WpClient.Module = -1;
                    break;
                case "0":
                    WpClient.Module = 0;
                    break;
                case "1":
                    WpClient.Module = 1;
                    break;
                case "2":
                    WpClient.Module = 2;
                    break;
                case "3":
                    WpClient.Module = 3;
                    break;
                case "4":
                    WpClient.Module = 4;
                    break;
                case "5":
                    WpClient.Module = 5;
                    break;
                case "6":
                    WpClient.Module = 6;
                    break;
                case "left":
                    var dragger = new Dragger(WpClient, WpClient.SelectedItems);
                    dragger.Align(2);
                    dragger = null;
                    WpClient.Module = -2;
                    break;
                case "right":
                    var dragger2 = new Dragger(WpClient, WpClient.SelectedItems);
                    dragger2.Align(3);
                    WpClient.Module = -2;

                    break;
                case "top":
                    var dragger3 = new Dragger(WpClient, WpClient.SelectedItems);
                    dragger3.Align(1);
                    WpClient.Module = -2;

                    break;
                case "bottom":
                    var dragger4 = new Dragger(WpClient, WpClient.SelectedItems);
                    dragger4.Align(4);
                    WpClient.Module = -2;
                    break;
                case "exit":
                    this.Close();
                    break;
                case "save":
                    WpClient.SaveWorkFlow();
                    WpClient.Module = -2;
                    break;
            }
        }

        private void SetIntoModle()
        {
            WpClient.ToolModel = true;
        }

        private void SetOutModle()
        {
            WpClient.ToolModel = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null) return;

            var b = e.ClickedItem is ToolStripButton;
            if (b == false) return;
            var nowToolBtn = (ToolStripButton)e.ClickedItem;
            if (nowToolBtn.Text == @"-2")//指针
            {
                SetTsbButton(false);
                nowToolBtn.Checked = true;
                //退出设计模式
                SetOutModle();
                return;
            }

            if (nowToolBtn.Text != @"-3")//不是“加锁”
            {
                WpClient.LockModel = false;
                SetTsbButton(false);
                nowToolBtn.Checked = true;
                SetIntoModle(); //进入设计模式
                WpClient.NowButton = nowToolBtn;
                SetTaskState(nowToolBtn.Text); //设置待画节点类型
            }
            else//加锁状态
            {
                WpClient.LockModel = true;
                nowToolBtn.Checked = !nowToolBtn.Checked;
                if (nowToolBtn.Checked == false)
                {
                    SetTsbButton(false);
                    SetOutModle();  //退出设计模式
                }
            }
        }

        private void FrmWorkFlowDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_nowTreeNode == null) return;
            if (WpClient != null && _nowTreeNode.NodeType == WorkConst.WORKFLOW_FLOW)
                WpClient.closeFlow();
        }
    }
}
