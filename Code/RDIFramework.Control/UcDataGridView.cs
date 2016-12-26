/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:30
 ******************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    /// <summary>
    /// 扩展DataGridView控件
    /// UcDataGridView
    /// </summary>
    /// 
    ///修改纪录:
    ///       2016-01-11 EricHu V3.0 增加点击某个单元格时使当前行前面的复选框(DataGridViewCheckBoxColumn控件)选中（打勾）或不选中（取消打勾）
    ///       2010-07-18 EricHu 创建"扩展DataGridView控件"
    /// 
    /// <author>
    ///     <name>EricHu</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    [ToolboxItem(true)]
    [Description("扩展DataGridView控件")]
    [ToolboxBitmap(typeof(System.Windows.Forms.DataGridView))]
    public partial class UcDataGridView : DevComponents.DotNetBar.Controls.DataGridViewX//System.Windows.Forms.DataGridView
    {
        private string checkboxFieldName = "colSelected";
        /// <summary>
        /// 选择列的名称，默认为：colSelected
        /// </summary>
        [Category("用户控件属性"), Description("选择列的名称，默认为：colSelected。"), Browsable(true)]
        public string CheckboxFieldName
        {
            get
            {
                return checkboxFieldName; 
                
            }
            set
            {
                checkboxFieldName = value;
            }
        }

        public UcDataGridView()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);         
        }

        protected override void OnCreateControl()
        {
            this.EnableHeadersVisualStyles = false;

            //this.ColumnHeadersDefaultCellStyle.BackColor          = Color.FromArgb(240, 246, 239);
            //设置所有DataGridView的表头居中对齐
            //this.ColumnHeadersDefaultCellStyle.Alignment          = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //this.DefaultCellStyle.SelectionForeColor              = Color.DarkSlateBlue;
            //this.GridColor                                        = System.Drawing.SystemColors.GradientActiveCaption;
            //this.BackgroundColor                                  = System.Drawing.SystemColors.Window;
            //this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;

            
            this.ColumnHeadersDefaultCellStyle.BackColor          = System.Drawing.SystemColors.Window;
            this.ColumnHeadersBorderStyle                         = DataGridViewHeaderBorderStyle.Raised;
            //this.ColumnHeadersHeight                              = 26;
            this.ColumnHeadersHeightSizeMode                      = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersDefaultCellStyle.ForeColor          = System.Drawing.SystemColors.WindowText;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.RowHeadersDefaultCellStyle.Alignment             = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.RowHeadersDefaultCellStyle.BackColor             = System.Drawing.SystemColors.Window;
            this.RowHeadersDefaultCellStyle.ForeColor             = System.Drawing.SystemColors.WindowText;
            this.RowHeadersWidthSizeMode                          = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RowHeadersBorderStyle                            = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.RowHeadersWidth                                  = 25;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DefaultCellStyle.SelectionBackColor              = Color.White;
            this.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;            
            this.GridColor = System.Drawing.SystemColors.ControlDark;            
            this.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.BorderStyle                                      = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AllowUserToOrderColumns                          = true;
            
            this.AutoGenerateColumns                              = true;   
             
            base.OnCreateControl();
        }
        
        Color defaultColor;

        //移到单元格时的颜色
        protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
        {

            base.OnCellMouseMove(e);
            try
            {
                //Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.YellowGreen;

            }
            catch (Exception)
            {

            }
        }

        //进入单元格时保存当前的颜色
        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseEnter(e);
            try
            {
                defaultColor = Rows[e.RowIndex].DefaultCellStyle.BackColor;
            }
            catch (Exception)
            {

            }

        }

        //离开时还原颜色
        protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
        {
            base.OnCellMouseLeave(e);
            try
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = defaultColor;
            }
            catch (Exception)
            {

            }
        }

        //处理回车事件
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.OnKeyPress(new KeyPressEventArgs('r'));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            // 点击某个单元格时使当前行前面的复选框(DataGridViewCheckBoxColumn控件)选中（打勾）或不选中（取消打勾）
            if (this.MultiSelect && this.Rows.Count > 1 && this.Columns.Contains(CheckboxFieldName))
            {
                var dataGridViewRow = this.CurrentRow;
                if (dataGridViewRow != null)
                {
                    dataGridViewRow.Cells[CheckboxFieldName].Value = !((System.Boolean) dataGridViewRow.Cells[CheckboxFieldName].FormattedValue);
                }
            }
            base.OnSelectionChanged(e);
        }
    }
}
