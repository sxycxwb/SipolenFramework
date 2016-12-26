using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.ServiceModel;

namespace RDIFramework.WinModule
{
    using RDIFramework.Utilities;
    using RDIFramework.BizLogic;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// 数据字典选择控件
    /// </summary>
    public partial class UcItemsSelect : UserControl
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
        /// 被选中的数据字典主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
                this.SelectedFullName = string.Empty;
                if (!this.DesignMode)
                {
                    // 获取父节点
                    if (!string.IsNullOrEmpty(this.selectedId))
                    {
                        if (!this.DesignMode)
                        {
                            RDIFrameworkService Service = new RDIFrameworkService();
                            CiItemsEntity entity = Service.ItemsService.GetEntity(UserInfo, this.selectedId);
                            if (Service.OrganizeService is ICommunicationObject)
                            {
                                ((ICommunicationObject)Service.OrganizeService).Close();
                            }
                            this.SelectedFullName = entity != null ? entity.FullName : string.Empty;
                        }
                    }
                    this.SetControlState();
                }
            }
        }

        /// <summary>
        /// 被选中的数据字典名称
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.txtFullName.Text;
            }
            set
            {
                this.txtFullName.Text = value;
                this.SetControlState();
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

        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect { get; set; }

        /// <summary>
        /// 按什么权限域获取角色列表
        /// </summary>
        public string PermissionScopeCode { get; set; }

        /// <summary>
        /// 原先被选中的节点主键
        /// </summary>
        public string OpenId { get; set; }


        /// <summary>
        /// 是否检查移动
        /// </summary>
        public bool CheckMove { get; set; }

        public UcItemsSelect()
        {
            PermissionScopeCode = string.Empty;
            OpenId = string.Empty;
            CheckMove = false;
            MultiSelect = false;
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        // 当选择的数据字典发生变化时
        public event BusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.txtFullName.ButtonClear.Visible = this.AllowNull;
            this.txtFullName.ButtonClear.Enabled = !String.IsNullOrEmpty(this.SelectedId);
        }
        #endregion

        private void UcItemsSelect_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetControlState();
            }
        }

        private void SelectAct()
        {
            // 用反射获得窗体
            string assemblyName = "RDIFramework.WinModule";
            string formName = "FrmItemsSelect";
            Form frmItemsSelect = CacheManager.Instance.GetForm(assemblyName, formName);           
            ((FrmItemsSelect)frmItemsSelect).OpenId = this.OpenId;
            ((FrmItemsSelect)frmItemsSelect).CheckMove = this.CheckMove;
            ((FrmItemsSelect)frmItemsSelect).AllowNull = this.AllowNull;
            ((FrmItemsSelect)frmItemsSelect).PermissionScopeCode = this.PermissionScopeCode;

            if (frmItemsSelect.ShowDialog() == DialogResult.OK)
            {
                this.SelectedId = ((FrmItemsSelect)frmItemsSelect).SelectedId;
                this.SelectedFullName = ((FrmItemsSelect)frmItemsSelect).SelectedFullName;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
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
            this.SetControlState();
        }       

        private void txtFullName_ButtonClearClick(object sender, CancelEventArgs e)
        {
            this.SetNull();
        }

        private void txtFullName_ButtonCustomClick(object sender, EventArgs e)
        {
            SelectAct();
        }
    }
}
