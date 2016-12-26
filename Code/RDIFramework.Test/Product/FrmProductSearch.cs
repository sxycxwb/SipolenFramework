using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Test
{
    using RDIFramework.BizLogic;
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmProductSearch : BaseForm
    {
        private string searchExpress = string.Empty;
        /// <summary>
        /// 搜寻值
        /// </summary>
        public string SearchExpress
        {
            get { return searchExpress; }
            set { searchExpress = value; }
        }

        public FrmProductSearch()
        {
            InitializeComponent();
        }
    }
}
