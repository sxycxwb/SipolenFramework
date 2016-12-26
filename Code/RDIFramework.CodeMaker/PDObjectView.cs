using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// PDObjectView
    /// 设计对象视图
    /// 
    /// 
    /// </summary>
    public partial class PDObjectView : Form
    {
        /// <summary>
        /// 设计文档
        /// </summary>
        private XmlDocument xmlDocument = new XmlDocument();
        string cmcfgfile = Application.StartupPath + @"\Config\cmcfg.ini";
        IniFile cmcfgIniFile;
        private TreeNode treeNodePD;
        private TreeNode nodeWorkSpace;
        MainForm mainfrm;

        string TAGWORKSPACE = "tagWorkSpace";
        string TAGPOWSERDESIGNER = "tagPowserDesigner";
        string TAGTABLES = "tagTables";
        string TAGTABLE = "tagTable";

        public PDObjectView(Form mdiParentForm)
        {
            InitializeComponent();
            mainfrm = (MainForm)mdiParentForm;
        }

        private void PDObjectView_Load(object sender, EventArgs e)
        {
            this.GetProjectPorpery();
            if (File.Exists(cmcfgfile))
            {
                cmcfgIniFile = new IniFile(cmcfgfile);
            }

            this.GetPDMSet();
        }

        #region 代码生成相关属性设置
        private string company = string.Empty;
        private string project = string.Empty;
        private string author = string.Empty;
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

        private string ReplaceAssemblyInfo(string code)
        {
            code = code.Replace("#Author#", this.Author);
            code = code.Replace("#ClassName#", this.GetClassName());
            //code = code.Replace("#Code#", this.codeEditorManager.Text);
            code = code.Replace("#Company#", this.Compay);
            code = code.Replace("#DateCreated#", DateTime.Now.ToString("yyyy-MM-dd"));
            code = code.Replace("#Project#", this.Project);
            code = code.Replace("#YearCreated#", DateTime.Now.Year.ToString());
            code = code.Replace("#Title#", this.GetDescription());
            code = code.Replace("#Description#", this.GetDescription());
            return code;
        }

        #region private void GetProjectPorpery() 获取项目属性设置
        private void GetProjectPorpery()
        {
            var setHelper = new SettingHelper();
            setHelper.GetSetting();
            this.Project = setHelper.Project;
            this.Compay = setHelper.Company;
            this.Author = setHelper.Author;
        }
        #endregion

        #region private string GetClassName() 获取类名
        /// <summary>
        /// 获取类名
        /// </summary>
        /// <returns>类名</returns>
        private string GetClassName()
        {
            var className = string.Empty;
            if (this.tvPDObjectView.SelectedNode != null)
            {
                className = this.tvPDObjectView.SelectedNode.Text.Split(',')[0];
                className = className.Replace("_", string.Empty);
                if ((!string.IsNullOrEmpty(className)) && (!string.IsNullOrEmpty(this.Project)))
                {
                    className = className.Replace(this.ProductName, string.Empty);
                }
            }
            return className;
        }
        #endregion

        #region private string GetTableName() 获取表名
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns>表名</returns>
        private string GetTableName()
        {
            var tableName = string.Empty;
            if (this.tvPDObjectView.SelectedNode != null)
            {
                tableName = this.tvPDObjectView.SelectedNode.Text.Split(',')[0];
            }
            return tableName;
        }
        #endregion

        #region private string GetDescription() 获取类描述
        /// <summary>
        /// 获取类描述
        /// </summary>
        /// <returns>类描述</returns>
        private string GetDescription()
        {
            var description = string.Empty;
            if (this.tvPDObjectView.SelectedNode != null)
            {               
                description = this.tvPDObjectView.SelectedNode.Text.Split(',')[1];
            }
            return description;
        }
        #endregion

        #region private string OpenDesignFile() 打开设计文件
        /// <summary>
        /// 打开设计文件
        /// </summary>
        /// <returns>文件名称</returns>
        private string OpenDesignFile()
        {
            var fileName = string.Empty;
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "设计文档(*.pdm)|*.pdm|所有文件|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "选择数据库模型设计文档";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    this.lblDesignDocPath.Text = fileName;
                }
            }
            return fileName;
        }
        #endregion

        private void GetPDMSet()
        {
            if (cmcfgIniFile == null) return;
            this.tvPDObjectView.Nodes.Clear();
            nodeWorkSpace = new TreeNode("WorkSpace")
            {
                Name = "nodeWorkSpace",
                Tag = this.TAGWORKSPACE,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            tvPDObjectView.Nodes.Add(nodeWorkSpace);

            foreach (var nodePd in from sectionItem in cmcfgIniFile.Sections["pdmSet"].Items 
                                   where sectionItem.Key.ToLower().Contains("pdmfile") 
                                   where !string.IsNullOrEmpty(sectionItem.Value) 
                                   select new TreeNode(sectionItem.Value)
            {
                Tag = this.TAGPOWSERDESIGNER,
                Name = sectionItem.Key,
                ImageIndex = 1,
                SelectedImageIndex = 1
            })
            {
                nodeWorkSpace.Nodes.Add(nodePd);
            }

            nodeWorkSpace.ExpandAll();
        }

        #region private string[] GetDesignTables(string fileName) 获取设计的数据表名集合
        /// <summary>
        /// 获取设计的数据表名集合
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>数据表名集合</returns>
        private string[] GetDesignTables(string fileName)
        {
            // 判断文件是否存在
            if (!File.Exists(fileName))
            {
                MessageBox.Show(this,"文件不存在", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            // 设置文件共享方式为读写，FileShare.ReadWrite，这样的话，就可以打开了
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // 如果直接打开是以只读共享的方式打开的，
            // 但若此文件已被一个拥有写权限的进程打开的话，就无法读取了
            // 
            // 解决方法：使用文件流方式打开，设置文件共享方式为读写，FileShare.ReadWrite
            this.xmlDocument.Load(fileStream);

            var nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            nsmgr.AddNamespace("a", "attribute");
            nsmgr.AddNamespace("c", "collection");
            nsmgr.AddNamespace("o", "object");

            // 获取表格
            //string selectPath = "/Model/*[local-name()='RootObject' and namespace-uri()='object'][1]/*[local-name()='Children' and namespace-uri()='collection'][1]/*[local-name()='Model' and namespace-uri()='object'][1]/*[local-name()='Tables' and namespace-uri()='collection'][1]";

            var tableList = xmlDocument.SelectNodes("/descendant::c:Tables/o:Table", nsmgr);
            if (tableList == null) return null;

            var tableNames = tableList.Cast<XmlNode>().Aggregate(string.Empty, (current, table) => current + (table.ChildNodes[2].InnerText + "," + table.ChildNodes[1].InnerText + ";"));
            if (tableNames.Length > 0)
            {
                tableNames = tableNames.Substring(0, tableNames.Length - 1);
            }
            return tableNames.Split(';');

            //V2.5版本代码：
            //string tableNames = string.Empty;
            //foreach (XmlNode table in tableList)
            //{
            //    tableNames += table.ChildNodes[2].InnerText + "," + table.ChildNodes[1].InnerText + ";";
            //}
        }
        #endregion

        #region private int GetDesignTables(TreeNode nodePD) 获取设计的数据表
        /// <summary>
        /// 获取设计的数据表
        /// </summary>
        /// <returns>数据表个数</returns>
        private int GetDesignTables(TreeNode nodePd)
        {
            if (nodePd != null && nodePd.Nodes.Count > 0)
            {
                nodePd.ExpandAll();  
                return 0;
            }

            var returnValue = 0;
            if (!String.IsNullOrEmpty(this.lblDesignDocPath.Text))
            {              
                var nodeTables = new TreeNode("数据表")
                {
                    Tag = this.TAGTABLES,
                    Name = "Tables",
                    ImageIndex = 2,
                    SelectedImageIndex = 2
                };
                nodePd.Nodes.Add(nodeTables);
                nodePd.ExpandAll();
                var tableList = this.GetDesignTables(this.lblDesignDocPath.Text);
                if (tableList == null)
                {                    
                    cmcfgIniFile.DeleteKey("pdmSet", nodePd.Name);
                    cmcfgIniFile.Save();
                    this.tvPDObjectView.Nodes.Remove(nodePd);                   
                }

                foreach (var table in tableList)
                {
                    var node = new TreeNode {Text = table, ImageIndex = 3, SelectedImageIndex = 3};
                    mainfrm.InvokeSendStatusMessage("加载表：" + table);
                    nodeTables.Nodes.Add(node);
                }
                nodeTables.ExpandAll();
                returnValue =  nodeTables.Nodes.Count;
                nodeTables.Text = "数据表（"  + nodeTables.Nodes.Count.ToString()+ "个）";
            }
            return returnValue;
        }
        #endregion

        private void tvPDObjectView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            cmnuItemDocument.Enabled = cmnuItemGengerateCode.Enabled = true;
            cmnuItemBatchGenerateAll.Enabled = false;

            if (e.Node.Tag == null) return;
            cmnuItemGengerateCode.Enabled = !(e.Node.Tag.ToString() == this.TAGWORKSPACE || e.Node.Tag.ToString() == this.TAGPOWSERDESIGNER || e.Node.Tag.ToString() == this.TAGTABLES);
            cmnuItemDocument.Enabled = cmnuItemGengerateCode.Enabled;
            cmnuItemBatchGenerateAll.Enabled = (e.Node.Tag.ToString() == this.TAGTABLES);
        }

        private void LoadPDDetail()
        {
            var tmpTreeNode = tvPDObjectView.SelectedNode;
            if (tmpTreeNode == null || tmpTreeNode.Tag == null || tmpTreeNode.Tag.ToString() != this.TAGPOWSERDESIGNER)
            {
                return;
            }

            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                mainfrm.InvokeSendStatusMessage("加载PowerDesigner设计源文件。");
                this.GetDesignTables(tmpTreeNode);
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
                mainfrm.InvokeSendStatusMessage("就绪。");
            }
        }

        private void tvPDObjectView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {           
            this.LoadPDDetail();
        }

        private void tvPDObjectView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
            {
                return;
            }

            tsBtnAdd.Enabled = tsBtnExpand.Enabled = tsBtnRemove.Enabled =  false;
            var nodeTag = e.Node.Tag.ToString();
            if (nodeTag == this.TAGWORKSPACE)
            {
                tsBtnAdd.Enabled = true;
            }
            else if (nodeTag == this.TAGPOWSERDESIGNER)
            {
                this.lblDesignDocPath.Text = e.Node.Text.Trim();
                tsBtnExpand.Enabled = tsBtnRemove.Enabled = true;
            } 
        }

        private void cmnuItemGengerateCode_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (tvPDObjectView.SelectedNode == null || !tvPDObjectView.SelectedNode.Text.Contains(","))
            {
                MessageBox.Show("请正确选择操作的节点数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (e.ClickedItem.Name)
            {
                case "cmnuItemGengerateTable":
                    this.GengerateTable();
                    break;
                case "cmnuItemGengerateEntity":
                    GengerateEntity();
                    break;
                case "cmnuItemGengerateMvcEntity":
                    GengerateMvcEntity();
                    break;
                case "cmnuItemGengerateIService":
                    this.GengerateIService();
                    break;
                case "cmnuItemGengerateService":
                    this.GenerateService();
                    break;
                case "cmnuItemGengerateManager":
                    this.GenerateManager();
                    break;
                case "cmnuItemGengerateDbScript": //生成数据库脚本
                    this.GenerateTableColumns();
                    break;
                case "cmnuItemGengerateAll": //全部生成
                    this.GengerateAll();
                    break;
            }
        }


        private void cmnuItemDocument_Click(object sender, EventArgs e)
        {
            if (tvPDObjectView.SelectedNode == null || !tvPDObjectView.SelectedNode.Text.Contains(","))
            {
                MessageBox.Show("请正确选择操作的节点数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.GenerateHtml();
        }

        //批量代码生成
        private void cmnuItemBatchGenerateAll_Click(object sender, EventArgs e)
        {
            if (tvPDObjectView.SelectedNode == null || tvPDObjectView.SelectedNode.Tag == null || string.IsNullOrEmpty(tvPDObjectView.SelectedNode.Tag.ToString()) ||tvPDObjectView.SelectedNode.Tag.ToString() != this.TAGTABLES)
            {
                MessageBox.Show("请选择“数据表”节点进行代码的批量生成！","提示信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            var setHelper = new SettingHelper();
            setHelper.GetSetting();
            if (string.IsNullOrEmpty(setHelper.Output))
            {
                MessageBox.Show("请先设置代码的输出路径！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var projProperty = new ProjectProperty();
                projProperty.ShowDialog();
                return;
            }
            var overwrite = true;
            var codeOutPutPath = setHelper.Output;
            // 设置鼠标繁忙状态，并保留原先的状态
            var holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            mainfrm.InvokeSendStatusMessage("准备批量生成代码...");
            try
            {
                foreach (TreeNode node in this.tvPDObjectView.SelectedNode.Nodes)
                {
                    tvPDObjectView.SelectedNode = node;
                    var className = node.Text.Split(',')[0].Replace("_", string.Empty);
                    var tableName = node.Text.Split(',')[0];
                    var description = node.Text.Split(',')[1];
                    mainfrm.InvokeSendStatusMessage("当前处理对象：" + tableName);
                    if ((!string.IsNullOrEmpty(className)) && (!string.IsNullOrEmpty(this.ProductName)))
                    {
                        className = className.Replace(this.ProductName, string.Empty);
                    }

                    var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), className, "Manager", tableName, description);
                    overwrite = codeMaker.BuilderTable(codeOutPutPath, overwrite);
                    overwrite = codeMaker.BuilderEntity(codeOutPutPath, overwrite);
                    overwrite = codeMaker.BuilderManager(codeOutPutPath, overwrite);
                    
                    var fileName = codeOutPutPath + "\\" + this.Project + ".BizLogic\\IService\\" + "I" + className + "Service.cs";
                    this.GengerateIService(fileName);
                    fileName = codeOutPutPath + "\\" + this.Project+ ".BizLogic\\Service\\" + className + "Service.cs";
                    this.GenerateService(fileName);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            finally
            {
                // 设置鼠标默认状态，原来的光标状态
                this.Cursor = holdCursor;
                mainfrm.InvokeSendStatusMessage("就绪。");
                // 打开文件夹
                Process.Start(codeOutPutPath);
            }           
        }

        #region 生成代码
        private void GengerateTable(string outPutFile = "")
        {            
            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), "Table", this.GetTableName(), this.GetDescription());
            var codeString = codeMaker.BuilderTable();
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = this.GetClassName() + "Table.cs";
                var codeForm = new CodeView(codeString) {FileName = fileName, Name = fileName};
                PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, codeString);
            }
        }

        private void GengerateEntity(string outPutFile = "")
        {           
            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), "Entity", this.GetTableName(), this.GetDescription());
            var codeString = codeMaker.BuilderEntity();
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = this.GetClassName() + "Entity.cs";
                var codeForm = new CodeView(codeString) {FileName = fileName, Name = fileName};
                PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, codeString);
            }
        }

        private void GengerateMvcEntity(string outPutFile = "")
        {
            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), "Entity", this.GetTableName(), this.GetDescription())
            {
                MVCEntity = true
            };
            var codeString = codeMaker.BuilderEntity();
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = this.GetClassName() + "Entity.cs";
                var codeForm = new CodeView(codeString) { FileName = fileName, Name = fileName };
                //PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
                PageUtility.AddTabPage(fileName, codeForm, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, codeString);
            }
        }

        private void GengerateIService(string outPutFile = "")
        {            
            var file = Application.StartupPath + "\\Templates\\IService.cst";
            var code = CodeMakerLibary.GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = "I" + this.GetClassName() + "Service.cs";
                var codeForm = new CodeView(code) {FileName = fileName, Name = fileName};
                PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, code);
            }
        }

        private void GenerateService(string outPutFile = "")
        {            
            var file = Application.StartupPath + "\\Templates\\Service.cst";
            var code = CodeMakerLibary.GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = this.GetClassName() + "Service.cs";
                var codeForm = new CodeView(code) {FileName = fileName, Name = fileName};
                PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, code);
            }
        }

        private void GenerateManager(string outPutFile = "")
        {           
            //以模版方式生成
            //string file = Application.StartupPath + "\\Templates\\Manager.cst";
            //string code = CodeMakerLibary.GetTemplate(file);
            //code = ReplaceAssemblyInfo(code); 

            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), "Manager", this.GetTableName(), this.GetDescription());
            var codeString = codeMaker.BuilderManager(null);
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = this.GetClassName() + "Manager.Generate.cs";
                var codeForm = new CodeView(codeString) {FileName = fileName, Name = fileName};
                PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, codeString);
            }
        }

        private void GenerateTableColumns(string outPutFile = "")
        {
            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), "Table", this.GetTableName(), this.GetDescription());
            var codeString = codeMaker.DBSQL();
            if (string.IsNullOrEmpty(outPutFile))
            {
                var fileName = this.GetClassName() + "TableColumns.sql";
                var codeForm = new CodeView(codeString) { FileName = fileName, Name = fileName };
                PageUtility.AddSinglePage(codeForm, fileName, mainfrm);
            }
            else
            {
                PDMCodeMaker.WriteCode(outPutFile, true, codeString);
            }
        }

        private void GenerateHtml()
        {
            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), string.Empty, this.GetTableName(), this.GetDescription());
            var bForm = new BrowserForm(codeMaker.TableToHTML());           
            var fileName = this.GetTableName() + "（" + this.GetDescription() + "）";
            bForm.Name = fileName;
            PageUtility.AddSinglePage(bForm,fileName, mainfrm); 
        }

        /// <summary>
        /// 全部生成
        /// </summary>
        private void GengerateAll()
        {
            var setHelper = new SettingHelper();
            setHelper.GetSetting();
            if (string.IsNullOrEmpty(setHelper.Output))
            {
                MessageBox.Show("请先设置代码的输出路径！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var projProperty = new ProjectProperty();
                projProperty.ShowDialog();
                return;               
            }
            var overwrite = true;
            var codeOutPutPath = setHelper.Output;
            var codeMaker = new PDMCodeMaker(this.xmlDocument, this.CompanyName, this.Project, this.Author, DateTime.Now.Year.ToString(), DateTime.Now.ToString("yyyy-MM-dd"), this.GetClassName(), "Manager", this.GetTableName(), this.GetDescription());
            overwrite = codeMaker.BuilderTable(codeOutPutPath, overwrite);
            overwrite = codeMaker.BuilderEntity(codeOutPutPath, overwrite);
            overwrite = codeMaker.BuilderManager(codeOutPutPath, overwrite);
            var fileName = codeOutPutPath + "\\" + this.Project+ ".BizLogic\\IService\\" + "I" + this.GetClassName() + "Service.cs";
            this.GengerateIService(fileName);
            fileName = codeOutPutPath + "\\" + this.Project + ".BizLogic\\Service\\" + this.GetClassName() + "Service.cs";
            this.GenerateService(fileName);
            // 打开文件夹
            Process.Start(codeOutPutPath);
        }
        #endregion

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            var fileName =  this.OpenDesignFile();
            if (this.lblDesignDocPath.Text.Length <= 0 || string.IsNullOrEmpty(fileName))
            {
                return;
            }

            if (nodeWorkSpace != null)
            {
                var treeNode = new TreeNode(fileName)
                {
                    ImageIndex = 1,
                    SelectedImageIndex = 1,
                    Tag = this.TAGPOWSERDESIGNER
                };
                var iniKey = "pdmfile" + System.Guid.NewGuid().ToString();
                treeNode.Name = iniKey;
                this.nodeWorkSpace.Nodes.Add(treeNode);               
                cmcfgIniFile.Write("pdmSet", iniKey, fileName);
                cmcfgIniFile.Save();
                nodeWorkSpace.ExpandAll();
            }         
        }

        private void tsBtnRemove_Click(object sender, EventArgs e)
        {
            var tmpTreeNode = tvPDObjectView.SelectedNode;
            if (tmpTreeNode == null && tmpTreeNode == null)
            {
                return;
            }

            if(MessageBox.Show("确定移除当前所选设计文件?\n" + tvPDObjectView.SelectedNode.Text,"询问信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (tmpTreeNode.Tag.ToString() == this.TAGPOWSERDESIGNER)
            {
                cmcfgIniFile.DeleteKey("pdmSet", tmpTreeNode.Name);
                cmcfgIniFile.Save();
                this.tvPDObjectView.Nodes.Remove(tmpTreeNode);
            }
        }

        private void tsBtnExpand_Click(object sender, EventArgs e)
        {
            this.LoadPDDetail();
        }
    }
}
