using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    public partial class CodeEditor : Form
    {
        public CodeEditor()
        {
            InitializeComponent();
        }

        public CodeEditor(string tempFile, string fileType)
        {
            InitializeComponent();          
            using (var srFile = new StreamReader(tempFile, Encoding.Default))
            {
                var Contents = srFile.ReadToEnd();
                srFile.Close();
                this.txtContent.Text = Contents;
            }
        }

        public CodeEditor(string strCode, string fileType,string temp)
        {
            InitializeComponent();            
            this.txtContent.Text = strCode;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSaveCode = null;
            try
            {
                dlgSaveCode = new SaveFileDialog
                {
                    Title = "���浱ǰ����",
                    Filter = "C# �ļ�(*.cs)|*.cs|�ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*"
                };
                if (dlgSaveCode.ShowDialog() != DialogResult.OK) return;
                var filename = dlgSaveCode.FileName;
                using (var sw = new StreamWriter(filename, false, Encoding.Default))
                {
                    sw.Write(txtContent.Text);
                    sw.Flush();//�ӻ�����д����������ļ���
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            finally
            {
                dlgSaveCode.Dispose();
            }           
        } 
    }
}