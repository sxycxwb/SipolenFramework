using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using RDIFramework.Utilities;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// FrmMainUserControl
    /// 主表单信息维护
    /// 
    /// </summary>
    public partial class FrmMainUserControl : BaseForm_Single
    {
        private string formState;//窗体状态，是修改还是新建
        public string UserId = "";
        public string UserName = "";
        public string NowNodeId = "";

        public FrmMainUserControl()
        {
            InitializeComponent();
        }

        public FrmMainUserControl(string userId, string userName, string state, string iKey)
        {
            InitializeComponent();
            formState = state;
            UserId = userId;
            NowNodeId = iKey;
            UserName = userName;
            lvUserControls.Columns.Add("子表单", 200, HorizontalAlignment.Left);
            lvUserControls.Columns.Add("子表单id", 0, HorizontalAlignment.Left);
            lvUserControls.Columns.Add("所在程序集",260, HorizontalAlignment.Left);
            lvUserControls.Columns.Add("窗体名称", 300, HorizontalAlignment.Left);
            lvUserControls.Columns.Add("状态", 100, HorizontalAlignment.Left);
            lvUserControls.Columns.Add("位置", 200, HorizontalAlignment.Left);
            lvUserControls.Columns.Add("描述", 200, HorizontalAlignment.Left);
            if (formState == WorkConst.STATE_ADD)
            {
                this.Text = "新建";
                NowNodeId = BusinessLogic.NewGuid();

            }
            else //肯定点的是流程节点
            {
                this.Text = "修改";
                GetInfoById();
            }
        }

        private void GetInfoById()
        {
            var dt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetMainUserControl(this.UserInfo,NowNodeId);
            txtFullName.Text = dt.Rows[0][MainUserControlTable.FieldFullName].ToString();
            txtDescription.Text = dt.Rows[0][MainUserControlTable.FieldDescription].ToString();
            //列出所有子表单
            var mdt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllChildUserControlsById(this.UserInfo, NowNodeId);
            
            foreach (DataRow dr in mdt.Rows)
            {
                var lvi1 = new ListViewItem(BusinessLogic.ConvertToString(dr["UCFULLNAME"]) ?? "", 0);
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldId]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldAssemblyName]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldFormName]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsLinkTable.FieldControlState]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldPath]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldDescription]) ?? "");
                lvUserControls.Items.Add(lvi1);
            }
        }

        private bool CheckData()
        {
            if (txtFullName.Text.Length == 0)
            {
                MessageBoxHelper.ShowWarningMsg("主表单名不能为空!");
                txtFullName.Focus();
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                return;
            }

            if (formState == WorkConst.STATE_ADD)
            {
                var m = new MainUserControlNode
                {
                    NodeId = NowNodeId,
                    Text = txtFullName.Text,
                    Description = txtDescription.Text,
                    NodeType = WorkConst.UserControl_Main
                };
                m.InsertMainUserControlNode();

            }
            else //修改
            {
                var m = new MainUserControlNode
                {
                    NodeId = NowNodeId,
                    Text = txtFullName.Text,
                    NodeType = WorkConst.UserControl_Main,
                    Description = txtDescription.Text
                };
                m.UpdateMainUserControlNode();
                RDIFrameworkService.Instance.WorkFlowUserControlService.MoveUserControlsOfMain(this.UserInfo, NowNodeId);//删除隶属主表单关系
            }

            var i = 0;
            foreach (ListViewItem lt in lvUserControls.Items)
            {
                RDIFrameworkService.Instance.WorkFlowUserControlService.AddUserControls(this.UserInfo, NowNodeId, lt.SubItems[1].Text, i, lt.SubItems[4].Text);
                i++;
            }
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var tmpSelectUser = new FrmSelectUserControl {FatherUserview = this.lvUserControls};
            tmpSelectUser.ShowDialog();
            var dlr = tmpSelectUser.DialogResult;
            if (dlr == DialogResult.OK)
            {
                lvUserControls.Items.Clear();
                foreach (ListViewItem lv in tmpSelectUser.lvSelectedUserControl.Items)
                {
                    var lvi = new ListViewItem(lv.Text, 0);
                    lvi.SubItems.Add(lv.SubItems[1].Text);
                    lvi.SubItems.Add(lv.SubItems[4].Text);
                    lvi.SubItems.Add(lv.SubItems[5].Text);
                    lvi.SubItems.Add(lv.SubItems[2].Text);
                    lvi.SubItems.Add(lv.SubItems[3].Text);
                    lvi.SubItems.Add(lv.SubItems[6].Text);
                    lvUserControls.Items.Add(lvi);
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lvUserControls.SelectedItems.Count > 0)
            {
                lvUserControls.Items.Remove(lvUserControls.SelectedItems[0]);
            }
        }

        private void lvExchange(ListViewItem slv, ListViewItem tlv)
        {
            var tmp = new ArrayList();
            for (var i = 0; i < slv.SubItems.Count; i++)
            {
                tmp.Add(slv.SubItems[i].Text);
            }
            for (var i = 0; i < slv.SubItems.Count; i++)
            {
                slv.SubItems[i].Text = tlv.SubItems[i].Text;
                tlv.SubItems[i].Text = tmp[i].ToString();
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lvUserControls.FocusedItem == null)
            {
                return;
            }

            var lvt = lvUserControls.FocusedItem;
            var curRow = lvt.Index;//当前行号
            if (curRow != 0)
            {
               
                lvExchange(lvUserControls.Items[curRow], lvUserControls.Items[curRow - 1]);
                lvUserControls.FocusedItem = lvUserControls.Items[curRow - 1];
            }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lvUserControls.FocusedItem == null)
            {
                return;
            }
            var lvt = lvUserControls.FocusedItem;
            var curRow = lvt.Index;//当前行号
            if (curRow != lvUserControls.Items.Count - 1)
            {
                lvExchange(lvUserControls.Items[curRow+1], lvUserControls.Items[curRow]);
                lvUserControls.FocusedItem = lvUserControls.Items[curRow+1];
            }
        }

        private void lvUserControls_DoubleClick(object sender, EventArgs e)
        {

            if (this.lvUserControls.SelectedItems.Count <= 0) return;
            var key = lvUserControls.SelectedItems[0].SubItems[1].Text;
            var f = new FrmUserControls(UserId, UserName, key);
            f.ShowDialog();
        }

        private void btnReadOnly_Click(object sender, EventArgs e)
        {
            SetCtrlState(WorkConst.STATE_VIEW);
        }

        private void SetCtrlState(string ctrlState)
        {
            if (lvUserControls.SelectedItems.Count > 0)
            {
                lvUserControls.SelectedItems[0].SubItems[4].Text = ctrlState;
            }
        }

        private void SetCtrlBtnState(string ctrlState)
        {
            btnReadOnly.Enabled = (ctrlState != WorkConst.STATE_VIEW);
            btnNew.Enabled = (ctrlState != WorkConst.STATE_ADD);
            btnModify.Enabled = (ctrlState != WorkConst.STATE_MOD);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            SetCtrlState(WorkConst.STATE_MOD);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetCtrlState(WorkConst.STATE_ADD);
        }
        
        private void lvUserControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvUserControls.SelectedItems.Count > 0)
            {
                var ctrlState = lvUserControls.SelectedItems[0].SubItems[2].Text;
                SetCtrlBtnState(ctrlState);
            }
        }
    }
}

