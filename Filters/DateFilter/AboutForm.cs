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
    public partial class AboutForm : Form
    {
        private MyFilter Filter { get; set; }
        public AboutForm(MyFilter filter = null)
        {
            InitializeComponent();
            this.Filter = filter;
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
