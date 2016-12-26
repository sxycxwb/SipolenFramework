using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;

namespace RDIFramework.WinModule
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 组织机构选择控件
    /// </summary>
    public partial class UcUserSelect : UserControl
    {
        public event BusinessLogic.CheckMoveEventHandler OnButtonConfirmClick;

        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.txtFullName.ButtonCustom.Visible;               
            }
            set
            {
                this.txtFullName.ButtonCustom.Visible = value;   
            }
        }

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public UserInfo UserInfo
        {
            get
            {
                return SystemInfo.UserInfo;
            }
        }

        private string selectedId = null;
        /// <summary>
        /// 被选中的用户主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                if (!this.DesignMode)
                {
                    this.selectedId = value;
                    this.SelectedFullName = string.Empty;
                    // 获取父节点
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        RDIFrameworkService Service = new RDIFrameworkService();
                        PiUserEntity entity = Service.UserService.GetEntity(UserInfo, this.selectedId);
                        if (Service.OrganizeService is ICommunicationObject)
                        {
                            ((ICommunicationObject)Service.UserService).Close();
                        }
                        this.SelectedFullName = entity != null ? entity.RealName : string.Empty;
                        
                    }
                    this.SetControlState();
                }
            }
        }
        private string[] userIds = null;    // 被选中的主键集
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string[] UserIds
        {
            get
            {
                return this.userIds;
            }
            set
            {
                this.userIds = value;
            }
        }

        private string[] selectedIds = null;    // 被选中的主键集
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;

                if (this.selectedIds != null && this.selectedIds.Length > 0)
                {
                    RDIFrameworkService Service = new RDIFrameworkService();
                    DataTable usersDT = Service.UserService.GetDTByIds(UserInfo, this.selectedIds);
                    if (Service.UserService is ICommunicationObject)
                    {
                        ((ICommunicationObject)Service.UserService).Close();
                    }

                    if (usersDT != null && usersDT.Rows.Count > 0)
                    {
                        string RealNames = usersDT.Rows.Cast<DataRow>().Aggregate(string.Empty, (current, row) => current + ("," + BusinessLogic.ConvertToString(row[PiUserTable.FieldRealName])));

                        if (!string.IsNullOrEmpty(RealNames))
                        {
                            RealNames = RealNames.Substring(1);
                        }

                        this.SelectedFullName = RealNames;
                    }
                    else
                    {
                        this.SelectedFullName = string.Empty;
                    }
                }
                else
                {
                    this.SelectedFullName = string.Empty;
                }

            }
        }

        private string[] setSelectedIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectedIds
        {
            get
            {
                return this.setSelectedIds;
            }
            set
            {
                this.setSelectedIds = value;
            }
        }

        private string selectedFullName = string.Empty;
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
                this.txtFullName.Text = value;
                this.SetControlState();
            }
        }

        private string organizeId = string.Empty;
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrganizeId
        {
            get
            {
                return this.organizeId;
            }
            set
            {
                this.organizeId = value;
            }
        }

        private string roleId = string.Empty;
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleId
        {
            get
            {
                return this.roleId;
            }
            set
            {
                this.roleId = value;
            }
        }

        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect
        {
            get
            {
                return this.multiSelect;
            }
            set
            {
                this.multiSelect = value;
            }
        }

        private bool allowNull = true;
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
                this.SetControlState();
            }
        }



        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取员工列表
        /// </summary>
        public string PermissionScopeCode
        {
            get
            {
                return this.byPermissionCode;
            }
            set
            {
                this.byPermissionCode = value;
            }
        }

        private string[] removeIds = null;
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        public string[] RemoveIds
        {
            get
            {
                return this.removeIds;
            }
            set
            {
                this.removeIds = value;
            }
        }

        public UcUserSelect()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        // 当选择的公司部门发生变化时
        public event BusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.txtFullName.ButtonClear.Visible = this.AllowNull;
            this.txtFullName.ButtonClear.Enabled = !String.IsNullOrEmpty(this.SelectedId) || this.SelectedIds != null;
        }
        #endregion


        private void UcUserSelect_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        private DialogResult SelectAct(string[] userIds, string organizeId, string roleId)
        {
            // 用反射获得窗体
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmUserSelect";
            FrmUserSelect frmUserSelect = (FrmUserSelect)CacheManager.Instance.GetForm(assemblyName, formName);
            frmUserSelect.MultiSelect = this.MultiSelect;
            frmUserSelect.UserIds = userIds;
            frmUserSelect.OrganizeId = organizeId;
            frmUserSelect.RoleId = roleId;
            ((FrmUserSelect)frmUserSelect).AllowNull = this.AllowNull;
            frmUserSelect.PermissionScopeCode = this.PermissionScopeCode;

            if (frmUserSelect.ShowDialog() == DialogResult.OK)
            {
                if (this.MultiSelect)
                {
                    this.SelectedIds = frmUserSelect.SelectedIds;
                }
                else
                {
                    this.SelectedId = frmUserSelect.SelectedId;
                    this.SelectedFullName = frmUserSelect.SelectedFullName;
                    this.txtFullName.Text = frmUserSelect.SelectedFullName;
                }
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
                this.SetControlState();
                return DialogResult.OK;
            }
            return DialogResult.Cancel;
        }

        public void SetNull()
        {
            if (!String.IsNullOrEmpty(this.SelectedId))
            {
                this.SelectedId = null;
                this.SelectedFullName = null;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }

            if (this.SelectedIds != null && this.SelectedIds.Length > 0)
            {
                this.SelectedIds = null;
                this.SelectedFullName = null;
            }

            this.SetControlState();
        }       

        private void txtFullName_ButtonClearClick(object sender, CancelEventArgs e)
        {
            this.SetNull();
        }

        private void txtFullName_ButtonCustomClick(object sender, EventArgs e)
        {
            SelectAct(this.UserIds,this.OrganizeId,this.RoleId);
        }
    }
}
