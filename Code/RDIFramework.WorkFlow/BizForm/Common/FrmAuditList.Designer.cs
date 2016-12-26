namespace RDIFramework.WorkFlow
{
    partial class FrmAuditList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAuditList = new RDIFramework.Controls.UcDataGridView();
            this.colAUDITTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAUDITUSERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAUDITARCH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAUDITDUTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAUDITRESULT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMESSAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAUDITUSERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAuditList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 563);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "审批列表";
            // 
            // dgvAuditList
            // 
            this.dgvAuditList.AllowUserToAddRows = false;
            this.dgvAuditList.AllowUserToDeleteRows = false;
            this.dgvAuditList.AllowUserToOrderColumns = true;
            this.dgvAuditList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAuditList.ColumnHeadersHeight = 26;
            this.dgvAuditList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAuditList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAUDITTIME,
            this.colAUDITUSERNAME,
            this.colAUDITARCH,
            this.colAUDITDUTY,
            this.colAUDITRESULT,
            this.colMESSAGE,
            this.colAUDITUSERID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAuditList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAuditList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditList.EnableHeadersVisualStyles = false;
            this.dgvAuditList.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvAuditList.Location = new System.Drawing.Point(3, 19);
            this.dgvAuditList.Name = "dgvAuditList";
            this.dgvAuditList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAuditList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAuditList.RowHeadersWidth = 30;
            this.dgvAuditList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAuditList.RowTemplate.Height = 23;
            this.dgvAuditList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAuditList.Size = new System.Drawing.Size(836, 541);
            this.dgvAuditList.TabIndex = 6;
            // 
            // colAUDITTIME
            // 
            this.colAUDITTIME.DataPropertyName = "AUDITTIME";
            this.colAUDITTIME.HeaderText = "审批时间";
            this.colAUDITTIME.Name = "colAUDITTIME";
            this.colAUDITTIME.Width = 150;
            // 
            // colAUDITUSERNAME
            // 
            this.colAUDITUSERNAME.DataPropertyName = "AUDITUSERNAME";
            this.colAUDITUSERNAME.HeaderText = "审批人";
            this.colAUDITUSERNAME.Name = "colAUDITUSERNAME";
            this.colAUDITUSERNAME.Width = 120;
            // 
            // colAUDITARCH
            // 
            this.colAUDITARCH.DataPropertyName = "AUDITARCH";
            this.colAUDITARCH.HeaderText = "部门";
            this.colAUDITARCH.Name = "colAUDITARCH";
            this.colAUDITARCH.Width = 180;
            // 
            // colAUDITDUTY
            // 
            this.colAUDITDUTY.DataPropertyName = "AUDITDUTY";
            this.colAUDITDUTY.HeaderText = "职务";
            this.colAUDITDUTY.Name = "colAUDITDUTY";
            this.colAUDITDUTY.Width = 150;
            // 
            // colAUDITRESULT
            // 
            this.colAUDITRESULT.DataPropertyName = "AUDITRESULT";
            this.colAUDITRESULT.HeaderText = "审批结果";
            this.colAUDITRESULT.Name = "colAUDITRESULT";
            this.colAUDITRESULT.Width = 150;
            // 
            // colMESSAGE
            // 
            this.colMESSAGE.DataPropertyName = "MESSAGE";
            this.colMESSAGE.HeaderText = "审批意见";
            this.colMESSAGE.Name = "colMESSAGE";
            this.colMESSAGE.Width = 300;
            // 
            // colAUDITUSERID
            // 
            this.colAUDITUSERID.DataPropertyName = "AUDITUSERID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colAUDITUSERID.DefaultCellStyle = dataGridViewCellStyle2;
            this.colAUDITUSERID.HeaderText = "审批人Id";
            this.colAUDITUSERID.Name = "colAUDITUSERID";
            this.colAUDITUSERID.Width = 150;
            // 
            // FrmAuditList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 573);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAuditList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "审批列表";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.UcDataGridView dgvAuditList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAUDITTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAUDITUSERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAUDITARCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAUDITDUTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAUDITRESULT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMESSAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAUDITUSERID;
    }
}