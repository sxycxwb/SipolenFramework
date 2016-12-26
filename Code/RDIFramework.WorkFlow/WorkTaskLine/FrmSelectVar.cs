using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;

    public partial class FrmSelectVar : BaseForm_Single
    {
        private string WorkTaskId = "";
        private string WorkflowId = "";
        public FrmSelectVar(string workflowId,string taskId)
        {
            WorkTaskId = taskId;
            WorkflowId = workflowId;
            InitializeComponent();
        }
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        private void InitializeUIData()
        {
            //�г������û�
            lvVar.Columns.Add("������", 200, HorizontalAlignment.Left);
            lvVar.Columns.Add("��������", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("����ģʽ", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("���ݿ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("���ݱ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("�ֶ���", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("��ʼֵ", 100, HorizontalAlignment.Left);
            lvVar.Columns.Add("��������", 100, HorizontalAlignment.Left);

            //�������̱���
            var dtSearch = RDIFrameworkService.Instance.WorkFlowTemplateService.GetWorkFlowVar(SystemInfo.UserInfo, WorkflowId);
            foreach (DataRow dr in dtSearch.Rows)
            {
                var lvi1 = new ListViewItem(dr[TaskVarTable.FieldVarName].ToString(), 0);
                lvi1.SubItems.Add(dr[TaskVarTable.FieldVarType].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldVarModule].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldDataBaseName].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTableName].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTableField].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldInitValue].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldAccessType].ToString());
                lvVar.Items.Add(lvi1);
            }

            //�����������
            dtSearch = RDIFrameworkService.Instance.WorkFlowTemplateService.GetTaskVar(SystemInfo.UserInfo, WorkTaskId);
            
            foreach (DataRow dr in dtSearch.Rows)
            {
                var lvi1 = new ListViewItem(dr[TaskVarTable.FieldVarName].ToString(), 0);
                lvi1.SubItems.Add(dr[TaskVarTable.FieldVarType].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldVarModule].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldDataBaseName].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTableName].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldTableField].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldInitValue].ToString());
                lvi1.SubItems.Add(dr[TaskVarTable.FieldAccessType].ToString());
                lvVar.Items.Add(lvi1);
            }
        }

        private void SelectVar_Load(object sender, EventArgs e)
        {
            InitializeUIData();
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
    }
}

