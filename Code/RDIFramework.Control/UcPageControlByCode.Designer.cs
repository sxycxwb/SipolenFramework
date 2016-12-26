namespace RDIFramework.Controls
{
    partial class UcPageControlByCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPageControlByCode));
            this.tlsUcPageControlByCode = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblCurrentPage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirstPage = new System.Windows.Forms.ToolStripButton();
            this.btnPrevPage = new System.Windows.Forms.ToolStripButton();
            this.btnNextPage = new System.Windows.Forms.ToolStripButton();
            this.btnLastPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.txtGoToPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.lblRecCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.tlsUcPageControlByCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsUcPageControlByCode
            // 
            this.tlsUcPageControlByCode.BackColor = System.Drawing.SystemColors.Control;
            this.tlsUcPageControlByCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlsUcPageControlByCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tlsUcPageControlByCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsUcPageControlByCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.lblCurrentPage,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.btnFirstPage,
            this.btnPrevPage,
            this.btnNextPage,
            this.btnLastPage,
            this.toolStripSeparator2,
            this.toolStripLabel8,
            this.txtGoToPage,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.lblPageCount,
            this.toolStripLabel5,
            this.lblRecCount,
            this.toolStripLabel7});
            this.tlsUcPageControlByCode.Location = new System.Drawing.Point(0, 0);
            this.tlsUcPageControlByCode.Name = "tlsUcPageControlByCode";
            this.tlsUcPageControlByCode.Size = new System.Drawing.Size(778, 32);
            this.tlsUcPageControlByCode.TabIndex = 15;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 29);
            this.toolStripLabel1.Text = "当前第[";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPage.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(84, 29);
            this.lblCurrentPage.Text = "LCurrentPage";
            this.lblCurrentPage.ToolTipText = "当前页码";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(27, 29);
            this.toolStripLabel2.Text = "]页";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFirstPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("btnFirstPage.Image")));
            this.btnFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(54, 29);
            this.btnFirstPage.Text = "第一页";
            this.btnFirstPage.ToolTipText = "单击转到第一页";
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevPage.Image")));
            this.btnPrevPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(54, 29);
            this.btnPrevPage.Text = "上一页";
            this.btnPrevPage.ToolTipText = "单击转到上一页";
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPage.Image")));
            this.btnNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(54, 29);
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.ToolTipText = "单击转到下一页";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLastPage.Image = ((System.Drawing.Image)(resources.GetObject("btnLastPage.Image")));
            this.btnLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(54, 29);
            this.btnLastPage.Text = "最末页";
            this.btnLastPage.ToolTipText = "单击转到最后一页";
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(36, 29);
            this.toolStripLabel8.Text = "跳页";
            // 
            // txtGoToPage
            // 
            this.txtGoToPage.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtGoToPage.ForeColor = System.Drawing.Color.Red;
            this.txtGoToPage.Name = "txtGoToPage";
            this.txtGoToPage.Size = new System.Drawing.Size(50, 32);
            this.txtGoToPage.ToolTipText = "跳转到指定页";
            this.txtGoToPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGoToPage_KeyDown);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(27, 29);
            this.toolStripLabel3.Text = "共[";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageCount.ForeColor = System.Drawing.Color.Red;
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(85, 29);
            this.lblPageCount.Text = "PageCount";
            this.lblPageCount.ToolTipText = "总页数";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(37, 29);
            this.toolStripLabel5.Text = "]页/[";
            // 
            // lblRecCount
            // 
            this.lblRecCount.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecCount.ForeColor = System.Drawing.Color.Red;
            this.lblRecCount.Name = "lblRecCount";
            this.lblRecCount.Size = new System.Drawing.Size(76, 29);
            this.lblRecCount.Text = "RecCount";
            this.lblRecCount.ToolTipText = "总记录数";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(55, 29);
            this.toolStripLabel7.Text = "]条记录";
            // 
            // UcPageControlByCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlsUcPageControlByCode);
            this.Name = "UcPageControlByCode";
            this.Size = new System.Drawing.Size(778, 32);
            this.tlsUcPageControlByCode.ResumeLayout(false);
            this.tlsUcPageControlByCode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsUcPageControlByCode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFirstPage;
        private System.Windows.Forms.ToolStripButton btnPrevPage;
        private System.Windows.Forms.ToolStripButton btnNextPage;
        private System.Windows.Forms.ToolStripButton btnLastPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel lblPageCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel lblRecCount;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripTextBox txtGoToPage;
    }
}
