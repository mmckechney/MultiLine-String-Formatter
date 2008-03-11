namespace MultiLineStringFormatter
{
    partial class FormatterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.e
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatterForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ddDelimiter = new System.Windows.Forms.ComboBox();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statGeneral = new System.Windows.Forms.ToolStripStatusLabel();
            this.statLinesSubmitted = new System.Windows.Forms.ToolStripStatusLabel();
            this.statLinesProcessed = new System.Windows.Forms.ToolStripStatusLabel();
            this.statEmptyLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.statMissingValues = new System.Windows.Forms.ToolStripStatusLabel();
            this.statProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trimEndsOnInputValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeEmptyLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCarriageReturnsFromOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.excludeLinesWithMissingValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillWithDefaultTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultFillTextMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.rtbStringResults = new System.Windows.Forms.RichTextBox();
            this.ctxCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnlFormat = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbFormat = new System.Windows.Forms.RichTextBox();
            this.ctxFormats = new System.Windows.Forms.ContextMenu();
            this.label2 = new System.Windows.Forms.Label();
            this.bgFormatProcessor = new System.ComponentModel.BackgroundWorker();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSourceTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTrimUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbStringSource = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.ctxCopy.SuspendLayout();
            this.pnlFormat.SuspendLayout();
            this.pnlSource.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Multi-Line String Formatter";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8F);
            this.btnCancel.Location = new System.Drawing.Point(179, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 19);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnCancel, "Process the file specified into code for a string");
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ddDelimiter
            // 
            this.ddDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddDelimiter.Items.AddRange(new object[] {
            "Comma",
            "Tab",
            "Pipe",
            "Space",
            "Tilde"});
            this.ddDelimiter.Location = new System.Drawing.Point(75, 95);
            this.ddDelimiter.Name = "ddDelimiter";
            this.ddDelimiter.Size = new System.Drawing.Size(104, 21);
            this.ddDelimiter.TabIndex = 21;
            // 
            // pnlResults
            // 
            this.pnlResults.Controls.Add(this.btnAnalysis);
            this.pnlResults.Controls.Add(this.btnExpand);
            this.pnlResults.Controls.Add(this.statusStrip1);
            this.pnlResults.Controls.Add(this.menuStrip2);
            this.pnlResults.Controls.Add(this.btnProcess);
            this.pnlResults.Controls.Add(this.btnCancel);
            this.pnlResults.Controls.Add(this.rtbStringResults);
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResults.Location = new System.Drawing.Point(0, 260);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(923, 261);
            this.pnlResults.TabIndex = 32;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnalysis.Font = new System.Drawing.Font("Arial", 8F);
            this.btnAnalysis.Location = new System.Drawing.Point(761, 6);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(72, 19);
            this.btnAnalysis.TabIndex = 28;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnAnalysis, "Process the file specified into code for a string");
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExpand.Font = new System.Drawing.Font("Arial", 8F);
            this.btnExpand.Location = new System.Drawing.Point(839, 6);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(72, 19);
            this.btnExpand.TabIndex = 27;
            this.btnExpand.Text = "Expand";
            this.btnExpand.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnExpand, "Process the file specified into code for a string");
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statGeneral,
            this.statLinesSubmitted,
            this.statLinesProcessed,
            this.statEmptyLines,
            this.statMissingValues,
            this.statProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(923, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statGeneral
            // 
            this.statGeneral.Name = "statGeneral";
            this.statGeneral.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.statGeneral.Size = new System.Drawing.Size(18, 17);
            this.statGeneral.Spring = true;
            this.statGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statLinesSubmitted
            // 
            this.statLinesSubmitted.Name = "statLinesSubmitted";
            this.statLinesSubmitted.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.statLinesSubmitted.Size = new System.Drawing.Size(140, 17);
            this.statLinesSubmitted.Text = "Lines Submitted: 0";
            // 
            // statLinesProcessed
            // 
            this.statLinesProcessed.Name = "statLinesProcessed";
            this.statLinesProcessed.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.statLinesProcessed.Size = new System.Drawing.Size(170, 17);
            this.statLinesProcessed.Text = "Total Lines Processed: 0";
            // 
            // statEmptyLines
            // 
            this.statEmptyLines.Name = "statEmptyLines";
            this.statEmptyLines.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.statEmptyLines.Size = new System.Drawing.Size(171, 17);
            this.statEmptyLines.Text = "Empty Lines Excluded: 0";
            // 
            // statMissingValues
            // 
            this.statMissingValues.Name = "statMissingValues";
            this.statMissingValues.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.statMissingValues.Size = new System.Drawing.Size(207, 17);
            this.statMissingValues.Text = "Missing Value Lines Excluded: 0";
            // 
            // statProgressBar
            // 
            this.statProgressBar.Name = "statProgressBar";
            this.statProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 7);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(90, 24);
            this.menuStrip2.TabIndex = 26;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trimEndsOnInputValuesToolStripMenuItem,
            this.excludeEmptyLinesToolStripMenuItem,
            this.removeCarriageReturnsFromOutputToolStripMenuItem,
            this.toolStripSeparator1,
            this.excludeLinesWithMissingValuesToolStripMenuItem,
            this.excludeToolStripMenuItem,
            this.fillWithDefaultTextToolStripMenuItem,
            this.defaultFillTextMenuItem});
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(72, 20);
            this.toolStripMenuItem1.Text = "Options";
            // 
            // trimEndsOnInputValuesToolStripMenuItem
            // 
            this.trimEndsOnInputValuesToolStripMenuItem.Checked = true;
            this.trimEndsOnInputValuesToolStripMenuItem.CheckOnClick = true;
            this.trimEndsOnInputValuesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trimEndsOnInputValuesToolStripMenuItem.Name = "trimEndsOnInputValuesToolStripMenuItem";
            this.trimEndsOnInputValuesToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.trimEndsOnInputValuesToolStripMenuItem.Text = "Trim Ends on Input Values";
            // 
            // excludeEmptyLinesToolStripMenuItem
            // 
            this.excludeEmptyLinesToolStripMenuItem.CheckOnClick = true;
            this.excludeEmptyLinesToolStripMenuItem.Name = "excludeEmptyLinesToolStripMenuItem";
            this.excludeEmptyLinesToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.excludeEmptyLinesToolStripMenuItem.Text = "Exclude Empty Lines";
            this.excludeEmptyLinesToolStripMenuItem.ToolTipText = "A line is considered empty if:\r\nIt is blank, \r\nOnly blank values are included wit" +
                "h the delimiters,\r\nIt contains an item array less than the lowest formater index" +
                "\r\n\r\n";
            // 
            // removeCarriageReturnsFromOutputToolStripMenuItem
            // 
            this.removeCarriageReturnsFromOutputToolStripMenuItem.CheckOnClick = true;
            this.removeCarriageReturnsFromOutputToolStripMenuItem.Name = "removeCarriageReturnsFromOutputToolStripMenuItem";
            this.removeCarriageReturnsFromOutputToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.removeCarriageReturnsFromOutputToolStripMenuItem.Text = "Remove Final Carriage Returns from Output";
            this.removeCarriageReturnsFromOutputToolStripMenuItem.ToolTipText = "Removes terminating Carriage Returns ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // excludeLinesWithMissingValuesToolStripMenuItem
            // 
            this.excludeLinesWithMissingValuesToolStripMenuItem.Name = "excludeLinesWithMissingValuesToolStripMenuItem";
            this.excludeLinesWithMissingValuesToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.excludeLinesWithMissingValuesToolStripMenuItem.Text = "Lines with Missing Values:";
            // 
            // excludeToolStripMenuItem
            // 
            this.excludeToolStripMenuItem.Checked = true;
            this.excludeToolStripMenuItem.CheckOnClick = true;
            this.excludeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.excludeToolStripMenuItem.Margin = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.excludeToolStripMenuItem.Name = "excludeToolStripMenuItem";
            this.excludeToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.excludeToolStripMenuItem.Text = "Exclude";
            this.excludeToolStripMenuItem.ToolTipText = "Select to exclude lines that don\'t contain all value items";
            this.excludeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.excludeToolStripMenuItem_CheckChanged);
            // 
            // fillWithDefaultTextToolStripMenuItem
            // 
            this.fillWithDefaultTextToolStripMenuItem.CheckOnClick = true;
            this.fillWithDefaultTextToolStripMenuItem.Margin = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.fillWithDefaultTextToolStripMenuItem.Name = "fillWithDefaultTextToolStripMenuItem";
            this.fillWithDefaultTextToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.fillWithDefaultTextToolStripMenuItem.Text = "Fill With DefaultText:";
            this.fillWithDefaultTextToolStripMenuItem.ToolTipText = "Select and add a default text value to be \r\nadded in place of a missing value ite" +
                "m.";
            this.fillWithDefaultTextToolStripMenuItem.CheckedChanged += new System.EventHandler(this.fillWithDefaultTextToolStripMenuItem_CheckedChanged);
            // 
            // defaultFillTextMenuItem
            // 
            this.defaultFillTextMenuItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.defaultFillTextMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.defaultFillTextMenuItem.Margin = new System.Windows.Forms.Padding(21, 1, 1, 1);
            this.defaultFillTextMenuItem.Name = "defaultFillTextMenuItem";
            this.defaultFillTextMenuItem.Size = new System.Drawing.Size(200, 21);
            this.defaultFillTextMenuItem.Text = "<Add Default Text Here>";
            this.defaultFillTextMenuItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.defaultFillTextMenuItem_MouseDown);
            this.defaultFillTextMenuItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.defaultFillTextMenuItem_KeyUp);
            // 
            // btnProcess
            // 
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProcess.Font = new System.Drawing.Font("Arial", 8F);
            this.btnProcess.Location = new System.Drawing.Point(101, 10);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(72, 19);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnProcess, "Process the file specified into code for a string");
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // rtbStringResults
            // 
            this.rtbStringResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbStringResults.ContextMenuStrip = this.ctxCopy;
            this.rtbStringResults.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStringResults.Location = new System.Drawing.Point(19, 34);
            this.rtbStringResults.Name = "rtbStringResults";
            this.rtbStringResults.Size = new System.Drawing.Size(892, 202);
            this.rtbStringResults.TabIndex = 1;
            this.rtbStringResults.Text = "";
            this.toolTip1.SetToolTip(this.rtbStringResults, "Right click to copy to clip board or save as a file");
            // 
            // ctxCopy
            // 
            this.ctxCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
            this.ctxCopy.Name = "contextMenuStrip2";
            this.ctxCopy.Size = new System.Drawing.Size(172, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to File";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 257);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(923, 3);
            this.splitter2.TabIndex = 31;
            this.splitter2.TabStop = false;
            // 
            // pnlFormat
            // 
            this.pnlFormat.Controls.Add(this.label1);
            this.pnlFormat.Controls.Add(this.rtbFormat);
            this.pnlFormat.Controls.Add(this.ddDelimiter);
            this.pnlFormat.Controls.Add(this.label2);
            this.pnlFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormat.Location = new System.Drawing.Point(0, 138);
            this.pnlFormat.Name = "pnlFormat";
            this.pnlFormat.Size = new System.Drawing.Size(923, 119);
            this.pnlFormat.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "String format (use {0},{1}, etc format for value insert):";
            this.toolTip1.SetToolTip(this.label1, "Text added before anything else (for instance, a method signature)");
            // 
            // rtbFormat
            // 
            this.rtbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFormat.ContextMenu = this.ctxFormats;
            this.rtbFormat.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbFormat.Location = new System.Drawing.Point(19, 26);
            this.rtbFormat.Name = "rtbFormat";
            this.rtbFormat.Size = new System.Drawing.Size(892, 62);
            this.rtbFormat.TabIndex = 6;
            this.rtbFormat.Text = "";
            this.rtbFormat.TextChanged += new System.EventHandler(this.rtbFormat_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(19, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Delimiter:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label2, "Text added after everything (for instance a method closing)");
            // 
            // bgFormatProcessor
            // 
            this.bgFormatProcessor.WorkerReportsProgress = true;
            this.bgFormatProcessor.WorkerSupportsCancellation = true;
            this.bgFormatProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgFormatProcessor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.bgFormatProcessor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 135);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(923, 3);
            this.splitter1.TabIndex = 29;
            this.splitter1.TabStop = false;
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.menuStrip1);
            this.pnlSource.Controls.Add(this.label3);
            this.pnlSource.Controls.Add(this.rtbStringSource);
            this.pnlSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSource.Location = new System.Drawing.Point(0, 0);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(923, 135);
            this.pnlSource.TabIndex = 28;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(923, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSourceTextFileToolStripMenuItem,
            this.fileTrimUtilityToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSourceTextFileToolStripMenuItem
            // 
            this.openSourceTextFileToolStripMenuItem.Name = "openSourceTextFileToolStripMenuItem";
            this.openSourceTextFileToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openSourceTextFileToolStripMenuItem.Text = "Open Source Text File";
            this.openSourceTextFileToolStripMenuItem.Click += new System.EventHandler(this.openSourceTextFileToolStripMenuItem_Click);
            // 
            // fileTrimUtilityToolStripMenuItem
            // 
            this.fileTrimUtilityToolStripMenuItem.Name = "fileTrimUtilityToolStripMenuItem";
            this.fileTrimUtilityToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.fileTrimUtilityToolStripMenuItem.Text = "File Trim Utility";
            this.fileTrimUtilityToolStripMenuItem.Click += new System.EventHandler(this.fileTrimUtilityToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Source String Lines:";
            this.toolTip1.SetToolTip(this.label3, "Text added after everything (for instance a method closing)");
            // 
            // rtbStringSource
            // 
            this.rtbStringSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbStringSource.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStringSource.Location = new System.Drawing.Point(19, 53);
            this.rtbStringSource.Name = "rtbStringSource";
            this.rtbStringSource.Size = new System.Drawing.Size(892, 76);
            this.rtbStringSource.TabIndex = 15;
            this.rtbStringSource.Text = "";
            this.rtbStringSource.WordWrap = false;
            this.rtbStringSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtbStringSource_MouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Comma Separated Files (*.csv)|*.csv|SQL Files (*.sql)|*." +
                "sql|All Files (*.*)|*.*";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // FormatterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 521);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.pnlFormat);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlSource);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormatterForm";
            this.Text = "Multi-Line String Formatter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormatterForm_FormClosing);
            this.Load += new System.EventHandler(this.FormatterForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ctxCopy.ResumeLayout(false);
            this.pnlFormat.ResumeLayout(false);
            this.pnlSource.ResumeLayout(false);
            this.pnlSource.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox ddDelimiter;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.RichTextBox rtbStringResults;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pnlFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbFormat;
        private System.Windows.Forms.ContextMenu ctxFormats;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgFormatProcessor;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbStringSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSourceTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileTrimUtilityToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statGeneral;
        private System.Windows.Forms.ToolStripProgressBar statProgressBar;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statLinesProcessed;
        private System.Windows.Forms.ToolStripStatusLabel statEmptyLines;
        private System.Windows.Forms.ToolStripStatusLabel statMissingValues;
        private System.Windows.Forms.ToolStripStatusLabel statLinesSubmitted;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeCarriageReturnsFromOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excludeEmptyLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excludeLinesWithMissingValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trimEndsOnInputValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem excludeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillWithDefaultTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox defaultFillTextMenuItem;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnAnalysis;

    }
}

