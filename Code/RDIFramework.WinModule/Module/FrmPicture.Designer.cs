/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 16:51:21
 ******************************************************************************/
namespace RDIFramework.WinModule
{
    partial class FrmPicture
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ucImageList = new RDIFramework.Controls.UcImageList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnCancel = new RDIFramework.Controls.UcButton();
            this.pnlBottomLeft = new System.Windows.Forms.Panel();
            this.ucImageView = new RDIFramework.Controls.UcImageView();
            this.lblCurrentIcon = new System.Windows.Forms.Label();
            this.btnDelete = new RDIFramework.Controls.UcButton();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.btnSelect = new RDIFramework.Controls.UcButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ucImageList);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(592, 513);
            this.pnlMain.TabIndex = 0;
            // 
            // ucImageList
            // 
            this.ucImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageList.Location = new System.Drawing.Point(0, 0);
            this.ucImageList.Name = "ucImageList";
            this.ucImageList.Size = new System.Drawing.Size(592, 476);
            this.ucImageList.TabIndex = 3;
            this.ucImageList.MouseDoubleClick += new System.EventHandler(this.ucImageList_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucPager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 37);
            this.panel1.TabIndex = 4;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(74, 7);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 56;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(515, 23);
            this.ucPager.TabIndex = 2;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPager_PageChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblSize);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.pnlBottomLeft);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Controls.Add(this.btnSelect);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(592, 74);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblSize
            // 
            this.lblSize.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSize.ForeColor = System.Drawing.Color.OliveDrab;
            this.lblSize.Location = new System.Drawing.Point(217, 24);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(58, 41);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "尺寸：32x32";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(510, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlBottomLeft
            // 
            this.pnlBottomLeft.Controls.Add(this.ucImageView);
            this.pnlBottomLeft.Controls.Add(this.lblCurrentIcon);
            this.pnlBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlBottomLeft.Name = "pnlBottomLeft";
            this.pnlBottomLeft.Size = new System.Drawing.Size(211, 74);
            this.pnlBottomLeft.TabIndex = 3;
            // 
            // ucImageView
            // 
            this.ucImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImageView.Location = new System.Drawing.Point(23, 0);
            this.ucImageView.MnuMoveImageChecked = false;
            this.ucImageView.MnuPrintVisible = true;
            this.ucImageView.Name = "ucImageView";
            this.ucImageView.Size = new System.Drawing.Size(188, 74);
            this.ucImageView.TabIndex = 1;
            // 
            // lblCurrentIcon
            // 
            this.lblCurrentIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCurrentIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentIcon.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentIcon.Name = "lblCurrentIcon";
            this.lblCurrentIcon.Size = new System.Drawing.Size(23, 74);
            this.lblCurrentIcon.TabIndex = 0;
            this.lblCurrentIcon.Text = "当前图标";
            this.lblCurrentIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(449, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 23);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(367, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(286, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(71, 23);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "选择(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files(*.jpg;*.jpeg;*.tiff;*.gif)|*.jpg;*.gpeg;*.tiff;*.gif|All files (*.*)|" +
    "*.*";
            this.openFileDialog.Multiselect = true;
            // 
            // FrmPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 587);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmPicture";
            this.Text = "模块图标选择";
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
        private Controls.UcButton btnSelect;
        private Controls.UcButton btnDelete;
        private Controls.UcButton btnAdd;
        private System.Windows.Forms.Panel pnlBottomLeft;
        private System.Windows.Forms.Label lblCurrentIcon;
        private Controls.UcImageView ucImageView;
        private Controls.UcButton btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Controls.UcImageList ucImageList;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcPagerEx ucPager;
    }
}