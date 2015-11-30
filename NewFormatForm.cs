using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiLineStringFormatter
{
    /// <summary>
    /// Authored by Michael McKechney (www.mckechney.com)
    /// This code and program are fully and freely distrubutable.
    /// If you re-use code in your own applications, please reference this original work.
    /// Thanks and your feedback is welcomed and encouraged.
    /// </summary>
    public partial class NewFormatForm : Form
    {
        public string Description
        {
            get
            {
                return this.txtDescription.Text;
            }
        }
        public string Format
        {
            get
            {
                return this.rtbBefore.Text;
            }
        }
        public NewFormatForm(string format)
        {
            InitializeComponent();
            this.rtbBefore.Text = format;
        }
        public NewFormatForm(string format, string formatName) : this(format)
        {
            this.txtDescription.Text = formatName;
            this.Text = "Update Saved String Format";
            btnAdd.Text = "Save Update";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}