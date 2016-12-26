namespace RDIFramework.WorkFlow
{
    partial class FrmSelectMainUserCtrl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectMainUserCtrl));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lblFormName = new System.Windows.Forms.Label();
            this.tbxCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.btnNew = new RDIFramework.Controls.UcButton();
            this.btnModify = new RDIFramework.Controls.UcButton();
            this.lvMainUserCtrl = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvMainUserCtrl);
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxCaption);
            this.plclassFill.Controls.Add(this.lblFormName);
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.plclassFill.Size = new System.Drawing.Size(494, 358);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Controls.Add(this.btnNew);
            this.plclassBottom.Controls.Add(this.btnModify);
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassBottom.Location = new System.Drawing.Point(0, 358);
            this.plclassBottom.Size = new System.Drawing.Size(494, 50);
            this.plclassBottom.Controls.SetChildIndex(this.btnModify, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnNew, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnSave, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(402, 13);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(300, 13);
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // lblFormName
            // 
            this.lblFormName.AutoEllipsis = true;
            this.lblFormName.Location = new System.Drawing.Point(7, 16);
            this.lblFormName.Name = "lblFormName";
            this.lblFormName.Size = new System.Drawing.Size(100, 14);
            this.lblFormName.TabIndex = 5;
            this.lblFormName.Text = "表单名称：";
            this.lblFormName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxCaption
            // 
            // 
            // 
            // 
            this.tbxCaption.Border.Class = "TextBoxBorder";
            this.tbxCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxCaption.FocusHighlightEnabled = true;
            this.tbxCaption.Location = new System.Drawing.Point(108, 14);
            this.tbxCaption.Name = "tbxCaption";
            this.tbxCaption.SelectedValue = ((object)(resources.GetObject("tbxCaption.SelectedValue")));
            this.tbxCaption.Size = new System.Drawing.Size(236, 23);
            this.tbxCaption.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(365, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNew.Location = new System.Drawing.Point(20, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(73, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "新建";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnModify
            // 
            this.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModify.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModify.Location = new System.Drawing.Point(99, 13);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(73, 23);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // lvMainUserCtrl
            // 
            // 
            // 
            // 
            this.lvMainUserCtrl.Border.Class = "ListViewBorder";
            this.lvMainUserCtrl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvMainUserCtrl.FullRowSelect = true;
            this.lvMainUserCtrl.Location = new System.Drawing.Point(18, 47);
            this.lvMainUserCtrl.MultiSelect = false;
            this.lvMainUserCtrl.Name = "lvMainUserCtrl";
            this.lvMainUserCtrl.Size = new System.Drawing.Size(464, 305);
            this.lvMainUserCtrl.SmallImageList = this.imgListSmall;
            this.lvMainUserCtrl.TabIndex = 144;
            this.lvMainUserCtrl.UseCompatibleStateImageBehavior = false;
            this.lvMainUserCtrl.View = System.Windows.Forms.View.Details;
            // 
            // FrmSelectMainUserCtrl
            // 
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.Name = "FrmSelectMainUserCtrl";
            this.Text = "选择主表单";
            this.Load += new System.EventHandler(this.FrmSelectUser_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        private Controls.UcButton btnSearch;
        private Controls.UcTextBox tbxCaption;
        private System.Windows.Forms.Label lblFormName;
        private Controls.UcButton btnNew;
        private Controls.UcButton btnModify;
        public DevComponents.DotNetBar.Controls.ListViewEx lvMainUserCtrl;
    }
}
