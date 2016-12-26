/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-7-6 10:48:47
 ******************************************************************************/
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.Utilities;

    public partial class BaseEditForm : BaseForm
    {
        public event EventHandler OnDataSaved; //数据编辑窗体数据保存时触发

        public List<string> idList = new List<string>();//所有待展示的ID列表        
        public List<string> IDList
        {
            get
            {
                return idList;
            }
            set
            {
                idList = value;
                dataNavigator.IDList = idList;
            }
        }

        /// <summary>
        /// 设置添加按钮的可见性
        /// </summary>
        public bool SetAddButtonVisible
        {
            set
            {
                this.btnAdd.Visible = value;
            }
        }

        /// <summary>
        /// 设置保存按钮的可见性
        /// </summary>
        public bool SetSaveButtonVisible
        {
            set
            {
                this.btnSave.Visible = value;
            }
        }

        public BaseEditForm()
        {
            InitializeComponent();
            this.dataNavigator.PositionChanged += new UcDataNavigator.PostionChangedEventHandler(dataNavigator_PositionChanged);
        }

        public virtual void DisplayData()
        {

        }

        /// <summary>
        /// 事件触发（处理数据保存的）
        /// </summary>
        public virtual void ProcessDataSaved(object sender, EventArgs e)
        {
            if (OnDataSaved != null)
            {
                OnDataSaved(sender, e);
            }
        }

        private void BaseEditForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (idList != null && dataNavigator != null)
                {
                    dataNavigator.CurrentIndex = idList.IndexOf(this.EntityId);
                }
            }
            catch
            { }
        }

        private void dataNavigator_PositionChanged(object sender, EventArgs e)
        {           
            this.EntityId = IDList[this.dataNavigator.CurrentIndex];           
            DisplayData();
        }    

        /// <summary>
        /// 保存数据（新增和编辑的保存）
        /// </summary>
        public virtual bool SaveEntity()
        {
            bool result = false;
            if (!string.IsNullOrEmpty(this.EntityId))
            {
                //编辑的保存
                result = SaveUpdated();
            }
            else
            {
                //新增的保存
                result = SaveAddNew();
            }

            return result;
        }

        /// <summary>
        /// 更新已有的数据
        /// </summary>
        /// <returns></returns>
        public virtual bool SaveUpdated()
        {
            return true;
        }

        /// <summary>
        /// 保存新增的数据
        /// </summary>
        /// <returns></returns>
        public virtual bool SaveAddNew()
        {
            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="close">关闭窗体</param>
        private void SaveEntity(bool close)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 设置鼠标繁忙状态
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if (this.SaveEntity())
                    {
                        ProcessDataSaved(this.btnSave, new EventArgs());
                        MessageBoxHelper.ShowSuccessMsg(RDIFrameworkMessage.MSG0011);
                        if (close)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            //说明是新增数据，清空界面。
                            if (this.EntityId == "")
                            {
                                ClearScreen();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveEntity(false);            
        }

        public virtual void ClearScreen()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEntity(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
