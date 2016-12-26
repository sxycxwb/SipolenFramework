namespace RDIFramework.WorkFlow
{
    partial class FrmSelectUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectUserControl));
            this.btnDelete = new RDIFramework.Controls.UcButton();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.btnDown = new RDIFramework.Controls.UcButton();
            this.btnUp = new RDIFramework.Controls.UcButton();
            this.lvSelectedUserControl = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.lvUserControl = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvUserControl);
            this.plclassFill.Controls.Add(this.lvSelectedUserControl);
            this.plclassFill.Controls.Add(this.btnDelete);
            this.plclassFill.Controls.Add(this.btnAdd);
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Top;
            this.plclassFill.Size = new System.Drawing.Size(494, 358);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Controls.Add(this.btnDown);
            this.plclassBottom.Controls.Add(this.btnUp);
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassBottom.Location = new System.Drawing.Point(0, 358);
            this.plclassBottom.Size = new System.Drawing.Size(494, 50);
            this.plclassBottom.Controls.SetChildIndex(this.btnSave, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnUp, 0);
            this.plclassBottom.Controls.SetChildIndex(this.btnDown, 0);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(385, 13);
            this.btnClose.Size = new System.Drawing.Size(93, 23);
            this.btnClose.Text = "取消(&E)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(267, 13);
            this.btnSave.Size = new System.Drawing.Size(93, 23);
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(118, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(16, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Location = new System.Drawing.Point(95, 13);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(52, 23);
            this.btnDown.TabIndex = 110;
            this.btnDown.Text = "下移";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Location = new System.Drawing.Point(26, 13);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(52, 23);
            this.btnUp.TabIndex = 109;
            this.btnUp.Text = "上移";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lvSelectedUserControl
            // 
            // 
            // 
            // 
            this.lvSelectedUserControl.Border.Class = "ListViewBorder";
            this.lvSelectedUserControl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvSelectedUserControl.FullRowSelect = true;
            this.lvSelectedUserControl.Location = new System.Drawing.Point(12, 219);
            this.lvSelectedUserControl.MultiSelect = false;
            this.lvSelectedUserControl.Name = "lvSelectedUserControl";
            this.lvSelectedUserControl.Size = new System.Drawing.Size(467, 133);
            this.lvSelectedUserControl.SmallImageList = this.imgListSmall;
            this.lvSelectedUserControl.TabIndex = 145;
            this.lvSelectedUserControl.UseCompatibleStateImageBehavior = false;
            this.lvSelectedUserControl.View = System.Windows.Forms.View.Details;
            this.lvSelectedUserControl.DoubleClick += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // lvUserControl
            // 
            // 
            // 
            // 
            this.lvUserControl.Border.Class = "ListViewBorder";
            this.lvUserControl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvUserControl.FullRowSelect = true;
            this.lvUserControl.Location = new System.Drawing.Point(15, 12);
            this.lvUserControl.MultiSelect = false;
            this.lvUserControl.Name = "lvUserControl";
            this.lvUserControl.Size = new System.Drawing.Size(467, 158);
            this.lvUserControl.SmallImageList = this.imgListSmall;
            this.lvUserControl.TabIndex = 146;
            this.lvUserControl.UseCompatibleStateImageBehavior = false;
            this.lvUserControl.View = System.Windows.Forms.View.Details;
            this.lvUserControl.DoubleClick += new System.EventHandler(this.btnAddUser_Click);
            // 
            // FrmSelectUserControl
            // 
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.Name = "FrmSelectUserControl";
            this.Text = "选择子表单";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcButton btnDelete;
        private Controls.UcButton btnAdd;
        private System.Windows.Forms.ImageList imgListSmall;
        private Controls.UcButton btnDown;
        private Controls.UcButton btnUp;
        public DevComponents.DotNetBar.Controls.ListViewEx lvSelectedUserControl;
        public DevComponents.DotNetBar.Controls.ListViewEx lvUserControl;
    }
}
