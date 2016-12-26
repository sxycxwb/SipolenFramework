using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDIFramework.BizLogic;
using RDIFramework.Utilities;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
    public partial class FrmAttachment : FrmBaseBizeForm
    {
        public FrmAttachment()
        {
            InitializeComponent();
        }

        private void FrmAttachment_Load(object sender, EventArgs e)
        {
            base.Form_Load();
            InitListViewColumn();
            this.ShowEntity();
            this.SetControlState();
        }

        public override void SetControlState()
        {
            if (!string.IsNullOrEmpty(this.PageState))
            {
                this.pnlTool.Enabled = this.PageState != WorkConst.STATE_VIEW;
                return;
            }

            if (!string.IsNullOrEmpty(this.CtrlState))
            {
                btnDelete.Enabled = btnUpload.Enabled = this.CtrlState != "查看";
            }
            else
            {
                pnlTool.Enabled = false;
            }
        }

        private void InitListViewColumn()
        {
            lvAttachment.Columns.Clear();
            lvAttachment.Columns.Add("附件名称", 200, HorizontalAlignment.Left);
            lvAttachment.Columns.Add("附件ID", 0, HorizontalAlignment.Left);
            lvAttachment.Columns.Add("附件类型", 100, HorizontalAlignment.Left);
            lvAttachment.Columns.Add("附件大小", 100, HorizontalAlignment.Left);
            lvAttachment.Columns.Add("附件路径", 300, HorizontalAlignment.Left);
        }

        public override void ShowEntity()
        {
            lvAttachment.Items.Clear();
            //string sql = "SELECT * FROM ATTACHMENT where WORKFLOWINSID=@WORKFLOWINSID";
            //var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
            //sqlBuilder.BeginSelect("ATTACHMENT");
            //sqlBuilder.SetWhere("WORKFLOWINSID", WorkFlowInsId);
            //DataTable dt = sqlBuilder.EndSelect();
            string[] names = {AttachmentTable.FieldWorkFlowInsId,AttachmentTable.FieldDeleteMark};
            string[] values = {WorkFlowInsId,"0"};
            DataTable dt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAttachmentByValues(this.UserInfo, names,values);
            if (dt != null && dt.Rows.Count > 0)//判断是否有数据，有数据读取数据库中的值
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var lvi1 = new ListViewItem(BusinessLogic.ConvertToString(dr["ATTACHMENTNAME"]) ?? "", 0);
                    lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr["ID"]) ?? "");
                    lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr["ATTACHMENTTYPE"]) ?? "");
                    lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr["ATTACHMENTSIZE"]) ?? "");
                    lvi1.SubItems.Add(BusinessLogic.ConvertToString(dr["ATTACHMENTPATH"]) ?? "");
                    lvAttachment.Items.Add(lvi1);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = @"请选择待上传的附件";
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                Cursor holdCursor = BeginWait();
                //var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
                //sqlBuilder.BeginInsert("ATTACHMENT");
                //sqlBuilder.SetValue("ID", BusinessLogic.NewGuid());
                //sqlBuilder.SetValue("WORKFLOWID", WorkFlowId);
                //sqlBuilder.SetValue("WORKTASKID", WorkTaskId);
                //sqlBuilder.SetValue("WORKFLOWINSID", WorkFlowInsId);
                //sqlBuilder.SetValue("WORKTASKINSID", WorkTaskInsId);
                //sqlBuilder.SetValue("ATTACHMENTNAME", FileHelper.GetName(ofd.FileName));
                //sqlBuilder.SetValue("ATTACHMENTCONTENT", FileHelper.GetFile(ofd.FileName));
                //sqlBuilder.SetValue("ATTACHMENTTYPE", FileHelper.GetPostfixStr(ofd.FileName));
                //sqlBuilder.SetValue("ATTACHMENTSIZE", FileHelper.GetFileSize(ofd.FileName));
                //sqlBuilder.SetValue("ENABLED", 1);
                //sqlBuilder.SetValue("DELETEMARK", 0);
                //if (UserInfo != null)
                //{
                //    sqlBuilder.SetValue("CREATEUSERID", UserInfo.Id);
                //    sqlBuilder.SetValue("CREATEBY", UserInfo.RealName);
                //    sqlBuilder.SetValue("MODIFIEDUSERID", UserInfo.Id);
                //    sqlBuilder.SetValue("MODIFIEDBY", UserInfo.RealName);
                //}
                //sqlBuilder.SetDBNow("CREATEON");
                //sqlBuilder.SetDBNow("MODIFIEDON");
                //sqlBuilder.EndInsert();
                var entity = new AttachmentEntity
                {
                    Id = BusinessLogic.NewGuid(),
                    WorkFlowId = WorkFlowId,
                    WorkFlowInsId = WorkFlowInsId,
                    WorkTaskId = WorkTaskId,
                    WorkTaskInsId = WorkTaskInsId,
                    AttachmentContent = FileHelper.GetFile(ofd.FileName),
                    AttachmentType = FileHelper.GetPostfixStr(ofd.FileName),
                    AttachmentSize = FileHelper.GetFileSize(ofd.FileName),
                    Enabled = 1,
                    DeleteMark = 0
                };
                entity.AttachmentName = FileHelper.GetName(ofd.FileName) + entity.AttachmentType;
                RDIFrameworkService.Instance.WorkFlowHelperService.InsertAttachment(this.UserInfo, entity);
                this.ShowEntity();
                EndWait(holdCursor);
            }
        }

        private void btnRefreash_Click(object sender, EventArgs e)
        {
            this.InitListViewColumn();
            this.ShowEntity();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvAttachment.SelectedItems.Count <= 0)
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
                return;
            }

            if (MessageBoxHelper.Show(RDIFrameworkMessage.Format(RDIFrameworkMessage.MSG0016, lvAttachment.SelectedItems[0].SubItems[0].Text)) == DialogResult.Yes)
            {
                Cursor holdCursor = BeginWait();
                var sqlBuilder = new SQLBuilder(this.WorkFlowDbProvider);
                sqlBuilder.BeginDelete("ATTACHMENT");
                sqlBuilder.SetWhere("ID", lvAttachment.SelectedItems[0].SubItems[1].Text);
                sqlBuilder.EndDelete();
                this.ShowEntity();
                EndWait(holdCursor);
            }
        }
    }
}
