using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOperation
{
    public partial class DateFilterSettingsForm : Form
    {
        private DateFilter Filter { get; set; }
        public DateFilterSettingsForm(DateFilter filter = null)
        {
            InitializeComponent();
            this.Filter = filter;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if ((this.Filter.DateFrom >= datePickerFrom.MinDate) && (this.Filter.DateFrom <= datePickerFrom.MaxDate))
                datePickerFrom.Value = this.Filter.DateFrom;
            else
                datePickerFrom.Value = DateTime.Now;
            chkDateTo.Checked = this.Filter.UseDateTo;
            chkDateTo_CheckedChanged(sender, e);

            if (this.Filter.UseDateTo)
            {
                if ((this.Filter.DateTo >= datePickerTo.MinDate) && (this.Filter.DateTo <= datePickerTo.MaxDate))
                    datePickerTo.Value = this.Filter.DateTo;
                else
                    datePickerTo.Value = DateTime.Now;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Filter.UseDateTo = chkDateTo.Checked;
            this.Filter.DateFrom = datePickerFrom.Value;
            if (this.Filter.UseDateTo)
                this.Filter.DateTo = datePickerTo.Value;
        }

        private void chkDateTo_CheckedChanged(object sender, EventArgs e)
        {
            datePickerTo.Enabled = chkDateTo.Checked;
        }
    }
}
