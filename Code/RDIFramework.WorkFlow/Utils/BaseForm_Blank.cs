using System;
using System.Windows.Forms;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class BaseFrom_Blank : BaseForm
	{
		protected System.Windows.Forms.Panel plbaseTop;
		protected System.Windows.Forms.Panel plbaseFill;
		protected System.Windows.Forms.Label lbbaseTitile;
        private PictureBox pbxTopClient;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseFrom_Blank()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.plbaseTop = new System.Windows.Forms.Panel();
            this.pbxTopClient = new System.Windows.Forms.PictureBox();
            this.lbbaseTitile = new System.Windows.Forms.Label();
            this.plbaseFill = new System.Windows.Forms.Panel();
            this.plbaseTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTopClient)).BeginInit();
            this.SuspendLayout();
            // 
            // plbaseTop
            // 
            this.plbaseTop.BackColor = System.Drawing.SystemColors.Window;
            this.plbaseTop.Controls.Add(this.pbxTopClient);
            this.plbaseTop.Controls.Add(this.lbbaseTitile);
            this.plbaseTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plbaseTop.Location = new System.Drawing.Point(0, 0);
            this.plbaseTop.Name = "plbaseTop";
            this.plbaseTop.Size = new System.Drawing.Size(632, 55);
            this.plbaseTop.TabIndex = 0;
            // 
            // pbxTopClient
            // 
            this.pbxTopClient.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxTopClient.ErrorImage = null;
            this.pbxTopClient.Location = new System.Drawing.Point(167, 0);
            this.pbxTopClient.Name = "pbxTopClient";
            this.pbxTopClient.Size = new System.Drawing.Size(465, 55);
            this.pbxTopClient.TabIndex = 2;
            this.pbxTopClient.TabStop = false;
            // 
            // lbbaseTitile
            // 
            this.lbbaseTitile.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbbaseTitile.Location = new System.Drawing.Point(37, 9);
            this.lbbaseTitile.Name = "lbbaseTitile";
            this.lbbaseTitile.Size = new System.Drawing.Size(117, 26);
            this.lbbaseTitile.TabIndex = 0;
            this.lbbaseTitile.Text = "label1";
            // 
            // plbaseFill
            // 
            this.plbaseFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plbaseFill.Location = new System.Drawing.Point(0, 55);
            this.plbaseFill.Name = "plbaseFill";
            this.plbaseFill.Size = new System.Drawing.Size(632, 390);
            this.plbaseFill.TabIndex = 1;
            // 
            // BaseFrom_Blank
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(632, 445);
            this.Controls.Add(this.plbaseFill);
            this.Controls.Add(this.plbaseTop);
            this.Name = "BaseFrom_Blank";
            this.Text = "BaseFrom_Blank";
            this.plbaseTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTopClient)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new BaseFrom_Blank());
		}
	}
}
