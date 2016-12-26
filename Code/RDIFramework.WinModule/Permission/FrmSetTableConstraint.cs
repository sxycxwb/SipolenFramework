using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmSetTableConstraint
    /// 设置指定表的约束条件
    /// 
    /// 修改记录
    ///     
    /// </summary>
    public partial class FrmSetTableConstraint : BaseForm
    {
        public FrmSetTableConstraint()
        {
            InitializeComponent();
        }

        public FrmSetTableConstraint(string resourceCategory, string resourceId, string tableName, string permissionCode = "Resource.AccessPermission")
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.TableName = tableName;
            this.PermissionCode = permissionCode;
            this.TableConstraint = null;
        }

        public FrmSetTableConstraint(string resourceCategory, string resourceId, string tableName, string tableConstraint,bool enabled=true)
            : this()
        {
            this.ResourceCategory = resourceCategory;
            this.ResourceId = resourceId;
            this.TableName = tableName;
            this.TableConstraint = tableConstraint;
            this.chkEnabled.Checked = enabled;
        }

        private string permissionCode = "Resource.AccessPermission";
        ///<summary>
        /// 什么操作权限
        ///</summary>
        public string PermissionCode
        {
            get
            {
                return permissionCode;
            }
            set
            {
                permissionCode = value;
            }
        }

        private string resourceCategory = string.Empty;
        ///<summary>
        /// 什么类型的
        ///</summary>
        public string ResourceCategory
        {
            get
            {
                return resourceCategory;
            }
            set
            {
                resourceCategory = value;
            }
        }

        private string resourceId = string.Empty;
        ///<summary>
        /// 什么资源
        ///</summary>
        public string ResourceId
        {
            get
            {
                return resourceId;
            }
            set
            {
                resourceId = value;
            }
        }

        private string tableName = string.Empty;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        private string tableRealName = string.Empty;
        /// <summary>
        /// 表全名
        /// </summary>
        public string TableRealName
        {
            get
            {
                return tableRealName;
            }
            set
            {
                tableRealName = value;
            }
        }


        private string tableConstraint = string.Empty;
        /// <summary>
        /// 条件表达式
        /// </summary>
        public string TableConstraint
        {
            get
            {
                return tableConstraint;
            }
            set
            {
                tableConstraint = value;
            }
        }

        // 表字段的绑定(有效的，未必删除的，是采用约束条件的)
        DataTable DTColumns = new DataTable(CiTableColumnsTable.TableName);

        private void GetResourceInfo()
        {
            if (this.ResourceCategory == PiRoleTable.TableName)
            {
                this.txtUserOrRole.Text = RDIFrameworkService.Instance.RoleService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
            if (this.ResourceCategory == PiUserTable.TableName)
            {
                this.txtUserOrRole.Text = RDIFrameworkService.Instance.UserService.GetEntity(this.UserInfo, this.ResourceId).RealName;
            }
        }

        private void GetTableRealName()
        {
            if (string.IsNullOrEmpty(this.TableName)) return;
            DataTable dt = RDIFrameworkService.Instance.TableColumnsService.GetAllTableScope(this.UserInfo);
            this.TableRealName = BusinessLogic.GetProperty(dt, PiTablePermissionScopeTable.FieldItemCode, this.TableName, PiTablePermissionScopeTable.FieldItemName);
            this.Text = this.Text + " " + TableRealName;
        }

        private void GetConstraint()
        {
            if (string.IsNullOrEmpty(this.TableConstraint))
            {
                var permissionScopeEntity = RDIFrameworkService.Instance.TableColumnsService.GetConstraintEntity(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TableName, this.PermissionCode);
                if (permissionScopeEntity != null)
                {
                    this.TableConstraint = permissionScopeEntity.PermissionConstraint;
                    this.chkEnabled.Checked = (permissionScopeEntity.Enabled == 1);
                }
            }
            if (!string.IsNullOrEmpty(this.TableConstraint))
            {
                this.txtTableConstraint.Text = this.TableConstraint;
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.GetResourceInfo();
            this.GetTableRealName();
            this.GetConstraint();           
            // 显示表达式
            this.ShowConstraint(this.TableConstraint);
          
        }
        #endregion

        private void ShowConstraint(string constraint)
        {
            this.txtTableConstraint.Text = this.TableConstraint;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnClearConstraint.Enabled = true;
            this.btnTestConstraint.Enabled = true;
            this.btnSave.Enabled = true;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (!this.ValidateConstraint())
            {
                return;
            }
   
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.TableConstraint = this.txtTableConstraint.Text.Trim();
                RDIFrameworkService.Instance.TableColumnsService.SetConstraint(this.UserInfo, this.ResourceCategory, this.ResourceId, this.TableName, this.PermissionCode, this.TableConstraint, this.chkEnabled.Checked);
                this.DialogResult = DialogResult.OK;
                // 关闭窗口
                this.Close();
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }           
        }

        private bool ValidateConstraint()
        {
            bool bResult = false;

            if (string.IsNullOrEmpty(this.txtTableConstraint.Text.Trim()))
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG9915);
                return false;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.TableConstraint = this.txtTableConstraint.Text.Trim();
            string commandText = string.Format("SELECT * FROM {0} WHERE 1<>1 AND {1}", this.TableName, this.TableConstraint);
            try
            {
                RDIFrameworkService.Instance.RDIFrameworkDBProviderService.ExecuteNonQuery(this.UserInfo, commandText);                
                bResult = true;
            }
            catch (Exception ex)
            {
                bResult = false;
                MessageBoxHelper.ShowErrorMsg(RDIFrameworkMessage.MSG9923);
            }
            finally
            {
                this.Cursor = holdCursor;
            }
            return bResult;
        }

        private void btnTestConstraint_Click(object sender, EventArgs e)
        {
            if (this.ValidateConstraint())
            {
                MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG9918);
            }
        }

        private void btnClearConstraint_Click(object sender, EventArgs e)
        {

        }

        private string GetConstraintExpression()
        {
            return this.txtTableConstraint.Text.Trim();
        }

        private void btnShowConstraintData_Click(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!this.CheckInput())
                {
                    return;
                }
                this.TableConstraint = this.GetConstraintExpression();
                if (string.IsNullOrEmpty(this.TableConstraint))
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG9915);
                    return;
                }
                else
                {
                    string assemblyName = "RDIFramework.WinModule";
                    string formName = "FrmShowConstraint" + this.TableName;
                    Type assemblyType = null;
                    try
                    {
                        assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
                    }
                    catch
                    {
                    }

                    Form frmTableShowConstraint = null;
                    if (assemblyType != null)
                    {
                        frmTableShowConstraint = (Form)Activator.CreateInstance(assemblyType, this.TableRealName, this.TableName, this.TableConstraint);
                    }
                    else
                    {
                        frmTableShowConstraint = new FrmShowConstraintTable(this.TableRealName, this.TableName, this.TableConstraint);
                    }
                    frmTableShowConstraint.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
