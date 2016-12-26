using System.Collections.Generic;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    public partial class DbBrowser : Form
    {
        IDbObject dbObject;

        public DbBrowser()
        {
            InitializeComponent();
            var dbviewfrm = (DbView)Application.OpenForms["DbView"];
            SetListView(dbviewfrm);
        }

        public void SetListView(DbView dbviewfrm)
        {
            #region �õ����Ͷ���
            var treeNodeSelected = dbviewfrm.treeView1.SelectedNode;
            if (treeNodeSelected == null)
                return;
            var servername = "";
            switch (treeNodeSelected.Tag.ToString())
            {
                case "serverlist":
                    return;
                case "server":
                    {
                        servername = treeNodeSelected.Text;
                        CreatDbObj(servername);

                        #region listView1

                        this.lblViewInfo.Text = " ��������" + servername;
                        this.lblNum.Text = treeNodeSelected.Nodes.Count.ToString() + "��";
                        this.listView1.Columns.Clear();
                        this.listView1.Items.Clear();
                        this.listView1.LargeImageList =this.imglistDB;
                        //this.listView1.SmallImageList = imglistView;
                        this.listView1.View = View.LargeIcon;
                        foreach (TreeNode node in treeNodeSelected.Nodes)
                        {
                            var dbName = node.Text;
                            var item1 = new ListViewItem(dbName, 0);
                            item1.SubItems.Add(dbName);
                            item1.ImageIndex = 0;
                            listView1.Items.AddRange(new ListViewItem[] { item1 });
                        }
                        SetListViewMenu("db");
                        #endregion
                    }
                    break;
                case "db":
                    {
                        servername = treeNodeSelected.Parent.Text;
                        CreatDbObj(servername);
                        #region
                        this.lblViewInfo.Text = " ���ݿ⣺" + treeNodeSelected.Text;
                        this.lblNum.Text = treeNodeSelected.Nodes.Count.ToString() + "��";                        
                        SetListViewMenu("table");
                        BindlistViewTab(treeNodeSelected.Text, treeNodeSelected.Tag.ToString());
                        #endregion
                    }
                    break;
                case "tableroot":
                case "viewroot":
                case "procroot":
                    {
                        servername = treeNodeSelected.Parent.Parent.Text;
                        var dbName = treeNodeSelected.Parent.Text;
                        CreatDbObj(servername);

                        #region
                        this.lblViewInfo.Text = " ���ݿ⣺" + dbName;
                        this.lblNum.Text = treeNodeSelected.Nodes.Count.ToString() + "��";
                                                                
                        SetListViewMenu("table");
                        BindlistViewTab(dbName, treeNodeSelected.Tag.ToString());
                        #endregion
                    }
                    break;                    
                case "table":
                case "view":
                    {
                        servername = treeNodeSelected.Parent.Parent.Parent.Text;
                        var dbName = treeNodeSelected.Parent.Parent.Text;
                        var tabname = treeNodeSelected.Text;
                        CreatDbObj(servername);                       

                        #region

                        this.lblViewInfo.Text = " ��" + tabname;
                        this.lblNum.Text = treeNodeSelected.Nodes.Count.ToString() + "��";

                        SetListViewMenu("column");
                        BindlistViewCol(dbName, tabname);

                        #endregion
                    }
                    break;
                case "proc":
                    {
                        servername = treeNodeSelected.Parent.Parent.Parent.Text;
                        var dbName = treeNodeSelected.Parent.Parent.Text;
                        var tabname = treeNodeSelected.Text;
                        CreatDbObj(servername);

                        #region

                        this.lblViewInfo.Text = " �洢���̣�" + tabname;
                        this.lblNum.Text = treeNodeSelected.Nodes.Count.ToString() + "��";

                        //SetListViewMenu("column");
                        //BindlistViewCol(dbName, tabname);
                        //this.listView1.Columns.Clear();
                        this.listView1.Items.Clear();

                        #endregion
                    }
                    break;
                case "column":
                    servername = treeNodeSelected.Parent.Parent.Parent.Parent.Text;
                    break;
            }           
            #endregion
        }

        private void CreatDbObj(string servername)
        {
            var dbset = DbConfig.GetSetting(servername);
            //todo:���Ҫ��������ͨ�á�
            dbObject = DBOMaker.CreateDbObj(dbset.DbType);
            dbObject.DbConnectStr = dbset.ConnectStr;
        }       

        #region ΪlistView� �� ����
        private void BindlistViewTab(string Dbname, string treeNodeSelectedType)
        {
           // SetListViewMenu("table");
           
            this.listView1.Columns.Clear();
            this.listView1.Items.Clear();
            this.listView1.LargeImageList = imglistView;
            this.listView1.SmallImageList = imglistView;
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;           
            listView1.Columns.Add("����", 250, HorizontalAlignment.Left);
            listView1.Columns.Add("������", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("����", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("��������", 200, HorizontalAlignment.Left);

            List<TableInfo> tablist = null;
            switch (treeNodeSelectedType)
            {
                case "db":
                    tablist = dbObject.GetTabViewsInfo(Dbname);
                    break;
                case "tableroot":
                    tablist = dbObject.GetTablesInfo(Dbname);
                    break;
                case "viewroot":
                    tablist = dbObject.GetVIEWsInfo(Dbname);
                    break;
                case "procroot":
                    tablist = dbObject.GetProcInfo(Dbname);
                    break;
            }

            if ((tablist!=null)&&(tablist.Count > 0))
            {
                foreach (var tab in tablist)
                {
                    var name = tab.TabName;
                    var item1 = new ListViewItem(name, 0);

                    var user =tab.TabUser;
                    item1.SubItems.Add(user);

                    var type = tab.TabType;
                    switch (type.Trim())
                    {
                        case "S":
                            type = "ϵͳ";
                            break;
                        case "U":
                            type = "�û�";
                            item1.ImageIndex = 2;
                            break;
                        case "TABLE":
                            type = "��";
                            item1.ImageIndex = 2;
                            break;
                        case "V":
                        case "VIEW":
                            type = "��ͼ";
                            item1.ImageIndex = 3;
                            break;
                        case "P":
                            type = "�洢����";
                            item1.ImageIndex = 5;
                            break;
                        default:
                            type = "ϵͳ";
                            break;

                    }
                    item1.SubItems.Add(type);
                    var time = tab.TabDate;
                    item1.SubItems.Add(time);
                    listView1.Items.AddRange(new ListViewItem[] { item1 });
                }
            }
        }

        #endregion

        #region  ΪlistView� �� ����

        private void BindlistViewCol(string Dbname, string TableName)
        {
            SetListViewMenu("colum");
            //�����б�
            this.listView1.Columns.Clear();
            this.listView1.Items.Clear();
            this.listView1.LargeImageList = imglistView;
            this.listView1.SmallImageList = imglistView;            
            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.FullRowSelect = true;
            
            listView1.Columns.Add("���", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("����", 110, HorizontalAlignment.Left);
            listView1.Columns.Add("��������", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("����", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("С��", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("��ʶ", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("����", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("�����", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Ĭ��ֵ", 100, HorizontalAlignment.Left);
            //listView1.Columns.Add("�ֶ�˵��", 100, HorizontalAlignment.Left);

            var collist = dbObject.GetColumnInfoList(Dbname, TableName);
            if ((collist!=null)&&(collist.Count > 0))
            {                
                foreach (var col in collist)
                {
                    var order = col.ColOrder;
                    var columnName = col.ColumnName;
                    var columnType = col.TypeName;
                    var Length = col.Length;
                    switch (columnType)
                    {                        
                        case "varchar":
                        case "nvarchar":
                        case "char":
                        case "nchar":
                        case "varbinary":
                            {
                                Length = CodeCommon.GetDataTypeLenVal(columnType, Length);                                
                            }
                            break;
                        default:                          
                            break;
                    }

                    var Preci = col.Preci;
                    var Scale = col.Scale;
                    var defaultVal = col.DefaultVal;
                    var description = col.ColDescription;
                    var IsIdentity = (col.IsIdentity) ? "��" : "";
                    var ispk = (col.IsPK) ? "��" : "";
                    var isnull = (col.IsNull) ? "��" : "";

                    var item1 = new ListViewItem(order, 0);
                    item1.ImageIndex = 4;
                    item1.SubItems.Add(columnName);
                    item1.SubItems.Add(columnType);
                    item1.SubItems.Add(Length);
                    item1.SubItems.Add(Scale);
                    item1.SubItems.Add(IsIdentity);
                    if ((ispk == "��") && (isnull.Trim() == ""))
                    {
                    }
                    else
                    {
                        ispk = "";
                    }
                    item1.SubItems.Add(ispk);
                    item1.SubItems.Add(isnull);
                    item1.SubItems.Add(defaultVal);

                    listView1.Items.AddRange(new ListViewItem[] { item1 });

                }
            }
        }
        #endregion
        
        #region �趨listview�Ҽ��˵�
        private void SetListViewMenu(string itemType)
        {
            switch (itemType.ToLower())
            {
                case "server":
                    {                        
                    }
                    break;
                case "db":
                    {
                    }
                    break;
                case "table":
                    {                        
                    }
                    break;
                case "column":
                    {
                    }
                    break;
                default:
                    {                       
                    }
                    break;
            }
        }
        #endregion
    }
}