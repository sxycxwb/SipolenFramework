using System;
using System.Windows.Forms;
using System.Globalization;

namespace MiniBrowser
{
    partial class ScriptErrorWindow : RDIFramework.WinForm.Utilities.BaseForm
    {
        public ScriptErrorWindow()
        {
            InitializeComponent();
            ScriptErrorManager.Instance.ScriptErrors.CollectionChanged += new EventHandler(ScriptErrors_CollectionChanged);
        }

        void ScriptErrors_CollectionChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (ScriptError item in ScriptErrorManager.Instance.ScriptErrors)
            {
                ListViewItem lvi = new ListViewItem(item.Description);
                lvi.SubItems.Add(item.LineNumber.ToString(CultureInfo.CurrentCulture));
                lvi.SubItems.Add(item.Url.ToString());
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void ScriptErrorWindow_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void clearListToolStripButton_Click(object sender, EventArgs e)
        {
            ScriptErrorManager.Instance.ScriptErrors.Clear();
        }

    }
}