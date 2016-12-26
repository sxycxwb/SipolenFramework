using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RDIFramework.Controls
{
    public enum RicherTextBoxToolStripGroups
    {
        SaveAndLoad = 0x1,
        FontNameAndSize = 0x2,
        BoldUnderlineItalic = 0x4,
        Alignment = 0x8,
        FontColor = 0x10,
        IndentationAndBullets = 0x20,
        Insert = 0x40,
        Zoom = 0x80
    }

    /// <summary>
    /// UcRichTextBoxEx
    /// 扩展文本控件
    /// 
    /// 
    /// 修改纪录
    ///     
    ///     2010-08-05 EricHu 创建扩展文本控件
    ///     
    /// <author>
    ///     <name>EricHu</name>
    ///     <QQ>406590790</QQ>
    ///     <Email>406590790@qq.com</Email>
    /// </author>
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(UcRichTextBoxEx), "Images.UcRichTextBoxEx.gif")]
    [Description("扩展文本控件")]
    public partial class UcRichTextBoxEx : UserControl
    {
        #region Settings
        private int indent = 10;
        [Category("Settings")]
        [Description("Value indicating the number of characters used for indentation")]
        public int INDENT
        {
            get { return indent; }
            set { indent = value; }
        }
        #endregion

        #region Properties for toolstrip items visibility
        [Category("Toolstip items visibility")]
        public bool GroupSaveAndLoadVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.SaveAndLoad); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.SaveAndLoad, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupFontNameAndSizeVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.FontNameAndSize); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.FontNameAndSize, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupBoldUnderlineItalicVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.BoldUnderlineItalic); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.BoldUnderlineItalic, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupAlignmentVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.Alignment); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.Alignment, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupFontColorVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.FontColor); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.FontColor, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupIndentationAndBulletsVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.IndentationAndBullets); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.IndentationAndBullets, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupInsertVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.Insert); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.Insert, value); }
        }
        [Category("Toolstip items visibility")]
        public bool GroupZoomVisible
        {
            get { return IsGroupVisible(RicherTextBoxToolStripGroups.Zoom); }
            set { HideToolstripItemsByGroup(RicherTextBoxToolStripGroups.Zoom, value); }
        }
        [Category("Toolstip items visibility")]
        public bool ToolStripVisible
        {
            get { return toolStrip1.Visible; }
            set { toolStrip1.Visible = value; }
        }
        [Category("Toolstip items visibility")]
        public bool FindReplaceVisible
        {
            get { return toolStripFindReplace.Visible; }
            set { toolStripFindReplace.Visible = value; }
        }

        [Category("Toolstrip single items visibility")]
        public bool SaveVisible
        {
            get { return tsbtnSave.Visible; }
            set { tsbtnSave.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool LoadVisible
        {
            get { return tsbtnOpen.Visible; }
            set { tsbtnOpen.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorSaveLoadVisible
        {
            get { return toolStripSeparator6.Visible; }
            set { toolStripSeparator6.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool FontFamilyVisible
        {
            get { return tscmbFont.Visible; }
            set { tscmbFont.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool FontSizeVisible
        {
            get { return tscmbFontSize.Visible; }
            set { tscmbFontSize.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool ChooseFontVisible
        {
            get { return tsbtnChooseFont.Visible; }
            set { tsbtnChooseFont.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorFontVisible
        {
            get { return toolStripSeparator1.Visible; }
            set { toolStripSeparator1.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool BoldVisible
        {
            get { return tsbtnBold.Visible; }
            set { tsbtnBold.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool ItalicVisible
        {
            get { return tsbtnItalic.Visible; }
            set { tsbtnItalic.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool UnderlineVisible
        {
            get { return tsbtnUnderline.Visible; }
            set { tsbtnUnderline.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorBoldUnderlineItalicVisible
        {
            get { return toolStripSeparator2.Visible; }
            set { toolStripSeparator2.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool AlignLeftVisible
        {
            get { return tsbtnAlignLeft.Visible; }
            set { tsbtnAlignLeft.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool AlignRightVisible
        {
            get { return tsbtnAlignRight.Visible; }
            set { tsbtnAlignRight.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool AlignCenterVisible
        {
            get { return tsbtnAlignCenter.Visible; }
            set { tsbtnAlignCenter.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorAlignVisible
        {
            get { return toolStripSeparator3.Visible; }
            set { toolStripSeparator3.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool FontColorVisible
        {
            get { return tsbtnFontColor.Visible; }
            set { tsbtnFontColor.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool WordWrapVisible
        {
            get { return tsbtnWordWrap.Visible; }
            set { tsbtnWordWrap.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorFontColorVisible
        {
            get { return toolStripSeparator4.Visible; }
            set { toolStripSeparator4.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool IndentVisible
        {
            get { return tsbtnIndent.Visible; }
            set { tsbtnIndent.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool OutdentVisible
        {
            get { return tsbtnOutdent.Visible; }
            set { tsbtnOutdent.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool BulletsVisible
        {
            get { return tsbtnBullets.Visible; }
            set { tsbtnBullets.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorIndentAndBulletsVisible
        {
            get { return toolStripSeparator5.Visible; }
            set { toolStripSeparator5.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool InsertPictureVisible
        {
            get { return tsbtnInsertPicture.Visible; }
            set { tsbtnInsertPicture.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool SeparatorInsertVisible
        {
            get { return toolStripSeparator4.Visible; }
            set { toolStripSeparator4.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool ZoomInVisible
        {
            get { return tsbtnZoomIn.Visible; }
            set { tsbtnZoomIn.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool ZoomOutVisible
        {
            get { return tsbtnZoomOut.Visible; }
            set { tsbtnZoomOut.Visible = value; }
        }
        [Category("Toolstrip single items visibility")]
        public bool ZoomFactorTextVisible
        {
            get { return tstxtZoomFactor.Visible; }
            set { tstxtZoomFactor.Visible = value; }
        }

        #endregion

        #region data properties
        [Category("Document data")]
        [Description("RicherTextBox content in plain text")]
        [Browsable(true)]
        public override string Text
        {
            get { return rtbDocument.Text; }
            set { rtbDocument.Text = value; }
        }
        [Category("Document data")]
        [Description("RicherTextBox content in rich-text format")]
        public string Rtf
        {
            get { return rtbDocument.Rtf; }
            set { try { rtbDocument.Rtf = value; } catch (ArgumentException) { rtbDocument.Text = value; } }
        }

        #endregion

        /// <summary>
        /// 增加按钮的单击事件
        /// </summary>
        [Category("用户控件属性"), Description("增加按钮的单击事件")]
        public event EventHandler OnRichTextBoxTextChanged;

        public UcRichTextBoxEx()
        {
            InitializeComponent();
        }

        private void UcRichTextBoxEx_Load(object sender, EventArgs e)
        {
            // load system fonts
            foreach (FontFamily family in FontFamily.Families)
            {
                tscmbFont.Items.Add(family.Name);
            }
            tscmbFont.SelectedItem = "Microsoft Sans Serif";

            tscmbFontSize.SelectedItem = "9";

            tstxtZoomFactor.Text = Convert.ToString(rtbDocument.ZoomFactor * 100);
            tsbtnWordWrap.Checked = rtbDocument.WordWrap;
        }

        private void tsbtnBIU_Click(object sender, EventArgs e)
        {
            // bold, italic, underline
            try
            {
                if (!(rtbDocument.SelectionFont == null))
                {
                    Font currentFont = rtbDocument.SelectionFont;
                    FontStyle newFontStyle = rtbDocument.SelectionFont.Style;
                     string txt =  string.Empty;
                     if (sender as ToolStripButton == null)
                     {
                         txt = (sender as System.Windows.Forms.ToolStripMenuItem).Name;
                     }
                     else
                     {
                         txt = (sender as ToolStripButton).Name;
                     }
                    if (txt.ToLower().IndexOf("bold") >= 0)
                        newFontStyle = rtbDocument.SelectionFont.Style ^ FontStyle.Bold;
                    else if (txt.ToLower().IndexOf("italic") >= 0)
                        newFontStyle = rtbDocument.SelectionFont.Style ^ FontStyle.Italic;
                    else if (txt.ToLower().IndexOf("underline") >= 0)
                        newFontStyle = rtbDocument.SelectionFont.Style ^ FontStyle.Underline;

                    rtbDocument.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void rtbDocument_SelectionChanged(object sender, EventArgs e)
        {
            if (rtbDocument.SelectionFont != null)
            {
                tsbtnBold.Checked = rtbDocument.SelectionFont.Bold;
                tsbtnItalic.Checked = rtbDocument.SelectionFont.Italic;
                tsbtnUnderline.Checked = rtbDocument.SelectionFont.Underline;

                boldToolStripMenuItem.Checked = rtbDocument.SelectionFont.Bold;
                italicToolStripMenuItem.Checked = rtbDocument.SelectionFont.Italic;
                underlineToolStripMenuItem.Checked = rtbDocument.SelectionFont.Underline;

                switch (rtbDocument.SelectionAlignment)
                {
                    case HorizontalAlignment.Left:
                        tsbtnAlignLeft.Checked = true;
                        tsbtnAlignCenter.Checked = false;
                        tsbtnAlignRight.Checked = false;

                        leftToolStripMenuItem.Checked = true;
                        centerToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = false;
                        break;

                    case HorizontalAlignment.Center:
                        tsbtnAlignLeft.Checked = false;
                        tsbtnAlignCenter.Checked = true;
                        tsbtnAlignRight.Checked = false;

                        leftToolStripMenuItem.Checked = false;
                        centerToolStripMenuItem.Checked = true;
                        rightToolStripMenuItem.Checked = false;
                        break;

                    case HorizontalAlignment.Right:
                        tsbtnAlignLeft.Checked = false;
                        tsbtnAlignCenter.Checked = false;
                        tsbtnAlignRight.Checked = true;

                        leftToolStripMenuItem.Checked = false;
                        centerToolStripMenuItem.Checked = false;
                        rightToolStripMenuItem.Checked = true;
                        break;
                }

                tsbtnBullets.Checked = rtbDocument.SelectionBullet;
                bulletsToolStripMenuItem.Checked = rtbDocument.SelectionBullet;

                tscmbFont.SelectedItem = rtbDocument.SelectionFont.FontFamily.Name;
                tscmbFontSize.SelectedItem = rtbDocument.SelectionFont.Size.ToString();
            }
        }

        private void tsbtnAlignment_Click(object sender, EventArgs e)
        {
            // alignment: left, center, right
            try
            {
                string txt = (sender as ToolStripButton).Name;
                if (txt.IndexOf("Left") >= 0)
                {
                    rtbDocument.SelectionAlignment = HorizontalAlignment.Left;
                    tsbtnAlignLeft.Checked = true;
                    tsbtnAlignCenter.Checked = false;
                    tsbtnAlignRight.Checked = false;
                }
                else if (txt.IndexOf("Center") >= 0)
                {
                    rtbDocument.SelectionAlignment = HorizontalAlignment.Center;
                    tsbtnAlignLeft.Checked = false;
                    tsbtnAlignCenter.Checked = true;
                    tsbtnAlignRight.Checked = false;
                }
                else if (txt.IndexOf("Right") >= 0)
                {
                    rtbDocument.SelectionAlignment = HorizontalAlignment.Right;
                    tsbtnAlignLeft.Checked = false;
                    tsbtnAlignCenter.Checked = false;
                    tsbtnAlignRight.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void tsbtnFontColor_Click(object sender, EventArgs e)
        {
            // font color
            try
            {
                using (ColorDialog dlg = new ColorDialog())
                {
                    dlg.Color = rtbDocument.SelectionColor;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        rtbDocument.SelectionColor = dlg.Color;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void tsbtnBulletsAndNumbering_Click(object sender, EventArgs e)
        {
            // bullets, indentation
            try
            {
                string name = string.Empty;
                if (sender as ToolStripButton == null)
                {
                    name = (sender as System.Windows.Forms.ToolStripMenuItem).Name;
                }
                else
                {
                    name = (sender as ToolStripButton).Name;
                }              
                if (name.ToLower().IndexOf("bullet") >= 0)
                    rtbDocument.SelectionBullet = tsbtnBullets.Checked || bulletsToolStripMenuItem.Checked;
                else if (name.ToLower().IndexOf("indent") >= 0)
                    rtbDocument.SelectionIndent += INDENT;
                else if (name.ToLower().IndexOf("outdent") >= 0)
                    rtbDocument.SelectionIndent -= INDENT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void tscmbFontSize_Click(object sender, EventArgs e)
        {
            // font size
            try
            {
                if (!(rtbDocument.SelectionFont == null))
                {
                    Font currentFont = rtbDocument.SelectionFont;
                    float newSize = Convert.ToSingle(tscmbFontSize.SelectedItem.ToString());
                    rtbDocument.SelectionFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void tscmbFontSize_TextChanged(object sender, EventArgs e)
        {
            // font size custom
            try
            {
                if (!(rtbDocument.SelectionFont == null))
                {
                    Font currentFont = rtbDocument.SelectionFont;
                    float newSize = Convert.ToSingle(tscmbFontSize.Text);
                    rtbDocument.SelectionFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void tscmbFont_Click(object sender, EventArgs e)
        {
            // font
            try
            {
                if (!(rtbDocument.SelectionFont == null))
                {
                    Font currentFont = rtbDocument.SelectionFont;
                    FontFamily newFamily = new FontFamily(tscmbFont.SelectedItem.ToString());
                    rtbDocument.SelectionFont = new Font(newFamily, currentFont.Size, currentFont.Style);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void btnChooseFont_Click(object sender, EventArgs e)
        {
            using (FontDialog dlg = new FontDialog())
            {
                if (rtbDocument.SelectionFont != null) dlg.Font = rtbDocument.SelectionFont;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    rtbDocument.SelectionFont = dlg.Font;
                }
            }
        }

        private void tsbtnInsertPicture_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Insert picture";
                dlg.DefaultExt = "jpg";
                dlg.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|All files|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string strImagePath = dlg.FileName;
                        Image img = Image.FromFile(strImagePath);
                        Clipboard.SetDataObject(img);
                        DataFormats.Format df;
                        df = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (this.rtbDocument.CanPaste(df))
                        {
                            this.rtbDocument.Paste(df);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Unable to insert image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Rich text format|*.rtf";
                dlg.FilterIndex = 0;
                dlg.OverwritePrompt = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        rtbDocument.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    }
                    catch (IOException exc)
                    {
                        MessageBox.Show("Error writing file: \n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException exc_a)
                    {
                        MessageBox.Show("Error writing file: \n" + exc_a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Rich text format|*.rtf";
                dlg.FilterIndex = 0;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        rtbDocument.LoadFile(dlg.FileName, RichTextBoxStreamType.RichText);
                    }
                    catch (IOException exc)
                    {
                        MessageBox.Show("Error reading file: \n" + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException exc_a)
                    {
                        MessageBox.Show("Error reading file: \n" + exc_a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void tsbtnZoomIn_Click(object sender, EventArgs e)
        {
            if (rtbDocument.ZoomFactor < 64.0f - 0.20f)
            {
                rtbDocument.ZoomFactor += 0.20f;
                tstxtZoomFactor.Text = String.Format("{0:F0}", rtbDocument.ZoomFactor * 100);
            }
        }

        private void tsbtnZoomOut_Click(object sender, EventArgs e)
        {
            if (rtbDocument.ZoomFactor > 0.16f + 0.20f)
            {
                rtbDocument.ZoomFactor -= 0.20f;
                tstxtZoomFactor.Text = String.Format("{0:F0}", rtbDocument.ZoomFactor * 100);
            }
        }

        private void tstxtZoomFactor_Leave(object sender, EventArgs e)
        {
            try
            {
                rtbDocument.ZoomFactor = Convert.ToSingle(tstxtZoomFactor.Text) / 100;
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tstxtZoomFactor.Focus();
                tstxtZoomFactor.SelectAll();
            }
            catch (OverflowException)
            {
                MessageBox.Show("Enter valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tstxtZoomFactor.Focus();
                tstxtZoomFactor.SelectAll();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Zoom factor should be between 20% and 6400%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tstxtZoomFactor.Focus();
                tstxtZoomFactor.SelectAll();
            }
        }

        private void tsbtnWordWrap_Click(object sender, EventArgs e)
        {
            rtbDocument.WordWrap = tsbtnWordWrap.Checked;
        }

        #region Changing visibility of toolstrip items

        public void HideToolstripItemsByGroup(RicherTextBoxToolStripGroups group, bool visible)
        {
            if ((group & RicherTextBoxToolStripGroups.SaveAndLoad) != 0)
            {
                tsbtnSave.Visible = visible;
                tsbtnOpen.Visible = visible;
                toolStripSeparator6.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.FontNameAndSize) != 0)
            {
                tscmbFont.Visible = visible;
                tscmbFontSize.Visible = visible;
                tsbtnChooseFont.Visible = visible;
                toolStripSeparator1.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.BoldUnderlineItalic) != 0)
            {
                tsbtnBold.Visible = visible;
                tsbtnItalic.Visible = visible;
                tsbtnUnderline.Visible = visible;
                toolStripSeparator2.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.Alignment) != 0)
            {
                tsbtnAlignLeft.Visible = visible;
                tsbtnAlignRight.Visible = visible;
                tsbtnAlignCenter.Visible = visible;
                toolStripSeparator3.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.FontColor) != 0)
            {
                tsbtnFontColor.Visible = visible;
                tsbtnWordWrap.Visible = visible;
                toolStripSeparator4.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.IndentationAndBullets) != 0)
            {
                tsbtnIndent.Visible = visible;
                tsbtnOutdent.Visible = visible;
                tsbtnBullets.Visible = visible;
                toolStripSeparator5.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.Insert) != 0)
            {
                tsbtnInsertPicture.Visible = visible;
                toolStripSeparator4.Visible = visible;
            }
            if ((group & RicherTextBoxToolStripGroups.Zoom) != 0)
            {
                tsbtnZoomOut.Visible = visible;
                tsbtnZoomIn.Visible = visible;
                tstxtZoomFactor.Visible = visible;
            }
        }

        public bool IsGroupVisible(RicherTextBoxToolStripGroups group)
        {
            switch (group)
            {
                case RicherTextBoxToolStripGroups.SaveAndLoad:
                    return tsbtnSave.Visible && tsbtnOpen.Visible && toolStripSeparator6.Visible;

                case RicherTextBoxToolStripGroups.FontNameAndSize:
                    return tscmbFont.Visible && tscmbFontSize.Visible && tsbtnChooseFont.Visible && toolStripSeparator1.Visible;

                case RicherTextBoxToolStripGroups.BoldUnderlineItalic:
                    return tsbtnBold.Visible && tsbtnItalic.Visible && tsbtnUnderline.Visible && toolStripSeparator2.Visible;

                case RicherTextBoxToolStripGroups.Alignment:
                    return tsbtnAlignLeft.Visible && tsbtnAlignRight.Visible && tsbtnAlignCenter.Visible && toolStripSeparator3.Visible;

                case RicherTextBoxToolStripGroups.FontColor:
                    return tsbtnFontColor.Visible && tsbtnWordWrap.Visible && toolStripSeparator4.Visible;

                case RicherTextBoxToolStripGroups.IndentationAndBullets:
                    return tsbtnIndent.Visible && tsbtnOutdent.Visible && tsbtnBullets.Visible && toolStripSeparator5.Visible;

                case RicherTextBoxToolStripGroups.Insert:
                    return tsbtnInsertPicture.Visible && toolStripSeparator4.Visible;

                case RicherTextBoxToolStripGroups.Zoom:
                    return tsbtnZoomOut.Visible && tsbtnZoomIn.Visible && tstxtZoomFactor.Visible;

                default:
                    return false;
            }
        }
        #endregion

        #region Public methods for accessing the functionality of the RicherTextBox

        public void SetFontFamily(FontFamily family)
        {
            if (family != null)
            {
                tscmbFont.SelectedItem = family.Name;
            }
        }

        public void SetFontSize(float newSize)
        {
            tscmbFontSize.Text = newSize.ToString();
        }

        public void ToggleBold()
        {
            tsbtnBold.PerformClick();
        }

        public void ToggleItalic()
        {
            tsbtnItalic.PerformClick();
        }

        public void ToggleUnderline()
        {
            tsbtnUnderline.PerformClick();
        }

        public void SetAlign(HorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case HorizontalAlignment.Center:
                    tsbtnAlignCenter.PerformClick();
                    break;

                case HorizontalAlignment.Left:
                    tsbtnAlignLeft.PerformClick();
                    break;

                case HorizontalAlignment.Right:
                    tsbtnAlignRight.PerformClick();
                    break;
            }
        }

        public void Indent()
        {
            tsbtnIndent.PerformClick();
        }

        public void Outdent()
        {
            tsbtnOutdent.PerformClick();
        }

        public void ToggleBullets()
        {
            tsbtnBullets.PerformClick();
        }

        public void ZoomIn()
        {
            tsbtnZoomIn.PerformClick();
        }

        public void ZoomOut()
        {
            tsbtnZoomOut.PerformClick();
        }

        public void ZoomTo(float factor)
        {
            rtbDocument.ZoomFactor = factor;
        }

        public void SetWordWrap(bool activated)
        {
            rtbDocument.WordWrap = activated;           
        }

        /// <summary>
        /// 选择文本范围
        /// </summary>
        /// <param name="start">开始位置</param>
        /// <param name="length">选择的长度</param>
        public void Select(int start, int length)
        {
            rtbDocument.Select(start, length); 
        }

        /// <summary>
        /// 选择所有文本
        /// </summary>
        public void SelectAll()
        {
            rtbDocument.SelectAll();
        }

        public Color SelectionColor
        {
            set { rtbDocument.SelectionColor = value; }
            get { return rtbDocument.SelectionColor; }
        }

        public int SelectionStart
        {
            set { rtbDocument.SelectionStart = value; }
            get { return rtbDocument.SelectionStart; }
        }

        public int SelectionLength
        {
            set { rtbDocument.SelectionLength = value; }
            get { return rtbDocument.SelectionLength; }
        }

        #endregion

        #region Context menu handlers
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbDocument.Redo();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnAlignLeft.PerformClick();

            leftToolStripMenuItem.Checked = true;
            centerToolStripMenuItem.Checked = false;
            rightToolStripMenuItem.Checked = false;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnAlignCenter.PerformClick();

            leftToolStripMenuItem.Checked = false;
            centerToolStripMenuItem.Checked = true;
            rightToolStripMenuItem.Checked = false;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnAlignRight.PerformClick();

            leftToolStripMenuItem.Checked = false;
            centerToolStripMenuItem.Checked = false;
            rightToolStripMenuItem.Checked = true;
        }        
        #endregion

        private void tsbtnFind_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm();
            findForm.RtbInstance = this.rtbDocument;
            findForm.InitialText = this.tstxtSearchText.Text;
            findForm.Show();
        }

        private void tsbtnReplace_Click(object sender, EventArgs e)
        {
            ReplaceForm replaceForm = new ReplaceForm();
            replaceForm.RtbInstance = this.rtbDocument;
            replaceForm.InitialText = this.tstxtSearchText.Text;
            replaceForm.Show();
        }

        private void rtbDocument_TextChanged(object sender, EventArgs e)
        {
            if (OnRichTextBoxTextChanged != null)
            {
                OnRichTextBoxTextChanged(this, null);
            }
        }
    }
}
