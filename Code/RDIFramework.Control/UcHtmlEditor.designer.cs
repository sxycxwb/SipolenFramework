/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:31
 ******************************************************************************/
/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-13 10:24:12
 ******************************************************************************/
namespace RDIFramework.Controls
{
    partial class UcHtmlEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcHtmlEditor));
            this.toolStripToolBar = new System.Windows.Forms.ToolStrip();
            this.cboFontName = new System.Windows.Forms.ToolStripComboBox();
            this.cboFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorFont = new System.Windows.Forms.ToolStripSeparator();
            this.btnNumbers = new System.Windows.Forms.ToolStripButton();
            this.btnBullets = new System.Windows.Forms.ToolStripButton();
            this.btnOutdent = new System.Windows.Forms.ToolStripButton();
            this.btnIndent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorFormat = new System.Windows.Forms.ToolStripSeparator();
            this.btnLeft = new System.Windows.Forms.ToolStripButton();
            this.btnCenter = new System.Windows.Forms.ToolStripButton();
            this.btnRight = new System.Windows.Forms.ToolStripButton();
            this.btnFull = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorAlign = new System.Windows.Forms.ToolStripSeparator();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnHyperlink = new System.Windows.Forms.ToolStripButton();
            this.btnPicture = new System.Windows.Forms.ToolStripButton();
            this.webBrowserBody = new System.Windows.Forms.WebBrowser();
            this.toolStripToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripToolBar
            // 
            this.toolStripToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboFontName,
            this.cboFontSize,
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.btnColor,
            this.toolStripSeparatorFont,
            this.btnNumbers,
            this.btnBullets,
            this.btnOutdent,
            this.btnIndent,
            this.toolStripSeparatorFormat,
            this.btnLeft,
            this.btnCenter,
            this.btnRight,
            this.btnFull,
            this.toolStripSeparatorAlign,
            this.btnLine,
            this.btnHyperlink,
            this.btnPicture});
            this.toolStripToolBar.Location = new System.Drawing.Point(0, 0);
            this.toolStripToolBar.Name = "toolStripToolBar";
            this.toolStripToolBar.Size = new System.Drawing.Size(600, 25);
            this.toolStripToolBar.TabIndex = 1;
            this.toolStripToolBar.Text = "Tool Bar";
            // 
            // cboFontName
            // 
            this.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontName.DropDownWidth = 130;
            this.cboFontName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFontName.MaxDropDownItems = 30;
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new System.Drawing.Size(100, 25);
            this.cboFontName.SelectedIndexChanged += new System.EventHandler(this.cboFontName_SelectedIndexChanged);
            // 
            // cboFontSize
            // 
            this.cboFontSize.AutoSize = false;
            this.cboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontSize.DropDownWidth = 35;
            this.cboFontSize.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cboFontSize.MaxDropDownItems = 10;
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(40, 25);
            this.cboFontSize.SelectedIndexChanged += new System.EventHandler(this.cboFontSize_SelectedIndexChanged);
            // 
            // btnBold
            // 
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Text = "Bold";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.Text = "Italic";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnUnderline.Text = "Underline";
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // btnColor
            // 
            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
            this.btnColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(23, 22);
            this.btnColor.Text = "Font Color";
            this.btnColor.Click += new System.EventHandler(this.toolStripButtonColor_Click);
            // 
            // toolStripSeparatorFont
            // 
            this.toolStripSeparatorFont.Name = "toolStripSeparatorFont";
            this.toolStripSeparatorFont.Size = new System.Drawing.Size(6, 25);
            // 
            // btnNumbers
            // 
            this.btnNumbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNumbers.Image = ((System.Drawing.Image)(resources.GetObject("btnNumbers.Image")));
            this.btnNumbers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNumbers.Name = "btnNumbers";
            this.btnNumbers.Size = new System.Drawing.Size(23, 22);
            this.btnNumbers.Text = "Format Numbers";
            this.btnNumbers.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // btnBullets
            // 
            this.btnBullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBullets.Image = ((System.Drawing.Image)(resources.GetObject("btnBullets.Image")));
            this.btnBullets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBullets.Name = "btnBullets";
            this.btnBullets.Size = new System.Drawing.Size(23, 22);
            this.btnBullets.Text = "Format Bullets";
            this.btnBullets.Click += new System.EventHandler(this.btnBullets_Click);
            // 
            // btnOutdent
            // 
            this.btnOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOutdent.Image = ((System.Drawing.Image)(resources.GetObject("btnOutdent.Image")));
            this.btnOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutdent.Name = "btnOutdent";
            this.btnOutdent.Size = new System.Drawing.Size(23, 22);
            this.btnOutdent.Text = "Decrease Indentation";
            this.btnOutdent.Click += new System.EventHandler(this.toolStripButtonOutdent_Click);
            // 
            // btnIndent
            // 
            this.btnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIndent.Image = ((System.Drawing.Image)(resources.GetObject("btnIndent.Image")));
            this.btnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIndent.Name = "btnIndent";
            this.btnIndent.Size = new System.Drawing.Size(23, 22);
            this.btnIndent.Text = "Increase Indentation";
            this.btnIndent.Click += new System.EventHandler(this.toolStripButtonIndent_Click);
            // 
            // toolStripSeparatorFormat
            // 
            this.toolStripSeparatorFormat.Name = "toolStripSeparatorFormat";
            this.toolStripSeparatorFormat.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLeft
            // 
            this.btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(23, 22);
            this.btnLeft.Text = "Align Left";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnCenter
            // 
            this.btnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnCenter.Image")));
            this.btnCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(23, 22);
            this.btnCenter.Text = "Center";
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnRight
            // 
            this.btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(23, 22);
            this.btnRight.Text = "Align Right";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnFull
            // 
            this.btnFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFull.Image = ((System.Drawing.Image)(resources.GetObject("btnFull.Image")));
            this.btnFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFull.Name = "btnFull";
            this.btnFull.Size = new System.Drawing.Size(23, 22);
            this.btnFull.Text = "Justify";
            this.btnFull.Click += new System.EventHandler(this.btnFull_Click);
            // 
            // toolStripSeparatorAlign
            // 
            this.toolStripSeparatorAlign.Name = "toolStripSeparatorAlign";
            this.toolStripSeparatorAlign.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLine
            // 
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(23, 22);
            this.btnLine.Text = "Insert Horizontal Line";
            this.btnLine.Click += new System.EventHandler(this.toolStripButtonLine_Click);
            // 
            // btnHyperlink
            // 
            this.btnHyperlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHyperlink.Image = ((System.Drawing.Image)(resources.GetObject("btnHyperlink.Image")));
            this.btnHyperlink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHyperlink.Name = "btnHyperlink";
            this.btnHyperlink.Size = new System.Drawing.Size(23, 22);
            this.btnHyperlink.Text = "Create a Hyperlink";
            this.btnHyperlink.Click += new System.EventHandler(this.toolStripButtonHyperlink_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnPicture.Image")));
            this.btnPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(23, 22);
            this.btnPicture.Text = "Insert Picture";
            this.btnPicture.Click += new System.EventHandler(this.toolStripButtonPicture_Click);
            // 
            // webBrowserBody
            // 
            this.webBrowserBody.AllowWebBrowserDrop = false;
            this.webBrowserBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserBody.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserBody.Location = new System.Drawing.Point(0, 25);
            this.webBrowserBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserBody.Name = "webBrowserBody";
            this.webBrowserBody.Size = new System.Drawing.Size(600, 425);
            this.webBrowserBody.TabIndex = 0;
            this.webBrowserBody.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserBody_DocumentCompleted);
            this.webBrowserBody.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowserBody_PreviewKeyDown);
            // 
            // UcHtmlEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.webBrowserBody);
            this.Controls.Add(this.toolStripToolBar);
            this.Name = "UcHtmlEditor";
            this.Size = new System.Drawing.Size(600, 450);
            this.toolStripToolBar.ResumeLayout(false);
            this.toolStripToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripToolBar;
        private System.Windows.Forms.WebBrowser webBrowserBody;
        private System.Windows.Forms.ToolStripComboBox cboFontName;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFont;
        private System.Windows.Forms.ToolStripButton btnNumbers;
        private System.Windows.Forms.ToolStripButton btnBullets;
        private System.Windows.Forms.ToolStripButton btnOutdent;
        private System.Windows.Forms.ToolStripButton btnIndent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFormat;
        private System.Windows.Forms.ToolStripButton btnLeft;
        private System.Windows.Forms.ToolStripButton btnCenter;
        private System.Windows.Forms.ToolStripButton btnRight;
        private System.Windows.Forms.ToolStripButton btnFull;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorAlign;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.ToolStripButton btnHyperlink;
        private System.Windows.Forms.ToolStripButton btnPicture;
        private System.Windows.Forms.ToolStripComboBox cboFontSize;
    }
}
