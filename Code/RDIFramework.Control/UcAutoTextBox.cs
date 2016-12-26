using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Configuration;
using System.Text.RegularExpressions;
using RDIFramework.Utilities;


namespace RDIFramework.Controls
{
  public  class UcAutoTextBox : TextBox
    {
        
        //选择检索字段
        public enum NameByType
        {
            py = 1,
            wb = 2,
            name = 3,
            code = 4,
            

        }

        public enum RuseltAmount
        {
            R10 = 1,
            R20 = 2,
            R30 = 3,
            R50 = 4,
            RAll=5
        }
        #region 字段
        public Label code = new Label();
        public Label name = new Label();
        private int tagsql = 0;
        private string tagSqlStr = string.Empty;
        private string tagSqlStr2 = string.Empty;
        private RuseltAmount reViewCount = RuseltAmount.R10;
        private string displayMember = string.Empty;
        private string valueMember = string.Empty;
        private string ColumnXML = string.Empty;
        public DataGridView popupdgv; // 所要用到的列表框
        private System.Windows.Forms.Control[] controlColumn;
        public Control[] ControlColumn
        {
            get { return this.controlColumn; }
            set { this.controlColumn = value; }
        }
        Control nextControl; // 下一个焦点的控件
        private ErrorProvider exShow;
        private bool isEmpty = false;
        public bool IsEmpty
        {
            get { return this.isEmpty; }
            set { this.isEmpty = value; }
        }
        int txt_type = 0;
         NameByType pyOrWb;
        public NameByType PyOrWb
        {
            get { return this.pyOrWb; }
            set { 
                this.pyOrWb = value;

                SetPyWb(this.PyOrWb);
                }
        }
        SqlParameter[] sqlp = null;
        private void SetPyWb(NameByType py)
        {
            
            switch (py)
            {
                case NameByType.code:
                    {  
                        sqlp = new SqlParameter[] {  new SqlParameter("@code",this.Text.ToUpper()+'%') ,
                                                    new SqlParameter("@name",'%' ) ,
                                                    new SqlParameter("@wb_code", '%') ,
                                                    new SqlParameter("@py_code", '%' )};
                        break;
                    }
                case NameByType.name:
                    {
                        sqlp = new SqlParameter[] {  new SqlParameter("@code",'%') ,
                                                    new SqlParameter("@name",this.Text.ToUpper()+'%' ) ,
                                                    new SqlParameter("@wb_code", '%') ,
                                                    new SqlParameter("@py_code", '%' )};
                        break;
                    }
                case NameByType.py:
                    {
                        sqlp = new SqlParameter[] {  new SqlParameter("@code",'%') ,
                                                    new SqlParameter("@name",'%' ) ,
                                                    new SqlParameter("@wb_code", '%') ,
                                                    new SqlParameter("@py_code", this.Text.ToUpper()+'%' )};
                        break;
                    }
                case NameByType.wb:
                    {
                        sqlp = new SqlParameter[] {  new SqlParameter("@code",'%') ,
                                                    new SqlParameter("@name",'%' ) ,
                                                    new SqlParameter("@wb_code",this.Text.ToUpper()+ '%') ,
                                                    new SqlParameter("@py_code", '%' )};
                        break;
                    }
                default:
              
                    {
                        sqlp = new SqlParameter[] { new SqlParameter("@code",'%') ,
                                                    new SqlParameter("@name",'%' ) ,
                                                    new SqlParameter("@wb_code",'%') ,
                                                    new SqlParameter("@py_code", this.Text.ToUpper()+ '%')};
                        
                    }
                    break;

            }
        }

