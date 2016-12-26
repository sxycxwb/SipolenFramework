using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RDIFramework.CodeMaker
{
    public partial class FrmTestForm : Form
    {
        public Mutex mutex;
        public FrmTestForm()
        {
            InitializeComponent();
            //mutex = new Mutex(false, "SINGLE_RDIFramework_CodeGenerator1");
            //if (!mutex.WaitOne(0, false))
            //{
            //    mutex.Close();
            //    mutex = null;
            //}
        }

        private void textEditorControlWrapper1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled)
            { }
        }

        private void textEditorControlWrapper1_KeyPressEvent(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.B)
            { }
        }
    }
}
