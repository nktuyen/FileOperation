using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SizeFilter
{
    public partial class SettingsForm : Form
    {
        public long SizeFrom { get; set; }
        public long SizeTo { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
            this.SizeFrom = 0;
            this.SizeTo = -1;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Assembly asm = null;
            try
            {
                asm = Assembly.GetExecutingAssembly();
                if (asm != null)
                {
                    FileVersionInfo ver = FileVersionInfo.GetVersionInfo(asm.Location);
                    this.Text = ver.FileDescription + " - Settings";
                }
            }
            catch (System.Exception ex)
            {
                this.Text = "Settings";
            }

            cbUnitFrom.SelectedIndex = 0;
            cbUnitTo.SelectedIndex = 0;
            txtSizeFrom.Text = this.SizeFrom.ToString();
            if (this.SizeTo < 0)
            {
                chkSizeTo.Checked = false;
                txtSizeTo.Text = string.Empty;
                chkSizeTo_CheckedChanged(sender, e);
            }
            else
            {
                chkSizeTo.Checked = true;
                txtSizeTo.Text = this.SizeTo.ToString();
                chkSizeTo_CheckedChanged(sender, e);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            long lValue = 0;
            long.TryParse(txtSizeFrom.Text, out lValue);
            this.SizeFrom = lValue * (long)Math.Pow(1024, cbUnitFrom.SelectedIndex);
            if (chkSizeTo.Checked)
            {
                long lToValue = 0;
                long.TryParse(txtSizeTo.Text, out lToValue);
                this.SizeTo = lToValue * (long)Math.Pow(1024, cbUnitTo.SelectedIndex);
            }
            else
                this.SizeTo = -1;
        }

        private void txtSizeTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtSizeFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != 8)
                e.Handled = true;
        }

        private void chkSizeTo_CheckedChanged(object sender, EventArgs e)
        {
            txtSizeTo.Enabled = chkSizeTo.Checked;
            cbUnitTo.Enabled = chkSizeTo.Checked;

            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
        }

        private void txtSizeFrom_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
        }

        private void txtSizeTo_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
        }

        private void cbUnitFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
        }

        private void cbUnitTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
        }
    }
}
