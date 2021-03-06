using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// DbToWord 的摘要说明。
    /// </summary>
    public class FrmDbToWord : Form
    {
        #region
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.ListBox listTable1;
        private System.Windows.Forms.ListBox listTable2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddlist;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDelList;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label4;//服务器配置
        #endregion

        private Word.Application WordApp = new Word.ApplicationClass();
        //Word._Application oWord = new Word.Application();
      
        Thread mythread;
        Thread mythreadload;
        IDbObject dbobj;
        delegate void SetBtnEnableEventHandler();
        delegate void SetBtnDisableEventHandler();
        delegate void SetlblStatuEventHandler(string text);
        delegate void SetProBar1MaxEventHandler(int val);
        delegate void SetProBar1ValEventHandler(int val);
        DbSettings dbset;
        private GroupBox groupBox3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private Label label5;        
        string dbName = "";

        public FrmDbToWord(string longServerName)
        {
            InitializeComponent();            
            dbset = DbConfig.GetSetting(longServerName);
            dbobj = DBOMaker.CreateDbObj(dbset.DbType);
            dbobj.DbConnectStr = dbset.ConnectStr;
            lblServer.Text = dbset.Server;
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbToWord));
            groupBox1 = new System.Windows.Forms.GroupBox();
            cmbDB = new System.Windows.Forms.ComboBox();
            lblServer = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            labelNum = new System.Windows.Forms.Label();
            btnAddlist = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnDel = new System.Windows.Forms.Button();
            btnDelList = new System.Windows.Forms.Button();
            listTable2 = new System.Windows.Forms.ListBox();
            listTable1 = new System.Windows.Forms.ListBox();
            btnGenerate = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            comboBox1 = new System.Windows.Forms.ComboBox();
            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton1 = new System.Windows.Forms.RadioButton();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbDB);
            groupBox1.Controls.Add(lblServer);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new System.Drawing.Point(8, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(464, 64);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "选择数据库";
            // 
            // cmbDB
            // 
            cmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDB.Location = new System.Drawing.Point(296, 24);
            cmbDB.Name = "cmbDB";
            cmbDB.Size = new System.Drawing.Size(152, 20);
            cmbDB.TabIndex = 2;
            cmbDB.SelectedIndexChanged += new System.EventHandler(cmbDB_SelectedIndexChanged);
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new System.Drawing.Point(104, 26);
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(41, 12);
            lblServer.TabIndex = 1;
            lblServer.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 12);
            label1.TabIndex = 0;
            label1.Text = "当前服务器：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(216, 26);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(77, 12);
            label3.TabIndex = 0;
            label3.Text = "选择数据库：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Controls.Add(labelNum);
            groupBox2.Controls.Add(btnAddlist);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Controls.Add(btnDel);
            groupBox2.Controls.Add(btnDelList);
            groupBox2.Controls.Add(listTable2);
            groupBox2.Controls.Add(listTable1);
            groupBox2.Location = new System.Drawing.Point(8, 76);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(464, 208);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "选择表";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = global::RDIFramework.CodeMaker.Properties.Resources.load;
            pictureBox1.Location = new System.Drawing.Point(213, 148);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(28, 28);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 53;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(64, 182);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(376, 20);
            progressBar1.TabIndex = 10;
            // 
            // labelNum
            // 
            labelNum.Location = new System.Drawing.Point(16, 180);
            labelNum.Name = "labelNum";
            labelNum.Size = new System.Drawing.Size(46, 22);
            labelNum.TabIndex = 9;
            labelNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddlist
            // 
            btnAddlist.Enabled = false;
            btnAddlist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnAddlist.Location = new System.Drawing.Point(208, 29);
            btnAddlist.Name = "btnAddlist";
            btnAddlist.Size = new System.Drawing.Size(40, 23);
            btnAddlist.TabIndex = 7;
            btnAddlist.Text = ">>";
            btnAddlist.Click += new System.EventHandler(btnAddlist_Click);
            // 
            // btnAdd
            // 
            btnAdd.Enabled = false;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnAdd.Location = new System.Drawing.Point(208, 60);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(40, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = ">";
            btnAdd.Click += new System.EventHandler(btnAdd_Click);
            // 
            // btnDel
            // 
            btnDel.Enabled = false;
            btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnDel.Location = new System.Drawing.Point(208, 91);
            btnDel.Name = "btnDel";
            btnDel.Size = new System.Drawing.Size(40, 23);
            btnDel.TabIndex = 5;
            btnDel.Text = "<";
            btnDel.Click += new System.EventHandler(btnDel_Click);
            // 
            // btnDelList
            // 
            btnDelList.Enabled = false;
            btnDelList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnDelList.Location = new System.Drawing.Point(208, 122);
            btnDelList.Name = "btnDelList";
            btnDelList.Size = new System.Drawing.Size(40, 23);
            btnDelList.TabIndex = 6;
            btnDelList.Text = "<<";
            btnDelList.Click += new System.EventHandler(btnDelList_Click);
            // 
            // listTable2
            // 
            listTable2.ItemHeight = 12;
            listTable2.Location = new System.Drawing.Point(288, 24);
            listTable2.Name = "listTable2";
            listTable2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listTable2.Size = new System.Drawing.Size(152, 148);
            listTable2.TabIndex = 1;
            listTable2.DoubleClick += new System.EventHandler(listTable2_DoubleClick);
            // 
            // listTable1
            // 
            listTable1.ItemHeight = 12;
            listTable1.Location = new System.Drawing.Point(16, 24);
            listTable1.Name = "listTable1";
            listTable1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listTable1.Size = new System.Drawing.Size(152, 148);
            listTable1.TabIndex = 0;
            listTable1.Click += new System.EventHandler(listTable1_Click);
            listTable1.DoubleClick += new System.EventHandler(listTable1_DoubleClick);
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            btnGenerate.Location = new System.Drawing.Point(245, 369);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(75, 26);
            btnGenerate.TabIndex = 42;
            btnGenerate.Text = "生  成";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += new System.EventHandler(btnGenerate_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            btnCancel.Location = new System.Drawing.Point(350, 369);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 26);
            btnCancel.TabIndex = 42;
            btnCancel.Text = "关  闭";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(btnCancel_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 300);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(0, 12);
            label2.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 50);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(329, 12);
            label4.TabIndex = 44;
            label4.Text = "注：如果文档生成失败，请检查本机是否安装了Office软件。";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(radioButton2);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(radioButton1);
            groupBox3.Location = new System.Drawing.Point(8, 288);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(464, 69);
            groupBox3.TabIndex = 45;
            groupBox3.TabStop = false;
            groupBox3.Text = "格式";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(171, 46);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 12);
            label5.TabIndex = 46;
            label5.Text = "选择风格：";
            label5.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] {
            "风格一",
            "风格二",
            "风格三"});
            comboBox1.Location = new System.Drawing.Point(237, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 20);
            comboBox1.TabIndex = 45;
            comboBox1.Visible = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(171, 20);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(77, 16);
            radioButton2.TabIndex = 0;
            radioButton2.Text = "Html 格式";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += new System.EventHandler(radioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new System.Drawing.Point(64, 20);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(77, 16);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Word 格式";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += new System.EventHandler(radioButton_CheckedChanged);
            // 
            // FrmDbToWord
            // 
            AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            ClientSize = new System.Drawing.Size(480, 406);
            Controls.Add(groupBox3);
            Controls.Add(label2);
            Controls.Add(btnGenerate);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDbToWord";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "生成数据库设计文档";
            Load += new System.EventHandler(DbToWord_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        #region load
        private void DbToWord_Load(object sender, System.EventArgs e)
        {
            btnGenerate.Enabled = false;
            ThreadWorkLoad();
            comboBox1.SelectedIndex = 0;
        }

        void ThreadWorkLoad()
        {            
            string mastedb = "master";
            switch (dbobj.DbType)
            {
                case "SQL2000":
                case "SQL2005":
                case "SQL2008":
                    mastedb = "master";
                    break;
                case "Oracle":
                case "OleDb":
                    mastedb = dbset.DbName;
                    break;                   
                case "MySQL":
                    mastedb = "mysql";
                    break;
            }

            if ((dbset.DbName == "") || (dbset.DbName == mastedb))
            {
                List<string> dblist = dbobj.GetDBList();
                if (dblist != null)
                {
                    if (dblist.Count > 0)
                    {
                        foreach (string dbName in dblist)
                        {
                            cmbDB.Items.Add(dbName);
                        }
                    }
                }
            }
            else
            {
                cmbDB.Items.Add(dbset.DbName);
            }
            if (cmbDB.Items.Count > 0)
            {
                cmbDB.SelectedIndex = 0;
            }
            else
            {
                List<string> tabNames = dbobj.GetTables("");
                listTable1.Items.Clear();
                listTable2.Items.Clear();
                if (tabNames.Count > 0)
                {
                    SetprogressBar1Max(tabNames.Count);
                    SetprogressBar1Val(1);
                    SetlblStatuText("");
                    int s = 1;
                    foreach (string tabname in tabNames)
                    {
                        listTable1.Items.Add(tabname);
                        SetprogressBar1Val(s);
                        SetlblStatuText(tabname);
                    }
                }
            }                     
        }
        
        private void cmbDB_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string dbName = cmbDB.Text;
            List<string> tabNames = dbobj.GetTables(dbName);

            listTable1.Items.Clear();
            listTable2.Items.Clear();
            if (tabNames.Count > 0)
            {
                foreach (string tabname in tabNames)
                {
                    listTable1.Items.Add(tabname);
                }
            }

            IsHasItem();
        }

        #endregion

        #region 按钮操作

        private void btnAddlist_Click(object sender, System.EventArgs e)
        {
            int c = listTable1.Items.Count;
            for (int i = 0; i < c; i++)
            {
                listTable2.Items.Add(listTable1.Items[i]);
            }
            listTable1.Items.Clear();

            IsHasItem();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {

            int c = listTable1.SelectedItems.Count;
            ListBox.SelectedObjectCollection objs = listTable1.SelectedItems;
            for (int i = 0; i < c; i++)
            {
                listTable2.Items.Add(listTable1.SelectedItems[i]);

            }
            for (int i = 0; i < c; i++)
            {
                if (listTable1.SelectedItems.Count > 0)
                {
                    listTable1.Items.Remove(listTable1.SelectedItems[0]);
                }
            }
            IsHasItem();
        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            int c = listTable2.SelectedItems.Count;
            ListBox.SelectedObjectCollection objs = listTable2.SelectedItems;
            for (int i = 0; i < c; i++)
            {
                listTable1.Items.Add(listTable2.SelectedItems[i]);

            }
            for (int i = 0; i < c; i++)
            {
                if (listTable2.SelectedItems.Count > 0)
                {
                    listTable2.Items.Remove(listTable2.SelectedItems[0]);
                }
            }

            IsHasItem();
        }

        private void btnDelList_Click(object sender, System.EventArgs e)
        {
            int c = listTable2.Items.Count;
            for (int i = 0; i < c; i++)
            {
                listTable1.Items.Add(listTable2.Items[i]);
            }
            listTable2.Items.Clear();
            IsHasItem();
        }
        #endregion

        #region listbox操作
        private void listTable1_Click(object sender, EventArgs e)
        {
            if (listTable1.SelectedItem == null) return;
            IsHasItem();
        }

        private void listTable1_DoubleClick(object sender, System.EventArgs e)
        {
            if (listTable1.SelectedItem == null) return;
            listTable2.Items.Add(listTable1.SelectedItem);
            listTable1.Items.Remove(listTable1.SelectedItem);
            IsHasItem();
        }

        private void listTable2_DoubleClick(object sender, System.EventArgs e)
        {
            if (listTable2.SelectedItem == null) return;
            listTable1.Items.Add(listTable2.SelectedItem);
            listTable2.Items.Remove(listTable2.SelectedItem);
            IsHasItem();
        }

        /// <summary>
        /// 判断listbox有没有项目
        /// </summary>
        private void IsHasItem()
        {
            if (listTable1.Items.Count > 0)
            {
                btnAdd.Enabled = true;
                btnAddlist.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnAddlist.Enabled = false;
            }

            if (listTable2.Items.Count > 0)
            {
                btnDel.Enabled = true;
                btnDelList.Enabled = true;
                btnGenerate.Enabled = true;
            }
            else
            {
                btnDel.Enabled = false;
                btnDelList.Enabled = false;
                btnGenerate.Enabled = false;
            }
        }
        #endregion

        #region 异步控件设置
        public void SetBtnEnable()
        {
            if (btnGenerate.InvokeRequired)
            {
                var d = new SetBtnEnableEventHandler(SetBtnEnable);
                Invoke(d, null);
            }
            else
            {
                btnGenerate.Enabled = true;               
            }
        }
        public void SetBtnDisable()
        {
            if (btnGenerate.InvokeRequired)
            {
                var d = new SetBtnDisableEventHandler(SetBtnDisable);
                Invoke(d, null);
            }
            else
            {
                btnGenerate.Enabled = false;               
            }
        }
        public void SetlblStatuText(string text)
        {
            if (labelNum.InvokeRequired)
            {
                var d = new SetlblStatuEventHandler(SetlblStatuText);
                Invoke(d, new object[] { text });
            }
            else
            {
                labelNum.Text = text;
            }
        }
        /// <summary>
        /// 循环网址进度最大值
        /// </summary>
        /// <param name="val"></param>
        public void SetprogressBar1Max(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                var d = new SetProBar1MaxEventHandler(SetprogressBar1Max);
                Invoke(d, new object[] { val });
            }
            else
            {
                progressBar1.Maximum = val;

            }
        }
        /// <summary>
        /// 循环网址进度
        /// </summary>
        /// <param name="val"></param>
        public void SetprogressBar1Val(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                var d = new SetProBar1ValEventHandler(SetprogressBar1Val);
                Invoke(d, new object[] { val });
            }
            else
            {
                progressBar1.Value = val;

            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                object Nothing = System.Reflection.Missing.Value;
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            Close();
        }

        #region 生成word
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                dbName = cmbDB.Text;
                pictureBox1.Visible = true;
                mythread = radioButton1.Checked ? new Thread(new ThreadStart(ThreadWork)) : new Thread(new ThreadStart(ThreadWorkhtml));
                mythread.Start();
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #region 生成方法1
        void ThreadWork1()
        {
            try
            {
                SetBtnDisable();
                string strtitle = "数据库名：" + dbName;
                int tblCount = listTable2.Items.Count;

                SetprogressBar1Max(tblCount);
                SetprogressBar1Val(1);
                SetlblStatuText("0");

                #region 产生文档，写入标题

                object missing = System.Reflection.Missing.Value;
                object fileName = "normal.dot";
                object newTemplate = false;
                object docType = 0;
                object isVisible = true;

                //Microsoft.Office.Interop.Word.Document aDoc = WordApp.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);

                Word.Document aDoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //添加页眉 
                WordApp.ActiveWindow.View.Type = Word.WdViewType.wdOutlineView;
                WordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekPrimaryHeader;
                WordApp.ActiveWindow.ActivePane.Selection.InsertAfter("[RDIFramework.NET框架代码生成器（http://www.cnblogs.com/huyong/）]");
                WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐
                WordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;//跳出页眉设置


                WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                WordApp.Selection.Font.Bold = (int)Word.WdConstants.wdToggle;
                
                WordApp.Selection.Font.Size = 12;
                WordApp.Selection.TypeText(strtitle);

                #endregion

                #region 循环每个表

                for (int i = 0; i < tblCount; i++)
                {
                    string tablename = listTable2.Items[i].ToString();
                    //this.listTable2.SelectedIndex = i;

                    //添加一个表格。
                    object missingValue = Type.Missing;
                    object location = strtitle.Trim().Length; //起始位置, 注：若location超过已有字符的长度将会出错。
                    Word.Range rng = aDoc.Range(ref location, ref location);
                    WordApp.Selection.Tables.Add(rng, 2, 10, ref missing, ref missing);

                    object pBreak = (int)Word.WdBreakType.wdTextWrappingBreak;//.wdLineBreak;//.wdPageBreak;
                    rng.InsertBreak(ref pBreak);//换行
                    rng.InsertBreak(ref pBreak);//换行
                    //rng.InsertParagraph();//段落
                    rng.InsertBefore("表名：" + tablename);
                    //rng.InsertBreak(ref pBreak );//换行

                    //设置表格
                    Word.Table tbl = aDoc.Tables[1]; //第一个表格为1，而不是0	

                    //设置表格样式
                    tbl.Borders.Enable = 1;
                    //tbl.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
                    //tbl.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                    tbl.AllowAutoFit = true;

                    tbl.Rows.Height = 15;

                    //设置行风格
                    Word.Range rngRow;
                    rngRow = tbl.Rows[1].Range;
                    rngRow.Font.Size = 9;
                    rngRow.Font.Name = "宋体";
                    rngRow.Font.Bold = 1;//(int)Microsoft.Office.Interop.Word.WdConstants.wdToggle;

                    ////合并单元格
                    // tbl.Cell(2, 1).Merge(tbl.Cell(2, 3));
                    // WordApp.Selection.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    //填充表格内容
                    tbl.Cell(1, 1).Range.Text = "序号"; //在表格的第一行第一列填入内容。                
                    tbl.Cell(1, 2).Range.Text = "列名";
                    tbl.Cell(1, 3).Range.Text = "数据类型";
                    tbl.Cell(1, 4).Range.Text = "长度";
                    tbl.Cell(1, 5).Range.Text = "小数位";
                    tbl.Cell(1, 6).Range.Text = "标识";
                    tbl.Cell(1, 7).Range.Text = "主键";
                    tbl.Cell(1, 8).Range.Text = "允许空";
                    tbl.Cell(1, 9).Range.Text = "默认值";
                    tbl.Cell(1, 10).Range.Text = "说明";


                    //tbl.Cell(2, 1).Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorDarkBlue;//设置单元格内字体颜色
                    //纵向合并单元格
                    //tbl.Cell(3, 3).Select();//选中一行

                    tbl.Columns[1].Width = 33;
                    //tbl.Columns[2].Width=80;
                    tbl.Columns[3].Width = 60;
                    tbl.Columns[4].Width = 33;
                    tbl.Columns[5].Width = 43;
                    tbl.Columns[6].Width = 33;
                    tbl.Columns[7].Width = 33;
                    tbl.Columns[8].Width = 43;
                    //tbl.Columns[9].Width=80;
                    //////////////////////////////////////////////////


                    #region 循环每一个列，产生一行数据
                    Object beforeRow;
                    List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbName, tablename);
                    int n = 2;
                    if ((collist != null) && (collist.Count > 0))
                    {
                        foreach (ColumnInfo col in collist)
                        {
                            string order = col.ColOrder;
                            string colum = col.ColumnName;
                            string typename = col.TypeName;
                            string length = col.Length;
                            string scale = col.Scale;
                            string IsIdentity = col.IsIdentity.ToString().ToLower()=="true"?"是":"";
                            string PK = col.IsPK.ToString().ToLower() == "true" ? "是" : "";
                            string isnull = col.IsNull.ToString().ToLower() == "true" ? "是" : "否";
                            string defaultstr = col.DefaultVal.ToString();
                            string description = col.ColDescription.ToString();

                            if (length.Trim() == "-1")
                            {
                                length = "MAX";
                            }

                            //一行数据//添加一行			
                            beforeRow = Type.Missing;
                            tbl.Rows.Add(ref beforeRow); //在表格的最后添加一行

                            tbl.Rows[n].Range.Select();
                            //设置行风格
                            Microsoft.Office.Interop.Word.Range rngRow2;
                            rngRow2 = tbl.Rows[n].Range;
                            rngRow2.Font.Size = 9;
                            rngRow2.Font.Name = "宋体";
                            rngRow2.Font.Bold = 0; //(int)Microsoft.Office.Interop.Word.WdConstants.wdBackward;
                            rngRow2.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                                      

                            tbl.Cell(n, 1).Range.Text = order; //在表格的第一行第一列填入内容。
                            tbl.Cell(n, 2).Range.Text = colum; //在表格的第一行第一列填入内容。
                            tbl.Cell(n, 3).Range.Text = typename;
                            tbl.Cell(n, 4).Range.Text = length;
                            tbl.Cell(n, 5).Range.Text = scale;
                            tbl.Cell(n, 6).Range.Text = IsIdentity;
                            tbl.Cell(n, 7).Range.Text = PK;
                            tbl.Cell(n, 8).Range.Text = isnull;
                            tbl.Cell(n, 9).Range.Text = defaultstr;
                            tbl.Cell(n, 10).Range.Text = description;
                            
                            n++;

                        }
                    }
                    #endregion


                    SetprogressBar1Val(i + 1);
                    SetlblStatuText((i + 1).ToString());

                    /*设置表第一行的属性*/
                    //tbl.Rows.First.Range.Font.Italic = 1;
                    //tbl.Rows.First.Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBlue;//设置表头字体颜色
                    //tbl.Rows.First.Range.Font.Bold = 1;//设置粗体
                    tbl.Rows.First.Shading.Texture = Microsoft.Office.Interop.Word.WdTextureIndex.wdTexture25Percent;//设置阴影
                    

                    ////“落款”
                    //Microsoft.Office.Interop.Word.Paragraphs.Last.Range.Text = "文档创建时间：" + DateTime.Now.ToString();
                    //Microsoft.Office.Interop.Word.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

                    
                    #region
                    //Microsoft.Office.Interop.Word.Range rng2 = aDoc.Range(ref location, ref location);				
                    //GoToTheEnd();
                    //插入空行
                    //WordApp.Selection.TypeParagraph();
                    //写上表名				
                    //WordApp.Selection.TypeText(tablename);
                    //aDoc.Paragraphs.First.Range.Text=tablename;
                    //aDoc.Paragraphs.Last.Range.Text="Wellcome To Aspxcn.Com";
                    #endregion

                }

                #endregion

                WordApp.Visible = true;
                aDoc.Activate();


                SetBtnEnable();
                MessageBox.Show("文档生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show("文档生成失败！(" + ex.Message + ")。\r\n请关闭重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        #endregion

        #region 方法2
        void ThreadWork()
        {
            try
            {
                SetBtnDisable();
                string strtitle = "数据库名：" + dbName;
                int tblCount = listTable2.Items.Count;

                SetprogressBar1Max(tblCount);
                SetprogressBar1Val(1);
                SetlblStatuText("0");

                #region 产生文档，写入标题

                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                //创建文档
                Word._Application oWord = new Word.Application();
                Word._Document oDoc;
                oWord.Visible = false;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                //设置页眉
                oWord.ActiveWindow.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdOutlineView;
                oWord.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekPrimaryHeader;
                oWord.ActiveWindow.ActivePane.Selection.InsertAfter("RDIFramework.NET平台代码生成器 http://www.cnblogs.com/huyong/  http://blog.csdn.net/chinahuyong");
                oWord.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;//设置右对齐
                oWord.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;//跳出页眉设置

                //库名
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = strtitle;
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Name = "宋体";
                oPara1.Range.Font.Size = 12;
                oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Format.SpaceAfter = 5;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                #endregion

                #region 循环每个表

                for (int i = 0; i < tblCount; i++)
                {
                    string tablename = listTable2.Items[i].ToString();
                    //this.listTable2.SelectedIndex = i;
                    string tabletitle = "表名：" + tablename;
                                        
                    #region 循环每一个列，产生一行数据
                                      
                    List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbName, tablename);                    
                    int rc = collist.Count;
                    if ((collist != null) && (collist.Count > 0))
                    {
                        //表名
                        Word.Paragraph oPara2;
                        object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
                        oPara2.Range.Text = tabletitle;
                        oPara2.Range.Font.Bold = 1;
                        oPara2.Range.Font.Name = "宋体";
                        oPara2.Range.Font.Size = 10;
                        oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oPara2.Format.SpaceBefore = 15;
                        oPara2.Format.SpaceAfter = 1;
                        oPara2.Range.InsertParagraphAfter();

                        //描述信息
                        Word.Paragraph oPara3;
                        oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                        oPara3.Range.Text = "";
                        oPara3.Range.Font.Bold = 0;
                        oPara3.Range.Font.Name = "宋体";
                        oPara3.Range.Font.Size = 9;
                        oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        oPara3.Format.SpaceBefore = 1;
                        oPara3.Format.SpaceAfter = 1;
                        oPara3.Range.InsertParagraphAfter();

                        //插入表格          
                        Word.Table oTable;
                        Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oTable = oDoc.Tables.Add(wrdRng, rc+1, 10, ref oMissing, ref oMissing);
                        oTable.Range.Font.Name = "宋体";
                        oTable.Range.Font.Size = 9;
                        oTable.Borders.Enable = 1;
                        oTable.Rows.Height = 10;
                        oTable.AllowAutoFit = true;                        
                        //wrdRng.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        //oTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleThickThinLargeGap;
                        //oTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        //oTable.Range.ParagraphFormat.SpaceAfter = 2;//表格里面的内容段落后空格

                        //填充表格内容
                        oTable.Cell(1, 1).Range.Text = "序号"; //在表格的第一行第一列填入内容。                
                        oTable.Cell(1, 2).Range.Text = "列名";
                        oTable.Cell(1, 3).Range.Text = "数据类型";
                        oTable.Cell(1, 4).Range.Text = "长度";
                        oTable.Cell(1, 5).Range.Text = "小数位";
                        oTable.Cell(1, 6).Range.Text = "标识";
                        oTable.Cell(1, 7).Range.Text = "主键";
                        oTable.Cell(1, 8).Range.Text = "允许空";
                        oTable.Cell(1, 9).Range.Text = "默认值";
                        oTable.Cell(1, 10).Range.Text = "说明";

                        oTable.Columns[1].Width = 33;
                        //oTable.Columns[2].Width=80;
                        oTable.Columns[3].Width = 60;
                        oTable.Columns[4].Width = 33;
                        oTable.Columns[5].Width = 43;
                        oTable.Columns[6].Width = 33;
                        oTable.Columns[7].Width = 33;
                        oTable.Columns[8].Width = 43;
                        //tbl.Columns[9].Width=80;
                        
                        int r, c;
                        string strText;
                        for (r = 0; r < rc; r++)
                        {
                            ColumnInfo col=(ColumnInfo)collist[r];
                            string order = col.ColOrder;
                            string colum = col.ColumnName;
                            string typename = col.TypeName;
                            string length = col.Length;
                            string scale = col.Scale;
                            string IsIdentity = col.IsIdentity.ToString().ToLower() == "true" ? "是" : "";
                            string PK = col.IsPK.ToString().ToLower() == "true" ? "是" : "";
                            string isnull = col.IsNull.ToString().ToLower() == "true" ? "是" : "否";
                            string defaultstr = col.DefaultVal.ToString();
                            string description = col.ColDescription.ToString();
                            if (length.Trim() == "-1")
                            {
                                length = "MAX";
                            }

                            oTable.Cell(r + 2, 1).Range.Text = order;
                            oTable.Cell(r + 2, 2).Range.Text = colum;
                            oTable.Cell(r + 2, 3).Range.Text = typename;
                            oTable.Cell(r + 2, 4).Range.Text = length;
                            oTable.Cell(r + 2, 5).Range.Text = scale;
                            oTable.Cell(r + 2, 6).Range.Text = IsIdentity;
                            oTable.Cell(r + 2, 7).Range.Text = PK;
                            oTable.Cell(r + 2, 8).Range.Text = isnull;
                            oTable.Cell(r + 2, 9).Range.Text = defaultstr;
                            oTable.Cell(r + 2, 10).Range.Text = description;                                                       
                        }
                        oTable.Rows[1].Range.Font.Bold = 1;
                        oTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        //oTable.Rows[1].Range.Font.Italic = 1;
                        //oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
                        //oTable.Columns[2].Width = oWord.InchesToPoints(3);
                        oTable.Rows.First.Shading.Texture = Word.WdTextureIndex.wdTexture25Percent;//设置阴影
                        //oTable.Rows.First.Range.Font.Bold = 1;
                        //oTable.Rows.First.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                                
                    }
                    #endregion
                    
                    SetprogressBar1Val(i + 1);
                    SetlblStatuText((i + 1).ToString());                                    
                                        
                }

                ////在后面插入文本
                //wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                //wrdRng.InsertParagraphAfter();
                //wrdRng.InsertAfter("本文结束");

                #endregion

                oWord.Visible = true;
                oDoc.Activate();
                
                SetBtnEnable();
                MessageBox.Show("文档生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show("文档生成失败！(" + ex.Message + ")。\r\n请关闭重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion 

        #region 生成html格式
        void ThreadWorkhtml()
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    string temphtml = Application.StartupPath + @"\Templates\table.htm";
                    if (!File.Exists(temphtml))
                    {
                        MessageBox.Show(this, "HMTL模版文件不存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SetBtnDisable();
                    string strtitle = "数据库名：" + dbName;
                    int tblCount = listTable2.Items.Count;

                    SetprogressBar1Max(tblCount);
                    SetprogressBar1Val(1);
                    SetlblStatuText("0");

                    StringBuilder htmlBody = new StringBuilder();


                    #region 产生文档，写入标题

                    htmlBody.Append("<div class=\"styledb\">" + strtitle + "</div>");

                    #endregion

                    #region 循环每个表

                    for (int i = 0; i < tblCount; i++)
                    {
                        string tablename = listTable2.Items[i].ToString();
                        string tabletitle = "表名：" + tablename;

                        #region 循环每一个列，产生一行数据

                        List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbName, tablename);
                        int rc = collist.Count;
                        if ((collist != null) && (collist.Count > 0))
                        {
                            htmlBody.Append("<div class=\"styletab\">" + tabletitle + "</div>");
                            htmlBody.Append("<div><table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");

                            if (comboBox1.SelectedIndex == 0)
                            {
                                htmlBody.Append("<tr><td bgcolor=\"#FBFBFB\">");
                                htmlBody.Append("<table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
                                htmlBody.Append("<tr bgcolor=\"#F0F0F0\">");
                            }
                            else if (comboBox1.SelectedIndex == 1)
                            {
                                htmlBody.Append("<tr><td bgcolor=\"#F5F9FF\">");
                                htmlBody.Append("<table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#4F7FC9\" bordercolordark=\"#D3D8E0\">");
                                htmlBody.Append("<tr bgcolor=\"#E3EFFF\">");
                            }
                            else
                            {
                                htmlBody.Append("<tr><td bgcolor=\"#DBEDF8\">");
                                htmlBody.Append("<table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#337FB2\" bordercolordark=\"#337FB2\">");
                                htmlBody.Append("<tr bgcolor=\"#337FB2\">");
                            }

                            htmlBody.Append("<td>序号</td>");
                            htmlBody.Append("<td>列名</td>");
                            htmlBody.Append("<td>数据类型</td>");
                            htmlBody.Append("<td>长度</td>");
                            htmlBody.Append("<td>小数位</td>");
                            htmlBody.Append("<td>标识</td>");
                            htmlBody.Append("<td>主键</td>");
                            htmlBody.Append("<td>允许空</td>");
                            htmlBody.Append("<td>默认值</td>");
                            htmlBody.Append("<td>说明</td>");
                            htmlBody.Append("</tr>");

                            int r, c;
                            //string strText;
                            for (r = 0; r < rc; r++)
                            {
                                ColumnInfo col = (ColumnInfo)collist[r];
                                string order = col.ColOrder;
                                string colum = col.ColumnName;
                                string typename = col.TypeName;
                                string length = col.Length == "" ? "&nbsp;" : col.Length;
                                string scale = col.Scale == "" ? "&nbsp;" : col.Scale;
                                string IsIdentity = col.IsIdentity.ToString().ToLower() == "true" ? "是" : "&nbsp;";
                                string PK = col.IsPK.ToString().ToLower() == "true" ? "是" : "&nbsp;";
                                string isnull = col.IsNull.ToString().ToLower() == "true" ? "是" : "否";
                                string defaultstr = col.DefaultVal.ToString().Trim() == "" ? "&nbsp;" : col.DefaultVal.ToString();
                                string description = col.ColDescription.ToString().Trim() == "" ? "&nbsp;" : col.ColDescription.ToString();
                                if (length.Trim() == "-1")
                                {
                                    length = "MAX";
                                }

                                htmlBody.Append("<tr>");
                                htmlBody.Append("<td>" + order + "</td>");
                                htmlBody.Append("<td>" + colum + "</td>");
                                htmlBody.Append("<td>" + typename + "</td>");
                                htmlBody.Append("<td>" + length + "</td>");
                                htmlBody.Append("<td>" + scale + "</td>");
                                htmlBody.Append("<td>" + IsIdentity + "</td>");
                                htmlBody.Append("<td>" + PK + "</td>");
                                htmlBody.Append("<td>" + isnull + "</td>");
                                htmlBody.Append("<td>" + defaultstr + "</td>");
                                htmlBody.Append("<td>" + description + "</td>");
                                htmlBody.Append("</tr>");

                            }

                        }
                        htmlBody.Append("</table>");
                        htmlBody.Append("</td>");
                        htmlBody.Append("</tr>");
                        htmlBody.Append("</table>");
                        htmlBody.Append("</div>");

                        #endregion

                        SetprogressBar1Val(i + 1);
                        SetlblStatuText((i + 1).ToString());
                    }
                    #endregion

                    string tempstr = "";                   
                    
                    using (StreamReader sr = new StreamReader(temphtml, Encoding.Default))
                    {
                        tempstr = sr.ReadToEnd().Replace("<$$tablestruct$$>", htmlBody.ToString());
                        sr.Close();
                    }

                    SaveFileDialog savedlg = new SaveFileDialog
                    {
                        Title = "保存表结构",
                        Filter = "htm files (*.htm)|*.htm|All files (*.*)|*.*",
                        FileName = dbName + "数据库表结构文档.htm"
                    };
                    DialogResult dlgresult = savedlg.ShowDialog(this);
                    if (dlgresult == DialogResult.OK)
                    {
                        string filename = savedlg.FileName;
                        using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Default))
                        {
                            sw.Write(tempstr);
                            sw.Flush();
                            sw.Close();
                        }
                    }
                    
                    SetBtnEnable();
                    MessageBox.Show(this, "文档生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(this,"文档生成失败！(" + ex.Message + ")。\r\n请关闭重试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        #endregion 

        /// <summary>
        /// 定位到文档结尾
        /// </summary>
        public void GoToTheEnd()
        {
            object missing = System.Reflection.Missing.Value;
            object unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            WordApp.Selection.EndKey(ref unit, ref missing);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label4.Visible = true;
                comboBox1.Visible = false;
                label5.Visible = false;
            }
            else
            {
                label4.Visible = false;
                comboBox1.Visible = true;
                label5.Visible = true;
            }
        }   

        #region 
        ////生成表格
        //public void MakeMyTable(DataTable DT, string strFilePath)
        //{
        //    string strStart = "1";
        //    string strEnd = "3";            
        //    //生成文档分页中的起始和终止页
        //    string strSign = "(" + strStart + "-" + strEnd + ")";

        //    //杀掉所有word进程以保证速度
        //    //KillWordProcess();

        //    object Nothing = System.Reflection.Missing.Value;
        //    object missing = System.Reflection.Missing.Value;
        //    object filename = strFilePath;

        //    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
        //    Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

        //    try
        //    {
        //        //生成过程中屏蔽返回按扭，不允许中途停止
        //        //Button2.Enabled = false;
                
        //        #region 生成文档
        //        //设置文档宽度
        //        wordApp.Selection.PageSetup.LeftMargin = wordApp.CentimetersToPoints(float.Parse("2"));
        //        wordApp.ActiveWindow.ActivePane.HorizontalPercentScrolled = 11;
        //        wordApp.Selection.PageSetup.RightMargin = wordApp.CentimetersToPoints(float.Parse("2"));

        //        Object start = Type.Missing;
        //        Object end = Type.Missing;
        //        Object unit = Type.Missing;
        //        Object count = Type.Missing;
        //        wordDoc.Range(ref start, ref end).Delete(ref unit, ref count);
                
        //        object rng = Type.Missing;
        //        string strInfo = "明细表" + strSign + "\r\n";
        //        start = 0;
        //        end = 0;
        //        wordDoc.Range(ref start, ref end).InsertBefore(strInfo);
        //        wordDoc.Range(ref start, ref end).Font.Name = "Verdana";
        //        wordDoc.Range(ref start, ref end).Font.Size = 20;
        //        wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

        //        start = 8;
        //        end = strInfo.Length;
        //        wordDoc.Range(ref start, ref end).InsertParagraphAfter();//插入回车

        //        if (DT.Rows.Count > 0)
        //        {
        //            //存在数据项
        //            //添加一个表格
        //            object missingValue = Type.Missing;
        //            object location = strInfo.Length; //注：若location超过已有字符的长度将会出错。一定要比"明细表"串多一个字符
        //            Microsoft.Office.Interop.Word.Range rng2 = wordDoc.Range(ref location, ref location);

        //            wordDoc.Tables.Add(rng2, 13, 6, ref missingValue, ref missingValue);
        //            wordDoc.Tables.Item(1).Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
        //            wordDoc.Tables.Item(1).Rows.Height = wordApp.CentimetersToPoints(float.Parse("0.8"));
        //            wordDoc.Tables.Item(1).Range.Font.Size = 10;
        //            wordDoc.Tables.Item(1).Range.Font.Name = "宋体";
        //            wordDoc.Tables.Item(1).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //            wordDoc.Tables.Item(1).Range.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    
        //            //设置表格样式
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            wordDoc.Tables.Item(1).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;

        //            //     wordDoc.Tables.Item(k).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderDiagonalDown).LineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
        //            //     wordDoc.Tables.Item(k).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderDiagonalDown).LineWidth = Microsoft.Office.Interop.Word.WdLineWidth.wdLineWidth050pt;
        //            //     wordDoc.Tables.Item(k).Borders.Item(Microsoft.Office.Interop.Word.WdBorderType.wdBorderDiagonalDown).Color = Microsoft.Office.Interop.Word.WdColor.wdColorAutomatic;
                    
        //            //第一行显示
        //            wordDoc.Tables.Item(1).Cell(1, 2).Merge(wordDoc.Tables.Item(1).Cell(1, 3));
        //            wordDoc.Tables.Item(1).Cell(1, 4).Merge(wordDoc.Tables.Item(1).Cell(1, 5));

        //            //第二行显示
        //            wordDoc.Tables.Item(1).Cell(2, 5).Merge(wordDoc.Tables.Item(1).Cell(2, 6));
        //            wordDoc.Tables.Item(1).Cell(1, 4).Merge(wordDoc.Tables.Item(1).Cell(2, 5));

        //            #region 插入数据行
        //            wordDoc.Tables.Item(1).Cell(1, 1).Range.Text = "cell11";
        //            //wordDoc.Tables.Item(k).Cell(1, 2).Range.Text = DT.Rows[i]["cell11"].ToString();


        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(1, 3).Range.Text = "cell13";
        //            //wordDoc.Tables.Item(k).Cell(1, 4).Range.Text = DT.Rows[i]["cell13"].ToString();


        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(2, 1).Range.Text = "cell21";
        //            //wordDoc.Tables.Item(k).Cell(2, 2).Range.Text = DT.Rows[i]["cell21"].ToString();


        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(2, 3).Range.Text = "cell23";
        //            //wordDoc.Tables.Item(k).Cell(2, 4).Range.Text = DT.Rows[i]["cell23"].ToString();

        //            #endregion
                    
        //            #region 第三行显示
        //            wordDoc.Tables.Item(1).Cell(3, 2).Merge(wordDoc.Tables.Item(1).Cell(3, 3));
        //            wordDoc.Tables.Item(1).Cell(3, 2).Merge(wordDoc.Tables.Item(1).Cell(3, 3));

        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(3, 1).Range.Text = "cell31";
                                        
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(3, 3).Range.Text = "cell33";


        //            #endregion
                    
        //            #region 第五行显示
        //            wordDoc.Tables.Item(1).Cell(5, 2).Merge(wordDoc.Tables.Item(1).Cell(5, 3));
        //            wordDoc.Tables.Item(1).Cell(5, 2).Merge(wordDoc.Tables.Item(1).Cell(5, 3));
        //            wordDoc.Tables.Item(1).Cell(5, 2).Merge(wordDoc.Tables.Item(1).Cell(5, 3));
        //            wordDoc.Tables.Item(1).Cell(5, 2).Merge(wordDoc.Tables.Item(1).Cell(5, 3));
        //            #endregion
                    
        //            #region  第四行显示
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(4, 1).Range.Text = "cell41";
                    
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(4, 3).Range.Text = "cell43";
                    
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(4, 5).Range.Text = "cell45";
        //            #endregion
                    
        //            #region 第六行显示
        //            wordDoc.Tables.Item(1).Cell(6, 2).Merge(wordDoc.Tables.Item(1).Cell(6, 3));
        //            wordDoc.Tables.Item(1).Cell(6, 2).Merge(wordDoc.Tables.Item(1).Cell(6, 3));
        //            wordDoc.Tables.Item(1).Cell(6, 2).Merge(wordDoc.Tables.Item(1).Cell(6, 3));
        //            wordDoc.Tables.Item(1).Cell(6, 2).Merge(wordDoc.Tables.Item(1).Cell(6, 3));
                    
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(5, 1).Range.Text = "cell51";
        //            wordDoc.Tables.Item(1).Cell(5, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(6, 1).Range.Text = "cdll61";
        //            wordDoc.Tables.Item(1).Cell(6, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
        //            #endregion
                    
        //            #region 第七行显示
        //            wordDoc.Tables.Item(1).Cell(7, 2).Merge(wordDoc.Tables.Item(1).Cell(7, 3));
        //            wordDoc.Tables.Item(1).Cell(7, 2).Merge(wordDoc.Tables.Item(1).Cell(7, 3));
        //            wordDoc.Tables.Item(1).Cell(7, 2).Merge(wordDoc.Tables.Item(1).Cell(7, 3));
        //            wordDoc.Tables.Item(1).Cell(7, 2).Merge(wordDoc.Tables.Item(1).Cell(7, 3));

        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(7, 1).Range.Text = "cell71";
        //            wordDoc.Tables.Item(1).Cell(7, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
        //            #endregion
                    
        //            #region 第八行显示
        //            wordDoc.Tables.Item(1).Cell(8, 1).Merge(wordDoc.Tables.Item(1).Cell(8, 2));
        //            wordDoc.Tables.Item(1).Cell(8, 2).Merge(wordDoc.Tables.Item(1).Cell(8, 3));
        //            wordDoc.Tables.Item(1).Cell(8, 2).Merge(wordDoc.Tables.Item(1).Cell(8, 3));
        //            wordDoc.Tables.Item(1).Cell(8, 2).Merge(wordDoc.Tables.Item(1).Cell(8, 3));
        //            #endregion
                    
        //            #region 第九行显示
        //            wordDoc.Tables.Item(1).Cell(9, 1).Merge(wordDoc.Tables.Item(1).Cell(9, 2));
        //            wordDoc.Tables.Item(1).Cell(9, 3).Merge(wordDoc.Tables.Item(1).Cell(9, 4));

        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(9, 1).Range.Text = "cell91";
        //            //wordDoc.Tables.Item(k).Cell(9, 2).Range.Text =  (DT.Rows[i]["cell91"].ToString()=="1"?"有":"无");
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(9, 3).Range.Text = "cell93";
        //            #endregion
                    
        //            #region 第十行显示
        //            wordDoc.Tables.Item(1).Cell(10, 1).Merge(wordDoc.Tables.Item(1).Cell(10, 2));
        //            wordDoc.Tables.Item(1).Cell(10, 3).Merge(wordDoc.Tables.Item(1).Cell(10, 4));
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(10, 1).Range.Text = "cell101";
                    
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(10, 3).Range.Text = "cdll103";
        //            //wordDoc.Tables.Item(k).Cell(10, 4).Range.Text = (DT.Rows[i]["Label"].ToString()=="1"?"有":"无");
        //            #endregion
                    
        //            #region 第十一行显示
        //            wordDoc.Tables.Item(1).Cell(11, 1).Merge(wordDoc.Tables.Item(1).Cell(11, 2));
        //            wordDoc.Tables.Item(1).Cell(11, 3).Merge(wordDoc.Tables.Item(1).Cell(11, 4));
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(11, 1).Range.Text = "cell111";
                    
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(11, 3).Range.Text = "cell113";
        //            #endregion
                    
        //            #region 第十二行显示
        //            wordDoc.Tables.Item(1).Cell(12, 1).Merge(wordDoc.Tables.Item(1).Cell(12, 2));
        //            wordDoc.Tables.Item(1).Cell(12, 3).Merge(wordDoc.Tables.Item(1).Cell(12, 4));
        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(12, 1).Range.Text = "cell121";


        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(12, 3).Range.Text = "cell123";

        //            #endregion


        //            #region 第十三行显示
        //            wordDoc.Tables.Item(1).Cell(13, 1).Merge(wordDoc.Tables.Item(1).Cell(13, 2));
        //            wordDoc.Tables.Item(1).Cell(13, 3).Merge(wordDoc.Tables.Item(1).Cell(13, 4));

        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(13, 1).Range.Text = "cell131";


        //            ////******************
        //            wordDoc.Tables.Item(1).Cell(13, 3).Range.Text = "cell133";

        //            #endregion

        //            wordDoc.Tables.Item(1).Select();
        //            wordApp.Application.Selection.Cut();

        //            //重新成声所有表                    
        //            for (int i = 0; i <= DT.Rows.Count - 1; i++)
        //            {
        //                wordApp.Application.Selection.Paste();
        //                int k = i + 1;

        //                #region    更新数据

        //                #region 插入数据行

        //                wordDoc.Tables.Item(k).Cell(1, 2).Range.Text = DT.Rows[i]["1"].ToString();                        
        //                wordDoc.Tables.Item(k).Cell(1, 4).Range.Text = DT.Rows[i]["2"].ToString();
        //                wordDoc.Tables.Item(k).Cell(2, 2).Range.Text = DT.Rows[i]["3"].ToString();
        //                wordDoc.Tables.Item(k).Cell(2, 4).Range.Text = DT.Rows[i]["4"].ToString();
        //                #endregion
                        
        //                #region 第三行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(3, 2).Range.Text = DT.Rows[i]["5"].ToString();
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(3, 4).Range.Text = DT.Rows[i]["6"].ToString();

        //                #endregion
                        
        //                #region 第五行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(5, 2).Range.Text = DT.Rows[i]["7"].ToString();
        //                wordDoc.Tables.Item(k).Cell(5, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
        //                #endregion

        //                #region  第四行显示

        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(4, 2).Range.Text = DT.Rows[i]["8"].ToString();


        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(4, 4).Range.Text = DT.Rows[i]["9"].ToString();


        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(4, 6).Range.Text = DT.Rows[i]["0"].ToString();
        //                #endregion
                        
        //                #region 第六行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(6, 2).Range.Text = DT.Rows[i]["11"].ToString();
        //                wordDoc.Tables.Item(k).Cell(6, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
        //                #endregion
                        
        //                #region 第七行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(7, 2).Range.Text = DT.Rows[i]["12"].ToString();
        //                wordDoc.Tables.Item(k).Cell(7, 2).Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
        //                #endregion
                        
        //                #region 第八行显示
        //                ////******************

        //                string strTechlevel = DT.Rows[i]["Level"].ToString();
        //                string returnTechlevel = "";
        //                switch (strTechlevel)
        //                {
        //                    case "1":
        //                        returnTechlevel = "Level1";
        //                        break;
        //                    case "2":
        //                        returnTechlevel = "Level2";
        //                        break;
        //                    case "3":
        //                        returnTechlevel = "Level3";
        //                        break;
        //                    case "0":
        //                        returnTechlevel = "Level4";
        //                        break;
        //                    default:
        //                        returnTechlevel = "Level5";
        //                        break;
        //                }
        //                wordDoc.Tables.Item(k).Cell(8, 2).Range.Text = returnTechlevel;

        //                #endregion
                        
        //                #region 第九行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(9, 2).Range.Text = (DT.Rows[i]["14"].ToString() == "1" ? "有" : "无");



        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(9, 4).Range.Text = (DT.Rows[i]["15"].ToString() == "1" ? "是" : "否");
        //                #endregion
                        
        //                #region 第十行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(10, 2).Range.Text = (DT.Rows[i]["16"].ToString() == "1" ? "有" : "无");


        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(10, 4).Range.Text = (DT.Rows[i]["17"].ToString() == "1" ? "有" : "无");
        //                #endregion
                        
        //                #region 第十一行显示

        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(11, 2).Range.Text = (DT.Rows[i]["18"].ToString() == "1" ? "是" : "否");


        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(11, 4).Range.Text = (DT.Rows[i]["19"].ToString() == "1" ? "是" : "否");
        //                #endregion
                        
        //                #region 第十二行显示
        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(12, 2).Range.Text = (DT.Rows[i]["20"].ToString() == "1" ? "是" : "否");

        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(12, 4).Range.Text = (DT.Rows[i]["21"].ToString() == "1" ? "是" : "否");
        //                #endregion
                        
        //                #region 第十三行显示


        //                wordDoc.Tables.Item(k).Cell(13, 2).Range.Text = (DT.Rows[i]["22"].ToString() == "1" ? "是" : "否");

        //                ////******************

        //                wordDoc.Tables.Item(k).Cell(13, 4).Range.Text = (DT.Rows[i]["23"].ToString() == "1" ? "是" : "否");
        //                #endregion

        //                #endregion

        //                //插入分页
        //                if (i != DT.Rows.Count - 1)
        //                {
        //                    object mymissing = System.Reflection.Missing.Value;
        //                    object myunit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
        //                    wordApp.Selection.EndKey(ref myunit, ref mymissing);

        //                    object pBreak = (int)Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak;
        //                    wordApp.Selection.InsertBreak(ref pBreak);
        //                }
        //            }


        //            wordDoc.SaveAs(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
        //            wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
        //            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
        //            if (wordDoc != null)
        //            {
        //                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
        //                wordDoc = null;
        //            }
        //            if (wordApp != null)
        //            {
        //                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
        //                wordApp = null;
        //            }
        //            GC.Collect();

        //            //KillWordProcess();                    
        //            utility.ShowPopMessage("文档生成完毕！");
        //        }
        //        else
        //        {
        //            utility.ShowPopMessage("无任何数据！");
        //        }
        //        #endregion
        //    }
        //    catch
        //    {
        //        wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
        //        wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
        //        if (wordDoc != null)
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
        //            wordDoc = null;
        //        }
        //        if (wordApp != null)
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
        //            wordApp = null;
        //        }
        //        GC.Collect();
        //        utility.ShowPopMessage("文档生成失败！");

        //    }
        //}

        #endregion

        #endregion
    }
}
