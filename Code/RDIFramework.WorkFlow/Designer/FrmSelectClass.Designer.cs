namespace RDIFramework.WorkFlow
{
    partial class FrmSelectClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectClass));
            this.tvWorkClass = new System.Windows.Forms.TreeView();
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lblWorkFlowClass = new System.Windows.Forms.Label();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lblWorkFlowClass);
            this.plclassFill.Controls.Add(this.tvWorkClass);
            this.plclassFill.Size = new System.Drawing.Size(368, 414);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 360);
            this.plclassBottom.Size = new System.Drawing.Size(368, 54);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(260, 16);
            this.btnClose.Size = new System.Drawing.Size(88, 23);
            this.btnClose.Text = "取消(&C)";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(161, 16);
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.Text = "确定(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tvWorkClass
            // 
            this.tvWorkClass.ImageIndex = 0;
            this.tvWorkClass.ImageList = this.imgListSmall;
            this.tvWorkClass.Location = new System.Drawing.Point(23, 33);
            this.tvWorkClass.Name = "tvWorkClass";
            this.tvWorkClass.SelectedImageIndex = 0;
            this.tvWorkClass.Size = new System.Drawing.Size(321, 309);
            this.tvWorkClass.StateImageList = this.imgListSmall;
            this.tvWorkClass.TabIndex = 0;
            this.tvWorkClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvArch_AfterSelect);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "folder.bmp");
            // 
            // lblWorkFlowClass
            // 
            this.lblWorkFlowClass.AutoSize = true;
            this.lblWorkFlowClass.Location = new System.Drawing.Point(21, 9);
            this.lblWorkFlowClass.Name = "lblWorkFlowClass";
            this.lblWorkFlowClass.Size = new System.Drawing.Size(77, 14);
            this.lblWorkFlowClass.TabIndex = 1;
            this.lblWorkFlowClass.Text = "流程分类：";
            // 
            // FrmSelectClass
            // 
            this.ClientSize = new System.Drawing.Size(368, 414);
            this.Name = "FrmSelectClass";
            this.Text = "选择分类";
            this.Load += new System.EventHandler(this.SelectDutyFm_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassFill.PerformLayout();
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWorkFlowClass;
        public System.Windows.Forms.TreeView tvWorkClass;
        private System.Windows.Forms.ImageList imgListSmall;
    }
}
