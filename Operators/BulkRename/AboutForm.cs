using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulkRename
{
    public partial class AboutForm : Form
    {
        private MyOperator Operator { get; set; }
        public AboutForm(MyOperator oper = null)
        {
            InitializeComponent();

            this.Operator = oper;
        }
    }
}
