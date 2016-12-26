using System.Drawing;
using TextEditor.Editor;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor.Actions;

namespace RDIFramework.CodeMaker
{
    partial class DbQuery
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbQuery));
            this.cmShortcutMeny = new System.Windows.Forms.ContextMenu();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ttParamenterInfo = new System.Windows.Forms.ToolTip(this.components);
            this.ExecutionTimer = new System.Windows.Forms.Timer(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pageSetupDialog = new System.Windows.Forms.PageSetupDialog();
            this.cmDragAndDrp = new System.Windows.Forms.ContextMenu();
            this.menuItemObjectName = new System.Windows.Forms.MenuItem();
            this.menuItemSplitter = new System.Windows.Forms.MenuItem();
            this.menuItemSelect1 = new System.Windows.Forms.MenuItem();
            this.menuItemSelect2 = new System.Windows.Forms.MenuItem();
            this.menuItemJoin = new System.Windows.Forms.MenuItem();
            this.menuItemLeftOuterJoin = new System.Windows.Forms.MenuItem();
            this.menuItemRightOuterJoin = new System.Windows.Forms.MenuItem();
            this.menuItemWhere = new System.Windows.Forms.MenuItem();
            this.menuItemOrderBy = new System.Windows.Forms.MenuItem();
            this.menuItemGroupBy = new System.Windows.Forms.MenuItem();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.txtContent = new TextEditor.Editor.TextEditorControlWrapper();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 483);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(454, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(439, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 339);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(454, 144);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(446, 117);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "结果";
            this.tabPage1.ToolTipText = "查询结果";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(446, 117);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtInfo);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(446, 117);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "消息";
            this.tabPage2.ToolTipText = "语句执行情况";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(0, 0);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(446, 117);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "List.png");
            this.imageList1.Images.SetKeyName(1, "Info.png");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 336);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(454, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // ttParamenterInfo
            // 
            this.ttParamenterInfo.Active = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            // 
            // pageSetupDialog
            // 
            this.pageSetupDialog.Document = this.printDocument;
            // 
            // cmDragAndDrp
            // 
            this.cmDragAndDrp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemObjectName,
            this.menuItemSplitter,
            this.menuItemSelect1,
            this.menuItemSelect2,
            this.menuItemJoin,
            this.menuItemLeftOuterJoin,
            this.menuItemRightOuterJoin,
            this.menuItemWhere,
            this.menuItemOrderBy,
            this.menuItemGroupBy});
            // 
            // menuItemObjectName
            // 
            this.menuItemObjectName.Index = 0;
            this.menuItemObjectName.Text = "Object name";
            this.menuItemObjectName.Click += new System.EventHandler(this.menuItemObjectName_Click);
            // 
            // menuItemSplitter
            // 
            this.menuItemSplitter.Index = 1;
            this.menuItemSplitter.Text = "-";
            // 
            // menuItemSelect1
            // 
            this.menuItemSelect1.Index = 2;
            this.menuItemSelect1.Text = "SELECT * FROM...";
            this.menuItemSelect1.Click += new System.EventHandler(this.menuItemSelect1_Click);
            // 
            // menuItemSelect2
            // 
            this.menuItemSelect2.Index = 3;
            this.menuItemSelect2.Text = "SELECT [Fields] FROM";
            this.menuItemSelect2.Click += new System.EventHandler(this.menuItemSelect2_Click);
            // 
            // menuItemJoin
            // 
            this.menuItemJoin.Index = 4;
            this.menuItemJoin.Text = "UPDATE...";
            this.menuItemJoin.Click += new System.EventHandler(this.menuItemJoin_Click);
            // 
            // menuItemLeftOuterJoin
            // 
            this.menuItemLeftOuterJoin.Index = 5;
            this.menuItemLeftOuterJoin.Text = "DELETE FROM...";
            this.menuItemLeftOuterJoin.Click += new System.EventHandler(this.menuItemLeftOuterJoin_Click);
            // 
            // menuItemRightOuterJoin
            // 
            this.menuItemRightOuterJoin.Index = 6;
            this.menuItemRightOuterJoin.Text = "INSERT INTO ...";
            this.menuItemRightOuterJoin.Click += new System.EventHandler(this.menuItemRightOuterJoin_Click);
            // 
            // menuItemWhere
            // 
            this.menuItemWhere.Index = 7;
            this.menuItemWhere.Text = "WHERE";
            this.menuItemWhere.Click += new System.EventHandler(this.menuItemWhere_Click);
            // 
            // menuItemOrderBy
            // 
            this.menuItemOrderBy.Index = 8;
            this.menuItemOrderBy.Text = "ORDER BY";
            this.menuItemOrderBy.Click += new System.EventHandler(this.menuItemOrderBy_Click);
            // 
            // menuItemGroupBy
            // 
            this.menuItemGroupBy.Index = 9;
            this.menuItemGroupBy.Text = "GROUP BY";
            this.menuItemGroupBy.Click += new System.EventHandler(this.menuItemGroupBy_Click);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // txtContent
            // 
            this.txtContent.AllowDrop = true;
            this.txtContent.AutoScroll = true;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Encoding = ((System.Text.Encoding)(resources.GetObject("txtContent.Encoding")));
            this.txtContent.IsIconBarVisible = false;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.SelectedText = "";
            this.txtContent.SelectionStart = 0;
            this.txtContent.ShowEOLMarkers = true;
            this.txtContent.ShowInvalidLines = false;
            this.txtContent.ShowSpaces = true;
            this.txtContent.ShowTabs = true;
            this.txtContent.ShowVRuler = true;
            this.txtContent.Size = new System.Drawing.Size(454, 336);
            this.txtContent.TabIndex = 2;
            this.txtContent.KeyPressEvent += new TextEditor.Editor.TextEditorControlWrapper.KeyPressEventHandler(this.qcTextEditor_KeyPressEvent);
            this.txtContent.RMouseUpEvent += new TextEditor.Editor.TextEditorControlWrapper.MYMouseRButtonUpEventHandler(this.qcTextEditor_MouseUp);
            // 
            // DbQuery
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 505);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DbQuery";
            this.Text = "DbQuery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DbQuery_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TextEditorControlWrapper txtContent;
        private System.Windows.Forms.ContextMenu cmShortcutMeny;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public  System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.ToolTip ttParamenterInfo;
        private System.Windows.Forms.Timer ExecutionTimer;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog;
        private System.Windows.Forms.ContextMenu cmDragAndDrp;
        private System.Windows.Forms.MenuItem menuItemObjectName;
        private System.Windows.Forms.MenuItem menuItemSplitter;
        private System.Windows.Forms.MenuItem menuItemSelect1;
        private System.Windows.Forms.MenuItem menuItemSelect2;
        private System.Windows.Forms.MenuItem menuItemJoin;
        private System.Windows.Forms.MenuItem menuItemLeftOuterJoin;
        private System.Windows.Forms.MenuItem menuItemRightOuterJoin;
        private System.Windows.Forms.MenuItem menuItemWhere;
        private System.Windows.Forms.MenuItem menuItemOrderBy;
        private System.Windows.Forms.MenuItem menuItemGroupBy;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}