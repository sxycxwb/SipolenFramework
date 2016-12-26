using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// DbToWord ��ժҪ˵����
	/// </summary>
	public class FrmDbToScript : System.Windows.Forms.Form
	{
		#region
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.ComboBox cmbDB;
		private System.Windows.Forms.ListBox listTable1;
		private System.Windows.Forms.ListBox listTable2;
        private System.Windows.Forms.Button btn_Creat;
        private System.Windows.Forms.Button btn_Cancle;
		private System.Windows.Forms.Button btn_Addlist;
		private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.Button btn_Del;
		private System.Windows.Forms.Button btn_Dellist;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labelNum;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtTargetFolder;
        private System.Windows.Forms.Button btn_TargetFold;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar2;
		#endregion
                
        IDbScriptBuilder dsb;
        IDbObject dbobj;
		string DbName="master";
        private PictureBox pictureBox1;
        Thread mythread;
        delegate void SetBtnEnableEventHandler();
        delegate void SetBtnDisableEventHandler();
        delegate void SetlblStatuEventHandler(string text);
        delegate void SetProBar1MaxEventHandler(int val);
        delegate void SetProBar1ValEventHandler(int val);

        public FrmDbToScript(string longServerName)
        {
            InitializeComponent();            
            dsb = ObjHelper.CreatDsb(longServerName);
            dbobj = ObjHelper.CreatDbObj(longServerName);

            int s = longServerName.IndexOf("(");
            string server = longServerName.Substring(0, s);
            this.lblServer.Text = server;

            List<string> dblist = dbobj.GetTables("");
            if (dblist != null)
            {
                if (dblist.Count > 0)
                {
                    foreach (string dbName in dblist)
                    {
                        this.cmbDB.Items.Add(dbName);
                    }
                }
            }

            //DataTable dt = dbobj.GetDBList();
            //if (dt != null)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        string dbName = row["name"].ToString();
            //        this.cmbDB.Items.Add(dbName);
            //    }
            //}
            this.btn_Creat.Enabled = false;
            if (cmbDB.Items.Count > 0)
            {
                this.cmbDB.SelectedIndex = 0;
            }

        }

        public FrmDbToScript(string longServerName, string dbName)
		{			
			InitializeComponent();			
			DbName=dbName;            
            dsb = ObjHelper.CreatDsb(longServerName);
            dbobj = ObjHelper.CreatDbObj(longServerName);
            this.lblServer.Text = longServerName;

            List<string> dblist = dbobj.GetDBList();
            if (dblist != null)
            {
                if (dblist.Count > 0)
                {
                    foreach (string name in dblist)
                    {
                        this.cmbDB.Items.Add(name);
                    }
                }
            }
            //DataTable dt = dbobj.GetDBList();
            //if (dt != null)
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {                    
            //        this.cmbDB.Items.Add(row["name"].ToString());
            //    }
            //}
            this.btn_Creat.Enabled = false;
            this.cmbDB.Text = DbName;
            
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbToScript));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelNum = new System.Windows.Forms.Label();
            this.btn_Addlist = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Dellist = new System.Windows.Forms.Button();
            this.listTable2 = new System.Windows.Forms.ListBox();
            this.listTable1 = new System.Windows.Forms.ListBox();
            this.btn_Creat = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTargetFolder = new System.Windows.Forms.TextBox();
            this.btn_TargetFold = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbDB);
            this.groupBox1.Controls.Add(this.lblServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ѡ�����ݿ�";
            // 
            // cmbDB
            // 
            this.cmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDB.Location = new System.Drawing.Point(326, 24);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(160, 20);
            this.cmbDB.TabIndex = 2;
            this.cmbDB.SelectedIndexChanged += new System.EventHandler(this.cmbDB_SelectedIndexChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(87, 26);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 12);
            this.lblServer.TabIndex = 1;
            this.lblServer.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "��ǰ��������";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "ѡ�����ݿ⣺";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.progressBar2);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.labelNum);
            this.groupBox2.Controls.Add(this.btn_Addlist);
            this.groupBox2.Controls.Add(this.btn_Add);
            this.groupBox2.Controls.Add(this.btn_Del);
            this.groupBox2.Controls.Add(this.btn_Dellist);
            this.groupBox2.Controls.Add(this.listTable2);
            this.groupBox2.Controls.Add(this.listTable1);
            this.groupBox2.Location = new System.Drawing.Point(8, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 224);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ѡ���";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(16, 178);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(428, 10);
            this.progressBar2.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(428, 20);
            this.progressBar1.TabIndex = 10;
            // 
            // labelNum
            // 
            this.labelNum.Location = new System.Drawing.Point(450, 191);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(35, 22);
            this.labelNum.TabIndex = 9;
            this.labelNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Addlist
            // 
            this.btn_Addlist.Enabled = false;
            this.btn_Addlist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Addlist.Location = new System.Drawing.Point(240, 31);
            this.btn_Addlist.Name = "btn_Addlist";
            this.btn_Addlist.Size = new System.Drawing.Size(40, 23);
            this.btn_Addlist.TabIndex = 7;
            this.btn_Addlist.Text = ">>";
            this.btn_Addlist.Click += new System.EventHandler(this.btn_Addlist_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Add.Location = new System.Drawing.Point(240, 61);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(40, 23);
            this.btn_Add.TabIndex = 8;
            this.btn_Add.Text = ">";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Enabled = false;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Del.Location = new System.Drawing.Point(240, 91);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(40, 23);
            this.btn_Del.TabIndex = 5;
            this.btn_Del.Text = "<";
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Dellist
            // 
            this.btn_Dellist.Enabled = false;
            this.btn_Dellist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Dellist.Location = new System.Drawing.Point(240, 121);
            this.btn_Dellist.Name = "btn_Dellist";
            this.btn_Dellist.Size = new System.Drawing.Size(40, 23);
            this.btn_Dellist.TabIndex = 6;
            this.btn_Dellist.Text = "<<";
            this.btn_Dellist.Click += new System.EventHandler(this.btn_Dellist_Click);
            // 
            // listTable2
            // 
            this.listTable2.ItemHeight = 12;
            this.listTable2.Location = new System.Drawing.Point(314, 21);
            this.listTable2.Name = "listTable2";
            this.listTable2.Size = new System.Drawing.Size(172, 148);
            this.listTable2.TabIndex = 1;
            this.listTable2.DoubleClick += new System.EventHandler(this.listTable2_DoubleClick);
            // 
            // listTable1
            // 
            this.listTable1.ItemHeight = 12;
            this.listTable1.Location = new System.Drawing.Point(16, 21);
            this.listTable1.Name = "listTable1";
            this.listTable1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listTable1.Size = new System.Drawing.Size(183, 148);
            this.listTable1.TabIndex = 0;
            this.listTable1.DoubleClick += new System.EventHandler(this.listTable1_DoubleClick);
            // 
            // btn_Creat
            // 
            this.btn_Creat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btn_Creat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Creat.Image = null;
            this.btn_Creat.Location = new System.Drawing.Point(308, 344);
            this.btn_Creat.Name = "btn_Creat";            
            this.btn_Creat.Size = new System.Drawing.Size(75, 26);
            this.btn_Creat.TabIndex = 42;
            this.btn_Creat.Text = "��  ��";
            this.btn_Creat.Click += new System.EventHandler(this.btn_Creat_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btn_Cancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Cancle.Image = null;
            this.btn_Cancle.Location = new System.Drawing.Point(412, 344);
            this.btn_Cancle.Name = "btn_Cancle";            
            this.btn_Cancle.Size = new System.Drawing.Size(75, 26);
            this.btn_Cancle.TabIndex = 42;
            this.btn_Cancle.Text = "ȡ  ��";
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTargetFolder);
            this.groupBox3.Controls.Add(this.btn_TargetFold);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(8, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 48);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "����";
            // 
            // txtTargetFolder
            // 
            this.txtTargetFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTargetFolder.Location = new System.Drawing.Point(72, 16);
            this.txtTargetFolder.Name = "txtTargetFolder";
            this.txtTargetFolder.Size = new System.Drawing.Size(351, 21);
            this.txtTargetFolder.TabIndex = 47;
            // 
            // btn_TargetFold
            // 
            this.btn_TargetFold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btn_TargetFold.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_TargetFold.Image = null;
            this.btn_TargetFold.Location = new System.Drawing.Point(429, 14);
            this.btn_TargetFold.Name = "btn_TargetFold";
            
            this.btn_TargetFold.Size = new System.Drawing.Size(57, 23);
            this.btn_TargetFold.TabIndex = 48;
            this.btn_TargetFold.Text = "ѡ��...";
            this.btn_TargetFold.Click += new System.EventHandler(this.btn_TargetFold_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "�ļ�����";
            // 
            // pictureBox1
            // 
            //this.pictureBox1.Image = global::Codematic.Properties.Resources.Control;
            this.pictureBox1.Location = new System.Drawing.Point(246, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // DbToScript
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(523, 382);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Creat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbToScript";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "����SQL���ݿ�ű�";
            this.Load += new System.EventHandler(this.DbToWord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void DbToWord_Load(object sender, System.EventArgs e)
		{			
			
		}

		private void cmbDB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            DbName = cmbDB.Text;
            List<string> tabNames = dbobj.GetTables(DbName);

			this.listTable1.Items.Clear();
			this.listTable2.Items.Clear();

            if (tabNames.Count > 0)
            {
                foreach (string tabname in tabNames)
                {
                    listTable1.Items.Add(tabname);
                }
            }	
			IsHasItem();			
		}

		#region ��ť����

		private void btn_Addlist_Click(object sender, System.EventArgs e)
		{
			int c=this.listTable1.Items.Count;
			for(int i=0;i<c;i++)
			{
				this.listTable2.Items.Add(this.listTable1.Items[i]);
			}
			this.listTable1.Items.Clear();

			IsHasItem();
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
		
			int c=this.listTable1.SelectedItems.Count;			
			ListBox.SelectedObjectCollection objs=this.listTable1.SelectedItems;
			for(int i=0;i<c;i++)
			{
				this.listTable2.Items.Add(listTable1.SelectedItems[i]);
				
			}
			for(int i=0;i<c;i++)
			{
				if(this.listTable1.SelectedItems.Count>0)
				{
					this.listTable1.Items.Remove(listTable1.SelectedItems[0]);
				}
			}
			IsHasItem();
		}

		private void btn_Del_Click(object sender, System.EventArgs e)
		{
			int c=this.listTable2.SelectedItems.Count;			
			ListBox.SelectedObjectCollection objs=this.listTable2.SelectedItems;
			for(int i=0;i<c;i++)
			{
				this.listTable1.Items.Add(listTable2.SelectedItems[i]);
				
			}
			for(int i=0;i<c;i++)
			{
				if(this.listTable2.SelectedItems.Count>0)
				{
					this.listTable2.Items.Remove(listTable2.SelectedItems[0]);
				}
			}
		
			IsHasItem();
		}

		private void btn_Dellist_Click(object sender, System.EventArgs e)
		{
			int c=this.listTable2.Items.Count;
			for(int i=0;i<c;i++)
			{
				this.listTable1.Items.Add(this.listTable2.Items[i]);
			}
			this.listTable2.Items.Clear();
			IsHasItem();			
		}
		#endregion

		#region listbox����
		private void listTable1_DoubleClick(object sender, System.EventArgs e)
		{
		    if (this.listTable1.SelectedItem == null) return;
		    this.listTable2.Items.Add(listTable1.SelectedItem);
		    this.listTable1.Items.Remove(this.listTable1.SelectedItem);
		    IsHasItem();
		}

		private void listTable2_DoubleClick(object sender, System.EventArgs e)
		{
		    if (this.listTable2.SelectedItem == null) return;
		    this.listTable1.Items.Add(listTable2.SelectedItem);
		    this.listTable2.Items.Remove(this.listTable2.SelectedItem);
		    IsHasItem();
		}

		/// <summary>
		/// �ж�listbox��û����Ŀ
		/// </summary>
		private void IsHasItem()
		{
			if(this.listTable1.Items.Count>0)
			{
				this.btn_Add.Enabled=true;
				this.btn_Addlist.Enabled=true;
			}
			else
			{
				this.btn_Add.Enabled=false;
				this.btn_Addlist.Enabled=false;
			}
			if(this.listTable2.Items.Count>0)
			{
				this.btn_Del.Enabled=true;
				this.btn_Dellist.Enabled=true;	
				this.btn_Creat.Enabled=true;
			}
			else
			{
				this.btn_Del.Enabled=false;
				this.btn_Dellist.Enabled=false;	
				this.btn_Creat.Enabled=false;
			}
		}
		#endregion

        #region �첽�ؼ�����
        public void SetBtnEnable()
        {
            if (this.btn_Creat.InvokeRequired)
            {
                SetBtnEnableEventHandler d = new SetBtnEnableEventHandler(SetBtnEnable);
                this.Invoke(d, null);
            }
            else
            {
                this.btn_Creat.Enabled = true;
                this.btn_Cancle.Enabled = true;
            }
        }
        public void SetBtnDisable()
        {
            if (this.btn_Creat.InvokeRequired)
            {
                SetBtnDisableEventHandler d = new SetBtnDisableEventHandler(SetBtnDisable);
                this.Invoke(d, null);
            }
            else
            {
                this.btn_Creat.Enabled = false;
                this.btn_Cancle.Enabled = false;
            }
        }
        public void SetlblStatuText(string text)
        {
            if (this.labelNum.InvokeRequired)
            {
                SetlblStatuEventHandler d = new SetlblStatuEventHandler(SetlblStatuText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelNum.Text = text;
            }
        }
        /// <summary>
        /// ѭ����ַ�������ֵ
        /// </summary>
        /// <param name="val"></param>
        public void SetprogressBar1Max(int val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetProBar1MaxEventHandler d = new SetProBar1MaxEventHandler(SetprogressBar1Max);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.progressBar1.Maximum = val;

            }
        }
        /// <summary>
        /// ѭ����ַ����
        /// </summary>
        /// <param name="val"></param>
        public void SetprogressBar1Val(int val)
        {
            if (this.progressBar1.InvokeRequired)
            {
                SetProBar1ValEventHandler d = new SetProBar1ValEventHandler(SetprogressBar1Val);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.progressBar1.Value = val;

            }
        }
        #endregion

		private void btn_Cancle_Click(object sender, System.EventArgs e)
		{	
			if((mythread!=null)&&(mythread.IsAlive))
			{
				mythread.Abort();
			}
			this.Close();
		}

		private void btn_Creat_Click(object sender, System.EventArgs e)
		{		
			try
			{
				if(this.txtTargetFolder.Text=="")
				{
					MessageBox.Show("��ѡ�񱣴��ļ�·����","���",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
                DbName = this.cmbDB.Text;
                pictureBox1.Visible = true;
                mythread = new Thread(new ThreadStart(ThreadWork));
                mythread.Start();
                //ThreadWork();
			}
			catch(System.Exception ex)
			{
                LogHelper.WriteException(ex);
				MessageBox.Show(ex.Message,"���",MessageBoxButtons.OK,MessageBoxIcon.Stop);
			}
		}
		void ThreadWork()
		{			
			try
			{				
                //this.Cursor=System.Windows.Forms.Cursors.WaitCursor;
                SetBtnDisable();				
				int tblCount=this.listTable2.Items.Count;
				string filename=this.txtTargetFolder.Text;
				
                SetprogressBar1Max(tblCount);
                SetprogressBar1Val(1);
                SetlblStatuText("0");

				#region ѭ��ÿ����

				for(int i=0;i<tblCount;i++)
				{
                    //this.listTable2.SelectedIndex=i;
					string tableName=this.listTable2.Items[i].ToString();
                    dsb.Fieldlist = new List<ColumnInfo>();
                    dsb.CreateTabScript(DbName, tableName, filename, progressBar2);	
									
                    SetprogressBar1Val(i + 1);
                    SetlblStatuText((i + 1).ToString());
				}
				#endregion

                SetBtnEnable();		
                //this.Cursor=System.Windows.Forms.Cursors.Default;
				MessageBox.Show("�ű�ȫ�����ɳɹ���","���",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch(System.Exception ex)
			{
                LogHelper.WriteException(ex);
                SetBtnEnable();
                //this.Cursor=System.Windows.Forms.Cursors.Default;
				MessageBox.Show("�ű�����ʧ�ܣ���������Ƿ�淶���������⵼�¡�("+ex.Message+")","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void btn_TargetFold_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sqlsavedlg = new SaveFileDialog
			{
			    Title = "���浱ǰ�ű�",
			    Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*"
			};
		    DialogResult result=sqlsavedlg.ShowDialog(this);
			if(result==DialogResult.OK)
			{
				this.txtTargetFolder.Text=sqlsavedlg.FileName;
			}	
		}


		
	}
}
