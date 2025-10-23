using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateFilter
{
    public partial class SettingsForm : Form
    {
        private DateTime _dtfrom = new DateTime();
        public DateTime DateFrom {
            get
            {
                return _dtfrom;
            }
            set
            {
                _dtfrom = value;
            }
        }
        public DateTime DateTo { get; set; }
        public bool UseDateTo { get; set; }

        public SettingsForm()
        {
            InitializeComponent();

            this.DateFrom = DateTime.Now;
            this.DateTo = DateTime.Now;
            this.UseDateTo = true;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if ((this.DateFrom >= datePickerFrom.MinDate) && (this.DateFrom <= datePickerFrom.MaxDate))
                datePickerFrom.Value = this.DateFrom;
            else
                datePickerFrom.Value = DateTime.Now;
            chkDateTo.Checked = this.UseDateTo;
            chkDateTo_CheckedChanged(sender, e);

            if (this.UseDateTo)
            {
                if ((this.DateTo >= datePickerTo.MinDate) && (this.DateTo <= datePickerTo.MaxDate))
                    datePickerTo.Value = this.DateTo;
                else
                    datePickerTo.Value = DateTime.Now;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.UseDateTo = chkDateTo.Checked;
            this.DateFrom = datePickerFrom.Value;
            if (this.UseDateTo)
                this.DateTo = datePickerTo.Value;
        }

        private void chkDateTo_CheckedChanged(object sender, EventArgs e)
        {
            datePickerTo.Enabled = chkDateTo.Checked;
        }
    }
}
