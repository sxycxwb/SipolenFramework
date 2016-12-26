/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:11
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcEditToolManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcEditToolManage));
            this.tlsEditToolManage = new System.Windows.Forms.ToolStrip();
            this.lblDataTable = new System.Windows.Forms.ToolStripLabel();
            this.cboDataTable = new System.Windows.Forms.ToolStripComboBox();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSplit = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuShowRecordList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowRecordDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSplitShow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnBookList = new System.Windows.Forms.ToolStripButton();
            this.btnSoilInfo = new System.Windows.Forms.ToolStripButton();
            this.drpReceiveData = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnReceiveData1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReceiveData2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReceiveData3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tlsEditToolManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsEditToolManage
            // 
            this.tlsEditToolManage.BackColor = System.Drawing.Color.White;
            this.tlsEditToolManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlsEditToolManage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsEditToolManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDataTable,
            this.cboDataTable,
            this.btnEdit,
            this.btnAdd,
            this.btnSave,
            this.btnDelete,
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnSplit,
            this.btnExport,
            this.btnPrint,
            this.btnBookList,
            this.btnSoilInfo,
            this.drpReceiveData,
            this.toolStripSeparator2,
            this.btnClose});
            this.tlsEditToolManage.Location = new System.Drawing.Point(0, 0);
            this.tlsEditToolManage.Name = "tlsEditToolManage";
            this.tlsEditToolManage.Size = new System.Drawing.Size(635, 25);
            this.tlsEditToolManage.TabIndex = 1;
            // 
            // lblDataTable
            // 
            this.lblDataTable.Name = "lblDataTable";
            this.lblDataTable.Size = new System.Drawing.Size(44, 22);
            this.lblDataTable.Text = "数据表";
            this.lblDataTable.Visible = false;
            // 
            // cboDataTable
            // 
            this.cboDataTable.BackColor = System.Drawing.Color.FloralWhite;
            this.cboDataTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataTable.Items.AddRange(new object[] {
            "用地档案",
            "监察档案",
            "交易档案"});
            this.cboDataTable.Name = "cboDataTable";
            this.cboDataTable.Size = new System.Drawing.Size(121, 25);
            this.cboDataTable.Visible = false;
            this.cboDataTable.SelectedIndexChanged += new System.EventHandler(this.cboDataTable_SelectedIndexChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(74, 22);
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.ToolTipText = "单击修改相应数据";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 22);
            this.btnAdd.Text = "增加(&A)";
            this.btnAdd.ToolTipText = "单击增加相应数据";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 22);
            this.btnSave.Text = "保存(&S)";
            this.btnSave.ToolTipText = "单击保存相应数据";
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.ToolTipText = "单击删除相关数据";
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 22);
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.ToolTipText = "单击取消增加或修改的数据";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSplit
            // 
            this.btnSplit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowRecordList,
            this.mnuShowRecordDetail,
            this.mnuSplitShow});
            this.btnSplit.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(46, 22);
            this.btnSplit.Text = "分隔";
            // 
            // mnuShowRecordList
            // 
            this.mnuShowRecordList.Image = ((System.Drawing.Image)(resources.GetObject("mnuShowRecordList.Image")));
            this.mnuShowRecordList.Name = "mnuShowRecordList";
            this.mnuShowRecordList.Size = new System.Drawing.Size(178, 22);
            this.mnuShowRecordList.Text = "显示记录列表";
            this.mnuShowRecordList.Click += new System.EventHandler(this.MnuShowRecordListClick);
            // 
            // mnuShowRecordDetail
            // 
            this.mnuShowRecordDetail.Image = ((System.Drawing.Image)(resources.GetObject("mnuShowRecordDetail.Image")));
            this.mnuShowRecordDetail.Name = "mnuShowRecordDetail";
            this.mnuShowRecordDetail.Size = new System.Drawing.Size(178, 22);
            this.mnuShowRecordDetail.Text = "显示记录详细信息";
            this.mnuShowRecordDetail.Click += new System.EventHandler(this.MnuShowRecordDetailClick);
            // 
            // mnuSplitShow
            // 
            this.mnuSplitShow.Image = ((System.Drawing.Image)(resources.GetObject("mnuSplitShow.Image")));
            this.mnuSplitShow.Name = "mnuSplitShow";
            this.mnuSplitShow.Size = new System.Drawing.Size(178, 22);
            this.mnuSplitShow.Text = "分隔显示";
            this.mnuSplitShow.Click += new System.EventHandler(this.MnuSplitShowClick);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(53, 22);
            this.btnExport.Text = "导出";
            this.btnExport.Click += new System.EventHandler(this.BtnExportClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 22);
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
            // 
            // btnBookList
            // 
            this.btnBookList.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnBookList.Image = ((System.Drawing.Image)(resources.GetObject("btnBookList.Image")));
            this.btnBookList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBookList.Name = "btnBookList";
            this.btnBookList.Size = new System.Drawing.Size(53, 22);
            this.btnBookList.Text = "著录";
            this.btnBookList.Visible = false;
            this.btnBookList.Click += new System.EventHandler(this.btnBookList_Click);
            // 
            // btnSoilInfo
            // 
            this.btnSoilInfo.Font = new System.Drawing.Font("宋体", 9.75F);
            this.btnSoilInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnSoilInfo.Image")));
            this.btnSoilInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSoilInfo.Name = "btnSoilInfo";
            this.btnSoilInfo.Size = new System.Drawing.Size(53, 22);
            this.btnSoilInfo.Text = "著录";
            this.btnSoilInfo.Visible = false;
            this.btnSoilInfo.Click += new System.EventHandler(this.btnSoilInfo_Click);
            // 
            // drpReceiveData
            // 
            this.drpReceiveData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReceiveData1,
            this.btnReceiveData2,
            this.btnReceiveData3});
            this.drpReceiveData.Font = new System.Drawing.Font("宋体", 9.75F);
            this.drpReceiveData.Image = ((System.Drawing.Image)(resources.GetObject("drpReceiveData.Image")));
            this.drpReceiveData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drpReceiveData.Name = "drpReceiveData";
            this.drpReceiveData.Size = new System.Drawing.Size(88, 20);
            this.drpReceiveData.Text = "接收数据";
            this.drpReceiveData.ToolTipText = "接收其它地方的数据";
            this.drpReceiveData.Visible = false;
            // 
            // btnReceiveData1
            // 
            this.btnReceiveData1.Image = ((System.Drawing.Image)(resources.GetObject("btnReceiveData1.Image")));
            this.btnReceiveData1.Name = "btnReceiveData1";
            this.btnReceiveData1.Size = new System.Drawing.Size(204, 22);
            this.btnReceiveData1.Text = "集体土地登记数据";
            this.btnReceiveData1.Click += new System.EventHandler(this.btnReceiveData1_Click);
            // 
            // btnReceiveData2
            // 
            this.btnReceiveData2.Image = ((System.Drawing.Image)(resources.GetObject("btnReceiveData2.Image")));
            this.btnReceiveData2.Name = "btnReceiveData2";
            this.btnReceiveData2.Size = new System.Drawing.Size(204, 22);
            this.btnReceiveData2.Text = "土地登记属性数据";
            this.btnReceiveData2.Click += new System.EventHandler(this.btnReceiveData2_Click);
            // 
            // btnReceiveData3
            // 
            this.btnReceiveData3.Image = ((System.Drawing.Image)(resources.GetObject("btnReceiveData3.Image")));
            this.btnReceiveData3.Name = "btnReceiveData3";
            this.btnReceiveData3.Size = new System.Drawing.Size(204, 22);
            this.btnReceiveData3.Text = "土地分割登记属性数据";
            this.btnReceiveData3.Click += new System.EventHandler(this.btnReceiveData3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 22);
            this.btnClose.Text = "关闭(&Q)";
            this.btnClose.ToolTipText = "单击关闭当前窗口";
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // UcEditToolManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlsEditToolManage);
            this.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UcEditToolManage";
            this.Size = new System.Drawing.Size(635, 25);
            this.Load += new System.EventHandler(this.UcEditToolManage_Load);
            this.tlsEditToolManage.ResumeLayout(false);
            this.tlsEditToolManage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsEditToolManage;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btnSplit;
        private System.Windows.Forms.ToolStripMenuItem mnuShowRecordList;
        private System.Windows.Forms.ToolStripMenuItem mnuShowRecordDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuSplitShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnSoilInfo;
        private System.Windows.Forms.ToolStripButton btnBookList;
        private System.Windows.Forms.ToolStripComboBox cboDataTable;
        private System.Windows.Forms.ToolStripLabel lblDataTable;
        private System.Windows.Forms.ToolStripDropDownButton drpReceiveData;
        private System.Windows.Forms.ToolStripMenuItem btnReceiveData1;
        private System.Windows.Forms.ToolStripMenuItem btnReceiveData2;
        private System.Windows.Forms.ToolStripMenuItem btnReceiveData3;

    }
}
