namespace RDIFramework.CodeMaker
{
    partial class CodeEditorControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditorControl));
            this.textEditorContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.contextMnuTask = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miEditFind = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditFindPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.miOption = new System.Windows.Forms.ToolStripMenuItem();
            this.miSplitWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowSpacesTabs = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowEOLMarkers = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowInvalidLines = new System.Windows.Forms.ToolStripMenuItem();
            this.miShowLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.miHLCurRow = new System.Windows.Forms.ToolStripMenuItem();
            this.miBracketMatchingStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnableVirtualSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miConvertTabsToSpaces = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.miSetFont = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewMode = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.contextMnuTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEditorContent
            // 
            this.textEditorContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorContent.Encoding = ((System.Text.Encoding)(resources.GetObject("textEditorContent.Encoding")));
            this.textEditorContent.Location = new System.Drawing.Point(0, 0);
            this.textEditorContent.Name = "textEditorContent";
            this.textEditorContent.ShowEOLMarkers = true;
            this.textEditorContent.ShowSpaces = true;
            this.textEditorContent.ShowTabs = true;
            this.textEditorContent.ShowVRuler = true;
            this.textEditorContent.Size = new System.Drawing.Size(702, 542);
            this.textEditorContent.TabIndex = 2;
            // 
            // contextMnuTask
            // 
            this.contextMnuTask.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.miOption,
            this.miViewMode});
            this.contextMnuTask.Name = "contextMnuTask";
            this.contextMnuTask.Size = new System.Drawing.Size(137, 92);
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenFile,
            this.miSave,
            this.miSaveAs});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(136, 22);
            this.miFile.Text = "文件(&F)";
            this.miFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miFile_DropDownItemClicked);
            // 
            // miOpenFile
            // 
            this.miOpenFile.Name = "miOpenFile";
            this.miOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpenFile.Size = new System.Drawing.Size(171, 22);
            this.miOpenFile.Text = "打开(&O)...";
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(171, 22);
            this.miSave.Text = "保存(&S)";
            // 
            // miSaveAs
            // 
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.Size = new System.Drawing.Size(171, 22);
            this.miSaveAs.Text = "另存为(&A)...";
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditCut,
            this.miEditCopy,
            this.miEditPaste,
            this.miEditDelete,
            this.toolStripMenuItem1,
            this.miEditFind,
            this.miEditReplace,
            this.miEditFindNext,
            this.miEditFindPrev});
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(136, 22);
            this.miEdit.Text = "编辑(&E)";
            this.miEdit.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miEdit_DropDownItemClicked);
            // 
            // miEditCut
            // 
            this.miEditCut.Name = "miEditCut";
            this.miEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.miEditCut.Size = new System.Drawing.Size(219, 22);
            this.miEditCut.Text = "剪切";
            // 
            // miEditCopy
            // 
            this.miEditCopy.Image = global::RDIFramework.CodeMaker.Properties.Resources.copy;
            this.miEditCopy.Name = "miEditCopy";
            this.miEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.miEditCopy.Size = new System.Drawing.Size(219, 22);
            this.miEditCopy.Text = "复制";
            // 
            // miEditPaste
            // 
            this.miEditPaste.Image = global::RDIFramework.CodeMaker.Properties.Resources.paste;
            this.miEditPaste.Name = "miEditPaste";
            this.miEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.miEditPaste.Size = new System.Drawing.Size(219, 22);
            this.miEditPaste.Text = "粘贴";
            // 
            // miEditDelete
            // 
            this.miEditDelete.Image = ((System.Drawing.Image)(resources.GetObject("miEditDelete.Image")));
            this.miEditDelete.Name = "miEditDelete";
            this.miEditDelete.Size = new System.Drawing.Size(219, 22);
            this.miEditDelete.Text = "删除(&D)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 6);
            // 
            // miEditFind
            // 
            this.miEditFind.Image = ((System.Drawing.Image)(resources.GetObject("miEditFind.Image")));
            this.miEditFind.Name = "miEditFind";
            this.miEditFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miEditFind.Size = new System.Drawing.Size(219, 22);
            this.miEditFind.Text = "查找(&F)...";
            // 
            // miEditReplace
            // 
            this.miEditReplace.Name = "miEditReplace";
            this.miEditReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.miEditReplace.Size = new System.Drawing.Size(219, 22);
            this.miEditReplace.Text = "替换(&H)...";
            // 
            // miEditFindNext
            // 
            this.miEditFindNext.Name = "miEditFindNext";
            this.miEditFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.miEditFindNext.Size = new System.Drawing.Size(219, 22);
            this.miEditFindNext.Text = "查找下一个(&N)...";
            // 
            // miEditFindPrev
            // 
            this.miEditFindPrev.Name = "miEditFindPrev";
            this.miEditFindPrev.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.miEditFindPrev.Size = new System.Drawing.Size(219, 22);
            this.miEditFindPrev.Text = "查找上一个(&P)...";
            // 
            // miOption
            // 
            this.miOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSplitWindow,
            this.miShowSpacesTabs,
            this.miShowEOLMarkers,
            this.miShowInvalidLines,
            this.miShowLineNumbers,
            this.miHLCurRow,
            this.miBracketMatchingStyle,
            this.miEnableVirtualSpace,
            this.toolStripMenuItem2,
            this.miConvertTabsToSpaces,
            this.toolStripMenuItem3,
            this.miSetFont});
            this.miOption.Name = "miOption";
            this.miOption.Size = new System.Drawing.Size(136, 22);
            this.miOption.Text = "选项(&O)";
            this.miOption.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.miOption_DropDownItemClicked);
            // 
            // miSplitWindow
            // 
            this.miSplitWindow.Name = "miSplitWindow";
            this.miSplitWindow.Size = new System.Drawing.Size(244, 22);
            this.miSplitWindow.Text = "拆分窗口(&W)";
            // 
            // miShowSpacesTabs
            // 
            this.miShowSpacesTabs.Name = "miShowSpacesTabs";
            this.miShowSpacesTabs.Size = new System.Drawing.Size(244, 22);
            this.miShowSpacesTabs.Text = "显示空格和制表符(&S)";
            // 
            // miShowEOLMarkers
            // 
            this.miShowEOLMarkers.Name = "miShowEOLMarkers";
            this.miShowEOLMarkers.Size = new System.Drawing.Size(244, 22);
            this.miShowEOLMarkers.Text = "显示换行标志(&E)";
            // 
            // miShowInvalidLines
            // 
            this.miShowInvalidLines.Name = "miShowInvalidLines";
            this.miShowInvalidLines.Size = new System.Drawing.Size(244, 22);
            this.miShowInvalidLines.Text = "显示无效标记(&I)";
            // 
            // miShowLineNumbers
            // 
            this.miShowLineNumbers.Name = "miShowLineNumbers";
            this.miShowLineNumbers.Size = new System.Drawing.Size(244, 22);
            this.miShowLineNumbers.Text = "显示行号(&L)";
            // 
            // miHLCurRow
            // 
            this.miHLCurRow.Name = "miHLCurRow";
            this.miHLCurRow.Size = new System.Drawing.Size(244, 22);
            this.miHLCurRow.Text = "高亮当前行(&H)";
            // 
            // miBracketMatchingStyle
            // 
            this.miBracketMatchingStyle.Name = "miBracketMatchingStyle";
            this.miBracketMatchingStyle.Size = new System.Drawing.Size(244, 22);
            this.miBracketMatchingStyle.Text = "高亮匹配括号当光标在其后时(&A)";
            // 
            // miEnableVirtualSpace
            // 
            this.miEnableVirtualSpace.Name = "miEnableVirtualSpace";
            this.miEnableVirtualSpace.Size = new System.Drawing.Size(244, 22);
            this.miEnableVirtualSpace.Text = "启用虚空格(&V)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
            // 
            // miConvertTabsToSpaces
            // 
            this.miConvertTabsToSpaces.Name = "miConvertTabsToSpaces";
            this.miConvertTabsToSpaces.Size = new System.Drawing.Size(244, 22);
            this.miConvertTabsToSpaces.Text = "制表符转换为空格(&C)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(241, 6);
            // 
            // miSetFont
            // 
            this.miSetFont.Name = "miSetFont";
            this.miSetFont.Size = new System.Drawing.Size(244, 22);
            this.miSetFont.Text = "字体(&F)";
            // 
            // miViewMode
            // 
            this.miViewMode.Name = "miViewMode";
            this.miViewMode.Size = new System.Drawing.Size(136, 22);
            this.miViewMode.Text = "查看方式(&M)";
            // 
            // fontDialog
            // 
            this.fontDialog.Color = System.Drawing.SystemColors.ControlText;
            // 
            // CodeEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditorContent);
            this.Name = "CodeEditorControl";
            this.Size = new System.Drawing.Size(702, 542);
            this.contextMnuTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl textEditorContent;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ContextMenuStrip contextMnuTask;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miEditCut;
        private System.Windows.Forms.ToolStripMenuItem miEditCopy;
        private System.Windows.Forms.ToolStripMenuItem miEditPaste;
        private System.Windows.Forms.ToolStripMenuItem miEditDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miEditFind;
        private System.Windows.Forms.ToolStripMenuItem miEditReplace;
        private System.Windows.Forms.ToolStripMenuItem miEditFindNext;
        private System.Windows.Forms.ToolStripMenuItem miEditFindPrev;
        private System.Windows.Forms.ToolStripMenuItem miOption;
        private System.Windows.Forms.ToolStripMenuItem miSplitWindow;
        private System.Windows.Forms.ToolStripMenuItem miShowSpacesTabs;
        private System.Windows.Forms.ToolStripMenuItem miShowEOLMarkers;
        private System.Windows.Forms.ToolStripMenuItem miShowInvalidLines;
        private System.Windows.Forms.ToolStripMenuItem miShowLineNumbers;
        private System.Windows.Forms.ToolStripMenuItem miHLCurRow;
        private System.Windows.Forms.ToolStripMenuItem miBracketMatchingStyle;
        private System.Windows.Forms.ToolStripMenuItem miEnableVirtualSpace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miConvertTabsToSpaces;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miSetFont;
        private System.Windows.Forms.ToolStripMenuItem miViewMode;
    }
}
