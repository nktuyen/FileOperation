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
    public partial class DeleteOperatorSettingsForm : Form
    {
        public bool MoveToTrash { get; set; }
        public DeleteOperatorSettingsForm()
        {
            InitializeComponent();
        }

        private void DeleteOperatorSettingsForm_Load(object sender, EventArgs e)
        {
            if (this.MoveToTrash)
                radMoveToTrash.Checked = true;
            else
                radPermanentDelete.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radMoveToTrash.Checked)
                this.MoveToTrash = true;
            else
                this.MoveToTrash = false;
        }
    }
}
