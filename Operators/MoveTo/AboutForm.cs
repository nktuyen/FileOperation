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
    public partial class AboutForm : Form
    {
        private MyOperator Operator { get;set; }
        public AboutForm(MyOperator oper = null)
        {
            InitializeComponent();

            this.Operator = oper;
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
