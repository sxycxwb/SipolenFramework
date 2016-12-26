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
    /// FrmWorkFlowImport.cs
    /// 流程导入
    /// 
    /// </summary>
    public partial class FrmWorkFlowImport : BaseForm
    {
        public string WfClassId;//导入到那个流程类型里面,分类编号
        public string WfClassName;//分类名称
        public string InputFlowId;// 导入的流程号
        private string _inputFilePath;

        public FrmWorkFlowImport(string iWFClassId, string iWFClassName)
        {
            InitializeComponent();
            WfClassId = iWFClassId;
            WfClassName = iWFClassName;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnFilePath_Click(object sender, System.EventArgs e)
        {
            var open = new OpenFileDialog { Filter = @"流程类型 文件|*.xml", Title = @"导入流程" };
            DialogResult rsult = open.ShowDialog();
            if (rsult == DialogResult.OK)
            {
                _inputFilePath = open.FileName;
                this.tbxFilePath.Text = _inputFilePath;
            }
        }

        /// <summary>
        /// 1判断流程模板是否存在
        /// </summary>
        /// <param name="iWorkFlowId"></param>
        /// <returns></returns>
        private bool existWorkflow(string iWorkFlowId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.WorkFlowExists(SystemInfo.UserInfo, iWorkFlowId);
        }

        /// <summary>
        /// 2判断任务模板是否存在
        /// </summary>
        /// <param name="iTaskId"></param>
        /// <returns></returns>
        private bool ExistWorktask(string iTaskId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistWorkTask(SystemInfo.UserInfo, iTaskId);
        }

        /// <summary>
        /// 3判断连线是否存在
        /// </summary>
        /// <param name="iWorkLinkId"></param>
        /// <returns></returns>
        private bool ExistWorkLink(string iWorkLinkId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistsWorkLink(SystemInfo.UserInfo, iWorkLinkId);
        }

        /// <summary>
        ///4 判断任务变量是否存在
        /// </summary>
        /// <param name="iTaskVarId"></param>
        /// <returns></returns>
        private bool ExistTaskVar(string iTaskVarId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistsTaskVar(SystemInfo.UserInfo, iTaskVarId);
        }

        /// <summary>
        /// 5判断处理者是否存在
        /// </summary>
        /// <param name="iOperatorId"></param>
        /// <returns></returns>
        private bool ExistOperator(string iOperatorId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistsOperator(SystemInfo.UserInfo, iOperatorId);
        }

        /// <summary>
        ///6 判断命令是否存在
        /// </summary>
        /// <param name="iCommandId"></param>
        /// <returns></returns>
        private bool ExistWorkTaskCommands(string iCommandId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistsWorkTaskCommands(SystemInfo.UserInfo, iCommandId);
        }

        /// <summary>
        /// 7判断任务表单是否存在
        /// </summary>
        /// <param name="iTaskControlId"></param>
        /// <returns></returns>
        private bool ExistWorktaskControls(string iTaskControlId)
        {
            return RDIFrameworkService.Instance.WorkFlowUserControlService.ExistsTaskControls(SystemInfo.UserInfo, iTaskControlId);
        }

        /// <summary>
        /// 8判断子流程是否存在
        /// </summary>
        /// <param name="subId"></param>
        /// <returns></returns>
        private bool ExistSubWorkflow(string subId)
        {
            return RDIFrameworkService.Instance.WorkFlowTemplateService.ExistsSubWorkFlowBySubId(SystemInfo.UserInfo, subId);
        }

        /// <summary>
        /// 1判断主表单是否存在
        /// </summary>
        /// <param name="iMainUserControlid"></param>
        /// <returns></returns>
        private bool ExistMainUserControl(string iMainUserControlid)
        {
            return RDIFrameworkService.Instance.WorkFlowUserControlService.ExistsMainControls(SystemInfo.UserInfo, iMainUserControlid);
        }

        /// <summary>
        /// 2判断子表单是否存在
        /// </summary>
        /// <param name="iUserControlId"></param>
        /// <returns></returns>
        private bool ExistUserControl(string iUserControlId)
        {
            return RDIFrameworkService.Instance.WorkFlowUserControlService.ExistsUserControls(SystemInfo.UserInfo, iUserControlId);
        }

        /// <summary>
        /// 3判断controllink是否存在
        /// </summary>
        /// <param name="iControllinkid"></param>
        /// <returns></returns>
        private bool ExistControlLink(string iControllinkid)
        {
            return RDIFrameworkService.Instance.WorkFlowUserControlService.ExistsControlsLink(SystemInfo.UserInfo, iControllinkid);
        }

        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="iMessage"></param>
        private void ProgressShow(string iMessage)
        {
            progressBar1.PerformStep();
            lbStep.Text = "正在导入：" + iMessage;
        }

        private bool InputWorkflow(DataSet ifromDs, DataSet itoDs)
        {
            DataTable fromTable = ifromDs.Tables["WorkFlow"];
            var dbProvider = DbFactoryProvider.GetProvider(SystemInfo.WorkFlowDbType, SystemInfo.WorkFlowDbConnectionString);
            DataTable toTable = null;
            string workFlowguid = "";//流程guid
            string workFlowname = "";//流程名

            if (fromTable != null && fromTable.Rows.Count > 0)
            {
                workFlowguid = fromTable.Rows[0]["workflowId"].ToString();
                workFlowname = fromTable.Rows[0]["flowCaption"].ToString();
                if (existWorkflow(workFlowguid))
                {
                    MessageBox.Show("流程[" + workFlowname + "]已经存在不能导入！", "系统提示");
                    return false;
                }
                InputFlowId = workFlowguid;//一定要放在开始导入后,导入失败后该值为空

                //1、导入workflow
                ProgressShow("WorkFlow");
                toTable = dbProvider.Fill("SELECT * FROM WorkFlow WHERE 1<>1");
                foreach (DataRow dr in fromTable.Rows)
                {
                    dr["wfclassid"] = WfClassId;
                    DataRow tmpdr = toTable.NewRow();
                    for (int i = 0; i < fromTable.Columns.Count; i++)
                    {
                        if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                            tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                    }
                    toTable.Rows.Add(tmpdr);
                }
                itoDs.Tables.Add(toTable.Copy());
                //2、导入worktask
                ProgressShow("WorkTask");
                fromTable = ifromDs.Tables["WorkTask"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from worktask where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                //3、导入worklink
                ProgressShow("worklink");
                fromTable = ifromDs.Tables["worklink"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from worklink where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }

                //4、导入var
                ProgressShow("taskvar");
                fromTable = ifromDs.Tables["taskvar"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from taskvar where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                //5、导入operator
                ProgressShow("operator");
                fromTable = ifromDs.Tables["operator"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from operator where 1<>1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                //6、导入subWorkFlow
                ProgressShow("subWorkFlow");
                fromTable = ifromDs.Tables["subWorkFlow"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from subworkflow where 1<>1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                //7、导入WorkTaskCommands
                ProgressShow("WorkTaskCommands");
                fromTable = ifromDs.Tables["WorkTaskCommands"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from worktaskcommands where 1<>1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                //8、导入worktaskControls
                ProgressShow("worktaskControls");
                fromTable = ifromDs.Tables["worktaskControls"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from worktaskcontrols where 1<>1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                //9、导入 WorkFlowEvent
                ProgressShow("WorkFlowEvent");
                fromTable = ifromDs.Tables["WorkFlowEvent"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from workflowevent where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string Evntguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }

                        toTable.Rows.Add(tmpdr);
                    }

                    itoDs.Tables.Add(toTable.Copy());
                }
                //10、导入 WorkOutTime
                ProgressShow("WorkOutTime");
                fromTable = ifromDs.Tables["WorkOutTime"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from workouttime where 1<>1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string otguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        toTable.Rows.Add(tmpdr);
                    }
                    itoDs.Tables.Add(toTable.Copy());
                }
                dbProvider.Close();
                dbProvider.Dispose();

                return true;
            }
            else
                return false;
        }

        private void InputPage(DataSet ifromDs, DataSet itoDs)
        {
            DataTable fromTable = ifromDs.Tables["MainUserControl"];
            DataTable toTable = null;
            var dbProvider = DbFactoryProvider.GetProvider(SystemInfo.WorkFlowDbType, SystemInfo.WorkFlowDbConnectionString);
            string tmpguid = "";

            //1、导入pagobj
            ProgressShow("MainUserControl");
            if (fromTable != null && fromTable.Rows.Count > 0)
            {
                toTable = dbProvider.Fill("select * from mainusercontrol where 1<> 1");
                foreach (DataRow dr in fromTable.Rows)
                {
                    tmpguid = dr["MainUserCtrlId"].ToString();
                    if (tmpguid == null || tmpguid.Trim().Length == 0) continue;
                    if (ExistMainUserControl(tmpguid)) continue;

                    DataRow tmpdr = toTable.NewRow();
                    for (int i = 0; i < fromTable.Columns.Count; i++)
                    {
                        if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                            tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                    }
                    toTable.Rows.Add(tmpdr);
                }
                itoDs.Tables.Add(toTable.Copy());
            }

            //2、导入Control
            ProgressShow("usercontrols");
            fromTable = ifromDs.Tables["usercontrols"];
            if (fromTable != null && fromTable.Rows.Count > 0)
            {
                toTable = dbProvider.Fill("select * from usercontrols where 1<> 1");
                foreach (DataRow dr in fromTable.Rows)
                {
                    tmpguid = dr["UserControlId"].ToString();
                    if (tmpguid == null || tmpguid.Trim().Length == 0) continue;
                    if (ExistUserControl(tmpguid)) continue;

                    DataRow tmpdr = toTable.NewRow();
                    for (int i = 0; i < fromTable.Columns.Count; i++)
                    {
                        if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                            tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                    }
                    toTable.Rows.Add(tmpdr);
                }
                itoDs.Tables.Add(toTable.Copy());
            }
            //3、导入UserControlsLink
            ProgressShow("UserControlsLink");
            fromTable = ifromDs.Tables["UserControlsLink"];
            if (fromTable != null && fromTable.Rows.Count > 0)
            {
                toTable = dbProvider.Fill("select * from usercontrolslink where 1<> 1");
                foreach (DataRow dr in fromTable.Rows)
                {
                    tmpguid = dr["mucLinkId"].ToString();
                    if (tmpguid == null || tmpguid.Trim().Length == 0) continue;
                    if (ExistControlLink(tmpguid)) continue;

                    DataRow tmpdr = toTable.NewRow();
                    for (int i = 0; i < fromTable.Columns.Count; i++)
                    {
                        if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                            tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                    }
                    toTable.Rows.Add(tmpdr);
                }
                itoDs.Tables.Add(toTable.Copy());
            }

            dbProvider.Close();
            dbProvider.Dispose();
        }

        private void InputNewWorkflow(DataSet ifromDs)
        {
            DataTable fromTable = ifromDs.Tables["WorkFlow"];
            DataTable toTable = null;
            string workFlowguid = "";//流程guid
            string workFlowname = "";//流程名
            var dbProvider = DbFactoryProvider.GetProvider(SystemInfo.WorkFlowDbType, SystemInfo.WorkFlowDbConnectionString);
            if (fromTable != null && fromTable.Rows.Count > 0)
            {
                workFlowguid = System.Guid.NewGuid().ToString();
                workFlowname = fromTable.Rows[0]["flowCaption"].ToString();
                InputFlowId = workFlowguid;//一定要放在开始导入后,导入失败后该值为空
                //1、导入workflow
                ProgressShow("WorkFlow");
                toTable = dbProvider.Fill("select * from workflow where 1<> 1");
                foreach (DataRow dr in fromTable.Rows)
                {
                    dr["WfClassId"] = WfClassId;
                    DataRow tmpdr = toTable.NewRow();
                    for (int i = 0; i < fromTable.Columns.Count; i++)
                    {
                        if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                            tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                    }
                    tmpdr["workflowId"] = workFlowguid;
                    toTable.Rows.Add(tmpdr);
                }

                //dbProvider.UpdateDTWithTranse(toTable);

                //2、导入WorkLink
                ProgressShow("worklink");
                fromTable = ifromDs.Tables["worklink"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from worklink  where 1<> 1");

                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string worklinkguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["WorklinkId"] = worklinkguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }

                    //dbProvider.UpdateDTWithTranse(toTable);
                }
                //3、导入 taskvar
                ProgressShow("taskvar");
                fromTable = ifromDs.Tables["taskvar"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from taskvar  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string varguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["taskvarId"] = varguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }

                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                //4、导入 worktaskcontrols
                ProgressShow("worktaskcontrols");
                fromTable = ifromDs.Tables["worktaskcontrols"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from worktaskcontrols  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string taskctrlguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["taskcontrolId"] = taskctrlguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }

                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                //5、导入 operator
                ProgressShow("operator");
                fromTable = ifromDs.Tables["operator"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from operator  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string operatorguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["operatorId"] = operatorguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }
                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                //6、导入 WorkTaskCommands
                ProgressShow("WorkTaskCommands");
                fromTable = ifromDs.Tables["WorkTaskCommands"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from WorkTaskCommands  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string cmdguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        tmpdr["CommandId"] = cmdguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }

                    //dbProvider.UpdateDTWithTranse(toTable);
                }
                //7、导入 subworkflow
                ProgressShow("subworkflow");
                fromTable = ifromDs.Tables["subworkflow"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from subworkflow  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string subguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["subId"] = subguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }
                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                //8、导入 WorkFlowEvent
                ProgressShow("WorkFlowEvent");
                fromTable = ifromDs.Tables["WorkFlowEvent"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from WorkFlowEvent  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string Evntguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["Guid"] = Evntguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }
                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                //9、导入 WorkOutTime
                ProgressShow("WorkOutTime");
                fromTable = ifromDs.Tables["WorkOutTime"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from WorkOutTime  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string otguid = System.Guid.NewGuid().ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];
                        }
                        tmpdr["Guid"] = otguid;
                        tmpdr["workflowId"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                    }
                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                //10、导入WorkTask
                ProgressShow("WorkTask");
                fromTable = ifromDs.Tables["WorkTask"];
                if (fromTable != null && fromTable.Rows.Count > 0)
                {
                    toTable = dbProvider.Fill("select * from WorkTask  where 1<> 1");
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        DataRow tmpdr = toTable.NewRow();
                        string taskguid = System.Guid.NewGuid().ToString();
                        string oldtaskguide = dr["worktaskId"].ToString();
                        for (int i = 0; i < fromTable.Columns.Count; i++)
                        {
                            if (toTable.Columns.Contains(fromTable.Columns[i].Caption))
                                tmpdr[fromTable.Columns[i].Caption] = dr[fromTable.Columns[i].Caption];

                        }
                        tmpdr["worktaskId"] = taskguid;
                        tmpdr["workflowid"] = workFlowguid;
                        toTable.Rows.Add(tmpdr);
                        string tmpUpdate = "update worklink set starttaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and starttaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update worklink set endtaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and endtaskId='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update taskvar set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update worktaskcontrols set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update operator set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update WorkTaskCommands set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update subworkflow set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update WorkFlowEvent set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                        tmpUpdate = "update WorkOutTime set worktaskid='" + taskguid + "' where workflowId='" + workFlowguid + "' and worktaskid='" + oldtaskguide + "'";
                        dbProvider.ExecuteNonQuery(tmpUpdate);
                    }

                    //dbProvider.UpdateDTWithTranse(toTable);
                }

                dbProvider.Close();
                dbProvider.Dispose();
            }
        }

        private void btnInput_Click(object sender, System.EventArgs e)
        {
            if (this.tbxFilePath.Text == "")
            {
                MessageBox.Show("请先选择导入的XML文件！", "系统提示");
                return;
            }
            DataSet dsFrom = new DataSet();
            DataSet dsTo = new DataSet();
            var dbProvider = DbFactoryProvider.GetProvider(SystemInfo.WorkFlowDbType, SystemInfo.WorkFlowDbConnectionString);
            System.IO.FileStream fsReadXml1 = new System.IO.FileStream(_inputFilePath, System.IO.FileMode.Open);
            System.Xml.XmlTextReader myXmlReader = new System.Xml.XmlTextReader(fsReadXml1);
            dsFrom.ReadXml(myXmlReader);
            myXmlReader.Close();
            try
            {

                if (this.rbtnAll.Checked)
                {
                    this.progressBar1.Maximum = 13;
                    if (InputWorkflow(dsFrom, dsTo))//导入原形
                        InputPage(dsFrom, dsTo);    //导入表单
                    //dbProvider.UpdateDSWithTranse(dsTo);
                }
                else
                    if (this.rbtnWorkFlow.Checked)
                    {
                        this.progressBar1.Maximum = 10;
                        if (InputWorkflow(dsFrom, dsTo)) //导入原形
                        {
                            //dbProvider.UpdateDSWithTranse(dsTo);
                        }
                    }
                    else
                        if (this.rdbtNewWorkFlow.Checked)
                        {
                            this.progressBar1.Maximum = 10;
                            InputNewWorkflow(dsFrom);

                        }
                //this.progressBar1.Maximum=0;
                lbStep.Text = "导入成功！";
            }
            catch (Exception ex)
            {
                InputFlowId = "";//一定要放在开始导入后,导入失败后该值为空
                MessageBox.Show("导入错误，错误代码：" + ex.Message.ToString(), "系统提示");
            }
        }
    }
}
