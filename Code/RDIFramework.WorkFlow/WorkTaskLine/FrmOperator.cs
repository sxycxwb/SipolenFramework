using System;
using System.Windows.Forms;
using RDIFramework.BizLogic;

namespace RDIFramework.WorkFlow
{
    public partial class FrmOperator : BaseForm_Single
    {
        public string OperContent { get; set; }
        public string Description { get; set; }
        public string OperDisplay { get; set; }
        public int OperType; //处理类型
        public int Relation=0;//没关系
        public bool InorExclude;
        public string FmState { get; set; }
        public string OperId { get; set; }
        public string WorkflowId { get; set; }

        /// <summary> 
        /// 权限域编号(按权限管理范围来列出数据，只能管理这个范围的数据)
        /// </summary>
        public string PermissionItemScopeCode = "Resource.ManagePermission";

        public FrmOperator(string state)
        {
            InitializeComponent();
            FmState = state;
        }

        public override void FormOnLoad()
        {
            if (FmState == WorkConst.STATE_MOD)
            {
                this.Text = @"修改处理者";
                InitData();
            }
        }

        private void SetOperation()
        {
            ///////处理者//////////
            if (rbtOpr1.Checked)//
            {
                Description = "流程启动者";
                OperType = 1;
                OperDisplay = "流程启动者";
            }
            else if (rbtOpr2.Checked) //某一任务实际执行者
            {
                Description = "[" + tbxOpr2.Text + "]任务实际执行者";
                OperDisplay = tbxOpr2.Text;
                OperType = 2;
            }
            else if (rbtOpr3.Checked) //指定人员
            {
                Description = tbxOpr3.Text;
                OperDisplay = tbxOpr3.Text;
                OperType = 3;
            }
            else if (rbtOpr4.Checked) //部门
            {
                Description = tbxOpr4.Text;
                OperDisplay = tbxOpr4.Text;
                OperType = 4;
            }
            else if (rbtOpr5.Checked) // 角色
            {
                Description = tbxOpr5.Text;
                OperDisplay = tbxOpr5.Text;
                OperType = 5;
            }
            else if (rbtOpr6.Checked) //岗位
            {
                Description = tbxOpr6.Text;
                OperDisplay = tbxOpr6.Text;
                OperType = 6;
            }
            else if (rbtOpr7.Checked) //从变量中获取
            {
                Description = tbxOpr7.Text;
                OperDisplay = tbxOpr7.Text;
                OperType = 7;
            }
            else if (rbtOpr8.Checked) //某一任务选择的处理者
            {
                Description = tbxOpr8.Text;
                OperDisplay = tbxOpr8.Text;
                OperType = 8;
            }
            else if (rbtOpr9.Checked) //所有人
            {
                Description = "所有人";
                OperDisplay = Description;
                OperType = 9;
            }

            ///////关系筛选//////////
            if (rbtRlt1.Checked && cbxRelation.Checked)//本部门领导
            {
                Description = "本部门领导 of [" + Description + "]";
                Relation = 1;
            }
            else if (rbtRlt2.Checked && cbxRelation.Checked)//所在部门
            {
                Description = "所在部门 of [" + Description + "]";
                Relation = 2;
            }
            else if (rbtRlt3.Checked && cbxRelation.Checked)//上级部门
            {
                Description = "上级部门 of [" + Description + "]";
                Relation = 3;
            }
            else if (rbtRlt4.Checked && cbxRelation.Checked)//下级部门
            {
                Description = "下级部门 of [" + Description + "]";
                Relation = 4;
            }
            else if (rbtRlt5.Checked && cbxRelation.Checked)//上级领导
            {
                Description = "上级领导 of [" + Description + "]";
                Relation = 5;
            }
            else if (rbtRlt6.Checked && cbxRelation.Checked)//下级领导
            {
                Description = "下级领导 of [" + Description + "]";
                Relation = 6;
            }
            else Relation = 0;

            /////包含排除//////////
            if (rbtInclude.Checked)
            {
                InorExclude = true;
            }
            else if (rbtExclude.Checked)
            {
                InorExclude = false;
            }
        }

