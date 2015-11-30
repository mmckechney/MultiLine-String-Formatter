using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
namespace MultiLineStringFormatter
{
    /// <summary>
    /// Authored by Michael McKechney (www.mckechney.com)
    /// This code and program are fully and freely distrubutable.
    /// If you re-use code in your own applications, please reference this original work.
    /// Thanks and your feedback is welcomed and encouraged.
    /// </summary>
    public partial class FormatterForm : Form
    {
        /// <summary>
        /// Place holder for the name of the currently inserted saved format (if any)
        /// </summary>
        string _currentFormat = string.Empty;
        int currentResultsLine = -1;
        private string CurrentFormat
        {
            get
            {
                return this._currentFormat;
            }
            set
            {
                this._currentFormat = value;
                if(this._currentFormat.Length > 0)
                {
                    MenuItem[] items = this.ctxFormats.MenuItems.Find("mnuUpdateFormat", false);
                    if (items.Length > 0)
                        items[0].Text = "Update Saved format \"" + this._currentFormat + "\"";
 
                }
            }

        }
        /// <summary>
        /// Tracking item to determine if inserted format has changed since it was pasted in.
        /// </summary>
        bool _currentFormatChanged = false;
        private bool CurrentFormatChanged
        {
            get
            {
                return this._currentFormatChanged;
            }
            set
            {
                this._currentFormatChanged = value;
                MenuItem[] items = this.ctxFormats.MenuItems.Find("mnuUpdateFormat", false);
                if (items.Length > 0)
                    items[0].Enabled = this._currentFormatChanged;
            }
        }
        /// <summary>
        /// Stores code base location for access to the .cfg file
        /// </summary>
        private string executingLocation = string.Empty;
        /// <summary>
        /// Name of the configuration file that stores the saved string format
        /// </summary>
        private string configFileName = string.Empty;
        /// <summary>
        /// Class to store the string formats in memory
        /// </summary>
        private StringManipulatorCfg formats = null;
        public FormatterForm()
        {
            InitializeComponent();

            Microsoft.Win32.SystemEvents.SessionEnded += new Microsoft.Win32.SessionEndedEventHandler(SystemEvents_SessionEnded);
        }

        void SystemEvents_SessionEnded(object sender, Microsoft.Win32.SessionEndedEventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }
        #region BackgroundWorker Handlers
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            if (e.Argument is StringData)
                e.Result = ProcessStringFormatting(e.Argument as StringData, sender as BackgroundWorker, e);
            else if (e.Argument is ExpandData)
                ProcessStringExpand(e.Argument as ExpandData, sender as BackgroundWorker, e);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (e.UserState == null)
            {
                if (e.ProgressPercentage >= 0)
                    this.statProgressBar.Increment(10);// = e.ProgressPercentage;
                else
                {
                    this.Cursor = Cursors.AppStarting;
                    this.statGeneral.Text = "Processing";
                    this.rtbStringResults.Text = string.Empty;
                    this.btnCancel.Enabled = true;
                    this.btnProcess.Enabled = false;
                    this.btnExpand.Enabled = false;

                    this.statProgressBar.Minimum = 0;
                    this.statProgressBar.Maximum = 100;
                    this.statProgressBar.Value = 0;

                    Regex numFind = new Regex(@"\d{1,9}");
                    this.statLinesProcessed.Text = numFind.Replace(this.statLinesProcessed.Text, "0");
                    this.statEmptyLines.Text = numFind.Replace(this.statEmptyLines.Text, "0");
                    this.statMissingValues.Text = numFind.Replace(this.statMissingValues.Text, "0");
                    this.statLinesSubmitted.Text = numFind.Replace(this.statLinesSubmitted.Text, "0");
                }
            }
            else if (e.UserState is BulkLinePurge)
            {
                Regex numFind = new Regex(@"\d{1,9}");
                BulkLinePurge purge = e.UserState as BulkLinePurge;
                this.rtbStringResults.Text += purge.LineResults;
                this.statLinesProcessed.Text = numFind.Replace(this.statLinesProcessed.Text, purge.LinesProcessed.ToString());
                this.statEmptyLines.Text = numFind.Replace(this.statEmptyLines.Text, purge.ExcludedEmptyLineCount.ToString());
                this.statMissingValues.Text = numFind.Replace(this.statMissingValues.Text, purge.ExcludedMissingValueLineCount.ToString());
                this.statLinesSubmitted.Text = numFind.Replace(this.statLinesSubmitted.Text, purge.TotalLinesSubmitted.ToString());

            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Regex numFind = new Regex(@"\d{1,9}");
            if (e.Cancelled)
            {
                this.statGeneral.Text = "Cancelled";
            }
            else if (e.Result != null)
            {
                if (e.Result is string)
                {
                    this.rtbStringResults.Text = e.Result.ToString();
                    this.statGeneral.Text = "Ready";
                    this.statProgressBar.Value = 0;

                }
                else
                {
                    this.statLinesProcessed.Text = numFind.Replace(this.statLinesProcessed.Text, e.Result.ToString());
                    this.statGeneral.Text = "Ready";
                    this.statProgressBar.Value = 0;
                }
            }

            this.btnProcess.Enabled = true;
            this.btnCancel.Enabled = false;
            this.btnExpand.Enabled = true;
            this.currentResultsLine = -1;

            this.Cursor = Cursors.Default;
        }
        #endregion

