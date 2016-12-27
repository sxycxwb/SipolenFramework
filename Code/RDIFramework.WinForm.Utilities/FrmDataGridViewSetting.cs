/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-21 16:44:03
 ******************************************************************************/
using System;
using System.Data;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmDataGridViewSetting
    ///  DataGridView设置页面
    ///  
    /// </summary>
    public partial class FrmDataGridViewSetting : BaseForm
    {
        #region 公共属性

        //所属窗体
        private Form targetForm = null;
        public Form TargetForm
        {
            get { return targetForm; }
            set { targetForm = value; }
        }

        //所属DataGridView
        private DataGridView targetDataGridView = null;
        public DataGridView TargetDataGridView
        {
            get { return targetDataGridView; }
            set { targetDataGridView = value; }
        }
        #endregion

        public FrmDataGridViewSetting()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(dgvSetting);
            string targetFileFullName = SystemInfo.StartupPath + "\\UserParameter\\" + TargetForm.Name + "_" + targetDataGridView.Name + ".xml";
            DataSet dsDataGridViewColumns = new DataSet();
            dsDataGridViewColumns.ReadXml(targetFileFullName);
            dgvSetting.DataSource = dsDataGridViewColumns.Tables[0];
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Save();
            BasePageLogic.LoadDataGridViewColumnWidth(TargetForm);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 私有方法
        //保存
        private void Save()
        {
            dgvSetting.EndEdit();
            string targetFilePath = SystemInfo.StartupPath + "\\UserParameter\\";
            if (!System.IO.Directory.Exists(targetFilePath))
            {
                System.IO.Directory.CreateDirectory(targetFilePath);
            }

            string targetFileFullName = targetFilePath + TargetForm.Name + "_" + TargetDataGridView.Name + ".xml";

            DataSet dsDataGridViewColumns = new DataSet(targetDataGridView.Name);
            dsDataGridViewColumns.Tables.Add(targetDataGridView.Name);
            dsDataGridViewColumns.Tables[0].Columns.Add("ColumnName", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("HeaderText", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("Frozen", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("Visible", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("DisplayIndex", typeof(int));
            dsDataGridViewColumns.Tables[0].Columns.Add("Width", typeof(int));
            foreach (DataGridViewRow item in dgvSetting.Rows)
            {
                try
                {
                    dsDataGridViewColumns.Tables[0].Rows.Add(item.Cells["ColumnName"].Value.ToString(), item.Cells["HeaderText"].Value, item.Cells["Frozen"].Value, item.Cells["Visible"].Value, item.Index, item.Cells["Width"].Value);
                }
                catch (Exception ee)
                {
                    ProcessException(ee);
                    return;
                }
            }
            //因为一列为冻结列前面的所有也得为冻结列
            for (int i = 0; i < dsDataGridViewColumns.Tables[0].Rows.Count - 1; i++)
            {
                if (dsDataGridViewColumns.Tables[0].Rows[i]["Frozen"].ToString() == "True")
                {
                    for (int j = 0; j < i; j++)
                    {
                        dsDataGridViewColumns.Tables[0].Rows[j]["Frozen"] = true;
                    }
                }
            }

            if (!System.IO.File.Exists(targetFileFullName))
            {
                System.IO.File.Create(targetFileFullName).Close();
            }

            dsDataGridViewColumns.WriteXml(targetFileFullName);

            this.DialogResult = DialogResult.OK;
        }        
        #endregion
    }
}
