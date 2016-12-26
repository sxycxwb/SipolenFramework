namespace RDIFramework.WorkFlow
{
    partial class FrmSelectUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectUser));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lblAccount = new System.Windows.Forms.Label();
            this.tbxUserId = new RDIFramework.Controls.UcTextBox(this.components);
            this.tbxUserName = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.lvUser = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvUser);
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxUserName);
            this.plclassFill.Controls.Add(this.lblUserName);
            this.plclassFill.Controls.Add(this.tbxUserId);
            this.plclassFill.Controls.Add(this.lblAccount);
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.plclassFill.Size = new System.Drawing.Size(494, 358);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassBottom.Location = new System.Drawing.Point(0, 358);
            this.plclassBottom.Size = new System.Drawing.Size(494, 50);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(393, 15);
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.Text = "取消(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(291, 15);
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // lblAccount
            // 
            this.lblAccount.AutoEllipsis = true;
            this.lblAccount.Location = new System.Drawing.Point(2, 24);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(70, 14);
            this.lblAccount.TabIndex = 5;
            this.lblAccount.Text = "帐号：";
            this.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbxUserId
            // 
            // 
            // 
            // 
            this.tbxUserId.Border.Class = "TextBoxBorder";
            this.tbxUserId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxUserId.FocusHighlightEnabled = true;
            this.tbxUserId.Location = new System.Drawing.Point(69, 20);
            this.tbxUserId.Name = "tbxUserId";
            this.tbxUserId.SelectedValue = ((object)(resources.GetObject("tbxUserId.SelectedValue")));
            this.tbxUserId.Size = new System.Drawing.Size(127, 23);
            this.tbxUserId.TabIndex = 6;
            // 
            // tbxUserName
            // 
            // 
            // 
            // 
            this.tbxUserName.Border.Class = "TextBoxBorder";
            this.tbxUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxUserName.FocusHighlightEnabled = true;
            this.tbxUserName.Location = new System.Drawing.Point(279, 20);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.SelectedValue = ((object)(resources.GetObject("tbxUserName.SelectedValue")));
            this.tbxUserName.Size = new System.Drawing.Size(116, 23);
            this.tbxUserName.TabIndex = 8;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoEllipsis = true;
            this.lblUserName.Location = new System.Drawing.Point(202, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(81, 14);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "姓名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(401, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvUser
            // 
            // 
            // 
            // 
            this.lvUser.Border.Class = "ListViewBorder";
            this.lvUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvUser.FullRowSelect = true;
            this.lvUser.Location = new System.Drawing.Point(12, 54);
            this.lvUser.MultiSelect = false;
            this.lvUser.Name = "lvUser";
            this.lvUser.Size = new System.Drawing.Size(470, 288);
            this.lvUser.SmallImageList = this.imgListSmall;
            this.lvUser.TabIndex = 143;
            this.lvUser.UseCompatibleStateImageBehavior = false;
            this.lvUser.View = System.Windows.Forms.View.Details;
            // 
            // FrmSelectUser
            // 
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.Name = "FrmSelectUser";
            this.Text = "选择用户";
            this.Load += new System.EventHandler(this.FrmSelectUser_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        private Controls.UcButton btnSearch;
        private Controls.UcTextBox tbxUserName;
        private System.Windows.Forms.Label lblUserName;
        private Controls.UcTextBox tbxUserId;
        private System.Windows.Forms.Label lblAccount;
        public DevComponents.DotNetBar.Controls.ListViewEx lvUser;
    }
}
