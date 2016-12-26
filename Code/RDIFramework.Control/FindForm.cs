using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    public partial class FindForm : Form
    {
        int lastFound = 0;
        RichTextBox rtbInstance = null;
        public RichTextBox RtbInstance
        {
            set { rtbInstance = value; }
            get { return rtbInstance; }
        }

        public string InitialText
        {
            set { txtSearchText.Text = value; }
            get { return txtSearchText.Text; }
        }

        public FindForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        void rtbInstance_SelectionChanged(object sender, EventArgs e)
        {
            lastFound = rtbInstance.SelectionStart;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.rtbInstance.SelectionChanged -= rtbInstance_SelectionChanged;
            this.Close();
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            RichTextBoxFinds options = RichTextBoxFinds.None;
            if (chkMatchCase.Checked) options |= RichTextBoxFinds.MatchCase;
            if (chkWholeWord.Checked) options |= RichTextBoxFinds.WholeWord;

            int index = rtbInstance.Find(txtSearchText.Text, lastFound, options);
            lastFound += txtSearchText.Text.Length;
            if (index >= 0)
            {
                rtbInstance.Parent.Focus();
            }
            else
            {
                MessageBox.Show("Search string not found", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lastFound = 0;
            }

        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            if (rtbInstance != null)
                this.rtbInstance.SelectionChanged += new EventHandler(rtbInstance_SelectionChanged);
        }
    }
}
