using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;

namespace RDIFramework.CodeMaker
{
    public partial class DbQuery : Form
    {
        public Form MdiParentForm = null;
        TreeNode treeNodeDragObject;
        MainForm mainForm;

        public DbQuery(Form mdiParentForm, string strSQL)
        {
            InitializeComponent();
            this.MdiParentForm = mdiParentForm;
            this.tabControl1.Visible = false;
            this.txtContent.ShowEOLMarkers = false;
            this.txtContent.ShowVRuler = false;
            this.txtContent.ActiveTextAreaControl.TextArea.MouseUp += new MouseEventHandler(qcTextEditor_MouseUp);
            this.txtContent.ActiveTextAreaControl.TextArea.DragDrop += new DragEventHandler(TextArea_DragDrop);
            this.txtContent.ActiveTextAreaControl.TextArea.DragEnter += new DragEventHandler(TextArea_DragEnter);
            this.txtContent.ActiveTextAreaControl.TextArea.Click += new EventHandler(TextArea_Click);
            this.txtContent.ActiveTextAreaControl.TextArea.KeyPress += new KeyPressEventHandler(TextArea_KeyPress);
            this.txtContent.ActiveTextAreaControl.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(TextArea_KeyUp);

            mainForm = (MainForm)mdiParentForm;
            mainForm.tsbtnExecSql.Visible = true;
            //mainForm.��ѯQToolStripMenuItem.Visible = true;
            this.InvokeSendCodeMessage(strSQL);
        }

        public DbQuery(string tempFile)
        {
            InitializeComponent();
            StreamReader srFile = new StreamReader(tempFile, Encoding.Default);
            string Contents = srFile.ReadToEnd();
            srFile.Close();
            this.InvokeSendCodeMessage(Contents);
        }

        private void InvokeSendCodeMessage(string info)
        {
            if (txtContent.InvokeRequired)
            {
                txtContent.Invoke(new MethodInvoker(() => { this.txtContent.Text = info; }));
            }
            else
            {
                txtContent.Text = info;
            }           
        }

        #region ˽�г�Ա

        private int keyPressCount = 0;
        //private string[] _lines;
        //private int _linesPrinted;
        private Hashtable Aliases = new Hashtable();
        private ArrayList AliasList = new ArrayList();
        private int lastPos;
        private int firstPos;
        private XmlDocument sqlReservedWords = new XmlDocument();
        private static ArrayList _sqlInfoMessages = new ArrayList();
        private ArrayList ReservedWords = new ArrayList();
        //private bool DoInsert;
        private string _OrginalName;
        private string m_fileName = string.Empty;
        private bool _canceled = false;
        private Regex _findNextRegex;
        private int _findNextStartPos;
        private TimeSpan _currentExecutionTime;
        private IAsyncResult _asyncResult;
        private Exception _currentException = null;
        private int _dragPos;

        //private IDatabaseManager _currentManager = null;
        //private DataSet _currentDataSet = null;

        //private QCTreeNode treeNodeDragObject;

        #endregion

        #region  ���г�Ա

        public bool IsActive;
        /// <summary>
        /// All queries will be executed with this connection
        /// </summary>
        //public IDbConnection dbConnection = null;
        /// <summary>
        /// Current database name
        /// </summary>
        public string DatabaseName = "";


        /// <summary>
        /// The Syntax reader handles all font and color settings.
        /// </summary>
        public TextEditor.Editor.SyntaxReader syntaxReader;
        /// <summary>
        /// Used when opening/saving.
        /// </summary>
        public string FileName
        {
            get { return m_fileName; }
            set
            {
                if (value != string.Empty)
                {
                    string fileName = value; //.Substring(value.LastIndexOf(@"\")+1);
                    this.Text = fileName;
                }

                m_fileName = value;
            }
        }

        /// <summary>
        /// The content of the txtContent
        /// </summary>
        public string Content
        {
            get { return txtContent.Text; }
            set
            {
                txtContent.Text = value;

                txtContent.Refresh();
                //MainForm frm = (MainForm)MdiParentForm;
                //frm.SetPandelInfo();
            }
        }

        /// <summary>
        /// Font settings 
        /// </summary>
        public Font EditorFont
        {
            get { return txtContent.Font; }
            set { txtContent.Font = value; }
        }
        #endregion

        private void DbQuery_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region �����¼�

        private void qcTextEditor_KeyPressEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string keyString = e.ToString();
            string line = txtContent.ActiveTextAreaControl.Caret.Line.ToString();
            string col = txtContent.ActiveTextAreaControl.Caret.Column.ToString();
            //((MainForm)MdiParentForm).SetPandelPositionInfo(line, col);

            if (e.Alt == true && e.KeyValue == 88)
            {
                e.Handled = false;
                RunQuery();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                //lstv_Commands.Focus();
            }

