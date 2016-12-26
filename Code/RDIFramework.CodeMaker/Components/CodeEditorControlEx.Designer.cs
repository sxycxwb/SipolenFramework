namespace RDIFramework.CodeMaker
{
    partial class CodeEditorControlEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditorControlEx));
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.拆分窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示空格和制表符SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示换行标志EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示无效标记IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示行号LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高亮当前行HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高亮匹配括号当光标在其后时AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启用虚空格VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.制表符转换为空格CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.字体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textEditorContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontDialog
            // 
            this.fontDialog.Color = System.Drawing.SystemColors.ControlText;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuOption});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(41, 20);
            this.mnuFile.Text = "文件";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(94, 22);
            this.mnuOpen.Text = "打开";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(94, 22);
            this.mnuSave.Text = "保存";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuOption
            // 
            this.mnuOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拆分窗口ToolStripMenuItem,
            this.显示空格和制表符SToolStripMenuItem,
            this.显示换行标志EToolStripMenuItem,
            this.显示无效标记IToolStripMenuItem,
            this.显示行号LToolStripMenuItem,
            this.高亮当前行HToolStripMenuItem,
            this.高亮匹配括号当光标在其后时AToolStripMenuItem,
            this.启用虚空格VToolStripMenuItem,
            this.toolStripMenuItem1,
            this.制表符转换为空格CToolStripMenuItem,
            this.toolStripMenuItem2,
            this.字体ToolStripMenuItem});
            this.mnuOption.Name = "mnuOption";
            this.mnuOption.Size = new System.Drawing.Size(41, 20);
            this.mnuOption.Text = "选项";
            // 
            // 拆分窗口ToolStripMenuItem
            // 
            this.拆分窗口ToolStripMenuItem.Name = "拆分窗口ToolStripMenuItem";
            this.拆分窗口ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.拆分窗口ToolStripMenuItem.Text = "拆分窗口(&W)";
            this.拆分窗口ToolStripMenuItem.Click += new System.EventHandler(this.拆分窗口ToolStripMenuItem_Click);
            // 
            // 显示空格和制表符SToolStripMenuItem
            // 
            this.显示空格和制表符SToolStripMenuItem.Name = "显示空格和制表符SToolStripMenuItem";
            this.显示空格和制表符SToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.显示空格和制表符SToolStripMenuItem.Text = "显示空格和制表符(&S)";
            this.显示空格和制表符SToolStripMenuItem.Click += new System.EventHandler(this.显示空格和制表符SToolStripMenuItem_Click);
            // 
            // 显示换行标志EToolStripMenuItem
            // 
            this.显示换行标志EToolStripMenuItem.Name = "显示换行标志EToolStripMenuItem";
            this.显示换行标志EToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.显示换行标志EToolStripMenuItem.Text = "显示换行标志(&E)";
            this.显示换行标志EToolStripMenuItem.Click += new System.EventHandler(this.显示换行标志EToolStripMenuItem_Click);
            // 
            // 显示无效标记IToolStripMenuItem
            // 
            this.显示无效标记IToolStripMenuItem.Name = "显示无效标记IToolStripMenuItem";
            this.显示无效标记IToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.显示无效标记IToolStripMenuItem.Text = "显示无效标记(&I)";
            this.显示无效标记IToolStripMenuItem.Click += new System.EventHandler(this.显示无效标记IToolStripMenuItem_Click);
            // 
            // 显示行号LToolStripMenuItem
            // 
            this.显示行号LToolStripMenuItem.Name = "显示行号LToolStripMenuItem";
            this.显示行号LToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.显示行号LToolStripMenuItem.Text = "显示行号(&L)";
            this.显示行号LToolStripMenuItem.Click += new System.EventHandler(this.显示行号LToolStripMenuItem_Click);
            // 
            // 高亮当前行HToolStripMenuItem
            // 
            this.高亮当前行HToolStripMenuItem.Name = "高亮当前行HToolStripMenuItem";
            this.高亮当前行HToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.高亮当前行HToolStripMenuItem.Text = "高亮当前行(&H)";
            this.高亮当前行HToolStripMenuItem.Click += new System.EventHandler(this.高亮当前行HToolStripMenuItem_Click);
            // 
            // 高亮匹配括号当光标在其后时AToolStripMenuItem
            // 
            this.高亮匹配括号当光标在其后时AToolStripMenuItem.Name = "高亮匹配括号当光标在其后时AToolStripMenuItem";
            this.高亮匹配括号当光标在其后时AToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.高亮匹配括号当光标在其后时AToolStripMenuItem.Text = "高亮匹配括号当光标在其后时(&A)";
            this.高亮匹配括号当光标在其后时AToolStripMenuItem.Click += new System.EventHandler(this.高亮匹配括号当光标在其后时AToolStripMenuItem_Click);
            // 
            // 启用虚空格VToolStripMenuItem
            // 
            this.启用虚空格VToolStripMenuItem.Name = "启用虚空格VToolStripMenuItem";
            this.启用虚空格VToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.启用虚空格VToolStripMenuItem.Text = "启用虚空格(&V)";
            this.启用虚空格VToolStripMenuItem.Click += new System.EventHandler(this.启用虚空格VToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(241, 6);
            // 
            // 制表符转换为空格CToolStripMenuItem
            // 
            this.制表符转换为空格CToolStripMenuItem.Name = "制表符转换为空格CToolStripMenuItem";
            this.制表符转换为空格CToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.制表符转换为空格CToolStripMenuItem.Text = "制表符转换为空格(&C)";
            this.制表符转换为空格CToolStripMenuItem.Click += new System.EventHandler(this.制表符转换为空格CToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
            // 
            // 字体ToolStripMenuItem
            // 
            this.字体ToolStripMenuItem.Name = "字体ToolStripMenuItem";
            this.字体ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.字体ToolStripMenuItem.Text = "字体(&F)";
            this.字体ToolStripMenuItem.Click += new System.EventHandler(this.字体ToolStripMenuItem_Click);
            // 
            // textEditorContent
            // 
            this.textEditorContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorContent.Encoding = ((System.Text.Encoding)(resources.GetObject("textEditorContent.Encoding")));
            this.textEditorContent.Location = new System.Drawing.Point(0, 24);
            this.textEditorContent.Name = "textEditorContent";
            this.textEditorContent.ShowEOLMarkers = true;
            this.textEditorContent.ShowSpaces = true;
            this.textEditorContent.ShowTabs = true;
            this.textEditorContent.ShowVRuler = true;
            this.textEditorContent.Size = new System.Drawing.Size(702, 518);
            this.textEditorContent.TabIndex = 2;
            // 
            // CodeEditorControlEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditorContent);
            this.Controls.Add(this.menuStrip1);
            this.Name = "CodeEditorControlEx";
            this.Size = new System.Drawing.Size(702, 542);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuOption;
        private System.Windows.Forms.ToolStripMenuItem 拆分窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示空格和制表符SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示换行标志EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示无效标记IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示行号LToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高亮当前行HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高亮匹配括号当光标在其后时AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启用虚空格VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 制表符转换为空格CToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 字体ToolStripMenuItem;
        public ICSharpCode.TextEditor.TextEditorControl textEditorContent;
    }
}
