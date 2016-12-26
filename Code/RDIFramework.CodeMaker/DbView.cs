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
    //数据库管理器
    public partial class DbView : Form
    {
        #region 系统变量

        MainForm mainfrm;
        LoginForm logo = new LoginForm();
        LoginOra logoOra = new LoginOra();
        TreeNode treeNodeRightClick;//右键菜单单击的节点
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

        #region 初始化服务器树

        private void LoadServer()
        {
            this.treeView1.Nodes.Clear();
            treeNodeServerList = new TreeNode("服务器") {Tag = "serverlist", ImageIndex = 0, SelectedImageIndex = 0};
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

        #region 公共方法

        // 增加TabPage
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
        // 增加TabPage
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

        // 创建新的唯一窗体页（不允许重复的）
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
            if (!showed)//不存在
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
        /// 异步线程中为树增加节点
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
        /// 异步线程中设置节点字体
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
        /// 得到选中的服务器名字信息
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

        //根据服务器配置得到服务器节点字符串
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

        #region 工具栏
        private void tsbtnAddServer_Click(object sender, EventArgs e)
        {
            if (bgwRegServer.IsBusy)
            {
                MessageBox.Show("程序正忙，请耐心等待", "运行提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("正在执行后台操作，请稍等！");
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
                MessageBox.Show("操作失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region treeview 鼠标点击
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
                    mainfrm.InvokeSendStatusMessage("正在检索数据库.....");
                    dbBrowserFrm.SetListView(this);
                }

                /*
                CodeMaker codemakerfrm = (CodeMaker)Application.OpenForms["CodeMaker"];
                if (codemakerfrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("正在检索数据库.....");
                    codemakerfrm.SetListView(this);
                }
                CodeMakerM codemakermfrm = (CodeMakerM)Application.OpenForms["CodeMakerM"];
                if (codemakermfrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("正在检索数据库.....");
                    codemakermfrm.SetListView(this);
                }

                CodeTemplate codetempfrm = (CodeTemplate)Application.OpenForms["CodeTemplate"];
                if (codetempfrm != null)
                {
                    mainfrm.InvokeSendStatusMessage("正在检索数据库.....");
                    codetempfrm.SetListView(this);
                }

                 */
                #region  选中某类型节点
                switch (nodeType)
                {
                    case "serverlist":
                        {
                            mainfrm.toolComboBox_DB.Items.Clear();
                            mainfrm.toolComboBox_Table.Items.Clear();
                            mainfrm.toolComboBox_DB.Visible = false;
                            mainfrm.toolComboBox_Table.Visible = false;
                            //mainfrm.生成ToolStripMenuItem.Visible = false;
                        }
                        break;
                    case "server":
                        {
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = false;
                            //mainfrm.生成ToolStripMenuItem.Visible = false;
                        }
                        break;
                    case "db":
                        {
                            #region
                            mainfrm.toolComboBox_DB.Visible = true;
                            mainfrm.toolComboBox_Table.Visible = true;
                            mainfrm.toolComboBox_DB.Text = tNodeSelected.Parent.Text;
                            ////mainfrm.生成ToolStripMenuItem.Visible = false;
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
                            //mainfrm.生成ToolStripMenuItem.Visible = false;
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
                            //mainfrm.生成ToolStripMenuItem.Visible = true;
                            //mainfrm.对象定义ToolStripMenuItem.Visible = false;
                            //mainfrm.toolStripMenuItem17.Visible = false;
                            //mainfrm.生成存储过程ToolStripMenuItem.Visible = true;
                            //mainfrm.生成数据脚本ToolStripMenuItem.Visible = true;

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
                            //mainfrm.生成ToolStripMenuItem.Visible = true;
                            //mainfrm.对象定义ToolStripMenuItem.Visible = true;
                            //mainfrm.toolStripMenuItem17.Visible = true;
                            //mainfrm.生成存储过程ToolStripMenuItem.Visible = false;
                            //mainfrm.生成数据脚本ToolStripMenuItem.Visible = false;

                            #endregion
                        }
                        break;
                    case "proc":
                        {
                            //mainfrm.生成ToolStripMenuItem.Visible = true;
                            //mainfrm.对象定义ToolStripMenuItem.Visible = true;
                            //mainfrm.toolStripMenuItem17.Visible = true;
                            //mainfrm.生成存储过程ToolStripMenuItem.Visible = false;
                            //mainfrm.生成数据脚本ToolStripMenuItem.Visible = false;
                        }
                        break;
                    default:
                        {
                            //mainfrm.生成ToolStripMenuItem.Visible = false;
                        }
                        break;
                }
                #endregion

                if (mainfrm != null) mainfrm.InvokeSendStatusMessage("就绪");
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

        #region 创建treeview 右键菜单
        ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));

        private void CreatMenu(string nodeType)
        {
            this.DbTreeContextMenu.Items.Clear();
            switch (nodeType)
            {
                case "serverlist":
                    {
                        #region
                        var 添加服务器Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("toolbtn_AddServer.Image"))),
                            Name = "添加服务器Item",
                            Text = "添加服务器"
                        };
                        //添加服务器Item.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                        //添加服务器Item.ImageTransparentColor = System.Drawing.Color.Magenta;
                        添加服务器Item.Click += 添加服务器Item_Click;

                        var 备份服务器配置Item = new ToolStripMenuItem
                        {
                            Name = "备份服务器配置Item", 
                            Text = "备份服务器配置"
                        };
                        备份服务器配置Item.Click += 备份服务器配置Item_Click;

                        var 导入服务器配置Item = new ToolStripMenuItem
                        {
                            Name = "导入服务器配置Item", 
                            Text = "导入服务器配置"
                        };
                        导入服务器配置Item.Click += 导入服务器配置Item_Click;

                        var 刷新Item = new ToolStripMenuItem
                        {
                            Name = "刷新Item", 
                            Text = "刷新"
                        };
                        刷新Item.Click += 刷新Item_Click;

                        var 属性Item = new ToolStripMenuItem
                        {
                            Name = "属性Item", 
                            Text = "属性"
                        };
                        属性Item.Click += 属性Item_Click;

                        DbTreeContextMenu.Items.AddRange(
                            new System.Windows.Forms.ToolStripItem[] { 
                                添加服务器Item, 
                                备份服务器配置Item,
                                导入服务器配置Item,
                                刷新Item                                
                            }
                            );
                        #endregion
                    }
                    break;
                case "server":
                    {
                        #region
                        var 连接服务器Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("toolbtn_Connect.Image"))),
                            Name = "连接服务器Item",
                            Text = "连接服务器"
                        };
                        //连接服务器Item.ImageTransparentColor = System.Drawing.Color.Magenta;
                        连接服务器Item.Click += 连接服务器Item_Click;

                        var 注销服务器Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("toolbtn_unConnect.Image"))),
                            Name = "注销服务器Item",
                            Text = "注销服务器"
                        };
                        注销服务器Item.Click += 注销服务器Item_Click;

                        var 属性Item = new ToolStripMenuItem {Name = "属性Item", Text = "刷新"};
                        属性Item.Click += server属性Item_Click;

                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                连接服务器Item, 
                                注销服务器Item,
                                属性Item
                            }
                            );
                        #endregion
                    }
                    break;
                case "db":
                    {
                        #region
                        var 浏览数据库Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("数据库管理器ToolStripMenuItem"))),
                            Name = "浏览数据库Item",
                            Text = "浏览数据库"
                        };
                        浏览数据库Item.Click += 浏览数据库Item_Click;


                        var 新建查询Item = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("查询分析器ToolStripMenuItem"))),
                            Name = "新建查询Item",
                            Text = "新建查询"
                        };
                        新建查询Item.Click += 新建查询Item_Click;
                        var Separator1 = new ToolStripSeparator {Name = "Separator1"};

                        var 生成存储过程dbItem = new ToolStripMenuItem {Name = "生成存储过程Item", Text = "生成存储过程"};
                        生成存储过程dbItem.Click += 生成存储过程dbItem_Click;

                        var 生成数据脚本dbItem = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("dB脚本生成器ToolStripMenuItem.Image"))),
                            Name = "生成数据脚本Item",
                            Text = "生成数据脚本"
                        };
                        生成数据脚本dbItem.Click += 生成数据脚本dbItem_Click;

                        #region  导出文件

                        var 导出文件dbItem = new ToolStripMenuItem {Name = "导出文件Item", Text = "导出文件"};
                        var 存储过程dbItem = new ToolStripMenuItem {Name = "存储过程Item", Text = "存储过程"};
                        存储过程dbItem.Click += 存储过程dbItem_Click;

                        var 数据脚本dbItem = new ToolStripMenuItem {Name = "数据脚本Item", Text = "数据脚本"};
                        数据脚本dbItem.Click += 数据脚本dbItem_Click;
                       
                        #endregion

                        导出文件dbItem.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                存储过程dbItem, 
                                数据脚本dbItem                                                            
                            }
                            );

                        var 刷新dbItem = new ToolStripMenuItem {Name = "刷新Item", Text = "刷新"};
                        刷新dbItem.Click += 刷新dbItem_Click;


                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                浏览数据库Item,
                                新建查询Item,
                                Separator1,
                                生成存储过程dbItem,
                                生成数据脚本dbItem,
                                导出文件dbItem,                              
                                刷新dbItem
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

                        var 生成SQL语句Item = new ToolStripMenuItem {Name = "生成SQL语句Item", Text = "生成SQL语句到"};

                        #region 生成SQL语句到

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

                        生成SQL语句Item.DropDownItems.AddRange(
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

                        var 查看表数据tabItem = new ToolStripMenuItem {Name = "查看表数据tabItem", Text = "浏览表数据"};
                        查看表数据tabItem.Click += 查看表数据tabItem_Click;

                        var 生成数据脚本tabItem = new ToolStripMenuItem
                        {
                            Image = ((System.Drawing.Image) (resources.GetObject("dB脚本生成器ToolStripMenuItem"))),
                            Name = "生成数据脚本tabItem",
                            Text = "生成数据脚本"
                        };
                        生成数据脚本tabItem.Click += 生成数据脚本tabItem_Click;

                        var 生成存储过程tabItem = new ToolStripMenuItem {Name = "生成存储过程tabItem", Text = "生成存储过程"};
                        生成存储过程tabItem.Click += 生成存储过程tabItem_Click;

                        #region 导出文件Item
                        var 导出文件tabItem = new ToolStripMenuItem {Name = "导出文件tabItem", Text = "导出文件"};

                        var 存储过程tabItem = new ToolStripMenuItem {Name = "存储过程tabItem", Text = "存储过程"};
                        存储过程tabItem.Click += 存储过程tabItem_Click;

                        var 数据脚本tabItem = new ToolStripMenuItem {Name = "数据脚本tabItem", Text = "数据脚本"};
                        数据脚本tabItem.Click += 数据脚本tabItem_Click;

                        /*
                        ToolStripMenuItem 表数据tabItem = new ToolStripMenuItem();
                        表数据tabItem.Name = "表数据tabItem";
                        表数据tabItem.Text = "表数据";
                        表数据tabItem.Click += new System.EventHandler(表数据tabItem_Click);
                        */
                        导出文件tabItem.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                存储过程tabItem, 
                                数据脚本tabItem                             
                            }
                            );
                        #endregion

                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] {                                 
                                生成SQL语句Item,
                                查看表数据tabItem,
                                生成数据脚本tabItem,
                                生成存储过程tabItem,                               
                                导出文件tabItem                              
                        });

                        var separator1 = new ToolStripSeparator {Name = "Separator1"};
                        var  数据实体tabItem = new ToolStripMenuItem {Name = "生成数据对象tabItem", Text = "生成数据对象"};
                        数据实体tabItem.Click += 生成数据对象tabItem_Click;
                        DbTreeContextMenu.Items.AddRange(new ToolStripItem[] { separator1,数据实体tabItem});

                        var WebUItabItem = new ToolStripMenuItem { Name = "生成WebUI界面tabItem", Text = "生成WebUI界面" };
                        WebUItabItem.Click += 生成WebUI界面tabItem_Click;
                        DbTreeContextMenu.Items.AddRange(new ToolStripItem[] { WebUItabItem });

                        var MvcUItabItem = new ToolStripMenuItem { Name = "生成MvcUI界面tabItem", Text = "生成MvcUI界面" };
                        MvcUItabItem.Click += 生成MvcUI界面tabItem_Click;
                        DbTreeContextMenu.Items.AddRange(new ToolStripItem[] { MvcUItabItem});
                        #endregion
                    }
                    break;
                case "view":
                    {
                        #region
                        var 脚本Item = new ToolStripMenuItem {Name = "脚本Item", Text = "脚本"};

                        var selecTviewItem = new ToolStripMenuItem {Name = "SELECTItem", Text = "SELECT(&S)"};
                        selecTviewItem.Click += SELECTviewItem_Click;

                        var alterViewItem = new ToolStripMenuItem {Name = "AlterViewItem", Text = "ALTER(&U)"};
                        alterViewItem.Click += AlterViewItem_Click;

                        var dropViewItem = new ToolStripMenuItem {Name = "DropViewItem", Text = "DROP(&D)"};
                        dropViewItem.Click += DropViewItem_Click;


                        脚本Item.DropDownItems.AddRange(
                            new ToolStripItem[] { 
                                selecTviewItem, 
                                alterViewItem,
                                dropViewItem                               
                            }
                            );

                        var 对象定义Item = new ToolStripMenuItem {Name = "对象定义Item", Text = "对象定义"};
                        对象定义Item.Click += 对象定义Item_Click;

                        var 查看表数据tabItem = new ToolStripMenuItem {Name = "查看表数据tabItem", Text = "浏览表数据"};
                        查看表数据tabItem.Click += 查看表数据tabItem_Click;

                        /*
                        ToolStripSeparator Separatorv1 = new ToolStripSeparator();
                        Separatorv1.Name = "Separatorv1";
                        */
                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                脚本Item, 
                                对象定义Item,
                                查看表数据tabItem
                            }
                            );
                        #endregion
                    }
                    break;
                case "proc":
                    {
                        #region
                        var 脚本Item = new ToolStripMenuItem {Name = "脚本Item", Text = "脚本"};

                        var procAlterItem = new ToolStripMenuItem {Name = "ProcAlterItem", Text = "ALTER(&U)"};
                        procAlterItem.Click += ProcAlterItem_Click;

                        var procDropItem = new ToolStripMenuItem {Name = "ProcDropItem", Text = "DROP(&D)"};
                        procDropItem.Click += ProcDropItem_Click;

                        var execItem = new ToolStripMenuItem {Name = "EXECItem", Text = "EXEC(&I)"};
                        //EXECItem.Click += new System.EventHandler(EXECItem_Click);
                        脚本Item.DropDownItems.AddRange(
                           new ToolStripItem[] {                                 
                                procAlterItem,
                                procDropItem                                
                            }
                           );

                        var 对象定义Item = new ToolStripMenuItem {Name = "对象定义Item", Text = "对象定义"};
                        对象定义Item.Click += 对象定义Item_Click;


                        DbTreeContextMenu.Items.AddRange(
                            new ToolStripItem[] { 
                                脚本Item, 
                                对象定义Item                                
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

        #region  treeview 右键菜单事件

        #region serverlist_click

        private void 添加服务器Item_Click(object sender, EventArgs e)
        {
            bgwRegServer.RunWorkerAsync();
        }

        private void 备份服务器配置Item_Click(object sender, EventArgs e)
        {
            var dlgSqlServer = new SaveFileDialog
            {
                Title = "保存服务器配置",
                Filter = "DB Serverlist(*.config)|*.config|All files (*.*)|*.*"
            };
            var dlgResult = dlgSqlServer.ShowDialog(this);
            if (dlgResult != DialogResult.OK) return;
            var filename = dlgSqlServer.FileName;
            var ds = DbConfig.GetSettingDs();
            ds.WriteXml(filename);
        }

        private void 导入服务器配置Item_Click(object sender, EventArgs e)
        {
            var dlgSqlField = new OpenFileDialog();
            dlgSqlField.Title = "选择服务器配置文件";
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
                    MessageBox.Show("读取配置文件失败！", "提示");
                }
            }
        }
        private void 刷新Item_Click(object sender, EventArgs e)
        {
            LoadServer();
        }
        private void 属性Item_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("刷新Item");
        }
        #endregion

        #region server_click

        private void 连接服务器Item_Click(object sender, EventArgs e)
        {
            bgwConnServer.RunWorkerAsync();
        }

        private void 注销服务器Item_Click(object sender, EventArgs e)
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
                MessageBox.Show("注销服务器失败，请关闭后重新打开再试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        //刷新服务器
        private void server属性Item_Click(object sender, EventArgs e)
        {
            bgwConnServer.RunWorkerAsync();
        }
        #endregion

        #region db_click
        private void 浏览数据库Item_Click(object sender, EventArgs e)
        {
          PageUtility.AddSinglePage(new DbBrowser(), "摘要",mainfrm);
        }

        private void 新建查询Item_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            //在combox选中当前库
            var dbName = treeNodeRightClick.Text;
            var server = treeNodeRightClick.Parent.Text;
            var title = server + "." + dbName + "查询.sql";
            var mainfrm = (MainForm)Application.OpenForms["MainForm"];
            PageUtility.AddTabPage(title, new DbQuery(mainfrm, ""), mainfrm);
            //AddTabPage(title, new DbQuery(mainfrm, ""), mainfrm);
            mainfrm.toolComboBox_DB.Text = dbName;
        }

        private void 生成存储过程dbItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            mainfrm.InvokeSendStatusMessage("正在生成数据库:[" +dbName + "]所有表的存储过程,请稍后...");
            var dsb = ObjHelper.CreatDsb(longServerName);                
            var strSql = dsb.GetPROCCode(dbName);
            var title = dbName + "存储过程.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
            mainfrm.InvokeSendStatusMessage("就绪");
        }

        private void 生成数据脚本dbItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            var dts = new FrmDbToScript(longServerName, dbName);
            dts.ShowDialog(this);
        }

        private void 存储过程dbItem_Click(object sender, EventArgs e)
        {
            var dlgSqlServer = new SaveFileDialog
            {
                Title = "保存当前脚本",
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
            sw.Flush(); //从缓冲区写入基础流（文件）
            sw.Close();
            MessageBox.Show("脚本生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 数据脚本dbItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Text;
            var dbName = treeNodeRightClick.Text;
            var dts = new FrmDbToScript(longServerName, dbName);
            dts.ShowDialog(this);
        }

        //代码生成器
        private void 代码生成dbItem_Click(object sender, EventArgs e)
        {
            var longServerName = treeNodeRightClick.Parent.Text;
            //mainfrm.AddSinglePage(new CodeMaker(), "代码生成器");
        }     

        private void 刷新dbItem_Click(object sender, EventArgs e)
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
            mainfrm.InvokeSendStatusMessage("加载数据库" + dbName + "...");
            var tabNode = new TreeNode("表") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "tableroot"};
            var viewNode = new TreeNode("视图") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "viewroot"};
            var procNode = new TreeNode("存储过程") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "procroot"};
            tn.Nodes.Add(tabNode);
            tn.Nodes.Add(viewNode);
            tn.Nodes.Add(procNode);

            #region 表

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

                        //加字段信息
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
                MessageBox.Show(this, "获取数据库" + dbName + "的表信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion

            #region	视图

            try
            {
                var dtv = dbObject2.GetVIEWs(dbName);
                if (dtv != null)
                {
                    var dRows = dtv.Select("", "name ASC");
                    foreach (var row in dRows) //循环每个表
                    {
                        var tabname = row["name"].ToString();
                        var tbNode = new TreeNode(tabname) {ImageIndex = 6, SelectedImageIndex = 6, Tag = "view"};
                        viewNode.Nodes.Add(tbNode);

                        //加字段信息
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
                MessageBox.Show(this, "获取数据库" + dbName + "的视图信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            #endregion

            #region 存储过程
            try
            {
                var dtp = dbObject2.GetProcs(dbName);
                if (dtp != null)
                {
                    var dRows = dtp.Select("", "name ASC");
                    foreach (var row in dRows) //循环每个表
                    {
                        var tabname = row["name"].ToString();
                        var tbNode = new TreeNode(tabname) {ImageIndex = 8, SelectedImageIndex = 8, Tag = "proc"};
                        procNode.Nodes.Add(tbNode);

                        //加字段参数信息
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
                MessageBox.Show(this, "获取数据库" + dbName + "的视图信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            #endregion

            mainfrm.InvokeSendStatusMessage("就绪");
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
            var title = tabname + "查询.sql";
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
            var title = tabname + "查询.sql";
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
            var title = tabname + "查询.sql";
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
            var title = tabname + "查询.sql";
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
            var title = name + "删除.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void 查看表数据tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            var dbObj = ObjHelper.CreatDbObj(longServerName);
            var dl = new DataList(dbObj, dbName, tabname);
            PageUtility.AddTabPage(tabname, dl, mainfrm);
        }

        private void 生成存储过程tabItem_Click(object sender, EventArgs e)
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
            var title = tabname + "存储过程.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }

        private void 生成数据对象tabItem_Click(object sender, EventArgs e)
        {
            //含定义、代码、DLL、文档等
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;             
            var doForm = new DataObjectForm {TableName = tabname, DBName = dbName, CurrentDbViewForm = this};
            PageUtility.AddTabPage(tabname, doForm, mainfrm);
        }

        private void 生成WebUI界面tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            IDbObject tempDbObject = ObjHelper.CreatDbObj(longServerName);
            var doForm = new MakerWebUI { TableName = tabname, DBName = dbName, CurrentDbViewForm = this, idbObj = tempDbObject };
            PageUtility.AddTabPage(tabname, doForm, mainfrm);
        }

        private void 生成MvcUI界面tabItem_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var tabname = treeNodeRightClick.Text;
            IDbObject tempDbObject = ObjHelper.CreatDbObj(longServerName);
            var doForm = new MakerMvcUI{ TableName = tabname, DBName = dbName, CurrentDbViewForm = this, idbObj = tempDbObject };
            PageUtility.AddTabPage(tabname, doForm, mainfrm);
        }

        
        private void 生成数据脚本tabItem_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(this, "如果该表数据量较大，直接生成将需要比较长的时间，\r\n确实需要直接生成吗？\r\n(建议采用脚本生成器生成。)", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                    var title = tabname + "脚本.sql";
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

        //导出文件
        private void 存储过程tabItem_Click(object sender, EventArgs e)
        {
            var dlgSqlServer = new SaveFileDialog
            {
                Title = "保存当前脚本",
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
                sw.Flush();//从缓冲区写入基础流（文件）
                sw.Close();
                MessageBox.Show("脚本生成成功！", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //导出文件
        private void 数据脚本tabItem_Click(object sender, EventArgs e)
        {
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var dts = new FrmDbToScript(longServerName, dbName);
            dts.ShowDialog(this);
        }

        //导出文件
        private void 表数据tabItem_Click(object sender, EventArgs e)
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

        //代码生成器
        private void 代码生成Item_Click(object sender, EventArgs e)
        {
            //string longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            //if (longServerName == "")
            //    return;
            //mainfrm.AddSinglePage(new CodeMaker(), "代码生成器");
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
            var title = viewName + "查询.sql";
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

            //替换CREATE VIEW 为ALTER VIEW
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
            var title = name + "修改.sql";
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
            var title = name + "删除.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        }


        private void 对象定义Item_Click(object sender, EventArgs e)
        {
            if (treeNodeRightClick == null) return;
            var longServerName = treeNodeRightClick.Parent.Parent.Parent.Text;
            var dbName = treeNodeRightClick.Parent.Parent.Text;
            var name = treeNodeRightClick.Text;
            var dbobj = ObjHelper.CreatDbObj(longServerName);
            var str = dbobj.GetObjectInfo(dbName, name);
            var title = name + "定义.sql";
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

            //替换CREATE VIEW 为ALTER VIEW
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
            var title = name + "修改.sql";
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
            var title = name + "删除.sql";
            AddTabPage(title, new DbQuery(mainfrm, strSql));
        } 
        #endregion

        #region 注册服务器RegServer

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
                MessageBox.Show("连接服务器失败，请关闭后重新打开再试。\r\n" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            e.Result = -1;           
        }
        #endregion
       
        #region 登录服务器LoginServer

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
                    mainfrm.InvokeSendStatusMessage("正在验证和连接服务器.....");
                    CreatTree("SqlServer", ServerIp, constr, dbName,e);                 

                }
                catch (System.Exception ex)
                {
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                mainfrm.InvokeSendStatusMessage("正在验证和连接服务器.....");
                CreatTree("Oracle", serverIp, constr, dbname, e);
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteException(ex);
                MessageBox.Show(this, ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region 创建库服务器树节点 CreatTree

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
            mainfrm.InvokeSendStatusMessage("加载数据库树...");
            Application.DoEvents();
            
            dbObject.DbConnectStr = constr;

            #region 绑定SQLSERVER 数据库信息
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

                        //下拉框2
                        var dto = dbObject.GetTabViews(dbName);
                        if (dto != null)
                        {
                            mainfrm.toolComboBox_Table.Items.Clear();
                            foreach (DataRow row in dto.Rows)//循环每个表
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
                    throw new Exception("获取数据库失败：" + ex.Message);
                }
            }

            #endregion

            #region Oracle 数据库单独处理
            if (dbtype == "Oracle")
            {
                string dbname = serverIp;
                TreeNode dbNode = new TreeNode(dbname) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                AddTreeNode(serverNode, dbNode);
                mainfrm.toolComboBox_DB.Items.Add(dbname);

                //下拉框2
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
            //todo:MySql数据库单独处理
            //todo:DB2数据库单独处理....

            serverNode.ExpandAll();

            #region  循环数据库，建立表信息
            
            foreach (TreeNode tn in serverNode.Nodes)
            {
                var dbName = tn.Text;
                mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "...");
                SetTreeNodeFont(tn, new Font("宋体", 9, FontStyle.Bold));
                var tabNode = new TreeNode("表") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "tableroot"};
                AddTreeNode(tn, tabNode);

                var viewNode = new TreeNode("视图") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "viewroot"};
                AddTreeNode(tn, viewNode);

                var procNode = new TreeNode("存储过程") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "procroot"};
                AddTreeNode(tn, procNode);

                #region 表

                try
                {
                    var tabNames = dbObject.GetTables(dbName);
                    if (tabNames.Count > 0)
                    {
                        var pi = 1;
                        foreach (var tabname in tabNames)//循环每个表
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

                            mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "的表 " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 5, SelectedImageIndex = 5, Tag = "table"};
                            AddTreeNode(tabNode, tbNode);

                            #region  加字段信息

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
                    MessageBox.Show(this, "获取数据库" + dbName + "的表信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion

                #region	视图

                try
                {
                    var dtv = dbObject.GetVIEWs(dbName);
                    if (dtv != null)
                    {
                        var dRows = dtv.Select("", "name ASC");
                        foreach (var row in dRows)//循环每个表
                        {
                            var tabname = row["name"].ToString();                            
                            mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "的视图 " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 6, SelectedImageIndex = 6, Tag = "view"};
                            AddTreeNode(viewNode, tbNode);

                            #region  加字段信息

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
                    MessageBox.Show(this, "获取数据库" + dbName + "的视图信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region 存储过程
                try
                {
                    var dtp = dbObject.GetProcs(dbName);
                    if (dtp != null)
                    {
                        var dRows = dtp.Select("", "name ASC");
                        foreach (var tabname in dRows.Select(row => row["name"].ToString()))
                        {
                            mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "的存储过程 " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 8, SelectedImageIndex = 8, Tag = "proc"};
                            AddTreeNode(procNode, tbNode);

                            #region  加字段信息
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
                    MessageBox.Show(this, "获取数据库" + dbName + "的视图信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                SetTreeNodeFont(tn, new Font("宋体", 9, FontStyle.Regular));

            }
            #endregion

            #region 选中根节点
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

        #region 连接服务器ConnectServer

        public void DoConnect(object sender, DoWorkEventArgs e)
        {
            if (treeNodeRightClick != null)
            {
                var nodetext = treeNodeRightClick.Text;
                var dbset = DbConfig.GetSetting(nodetext);
                if (dbset == null)
                {
                    MessageBox.Show("该服务器信息已经不存在，请关闭软件然后重试。" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("加载数据库失败，请关闭后重新打开再试。\r\n"+ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                mainfrm.InvokeSendStatusMessage("完成");
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
                mainfrm.InvokeSendStatusMessage("完成");                
            }
        }
        
        //根据服务器节点创建下面库和表节点
        private void ConnectServer(TreeNode serverNode, string dbtype, string ServerIp, string DbName, bool ConnectSimple, DoWorkEventArgs e)
        {
            var dbObject2 = DBOMaker.CreateDbObj(dbtype);

            mainfrm.InvokeSendStatusMessage("加载数据库树...");            
            Application.DoEvents();
            
            var dbset = DbConfig.GetSetting(dbtype, ServerIp, DbName);
            dbObject2.DbConnectStr = dbset.ConnectStr;

            serverNode.Nodes.Clear();

            #region SQLSERVER 数据库信息
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
                       

                        //下拉框2
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
                    // throw new Exception("获取数据库失败：" + ex.Message);
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "连接服务器失败！请检查服务器是否已经启动或工作正常！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            #endregion    

            #region Oracle 数据库单独处理
            if (dbtype == "Oracle")
            {
                TreeNode dbNode = new TreeNode(ServerIp) {ImageIndex = 2, SelectedImageIndex = 2, Tag = "db"};
                AddTreeNode(serverNode, dbNode);

                mainfrm.BeginInvoke(new Action(() =>
                {
                    mainfrm.toolComboBox_DB.Items.Add(ServerIp);
                    mainfrm.toolComboBox_DB.SelectedIndex = 0;
                })); 

                //下拉框2
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

            #region 循环数据库，建立表信息
            foreach (TreeNode tn in serverNode.Nodes)
            {
                var dbName = tn.Text;
                mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "...");
                SetTreeNodeFont(tn, new Font("宋体", 9, FontStyle.Bold));
                var tabNode = new TreeNode("表") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "tableroot"};
                AddTreeNode(tn, tabNode);

                var viewNode = new TreeNode("视图") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "viewroot"};
                AddTreeNode(tn, viewNode);

                var procNode = new TreeNode("存储过程") {ImageIndex = 3, SelectedImageIndex = 4, Tag = "procroot"};
                AddTreeNode(tn, procNode);

                #region 表

                try
                {
                    var tabNames = dbObject2.GetTables(dbName);
                    if (tabNames.Count > 0)
                    {
                        var pi = 1;
                        foreach (var tabname in tabNames)//循环每个表
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

                            mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "的表 " + tabname);
                            var tbNode = new TreeNode(tabname) {ImageIndex = 5, SelectedImageIndex = 5, Tag = "table"};
                            AddTreeNode(tabNode, tbNode);

                            #region  加字段信息
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
                    MessageBox.Show(this, "获取数据库" + dbName + "的表信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region	视图

                try
                {
                    var dtv = dbObject2.GetVIEWs(dbName);
                    if (dtv != null)
                    {
                        var dRows = dtv.Select("", "name ASC");
                        foreach (var row in dRows)//循环每个表
                        {
                            var tabname = row["name"].ToString();
                            mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "的视图 " + tabname);                          
                            var tbNode = new TreeNode(tabname) {ImageIndex = 6, SelectedImageIndex = 6, Tag = "view"};
                            //viewNode.Nodes.Add(tbNode);
                            AddTreeNode(viewNode, tbNode);

                            #region  加字段信息
                            if (!ConnectSimple)
                            {
                                var collist = dbObject2.GetColumnList(dbName, tabname);
                                if ((collist == null) || (collist.Count <= 0)) continue;
                                foreach (var col in collist)//循环每个列
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
                    MessageBox.Show(this, "获取数据库" + dbName + "的视图信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                #region 存储过程
                try
                {
                    var dtp = dbObject2.GetProcs(dbName);
                    if (dtp != null)
                    {
                        var dRows = dtp.Select("", "name ASC");
                        foreach (var row in dRows)//循环每个表
                        {
                            var tabname = row["name"].ToString();                            
                            mainfrm.InvokeSendStatusMessage("加载数据库 " + dbName + "的存储过程 " + tabname);    
                            var tbNode = new TreeNode(tabname) {ImageIndex = 8, SelectedImageIndex = 8, Tag = "proc"};
                            AddTreeNode(procNode, tbNode);

                            #region  加字段信息
                            if (!ConnectSimple)
                            {
                                var collist = dbObject2.GetColumnList(dbName, tabname);
                                if ((collist != null) && (collist.Count > 0))
                                {
                                    foreach (var col in collist)//循环每个列
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
                    MessageBox.Show(this, "获取数据库" + dbName + "的视图信息失败：" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                SetTreeNodeFont(tn, new Font("宋体", 9, FontStyle.Regular));
            }
            #endregion
                        
            #region 选中根节点
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

            //mainfrm.InvokeSendStatusMessage("就绪";
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