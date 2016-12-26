using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmUserControlAdmin.cs
    /// 用户表单(控件)维护
    /// 
    /// </summary>
    public partial class FrmUserControlAdmin : BaseForm
    {
       public BaseUserControlTreeNode NowNode;

        public FrmUserControlAdmin()
        {
            InitializeComponent();
            InitUserControlTree();
        }

        private void InitUserControlTree()
        {
            var tmpNode1 = new BaseUserControlTreeNode
            {
                NodeType = "#0",
                Text = @"表单管理",
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            tvUserControl.Nodes.Add(tmpNode1);
            var tmpNode01 = new UserControlNode
            {
                NodeType = WorkConst.UserControl_Child + "#",
                Text = @"子表单管理",
                ImageIndex = 1,
                SelectedImageIndex = 1
            };
            tmpNode1.Nodes.Add(tmpNode01);

            var tmpNode02 = new MainUserControlNode
            {
                NodeType = WorkConst.UserControl_Main + "#",
                Text = @"主表单管理",
                ImageIndex = 2,
                SelectedImageIndex = 2
            };
            tmpNode1.Nodes.Add(tmpNode02);
            tvUserControl.ExpandAll();
        }

        /// <summary>
        /// 显示主表单和子表单
        /// </summary>
        private void LvShowType()
        {
            var lvi1 = new ListViewItem("子表单管理", 0);
            lvi1.SubItems.Add("管理业务系统中的子表单");
            lvClient.Items.Add(lvi1);

            lvi1 = new ListViewItem("主表单", 1);
            lvi1.SubItems.Add("管理业务系统中的主表单");
            lvClient.Items.Add(lvi1);
        }

        /// <summary>
        /// 显示子表单
        /// </summary>
        private void LvShowUserControl()
        {
            var tmpTable = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllChildUserControls(this.UserInfo);
            foreach (DataRow dr in tmpTable.Rows)
            {
                var lvi1 = new ListViewItem(dr[UserControlsTable.FieldFullName].ToString(), 0);
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldId]) ?? string.Empty);
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldPath]) ?? string.Empty);
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldFormName]) ?? string.Empty, SystemColors.WindowText, SystemColors.Info, new Font("宋体", 11, FontStyle.Bold));
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldAssemblyName]) ?? string.Empty, SystemColors.WindowText, SystemColors.Info, new Font("宋体", 11, FontStyle.Bold));
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldDescription]) ?? string.Empty);
                lvi1.ImageIndex = 1;
                lvClient.Items.Add(lvi1);
            }
        }

        /// <summary>
        /// 显示主表单
        /// </summary>
        private void LvShowMainUserControl()
        {
            var tmpTable = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllMainUserControls(this.UserInfo);
            foreach (DataRow dr in tmpTable.Rows)
            {
                var lvi1 = new ListViewItem(dr[MainUserControlTable.FieldFullName].ToString(), 0);
                lvi1.SubItems.Add(dr[MainUserControlTable.FieldId].ToString());
                lvi1.SubItems.Add(dr[MainUserControlTable.FieldDescription].ToString());
                lvi1.ImageIndex = 2;
                lvClient.Items.Add(lvi1);
            }
        }

        /// <summary>
        /// 初始化树和listview表头信息
        /// </summary>
        /// <param name="typeClient"></param>
        /// <param name="iKey"></param>
        private void InitListView(string typeClient, string iKey)
        {
            lvClient.Clear();
            lvClient.ContextMenuStrip = null;
            lvClient.View = View.Details;
            switch (typeClient)
            {
                case "#0"://显示子表单和主表单
                    {
                        lvClient.Columns.Add("名称", 100, HorizontalAlignment.Left);
                        lvClient.Columns.Add("描述", 200, HorizontalAlignment.Left);
                        LvShowType();
                        tvUserControl.ContextMenuStrip = null;
                        break;
                    }
                case WorkConst.UserControl_Child + "#"://子表单
                    {
                        UserControlNode.LoadAllUserControlsNode(tvUserControl.SelectedNode.Nodes);
                        lvClient.Columns.Add("子表单", 150, HorizontalAlignment.Left);
                        lvClient.Columns.Add("子表单Id", 0, HorizontalAlignment.Left);
                        lvClient.Columns.Add("位置", 300, HorizontalAlignment.Left);
                        lvClient.Columns.Add("表单名称",300, HorizontalAlignment.Left);
                        lvClient.Columns.Add("所在程序集", 270, HorizontalAlignment.Left);
                        lvClient.Columns.Add("描述", 200, HorizontalAlignment.Left);
                        LvShowUserControl();
                        tvUserControl.ContextMenuStrip = cmUserControl;
                        break;
                    }
                case WorkConst.UserControl_Child:
                    {
                        tvUserControl.ContextMenuStrip = cmUserControl;
                        break;
                    }
                case WorkConst.UserControl_Main + "#"://主表单管理
                    {
                        MainUserControlNode.LoadAllMainUserControls(tvUserControl.SelectedNode.Nodes);
                        lvClient.Columns.Add("主表单", 200, HorizontalAlignment.Left);
                        lvClient.Columns.Add("主表单Id", 0, HorizontalAlignment.Left);
                        lvClient.Columns.Add("描述", 200, HorizontalAlignment.Left);
                        LvShowMainUserControl();
                        tvUserControl.ContextMenuStrip = cmMainUserControl;
                        break;
                    }
                case WorkConst.UserControl_Main:
                    {
                        tvUserControl.ContextMenuStrip = cmMainUserControl;
                        break;
                    }
            }
        }

        private void MenuEnable(string state)
        {
            if (state == WorkConst.UserControl_Main + "#")
            {
                newmucToolStripMenuItem.Enabled = true;
                modifymucToolStripMenuItem.Enabled = false;
                delmucToolStripMenuItem.Enabled = false;
            }
            else
            {
                newmucToolStripMenuItem.Enabled = true;
                modifymucToolStripMenuItem.Enabled = true;
                delmucToolStripMenuItem.Enabled = true;
            }
            if (state == WorkConst.UserControl_Child + "#")
            {
                NewUctoolStripMenuItem2.Enabled = true;
                ModifyUcToolStripMenuItem.Enabled = false;
                delucToolStripMenuItem.Enabled = false;
            }
            else
            {
                NewUctoolStripMenuItem2.Enabled = true;
                ModifyUcToolStripMenuItem.Enabled = true;
                delucToolStripMenuItem.Enabled = true;
            }
        }

        private void tvUserControl_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvUserControl.SelectedNode == null) return;
            NowNode = (BaseUserControlTreeNode)tvUserControl.SelectedNode;
            MenuEnable(NowNode.NodeType);
            InitListView(NowNode.NodeType, NowNode.NodeId);
        }

        private void tbtnLargeIcon_Click(object sender, EventArgs e)
        {
            lvClient.View = View.LargeIcon;
        }

        private void tbtnSmallIcon_Click(object sender, EventArgs e)
        {
            lvClient.View = View.SmallIcon;
        }

        private void tbtnListIcon_Click(object sender, EventArgs e)
        {
            lvClient.View = View.List;
        }

        private void tbtnDetails_Click(object sender, EventArgs e)
        {
            lvClient.View = View.Details;
        }

        private void tbtnAttribute_Click(object sender, EventArgs e)
        {
            if (this.tvUserControl.SelectedNode == null) return;
            if (this.lvClient.SelectedItems.Count <= 0) return;
            var tmpTreeNode = (BaseUserControlTreeNode)tvUserControl.SelectedNode;
            var key = lvClient.SelectedItems[0].SubItems[1].Text;
            if (tmpTreeNode.NodeType == WorkConst.UserControl_Child + "#")
            {
                lvClient.ContextMenuStrip = lvcmUserControl;
                var f = new FrmUserControls(UserInfo.Id, UserInfo.UserName, key);
                f.ShowDialog();
            }
            else
            {
                if (tmpTreeNode.NodeType == WorkConst.UserControl_Main + "#")
                {
                    //lvClient.ContextMenuStrip = lvcmMainUserCtrl;
                    lvClient.ContextMenuStrip = lvcmMainUserControl;
                    var f = new FrmMainUserControl(UserInfo.Id, UserInfo.UserName, WorkConst.STATE_MOD, key);
                    f.ShowDialog();
                }
                else
                {
                    lvClient.ContextMenuStrip = null;
                }
            }
        }

        private void tbtnOper_Click(object sender, EventArgs e)
        {
            var p = Cursor.Position;
            cmenuOperation.Show(p); 
        }

        private void tbtnLook_Click(object sender, EventArgs e)
        {
            var p = Cursor.Position;
            cmenuView.Show(p);
        }

        private void tbtnVisable_Click(object sender, EventArgs e)
        {
            
        }

        private void tbtnRefrush_Click(object sender, EventArgs e)
        {
            tvUserControl_AfterSelect(null, null);
        }

        private void tbtnDelete_Click(object sender, EventArgs e)
        {
            if (lvClient.Focused)
            {
                deleteListView_Click(null, null);
            }
        }

        private void deleteListView_Click(object sender, EventArgs e)
        {

        }

        private void NewUctoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var f = new FrmAddUserControl(UserInfo.Id, UserInfo.UserName);
            f.ShowDialog();
        }

        private void ModifyUcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmUserControls(UserInfo.Id, UserInfo.UserName, NowNode.NodeId);
            f.ShowDialog();
        }

        private void delucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("是否删除子表单[" + NowNode.Text + "]?删除后不能回复。") == DialogResult.Yes)
            {
                UserControlNode.DeleteUserControl(NowNode.NodeId);
                NowNode.Remove();
            }
        }

        private void newmucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmMainUserControl(UserInfo.Id, UserInfo.UserName, WorkConst.STATE_ADD, NowNode.NodeId);
            f.ShowDialog();
        }

        private void modifymucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmMainUserControl(UserInfo.Id, UserInfo.UserName, WorkConst.STATE_MOD, NowNode.NodeId);
            f.ShowDialog();
        }

        private void delmucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show("是否删除主表单[" + NowNode.Text + "]?删除后不能回复。") == DialogResult.Yes)
            {
                MainUserControlNode.DeleteMainUserControlNode(NowNode.NodeId);
                NowNode.Remove();
            }
        }

        private void lvnewUctoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new FrmAddUserControl(UserInfo.Id, UserInfo.UserName);
            f.ShowDialog();
        }

        private void lvModifyUctoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.lvClient.SelectedItems.Count <= 0) return;
            var key = lvClient.SelectedItems[0].SubItems[1].Text;
            var f = new FrmUserControls(UserInfo.Id, UserInfo.UserName, key);
            f.ShowDialog();
        }

        private void lvDelUctoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.lvClient.SelectedItems.Count <= 0) return;
            var key = lvClient.SelectedItems[0].SubItems[1].Text;
            if (MessageBoxHelper.Show("是否删除子表单[" + lvClient.SelectedItems[0].Text + "]?删除后不能回复。") == DialogResult.Yes)
            {
                UserControlNode.DeleteUserControl(key);
                lvClient.Items.Remove(lvClient.SelectedItems[0]);
            }
        }

        private void lvNewMuctoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new FrmMainUserControl(UserInfo.Id, UserInfo.UserName, WorkConst.STATE_ADD, "");
            f.ShowDialog();
        }

        private void lvModifyMuctoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.lvClient.SelectedItems.Count <= 0) return;
            var key = lvClient.SelectedItems[0].SubItems[1].Text;
            var f = new FrmMainUserControl(UserInfo.Id, UserInfo.UserName, WorkConst.STATE_MOD, key);
            f.ShowDialog();
        }

        private void lvDelMuctoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.lvClient.SelectedItems.Count <= 0) return;
            var key = lvClient.SelectedItems[0].SubItems[1].Text;
            if (MessageBoxHelper.Show("是否删除主表单[" + lvClient.SelectedItems[0].Text + "]?删除后不能回复。") == DialogResult.Yes)
            {
                MainUserControlNode.DeleteMainUserControlNode(key);
                lvClient.Items.Remove(lvClient.SelectedItems[0]);
            }
        }

        private void lvClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (NowNode.NodeType)
            {
                case WorkConst.UserControl_Child + "#":
                    lvClient.ContextMenuStrip = lvcmUserControl;
                    break;
                case WorkConst.UserControl_Main + "#":
                    lvClient.ContextMenuStrip = lvcmMainUserControl;
                    break;
                default:
                    lvClient.ContextMenuStrip = null;
                    break;
            }
        }

        private void tbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvClient_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void lvClient_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }
    }
}
