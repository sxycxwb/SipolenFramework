using System;
using System.Windows.Forms;

namespace RDIFramework.WinForm.Utilities
{
    public partial class SplashFormEx : Form
    {
        public SplashFormEx()
        {
            InitializeComponent();
        }

        public string StatusInfo
        {
            set
            {
                _StatusInfo = value;
                ChangeStatusText();
            }
            get
            {
                return _StatusInfo;
            }
        }

        public void ChangeStatusText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.ChangeStatusText));
                    return;
                }

                lStatusInfo.Text = _StatusInfo;
            }
            catch (Exception e)
            {
                //	do something here...
            }
        }
        private string _StatusInfo = "";
    }
}
