namespace RDIFramework.WorkFlow
{
    partial class FrmMainUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainUserControl));
            this.btnDelete = new RDIFramework.Controls.UcButton();
            this.btnAdd = new RDIFramework.Controls.UcButton();
            this.lblSubControl = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new RDIFramework.Controls.UcTextBox(this.components);
            this.btnUp = new RDIFramework.Controls.UcButton();
            this.btnDown = new RDIFramework.Controls.UcButton();
            this.btnReadOnly = new RDIFramework.Controls.UcButton();
            this.btnModify = new RDIFramework.Controls.UcButton();
            this.btnNew = new RDIFramework.Controls.UcButton();
            this.lvUserControls = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvUserControls);
            this.plclassFill.Controls.Add(this.btnNew);
            this.plclassFill.Controls.Add(this.btnModify);
            this.plclassFill.Controls.Add(this.btnReadOnly);
            this.plclassFill.Controls.Add(this.btnDown);
            this.plclassFill.Controls.Add(this.btnUp);
            this.plclassFill.Controls.Add(this.btnDelete);
            this.plclassFill.Controls.Add(this.btnAdd);
            this.plclassFill.Controls.Add(this.lblSubControl);
            this.plclassFill.Controls.Add(this.lblDescription);
            this.plclassFill.Controls.Add(this.txtDescription);
            this.plclassFill.Controls.Add(this.lblFullName);
            this.plclassFill.Controls.Add(this.txtFullName);
            this.plclassFill.Size = new System.Drawing.Size(434, 382);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 333);
            this.plclassBottom.Size = new System.Drawing.Size(434, 49);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(329, 14);
            this.btnClose.Size = new System.Drawing.Size(82, 23);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(229, 14);
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(118, 294);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 23);
            this.btnDelete.TabIndex = 106;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(23, 294);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 23);
            this.btnAdd.TabIndex = 105;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // lblSubControl
            // 
            this.lblSubControl.AutoEllipsis = true;
            this.lblSubControl.Location = new System.Drawing.Point(20, 94);
            this.lblSubControl.Name = "lblSubControl";
            this.lblSubControl.Size = new System.Drawing.Size(171, 14);
            this.lblSubControl.TabIndex = 104;
            this.lblSubControl.Text = "子表单：";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 14);
            this.lblDescription.TabIndex = 102;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.FocusHighlightEnabled = true;
            this.txtDescription.Location = new System.Drawing.Point(107, 46);
            this.txtDescription.MaxLength = 40;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.SelectedValue = ((object)(resources.GetObject("txtDescription.SelectedValue")));
            this.txtDescription.Size = new System.Drawing.Size(302, 23);
            this.txtDescription.TabIndex = 101;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoEllipsis = true;
            this.lblFullName.Location = new System.Drawing.Point(11, 20);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(92, 14);
            this.lblFullName.TabIndex = 100;
            this.lblFullName.Text = "主表单：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            // 
            // 
            // 
            this.txtFullName.Border.Class = "TextBoxBorder";
            this.txtFullName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFullName.FocusHighlightEnabled = true;
            this.txtFullName.Location = new System.Drawing.Point(107, 16);
            this.txtFullName.MaxLength = 40;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.SelectedValue = ((object)(resources.GetObject("txtFullName.SelectedValue")));
            this.txtFullName.Size = new System.Drawing.Size(302, 23);
            this.txtFullName.TabIndex = 99;
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Location = new System.Drawing.Point(246, 294);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(52, 23);
            this.btnUp.TabIndex = 107;
            this.btnUp.Text = "上移";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Location = new System.Drawing.Point(304, 294);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(52, 23);
            this.btnDown.TabIndex = 108;
            this.btnDown.Text = "下移";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnReadOnly
            // 
            this.btnReadOnly.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReadOnly.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReadOnly.Location = new System.Drawing.Point(363, 140);
            this.btnReadOnly.Name = "btnReadOnly";
            this.btnReadOnly.Size = new System.Drawing.Size(63, 23);
            this.btnReadOnly.TabIndex = 109;
            this.btnReadOnly.Text = "查看";
            this.btnReadOnly.Click += new System.EventHandler(this.btnReadOnly_Click);
            // 
            // btnModify
            // 
            this.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModify.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModify.Location = new System.Drawing.Point(363, 181);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(63, 23);
            this.btnModify.TabIndex = 110;
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNew.Location = new System.Drawing.Point(363, 226);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(63, 23);
            this.btnNew.TabIndex = 111;
            this.btnNew.Text = "新建";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lvUserControls
            // 
            // 
            // 
            // 
            this.lvUserControls.Border.Class = "ListViewBorder";
            this.lvUserControls.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvUserControls.FullRowSelect = true;
            this.lvUserControls.Location = new System.Drawing.Point(18, 117);
            this.lvUserControls.MultiSelect = false;
            this.lvUserControls.Name = "lvUserControls";
            this.lvUserControls.Size = new System.Drawing.Size(338, 160);
            this.lvUserControls.TabIndex = 146;
            this.lvUserControls.UseCompatibleStateImageBehavior = false;
            this.lvUserControls.View = System.Windows.Forms.View.Details;
            this.lvUserControls.SelectedIndexChanged += new System.EventHandler(this.lvUserControls_SelectedIndexChanged);
            this.lvUserControls.DoubleClick += new System.EventHandler(this.lvUserControls_DoubleClick);
            // 
            // FrmMainUserControl
            // 
            this.ClientSize = new System.Drawing.Size(434, 382);
            this.Name = "FrmMainUserControl";
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcButton btnDelete;
        private Controls.UcButton btnAdd;
        private System.Windows.Forms.Label lblSubControl;
        private System.Windows.Forms.Label lblDescription;
        private Controls.UcTextBox txtDescription;
        private System.Windows.Forms.Label lblFullName;
        private Controls.UcTextBox txtFullName;
        private Controls.UcButton btnDown;
        private Controls.UcButton btnUp;
        private Controls.UcButton btnReadOnly;
        private Controls.UcButton btnNew;
        private Controls.UcButton btnModify;
        public DevComponents.DotNetBar.Controls.ListViewEx lvUserControls;

    }
}
