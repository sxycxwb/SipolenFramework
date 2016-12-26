namespace RDIFramework.Test
{
    partial class FrmFormBindingTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Int1 = new RDIFramework.Controls.UcTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Description = new RDIFramework.Controls.UcTextBox(this.components);
            this.ProductCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.Text2 = new RDIFramework.Controls.UcTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaskText1 = new System.Windows.Forms.MaskedTextBox();
            this.DateTime1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Enabled1 = new System.Windows.Forms.CheckBox();
            this.Text1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnEntityToControl = new System.Windows.Forms.Button();
            this.btnControlToEntity = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Int1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Description);
            this.panel1.Controls.Add(this.ProductCategory);
            this.panel1.Controls.Add(this.Text2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.MaskText1);
            this.panel1.Controls.Add(this.DateTime1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.Enabled1);
            this.panel1.Controls.Add(this.Text1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 174);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "ProductCategory：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "Int1：";
            // 
            // Int1
            // 
            this.Int1.AccessibleName = "";
            this.Int1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Int1.Border.Class = "TextBoxBorder";
            this.Int1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Int1.FocusHighlightEnabled = true;
            this.Int1.Location = new System.Drawing.Point(413, 44);
            this.Int1.Name = "Int1";
            this.Int1.SelectedValue = null;
            this.Int1.Size = new System.Drawing.Size(190, 23);
            this.Int1.TabIndex = 13;
            this.Int1.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Text2：";
            // 
            // Description
            // 
            this.Description.AccessibleName = "EmptyValue";
            this.Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Description.Border.Class = "TextBoxBorder";
            this.Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Description.FocusHighlightEnabled = true;
            this.Description.Location = new System.Drawing.Point(413, 79);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description.SelectedValue = null;
            this.Description.Size = new System.Drawing.Size(199, 0);
            this.Description.TabIndex = 11;
            this.Description.Tag = "";
            // 
            // ProductCategory
            // 
            this.ProductCategory.AccessibleName = "EmptyValue";
            this.ProductCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductCategory.DisplayMember = "Text";
            this.ProductCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductCategory.FormattingEnabled = true;
            this.ProductCategory.ItemHeight = 17;
            this.ProductCategory.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8,
            this.comboItem9});
            this.ProductCategory.Location = new System.Drawing.Point(413, 85);
            this.ProductCategory.Name = "ProductCategory";
            this.ProductCategory.Size = new System.Drawing.Size(197, 23);
            this.ProductCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ProductCategory.TabIndex = 10;
            this.ProductCategory.Tag = "类别";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "先生";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "女士";
            // 
            // Text2
            // 
            this.Text2.AccessibleName = "";
            this.Text2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Text2.Border.Class = "TextBoxBorder";
            this.Text2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text2.FocusHighlightEnabled = true;
            this.Text2.Location = new System.Drawing.Point(413, 15);
            this.Text2.Name = "Text2";
            this.Text2.SelectedValue = null;
            this.Text2.Size = new System.Drawing.Size(190, 23);
            this.Text2.TabIndex = 9;
            this.Text2.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "MaskText1：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "DateTime1：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "comboBox1：";
            // 
            // MaskText1
            // 
            this.MaskText1.Location = new System.Drawing.Point(89, 99);
            this.MaskText1.Mask = "99999.99";
            this.MaskText1.Name = "MaskText1";
            this.MaskText1.Size = new System.Drawing.Size(190, 23);
            this.MaskText1.TabIndex = 5;
            // 
            // DateTime1
            // 
            this.DateTime1.Location = new System.Drawing.Point(89, 69);
            this.DateTime1.Name = "DateTime1";
            this.DateTime1.Size = new System.Drawing.Size(190, 23);
            this.DateTime1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(89, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(190, 22);
            this.comboBox1.TabIndex = 3;
            // 
            // Enabled1
            // 
            this.Enabled1.AutoSize = true;
            this.Enabled1.Location = new System.Drawing.Point(81, 141);
            this.Enabled1.Name = "Enabled1";
            this.Enabled1.Size = new System.Drawing.Size(82, 18);
            this.Enabled1.TabIndex = 2;
            this.Enabled1.Text = "Enabled1";
            this.Enabled1.UseVisualStyleBackColor = true;
            // 
            // Text1
            // 
            this.Text1.Location = new System.Drawing.Point(89, 9);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(190, 23);
            this.Text1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text1：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(12, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 115);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(656, 109);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnEntityToControl
            // 
            this.btnEntityToControl.Location = new System.Drawing.Point(309, 328);
            this.btnEntityToControl.Name = "btnEntityToControl";
            this.btnEntityToControl.Size = new System.Drawing.Size(160, 23);
            this.btnEntityToControl.TabIndex = 2;
            this.btnEntityToControl.Text = "将业务对象绑定到窗体";
            this.btnEntityToControl.UseVisualStyleBackColor = true;
            this.btnEntityToControl.Click += new System.EventHandler(this.btnEntityToControl_Click);
            // 
            // btnControlToEntity
            // 
            this.btnControlToEntity.Location = new System.Drawing.Point(309, 357);
            this.btnControlToEntity.Name = "btnControlToEntity";
            this.btnControlToEntity.Size = new System.Drawing.Size(160, 25);
            this.btnControlToEntity.TabIndex = 3;
            this.btnControlToEntity.Text = "将窗体绑定到业务对象";
            this.btnControlToEntity.UseVisualStyleBackColor = true;
            this.btnControlToEntity.Click += new System.EventHandler(this.btnControlToEntity_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(490, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmFormBindingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 409);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnControlToEntity);
            this.Controls.Add(this.btnEntityToControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmFormBindingTest";
            this.Text = "FrmFormBindingTest";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEntityToControl;
        private System.Windows.Forms.Button btnControlToEntity;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox Text1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTime1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox Enabled1;
        private System.Windows.Forms.MaskedTextBox MaskText1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Controls.UcTextBox Text2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ProductCategory;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private Controls.UcTextBox Description;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Controls.UcTextBox Int1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
    }
}