using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    /// <summary>
    /// UCStartPage.cs
    /// 起始页
    /// 
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("OnMoreClicked")]
    [Description("起始页控件")]
    public partial class UCStartPage : UserControl
    {
        public StartPageArea PageArea = StartPageArea.UnClaimedTask;

        /// <summary>
        /// 增加按钮的单击事件
        /// </summary>
        [Category("用户控件属性"), Description("更多>>按钮的单击事件")]
        public event EventHandler OnMoreClicked;

        public UCStartPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载起始页数据
        /// </summary>
        public void LoadStartPageData()
        {
            CreatUnClaimedTaskListView();
            CreatTodoTaskListView();
            CreatBeDoneListView();
            CreatWorkFlowMonitorListView();
        }

        private void CreatUnClaimedTaskListView()
        {
            this.lvUnClaimedTask.Columns.Clear();
            this.lvUnClaimedTask.Items.Clear();
            lvUnClaimedTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmUnClaimedTask_colFlowInsCaption"), "业务名称"), 200, HorizontalAlignment.Left);
            lvUnClaimedTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmUnClaimedTask_colTaskInsCaption"), "任务名称"), 200, HorizontalAlignment.Left);
            lvUnClaimedTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmUnClaimedTask_colpOperatedDes"), "任务提交人"), 100, HorizontalAlignment.Left);
            lvUnClaimedTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmUnClaimedTask_coltaskStartTime"), "任务到达时间"), 150, HorizontalAlignment.Left);
            lvUnClaimedTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmUnClaimedTask_colflowStartTime"), "流程开始时间"), 150, HorizontalAlignment.Left);
            int recordCount;
            DataTable datatableWF = RDIFrameworkService.Instance.WorkFlowInstanceService.GetUnClaimedTaskByPage(SystemInfo.UserInfo, SystemInfo.UserInfo.Id, "", out recordCount, 1, 20);
            if (datatableWF != null && datatableWF.Rows.Count > 0)
            {
                foreach (DataRow dr in datatableWF.Rows)
                {
                    ListViewItem item1 = new ListViewItem(BusinessLogic.ConvertToString(dr["FlowInsCaption"].ToString()), 0) { ForeColor = ColorTranslator.FromHtml("#458FCE") };
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["TaskInsCaption"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["pOperatedDes"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["taskStartTime"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["flowStartTime"].ToString()));
                    lvUnClaimedTask.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
        }

        private void CreatTodoTaskListView()
        {
            this.lvTodoTask.Columns.Clear();
            this.lvTodoTask.Items.Clear();
            lvTodoTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmToDoTask_colFlowInsCaption"), "流程实例名"), 400, HorizontalAlignment.Left);
            lvTodoTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmToDoTask_coltaskStartTime"), "任务到达时间"), 150, HorizontalAlignment.Left);
            lvTodoTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmToDoTask_colFlowInsCaption"),"任务名称"), 200, HorizontalAlignment.Left);
            lvTodoTask.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmToDoTask_colpOperatedDes"), "任务提交人"), 100, HorizontalAlignment.Left);

            int recordCount;
            DataTable datatableWF = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowClaimedTaskByPage(SystemInfo.UserInfo, SystemInfo.UserInfo.Id, "", out recordCount, 1, 20);
            if (datatableWF != null && datatableWF.Rows.Count > 0)
            {
                foreach (DataRow dr in datatableWF.Rows)
                {
                    ListViewItem item1 = new ListViewItem(BusinessLogic.ConvertToString(dr["FlowInsCaption"].ToString()), 0) { ForeColor = ColorTranslator.FromHtml("#458FCE") };
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["taskStartTime"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["TaskInsCaption"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["pOperatedDes"].ToString()));
                    lvTodoTask.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
        }

        private void CreatBeDoneListView()
        {
            this.lvBeDownList.Columns.Clear();
            this.lvBeDownList.Items.Clear();
            lvBeDownList.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmBeDoneTask_colFlowInsCaption"), "流程实例名"), 400, HorizontalAlignment.Left);
            lvBeDownList.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmBeDoneTask_colTaskInsCaption"), "任务名称"), 150, HorizontalAlignment.Left);
            lvBeDownList.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmBeDoneTask_colpOperatedDes"), "提交人"), 100, HorizontalAlignment.Left);
            lvBeDownList.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmBeDoneTask_coltaskStartTime"), "开始时间"), 150, HorizontalAlignment.Left);
            lvBeDownList.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmBeDoneTask_colTaskEndTime"), "结束时间"), 150, HorizontalAlignment.Left);

            int recordCount;
            DataTable datatableWF = RDIFrameworkService.Instance.WorkFlowInstanceService.WorkFlowCompletedTaskByPage(SystemInfo.UserInfo, SystemInfo.UserInfo.Id, "", out recordCount, 1, 20);
            if (datatableWF != null && datatableWF.Rows.Count > 0)
            {
                foreach (DataRow dr in datatableWF.Rows)
                {
                    ListViewItem item1 = new ListViewItem(BusinessLogic.ConvertToString(dr["FlowInsCaption"].ToString()), 0) { ForeColor = ColorTranslator.FromHtml("#458FCE") };
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["TaskInsCaption"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["pOperatedDes"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["taskStartTime"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["taskEndTime"].ToString()));
                    lvBeDownList.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
        }

        private void CreatWorkFlowMonitorListView()
        {
            this.lvWorkFlowMonitor.Columns.Clear();
            this.lvWorkFlowMonitor.Items.Clear();
            lvWorkFlowMonitor.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmWorkFlowMonitor_colFlowInsCaption"), "流程实例名"), 400, HorizontalAlignment.Left);
            lvWorkFlowMonitor.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmWorkFlowMonitor_colStartTime"), "开始时间"), 160, HorizontalAlignment.Left);
            lvWorkFlowMonitor.Columns.Add(StringHelper.GetStringValue(ResourceManagerWrapper.Instance.Get("FrmWorkFlowMonitor_colEndTime"), "结束时间"), 150, HorizontalAlignment.Left);
            int recordCount;
            DataTable datatableWF = RDIFrameworkService.Instance.WorkFlowInstanceService.GetWorkFlowInstanceDTByPage(SystemInfo.UserInfo, "", out recordCount, 1, 20, WorkFlowInstanceTable.FieldStartTime + " DESC ");
            if (datatableWF != null && datatableWF.Rows.Count > 0)
            {
                foreach (DataRow dr in datatableWF.Rows)
                {
                    ListViewItem item1 = new ListViewItem(BusinessLogic.ConvertToString(dr["FlowInsCaption"].ToString()), 0) { ForeColor = ColorTranslator.FromHtml("#458FCE") };
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["StartTime"].ToString()));
                    item1.SubItems.Add(BusinessLogic.ConvertToString(dr["EndTime"].ToString()));
                    lvWorkFlowMonitor.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
        }

        private void lblRefresh1_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            CreatUnClaimedTaskListView();
            this.Cursor = holdCursor;
        }

        private void lblMore1_Click(object sender, EventArgs e)
        {
            if (OnMoreClicked != null)
            {
                this.PageArea = StartPageArea.UnClaimedTask;
                OnMoreClicked(this, null);
            }
        }

        private void lblRefresh2_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            CreatTodoTaskListView();
            this.Cursor = holdCursor;
        }

        private void lblMore2_Click(object sender, EventArgs e)
        {
            if (OnMoreClicked != null)
            {
                this.PageArea = StartPageArea.ToDoList;
                OnMoreClicked(this, null);
            }
        }

        private void lblRefresh3_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            CreatBeDoneListView();
            this.Cursor = holdCursor;
        }

        private void lblMore3_Click(object sender, EventArgs e)
        {
            if (OnMoreClicked != null)
            {
                this.PageArea = StartPageArea.BeDownList;
                OnMoreClicked(this, null);
            }
        }

        private void lblRefresh4_Click(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            CreatWorkFlowMonitorListView();
            this.Cursor = holdCursor;
        }

        private void lblMore4_Click(object sender, EventArgs e)
        {
            if (OnMoreClicked != null)
            {
                this.PageArea = StartPageArea.WorkFlowMonitor;
                OnMoreClicked(this, null);
            }
        }
    }

    /// <summary>
    /// 起始页控件页面区域
    /// </summary>
    public enum StartPageArea
    {
        /// <summary>
        /// 未认领任务区域
        /// </summary>
        UnClaimedTask = 00001,

        /// <summary>
        /// 待办任务区域
        /// </summary>
        ToDoList = 00002,

        /// <summary>
        /// 已完成任务区域
        /// </summary>
        BeDownList = 00003,

        /// <summary>
        /// 流程监控区域
        /// </summary>
        WorkFlowMonitor = 00004
    }
}
