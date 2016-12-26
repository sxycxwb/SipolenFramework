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
    using RDIFramework.WinForm.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class FrmDailyBiz : BaseForm
    {
        private DataTable DTMyStartWF = new DataTable(WorkFlowTemplateTable.TableName);

        public FrmDailyBiz()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.BindUIData(tvNavigateTree.Nodes);
        }

        private bool FatherExist(DataTable dt, string key)
        {
            var filter = "Wfclassid='" + key + "'";
            var dv = new DataView(dt) {RowFilter = filter};
            return dv.Count > 0;
        }

        /// <summary>
        /// 递归装载流程分类
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public void LoadWorkflowClass(DataTable dt, string key, TreeNodeCollection startNodes)
        {
            var filter = "";
            try
            {
                filter = "cllevel='" + key + "'";
                var dv = new DataView(dt) {RowFilter = filter};
                var tmpClassId = "###";
                foreach (DataRowView row in dv)
                {
                    var nowClassId = row["WFClassId"].ToString();
                    if (tmpClassId == nowClassId) continue;//避免重复添加
                    tmpClassId = nowClassId;
                    var tmpNode = new TreeNode {Text = row["Caption"].ToString()};
                    var url = row["clmgrurl"].ToString();
                    tmpNode.Tag = tmpClassId;
                    tmpNode.ImageIndex = 5;
                    startNodes.Add(tmpNode);
                    LoadChildClass(dt, tmpClassId, tmpNode.Nodes);//递归加载子分类
                }
            }
            catch (Exception ex)
            {
                throw new Exception("LoadWorkflowClass函数," + filter + ex.Message);
            }
        }

        public void LoadChildClass(DataTable dt, string key, TreeNodeCollection startNodes)
        {
            var filter = "";
            try
            {
                filter = "FatherId='" + key + "'";
                var tmpClassId = "###";
                var dv = new DataView(dt) {RowFilter = filter};
                foreach (DataRowView row in dv)
                {
                    var nowClassId = row["WFClassId"].ToString();
                    if (tmpClassId == nowClassId) continue;//避免重复添加
                    tmpClassId = nowClassId;
                    var tmpNode = new TreeNode
                    {
                        Text = row["Caption"].ToString(),
                        Tag = row["WFClassId"].ToString(),
                        ImageIndex = 5
                    };
                    startNodes.Add(tmpNode);
                    LoadChildClass(dt, tmpNode.Tag.ToString(), tmpNode.Nodes);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("loadChildClass函数," + filter + ex.Message);
            }
        }

        private void BindUIData(TreeNodeCollection startNodes)
        {
            var tmpNode = new TreeNode
            {
                Text = @"日常业务", 
                ImageIndex = 6, 
                SelectedImageIndex=6,
                Tag = "##"
            };
            startNodes.Add(tmpNode);
            var cllevel = "";
            DTMyStartWF = RDIFrameworkService.Instance.WorkFlowTemplateService.GetAllowStartWorkFlows(UserInfo,UserInfo.Id);
            foreach (DataRow dr in DTMyStartWF.Rows)
            {
                var nowcllevel = dr["cllevel"].ToString();
                if (nowcllevel == cllevel) continue;
                var clfathid = dr["FatherId"].ToString();
                if (FatherExist(DTMyStartWF, clfathid)) continue;
                LoadWorkflowClass(DTMyStartWF, nowcllevel, tmpNode.Nodes);
                cllevel = nowcllevel;
            }
            this.tvNavigateTree.ExpandAll();
        }

        /// <summary>
        /// 加载流程
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public void LoadWorkflow(DataTable dt, string key, TreeNodeCollection startNodes)
        {
            var filter = "WFCLASSID='" + key + "'";
            var tmpTaskId = "###";
            var dv = new DataView(dt) {RowFilter = filter};
            try
            {
                btnStartTask.Enabled = dv.Count > 0;
                foreach (DataRowView row in dv)
                {
                    var nowtaskid = row["WORKTASKID"].ToString();
                    if (tmpTaskId == nowtaskid) continue;//避免重复添加
                    tmpTaskId = nowtaskid;
                    lvData.Items.Add(nowtaskid, "", 1);
                    lvData.Items[nowtaskid].SubItems.Add(row["FLOWCAPTION"].ToString());
                    lvData.Items[nowtaskid].SubItems.Add(nowtaskid);
                    lvData.Items[nowtaskid].SubItems.Add(row["WORKFLOWID"].ToString());
                }
            }
            catch (Exception ex)
            {

                throw new Exception("LoadWorkflow函数," + ex.Message);
            }
        }

        private void tvNavigateTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnStartTask.Enabled = false;
            if (e.Node.Tag != null)
            {
                lvData.Items.Clear();
                LoadWorkflow(DTMyStartWF, e.Node.Tag.ToString(), e.Node.Nodes);
            }
        }

        private void btnStartTask_Click(object sender, EventArgs e)
        {
            if (lvData.SelectedItems.Count <= 0)
            {
                MessageBoxHelper.ShowWarningMsg("请选择要启动的流程！");
                return;
            }
            //var testWf = new FrmCommTestWF {WorkTaskId = lvData.SelectedItems[0].SubItems[2].Text};
            //testWf.ShowDialog();
            var frmStartForm = new FrmStartWorkFlow
            {
                WorkFlowId = lvData.SelectedItems[0].SubItems[3].Text,
                WorkTaskId = lvData.SelectedItems[0].SubItems[2].Text,
                WorkFlowInsId = BusinessLogic.NewGuid(),
                WorkTaskInsId = BusinessLogic.NewGuid()
            };
            frmStartForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
