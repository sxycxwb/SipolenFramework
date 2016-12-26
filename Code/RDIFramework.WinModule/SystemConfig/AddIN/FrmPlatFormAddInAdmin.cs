/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-25 10:39:34
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmAddInAdmin
    /// 平台插件管理
    /// 
    /// 修改纪录
    ///
    ///		2012-05-25 版本：1.0 EricHu 创建FrmAddInAdmin。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>EricHu</name>
    ///		<date>2012-05-25</date>
    /// </author>
    /// </summary>
    public partial class FrmPlatFormAddInAdmin : BaseForm
    {
        DataTable DTAddIn = new DataTable(PiPlatFormAddInTable.TableName);

        /// <summary>
        /// 本模块的访问权限
        /// </summary>
        private bool permissionAccess = false;

        /// <summary>
        /// 本模块的添加权限
        /// </summary>
        private bool permissionAdd = false;

        /// <summary>
        /// 本模块的删除权限
        /// </summary>
        private bool permissionDelete = false;


        /// <summary>
        /// 表格中的主键
        /// </summary>
        public override string EntityId
        {
            get
            {
                return BasePageLogic.GetDataGridViewEntityId(this.dgvInfo, PiPlatFormAddInTable.FieldId);
            }
        }


        public FrmPlatFormAddInAdmin()
        {
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {            
            this.btnDelete.Enabled = false;
            this.btnAdd.Enabled = this.permissionAdd;
            if (DTAddIn.DefaultView.Count >= 1)
            {
                this.btnAdd.Enabled = this.permissionAdd;
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
            this.permissionAccess = this.IsModuleAuthorized("PlatFormAddInAdmin");
            this.permissionAdd = this.IsAuthorized("PlatFormAddInAdmin.Add");
            this.permissionDelete = this.IsAuthorized("PlatFormAddInAdmin.Delete");
        }
        #endregion

        #region private void BindData():绑定屏幕数据
        private void BindData()
        {
            this.DTAddIn = RDIFrameworkService.Instance.PlatFormAddInService.GetDT(this.UserInfo);

            if (this.DTAddIn != null && this.DTAddIn.Rows.Count > 0)
            {
                this.dgvInfo.DataSource = this.DTAddIn.DefaultView;
            }
        }
        #endregion

        #region public override void FormOnLoad()
        public override void FormOnLoad()
        {
            this.DataGridViewOnLoad(dgvInfo);
            this.dgvInfo.AutoGenerateColumns = false;            
            this.BindData();
            this.SetControlState();
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmPlatFormAddInAdd platFormAddInAdd  = new FrmPlatFormAddInAdd();
            if (platFormAddInAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BindData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvInfo.EndEdit(); //此句非常关键，必须结束DataGridView的修改，才能得到其真实的值。
            if (BasePageLogic.CheckInputSelectAnyOne(dgvInfo, "colSelected"))
            {
                if (!CheckInput())
                {
                    return;
                }

                if (MessageBoxHelper.Show("你确定所选数据吗？（是/否）") == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        int returnValue = RDIFrameworkService.Instance.PlatFormAddInService.SetDeleted(base.UserInfo, BasePageLogic.GetSelecteIds(this.dgvInfo, CiDbLinkDefineTable.FieldId, "colSelected", true));
                        if (returnValue > 0)
                        {
                            if (SystemInfo.ShowSuccessMsg)
                            {
                                MessageBoxHelper.ShowSuccessMsg("共删除【" + returnValue.ToString() + "】条数据！");
                                this.BindData();
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        this.ProcessException(exception);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInfo_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgvInfo.CurrentCell != null)
            {
                if (BusinessLogic.ConvertIntToBoolean(dgvInfo.CurrentRow.Cells["colEnabled"].Value))
                {
                    this.btnEnabled.Text = "停用";
                }
                else
                {
                    this.btnEnabled.Text = "启用";
                }
            }
        }

        private void btnEnabled_Click(object sender, EventArgs e)
        {
            if (dgvInfo.CurrentCell == null || dgvInfo.Rows.Count <= 0)
            {
                return;
            }

            int currentRowIndex = dgvInfo.CurrentCell.RowIndex;

            if (this.btnEnabled.Text == "启用")
            {                               
                if (RDIFrameworkService.Instance.PlatFormAddInService.SetEnabled(UserInfo, this.EntityId, 1) > 0)
                {
                    this.BindData();
                    
                }
            }
            else
            {
                if (RDIFrameworkService.Instance.PlatFormAddInService.SetEnabled(UserInfo, this.EntityId, 0) > 0)
                {
                    this.BindData();
                }
            }

            dgvInfo.Rows[currentRowIndex].Selected = true;
        }

        private void dgvInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdaterConfig_Click(object sender, EventArgs e)
        {
            FrmGenerateUpdaterConfig updaterConfig = new FrmGenerateUpdaterConfig();
            updaterConfig.ShowDialog();
        }  
    }
}