        private void InitData()
        {
            if (InorExclude)
                rbtInclude.Checked = true;
            else rbtExclude.Checked = true;
            switch (OperType)
            {
                case 1:
                    rbtOpr1.Checked = true;
                    break;
                case 2:
                    rbtOpr2.Checked = true;
                   // tbxOpr2.Enabled = true;
                    tbxOpr2.Text = OperDisplay;
                    break;
                case 3:

                    rbtOpr3.Checked = true;
                    //tbxOpr3.Enabled = true;
                    tbxOpr3.Text = OperDisplay;
                    break;
                case 4:
                    rbtOpr4.Checked = true;
                   // tbxOpr4.Enabled = true;
                    tbxOpr4.Text = OperDisplay;
                    break;
                case 5:
                    rbtOpr5.Checked = true;
                   // tbxOpr5.Enabled = true;
                    tbxOpr5.Text = OperDisplay;
                    break;
                case 6:
                    rbtOpr6.Checked = true;
                  //  tbxOpr6.Enabled = true;
                    tbxOpr6.Text = OperDisplay;
                    break;
                case 7:
                    rbtOpr7.Checked = true;
                    //tbxOpr7.Enabled = true;
                    tbxOpr7.Text = OperDisplay;
                    break;
                case 8:
                    rbtOpr8.Checked = true;
                   // tbxOpr8.Enabled = true;
                    tbxOpr8.Text = OperDisplay;
                    break;
                case 9:
                    rbtOpr9.Checked = true;
                    break;
            }

            cbxRelation.Checked = Relation != 0;
            switch (Relation)
            {
                case 1:
                    rbtRlt1.Checked = true;
                    break;
                case 2:
                    rbtRlt2.Checked = true;
                    break;
                case 3:
                    rbtRlt3.Checked = true;
                    break;
                case 4:
                    rbtRlt4.Checked = true;
                    break;
                case 5:
                    rbtRlt5.Checked = true;
                    break;
                case 6:
                    rbtRlt6.Checked = true;
                    break;
            }
        }

        private void operEnable()
        {
            btnSelectOpr.Enabled = rbtOpr2.Checked;
            btnSelectUser.Enabled = rbtOpr3.Checked;
            btnSelectArch.Enabled = rbtOpr4.Checked;
            btnSelectRole.Enabled = rbtOpr5.Checked;
            btnSelectDuty.Enabled = rbtOpr6.Checked;
            btnSelectVar.Enabled = rbtOpr7.Checked;
            btnSelectTask.Enabled = rbtOpr8.Checked;
        }

        private void rltEnable(bool enable)
        {
            rbtRlt1.Enabled = enable;
            rbtRlt2.Enabled = enable;
            rbtRlt3.Enabled = enable;
            rbtRlt4.Enabled = enable;
            rbtRlt5.Enabled = enable;
            rbtRlt6.Enabled = enable;
        }

