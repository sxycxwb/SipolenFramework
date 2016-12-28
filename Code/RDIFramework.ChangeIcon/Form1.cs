using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.ChangeIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;

            var dir = Directory.GetParent(rootPath).Parent.Parent.Parent;
            rootPath = dir.FullName;
            var iconContent = XMLHelper.GetXmlNodeByXpath("icon.xml", "/root/data[@name='$this.Icon']/value").InnerText;//获取左上角小图标base64内容
            DirectoryInfo theFolder = new DirectoryInfo(rootPath);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();

            //遍历文件夹
            foreach (DirectoryInfo nextFolder in dirInfo)
            {
                FileInfo[] fileInfo = nextFolder.GetFiles();
                foreach (FileInfo nextFile in fileInfo) //遍历文件
                {
                    if (nextFile.Extension == ".resx")//判断是资源文件的才处理
                    {
                        //设置小图标内容
                        XMLHelper.CreateOrUpdateXmlNodeByXPath(nextFile.FullName, "/root/data[@name='$this.Icon']", "value", iconContent);
                    }
                }
            }
        }
    }
}
