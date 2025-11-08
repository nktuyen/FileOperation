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
        private MyFilter Filter { get; set; }
        public SettingsForm(MyFilter filter = null)
        {
            InitializeComponent();
            this.Filter = filter;
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
            
            txtSizeFrom.Text = this.Filter.SizeFrom.ToString();
            if (this.Filter.SizeTo < 0)
            {
                chkSizeTo.Checked = false;
                txtSizeTo.Text = string.Empty;
                chkSizeTo_CheckedChanged(sender, e);
            }
            else
            {
                chkSizeTo.Checked = true;
                txtSizeTo.Text = this.Filter.SizeTo.ToString();
                chkSizeTo_CheckedChanged(sender, e);
            }

            if (this.Filter.SizeFrom >= Math.Pow(1024,1))
            {
                if (this.Filter.SizeFrom >= Math.Pow(1024, 2))
                {
                    if (this.Filter.SizeFrom >= Math.Pow(1024, 3))
                    {
                        if (this.Filter.SizeFrom >= Math.Pow(1024, 4))
                        {
                            if (this.Filter.SizeFrom >= Math.Pow(1024, 5))
                            {
                                cbUnitFrom.SelectedIndex = 5;
                                txtSizeFrom.Text = (((double)this.Filter.SizeFrom / Math.Pow(1024, 5))).ToString("0.###");
                            }
                            else
                            {
                                cbUnitFrom.SelectedIndex = 4;
                                txtSizeFrom.Text =  (((double)this.Filter.SizeFrom / Math.Pow(1024, 4))).ToString("0.###");
                            }
                        }
                        else
                        {
                            cbUnitFrom.SelectedIndex = 3;
                            txtSizeFrom.Text = (((double)this.Filter.SizeFrom / Math.Pow(1024, 3))).ToString("0.###");
                        }
                    }
                    else
                    {
                        cbUnitFrom.SelectedIndex = 2;
                        txtSizeFrom.Text = (((double)this.Filter.SizeFrom / Math.Pow(1024, 2))).ToString("0.###");
                    }
                }
                else
                {
                    cbUnitFrom.SelectedIndex = 1;
                    txtSizeFrom.Text = (((double)this.Filter.SizeFrom / Math.Pow(1024, 1))).ToString("0.###");
                }
            }
            else
            {
                cbUnitFrom.SelectedIndex = 0;
                txtSizeFrom.Text = this.Filter.SizeFrom.ToString();
            }

            //Size to
            if (this.Filter.SizeTo >= Math.Pow(1024, 1))
            {
                if (this.Filter.SizeTo >= Math.Pow(1024, 2))
                {
                    if (this.Filter.SizeTo >= Math.Pow(1024, 3))
                    {
                        if (this.Filter.SizeTo >= Math.Pow(1024, 4))
                        {
                            if (this.Filter.SizeTo >= Math.Pow(1024, 5))
                            {
                                cbUnitTo.SelectedIndex = 5;
                                txtSizeTo.Text = (((double)this.Filter.SizeTo / Math.Pow(1024, 5))).ToString("0.###");
                            }
                            else
                            {
                                cbUnitTo.SelectedIndex = 4;
                                txtSizeTo.Text = (((double)this.Filter.SizeTo / Math.Pow(1024, 4))).ToString("0.###");
                            }
                        }
                        else
                        {
                            cbUnitTo.SelectedIndex = 3;
                            txtSizeTo.Text = (((double)this.Filter.SizeTo / Math.Pow(1024, 3))).ToString("0.###");
                        }
                    }
                    else
                    {
                        cbUnitTo.SelectedIndex = 2;
                        txtSizeTo.Text = (((double)this.Filter.SizeTo / Math.Pow(1024, 2))).ToString("0.###");
                    }
                }
                else
                {
                    cbUnitTo.SelectedIndex = 1;
                    txtSizeTo.Text = (((double)this.Filter.SizeTo / Math.Pow(1024, 1))).ToString("0.###");
                }
            }
            else
            {
                cbUnitTo.SelectedIndex = 0;
                txtSizeTo.Text = this.Filter.SizeTo.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double lValue = 0;
            double.TryParse(txtSizeFrom.Text, out lValue);
            this.Filter.SizeFrom = (long)(lValue * Math.Pow(1024, cbUnitFrom.SelectedIndex));
            if (chkSizeTo.Checked)
            {
                double lToValue = 0;
                double.TryParse(txtSizeTo.Text, out lToValue);
                this.Filter.SizeTo = (long)(lToValue * Math.Pow(1024, cbUnitTo.SelectedIndex));
            }
            else
                this.Filter.SizeTo = -1;
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
            this.Filter.UnitFrom = (SizeUnit)cbUnitFrom.SelectedIndex;
        }

        private void cbUnitTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtSizeFrom.TextLength > 0 && (!txtSizeTo.Enabled || txtSizeTo.TextLength > 0);
            this.Filter.UnitTo = (SizeUnit)cbUnitTo.SelectedIndex;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
