namespace RDIFramework.NET
{
    partial class FrmRegexTester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegexTester));
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.sbpStatus = new System.Windows.Forms.StatusBarPanel();
            this.sbpMatches = new System.Windows.Forms.StatusBarPanel();
            this.sbpExecutionTime = new System.Windows.Forms.StatusBarPanel();
            this.sbpContext = new System.Windows.Forms.StatusBarPanel();
            this.regExLibraryButton = new System.Windows.Forms.Button();
            this.regExCheatSheetButton = new System.Windows.Forms.Button();
            this.resultsListLabel = new System.Windows.Forms.Label();
            this.copyButtonContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyGeneric0MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGeneric1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGeneric2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyGeneric3MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lengthColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.exportResultsButton = new System.Windows.Forms.Button();
            this.replaceModeButton = new System.Windows.Forms.Button();
            this.indentedInputButton = new System.Windows.Forms.Button();
            this.resultListView = new System.Windows.Forms.ListView();
            this.matchColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.positionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.singleLineButton = new System.Windows.Forms.Button();
            this.multiLineButton = new System.Windows.Forms.Button();
            this.cultureInvariantButton = new System.Windows.Forms.Button();
            this.ignoreCaseButton = new System.Windows.Forms.Button();
            this.exportSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.replaceModeCheckBox = new System.Windows.Forms.CheckBox();
            this.indentedInputCheckBox = new System.Windows.Forms.CheckBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.singleLineCheckBox = new System.Windows.Forms.CheckBox();
            this.multiLineCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.topAndMiddleSplitContainer = new System.Windows.Forms.SplitContainer();
            this.cultureInvariantCheckBox = new System.Windows.Forms.CheckBox();
            this.regExAndRepExSplitContainer = new System.Windows.Forms.SplitContainer();
            this.regExLabel = new System.Windows.Forms.Label();
            this.regExTextBox = new System.Windows.Forms.TextBox();
            this.repExLabel = new System.Windows.Forms.Label();
            this.repExTextBox = new System.Windows.Forms.TextBox();
            this.middleAndBottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.textAndResultsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.textRichTextBox = new RDIFramework.Controls.UcRichTextBoxEx();
            this.resultsRichTextBox = new RDIFramework.Controls.UcRichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.sbpStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpExecutionTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpContext)).BeginInit();
            this.copyButtonContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topAndMiddleSplitContainer)).BeginInit();
            this.topAndMiddleSplitContainer.Panel1.SuspendLayout();
            this.topAndMiddleSplitContainer.Panel2.SuspendLayout();
            this.topAndMiddleSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regExAndRepExSplitContainer)).BeginInit();
            this.regExAndRepExSplitContainer.Panel1.SuspendLayout();
            this.regExAndRepExSplitContainer.Panel2.SuspendLayout();
            this.regExAndRepExSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.middleAndBottomSplitContainer)).BeginInit();
            this.middleAndBottomSplitContainer.Panel1.SuspendLayout();
            this.middleAndBottomSplitContainer.Panel2.SuspendLayout();
            this.middleAndBottomSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textAndResultsSplitContainer)).BeginInit();
            this.textAndResultsSplitContainer.Panel1.SuspendLayout();
            this.textAndResultsSplitContainer.Panel2.SuspendLayout();
            this.textAndResultsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 517);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpStatus,
            this.sbpMatches,
            this.sbpExecutionTime,
            this.sbpContext});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(858, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusBar";
            // 
            // sbpStatus
            // 
            this.sbpStatus.Name = "sbpStatus";
            this.sbpStatus.Text = "Nothing searched yet.";
            this.sbpStatus.Width = 812;
            // 
            // sbpMatches
            // 
            this.sbpMatches.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpMatches.MinWidth = 0;
            this.sbpMatches.Name = "sbpMatches";
            this.sbpMatches.Width = 10;
            // 
            // sbpExecutionTime
            // 
            this.sbpExecutionTime.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpExecutionTime.MinWidth = 0;
            this.sbpExecutionTime.Name = "sbpExecutionTime";
            this.sbpExecutionTime.Width = 10;
            // 
            // sbpContext
            // 
            this.sbpContext.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbpContext.MinWidth = 0;
            this.sbpContext.Name = "sbpContext";
            this.sbpContext.Width = 10;
            // 
            // regExLibraryButton
            // 
            this.regExLibraryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regExLibraryButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.regExLibraryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regExLibraryButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regExLibraryButton.ForeColor = System.Drawing.Color.Blue;
            this.regExLibraryButton.Location = new System.Drawing.Point(312, -4);
            this.regExLibraryButton.Name = "regExLibraryButton";
            this.regExLibraryButton.Size = new System.Drawing.Size(102, 25);
            this.regExLibraryButton.TabIndex = 30;
            this.regExLibraryButton.Text = "RegEx Library";
            this.regExLibraryButton.UseVisualStyleBackColor = true;
            this.regExLibraryButton.Click += new System.EventHandler(this.regExLibraryButton_Click);
            // 
            // regExCheatSheetButton
            // 
            this.regExCheatSheetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regExCheatSheetButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.regExCheatSheetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regExCheatSheetButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regExCheatSheetButton.ForeColor = System.Drawing.Color.Blue;
            this.regExCheatSheetButton.Location = new System.Drawing.Point(189, -4);
            this.regExCheatSheetButton.Name = "regExCheatSheetButton";
            this.regExCheatSheetButton.Size = new System.Drawing.Size(127, 25);
            this.regExCheatSheetButton.TabIndex = 28;
            this.regExCheatSheetButton.Text = "RegEx CheatSheet";
            this.regExCheatSheetButton.UseVisualStyleBackColor = true;
            this.regExCheatSheetButton.Click += new System.EventHandler(this.regExCheatSheetButton_Click);
            // 
            // resultsListLabel
            // 
            this.resultsListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsListLabel.Location = new System.Drawing.Point(8, 9);
            this.resultsListLabel.Name = "resultsListLabel";
            this.resultsListLabel.Size = new System.Drawing.Size(836, 15);
            this.resultsListLabel.TabIndex = 0;
            this.resultsListLabel.Text = "Test Results";
            // 
            // copyButtonContextMenu
            // 
            this.copyButtonContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyGeneric0MenuItem,
            this.copyGeneric1MenuItem,
            this.copyGeneric2MenuItem,
            this.copyGeneric3MenuItem});
            this.copyButtonContextMenu.Name = "btnCopyContextMenuStrip";
            this.copyButtonContextMenu.Size = new System.Drawing.Size(173, 92);
            // 
            // copyGeneric0MenuItem
            // 
            this.copyGeneric0MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyGeneric0MenuItem.Image")));
            this.copyGeneric0MenuItem.Name = "copyGeneric0MenuItem";
            this.copyGeneric0MenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyGeneric0MenuItem.Tag = "csharp snippet";
            this.copyGeneric0MenuItem.Text = "C# code &snippet";
            this.copyGeneric0MenuItem.Click += new System.EventHandler(this.copyGeneric0MenuItem_Click);
            // 
            // copyGeneric1MenuItem
            // 
            this.copyGeneric1MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyGeneric1MenuItem.Image")));
            this.copyGeneric1MenuItem.Name = "copyGeneric1MenuItem";
            this.copyGeneric1MenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyGeneric1MenuItem.Tag = "csharp";
            this.copyGeneric1MenuItem.Text = "&C# escaped string";
            // 
            // copyGeneric2MenuItem
            // 
            this.copyGeneric2MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyGeneric2MenuItem.Image")));
            this.copyGeneric2MenuItem.Name = "copyGeneric2MenuItem";
            this.copyGeneric2MenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyGeneric2MenuItem.Tag = "html";
            this.copyGeneric2MenuItem.Text = "&HTML encoded";
            // 
            // copyGeneric3MenuItem
            // 
            this.copyGeneric3MenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyGeneric3MenuItem.Image")));
            this.copyGeneric3MenuItem.Name = "copyGeneric3MenuItem";
            this.copyGeneric3MenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyGeneric3MenuItem.Tag = "plain";
            this.copyGeneric3MenuItem.Text = "&Plain text";
            // 
            // lengthColumnHeader
            // 
            this.lengthColumnHeader.Text = "Length";
            // 
            // exportResultsButton
            // 
            this.exportResultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportResultsButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.exportResultsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportResultsButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportResultsButton.ForeColor = System.Drawing.Color.Blue;
            this.exportResultsButton.Location = new System.Drawing.Point(739, 1);
            this.exportResultsButton.Name = "exportResultsButton";
            this.exportResultsButton.Size = new System.Drawing.Size(102, 25);
            this.exportResultsButton.TabIndex = 32;
            this.exportResultsButton.Text = "Export Results (CSV)";
            this.exportResultsButton.UseVisualStyleBackColor = true;
            this.exportResultsButton.Click += new System.EventHandler(this.exportResultsButton_Click);
            // 
            // replaceModeButton
            // 
            this.replaceModeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceModeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.replaceModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaceModeButton.ForeColor = System.Drawing.Color.Blue;
            this.replaceModeButton.Location = new System.Drawing.Point(375, 73);
            this.replaceModeButton.Name = "replaceModeButton";
            this.replaceModeButton.Size = new System.Drawing.Size(22, 22);
            this.replaceModeButton.TabIndex = 24;
            this.replaceModeButton.Text = "?";
            this.replaceModeButton.UseVisualStyleBackColor = true;
            this.replaceModeButton.Click += new System.EventHandler(this.replaceModeButton_Click);
            // 
            // indentedInputButton
            // 
            this.indentedInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.indentedInputButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.indentedInputButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.indentedInputButton.ForeColor = System.Drawing.Color.Blue;
            this.indentedInputButton.Location = new System.Drawing.Point(380, 51);
            this.indentedInputButton.Name = "indentedInputButton";
            this.indentedInputButton.Size = new System.Drawing.Size(22, 22);
            this.indentedInputButton.TabIndex = 23;
            this.indentedInputButton.Text = "?";
            this.indentedInputButton.UseVisualStyleBackColor = true;
            this.indentedInputButton.Click += new System.EventHandler(this.indentedInputButton_Click);
            // 
            // resultListView
            // 
            this.resultListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.matchColumnHeader,
            this.positionColumnHeader,
            this.lengthColumnHeader});
            this.resultListView.FullRowSelect = true;
            this.resultListView.GridLines = true;
            this.resultListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultListView.HideSelection = false;
            this.resultListView.Location = new System.Drawing.Point(11, 27);
            this.resultListView.MultiSelect = false;
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(833, 135);
            this.resultListView.TabIndex = 1;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            this.resultListView.SelectedIndexChanged += new System.EventHandler(this.resultListView_SelectedIndexChanged);
            // 
            // matchColumnHeader
            // 
            this.matchColumnHeader.Text = "Match";
            this.matchColumnHeader.Width = 350;
            // 
            // positionColumnHeader
            // 
            this.positionColumnHeader.Text = "Position";
            // 
            // singleLineButton
            // 
            this.singleLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.singleLineButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.singleLineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.singleLineButton.ForeColor = System.Drawing.Color.Blue;
            this.singleLineButton.Location = new System.Drawing.Point(243, 73);
            this.singleLineButton.Name = "singleLineButton";
            this.singleLineButton.Size = new System.Drawing.Size(22, 22);
            this.singleLineButton.TabIndex = 22;
            this.singleLineButton.Text = "?";
            this.singleLineButton.UseVisualStyleBackColor = true;
            this.singleLineButton.Click += new System.EventHandler(this.singleLineButton_Click);
            // 
            // multiLineButton
            // 
            this.multiLineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.multiLineButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.multiLineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiLineButton.ForeColor = System.Drawing.Color.Blue;
            this.multiLineButton.Location = new System.Drawing.Point(232, 51);
            this.multiLineButton.Name = "multiLineButton";
            this.multiLineButton.Size = new System.Drawing.Size(22, 22);
            this.multiLineButton.TabIndex = 21;
            this.multiLineButton.Text = "?";
            this.multiLineButton.UseVisualStyleBackColor = true;
            this.multiLineButton.Click += new System.EventHandler(this.multiLineButton_Click);
            // 
            // cultureInvariantButton
            // 
            this.cultureInvariantButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cultureInvariantButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.cultureInvariantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cultureInvariantButton.ForeColor = System.Drawing.Color.Blue;
            this.cultureInvariantButton.Location = new System.Drawing.Point(130, 73);
            this.cultureInvariantButton.Name = "cultureInvariantButton";
            this.cultureInvariantButton.Size = new System.Drawing.Size(22, 22);
            this.cultureInvariantButton.TabIndex = 20;
            this.cultureInvariantButton.Text = "?";
            this.cultureInvariantButton.UseVisualStyleBackColor = true;
            this.cultureInvariantButton.Click += new System.EventHandler(this.cultureInvariantButton_Click);
            // 
            // ignoreCaseButton
            // 
            this.ignoreCaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreCaseButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ignoreCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ignoreCaseButton.ForeColor = System.Drawing.Color.Blue;
            this.ignoreCaseButton.Location = new System.Drawing.Point(102, 51);
            this.ignoreCaseButton.Name = "ignoreCaseButton";
            this.ignoreCaseButton.Size = new System.Drawing.Size(22, 22);
            this.ignoreCaseButton.TabIndex = 19;
            this.ignoreCaseButton.Text = "?";
            this.ignoreCaseButton.UseVisualStyleBackColor = true;
            this.ignoreCaseButton.Click += new System.EventHandler(this.ignoreCaseButton_Click);
            // 
            // exportSaveFileDialog
            // 
            this.exportSaveFileDialog.DefaultExt = "csv";
            this.exportSaveFileDialog.Filter = "Comma Separated Values|*.csv|All files|*.*";
            // 
            // replaceModeCheckBox
            // 
            this.replaceModeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceModeCheckBox.CausesValidation = false;
            this.replaceModeCheckBox.Checked = true;
            this.replaceModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.replaceModeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.replaceModeCheckBox.Location = new System.Drawing.Point(275, 73);
            this.replaceModeCheckBox.Name = "replaceModeCheckBox";
            this.replaceModeCheckBox.Size = new System.Drawing.Size(127, 22);
            this.replaceModeCheckBox.TabIndex = 15;
            this.replaceModeCheckBox.Text = "Replace mode";
            this.replaceModeCheckBox.CheckedChanged += new System.EventHandler(this.replaceModeCheckBox_CheckedChanged);
            // 
            // indentedInputCheckBox
            // 
            this.indentedInputCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.indentedInputCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.indentedInputCheckBox.Location = new System.Drawing.Point(275, 51);
            this.indentedInputCheckBox.Name = "indentedInputCheckBox";
            this.indentedInputCheckBox.Size = new System.Drawing.Size(127, 22);
            this.indentedInputCheckBox.TabIndex = 13;
            this.indentedInputCheckBox.Text = "Indented Input";
            this.indentedInputCheckBox.CheckedChanged += new System.EventHandler(this.indentedInputCheckBox_CheckedChanged);
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Location = new System.Drawing.Point(671, 56);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 34);
            this.copyButton.TabIndex = 17;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // resultsLabel
            // 
            this.resultsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsLabel.Location = new System.Drawing.Point(8, 3);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(404, 16);
            this.resultsLabel.TabIndex = 2;
            this.resultsLabel.Text = "Test Results";
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton.Location = new System.Drawing.Point(752, 56);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(92, 34);
            this.testButton.TabIndex = 18;
            this.testButton.Text = "Test [F5]";
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // singleLineCheckBox
            // 
            this.singleLineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.singleLineCheckBox.Checked = true;
            this.singleLineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.singleLineCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.singleLineCheckBox.Location = new System.Drawing.Point(160, 73);
            this.singleLineCheckBox.Name = "singleLineCheckBox";
            this.singleLineCheckBox.Size = new System.Drawing.Size(109, 22);
            this.singleLineCheckBox.TabIndex = 11;
            this.singleLineCheckBox.Text = "Single Line";
            // 
            // multiLineCheckBox
            // 
            this.multiLineCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.multiLineCheckBox.Checked = true;
            this.multiLineCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.multiLineCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.multiLineCheckBox.Location = new System.Drawing.Point(160, 51);
            this.multiLineCheckBox.Name = "multiLineCheckBox";
            this.multiLineCheckBox.Size = new System.Drawing.Size(109, 22);
            this.multiLineCheckBox.TabIndex = 9;
            this.multiLineCheckBox.Text = "Multi Line";
            // 
            // ignoreCaseCheckBox
            // 
            this.ignoreCaseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ignoreCaseCheckBox.Checked = true;
            this.ignoreCaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreCaseCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ignoreCaseCheckBox.Location = new System.Drawing.Point(11, 51);
            this.ignoreCaseCheckBox.Name = "ignoreCaseCheckBox";
            this.ignoreCaseCheckBox.Size = new System.Drawing.Size(142, 22);
            this.ignoreCaseCheckBox.TabIndex = 5;
            this.ignoreCaseCheckBox.Text = "Ignore Case";
            // 
            // textLabel
            // 
            this.textLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textLabel.Location = new System.Drawing.Point(9, 3);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(400, 16);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "Test Text";
            // 
            // topAndMiddleSplitContainer
            // 
            this.topAndMiddleSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topAndMiddleSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topAndMiddleSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.topAndMiddleSplitContainer.IsSplitterFixed = true;
            this.topAndMiddleSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.topAndMiddleSplitContainer.Name = "topAndMiddleSplitContainer";
            this.topAndMiddleSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // topAndMiddleSplitContainer.Panel1
            // 
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.replaceModeButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.indentedInputButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.singleLineButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.multiLineButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.cultureInvariantButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.ignoreCaseButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.replaceModeCheckBox);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.indentedInputCheckBox);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.copyButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.testButton);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.singleLineCheckBox);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.multiLineCheckBox);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.ignoreCaseCheckBox);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.cultureInvariantCheckBox);
            this.topAndMiddleSplitContainer.Panel1.Controls.Add(this.regExAndRepExSplitContainer);
            this.topAndMiddleSplitContainer.Panel1MinSize = 100;
            // 
            // topAndMiddleSplitContainer.Panel2
            // 
            this.topAndMiddleSplitContainer.Panel2.Controls.Add(this.middleAndBottomSplitContainer);
            this.topAndMiddleSplitContainer.Size = new System.Drawing.Size(858, 539);
            this.topAndMiddleSplitContainer.SplitterDistance = 100;
            this.topAndMiddleSplitContainer.TabIndex = 2;
            // 
            // cultureInvariantCheckBox
            // 
            this.cultureInvariantCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cultureInvariantCheckBox.Checked = true;
            this.cultureInvariantCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cultureInvariantCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cultureInvariantCheckBox.Location = new System.Drawing.Point(11, 73);
            this.cultureInvariantCheckBox.Name = "cultureInvariantCheckBox";
            this.cultureInvariantCheckBox.Size = new System.Drawing.Size(142, 22);
            this.cultureInvariantCheckBox.TabIndex = 7;
            this.cultureInvariantCheckBox.Text = "Culture Invariant";
            // 
            // regExAndRepExSplitContainer
            // 
            this.regExAndRepExSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.regExAndRepExSplitContainer.Location = new System.Drawing.Point(11, 5);
            this.regExAndRepExSplitContainer.Name = "regExAndRepExSplitContainer";
            // 
            // regExAndRepExSplitContainer.Panel1
            // 
            this.regExAndRepExSplitContainer.Panel1.Controls.Add(this.regExLabel);
            this.regExAndRepExSplitContainer.Panel1.Controls.Add(this.regExTextBox);
            // 
            // regExAndRepExSplitContainer.Panel2
            // 
            this.regExAndRepExSplitContainer.Panel2.Controls.Add(this.regExLibraryButton);
            this.regExAndRepExSplitContainer.Panel2.Controls.Add(this.regExCheatSheetButton);
            this.regExAndRepExSplitContainer.Panel2.Controls.Add(this.repExLabel);
            this.regExAndRepExSplitContainer.Panel2.Controls.Add(this.repExTextBox);
            this.regExAndRepExSplitContainer.Size = new System.Drawing.Size(833, 42);
            this.regExAndRepExSplitContainer.SplitterDistance = 414;
            this.regExAndRepExSplitContainer.TabIndex = 4;
            // 
            // regExLabel
            // 
            this.regExLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.regExLabel.Location = new System.Drawing.Point(0, 3);
            this.regExLabel.Name = "regExLabel";
            this.regExLabel.Size = new System.Drawing.Size(414, 16);
            this.regExLabel.TabIndex = 1;
            this.regExLabel.Text = "Regular Expression";
            // 
            // regExTextBox
            // 
            this.regExTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.regExTextBox.HideSelection = false;
            this.regExTextBox.Location = new System.Drawing.Point(0, 21);
            this.regExTextBox.Name = "regExTextBox";
            this.regExTextBox.Size = new System.Drawing.Size(414, 21);
            this.regExTextBox.TabIndex = 0;
            // 
            // repExLabel
            // 
            this.repExLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repExLabel.Location = new System.Drawing.Point(0, 3);
            this.repExLabel.Name = "repExLabel";
            this.repExLabel.Size = new System.Drawing.Size(418, 16);
            this.repExLabel.TabIndex = 2;
            this.repExLabel.Text = "Replacement Expression";
            // 
            // repExTextBox
            // 
            this.repExTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repExTextBox.HideSelection = false;
            this.repExTextBox.Location = new System.Drawing.Point(0, 21);
            this.repExTextBox.Name = "repExTextBox";
            this.repExTextBox.Size = new System.Drawing.Size(414, 21);
            this.repExTextBox.TabIndex = 0;
            // 
            // middleAndBottomSplitContainer
            // 
            this.middleAndBottomSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.middleAndBottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleAndBottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.middleAndBottomSplitContainer.Name = "middleAndBottomSplitContainer";
            this.middleAndBottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // middleAndBottomSplitContainer.Panel1
            // 
            this.middleAndBottomSplitContainer.Panel1.Controls.Add(this.textAndResultsSplitContainer);
            this.middleAndBottomSplitContainer.Panel1MinSize = 61;
            // 
            // middleAndBottomSplitContainer.Panel2
            // 
            this.middleAndBottomSplitContainer.Panel2.Controls.Add(this.exportResultsButton);
            this.middleAndBottomSplitContainer.Panel2.Controls.Add(this.resultListView);
            this.middleAndBottomSplitContainer.Panel2.Controls.Add(this.resultsListLabel);
            this.middleAndBottomSplitContainer.Panel2MinSize = 89;
            this.middleAndBottomSplitContainer.Size = new System.Drawing.Size(858, 435);
            this.middleAndBottomSplitContainer.SplitterDistance = 250;
            this.middleAndBottomSplitContainer.TabIndex = 0;
            // 
            // textAndResultsSplitContainer
            // 
            this.textAndResultsSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textAndResultsSplitContainer.Location = new System.Drawing.Point(11, 9);
            this.textAndResultsSplitContainer.Name = "textAndResultsSplitContainer";
            // 
            // textAndResultsSplitContainer.Panel1
            // 
            this.textAndResultsSplitContainer.Panel1.Controls.Add(this.textRichTextBox);
            this.textAndResultsSplitContainer.Panel1.Controls.Add(this.textLabel);
            // 
            // textAndResultsSplitContainer.Panel2
            // 
            this.textAndResultsSplitContainer.Panel2.Controls.Add(this.resultsRichTextBox);
            this.textAndResultsSplitContainer.Panel2.Controls.Add(this.resultsLabel);
            this.textAndResultsSplitContainer.Size = new System.Drawing.Size(834, 225);
            this.textAndResultsSplitContainer.SplitterDistance = 414;
            this.textAndResultsSplitContainer.TabIndex = 1;
            // 
            // textRichTextBox
            // 
            this.textRichTextBox.AlignCenterVisible = false;
            this.textRichTextBox.AlignLeftVisible = false;
            this.textRichTextBox.AlignRightVisible = false;
            this.textRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textRichTextBox.BoldVisible = false;
            this.textRichTextBox.BulletsVisible = false;
            this.textRichTextBox.ChooseFontVisible = false;
            this.textRichTextBox.FindReplaceVisible = false;
            this.textRichTextBox.FontColorVisible = false;
            this.textRichTextBox.FontFamilyVisible = false;
            this.textRichTextBox.FontSizeVisible = false;
            this.textRichTextBox.GroupAlignmentVisible = false;
            this.textRichTextBox.GroupBoldUnderlineItalicVisible = false;
            this.textRichTextBox.GroupFontColorVisible = false;
            this.textRichTextBox.GroupFontNameAndSizeVisible = false;
            this.textRichTextBox.GroupIndentationAndBulletsVisible = false;
            this.textRichTextBox.GroupInsertVisible = false;
            this.textRichTextBox.GroupSaveAndLoadVisible = false;
            this.textRichTextBox.GroupZoomVisible = false;
            this.textRichTextBox.INDENT = 10;
            this.textRichTextBox.IndentVisible = false;
            this.textRichTextBox.InsertPictureVisible = false;
            this.textRichTextBox.ItalicVisible = false;
            this.textRichTextBox.LoadVisible = false;
            this.textRichTextBox.Location = new System.Drawing.Point(9, 19);
            this.textRichTextBox.Name = "textRichTextBox";
            this.textRichTextBox.OutdentVisible = false;
            this.textRichTextBox.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
                "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs21\\par\r\n}\r\n";
            this.textRichTextBox.SaveVisible = false;
            this.textRichTextBox.SelectionColor = System.Drawing.Color.Black;
            this.textRichTextBox.SelectionLength = 0;
            this.textRichTextBox.SelectionStart = 0;
            this.textRichTextBox.SeparatorAlignVisible = false;
            this.textRichTextBox.SeparatorBoldUnderlineItalicVisible = false;
            this.textRichTextBox.SeparatorFontColorVisible = false;
            this.textRichTextBox.SeparatorFontVisible = false;
            this.textRichTextBox.SeparatorIndentAndBulletsVisible = false;
            this.textRichTextBox.SeparatorInsertVisible = false;
            this.textRichTextBox.SeparatorSaveLoadVisible = false;
            this.textRichTextBox.Size = new System.Drawing.Size(400, 203);
            this.textRichTextBox.TabIndex = 2;
            this.textRichTextBox.ToolStripVisible = false;
            this.textRichTextBox.UnderlineVisible = false;
            this.textRichTextBox.WordWrapVisible = false;
            this.textRichTextBox.ZoomFactorTextVisible = false;
            this.textRichTextBox.ZoomInVisible = false;
            this.textRichTextBox.ZoomOutVisible = false;
            // 
            // resultsRichTextBox
            // 
            this.resultsRichTextBox.AlignCenterVisible = false;
            this.resultsRichTextBox.AlignLeftVisible = false;
            this.resultsRichTextBox.AlignRightVisible = false;
            this.resultsRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsRichTextBox.BoldVisible = false;
            this.resultsRichTextBox.BulletsVisible = false;
            this.resultsRichTextBox.ChooseFontVisible = false;
            this.resultsRichTextBox.FindReplaceVisible = false;
            this.resultsRichTextBox.FontColorVisible = false;
            this.resultsRichTextBox.FontFamilyVisible = false;
            this.resultsRichTextBox.FontSizeVisible = false;
            this.resultsRichTextBox.GroupAlignmentVisible = false;
            this.resultsRichTextBox.GroupBoldUnderlineItalicVisible = false;
            this.resultsRichTextBox.GroupFontColorVisible = false;
            this.resultsRichTextBox.GroupFontNameAndSizeVisible = false;
            this.resultsRichTextBox.GroupIndentationAndBulletsVisible = false;
            this.resultsRichTextBox.GroupInsertVisible = false;
            this.resultsRichTextBox.GroupSaveAndLoadVisible = false;
            this.resultsRichTextBox.GroupZoomVisible = false;
            this.resultsRichTextBox.INDENT = 10;
            this.resultsRichTextBox.IndentVisible = false;
            this.resultsRichTextBox.InsertPictureVisible = false;
            this.resultsRichTextBox.ItalicVisible = false;
            this.resultsRichTextBox.LoadVisible = false;
            this.resultsRichTextBox.Location = new System.Drawing.Point(6, 22);
            this.resultsRichTextBox.Name = "resultsRichTextBox";
            this.resultsRichTextBox.OutdentVisible = false;
            this.resultsRichTextBox.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
                "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs21\\par\r\n}\r\n";
            this.resultsRichTextBox.SaveVisible = false;
            this.resultsRichTextBox.SelectionColor = System.Drawing.Color.Black;
            this.resultsRichTextBox.SelectionLength = 0;
            this.resultsRichTextBox.SelectionStart = 0;
            this.resultsRichTextBox.SeparatorAlignVisible = false;
            this.resultsRichTextBox.SeparatorBoldUnderlineItalicVisible = false;
            this.resultsRichTextBox.SeparatorFontColorVisible = false;
            this.resultsRichTextBox.SeparatorFontVisible = false;
            this.resultsRichTextBox.SeparatorIndentAndBulletsVisible = false;
            this.resultsRichTextBox.SeparatorInsertVisible = false;
            this.resultsRichTextBox.SeparatorSaveLoadVisible = false;
            this.resultsRichTextBox.Size = new System.Drawing.Size(402, 200);
            this.resultsRichTextBox.TabIndex = 3;
            this.resultsRichTextBox.ToolStripVisible = false;
            this.resultsRichTextBox.UnderlineVisible = false;
            this.resultsRichTextBox.WordWrapVisible = false;
            this.resultsRichTextBox.ZoomFactorTextVisible = false;
            this.resultsRichTextBox.ZoomInVisible = false;
            this.resultsRichTextBox.ZoomOutVisible = false;
            // 
            // FrmRegexTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 539);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.topAndMiddleSplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegexTester";
            this.Text = "正则表达式测试器";
            this.Load += new System.EventHandler(this.FrmRegexTester_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRegexTester_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.sbpStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpExecutionTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpContext)).EndInit();
            this.copyButtonContextMenu.ResumeLayout(false);
            this.topAndMiddleSplitContainer.Panel1.ResumeLayout(false);
            this.topAndMiddleSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topAndMiddleSplitContainer)).EndInit();
            this.topAndMiddleSplitContainer.ResumeLayout(false);
            this.regExAndRepExSplitContainer.Panel1.ResumeLayout(false);
            this.regExAndRepExSplitContainer.Panel1.PerformLayout();
            this.regExAndRepExSplitContainer.Panel2.ResumeLayout(false);
            this.regExAndRepExSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.regExAndRepExSplitContainer)).EndInit();
            this.regExAndRepExSplitContainer.ResumeLayout(false);
            this.middleAndBottomSplitContainer.Panel1.ResumeLayout(false);
            this.middleAndBottomSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.middleAndBottomSplitContainer)).EndInit();
            this.middleAndBottomSplitContainer.ResumeLayout(false);
            this.textAndResultsSplitContainer.Panel1.ResumeLayout(false);
            this.textAndResultsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textAndResultsSplitContainer)).EndInit();
            this.textAndResultsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar statusBar;
       
        private System.Windows.Forms.StatusBarPanel sbpStatus;
        private System.Windows.Forms.StatusBarPanel sbpMatches;
        private System.Windows.Forms.StatusBarPanel sbpExecutionTime;
        private System.Windows.Forms.StatusBarPanel sbpContext;
        private System.Windows.Forms.Button regExLibraryButton;
        private System.Windows.Forms.Button regExCheatSheetButton;
        private System.Windows.Forms.Label resultsListLabel;
        private System.Windows.Forms.ContextMenuStrip copyButtonContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyGeneric0MenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyGeneric1MenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyGeneric2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyGeneric3MenuItem;
        private System.Windows.Forms.ColumnHeader lengthColumnHeader;
        private System.Windows.Forms.Button exportResultsButton;
        private System.Windows.Forms.Button replaceModeButton;
        private System.Windows.Forms.Button indentedInputButton;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader matchColumnHeader;
        private System.Windows.Forms.ColumnHeader positionColumnHeader;
        private System.Windows.Forms.Button singleLineButton;
        private System.Windows.Forms.Button multiLineButton;
        private System.Windows.Forms.Button cultureInvariantButton;
        private System.Windows.Forms.Button ignoreCaseButton;
        private System.Windows.Forms.SaveFileDialog exportSaveFileDialog;
        private System.Windows.Forms.CheckBox replaceModeCheckBox;
        private System.Windows.Forms.CheckBox indentedInputCheckBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.CheckBox singleLineCheckBox;
        private System.Windows.Forms.CheckBox multiLineCheckBox;
        private System.Windows.Forms.CheckBox ignoreCaseCheckBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.SplitContainer topAndMiddleSplitContainer;
        private System.Windows.Forms.CheckBox cultureInvariantCheckBox;
        private System.Windows.Forms.SplitContainer regExAndRepExSplitContainer;
        private System.Windows.Forms.Label regExLabel;
        private System.Windows.Forms.TextBox regExTextBox;
        private System.Windows.Forms.Label repExLabel;
        private System.Windows.Forms.TextBox repExTextBox;
        private System.Windows.Forms.SplitContainer middleAndBottomSplitContainer;
        private System.Windows.Forms.SplitContainer textAndResultsSplitContainer;
        private Controls.UcRichTextBoxEx textRichTextBox;
        private Controls.UcRichTextBoxEx resultsRichTextBox;
    }
}