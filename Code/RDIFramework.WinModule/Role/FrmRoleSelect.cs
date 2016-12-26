/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-4 11:07:45
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
    /// FrmRoleSelect
    /// 权限管理-选择角色窗体
    /// 
    /// </summary>
    public partial class FrmRoleSelect : BaseForm,IBaseSelectRoleForm
    {
        private DataTable DTRole = new DataTable(PiRoleTable.TableName);

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

        private bool showRoleOnly = true;
        /// <summary>
        /// 只显示角色
        /// </summary>
        public bool ShowRoleOnly
        {
            get
            {
                return this.showRoleOnly;
            }
            set
            {
                this.showRoleOnly = value;
            }
        }

        private string categoryCode = string.Empty;
        /// <summary>
        /// 角色分类
        /// </summary>
        public string CategoryCode
        {
            get
            {
                return this.categoryCode;
            }
            set
            {
                this.categoryCode = value;
            }
        }

        private bool allowNull = true;
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
            }
        }

        private bool allowSelect = true;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
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

        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取角色列表
        /// </summary>
        public string PermissionItemScopeCode
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

        private string selectedId = string.Empty; // 被选中的角色主键
        /// <summary>
        /// 被选中的角色主键
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
            }
        }

        private string selectedFullName = string.Empty; // 被选中的角色全名
        /// <summary>
        /// 被选中的角色全名
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        private string[] selectedIds = new string[0];    // 被选中的主键集
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
            }
        }

        public FrmRoleSelect()
        {
            InitializeComponent();
        }

        public FrmRoleSelect(string categoryCode)
            : this()
        {
            this.CategoryCode = categoryCode;
        }

        #region private void BindItemDetails() 绑定下拉筐数据
        public void SetSelectedValue(string selectedValue)
        {
            if (selectedValue != null)
            {
                for (int i = 0; i < this.cboRoleCategory.Items.Count; i++)
                {
                    if (selectedValue.Equals(this.cboRoleCategory.Items[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        this.cboRoleCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定下拉筐数据
        /// </summary>
        private void BindItemDetails()
        {
            // 绑定职位数据，这里需要考虑屏幕刷新、批量保存时的效果问题
            if (this.cboRoleCategory.Items.Count != 0) return;
            var dtItemDetail = RDIFrameworkService.Instance.ItemDetailsService.GetDTByCode(base.UserInfo, "RoleCategory");
            if (dtItemDetail == null || dtItemDetail.Rows.Count <= 0) return;
            cboRoleCategory.Items.Clear();
            cboRoleCategory.Items.Insert(0, string.Empty);
            cboRoleCategory.Items.AddRange(BusinessLogic.FieldToArray(dtItemDetail, CiItemDetailsTable.FieldItemValue));

            if (!string.IsNullOrEmpty(this.CategoryCode))
            {
                if (this.cboRoleCategory.Items.Contains(this.CategoryCode))
                {
                    SetSelectedValue(this.CategoryCode);
                }
                if (!this.UserInfo.IsAdministrator)
                {
                    this.cboRoleCategory.Enabled = false;
                }
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvRole);

            // 调用接口方式实现
            this.DTRole = !String.IsNullOrEmpty(this.PermissionItemScopeCode) ? RDIFrameworkService.Instance.PermissionService.GetRoleDTByPermissionScope(UserInfo, UserInfo.Id, this.PermissionItemScopeCode) : RDIFrameworkService.Instance.RoleService.GetDT(UserInfo);

            // 设置表主键
            var primaryKey = new DataColumn[] { this.DTRole.Columns[PiRoleTable.FieldId] };
            this.DTRole.PrimaryKey = primaryKey;
            // 检查是否需要移出
            if (this.RemoveIds != null)
            {
                for (int i = 0; i < this.RemoveIds.Length; i++)
                {
                    var dataRow = this.DTRole.Rows.Find(this.RemoveIds[i]);
                    if (dataRow != null)
                    {
                        dataRow.Delete();
                    }
                }
                this.DTRole.AcceptChanges();
            }

            // 往DataTable中添加选择列
            //BasePageLogic.DataTableAddColumn(this.DTRole, "colSelected");
            this.dgvRole.AutoGenerateColumns = false;
            //this.dgvRole.DefaultView.Sort = PiRoleTable.FieldSortCode;
            this.dgvRole.DataSource = this.DTRole;
            // 获取分类列表
            this.BindItemDetails();
            // 设置数据过滤
            this.SetRowFilter();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSelect.Enabled = this.DTRole.DefaultView.Count != 0;
        }

        #endregion

        private string GetCategoryFilter()
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(this.cboRoleCategory.Text) && this.cboRoleCategory.Text.Trim().Length > 0)
            {
                returnValue = PiRoleTable.FieldCategory + " = '" + this.cboRoleCategory.Text + "' ";
            }
            return returnValue;
        }

        #region private void SetRowFilter() 设置数据过滤
        /// <summary>
        /// 设置数据过滤
        /// </summary>
        private void SetRowFilter()
        {
            this.DTRole.DefaultView.RowFilter = this.GetCategoryFilter();
        }
        #endregion

        #region private void GetSelectedId(DataRow dataRow) 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// <param name="dataRow">数据行</param>
        /// </summary>
        private void GetSelectedId(DataRow dataRow)
        {
            // 获得当前选中的行 
            var roleEntity = new PiRoleEntity();
            roleEntity.GetFrom(dataRow);
            // 获得具体选中的内容
            if (string.IsNullOrEmpty(roleEntity.Id)) return;
            this.SelectedId = roleEntity.Id;
            this.SelectedFullName = roleEntity.RealName;
        }
        #endregion

        private void dgvRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiSelect)
            {
                var dataRow = BasePageLogic.GetDataGridViewEntity(this.dgvRole);
                if (dataRow != null)
                {
                    this.GetSelectedId(dataRow);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }      

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <returns>主键数组</returns>
        private string[] GetSelectedIds()
        {
            return BasePageLogic.GetSelecteIds(this.dgvRole, PiRoleTable.FieldId, "colSelected", true);
        }
        #endregion

        private void cboRoleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                // 设置数据过滤
                this.SetRowFilter();
                // 设置按钮状态
                this.SetControlState();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.MultiSelect)
            {
                if (!BasePageLogic.CheckInputSelectAnyOne(this.dgvRole, "colSelected")) return;
                this.SelectedIds = this.GetSelectedIds();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (!BasePageLogic.CheckInputSelectOne(this.dgvRole, "colSelected")) return;
                var dataRow = BasePageLogic.GetSelecteRow(this.dgvRole, "colSelected") ??
                              BasePageLogic.GetDataGridViewEntity(this.dgvRole);
                if (dataRow != null)
                {
                    this.GetSelectedId(dataRow);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
