namespace RDIFramework.WorkFlow
{
    partial class FrmSelectGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectGroup));
            this.imgListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvGroup = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvGroup);
            this.plclassFill.Size = new System.Drawing.Size(426, 466);
            this.plclassFill.Paint += new System.Windows.Forms.PaintEventHandler(this.plclassFill_Paint);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 403);
            this.plclassBottom.Size = new System.Drawing.Size(426, 63);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(312, 17);
            this.btnClose.Text = "ȡ��(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(214, 17);
            this.btnSave.Text = "ȷ��(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // imgListSmall
            // 
            this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
            this.imgListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListSmall.Images.SetKeyName(0, "13.bmp");
            // 
            // lvGroup
            // 
            // 
            // 
            // 
            this.lvGroup.Border.Class = "ListViewBorder";
            this.lvGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvGroup.FullRowSelect = true;
            this.lvGroup.Location = new System.Drawing.Point(3, 12);
            this.lvGroup.MultiSelect = false;
            this.lvGroup.Name = "lvGroup";
            this.lvGroup.Size = new System.Drawing.Size(411, 385);
            this.lvGroup.SmallImageList = this.imgListSmall;
            this.lvGroup.TabIndex = 143;
            this.lvGroup.UseCompatibleStateImageBehavior = false;
            this.lvGroup.View = System.Windows.Forms.View.Details;
            // 
            // FrmSelectGroup
            // 
            this.ClientSize = new System.Drawing.Size(426, 466);
            this.Name = "FrmSelectGroup";
            this.Text = "ѡ���ɫ";
            this.Load += new System.EventHandler(this.SelectGroupFm_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListSmall;
        public DevComponents.DotNetBar.Controls.ListViewEx lvGroup;
    }
}
