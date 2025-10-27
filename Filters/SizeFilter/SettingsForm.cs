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
        public SizeUnit UnitFrom { get; set; }
        public SizeUnit UnitTo { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            this.SizeFrom = 0;
            this.SizeTo = -1;
            this.UnitFrom = SizeUnit.bytes;
            this.UnitTo = SizeUnit.bytes;
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
                Debug.Print(ex.Message);
                this.Text = "Settings";
            }
            
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

            if (this.SizeFrom >= Math.Pow(1024,1))
            {
                if (this.SizeFrom >= Math.Pow(1024, 2))
                {
                    if (this.SizeFrom >= Math.Pow(1024, 3))
                    {
                        if (this.SizeFrom >= Math.Pow(1024, 4))
                        {
                            if (this.SizeFrom >= Math.Pow(1024, 5))
                            {
                                cbUnitFrom.SelectedIndex = 5;
                                txtSizeFrom.Text = (((double)this.SizeFrom / Math.Pow(1024, 5))).ToString("0.###");
                            }
                            else
                            {
                                cbUnitFrom.SelectedIndex = 4;
                                txtSizeFrom.Text =  (((double)this.SizeFrom / Math.Pow(1024, 4))).ToString("0.###");
                            }
                        }
                        else
                        {
                            cbUnitFrom.SelectedIndex = 3;
                            txtSizeFrom.Text = (((double)this.SizeFrom / Math.Pow(1024, 3))).ToString("0.###");
                        }
                    }
                    else
                    {
                        cbUnitFrom.SelectedIndex = 2;
                        txtSizeFrom.Text = (((double)this.SizeFrom / Math.Pow(1024, 2))).ToString("0.###");
                    }
                }
                else
                {
                    cbUnitFrom.SelectedIndex = 1;
                    txtSizeFrom.Text = (((double)this.SizeFrom / Math.Pow(1024, 1))).ToString("0.###");
                }
            }
            else
            {
                cbUnitFrom.SelectedIndex = 0;
                txtSizeFrom.Text = this.SizeFrom.ToString();
            }

            //Size to
            if (this.SizeTo >= Math.Pow(1024, 1))
            {
                if (this.SizeTo >= Math.Pow(1024, 2))
                {
                    if (this.SizeTo >= Math.Pow(1024, 3))
                    {
                        if (this.SizeTo >= Math.Pow(1024, 4))
                        {
                            if (this.SizeTo >= Math.Pow(1024, 5))
                            {
                                cbUnitTo.SelectedIndex = 5;
                                txtSizeTo.Text = (((double)this.SizeTo / Math.Pow(1024, 5))).ToString("0.###");
                            }
                            else
                            {
                                cbUnitTo.SelectedIndex = 4;
                                txtSizeTo.Text = (((double)this.SizeTo / Math.Pow(1024, 4))).ToString("0.###");
                            }
                        }
                        else
                        {
                            cbUnitTo.SelectedIndex = 3;
                            txtSizeTo.Text = (((double)this.SizeTo / Math.Pow(1024, 3))).ToString("0.###");
                        }
                    }
                    else
                    {
                        cbUnitTo.SelectedIndex = 2;
                        txtSizeTo.Text = (((double)this.SizeTo / Math.Pow(1024, 2))).ToString("0.###");
                    }
                }
                else
                {
                    cbUnitTo.SelectedIndex = 1;
                    txtSizeTo.Text = (((double)this.SizeTo / Math.Pow(1024, 1))).ToString("0.###");
                }
            }
            else
            {
                cbUnitTo.SelectedIndex = 0;
                txtSizeTo.Text = this.SizeTo.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double lValue = 0;
            double.TryParse(txtSizeFrom.Text, out lValue);
            this.SizeFrom = (long)(lValue * Math.Pow(1024, cbUnitFrom.SelectedIndex));
            if (chkSizeTo.Checked)
            {
                double lToValue = 0;
                double.TryParse(txtSizeTo.Text, out lToValue);
                this.SizeTo = (long)(lToValue * Math.Pow(1024, cbUnitTo.SelectedIndex));
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
            this.UnitFrom = (SizeUnit)cbUnitFrom.SelectedIndex;
        }

        private void cbUnitTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
            this.UnitTo = (SizeUnit)cbUnitTo.SelectedIndex;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
