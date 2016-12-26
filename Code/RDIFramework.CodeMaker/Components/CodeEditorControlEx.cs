using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace RDIFramework.CodeMaker
{
    public partial class CodeEditorControlEx : UserControl
    {
        private string Type = "CS";     

        public CodeEditorControlEx()
        {
            InitializeComponent();
            this.textEditorContent.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
            this.SetCodeEditorContent("CS", "");
        }


        private void Document_DocumentChanged(object sender, DocumentEventArgs e)
        {
            this.textEditorContent.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
            this.textEditorContent.Document.FoldingManager.UpdateFoldings(null, null);
        }

        private string GetTypeName(string Type)
        {
            //string[] modes = new string[] { "ASP3/XHTML", "BAT", "Boo", "Coco", "C++.NET", "C#", "HTML", "Java", "JavaScript", "PHP", "TeX", "VBNET", "XML", "TSQL" };
            string ReturnValue = String.Empty;
            switch (Type)
            {
                case "SQL":
                    ReturnValue = "TSQL";
                    break;
                case "CS":
                    ReturnValue = "C#";
                    break;
                case "Aspx":
                    ReturnValue = "HTML";
                    break;
                case "HTML":
                    ReturnValue = "HTML";
                    break;
                case "XML":
                    ReturnValue = "XML";
                    break;
                case "JavaScript":
                    ReturnValue = "JavaScript";
                    break;
                default:
                    ReturnValue = "C#";
                    break;
            }
            return ReturnValue;
        }

        public void SetCodeEditorContent(string Type, string strContent)
        {
            this.Type = Type;
            this.textEditorContent.Encoding = System.Text.Encoding.Default;
            this.textEditorContent.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(GetTypeName(Type));
            this.textEditorContent.ShowEOLMarkers = false;
            this.textEditorContent.ShowSpaces = false;
            this.textEditorContent.ShowTabs = false;
            this.textEditorContent.ShowInvalidLines = false;
            this.textEditorContent.LineViewerStyle = LineViewerStyle.FullRow;
            this.textEditorContent.Text = strContent;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {           
            try
            {               
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Title = "保存当前代码";
                    string text = "";
                    if (this.Type == "CS")
                    {
                        dialog.Filter = "C# files (*.cs)|*.cs|All files (*.*)|*.*";
                        text = this.textEditorContent.Text;
                    }
                    if (this.Type == "SQL")
                    {
                        dialog.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                        text = this.textEditorContent.Text;
                    }
                    if (this.Type == "Aspx")
                    {
                        dialog.Filter = "Aspx files (*.aspx)|*.aspx|All files (*.*)|*.*";
                        text = this.textEditorContent.Text;
                    }
                    if (this.Type == "XML")
                    {
                        dialog.Filter = "Aspx files (*.xml)|*.xml|All files (*.*)|*.*";
                        text = this.textEditorContent.Text;
                    }
                    if (this.Type == "HTML")
                    {
                        dialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
                        text = this.textEditorContent.Text;
                    }

                    if (this.Type == "JavaScript")
                    {
                        dialog.Filter = "JavaScritp files (*.js)|*.js|All files (*.*)|*.*";
                        text = this.textEditorContent.Text;
                    }

                    if (!string.IsNullOrEmpty(this.SaveFileName))
                    {
                        dialog.FileName = this.SaveFileName;
                    }

                    dialog.ShowDialog();
                    if (!string.IsNullOrEmpty(dialog.FileName))
                    {
                        using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.Default))
                        {
                            writer.Write(text);
                            writer.Flush();
                            writer.Close();
                        }
                    }          
                }
            }
            catch (System.AccessViolationException accEx)
            {
                LogHelper.WriteException(accEx);
            }
            catch (System.StackOverflowException flowEx)
            {
                LogHelper.WriteException(flowEx);
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        private string _PropertySavePath = "XmlEditor.TextEditorControl.{0}";
        private string SharpPadFileFilter = "程序文件(*.cs)|*.cs|页面文件(*.aspx)|*.aspx|cshtml文件(*.cshtml)|*.cshtml|Xml Files (*.xml)|*.xml|All Files (*.*)|*.*";
        private string saveFileName = string.Empty;
        /// <summary>
        /// 保存文件的名称
        /// </summary>
        [Category("用户自定义属性"), Description("保存文件的名称。"), Browsable(false)]
        public string SaveFileName
        {
            get { return this.saveFileName; }
            set { this.saveFileName = value; }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = SharpPadFileFilter;
                    dialog.FilterIndex = 0;
                    dialog.ShowDialog();
                    if (!string.IsNullOrEmpty(dialog.FileName))
                    {
                        using (StreamReader reader = new StreamReader(dialog.FileName, Encoding.Default))
                        {
                            this.textEditorContent.Text = reader.ReadToEnd();
                        }
                    }
                    //if (DialogResult.OK == dialog.ShowDialog())
                    //{
                    //    StreamReader reader = new StreamReader(dialog.FileName, Encoding.Default);
                    //    this.textEditorContent.Text= reader.ReadToEnd();                    
                    //}
                }
            }
            catch (System.AccessViolationException accEx)
            {
                LogHelper.WriteException(accEx);
            }
            catch (System.StackOverflowException flowEx)
            {
                LogHelper.WriteException(flowEx);
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        private void 拆分窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textEditorContent.Split();
        }

        private void 显示空格和制表符SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.显示空格和制表符SToolStripMenuItem.Checked = this.textEditorContent.ShowTabs; 
            this.textEditorContent.ShowSpaces = this.textEditorContent.ShowTabs = !this.textEditorContent.ShowSpaces;
        }

        private void 显示换行标志EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.显示换行标志EToolStripMenuItem.Checked = this.textEditorContent.ShowEOLMarkers; 
            this.textEditorContent.ShowEOLMarkers = !this.textEditorContent.ShowEOLMarkers;
        }

        private void 显示无效标记IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.显示无效标记IToolStripMenuItem.Checked = this.textEditorContent.ShowInvalidLines; 
            this.textEditorContent.ShowInvalidLines = !this.textEditorContent.ShowInvalidLines;
        }

        private void 显示行号LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.显示行号LToolStripMenuItem.Checked = this.textEditorContent.ShowLineNumbers; 
            this.textEditorContent.ShowLineNumbers = !this.textEditorContent.ShowLineNumbers;
        }

        private void 高亮当前行HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textEditorContent.LineViewerStyle = this.textEditorContent.LineViewerStyle == LineViewerStyle.None ? LineViewerStyle.FullRow : LineViewerStyle.None;
        }

        private void 高亮匹配括号当光标在其后时AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textEditorContent.BracketMatchingStyle = this.textEditorContent.BracketMatchingStyle == BracketMatchingStyle.After ? BracketMatchingStyle.Before : BracketMatchingStyle.After;
        }

        private void 启用虚空格VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.启用虚空格VToolStripMenuItem.Checked = this.textEditorContent.AllowCaretBeyondEOL; 
            this.textEditorContent.AllowCaretBeyondEOL = !this.textEditorContent.AllowCaretBeyondEOL;
        }

        private void 制表符转换为空格CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.制表符转换为空格CToolStripMenuItem.Checked = this.textEditorContent.ConvertTabsToSpaces; 
            this.textEditorContent.ConvertTabsToSpaces = !this.textEditorContent.ConvertTabsToSpaces;
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = this.textEditorContent.Font;
            fontDialog.ShowDialog();
            this.textEditorContent.Font = fontDialog.Font;
        }      
    }  
}