            if (e.KeyCode == Keys.F5)
            {
                RunQuery();
            }

            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 32
                || e.KeyValue == 190)
            {
                if (e.KeyValue == 190)
                {
                    //ApplyProperty();
                }
                else
                {
                    e.Handled = true;
                    //ComplementWord();
                }
            }
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 67 || e.KeyValue == 99)
            {
                //ToggleComment();
            }
        }

        //��ק
        private void TextArea_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData("System.Windows.Forms.TreeNode", false) != null)
            {
                TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode", false);
                if ((node.Tag.ToString() == "table") || (node.Tag.ToString() == "view") || (node.Tag.ToString() == "column"))
                {
                    System.Drawing.Rectangle r = txtContent.RectangleToClient(txtContent.ClientRectangle);
                    Point p = new Point(e.X + r.X, e.Y + r.Y);

                    _dragPos = txtContent.GetCharIndexFromPosition(p);
                    treeNodeDragObject = node;

                    string objectName = node.Text;
                    //if (node.Tag.ToString() == "column")
                    //{
                    //    int spacePos = objectName.IndexOf("[");
                    //    if (spacePos > 0)
                    //        objectName = objectName.Substring(0, spacePos);

                    //    objectName = ((TreeNode)node.Parent.Parent).Text + "." + objectName;

                    //}

                    //treeNodeDragObject.Text = objectName;
                    SetDragAndDropContextMenu(node);
                    //foreach (MainForm.DBConnection c in ((MainForm)this.MdiParentForm).DBConnections)
                    //{
                    //    if (c.ConnectionName == node.server)
                    //    {
                    //        SetDatabaseConnection(node.database, c.Connection);
                    //        break;
                    //    }
                    //}

                    cmDragAndDrp.Show(txtContent, p);

                }
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    string fullName = files[0];
                    if (files.Length > 1)
                        return;
                    MainForm mainform = (MainForm)MdiParentForm;
                    string fileName = Path.GetFileName(fullName);
                    //string line;
                    string fileContent = "";

                    //FrmQuery frmquery = new FrmQuery(MdiParentForm);

                    StreamReader sr = new StreamReader(fullName);
                    fileContent = sr.ReadToEnd();
                    //					while ((line = sr.ReadLine()) != null) 
                    //					{
                    //						fileContent += "\n" + line;
                    //					}
                    sr.Close();
                    sr = null;

                    this.Content = fileContent;
                }
                catch (Exception ex)
                {                    
                    LogHelper.WriteException(ex);
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void TextArea_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData("System.Windows.Forms.TreeNode", false) != null)
            {
                TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode", false);
                if ((node.Tag.ToString() == "table") || (node.Tag.ToString() == "view"))
                    ((DragEventArgs)e).Effect = DragDropEffects.Copy;
                else
                    if (node.Tag.ToString() == "column")
                        ((DragEventArgs)e).Effect = DragDropEffects.Copy;

                return;
            }

            ((DragEventArgs)e).Effect = ((DragEventArgs)e).Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void TextArea_Click(object sender, EventArgs e)
        {
            string line = txtContent.ActiveTextAreaControl.Caret.Line.ToString();
            string col = txtContent.ActiveTextAreaControl.Caret.Column.ToString();
            //((MainForm)MdiParentForm).SetPandelPositionInfo(line, col);
        }
        private void ExecutionTimer_Tick(object sender, System.EventArgs e)
        {
            //if (_asyncResult.IsCompleted)
            //{
            //    ExecutionTimer.Enabled = false;
            //    HandleExecutionResult(_currentDataSet, _currentExecutionTime, _currentManager);
            //}
        }

        private void TextArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                // Counts the backspaces.
                case '\b':
                    break;
                // Counts the ENTER keys.
                case '\r':
                    break;
                // Counts the ESC keys.  
                case (char)27:
                    break;
                // Counts all other keys.
                default:
                    keyPressCount = keyPressCount + 1;
                    if (this.Text.IndexOf("*") <= 0)
                    {
                        this.Text = this.Text + "*";
                    }
                    break;
            }
        }

        private void TextArea_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back || e.KeyCode == Keys.Enter)
            {
                if (this.Text.IndexOf("*") <= 0)
                {
                    this.Text = this.Text + "*";
                }
            }
        }

        #endregion

        #region ����Ҽ��¼�
        private void qcTextEditor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            string word = txtContent.GetCurrentWord();
            IDataObject iData = Clipboard.GetDataObject();
            MenuItem miRunCurrentQuery = null;
            MenuItem miValidateCurrentQuery = null;
            MenuItem miMakeCurrentQueryCS = null;
            MenuItem miMakeCurrentQuerySQL = null;


            MenuItem miCopy = new MenuItem("���� (&C)");
            MenuItem miCut = new MenuItem("���� (&T)");
            MenuItem miPaste = new MenuItem("ճ�� (&P)");
            MenuItem miAllSel = new MenuItem("ȫѡ (&A)");
            MenuItem miSeparator = new MenuItem("-");
            MenuItem miGoToDefinision = new MenuItem("ת������ (&G)");
            MenuItem miGoToRererence = new MenuItem("ת���������� (&R)");
            MenuItem miGoToAnyRererence = new MenuItem("ת�����ж�������");
            MenuItem miSeparator2 = new MenuItem("-");
            if (txtContent.SelectedText.Length > 0)
            {
                miRunCurrentQuery = new MenuItem("���е�ǰѡ��");
                miValidateCurrentQuery = new MenuItem("��֤��ǰѡ��");
                miMakeCurrentQueryCS = new MenuItem("���ɵ�ǰѡ��SQL����ƴ�Ӵ���");
                miMakeCurrentQuerySQL = new MenuItem("���ɵ�ǰѡ���ѯ��������ݽű�");
            }
            else
            {
                miRunCurrentQuery = new MenuItem("���е�ǰ��ѯ");
                miValidateCurrentQuery = new MenuItem("��֤��ǰ��ѯ");
                miMakeCurrentQueryCS = new MenuItem("���ɵ�ǰ��ѯSQL����ƴ�Ӵ���");
                miMakeCurrentQuerySQL = new MenuItem("���ɵ�ǰ��ѯ��������ݽű�");
            }
            MenuItem miSeparator3 = new MenuItem("-");
            MenuItem miOptions = new MenuItem("ѡ�� (&O)");
            MenuItem miSeparator4 = new MenuItem("-");
            MenuItem miSnippets = new MenuItem("�ű�Ƭ��");
            MenuItem miAddToSnippets = new MenuItem("���ӵ��ű�Ƭ��");

            // Events				
            miCopy.Click += new System.EventHandler(this.miCopy_Click);
            miCut.Click += new System.EventHandler(this.miCut_Click);
            miPaste.Click += new System.EventHandler(this.miPaste_Click);
            miAllSel.Click += new System.EventHandler(this.miAllSel_Click);
            miGoToDefinision.Click += new System.EventHandler(this.miGoToDefinision_Click);
            miGoToRererence.Click += new System.EventHandler(this.miGoToRererence_Click);
            miGoToAnyRererence.Click += new System.EventHandler(this.miGoToAnyRererence_Click);
            miRunCurrentQuery.Click += new System.EventHandler(this.miRunCurrentQuery_Click);
            miValidateCurrentQuery.Click += new EventHandler(miValidateCurrentQuery_Click);
            miMakeCurrentQueryCS.Click += new EventHandler(miMakeCurrentQueryCS_Click);
            miMakeCurrentQuerySQL.Click += new EventHandler(miMakeCurrentQuerySQL_Click);

            miOptions.Click += new System.EventHandler(this.miOptions_Click);
            miAddToSnippets.Click += new System.EventHandler(this.miAddToSnippet_Click);

            if (!iData.GetDataPresent(DataFormats.Text))
                miPaste.Enabled = false;

            // Clear all previously added MenuItems.
            cmShortcutMeny.MenuItems.Clear();
            cmShortcutMeny.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { miCopy, miCut, miPaste, miAllSel }
                );

            //cmShortcutMeny.MenuItems.AddRange(
            //    new System.Windows.Forms.MenuItem[] { miSeparator, miGoToDefinision, miGoToRererence, miGoToAnyRererence }
            //    );   

            cmShortcutMeny.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { miSeparator2, miRunCurrentQuery });
            //cmShortcutMeny.MenuItems.Add(miValidateCurrentQuery);

            cmShortcutMeny.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { miSeparator3, miMakeCurrentQueryCS, miMakeCurrentQuerySQL});
            //cmShortcutMeny.MenuItems.Add(miOptions);
            cmShortcutMeny.MenuItems.AddRange(
                new System.Windows.Forms.MenuItem[] { miSeparator4, miSnippets });
 
            // Snippets//����ű����Ƭ��
            XmlDocument xmlSnippets = new XmlDocument();
            xmlSnippets.Load(Application.StartupPath + @"\Config\Snippets.xml");
            XmlNodeList xmlNodeList = xmlSnippets.GetElementsByTagName("snippets");

            if (txtContent.SelectedText.Length > 1)
                miSnippets.MenuItems.Add(miAddToSnippets);

            foreach (XmlNode node in xmlNodeList[0].ChildNodes)
            {
                SnippetMenuItem snippet = new SnippetMenuItem();
                snippet.Text = node.Attributes["name"].Value;
                snippet.statement = node.InnerText;
                snippet.Click += new System.EventHandler(this.miSnippet_Click);

                miSnippets.MenuItems.Add(snippet);
            }

            cmShortcutMeny.Show(txtContent, new Point(e.X, e.Y));
        }
        #endregion

        #region ����Ҽ��˵��¼�
        private void miCopy_Click(object sender, System.EventArgs e)
        {
            this.Copy();
        }
        private void miCut_Click(object sender, System.EventArgs e)
        {
            this.txtContent.Cut();
        }
        private void miPaste_Click(object sender, System.EventArgs e)
        {
            this.Paste();
        }
        private void miAllSel_Click(object sender, System.EventArgs e)
        {
            this.txtContent.Select(0, this.txtContent.Text.Length);
        }
        private void miGoToDefinision_Click(object sender, System.EventArgs e)
        {
            this.GoToDefenition();
        }
        private void miGoToRererence_Click(object sender, System.EventArgs e)
        {
            this.GoToReferenceObject();
        }
        private void miGoToAnyRererence_Click(object sender, System.EventArgs e)
        {
            this.GoToReferenceAny();
        }
        private void miOptions_Click(object sender, System.EventArgs e)
        {
            //MainForm frm = (MainForm)MdiParentForm;

            //FrmOption frmOption = new FrmOption(frm);
            //frmOption.ShowDialog();

        }
        //���ӵ��ű�Ƭ��
        private void miAddToSnippet_Click(object sender, System.EventArgs e)
        {
            //FrmAddToSnippet frm = new FrmAddToSnippet(txtContent.Text);
            //frm.ShowDialog(this);

        }
        private void miSnippet_Click(object sender, System.EventArgs e)
        {
            string statement = ((SnippetMenuItem)sender).statement;

            statement = statement.Replace(@"\n", "\n");
            statement = statement.Replace(@"\t", "\t");

            int cursorPos = txtContent.SelectionStart;

            txtContent.Document.Replace(cursorPos, 0, statement);

            if (statement.IndexOf("{}") > -1)
                cursorPos = cursorPos + statement.IndexOf("{}") + 1;

            txtContent.SetPosition(cursorPos);
            txtContent.Refresh();
        }

        private void miRunCurrentQuery_Click(object sender, System.EventArgs e)
        {
            RunCurrentQuery();
        }
        public void miValidateCurrentQuery_Click(object sender, EventArgs e)
        {
            txtContent.ResumeLayout();
            string contentHolder = this.Content;
            if (txtContent.SelectedText.Length > 0)
            {
                string validate = "SET NOEXEC ON;" + txtContent.SelectedText + ";SET NOEXEC OFF;";
                int len = validate.Length;
                int pos = this.Content.IndexOf(txtContent.SelectedText);
                if (this.Content.IndexOf("SET NOEXEC ON", 0) < 0 && pos >= 0 && len > 0)
                {
                    this.Content = this.Content.Replace(txtContent.SelectedText, validate);
                    txtContent.Select(pos, len);
                }
            }
            else
            {
                this.Content = "SET NOEXEC ON;" + this.Content + ";SET NOEXEC OFF;\n\n";
            }
            this.RunQuery();
            this.Content = contentHolder;
            txtContent.ResumeLayout();
        }

        //����sql����ƴ�Ӵ���
        private void miMakeCurrentQueryCS_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.toolStripStatusLabel1.Text = "��������......";
                string SQLstring = this.txtContent.Text;
                if (txtContent.SelectedText.Length > 1)
                {
                    SQLstring = txtContent.SelectedText;
                }
                else
                {
                    SQLstring = txtContent.Text;

                }
                if (SQLstring.Trim() == "")
                {
                    this.toolStripStatusLabel1.Text = "��ѯ���Ϊ�գ�";
                    return;
                }
                StringPlus strCode = new StringPlus();
                strCode.AppendLine("StringBuilder strSql=new StringBuilder();");
                //GO�Ĵ���
                if (SQLstring.IndexOf("\r\n") > 0)//�������
                {
                    string[] split = SQLstring.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string sql in split)
                    {
                        if (sql.Trim() != "")
                        {
                            strCode.AppendLine("strSql.Append(\"" + sql + " \");");
                        }
                    }
                }
                else//�������
                {
                    strCode.AppendLine("strSql.Append(\"" + SQLstring + " \");");
                }
                mainForm.AddTabPage("Class1.cs", new CodeEditor(strCode.Value, "cs",""));
                this.toolStripStatusLabel1.Text = "�ɹ���ɡ�";
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                this.toolStripStatusLabel1.Text = "ִ��ʧ�ܣ�";
            }
        }

        //����sql��ѯ���ݽ���������ݽű�
        private void miMakeCurrentQuerySQL_Click(object sender, System.EventArgs e)
        {
            try
            {
                MainForm frm = (MainForm)MdiParentForm;

                DbView dbviewfrm = (DbView)Application.OpenForms["DbView"];
                string longServername = dbviewfrm.GetLongServername();
                if (longServername.Length < 1)
                {
                    this.toolStripStatusLabel1.Text = "û��ѡ���κη�������";
                    return;
                }
                string dbName = frm.toolComboBox_DB.Text;
                if (dbName.Length < 1)
                {
                    this.toolStripStatusLabel1.Text = "û��ѡ���ִ�е����ݿ⣡";
                    return;
                }

                this.toolStripStatusLabel1.Text = "��������......";
                string SQLstring = this.txtContent.Text;
                if (txtContent.SelectedText.Length > 1)
                {
                    SQLstring = txtContent.SelectedText;
                }
                else
                {
                    SQLstring = txtContent.Text;

                }
                if (SQLstring.Trim() == "")
                {
                    this.toolStripStatusLabel1.Text = "��ѯ���Ϊ�գ�";
                    return;
                }
                
                IDbScriptBuilder dsb = ObjHelper.CreatDsb(longServername);
                string strCode = dsb.CreateTabScriptBySQL(dbName, SQLstring.Trim());
                mainForm.AddTabPage("SQL1.sql", new CodeEditor(strCode, "sql", ""));
                this.toolStripStatusLabel1.Text = "�ɹ���ɡ�";
            }
            catch(System.Exception ex)
            {
                LogHelper.WriteException(ex);
                this.toolStripStatusLabel1.Text = "ִ��ʧ�ܣ�";
            }
        }



        #endregion

        #region Drag & Drop Context menu

        private void SetDragAndDropContextMenu(TreeNode node)
        {
            foreach (MenuItem mi in cmDragAndDrp.MenuItems)
            {
                mi.Visible = false;
            }
            menuItemObjectName.Visible = true;
            menuItemObjectName.Text = node.Text;
            menuItemSplitter.Visible = true;

            //QueryCommander.SQL.SQLStatement sqlStatement = new QueryCommander.SQL.SQLStatement(qcTextEditor.Text, qcTextEditor.SelectionStart, QueryCommander.SQL.SQLStatement.SearchOrder.asc, DBConnectionType.MicrosoftSqlClient);
            //Chris.Beckett.MenuImageLib.MenuImage menuExtender = new Chris.Beckett.MenuImageLib.MenuImage();
            //menuExtender.ImageList = imageList1;

            //if (node.objecttype == QCTreeNode.ObjectType.Table ||
            //    node.objecttype == QCTreeNode.ObjectType.View)
            if ((node.Tag.ToString() == "table") || (node.Tag.ToString() == "view"))
            {
                menuItemSelect1.Visible = true;
                menuItemSelect2.Visible = true;
                menuItemJoin.Visible = true;
                menuItemLeftOuterJoin.Visible = true;
                menuItemRightOuterJoin.Visible = true;
                //menuExtender.SetMenuImage(menuItemSelect1, "2");
                //menuExtender.SetMenuImage(menuItemSelect2, "2");
                //menuExtender.SetMenuImage(menuItemJoin, "2");
                //menuExtender.SetMenuImage(menuItemLeftOuterJoin, "2");
                //menuExtender.SetMenuImage(menuItemRightOuterJoin, "2");

                //menuExtender.SetMenuImage(menuItemObjectName, "4");
            }
            else if (node.Tag.ToString() == "column")
            {
                //if (sqlStatement.Statement.ToUpper().IndexOf("WHERE") >= 0)
                //    menuItemWhere.Text = "AND " + node.Text;
                //else
                //    menuItemWhere.Text = "WHERE " + node.Text;

                //menuItemWhere.Visible = true;
                //menuItemOrderBy.Visible = true;
                //menuItemGroupBy.Visible = true;
                //menuExtender.SetMenuImage(menuItemWhere, "2");
                //menuExtender.SetMenuImage(menuItemOrderBy, "2");
                //menuExtender.SetMenuImage(menuItemGroupBy, "2");

                //menuExtender.SetMenuImage(menuItemObjectName, "3");

            }

        }
        private void SetDragAndDropMenuIcons()
        {
            //Chris.Beckett.MenuImageLib.MenuImage menuExtender = new Chris.Beckett.MenuImageLib.MenuImage();
            //menuExtender.ImageList = imageList1;

            //menuExtender.SetMenuImage(menuItemObjectName, "6");
        }
        private void menuItemObjectName_Click(object sender, System.EventArgs e)
        {
            string text = treeNodeDragObject.Text;
            txtContent.ActiveTextAreaControl.TextArea.InsertString(text);
        }

        private void menuItemSelect1_Click(object sender, System.EventArgs e)
        {
            string text = "SELECT *\nFROM\t" + treeNodeDragObject.Text + "\n";
            txtContent.ActiveTextAreaControl.TextArea.InsertString(text);
        }

        private void menuItemSelect2_Click(object sender, System.EventArgs e)
        {
            string longservername = treeNodeDragObject.Parent.Parent.Parent.Text;
            string dbName = treeNodeDragObject.Parent.Parent.Text;
            string tabname = treeNodeDragObject.Text;
            IDbScriptBuilder dsb = ObjHelper.CreatDsb(longservername);
            string strSql = dsb.GetSQLSelect(dbName, tabname);
            txtContent.ActiveTextAreaControl.TextArea.InsertString(strSql);

        }
        private void menuItemJoin_Click(object sender, System.EventArgs e)
        {
            string longservername = treeNodeDragObject.Parent.Parent.Parent.Text;
            string dbName = treeNodeDragObject.Parent.Parent.Text;
            string tabname = treeNodeDragObject.Text;
            IDbScriptBuilder dsb = ObjHelper.CreatDsb(longservername);
            string strSql = dsb.GetSQLUpdate(dbName, tabname);
            txtContent.ActiveTextAreaControl.TextArea.InsertString(strSql);

        }

        private void menuItemLeftOuterJoin_Click(object sender, System.EventArgs e)
        {
            string longservername = treeNodeDragObject.Parent.Parent.Parent.Text;
            string dbName = treeNodeDragObject.Parent.Parent.Text;
            string tabname = treeNodeDragObject.Text;
            IDbScriptBuilder dsb = ObjHelper.CreatDsb(longservername);
            string strSql = dsb.GetSQLDelete(dbName, tabname);
            txtContent.ActiveTextAreaControl.TextArea.InsertString(strSql);

        }

        private void menuItemRightOuterJoin_Click(object sender, System.EventArgs e)
        {
            string longservername = treeNodeDragObject.Parent.Parent.Parent.Text;
            string dbName = treeNodeDragObject.Parent.Parent.Text;
            string tabname = treeNodeDragObject.Text;
            IDbScriptBuilder dsb = ObjHelper.CreatDsb(longservername);
            string strSql = dsb.GetSQLInsert(dbName, tabname);
            txtContent.ActiveTextAreaControl.TextArea.InsertString(strSql);

        }
        private void menuItemWhere_Click(object sender, System.EventArgs e)
        {
        }
        private void menuItemOrderBy_Click(object sender, System.EventArgs e)
        {
        }
        private void menuItemGroupBy_Click(object sender, System.EventArgs e)
        {
        }

        #endregion

        #region ��������
        public bool ClosingCanceled
        {
            get { return _canceled; }
        }

        public void RefreshLineRangeColor(int firstLine, int toLine)
        {
            //txtContent.SetLineRangeColor(firstLine,toLine);
        }

        public void SendToOutPutWindow()
        {
            //if (_outPutContainer == null)
            //    return;

            //MainForm frm = (MainForm)MdiParentForm;

            //if (_outPutContainer.dataset.Tables.Count > 0)
            //{
            //    if (_outPutContainer.dataset.Tables.Count > 1)
            //        frm.OutputWindow.BrowseTable(_outPutContainer.dataset, _outPutContainer.database.DataAdapter);
            //    else
            //        frm.OutputWindow.BrowseTable(_outPutContainer.dataset.Tables[0], _outPutContainer.database.DataAdapter);
            //}
            //else
            //    frm.OutputWindow.tabControl1.TabPages.Clear();

            //frm.OutputWindow.AddMessage(_outPutContainer.message);
            //frm.statusBar.Panels[3].Text = _outPutContainer.statusText;
            //frm.OutputWindow.Activate();
            //frm.TaskList.ApplyTask("Query executed successfully");
        }

        /// <summary>
        /// Openeds a new query window displaing the requested constructor (alter statement) 
        /// </summary>
        public void GoToDefenition()
        {
            //this.Cursor = Cursors.WaitCursor;
            //string objectName = txtContent.GetCurrentWord();
            //if (DatabaseFactory.GetConnectionType(dbConnection) != DBConnectionType.DB2)
            //    objectName = objectName.Substring(objectName.IndexOf(".") + 1);
            //if (objectName.Length == 0)
            //{
            //    MessageBox.Show("The referenced object was not found", "Go to reference", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Cursor = Cursors.Default;
            //    return;
            //}
            //MainForm frm = (MainForm)MdiParentForm;
            //frm.m_FrmDBObjects.CreateConstructorString(objectName);
            //this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Displays all database objects referencing selected object 
        /// Matching only objectname. Asuming, that objectname is enclosed by spaces
        /// </summary>
        public void GoToReferenceObject()
        {
            this.Cursor = Cursors.WaitCursor;
            string objectName = txtContent.GetCurrentWord();
            if (objectName.IndexOf(".") > -1)
                objectName = objectName.Substring(objectName.IndexOf(".") + 1);

            if (objectName.Length == 0)
            {
                MessageBox.Show("The referenced object was not found", "Go to reference", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }

            //IDatabaseManager db = DatabaseFactory.CreateNew(dbConnection);

            //ArrayList DatabaseObjects = db.GetDatabasesReferencedObjectsClear(DatabaseName, objectName, dbConnection);


            //this.Cursor = Cursors.Default;

            //MainForm frm = (MainForm)MdiParentForm;
            //frm.ResultWindow.ShowResults(DatabaseObjects, objectName);
            //frm.ResultWindow.Show(dockManager);
        }

        /// <summary>
        /// Displays all database objects referencing selected keyword
        /// Matching any occurence within a text (Example sp_test -> sp_test, sp_test1,...)
        /// </summary>
        public void GoToReferenceAny()
        {
            //this.Cursor = Cursors.WaitCursor;
            //string objectName = txtContent.GetCurrentWord();
            //if (objectName.Length == 0)
            //{
            //    MessageBox.Show("The referenced object was not found", "Go to reference", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.Cursor = Cursors.Default;
            //    return;
            //}

            //IDatabaseManager db = DatabaseFactory.CreateNew(dbConnection);
            ////Database db = new Database();
            //ArrayList DatabaseObjects = db.GetDatabasesReferencedObjects(DatabaseName, objectName, dbConnection);

            ////FrmReferenceObjects frmReferenceObjects = new FrmReferenceObjects(DatabaseObjects,objectName);
            //MainForm frm = (MainForm)MdiParentForm;
            //frm.ResultWindow.ShowResults(DatabaseObjects, objectName);
            //frm.ResultWindow.Show(dockManager);

            //this.Cursor = Cursors.Default;
            ///*if(frmReferenceObjects.ShowDialogWindow(this) ==DialogResult.OK)
            //{
            //    MainForm frm = (MainForm)MdiParentForm;
            //    frm.m_FrmDBObjects.CreateConstructorString(frmReferenceObjects.ReferencedObject);
            //}
            //this.Cursor=Cursors.Default;*/
        }

        /// <summary>
        /// Searches for specified pattern. Called from FrmSearch
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        public int Find(Regex regex, int startPos)
        {
            string context = this.txtContent.Text.Substring(startPos);

            Match m = regex.Match(context);
            if (!m.Success)
            {
                MessageBox.Show("û���ҵ�ָ���ı�.", "Codematic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }

            int line = txtContent.Document.GetLineNumberForOffset(m.Index + startPos);
            txtContent.ActiveTextAreaControl.TextArea.ScrollTo(line);

            txtContent.Select(m.Index + startPos, m.Length);
            _findNextRegex = regex;
            _findNextStartPos = m.Index + startPos;

            txtContent.SetPosition(m.Index + m.Length + startPos);
            return m.Index + m.Length + startPos;
        }
        /// <summary>
        /// 
        /// </summary>
        public void FindNext()
        {
            if (_findNextRegex != null)
                Find(_findNextRegex, _findNextStartPos + 1);
        }
        /// <summary>
        /// Searches for specified pattern and replaces it. Called from FrmSearch
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="startPos"></param>
        /// <param name="replaceWith"></param>
        /// <returns></returns>
        public int Replace(Regex regex, int startPos, string replaceWith)
        {
            if (txtContent.SelectedText.Length > 0)
            {
                int start = txtContent.ActiveTextAreaControl.SelectionManager.SelectionCollection[0].Offset;
                //int start = txtContent.SelectionStart;
                int length = txtContent.SelectedText.Length;
                txtContent.Document.Replace(start, length, replaceWith);

                return Find(regex, length + start);

            }

            string context = this.txtContent.Text.Substring(startPos);

            Match m = regex.Match(context);

            if (!m.Success)
            {
                MessageBox.Show("û���ҵ�ָ���ı�.", "Codematic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            txtContent.Document.Replace(m.Index + startPos, m.Length, replaceWith);

            return m.Index + m.Length + startPos;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="replaceWith"></param>
        public void ReplaceAll(Regex regex, string replaceWith)
        {
            string context = this.txtContent.Text;

            this.txtContent.Text = regex.Replace(this.txtContent.Text, replaceWith);

        }
        /// <summary>
        /// Calls FrmGotoLine
        /// </summary>
        public void GoToLine()
        {
            int lineNumber = txtContent.GetLineFromCharIndex(txtContent.SelectionStart);
            // Fix Goto Bug
            lineNumber++;
            //FrmGotoLine frmGotoLine = new FrmGotoLine(this, lineNumber, txtContent.Document.LineSegmentCollection.Count);
            //frmGotoLine.Show();
        }
        /// <summary>
        /// Sets cursor to requested line
        /// </summary>
        /// <param name="line"></param>
        public void GoToLine(int line)
        {
            // Fix Goto Bug
            int offset = txtContent.Document.GetLineSegment(line - 1).Offset;
            int length = txtContent.Document.GetLineSegment(line - 1).Length;
            txtContent.ActiveTextAreaControl.TextArea.ScrollTo(line - 1);
            if (length == 0)
                length++;
            txtContent.Select(offset, length);
            txtContent.SetLine(line - 1);
        }

        /// <summary>
        /// Returns the name of requested alia
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public string GetAliasTableName(string alias)
        {
            //SQL.SQLStatement statement = new QueryCommander.SQL.SQLStatement(txtContent.Text, txtContent.SelectionStart, SQL.SQLStatement.SearchOrder.asc, DBConnectionType.MicrosoftSqlClient);
            //return statement.GetAliasTableName(alias);
            return null;
        }
        /// <summary>
        /// Sets [dbConnection] and [DatabaseName]
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="conn"></param>
        public void SetDatabaseConnection(string dbName, IDbConnection conn)
        {
            //if (DatabaseFactory.GetConnectionType(conn) != QueryCommander.Database.DBConnectionType.DB2)
            //{
            //    this.Text = _OrginalName + " [" + dbName + "]";
            //    DatabaseName = dbName;
            //}
            //else
            //{
            //    this.Text = _OrginalName + " [" + conn.Database + "]";
            //    DatabaseName = conn.Database;

            //}
            //dbConnection = conn;

            //string highLightingStragegy = DatabaseFactory.ChangeDatabase(conn, dbName);
            //DatabaseName = dbName;
            //txtContent.SetHighLightingStragegy(highLightingStragegy);


            //MainForm frm = (MainForm)MdiParentForm;
            //frm.SetPandelInfo();
        }

        /// <summary>
        /// This is where it happens...
        /// </summary>
        public void RunQuery()
        {
            ExecuteSql();            
        }

        public void ExecuteSql()
        {
            MainForm frm = (MainForm)MdiParentForm;
            DataSet ds = new DataSet();
            try
            {
                DbView dbviewfrm = (DbView)Application.OpenForms["DbView"];
                string longServername = dbviewfrm.GetLongServername();
                if (longServername.Length < 1)
                {
                    this.toolStripStatusLabel1.Text = "û��ѡ���κη�������";
                    return;
                }
                string dbName = frm.toolComboBox_DB.Text;
                if (dbName.Length < 1)
                {
                    this.toolStripStatusLabel1.Text = "û��ѡ���ִ�е����ݿ⣡";
                    return;
                }

                this.toolStripStatusLabel1.Text = "���ڽ�������ѯ......";
                string SQLstring = this.txtContent.Text;              
                SQLstring = txtContent.SelectedText.Length > 1 ? txtContent.SelectedText : txtContent.Text;
                if (string.IsNullOrEmpty(SQLstring.Trim()))
                {
                    this.toolStripStatusLabel1.Text = "��ѯ���Ϊ�գ�";
                    return;
                }

                IDbObject dbobj = ObjHelper.CreatDbObj(longServername);
                this.txtInfo.Text = "";
                StringBuilder rowinfo = new StringBuilder();
                if ((!SQLstring.Trim().StartsWith("select")) && (!SQLstring.Trim().StartsWith("SELECT")))
                {
                    //GO�Ĵ���
                    if (SQLstring.IndexOf("GO\r\n") > 0)
                    {
                        string[] split = SQLstring.Split(new string[] { "GO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (int rows in from sql in split where sql.Trim() != "" select dbobj.ExecuteSql(dbName, sql.Trim()))
                        {
                            rowinfo.Append("����ɹ����!" + "\r\n");
                        }
                    }
                    else
                    {
                        int rows = dbobj.ExecuteSql(dbName, SQLstring);
                        rowinfo.Append("����ɹ����" + "����Ӱ�������Ϊ�� " + rows.ToString() + " �У�");
                    }
                    this.tabControl1.SelectedIndex = 1;
                }
                else
                {
                    ds = dbobj.Query(dbName, SQLstring);
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataTable dt in ds.Tables)
                        {
                            rowinfo.Append("����Ӱ�������Ϊ " + dt.Rows.Count.ToString() + " �У�" + "\r\n");
                        }
                    }
                    this.tabControl1.SelectedIndex = 0;
                }
                this.txtInfo.Text = rowinfo.ToString();
                this.toolStripStatusLabel1.Text = "�����ѳɹ���ɡ�";

            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                this.toolStripStatusLabel1.Text = "����ִ��ʧ�ܣ�";
                txtInfo.Text = ex.Message;
                this.tabControl1.SelectedIndex = 1;
            }

            try
            {
                this.tabControl1.Visible = true;
                this.dataGridView1.BackColor = Color.FromArgb(148, 182, 237);//������ɫ
                if (ds.Tables.Count > 1)
                {
                    this.dataGridView1.DataSource = ds;
                }
                else
                    if (ds.Tables.Count == 1)
                    {
                        this.dataGridView1.DataSource = ds.Tables[0];
                    }
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopCurrentExecution()
        {
            txtContent.Enabled = true; 
        }

        /// <summary>
        /// Selects current line before calling RunQuery
        /// </summary>
        public void RunQueryLine()
        {
            Point pt = txtContent.GetPositionFromCharIndex(txtContent.SelectionStart);
            pt.X = 0;
            int lineStartPosition = txtContent.GetCharIndexFromPosition(pt);
            int lineEndPosition = txtContent.Text.IndexOf("\n", lineStartPosition);
            if (lineEndPosition == -1)
                lineEndPosition = txtContent.Text.Length;

            txtContent.Select(lineStartPosition, lineEndPosition - lineStartPosition);
            RunQuery();
        }

        /// <summary>
        /// Selects current query before calling RunQuery
        /// </summary>
        public void RunCurrentQuery()
        {
            try
            {
                //SetCurrentStatement();              
                RunQuery();                
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                return;
            }          
        }

        /// <summary>
        /// Generates insert statements based on current query
        /// </summary>
        public void CreateInsertStatement()
        {
            //MainForm frm = (MainForm)MdiParentForm;
            //string SQLstring;

            //try
            //{
            //    txtContent.SuspendLayout();
            //    if (txtContent.SelectedText.Length > 1)
            //        SQLstring = txtContent.SelectedText;
            //    else
            //        SQLstring = txtContent.Text;

            //    frm.NewQueryform();

            //    txtContent.ResumeLayout();

            //    CreateInsertStatement(SQLstring);
            //}
            //catch (Exception ex)
            //{
            //    frm.ShowTaskWindow();
            //    frm.TaskList.ApplyTask("Invalid SQL\n" + ex.Message);
            //    frm.TaskList.Activate();
            //}
        }

        public void CreateInsertStatement(string SQLstring)
        {
            //string Result = "";
            //MainForm frm = (MainForm)MdiParentForm;
            //try
            //{
            //    txtContent.SuspendLayout();

            //    IDatabaseManager db = DatabaseFactory.CreateNew(dbConnection);
            //    Result = db.GetInsertStatements(SQLstring, dbConnection, DatabaseName);

            //    if (Result.Length > 0)
            //    {
            //        frm.ActiveQueryForm.SetDatabaseConnection(this.DatabaseName, this.dbConnection);
            //        frm.ActiveQueryForm.Content = Result;
            //    }
            //    txtContent.ResumeLayout();
            //}
            //catch (Exception ex)
            //{
            //    frm.ShowTaskWindow();
            //    frm.TaskList.ApplyTask("Invalid SQL\n" + ex.Message);
            //    frm.TaskList.Activate();
            //}
        }

        /// <summary>
        /// Generates update statements based on current query
        /// </summary>
        public void CreateUpdateStatement()
        {
            //MainForm frm = (MainForm)MdiParentForm;
            //string SQLstring;

            //try
            //{
            //    txtContent.SuspendLayout();
            //    if (txtContent.SelectedText.Length > 1)
            //        SQLstring = txtContent.SelectedText;
            //    else
            //        SQLstring = txtContent.Text;
            //    txtContent.ResumeLayout();

            //    frm.NewQueryform();

            //    CreateUpdateStatement(SQLstring);
            //}
            //catch (Exception ex)
            //{
            //    frm.ShowTaskWindow();
            //    frm.TaskList.ApplyTask("Invalid SQL\n" + ex.Message);
            //    frm.TaskList.Activate();
            //}
        }

        /// <summary>
        /// Generates update statements based on current query
        /// </summary>
        public void CreateUpdateStatement(string SQLstring)
        {
            //string Result = "";
            //MainForm frm = (MainForm)MdiParentForm;
            //try
            //{
            //    txtContent.SuspendLayout();

            //    IDatabaseManager db = DatabaseFactory.CreateNew(dbConnection);
            //    Result = db.GetUpdateStatements(SQLstring, dbConnection, DatabaseName);

            //    if (Result.Length > 0)
            //    {
            //        frm.ActiveQueryForm.SetDatabaseConnection(this.DatabaseName, this.dbConnection);
            //        frm.ActiveQueryForm.Content = Result;
            //    }
            //    txtContent.ResumeLayout();
            //}
            //catch (Exception ex)
            //{
            //    frm.ShowTaskWindow();
            //    frm.TaskList.ApplyTask("Invalid SQL\n" + ex.Message);
            //    frm.TaskList.Activate();
            //}
        }

        /// <summary>
        /// Undo next action in the undo buffer
        /// </summary>
        public void Undo()
        {
            txtContent.UndoAction();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Paste()
        {

            txtContent.Paste();

        }

        /// <summary>
        /// Copy
        /// </summary>
        public void Copy()
        {
            txtContent.Copy();
        }

        /// <summary>
        /// Cut
        /// </summary>
        public void Cut()
        {
            txtContent.Cut();
        }     

        /// <summary>
        /// Adds a Comment header
        /// </summary>
        public void InsertHeader()
        {
            //txtContent.SuspendLayout();
            //string header = ParseHeaderComment();
            //txtContent.Text = header + txtContent.Text;
            //txtContent.ResumeLayout();
        }

        /// <summary>
        /// Alters the comment header with a revision tag
        /// </summary>
        public void AddRevisionCommentSection()
        {
            int startpos = txtContent.Text.IndexOf("</member>", 0);
            if (startpos < 1)
                return;
            startpos = txtContent.Text.LastIndexOf("</revision>") + 11;
            txtContent.Text = txtContent.Text.Substring(0, startpos) + "\n\t<revision author='" + SystemInformation.UserName.ToString() + "' date='" + DateTime.Now.ToString() + "'>Altered</revision>" + txtContent.Text.Substring(startpos);
            txtContent.Refresh();

        }

        /// <summary>
        /// Consolidates all xml comment headers 
        /// </summary>
        public void GetXmlDocFile()
        {
            //string whereConcitions = "";
            //FrmAlterDocumentationOutput frm = new FrmAlterDocumentationOutput();
            //frm.ShowDialog(this);
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    if (frm.chbView.Checked)
            //        whereConcitions = "'V'";
            //    if (frm.chbSP.Checked)
            //        if (whereConcitions.Length > 0)
            //            whereConcitions += ",'P'";
            //        else
            //            whereConcitions = "'P'";
            //    if (frm.chbFn.Checked)
            //        if (whereConcitions.Length > 0)
            //            whereConcitions += ",'FN','TF'";
            //        else
            //            whereConcitions = "'FN','TF'";
            //    if (frm.txtLike.Text.Length > 0)
            //    {
            //        string like = frm.txtLike.Text.Replace("*", "%");
            //        whereConcitions += ") AND (o.name like '" + like + "'";
            //    }
            //}

            //this.Cursor = Cursors.WaitCursor;
            //string doc = "<?xml version='1.0' encoding='UTF-8'?>\n<!-- Generated by QueryCommander-->\n<?xml-stylesheet type='text/xsl' href='doc.xsl'?>\n<members>\n";
            //XmlDocument xmlDoc = new XmlDocument();
            //try
            //{
            //    IDatabaseManager db = DatabaseFactory.CreateNew(dbConnection);
            //    doc += db.GetXmlDoc(DatabaseName, dbConnection, whereConcitions) + "\n</members>";

            //    xmlDoc.LoadXml(doc);
            //}
            //catch (Exception ex)
            //{
            //    int startpos = ex.Message.IndexOf("Line ") + 5;
            //    int endpos = ex.Message.IndexOf(",", startpos);
            //    int line = Convert.ToInt16(ex.Message.Substring(startpos, endpos - startpos));
            //    FrmXMLError frmXMLError = new FrmXMLError(ex.Message, doc, line);
            //    frmXMLError.ShowDialog(this);
            //    return;
            //}


            //// TODO:  create common file same method or class
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.AddExtension = true;
            //saveFileDialog.DefaultExt = "xml";
            //saveFileDialog.FileName = DatabaseName + " Procedures";
            //saveFileDialog.Title = "Save Documentation file";
            //saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            //DialogResult result = saveFileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string saveFileName = saveFileDialog.FileName;
            //    try
            //    {
            //        xmlDoc.Save(saveFileName);

            //    }
            //    catch (Exception exp)
            //    {
            //        MessageBox.Show("An error occurred while attempting to save the file. The error is:"
            //            + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
            //        return;
            //    }
            //    string xslPath = saveFileName.Substring(0, saveFileName.LastIndexOf("\\"));
            //    CopyEmbeddedResource("QueryCommander.Embedded.doc.xsl", xslPath + "\\doc.xsl");

            //    System.Diagnostics.Process.Start("IExplore.exe", saveFileName);


            //    this.Cursor = Cursors.Default;
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCurrentWord()
        {
            return txtContent.GetCurrentWord();
        }
        /// <summary>
        /// Save query statement to file
        /// </summary>
        /// <param name="path"></param>
        public void SaveAs(string path)
        {
            try
            {
                // remove readonly attribute
                FileInfo fi = new FileInfo(path);
                if (fi.Exists && ((fi.Attributes & System.IO.FileAttributes.ReadOnly) != 0))
                {
                    DialogResult dr = MessageBox.Show("Overwrite read-only file?", path, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        fi.Attributes -= System.IO.FileAttributes.ReadOnly;
                        fi.Delete();
                    }
                    else
                    {
                        return;
                    }
                }
                txtContent.SaveFile(path);
                FileName = path;
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(string.Format("Errors Ocurred\n{0}", ex.Message), "Save Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Gives the user the option to alter the header
        /// </summary>
        public void ComplementHeader()
        {
            //string header = "";
            //if (txtContent.SelectedText.Length > 1)
            //    return;
            //try
            //{
            //    QueryCommander.Config.Settings settings = QueryCommander.Config.Settings.Load();
            //    if (settings.Exists())
            //    {
            //        if (!settings.ShowFrmDocumentHeader)
            //            return;
            //    }
            //    int start = txtContent.Text.IndexOf("<member");
            //    int end = txtContent.Text.IndexOf("</member>");
            //    if (start > -1 && end > -1)
            //    {
            //        end += 9; //Add length of </member>
            //        header = txtContent.Text.Substring(start, end - start);
            //        FrmDocumentHeader frm = new FrmDocumentHeader(header);
            //        if (frm.ShowDialogWindow(this) == DialogResult.OK)
            //        {
            //            txtContent.Text = txtContent.Text.Replace(header, frm.Header);
            //            txtContent.Refresh();

            //        }
            //        XmlDocument _doc = new XmlDocument();
            //        _doc.LoadXml(header);
            //        XmlNodeList nList = _doc.GetElementsByTagName("member");
            //        XmlNode n = nList[0].Attributes.GetNamedItem("name");
            //    }
            //}
            //catch (System.Xml.XmlException ex)
            //{
            //    int pos = 0;
            //    for (int i = 0; i < ex.LineNumber - 1; i++)
            //    {
            //        pos = header.IndexOf("\n", pos + 1);
            //    }

            //    string lineText = header.Substring(pos, ex.LinePosition) + "<-\n\n\tMake sure the text in well formated\n\nref: http://www.w3c.org\n";

            //    XmlException xmlEx = new XmlException(ex.Message + "\n" + lineText, ex.InnerException, ex.LineNumber, ex.LinePosition);

            //    throw xmlEx;
            //}

        }

        /// <summary>
        /// Calls MainForm.PopulateRecentItems
        /// </summary>
        /// <param name="objectName"></param>
        public void AddToRecentObjects(string objectName)
        {
            //if (objectName.Trim().Length == 0)
            //    return;

            //bool nodeExists = false;

            //try
            //{
            //    XmlDocument doc = GetRecentObjects();

            //    XmlNodeList rootNodeList = doc.GetElementsByTagName("recentobjects");

            //    XmlNodeList nl = doc.GetElementsByTagName("objectName");

            //    foreach (XmlNode n in nl)
            //    {
            //        if (n.InnerText == objectName)
            //        {
            //            n.Attributes["changedate"].Value = DateTime.Now.ToString();
            //            nodeExists = true;
            //            break;
            //        }
            //    }

            //    if (!nodeExists)
            //    {
            //        XmlElement xmlelem = doc.CreateElement("", "objectName", "");
            //        XmlText xmltext = doc.CreateTextNode(objectName);
            //        xmlelem.AppendChild(xmltext);
            //        xmlelem.SetAttribute("changedate", DateTime.Now.ToString());
            //        doc.ChildNodes.Item(1).AppendChild(xmlelem);
            //        XmlElement elem = doc.CreateElement("objectName");
            //        elem.SetAttribute("changedate", DateTime.Now.ToLongTimeString());
            //    }

            //    doc.Save(Application.StartupPath + "\\RecentObjects.xml");
            //    MainForm frm = (MainForm)MdiParentForm;
            //    frm.PopulateRecentItems();
            //}
            //catch
            //{
            //    throw;
            //}

        }

        /// <summary>
        /// xml2Data - CreateTablesScript
        /// </summary>
        public void GetCreateTablesScriptFromXMLFile()
        {
            try
            {
                //    FrmChooseXMLFile frm = new FrmChooseXMLFile();
                //    frm.rbData.Checked = false;
                //    frm.rbStructure.Checked = true;

                //    if (frm.ShowDialogWindow(this) == DialogResult.OK)
                //    {
                //        string file = frm.FileName;
                //        bool createKeys = frm.CreateKeys;
                //        XmlTextReader reader = new XmlTextReader(file);
                //        XMLDatabase xmlDatabase = new XMLDatabase(reader);
                //        string script = "";

                //        if (frm.rbStructure.Checked)
                //        {
                //            script = xmlDatabase.GetDatabaseSQLScript(createKeys);
                //        }
                //        else
                //        {
                //            script = xmlDatabase.GetInsertScript(createKeys);
                //        }

                //        this.Content = script;
                //    }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                if (ex.Message == "XmlContainsAttributes")
                {
                    MessageBox.Show("QueryCommander XML-import only support XmlElement in this version\n\nSample:\n<PERSON>\n\t<FIRSTNAME>John</FIRSTNAME>\n\t<LASTNAME>Smith</LASTNAME>\n</PERSON>", "XMLAttributes not supported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                throw;
            }
        }
        /// <summary>
        /// xml2Data - Import data
        /// </summary>
        public void GetInsertScriptFromXMLFile()
        {
            try
            {
                //FrmChooseXMLFile frm = new FrmChooseXMLFile();
                //frm.rbData.Checked = true;
                //frm.rbStructure.Checked = false;

                //if (frm.ShowDialogWindow(this) == DialogResult.OK)
                //{
                //    string file = frm.FileName;
                //    bool createKeys = frm.CreateKeys;
                //    XmlTextReader reader = new XmlTextReader(file);
                //    XMLDatabase xmlDatabase = new XMLDatabase(reader);
                //    string script = "";

                //    if (frm.rbStructure.Checked)
                //    {
                //        script = xmlDatabase.GetDatabaseSQLScript(createKeys);
                //    }
                //    else
                //    {
                //        script = xmlDatabase.GetInsertScript(createKeys);
                //    }

                //    this.Content = script;
                //}
            }
            catch
            {
                throw;
            }
        }

        ///// <summary>
        ///// Calls Plug-in method
        ///// </summary>
        ///// <param name="triggerType"></param>
        ///// <param name="callContext"></param>
        //public void ExecutePlugin(Common.TriggerTypes triggerType, QueryCommander.PlugIn.Core.CallContext callContext)
        //{
        //    try
        //    {
        //        string ret = null;
        //        MainForm frm = (MainForm)MdiParentForm;
        //        foreach (string fileName in frm.Plugins)
        //        {
        //            if (fileName.IndexOf("Interop.") > -1)
        //                continue;

        //            if (IsTriggerType(fileName, triggerType))
        //            {
        //                object obj = GetTriggerTypeObject(fileName, triggerType);
        //                PropertyInfo property = obj.GetType().GetProperty("ExecutionType");
        //                Common.ExecutionTypes executionType = (Common.ExecutionTypes)property.GetValue(obj, null);

        //                switch (triggerType)
        //                {
        //                    case Common.TriggerTypes.OnBeforeQueryExecution:
        //                        ret = (string)((QueryCommander.PlugIn.Core.Interfaces.IPlugin_OnBeforeQueryExecution1)obj).Execute(callContext, this.Handle, ((MainForm)MdiParentForm).plugInVariables);
        //                        break;
        //                    case Common.TriggerTypes.OnAfterQueryExecution:
        //                        ret = (string)((QueryCommander.PlugIn.Core.Interfaces.IPlugin_OnAfterQueryExecution1)obj).Execute(callContext, this.Handle, ((MainForm)MdiParentForm).plugInVariables);
        //                        break;
        //                    default:
        //                        return;
        //                }

        //                switch (executionType)
        //                {
        //                    case Common.ExecutionTypes.InsertAtPoint:
        //                        int pos = txtContent.SelectionStart;
        //                        txtContent.SelectedText = (string)ret;
        //                        break;
        //                    case Common.ExecutionTypes.InsertToNewQueryWindow:
        //                        frm.NewQueryform();
        //                        frm.ActiveQueryForm.Content = (string)ret;
        //                        break;
        //                    case Common.ExecutionTypes.ReplaceToQueryWindow:
        //                        this.Content = (string)ret;
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    catch //(Exception ex)
        //    {
        //        return;
        //    }
        //}
        ///// <summary>
        ///// Calls Plug-in method
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="menuItem"></param>

        //public void ExecutePlugin(QueryCommander.PlugIn.Core.Interfaces.IPlugin_OnMenuClick1 obj, MenuItem menuItem)
        //{
        //    QueryCommander.PlugIn.Core.CallContext callContext = new QueryCommander.PlugIn.Core.CallContext(this.dbConnection, txtContent.Text, null);

        //    object ret = obj.Execute(callContext, this.Handle, ((MainForm)MdiParentForm).plugInVariables, menuItem);
        //    switch (obj.ExecutionType)
        //    {
        //        case Common.ExecutionTypes.InsertAtPoint:
        //            int pos = txtContent.SelectionStart;
        //            txtContent.SelectedText = (string)ret;
        //            break;
        //        case Common.ExecutionTypes.InsertToNewQueryWindow:
        //            MainForm frm = (MainForm)MdiParentForm;
        //            frm.NewQueryform();
        //            frm.ActiveQueryForm.Content = (string)ret;
        //            break;
        //        case Common.ExecutionTypes.ReplaceToQueryWindow:
        //            this.Content = (string)ret;
        //            break;
        //    }
        //}


        public void PrintStatement(bool preview)
        {
            //_printType = PrintType.Statement;
            //if (preview)
            //{
            //    printPreviewDialog.ShowDialog();
            //    return;
            //}
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}
        }
        public void PrintOutPut(bool preview)
        {
            try
            {
                //_printType = PrintType.output;
                //TabPage tc = ((MainForm)this.MdiParentForm).OutputWindow.tabControl1.TabPages[0];

                //for (int controlIndex = 0; controlIndex < tc.Controls.Count; controlIndex++)
                //{
                //    if (tc.Controls[controlIndex] is DataGrid)
                //    {
                //        DataGrid dg = (DataGrid)tc.Controls[controlIndex];

                //        _gridPrinterClass = new GridPrinterClass(printDocument, dg);

                //        if (preview)
                //        {
                //            printPreviewDialog.ShowDialog();
                //            return;
                //        }
                //        else
                //            printDocument.Print();
                //    }
                //}

                ////			_printType = PrintType.output;
                ////			foreach(TabPage tc in ((MainForm) this.MdiParentForm).OutputWindow.tabControl1.TabPages)
                ////			{
                ////				//foreach(DataGrid dg in tc.Controls)
                ////				for(int controlIndex=0;controlIndex<tc.Controls.Count;controlIndex++)
                ////				{
                ////					if(tc.Controls[controlIndex] is DataGrid)
                ////					{
                ////						DataGrid dg = (DataGrid)tc.Controls[controlIndex];
                ////					
                ////						_gridPrinterClass = new GridPrinterClass(printDocument,dg);
                ////					
                ////						if(preview)
                ////						{
                ////							printPreviewDialog.ShowDialog();
                ////							return;
                ////						}
                ////						else
                ////							printDocument.Print();
                ////					}
                ////				}
                ////			}

                //_gridPrinterClass = null;
            }
            catch
            { return; }

        }
        public void PrintPageSetUp()
        {
            //pageSetupDialog.ShowDialog();
        }
        #endregion

        #region Classes
        /// <summary>
        /// Custom MenuItem used for snippets
        /// </summary>
        public class SnippetMenuItem : MenuItem
        {
            public string statement = "";
        }
        //public class DateTimeReverserClass : IComparer
        //{
        //    // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        //    int IComparer.Compare(Object x, Object y)
        //    {
        //        DateTime dx = (DateTime)x;
        //        DateTime dy = (DateTime)y;
        //        if (dx > dy)
        //            return -1;
        //        else
        //            return 1;
        //    }
        //}

        private class Alias
        {
            public Alias(string alias, string table)
            {
                AliasName = alias;
                TableName = table;

            }

            public string AliasName;
            public string TableName;
        }

        //private class OutPutContainer
        //{
        //    public OutPutContainer(DataSet dataset, IDatabaseManager database, string message, TimeSpan executionTime, bool query, string statusText)
        //    {
        //        this.dataset = dataset;
        //        this.database = database;
        //        this.message = message;
        //        this.executionTime = executionTime;
        //        this.query = query;
        //        this.statusText = statusText;
        //    }
        //    public DataSet dataset;
        //    public IDatabaseManager database;
        //    public string message;
        //    public TimeSpan executionTime;
        //    public string statusText;
        //    bool query;
        //}
        #endregion
    }
}