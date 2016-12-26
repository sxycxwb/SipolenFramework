using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;

namespace RDIFramework.WorkFlow
{
    public partial class FrmSelectArch : BaseForm_Single
    {
        private string fmState = "";//区分岗位和部门
        public FrmSelectArch(string state)
        {
            InitializeComponent();
            fmState = state;
        }
        /// <summary>
        /// 递归装载全部组织结构
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNodes"></param>
        public static void LoadArchitecture(string key, TreeNodeCollection startNodes)
        {
            try
            {
                if (key == null || key == "") key = "0";
               // DataTable table = ArchitectureData.GetChildArchitecture(key);
                DataTable table = RDIFrameworkService.Instance.OrganizeService.GetChildrensById(SystemInfo.UserInfo,key);
                startNodes.Clear();
                foreach (DataRow row in table.Rows)
                {
                    BaseTemplateTreeNode tmpNode = new BaseTemplateTreeNode();
                    tmpNode.NodeId = row["ArchitectureId"].ToString();
                   
                    tmpNode.NodeType = row["TypeName"].ToString();
                    tmpNode.Text = row["Caption"].ToString();
                    if (row["TypeName"].ToString() == WorkConst.ARCHITECTURE_ARCH)
                    {
                        tmpNode.ImageIndex = 0;
                        tmpNode.SelectedImageIndex = 0;
                        tmpNode.ForeColor = Color.Black;
                    }
                    else
                        if (row["TypeName"].ToString() == WorkConst.ARCHITECTURE_DUTY)
                        {
                            tmpNode.ImageIndex = 1;
                            tmpNode.SelectedImageIndex = 1;
                            tmpNode.ForeColor = Color.Red;
                        }

                    startNodes.Add(tmpNode);

                    LoadArchitecture(tmpNode.NodeId, tmpNode.Nodes);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SelectDutyFm_Load(object sender, EventArgs e)
        {
            LoadArchitecture(WorkConst.ARCHITECTURE_ARCH, tvArch.Nodes);
            tvArch.ExpandAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tvArch_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvArch.SelectedNode != null)
            {
                BaseTemplateTreeNode tmpNode=(BaseTemplateTreeNode)tvArch.SelectedNode;
                btnSave.Enabled = (fmState == tmpNode.NodeType);
            }
        }
    }
}

