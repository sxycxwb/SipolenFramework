namespace RDIFramework.Test
{
    partial class FrmTestDgvSummary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProductInfo = new RDIFramework.Controls.DataGridViewSummary();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucPager = new RDIFramework.Controls.UcPagerEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductInfo.DisplaySumRowHeader = true;
            this.dgvProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvProductInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductInfo.Size = new System.Drawing.Size(873, 555);
            this.dgvProductInfo.SummaryColumns = new string[] {
        "PRODUCTPRICE",
        "MIDDLERATE",
        "REFERENCECOEFFICIENT"};
            this.dgvProductInfo.SummaryRowBackColor = System.Drawing.Color.White;
            this.dgvProductInfo.SummaryRowSpace = 0;
            this.dgvProductInfo.SummaryRowVisible = true;
            this.dgvProductInfo.SumRowHeaderText = "统计";
            this.dgvProductInfo.SumRowHeaderTextBold = true;
            this.dgvProductInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucPager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 23);
            this.panel1.TabIndex = 2;
            // 
            // ucPager
            // 
            this.ucPager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPager.Location = new System.Drawing.Point(360, 0);
            this.ucPager.Name = "ucPager";
            this.ucPager.PageIndex = 1;
            this.ucPager.PageSize = 50;
            this.ucPager.RecordCount = 0;
            this.ucPager.Size = new System.Drawing.Size(511, 23);
            this.ucPager.TabIndex = 2;
            this.ucPager.PageChanged += new RDIFramework.Controls.PageChangedEventHandler(this.ucPagerEx1_PageChanged);
            // 
            // FrmTestDgvSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 578);
            this.Controls.Add(this.dgvProductInfo);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTestDgvSummary";
            this.Text = "DataGridView带合计与分页";
            this.Load += new System.EventHandler(this.FrmTestDgvSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.DataGridViewSummary dgvProductInfo;
        private System.Windows.Forms.Panel panel1;
        private Controls.UcPagerEx ucPager;
    }
}