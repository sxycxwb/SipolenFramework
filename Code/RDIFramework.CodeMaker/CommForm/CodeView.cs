using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    public partial class CodeView : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code">代码内容</param>
        /// <param name="codeType">Code类型</param>
        public CodeView(string code, string codeType = "CS")
        {
            InitializeComponent();
            codeContent.SetCodeEditorContent(codeType, code);
        }

        /// <summary>
        /// 要保存的文件名称
        /// </summary>
        public string FileName
        {
            get { return codeContent.SaveFileName; }
            set { codeContent.SaveFileName = value; }
        }
    }
}
