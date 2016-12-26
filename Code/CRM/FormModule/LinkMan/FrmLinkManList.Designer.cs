namespace CRM
{
    partial class FrmLinkManList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlsLinkManList = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.dropDownLinkManSaveAs = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnExportLinkManToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportLinkManToWordpad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvLinkMain = new RDIFramework.Controls.UcDataGridView();
            this.colLinkManId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPostion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobilePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOfficeFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMajor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEducationalBackground = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMainLinkMan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsLinkManList.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsLinkManList
            // 
            this.tlsLinkManList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtSearch,
            this.toolStripSeparator1,
            this.btnFind,
            this.dropDownLinkManSaveAs,
            this.toolStripSeparator3,
            this.btnClose});
            this.tlsLinkManList.Location = new System.Drawing.Point(0, 0);
            this.tlsLinkManList.Name = "tlsLinkManList";
            this.tlsLinkManList.Size = new System.Drawing.Size(817, 25);
            this.tlsLinkManList.TabIndex = 1;
            this.tlsLinkManList.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel1.Text = "查找关键字：";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 25);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::CRM.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(67, 22);
            this.btnFind.Text = "查找(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dropDownLinkManSaveAs
            // 
            this.dropDownLinkManSaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExportLinkManToExcel,
            this.btnExportLinkManToTxt,
            this.btnExportLinkManToCSV,
            this.btnExportLinkManToHTML,
            this.btnExportLinkManToWordpad});
            this.dropDownLinkManSaveAs.Image = global::CRM.Properties.Resources.saveAs;
            this.dropDownLinkManSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropDownLinkManSaveAs.Name = "dropDownLinkManSaveAs";
            this.dropDownLinkManSaveAs.Size = new System.Drawing.Size(70, 22);
            this.dropDownLinkManSaveAs.Text = "另存为";
            // 
            // btnExportLinkManToExcel
            // 
            this.btnExportLinkManToExcel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportLinkManToExcel.Name = "btnExportLinkManToExcel";
            this.btnExportLinkManToExcel.Size = new System.Drawing.Size(235, 22);
            this.btnExportLinkManToExcel.Text = "Microsoft Excel工作薄[1]";
            this.btnExportLinkManToExcel.Click += new System.EventHandler(this.btnExportLinkManToExcel_Click);
            // 
            // btnExportLinkManToTxt
            // 
            this.btnExportLinkManToTxt.Name = "btnExportLinkManToTxt";
            this.btnExportLinkManToTxt.Size = new System.Drawing.Size(235, 22);
            this.btnExportLinkManToTxt.Text = "文本文件[2]";
            this.btnExportLinkManToTxt.Click += new System.EventHandler(this.btnExportLinkManToTxt_Click);
            // 
            // btnExportLinkManToCSV
            // 
            this.btnExportLinkManToCSV.Name = "btnExportLinkManToCSV";
            this.btnExportLinkManToCSV.Size = new System.Drawing.Size(235, 22);
            this.btnExportLinkManToCSV.Text = "CSV格式文件[3]";
            this.btnExportLinkManToCSV.Click += new System.EventHandler(this.btnExportLinkManToExcel_Click);
            // 
            // btnExportLinkManToHTML
            // 
            this.btnExportLinkManToHTML.Name = "btnExportLinkManToHTML";
            this.btnExportLinkManToHTML.Size = new System.Drawing.Size(235, 22);
            this.btnExportLinkManToHTML.Text = "网页文件[4]";
            // 
            // btnExportLinkManToWordpad
            // 
            this.btnExportLinkManToWordpad.Name = "btnExportLinkManToWordpad";
            this.btnExportLinkManToWordpad.Size = new System.Drawing.Size(235, 22);
            this.btnExportLinkManToWordpad.Text = "写字板文件[5]";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CRM.Properties.Resources.close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvLinkMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(817, 578);
            this.pnlMain.TabIndex = 2;
            // 
            // dgvLinkMain
            // 
            this.dgvLinkMain.AllowUserToAddRows = false;
            this.dgvLinkMain.AllowUserToDeleteRows = false;
            this.dgvLinkMain.AllowUserToOrderColumns = true;
            this.dgvLinkMain.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLinkMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinkMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLinkMain.ColumnHeadersHeight = 26;
            this.dgvLinkMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLinkMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLinkManId,
            this.CustomerId,
            this.colShortName,
            this.colCompanyName,
            this.colName,
            this.colSex,
            this.colDepartment,
            this.colPostion,
            this.colTelephone,
            this.colMobilePhone,
            this.colOfficeFax,
            this.colEmail,
            this.colQQ,
            this.colBirthday,
            this.colMajor,
            this.colEducationalBackground,
            this.colInterest,
            this.colMainLinkMan,
            this.colEnabled,
            this.colDescription});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLinkMain.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLinkMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLinkMain.EnableHeadersVisualStyles = false;
            this.dgvLinkMain.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvLinkMain.Location = new System.Drawing.Point(0, 0);
            this.dgvLinkMain.Name = "dgvLinkMain";
            this.dgvLinkMain.ReadOnly = true;
            this.dgvLinkMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinkMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLinkMain.RowHeadersWidth = 30;
            this.dgvLinkMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLinkMain.RowTemplate.Height = 23;
            this.dgvLinkMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinkMain.Size = new System.Drawing.Size(817, 578);
            this.dgvLinkMain.TabIndex = 2;
            // 
            // colLinkManId
            // 
            this.colLinkManId.DataPropertyName = "Id";
            this.colLinkManId.Frozen = true;
            this.colLinkManId.HeaderText = "Id";
            this.colLinkManId.Name = "colLinkManId";
            this.colLinkManId.ReadOnly = true;
            this.colLinkManId.Visible = false;
            this.colLinkManId.Width = 75;
            // 
            // CustomerId
            // 
            this.CustomerId.Frozen = true;
            this.CustomerId.HeaderText = "CustomerId";
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            // 
            // colShortName
            // 
            this.colShortName.DataPropertyName = "ShortName";
            this.colShortName.Frozen = true;
            this.colShortName.HeaderText = "客户简称";
            this.colShortName.Name = "colShortName";
            this.colShortName.ReadOnly = true;
            // 
            // colCompanyName
            // 
            this.colCompanyName.DataPropertyName = "CompanyName";
            this.colCompanyName.Frozen = true;
            this.colCompanyName.HeaderText = "公司名称";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.ReadOnly = true;
            this.colCompanyName.Width = 200;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.Frozen = true;
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colSex
            // 
            this.colSex.DataPropertyName = "Sex";
            this.colSex.Frozen = true;
            this.colSex.HeaderText = "性别";
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Width = 50;
            // 
            // colDepartment
            // 
            this.colDepartment.DataPropertyName = "Department";
            this.colDepartment.Frozen = true;
            this.colDepartment.HeaderText = "部门";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            this.colDepartment.Width = 120;
            // 
            // colPostion
            // 
            this.colPostion.DataPropertyName = "Postion";
            this.colPostion.Frozen = true;
            this.colPostion.HeaderText = "职位";
            this.colPostion.Name = "colPostion";
            this.colPostion.ReadOnly = true;
            this.colPostion.Width = 120;
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            this.colTelephone.HeaderText = "办公电话";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.ReadOnly = true;
            this.colTelephone.Width = 120;
            // 
            // colMobilePhone
            // 
            this.colMobilePhone.DataPropertyName = "MobilePhone";
            this.colMobilePhone.HeaderText = "手机";
            this.colMobilePhone.Name = "colMobilePhone";
            this.colMobilePhone.ReadOnly = true;
            this.colMobilePhone.Width = 120;
            // 
            // colOfficeFax
            // 
            this.colOfficeFax.DataPropertyName = "OfficeFax";
            this.colOfficeFax.HeaderText = "传真";
            this.colOfficeFax.Name = "colOfficeFax";
            this.colOfficeFax.ReadOnly = true;
            this.colOfficeFax.Width = 120;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "邮箱";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 130;
            // 
            // colQQ
            // 
            this.colQQ.DataPropertyName = "QQ";
            this.colQQ.HeaderText = "QQ";
            this.colQQ.Name = "colQQ";
            this.colQQ.ReadOnly = true;
            // 
            // colBirthday
            // 
            this.colBirthday.DataPropertyName = "Birthday";
            this.colBirthday.HeaderText = "生日";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.ReadOnly = true;
            // 
            // colMajor
            // 
            this.colMajor.DataPropertyName = "Major";
            this.colMajor.HeaderText = "专业";
            this.colMajor.Name = "colMajor";
            this.colMajor.ReadOnly = true;
            this.colMajor.Width = 120;
            // 
            // colEducationalBackground
            // 
            this.colEducationalBackground.DataPropertyName = "EducationalBackground";
            this.colEducationalBackground.HeaderText = "学历";
            this.colEducationalBackground.Name = "colEducationalBackground";
            this.colEducationalBackground.ReadOnly = true;
            // 
            // colInterest
            // 
            this.colInterest.DataPropertyName = "Interest";
            this.colInterest.HeaderText = "兴趣";
            this.colInterest.Name = "colInterest";
            this.colInterest.ReadOnly = true;
            // 
            // colMainLinkMan
            // 
            this.colMainLinkMan.DataPropertyName = "MainLinkMan";
            this.colMainLinkMan.HeaderText = "主联系人";
            this.colMainLinkMan.Name = "colMainLinkMan";
            this.colMainLinkMan.ReadOnly = true;
            this.colMainLinkMan.Width = 70;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.Width = 45;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "备注/描述";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.Width = 300;
            // 
            // FrmLinkManList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 603);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsLinkManList);
            this.Name = "FrmLinkManList";
            this.Text = "联系人列表";
            this.tlsLinkManList.ResumeLayout(false);
            this.tlsLinkManList.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinkMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsLinkManList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton dropDownLinkManSaveAs;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToExcel;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToTxt;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToCSV;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToHTML;
        private System.Windows.Forms.ToolStripMenuItem btnExportLinkManToWordpad;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel pnlMain;
        private RDIFramework.Controls.UcDataGridView dgvLinkMain;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinkManId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPostion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobilePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOfficeFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMajor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEducationalBackground;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterest;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMainLinkMan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}