namespace RDIFramework.Test
{
    partial class ReportCommonTool
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ProductInfoEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ProductInfoEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductInfoEntityBindingSource
            // 
            this.ProductInfoEntityBindingSource.DataSource = typeof(RDIFramework.Test.ProductInfoEntity);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsProductInfo";
            reportDataSource1.Value = this.ProductInfoEntityBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "RDIFramework.Test.Report.ProductInfo.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1080, 656);
            this.reportViewer2.TabIndex = 0;
            // 
            // ReportCommonTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 656);
            this.Controls.Add(this.reportViewer2);
            this.Name = "ReportCommonTool";
            this.Text = "打印窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fm_Report_FormClosing);
            this.Load += new System.EventHandler(this.ReportCommonTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductInfoEntityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.BindingSource ProductInfoEntityBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}

