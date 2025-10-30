using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveTo
{
    public partial class SettingsForm : Form
    {
        public int FileExistingAction { get; set; }
        public int BrowserDialogStyle { get; set; }

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

            if (radioButtonFileDialogStyle.Checked)
                this.BrowserDialogStyle = 0;
            else
                this.BrowserDialogStyle = 1;
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

            if (this.BrowserDialogStyle == 0)
                radioButtonFileDialogStyle.Checked = true;
            else
                radioButtonFolderDialogStyle.Checked = true;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
