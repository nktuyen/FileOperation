using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyTo
{
    public partial class SettingsForm : Form
    {
        public int FileExistingAction { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radIgnoreExistFile.Checked)
                this.FileExistingAction = 0;
            else if (radAsk.Checked)
                this.FileExistingAction = 1;
            else if (radOverwrite.Checked)
                this.FileExistingAction = 2;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (this.FileExistingAction == 0)
            {
                radIgnoreExistFile.Checked = true;
            }
            else if (this.FileExistingAction == 1)
            {
                radAsk.Checked = true;
            }
            else if (this.FileExistingAction == 2)
            {
                radOverwrite.Checked = true;
            }
        }
    }
}
