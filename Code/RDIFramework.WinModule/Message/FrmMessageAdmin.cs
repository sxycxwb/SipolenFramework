using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmMessageAdmin.cs
    /// 消息管理
    /// 
    /// </summary>
    public partial class FrmMessageAdmin : BaseForm
    {
        private DataTable dtMessage = new DataTable(CiMessageTable.TableName);

        public FrmMessageAdmin()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            this.tvList.Nodes[0].Expand();
            btnBroadcastMessage.Visible = this.UserInfo.IsAdministrator; //超级管理员才能广播消息
        }

        private void tvList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvList.SelectedNode.Tag != null)
            {
                theLastNode = tvList.SelectedNode;
                GetMessageListByFunctionCode();
            }
        }

        private void GetMessageListByFunctionCode()
        {
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            string searchValue = string.Empty;
            string functionCode = BusinessLogic.ConvertToString(tvList.SelectedNode.Tag);
            if (!string.IsNullOrEmpty(functionCode) && !functionCode.Equals("All"))
            {
                searchValue += CiMessageTable.FieldFunctionCode + " = '" + functionCode + "'";
            }
            searchValue = !string.IsNullOrEmpty(searchValue) ? searchValue + " AND " : "";
            /*
             SELECT * FROM dbo.CIMESSAGE 
                WHERE FUNCTIONCODE = 'UserMessage' 
                AND ((RECEIVERID = '26F43BC9-AE6D-42D2-BAC9-F4237A949484' AND CATEGORYCODE = 'Receiver') 
                OR  (CREATEUSERID = '26F43BC9-AE6D-42D2-BAC9-F4237A949484' AND CATEGORYCODE = 'Send'))
                ORDER BY CREATEON DESC
             */
            searchValue += "((" + CiMessageTable.FieldReceiverId + " = '" + UserInfo.Id + "' AND " + CiMessageTable.FieldCategoryCode + " ='Receiver') "
                        + " OR  (" + CiMessageTable.FieldCreateUserId + " = '" + UserInfo.Id + "' AND " + CiMessageTable.FieldCategoryCode + " ='Send'))"; //只显示自己发送的与自己授收的数据

            int recordCount = 0;
            dtMessage = RDIFrameworkService.Instance.MessageService.GetMessagesByConditional(this.UserInfo, searchValue, out recordCount, ucPager.PageIndex, ucPager.PageSize);
            ucPager.RecordCount = recordCount;
            ucPager.InitPageInfo();
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.DataSource = this.dtMessage.DefaultView;
            this.SetControlState();
            this.Cursor = holdCursor;
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetMessageListByFunctionCode();
            this.Cursor = holdCursor;
        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            if (this.tvList.SelectedNode.Tag != null)
            {
                theLastNode = tvList.SelectedNode;
                GetMessageListByFunctionCode();
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var sendMessage = new FrmSendMessage();
            if (sendMessage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.GetMessageListByFunctionCode();
            }
        }

        private void btnBroadcastMessage_Click(object sender, EventArgs e)
        {
            var broadcastMessage = new FrmBroadcastMessage();
            if (broadcastMessage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.GetMessageListByFunctionCode();
            }
        }

        private void btnReadMessage_Click(object sender, EventArgs e)
        {
            try
            {
                RDIFrameworkService.Instance.MessageService.Read(this.UserInfo, BasePageLogic.GetDataGridViewEntityId(dgvList,CiMessageTable.FieldId));
                this.GetMessageListByFunctionCode();
                MessageBoxHelper.ShowSuccessMsg(RDIFramework.Utilities.RDIFrameworkMessage.MSG3010);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowErrorMsg(RDIFramework.Utilities.RDIFrameworkMessage.MSG3020 + "\n"  + ex.Message);
            }
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e)
        {
            dgvList.EndEdit();
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvList, "colSelected")) return;
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0075) != DialogResult.Yes) return;

            try
            {
                var returnValue = RDIFrameworkService.Instance.MessageService.SetDeleted(base.UserInfo, BasePageLogic.GetSelecteIds(this.dgvList, CiMessageTable.FieldId, "colSelected", true));
                if (returnValue <= 0 || !SystemInfo.ShowSuccessMsg) return;
                MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077, returnValue.ToString(CultureInfo.InvariantCulture)));
                this.GetMessageListByFunctionCode();
            }
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        TreeNode theLastNode = null;
        private void tvList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ForeColor = Color.Blue;
            e.Node.NodeFont = new Font("宋体", 10, FontStyle.Underline | FontStyle.Bold);
            if (theLastNode != null)
            {
                theLastNode.ForeColor = SystemColors.WindowText;
                theLastNode.NodeFont = new Font("宋体", 11, FontStyle.Regular);
            }
        }

        private void dgvList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null || e.RowIndex <= -1) return;
            var dataGridViewColumn = this.dgvList.Columns["colISNEW"];
            if (dataGridViewColumn == null || e.ColumnIndex != dataGridViewColumn.Index) return;
            string strValue = e.Value.ToString();
            switch (strValue)
            {
                case "0":
                    this.dgvList.Rows[e.RowIndex].Cells["colISNEW"].Style.BackColor = Color.Gray;
                    break;
                case "1":
                    this.dgvList.Rows[e.RowIndex].Cells["colISNEW"].Style.BackColor = Color.Green;
                    break;
            }
        }
    }
}
