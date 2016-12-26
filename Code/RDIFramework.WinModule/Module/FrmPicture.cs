/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-5-17 8:50:50
 ******************************************************************************/
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Controls;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmPicture
    /// 模块图标设置窗体
    /// 
    ///     2016-01-13 EricHu V3.0 修改模块中的图标选择界面增加分页的支持，这样当图标过多时就会以分页的方式显示提高加载速度，同时删除已经被模块使用的图标会提示。
    /// 
    /// 修改记录
    /// </summary>
    public partial class FrmPicture : BaseForm
    {
        DataTable dtPicture = new DataTable(CiFileTable.TableName);

        #region 属性定义区域
        private string folderId = string.Empty;
        public string FolderId
        {
            get { return folderId; }
            set { folderId = value; }
        }

        private string folderName = "ModuleIcon";//文件夹名称，默认为：模块图标
        /// <summary>
        /// 文件夹名称【默认为：ModuleIcon】
        /// </summary>
        public string FolderName
        {
            get { return folderName; }
            set { folderName = value; }
            
        }

        private string selectedFileId = string.Empty;
        /// <summary>
        /// 当前选择的文件Id
        /// </summary>
        public string SelectedFileId
        {
            get { return selectedFileId; }
            set { selectedFileId = value; }
        }

        private Bitmap selectedBitMap = null;
        /// <summary>
        /// 当前选择的图标文件
        /// </summary>
        public Bitmap SelectedBitMap
        {
            get { return selectedBitMap;  }
            set { selectedBitMap = value; }
        }
        #endregion

        public FrmPicture()
        {
            InitializeComponent();
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            ucImageList.ImgHeight = 64;
            ucImageList.ImgWidth  = 64;
            this.GetList();
        }
        #endregion

        public override void GetList()
        {
            var dtFolder = RDIFrameworkService.Instance.FolderService.GetDT(this.UserInfo, CiFolderTable.FieldFolderName, this.FolderName);
            if (dtFolder != null && dtFolder.Rows.Count > 0)
            {
                // this.dtPicture = FileService.GetDTByFolder(this.UserInfo, dtFolder.Rows[0][CiFolderTable.FieldId].ToString());
                var recordCount = 0;
                string whereCondition = CiFileTable.FieldFolderId + " = '" + dtFolder.Rows[0][CiFolderTable.FieldId].ToString() + "'";
                this.dtPicture = RDIFrameworkService.Instance.FileService.GetFileDTByPage(UserInfo, out recordCount, ucPager.PageIndex, ucPager.PageSize, whereCondition, CiFileTable.FieldSortCode + " desc ");
                ucPager.RecordCount = recordCount;
                ucPager.InitPageInfo();
                foreach (DataRow dataRow in this.dtPicture.Rows)
                {
                    var pictureItem = new Controls.PictureItem
                    {
                        tag = dataRow[CiFileTable.FieldId],
                        Pic = new Bitmap(BusinessLogic.byteArrayToImage(RDIFrameworkService.Instance.FileService.Download(this.UserInfo, dataRow[CiFileTable.FieldId].ToString()))),
                        Text = dataRow[CiFileTable.FieldFileName].ToString(),
                        strMsg1 = "NONE",
                        strMsg2 = "NONE"
                    };
                    ucImageList.AddPictureItem(pictureItem);
                }
                ucImageList.Draw();
            }
            else
            {
                var folderEntity = new CiFolderEntity { FolderName = this.FolderName, Enabled = 1, DeleteMark = 0 };
                string statusCode;
                string statusMessage;
                RDIFrameworkService.Instance.FolderService.Add(this.UserInfo, folderEntity, out statusCode, out statusMessage);
            }   
        }

        private void ucPager_PageChanged(object sender, EventArgs e)
        {
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            ucImageList.RemoveAllPictureItem();
            GetList();
            this.Cursor = holdCursor;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var picItem = new PictureItem();
            picItem = ucImageList.GetCurrentPictureItem();
            if (!picItem.Pic.Equals(null))
            {
                ucImageView.AddImage(picItem.Pic);
                this.SelectedBitMap = picItem.Pic;
                this.SelectedFileId = ((PictureItem)ucImageList.data[ucImageList.CurrentImg]).tag.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg("没有选择任何图标文件！");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = @"Image Files(*.jpg;*.jpeg;*.icon;*.ico;*.gif;*.png)|*.jpg;*.gpeg;*.icon;*.ico;*.gif;*.png";
            openFileDialog.Title = @"请选择32x32大小的图像文件";
            var iSuccess = 0;
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            foreach (var selectedName in openFileDialog.FileNames)
            {
                string fileName = FileHelper.GetName(selectedName);
                var fs = new FileStream(selectedName, FileMode.Open, FileAccess.Read);
                var buffByte = new byte[fs.Length];
                fs.Read(buffByte, 0, (int)fs.Length);
                fs.Close();
                fs = null;                   
                var statusCode = string.Empty;
                var statusMessage = string.Empty;
                RDIFrameworkService.Instance.FileService.Add(this.UserInfo, this.FolderId, fileName, buffByte, string.Empty, this.FolderName, true, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OKAdd.ToString())
                {
                    iSuccess++;
                    //将图像读入到字节数组
                    var pictureItem = new PictureItem {Pic = new Bitmap(selectedName), Text = fileName};
                    ucImageList.AddPictureItem(pictureItem);
                    ucImageList.Draw();
                    this.Changed = true;                       
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);
                }
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;

            if (SystemInfo.ShowInformation)
            {
                MessageBoxHelper.ShowSuccessMsg("成功增加" + iSuccess.ToString(CultureInfo.InvariantCulture) +"条图标文件。");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = PiModuleTable.FieldImageIndex + " = '" + ((PictureItem)ucImageList.data[ucImageList.CurrentImg]).tag.ToString() + "'";
                bool isReturn = false;
                DataTable dtUseModule = RDIFrameworkService.Instance.ModuleService.GetDTByCondition(this.UserInfo,condition);
                if (dtUseModule.Rows.Count > 0)
                {
                    string moduleFullName = BaseEntity.Create<PiModuleEntity>(dtUseModule).FullName ?? "";
                    if (MessageBoxHelper.Show("待删除的图标正在被模块\"" + moduleFullName + "\"使用，确认删除？") == DialogResult.No)
                    {
                        return;
                    }
                    isReturn = true;
                }

                if (!isReturn && MessageBoxHelper.Show(RDIFrameworkMessage.MSG0015) == DialogResult.No)
                {
                    return;
                }

                if (RDIFrameworkService.Instance.FileService.Delete(this.UserInfo, ((PictureItem)ucImageList.data[ucImageList.CurrentImg]).tag.ToString()) > 0)
                {
                    MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0013);
                    ucImageList.RemovePictureItem(ucImageList.CurrentImg);
                    ucImageList.Draw();
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSG3020);
                }
            }
            catch (Exception ex)
            {
                ProcessException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucImageList_MouseDoubleClick(object sender, EventArgs e)
        {
            if (ucImageList.CurrentImg < 0) return;
            var picItem = new PictureItem();
            picItem = ucImageList.GetCurrentPictureItem();
            if (!picItem.Pic.Equals(null))
            {
                ucImageView.AddImage(picItem.Pic);
                this.SelectedBitMap = picItem.Pic;
                this.SelectedFileId = ((PictureItem)ucImageList.data[ucImageList.CurrentImg]).tag.ToString();
            }
            else
            {
                MessageBoxHelper.ShowWarningMsg(RDIFrameworkMessage.MSGC023);
            }
        }
    }
}
