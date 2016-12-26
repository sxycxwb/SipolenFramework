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
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmWorkFlowExport.cs
    /// 流程导出
    /// 
    /// </summary>
    public partial class FrmWorkFlowExport : BaseForm
    {
        /// <summary>
        /// 导出流程的guid 主建
        /// </summary>
        public string ExportGuid { get; set; }

        /// <summary>
        /// 导出的流程名
        /// </summary>
        public string ExportName { get; set; }

        private string _exportFileName;

        public FrmWorkFlowExport(string iExportGuid, string iexportName)
        {
            InitializeComponent();
            ExportGuid = iExportGuid;
            ExportName = iexportName;
        }

        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="iMessage"></param>
        private void ProgressShow(string iMessage)
        {
            progressBar1.PerformStep();
            lbStep.Text = @"正在导出：" + iMessage;
        }

        /// <summary>
        /// 导出原形(不包含表单)
        /// </summary>
        /// <param name="iDs"></param>
        /// <param name="flowId"></param>
        /// <returns></returns>
        public void ExportWorkFlow(DataSet iDs, string flowId)
        {
            //1、WorkFlow
            ProgressShow("WorkFlow");
            var WorkFlow = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowTable(SystemInfo.UserInfo, flowId);
            WorkFlow.TableName = "WorkFlow";
            iDs.Tables.Add(WorkFlow.Copy());

            //2、WorkTask表
            ProgressShow("WorkTask");
            var WorkTask = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkTasks(SystemInfo.UserInfo, flowId);
            WorkTask.TableName = "WorkTask";
            iDs.Tables.Add(WorkTask.Copy());


            //3、WorkLink
            ProgressShow("WorkLink");
            var WorkLink = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkLinks(SystemInfo.UserInfo, flowId);
            WorkLink.TableName = "WorkLink";
            iDs.Tables.Add(WorkLink.Copy());

            //4、TaskVar
            ProgressShow("TaskVar");
            var var = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllVar(SystemInfo.UserInfo, flowId);
            var.TableName = "TaskVar";
            iDs.Tables.Add(var.Copy());

            //5、Operator
            ProgressShow("Operator");
            var wfOperator = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllOperator(SystemInfo.UserInfo, flowId);
            wfOperator.TableName = "Operator";
            iDs.Tables.Add(wfOperator.Copy());

            //6、subWorkFlow
            ProgressShow("subWorkFlow");
            var subWorkFlow = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllSub(SystemInfo.UserInfo, flowId);
            subWorkFlow.TableName = "subWorkFlow";
            iDs.Tables.Add(subWorkFlow.Copy());

            //7、WorkTaskCommands
            ProgressShow("WorkTaskCommands");
            var workTaskCommands = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllCommands(SystemInfo.UserInfo, flowId);
            workTaskCommands.TableName = "WorkTaskCommands";
            iDs.Tables.Add(workTaskCommands.Copy());
            //8、worktaskControls
            ProgressShow("worktaskControls");
            var dtworktaskControls = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllControlsTable(SystemInfo.UserInfo, flowId);
            dtworktaskControls.TableName = "worktaskControls";
            iDs.Tables.Add(dtworktaskControls.Copy());
            //9、WorkFlowEvent
            ProgressShow("WorkFlowEvent");
            var dtWorkFlowEvent = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllEventTable(SystemInfo.UserInfo, flowId);
            dtWorkFlowEvent.TableName = "WorkFlowEvent";
            iDs.Tables.Add(dtWorkFlowEvent.Copy());
            //10、WorkOutTime
            ProgressShow("WorkOutTime");
            var dtWorkOutTime = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowAllOutTimeTable(SystemInfo.UserInfo, flowId);
            dtWorkOutTime.TableName = "WorkOutTime";
            iDs.Tables.Add(dtWorkOutTime.Copy());
        }

        /// <summary>
        /// 导出表单
        /// </summary>
        /// <param name="iDs"></param>
        /// <param name="flowId"></param>
        /// <returns></returns>
        private void ExportPage(DataSet iDs, string flowId)
        {
            try
            {
                //1\UserControlsLink
                ProgressShow("UserControlsLink");
                var controllink = RDIFrameworkService.Instance.WorkFlowUserControlService.GetWorkFlowAllControlsLink(SystemInfo.UserInfo, flowId);
                controllink.TableName = "UserControlsLink";
                iDs.Tables.Add(controllink.Copy());
                ;
                //2、MainUserControl
                ProgressShow("MainUserControl");
                var control = RDIFrameworkService.Instance.WorkFlowUserControlService.GetWorkFlowAllMainControls(SystemInfo.UserInfo, flowId);
                control.TableName = "MainUserControl";
                iDs.Tables.Add(control.Copy());

                //3、UserControls
                ProgressShow("UserControls");
                var dtuserControls = RDIFrameworkService.Instance.WorkFlowUserControlService.GetWorkFlowAllControls(SystemInfo.UserInfo, flowId);
                dtuserControls.TableName = "UserControls";
                iDs.Tables.Add(dtuserControls.Copy());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnFilePath_Click(object sender, System.EventArgs e)
        {
            var save = new SaveFileDialog
            {
                Filter = "Xml 文件|*.xml",
                Title = "[" + ExportName + "]流程导出",
                FileName = ExportName,
                AddExtension = true
            };
            var rsult = save.ShowDialog();
            if (rsult == DialogResult.OK)
            {
                _exportFileName = save.FileName;
                tbxFilePath.Text = save.FileName;
            }
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            if (this.tbxFilePath.Text == "")
            {
                MessageBox.Show("请先选择导出的文件名！", "系统提示");
                return;
            }

            this.progressBar1.Maximum = 0;
            using (var fsWriteXml = new System.IO.FileStream(_exportFileName, System.IO.FileMode.Create))
            {
                try
                {
                    // Create an XmlTextWriter to write the file.
                    var xmlWriter = new System.Xml.XmlTextWriter(fsWriteXml, System.Text.Encoding.Unicode);
                    var ds = new DataSet();
                    if (rbtnAll.Checked)
                    {
                        this.progressBar1.Maximum = 13;
                        ExportWorkFlow(ds, ExportGuid); //导出原形
                        ExportPage(ds, ExportGuid); //导出表单
                    }
                    else if (rbtnWorkFlow.Checked)
                    {
                        this.progressBar1.Maximum = 10;
                        ExportWorkFlow(ds, ExportGuid);
                    }

                    ds.WriteXml(xmlWriter);
                    fsWriteXml.Close();
                    lbStep.Text = "导出成功！";
                }
                catch (Exception ex)
                {
                    fsWriteXml.Close();
                    MessageBox.Show("导出错误，错误代码：" + ex.Message.ToString(), "系统提示");
                }
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
