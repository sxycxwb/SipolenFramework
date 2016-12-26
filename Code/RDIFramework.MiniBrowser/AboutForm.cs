using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace MiniBrowser
{
    partial class AboutForm : RDIFramework.WinForm.Utilities.BaseForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void licenseButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.cnblogs.com/huyong/");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void theWheelLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cnblogs.com/huyong/");
        }
    }
}