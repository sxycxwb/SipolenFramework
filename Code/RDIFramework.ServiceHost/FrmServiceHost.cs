using System.Windows.Forms;

namespace RDIFramework.ServiceHost
{
    public partial class FrmServiceHost : Form
    {
        public FrmServiceHost()
        {
            InitializeComponent();
        }

        private void FrmServiceHost_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(RDIFramework.Utilities.SystemInfo.SoftFullName))
            {
                lblSoftFullName.Text = RDIFramework.Utilities.SystemInfo.SoftFullName;
                this.Text = string.IsNullOrEmpty(RDIFramework.Utilities.SystemInfo.SoftName) ? this.Text : RDIFramework.Utilities.SystemInfo.SoftName + " WCF Server...";
            }
        }
    }
}
