using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NameFilter
{
    public partial class SettingsForm : Form
    {
        public string Wildcard { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
            this.Wildcard = string.Empty;
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

            txtWildcard.Text = this.Wildcard;
        }

        private void txtWildcard_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtWildcard.TextLength > 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Wildcard = txtWildcard.Text;
        }
    }
}
