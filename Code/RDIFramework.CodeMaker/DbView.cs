using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RDIFramework.CodeMaker
{
    //���ݿ������
    public partial class DbView : Form
    {
        #region ϵͳ����

        MainForm mainfrm;
        LoginForm logo = new LoginForm();
        LoginOra logoOra = new LoginOra();
        TreeNode treeNodeRightClick;//�Ҽ��˵������Ľڵ�
        public TreeNode treeNodeServerList;
        IDbObject dbObject;
        DbTypeSel dbTypeSelect = new DbTypeSel();
        ModuleSettings setting;
        private bool isLayoutCalled = false;    
        #endregion       
 
        delegate void AddTreeNodeEventHandler(TreeNode ParentNode, TreeNode Node);
        delegate void SetTreeNodeFontEventHandler(TreeNode Node, Font nodeFont);
        //delegate void SetTreeEventHandler(TreeNode serverNode, string dbtype, string ServerIp);

        public DbView(Form mdiParentForm)
        {
            InitializeComponent();            
            mainfrm = (MainForm)mdiParentForm;
            bgwConnServer.DoWork += DoConnect;
            bgwConnServer.ProgressChanged += ProgessChangedCon;
            bgwConnServer.RunWorkerCompleted += CompleteWorkCon;

            bgwRegServer.DoWork += RegServer;
            bgwRegServer.ProgressChanged += ProgessChangedReg;
            bgwRegServer.RunWorkerCompleted += CompleteWorkReg;
            this.treeView1.ExpandAll();
        }

        #region FormLoad

        private void DbView_Load(object sender, EventArgs e)
        {
            LoadServer();
            setting = ModuleConfig.GetSettings();
            mainfrm = (MainForm)Application.OpenForms["MainForm"];
        }

        #endregion

        #region ��ʼ����������

        private void LoadServer()
        {
            this.treeView1.Nodes.Clear();
            treeNodeServerList = new TreeNode("������") {Tag = "serverlist", ImageIndex = 0, SelectedImageIndex = 0};
            treeView1.Nodes.Add(treeNodeServerList);

            var dbs = DbConfig.GetSettings();
            if (dbs == null) return;
            foreach (var serverNode in from db in dbs
                                       let servername = db.Server
                                       let dbtype = db.DbType
                                       let dbName = db.DbName
                                       select new TreeNode(GetserverNodeText(servername, dbtype, dbName))
            {
                ImageIndex = 1,
                SelectedImageIndex = 1,
                Tag = "server"
            })
            {
                treeNodeServerList.Nodes.Add(serverNode);
            }
           
            treeNodeServerList.Expand();
        }

        #endregion

        #region ��������

        // ����TabPage
        private void AddTabPage(string pageTitle, Control ctrForm)
        {
            if (mainfrm.tabControlMain.Visible == false)
            {
                mainfrm.tabControlMain.Visible = true;
            }
            var page = new Crownwood.Magic.Controls.TabPage {Title = pageTitle, Control = ctrForm};
            //MainForm mainfrm = (MainForm)Application.OpenForms["MainForm"];
            mainfrm.tabControlMain.TabPages.Add(page);
            mainfrm.tabControlMain.SelectedTab = page;
        }

        /*
        // ����TabPage
        private void AddTabPage(string pageTitle, Control ctrForm, MainForm mainfrm)
        {
            if (mainfrm.tabControlMain.Visible == false)
            {
                mainfrm.tabControlMain.Visible = true;
            }
            Crownwood.Magic.Controls.TabPage page = new Crownwood.Magic.Controls.TabPage();
            page.Title = pageTitle;
            page.Control = ctrForm;
            mainfrm.tabControlMain.TabPages.Add(page);
            mainfrm.tabControlMain.SelectedTab = page;
        }

        // �����µ�Ψһ����ҳ���������ظ��ģ�
        private void AddSinglePage(Control control, string Title)
        {
            if (mainfrm.tabControlMain.Visible == false)
            {
                mainfrm.tabControlMain.Visible = true;
            }
            bool showed = false;
            Crownwood.Magic.Controls.TabPage currPage = null;
            foreach (Crownwood.Magic.Controls.TabPage page in mainfrm.tabControlMain.TabPages)
            {
                if (page.Control.Name == control.Name)
                {
                    showed = true;
                    currPage = page;
                }
            }
            if (!showed)//������
            {
                AddTabPage(Title, control);
            }
            else
            {
                mainfrm.tabControlMain.SelectedTab = currPage;
            }
        }
        */

        /// <summary>
        /// �첽�߳���Ϊ�����ӽڵ�
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="node"></param>
        public void AddTreeNode(TreeNode parentNode, TreeNode node)
        {
            //this.treeView1.BeginInvoke(new Action(() => { ParentNode.Nodes.Add(Node); }));
            if (this.treeView1.InvokeRequired)
            {
                var onAddTreeNode = new AddTreeNodeEventHandler(AddTreeNode);
                this.Invoke(onAddTreeNode, new object[] { parentNode, node });
            }
            else
            {
                parentNode.Nodes.Add(node);
            }
        }

        /// <summary>
        /// �첽�߳������ýڵ�����
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeFont"></param>
        public void SetTreeNodeFont(TreeNode node, Font nodeFont)
        {
            if (this.treeView1.InvokeRequired)
            {
                var onSetTreeNodeFont = new SetTreeNodeFontEventHandler(SetTreeNodeFont);
                this.Invoke(onSetTreeNodeFont, new object[] { node, nodeFont });
            }
            else
            {
                node.NodeFont = nodeFont;
            }
        }

        /// <summary>
        /// �õ�ѡ�еķ�����������Ϣ
        /// </summary>
        /// <returns></returns>
        public string GetLongServername()
        {
            var tNodeSelected = treeView1.SelectedNode;
            if (tNodeSelected == null)
                return "";
            var loneServername = "";
            switch (tNodeSelected.Tag.ToString())
            {
                case "serverlist":
                    return "";
                case "server":
                    {
                        loneServername = tNodeSelected.Text;
                    }
                    break;
                case "db":
                    {
                        loneServername = tNodeSelected.Parent.Text;
                    }
                    break;
                case "tableroot":
                case "viewroot":
                    {
                        loneServername = tNodeSelected.Parent.Parent.Text;
                    }
                    break;
                case "table":
                case "view":
                    {
                        loneServername = tNodeSelected.Parent.Parent.Parent.Text;
                    }
                    break;
                case "column":
                    loneServername = tNodeSelected.Parent.Parent.Parent.Parent.Text;
                    break;
            }

            return loneServername;
        }

        //���ݷ��������õõ��������ڵ��ַ���
        private string GetserverNodeText(string servername, string dbtype, string dbName)
        {
            var str = servername + "(" + dbtype + ")";
            if ((dbName.Trim() != "") && (dbName.Trim() != "master"))
            {
                str += "(" + dbName + ")";
            }
            return str;
        }

        #endregion

        #region ������
        private void tsbtnAddServer_Click(object sender, EventArgs e)
        {
            if (bgwRegServer.IsBusy)
            {
                MessageBox.Show("������æ�������ĵȴ�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bgwRegServer.RunWorkerAsync();
            }
        }

        private void tsbtnConnect_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null || treeNodeRightClick.Tag == null || treeNodeRightClick.Tag.ToString() != "server")
            {
                return;
            }

            if ((treeNodeRightClick.Tag.ToString() == "server") & (treeNodeRightClick.Nodes.Count > 0))
            {
                return;
            }

            if (!bgwConnServer.IsBusy)
            {
                bgwConnServer.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("����ִ�к�̨���������Եȣ�");
            }
        }

        private void tsbtnDisConnect_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null || treeNodeRightClick.Tag == null || treeNodeRightClick.Tag.ToString() != "server")
            {
                return;
            }

            try
            {
                if ((treeNodeRightClick.Tag.ToString() == "server") & (treeNodeRightClick.Nodes.Count > 0))
                {
                    treeNodeRightClick.Nodes.Clear();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show("����ʧ�ܣ�" + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region treeview �����
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (bgwConnServer.IsBusy)
                {
                    return;
                }
                var tNodeSelected = this.treeView1.SelectedNode;
                var selectedStr = tNodeSelected.Text;
                var nodeType = tNodeSelected.Tag.ToString().ToLower();
                mainfrm = (MainForm)Application.OpenForms["MainForm"];
                
                var dbBrowserFrm = (DbBrowser)Application.OpenForms["DbBrowser"];
                if (dbBrowserFrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("���ڼ������ݿ�.....");
                    dbBrowserFrm.SetListView(this);
                }

                /*
                CodeMaker codemakerfrm = (CodeMaker)Application.OpenForms["CodeMaker"];
                if (codemakerfrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("���ڼ������ݿ�.....");
                    codemakerfrm.SetListView(this);
                }
                CodeMakerM codemakermfrm = (CodeMakerM)Application.OpenForms["CodeMakerM"];
                if (codemakermfrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("���ڼ������ݿ�.....");
                    codemakermfrm.SetListView(this);
                }

                CodeTemplate codetempfrm = (CodeTemplate)Application.OpenForms["CodeTemplate"];
                if (codetempfrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("���ڼ������ݿ�.....");
                    codetempfrm.SetListView(this);
                }

                 */
                #region  ѡ��ĳ���ͽڵ�
                switch (nodeType)
                {
                    case "serverlist":
                        {
                            mainfrm.toolComboBox_DB.Items.Clear();
                            mainfrm.toolComboBox_Table.Items.Clear();
                            mainfrm.toolComboBox_DB.Visible = false;
                            mainfrm.toolComboBox_Table.Visible = false;
                            //mainfrm.����ToolStripMenuItem.Visible = false;
                        }
                        break;
                    case "server":
                        {
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = false;
                            //mainfrm.����ToolStripMenuItem.Visible = false;
                        }
                        break;
                    case "db":
                        {
                            #region
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = true;
                            mainfrm.toolComboBox_DB.Text = tNodeSelected.Parent.Text;
                            ////mainfrm.����ToolStripMenuItem.Visible = false;
                            #endregion
                        }
                        break;
                    case "tableroot":
                    case "viewroot":
                        {
                            #region
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = true;
                            mainfrm.toolComboBox_DB.Text = tNodeSelected.Parent.Text;
                            //mainfrm.����ToolStripMenuItem.Visible = false;
                            #endregion

                        }
                        break;
                    case "table":
                        {
                            #region
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = true;
                            mainfrm.toolComboBox_DB.Text = tNodeSelected.Parent.Parent.Text;
                            mainfrm.toolComboBox_Table.Text = selectedStr;
                            //mainfrm.����ToolStripMenuItem.Visible = true;
                            //mainfrm.������ToolStripMenuItem.Visible = false;
                            //mainfrm.toolStripMenuItem17.Visible = false;
                            //mainfrm.���ɴ洢����ToolStripMenuItem.Visible = true;
                            //mainfrm.�������ݽű�ToolStripMenuItem.Visible = true;

                            #endregion
                        }
                        break;
                    case "view":
                        {
                            #region
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = true;
                            mainfrm.toolComboBox_DB.Text = tNodeSelected.Parent.Parent.Text;
                            mainfrm.toolComboBox_Table.Text = selectedStr;
                            //mainfrm.����ToolStripMenuItem.Visible = true;
                            //mainfrm.������ToolStripMenuItem.Visible = true;
                            //mainfrm.toolStripMenuItem17.Visible = true;
                            //mainfrm.���ɴ洢����ToolStripMenuItem.Visible = false;
                            //mainfrm.�������ݽű�ToolStripMenuItem.Visible = false;

                            #endregion
                        }
                        break;
                    case "proc":
                        {
                            //mainfrm.����ToolStripMenuItem.Visible = true;
                            //mainfrm.������ToolStripMenuItem.Visible = true;
                            //mainfrm.toolStripMenuItem17.Visible = true;
                            //mainfrm.���ɴ洢����ToolStripMenuItem.Visible = false;
                            //mainfrm.�������ݽű�ToolStripMenuItem.Visible = false;
                        }
                        break;
                    default:
                        {
                            //mainfrm.����ToolStripMenuItem.Visible = false;
                        }
                        break;
                }
                #endregion

                if (mainfrm != null) mainfrm.InvokeSendStatusMessage("����");
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (bgwConnServer.IsBusy)
                {
                    return;
                }

                var mpt = new Point(e.X, e.Y);
                treeNodeRightClick = this.treeView1.GetNodeAt(mpt);
                this.treeView1.SelectedNode = treeNodeRightClick;
                if (treeNodeRightClick != null)
                {
                    CreatMenu(treeNodeRightClick.Tag.ToString());
                    if (e.Button == MouseButtons.Right)
                    {
                        this.DbTreeContextMenu.Show(this.treeView1, mpt);
                        //this.treeView1.ContextMenu.Show(treeView1,mpt);
                    }
                }
                else
                {
                    DbTreeContextMenu.Items.Clear();
                }
            }
            catch(System.Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        #endregion

        #region ����treeview �Ҽ��˵�
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

        private void CreatMenu(string nodeType)
        {
            this.DbTreeContextMenu.Items.Clear();
            switch (nodeType)
            {
                case "serverlist":
                    {
                        #region
                        var ��ӷ�����Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("toolbtn_AddServer.Image"))),
                            Name = "��ӷ�����Item",
                            Text = "��ӷ�����"
                        };
                        //��ӷ�����Item.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                        //��ӷ�����Item.ImageTransparentColor = System.Drawing.Color.Magenta;
                        ��ӷ�����Item.Click += ��ӷ�����Item_Click;

                        var ���ݷ���������Item = new ToolStripMenuItem
                        {
                            Name = "���ݷ���������Item", 
                            Text = "���ݷ���������"
                        };
                        ���ݷ���������Item.Click += ���ݷ���������Item_Click;

                        var �������������Item = new ToolStripMenuItem
                        {
                            Name = "�������������Item", 
                            Text = "�������������"
                        };
                        �������������Item.Click += �������������Item_Click;

                        var ˢ��Item = new ToolStripMenuItem
                        {
                            Name = "ˢ��Item", 
                            Text = "ˢ��"
                        };
                        ˢ��Item.Click += ˢ��Item_Click;

                        var ����Item = new ToolStripMenuItem
                        {
                            Name = "����Item", 
                            Text = "����"
                        };
                        ����Item.Click += ����Item_Click;

                        DbTreeContextMenu.Items.AddRange(
                            new System.Windows.Forms.ToolStripItem[] { 
                                ��ӷ�����Item, 
                                ���ݷ���������Item,
                                �������������Item,
                                ˢ��Item                                
                            }
                            );
                        #endregion
                    }
                    break;
                case "server":
                    {
                        #region
                        var ���ӷ�����Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("toolbtn_Connect.Image"))),
                            Name = "���ӷ�����Item",
                            Text = "���ӷ�����"
                        };
                        //���ӷ�����Item.ImageTransparentColor = System.Drawing.Color.Magenta;
                        ���ӷ�����Item.Click += ���ӷ�����Item_Click;

                        var ע��������Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("toolbtn_unConnect.Image"))),
                            Name = "ע��������Item",
                            Text = "ע��������"
                        };
                        ע��������Item.Click += ע��������Item_Click;

                        var ����Item = new ToolStripMenuItem {Name = "����Item", Text = "ˢ��"};
                        ����Item.Click += server����Item_Click;

                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                ���ӷ�����Item, 
                                ע��������Item,
                                ����Item
                            }
                            );
                        #endregion
                    }
                    break;
                case "db":
                    {
                        #region
                        var ������ݿ�Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("���ݿ������ToolStripMenuItem"))),
                            Name = "������ݿ�Item",
                            Text = "������ݿ�"
                        };
                        ������ݿ�Item.Click += ������ݿ�Item_Click;


                        var �½���ѯItem = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("��ѯ������ToolStripMenuItem"))),
                            Name = "�½���ѯItem",
                            Text = "�½���ѯ"
                        };
                        �½���ѯItem.Click += �½���ѯItem_Click;
                        var Separator1 = new ToolStripSeparator {Name = "Separator1"};

                        var ���ɴ洢����dbItem = new ToolStripMenuItem {Name = "���ɴ洢����Item", Text = "���ɴ洢����"};
                        ���ɴ洢����dbItem.Click += ���ɴ洢����dbItem_Click;

                        var �������ݽű�dbItem = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("dB�ű�������ToolStripMenuItem.Image"))),
                            Name = "�������ݽű�Item",
                            Text = "�������ݽű�"
                        };
                        �������ݽű�dbItem.Click += �������ݽű�dbItem_Click;

                        #region  �����ļ�

                        var �����ļ�dbItem = new ToolStripMenuItem {Name = "�����ļ�Item", Text = "�����ļ�"};
                        var �洢����dbItem = new ToolStripMenuItem {Name = "�洢����Item", Text = "�洢����"};
                        �洢����dbItem.Click += �洢����dbItem_Click;

                        var ���ݽű�dbItem = new ToolStripMenuItem {Name = "���ݽű�Item", Text = "���ݽű�"};
                        ���ݽű�dbItem.Click += ���ݽű�dbItem_Click;
                       
                        #endregion

                        �����ļ�dbItem.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                �洢����dbItem, 
                                ���ݽű�dbItem                                                            
                            }
                            );

                        var ˢ��dbItem = new ToolStripMenuItem {Name = "ˢ��Item", Text = "ˢ��"};
                        ˢ��dbItem.Click += ˢ��dbItem_Click;


                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                ������ݿ�Item,
                                �½���ѯItem,
                                Separator1,
                                ���ɴ洢����dbItem,
                                �������ݽű�dbItem,
                                �����ļ�dbItem,                              
                                ˢ��dbItem
                            }
                            );
                        #endregion
                    }
                    break;
                case "tableroot":
                    break;
                case "viewroot":
                    break;
                case "procroot":
                    break;
                case "table":
                    {
                        #region

                        var ����SQL���Item = new ToolStripMenuItem {Name = "����SQL���Item", Text = "����SQL��䵽"};

                        #region ����SQL��䵽

                        var SELECTItem = new ToolStripMenuItem {Name = "SELECTItem", Text = "SELECT(&S)"};
                        SELECTItem.Click += SELECTItem_Click;

                        var UPDATEItem = new ToolStripMenuItem {Name = "UPDATEItem", Text = "UPDATE(&U)"};
                        UPDATEItem.Click += UPDATEItem_Click;

                        var DELETEItem = new ToolStripMenuItem {Name = "DELETEItem", Text = "DELETE(&D)"};
                        DELETEItem.Click += DELETEItem_Click;

                        var INSERTItem = new ToolStripMenuItem {Name = "INSERTItem", Text = "INSERT(&I)"};
                        INSERTItem.Click += INSERTItem_Click;
                        
                        var Separatort1 = new ToolStripSeparator {Name = "Separatorv1"};

                        var TableDropItem = new ToolStripMenuItem {Name = "TableDropItem", Text = "DROP(&D)"};
                        TableDropItem.Click += TableDropItem_Click;

                        ����SQL���Item.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                SELECTItem, 
                                UPDATEItem,
                                DELETEItem,
                                INSERTItem,
                                Separatort1,
                                TableDropItem
                            }
                            );

                        #endregion

                        var �鿴������tabItem = new ToolStripMenuItem {Name = "�鿴������tabItem", Text = "���������"};
                        �鿴������tabItem.Click += �鿴������tabItem_Click;

                        var �������ݽű�tabItem = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("dB�ű�������ToolStripMenuItem"))),
                            Name = "�������ݽű�tabItem",
                            Text = "�������ݽű�"
                        };
                        �������ݽű�tabItem.Click += �������ݽű�tabItem_Click;

                        var ���ɴ洢����tabItem = new ToolStripMenuItem {Name = "���ɴ洢����tabItem", Text = "���ɴ洢����"};
                        ���ɴ洢����tabItem.Click += ���ɴ洢����tabItem_Click;

                        #region �����ļ�Item
                        var �����ļ�tabItem = new ToolStripMenuItem {Name = "�����ļ�tabItem", Text = "�����ļ�"};

                        var �洢����tabItem = new ToolStripMenuItem {Name = "�洢����tabItem", Text = "�洢����"};
                        �洢����tabItem.Click += �洢����tabItem_Click;

                        var ���ݽű�tabItem = new ToolStripMenuItem {Name = "���ݽű�tabItem", Text = "���ݽű�"};
                        ���ݽű�tabItem.Click += ���ݽű�tabItem_Click;

                        /*
                        ToolStripMenuItem ������tabItem = new ToolStripMenuItem();
                        ������tabItem.Name = "������tabItem";
                        ������tabItem.Text = "������";
                        ������tabItem.Click += new System.EventHandler(������tabItem_Click);
                        */
                        �����ļ�tabItem.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                �洢����tabItem, 
                                ���ݽű�tabItem                             
                            }
                            );
                        #endregion

                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] {                                 
                                ����SQL���Item,
                                �鿴������tabItem,
                                �������ݽű�tabItem,
                                ���ɴ洢����tabItem,                               
                                �����ļ�tabItem                              
                        });

                        var separator1 = new ToolStripSeparator {Name = "Separator1"};
                        var  ����ʵ��tabItem = new ToolStripMenuItem {Name = "�������ݶ���tabItem", Text = "�������ݶ���"};
                        ����ʵ��tabItem.Click += �������ݶ���tabItem_Click;
                        DbTreeContextMenu.Items.AddRange(new ToolStripItem[] { separator1,����ʵ��tabItem});

                        var WebUItabItem = new ToolStripMenuItem { Name = "����WebUI����tabItem", Text = "����WebUI����" };
                        WebUItabItem.Click += ����WebUI����tabItem_Click;
                        DbTreeContextMenu.Items.AddRange(new ToolStripItem[] { WebUItabItem });

                        var MvcUItabItem = new ToolStripMenuItem { Name = "����MvcUI����tabItem", Text = "����MvcUI����" };
                        MvcUItabItem.Click += ����MvcUI����tabItem_Click;
                        DbTreeContextMenu.Items.AddRange(new ToolStripItem[] { MvcUItabItem});
                        #endregion
                    }
                    break;
                case "view":
                    {
                        #region
                        var �ű�Item = new ToolStripMenuItem {Name = "�ű�Item", Text = "�ű�"};

                        var selecTviewItem = new ToolStripMenuItem {Name = "SELECTItem", Text = "SELECT(&S)"};
                        selecTviewItem.Click += SELECTviewItem_Click;

                        var alterViewItem = new ToolStripMenuItem {Name = "AlterViewItem", Text = "ALTER(&U)"};
                        alterViewItem.Click += AlterViewItem_Click;

                        var dropViewItem = new ToolStripMenuItem {Name = "DropViewItem", Text = "DROP(&D)"};
                        dropViewItem.Click += DropViewItem_Click;


                        �ű�Item.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                selecTviewItem, 
                                alterViewItem,
                                dropViewItem                               
                            }
                            );

                        var ������Item = new ToolStripMenuItem {Name = "������Item", Text = "������"};
                        ������Item.Click += ������Item_Click;

                        var �鿴������tabItem = new ToolStripMenuItem {Name = "�鿴������tabItem", Text = "���������"};
                        �鿴������tabItem.Click += �鿴������tabItem_Click;

                        /*
                        ToolStripSeparator Separatorv1 = new ToolStripSeparator();
                        Separatorv1.Name = "Separatorv1";
                        */
                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                �ű�Item, 
                                ������Item,
                                �鿴������tabItem
                            }
                            );
                        #endregion
                    }
                    break;
                case "proc":
                    {
                        #region
                        var �ű�Item = new ToolStripMenuItem {Name = "�ű�Item", Text = "�ű�"};

                        var procAlterItem = new ToolStripMenuItem {Name = "ProcAlterItem", Text = "ALTER(&U)"};
                        procAlterItem.Click += ProcAlterItem_Click;

                        var procDropItem = new ToolStripMenuItem {Name = "ProcDropItem", Text = "DROP(&D)"};
                        procDropItem.Click += ProcDropItem_Click;

                        var execItem = new ToolStripMenuItem {Name = "EXECItem", Text = "EXEC(&I)"};
                        //EXECItem.Click += new System.EventHandler(EXECItem_Click);
                        �ű�Item.DropDownItems.AddRange(
                           new ToolStripItem[] {                                 
                                procAlterItem,
                                procDropItem                                
                            }
                           );

                        var ������Item = new ToolStripMenuItem {Name = "������Item", Text = "������"};
                        ������Item.Click += ������Item_Click;


                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                �ű�Item, 
                                ������Item                                
                            }
                            );
                        #endregion
                    }
                    break;
                case "column":
                    break;
            }
        }

        #endregion

        #region  treeview �Ҽ��˵��¼�

        #region serverlist_click

        private void ��ӷ�����Item_Click(object sender, EventArgs e)
        {
            bgwRegServer.RunWorkerAsync();
        }

        private void ���ݷ���������Item_Click(object sender, EventArgs e)
        {
            var dlgSqlServer = new SaveFileDialog
            {
                Title = "�������������",
                Filter = "DB Serverlist(*.config)|*.config|All files (*.*)|*.*"
            };
            var dlgResult = dlgSqlServer.ShowDialog(this);
            if (dlgResult != DialogResult.OK) return;
            var filename = dlgSqlServer.FileName;
            var ds = DbConfig.GetSettingDs();
            ds.WriteXml(filename);
        }

        private void �������������Item_Click(object sender, EventArgs e)
        {
            var dlgSqlField = new OpenFileDialog();
            dlgSqlField.Title = "ѡ������������ļ�";
            dlgSqlField.Filter = "DB Serverlist(*.config)|*.config|All files (*.*)|*.*";
            var result = dlgSqlField.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                try
                {
                    var filename = dlgSqlField.FileName;
                    var ds = new DataSet();
                    if (File.Exists(filename))
                    {
                        ds.ReadXml(filename);
                        var fileNamelocal = Application.StartupPath + "\\DbSetting.config";
                        ds.WriteXml(fileNamelocal);
                    }
                    LoadServer();
                }
                catch(Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show("��ȡ�����ļ�ʧ�ܣ�", "��ʾ");
                }
            }
        }
        private void ˢ��Item_Click(object sender, EventArgs e)
        {
            LoadServer();
        }
        private void ����Item_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("ˢ��Item");
        }
        #endregion

        #region server_click

        private void ���ӷ�����Item_Click(object sender, EventArgs e)
        {
            bgwConnServer.RunWorkerAsync();
        }

        private void ע��������Item_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeNodeRightClick == null) return;
                var nodetext = treeNodeRightClick.Text;
                var dbset = DbConfig.GetSetting(nodetext);
                if (dbset != null)
                {
                    DbConfig.DelSetting(dbset.DbType, dbset.Server, dbset.DbName);
                }
                treeNodeServerList.Nodes.Remove(treeNodeRightClick);
            }
            catch
            {
                MessageBox.Show("ע��������ʧ�ܣ���رպ����´����ԡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        //ˢ�·�����
        private void server����Item_Click(object sender, EventArgs e)
        {
            bgwConnServer.RunWorkerAsync();
        }
        #endregion

        #region db_click
        private void ������ݿ�Item_Click(object sender, EventArgs e)
        {
          PageUtility.AddSinglePage(new DbBrowser(), "ժҪ",mainfrm);
        }

        private void �½���ѯItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            //��comboxѡ�е�ǰ��
            var dbName = treeNodeRightClick.Text;
            var server = treeNodeRightClick.Parent.Text;
            var title = server + "." + dbName + "��ѯ.sql";
            var mainfrm = (MainForm)Application.OpenForms["MainForm"];
            PageUtility.AddTabPage(title, new DbQuery(mainfrm, ""), mainfrm);
            //AddTabPage(title, new DbQuery(mainfrm, ""), mainfrm);
            mainfrm.toolComboBox_DB.Text = dbName;
        }

        private void ���ɴ洢����dbItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            mainfrm.InvokeSendStatusMessage("�����������ݿ�:[" +dbName + "]���б�Ĵ洢����,���Ժ�...");
            var dsb = ObjHelper.CreatDsb(longServerName);                
            var strSql = dsb.GetPROCCode(dbName);
            var title = dbName + "�洢����.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
            mainfrm.InvokeSendStatusMessage("����");
        }

        private void �������ݽű�dbItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            var dts = new FrmDbToScript(longServerName, dbName);
            dts.ShowDialog(this);
        }

        private void �洢����dbItem_Click(object sender, EventArgs e)
        {
            var dlgSqlServer = new SaveFileDialog
            {
                Title = "���浱ǰ�ű�",
                Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*"
            };
            var dlgResult = dlgSqlServer.ShowDialog(this);
            if (dlgResult != DialogResult.OK || treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetPROCCode(dbName);

            var filename = dlgSqlServer.FileName;
            var sw = new StreamWriter(filename, false, Encoding.Default); //,false);
            sw.Write(strSql);
            sw.Flush(); //�ӻ�����д����������ļ���
            sw.Close();
            MessageBox.Show("�ű����ɳɹ���", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ���ݽű�dbItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            var dts = new FrmDbToScript(longServerName, dbName);
            dts.ShowDialog(this);
        }

        //����������
        private void ��������dbItem_Click(object sender, EventArgs e)
        {
            var longServerName = treeNodeRightClick.Parent.Text;
            //mainfrm.AddSinglePage(new CodeMaker(), "����������");
        }     

        private void ˢ��dbItem_Click(object sender, EventArgs e)
        {
            var tn = treeNodeRightClick;
            var servercfg = tn.Parent.Text;
            var dbset = DbConfig.GetSetting(servercfg);
            var server = dbset.Server;
            var dbtype = dbset.DbType;
            //string dbName = dbset.DbName; 

            tn.Nodes.Clear();
            var dbObject2 = DBOMaker.CreateDbObj(dbtype);
            dbObject2.DbConnectStr = dbset.ConnectStr;
            var dbName = tn.Text;
            mainfrm.InvokeSendStatusMessage("�������ݿ�" + dbName + "...");
            var tabNode = new TreeNode("��") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "tableroot"};
            var viewNode = new TreeNode("��ͼ") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "viewroot"};
            var procNode = new TreeNode("�洢����") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "procroot"};
            tn.Nodes.Add(tabNode);
            tn.Nodes.Add(viewNode);
            tn.Nodes.Add(procNode);

            #region ��

            try
            {
                var tabNames = dbObject2.GetTables(dbName);
                if (tabNames.Count > 0)
                {
                    //DataRow[] dRows = dt.Select("", "name ASC");
                    foreach (var tabname in tabNames)
                    {
                        var tbNode = new TreeNode(tabname) {ImageIndex = 5, SelectedImageIndex = 5, Tag = "table"};
                        tabNode.Nodes.Add(tbNode);

                        //���ֶ���Ϣ
                        var collist = dbObject2.GetColumnList(dbName, tabname);
                        if ((collist == null) || (collist.Count <= 0)) continue;
                        foreach (var colNode in from col in collist let columnName = col.ColumnName let columnType = col.TypeName select new TreeNode(columnName + "[" + columnType + "]")
                        {
                            ImageIndex = 7,
                            SelectedImageIndex = 7,
                            Tag = "column"
                        })
                        {
                            tbNode.Nodes.Add(colNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "�ı���Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion

            #region	��ͼ

            try
            {
                var dtv = dbObject2.GetVIEWs(dbName);
                if (dtv != null)
                {
                    var dRows = dtv.Select("", "name ASC");
                    foreach (var row in dRows) //ѭ��ÿ����
                    {
                        var tabname = row["name"].ToString();
                        var tbNode = new TreeNode(tabname) {ImageIndex = 6, SelectedImageIndex = 6, Tag = "view"};
                        viewNode.Nodes.Add(tbNode);

                        //���ֶ���Ϣ
                        var collist = dbObject2.GetColumnList(dbName, tabname);
                        if ((collist == null) || (collist.Count <= 0)) continue;
                        foreach (var colNode in from col in collist let columnName = col.ColumnName let columnType = col.TypeName select new TreeNode(columnName + "[" + columnType + "]")
                        {
                            ImageIndex = 7,
                            SelectedImageIndex = 7,
                            Tag = "column"
                        })
                        {
                            tbNode.Nodes.Add(colNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "����ͼ��Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            #endregion

            #region �洢����
            try
            {
                var dtp = dbObject2.GetProcs(dbName);
                if (dtp != null)
                {
                    var dRows = dtp.Select("", "name ASC");
                    foreach (var row in dRows) //ѭ��ÿ����
                    {
                        var tabname = row["name"].ToString();
                        var tbNode = new TreeNode(tabname) {ImageIndex = 8, SelectedImageIndex = 8, Tag = "proc"};
                        procNode.Nodes.Add(tbNode);

                        //���ֶβ�����Ϣ
                        var collist = dbObject2.GetColumnList(dbName, tabname);
                        if ((collist == null) || (collist.Count <= 0)) continue;
                        foreach (var colNode in from col in collist let columnName = col.ColumnName let columnType = col.TypeName select new TreeNode(columnName + "[" + columnType + "]")
                        {
                            ImageIndex = 9,
                            SelectedImageIndex = 9,
                            Tag = "column"
                        })
                        {
                            tbNode.Nodes.Add(colNode);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "����ͼ��Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            #endregion

            mainfrm.InvokeSendStatusMessage("����");
        }

        #endregion

        #region table_click
        private void SELECTItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSQLSelect(dbName, tabname);
            var title = tabname + "��ѯ.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void UPDATEItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSQLUpdate(dbName, tabname);
            var title = tabname + "��ѯ.sql";
            //MainForm frm = (MainForm)MdiParentForm;
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }
        private void DELETEItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSQLDelete(dbName, tabname);
            var title = tabname + "��ѯ.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }
        private void INSERTItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSQLInsert(dbName, tabname);
            var title = tabname + "��ѯ.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void TableDropItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSqlDrop(dbName, name, DBObjectType.TABLE);
            var title = name + "ɾ��.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void �鿴������tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dbObj = ObjHelper.CreatDbObj(longServerName);
            var dl = new DataList(dbObj, dbName, tabname);
            PageUtility.AddTabPage(tabname, dl, mainfrm);
        }

        private void ���ɴ洢����tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);

            dsb.DbName = dbName;
            dsb.TableName = tabname;
            dsb.ProjectName = setting.ProjectName;
            dsb.ProcPrefix = setting.ProcPrefix;
            dsb.Keys = new List<ColumnInfo>();
            dsb.Fieldlist = new List<ColumnInfo>();

            var strSql = dsb.GetPROCCode(dbName, tabname);
            var title = tabname + "�洢����.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void �������ݶ���tabItem_Click(object sender, EventArgs e)
        {
            //�����塢���롢DLL���ĵ���
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;             
            var doForm = new DataObjectForm {TableName = tabname, DBName = dbName, CurrentDbViewForm = this};
            PageUtility.AddTabPage(tabname, doForm, mainfrm);
        }

        private void ����WebUI����tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            IDbObject tempDbObject = ObjHelper.CreatDbObj(longServerName);
            var doForm = new MakerWebUI { TableName = tabname, DBName = dbName, CurrentDbViewForm = this, idbObj = tempDbObject };
            PageUtility.AddTabPage(tabname, doForm, mainfrm);
        }

        private void ����MvcUI����tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            IDbObject tempDbObject = ObjHelper.CreatDbObj(longServerName);
            var doForm = new MakerMvcUI{ TableName = tabname, DBName = dbName, CurrentDbViewForm = this, idbObj = tempDbObject };
            PageUtility.AddTabPage(tabname, doForm, mainfrm);
        }

        
        private void �������ݽű�tabItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(this, "����ñ��������ϴ�ֱ�����ɽ���Ҫ�Ƚϳ���ʱ�䣬\r\nȷʵ��Ҫֱ��������\r\n(������ýű����������ɡ�)", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (treeNodeRightClick != null)
                {
                    var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
                    var dbName = treeNodeRightClick.Parent.Parent.Text;
                    var tabname = treeNodeRightClick.Text;
                    var dsb = ObjHelper.CreatDsb(longServerName);
                    dsb.Fieldlist = new List<ColumnInfo>();
                    var strSql = dsb.CreateTabScript(dbName, tabname);
                    var title = tabname + "�ű�.sql";
                    AddTabPage(title, new DbQuery(mainfrm, strSql));
                }
            }
            if (dr == DialogResult.No && treeNodeRightClick != null)
            {
                var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
                var dbName = treeNodeRightClick.Parent.Parent.Text;
                var tabname = treeNodeRightClick.Text;
                var dts = new FrmDbToScript(longServerName, dbName);
                dts.ShowDialog(this);
            }
        }

        //�����ļ�
        private void �洢����tabItem_Click(object sender, EventArgs e)
        {
            var dlgSqlServer = new SaveFileDialog
            {
                Title = "���浱ǰ�ű�",
                Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*"
            };
            var dlgResult = dlgSqlServer.ShowDialog(this);
            if (dlgResult == DialogResult.OK)
            {
                if (treeNodeRightClick == null)
                {
                    return;
                }
                var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
                var dbName = treeNodeRightClick.Parent.Parent.Text;
                var tabname = treeNodeRightClick.Text;
                var dsb = ObjHelper.CreatDsb(longServerName);
                dsb.DbName = dbName;
                dsb.TableName = tabname;
                dsb.ProjectName = setting.ProjectName;
                dsb.ProcPrefix = setting.ProcPrefix;
                dsb.Keys = new List<ColumnInfo>();
                dsb.Fieldlist = new List<ColumnInfo>();

                var strSql = dsb.GetPROCCode(dbName, tabname);

                var filename = dlgSqlServer.FileName;
                var sw = new StreamWriter(filename, false, Encoding.Default);//,false);
                sw.Write(strSql);
                sw.Flush();//�ӻ�����д����������ļ���
                sw.Close();
                MessageBox.Show("�ű����ɳɹ���", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //�����ļ�
        private void ���ݽű�tabItem_Click(object sender, EventArgs e)
        {
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var dts = new FrmDbToScript(longServerName, dbName);
            dts.ShowDialog(this);
        }

        //�����ļ�
        private void ������tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null)
            {
                return;
            }
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dbObject = ObjHelper.CreatDbObj(longServerName);
        }

        //����������
        private void ��������Item_Click(object sender, EventArgs e)
        {
            //string longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            //if (longServerName == "")
            //    return;
            //mainfrm.AddSinglePage(new CodeMaker(), "����������");
        }
                  
        #endregion   
     
        #region view_click
        private void SELECTviewItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var viewName = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSQLSelect(dbName, viewName);
            var title = viewName + "��ѯ.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void AlterViewItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dbobj = ObjHelper.CreatDbObj(longServerName);
            var str = dbobj.GetObjectInfo(dbName, name);

            //�滻CREATE VIEW ΪALTER VIEW
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    str = System.Text.RegularExpressions.Regex.Replace(str, @"create[\s]+view", "ALTER VIEW ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            var title = name + "�޸�.sql";
            AddTabPage(title, new DbQuery(mainfrm, str));
        }

        private void DropViewItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSqlDrop(dbName, name,DBObjectType.VIEW);
            var title = name + "ɾ��.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }


        private void ������Item_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dbobj = ObjHelper.CreatDbObj(longServerName);
            var str = dbobj.GetObjectInfo(dbName, name);
            var title = name + "����.sql";
            AddTabPage(title, new DbQuery(mainfrm, str));
        }
        #endregion

        #region proc_click
        private void ProcAlterItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dbobj = ObjHelper.CreatDbObj(longServerName);
            var str = dbobj.GetObjectInfo(dbName, name);

            //�滻CREATE VIEW ΪALTER VIEW
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    str = System.Text.RegularExpressions.Regex.Replace(str, @"create[\s]+procedure", "ALTER PROCEDURE ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteException(ex);
            }
            var title = name + "�޸�.sql";
            AddTabPage(title, new DbQuery(mainfrm, str));
        }

        private void ProcDropItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dsb = ObjHelper.CreatDsb(longServerName);
            var strSql = dsb.GetSqlDrop(dbName, name, DBObjectType.PROCEDURE);
            var title = name + "ɾ��.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        } 
        #endregion

        #region ע�������RegServer

        public void RegServer(object sender, DoWorkEventArgs e)
        {
            try
            {              
                Application.DoEvents();
                var dbtype = "SQL2005";
                var dbTypeSelectresult = dbTypeSelect.ShowDialog(this);              
                //this.Invoke(new MethodInvoker(delegate{
                //    dbTypeSelectresult = dbTypeSelect.ShowDialog(this);
                //}));
                if (dbTypeSelectresult == DialogResult.OK)
                {
                    dbtype = dbTypeSelect.dbtype;
                    switch (dbtype)
                    {
                        case "SQL2000":
                        case "SQL2005":
                        case "SQL2008":
                            LoginServer(e);
                            break;
                        case "Oracle":
                            LoginServerOra(e);
                            break;
                        case "OleDb":
                            // LoginServerOledb(e);
                            break;
                        case "MySQL":
                            //LoginServerMySQL(e);
                            break;
                        case "SQLite":
                            //LoginServerSQLite(e);
                            break;
                        default:
                            LoginServer(e);
                            break;
                    }

                    if (treeNodeServerList != null)
                    {
                        treeNodeServerList.Expand();
                    }
                }
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("���ӷ�����ʧ�ܣ���رպ����´����ԡ�\r\n" + ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            e.Result = -1;           
        }
        #endregion
       
        #region ��¼������LoginServer

        #region SQL
        private void LoginServer(DoWorkEventArgs e)
        {
            mainfrm = (MainForm)Application.OpenForms["MainForm"];
            var result = logo.ShowDialog(this);
            if (result == DialogResult.OK)
            {                
                Application.DoEvents();
                                
                var ServerIp = logo.comboBoxServer.Text;
                var dbName = logo.dbName;
                var constr = logo.constr;
                var dbtype = logo.GetSelVer();

                try
                {                    
                    mainfrm.InvokeSendStatusMessage("������֤�����ӷ�����.....");
                    CreatTree("SqlServer", ServerIp, constr, dbName,e);                 

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion       

        #region Oracle
        private void LoginServerOra(DoWorkEventArgs e)
        {
            mainfrm = (MainForm)Application.OpenForms["MainForm"];
            DialogResult result = logoOra.ShowDialog(this);
            if (result != DialogResult.OK) return;
            Application.DoEvents();
            string serverIp = logoOra.txtServer.Text;
            string constr = logoOra.constr;
            string dbname = logoOra.dbname;
            try
            {
                mainfrm.InvokeSendStatusMessage("������֤�����ӷ�����.....");
                CreatTree("Oracle", serverIp, constr, dbname, e);
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(this, ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region ��������������ڵ� CreatTree

        private void CreatTree(string dbtype, string serverIp, string constr, string Dbname, DoWorkEventArgs e)
        {
            dbObject = DBOMaker.CreateDbObj(dbtype);

            var serverNode = new TreeNode(GetserverNodeText(serverIp, dbtype, Dbname)) {Tag = "server"};
            AddTreeNode(treeNodeServerList, serverNode);

            serverNode.ImageIndex = 1;
            serverNode.SelectedImageIndex = 1;

            //0 serverlist
            //1 server
            //2 db
            //3 folderclose
            //4 folderopen
            //5 table
            //6 view
            //7 fild
            this.treeView1.SelectedNode = serverNode;
            mainfrm.InvokeSendStatusMessage("�������ݿ���...");
            Application.DoEvents();
            
            dbObject.DbConnectStr = constr;

            #region ��SQLSERVER ���ݿ���Ϣ
            if ((dbtype == "SQL2005") || (dbtype == "SQL2008"))
            {
                try
                {
                    if ((logo.dbName == "master") || (logo.dbName == ""))
                    {
                        var dblist = dbObject.GetDBList();
                        if (dblist != null)
                        {
                            if (dblist.Count > 0)
                            {
                                mainfrm.toolComboBox_DB.Items.Clear();
                                foreach (var dbName in dblist)
                                {
                                    var dbNode = new TreeNode(dbName)
                                    {
                                        ImageIndex = 2,
                                        SelectedImageIndex = 2,
                                        Tag = "db"
                                    };
                                    AddTreeNode(serverNode, dbNode);
                                    mainfrm.toolComboBox_DB.Items.Add(dbName);
                                }
                                if (mainfrm.toolComboBox_DB.Items.Count > 0)
                                {
                                    mainfrm.toolComboBox_DB.SelectedIndex = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        var dbName = logo.dbName;
                        var dbNode = new TreeNode(dbName) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                        AddTreeNode(serverNode, dbNode);
                        mainfrm.toolComboBox_DB.Items.Clear();
                        mainfrm.toolComboBox_DB.Items.Add(dbName);

                        //������2
                        var dto = dbObject.GetTabViews(dbName);
                        if (dto != null)
                        {
                            mainfrm.toolComboBox_Table.Items.Clear();
                            foreach (DataRow row in dto.Rows)//ѭ��ÿ����
                            {
                                var tabname = row["name"].ToString();
                                mainfrm.toolComboBox_Table.Items.Add(dbName);
                            }
                        }
                    }

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    throw new Exception("��ȡ���ݿ�ʧ�ܣ�" + ex.Message);
                }
            }

            #endregion

            #region Oracle ���ݿⵥ������
            if (dbtype == "Oracle")
            {
                string dbname = serverIp;
                TreeNode dbNode = new TreeNode(dbname) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                AddTreeNode(serverNode, dbNode);
                mainfrm.toolComboBox_DB.Items.Add(dbname);

                //������2
                DataTable dto = dbObject.GetTabViews(dbname);
                if (dto != null)
                {
                    mainfrm.toolComboBox_Table.Items.Clear();
                    foreach (string tabname in from DataRow row in dto.Rows select row["name"].ToString())
                    {
                        mainfrm.toolComboBox_Table.Items.Add(dbname);
                    }
                    if (mainfrm.toolComboBox_Table.Items.Count > 0)
                    {
                        mainfrm.toolComboBox_Table.SelectedIndex = 0;
                    }
                }
            }
            #endregion
            //todo:MySql���ݿⵥ������
            //todo:DB2���ݿⵥ������....

            serverNode.ExpandAll();

            #region  ѭ�����ݿ⣬��������Ϣ
            
            foreach (TreeNode tn in serverNode.Nodes)
            {
                var dbName = tn.Text;
                mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "...");
                SetTreeNodeFont(tn, new Font("����", 9, FontStyle.Bold));
                var tabNode = new TreeNode("��") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "tableroot"};
                AddTreeNode(tn, tabNode);

                var viewNode = new TreeNode("��ͼ") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "viewroot"};
                AddTreeNode(tn, viewNode);

                var procNode = new TreeNode("�洢����") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "procroot"};
                AddTreeNode(tn, procNode);

                #region ��

                try
                {
                    var tabNames = dbObject.GetTables(dbName);
                    if (tabNames.Count > 0)
                    {
                        var pi = 1;
                        foreach (var tabname in tabNames)//ѭ��ÿ����
                        {
                            if (bgwRegServer.CancellationPending)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                bgwRegServer.ReportProgress(pi);
                            }
                            pi++;

                            mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "�ı� " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 5, SelectedImageIndex = 5, Tag = "table"};
                            AddTreeNode(tabNode, tbNode);

                            #region  ���ֶ���Ϣ

                            if (logo.chk_Simple.Checked) continue;
                            var collist = dbObject.GetColumnList(dbName, tabname);
                            if ((collist == null) || (collist.Count <= 0)) continue;
                            foreach (var col in collist)
                            {
                                var columnName = col.ColumnName;
                                var columnType = col.TypeName;
                                var colNode = new TreeNode(columnName + "[" + columnType + "]")
                                {
                                    ImageIndex = 7,
                                    SelectedImageIndex = 7,
                                    Tag = "column"
                                };
                                AddTreeNode(tbNode, colNode);
                            }

                            #endregion
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "�ı���Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

                #region	��ͼ

                try
                {
                    var dtv = dbObject.GetVIEWs(dbName);
                    if (dtv != null)
                    {
                        var dRows = dtv.Select("", "name ASC");
                        foreach (var row in dRows)//ѭ��ÿ����
                        {
                            var tabname = row["name"].ToString();                            
                            mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "����ͼ " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 6, SelectedImageIndex = 6, Tag = "view"};
                            AddTreeNode(viewNode, tbNode);

                            #region  ���ֶ���Ϣ

                            if (logo.chk_Simple.Checked) continue;
                            var collist = dbObject.GetColumnList(dbName, tabname);
                            if ((collist == null) || (collist.Count <= 0)) continue;
                            foreach (var col in collist)
                            {
                                var columnName = col.ColumnName;
                                var columnType = col.TypeName;
                                var colNode = new TreeNode(columnName + "[" + columnType + "]")
                                {
                                    ImageIndex = 7,
                                    SelectedImageIndex = 7,
                                    Tag = "column"
                                };
                                //tbNode.Nodes.Add(colNode);
                                AddTreeNode(tbNode, colNode);
                            }

                            #endregion

                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "����ͼ��Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region �洢����
                try
                {
                    var dtp = dbObject.GetProcs(dbName);
                    if (dtp != null)
                    {
                        var dRows = dtp.Select("", "name ASC");
                        foreach (var tabname in dRows.Select(row => row["name"].ToString()))
                        {
                            mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "�Ĵ洢���� " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 8, SelectedImageIndex = 8, Tag = "proc"};
                            AddTreeNode(procNode, tbNode);

                            #region  ���ֶ���Ϣ
                            if (logo.chk_Simple.Checked) continue;
                            var collist = dbObject.GetColumnList(dbName, tabname);
                            if ((collist == null) || (collist.Count <= 0)) continue;
                            foreach (var colNode in from col in collist 
                                let columnName = col.ColumnName 
                                let columnType = col.TypeName 
                                select new TreeNode(columnName + "[" + columnType + "]")
                                {
                                    ImageIndex = 9,
                                    SelectedImageIndex = 9,
                                    Tag = "column"
                                })
                            {
                                AddTreeNode(tbNode, colNode);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "����ͼ��Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                SetTreeNodeFont(tn, new Font("����", 9, FontStyle.Regular));

            }
            #endregion

            #region ѡ�и��ڵ�
            foreach (TreeNode node in this.treeView1.Nodes.Cast<TreeNode>().Where(node => node.Text == serverIp))
            {
                this.treeView1.SelectedNode = node;
                node.BackColor = Color.FromArgb(10, 36, 106);
                node.ForeColor = Color.White;
            }
            #endregion
        }

        #endregion

        #endregion

        #region ���ӷ�����ConnectServer

        public void DoConnect(object sender, DoWorkEventArgs e)
        {
            if (treeNodeRightClick != null)
            {
                var nodetext = treeNodeRightClick.Text;
                var dbset = DbConfig.GetSetting(nodetext);
                if (dbset == null)
                {
                    MessageBox.Show("�÷�������Ϣ�Ѿ������ڣ���ر����Ȼ�����ԡ�" , "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var server = dbset.Server;
                var dbtype = dbset.DbType;
                var dbName = dbset.DbName;
                var connectSimple = dbset.ConnectSimple;

                try
                {                    
                    ConnectServer(treeNodeRightClick, dbtype, server, dbName, connectSimple,e);
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show("�������ݿ�ʧ�ܣ���رպ����´����ԡ�\r\n"+ex.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            e.Result = -1;
        }
        #endregion

        public void ProgessChangedCon(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar1.Maximum = 1000;
            //this.progressBar1.Value = e.ProgressPercentage;
        }
        public void CompleteWorkCon(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mainfrm != null)
            {
                mainfrm.InvokeSendStatusMessage("���");
            }
        }

        public void ProgessChangedReg(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar1.Maximum = 1000;
            //this.progressBar1.Value = e.ProgressPercentage;
        }
        public void CompleteWorkReg(object sender, RunWorkerCompletedEventArgs e)
        {
            if (mainfrm != null)
            {
                mainfrm.InvokeSendStatusMessage("���");                
            }
        }
        
        //���ݷ������ڵ㴴�������ͱ�ڵ�
        private void ConnectServer(TreeNode serverNode, string dbtype, string ServerIp, string DbName, bool ConnectSimple, DoWorkEventArgs e)
        {
            var dbObject2 = DBOMaker.CreateDbObj(dbtype);

            mainfrm.InvokeSendStatusMessage("�������ݿ���...");            
            Application.DoEvents();
            
            var dbset = DbConfig.GetSetting(dbtype, ServerIp, DbName);
            dbObject2.DbConnectStr = dbset.ConnectStr;

            serverNode.Nodes.Clear();

            #region SQLSERVER ���ݿ���Ϣ
            if ((dbtype == "SQL2005") || (dbtype == "SQL2008"))
            {
                try
                {
                    if ((dbset.DbName == "master") || (dbset.DbName == ""))
                    {
                        var dblist = dbObject2.GetDBList();
                        if (dblist.Count > 0)
                        {
                            //mainfrm.toolComboBox_DB.Items.Clear();
                            foreach (var dbName in dblist)
                            {
                                var dbNode = new TreeNode(dbName) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                                AddTreeNode(serverNode, dbNode);
                                mainfrm.toolComboBox_DB.Items.Add(dbName);
                            }
                            if (mainfrm.toolComboBox_DB.Items.Count > 0)
                            {
                                mainfrm.toolComboBox_DB.SelectedIndex = 0;
                            }
                        }
                    }
                    else
                    {
                        var dbNode = new TreeNode(dbset.DbName) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                        AddTreeNode(serverNode, dbNode);
                       
                        mainfrm.BeginInvoke(new Action(() =>
                        {
                            mainfrm.toolComboBox_DB.Items.Clear();
                            mainfrm.toolComboBox_DB.Items.Add(dbset.DbName);
                        }));                      
                       

                        //������2
                        var dto = dbObject2.GetTabViews(dbset.DbName);
                        if (dto != null)
                        {                           
                            mainfrm.BeginInvoke(new Action(() =>
                            { mainfrm.toolComboBox_Table.Items.Clear(); }));
                            foreach (var tabname in from DataRow row in dto.Rows select row["name"].ToString())
                            {
                                mainfrm.BeginInvoke(new Action(() =>
                                {
                                    mainfrm.toolComboBox_Table.Items.Add(tabname);
                                }));
                            }

                            if (mainfrm.toolComboBox_Table.Items.Count > 0)
                            {
                                mainfrm.toolComboBox_Table.SelectedIndex = 0;
                            }
                        }
                    }

                }
                catch(System.Exception ex)
                {
                    // throw new Exception("��ȡ���ݿ�ʧ�ܣ�" + ex.Message);
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "���ӷ�����ʧ�ܣ�����������Ƿ��Ѿ���������������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            #endregion    

            #region Oracle ���ݿⵥ������
            if (dbtype == "Oracle")
            {
                TreeNode dbNode = new TreeNode(ServerIp) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                AddTreeNode(serverNode, dbNode);

                mainfrm.BeginInvoke(new Action(() =>
                {
                    mainfrm.toolComboBox_DB.Items.Add(ServerIp);
                    mainfrm.toolComboBox_DB.SelectedIndex = 0;
                })); 

                //������2
                DataTable dto = dbObject2.GetTabViews(ServerIp);
                if (dto != null)
                {
                    mainfrm.BeginInvoke(new Action(() =>
                    {
                        mainfrm.toolComboBox_Table.Items.Clear();
                        foreach (string tabname in from DataRow row in dto.Rows select row["name"].ToString())
                        {
                            mainfrm.toolComboBox_Table.Items.Add(tabname);
                        }
                        if (mainfrm.toolComboBox_Table.Items.Count > 0)
                        {
                            mainfrm.toolComboBox_Table.SelectedIndex = 0;
                        }
                    })); 
                    
                }
            }
            #endregion

            this.BeginInvoke(new Action(serverNode.ExpandAll));  

            #region ѭ�����ݿ⣬��������Ϣ
            foreach (TreeNode tn in serverNode.Nodes)
            {
                var dbName = tn.Text;
                mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "...");
                SetTreeNodeFont(tn, new Font("����", 9, FontStyle.Bold));
                var tabNode = new TreeNode("��") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "tableroot"};
                AddTreeNode(tn, tabNode);

                var viewNode = new TreeNode("��ͼ") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "viewroot"};
                AddTreeNode(tn, viewNode);

                var procNode = new TreeNode("�洢����") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "procroot"};
                AddTreeNode(tn, procNode);

                #region ��

                try
                {
                    var tabNames = dbObject2.GetTables(dbName);
                    if (tabNames.Count > 0)
                    {
                        var pi = 1;
                        foreach (var tabname in tabNames)//ѭ��ÿ����
                        {
                            if (bgwConnServer.CancellationPending)
                            {
                                e.Cancel = true;
                            }
                            else
                            {
                                bgwConnServer.ReportProgress(pi);
                            } 
                            pi++;

                            mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "�ı� " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 5, SelectedImageIndex = 5, Tag = "table"};
                            AddTreeNode(tabNode, tbNode);

                            #region  ���ֶ���Ϣ
                            if (!ConnectSimple)
                            {
                                var collist = dbObject2.GetColumnList(dbName, tabname);
                                if ((collist == null) || (collist.Count <= 0)) continue;
                                foreach (var col in collist)
                                {
                                    var columnName = col.ColumnName;
                                    var columnType = col.TypeName;
                                    var colNode = new TreeNode(columnName + "[" + columnType + "]")
                                    {
                                        ImageIndex = 7,
                                        SelectedImageIndex = 7,
                                        Tag = "column"
                                    };
                                    AddTreeNode(tbNode, colNode);
                                }
                            }
                            #endregion

                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "�ı���Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region	��ͼ

                try
                {
                    var dtv = dbObject2.GetVIEWs(dbName);
                    if (dtv != null)
                    {
                        var dRows = dtv.Select("", "name ASC");
                        foreach (var row in dRows)//ѭ��ÿ����
                        {
                            var tabname = row["name"].ToString();
                            mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "����ͼ " + tabname);                          
                            var tbNode = new TreeNode(tabname) {ImageIndex = 6, SelectedImageIndex = 6, Tag = "view"};
                            //viewNode.Nodes.Add(tbNode);
                            AddTreeNode(viewNode, tbNode);

                            #region  ���ֶ���Ϣ
                            if (!ConnectSimple)
                            {
                                var collist = dbObject2.GetColumnList(dbName, tabname);
                                if ((collist == null) || (collist.Count <= 0)) continue;
                                foreach (var col in collist)//ѭ��ÿ����
                                {
                                    var columnName = col.ColumnName;
                                    var columnType = col.TypeName;
                                    var colNode = new TreeNode(columnName + "[" + columnType + "]")
                                    {
                                        ImageIndex = 7,
                                        SelectedImageIndex = 7,
                                        Tag = "column"
                                    };
                                    //tbNode.Nodes.Add(colNode);
                                    AddTreeNode(tbNode, colNode);
                                }
                            }
                            #endregion

                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "����ͼ��Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region �洢����
                try
                {
                    var dtp = dbObject2.GetProcs(dbName);
                    if (dtp != null)
                    {
                        var dRows = dtp.Select("", "name ASC");
                        foreach (var row in dRows)//ѭ��ÿ����
                        {
                            var tabname = row["name"].ToString();                            
                            mainfrm.InvokeSendStatusMessage("�������ݿ� " + dbName + "�Ĵ洢���� " + tabname);    
                            var tbNode = new TreeNode(tabname) {ImageIndex = 8, SelectedImageIndex = 8, Tag = "proc"};
                            AddTreeNode(procNode, tbNode);

                            #region  ���ֶ���Ϣ
                            if (!ConnectSimple)
                            {
                                var collist = dbObject2.GetColumnList(dbName, tabname);
                                if ((collist != null) && (collist.Count > 0))
                                {
                                    foreach (var col in collist)//ѭ��ÿ����
                                    {
                                        var columnName = col.ColumnName;
                                        var columnType = col.TypeName;
                                        var colNode = new TreeNode(columnName + "[" + columnType + "]");
                                        colNode.ImageIndex = 9;
                                        colNode.SelectedImageIndex = 9;
                                        colNode.Tag = "column";
                                        //tbNode.Nodes.Add(colNode);
                                        AddTreeNode(tbNode, colNode);
                                    }
                                }
                            }
                            #endregion

                        }
                    }
                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "��ȡ���ݿ�" + dbName + "����ͼ��Ϣʧ�ܣ�" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                SetTreeNodeFont(tn, new Font("����", 9, FontStyle.Regular));
            }
            #endregion
                        
            #region ѡ�и��ڵ�
            foreach (TreeNode node in treeNodeServerList.Nodes)
            {
                if (node.Text == ServerIp)
                {
                    this.treeView1.SelectedNode = node;
                    //node.BackColor=Color.FromArgb(10,36,106);
                    node.ForeColor = Color.White;
                }
            }
            #endregion

            //mainfrm.InvokeSendStatusMessage("����";
        }

        #endregion

        #endregion

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var node = (TreeNode)e.Item;          
            if ((node.Tag.ToString() == "table") || (node.Tag.ToString() == "view") || (node.Tag.ToString() == "column"))
            {
                DoDragDrop(node, System.Windows.Forms.DragDropEffects.Copy);
            }
        }

        private void DbView_Layout(object sender, LayoutEventArgs e)
        {
            if (isLayoutCalled != false) return;
            isLayoutCalled = true;              
            //LTP.SplashScrForm.SplashScreen.CloseForm();
            this.Activate();
        }      
    }
}