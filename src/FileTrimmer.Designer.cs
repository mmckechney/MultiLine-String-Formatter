namespace MultiLineStringFormatter
{
    partial class FileTrimmer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTrimmer));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.rtbInputFile = new System.Windows.Forms.RichTextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtIndexes = new System.Windows.Forms.TextBox();
            this.ddDelimiter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkKeepBlank = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbOutPutFile = new System.Windows.Forms.RichTextBox();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(532, 87);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(108, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select Input File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // rtbInputFile
            // 
            this.rtbInputFile.Location = new System.Drawing.Point(12, 26);
            this.rtbInputFile.Name = "rtbInputFile";
            this.rtbInputFile.Size = new System.Drawing.Size(628, 55);
            this.rtbInputFile.TabIndex = 1;
            this.rtbInputFile.Text = "";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 300);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(88, 24);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtIndexes
            // 
            this.txtIndexes.Location = new System.Drawing.Point(388, 19);
            this.txtIndexes.Name = "txtIndexes";
            this.txtIndexes.Size = new System.Drawing.Size(100, 20);
            this.txtIndexes.TabIndex = 3;
            // 
            // ddDelimiter
            // 
            this.ddDelimiter.Items.AddRange(new object[] {
            "Comma",
            "Tab",
            "Pipe",
            "Space",
            "Tilde"});
            this.ddDelimiter.Location = new System.Drawing.Point(60, 19);
            this.ddDelimiter.Name = "ddDelimiter";
            this.ddDelimiter.Size = new System.Drawing.Size(104, 21);
            this.ddDelimiter.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Delimiter:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(200, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 22);
            this.label1.TabIndex = 24;
            this.label1.Text = "Indexes to Keep (comma delimited):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 22);
            this.label3.TabIndex = 25;
            this.label3.Text = "Input File:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkKeepBlank);
            this.groupBox1.Controls.Add(this.ddDelimiter);
            this.groupBox1.Controls.Add(this.txtIndexes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 56);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing Criteria";
            // 
            // chkKeepBlank
            // 
            this.chkKeepBlank.AutoSize = true;
            this.chkKeepBlank.Checked = true;
            this.chkKeepBlank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeepBlank.Location = new System.Drawing.Point(509, 19);
            this.chkKeepBlank.Name = "chkKeepBlank";
            this.chkKeepBlank.Size = new System.Drawing.Size(109, 17);
            this.chkKeepBlank.TabIndex = 25;
            this.chkKeepBlank.Text = "Keep Blank Lines";
            this.chkKeepBlank.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 22);
            this.label4.TabIndex = 29;
            this.label4.Text = "Output File:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbOutPutFile
            // 
            this.rtbOutPutFile.Location = new System.Drawing.Point(12, 206);
            this.rtbOutPutFile.Name = "rtbOutPutFile";
            this.rtbOutPutFile.Size = new System.Drawing.Size(628, 55);
            this.rtbOutPutFile.TabIndex = 28;
            this.rtbOutPutFile.Text = "";
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(532, 267);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(108, 23);
            this.btnOutputFile.TabIndex = 27;
            this.btnOutputFile.Text = "Select Output File";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.btnOutputFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.progBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 343);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(665, 22);
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(448, 17);
            this.tsslStatus.Spring = true;
            this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progBar
            // 
            this.progBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(200, 16);
            // 
            // btnNewFile
            // 
            this.btnNewFile.Enabled = false;
            this.btnNewFile.Location = new System.Drawing.Point(106, 300);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(88, 24);
            this.btnNewFile.TabIndex = 31;
            this.btnNewFile.Text = "Open New File";
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = "notepad.exe";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // FileTrimmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 365);
            this.Controls.Add(this.btnNewFile);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbOutPutFile);
            this.Controls.Add(this.btnOutputFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.rtbInputFile);
            this.Controls.Add(this.btnSelectFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileTrimmer";
            this.Text = "File Trimmer and Reorganizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.RichTextBox rtbInputFile;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtIndexes;
        private System.Windows.Forms.ComboBox ddDelimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbOutPutFile;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Button btnNewFile;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.CheckBox chkKeepBlank;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}