/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-4-18 9:00:32
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmModuleEdit
    /// 模块编辑（新增、修改）。
    /// 
    /// 修改记录
    ///     2015-08-08 XuWangBin V3.0 增加对MVC导航地址的配置。
    ///     2013-11-08 XuWangBin V2.7 增加对模块类型（1：WinForm、2：WebForm、3：WinForm与WebForm都支持-默认、6：其他）的识别。
    ///     2013-02-15 XuWangBin 修改模块ImageIndex为空时提示的错误信息。
    ///     2012-10-28 XuWangBin 新增对WebForm配置的要求。
    ///     2012-05-18 XuWangBin 新增模块图标的选择。
    /// </summary>
    public partial class FrmModuleEdit : BaseForm
    {
        IModuleService moduleService        = RDIFrameworkService.Instance.ModuleService;
        DataTable DTModule                  = null;
        PiModuleEntity currentModuleEntity  = null;
        bool isAdd                          = true;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 父模块Id
        /// </summary>
        public string ParentId { get; set; }

        private string SelectedFileId = string.Empty;

        public FrmModuleEdit()
        {
            ParentId = string.Empty;
            FullName = string.Empty;
            InitializeComponent();
        }

        #region public FrmModuleEdit(string id) 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">主键</param>
        public FrmModuleEdit(string id): this()
        {
            this.EntityId = id;
        }
        #endregion

        #region public override void ShowEntity() 显示内容
        /// <summary>
        /// 显示内容
        /// </summary>
        public override void ShowEntity()
        {
            currentModuleEntity         = BaseEntity.Create<PiModuleEntity>(this.DTModule);
            this.ParentId               = BusinessLogic.ConvertToString(currentModuleEntity.ParentId);
            this.txtCode.Text           = currentModuleEntity.Code;
            this.txtFullName.Text       = currentModuleEntity.FullName;
            this.txtNavigateUrl.Text    = currentModuleEntity.NavigateUrl;
            this.txtMvcNavigateUrl.Text = currentModuleEntity.MvcNavigateUrl;
            this.txtFormName.Text       = currentModuleEntity.FormName;
            this.txtAssemblyName.Text   = currentModuleEntity.AssemblyName;
            this.txtIconUrl.Text        = currentModuleEntity.IconUrl;
            this.txtIconCss.Text        = currentModuleEntity.IconCss;
            this.txtTarget.Text         = currentModuleEntity.Target;
            switch (currentModuleEntity.ModuleType)
            {
                case 1:
                    rbModuleType1.Checked = true;
                    break;
                case 2:
                    rbModuleType2.Checked = true;
                    break;
                case 3:
                    rbModuleType3.Checked = true;
                    break;
            }

            this.chkEnabled.Checked     = BusinessLogic.ConvertIntToBoolean(currentModuleEntity.Enabled);
            this.chkIsPublic.Checked    = BusinessLogic.ConvertIntToBoolean(currentModuleEntity.IsPublic);
            this.chkExpand.Checked      = BusinessLogic.ConvertIntToBoolean(currentModuleEntity.Expand);
            this.chkAllowEdit.Checked   = BusinessLogic.ConvertIntToBoolean(currentModuleEntity.AllowEdit);
            this.chkAllowDelete.Checked = BusinessLogic.ConvertIntToBoolean(currentModuleEntity.AllowDelete);
            this.chkIsMenu.Checked      = BusinessLogic.ConvertIntToBoolean(currentModuleEntity.IsMenu);
            this.txtDescription.Text    = currentModuleEntity.Description;
            if (!string.IsNullOrEmpty(currentModuleEntity.ImageIndex) && currentModuleEntity.ImageIndex.Trim().Length > 0)
            {
                var buffer = RDIFrameworkService.Instance.FileService.Download(this.UserInfo, currentModuleEntity.ImageIndex);
                if (buffer != null && buffer.Length > 0)
                {
                    pictureModulePic.Image = BusinessLogic.byteArrayToImage(buffer);
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
            //修改数据
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                btnSaveContinue.Visible = false;
                isAdd = false;
                this.DTModule = moduleService.GetDTByIds(UserInfo, new string[] { this.EntityId });
                // 显示内容
                this.ShowEntity();
                this.Text = @"编辑模块 - " + currentModuleEntity.FullName;
                // 设置焦点
                this.ActiveControl = this.txtFullName;
                this.txtFullName.Focus();
                this.btnAccessPermission.Visible = true;
            }
            else
            {
                rbModuleType1.Checked = true;
            }

            if (!string.IsNullOrEmpty(this.ParentId))
            {
                this.txtParentId.SelectedValue = this.ParentId;
                this.txtParentId.Text = moduleService.GetEntity(UserInfo, this.ParentId).FullName; 
            }          
        }
        #endregion

        #region public override void GetPermission() 获得页面的权限
        /// <summary>
        /// 获得页面的权限
        /// </summary>
        public override void GetPermission()
        {
            if (!UserInfo.IsAdministrator)
            {
            }
        }
        #endregion

        #region private void SaveAddData(bool close) 保存新增的数据
        /// <summary>
        /// 保存新增的数据
        /// </summary>
        /// <param name="close">增加成功是否关闭窗体</param>
        private void SaveAddData(bool close)
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbMain)) return;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            var moduleEntity = new PiModuleEntity
            {
                ParentId       = BusinessLogic.ConvertToString(txtParentId.SelectedValue),
                FullName       = txtFullName.Text.Trim(),
                Code           = txtCode.Text.Trim(),
                Target         = txtTarget.Text.Trim(),
                NavigateUrl    = txtNavigateUrl.Text.Trim(),
                MvcNavigateUrl = txtMvcNavigateUrl.Text.Trim(),
                ImageIndex     = SelectedFileId,
                IconUrl        = txtIconUrl.Text.Trim(),
                IconCss        = txtIconCss.Text.Trim(),
                FormName       = txtFormName.Text.Trim(),
                AssemblyName   = txtAssemblyName.Text.Trim(),
                ModuleType     = 3
            };
            if (rbModuleType1.Checked)
            {
                moduleEntity.ModuleType = 1;
            }

            if (rbModuleType2.Checked)
            {
                moduleEntity.ModuleType = 2;
            }

            if (rbModuleType3.Checked)
            {
                moduleEntity.ModuleType = 3;
            }

            if (string.IsNullOrEmpty(moduleEntity.NavigateUrl))
            {
                moduleEntity.NavigateUrl = @"#";
            }
            if (moduleEntity.ModuleType != null && moduleEntity.ModuleType == 2)
            {
                moduleEntity.IconCss = "icon-note";
            }

            moduleEntity.PermissionItemCode = "Resource.AccessPermission";
            moduleEntity.Enabled            = chkEnabled.Checked ? 1 : 0;
            moduleEntity.IsPublic           = chkIsPublic.Checked ? 1 : 0;
            moduleEntity.Expand             = chkExpand.Checked ? 1 : 0;
            moduleEntity.Description        = txtDescription.Text.Trim();            
            moduleEntity.AllowDelete        = chkAllowDelete.Checked ? 1 : 0;
            moduleEntity.AllowEdit          = chkAllowEdit.Checked ? 1 : 0;
            moduleEntity.IsMenu             = chkIsMenu.Checked ? 1 : 0;
            moduleEntity.DeleteMark         = 0;

            string statusCode    = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId        = moduleService.Add(UserInfo, moduleEntity, out statusCode, out statusMessage);
            this.FullName        = moduleEntity.FullName;
            this.ParentId        = BusinessLogic.ConvertToString(moduleEntity.ParentId);
            if (statusCode == StatusCode.OKAdd.ToString())
            {
                this.Changed = true;

                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    BasePageLogic.EmptyControlValue(gbMain);
                    this.chkEnabled.Checked     = true;
                    this.chkAllowEdit.Checked   = true;
                    this.chkAllowDelete.Checked = true;
                    txtFullName.Focus();
                }
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (this.Changed && close)
            {
                this.Close();
            }
        }
        #endregion

        #region private void SaveEditData() 保存修改的数据
        /// <summary>
        /// 保存修改的数据
        /// </summary>
        private void SaveEditData()
        {
            if (!BasePageLogic.ControlValueIsEmpty(gbMain))
            {
                return;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            currentModuleEntity.ParentId       = BusinessLogic.ConvertToString(txtParentId.SelectedValue);
            currentModuleEntity.FullName       = txtFullName.Text.Trim();
            currentModuleEntity.Code           = txtCode.Text.Trim();
            currentModuleEntity.Target         = txtTarget.Text.Trim();
            currentModuleEntity.NavigateUrl    = txtNavigateUrl.Text.Trim();
            currentModuleEntity.MvcNavigateUrl = txtMvcNavigateUrl.Text.Trim();
            currentModuleEntity.IconUrl        = txtIconUrl.Text.Trim();
            currentModuleEntity.IconCss        = txtIconCss.Text.Trim();
            currentModuleEntity.FormName       = txtFormName.Text.Trim();
            currentModuleEntity.AssemblyName   = txtAssemblyName.Text.Trim();
            if (rbModuleType1.Checked)
            {
                currentModuleEntity.ModuleType = 1;
            }

            if (rbModuleType2.Checked)
            {
                currentModuleEntity.ModuleType = 2;
            }

            if (rbModuleType3.Checked)
            {
                currentModuleEntity.ModuleType = 3;
            }
            currentModuleEntity.Enabled     = chkEnabled.Checked ? 1 : 0;
            currentModuleEntity.IsPublic    = chkIsPublic.Checked ? 1 : 0;
            currentModuleEntity.Expand      = chkExpand.Checked ? 1 : 0;
            currentModuleEntity.AllowDelete = chkAllowDelete.Checked ? 1 : 0;
            currentModuleEntity.AllowEdit   = chkAllowEdit.Checked ? 1 : 0;
            currentModuleEntity.IsMenu      = chkIsMenu.Checked ? 1 : 0;
            currentModuleEntity.Description = txtDescription.Text.Trim();
            if (!string.IsNullOrEmpty(SelectedFileId.Trim()))
            {
                currentModuleEntity.ImageIndex = SelectedFileId;
            }

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            this.EntityId = currentModuleEntity.Id.ToString();
            this.FullName = currentModuleEntity.FullName;
            this.ParentId = BusinessLogic.ConvertToString(currentModuleEntity.ParentId);
            moduleService.Update(UserInfo, currentModuleEntity, out statusCode, out statusMessage);

            if (statusCode == StatusCode.OKUpdate.ToString())
            {
                this.Changed = true;

                if (SystemInfo.ShowInformation)
                {
                    // 添加成功，进行提示
                    MessageBoxHelper.ShowSuccessMsg(statusMessage);
                }
                this.DialogResult = DialogResult.OK;                
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(statusMessage);
                // 是否编号重复了，提高友善性
                if (statusCode == StatusCode.ErrorCodeExist.ToString())
                {
                    this.txtCode.SelectAll();
                    this.txtCode.Focus();
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (this.Changed)
            {
                this.Close();
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.SaveAddData(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd)
            {
                this.SaveAddData(true);
            }
            else
            {
                this.SaveEditData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            var frmModuleSelect = new FrmModuleSelect();
            if (frmModuleSelect.ShowDialog() == DialogResult.OK)
            {
                this.txtParentId.SelectedValue = frmModuleSelect.SelectedId;
                this.txtParentId.Text = frmModuleSelect.SelectedFullName;                
            }
            this.SetControlState();
        }

        private void btnSetEmpty_Click(object sender, EventArgs e)
        {
            this.txtParentId.SelectedValue = null;
            this.txtParentId.Text = string.Empty;
        }

        private void btnSelectModulePic_Click(object sender, EventArgs e)
        {
            var frmPicture = new FrmPicture();
            var dtFolder = RDIFrameworkService.Instance.FolderService.GetDT(this.UserInfo, CiFolderTable.FieldFolderName, "ModuleIcon");
            if (dtFolder != null && dtFolder.Rows.Count > 0)
            {
                frmPicture.FolderId = dtFolder.Rows[0][CiFolderTable.FieldId].ToString();                
            }

            frmPicture.FolderName = "ModuleIcon";

            if (frmPicture.ShowDialog() == DialogResult.OK && frmPicture.SelectedBitMap != null)
            {
                pictureModulePic.Image = frmPicture.SelectedBitMap;
                SelectedFileId = frmPicture.SelectedFileId;
            }
        }

        private void btnEmptyModulePic_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Show(RDIFrameworkMessage.MSG0075) == DialogResult.No)
            {
                return;
            }

            this.pictureModulePic.Image = null;
            if (isAdd)
            {
                this.SelectedFileId = string.Empty;
                this.SaveAddData(true);
            }
            else
            {
                this.SelectedFileId = string.Empty;
                currentModuleEntity.ImageIndex = string.Empty;
                this.SaveEditData();
            }
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            this.SaveAddData(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region private void SetAccessPermission() 资源访问权限设置
        /// <summary>
        /// 资源访问权限设置
        /// </summary>
        private void SetAccessPermission()
        {
            string targetResourceCategory = PiModuleTable.TableName;
            string targetResourceId = this.currentModuleEntity.Id.ToString();
            string targetResourceName = this.currentModuleEntity.FullName;
            const string permissionItemCode = "Resource.AccessPermission";
            if (string.IsNullOrEmpty(targetResourceId)) return;
            const string assemblyName = "RDIFramework.WinModule";
            const string formName = "FrmResourcePermissionScope";
            Type assemblyType = CacheManager.Instance.GetType(assemblyName, formName);
            Form frmResourceSetPermission = (Form)Activator.CreateInstance(assemblyType, targetResourceCategory, targetResourceId, targetResourceName, permissionItemCode);
            frmResourceSetPermission.ShowDialog(this);
        }
        #endregion

        private void btnAccessPermission_Click(object sender, EventArgs e)
        {
            this.SetAccessPermission();
        }
    }
}
