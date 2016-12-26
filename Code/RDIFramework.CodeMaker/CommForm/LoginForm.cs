using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RDIFramework.CodeMaker
{
	/// <summary>
	/// LoginForm ��ժҪ˵����
	/// </summary>
	public class LoginForm : System.Windows.Forms.Form
    {
        #region 
        public System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.TextBox txtUser;
		public System.Windows.Forms.TextBox txtPass;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnConnTest;
		public System.Windows.Forms.ComboBox cmbDBlist;
        #endregion

        DbSettings dbobj=new DbSettings();
		public string constr;
        public ComboBox comboBoxServer;
        public Label label5;
        public ComboBox comboBoxServerVer;
        public Label label6;
        public ComboBox comboBox_Verified;
        public CheckBox chk_Simple;
        private PictureBox pictureBox1;
        private Label label7;
		public string dbName="master";
      
		

		public LoginForm()
		{			
			InitializeComponent();			
		}

		#region Windows Form Designer generated code
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
		public void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDBlist = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chk_Simple = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConnTest = new System.Windows.Forms.Button();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxServerVer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Verified = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "����������(&S)��";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbDBlist
            // 
            this.cmbDBlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBlist.Enabled = false;
            this.cmbDBlist.Location = new System.Drawing.Point(144, 219);
            this.cmbDBlist.Name = "cmbDBlist";
            this.cmbDBlist.Size = new System.Drawing.Size(232, 20);
            this.cmbDBlist.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "���ݿ�(&D)��";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(144, 169);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(232, 21);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "��¼��(&L)��";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(144, 194);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(232, 21);
            this.txtPass.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "����(&P)��";
            // 
            // chk_Simple
            // 
            this.chk_Simple.AutoSize = true;
            this.chk_Simple.Checked = true;
            this.chk_Simple.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Simple.Location = new System.Drawing.Point(144, 244);
            this.chk_Simple.Name = "chk_Simple";
            this.chk_Simple.Size = new System.Drawing.Size(96, 16);
            this.chk_Simple.TabIndex = 22;
            this.chk_Simple.Text = "��Ч����ģʽ";
            this.toolTip1.SetToolTip(this.chk_Simple, "�ڱ�ǳ��������£����ø�ģʽ��������ٶ�");
            this.chk_Simple.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnOk.Location = new System.Drawing.Point(163, 287);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 28);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "ȷ��(&O)";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "ȡ��(&C)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConnTest
            // 
            this.btnConnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnConnTest.Location = new System.Drawing.Point(56, 287);
            this.btnConnTest.Name = "btnConnTest";
            this.btnConnTest.Size = new System.Drawing.Size(80, 28);
            this.btnConnTest.TabIndex = 19;
            this.btnConnTest.Text = "����/����";
            this.btnConnTest.UseVisualStyleBackColor = false;
            this.btnConnTest.Click += new System.EventHandler(this.btnConnTest_Click);
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(144, 97);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(232, 20);
            this.comboBoxServer.TabIndex = 21;
            this.comboBoxServer.Text = "127.0.0.1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "����������(&T)��";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxServerVer
            // 
            this.comboBoxServerVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServerVer.FormattingEnabled = true;
            this.comboBoxServerVer.Items.AddRange(new object[] {
            "SQL Server2008",
            "SQL Server2005",
            "SQL Server2000"});
            this.comboBoxServerVer.Location = new System.Drawing.Point(144, 121);
            this.comboBoxServerVer.Name = "comboBoxServerVer";
            this.comboBoxServerVer.Size = new System.Drawing.Size(232, 20);
            this.comboBoxServerVer.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "�����֤(&A)��";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_Verified
            // 
            this.comboBox_Verified.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Verified.FormattingEnabled = true;
            this.comboBox_Verified.Items.AddRange(new object[] {
            "SQL Server �����֤",
            "Windows �����֤"});
            this.comboBox_Verified.Location = new System.Drawing.Point(144, 145);
            this.comboBox_Verified.Name = "comboBox_Verified";
            this.comboBox_Verified.Size = new System.Drawing.Size(232, 20);
            this.comboBox_Verified.TabIndex = 21;
            this.comboBox_Verified.SelectedIndexChanged += new System.EventHandler(this.comboBox_Verified_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RDIFramework.CodeMaker.Properties.Resources.loginsql;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(11, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(416, 2);
            this.label7.TabIndex = 24;
            this.label7.Text = "������������������������������������������������";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 339);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chk_Simple);
            this.Controls.Add(this.comboBox_Verified);
            this.Controls.Add(this.comboBoxServerVer);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.cmbDBlist);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnConnTest);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���ӵ�������";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

