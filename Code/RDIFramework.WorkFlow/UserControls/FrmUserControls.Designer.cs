namespace RDIFramework.WorkFlow
{
    partial class FrmUserControls
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserControls));
            this.tcUser = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.lvMainUserControl = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lblBelongMainForm = new System.Windows.Forms.Label();
            this.tabItemBelong = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.rbType3 = new System.Windows.Forms.RadioButton();
            this.rbType2 = new System.Windows.Forms.RadioButton();
            this.rbType1 = new System.Windows.Forms.RadioButton();
            this.lblFormType = new System.Windows.Forms.Label();
            this.txtAssemblyName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblAssemblyName = new System.Windows.Forms.Label();
            this.txtFormName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFormName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtControlId = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblControlId = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDes = new RDIFramework.Controls.UcTextBox(this.components);
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtPath = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblPath = new System.Windows.Forms.Label();
            this.tabItemGeneral = new DevComponents.DotNetBar.TabItem(this.components);
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).BeginInit();
            this.tcUser.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.tcUser);
            this.plclassFill.Size = new System.Drawing.Size(481, 445);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 403);
            this.plclassBottom.Size = new System.Drawing.Size(481, 42);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(379, 9);
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(279, 9);
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcUser
            // 
            this.tcUser.BackColor = System.Drawing.SystemColors.Window;
            this.tcUser.CanReorderTabs = true;
            this.tcUser.Controls.Add(this.tabControlPanel2);
            this.tcUser.Controls.Add(this.tabControlPanel1);
            this.tcUser.Location = new System.Drawing.Point(6, 9);
            this.tcUser.Name = "tcUser";
            this.tcUser.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.tcUser.SelectedTabIndex = 0;
            this.tcUser.Size = new System.Drawing.Size(470, 389);
            this.tcUser.Style = DevComponents.DotNetBar.eTabStripStyle.VS2005;
            this.tcUser.TabIndex = 25;
            this.tcUser.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tcUser.Tabs.Add(this.tabItemGeneral);
            this.tcUser.Tabs.Add(this.tabItemBelong);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lvMainUserControl);
            this.tabControlPanel1.Controls.Add(this.lblBelongMainForm);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(470, 362);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 2;
            this.tabControlPanel1.TabItem = this.tabItemBelong;
            // 
            // lvMainUserControl
            // 
            // 
            // 
            // 
            this.lvMainUserControl.Border.Class = "ListViewBorder";
            this.lvMainUserControl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvMainUserControl.FullRowSelect = true;
            this.lvMainUserControl.Location = new System.Drawing.Point(18, 39);
            this.lvMainUserControl.MultiSelect = false;
            this.lvMainUserControl.Name = "lvMainUserControl";
            this.lvMainUserControl.Size = new System.Drawing.Size(439, 311);
            this.lvMainUserControl.SmallImageList = this.imgListSmall;
            this.lvMainUserControl.TabIndex = 144;
            this.lvMainUserControl.UseCompatibleStateImageBehavior = false;
            this.lvMainUserControl.View = System.Windows.Forms.View.Details;
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "13.bmp");
            // 
            // lblBelongMainForm
            // 
            this.lblBelongMainForm.AutoSize = true;
            this.lblBelongMainForm.BackColor = System.Drawing.Color.Transparent;
            this.lblBelongMainForm.Location = new System.Drawing.Point(15, 18);
            this.lblBelongMainForm.Name = "lblBelongMainForm";
            this.lblBelongMainForm.Size = new System.Drawing.Size(119, 14);
            this.lblBelongMainForm.TabIndex = 2;
            this.lblBelongMainForm.Text = "隶属于主表单(&M):";
            // 
            // tabItemBelong
            // 
            this.tabItemBelong.AttachedControl = this.tabControlPanel1;
            this.tabItemBelong.Name = "tabItemBelong";
            this.tabItemBelong.Text = "隶属于";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.rbType3);
            this.tabControlPanel2.Controls.Add(this.rbType2);
            this.tabControlPanel2.Controls.Add(this.rbType1);
            this.tabControlPanel2.Controls.Add(this.lblFormType);
            this.tabControlPanel2.Controls.Add(this.txtAssemblyName);
            this.tabControlPanel2.Controls.Add(this.lblAssemblyName);
            this.tabControlPanel2.Controls.Add(this.txtFormName);
            this.tabControlPanel2.Controls.Add(this.lblFormName);
            this.tabControlPanel2.Controls.Add(this.pictureBox1);
            this.tabControlPanel2.Controls.Add(this.label5);
            this.tabControlPanel2.Controls.Add(this.txtControlId);
            this.tabControlPanel2.Controls.Add(this.lblControlId);
            this.tabControlPanel2.Controls.Add(this.lblDescription);
            this.tabControlPanel2.Controls.Add(this.txtDes);
            this.tabControlPanel2.Controls.Add(this.txtFullName);
            this.tabControlPanel2.Controls.Add(this.btnSearch);
            this.tabControlPanel2.Controls.Add(this.lblFullName);
            this.tabControlPanel2.Controls.Add(this.txtPath);
            this.tabControlPanel2.Controls.Add(this.lblPath);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(470, 362);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 1;
            this.tabControlPanel2.TabItem = this.tabItemGeneral;
            this.tabControlPanel2.Text = "归属角色";
            // 
            // rbType3
            // 
            this.rbType3.AutoSize = true;
            this.rbType3.BackColor = System.Drawing.Color.Transparent;
            this.rbType3.Location = new System.Drawing.Point(245, 131);
            this.rbType3.Name = "rbType3";
            this.rbType3.Size = new System.Drawing.Size(102, 18);
            this.rbType3.TabIndex = 3;
            this.rbType3.TabStop = true;
            this.rbType3.Text = "WinForm/Web";
            this.rbType3.UseVisualStyleBackColor = false;
            // 
            // rbType2
            // 
            this.rbType2.AutoSize = true;
            this.rbType2.BackColor = System.Drawing.Color.Transparent;
            this.rbType2.Location = new System.Drawing.Point(193, 130);
            this.rbType2.Name = "rbType2";
            this.rbType2.Size = new System.Drawing.Size(46, 18);
            this.rbType2.TabIndex = 2;
            this.rbType2.TabStop = true;
            this.rbType2.Text = "Web";
            this.rbType2.UseVisualStyleBackColor = false;
            // 
            // rbType1
            // 
            this.rbType1.AutoSize = true;
            this.rbType1.BackColor = System.Drawing.Color.Transparent;
            this.rbType1.Location = new System.Drawing.Point(113, 130);
            this.rbType1.Name = "rbType1";
            this.rbType1.Size = new System.Drawing.Size(74, 18);
            this.rbType1.TabIndex = 1;
            this.rbType1.TabStop = true;
            this.rbType1.Text = "WinForm";
            this.rbType1.UseVisualStyleBackColor = false;
            // 
            // lblFormType
            // 
            this.lblFormType.AutoEllipsis = true;
            this.lblFormType.BackColor = System.Drawing.Color.Transparent;
            this.lblFormType.Location = new System.Drawing.Point(4, 133);
            this.lblFormType.Name = "lblFormType";
            this.lblFormType.Size = new System.Drawing.Size(107, 14);
            this.lblFormType.TabIndex = 122;
            this.lblFormType.Text = "表单类型:";
            this.lblFormType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssemblyName
            // 
            this.txtAssemblyName.BackColor = System.Drawing.Color.Lavender;
            // 
            // 
            // 
            this.txtAssemblyName.Border.Class = "TextBoxBorder";
            this.txtAssemblyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAssemblyName.FocusHighlightEnabled = true;
            this.txtAssemblyName.Location = new System.Drawing.Point(112, 256);
            this.txtAssemblyName.MaxLength = 100;
            this.txtAssemblyName.Name = "txtAssemblyName";
            this.txtAssemblyName.SelectedValue = ((object)(resources.GetObject("txtAssemblyName.SelectedValue")));
            this.txtAssemblyName.Size = new System.Drawing.Size(332, 23);
            this.txtAssemblyName.TabIndex = 7;
            // 
            // lblAssemblyName
            // 
            this.lblAssemblyName.AutoEllipsis = true;
            this.lblAssemblyName.BackColor = System.Drawing.Color.Transparent;
            this.lblAssemblyName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAssemblyName.ForeColor = System.Drawing.Color.Blue;
            this.lblAssemblyName.Location = new System.Drawing.Point(4, 262);
            this.lblAssemblyName.Name = "lblAssemblyName";
            this.lblAssemblyName.Size = new System.Drawing.Size(107, 14);
            this.lblAssemblyName.TabIndex = 120;
            this.lblAssemblyName.Text = "所在程序集:";
            this.lblAssemblyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFormName
            // 
            this.txtFormName.BackColor = System.Drawing.Color.Lavender;
            // 
            // 
            // 
            this.txtFormName.Border.Class = "TextBoxBorder";
            this.txtFormName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFormName.FocusHighlightEnabled = true;
            this.txtFormName.Location = new System.Drawing.Point(112, 225);
            this.txtFormName.MaxLength = 100;
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.SelectedValue = ((object)(resources.GetObject("txtFormName.SelectedValue")));
            this.txtFormName.Size = new System.Drawing.Size(332, 23);
            this.txtFormName.TabIndex = 6;
            // 
            // lblFormName
            // 
            this.lblFormName.AutoEllipsis = true;
            this.lblFormName.BackColor = System.Drawing.Color.Transparent;
            this.lblFormName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFormName.ForeColor = System.Drawing.Color.Blue;
            this.lblFormName.Location = new System.Drawing.Point(4, 229);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(107, 14);
            this.lblFormName.TabIndex = 119;
            this.lblFormName.Text = "表单名称:";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(19, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 50);
            this.pictureBox1.TabIndex = 117;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(15, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(431, 3);
            this.label5.TabIndex = 116;
            this.label5.Text = "label5";
            // 
            // txtControlId
            // 
            // 
            // 
            // 
            this.txtControlId.Border.Class = "TextBoxBorder";
            this.txtControlId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtControlId.FocusHighlightEnabled = true;
            this.txtControlId.Location = new System.Drawing.Point(112, 189);
            this.txtControlId.MaxLength = 50;
            this.txtControlId.Name = "txtControlId";
            this.txtControlId.SelectedValue = ((object)(resources.GetObject("txtControlId.SelectedValue")));
            this.txtControlId.Size = new System.Drawing.Size(332, 23);
            this.txtControlId.TabIndex = 5;
            // 
            // lblControlId
            // 
            this.lblControlId.AutoEllipsis = true;
            this.lblControlId.BackColor = System.Drawing.Color.Transparent;
            this.lblControlId.Location = new System.Drawing.Point(4, 193);
            this.lblControlId.Name = "lblControlId";
            this.lblControlId.Size = new System.Drawing.Size(107, 14);
            this.lblControlId.TabIndex = 114;
            this.lblControlId.Text = "控件ID:";
            this.lblControlId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Location = new System.Drawing.Point(4, 300);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(107, 14);
            this.lblDescription.TabIndex = 112;
            this.lblDescription.Text = "描述(&D):";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDes
            // 
            // 
            // 
            // 
            this.txtDes.Border.Class = "TextBoxBorder";
            this.txtDes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDes.FocusHighlightEnabled = true;
            this.txtDes.Location = new System.Drawing.Point(112, 295);
            this.txtDes.MaxLength = 500;
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDes.SelectedValue = ((object)(resources.GetObject("txtDes.SelectedValue")));
            this.txtDes.Size = new System.Drawing.Size(332, 61);
            this.txtDes.TabIndex = 8;
            // 
            // txtFullName
            // 
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(112, 97);
            this.txtFullName.MaxLength = 500;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = ((object)(resources.GetObject("txtFullName.SelectedValue")));
            this.txtFullName.Size = new System.Drawing.Size(332, 23);
            this.txtFullName.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(397, 156);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(48, 26);
            this.btnSearch.TabIndex = 110;
            this.btnSearch.Text = "...";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Location = new System.Drawing.Point(4, 101);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(107, 14);
            this.lblFullName.TabIndex = 109;
            this.lblFullName.Text = "子表单名:";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.Border.Class = "TextBoxBorder";
            this.txtPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPath.FocusHighlightEnabled = true;
            this.txtPath.Location = new System.Drawing.Point(112, 158);
            this.txtPath.MaxLength = 500;
            this.txtPath.Name = "txtPath";
            this.txtPath.SelectedValue = ((object)(resources.GetObject("txtPath.SelectedValue")));
            this.txtPath.Size = new System.Drawing.Size(272, 23);
            this.txtPath.TabIndex = 4;
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Location = new System.Drawing.Point(4, 164);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(107, 14);
            this.lblPath.TabIndex = 108;
            this.lblPath.Text = "位置:";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabItemGeneral
            // 
            this.tabItemGeneral.AttachedControl = this.tabControlPanel2;
            this.tabItemGeneral.Name = "tabItemGeneral";
            this.tabItemGeneral.Text = "常规";
            // 
            // FrmUserControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 445);
            this.Name = "FrmUserControls";
            this.Text = "FrmUserControls";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcUser)).EndInit();
            this.tcUser.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tcUser;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private System.Windows.Forms.RadioButton rbType3;
        private System.Windows.Forms.RadioButton rbType2;
        private System.Windows.Forms.RadioButton rbType1;
        private System.Windows.Forms.Label lblFormType;
        private Controls.UcTextBox txtAssemblyName;
        private System.Windows.Forms.Label lblAssemblyName;
        private Controls.UcTextBox txtFormName;
        private System.Windows.Forms.Label lblFormName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private Controls.UcTextBox txtControlId;
        private System.Windows.Forms.Label lblControlId;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcTextBox txtDes;
        private Controls.UcTextBox txtFullName;
        private Controls.UcButton btnSearch;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private DevComponents.DotNetBar.TabItem tabItemGeneral;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private System.Windows.Forms.Label lblBelongMainForm;
        private DevComponents.DotNetBar.TabItem tabItemBelong;
        private System.Windows.Forms.ImageList imgListSmall;
        public DevComponents.DotNetBar.Controls.ListViewEx lvMainUserControl;
    }
}