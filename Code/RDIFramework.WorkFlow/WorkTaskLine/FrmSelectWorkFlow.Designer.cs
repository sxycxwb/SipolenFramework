namespace RDIFramework.WorkFlow
{
    partial class FrmSelectWorkFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectWorkFlow));
            this.btnSearch = new RDIFramework.Controls.UcButton();
            this.tbxWorkflowCaption = new RDIFramework.Controls.UcTextBox(this.components);
            this.lblFlowName = new System.Windows.Forms.Label();
            this.lvWorkflow = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.plclassFill.SuspendLayout();
            this.plclassBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // plclassFill
            // 
            this.plclassFill.Controls.Add(this.lvWorkflow);
            this.plclassFill.Controls.Add(this.btnSearch);
            this.plclassFill.Controls.Add(this.tbxWorkflowCaption);
            this.plclassFill.Controls.Add(this.lblFlowName);
            resources.ApplyResources(this.plclassFill, "plclassFill");
            // 
            // plclassBottom
            // 
            resources.ApplyResources(this.plclassBottom, "plclassBottom");
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxWorkflowCaption
            // 
            // 
            // 
            // 
            this.tbxWorkflowCaption.Border.Class = "TextBoxBorder";
            this.tbxWorkflowCaption.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbxWorkflowCaption.FocusHighlightEnabled = true;
            resources.ApplyResources(this.tbxWorkflowCaption, "tbxWorkflowCaption");
            this.tbxWorkflowCaption.Name = "tbxWorkflowCaption";
            this.tbxWorkflowCaption.SelectedValue = ((object)(resources.GetObject("tbxWorkflowCaption.SelectedValue")));
            // 
            // lblFlowName
            // 
            this.lblFlowName.AutoEllipsis = true;
            resources.ApplyResources(this.lblFlowName, "lblFlowName");
            this.lblFlowName.Name = "lblFlowName";
            // 
            // lvWorkflow
            // 
            // 
            // 
            // 
            this.lvWorkflow.Border.Class = "ListViewBorder";
            this.lvWorkflow.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lvWorkflow.FullRowSelect = true;
            resources.ApplyResources(this.lvWorkflow, "lvWorkflow");
            this.lvWorkflow.MultiSelect = false;
            this.lvWorkflow.Name = "lvWorkflow";
            this.lvWorkflow.UseCompatibleStateImageBehavior = false;
            this.lvWorkflow.View = System.Windows.Forms.View.Details;
            // 
            // FrmSelectWorkFlow
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "FrmSelectWorkFlow";
            this.Load += new System.EventHandler(this.FrmSelectWorkFlow_Load);
            this.plclassFill.ResumeLayout(false);
            this.plclassBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcButton btnSearch;
        private Controls.UcTextBox tbxWorkflowCaption;
        private System.Windows.Forms.Label lblFlowName;
        public DevComponents.DotNetBar.Controls.ListViewEx lvWorkflow;
    }
}
