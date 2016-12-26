/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-8 14:49:57
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcQueryControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcQueryControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new DevComponents.DotNetBar.PanelEx();
            this.barTools = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.pnlMain = new DevComponents.DotNetBar.PanelEx();
            this.dgvFilter = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colLogical = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colLeftParentheses = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colColumn = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colOperator = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colValue = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.colRigthParentheses = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barTools)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlTop.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlTop.Controls.Add(this.barTools);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(631, 29);
            this.pnlTop.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlTop.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlTop.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlTop.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlTop.Style.GradientAngle = 90;
            this.pnlTop.TabIndex = 0;
            // 
            // barTools
            // 
            this.barTools.AntiAlias = true;
            this.barTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTools.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.barTools.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5});
            this.barTools.Location = new System.Drawing.Point(0, 0);
            this.barTools.Name = "barTools";
            this.barTools.Size = new System.Drawing.Size(631, 29);
            this.barTools.Stretch = true;
            this.barTools.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barTools.TabIndex = 0;
            this.barTools.TabStop = false;
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.ImagePaddingHorizontal = 3;
            this.buttonItem1.ImagePaddingVertical = 10;
            this.buttonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "增行";
            // 
            // buttonItem2
            // 
            this.buttonItem2.BeginGroup = true;
            this.buttonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "删行";
            // 
            // buttonItem3
            // 
            this.buttonItem3.BeginGroup = true;
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "全部清除";
            // 
            // buttonItem4
            // 
            this.buttonItem4.BeginGroup = true;
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "确认";
            // 
            // buttonItem5
            // 
            this.buttonItem5.BeginGroup = true;
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "关闭/返回";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlMain.Controls.Add(this.dgvFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 29);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5);
            this.pnlMain.Size = new System.Drawing.Size(631, 249);
            this.pnlMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlMain.Style.GradientAngle = 90;
            this.pnlMain.TabIndex = 1;
            // 
            // dgvFilter
            // 
            this.dgvFilter.BackgroundColor = System.Drawing.Color.White;
            this.dgvFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFilter.ColumnHeadersHeight = 30;
            this.dgvFilter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLogical,
            this.colLeftParentheses,
            this.colColumn,
            this.colOperator,
            this.colValue,
            this.colRigthParentheses});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilter.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFilter.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvFilter.Location = new System.Drawing.Point(5, 5);
            this.dgvFilter.Name = "dgvFilter";
            this.dgvFilter.RowHeadersVisible = false;
            this.dgvFilter.RowTemplate.Height = 23;
            this.dgvFilter.Size = new System.Drawing.Size(621, 73);
            this.dgvFilter.TabIndex = 0;
            // 
            // colLogical
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colLogical.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLogical.DisplayMember = "Text";
            this.colLogical.DropDownHeight = 106;
            this.colLogical.DropDownWidth = 121;
            this.colLogical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colLogical.HeaderText = "关系";
            this.colLogical.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colLogical.IntegralHeight = false;
            this.colLogical.ItemHeight = 16;
            this.colLogical.Name = "colLogical";
            this.colLogical.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLogical.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colLogical.Width = 70;
            // 
            // colLeftParentheses
            // 
            this.colLeftParentheses.DisplayMember = "Text";
            this.colLeftParentheses.DropDownHeight = 106;
            this.colLeftParentheses.DropDownWidth = 121;
            this.colLeftParentheses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colLeftParentheses.HeaderText = "括号";
            this.colLeftParentheses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colLeftParentheses.IntegralHeight = false;
            this.colLeftParentheses.ItemHeight = 16;
            this.colLeftParentheses.Name = "colLeftParentheses";
            this.colLeftParentheses.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colLeftParentheses.Width = 70;
            // 
            // colColumn
            // 
            this.colColumn.DisplayMember = "Text";
            this.colColumn.DropDownHeight = 106;
            this.colColumn.DropDownWidth = 121;
            this.colColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colColumn.HeaderText = "字段名";
            this.colColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colColumn.IntegralHeight = false;
            this.colColumn.ItemHeight = 16;
            this.colColumn.Name = "colColumn";
            this.colColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colColumn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colColumn.Width = 120;
            // 
            // colOperator
            // 
            this.colOperator.DisplayMember = "Text";
            this.colOperator.DropDownHeight = 106;
            this.colOperator.DropDownWidth = 121;
            this.colOperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colOperator.HeaderText = "操作符";
            this.colOperator.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colOperator.IntegralHeight = false;
            this.colOperator.ItemHeight = 16;
            this.colOperator.Name = "colOperator";
            this.colOperator.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colOperator.Width = 70;
            // 
            // colValue
            // 
            this.colValue.DisplayMember = "Text";
            this.colValue.DropDownHeight = 106;
            this.colValue.DropDownWidth = 121;
            this.colValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colValue.HeaderText = "值";
            this.colValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colValue.IntegralHeight = false;
            this.colValue.ItemHeight = 16;
            this.colValue.Name = "colValue";
            this.colValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colValue.Width = 220;
            // 
            // colRigthParentheses
            // 
            this.colRigthParentheses.DisplayMember = "Text";
            this.colRigthParentheses.DropDownHeight = 106;
            this.colRigthParentheses.DropDownWidth = 121;
            this.colRigthParentheses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRigthParentheses.HeaderText = "括号";
            this.colRigthParentheses.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colRigthParentheses.IntegralHeight = false;
            this.colRigthParentheses.ItemHeight = 16;
            this.colRigthParentheses.Name = "colRigthParentheses";
            this.colRigthParentheses.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.colRigthParentheses.Width = 70;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Yellow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 29);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(631, 1);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // UcQueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "UcQueryControl";
            this.Size = new System.Drawing.Size(631, 278);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barTools)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlTop;
        private DevComponents.DotNetBar.Bar barTools;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.PanelEx pnlMain;
        private System.Windows.Forms.Splitter splitter1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvFilter;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colLogical;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colLeftParentheses;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colOperator;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colValue;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn colRigthParentheses;
    }
}
