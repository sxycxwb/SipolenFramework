/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-6 12:55:06
 ******************************************************************************/
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace RDIFramework.WinForm.Utilities
{
    using RDIFramework.Utilities;

    /// <summary>
    /// FrmAbout
    /// 关于本软件
    /// 
    /// 修改记录
    ///     2012-06-06 EricHu 创建：FrmAbout
    /// </summary>
    public partial class FrmAbout : BaseForm
    {
        AssemblyInformation currentAssemblyInfo = null;
        string currentAuthor = string.Empty;
        string currentUrlAddress = string.Empty;

        public FrmAbout()
        {
            InitializeComponent();
        }

        public FrmAbout(AssemblyInformation assemblyInfo, string author, string urlAddress)
        {
            InitializeComponent();
            currentAssemblyInfo = assemblyInfo;
            currentAuthor = author;
            currentUrlAddress = urlAddress;
        }

        public override void FormOnLoad()
        {
            this.Text = "关于" + SystemInfo.SoftFullName;
            this.lblSoftFullName.Text = SystemInfo.SoftFullName;
            this.lblCustomerCompanyName.Text = SystemInfo.CustomerCompanyName + " 版权所有";
            this.lblCopyRight.Text = "Copyright (C) " + DateTime.Now.Year.ToString() +  ". All Rights Reserved.";
            if (!string.IsNullOrEmpty(SystemInfo.RDIFrameworkBlog))
            {
                this.linkLabel1.Text = SystemInfo.RDIFrameworkBlog;
            }
            GetCopyRight();
        }


        private void GetCopyRight()
        {
            var computerName = Environment.MachineName;
            if (Environment.UserDomainName != computerName)
            {
                computerName = Environment.UserDomainName + "\\" + computerName;
            }            

            txtCopyRight.AppendText("程序名称：" + currentAssemblyInfo.Title + " - " + currentAssemblyInfo.Name + "\n");
            txtCopyRight.AppendText("程序版本：" + string.Format("{0} (Build: {1:yyyy-MM-dd hh:mm:ss})", currentAssemblyInfo.Version, currentAssemblyInfo.BuildTime) + "\n");
            txtCopyRight.AppendText("程序标识：" + currentAssemblyInfo.Guid.ToString() + "\n");
            txtCopyRight.AppendText("程序说明：" + currentAssemblyInfo.Description + "\n");
            txtCopyRight.AppendText("作者: " + currentAuthor + " ( " + currentAssemblyInfo.Company + ")" + "\n");
            txtCopyRight.AppendText("主页：" + currentUrlAddress + "\n");
            txtCopyRight.AppendText("计算机用户：" + Environment.UserName + " @ " + computerName + "\n");
            txtCopyRight.AppendText("操作系统: " + Environment.OSVersion.ToString() + "\n");
            txtCopyRight.AppendText("程序文件名称：" + currentAssemblyInfo.ExecuteFileFullName + "\n");
            txtCopyRight.AppendText("程序内存使用：" + Environment.WorkingSet.ToString("N0") + " bytes");         
        }

        private void btnCofirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklblcnblogs_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linklblcnblogs.Text);  
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);  
        }

        private void picQQ_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wpa.qq.com/msgrd?v=3&uin=406590790&site=qq&menu=yes");
        }
    }

    /// <summary>
    /// 用于获取程序集信息的东东
    /// </summary>
    public sealed class AssemblyInformation
    {
        Assembly assembly;

        public Version Version { get { return assembly.GetName().Version; } }
        public string Name { get { return assembly.GetName().Name; } }
        public string ExecuteFileFullName { get { return assembly.Location; } }
        public string ExecuteFileDirectory { get { return Path.GetDirectoryName(ExecuteFileFullName); } }
        public DateTime BuildTime { get { return GetPe32Time(ExecuteFileFullName); } }

        public AssemblyInformation(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public string Title
        {
            get
            {
                var attrs = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attrs.Length > 0)
                {
                    var attr = (AssemblyTitleAttribute)attrs[0];
                    if (attr.Title != "") return attr.Title;
                }
                return Name;
            }
        }

        public Guid Guid
        {
            get
            {
                var attrs = assembly.GetCustomAttributes(typeof(GuidAttribute), false);
                return (attrs.Length == 0) ? Guid.Empty : new Guid(((GuidAttribute)attrs[0]).Value);
            }
        }

        public string Company
        {
            get
            {
                var attrs = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return (attrs.Length == 0) ? "" : ((AssemblyCompanyAttribute)attrs[0]).Company;
            }
        }

        public string Description
        {
            get
            {
                var attrs = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return (attrs.Length == 0) ? "" : ((AssemblyDescriptionAttribute)attrs[0]).Description;
            }
        }

        private string GetComputerName()
        {
            var name = Environment.MachineName;
            if (Environment.UserDomainName != name) name = Environment.UserDomainName + "\\" + name;
            return name;
        }

        private DateTime GetPe32Time(string fileName)
        {
            int seconds;
            using (var br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
            {
                var bs = br.ReadBytes(2);
                var msg = "非法的PE32文件";
                if (bs.Length != 2) throw new Exception(msg);
                if (bs[0] != 'M' || bs[1] != 'Z') throw new Exception(msg);
                br.BaseStream.Seek(0x3c, SeekOrigin.Begin);
                var offset = br.ReadByte();
                br.BaseStream.Seek(offset, SeekOrigin.Begin);
                bs = br.ReadBytes(4);
                if (bs.Length != 4) throw new Exception(msg);
                if (bs[0] != 'P' || bs[1] != 'E' || bs[2] != 0 || bs[3] != 0) throw new Exception(msg);
                bs = br.ReadBytes(4);
                if (bs.Length != 4) throw new Exception(msg);
                seconds = br.ReadInt32();
            }
            return DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc).
              AddSeconds(seconds).ToLocalTime();
        }
    }
}
