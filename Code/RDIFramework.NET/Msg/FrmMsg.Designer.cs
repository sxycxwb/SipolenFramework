namespace RDIFramework.NET
{
    partial class FrmMsg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMsg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCurentUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tcMsg = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvRole = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tpRole = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.tpOrganize = new DevComponents.DotNetBar.TabItem(this.components);
            this.statusMsg = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.cMnuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timerFrmMsg = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMsg)).BeginInit();
            this.tcMsg.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lblCurentUser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 76);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(271, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-27, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 2);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(225)))), ((int)(((byte)(249)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(70, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 14);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "编辑签名....";
            // 
            // lblCurentUser
            // 
            this.lblCurentUser.AutoSize = true;
            this.lblCurentUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurentUser.Location = new System.Drawing.Point(67, 12);
            this.lblCurentUser.Name = "lblCurentUser";
            this.lblCurentUser.Size = new System.Drawing.Size(67, 14);
            this.lblCurentUser.TabIndex = 1;
            this.lblCurentUser.Text = "当前用户";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 49);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tcMsg
            // 
            this.tcMsg.AutoHideSystemBox = false;
            this.tcMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tcMsg.CanReorderTabs = true;
            this.tcMsg.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tcMsg.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.Empty, 1F)});
            this.tcMsg.ColorScheme.TabItemBorder = System.Drawing.Color.Empty;
            this.tcMsg.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(119)))), ((int)(((byte)(118))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(108)))), ((int)(((byte)(117))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(105)))), ((int)(((byte)(117))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(95)))), ((int)(((byte)(116))))), 1F)});
            this.tcMsg.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.WhiteSmoke;
            this.tcMsg.ColorScheme.TabItemSelectedBackground2 = System.Drawing.Color.WhiteSmoke;
            this.tcMsg.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(242))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(207))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(166))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(166))))), 1F)});
            this.tcMsg.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.Navy;
            this.tcMsg.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.Navy;
            this.tcMsg.ColorScheme.TabPanelBorder = System.Drawing.Color.Navy;
            this.tcMsg.Controls.Add(this.tabControlPanel1);
            this.tcMsg.Controls.Add(this.tabControlPanel2);
            this.tcMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMsg.Location = new System.Drawing.Point(0, 76);
            this.tcMsg.Name = "tcMsg";
            this.tcMsg.SelectedTabFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.tcMsg.SelectedTabIndex = 0;
            this.tcMsg.Size = new System.Drawing.Size(296, 510);
            this.tcMsg.Style = DevComponents.DotNetBar.eTabStripStyle.Office2003;
            this.tcMsg.TabIndex = 1;
            this.tcMsg.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcMsg.Tabs.Add(this.tpOrganize);
            this.tcMsg.Tabs.Add(this.tpRole);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.tvRole);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(296, 484);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.Navy;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tpRole;
            // 
            // tvRole
            // 
            this.tvRole.AllowDrop = true;
            this.tvRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRole.ImageIndex = 0;
            this.tvRole.ImageList = this.imageList;
            this.tvRole.Location = new System.Drawing.Point(1, 1);
            this.tvRole.Name = "tvRole";
            this.tvRole.SelectedImageIndex = 1;
            this.tvRole.Size = new System.Drawing.Size(294, 482);
            this.tvRole.TabIndex = 3;
            this.tvRole.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvRole.Click += new System.EventHandler(this.tvTree_Click);
            this.tvRole.DoubleClick += new System.EventHandler(this.tvTree_DoubleClick);
            this.tvRole.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTreeView_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.gif");
            this.imageList.Images.SetKeyName(1, "folderOpen.gif");
            this.imageList.Images.SetKeyName(2, "msg_02.ico");
            this.imageList.Images.SetKeyName(3, "msg_01.ico");
            this.imageList.Images.SetKeyName(4, "msg_03.ico");
            this.imageList.Images.SetKeyName(5, "msg_04.ico");
            this.imageList.Images.SetKeyName(6, "msg_05.ico");
            this.imageList.Images.SetKeyName(7, "msg_06.ico");
            this.imageList.Images.SetKeyName(8, "msg_07.ico");
            // 
            // tpRole
            // 
            this.tpRole.AttachedControl = this.tabControlPanel2;
            this.tpRole.Image = ((System.Drawing.Image)(resources.GetObject("tpRole.Image")));
            this.tpRole.Name = "tpRole";
            this.tpRole.Text = "角色";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.tvOrganize);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(296, 484);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.Navy;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tpOrganize;
            // 
            // tvOrganize
            // 
            this.tvOrganize.AllowDrop = true;
            this.tvOrganize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(1, 1);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 1;
            this.tvOrganize.Size = new System.Drawing.Size(294, 482);
            this.tvOrganize.TabIndex = 2;
            this.tvOrganize.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvOrganize_ItemDrag);
            this.tvOrganize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
            this.tvOrganize.Click += new System.EventHandler(this.tvTree_Click);
            this.tvOrganize.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragDrop);
            this.tvOrganize.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvOrganize_DragEnter);
            this.tvOrganize.DoubleClick += new System.EventHandler(this.tvTree_DoubleClick);
            this.tvOrganize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTreeView_MouseDown);
            // 
            // tpOrganize
            // 
            this.tpOrganize.AttachedControl = this.tabControlPanel1;
            this.tpOrganize.Image = ((System.Drawing.Image)(resources.GetObject("tpOrganize.Image")));
            this.tpOrganize.Name = "tpOrganize";
            this.tpOrganize.Text = "机构";
            this.tpOrganize.Tooltip = "组织机构";
            // 
            // statusMsg
            // 
            this.statusMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(201)))), ((int)(((byte)(247)))));
            this.statusMsg.Location = new System.Drawing.Point(0, 586);
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Size = new System.Drawing.Size(296, 22);
            this.statusMsg.TabIndex = 2;
            this.statusMsg.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(72, 17);
            this.lblStatusMsg.Text = "                ";
            // 
            // cMnuUser
            // 
            this.cMnuUser.Name = "cMnuUser";
            this.cMnuUser.Size = new System.Drawing.Size(61, 4);
            // 
            // timerFrmMsg
            // 
            this.timerFrmMsg.Enabled = true;
            this.timerFrmMsg.Tick += new System.EventHandler(this.timerFrmMsg_Tick);
            // 
            // FrmMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 608);
            this.Controls.Add(this.tcMsg);
            this.Controls.Add(this.statusMsg);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMsg";
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "企业通";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FrmMsg_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMsg_FormClosing);
            this.LocationChanged += new System.EventHandler(this.FrmMsg_LocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMsg_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMsg_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcMsg)).EndInit();
            this.tcMsg.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCurentUser;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.TabControl tcMsg;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tpOrganize;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tpRole;
        private System.Windows.Forms.StatusStrip statusMsg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMsg;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.TreeView tvRole;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip cMnuUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timerFrmMsg;
    }
}