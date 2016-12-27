using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Xml;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// MakerMvcUI
    /// 
    /// 2016-03-28 V3.0 XuWangBin 新增生成“创建MVC UI的界面代码”。
    /// 
    /// </summary>
    public partial class MakerMvcUI : Form
    {
        DbSettings dbSet;
        List<DataTypeReference> listDataTypeRefer = null;
        StringCollection sCollection;

        /// <summary>
        /// 设计文档
        /// </summary>
        private XmlDocument xmlDocument = new XmlDocument();

        public IDbObject idbObj { get; set; }

        /// <summary>
        /// 当前表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表的中文名称（表描述）
        /// </summary>
        public string TableDescription
        {
            get { return this.txtTableDescription.Text.Trim(); }
        }

        private string _serverName = string.Empty;
        /// <summary>
        /// 当前服务器
        /// </summary>
        public string ServerName
        {
            get{return _serverName;}
            set{_serverName = value;}
        }
        
        string _dbName=string.Empty;
        /// <summary>
        /// 当前数据库名称
        /// </summary>
        public string DBName
        {
            get { return _dbName; }
            set { _dbName = value; }
        }       

        /// <summary>
        /// 获取类名
        /// </summary>
        public string GetClassName
        {
            get {
                return string.IsNullOrEmpty(this.txtName.Text) ? string.Empty : this.txtName.Text.Trim();
            }
        }

        #region 代码生成相关属性设置
        private string company = string.Empty;
        private string project = string.Empty;
        private string author  = string.Empty;
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

        private DbView _currentDbViewForm = null;
        public DbView CurrentDbViewForm
        {
            get { return _currentDbViewForm; }
            set { _currentDbViewForm = value; }
        }

        public MakerMvcUI()
        {
            TableName = string.Empty;
            InitializeComponent();
        }

        private void MakerWebUI_Shown(object sender, EventArgs e)
        {           
            this.codeEditorIndexCshtml.SetCodeEditorContent("HTML", string.Empty);
            this.codeEditorFormCshtml.SetCodeEditorContent("HTML", string.Empty);
            this.codeEditorController.SetCodeEditorContent("CS", string.Empty);
            this.codeEditorJs.SetCodeEditorContent("JavaScript", string.Empty);
            GetProjectPorpery();
            BuilderIndexCshtml();
        }

        private void GetProjectPorpery()
        {
            var setHelper = new SettingHelper();
            setHelper.GetSetting();
            this.Project = setHelper.Project;
            this.Compay = setHelper.Company;
            this.Author = setHelper.Author;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetProjectPorpery();
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPIndexCshtml": //Index.cshtml页面文件
                    BuilderIndexCshtml();
                    break;
                case "tabPFormCshtml": //生成Form.cshtml编辑界面
                    BuilderFormCshtml();
                    break;
                case "tabPController": //生成Contorller文件
                    BuilerController();
                    break;
                case "tabPJs": //生成js
                    BuilderJs();
                    break;
                default: //定义
                    break;
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region 生成Index.cshtml页面文件 private void BuilderIndexCshtml()
        private void BuilderIndexCshtml()
        {
            this.codeEditorIndexCshtml.Text = string.Empty;
            var codeMaker = new DBCodeWebUIMaker(idbObj,this.DBName,this.TableName);
            CodeOptions optins = new CodeOptions
            {
                ModelName = this.TableName,
                NameSpace = "RDIFramework.MvcApp",
                tableName = this.TableName
            };
            string templatePaht = Application.StartupPath + @"\Templates\MvcUI\";
            NVelocityHelper vel = new NVelocityHelper(templatePaht);
            vel.Put("code", optins);
            string stringResult = vel.FileToString("IndexCshtml.vm");
            this.codeEditorIndexCshtml.SetCodeEditorContent("Aspx", stringResult);
            this.codeEditorIndexCshtml.SaveFileName = this.TableName;
        }
        #endregion

        #region 生成Form.cshtml编辑界面 private void BuilderFormCshtml()
        private void BuilderFormCshtml()
        {
            var codeMaker = new DBCodeWebUIMaker(idbObj, this.DBName, this.TableName);
            CodeOptions optins = new CodeOptions
            {
                ModelName = this.TableName,
                //NameSpace = "RDIFramework.MvcApp",
                tableName = this.TableName,
                dbName = this.DBName,
                dbObj = idbObj
            };

            string templatePaht = Application.StartupPath + @"\Templates\MvcUI\";
            NVelocityHelper vel = new NVelocityHelper(templatePaht);
            vel.Put("options", optins);
            string stringResult =  vel.FileToString("FormCshtml.vm");
            this.codeEditorFormCshtml.SetCodeEditorContent("HTML", stringResult);
            this.codeEditorFormCshtml.SaveFileName = "Form";
        }
        #endregion

        #region 生成Js文件 private void BuilderJs()
        private void BuilderJs()
        {
            var codeMaker = new DBCodeWebUIMaker(idbObj, this.DBName, this.TableName);
            CodeOptions optins = new CodeOptions
            {
                ModelName = this.TableName,
                //NameSpace = "RDIFramework.MvcApp",
                tableName = this.TableName,
                dbName = this.DBName,
                dbObj = idbObj
            };

            string templatePaht = Application.StartupPath + @"\Templates\MvcUI\";
            NVelocityHelper vel = new NVelocityHelper(templatePaht);
            vel.Put("options", optins);
            string stringResult = vel.FileToString("JavaScript.vm");
            this.codeEditorJs.SetCodeEditorContent("JavaScript", stringResult);
            this.codeEditorJs.SaveFileName = this.TableName;
        }
        #endregion

        #region 生成Controller文件 private void BuilerController()
        /// <summary>
        /// 生成Controller文件
        /// </summary>
        private void BuilerController()
        {
            var codeMaker = new DBCodeWebUIMaker(idbObj, this.DBName, this.TableName);
            var optins = new CodeOptions
            {
                ModelName = this.TableName,
                NameSpace = "RDIFramework.MvcApp.Areas.ExampleModule.Controllers",
                tableName = this.TableName,
                dbName = this.DBName,
                dbObj = idbObj
            };

            string templatePaht = Application.StartupPath + @"\Templates\MvcUI\";
            NVelocityHelper vel = new NVelocityHelper(templatePaht);
            vel.Put("options", optins);
            string stringResult = vel.FileToString("Controller.vm");
            this.codeEditorController.SetCodeEditorContent("CS", stringResult);
            this.codeEditorController.SaveFileName = this.TableName + "Controller.cs";
        }
        #endregion
    }
}