//		protected override void OnClosing(CancelEventArgs e)
//		{				
//			if(this.DialogResult==DialogResult.Cancel)
//			{					
//				this.Close();
//			}	
//			else
//			{
//				e.Cancel = true;
//			}
//			// otherwise, let the framework close the app
//		}


		#endregion

		private void LoginForm_Load(object sender, System.EventArgs e)
		{			
			this.toolTip1.SetToolTip(this.txtUser,"�뱣֤���û�����ÿ�����ݿ�ķ���Ȩ��");
            comboBoxServerVer.SelectedIndex = 0;
            comboBox_Verified.SelectedIndex = 0;
        }

        #region ��������
        /// <summary>
        /// �õ�ѡ��İ汾
        /// </summary>
        /// <returns></returns>
        public string GetSelVer()
        {
            string dbtype = "SQL2005";
            switch (comboBoxServerVer.Text)
            {
                case "SQL Server2000":
                    dbtype= "SQL2000";
                    break;
                case "SQL Server2005":
                    dbtype= "SQL2005";
                    break;
                case "SQL Server2008":
                    dbtype = "SQL2008";
                    break;
                default:
                    dbtype= "SQL2005";
                    break;
            }
            return dbtype;
        }

        /// <summary>
        /// �õ�ѡ��ĵ�¼��֤��ʽ
        /// </summary>
        /// <returns></returns>
        public string GetSelVerified()
        {
            if (comboBox_Verified.SelectedItem.ToString() == "Windows �����֤")
            {
                return "Windows";
            }
            else
            {
                return "SQL";
            }

        }

        /// <summary>
        /// �ж�sql�İ汾
        /// </summary>
        /// <param name="connectionString">���ݿ������ַ���</param>
        /// <returns>��ǰSQL���ݿ�汾��</returns>
        private string GetSQLVer(string connectionString)
        {
            string SQLString = "SELECT SERVERPROPERTY('productversion')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return "";
                        }
                        else
                        {
                            string ver = obj.ToString().Trim();
                            if (ver.Length > 1)
                            {
                                return ver.Substring(0, 1);
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        connection.Close();
                        LogHelper.WriteException(ex);
                        throw ex;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        #endregion

        #region ѡ���������
        private void comboBox_Verified_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GetSelVerified() == "Windows")
            {
                this.label2.Enabled = false;
                this.label3.Enabled = false;
                this.txtUser.Enabled = false;
                this.txtPass.Enabled = false;
            }
            else
            {
                this.label2.Enabled = true;
                this.label3.Enabled = true;
                this.txtUser.Enabled = true;
                this.txtPass.Enabled = true;
            }
        }
		#endregion

		#region ��֤��¼��Ϣ

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			try
			{							
				string server=this.comboBoxServer.Text.Trim();
				string user=this.txtUser.Text.Trim();
				string pass=this.txtPass.Text.Trim();
				if((user=="")||(server==""))
				{
					MessageBox.Show(this,"���������û�������Ϊ�գ�","����",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}				
				
				dbName = this.cmbDBlist.SelectedIndex>0 ? cmbDBlist.Text : "master";

			    constr = GetSelVerified() == "Windows"
			        ? "Integrated Security=SSPI;Data Source=" + server + ";Initial Catalog=" + dbName
			        : (pass == ""
			            ? "user id=" + user + ";initial catalog=" + dbName + ";data source=" + server
			            : "user id=" + user + ";password=" + pass + ";initial catalog=" + dbName + ";data source=" + server);

			    string strtype = GetSelVer();

                #region �жϰ汾 GetSelVer()
                try
                {
                    string ver = GetSQLVer(constr);
                    if ((ver == "8") && (strtype == "SQL2005"))
                    {
                        DialogResult dr = MessageBox.Show(this, "�÷���������SQLServer 2005���Ƿ���и���ѡ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            comboBoxServerVer.SelectedIndex = 2;
                        }
                    }

                    if ((ver == "9") && (strtype == "SQL2000"))
                    {
                        DialogResult dr = MessageBox.Show(this, "�÷���������SQLServer 2000���Ƿ���и���ѡ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            comboBoxServerVer.SelectedIndex = 1;
                        }
                    } 
              
                    if((ver=="10") && (strtype != "SQL2008"))
                    {
                        DialogResult dr = MessageBox.Show(this, "�÷���������SQLServer 2008���Ƿ���и���ѡ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            comboBoxServerVer.SelectedIndex = 0;
                        }
                    }
                }
                catch
                { 
                }
                
                #endregion

                //��������
				var myCn = new SqlConnection(constr);
                try
                {
                    this.Text = "�������ӷ����������Ժ�...";
                    myCn.Open();
                }
                catch(System.Exception ex)
                {
                    this.Text = "���ӷ�����ʧ�ܣ�";                    
                    LogHelper.WriteException(ex);
                    MessageBox.Show(this, "���ӷ�����ʧ�ܣ������������ַ���û��������Ƿ���ȷ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    myCn.Close(); 
                }
				
				this.Text="���ӷ������ɹ���";

                if (dbobj == null)
                {
                    dbobj = new DbSettings();
                }

                //string strtype="SQL2000";
                //if (this.comboBoxServerVer.Text == "SQL Server2005")
                //{
                //    strtype="SQL2005";
                //}
                
				//����ǰ����д�������ļ�
				dbobj.DbType=strtype;
				dbobj.Server=server;
                dbobj.ConnectStr = constr;
                dbobj.DbName = dbName;
                dbobj.ConnectSimple = chk_Simple.Checked;
                bool succ=DbConfig.AddSettings(dbobj);
                if (!succ)
                {
                    MessageBox.Show(this, "�÷������Ѿ����ڣ��������������ַ���������Ƿ���ȷ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
								
				this.DialogResult=DialogResult.OK;
				this.Close();
				
			}
			catch(System.Exception ex)
			{				
				MessageBox.Show(this,ex.Message,"����",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                LogHelper.WriteException(ex);
			}			
		}
		
		#endregion
		
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
        }

        #region ��������
        private void btnConnTest_Click(object sender, System.EventArgs e)
		{
			try
			{
                string server = this.comboBoxServer.Text.Trim();
				string user=this.txtUser.Text.Trim();
				string pass=this.txtPass.Text.Trim();
				if((user=="")||(server==""))
				{
					MessageBox.Show(this,"���������û�������Ϊ�գ�","����",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
			    constr = GetSelVerified() == "Windows"
			        ? "Integrated Security=SSPI;Data Source=" + server + ";Initial Catalog=master"
			        : (pass == ""
			            ? "user id=" + user + ";initial catalog=master;data source=" + server
			            : "user id=" + user + ";password=" + pass + ";initial catalog=master;data source=" + server);

			    string strtype = GetSelVer();	
	
                #region �жϰ汾 GetSelVer()
                try
                {
                    string ver = GetSQLVer(constr);
                    if ((ver == "8") && (strtype == "SQL2005"))
                    {
                        DialogResult dr = MessageBox.Show(this, "�����ݿ�������汾����SQLServer 2005���Ƿ��������ѡ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            //comboBoxServerVer.SelectedIndex = 1;
                            return;
                        }
                    }
                    if ((ver == "9") && (strtype == "SQL2000"))
                    {
                        DialogResult dr = MessageBox.Show(this, "�����ݿ�������汾����SQLServer 2000���Ƿ��������ѡ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            //comboBoxServerVer.SelectedIndex = 0;
                            return;
                        }
                    }
                }
                catch
                {
                }
                #endregion
	
				try
				{
					this.Text="�������ӷ����������Ժ�...";
					
					IDbObject dbobj;                    			
                    dbobj = DBOMaker.CreateDbObj(strtype);
					
					dbobj.DbConnectStr=constr;
                    var dblist = dbobj.GetDBList();
                      
					this.cmbDBlist.Enabled=true;
                    this.cmbDBlist.Items.Clear();
					this.cmbDBlist.Items.Add("ȫ����");
                    if (dblist != null)
                    {
                        if (dblist.Count > 0)
                        {
                            foreach (string dbName in dblist)
                            {
                                this.cmbDBlist.Items.Add(dbName);
                            }
                        }
                    }
					this.cmbDBlist.SelectedIndex=0;
					this.Text="���ӷ������ɹ���";
					
				}
                catch (System.Exception ex)
				{
                    LogHelper.WriteException(ex);
					this.Text="���ӷ��������ȡ������Ϣʧ�ܣ�";
                    string strinfo="���ӷ��������ȡ������Ϣʧ�ܣ�\r\n";
                    strinfo += "�����������ַ���û��������Ƿ���ȷ��\r\n";
                    strinfo += "�������ʧ�ܣ��������������� ��(local)�����ǡ�.�� ���ߡ��������� ��һ�£�\r\n";
                    strinfo+="�����Ҫ�鿴�����ļ��԰�����������⣬��㡰ȷ����������㡰ȡ����";
                    DialogResult drs = MessageBox.Show(this, strinfo, "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (drs == DialogResult.OK)
                    {
                        try
                        {
                            Process proc = new Process();
                            Process.Start("IExplore.exe", "http://www.cnblogs.com/huyong/");
                        }
                        catch
                        {
                            MessageBox.Show("����ʣ�http://www.cnblogs.com/huyong/", "���", MessageBoxButtons.OK, MessageBoxIcon.Information);                            
                        }
                    }
					return;					
				}				
				
			}
			catch(System.Exception ex)
			{
                //LogInfo.WriteLog(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                LogHelper.WriteException(ex);
				MessageBox.Show(this,ex.Message,"����",MessageBoxButtons.OK,MessageBoxIcon.Warning);                
			}

        }
        #endregion
    }
}
