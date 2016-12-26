using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Gui.CompletionWindow;

namespace RDIFramework.CodeMaker
{
    public partial class CodeEditorControl : UserControl
    {
        #region Delegates
        //public delegate void KeyPressEventHandler(object sender, KeyEventArgs args);
        //public event KeyPressEventHandler KeyPressEvent;

        //public delegate void MYMouseRButtonUpEventHandler(object sender, MouseEventArgs args);
        //public event MYMouseRButtonUpEventHandler RMouseUpEvent;

        #endregion

        private string Type = "CS";

        public CodeEditorControl()
        {
            InitializeComponent();
            //this.textEditorContent.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
            this.SetCodeEditorContent("CS", "");
        }


        private void Document_DocumentChanged(object sender, DocumentEventArgs e)
        {
            this.textEditorContent.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
            this.textEditorContent.Document.FoldingManager.UpdateFoldings(null, null);
        }

        private string GetTypeName(string Type)
        {
            string ReturnValue = String.Empty;
            switch (Type)
            {
                case "SQL":
                    ReturnValue = "SQL";
                    break;
                case "CS":
                    ReturnValue = "C#";
                    break;
                case "Aspx":
                    ReturnValue = "HTML";
                    break;
                case "XML":
                    ReturnValue = "XML";
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
        
        /// <summary>
        /// Forces the editor to update its folds.
        /// </summary>
        void UpdateFolding()
        {
            textEditorContent.Document.FoldingManager.UpdateFoldings(String.Empty, null);
            textEditorContent.ActiveTextAreaControl.TextArea.Refresh();
        }  
      
        const string _PropertySavePath = "XmlEditor.TextEditorControl.{0}";
        const string SharpPadFileFilter = "程序文件(*.cs)|*.cs|页面文件(*.aspx)|*.aspx|Xml Files (*.xml)|*.xml|All Files (*.*)|*.*";
        private string saveFileName = string.Empty;
        /// <summary>
        /// 保存文件的名称
        /// </summary>
        public string SaveFileName
        {
            get { return this.saveFileName; }
            set { this.saveFileName = value; }
        }

        private void miFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {          
            #region 快捷菜单-文件
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "miOpenFile": //打开
                        {
                            TextEditorControl editor = textEditorContent;
                            if (editor != null)
                            {

                                using (OpenFileDialog dialog = new OpenFileDialog())
                                {
                                    dialog.Filter = SharpPadFileFilter;
                                    dialog.FilterIndex = 0;
                                    if (DialogResult.OK == dialog.ShowDialog())
                                    {
                                        editor.LoadFile(dialog.FileName);
                                        CheckCurrentViewMode(editor.Document.HighlightingStrategy.Name);
                                        if (System.IO.Path.GetExtension(dialog.FileName).ToLower() == ".xml")
                                        {
                                            if (!(textEditorContent.Document.FoldingManager.FoldingStrategy is XmlFoldingStrategy))
                                            {
                                                textEditorContent.Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
                                            }
                                            UpdateFolding();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "miSave": //保存
                        {
                            TextEditorControl editor = textEditorContent;
                            if (editor != null)
                            {
                                SaveAs();
                            }
                        }
                        break;
                    case "miSaveAs": //另存为
                        SaveAs();
                        break;
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
            #endregion
        }

        private void CheckCurrentViewMode(string modeName)
        {
            TextEditorControl editor = textEditorContent;
            if (editor != null)
            {
                if (editor.Document.HighlightingStrategy != null && this.miViewMode.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem mi in this.miViewMode.DropDownItems)
                    {
                        if (mi.Tag != null && mi.Tag.ToString().Equals(modeName, StringComparison.OrdinalIgnoreCase))
                        {
                            mi.Checked = true;
                        }
                        else
                        {
                            mi.Checked = false;
                        }
                    }
                }
            }
        }

        void SaveAs()
        {
            TextEditorControl editor = textEditorContent;
            if (editor != null)
            {
                SaveFileDialog dialog = null;
                try
                {
                    dialog = new SaveFileDialog();
                    dialog.Filter = SharpPadFileFilter;
                    dialog.FilterIndex = 0;
                    dialog.FileName = this.SaveFileName;
                    DialogResult result =  dialog.ShowDialog();
                    if (DialogResult.OK == result)
                    {
                        string kk = editor.Text;
                        FileHelper.WriteFile(dialog.FileName, editor.Text);
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
                finally
                {
                    dialog.Dispose();
                }                
            }
        }

        FindAndReplaceForm _findForm = new FindAndReplaceForm();
        private void miEdit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                #region 快捷菜单-编辑
                case "miEditCut": //剪切
                    if (HaveSelection())
                        DoEditAction(textEditorContent, new ICSharpCode.TextEditor.Actions.Cut());
                    break;
                case "miEditCopy": //复制
                    if (HaveSelection())
                        DoEditAction(textEditorContent, new ICSharpCode.TextEditor.Actions.Copy());
                    break;
                case "miEditPaste"://粘贴
                    DoEditAction(textEditorContent, new ICSharpCode.TextEditor.Actions.Paste());
                    break;
                case "miEditDelete": //删除
                    if (HaveSelection())
                        DoEditAction(textEditorContent, new ICSharpCode.TextEditor.Actions.Delete());
                    break;
                case "miEditFind": //查找
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        _findForm.ShowFor(editor, false);
                    }
                    break;
                case "miEditReplace": //替换
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        _findForm.ShowFor(editor, true);
                    }
                    break;
                case "miEditFindNext": // 查找下一个
                    _findForm.FindNext(true, false, string.Format("没有找到你要查找的内容！", _findForm.LookFor));
                    break;
                case "miEditFindPrev": // 查找上一个
                    _findForm.FindNext(true, true, string.Format("没有找到你要查找的内容！", _findForm.LookFor));
                    break;
                #endregion
            }
        }

        private void miOption_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                #region 快捷菜单-选项
                case "miSplitWindow": //拆分窗口
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.Split();
                        //OnSettingsChanged();
                    }
                    break;
                case "miShowSpacesTabs": //显示空格和制表符
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.ShowSpaces = editor.ShowTabs = !editor.ShowSpaces;
                        //OnSettingsChanged();
                    }
                    break;
                case "miShowEOLMarkers": //显示换行标志
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.ShowEOLMarkers = !editor.ShowEOLMarkers;
                        //OnSettingsChanged();
                    }
                    break;
                case "miShowInvalidLines": //显示无效标记
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.ShowInvalidLines = !editor.ShowInvalidLines;
                        //OnSettingsChanged();
                    }
                    break;
                case "miShowLineNumbers": //显示行号
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.ShowLineNumbers = !editor.ShowLineNumbers;
                        //OnSettingsChanged();
                    }
                    break;
                case "miHLCurRow": //高亮当前行
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.LineViewerStyle = editor.LineViewerStyle == LineViewerStyle.None ? LineViewerStyle.FullRow : LineViewerStyle.None;
                        //OnSettingsChanged();
                    }
                    break;
                case "miBracketMatchingStyle": //高亮匹配括号当光标在其后时
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.BracketMatchingStyle = editor.BracketMatchingStyle == BracketMatchingStyle.After ? BracketMatchingStyle.Before : BracketMatchingStyle.After;
                        //OnSettingsChanged();
                    }
                    break;
                case "miEnableVirtualSpace": //启用虚空格
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.AllowCaretBeyondEOL = !editor.AllowCaretBeyondEOL;
                        //OnSettingsChanged();
                    }
                    break;
                case "miConvertTabsToSpaces": //制表符转换为空格
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor == null) return;
                        editor.ConvertTabsToSpaces = !editor.ConvertTabsToSpaces;
                        //OnSettingsChanged();
                    }
                    break;
                case "miSetFont": //字体
                    {
                        TextEditorControl editor = textEditorContent;
                        if (editor != null)
                        {
                            fontDialog.Font = editor.Font;
                            if (fontDialog.ShowDialog(this) == DialogResult.OK)
                            {
                                editor.Font = fontDialog.Font;
                               // OnSettingsChanged();
                            }
                        }
                    }
                    break;
                #endregion
            }
        }

        /// <summary>
        /// This variable holds the settings (whether to show line numbers, 
        /// etc.) that all editor controls share.</summary>
        //ITextEditorProperties _editorSettings;

        /// <summary>Show current settings on the Options menu</summary>
        /// <remarks>We don't have to sync settings between the editors because 
        /// they all share the same DefaultTextEditorProperties object.</remarks>
        //private void OnSettingsChanged()
        //{
        //    this.miShowSpacesTabs.Checked = _editorSettings.ShowSpaces;
        //    this.miShowEOLMarkers.Checked = _editorSettings.ShowEOLMarker;
        //    this.miShowInvalidLines.Checked = _editorSettings.ShowInvalidLines;
        //    this.miHLCurRow.Checked = _editorSettings.LineViewerStyle == LineViewerStyle.FullRow;
        //    this.miBracketMatchingStyle.Checked = _editorSettings.BracketMatchingStyle == BracketMatchingStyle.After;
        //    this.miEnableVirtualSpace.Checked = _editorSettings.AllowCaretBeyondEOL;
        //    this.miShowLineNumbers.Checked = _editorSettings.ShowLineNumbers;
        //    this.miConvertTabsToSpaces.Checked = textEditorContent.ConvertTabsToSpaces;
        //}

        private bool HaveSelection()
        {
            TextEditorControl editor = textEditorContent;
            return editor != null &&
                editor.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected;
        }

        //this.textEditorDDL.ShowEOLMarkers = false;
        //this.textEditorDDL.ShowHRuler = false;
        //this.textEditorDDL.ShowInvalidLines = false;
        //this.textEditorDDL.ShowTabs = false;
        //this.textEditorDDL.ShowVRuler = false;

        [Category("CodeEditor Propery"), Description("与控件关联的文本"), Browsable(true)]
        public override string Text
        {
            get
            {
                return textEditorContent.Text;
            }
            set
            {
                textEditorContent.Text = value;
            }
        }

        [Category("CodeEditor Propery"), Description("If true EOL markers are shown in the textarea。"), Browsable(true)]
        public bool ShowEOLMarkers
        {
            get { return textEditorContent.ShowEOLMarkers; }
            set { textEditorContent.ShowEOLMarkers = value; }
        }

        [Category("CodeEditor Propery"), Description("If true the horizontal ruler is shown in the textarea"), Browsable(true)]
        public bool ShowHRuler
        {
            get { return textEditorContent.ShowHRuler; }
            set { textEditorContent.ShowHRuler = value; }
        }

        [Category("CodeEditor Propery"), Description("If true invalid lines are marked in the textarea"), Browsable(true)]
        public bool ShowInvalidLines
        {
            get { return textEditorContent.ShowInvalidLines; }
            set { textEditorContent.ShowInvalidLines = value; }
        }

        [Category("CodeEditor Propery"), Description("If true tabs are shown in the textarea"), Browsable(true)]
        public bool ShowTabs
        {
            get { return textEditorContent.ShowTabs; }
            set { textEditorContent.ShowTabs = value; }
        }

        [Category("CodeEditor Propery"), Description("If true the vertical ruler is shown in the textarea"), Browsable(true)]
        public bool ShowVRuler
        {
            get { return textEditorContent.ShowVRuler; }
            set { textEditorContent.ShowVRuler = value; }
        }

        [Category("CodeEditor Propery"), Description("If true line numbers are shown in the textarea"), Browsable(true)]
        public bool ShowLineNumbers
        {
            get { return textEditorContent.ShowLineNumbers; }
            set { textEditorContent.ShowLineNumbers = value; }
        }


        /// <summary>Performs an action encapsulated in IEditAction.</summary>
        /// <remarks>
        /// There is an implementation of IEditAction for every action that 
        /// the user can invoke using a shortcut key (arrow keys, Ctrl+X, etc.)
        /// The editor control doesn't provide a public funciton to perform one
        /// of these actions directly, so I wrote DoEditAction() based on the
        /// code in TextArea.ExecuteDialogKey(). You can call ExecuteDialogKey
        /// directly, but it is more fragile because it takes a Keys value (e.g.
        /// Keys.Left) instead of the action to perform.
        /// <para/>
        /// Clipboard commands could also be done by calling methods in
        /// editor.ActiveTextAreaControl.TextArea.ClipboardHandler.
        /// </remarks>
        private void DoEditAction(TextEditorControl editor, ICSharpCode.TextEditor.Actions.IEditAction action)
        {
            if (editor != null && action != null)
            {
                TextArea area = editor.ActiveTextAreaControl.TextArea;
                editor.BeginUpdate();
                try
                {
                    lock (editor.Document)
                    {
                        action.Execute(area);
                        if (area.SelectionManager.HasSomethingSelected && area.AutoClearSelection /*&& caretchanged*/)
                        {
                            if (area.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal)
                            {
                                area.SelectionManager.ClearSelection();
                            }
                        }
                    }
                }
                finally
                {
                    editor.EndUpdate();
                    area.Caret.UpdateCaretPosition();
                }
            }
        }
    
        public enum LanguageType
        {
            SQL = 0,
            VBNET = 1,
            CSHARP = 2,
            HTML = 3,
            CPP = 4,
            Java = 5,
            JavaScript = 6,
            XML = 7,
            CPlusPlusNET=8,
            PHP=9,
            BAT=10
        }

        //private void textEditorContent_Load(object sender, EventArgs e)
        //{
        //    //if (_editorSettings == null)
        //    //{
        //    //    _editorSettings = textEditorContent.TextEditorProperties;
        //    //    OnSettingsChanged();
        //    //}
        //    //else
        //    //    textEditorContent.TextEditorProperties = _editorSettings;
        //}       
    }  
}
