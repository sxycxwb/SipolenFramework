namespace RDIFramework.CodeMaker
{
    partial class DataObjectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkTypeLink = new System.Windows.Forms.CheckBox();
            this.txtTableDescription = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPDefine = new System.Windows.Forms.TabPage();
            this.dgvDefine = new System.Windows.Forms.DataGridView();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDTColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDTDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDTDataLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDTDataPreci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDTDataScale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDTDataNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDTDataPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDTDataIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDTDataDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPDDL = new System.Windows.Forms.TabPage();
            this.textEditorDDL = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPStorageTable = new System.Windows.Forms.TabPage();
            this.codeEditorStorageTable = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPEntity = new System.Windows.Forms.TabPage();
            this.textEditorEntity = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPMvcEntity = new System.Windows.Forms.TabPage();
            this.textEditorMvcEntity = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPIService = new System.Windows.Forms.TabPage();
            this.codeEditorIService = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPService = new System.Windows.Forms.TabPage();
            this.codeEditorService = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabPManager = new System.Windows.Forms.TabPage();
            this.codeEditorManager = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.tabGengerateDbScript = new System.Windows.Forms.TabPage();
            this.tabPDoc = new System.Windows.Forms.TabPage();
            this.wbDoc = new System.Windows.Forms.WebBrowser();
            this.codeGengerateDbScript = new RDIFramework.CodeMaker.CodeEditorControlEx();
            this.panel1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPDefine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefine)).BeginInit();
            this.tabPDDL.SuspendLayout();
            this.tabPStorageTable.SuspendLayout();
            this.tabPEntity.SuspendLayout();
            this.tabPMvcEntity.SuspendLayout();
            this.tabPIService.SuspendLayout();
            this.tabPService.SuspendLayout();
            this.tabPManager.SuspendLayout();
            this.tabGengerateDbScript.SuspendLayout();
            this.tabPDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkTypeLink);
            this.panel1.Controls.Add(this.txtTableDescription);
            this.panel1.Controls.Add(this.txtTableName);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 76);
            this.panel1.TabIndex = 0;
            // 
            // chkTypeLink
            // 
            this.chkTypeLink.AutoSize = true;
            this.chkTypeLink.Checked = true;
            this.chkTypeLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTypeLink.Location = new System.Drawing.Point(301, 13);
            this.chkTypeLink.Name = "chkTypeLink";
            this.chkTypeLink.Size = new System.Drawing.Size(180, 16);
            this.chkTypeLink.TabIndex = 6;
            this.chkTypeLink.Text = "类型联动（数据类型->类型）";
            this.chkTypeLink.UseVisualStyleBackColor = true;
            // 
            // txtTableDescription
            // 
            this.txtTableDescription.Location = new System.Drawing.Point(388, 42);
            this.txtTableDescription.Name = "txtTableDescription";
            this.txtTableDescription.Size = new System.Drawing.Size(397, 21);
            this.txtTableDescription.TabIndex = 5;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(64, 43);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(218, 21);
            this.txtTableName.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(64, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 21);
            this.txtName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "中文名称/说明：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据表：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名  称：";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPDefine);
            this.tabControlMain.Controls.Add(this.tabPDDL);
            this.tabControlMain.Controls.Add(this.tabPStorageTable);
            this.tabControlMain.Controls.Add(this.tabPEntity);
            this.tabControlMain.Controls.Add(this.tabPMvcEntity);
            this.tabControlMain.Controls.Add(this.tabPIService);
            this.tabControlMain.Controls.Add(this.tabPService);
            this.tabControlMain.Controls.Add(this.tabPManager);
            this.tabControlMain.Controls.Add(this.tabGengerateDbScript);
            this.tabControlMain.Controls.Add(this.tabPDoc);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 76);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(932, 569);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPDefine
            // 
            this.tabPDefine.Controls.Add(this.dgvDefine);
            this.tabPDefine.Location = new System.Drawing.Point(4, 21);
            this.tabPDefine.Name = "tabPDefine";
            this.tabPDefine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPDefine.Size = new System.Drawing.Size(924, 544);
            this.tabPDefine.TabIndex = 0;
            this.tabPDefine.Text = "定义";
            this.tabPDefine.UseVisualStyleBackColor = true;
            // 
            // dgvDefine
            // 
            this.dgvDefine.AllowUserToDeleteRows = false;
            this.dgvDefine.AllowUserToOrderColumns = true;
            this.dgvDefine.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDefine.ColumnHeadersHeight = 28;
            this.dgvDefine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeName,
            this.colId,
            this.colAttribute,
            this.colType,
            this.colTitle,
            this.colDTColumnName,
            this.colDTDataType,
            this.colDTDataLength,
            this.colDTDataPreci,
            this.colDTDataScale,
            this.colDTDataNull,
            this.colDTDataPrimaryKey,
            this.colDTDataIdentity,
            this.colDTDataDefaultValue});
            this.dgvDefine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefine.Location = new System.Drawing.Point(3, 3);
            this.dgvDefine.Name = "dgvDefine";
            this.dgvDefine.RowHeadersWidth = 30;
            this.dgvDefine.RowTemplate.Height = 23;
            this.dgvDefine.Size = new System.Drawing.Size(918, 538);
            this.dgvDefine.TabIndex = 1;
            this.dgvDefine.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDefine_CellValueChanged);
            this.dgvDefine.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDefine_DataBindingComplete);
            this.dgvDefine.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDefine_DataError);
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.Frozen = true;
            this.TypeName.HeaderText = "TypeName";
            this.TypeName.Name = "TypeName";
            this.TypeName.Visible = false;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ColOrder";
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            this.colId.DefaultCellStyle = dataGridViewCellStyle5;
            this.colId.Frozen = true;
            this.colId.HeaderText = "序号";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 35;
            // 
            // colAttribute
            // 
            this.colAttribute.DataPropertyName = "ColumnName";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Wheat;
            this.colAttribute.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAttribute.Frozen = true;
            this.colAttribute.HeaderText = "属性名称";
            this.colAttribute.Name = "colAttribute";
            this.colAttribute.Width = 130;
            // 
            // colType
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Wheat;
            this.colType.DefaultCellStyle = dataGridViewCellStyle7;
            this.colType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colType.HeaderText = "类型";
            this.colType.Name = "colType";
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colType.Width = 130;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "ColDescription";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Wheat;
            this.colTitle.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTitle.HeaderText = "标题";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 130;
            // 
            // colDTColumnName
            // 
            this.colDTColumnName.DataPropertyName = "ColumnName";
            this.colDTColumnName.HeaderText = "列名";
            this.colDTColumnName.Name = "colDTColumnName";
            this.colDTColumnName.Width = 130;
            // 
            // colDTDataType
            // 
            this.colDTDataType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colDTDataType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colDTDataType.HeaderText = "数据类型";
            this.colDTDataType.Name = "colDTDataType";
            this.colDTDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDTDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDTDataType.Width = 130;
            // 
            // colDTDataLength
            // 
            this.colDTDataLength.DataPropertyName = "Length";
            this.colDTDataLength.HeaderText = "长度";
            this.colDTDataLength.Name = "colDTDataLength";
            this.colDTDataLength.Width = 45;
            // 
            // colDTDataPreci
            // 
            this.colDTDataPreci.DataPropertyName = "Preci";
            this.colDTDataPreci.HeaderText = "精度";
            this.colDTDataPreci.Name = "colDTDataPreci";
            this.colDTDataPreci.Width = 45;
            // 
            // colDTDataScale
            // 
            this.colDTDataScale.DataPropertyName = "Scale";
            this.colDTDataScale.HeaderText = "小数位数";
            this.colDTDataScale.Name = "colDTDataScale";
            this.colDTDataScale.Width = 60;
            // 
            // colDTDataNull
            // 
            this.colDTDataNull.DataPropertyName = "IsNull";
            this.colDTDataNull.HeaderText = "非空";
            this.colDTDataNull.Name = "colDTDataNull";
            this.colDTDataNull.Width = 40;
            // 
            // colDTDataPrimaryKey
            // 
            this.colDTDataPrimaryKey.DataPropertyName = "IsPK";
            this.colDTDataPrimaryKey.HeaderText = "主键";
            this.colDTDataPrimaryKey.Name = "colDTDataPrimaryKey";
            this.colDTDataPrimaryKey.Width = 40;
            // 
            // colDTDataIdentity
            // 
            this.colDTDataIdentity.DataPropertyName = "IsIdentity";
            this.colDTDataIdentity.HeaderText = "自增";
            this.colDTDataIdentity.Name = "colDTDataIdentity";
            this.colDTDataIdentity.Width = 40;
            // 
            // colDTDataDefaultValue
            // 
            this.colDTDataDefaultValue.DataPropertyName = "DefaultVal";
            this.colDTDataDefaultValue.HeaderText = "默认值";
            this.colDTDataDefaultValue.Name = "colDTDataDefaultValue";
            this.colDTDataDefaultValue.Width = 300;
            // 
            // tabPDDL
            // 
            this.tabPDDL.Controls.Add(this.textEditorDDL);
            this.tabPDDL.Location = new System.Drawing.Point(4, 21);
            this.tabPDDL.Name = "tabPDDL";
            this.tabPDDL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPDDL.Size = new System.Drawing.Size(924, 544);
            this.tabPDDL.TabIndex = 2;
            this.tabPDDL.Text = "DDL";
            this.tabPDDL.UseVisualStyleBackColor = true;
            // 
            // textEditorDDL
            // 
            this.textEditorDDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorDDL.Location = new System.Drawing.Point(3, 3);
            this.textEditorDDL.Name = "textEditorDDL";
            this.textEditorDDL.SaveFileName = "";
            this.textEditorDDL.Size = new System.Drawing.Size(918, 537);
            this.textEditorDDL.TabIndex = 2;
            // 
            // tabPStorageTable
            // 
            this.tabPStorageTable.Controls.Add(this.codeEditorStorageTable);
            this.tabPStorageTable.Location = new System.Drawing.Point(4, 21);
            this.tabPStorageTable.Name = "tabPStorageTable";
            this.tabPStorageTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabPStorageTable.Size = new System.Drawing.Size(924, 544);
            this.tabPStorageTable.TabIndex = 4;
            this.tabPStorageTable.Text = "类数据表";
            this.tabPStorageTable.UseVisualStyleBackColor = true;
            // 
            // codeEditorStorageTable
            // 
            this.codeEditorStorageTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorStorageTable.Location = new System.Drawing.Point(3, 3);
            this.codeEditorStorageTable.Name = "codeEditorStorageTable";
            this.codeEditorStorageTable.SaveFileName = "";
            this.codeEditorStorageTable.Size = new System.Drawing.Size(918, 538);
            this.codeEditorStorageTable.TabIndex = 4;
            // 
            // tabPEntity
            // 
            this.tabPEntity.Controls.Add(this.textEditorEntity);
            this.tabPEntity.Location = new System.Drawing.Point(4, 21);
            this.tabPEntity.Name = "tabPEntity";
            this.tabPEntity.Padding = new System.Windows.Forms.Padding(3);
            this.tabPEntity.Size = new System.Drawing.Size(924, 544);
            this.tabPEntity.TabIndex = 1;
            this.tabPEntity.Text = "业务实体（Entity）";
            this.tabPEntity.UseVisualStyleBackColor = true;
            // 
            // textEditorEntity
            // 
            this.textEditorEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorEntity.Location = new System.Drawing.Point(3, 3);
            this.textEditorEntity.Name = "textEditorEntity";
            this.textEditorEntity.SaveFileName = "";
            this.textEditorEntity.Size = new System.Drawing.Size(918, 538);
            this.textEditorEntity.TabIndex = 3;
            // 
            // tabPMvcEntity
            // 
            this.tabPMvcEntity.Controls.Add(this.textEditorMvcEntity);
            this.tabPMvcEntity.Location = new System.Drawing.Point(4, 21);
            this.tabPMvcEntity.Name = "tabPMvcEntity";
            this.tabPMvcEntity.Padding = new System.Windows.Forms.Padding(3);
            this.tabPMvcEntity.Size = new System.Drawing.Size(924, 544);
            this.tabPMvcEntity.TabIndex = 8;
            this.tabPMvcEntity.Text = "MVC实体";
            this.tabPMvcEntity.UseVisualStyleBackColor = true;
            // 
            // textEditorMvcEntity
            // 
            this.textEditorMvcEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorMvcEntity.Location = new System.Drawing.Point(3, 3);
            this.textEditorMvcEntity.Name = "textEditorMvcEntity";
            this.textEditorMvcEntity.SaveFileName = "";
            this.textEditorMvcEntity.Size = new System.Drawing.Size(918, 538);
            this.textEditorMvcEntity.TabIndex = 4;
            // 
            // tabPIService
            // 
            this.tabPIService.Controls.Add(this.codeEditorIService);
            this.tabPIService.Location = new System.Drawing.Point(4, 21);
            this.tabPIService.Name = "tabPIService";
            this.tabPIService.Size = new System.Drawing.Size(924, 544);
            this.tabPIService.TabIndex = 6;
            this.tabPIService.Text = "契约服务接口（WCF服务接口）";
            this.tabPIService.UseVisualStyleBackColor = true;
            // 
            // codeEditorIService
            // 
            this.codeEditorIService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorIService.Location = new System.Drawing.Point(0, 0);
            this.codeEditorIService.Name = "codeEditorIService";
            this.codeEditorIService.SaveFileName = "";
            this.codeEditorIService.Size = new System.Drawing.Size(924, 544);
            this.codeEditorIService.TabIndex = 5;
            // 
            // tabPService
            // 
            this.tabPService.Controls.Add(this.codeEditorService);
            this.tabPService.Location = new System.Drawing.Point(4, 21);
            this.tabPService.Name = "tabPService";
            this.tabPService.Size = new System.Drawing.Size(924, 544);
            this.tabPService.TabIndex = 7;
            this.tabPService.Text = "契约服务（WCF服务实现）";
            this.tabPService.UseVisualStyleBackColor = true;
            // 
            // codeEditorService
            // 
            this.codeEditorService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorService.Location = new System.Drawing.Point(0, 0);
            this.codeEditorService.Name = "codeEditorService";
            this.codeEditorService.SaveFileName = "";
            this.codeEditorService.Size = new System.Drawing.Size(924, 544);
            this.codeEditorService.TabIndex = 5;
            // 
            // tabPManager
            // 
            this.tabPManager.Controls.Add(this.codeEditorManager);
            this.tabPManager.Location = new System.Drawing.Point(4, 21);
            this.tabPManager.Name = "tabPManager";
            this.tabPManager.Size = new System.Drawing.Size(924, 544);
            this.tabPManager.TabIndex = 5;
            this.tabPManager.Text = "服务管理器";
            this.tabPManager.UseVisualStyleBackColor = true;
            // 
            // codeEditorManager
            // 
            this.codeEditorManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditorManager.Location = new System.Drawing.Point(0, 0);
            this.codeEditorManager.Name = "codeEditorManager";
            this.codeEditorManager.SaveFileName = "";
            this.codeEditorManager.Size = new System.Drawing.Size(924, 544);
            this.codeEditorManager.TabIndex = 4;
            // 
            // tabGengerateDbScript
            // 
            this.tabGengerateDbScript.Controls.Add(this.codeGengerateDbScript);
            this.tabGengerateDbScript.Location = new System.Drawing.Point(4, 21);
            this.tabGengerateDbScript.Name = "tabGengerateDbScript";
            this.tabGengerateDbScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabGengerateDbScript.Size = new System.Drawing.Size(924, 544);
            this.tabGengerateDbScript.TabIndex = 9;
            this.tabGengerateDbScript.Text = "数据库脚本";
            this.tabGengerateDbScript.UseVisualStyleBackColor = true;
            // 
            // tabPDoc
            // 
            this.tabPDoc.Controls.Add(this.wbDoc);
            this.tabPDoc.Location = new System.Drawing.Point(4, 21);
            this.tabPDoc.Name = "tabPDoc";
            this.tabPDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPDoc.Size = new System.Drawing.Size(924, 544);
            this.tabPDoc.TabIndex = 3;
            this.tabPDoc.Text = "文档";
            this.tabPDoc.UseVisualStyleBackColor = true;
            // 
            // wbDoc
            // 
            this.wbDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbDoc.Location = new System.Drawing.Point(3, 3);
            this.wbDoc.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDoc.Name = "wbDoc";
            this.wbDoc.Size = new System.Drawing.Size(918, 538);
            this.wbDoc.TabIndex = 0;
            // 
            // codeGengerateDbScript
            // 
            this.codeGengerateDbScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeGengerateDbScript.Location = new System.Drawing.Point(3, 3);
            this.codeGengerateDbScript.Name = "codeGengerateDbScript";
            this.codeGengerateDbScript.SaveFileName = "";
            this.codeGengerateDbScript.Size = new System.Drawing.Size(918, 538);
            this.codeGengerateDbScript.TabIndex = 5;
            // 
            // DataObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 645);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "DataObjectForm";
            this.Text = "数据对象设计器";
            this.Shown += new System.EventHandler(this.DataObjectForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPDefine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefine)).EndInit();
            this.tabPDDL.ResumeLayout(false);
            this.tabPStorageTable.ResumeLayout(false);
            this.tabPEntity.ResumeLayout(false);
            this.tabPMvcEntity.ResumeLayout(false);
            this.tabPIService.ResumeLayout(false);
            this.tabPService.ResumeLayout(false);
            this.tabPManager.ResumeLayout(false);
            this.tabGengerateDbScript.ResumeLayout(false);
            this.tabPDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPDefine;
        private System.Windows.Forms.TabPage tabPEntity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableDescription;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage tabPDDL;
        private System.Windows.Forms.TabPage tabPDoc;
        private System.Windows.Forms.DataGridView dgvDefine;
        private System.Windows.Forms.WebBrowser wbDoc;
        private System.Windows.Forms.CheckBox chkTypeLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttribute;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDTColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDTDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDTDataLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDTDataPreci;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDTDataScale;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDTDataNull;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDTDataPrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDTDataIdentity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDTDataDefaultValue;
        public CodeEditorControlEx textEditorDDL;
        public CodeEditorControlEx textEditorEntity;
        private System.Windows.Forms.TabPage tabPStorageTable;
        public CodeEditorControlEx codeEditorStorageTable;
        private System.Windows.Forms.TabPage tabPManager;
        public CodeEditorControlEx codeEditorManager;
        private System.Windows.Forms.TabPage tabPIService;
        private System.Windows.Forms.TabPage tabPService;
        public CodeEditorControlEx codeEditorIService;
        public CodeEditorControlEx codeEditorService;
        private System.Windows.Forms.TabPage tabPMvcEntity;
        public CodeEditorControlEx textEditorMvcEntity;
        private System.Windows.Forms.TabPage tabGengerateDbScript;
        public CodeEditorControlEx codeGengerateDbScript;
    }
}