using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;

namespace RDIFramework.CodeMaker
{

    public partial class StartPageForm : Form
    {
        MainForm mainfrm = null;
        private Thread workThread;
        private string tempOpmlfile = Application.StartupPath + @"\tempopml.xml"; //��ʱRSS
        private string tempRssfile = Application.StartupPath + @"\temprss.xml"; //��ʱRSS    
        //cnblogs rss:http://feed.cnblogs.com/blog/u/76228/rss
        //csdn:http://blog.csdn.net/chinahuyong/rss/list
        private string RssPath = "http://feed.cnblogs.com/blog/u/76228/rss";	//rss��ַ
        string cmcfgfile = Application.StartupPath + @"\Config\cmcfg.ini";

        IniFileHelper cfgfile;
        delegate void SetTextEventHandler(string text);
        delegate void SetListEventHandler();


        public StartPageForm(Form mdiParentForm, string strRsspath)
        {
            InitializeComponent();           
            mainfrm = (MainForm)mdiParentForm;
            RssPath = strRsspath;
        }

        private void StartPageForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.workThread = new Thread(new ThreadStart(LoadRss));
                this.workThread.Start();
            }
            catch(Exception ex)
            {
                LogHelper.WriteException(ex);
            }
        }

        #region LoadRss����Rss

        private void LoadRss()
        {
            try
            {
                CreatListview();
                LoadRss(RssPath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("��ȡ��վ��Ϣʧ�ܣ��������������Ƿ��������Ժ����ԡ�" + ex.Message);
                LogHelper.WriteException(ex);
            }
        }
        private void LoadRss(string RssPath)
        {
            if (!IsHasLoaded())
            {
                SetText("���ڻ�ȡ��վ������Ϣ�����Ժ�");
                this.LoadXml2Coach(RssPath, tempRssfile);
                LoadedRssMarker();
            }

            SetText("���ڶ�ȡ������Ϣ��");
            SetListText();

            SetText("���");
        }
        #endregion

        #region ��������
        private void CreatListview()
        {
            //�����б�
            this.listView1.Columns.Clear();
            this.listView1.Items.Clear();
           
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
            this.listView1.BackColor = Color.FromArgb(235, 241, 255);

            listView1.Columns.Add("", 300, HorizontalAlignment.Left);//�ļ�������
            listView1.Columns.Add("", 200, HorizontalAlignment.Left);//���·���ʱ����
           
        }

        private void SetText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (this.lblTip.InvokeRequired)
            {
                var d = new SetTextEventHandler(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblTip.Text = text;
            }
        }
        private void SetListText()
        {
            if (this.listView1.InvokeRequired)
            {
                var d = new SetListEventHandler(SetListText);
                this.Invoke(d, null);
            }
            else
            {
                LoadItem();
            }
        }
        
        /// <summary>
        /// �Ƿ��Ѿ����ع�RSS����
        /// </summary>
        /// <returns></returns>
        private bool IsHasLoaded()
        {
            if (File.Exists(cmcfgfile))
            {
                cfgfile = new IniFileHelper(cmcfgfile);
                var Contents = cfgfile.ReadString("updaterss", "today", string.Empty);
                return Contents == DateTime.Today.ToString("yyyyMMdd");
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ��ǽ����Ѿ����ع�RSS����
        /// </summary>
        private void LoadedRssMarker()
        {
            cfgfile.ReadString("updaterss", "today", "");
        }

        #endregion

        #region LoadXml2Coach��ȡRSS���ڱ���
        
        /// <summary>
        /// ��ȡRSS���ڱ���
        /// </summary>        
        private void LoadXml2Coach(string url, string tempfile)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(url);
                doc.Save(tempfile);
            }
            catch//(System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //return;
            }
        }
        #endregion

        #region LoadItem����RSS��Ŀ

        /// <summary>
        /// ����RSS��Ŀ
        /// </summary>
        private void LoadItem()
        {
            var doc = new XmlDocument();
            doc.Load(this.tempRssfile);
            XmlNodeList nodeList;
            nodeList = doc.SelectNodes("/rss/channel/item");
            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

            this.listView1.Items.Clear();
            try
            {
                foreach (XmlNode objNode in nodeList)//ѭ��ÿ��item��
                {
                    if (objNode.HasChildNodes != true) continue;
                    var title = "";
                    var link = "";
                    var creator = "";
                    var author = "";
                    var pubDate = DateTime.Now.ToString();
                    var description = string.Empty;
                    var objItemsChild = objNode.ChildNodes;
                    foreach (XmlNode objNodeChild in objItemsChild)//ÿ��item���µĽڵ�ֵ
                    {
                        switch (objNodeChild.Name)
                        {
                            case "title":
                                title =  PageUtility.ClearHTMLTags(objNodeChild.InnerText);
                                break;
                            case "link":
                                link = objNodeChild.InnerText;
                                break;
                            case "dc:creator":
                                creator = objNodeChild.InnerText;
                                break;
                            case "author":
                                author = objNodeChild.InnerText;
                                break;
                            case "pubDate":
                                pubDate = objNodeChild.InnerText;
                                pubDate = DateTime.Parse(pubDate).ToString();
                                break;
                            case "description":
                                if (listView1.Items.Count < 1)
                                {
                                    if (!string.IsNullOrEmpty(objNodeChild.InnerText))
                                    {
                                        description = PageUtility.ClearHTMLTags(objNodeChild.InnerText);
                                        if (!string.IsNullOrEmpty(description) && description.Length > 400)
                                        {
                                            description = description.Substring(0, 400) + "...";
                                        }
                                    }
                                }
                                break;

                        }
                    }                        

                    ListViewItem item1 = null;
                    item1 = new ListViewItem(title, 0);
                    if (listView1.Items.Count < 1)
                    {
                        item1 = new ListViewItem(title, 1) {ForeColor = ColorTranslator.FromHtml("#458FCE")};
                        item1.Font = new Font("����", item1.Font.Size, FontStyle.Bold);
                        pnlFirstRss.Visible = true;
                        pnlFirstRss.Dock = DockStyle.Top;
                        lblFirstTitle.Text = title;
                        lblFirstDescript.Text = "����" + description;
                    }                        
                    item1.SubItems.Add(pubDate);
                    item1.SubItems.Add(link);
                    listView1.Items.AddRange(new ListViewItem[] { item1 });
                }


                listView1.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                //listView1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lblTip.Visible = false;
                pictureBox1.Visible = false;
                listView1.Visible = true;
                splitContainerRss.Dock = DockStyle.Fill;
                if (listView1.Items.Count < 0)
                {
                    splitContainerRss.Panel1Collapsed = true;
                }
                else
                {
                   
                    splitContainerRss.Visible = true;
                }
            }
            catch//(Exception ex) 
            {
                //MessageBox.Show(ex.ToString()); 
            }
        }

        #endregion

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count <= 0) return;
            var selstr = this.listView1.SelectedItems[0].Text;
            var link = this.listView1.SelectedItems[0].SubItems[2].Text;
            //��ʼҳ
            var page = new Crownwood.Magic.Controls.TabPage();
            page.Title = selstr;
            page.Control = new IEView(mainfrm, link);
            //MainForm mainfrm = (MainForm)Application.OpenForms["MainForm"];
            mainfrm.tabControlMain.TabPages.Add(page);
            mainfrm.tabControlMain.SelectedTab = page;
        }
       
        #region ���ò����¼�

        private void lblAddServer_Click(object sender, EventArgs e)
        {
            var dbview = new DbView(mainfrm);
            dbview.bgwRegServer.RunWorkerAsync();
        }

        private void lblDBObjectBrowser_Click(object sender, EventArgs e)
        {
            mainfrm.AddSinglePage(new DbBrowser(), "������Դ������");
        }

        private void lblDBScript_Click(object sender, EventArgs e)
        {
            var longservername = PageUtility.GetDbViewSelServer();
            if (longservername == "")
            {
                MessageBox.Show("�޿������ݿ����ӣ������������ݿ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var ce = new FrmDbToScript(longservername);
            ce.ShowDialog(this);
        }

        private void lblWord_Click(object sender, EventArgs e)
        {
            var longservername = PageUtility.GetDbViewSelServer();
            if (longservername == "")
            {
                MessageBox.Show("û�п��õ����ݿ����ӣ������������ݿ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dbtoword = new FrmDbToWord(longservername);
            dbtoword.Show();
        }

        private void lblNewPro_Click(object sender, EventArgs e)
        {
            //NewProject newpro = new NewProject();
            //newpro.ShowDialog(mainfrm);
        }

        private void lblCodeMaker_Click(object sender, EventArgs e)
        {
            var longservername = PageUtility.GetDbViewSelServer();
            if (longservername != "") return;
            MessageBox.Show("û�п��õ����ݿ����ӣ������������ݿ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //mainfrm.AddSinglePage(new CodeMaker(), "��������");
        }

        private void lblCodeExport_Click(object sender, EventArgs e)
        {
            var longservername = PageUtility.GetDbViewSelServer();
            if (longservername == "")
            {
                MessageBox.Show("û�п��õ����ݿ����ӣ������������ݿ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var batchCodeMaker = new FrmBatchCodeMaker(longservername);
            batchCodeMaker.ShowDialog(this);
        }

        private void lblProjectProperty_Click(object sender, EventArgs e)
        {
            new ProjectProperty().ShowDialog();
        }
        #endregion     
    }
}