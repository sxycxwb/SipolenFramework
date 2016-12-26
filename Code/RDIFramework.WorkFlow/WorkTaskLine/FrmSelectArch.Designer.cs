namespace RDIFramework.WorkFlow
{
    partial class FrmSelectArch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectArch));
            this.tvArch = new System.Windows.Forms.TreeView();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lblSelectDepartment = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lblSelectDepartment);
            this.plclassFill.Controls.Add(this.tvArch);
            this.plclassFill.Size = new System.Drawing.Size(368, 414);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 358);
            this.plclassBottom.Size = new System.Drawing.Size(368, 56);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(250, 16);
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.Text = "取消(&C)";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(151, 16);
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tvArch
            // 
            this.tvArch.ImageIndex = 0;
            this.tvArch.ImageList = this.imgListSmall;
            this.tvArch.Location = new System.Drawing.Point(23, 33);
            this.tvArch.Name = "tvArch";
            this.tvArch.SelectedImageIndex = 0;
            this.tvArch.Size = new System.Drawing.Size(321, 309);
            this.tvArch.StateImageList = this.imgListSmall;
            this.tvArch.TabIndex = 0;
            this.tvArch.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvArch_AfterSelect);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "12.bmp");
            this.imgListSmall.Images.SetKeyName(1, "duty.bmp");
            // 
            // lblSelectDepartment
            // 
            this.lblSelectDepartment.AutoSize = true;
            this.lblSelectDepartment.Location = new System.Drawing.Point(21, 12);
            this.lblSelectDepartment.Name = "lblSelectDepartment";
            this.lblSelectDepartment.Size = new System.Drawing.Size(91, 14);
            this.lblSelectDepartment.TabIndex = 1;
            this.lblSelectDepartment.Text = "请选择部门：";
            // 
            // FrmSelectArch
            // 
            this.ClientSize = new System.Drawing.Size(368, 414);
            this.Name = "FrmSelectArch";
            this.Text = "选择部门";
            this.Load += new System.EventHandler(this.SelectDutyFm_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSelectDepartment;
        public System.Windows.Forms.TreeView tvArch;
        private System.Windows.Forms.ImageList imgListSmall;
    }
}
