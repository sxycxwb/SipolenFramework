/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-13 10:24:11
 ******************************************************************************/
#region  版权信息
/*---------------------------------------------------------------------*
// Copyright (C) 2009 http://www.cnblogs.com/huyong
// 版权所有。 
// 项目  名称：《Winform通用控件库》
// 文  件  名： UcHtmlEditor.cs
// 类  全  名： RDIFramework.Controls.UcHtmlEditor 
// 描      述:  Html编辑器控件
// 创建  时间： 2009-07-02
// 创建人信息： [**** 姓名:XuWangBin QQ:406590790 E-Mail:406590790@qq.com *****]
*----------------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.IO;

namespace RDIFramework.Controls
{
    /// <summary>
    /// Html编辑器控件
    /// 修改纪录:    
    ///     2010-01-11 XuWangBin 对于"字条大小"下拉列表框，使用VS自带的Combox控件。
    ///     2010-01-02 XuWangBin 新增"线条的插入"。
    ///     2009-07-02 XuWangBin 创建Html编辑器控件。
    /// <author>
    ///     <name>XuWangBin</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    /// </summary>
    [Description("Html编辑器控件"), ToolboxItem(true)]
    [ToolboxBitmap(typeof(UcHtmlEditor), "Images.UcHtmlEditor.png")]
    public partial class UcHtmlEditor : UserControl
    {
        #region 构造函数:UcHtmlEditor()
        public UcHtmlEditor()
        {
            dataUpdate = 0; 
            InitializeComponent();
            InitializeControls();             
        }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 设置工具栏的可见性
        /// </summary>
        public bool ToolBarVisible
        {
            get { return toolStripToolBar.Visible; }
            set { this.toolStripToolBar.Visible = value; }
        }

        /// <summary>
        /// 获取和设置当前的Html文本
        /// </summary>
        public string Html
        {
            get
            {
                return webBrowserBody.DocumentText;
            }
            set
            {
                if (webBrowserBody.Document != null && webBrowserBody.Document.Body != null)
                {
                    webBrowserBody.Document.Body.InnerHtml = value.Replace("\r\n", "<br>");
                }
            }
        }

        /// <summary>
        /// 获取集成了图片资源的HTML BODY 的 MailMessage
        /// </summary>
        public MailMessage XMailMessage
        {
            get
            {
                MailMessage msg = new MailMessage();
                msg.IsBodyHtml = true;

                string html = webBrowserBody.DocumentText;

                HtmlElementCollection images = webBrowserBody.Document.Images;
                if (images.Count > 0)
                {
                    List<string> imgs = new List<string>();

                    foreach (HtmlElement image in images)
                    {
                        string imagePath = image.GetAttribute("src");
                        if (imagePath.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
                        {
                            imgs.Add(imagePath);
                        }
                    }

                    for (int i = 0; i < imgs.Count; i++)
                    {
                        string cid = string.Format("em_image_{0:00}", i);
                        string imagePath = Path.GetFullPath(imgs[i].Replace("%20", " ").Replace("file:///", ""));
                        Attachment attach = new Attachment(imagePath);
                        attach.ContentId = cid;
                        attach.Name = Path.GetFileNameWithoutExtension(imagePath);
                        msg.Attachments.Add(attach);

                        html.Replace(imgs[i], string.Format("cid:{0}", cid));
                    }
                }

                msg.Body = html;

                return msg;
            }
        }

        /// <summary>
        /// 获取插入的图片名称集合
        /// </summary>
        public string[] Images
        {
            get
            {
                List<string> images = new List<string>();

                foreach (HtmlElement element in webBrowserBody.Document.Images)
                {
                    string image = element.GetAttribute("src");
                    if (!images.Contains(image))
                    {
                        images.Add(image);
                    }
                }

                return images.ToArray();
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 控件初始化
        /// </summary>
        private void InitializeControls()
        {
            BeginUpdate();

            //工具栏
            foreach (FontFamily family in FontFamily.Families)
            {
                cboFontName.Items.Add(family.Name);
            }

            cboFontSize.Items.AddRange(FontSize.All.ToArray());

            //浏览器
            webBrowserBody.DocumentText = string.Empty;
            webBrowserBody.Document.Click += new HtmlElementEventHandler(webBrowserBody_DocumentClick);
            webBrowserBody.Document.Focusing += new HtmlElementEventHandler(webBrowserBody_DocumentFocusing);
            webBrowserBody.Document.ExecCommand("EditMode", false, null);
            webBrowserBody.Document.ExecCommand("LiveResize", false, null);

            EndUpdate();
        }

        /// <summary>
        /// 刷新按钮状态
        /// </summary>
        private void RefreshToolBar()
        {
            BeginUpdate();

            try
            {
                mshtml.IHTMLDocument2 document = (mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument;
                
                cboFontName.Text = document.queryCommandValue("FontName").ToString();
                cboFontSize.SelectedItem = FontSize.Find((int)document.queryCommandValue("FontSize"));
                btnBold.Checked = document.queryCommandState("Bold");
                btnItalic.Checked = document.queryCommandState("Italic");
                btnUnderline.Checked = document.queryCommandState("Underline");
                
                btnNumbers.Checked = document.queryCommandState("InsertOrderedList");
                btnBullets.Checked = document.queryCommandState("InsertUnorderedList");
                
                btnLeft.Checked = document.queryCommandState("JustifyLeft");
                btnCenter.Checked = document.queryCommandState("JustifyCenter");
                btnRight.Checked = document.queryCommandState("JustifyRight");
                btnFull.Checked = document.queryCommandState("JustifyFull");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                EndUpdate();
            }
        }

        #endregion

        #region 更新相关

        private int dataUpdate;
        private bool Updating
        {
            get
            {
                return dataUpdate != 0;
            }
        }

        private void BeginUpdate()
        {
            ++dataUpdate;
        }
        private void EndUpdate()
        {
            --dataUpdate;
        }

        #endregion

        #region 工具栏

        private void cboFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("FontName", false, cboFontName.Text);
        }
        private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            int size = (cboFontSize.SelectedItem == null) ? 1 : (cboFontSize.SelectedItem as FontSize).Value;
            webBrowserBody.Document.ExecCommand("FontSize", false, size);
        }
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Bold", false, null);
            RefreshToolBar();
        }
        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Italic", false, null);
            RefreshToolBar();
        }
        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Underline", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            int fontcolor = (int)((mshtml.IHTMLDocument2)webBrowserBody.Document.DomDocument).queryCommandValue("ForeColor");

            ColorDialog dialog = new ColorDialog();
            dialog.Color = Color.FromArgb(0xff, fontcolor & 0xff, (fontcolor >> 8) & 0xff, (fontcolor >> 16) & 0xff);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string color = dialog.Color.Name;
                if (!dialog.Color.IsNamedColor)
                {
                    color = "#" + color.Remove(0, 2);
                }

                webBrowserBody.Document.ExecCommand("ForeColor", false, color);
            }
            RefreshToolBar();
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertOrderedList", false, null);
            RefreshToolBar();
        }
        private void btnBullets_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertUnorderedList", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonOutdent_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Outdent", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonIndent_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("Indent", false, null);
            RefreshToolBar();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyLeft", false, null);
            RefreshToolBar();
        }
        private void btnCenter_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyCenter", false, null);
            RefreshToolBar();
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyRight", false, null);
            RefreshToolBar();
        }
        private void btnFull_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("JustifyFull", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertHorizontalRule", false, null);
            RefreshToolBar();
        }
        private void toolStripButtonHyperlink_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("CreateLink", true, null);
            RefreshToolBar();
        }
        private void toolStripButtonPicture_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("InsertImage", true, null);
            RefreshToolBar();
        }

        private void toolStripButtonUnDo_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("UnDo", false, null);
            RefreshToolBar();
        }

        private void toolStripButtonRedo_Click(object sender, EventArgs e)
        {
            if (Updating)
            {
                return;
            }

            webBrowserBody.Document.ExecCommand("ReDo", false, null);
            RefreshToolBar();
        }

        #endregion

        #region 浏览器

        private void webBrowserBody_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void webBrowserBody_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.IsInputKey)
            {
                return;
            }

            RefreshToolBar();
        }

        private void webBrowserBody_DocumentClick(object sender, HtmlElementEventArgs e)
        {
            RefreshToolBar();
        }

        private void webBrowserBody_DocumentFocusing(object sender, HtmlElementEventArgs e)
        {
            RefreshToolBar();
        }

        #endregion

        #region 字体大小转换

        private class FontSize
        {
            private static List<FontSize> allFontSize = null;
            public static List<FontSize> All
            {
                get
                {
                    if (allFontSize == null)
                    {
                        allFontSize = new List<FontSize>();
                        allFontSize.Add(new FontSize(8, 1));
                        allFontSize.Add(new FontSize(10, 2));
                        allFontSize.Add(new FontSize(12, 3));
                        allFontSize.Add(new FontSize(14, 4));
                        allFontSize.Add(new FontSize(18, 5));
                        allFontSize.Add(new FontSize(24, 6));
                        allFontSize.Add(new FontSize(36, 7));
                    }

                    return allFontSize;
                }
            }

            public static FontSize Find(int value)
            {
                if (value < 1)
                {
                    return All[0];
                }

                if (value > 7)
                {
                    return All[6];
                }

                return All[value - 1];
            }

            private FontSize(int display, int value)
            {
                displaySize = display;
                valueSize = value;
            }

            private int valueSize;
            public int Value
            {
                get
                {
                    return valueSize;
                }
            }

            private int displaySize;
            public int Display
            {
                get
                {
                    return displaySize;
                }
            }

            public override string ToString()
            {
                return displaySize.ToString();
            }
        }

        #endregion

        #region 下拉框

        private class ToolStripComboBoxEx : ToolStripComboBox
        {
            public override Size GetPreferredSize(Size constrainingSize)
            {
                Size size = base.GetPreferredSize(constrainingSize);
                size.Width = Math.Max(Width, 0x20);
                return size;
            }
        }

        #endregion
    }
}
