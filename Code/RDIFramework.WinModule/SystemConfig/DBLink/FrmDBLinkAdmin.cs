/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-22 15:37:17
 ******************************************************************************/
using System;
using System.Data;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmDBLinkAdmin : BaseForm
    {
        private DataTable DTDBLinkList = new DataTable(CiDbLinkDefineTable.TableName);
        private IDbLinkDefineService DBLinkDefinService = RDIFrameworkService.Instance.DbLinkDefineService;

        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的编辑权限
        /// </summary>
        private bool permissionEdit = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;

        /// <summary>
        /// 目标主键
        /// </summary>
        public string TargetId
        {
            get
            {
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvInfo);
                var targetId = dataRow[CiDbLinkDefineTable.FieldId].ToString();
                return targetId;
            }
        }

        public FrmDBLinkAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnDelete.Enabled  = false;
            this.btnEdit.Enabled    = false;
            this.btnAdd.Enabled     = true;
            if (this.DTDBLinkList.DefaultView.Count >= 1)
            {
                this.btnAdd.Enabled    = this.permissionAdd;
                this.btnEdit.Enabled   = this.permissionEdit;                
                this.btnDelete.Enabled = this.permissionDelete;
            }
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            this.permissionAccess   = this.IsModuleAuthorized("DBLinkManagement");
            this.permissionAdd      = this.IsAuthorized("DBLinkManagement.Add");
            this.permissionEdit     = this.IsAuthorized("DBLinkManagement.Edit");
            this.permissionDelete   = this.IsAuthorized("DBLinkManagement.Delete");            
        }
        #endregion

        private void BindData()
        {
            this.DTDBLinkList = DBLinkDefinService.GetDT(this.UserInfo);
            this.dgvInfo.AutoGenerateColumns = false;
            dgvInfo.DataSource = this.DTDBLinkList.DefaultView;           
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvInfo);

            // 绑定屏幕数据
            this.BindData();
            this.SetControlState();

        }
        #endregion        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmDbLink = new FrmDBLinkEdit {IsAdd = true};
            if (frmDbLink.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BindData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tmpId = BasePageLogic.GetDataGridViewEntityId(dgvInfo, CiDbLinkDefineTable.FieldId);
            if (string.IsNullOrEmpty(tmpId))
            {
                return;
            }
            var frmDbLink = new FrmDBLinkEdit(tmpId) { IsAdd = false };
            if (frmDbLink.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BindData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (!BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected")) return;
            if (!CheckInput())
            {
                return;
            }

            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    var returnValue = DBLinkDefinService.SetDeleted(base.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, CiDbLinkDefineTable.FieldId, "colSelected", true));
                    if (returnValue > 0 && SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(string.Format(RDIFrameworkMessage.MSG0077,returnValue.ToString()));
                        this.BindData();
                    }
                }
                catch (Exception exception)
                {
                    this.ProcessException(exception);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0102) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            this.Close(); 
        }
    }
}