        private void ProcessStringExpand(ExpandData expData, BackgroundWorker bgWorker, DoWorkEventArgs e)
        {
            bgWorker.ReportProgress(-1);
            int emptyLinesExcluded = 0;
            char[] delimiter = Utility.GetDelimiter(expData.Delimiter);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < expData.Lines.Length; i++)
            {
                if (expData.Lines[i].Trim().Length == 0)
                {
                    emptyLinesExcluded++;
                    continue;
                }
                string[] split = expData.Lines[i].Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < split.Length; j++)
                {
                    sb.Append(split[j].Trim() + "\r\n");
                }

                e.Result = sb.ToString();
            }

        }
        /// <summary>
        /// Event handler for the process button. Gets things started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            string delimiterString = (ddDelimiter.SelectedItem != null) ? ddDelimiter.SelectedItem.ToString() : ddDelimiter.Text;

            StringData dat = new StringData(rtbFormat.Text, rtbStringSource.Lines, delimiterString,
                removeCarriageReturnsFromOutputToolStripMenuItem.Checked,
                excludeEmptyLinesToolStripMenuItem.Checked,
                excludeToolStripMenuItem.Checked,
                trimEndsOnInputValuesToolStripMenuItem.Checked,
                (fillWithDefaultTextToolStripMenuItem.Checked ? defaultFillTextMenuItem.TextBox.Text : ""));


            this.bgFormatProcessor.RunWorkerAsync(dat);
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            string delimiterString = (ddDelimiter.SelectedItem != null) ? ddDelimiter.SelectedItem.ToString() : ddDelimiter.Text;
            ExpandData data = new ExpandData(rtbFormat.Text, rtbStringSource.Lines, delimiterString);
            this.bgFormatProcessor.RunWorkerAsync(data);

        }

        /// <summary>
        /// The true worker method
        /// </summary>
        /// <param name="data">StringData object that contains the items to process</param>
        /// <param name="worker">BackgroundWorker object used for threading</param>
        /// <param name="e">DoWorkEventArgs used for threading</param>
        /// <returns>Returns total lines processed</returns>
        private int ProcessStringFormatting(StringData data, BackgroundWorker worker, DoWorkEventArgs e)
        {
            worker.ReportProgress(-1);

            int emptyLinesExcluded = 0;
            int missingValueLinesExcluded = 0;
            char[] delimiter = Utility.GetDelimiter(data.Delimiter);
            
            StringBuilder sb = new StringBuilder();
            int linesProcessed = 0;
            int totalLines = 0;
            int length = data.Lines.Length;
            totalLines = length;

            //Get the count of format elements in the string 
            Regex formatCounter = new Regex(@"\{[0-9]+\}");
            MatchCollection matches = formatCounter.Matches(data.Format);
            int maxMatchFormatNumber = 0;
            int minMatchFormatNumber = int.MaxValue;
            int tmp;
            for (int i = 0; i < matches.Count; i++)
            {
                Int32.TryParse(matches[i].Value.Replace("{", "").Replace("}", ""), out tmp);
                if (tmp + 1 > maxMatchFormatNumber) maxMatchFormatNumber = tmp + 1;
                if (tmp < minMatchFormatNumber) minMatchFormatNumber = tmp;
            }

            int tenPercent = Convert.ToInt32(length * 0.1);
            for (int i = 0; i < length; i++)
            {
                //If excluding empty lines, see if there is a blank line or a line of delimiters with no values.
                if (data.ExcludeEmptyLines && data.Lines[i].Replace(delimiter[0].ToString(), "").Trim().Length == 0)
                {
                    emptyLinesExcluded++;
                    continue;
                }

                //Get a string array of the values to process.
                string[] vals = data.Lines[i].Trim().Split(delimiter);

                //Also consider it empty if is doesn't at least contain the lowest format number
                if (data.ExcludeEmptyLines && vals.Length - 1 < minMatchFormatNumber)
                {
                    emptyLinesExcluded++;
                    continue;
                }
              
                bool skip = false;
                //If supposed to skip missing values, see if there are any missing values
                if (data.ExcludeMissingValues)
                {
                    //If the array contains less then the needed format lengths, it's automatically a skip
                    if (vals.Length < maxMatchFormatNumber)
                    {
                        missingValueLinesExcluded++;
                        skip = true;
                    }
                    else
                    {
                        //Otherwise, check each value to see if it's blank.
                        for (int j = 0; j < maxMatchFormatNumber; j++)
                        {
                            if (vals[j].Trim().Length == 0)
                            {
                                missingValueLinesExcluded++;
                                skip = true;
                                continue;
                            }
                        }
                    }
                }
                else //If we are to include lines with missing values, insert the default fill text
                {
                    //If the array isn't long enough, make it bigger.
                    if (vals.Length -1 < maxMatchFormatNumber)
                    {
                        string[] tmpArr = new string[maxMatchFormatNumber];
                        tmpArr.Initialize();
                        vals.CopyTo(tmpArr, 0);
                        vals = tmpArr;
                    }
       
                    //Check the values and add default as needed
                    for (int j = 0; j < vals.Length; j++)
                        if (vals[j] == null || vals[j].Trim().Length == 0)
                            vals[j] = data.DefaultFillText;
                }

                if (skip)
                    continue;

                if (data.TrimInputValues)
                {
                    for (int j = 0; j < vals.Length; j++)
                        vals[j] = vals[j].Trim();
                }

                try
                {
                    sb.Append(String.Format(data.Format, vals));
                    if (!data.RemoveCarrigeReturns)
                        sb.Append("\r\n");

                    linesProcessed++;
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        BulkLinePurge purge = new BulkLinePurge(sb.ToString(), linesProcessed, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
                        worker.ReportProgress(0, purge);
                        sb.Length = 0;
                        return linesProcessed;
                    }
                    if (tenPercent > 0 && linesProcessed % tenPercent == 0)
                        worker.ReportProgress(linesProcessed);
                }
                catch (System.FormatException exe)
                {
                    if (!data.ExcludeMissingValues)
                    {
                        BulkLinePurge purge = new BulkLinePurge(sb.ToString(), i, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
                        worker.ReportProgress(0, purge);
                        sb.Length = 0;
                        if (DialogResult.No == MessageBox.Show("Line " + Convert.ToString(i + 1) + " does not contain enough values. Skip line and continue?", "Missing Values", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            break;
                    }
                    else
                    {
                        missingValueLinesExcluded++;
                    }
                }
            }

            BulkLinePurge finalPurge = new BulkLinePurge(sb.ToString(), linesProcessed, emptyLinesExcluded, missingValueLinesExcluded, totalLines);
            worker.ReportProgress(0, finalPurge);
            e.Result = finalPurge;
            sb.Length = 0;
            return linesProcessed;

        }

        /// <summary>
        /// Loads form and pre-loads and saved string formats
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatterForm_Load(object sender, EventArgs e)
        {
            this.ddDelimiter.SelectedIndex = 0;
            executingLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            LoadSavedFormats();
        }
        /// <summary>
        /// Gets any pre-saved formats
        /// </summary>
        private void LoadSavedFormats()
        {
            configFileName = executingLocation + @"\StringManipulatorFormats.cfg";
            if (Directory.Exists(executingLocation) && File.Exists(configFileName))
            {
                using (StreamReader sr = new StreamReader(configFileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(StringManipulatorCfg));
                    object obj = serializer.Deserialize(sr);
                    this.formats = (StringManipulatorCfg)obj;
                }
            }
            ctxFormats.MenuItems.Clear();
            if (formats != null)
            {

                string tease = string.Empty;
                for (int i = 0; i < formats.Items.Length; i++)
                {
                    if (formats.Items[i].Value.Length > 30)
                        tease = formats.Items[i].Value.Substring(0, 30) + " ...";
                    else
                        tease = formats.Items[i].Value;

                    MenuItem item = new MenuItem(formats.Items[i].Name + " :: " + tease, new EventHandler(InsertFormat_Click));
                    item.Tag = formats.Items[i];
                    this.ctxFormats.MenuItems.Add(item);
                }
            }
            if (this.ctxFormats.MenuItems.Count > 0)
                this.ctxFormats.MenuItems.Add("-");

            this.ctxFormats.MenuItems.AddRange(SaveNewFormatMenuItem());


        }
       /// <summary>
       /// Pre-defined menu item for saving the string format 
       /// </summary>
       /// <returns></returns>
        private MenuItem[] SaveNewFormatMenuItem()
        {
            MenuItem[] items = new MenuItem[3];
            items[0] =  new MenuItem("Save Current Format...", new EventHandler(SaveNewFormat_Click));
            items[1] = new MenuItem("-");
            items[2] = new MenuItem("Update Saved Format", new EventHandler(UpdateSavedFormat_Click));
            items[2].Enabled = false;
            items[2].Name = "mnuUpdateFormat";
            return items;


        }
        
        /// <summary>
        /// Handles the "Save Current Format..." context menu click. 
        /// Processes the save to the configuration file then re-loads the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveNewFormat_Click(object sender, System.EventArgs e)
        {
            NewFormatForm frmNew = new NewFormatForm(this.rtbFormat.Text);
            if (DialogResult.OK == frmNew.ShowDialog())
            {
                StringManipulatorCfgFormat frmt = new StringManipulatorCfgFormat();
                frmt.Name = frmNew.Description;
                frmt.Value = frmNew.Format;
                frmt.Delimiter = rtbFormat.Text;

                if (this.formats != null)
                {
                    ArrayList lst = new ArrayList(this.formats.Items);
                    lst.Add(frmt);
                    StringManipulatorCfgFormat[] newlist = new StringManipulatorCfgFormat[lst.Count];
                    lst.CopyTo(newlist);
                    this.formats.Items = newlist;
                }
                else
                {
                    this.formats = new StringManipulatorCfg();
                    this.formats.Items = new StringManipulatorCfgFormat[] { frmt };
                }

                System.Xml.XmlTextWriter tw = null;
                try
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(StringManipulatorCfg));
                    tw = new System.Xml.XmlTextWriter(this.configFileName, Encoding.UTF8);
                    tw.Indentation = 4;
                    tw.Formatting = System.Xml.Formatting.Indented;
                    xmlS.Serialize(tw, this.formats);
                    tw.Close();

                    LoadSavedFormats();
                }
                finally
                {
                    if (tw != null)
                        tw.Close();
                }
            }

        }
        /// <summary>
        /// Inserts the selected string format from the context menu into the "String Format"
        /// text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertFormat_Click(object sender, System.EventArgs e)
        {
            if (this.formats == null)
                return;

            var format = ((MenuItem)sender).Tag as StringManipulatorCfgFormat;
           
            this.rtbFormat.Clear();
            this.rtbFormat.Text = format.Value;
            this.CurrentFormat = format.Name;
            this.ddDelimiter.Text = format.Delimiter;
            this.CurrentFormatChanged = false;

        }
        private void UpdateSavedFormat_Click(object sender, EventArgs e)
        {
            NewFormatForm frmFormat = new NewFormatForm(rtbFormat.Text, this.CurrentFormat);
            if (DialogResult.OK == frmFormat.ShowDialog())
            {
                for (int i = 0; i < this.formats.Items.Length; i++)
                {
                    if (this.formats.Items[i].Name.Trim() == this.CurrentFormat)
                    {
                        this.formats.Items[i].Name = frmFormat.Description;
                        this.formats.Items[i].Value = frmFormat.Format;
                        this.formats.Items[i].Delimiter = ddDelimiter.Text;
                        this.CurrentFormat = frmFormat.Description;
                        this.CurrentFormatChanged = false;

                        break;
                    }
                }
                System.Xml.XmlTextWriter tw = null;
                try
                {
                    XmlSerializer xmlS = new XmlSerializer(typeof(StringManipulatorCfg));
                    tw = new System.Xml.XmlTextWriter(this.configFileName, Encoding.UTF8);
                    tw.Indentation = 4;
                    tw.Formatting = System.Xml.Formatting.Indented;
                    xmlS.Serialize(tw, this.formats);
                    tw.Close();

                    LoadSavedFormats();
                }
                finally
                {
                    if (tw != null)
                        tw.Close();
                }
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgFormatProcessor.CancelAsync();
        }

        /// <summary>
        /// Determines where the mouse clicks in the source lines, then 
        /// determines what the index of the delimited string it's in and sets the 
        /// tooltip to that index and string value.
        /// NOTE: this is a work in progress. It works only for the first line in the rich text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbStringSource_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int charIndex = rtbStringSource.GetCharIndexFromPosition(e.Location);
                int lineNumber = rtbStringSource.GetLineFromCharIndex(charIndex);
                int lineStartIndex = rtbStringSource.GetFirstCharIndexOfCurrentLine();
                string line = rtbStringSource.Lines[lineNumber];
                string delimiter = (ddDelimiter.SelectedItem != null) ? ddDelimiter.SelectedItem.ToString() : ddDelimiter.Text;
                string[] split = line.Split(Utility.GetDelimiter(delimiter));
                int sum = lineStartIndex;
                string value = string.Empty;
                int index = -1;
                for (int i = 0; i < split.Length; i++)
                {
                    sum += split[i].Length + 1;
                    if (sum >= charIndex)
                    {
                        value = split[i];
                        index = i;
                        break;
                    }
                }
                toolTip1.SetToolTip(rtbStringSource, "Index =" + index.ToString() + " [" + value + "]");
                
            }
            catch (Exception exe)
            {
                System.Diagnostics.Debug.WriteLine(exe.ToString());
            }
        }

        /// <summary>
        /// Captures the close event and instead hides the form, leaving the 
        /// program active and in the system tray for quick re-use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbStringResults.Text);
        }

        /// <summary>
        /// Opens the file trimmer utility form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileTrimUtilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileTrimmer frmTrim = new FileTrimmer();
            frmTrim.Show();

        }

        /// <summary>
        /// Opens a source text file for processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSourceTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                this.statGeneral.Text = "Loading File";
                this.statusStrip1.Invalidate();
                this.Cursor = Cursors.WaitCursor;
                if(File.Exists(openFileDialog1.FileName))
                {
                    using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                    {
                        rtbStringSource.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                }
                this.statGeneral.Text = "File Load Complete";
                this.Cursor = Cursors.Default;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                File.WriteAllText(saveFileDialog1.FileName, rtbStringResults.Text);
            }
        }


        private void defaultFillTextMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (defaultFillTextMenuItem.TextBox.ForeColor != Color.Black)
            {
                defaultFillTextMenuItem.TextBox.Text = "";
                defaultFillTextMenuItem.TextBox.ForeColor = Color.Black;
            }
        }

        private void defaultFillTextMenuItem_KeyUp(object sender, KeyEventArgs e)
        {
            fillWithDefaultTextToolStripMenuItem.Checked = true; 
        }

        private void excludeToolStripMenuItem_CheckChanged(object sender, EventArgs e)
        {
            if (excludeToolStripMenuItem.Checked)
                fillWithDefaultTextToolStripMenuItem.Checked = false;
            else
                fillWithDefaultTextToolStripMenuItem.Checked = true;
 
        }

        private void fillWithDefaultTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (fillWithDefaultTextToolStripMenuItem.Checked)
                excludeToolStripMenuItem.Checked = false;
            else
                excludeToolStripMenuItem.Checked = true;
        }

        private void rtbFormat_TextChanged(object sender, EventArgs e)
        {
            if (this.CurrentFormat.Length > 0)
                this.CurrentFormatChanged = true;
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            string delimiterString = (ddDelimiter.SelectedItem != null) ? ddDelimiter.SelectedItem.ToString() : ddDelimiter.Text;

            AnalysisData data = new AnalysisData();
            data.SourceLines = rtbStringSource.Lines;
            data.TotalLines = data.SourceLines.Length;
            data.Delimiter = delimiterString;
            AnalysisForm frmAnalysis = new AnalysisForm(data);
            frmAnalysis.Show();
        }

        private void rtbStringResults_MouseDown(object sender, MouseEventArgs e)
        {
           int index =  rtbStringResults.GetCharIndexFromPosition(new Point(e.X, e.Y));
           int line = rtbStringResults.GetLineFromCharIndex(index);
           if (line > 0)
               currentResultsLine = line - 1;
           else
               currentResultsLine = -1;
            
        }

        private void FormatterForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                currentResultsLine++;
                if (rtbStringResults.Lines.Length > currentResultsLine)
                {
                    this.rtbStringResults.Select(this.rtbStringResults.GetFirstCharIndexFromLine(currentResultsLine), rtbStringResults.Lines[currentResultsLine].Length);
                    this.rtbStringResults.Focus();

                    Clipboard.SetText( (rtbStringResults.Lines[currentResultsLine].Length > 0) ? rtbStringResults.Lines[currentResultsLine] : " " );
                    Point pnt = new Point(this.pnlResults.Location.X + (int)(this.pnlResults.Width *  .25), this.pnlResults.Location.Y + (int)(this.pnlResults.Height * .25));
                    toolTip1.Show("Copied to Clipboard:\r\n\t"+rtbStringResults.Lines[currentResultsLine] + "\t\r\n", this, pnt, 3000);
                }
            }
        }

        private void ctxFormats_Popup(object sender, EventArgs e)
        {

        }

        private void ddDelimiter_TextUpdate(object sender, EventArgs e)
        {
            this.CurrentFormatChanged = true;
        }

        private void ddDelimiter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.CurrentFormatChanged = true;
        }
    }
}