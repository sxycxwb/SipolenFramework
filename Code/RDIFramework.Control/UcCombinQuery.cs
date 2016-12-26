/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:29
 ******************************************************************************/
#region  版权信息
/*---------------------------------------------------------------------*
// Copyright (C) 2008 http://www.cnblogs.com/huyong
// 版权所有。 
// 项目  名称：《Winform通用控件库》
// 文  件  名： UcCombinQuery.cs
// 类  全  名： RDIFramework.Controls.UcCombinQuery 
// 描      述:  组合查询控件
// 创建  时间： 2008-08-05
// 创建人信息： [**** 姓名:EricHu QQ:406590790 E-Mail:406590790@qq.com *****]
*----------------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RDIFramework.Utilities;

namespace RDIFramework.Controls
{
    /// <summary>
    /// 组合查询控件
    /// UcCombinQuery
    /// 修改纪录
    ///     2012-03-08  EricHu 再次对组合查询控件进行重构，清除了相关冗余代码，新增了一种对查询项的填充。
    ///     2010-12-06  EricHu 优化相关代码。
    ///     2010-11-29  EricHu 取消对：清除组合查询控件条件时的提示。
    ///     2010-11-08  EricHu 要是查询项中包含"案卷号",则把案卷号移动到第一个查询项。
    ///     2010-11-05  EricHu 对案卷号的查询，不加单引号。
    ///     2010-09-07  EricHu 增加对SQL注入的判断，以防止SQL注入。
    ///     2010-08-30  EricHu 对查询字符型字段进行>、<、>=、<=、=操作时，其值自动加单引号。
    ///      2008-08-05 EricHu 创建组合查询控件
    ///     
    /// <author>
    ///     <name>EricHu</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    /// </summary>
    [ToolboxItem(true)]
    [DefaultEvent("OnQueryClicked")]
    [ToolboxBitmap(typeof(UcCombinQuery), "Images.UcCombinQuery.bmp")]
    [Description("组合查询控件")]
    public partial class UcCombinQuery : UserControl
    { 
        #region 公共变量
        Dictionary<string, string> dicQueryItem = new Dictionary<string, string>();
        IList<QueryItem> listQueryItem = new List<QueryItem>();
        #endregion

        #region 公共方法
        /// <summary>
        /// 查询模式
        /// </summary>
        public enum QueryMode
        {
            /// <summary>
            /// 固定查询
            /// </summary>
            FixQueryMode       = 0x0001,
            /// <summary>
            /// 组合查询
            /// </summary>
            CompositeQueryMode = 0x0002
        }

        /// <summary>
        /// 设置查询模式
        /// </summary>
        /// <param name="queryMode">查询模式</param>
        public void SetQueryMode(QueryMode queryMode)
        {
            if (queryMode == QueryMode.FixQueryMode)
            {
                btnQueryMode.Text = "固定查询";
            }
            else
            {
                btnQueryMode.Text = "组合查询";
            }
            btnQueryMode_Click(null, null);
        }

        /// <summary>
        /// 设置查询项中第一个显示值
        /// </summary>
        /// <param name="queryItem">查询项</param>
        public void SetFirstQueryItem(string queryItem)
        {
            if (cboQueryItems.Items.Count > 0)
            {
                for(int itemCount = 0;itemCount < cboQueryItems.Items.Count;itemCount++)
                {
                    if(cboQueryItems.Items[itemCount].Equals(queryItem))
                    {
                        cboQueryItems.Items.Remove(queryItem);
                        return;
                    }
                }

                cboQueryItems.Items.Insert(0, queryItem);
                cboQueryItems.SelectedIndex = 0;
            }
        }
        #endregion

        #region 可见性属性
        private bool _QueryModeButtomVisible = true;
        /// <summary>
        /// 组合查询按钮是否可见
        /// </summary>
        [Category("用户控件属性"), Description("组合查询是否可见。")]
        public bool QueryModeButtomVisible
        {
            get
            {
                return _QueryModeButtomVisible;
            }
            set
            {
                _QueryModeButtomVisible = value;
                if (!_QueryModeButtomVisible)
                {
                    toolStripSeparator1.Visible = false;
                }
                this.btnQueryMode.Visible = _QueryModeButtomVisible;
            }
        }
        #endregion

        #region 构造函数
        public UcCombinQuery()
        {
            InitializeComponent();
        }
        #endregion

        #region 组合查询表达式
        /// <summary>
        /// 单击[查询]按钮时发生
        /// </summary>
        [Category("用户控件属性"), Description("单击[查询]按钮时发生。"), Browsable(true)]
        public event EventHandler OnQueryClicked;

        private string _queryExpression;
        /// <summary>
        /// 最终的查询表达式，可直接用于Where子句中
        /// </summary>
        [Category("用户控件属性"), Description("最终的查询表达式，可直接用于Where子句中。"), Browsable(false)]
        public string QueryExpression
        {
            get { return _queryExpression; }
            set
            {
                _queryExpression = value;
                if (OnQueryClicked != null)
                {
                    OnQueryClicked(this, null);
                }
            }
        }
        #endregion

        #region 查询项相关控制

        #region 设置查询项中要显示的数据列表
        /// <summary>
        /// 设置查询项中要显示的数据列表
        /// </summary>
        /// <param name="listQueryItem"></param>
        public void SetQueryItems(IList<QueryItem> queryItems)
        {
            cboQueryItems.Items.Clear();
            listQueryItem = null;
            listQueryItem = queryItems;
            foreach (QueryItem queryItem in queryItems)
            {
                cboQueryItems.Items.Add(queryItem.Name); 
            }                       
        }

        /// <summary>
        /// 设置查询项中要显示的数据列表(推荐使用这个方法)
        /// </summary>
        /// <param name="dicListQueryItems">表示键和值的集合(键：数据字段，值：数据字段对应的数据类型)</param>
        public void SetQueryItems(Dictionary<string, string> dicListQueryItems)
        {
            cboQueryItems.Items.Clear();
            dicQueryItem = null;
            dicQueryItem = dicListQueryItems;
            foreach (KeyValuePair<string, string> kvp in dicListQueryItems)
            {
                cboQueryItems.Items.Add(kvp.Key);
            }
          
            cboQueryItems.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置查询项中要显示的数据列表
        /// </summary>
        /// <param name="sQueryItems">string类型数组</param>
        public void SetQueryItems(string[] sQueryItems)
        {
            cboQueryItems.Items.Clear();

            foreach (string queryItem in sQueryItems)
            {
                cboQueryItems.Items.Add(queryItem);
            }
            cboQueryItems.SelectedIndex = 0;
        }

        /// <summary>
        /// 设置查询项中要显示的数据列表
        /// </summary>
        /// <param name="listQueryItems">List泛型</param>
        public void SetQueryItems(List<string> listQueryItems)
        {
            cboQueryItems.Items.Clear();
            foreach (string queryItem in listQueryItems)
            {
                cboQueryItems.Items.Add(queryItem);
            }
            cboQueryItems.SelectedIndex = 0;
        }       
        #endregion

        /// <summary>
        /// 设置查询项的选择索引项
        /// </summary>
        /// <param name="index">索引的下标</param>
        public void SetQueryItemsSelectIndex(int index)
        {
            this.cboQueryItems.SelectedIndex = index;        
        }

        /// <summary>
        /// 设置查询项的选择内容
        /// </summary>
        /// <param name="sTxt">查询项选中的内容</param>
        public void SetQueryItemSelectText(string sTxt)
        {
            this.cboQueryItems.SelectedText =sTxt;
        }

        /// <summary>
        /// 清空选项值
        /// </summary>
        public void ClearQueryItems()
        {
            cboQueryItems.Items.Clear();
        }
        #endregion

        #region 事件代码

        #region 窗体Load事件 UcCombinQuery_Load(object sender, EventArgs e)
        private void UcCombinQuery_Load(object sender, EventArgs e)
        {
            this.Height = 25;
        }
        #endregion

        #region 设置查询模式(组合查询或固定查询:btnQueryMode_Click(object sender, EventArgs e)
        private void btnQueryMode_Click(object sender, EventArgs e)
        {
            cboQueryItems.Focus();
            //spContainerHorizontal.Panel2Collapsed = !spContainerHorizontal.Panel2Collapsed;
            lblOperator.Visible = !lblOperator.Visible;
            cboOperator.Visible = !cboOperator.Visible;
            lblCombinMode.Visible = !lblCombinMode.Visible;
            cboCombinMode.Visible = !cboCombinMode.Visible;
            sp1.Visible = !sp1.Visible;
            if (btnQueryMode.Text == "固定查询")
            {
                btnQueryMode.Text = "组合查询";
                btnAddQueryCondition.Visible = !btnAddQueryCondition.Visible;
                btnClsQueryCondition.Visible = !btnClsQueryCondition.Visible;
                this.Height = 25;
                btnQueryMode.Image = RDIFramework.Controls.Properties.Resources.组合查询;//导入图片
            }
            else if (btnQueryMode.Text == "组合查询")
            {
                txtQueryCondition.Clear();
                cboOperator.SelectedIndex = 0;
                cboCombinMode.SelectedIndex = 0;
                btnAddQueryCondition.Visible = !btnAddQueryCondition.Visible;
                btnClsQueryCondition.Visible = !btnClsQueryCondition.Visible;
                this.Height = 86;
                btnQueryMode.Text = "固定查询";
                btnQueryMode.Image = RDIFramework.Controls.Properties.Resources.固定查询;
            }
        }
        #endregion

        #region 增加查询条件单击事件 btnAddQueryCondition_Click(object sender, EventArgs e)

        private void btnAddQueryCondition_Click(object sender, EventArgs e)
        {
            if (cboQueryItems.Items.Count == 0)
            {
                MessageBox.Show("查询项为空，不能进行查询！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string sQueryItem = cboQueryItems.Text.Trim(); //要查询的项
                string sQueryValue = txtQueryValue.Text.Trim(); //查询项的值
                string sCombinMode = string.Empty; //组合方式
                string sQueryExpress = string.Empty;//查询条件表达式

                if (cboOperator.Text != "为空" && cboOperator.Text != "不为空")
                {
                    if (string.IsNullOrEmpty(txtQueryValue.Text.Trim()))
                    {
                        MessageBox.Show("必须输入查询项的值!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQueryValue.Focus();
                        return;
                    }
                    else
                    {
                        if (StringHelper.HasDangerousWord(txtQueryValue.Text.Trim())) 
                        {
                            MessageBox.Show("对不起，你的输入含有危险字符！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtQueryValue.Clear();
                            txtQueryValue.Focus();
                            return;
                        }
                    }
                }

                switch (cboCombinMode.Text)
                {
                    case "与方式":
                        sCombinMode = "AND";
                        break;
                    case "或方式":
                        sCombinMode = "OR";
                        break;
                    case "非方式":
                        sCombinMode = "AND NOT";
                        break;
                    default:
                        break;
                }

                #region 条件设置
                switch (cboOperator.Text)
                {
                    case "包含":
                        sQueryExpress = getExpress("like");
                        break;
                    case "左包含":
                        sQueryExpress = getExpress("left contains");                       
                        break;
                    case "右包含":
                        sQueryExpress = getExpress("right contains");
                        break;
                    case "为空":
                        sQueryExpress = getExpress("is null");
                        break;
                    case "不为空":
                        sQueryExpress = getExpress("is not null");
                        break;
                    case "大于":                  
                        sQueryExpress = getExpress(">");
                        break;
                    case "大于或等于":
                        sQueryExpress = getExpress(">=");                        
                        break;
                    case "等于":
                        sQueryExpress = getExpress("=");                        
                        break;
                    case "小于或等于":
                        sQueryExpress = getExpress("<=");                        
                        break;
                    case "小于":
                        sQueryExpress = getExpress("<");                       
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(txtQueryCondition.Text.Trim()))
                {
                    sQueryExpress = sCombinMode + " " + sQueryExpress;
                }               

                txtQueryCondition.AppendText(" " + sQueryExpress);
                #endregion
            }
        }
        #endregion

        private string getExpress(string operation)
        {
            string sQueryItem = cboQueryItems.Text.Trim(); //要查询的项
            string sQueryValue = txtQueryValue.Text.Trim(); //查询项的值
            string returnValue = string.Empty;
            if (listQueryItem.Count > 0)
            {
                foreach (QueryItem queryItem in listQueryItem)
                {
                    if (queryItem.Name.Equals(cboQueryItems.Text))
                    {
                        if (queryItem.DataType.ToLower().Contains("string") || queryItem.DataType.ToLower().Contains("date"))
                        {
                            returnValue = queryItem.Code + operation + "'" + sQueryValue + "'";
                        }
                        else if (queryItem.DataType.ToLower().Contains("is null") )
                        { 
                            returnValue = queryItem.Code + " IS NULL OR " + queryItem.Code + "=''";
                        }
                        else if(queryItem.DataType.ToLower().Contains("is not null"))
                        {
                            returnValue = queryItem.Code + " IS NOT NULL And " + queryItem.Code + "!=''";
                        }
                        else if (queryItem.DataType.ToLower().Contains("left contains"))
                        {
                            returnValue = queryItem.Code + " LIKE '" + sQueryValue + "%'";
                        }
                        else if (queryItem.DataType.ToLower().Contains("right contains"))
                        {
                            returnValue = queryItem.Code + " LIKE '%" + sQueryValue + "'";
                        }
                        else if (queryItem.DataType.ToLower().Contains("like"))
                        {
                            returnValue = queryItem.Code + " LIKE '%" + sQueryValue + "%'";
                        }
                        else
                        {
                            returnValue = queryItem.Code + " " + operation + " " + sQueryValue;
                        } 
                    }
                }
            }
            else if (dicQueryItem.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in dicQueryItem)
                {
                    if (kvp.Value.ToLower().Contains("string") || kvp.Value.ToLower().Contains("date"))
                    {
                        returnValue = sQueryItem + operation + "'" + sQueryValue + "'";
                    }
                    else if (kvp.Value.ToLower().Contains("is null"))
                    {
                        returnValue = sQueryItem + " IS NULL OR " + sQueryItem + "=''";
                    }
                    else if (kvp.Value.ToLower().Contains("is not null"))
                    {
                        returnValue = sQueryItem + " IS NOT NULL And " + sQueryItem + "!=''";
                    }
                    else if (kvp.Value.ToLower().Contains("left contains"))
                    {
                        returnValue = sQueryItem + " LIKE '" + sQueryValue + "%'";
                    }
                    else if (kvp.Value.ToLower().Contains("right contains"))
                    {
                        returnValue = sQueryItem + " LIKE '%" + sQueryValue + "'";
                    }
                    else if (kvp.Value.ToLower().Contains("like"))
                    {
                        returnValue = sQueryItem + " LIKE '%" + sQueryValue + "%'";
                    }
                    else
                    {
                        returnValue = sQueryItem + " " + operation + " " + sQueryValue;
                    } 
                }
            }
            else
            {
                returnValue = sQueryItem + " >  " + sQueryValue;
            }                 
            return returnValue;
        }

        #region 清除查询条件 btnClsQueryCondition_Click(object sender, EventArgs e)
        //清除查询条件
        private void btnClsQueryCondition_Click(object sender, EventArgs e)
        {
            if (txtQueryCondition.Text.Trim() != string.Empty)
            {
                txtQueryCondition.Clear();
            }
        }
        #endregion

        #region 查询单击事件 btnQuery_Click(object sender, EventArgs e)
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (cboQueryItems.Items.Count == 0)
            {
                MessageBox.Show("查询项为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (btnQueryMode.Text == "组合查询")
                {
                    if (string.IsNullOrEmpty(txtQueryValue.Text.Trim()))
                    {
                        QueryExpression = "1 = 1";
                        return;
                    }
                    else
                    {
                        if (StringHelper.HasDangerousWord(txtQueryValue.Text.Trim())) //危险字符判断，防止SQL注入
                        {
                            MessageBox.Show("对不起，你的输入含有危险字符！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtQueryValue.Clear();
                            txtQueryValue.Focus();
                            return;
                        }
                        else
                        {
                            QueryExpression =  getExpress("=");                                             
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(txtQueryCondition.Text.Trim()))
                    {
                        if (cboOperator.Text != "为空" && cboOperator.Text != "不为空")
                        {
                            if (txtQueryValue.Text.Trim() == string.Empty)
                            {
                                MessageBox.Show("必须输入查询项的值！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtQueryValue.Focus();
                                return;
                            }
                            else
                            {
                                if (StringHelper.HasDangerousWord(txtQueryValue.Text.Trim()))
                                {
                                    MessageBox.Show("对不起，你的输入含有危险字符！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    txtQueryValue.Clear();
                                    txtQueryValue.Focus();
                                    return;
                                }
                                else
                                {
                                    btnAddQueryCondition_Click(sender, e);
                                }
                            }
                        }
                        else
                        {
                            btnAddQueryCondition_Click(sender, e);
                        }
                    }
                    QueryExpression = txtQueryCondition.Text.Trim();
                }
            }
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// 查询项结构
    /// </summary>
    public struct QueryItem
    {
        /// <summary>
        /// 查询项中文名称(显示的友好名称)
        /// </summary>
        public string Name;

        /// <summary>
        /// 查询项的实际名称（对应于字段名称）
        /// </summary>
        public string Code;

        /// <summary>
        /// 查询项的数据类型
        /// </summary>
        public string DataType;
    }

}
