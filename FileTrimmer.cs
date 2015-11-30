using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace MultiLineStringFormatter
{
    /// <summary>
    /// Authored by Michael McKechney (www.mckechney.com)
    /// This code and program are fully and freely distrubutable.
    /// If you re-use code in your own applications, please reference this original work.
    /// Thanks and your feedback is welcomed and encouraged.
    /// </summary>
    public partial class FileTrimmer : Form
    {
        public FileTrimmer()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            if(DialogResult.OK == openFileDialog1.ShowDialog())
            {
                rtbInputFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnOutputFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = false; 
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                rtbOutPutFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            this.btnNewFile.Enabled = false;
            this.progBar.Value = 0;
            string delimiterString = (ddDelimiter.SelectedItem != null) ? ddDelimiter.SelectedItem.ToString() : ddDelimiter.Text;
            char[] delimiter = Utility.GetDelimiter(delimiterString);
            string[] strindexes = txtIndexes.Text.Split(',');
            int[] indexes = new int[strindexes.Length];
            for (short i = 0; i < indexes.Length; i++)
                if (!Int32.TryParse(strindexes[i], out indexes[i]))
                {
                    MessageBox.Show("Please ensure that all Indexes are Integers", "Invalid Indexes Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
           
           if (rtbOutPutFile.Text.Length == 0)
            {
                MessageBox.Show("Please select an output file name", "Output needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TrimmerData tData = new TrimmerData(rtbInputFile.Text, rtbOutPutFile.Text, indexes, delimiter, chkKeepBlank.Checked);
            this.backgroundWorker1.RunWorkerAsync(tData);
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            process1.StartInfo.Arguments = rtbOutPutFile.Text;
            process1.Start();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            e.Result = ProcessSourceFile(e.Argument as TrimmerData, sender as BackgroundWorker, e);

        }
        private int ProcessSourceFile(TrimmerData tData, BackgroundWorker worker, DoWorkEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string line;
            string[] delimited;
            int currentLine = 0;
            int lastLineEnd;

            //Count the # of lines
            int lineCount = 0;
            using (StreamReader sr = File.OpenText(tData.SourceFile))
            {
                while (sr.ReadLine() != null)
                    lineCount++;
            }
            int tenPercent = Convert.ToInt32(lineCount * 0.1);
            //Start processing the file
            using (StreamReader sr = File.OpenText(tData.SourceFile))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    currentLine++;
                    bool keepLine = false;
                    delimited = line.Split(tData.Delimiter);
                    lastLineEnd = sb.Length;
                    for (short i = 0; i < tData.Indexes.Length; i++)
                    {
                        if (keepLine == false && delimited[tData.Indexes[i]].Trim().Length > 0)
                            keepLine = true;

                        sb.Append(delimited[tData.Indexes[i]] + tData.Delimiter[0].ToString());
                    }
                    if (keepLine)
                    {
                        sb.Length = sb.Length - 1;
                        sb.Append("\r\n");
                    }
                    else
                    {
                        sb.Length = lastLineEnd;
                    }
                    if (currentLine % tenPercent == 0)
                    {
                        worker.ReportProgress(currentLine);
                        File.AppendAllText(tData.DestinationFile, sb.ToString());
                        sb.Length = 0;
                        lastLineEnd = 0;
                    }
                }
                File.AppendAllText(tData.DestinationFile, sb.ToString());
                sb.Length = 0;
                tsslStatus.Text = "Complete. Lines Processed " + currentLine.ToString();
            }
            return currentLine;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState == null)
                this.progBar.Increment(10);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnNewFile.Enabled = true;
        }

        
    }
}