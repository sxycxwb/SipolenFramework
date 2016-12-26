using System;

namespace RDIFramework.WorkFlow
{
    public partial class FrmAddCommands : BaseForm_Single
    {
        private string fmState="";
        public string CommandId = "";

        public FrmAddCommands(string state)
        {
            InitializeComponent();
            fmState = state;
        }

        private void FrmAddCommands_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

