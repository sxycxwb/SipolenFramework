namespace RDIFramework.WorkFlow
{
    partial class FrmSelectVar
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
            this.lvVar = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvVar);
            this.plclassFill.Size = new System.Drawing.Size(426, 394);
            // 
            // plclassBottom
            // 
            this.plclassBottom.Location = new System.Drawing.Point(0, 351);
            this.plclassBottom.Size = new System.Drawing.Size(426, 43);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(327, 11);
            this.btnClose.Size = new System.Drawing.Size(79, 23);
            this.btnClose.Text = "�ر�(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(231, 11);
            this.btnSave.Size = new System.Drawing.Size(79, 23);
            this.btnSave.Text = "ȷ��(&O)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvVar
            // 
            // 
            // 
            // 
            this.lvVar.Border.Class = "ListViewBorder";
            this.lvVar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvVar.FullRowSelect = true;
            this.lvVar.Location = new System.Drawing.Point(12, 8);
            this.lvVar.MultiSelect = false;
            this.lvVar.Name = "lvVar";
            this.lvVar.Size = new System.Drawing.Size(402, 336);
            this.lvVar.TabIndex = 143;
            this.lvVar.UseCompatibleStateImageBehavior = false;
            this.lvVar.View = System.Windows.Forms.View.Details;
            // 
            // FrmSelectVar
            // 
            this.ClientSize = new System.Drawing.Size(426, 394);
            this.Name = "FrmSelectVar";
            this.Text = "ѡ�����";
            this.Load += new System.EventHandler(this.SelectVar_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.Controls.ListViewEx lvVar;

    }
}
