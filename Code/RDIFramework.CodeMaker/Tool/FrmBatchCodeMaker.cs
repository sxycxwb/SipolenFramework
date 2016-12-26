using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    public partial class FrmBatchCodeMaker : Form
    {
        Thread mythread;       
        IDbObject dbobj;//数据库对象
        DbSettings dbset;//服务器配置
        string dbname = "";
        delegate void SetBtnEnableEventHandler();
        delegate void SetBtnDisableEventHandler();
        delegate void SetLblStatusEventHandler(string text);
        delegate void SetProBar1MaxEventHandler(int val);
        delegate void SetProBar1ValueEventHandler(int val);

        #region 代码生成相关属性设置
        private string outputPath = string.Empty;
        private string company = string.Empty;
        private string project = string.Empty;
        private string author = string.Empty;
        private string createYear = string.Empty;
        private string createDate = string.Empty;
        private string className = string.Empty;

        public string OutPutPath
        {
            get { return this.outputPath; }
            set { this.outputPath = value; }
        }

        public string ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }
        public string CreateYear
        {
            get { return this.createYear; }
            set { this.createYear = value; }
        }

        public string CreateDate
        {
            get { return this.createDate; }
            set { this.createDate = value; }
        }

        public string Compay
        {
            get { return this.company; }
            set { this.company = value; }
        }
        public string Project
        {
            get { return this.project; }
            set { this.project = value; }
        }
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }
        #endregion

        public FrmBatchCodeMaker(string longservername)
        {
            InitializeComponent();
            dbset = DbConfig.GetSetting(longservername);
            dbobj = DBOMaker.CreateDbObj(dbset.DbType);
            dbobj.DbConnectStr = dbset.ConnectStr;     
            this.lblServer.Text = dbset.Server;
        }

        private void FrmBatchCodeMaker_Shown(object sender, EventArgs e)
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
                        foreach (string dbname in dblist)
                        {
                            this.cboDBList.Items.Add(dbname);
                        }
                    }
                }
            }
            else
            {
                this.cboDBList.Items.Add(dbset.DbName);
            }

            if (this.cboDBList.Items.Count > 0)
            {
                this.cboDBList.SelectedIndex = 0;
            }
            else
            {
                List<string> tabNames = dbobj.GetTables("");
                this.listTable1.Items.Clear();
                this.listTable2.Items.Clear();
                if (tabNames.Count > 0)
                {
                    foreach (string tabname in tabNames)
                    {
                        listTable1.Items.Add(tabname);
                    }
                }
            }
            this.btnExport.Enabled = false;
            SettingHelper setting = new SettingHelper();
            setting.GetSetting();
            txtTargetFolder.Text = setting.Output;
            txtNamespace.Text = setting.Project;
            txtCompanyName.Text = setting.Company;
            txtDeveloper.Text = setting.Author;
            txtCreateYear.Text = DateTime.Now.Year.ToString();
            txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }

        #region ListBox相关控制
        private void btnAddlist_Click(object sender, EventArgs e)
        {
            int c = this.listTable1.Items.Count;
            for (int i = 0; i < c; i++)
            {
                this.listTable2.Items.Add(this.listTable1.Items[i]);
            }
            this.listTable1.Items.Clear();

            IsHasItem();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int c = this.listTable1.SelectedItems.Count;
            ListBox.SelectedObjectCollection objs = this.listTable1.SelectedItems;
            for (int i = 0; i < c; i++)
            {
                this.listTable2.Items.Add(listTable1.SelectedItems[i]);

            }
            for (int i = 0; i < c; i++)
            {
                if (this.listTable1.SelectedItems.Count > 0)
                {
                    this.listTable1.Items.Remove(listTable1.SelectedItems[0]);
                }
            }
            IsHasItem();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int c = this.listTable2.SelectedItems.Count;
            ListBox.SelectedObjectCollection objs = this.listTable2.SelectedItems;
            for (int i = 0; i < c; i++)
            {
                this.listTable1.Items.Add(listTable2.SelectedItems[i]);

            }
            for (int i = 0; i < c; i++)
            {
                if (this.listTable2.SelectedItems.Count > 0)
                {
                    this.listTable2.Items.Remove(listTable2.SelectedItems[0]);
                }
            }

            IsHasItem();
        }

        private void btnDelList_Click(object sender, EventArgs e)
        {
            int c = this.listTable2.Items.Count;
            for (int i = 0; i < c; i++)
            {
                this.listTable1.Items.Add(this.listTable2.Items[i]);
            }
            this.listTable2.Items.Clear();
            IsHasItem();	
        }

        private void listTable1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listTable1.SelectedItem != null)
            {
                this.listTable2.Items.Add(listTable1.SelectedItem);
                this.listTable1.Items.Remove(this.listTable1.SelectedItem);
                IsHasItem();
            }
        }

        private void listTable2_DoubleClick(object sender, EventArgs e)
        {
            if (this.listTable2.SelectedItem != null)
            {
                this.listTable1.Items.Add(listTable2.SelectedItem);
                this.listTable2.Items.Remove(this.listTable2.SelectedItem);
                IsHasItem();
            }
        }

        /// <summary>
        /// 判断listbox有没有项目
        /// </summary>
        private void IsHasItem()
        {
            if (this.listTable1.Items.Count > 0)
            {
                this.btnAdd.Enabled = true;
                this.btnAddlist.Enabled = true;
            }
            else
            {
                this.btnAdd.Enabled = false;
                this.btnAddlist.Enabled = false;
            }
            if (this.listTable2.Items.Count > 0)
            {
                this.btnDel.Enabled = true;
                this.btnDelList.Enabled = true;
                this.btnExport.Enabled = true;
            }
            else
            {
                this.btnDel.Enabled = false;
                this.btnDelList.Enabled = false;
                this.btnExport.Enabled = false;
            }
        }
        #endregion

        #region 控件设置
        public void SetBtnEnable()
        {
            if (this.btnExport.InvokeRequired)
            {
                SetBtnEnableEventHandler d = new SetBtnEnableEventHandler(SetBtnEnable);
                this.Invoke(d, null);
            }
            else
            {
                this.btnExport.Enabled = true;
                this.btnClose.Enabled = true;
            }
        }
        public void SetBtnDisable()
        {
            if (this.btnExport.InvokeRequired)
            {
                SetBtnDisableEventHandler d = new SetBtnDisableEventHandler(SetBtnDisable);
                this.Invoke(d, null);
            }
            else
            {
                this.btnExport.Enabled = false;
                this.btnClose.Enabled = false;
            }
        }
        public void SetlblStatuText(string text)
        {
            if (this.labelNum.InvokeRequired)
            {
                SetLblStatusEventHandler d = new SetLblStatusEventHandler(SetlblStatuText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelNum.Text = text;
            }
        }
        /// <summary>
        /// 循环网址进度最大值
        /// </summary>
        /// <param name="val"></param>
        public void SetprogressBar1Max(int val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetProBar1MaxEventHandler d = new SetProBar1MaxEventHandler(SetprogressBar1Max);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.progressBar1.Maximum = val;

            }
        }
        /// <summary>
        /// 循环网址进度
        /// </summary>
        /// <param name="val"></param>
        public void SetprogressBar1Val(int val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetProBar1ValueEventHandler d = new SetProBar1ValueEventHandler(SetprogressBar1Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.progressBar1.Value = val;

            }
        }
        #endregion

        private void cboDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> tabNames = dbobj.GetTables(cboDBList.Text);
            this.listTable1.Items.Clear();
            this.listTable2.Items.Clear();
            if (tabNames.Count > 0)
            {
                foreach (string tabname in tabNames)
                {
                    listTable1.Items.Add(tabname);
                }
            }

            IsHasItem();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtTargetFolder.Text = folderBrowserDialog1.SelectedPath;               
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTargetFolder.Text.Trim() == "")
                {
                    MessageBox.Show("目标文件夹为空！");
                    return;
                }
                this.Project = txtNamespace.Text.Trim();
                this.CreateDate = txtCreateDate.Text.Trim();
                this.CreateYear = txtCreateYear.Text.Trim();
                this.Author = txtDeveloper.Text.Trim();
                this.OutPutPath = txtTargetFolder.Text.Trim();
                dbname = this.cboDBList.Text;
                pictureBox1.Visible = true;
                mythread = new Thread(new ThreadStart(ThreadWork));
                mythread.Start();
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
        }

        void ThreadWork()
        {
            SetBtnDisable();
            string strnamespace = this.txtNamespace.Text.Trim();
            string strfolder = this.txtTargetFolder.Text.Trim();
            int tblCount = this.listTable2.Items.Count;
            SetprogressBar1Max(tblCount);
            SetprogressBar1Val(1);
            SetlblStatuText("0");            

            #region 循环每个表

            for (int i = 0; i < tblCount; i++)
            {
                string tablename = this.listTable2.Items[i].ToString();
                this.ClassName = tablename;
                DataTable dtkey = dbobj.GetKeyName(dbname, tablename);
                List<ColumnInfo> collist = dbobj.GetColumnInfoList(dbname, tablename);
                this.BuilderEntity(this.OutPutPath,tablename);
                this.BuilderTable(this.OutPutPath, tablename);
                this.BuilderManager(this.OutPutPath, tablename);
                string fileName = this.OutPutPath + "\\" + this.Project + ".BizLogic\\IService\\" + "I" + className + "Service.cs";
                this.BuilderIServic(fileName, tablename);
                fileName = this.OutPutPath + "\\" + this.Project + ".BizLogic\\Service\\" + className + "Service.cs";
                this.BuilderService(fileName, tablename);
                SetprogressBar1Val(i + 1);
                SetlblStatuText((i + 1).ToString());
            }

            #endregion

            SetBtnEnable();
            this.Invoke(new MethodInvoker(() => { MessageBox.Show(this, "代码批量生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information); }));
        }

        private string ReplaceAssemblyInfo(string code)
        {
            code = code.Replace("#Author#", this.Author);
            code = code.Replace("#ClassName#", this.ClassName);
            //code = code.Replace("#Code#", this.codeEditorManager.Text);
            code = code.Replace("#Company#", this.Compay);
            code = code.Replace("#DateCreated#", this.CreateDate);
            code = code.Replace("#Project#", this.Project);
            code = code.Replace("#YearCreated#", this.CreateYear);
            code = code.Replace("#Title#", string.Empty);
            code = code.Replace("#Description#", string.Empty);
            return code;
        }

        #region 生成存储表
        private void BuilderTable(string outPutFile,string tabName)
        {
            DBCodeMaker codeMaker = new DBCodeMaker(dbobj, this.dbname, tabName,this.CompanyName, this.Project, this.Author, this.ClassName, "Table", tabName,string.Empty);
            codeMaker.BuilderTable(outPutFile, true);
        }
        #endregion

        #region 生成实体类
        private void BuilderEntity(string outPutFile, string tabName)
        {
            DBCodeMaker codeMaker = new DBCodeMaker(dbobj, this.dbname, tabName, this.CompanyName, this.Project, this.Author, this.ClassName, "Entity", tabName, string.Empty);
            codeMaker.BuilderEntity(outPutFile,true);
        }
        #endregion

        #region 生成管理器
        private void BuilderManager(string outPutFile, string tabName)
        {
            DBCodeMaker codeMaker = new DBCodeMaker(dbobj, this.dbname, tabName, this.CompanyName, this.Project, this.Author, this.ClassName, "Manager", tabName, string.Empty);
            codeMaker.BuilderManager(outPutFile, true);
        }
        #endregion

        #region 生成服务接口
        private void BuilderIServic(string outPutFile, string tabName)
        {
            string file = Application.StartupPath + "\\Templates\\IService.cst";
            string code = CodeMakerLibary.GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            DBCodeMaker.WriteCode(outPutFile, true, code);
        }
        #endregion

        #region 生成服务
        private void BuilderService(string outPutFile, string tabName)
        {
            string file = Application.StartupPath + "\\Templates\\Service.cst";
            string code = CodeMakerLibary.GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            DBCodeMaker.WriteCode(outPutFile, true, code);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
