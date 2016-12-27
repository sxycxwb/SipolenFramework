/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:29
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:10
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcCombinQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCombinQuery));
            this.spContainerHorizontal = new System.Windows.Forms.SplitContainer();
            this.tlsQuery = new System.Windows.Forms.ToolStrip();
            this.lblQueryItems = new System.Windows.Forms.ToolStripLabel();
            this.cboQueryItems = new System.Windows.Forms.ToolStripComboBox();
            this.lblOperator = new System.Windows.Forms.ToolStripLabel();
            this.cboOperator = new System.Windows.Forms.ToolStripComboBox();
            this.lblQueryValue = new System.Windows.Forms.ToolStripLabel();
            this.txtQueryValue = new System.Windows.Forms.ToolStripTextBox();
            this.lblCombinMode = new System.Windows.Forms.ToolStripLabel();
            this.cboCombinMode = new System.Windows.Forms.ToolStripComboBox();
            this.sp1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddQueryCondition = new System.Windows.Forms.ToolStripButton();
            this.btnClsQueryCondition = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuery = new System.Windows.Forms.ToolStripButton();
            this.btnQueryMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.spContainerVertical = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQueryCondition = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spContainerHorizontal)).BeginInit();
            this.spContainerHorizontal.Panel1.SuspendLayout();
            this.spContainerHorizontal.Panel2.SuspendLayout();
            this.spContainerHorizontal.SuspendLayout();
            this.tlsQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spContainerVertical)).BeginInit();
            this.spContainerVertical.Panel1.SuspendLayout();
            this.spContainerVertical.Panel2.SuspendLayout();
            this.spContainerVertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // spContainerHorizontal
            // 
            this.spContainerHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContainerHorizontal.Location = new System.Drawing.Point(0, 0);
            this.spContainerHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.spContainerHorizontal.Name = "spContainerHorizontal";
            this.spContainerHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spContainerHorizontal.Panel1
            // 
            this.spContainerHorizontal.Panel1.Controls.Add(this.tlsQuery);
            // 
            // spContainerHorizontal.Panel2
            // 
            this.spContainerHorizontal.Panel2.Controls.Add(this.spContainerVertical);
            this.spContainerHorizontal.Size = new System.Drawing.Size(888, 86);
            this.spContainerHorizontal.SplitterDistance = 25;
            this.spContainerHorizontal.SplitterWidth = 1;
            this.spContainerHorizontal.TabIndex = 3;
            // 
            // tlsQuery
            // 
            this.tlsQuery.BackColor = System.Drawing.Color.White;
            this.tlsQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlsQuery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblQueryItems,
            this.cboQueryItems,
            this.lblOperator,
            this.cboOperator,
            this.lblQueryValue,
            this.txtQueryValue,
            this.lblCombinMode,
            this.cboCombinMode,
            this.sp1,
            this.btnAddQueryCondition,
            this.btnClsQueryCondition,
            this.toolStripSeparator2,
            this.btnQuery,
            this.btnQueryMode,
            this.toolStripSeparator1,
            this.btnClose});
            this.tlsQuery.Location = new System.Drawing.Point(0, 0);
            this.tlsQuery.Name = "tlsQuery";
            this.tlsQuery.Size = new System.Drawing.Size(888, 25);
            this.tlsQuery.TabIndex = 3;
            this.tlsQuery.Text = "toolStrip1";
            // 
            // lblQueryItems
            // 
            this.lblQueryItems.Name = "lblQueryItems";
            this.lblQueryItems.Size = new System.Drawing.Size(56, 22);
            this.lblQueryItems.Text = "查询项：";
            // 
            // cboQueryItems
            // 
            this.cboQueryItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryItems.MaxDropDownItems = 15;
            this.cboQueryItems.Name = "cboQueryItems";
            this.cboQueryItems.Size = new System.Drawing.Size(121, 25);
            this.cboQueryItems.ToolTipText = "选择要进行查询的数据项";
            // 
            // lblOperator
            // 
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(44, 22);
            this.lblOperator.Text = "运算符";
            this.lblOperator.Visible = false;
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.Items.AddRange(new object[] {
            "等于",
            "包含",
            "为空",
            "不为空",
            "大于",
            "大于或等于",
            "小于或等于",
            "小于",
            "左包含",
            "右包含"});
            this.cboOperator.MaxDropDownItems = 15;
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(75, 25);
            this.cboOperator.Visible = false;
            // 
            // lblQueryValue
            // 
            this.lblQueryValue.Name = "lblQueryValue";
            this.lblQueryValue.Size = new System.Drawing.Size(32, 22);
            this.lblQueryValue.Text = "值：";
            // 
            // txtQueryValue
            // 
            this.txtQueryValue.MaxLength = 50;
            this.txtQueryValue.Name = "txtQueryValue";
            this.txtQueryValue.Size = new System.Drawing.Size(100, 25);
            this.txtQueryValue.ToolTipText = "输入查询项对应的值";
            // 
            // lblCombinMode
            // 
            this.lblCombinMode.Name = "lblCombinMode";
            this.lblCombinMode.Size = new System.Drawing.Size(56, 22);
            this.lblCombinMode.Text = "组合方式";
            this.lblCombinMode.Visible = false;
            // 
            // cboCombinMode
            // 
            this.cboCombinMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCombinMode.Items.AddRange(new object[] {
            "与方式",
            "或方式",
            "非方式"});
            this.cboCombinMode.Name = "cboCombinMode";
            this.cboCombinMode.Size = new System.Drawing.Size(75, 25);
            this.cboCombinMode.ToolTipText = "选择组合查询的组合方式";
            this.cboCombinMode.Visible = false;
            // 
            // sp1
            // 
            this.sp1.Name = "sp1";
            this.sp1.Size = new System.Drawing.Size(6, 25);
            this.sp1.Visible = false;
            // 
            // btnAddQueryCondition
            // 
            this.btnAddQueryCondition.Image = global::RDIFramework.Controls.Properties.Resources.新增查询条件;
            this.btnAddQueryCondition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddQueryCondition.Name = "btnAddQueryCondition";
            this.btnAddQueryCondition.Size = new System.Drawing.Size(52, 22);
            this.btnAddQueryCondition.Text = "新增";
            this.btnAddQueryCondition.ToolTipText = "新增组合查询条件";
            this.btnAddQueryCondition.Visible = false;
            this.btnAddQueryCondition.Click += new System.EventHandler(this.btnAddQueryCondition_Click);
            // 
            // btnClsQueryCondition
            // 
            this.btnClsQueryCondition.Image = global::RDIFramework.Controls.Properties.Resources.清除查询条件;
            this.btnClsQueryCondition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClsQueryCondition.Name = "btnClsQueryCondition";
            this.btnClsQueryCondition.Size = new System.Drawing.Size(52, 22);
            this.btnClsQueryCondition.Text = "清除";
            this.btnClsQueryCondition.ToolTipText = "清除组合查询条件";
            this.btnClsQueryCondition.Visible = false;
            this.btnClsQueryCondition.Click += new System.EventHandler(this.btnClsQueryCondition_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(52, 22);
            this.btnQuery.Text = "查询";
            this.btnQuery.ToolTipText = "单击开始查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnQueryMode
            // 
            this.btnQueryMode.Image = global::RDIFramework.Controls.Properties.Resources.组合查询;
            this.btnQueryMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQueryMode.Name = "btnQueryMode";
            this.btnQueryMode.Size = new System.Drawing.Size(76, 22);
            this.btnQueryMode.Text = "组合查询";
            this.btnQueryMode.Click += new System.EventHandler(this.btnQueryMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Visible = false;
            // 
            // spContainerVertical
            // 
            this.spContainerVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spContainerVertical.Location = new System.Drawing.Point(0, 0);
            this.spContainerVertical.Margin = new System.Windows.Forms.Padding(0);
            this.spContainerVertical.Name = "spContainerVertical";
            // 
            // spContainerVertical.Panel1
            // 
            this.spContainerVertical.Panel1.Controls.Add(this.label2);
            // 
            // spContainerVertical.Panel2
            // 
            this.spContainerVertical.Panel2.Controls.Add(this.txtQueryCondition);
            this.spContainerVertical.Size = new System.Drawing.Size(888, 60);
            this.spContainerVertical.SplitterDistance = 36;
            this.spContainerVertical.SplitterWidth = 1;
            this.spContainerVertical.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "组合条件";
            // 
            // txtQueryCondition
            // 
            this.txtQueryCondition.BackColor = System.Drawing.Color.White;
            this.txtQueryCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQueryCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQueryCondition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryCondition.ForeColor = System.Drawing.Color.Blue;
            this.txtQueryCondition.Location = new System.Drawing.Point(0, 0);
            this.txtQueryCondition.Name = "txtQueryCondition";
            this.txtQueryCondition.ReadOnly = true;
            this.txtQueryCondition.Size = new System.Drawing.Size(851, 60);
            this.txtQueryCondition.TabIndex = 8;
            this.txtQueryCondition.Text = "";
            // 
            // UcCombinQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.spContainerHorizontal);
            this.Name = "UcCombinQuery";
            this.Size = new System.Drawing.Size(888, 86);
            this.Load += new System.EventHandler(this.UcCombinQuery_Load);
            this.spContainerHorizontal.Panel1.ResumeLayout(false);
            this.spContainerHorizontal.Panel1.PerformLayout();
            this.spContainerHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainerHorizontal)).EndInit();
            this.spContainerHorizontal.ResumeLayout(false);
            this.tlsQuery.ResumeLayout(false);
            this.tlsQuery.PerformLayout();
            this.spContainerVertical.Panel1.ResumeLayout(false);
            this.spContainerVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spContainerVertical)).EndInit();
            this.spContainerVertical.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spContainerHorizontal;
        private System.Windows.Forms.ToolStrip tlsQuery;
        private System.Windows.Forms.ToolStripLabel lblQueryItems;
        private System.Windows.Forms.ToolStripComboBox cboQueryItems;
        private System.Windows.Forms.ToolStripLabel lblOperator;
        private System.Windows.Forms.ToolStripComboBox cboOperator;
        private System.Windows.Forms.ToolStripLabel lblQueryValue;
        private System.Windows.Forms.ToolStripTextBox txtQueryValue;
        private System.Windows.Forms.ToolStripLabel lblCombinMode;
        private System.Windows.Forms.ToolStripComboBox cboCombinMode;
        private System.Windows.Forms.ToolStripSeparator sp1;
        private System.Windows.Forms.ToolStripButton btnAddQueryCondition;
        private System.Windows.Forms.ToolStripButton btnClsQueryCondition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnQuery;
        private System.Windows.Forms.ToolStripButton btnQueryMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.SplitContainer spContainerVertical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtQueryCondition;
    }
}
