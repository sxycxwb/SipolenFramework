using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// DataObjectForm
    /// 
    /// 2015-04-30 V2.9 XuWangBin 新增生成“生成数据库脚本”
    /// 
    /// </summary>
    public partial class DataObjectForm : Form
    {
        IDbObject idbObj;
        DbSettings dbSet;
        List<DataTypeReference> listDataTypeRefer = null;
        StringCollection sCollection;
        ScriptingOptions scriptOption = new ScriptingOptions();
        /// <summary>
        /// 设计文档
        /// </summary>
        private XmlDocument xmlDocument = new XmlDocument();

        string _tableName = string.Empty;
        /// <summary>
        /// 当前表名
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { this._tableName = value; }
        }

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

        public DataObjectForm()
        {
            InitializeComponent();            
        }

        private void DataObjectForm_Shown(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
            this.textEditorEntity.SetCodeEditorContent("CS", string.Empty);
            this.textEditorEntity.SetCodeEditorContent("SQL", string.Empty);
            this.textEditorEntity.SetCodeEditorContent("CS", string.Empty);
            GetProjectPorpery();
            GenerateDataGridView();
        }

        private void GetProjectPorpery()
        {
            var setHelper = new SettingHelper();
            setHelper.GetSetting();
            this.Project = setHelper.Project;
            this.Compay = setHelper.Company;
            this.Author = setHelper.Author;
        }

        #region public void GenerateDataGridView() 生成表列展示
        public void GenerateDataGridView()
        {
            if (this.CurrentDbViewForm == null)
            {
                MessageBox.Show("无可用对象！");
            }

            dgvDefine.AutoGenerateColumns = false;

            #region 手动生成列（已注释）
            /*
            DataGridViewTextBoxColumn colAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAttribute.DataPropertyName = "ColumnName";
            colAttribute.HeaderText = "属性名称";
            colAttribute.Name = "colAttribute";

            DataGridViewComboBoxColumn colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            colAttribute.DataPropertyName = "TypeName";
            colAttribute.HeaderText = "类型";
            colAttribute.Name = "colType";

            DataGridViewTextBoxColumn colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAttribute.DataPropertyName = "ColDescription";
            colAttribute.HeaderText = "标题";
            colAttribute.Name = "colTitle";

            DataGridViewTextBoxColumn colDTColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAttribute.DataPropertyName = "ColumnName";
            colAttribute.HeaderText = "列名";
            colAttribute.Name = "colDTColumnName";

            DataGridViewComboBoxColumn colDTDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            colAttribute.DataPropertyName = "";
            colAttribute.HeaderText = "数据类型";
            colAttribute.Name = "colDTDataType";

            DataGridViewTextBoxColumn colDTDataLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAttribute.DataPropertyName = "Length";
            colAttribute.HeaderText = "长度";
            colAttribute.Name = "colDTDataLength";

            DataGridViewTextBoxColumn colDTDataPreci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAttribute.DataPropertyName = "Preci";
            colAttribute.HeaderText = "小数";
            colAttribute.Name = "colDTDataPreci";

            DataGridViewCheckBoxColumn colDTDataNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colAttribute.DataPropertyName = "IsNull";
            colAttribute.HeaderText = "非空";
            colDTDataNull.Width = 45;
            colAttribute.Name = "colDTDataNull";

            DataGridViewCheckBoxColumn colDTDataPrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colAttribute.DataPropertyName = "IsPK";
            colAttribute.HeaderText = "主键";
            colDTDataNull.Width = 45;
            colAttribute.Name = "colDTDataPrimaryKey";

            DataGridViewCheckBoxColumn colDTDataIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colAttribute.DataPropertyName = "IsIdentity";
            colAttribute.HeaderText = "自增";
            colDTDataNull.Width = 45;
            colAttribute.Name = "colDTDataIdentity";

            DataGridViewTextBoxColumn colDTDataDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colAttribute.DataPropertyName = "DefaultVal";
            colAttribute.HeaderText = "默认值";
            colAttribute.Name = "colDTDataDefaultValue";

            this.dgvDefine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] 
            { 
                colAttribute, colType, colTitle, colDTColumnName, colDTDataType, colDTDataLength, 
                colDTDataPreci, colDTDataNull, colDTDataPrimaryKey, colDTDataIdentity, colDTDataDefaultValue 
            });
            */
            #endregion

            var selectedNode = this.CurrentDbViewForm.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }
            this.ServerName = selectedNode.Parent.Parent.Parent.Text;            
            this.DBName = selectedNode.Parent.Parent.Text;
            this.TableName = selectedNode.Text;

            txtName.Text = this.TableName;
            txtTableName.Text = this.TableName;
            dbSet = DbConfig.GetSetting(this.ServerName);

            var listDataTypeRefer = GetDataTypeRefer();
            colType.ValueMember = "To";
            colType.DisplayMember = "To";
            colType.DataPropertyName = "To";
            colType.DataSource = listDataTypeRefer;

            colDTDataType.ValueMember = "From";
            colDTDataType.DisplayMember = "From";
            colDTDataType.DataPropertyName = "From";
            colDTDataType.DataSource = listDataTypeRefer;
            //todo:这儿要尽量做到通用。
            idbObj = DBOMaker.CreateDbObj(dbSet.DbType);
            idbObj.DbConnectStr = dbSet.ConnectStr;
            var colList = idbObj.GetColumnInfoList(this.DBName, this.TableName);
            dgvDefine.DataSource = colList;
        }
        #endregion

        private List<DataTypeReference> GetDataTypeRefer()
        {
            var nodeList = XMLHelper.GetXmlNodeListByXpath(Application.StartupPath + @"\Config\DataTypeReference.xml", @"/Languages/Language");
            if (nodeList == null || nodeList.Count <= 0)
            {
                return null;                
            }           
            foreach (XmlNode node in nodeList)
            {
                switch (dbSet.DbType.ToLower())
                {
                    case "sql2008":
                    case "sql2005":
                    case "sql2000":
                    case "sqlserver":
                        if (node.Attributes["From"].Value.ToLower().Trim() == "sqlserver")
                        {
                            listDataTypeRefer = this.GetTypeList(node);                           
                        }
                        break;
                    case "oracle":
                        if (node.Attributes["From"].Value.ToLower().Trim() == "oracle")
                        {
                            listDataTypeRefer = this.GetTypeList(node);
                        }
                        break;
                    default:
                        listDataTypeRefer = this.GetTypeList(node);
                        break;
                }
            }
            return listDataTypeRefer;
        }

        private List<DataTypeReference> GetTypeList(XmlNode node)
        {
            var typeNodeList = node.SelectNodes(@"Type");
            return (from XmlNode nodeTemp in typeNodeList 
                    select new DataTypeReference(nodeTemp.Attributes["From"].Value, nodeTemp.Attributes["To"].Value)).ToList();
        }      

        private string ReplaceAssemblyInfo(string code)
        {
            code = code.Replace("#Author#", this.Author);
            code = code.Replace("#ClassName#", this.GetClassName);
            code = code.Replace("#Code#", this.codeEditorManager.Text);
            code = code.Replace("#Company#", this.Compay);
            code = code.Replace("#DateCreated#", DateTime.Now.ToString("yyyy-MM-dd"));
            code = code.Replace("#Project#", this.Project);
            code = code.Replace("#YearCreated#", DateTime.Now.Year.ToString());
            code = code.Replace("#Title#", this.TableDescription);
            code = code.Replace("#Description#", this.TableDescription);
            return code;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            GetProjectPorpery();
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPDefine": //定义
                    break;
                case "tabPStorageTable": //存储表
                    BuilderTable();
                    break;
                case "tabPEntity": //实体代码
                    BuilderEntity();
                    break;
                case "tabPMvcEntity": //MVC实体
                    BuilerMvcEntity();
                    break;
                case "tabPDDL": //DDL
                    GenerateDDL();
                    break;
                case "tabPManager"://管理器
                    BuilderManager();
                    break;
                case "tabPIService": //服务接口
                    BuilderIService();
                    break;
                case "tabPService"://服务
                    BuilderService();
                    break;
                case "tabGengerateDbScript"://数据库脚本
                    GenerateTableColumns();
                    break;
                case "tabPDoc": //文档
                    GenerateHTML();
                    break;
                default: //定义
                    break;
            }
            // 设置鼠标默认状态，原来的光标状态
            this.Cursor = holdCursor;
        }

        #region 生成存储表
        private void BuilderTable()
        {
            this.codeEditorStorageTable.Text = string.Empty;
            var codeMaker = new DBCodeMaker(idbObj, this.DBName, this.TableName, this.Compay, this.Project, this.Author, this.GetClassName, "Table", this.TableName, this.TableDescription);
            this.codeEditorStorageTable.SetCodeEditorContent("CS", codeMaker.BuilderTable());
            this.codeEditorStorageTable.SaveFileName = this.TableName + "Table";
        }
        #endregion

        #region 生成实体类
        private void BuilderEntity()
        {
            var codeMaker = new DBCodeMaker(idbObj, this.DBName, this.TableName, this.Compay, this.Project, this.Author, this.GetClassName, "Entity", this.TableName, this.TableDescription);
            this.textEditorEntity.SetCodeEditorContent("CS", codeMaker.BuilderEntity());
            this.textEditorEntity.SaveFileName = this.TableName + "Entity";
        }
        #endregion

        /// <summary>
        /// 生成MVC实体
        /// </summary>
        private void BuilerMvcEntity()
        {
            var codeMaker = new DBCodeMaker(idbObj, this.DBName, this.TableName, this.Compay, this.Project, this.Author, this.GetClassName, "Entity", this.TableName, this.TableDescription)
            {
                MVCEntity = true
            };
            this.textEditorMvcEntity.SetCodeEditorContent("CS", codeMaker.BuilderEntity());
            this.textEditorMvcEntity.SaveFileName = this.TableName + "Entity";
        }

        #region 生成管理器
        private void BuilderManager()
        {
            this.codeEditorManager.Text = string.Empty;
            var codeMaker = new DBCodeMaker(idbObj, this.DBName, this.TableName, this.Compay, this.Project, this.Author, this.GetClassName, "Manager", this.TableName, this.TableDescription);
            this.codeEditorManager.SetCodeEditorContent("CS", codeMaker.BuilderManager());
            this.codeEditorManager.SaveFileName = this.TableName + "Manager.Auto";           
        }
        #endregion

        #region 生成DDL
        private void GenerateDDL()
        {
            switch (dbSet.DbType.ToUpper())
            {
                case "SQL2000":
                case "SQL2005":
                case "SQL2008":
                    GenerateSqlServerDDL();
                    break;
            }
            
        }

        private void ScriptOption()
        {
            scriptOption.ContinueScriptingOnError = true;
            scriptOption.IncludeIfNotExists = true;
            scriptOption.NoCollation = true;
            scriptOption.ScriptDrops = false;
            scriptOption.ContinueScriptingOnError = true;
            //scriptOption.DriAllConstraints = true;
            scriptOption.WithDependencies = false;
            scriptOption.DriForeignKeys = true;
            scriptOption.DriPrimaryKey = true;
            scriptOption.DriDefaults = true;
            scriptOption.DriChecks = true;
            scriptOption.DriUniqueKeys = true;
            scriptOption.Triggers = true;
            scriptOption.ExtendedProperties = true;
            scriptOption.NoIdentities = false;
        }

        /// <summary>
        /// 生成数据库类型为SqlServer指定表的DDL
        /// </summary>
        private void GenerateSqlServerDDL()
        {
            //对于已经生成过的就不用再次生成了，节约资源。
            if (!string.IsNullOrEmpty(textEditorDDL.Text) && textEditorDDL.Text.Trim().Length > 10)
            {
                return;
            }

            ScriptOption();
            ServerConnection sqlConnection = null;
            try
            {
                var sbOutPut = new StringBuilder();
                
                if (dbSet.ConnectStr.ToLower().Contains("integrated security")) //Windows身份验证
                {
                    sqlConnection = new ServerConnection(dbSet.Server);
                }
                else        //SqlServer身份验证
                {
                    var linkDataArray = dbSet.ConnectStr.Split(';');
                    var userName = string.Empty;
                    var pwd = string.Empty;
                    foreach (var str in linkDataArray)
                    { 
                        if(str.ToLower().Replace(" ","").Contains("userid="))
                        {
                            userName = str.Split('=')[1];
                        }

                        if (str.ToLower().Replace(" ", "").Contains("password"))
                        {
                            pwd = str.Split('=')[1];
                        }
                    }

                    sqlConnection = new ServerConnection(dbSet.Server,userName,pwd);
                }

                var sqlServer = new Server(sqlConnection);
                var table = sqlServer.Databases[dbSet.DbName].Tables[txtName.Text];
                string ids;
                //编写表的脚本
                sbOutPut = new StringBuilder();
                sbOutPut.AppendLine();
                sCollection = table.Script(scriptOption);

                foreach (var str in sCollection)
                {
                    //此处修正smo的bug
                    if (str.Contains("ADD  DEFAULT") && str.Contains("') AND type = 'D'"))
                    {
                        ids = str.Substring(str.IndexOf("OBJECT_ID(N'") + "OBJECT_ID(N'".Length, str.IndexOf("') AND type = 'D'") - str.IndexOf("OBJECT_ID(N'") - "OBJECT_ID(N'".Length);
                        sbOutPut.AppendLine(str.Insert(str.IndexOf("ADD  DEFAULT") + 4, "CONSTRAINT " + ids));
                    }
                    else
                        sbOutPut.AppendLine(str);

                    sbOutPut.AppendLine("GO");
                }

                //生成存储过程
                this.textEditorDDL.SetCodeEditorContent("SQL", sbOutPut.ToString());
                this.textEditorDDL.SaveFileName = this.TableName + ".sql";
                sbOutPut = new StringBuilder();
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            finally
            {
                sqlConnection.Disconnect();
            }
        }
        #endregion

        #region 生成服务接口
        private void BuilderIService()
        {
            this.codeEditorIService.Text = string.Empty;
            var file = Application.StartupPath + "\\Templates\\IService.cst";
            var code = CodeMakerLibary.GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            this.codeEditorIService.SetCodeEditorContent("CS", code);
            codeEditorIService.SaveFileName = "I" + this.TableName + "Service";
        }
        #endregion

        #region 生成服务
        private void BuilderService()
        {
            this.codeEditorService.Text = string.Empty;          
            var file = Application.StartupPath + "\\Templates\\Service.cst";
            var code = CodeMakerLibary.GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            this.codeEditorService.SetCodeEditorContent("CS", code);
            this.codeEditorService.SaveFileName = this.GetClassName + "Service";           
        }
        #endregion

        #region 生成数据库脚本
        private void GenerateTableColumns()
        {
            var codeMaker = new DBCodeMaker(idbObj, this.DBName, this.TableName, this.Compay, this.Project, this.Author, this.GetClassName, "Table", this.TableName, this.TableDescription);
            this.codeGengerateDbScript.SetCodeEditorContent("SQL", codeMaker.DBSQL());
            this.codeGengerateDbScript.SaveFileName = this.GetClassName + "TableColumns.sql";     
        }
        #endregion

        #region 生成HTML格式的文档
        private void GenerateHTML()
        {
            try
            {
                var htmlBody = new StringBuilder();

                #region 产生文档，写入标题
                htmlBody.Append("<div class=\"styledb\">数据库名：" + dbSet.DbName + "</div>");
                var tabletitle = "表名：" + this.TableName;
                #endregion

                #region 循环每一个列，产生一行数据
                var colList = idbObj.GetColumnInfoList(dbSet.DbName, this.TableName);
                var rc = colList.Count;
                if ((colList.Count > 0))
                {
                    htmlBody.Append("<div class=\"styletab\">" + tabletitle + "</div>");
                    htmlBody.Append("<div><table border=\"0\" cellpadding=\"5\" cellspacing=\"0\" width=\"90%\">");
                    //网页风格
                    htmlBody.Append("<tr><td bgcolor=\"#FBFBFB\">");
                    htmlBody.Append("<table cellspacing=\"0\" cellpadding=\"5\" border=\"1\" width=\"100%\" bordercolorlight=\"#D7D7E5\" bordercolordark=\"#D3D8E0\">");
                    htmlBody.Append("<tr bgcolor=\"#F0F0F0\">");

                    htmlBody.Append("<td>序号</td>");
                    htmlBody.Append("<td>列名</td>");
                        htmlBody.Append("<td>数据类型</td>");
                    htmlBody.Append("<td>长度</td>");
                    htmlBody.Append("<td>小数位</td>");
                    htmlBody.Append("<td>标识</td>");
                    htmlBody.Append("<td>主键</td>");
                    htmlBody.Append("<td>允许空</td>");
                    htmlBody.Append("<td>默认值</td>");
                    htmlBody.Append("<td>描述</td>");
                    htmlBody.Append("</tr>");

                    int rowIndex;
                    //string strText;
                    for (rowIndex = 0; rowIndex < rc; rowIndex++)
                    {
                        var col = (ColumnInfo)colList[rowIndex];
                        var order = col.ColOrder;
                        var colum = col.ColumnName;
                        var typename = col.TypeName;
                        var length = col.Length == "" ? "&nbsp;" : col.Length;
                        var scale = col.Scale == "" ? "&nbsp;" : col.Scale;
                        var IsIdentity = col.IsIdentity.ToString().ToLower() == "true" ? "是" : "&nbsp;";
                        var PK = col.IsPK.ToString().ToLower() == "true" ? "是" : "&nbsp;";
                        var isnull = col.IsNull.ToString().ToLower() == "true" ? "是" : "否";
                        var defaultstr = col.DefaultVal.ToString().Trim() == "" ? "&nbsp;" : col.DefaultVal.ToString();
                        var description = col.ColDescription.ToString().Trim() == "" ? "&nbsp;" : col.ColDescription.ToString();
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

                wbDoc.DocumentText = htmlBody.ToString();
            }
            catch (Exception ex)
            {
                var htmlBody = new StringBuilder();
                htmlBody.Append(@"<h3><strong><span style=\""color:#006600;font-size:18px;background-color:#FFE500;\"">生成文档出错了...</span></strong></h3>");
                htmlBody.Append(@"<p><span><span style=\""line-height:27px;color:#E53333;\""><b>出错信息为：</b></span></span></p>");
                htmlBody.Append("   " + ex.ToString());
                wbDoc.DocumentText = htmlBody.ToString();
            }
        }
        #endregion

        private void dgvDefine_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (listDataTypeRefer == null || dgvDefine.DataSource == null || dgvDefine.Rows.Count <= 0)
            {
                return;
            }

            for (var index = 0; index < dgvDefine.Rows.Count; index++)
            {
                if (dgvDefine["TypeName", index].Value == null || string.IsNullOrEmpty(dgvDefine["TypeName", index].Value.ToString())) continue;
                var strTypeName = dgvDefine["TypeName", index].Value.ToString().ToLower();
                ((DataGridViewComboBoxCell)dgvDefine.Rows[index].Cells["colDTDataType"]).Value = strTypeName;
                foreach (var dtReference in listDataTypeRefer.Where(dtReference => String.Equals(dtReference.From, strTypeName, StringComparison.CurrentCultureIgnoreCase)))
                {
                    ((DataGridViewComboBoxCell)dgvDefine.Rows[index].Cells["colType"]).Value = dtReference.To;
                    break;
                }
            }
        }

        private void dgvDefine_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (listDataTypeRefer == null || dgvDefine.DataSource == null || dgvDefine.Rows.Count <= 0 || !chkTypeLink.Checked)
            { 
                return;
            }

            //联动（数据类型->类型）
            if (dgvDefine.Columns[e.ColumnIndex].Name == "colDTDataType")
            {
                var strTypeName = ((DataGridViewComboBoxCell)dgvDefine.Rows[e.RowIndex].Cells["colDTDataType"]).Value.ToString().ToLower();
                foreach (var dtReference in listDataTypeRefer.Where(dtReference => String.Equals(dtReference.From, strTypeName, StringComparison.CurrentCultureIgnoreCase)))
                {
                    ((DataGridViewComboBoxCell)dgvDefine.Rows[e.RowIndex].Cells["colType"]).Value = dtReference.To;
                    break;
                }
            }

            if (dgvDefine.Columns[e.ColumnIndex].Name == "colType")
            {
                var strTypeName = ((DataGridViewComboBoxCell)dgvDefine.Rows[e.RowIndex].Cells["colType"]).Value.ToString().ToLower();
                foreach (var dtReference in listDataTypeRefer.Where(dtReference => String.Equals(dtReference.To, strTypeName, StringComparison.CurrentCultureIgnoreCase)))
                {
                    ((DataGridViewComboBoxCell)dgvDefine.Rows[e.RowIndex].Cells["colDTDataType"]).Value = dtReference.From;
                    break;
                }
            }
        }

        private void dgvDefine_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void textEditorCode_KeyPressEvent(object sender, KeyEventArgs args)
        {

        }

        private void textEditorDDL_KeyPressEvent(object sender, KeyEventArgs args)
        {

        }

        private void codeEditorStorageTable_KeyPressEvent(object sender, KeyEventArgs args)
        {

        }
    }

    public class DataTypeReference
    {
        public DataTypeReference()
        { }

        public DataTypeReference(string sFrom,string sTo)
        {
            this.From = sFrom;
            this.To = sTo;
        }

        private string _from = string.Empty;
        private string _to = string.Empty;

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
    }
}
