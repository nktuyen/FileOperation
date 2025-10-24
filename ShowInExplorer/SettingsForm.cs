using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowInExplorer
{
    public partial class SettingsForm : Form
    {
        public bool Selected { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            chbShowSelected.Checked = this.Selected;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Selected = chbShowSelected.Checked;
        }
    }
}
