namespace RDIFramework.WorkFlow
{
    partial class FrmAttachment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAttachment));
            this.pnlTool = new System.Windows.Forms.Panel();
            this.btnUpload = new RDIFramework.Controls.UcButton();
            this.btnDelete = new RDIFramework.Controls.UcButton();
            this.btnDownLoad = new RDIFramework.Controls.UcButton();
            this.btnRefreash = new RDIFramework.Controls.UcButton();
            this.ucComboBoxEx1 = new RDIFramework.Controls.UcComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvAttachment = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.pnlTool.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTool
            // 
            resources.ApplyResources(this.pnlTool, "pnlTool");
            this.pnlTool.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlTool.Controls.Add(this.btnUpload);
            this.pnlTool.Controls.Add(this.btnDelete);
            this.pnlTool.Controls.Add(this.btnDownLoad);
            this.pnlTool.Controls.Add(this.btnRefreash);
            this.pnlTool.Controls.Add(this.ucComboBoxEx1);
            this.pnlTool.Controls.Add(this.label1);
            this.pnlTool.Name = "pnlTool";
            // 
            // btnUpload
            // 
            resources.ApplyResources(this.btnUpload, "btnUpload");
            this.btnUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDownLoad
            // 
            resources.ApplyResources(this.btnDownLoad, "btnDownLoad");
            this.btnDownLoad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDownLoad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // btnRefreash
            // 
            resources.ApplyResources(this.btnRefreash, "btnRefreash");
            this.btnRefreash.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefreash.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefreash.Name = "btnRefreash";
            this.btnRefreash.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRefreash.Click += new System.EventHandler(this.btnRefreash_Click);
            // 
            // ucComboBoxEx1
            // 
            resources.ApplyResources(this.ucComboBoxEx1, "ucComboBoxEx1");
            this.ucComboBoxEx1.DisplayMember = "Text";
            this.ucComboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ucComboBoxEx1.FormattingEnabled = true;
            this.ucComboBoxEx1.Name = "ucComboBoxEx1";
            this.ucComboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.lvAttachment);
            this.panel2.Name = "panel2";
            // 
            // lvAttachment
            // 
            resources.ApplyResources(this.lvAttachment, "lvAttachment");
            // 
            // 
            // 
            this.lvAttachment.Border.Class = "ListViewBorder";
            this.lvAttachment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvAttachment.Name = "lvAttachment";
            this.lvAttachment.UseCompatibleStateImageBehavior = false;
            this.lvAttachment.View = System.Windows.Forms.View.Details;
            // 
            // FrmAttachment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTool);
            this.Name = "FrmAttachment";
            this.Load += new System.EventHandler(this.FrmAttachment_Load);
            this.pnlTool.ResumeLayout(false);
            this.pnlTool.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTool;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Controls.UcComboBoxEx ucComboBoxEx1;
        private Controls.UcButton btnUpload;
        private Controls.UcButton btnDelete;
        private Controls.UcButton btnDownLoad;
        private Controls.UcButton btnRefreash;
        private DevComponents.DotNetBar.Controls.ListViewEx lvAttachment;
    }
}