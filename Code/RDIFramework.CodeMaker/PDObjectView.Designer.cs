namespace RDIFramework.CodeMaker
{
    partial class PDObjectView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Procedure", 4, 4);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Table", 3, 3);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("View", 4, 4);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Procedure", 5, 5);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Tables", 2, 2, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("PowserDesigner设计源文件", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("WorkSpace", 0, 0, new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDObjectView));
            this.tlDesignObjectView = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnExpand = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.tvPDObjectView = new System.Windows.Forms.TreeView();
            this.cmnuPD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuItemGengerateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemGengerateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemGengerateEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemGengerateMvcEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemGengerateIService = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemGengerateService = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemGengerateManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuItemGengerateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuItemDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuItemRefreash = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuItemBatchGenerateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListPD = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDesignDocPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmnuItemGengerateDbScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tlDesignObjectView.SuspendLayout();
            this.cmnuPD.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlDesignObjectView
            // 
            this.tlDesignObjectView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnExpand,
            this.tsBtnRemove});
            this.tlDesignObjectView.Location = new System.Drawing.Point(0, 0);
            this.tlDesignObjectView.Name = "tlDesignObjectView";
            this.tlDesignObjectView.Size = new System.Drawing.Size(254, 25);
            this.tlDesignObjectView.TabIndex = 0;
            this.tlDesignObjectView.Text = "toolStrip1";
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAdd.Enabled = false;
            this.tsBtnAdd.Image = global::RDIFramework.CodeMaker.Properties.Resources.add;
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAdd.Text = "增加PowerDesigner设计文档";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
            // 
            // tsBtnExpand
            // 
            this.tsBtnExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnExpand.Enabled = false;
            this.tsBtnExpand.Image = global::RDIFramework.CodeMaker.Properties.Resources.expand;
            this.tsBtnExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExpand.Name = "tsBtnExpand";
            this.tsBtnExpand.Size = new System.Drawing.Size(23, 22);
            this.tsBtnExpand.Text = "展开PowerDesigner设计文件";
            this.tsBtnExpand.Click += new System.EventHandler(this.tsBtnExpand_Click);
            // 
            // tsBtnRemove
            // 
            this.tsBtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRemove.Enabled = false;
            this.tsBtnRemove.Image = global::RDIFramework.CodeMaker.Properties.Resources.delete;
            this.tsBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemove.Name = "tsBtnRemove";
            this.tsBtnRemove.Size = new System.Drawing.Size(23, 22);
            this.tsBtnRemove.Text = "移除PowerDesigner设计文档";
            this.tsBtnRemove.Click += new System.EventHandler(this.tsBtnRemove_Click);
            // 
            // tvPDObjectView
            // 
            this.tvPDObjectView.ContextMenuStrip = this.cmnuPD;
            this.tvPDObjectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPDObjectView.ImageIndex = 0;
            this.tvPDObjectView.ImageList = this.imgListPD;
            this.tvPDObjectView.Location = new System.Drawing.Point(0, 25);
            this.tvPDObjectView.Name = "tvPDObjectView";
            treeNode1.ImageIndex = 4;
            treeNode1.Name = "节点5";
            treeNode1.SelectedImageIndex = 4;
            treeNode1.Text = "Procedure";
            treeNode2.ImageIndex = 3;
            treeNode2.Name = "nodeTable";
            treeNode2.SelectedImageIndex = 3;
            treeNode2.Text = "Table";
            treeNode3.ImageIndex = 4;
            treeNode3.Name = "节点4";
            treeNode3.SelectedImageIndex = 4;
            treeNode3.Text = "View";
            treeNode4.ImageIndex = 5;
            treeNode4.Name = "节点5";
            treeNode4.SelectedImageIndex = 5;
            treeNode4.Text = "Procedure";
            treeNode5.ImageIndex = 2;
            treeNode5.Name = "nodeTables";
            treeNode5.SelectedImageIndex = 2;
            treeNode5.Text = "Tables";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "节点3";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Text = "PowserDesigner设计源文件";
            treeNode7.ImageIndex = 0;
            treeNode7.Name = "nodeWorkSpace";
            treeNode7.SelectedImageIndex = 0;
            treeNode7.Text = "WorkSpace";
            this.tvPDObjectView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.tvPDObjectView.SelectedImageIndex = 0;
            this.tvPDObjectView.Size = new System.Drawing.Size(254, 488);
            this.tvPDObjectView.TabIndex = 1;
            this.tvPDObjectView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPDObjectView_AfterSelect);
            this.tvPDObjectView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPDObjectView_NodeMouseClick);
            this.tvPDObjectView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvPDObjectView_NodeMouseDoubleClick);
            // 
            // cmnuPD
            // 
            this.cmnuPD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemGengerateCode,
            this.cmnuItemDocument,
            this.toolStripMenuItem1,
            this.cmnuItemRefreash,
            this.toolStripMenuItem3,
            this.cmnuItemBatchGenerateAll});
            this.cmnuPD.Name = "cmnuPD";
            this.cmnuPD.Size = new System.Drawing.Size(153, 126);
            // 
            // cmnuItemGengerateCode
            // 
            this.cmnuItemGengerateCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuItemGengerateTable,
            this.cmnuItemGengerateEntity,
            this.cmnuItemGengerateMvcEntity,
            this.cmnuItemGengerateIService,
            this.cmnuItemGengerateService,
            this.cmnuItemGengerateManager,
            this.cmnuItemGengerateDbScript,
            this.toolStripMenuItem2,
            this.cmnuItemGengerateAll});
            this.cmnuItemGengerateCode.Image = global::RDIFramework.CodeMaker.Properties.Resources.code;
            this.cmnuItemGengerateCode.Name = "cmnuItemGengerateCode";
            this.cmnuItemGengerateCode.Size = new System.Drawing.Size(152, 22);
            this.cmnuItemGengerateCode.Text = "生成代码";
            this.cmnuItemGengerateCode.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmnuItemGengerateCode_DropDownItemClicked);
            // 
            // cmnuItemGengerateTable
            // 
            this.cmnuItemGengerateTable.Image = global::RDIFramework.CodeMaker.Properties.Resources.table;
            this.cmnuItemGengerateTable.Name = "cmnuItemGengerateTable";
            this.cmnuItemGengerateTable.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateTable.Text = "类数据表";
            // 
            // cmnuItemGengerateEntity
            // 
            this.cmnuItemGengerateEntity.Name = "cmnuItemGengerateEntity";
            this.cmnuItemGengerateEntity.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateEntity.Text = "业务实体（Entity）";
            // 
            // cmnuItemGengerateMvcEntity
            // 
            this.cmnuItemGengerateMvcEntity.Name = "cmnuItemGengerateMvcEntity";
            this.cmnuItemGengerateMvcEntity.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateMvcEntity.Text = "MVC业务实体(MvcEntity";
            // 
            // cmnuItemGengerateIService
            // 
            this.cmnuItemGengerateIService.Name = "cmnuItemGengerateIService";
            this.cmnuItemGengerateIService.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateIService.Text = "契约服务接口（WCF服务接口）";
            // 
            // cmnuItemGengerateService
            // 
            this.cmnuItemGengerateService.Name = "cmnuItemGengerateService";
            this.cmnuItemGengerateService.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateService.Text = "契约服务（WCF服务实现）";
            // 
            // cmnuItemGengerateManager
            // 
            this.cmnuItemGengerateManager.Name = "cmnuItemGengerateManager";
            this.cmnuItemGengerateManager.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateManager.Text = "服务管理器";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(229, 6);
            // 
            // cmnuItemGengerateAll
            // 
            this.cmnuItemGengerateAll.Name = "cmnuItemGengerateAll";
            this.cmnuItemGengerateAll.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateAll.Text = "全部生成";
            // 
            // cmnuItemDocument
            // 
            this.cmnuItemDocument.Image = global::RDIFramework.CodeMaker.Properties.Resources.document;
            this.cmnuItemDocument.Name = "cmnuItemDocument";
            this.cmnuItemDocument.Size = new System.Drawing.Size(152, 22);
            this.cmnuItemDocument.Text = "文档";
            this.cmnuItemDocument.Click += new System.EventHandler(this.cmnuItemDocument_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // cmnuItemRefreash
            // 
            this.cmnuItemRefreash.Image = global::RDIFramework.CodeMaker.Properties.Resources.refresh;
            this.cmnuItemRefreash.Name = "cmnuItemRefreash";
            this.cmnuItemRefreash.Size = new System.Drawing.Size(152, 22);
            this.cmnuItemRefreash.Text = "刷新";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // cmnuItemBatchGenerateAll
            // 
            this.cmnuItemBatchGenerateAll.Image = global::RDIFramework.CodeMaker.Properties.Resources.generate;
            this.cmnuItemBatchGenerateAll.Name = "cmnuItemBatchGenerateAll";
            this.cmnuItemBatchGenerateAll.Size = new System.Drawing.Size(152, 22);
            this.cmnuItemBatchGenerateAll.Text = "批量代码生成";
            this.cmnuItemBatchGenerateAll.Click += new System.EventHandler(this.cmnuItemBatchGenerateAll_Click);
            // 
            // imgListPD
            // 
            this.imgListPD.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListPD.ImageStream")));
            this.imgListPD.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListPD.Images.SetKeyName(0, "workspace.png");
            this.imgListPD.Images.SetKeyName(1, "pd.gif");
            this.imgListPD.Images.SetKeyName(2, "tables.png");
            this.imgListPD.Images.SetKeyName(3, "table.png");
            this.imgListPD.Images.SetKeyName(4, "view.png");
            this.imgListPD.Images.SetKeyName(5, "procedure.png");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDesignDocPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 513);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(254, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDesignDocPath
            // 
            this.lblDesignDocPath.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.lblDesignDocPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblDesignDocPath.Name = "lblDesignDocPath";
            this.lblDesignDocPath.Size = new System.Drawing.Size(77, 17);
            this.lblDesignDocPath.Text = "            ";
            this.lblDesignDocPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmnuItemGengerateDbScript
            // 
            this.cmnuItemGengerateDbScript.Name = "cmnuItemGengerateDbScript";
            this.cmnuItemGengerateDbScript.Size = new System.Drawing.Size(232, 22);
            this.cmnuItemGengerateDbScript.Text = "数据库脚本";
            // 
            // PDObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 535);
            this.Controls.Add(this.tvPDObjectView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tlDesignObjectView);
            this.Name = "PDObjectView";
            this.Text = "PowerDesigner Objects";
            this.Load += new System.EventHandler(this.PDObjectView_Load);
            this.tlDesignObjectView.ResumeLayout(false);
            this.tlDesignObjectView.PerformLayout();
            this.cmnuPD.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlDesignObjectView;
        private System.Windows.Forms.TreeView tvPDObjectView;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ImageList imgListPD;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDesignDocPath;
        private System.Windows.Forms.ContextMenuStrip cmnuPD;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateCode;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemRefreash;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateTable;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateEntity;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateIService;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateService;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateManager;
        private System.Windows.Forms.ToolStripButton tsBtnExpand;
        private System.Windows.Forms.ToolStripButton tsBtnRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemBatchGenerateAll;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateMvcEntity;
        private System.Windows.Forms.ToolStripMenuItem cmnuItemGengerateDbScript;
    }
}