        public void SetRuseltAmount(RuseltAmount RA)
        {

            switch (RA)
            {
                case RuseltAmount.R10:
                    {
                        if (this.tagSqlStr2 != string.Empty)
                        {
                            this.tagSqlStr = string.Empty;
                            this.tagSqlStr = this.tagSqlStr2.TrimStart();
                            this.tagSqlStr = this.tagSqlStr.Substring(6, this.tagSqlStr.Length-6);
                          //  this.tagSqlStr.Insert(0, "SELECT TOP 10 ");
                            this.tagSqlStr = "SELECT TOP 10 " + tagSqlStr;
                        }
                        break;
                    }
                case RuseltAmount.R20:
                    {
                        if (this.tagSqlStr2 != string.Empty)
                        {
                            this.tagSqlStr = string.Empty;
                            this.tagSqlStr = this.tagSqlStr2.TrimStart();
                            this.tagSqlStr = this.tagSqlStr.Substring(6, this.tagSqlStr.Length - 6);
                            //  this.tagSqlStr.Insert(0, "SELECT TOP 10 ");
                            this.tagSqlStr = "SELECT TOP 20 " + tagSqlStr;
                        }
                        break;
                    }
                case RuseltAmount.R30:
                    {
                        if (this.tagSqlStr2 != string.Empty)
                        {
                            this.tagSqlStr = string.Empty;
                            this.tagSqlStr = this.tagSqlStr2.TrimStart();
                            this.tagSqlStr = this.tagSqlStr.Substring(6, this.tagSqlStr.Length - 6);
                            //  this.tagSqlStr.Insert(0, "SELECT TOP 10 ");
                            this.tagSqlStr = "SELECT TOP 30 " + tagSqlStr;
                        }
                        break;
                    }
                case RuseltAmount.R50:
                    {
                        if (this.tagSqlStr2 != string.Empty)
                        {
                            this.tagSqlStr = string.Empty;
                            this.tagSqlStr = this.tagSqlStr2.TrimStart();
                            this.tagSqlStr = this.tagSqlStr.Substring(6, this.tagSqlStr.Length - 6);
                            //  this.tagSqlStr.Insert(0, "SELECT TOP 10 ");
                            this.tagSqlStr = "SELECT TOP 50 " + tagSqlStr;
                        }
                        break;
                    }
                case RuseltAmount.RAll:
                    {
                        if (this.tagSqlStr2 != string.Empty)
                        {
                            this.tagSqlStr = string.Empty;
                            this.tagSqlStr = this.tagSqlStr2.TrimStart();
                            this.tagSqlStr = this.tagSqlStr.Substring(6, this.tagSqlStr.Length - 6);
                            //  this.tagSqlStr.Insert(0, "SELECT TOP 10 ");
                            this.tagSqlStr = "SELECT  " + tagSqlStr;
                        }
                        break;
                    }
                default:
                    {

                        if (this.tagSqlStr2 != string.Empty)
                        {
                            this.tagSqlStr = string.Empty;
                            this.tagSqlStr = this.tagSqlStr2.TrimStart();
                            this.tagSqlStr = this.tagSqlStr.Substring(6, this.tagSqlStr.Length);
                            this.tagSqlStr.Insert(0, "SELECT TOP 10 ");
                        }

                    }
                    break;

            }
        }

        #endregion

        #region 构造器

        public UcAutoTextBox()
        {
           // dbProvider = DbFactoryProvider.GetProvider(DbLinks["ProductDBLink"].DbType, SecretHelper.AESDecrypt(DbLinks["ProductDBLink"].DbLink));
            this.exShow = new ErrorProvider();
            this.PyOrWb = NameByType.py;
            //this.SetPyWb(NameByType.py);
            //this.GetTagSql(this.tagsql);
            this.ReViewCount = RuseltAmount.R10;
            this.popupdgv = new DataGridView();
            this.popupdgv.AutoGenerateColumns = false;
            this.Width = 100;
            this.popupdgv.ReadOnly = true;
            this.popupdgv.Visible = false;
            this.popupdgv.Margin = new Padding(0, 0, 0, 0);

            this.popupdgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.popupdgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.popupdgv.AllowUserToAddRows = false;
            this.popupdgv.AllowUserToResizeRows = false;
            this.popupdgv.RowHeadersVisible = false;
            this.popupdgv.Tag = "111";
            this.popupdgv.Font = this.Font;
            this.popupdgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.popupdgv.AllowUserToResizeRows = false;
            this.popupdgv.MultiSelect = false;
            this.popupdgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dgv_CellMouseClick);

