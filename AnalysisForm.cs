using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiLineStringFormatter
{
    public partial class AnalysisForm : Form
    {
        AnalysisData data = null;
        private AnalysisForm()
        {
            InitializeComponent();
        }
        public AnalysisForm(AnalysisData data) : this()
        {
            this.data = data;
        }
        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            this.statProgress.Style = ProgressBarStyle.Marquee;
            this.statGeneral.Text = "Analyzing input data...";
            this.bgAnalysis.RunWorkerAsync(this.data);
        }

        private void bgAnalysis_DoWork(object sender, DoWorkEventArgs e)
        {
            this.statGeneral.Text = "Ready.";
            int maxIndexes = 0;
            BackgroundWorker bg = (BackgroundWorker)sender;
            AnalysisData data = (AnalysisData)e.Argument;
            char[] delimiter = Utility.GetDelimiter(data.Delimiter);
            string[] tmp;
            for(int i=0;i<data.SourceLines.Length;i++)
            {
                tmp = data.SourceLines[i].Split(delimiter,StringSplitOptions.None);
                if (tmp.Length > maxIndexes)
                    maxIndexes = tmp.Length;

                if (data.IndexTally.ContainsKey(tmp.Length))
                {
                    data.IndexTally[tmp.Length]++;
                }
                else
                {
                    data.IndexTally.Add(tmp.Length, 1);
                }
                LineInfo info = new LineInfo(i + 1, data.SourceLines[i], tmp.Length);
                data.LineData.Add(info);
            }
            data.MaxIndexes = maxIndexes;
            e.Result = data;
        }

        private void bgAnalysis_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgAnalysis_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.statProgress.Style = ProgressBarStyle.Blocks;

             AnalysisData data =  (AnalysisData)e.Result;
             this.lblDelimiter.Text = data.Delimiter;
             this.lblTotalLines.Text = data.TotalLines.ToString();
             
             for (int i = 0; i < data.MaxIndexes; i++)
             {
                 if(data.IndexTally.ContainsKey(i+1))
                        ddIndexes.Items.Add(i + 1);
             }
             ddIndexes.SelectedIndex = ddIndexes.Items.Count-1;
             ddIndexes_SelectionChangeCommitted(null, EventArgs.Empty);
           
        }

        private void ddIndexes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int indexValue = (int)ddIndexes.SelectedItem;
            int compliant = 0;
            int moreIndexes = 0;
            int lessIndexes = 0;
            List<LineInfo> lineData = new List<LineInfo>();
            for (int i = 0; i < data.LineData.Count; i++)
            {
                if (data.LineData[i].ActualIndexCount == indexValue)
                {
                    lineData.Add(data.LineData[i]);
                    compliant++;
                }
                else if (data.LineData[i].ActualIndexCount >= indexValue)
                {
                    moreIndexes++;
                }
                else
                {
                    lessIndexes++;
                }
            }

            this.lblMatchingLines.Text = lineData.Count.ToString();
            this.lblLessIndexes.Text = lessIndexes.ToString();
            this.lblMoreIndexes.Text = moreIndexes.ToString();
            
            this.dataGridView1.DataSource = lineData;
        }
        //TODO: Set the DataSource on lineInfoBindingSource
        //this.lineInfoBindingSource.DataSource = typeof(MultiLineStringFormatter.LineInfo);



    }
}