        private void operEnable(bool enable)
        {
            rbtOpr1.Enabled = enable;
            rbtOpr2.Enabled = enable;
            rbtOpr3.Enabled = enable;
            rbtOpr4.Enabled = enable;
            rbtOpr5.Enabled = enable;
            rbtOpr6.Enabled = enable;
            rbtOpr7.Enabled = enable;
            rbtOpr8.Enabled = enable;
            rbtOpr9.Enabled = enable;
            operEnable();
            groupBox2.Enabled = enable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetOperation();
            Close();
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            //FrmSelectUser tmpFrmSelectUser = new FrmSelectUser();
            //tmpFrmSelectUser.ShowDialog();
            //DialogResult dlr = tmpFrmSelectUser.DialogResult;
            //if (dlr == DialogResult.OK && tmpFrmSelectUser.lvUser.SelectedItems.Count>0)
            //{
            //    tbxOpr3.Text=tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[1].Text;
            //    OperContent = tmpFrmSelectUser.lvUser.SelectedItems[0].SubItems[0].Text;
            //}

            var frmUserSelect = new FrmUserSelect {MultiSelect = false};
            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                tbxOpr3.Text = frmUserSelect.SelectedFullName;
                OperContent = frmUserSelect.SelectedId;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelectArch_Click(object sender, EventArgs e)
        {
            //FrmSelectArch tmpFrmSelectArch = new FrmSelectArch(WorkConst.ARCHITECTURE_ARCH);
            //tmpFrmSelectArch.ShowDialog();
            //DialogResult dlr = tmpFrmSelectArch.DialogResult;
            //if (dlr == DialogResult.OK && tmpFrmSelectArch.tvArch.SelectedNode != null)
            //{
            //    tbxOpr4.Text = tmpFrmSelectArch.tvArch.SelectedNode.Text;
            //    OperContent = (tmpFrmSelectArch.tvArch.SelectedNode as BaseTemplateTreeNode).NodeId;
            //}

            var frmOrganizeSelect = new FrmOrganizeSelect
            {
                AllowNull = false,
                PermissionScopeCode = this.PermissionItemScopeCode
            };
            if (frmOrganizeSelect.ShowDialog() == DialogResult.OK)
            {
                tbxOpr4.Text = frmOrganizeSelect.SelectedFullName;
                OperContent = frmOrganizeSelect.SelectedId;
            }
        }

        private void btnSelectRole_Click(object sender, EventArgs e)
        {
            FrmRoleSelect frmRoleSelect = new FrmRoleSelect
            {
                MultiSelect = false,
                PermissionItemScopeCode = this.PermissionItemScopeCode
            };
            if (frmRoleSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxOpr5.Text = frmRoleSelect.SelectedFullName;
                OperContent = frmRoleSelect.SelectedId;
            }

            //FrmSelectGroup tmpFrmSelectGroup = new FrmSelectGroup();
            //tmpFrmSelectGroup.ShowDialog();
            //DialogResult dlr = tmpFrmSelectGroup.DialogResult;
            //if (dlr == DialogResult.OK && tmpFrmSelectGroup.lvGroup.SelectedItems.Count>0)
            //{
            //    tbxOpr5.Text = tmpFrmSelectGroup.lvGroup.SelectedItems[0].Text;
            //    OperContent = tmpFrmSelectGroup.lvGroup.SelectedItems[0].SubItems[1].Text;
            //}
        }

        private void btnSelectDuty_Click(object sender, EventArgs e)
        {
            FrmRoleSelect frmRoleSelect = new FrmRoleSelect("Duty")
            {
                MultiSelect = false,
                PermissionItemScopeCode = this.PermissionItemScopeCode
            };
            if (frmRoleSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxOpr6.Text = frmRoleSelect.SelectedFullName;
                OperContent = frmRoleSelect.SelectedId;
            }

            //FrmSelectArch tmpFrmSelectArch = new FrmSelectArch(WorkConst.ARCHITECTURE_DUTY);
            //tmpFrmSelectArch.ShowDialog();
            //DialogResult dlr = tmpFrmSelectArch.DialogResult;
            //if (dlr == DialogResult.OK && tmpFrmSelectArch.tvArch.SelectedNode != null)
            //{
            //    tbxOpr6.Text = tmpFrmSelectArch.tvArch.SelectedNode.Text;
            //    OperContent = (tmpFrmSelectArch.tvArch.SelectedNode as BaseTemplateTreeNode).NodeId;
            //}
        }

        private void rbtOpr2_CheckedChanged(object sender, EventArgs e)
        {
            //某一任务实际处理者2
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
        }

        private void rbtOpr1_CheckedChanged(object sender, EventArgs e)
        {
            //流程启动者1
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
         
        }

        private void rbtOpr3_CheckedChanged(object sender, EventArgs e)
        {
            //指定处理人3
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
        }

        private void rbtOpr4_CheckedChanged(object sender, EventArgs e)
        {
            //部门4
            operEnable();
            cbxRelation.Enabled = true;
            rltEnable(true);
            rbtRlt2.Enabled = false;
        }

        private void rbtOpr5_CheckedChanged(object sender, EventArgs e)
        {
            //角色5
            operEnable();
            rltEnable(false);
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
        }

        private void rbtOpr6_CheckedChanged(object sender, EventArgs e)
        {
            //岗位职务6
            operEnable();
            rltEnable(false);
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
        }

        private void rbtOpr7_CheckedChanged(object sender, EventArgs e)
        {
            //从变量中获取7
            operEnable();
            rltEnable(false);
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
        }

        private void rbtOpr8_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbtOpr9_CheckedChanged(object sender, EventArgs e)
        {
            //所有人9
            operEnable();
            rltEnable(false);
            OperContent = "ALL";
            cbxRelation.Enabled = false;
            cbxRelation.Checked = false;
        }

        private void cbxRelation_CheckedChanged(object sender, EventArgs e)
        {
            rltEnable(cbxRelation.Checked);
        }

        private void btnSelectOpr_Click(object sender, EventArgs e)
        {
            FrmSelectTaskOperUser tmpFrmSelectTaskOperUser = new FrmSelectTaskOperUser(WorkflowId);
            tmpFrmSelectTaskOperUser.ShowDialog();
            DialogResult dlr = tmpFrmSelectTaskOperUser.DialogResult;
            if (dlr == DialogResult.OK && tmpFrmSelectTaskOperUser.lvTask.SelectedItems.Count > 0)
            {
                tbxOpr2.Text = tmpFrmSelectTaskOperUser.lvTask.SelectedItems[0].Text;
                OperContent = tmpFrmSelectTaskOperUser.lvTask.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnSelectTask_Click(object sender, EventArgs e)
        {
           
        }
    
        private void rbtExclude_CheckedChanged(object sender, EventArgs e)
        {
            //排除处理人时最允许排除具体的某个userid
            if (rbtExclude.Checked == true)
            {
                operEnable(false);
                this.rbtOpr3.Enabled = true;
                this.rbtOpr3.Checked = true;
                btnSelectUser.Enabled = true;
            }
        }

        private void rbtInclude_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtInclude.Checked == true)
            {
                operEnable(true);
            }
        }

        private void btnSelectVar_Click(object sender, EventArgs e)
        {
            FrmSelectVar tmpSelectVar = new FrmSelectVar(WorkflowId, "##");
            tmpSelectVar.ShowDialog();
            DialogResult dlr = tmpSelectVar.DialogResult;
            if (dlr == DialogResult.OK && tmpSelectVar.lvVar.SelectedItems.Count > 0)
            {
                tbxOpr7.Text = tbxOpr7.Text + "<%" + tmpSelectVar.lvVar.SelectedItems[0].Text + "%>";
            }
        }
    }
}