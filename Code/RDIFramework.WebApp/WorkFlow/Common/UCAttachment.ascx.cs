using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace RDIFramework.WebApp.WorkFlow.Common
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class UCAttachment : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load();
            if (!IsPostBack)
                InitData();
        }

        private void InitData()
        {
            string[] names = { AttachmentTable.FieldWorkFlowInsId, AttachmentTable.FieldDeleteMark };
            string[] values = { WorkFlowInsId, "0" };
            DataTable dt = RDIFrameworkService.Instance.WorkFlowHelperService.GetAttachmentByValues(Utils.UserInfo, names, values);
            gvAffixfiles.DataSource = dt;
            gvAffixfiles.DataBind();
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (inputFile.PostedFile.ContentLength > 0)
            {
                string path = this.inputFile.PostedFile.FileName;
                string fileName = path.Substring(path.LastIndexOf("\\", System.StringComparison.Ordinal) + 1);
                int size = this.inputFile.PostedFile.ContentLength;
                string type = FileHelper.GetPostfixStr(fileName);//this.inputFile.PostedFile.ContentType;
                string newId = BusinessLogic.NewGuid();
                Stream imageStream = inputFile.PostedFile.InputStream;
                var content = new byte[size];
                imageStream.Read(content, 0, size);
                var entity = new AttachmentEntity
                {
                    Id = newId,
                    WorkFlowId = WorkFlowId,
                    WorkFlowInsId = WorkFlowInsId,
                    WorkTaskId = WorkTaskId,
                    WorkTaskInsId = WorkTaskInsId,
                    AttachmentName = fileName,
                    AttachmentContent = content,
                    AttachmentType = type,
                    AttachmentSize = size,
                    Enabled = 1,
                    DeleteMark = 0
                };
                RDIFrameworkService.Instance.WorkFlowHelperService.InsertAttachment(Utils.UserInfo, entity);
                labelUpResult.Text = "上传成功！";
                InitData();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string[] parms = (sender as LinkButton).CommandArgument.Split(',');
           
            byte[] fileData = null;
            DataTable dtAttatch = RDIFrameworkService.Instance.WorkFlowHelperService.GetAttachmentTable(Utils.UserInfo,parms[0]);
            if (dtAttatch != null && dtAttatch.Rows.Count > 0)
            {
                var entity = BaseEntity.Create<AttachmentEntity>(dtAttatch);
                fileData = entity.AttachmentContent;
            }
         
            if (fileData == null)
            {
                Response.StatusCode = 404;
            }
            else
            {
                //使用Content-Disposition会有些缺点，在不同的浏览器中文件名显示有些不正常，如果用FireFox就无须编码
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlEncode(parms[1], System.Text.Encoding.UTF8) + "\"");
                Response.BinaryWrite(fileData);
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (CtrlState == WorkConst.STATE_VIEW)
            {
                return;
            }
            string[] parms = (sender as LinkButton).CommandArgument.Split(',');
            RDIFrameworkService.Instance.WorkFlowHelperService.DeleteAttachment(Utils.UserInfo,parms[0]);//删除数据库记录文件
            labelUpResult.Text = "删除成功！";
            InitData();
        }

        protected void gvAffixfiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}