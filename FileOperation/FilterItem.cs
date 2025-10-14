using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileOperation
{
    public partial class FilterItem : UserControl
    {
        public event EventHandler CheckedChanged;
        public event EventHandler SettingsClick;
        public event EventHandler AboutClick;

        [System.ComponentModel.Browsable(true)]
        public string Text
        {
            get
            {
                return cbFilterEnabled.Text;
            }
            set
            {
                cbFilterEnabled.Text = value;
            }
        }
        [System.ComponentModel.Browsable(true)]
        public bool Enabled
        {
            get
            {
                return btnFilterSettings.Enabled;
            }
            set
            {
                btnFilterSettings.Enabled = value;
                btnAbout.Enabled = value;
                if (value)
                    cbFilterEnabled.ForeColor = Color.Black;
                else
                    cbFilterEnabled.ForeColor = Color.Gray;
            }
        }
        public FilterItem()
        {
            InitializeComponent();
        }

        private void FilterItem_Load(object sender, EventArgs e)
        {
            cbFilterEnabled.Text = this.Text;
        }

        private void FilterItem_SizeChanged(object sender, EventArgs e)
        {
            btnFilterSettings.Height = this.Height - 2;
            btnAbout.Height = this.Height - 2;
            btnFilterSettings.Width = btnFilterSettings.Height;
            btnAbout.Width = btnAbout.Height;
            btnFilterSettings.Left = this.Width - btnFilterSettings.Width - 1;
            cbFilterEnabled.Left = 1;

            cbFilterEnabled.Top = Height / 2 - cbFilterEnabled.Height / 2;
            btnFilterSettings.Top = Height / 2 - btnFilterSettings.Height / 2;
            btnAbout.Top = Height / 2 - btnAbout.Height / 2;

            btnAbout.Left = btnFilterSettings.Left - btnAbout.Width - 1;
        }

        private void cbFilterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedChanged != null)
                CheckedChanged(this, e);
            this.Enabled = cbFilterEnabled.Checked;
        }

        private void btnFilterSettings_Click(object sender, EventArgs e)
        {
            if (SettingsClick != null)
                SettingsClick(this, e);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (this.AboutClick != null)
                this.AboutClick(this, e);
        }
    }
}
