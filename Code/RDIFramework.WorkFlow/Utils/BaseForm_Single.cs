using System;
using RDIFramework.WinForm.Utilities;

namespace RDIFramework.WorkFlow
{
	/// <summary>
	/// BaseForm_Single 的摘要说明。
	/// </summary>
    public class BaseForm_Single : BaseForm
	{
		protected System.Windows.Forms.Panel plclassFill;
        protected System.Windows.Forms.Panel plclassBottom;
        protected Controls.UcButton btnClose;
        protected Controls.UcButton btnSave;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseForm_Single()
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
				if(components != null)
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
            this.plclassFill = new System.Windows.Forms.Panel();
            this.plclassBottom = new System.Windows.Forms.Panel();
            this.btnClose = new RDIFramework.Controls.UcButton();
            this.btnSave = new RDIFramework.Controls.UcButton();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plclassFill.Location = new System.Drawing.Point(0, 0);
            this.plclassFill.Name = "plclassFill";
            this.plclassFill.Size = new System.Drawing.Size(519, 514);
            this.plclassFill.TabIndex = 0;
            // 
            // plclassBottom
            // 
            this.plclassBottom.Controls.Add(this.btnClose);
            this.plclassBottom.Controls.Add(this.btnSave);
            this.plclassBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plclassBottom.Location = new System.Drawing.Point(0, 461);
            this.plclassBottom.Name = "plclassBottom";
            this.plclassBottom.Size = new System.Drawing.Size(519, 53);
            this.plclassBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(427, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&E)";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(327, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BaseForm_Single
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(519, 514);
            this.Controls.Add(this.plclassBottom);
            this.Controls.Add(this.plclassFill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseForm_Single";
            this.Text = "信息维护";
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
	}
}
