namespace RDIFramework.WorkFlow
{
    partial class FrmSelectTaskOperUser
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectTaskOperUser));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvTask = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvTask);
            this.plclassFill.Size = new System.Drawing.Size(426, 445);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 397);
            this.plclassBottom.Size = new System.Drawing.Size(426, 48);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(318, 15);
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.Text = "ȡ��(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(222, 15);
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.Text = "ȷ��(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "�����ڵ�.ico");
            // 
            // lvTask
            // 
            // 
            // 
            // 
            this.lvTask.Border.Class = "ListViewBorder";
            this.lvTask.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvTask.FullRowSelect = true;
            this.lvTask.Location = new System.Drawing.Point(12, 12);
            this.lvTask.MultiSelect = false;
            this.lvTask.Name = "lvTask";
            this.lvTask.Size = new System.Drawing.Size(402, 376);
            this.lvTask.SmallImageList = this.imgListSmall;
            this.lvTask.TabIndex = 145;
            this.lvTask.UseCompatibleStateImageBehavior = false;
            this.lvTask.View = System.Windows.Forms.View.Details;
            // 
            // FrmSelectTaskOperUser
            // 
            this.ClientSize = new System.Drawing.Size(426, 445);
            this.Name = "FrmSelectTaskOperUser";
            this.Text = "ѡ������";
            this.Load += new System.EventHandler(this.FrmSelectTaskOperUser_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        public DevComponents.DotNetBar.Controls.ListViewEx lvTask;
    }
}
