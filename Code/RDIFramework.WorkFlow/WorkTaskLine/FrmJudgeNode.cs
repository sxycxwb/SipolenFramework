using System;

namespace RDIFramework.WorkFlow
{
    using RDIFramework.BizLogic;

    /// <summary>
    /// FrmJudgeNode.cs
    /// 控制节点配置
    /// 
    /// </summary>
    public partial class FrmJudgeNode : BaseForm_Single
    {
        public JudgeTask NowTask;
        public string UserId = "";//操作人账号，用作权限判断。
        public string UserName = "";

        public FrmJudgeNode(JudgeTask jTask, string userId, string userName)
        {
            InitializeComponent();
            NowTask = jTask;
            this.UserId = userId;
            this.UserName = userName;
            tbxTaskName.Text = NowTask.TaskName;
            switch (NowTask.TaskTypeAndOr)
            {
                case WorkConst.Command_And:
                    rbtAnd.Checked = true;
                    break;
                case WorkConst.Command_Or:
                    rbtOr.Checked = true;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbtAnd.Checked)
            {
                NowTask.TaskTypeAndOr = WorkConst.Command_And;
            }
            else if (rbtOr.Checked)
            {
                NowTask.TaskTypeAndOr = WorkConst.Command_Or;
            }

            NowTask.TaskName = tbxTaskName.Text;
            NowTask.SaveUpdateTask();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
