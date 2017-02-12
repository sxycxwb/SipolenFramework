namespace Sipolen.ExcelTools
{
    partial class BrowseNodes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.browse_nodes = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeGridView = new RDIFramework.Controls.UcDataGridView();
            this.NodeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nodeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // browse_nodes
            // 
            this.browse_nodes.Location = new System.Drawing.Point(258, 52);
            this.browse_nodes.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.browse_nodes.Name = "browse_nodes";
            this.browse_nodes.Size = new System.Drawing.Size(475, 31);
            this.browse_nodes.TabIndex = 32;
            this.browse_nodes.TextChanged += new System.EventHandler(this.browse_nodes_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(17, 56);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(220, 21);
            this.label16.TabIndex = 33;
            this.label16.Tag = "";
            this.label16.Text = "输入推荐节点关键字：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(806, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 21);
            this.label1.TabIndex = 34;
            this.label1.Tag = "";
            this.label1.Text = "【提示：双击数据项进行选择】";
            // 
            // nodeGridView
            // 
            this.nodeGridView.AllowUserToOrderColumns = true;
            this.nodeGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nodeGridView.CheckboxFieldName = "colSelected";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nodeGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.nodeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.nodeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NodeId,
            this.NodeDesc,
            this.NodeName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.nodeGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.nodeGridView.EnableHeadersVisualStyles = false;
            this.nodeGridView.Location = new System.Drawing.Point(21, 148);
            this.nodeGridView.Name = "nodeGridView";
            this.nodeGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nodeGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.nodeGridView.RowHeadersWidth = 25;
            this.nodeGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.nodeGridView.RowTemplate.Height = 30;
            this.nodeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.nodeGridView.Size = new System.Drawing.Size(1636, 747);
            this.nodeGridView.TabIndex = 35;
            // 
            // NodeId
            // 
            this.NodeId.DataPropertyName = "NODEID";
            this.NodeId.HeaderText = "节点ID";
            this.NodeId.Name = "NodeId";
            this.NodeId.Width = 200;
            // 
            // NodeDesc
            // 
            this.NodeDesc.DataPropertyName = "NODEDESC";
            this.NodeDesc.HeaderText = "类别名称";
            this.NodeDesc.Name = "NodeDesc";
            this.NodeDesc.Width = 900;
            // 
            // NodeName
            // 
            this.NodeName.DataPropertyName = "NODENAME";
            this.NodeName.HeaderText = "类别英文";
            this.NodeName.Name = "NodeName";
            this.NodeName.Width = 600;
            // 
            // BrowseNodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 907);
            this.Controls.Add(this.nodeGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.browse_nodes);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BrowseNodes";
            this.Text = "推荐节点选择";
            ((System.ComponentModel.ISupportInitialize)(this.nodeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox browse_nodes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private RDIFramework.Controls.UcDataGridView nodeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
    }
}