            this.CMS = new ContextMenuStrip();
            this.TSMIpy = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIwb = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIcode = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIName = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIsplit = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI10 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI20 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI50 = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIsplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMITAG = new System.Windows.Forms.ToolStripMenuItem();


           
            this.CMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIpy,
            this.TSMIwb,
            this.TSMIcode,
            this.TSMIName,
            this.TSMIsplit,
            this.TSMI10,
            this.TSMI20,
            this.TSMI50,
            this.TSMIAll,
            this.TSMIsplit1,
            this.TSMITAG
            });
            this.CMS.Name = "CMS";
            this.CMS.Size = new System.Drawing.Size(153, 224);
            // 
            // TSMIpy
            // 
            this.TSMIpy.Checked = true;
            this.TSMIpy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMIpy.Name = "TSMIpy";
            this.TSMIpy.Size = new System.Drawing.Size(152, 24);
            this.TSMIpy.Text = "拼音";
            this.TSMIpy.Click +=new EventHandler(TSMIpy_Click);
            // 
            // TSMIwb
            // 
            this.TSMIwb.Checked = false;
            this.TSMIwb.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIwb.Name = "TSMIwb";
            this.TSMIwb.Size = new System.Drawing.Size(152, 24);
            this.TSMIwb.Text = "五笔";
            this.TSMIwb.Click +=new EventHandler(TSMIwb_Click);
            //
            // TSMIcode
            // 
            this.TSMIcode.Checked = false;
            this.TSMIcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIcode.Name = "TSMIcode";
            this.TSMIcode.Size = new System.Drawing.Size(152, 24);
            this.TSMIcode.Text = "代码";
            this.TSMIcode.Click +=new EventHandler(TSMIcode_Click); 
          
            // 
            // TSMIName
            // 
            this.TSMIName.Checked = false;
            this.TSMIName.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIName.Name = "TSMIName";
            this.TSMIName.Size = new System.Drawing.Size(152, 24);
            this.TSMIName.Text = "名称";
            this.TSMIName.Click+=new EventHandler(TSMIName_Click);
            
            // 
            // 
            // TSMIsplit
            // 
            this.TSMIsplit.Name = "TSMIsplit";
            this.TSMIsplit.Size = new System.Drawing.Size(149, 6);
            // 
            // TSMI10
            // 
            this.TSMI10.Checked = true;
            this.TSMI10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI10.Name = "TSMI10";
            this.TSMI10.Size = new System.Drawing.Size(152, 24);
            this.TSMI10.Text = "10行";
            this.TSMI10.Click += new EventHandler(TSMIR10_Click);
            // 
            // TSMI20
            // 
            this.TSMI20.Checked = false;
            this.TSMI20.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI20.Name = "TSMI20";
            this.TSMI20.Size = new System.Drawing.Size(152, 24);
            this.TSMI20.Text = "20行";
            this.TSMI20.Click += new EventHandler(TSMIR20_Click);
            // 
            // TSMI50
            // 
            this.TSMI50.Checked = false;
            this.TSMI50.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI50.Name = "TSMI50";
            this.TSMI50.Size = new System.Drawing.Size(152, 24);
            this.TSMI50.Text = "50行";
            this.TSMI50.Click += new EventHandler(TSMIR50_Click);
            // 
            // TSMIAll
            // 
            this.TSMIAll.Checked = false;
            this.TSMIAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIAll.Name = "TSMIAll";
            this.TSMIAll.Size = new System.Drawing.Size(152, 24);
            this.TSMIAll.Text = "所有行";
            this.TSMIAll.Click += new EventHandler(TSMIRAll_Click);

            // 
            // 
            // TSMIsplit
            // 
            this.TSMIsplit1.Name = "TSMIsplit";
            this.TSMIsplit1.Size = new System.Drawing.Size(149, 6);

            //this.TSMITAG.Checked = false;
            //this.TSMITAG.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMITAG.Name = "TSMITAG";
            this.TSMITAG.Size = new System.Drawing.Size(152, 24);
            this.TSMITAG.Text = "获取TagSql号";
            this.TSMITAG.Click += new EventHandler(TSMITAG_Click);
            this.ContextMenuStrip = this.CMS;
           

        }
        void TSMIcode_Click(object sender, EventArgs e)  
        {
            this.TSMIcode.Checked = true;
            this.TSMIName.Checked=false;
            this.TSMIpy.Checked=false;
            this.TSMIwb.Checked = false;



            this.TSMIcode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMIName.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIpy.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIwb.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.PyOrWb = NameByType.code;
            this.BackColor = Color.DarkOliveGreen;
        }
        void TSMIName_Click(object sender, EventArgs e)
        {
            
                this.TSMIcode.Checked = false;
                this.TSMIName.Checked = true;
                this.TSMIpy.Checked = false;
                this.TSMIwb.Checked = false;
                this.TSMIcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
                this.TSMIName.CheckState = System.Windows.Forms.CheckState.Checked;
                this.TSMIpy.CheckState = System.Windows.Forms.CheckState.Unchecked;
                this.TSMIwb.CheckState = System.Windows.Forms.CheckState.Unchecked;
                this.PyOrWb = NameByType.name;
                this.BackColor = Color.DarkRed;
        }
        void TSMIpy_Click(object sender, EventArgs e)
        {
            this.TSMIcode.Checked = false;
            this.TSMIName.Checked = false;
            this.TSMIpy.Checked = true;
            this.TSMIwb.Checked = false;
            this.TSMIcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIName.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIpy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMIwb.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.PyOrWb = NameByType.py;
            this.BackColor = Color.White;
        }
        void TSMIwb_Click(object sender, EventArgs e)
        {
            this.TSMIcode.Checked = false;
            this.TSMIName.Checked = false;
            this.TSMIpy.Checked = false;
            this.TSMIwb.Checked = true;
            this.TSMIcode.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIName.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIpy.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIwb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PyOrWb = NameByType.wb;
            this.BackColor = Color.Yellow;
        }


        void TSMIR10_Click(object sender, EventArgs e)
        {
            this.TSMI10.Checked = true;
            this.TSMI20.Checked = false;
            this.TSMI50.Checked = false;
            this.TSMIAll.Checked = false;
            this.TSMI10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI20.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI50.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.ReViewCount = RuseltAmount.R10;
           
        }
        void TSMIR20_Click(object sender, EventArgs e)
        {
            this.TSMI20.Checked = true;
            this.TSMI10.Checked = false;
            this.TSMI50.Checked = false;
            this.TSMIAll.Checked = false;
            this.TSMI20.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI10.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI50.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.ReViewCount = RuseltAmount.R20;

        }
        void TSMIR50_Click(object sender, EventArgs e)
        {
            this.TSMI50.Checked = true;
            this.TSMI10.Checked = false;
            this.TSMI20.Checked = false;
            this.TSMIAll.Checked = false;
            this.TSMI50.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI10.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI20.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMIAll.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.ReViewCount = RuseltAmount.R50;

        }
        void TSMIRAll_Click(object sender, EventArgs e)
        {
            this.TSMIAll.Checked = true;
            this.TSMI10.Checked = false;
            this.TSMI20.Checked = false;
            this.TSMI50.Checked = false;
            this.TSMIAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI10.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI20.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.TSMI50.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.ReViewCount = RuseltAmount.RAll;

        }
        void TSMITAG_Click(object sender, EventArgs e)
        {
            this.TSMITAG.Text = "=" + this.TagSql.ToString();

        }
        #endregion

        #region 属性
        [Category("周高岭"), Description("AutoText的Tagsql值")]
        public int TagSql
        {
            get { return this.tagsql; }
            set { this.tagsql = value; }
        }
       
     
        [Category("周高岭"), Description("AutoText显示值")]
        public string DisplayMember
        {
            get { return this.displayMember; }
            set
            {

                this.displayMember = value;
                this.Text = value;
            }
        }
        [Category("周高岭"), Description("AutoText实际值")]
        public string ValueMember
        {
            get { return this.valueMember; }
            set
            {
                if (this.valueMember != value)
                {

                     GetDisplayName(value);
                    this.ShowFlag = false;
                    this.Text = this.DisplayMember;
                }
                this.valueMember = value;
                this.Tag = value;
            }
        }

        private void GetDisplayName(string str)
        {
            string result = string.Empty;
           // string sql = "";
           
               

               
               // sql = this.tagSqlStr;
                
                SetPyWb(this.PyOrWb);
                SetRuseltAmount(this.ReViewCount);
                this.sqlp[0].Value = str;
                this.sqlp[1].Value = "%";
                this.sqlp[2].Value = "%";
                this.sqlp[3].Value = "%";
                ds=  DBhelper.Query( this.tagSqlStr ,sqlp);
                DataColumn[] PK = new DataColumn[1];

                PK[0] = ds.Tables[0].Columns["code"];

                ds.Tables[0].PrimaryKey = PK;
                this.popupdgv.DataSource = ds.Tables[0].DefaultView;
                SetDgvPosition();
                this.popupdgv.Visible = false;
                if (this.popupdgv.Rows.Count==1)
                {
                    ShowFlag = false;
                   this.valueMember = this.popupdgv.Rows[0].Cells["code"].Value.ToString();
                   this.DisplayMember = this.popupdgv.Rows[0].Cells["name"].Value.ToString();
                    //this.Text = this.popupdgv.Rows[0].Cells["name"].Value.ToString();
                   
                    

                }
            
        }
        [Category("周高岭"), Description(" 指定返回数据数量.")]
        public RuseltAmount ReViewCount
        {
            get { return this.reViewCount; }
            set 
            { 
                this.reViewCount = value;
                this.SetRuseltAmount(this.reViewCount);
            }
        }
        [Category("周高岭"), Description("指定该文本框的TagSql值")]

        public int Txttype
        {
            get { return txt_type; }
            set { txt_type = value; }
        }
        [Category("周高岭"), Description("下一个Tab的控件")]
        public Control NextControl
        {
            get { return this.nextControl; }
            set { this.nextControl = value; }
        }

        DataGridViewColumn[] col;
        [Category("周高岭"), Description("列宽信息")]
        public DataGridViewColumn[] Col
        {
            get { return this.col; }
            set { this.col = value; }
        }
        DataGridViewRow dr;
        [Category("周高岭"), Description("数据列")]
        public DataGridViewRow Dr
        {
            get { return this.dr; }
            set { this.dr = value; }
        }
        #endregion

        #region  右键快捷菜单
        private System.Windows.Forms.ContextMenuStrip CMS;
        private System.Windows.Forms.ToolStripMenuItem TSMIpy;
        private System.Windows.Forms.ToolStripMenuItem TSMIwb;
        private System.Windows.Forms.ToolStripMenuItem TSMIcode;
        private System.Windows.Forms.ToolStripMenuItem TSMIName;
        private System.Windows.Forms.ToolStripSeparator TSMIsplit;
        private System.Windows.Forms.ToolStripMenuItem TSMI10;
        private System.Windows.Forms.ToolStripMenuItem TSMI20;
        private System.Windows.Forms.ToolStripMenuItem TSMI50;
        private System.Windows.Forms.ToolStripMenuItem TSMIAll;
        private System.Windows.Forms.ToolStripSeparator TSMIsplit1;
        private System.Windows.Forms.ToolStripMenuItem TSMITAG;
        #endregion

        public void GetTagSql(int tag)
        {
            
            string result = "请维护Tagsql";

            SqlDataReader dr = DBhelper.ExecuteReader("select [gridColumn], [Sql] from [CIAUTOTEXTSQL] where [tag]=" + tag);

            if (dr.Read())
            {
                result = dr["sql"].ToString();
                this.ColumnXML = dr["gridColumn"].ToString();
            }
            this.tagSqlStr2 = result;
            SetCol();
        }
        private void SetCol()
        {
           
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(this.ColumnXML);
            XmlNode xn = doc.SelectSingleNode("TextBoxColumn");
            
            XmlNodeList xnl = xn.ChildNodes;
            DataGridViewTextBoxColumn c2;
            this.popupdgv.Columns.Clear();
            foreach (XmlNode xnf in xnl)
            {
               
               // XmlElement xe = (XmlElement)xnf;
               
               
                    c2 = new DataGridViewTextBoxColumn();
                    c2.Name = xnf.ChildNodes[0].InnerText;
                    c2.DataPropertyName = xnf.ChildNodes[1].InnerText; 
                    c2.HeaderText = xnf.ChildNodes[2].InnerText;
                    c2.Width = int.Parse(xnf.ChildNodes[3].InnerText);
                    c2.Visible = bool.Parse(xnf.ChildNodes[4].InnerText);
                    c2.SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.popupdgv.Columns.Add(c2);

                
            }
            SetDgvWidth(this.popupdgv);
        }
        public void SetDgvClose()
        {
            // ds.Tables[0].Rows.Clear();

            this.Refresh();
        }


        #region  动态设置列表控件的宽度
        public void SetColumn()
        {

            this.popupdgv.Columns.Clear();
            if (Col != null)
                foreach (DataGridViewColumn c in Col)
                {
                    this.popupdgv.Columns.Add(c);

                }
            //读数据库gridcolumns 字段xml 设置列
            SetDgvWidth(this.popupdgv);
        }
        private void SetDgvWidth(DataGridView dgv)
        {
            int Wd = 0;
           

            foreach (DataGridViewColumn c in dgv.Columns)
            {

                Wd += c.Width;
            }
            dgv.Width = Wd + 27;
            dgv.Height = 300;
          
        }
    
        #endregion
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar))       
            {
                    
                    ShowFlag = true;
            }
            
        }
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if (this.IsEmpty && this.valueMember == string.Empty && !this.popupdgv.Visible)
            {
                this.Text = string.Empty;
                this.exShow.SetError(this, "此项目不能为空");
            }
            else
                this.exShow.Clear();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                case Keys.Back:
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                    ShowFlag = true;
                  
                    break;

            }
            
        }

        #region   将数据表内容填充到列表控件里
        /// <summary>
        /// ◆ 将数据表内容填充到列表控件里
        /// </summary>
        /// <param name="lb">▼列表控件</param>
        /// <param name="dt">▼数据表</param>
        /// <param name="DisplayMember">▼显示成员</param>
        /// <param name="ValueMember">▼值成员</param> 
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        //private void SetValues()
        //{
        //    try
        //    {

        //        dt = ds.Tables[0].Copy();

        //        string code = this.popupdgv.CurrentRow.Cells["code"].Value.ToString();
        //        DataRow dr = dt.Rows.Find(code);
        //        int dtindex = dt.Rows.IndexOf(dr);
        //        // this.Text = dt.Rows[dtindex]["name"].ToString();
        //        if (this.ControlColumn.Length <= 0 && dtindex >= 0)
        //        {
        //            this.DisplayMember = dt.Rows[dtindex]["name"].ToString();
        //            this.code.Text = dt.Rows[dtindex]["code"].ToString();

        //        }
        //        else
        //        {
        //            foreach (Control c in this.ControlColumn)
        //            {
        //                c.Text = dt.Rows[dtindex][c.Name].ToString();

        //            }
        //        }




        //        this.popupdgv.Visible = false;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private  void SetDgvData()
        {

            if (Text == "")
            {

                ds.Clear();
                this.displayMember = string.Empty;
                this.valueMember = "";
                this.popupdgv.Visible = false;
                return;
            }
           
            try
            {
                
                SetPyWb(this.PyOrWb);
                SetRuseltAmount(this.ReViewCount);

                ds=  DBhelper.Query( this.tagSqlStr ,sqlp);
                DataColumn[] PK = new DataColumn[1];

                PK[0] = ds.Tables[0].Columns["code"];

                ds.Tables[0].PrimaryKey = PK;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.popupdgv.Visible = true;
                    SetDgvPosition();
                }
                else
                { 
                    this.popupdgv.Visible = false;
                    //this.displayMember = string.Empty;
                   // this.valueMember = "";
                }

                this.popupdgv.DataSource = ds.Tables[0].DefaultView;
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion
        private bool ShowFlag = false;
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (ShowFlag)
            {
                SetDgvData();
                ShowFlag = false;
            }
            if (this.Text == string.Empty)
            {
                this.valueMember = string.Empty;
                //this.Tag = string.Empty;
            }
            //
        }
        public void SetDgvPosition()
        {
                this.popupdgv.Parent = this.TopLevelControl;
                Point textPos = this.Parent.PointToScreen(this.Location);
                Point formPos = this.TopLevelControl.PointToScreen(new Point(0, 0)); // 得到窗体所在屏幕位置
                textPos = new Point(textPos.X - formPos.X, textPos.Y - formPos.Y + this.Height); // 计算相对值
                this.popupdgv.Location = textPos;
                this.popupdgv.Visible = true;
                this.popupdgv.BringToFront();
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1 && popupdgv.Rows.Count != 0 && popupdgv.CurrentCell != null)
            {

                ShowFlag = false;
                this.valueMember = popupdgv.Rows[popupdgv.CurrentCell.RowIndex].Cells["code"].Value.ToString();
                string str = popupdgv.Rows[popupdgv.CurrentCell.RowIndex].Cells["name"].Value.ToString();
                
                
                Text = str;
                this.DisplayMember = str;
               
                ///this.nextControl.Focus();


                if (popupdgv.Visible && this.NextControl != null)
                {
                    popupdgv.Visible = false;

                    this.nextControl.Focus();

                }
            }
        }


        #region 重载方法
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                scrollUp();

            }
            else if (e.Delta < 0)
            {
                scrollDown();

            }


        }

        void scrollUp()
        {
            if (popupdgv.DataSource == null || popupdgv.Rows.Count < 0)
            {

                return;
            }
            if (popupdgv.CurrentRow != null)
                if (popupdgv.CurrentRow.Index == 0)
                {
                    var index = popupdgv.Rows.Count;

                    popupdgv.ClearSelection();
                    popupdgv.Rows[index - 1].Selected = true;
                    popupdgv.CurrentCell = popupdgv.Rows[index - 1].Cells[1];


                }
                else
                {
                    var index = popupdgv.SelectedRows[0].Index; ;

                    popupdgv.ClearSelection();
                    popupdgv.Rows[index - 1].Selected = true;
                    popupdgv.CurrentCell = popupdgv.Rows[index - 1].Cells[1];
                }
        }

        void scrollDown()
        {
            if (popupdgv.DataSource == null || popupdgv.Rows.Count < 0)
            {
                //VerifyValue(popupdgv, this);
                return;
            }
            if (popupdgv.CurrentRow != null)

                if (popupdgv.CurrentRow.Index == 0)
                {
                    var index = popupdgv.CurrentRow.Index;

                    popupdgv.ClearSelection();
                    popupdgv.Rows[index + 1].Selected = true;
                    popupdgv.CurrentCell = popupdgv.Rows[index + 1].Cells[1];

                }
                else
                {
                    var index = popupdgv.CurrentRow.Index; ;
                    if (index == popupdgv.Rows.Count - 1)
                    {
                        popupdgv.ClearSelection();
                        popupdgv.Rows[0].Selected = true;
                        popupdgv.CurrentCell = popupdgv.Rows[0].Cells[1];
                    }
                    else
                    {
                        popupdgv.ClearSelection();
                        popupdgv.Rows[index + 1].Selected = true;
                        popupdgv.CurrentCell = popupdgv.Rows[index + 1].Cells[1];
                    }
                }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //if (this.ValueMember != null)
            //    this.Text = this.ValueMember;
            this.Select(this.Text.Length, 0);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this.Text.Length > 0)
            { this.SelectAll(); }
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.popupdgv.Focused)
            {
                return;
            }
            else
            {
                ShowFlag = false;
                this.Text = this.DisplayMember;
               // this.Tag = this.ValueMember;
                this.popupdgv.Visible = false;
                //this.BackColor = SystemColors.Info; 
                if (this.valueMember == null)
                { 
                    this.valueMember = string.Empty;
                    this.DisplayMember = string.Empty;
                }
            }


        }
        /// <summary>
        /// ◆ TextBox控件发生回车事件时，设置对应文本框控件的值和控件的状态
        /// </summary>
        /// <param name="e">wow</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:



                   //ShowFlag = true;

                    e.Handled = true;
                    break;

                case Keys.Up:
                    e.Handled = true;
                    scrollUp();

                    break;
                case Keys.Escape:
                    {
                        this.Text = string.Empty;
                        this.Tag = null;
                        this.ValueMember = null;
                        this.DisplayMember = null;
                        popupdgv.Visible = false;
                        ds.Clear();
                    }


                    break;
                case Keys.Back:
                    {
                        e.Handled = true;

                        this.Tag = null;
                        this.valueMember = null;
                        //this.DisplayMember = null;
                       
                    }

                    break;
                case Keys.Down:
                    scrollDown();
                    break;
                case Keys.Enter:
                    {
                        if (!popupdgv.Visible)
                        {
                            this.NextControl.Focus();
                            return;
                        }
                        this.valueMember = popupdgv.Rows[popupdgv.CurrentCell.RowIndex].Cells["code"].Value.ToString(); ; //取实际值
                        ShowFlag = false;
                        Text = popupdgv.Rows[popupdgv.CurrentCell.RowIndex].Cells["name"].Value.ToString(); ;//取显示值 
                        this.DisplayMember = this.Text;
                        //this.ValueMember =this.Tag.ToString();
                        //SetValues();
                        popupdgv.Visible = false;
                        ds.Clear();
                        this.BindingContext["Text"].EndCurrentEdit();
                        this.BindingContext["Tag"].EndCurrentEdit();
                        this.nextControl.Focus();
                    }
                    break;
            }

        }






        #endregion


        public class DBhelper
        {
            #region 数据连接字符串

            public static string ConnectionStr;//= GetConnStr();


            private static string GetConnStr()
            {
                string ConStr = null;
                try
                {
                    XmlDocument doc = new XmlDocument();
                    StringBuilder path = new StringBuilder();
                    path.Append(Application.StartupPath);
                    path.Append(@"\cis.xml");


                    doc.Load(path.ToString());
                    XmlNodeList elemlist = doc.GetElementsByTagName("connectionStrings");
                    //ConStr = elemlist[0].InnerXml;
                    //ConStr = UcAutoTextBox.DbProvider.ConnectionString;
                    // ConStr= UcAutoTextBox.db

                }
                catch
                {
                    throw new SystemException();
                }
                return ConStr;
            }
            #endregion

            #region SQL操作
            public static SqlDataReader ExecuteReader(string SQLString)
            {
                SqlConnection Conn = new SqlConnection(ConnectionStr);
                SqlCommand Cmd = new SqlCommand(SQLString, Conn);
                Cmd.Parameters.Clear();
                
                SqlDataReader MyReader;
                try
                {
                    Conn.Open();
                    MyReader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return MyReader;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    //Cmd.Dispose();
                    //Conn.Close();
                }
            }
            //public static DataSet ExecuteReader(string SQLString, SqlParameter[] parameters)
            //{
            //    SqlConnection Conn = new SqlConnection(ConnectionStr);
            //    SqlCommand Cmd = new SqlCommand(SQLString, Conn);
            //    Cmd.Parameters.Clear();
            //    Cmd.Parameters.AddRange(parameters);
            //    DataSet ds;
            //    try
            //    {
            //        Conn.Open();
            //        MyReader = Cmd.e(CommandBehavior.CloseConnection);
            //        return MyReader;
            //    }
            //    catch (System.Data.SqlClient.SqlException E)
            //    {
            //        throw new Exception(E.Message);
            //    }
            //    finally
            //    {
            //        //Cmd.Dispose();
            //        //Conn.Close();
            //    }
            //}
            /// 
            /// 执行查询语句，返回DataSet
            /// 
            /// 
            /// 
            public static DataSet Query(string SQLString, SqlParameter[] parameters)
            {
                SqlConnection Conn = new SqlConnection(ConnectionStr);
                DataSet DS = new DataSet();
                try
                {
                    Conn.Open();
                    SqlDataAdapter DA = new SqlDataAdapter(SQLString, Conn);
                    DA.SelectCommand.Parameters.Clear();
                    DA.SelectCommand.Parameters.AddRange(parameters);
                    DA.Fill(DS, "ds");
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {

                    Conn.Close();
                }
                return DS;
            }
            #endregion

        } 
    }
    
}
