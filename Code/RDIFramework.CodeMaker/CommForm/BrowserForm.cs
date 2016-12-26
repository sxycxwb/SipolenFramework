using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    public partial class BrowserForm : Form
    {
        public BrowserForm(string htmlBody)
        {
            InitializeComponent();

            this.webBrowser.DocumentText = htmlBody;
        }
    }
}
