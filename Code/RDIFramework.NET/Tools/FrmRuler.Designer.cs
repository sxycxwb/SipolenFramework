namespace RDIFramework.NET
{
    partial class FrmRuler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRuler));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemFlipRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPixels = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemInches = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCentimeters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemFlipRuler,
            this.toolStripMenuItem2,
            this.mnuItemPixels,
            this.mnuItemInches,
            this.mnuItemCentimeters,
            this.toolStripMenuItem1,
            this.mnuItemClose});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(137, 126);
            // 
            // mnuItemFlipRuler
            // 
            this.mnuItemFlipRuler.Name = "mnuItemFlipRuler";
            this.mnuItemFlipRuler.Size = new System.Drawing.Size(136, 22);
            this.mnuItemFlipRuler.Text = "Flip Ruler";
            this.mnuItemFlipRuler.Click += new System.EventHandler(this.mnuItemFlipRuler_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuItemPixels
            // 
            this.mnuItemPixels.Checked = true;
            this.mnuItemPixels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuItemPixels.Name = "mnuItemPixels";
            this.mnuItemPixels.Size = new System.Drawing.Size(136, 22);
            this.mnuItemPixels.Text = "Pixels";
            this.mnuItemPixels.Click += new System.EventHandler(this.mnuItemPixels_Click);
            // 
            // mnuItemInches
            // 
            this.mnuItemInches.Name = "mnuItemInches";
            this.mnuItemInches.Size = new System.Drawing.Size(136, 22);
            this.mnuItemInches.Text = "Inches";
            this.mnuItemInches.Click += new System.EventHandler(this.mnuItemInches_Click);
            // 
            // mnuItemCentimeters
            // 
            this.mnuItemCentimeters.Name = "mnuItemCentimeters";
            this.mnuItemCentimeters.Size = new System.Drawing.Size(136, 22);
            this.mnuItemCentimeters.Text = "Centimeters";
            this.mnuItemCentimeters.Click += new System.EventHandler(this.mnuItemCentimeters_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.Size = new System.Drawing.Size(136, 22);
            this.mnuItemClose.Text = "Close";
            this.mnuItemClose.Click += new System.EventHandler(this.mnuItemClose_Click);
            // 
            // FrmRuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(400, 48);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(54, 48);
            this.Name = "FrmRuler";
            this.ShowInTaskbar = false;
            this.Text = "Ruler";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmRuler_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmRuler_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRuler_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmRuler_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmRuler_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmRuler_MouseUp);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuItemFlipRuler;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPixels;
        private System.Windows.Forms.ToolStripMenuItem mnuItemInches;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCentimeters;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
    }
}