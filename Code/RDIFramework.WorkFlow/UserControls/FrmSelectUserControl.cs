using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmSelectUserControl
    /// ѡ���ӱ�
    /// 
    /// </summary>
    public partial class FrmSelectUserControl : BaseForm_Single
    {
        public ListView FatherUserview;

        public FrmSelectUserControl()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            InitializeUIData();
        }

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        private void InitializeUIData()
        {
            lvUserControl.Columns.Add("�ӱ�", 100, HorizontalAlignment.Left);
            lvUserControl.Columns.Add("�ӱ�Id", 0, HorizontalAlignment.Left);
            lvUserControl.Columns.Add("λ��", 200, HorizontalAlignment.Left);
            lvUserControl.Columns.Add("���ڳ���", 260, HorizontalAlignment.Left);
            lvUserControl.Columns.Add("������", 300, HorizontalAlignment.Left);
            lvUserControl.Columns.Add("����", 100, HorizontalAlignment.Left);
            var dt = RDIFrameworkService.Instance.WorkFlowUserControlService.GetAllChildUserControls(this.UserInfo);
            foreach (DataRow dr in dt.Rows)
            {
                var lvi1 = new ListViewItem(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldFullName]) ?? "", 0);
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldId]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldPath]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldAssemblyName]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldFormName]) ?? "");
                lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr[UserControlsTable.FieldDescription]) ?? "");
                lvUserControl.Items.Add(lvi1);
            }

            //�г���ѡ���ӱ�
            lvSelectedUserControl.Columns.Add("�ӱ�", 100, HorizontalAlignment.Left);
            lvSelectedUserControl.Columns.Add("�ӱ�Id", 0, HorizontalAlignment.Left);
            lvSelectedUserControl.Columns.Add("״̬", 100, HorizontalAlignment.Left);
            lvSelectedUserControl.Columns.Add("λ��", 200, HorizontalAlignment.Left);
            lvSelectedUserControl.Columns.Add("���ڳ���", 260, HorizontalAlignment.Left);
            lvSelectedUserControl.Columns.Add("������", 300, HorizontalAlignment.Left);
            lvSelectedUserControl.Columns.Add("����", 100, HorizontalAlignment.Left);
            foreach (ListViewItem lv in FatherUserview.Items)
            {
                var lvi = new ListViewItem(lv.Text, 0);
                lvi.SubItems.Add(lv.SubItems[1].Text);
                lvi.SubItems.Add(lv.SubItems[4].Text);
                lvi.SubItems.Add(lv.SubItems[5].Text);
                lvi.SubItems.Add(lv.SubItems[2].Text);
                lvi.SubItems.Add(lv.SubItems[3].Text);
                lvi.SubItems.Add(lv.SubItems[6].Text);
                lvSelectedUserControl.Items.Add(lvi);
            }
        }

        private bool Exists(string iValue,ListView iListView)
        {
            return iListView.Items.Cast<ListViewItem>().Any(lv => lv.SubItems[1].Text == iValue);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (lvUserControl.SelectedItems.Count > 0)
            {
                var tmpUser = "";
                tmpUser = lvUserControl.SelectedItems[0].Text;
                if (Exists(lvUserControl.SelectedItems[0].SubItems[1].Text,lvSelectedUserControl))
                {
                    MessageBoxHelper.ShowWarningMsg(tmpUser + " �Ѿ����ڡ�");
                    return;
                }
                var lvi = new ListViewItem(lvUserControl.SelectedItems[0].Text,0);
                lvi.SubItems.Add(lvUserControl.SelectedItems[0].SubItems[1].Text);
                lvi.SubItems.Add(WorkConst.STATE_MOD);
                lvi.SubItems.Add(lvUserControl.SelectedItems[0].SubItems[2].Text);
                lvi.SubItems.Add(lvUserControl.SelectedItems[0].SubItems[3].Text);
                lvi.SubItems.Add(lvUserControl.SelectedItems[0].SubItems[4].Text);
                lvi.SubItems.Add(lvUserControl.SelectedItems[0].SubItems[5].Text);
                lvSelectedUserControl.Items.Add(lvi);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lvSelectedUserControl.SelectedItems.Count > 0)
            {
                lvSelectedUserControl.Items.Remove(lvSelectedUserControl.SelectedItems[0]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lvSelectedUserControl.FocusedItem == null)
            {
                return;
            }

            var lvt = lvSelectedUserControl.FocusedItem;
            var curRow = lvt.Index;//��ǰ�к�
            if (curRow != 0)
            {
                lvExchange(lvSelectedUserControl.Items[curRow], lvSelectedUserControl.Items[curRow - 1]);
                lvSelectedUserControl.FocusedItem = lvSelectedUserControl.Items[curRow - 1];
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lvSelectedUserControl.FocusedItem == null)
            {
                return;
            }

            var lvt = lvSelectedUserControl.FocusedItem;
            var curRow = lvt.Index;//��ǰ�к�
            if (curRow != lvSelectedUserControl.Items.Count - 1)
            {
                lvExchange(lvSelectedUserControl.Items[curRow + 1], lvSelectedUserControl.Items[curRow]);
                lvSelectedUserControl.FocusedItem = lvSelectedUserControl.Items[curRow + 1];
            }
        }
    }
}

