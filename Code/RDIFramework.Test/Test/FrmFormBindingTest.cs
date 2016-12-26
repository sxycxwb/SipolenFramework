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
    using RDIFramework.Utilities;
    using RDIFramework.WinForm.Utilities;

    public partial class FrmFormBindingTest : BaseForm
    {
        ExampleEntity TestEntity = new ExampleEntity();

        public FrmFormBindingTest()
        {
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            base.FormOnLoad();
            BindCategory();
            FormBinding.BindObjectToControls(TestEntity, this);
        }

        private void BindCategory()
        {
            BasePageLogic.BindCategory(base.UserInfo, ProductCategory, "ProductCategory");
            BasePageLogic.BindCategory(base.UserInfo, comboBox1, "Gender");
        }

        private void btnEntityToControl_Click(object sender, EventArgs e)
        {
            FormBinding.BindObjectToControls(TestEntity, this);
        }

        private void btnControlToEntity_Click(object sender, EventArgs e)
        {
            FormBinding.BindControlsToObject(TestEntity, this);
            this.richTextBox1.Text = TestEntity.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ExampleEntity
    {
        public string Text1 { get; set; }

        public string Text2 { get; set; }

        public string comboBox1 { get; set; }

        public string ProductCategory { get; set; }

        public DateTime? DateTime1 { get; set; }

        public decimal? MaskText1 { get; set; }

        public int? Int1 { get; set; }

        public int Enabled1 { get; set; }

        public ExampleEntity() {
            Text1 = "ValueText1";
            Text2 = "ValueText2";
            DateTime1 = BusinessLogic.ConvertToDateTime(DateTime.Now.AddDays(-2));
            MaskText1 = BusinessLogic.ConvertToNullableDecimal(12345.12);
            Int1 = 124;
            Enabled1 = 1;
            comboBox1 = "男";
            ProductCategory = "其他";
        }

        public override string ToString()
        {
            string returnValue = "Text1: " + Text1 + "\r Text2: " + Text2;
            returnValue += "\r comboBox1:" + comboBox1 + "\r Int1:" + Int1.ToString() + "\r DateTime1:" + DateTime1.ToString() ;
            returnValue += "\r ProductCategory:" + ProductCategory + "\r MaskText1:" + MaskText1.ToString() + "\r Enabled1:" + Enabled1.ToString();
            return returnValue.ToString();
        }
    }
}
