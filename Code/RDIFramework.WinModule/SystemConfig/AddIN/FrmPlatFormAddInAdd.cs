/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-25 13:47:09
 ******************************************************************************/
using System;
using System.Reflection;
using System.IO;

namespace RDIFramework.WinModule
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    /// <summary>
    /// FrmPlatFormAddInAdd
    /// 增加平台插件
    /// 
    /// 修改纪录
    ///
    ///		2012-05-25 版本：1.0 XuWangBin 创建FrmPlatFormAddInAdd。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>XuWangBin</name>
    ///		<date>2012-05-25</date>
    /// </author>
    /// </summary>
    public partial class FrmPlatFormAddInAdd : BaseForm
    {
        public FrmPlatFormAddInAdd()
        {
            InitializeComponent();
        }

        public override bool SaveEntity()
        {
            PiPlatFormAddInEntity platFormAddInEntity = new PiPlatFormAddInEntity();
            platFormAddInEntity.Guid = txtGUID.Text.Trim();
            platFormAddInEntity.AssemblyName = txtAssemblyName.Text.Trim();
            platFormAddInEntity.Name = txtName.Text.Trim();
            platFormAddInEntity.Version = txtVersion.Text.Trim();
            platFormAddInEntity.Developer = txtDeveloper.Text.Trim();
            platFormAddInEntity.Description = txtDescription.Text.Trim();

            FileStream fs = new FileStream(txtAddInPath.Text.Trim(), FileMode.Open, FileAccess.Read);
            byte[] buffByte = new byte[fs.Length];
            fs.Read(buffByte, 0, (int)fs.Length);
            fs.Close();
            fs = null;

            platFormAddInEntity.AddIn = buffByte;
            platFormAddInEntity.AddInSize = FileHelper.GetFileSize(txtAddInPath.Text.Trim()) / 1024 ;//以字节为单位

            string statusMessage = string.Empty;
            string statusCode = string.Empty;

            try
            {
                RDIFrameworkService.Instance.PlatFormAddInService.Add(base.UserInfo, platFormAddInEntity, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OKAdd.ToString() || statusCode == StatusCode.OKUpdate.ToString())
                {
                    if (SystemInfo.ShowSuccessMsg)
                    {
                        MessageBoxHelper.ShowSuccessMsg(statusMessage);
                    }
                    return true;
                }
                else
                {
                    MessageBoxHelper.ShowWarningMsg(statusMessage);                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                base.ProcessException(ex);
                return false;
            } 
        }

        /// <summary>
        /// 是否是标准接口的程序
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private bool IsValidPlugin(Type t)
        {
            bool ret = false; 
            Type[] interfaces = t.GetInterfaces();
            foreach (Type theInterface in interfaces)
            {
                if ((theInterface.FullName == "RDIFramework.WinForm.Utilities.IBaseForm"))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }  

        private void btnSelectAddIn_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "选择插件文件";
            openFileDialog.Filter = "插件文件 (*.dll)|*.dll|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                try
                {
                    Assembly assembly = Assembly.LoadFile(fileName);
                    AssemblyName assemblyName = assembly.GetName();
                    Version version = assemblyName.Version;

                    //bool isValid = false;
                    //Type[] types = assembly.GetTypes();
                    //foreach (Type t in types)
                    //{
                    //    if (IsValidPlugin(t))
                    //    {
                    //        isValid = true;
                    txtAddInPath.Text = fileName;
                    txtName.Text = System.IO.Path.GetFileName(fileName); //文件名(带扩展名)
                    object[] objs = assembly.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                    if (objs.Length > 0)
                    {
                        txtGUID.Text = ((System.Runtime.InteropServices.GuidAttribute)objs[0]).Value.ToString(); //得到AssemblyInfo.cs中的GUID
                    }
                    else
                    {
                        txtGUID.Text = BusinessLogic.NewGuid();
                    }

                    txtAssemblyName.Text = assemblyName.Name;
                    txtVersion.Text = version.ToString();
                    //        break;
                    //    }
                    //}
                    //if (!isValid)
                    //{
                    //    MessageBoxHelper.ShowWarningMsg("非标准标准平台插件，请重新选择或改写文件！");
                    //}
                }
                catch (Exception ex)
                {
                    ProcessException(ex);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BasePageLogic.ControlValueIsEmpty(groupBox1))
            {
                if (this.SaveEntity())
                {
                    this.Changed = true;
                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;                                     
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.Changed)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
            }
            this.Close();
        }
    }
}
