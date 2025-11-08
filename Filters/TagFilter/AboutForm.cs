using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagFilter
{
    public partial class AboutForm : Form
    {
        private MyFilter Filter { get;set; }
        public AboutForm(MyFilter filter = null)
        {
            InitializeComponent();
            this.Filter = filter;
        }
    }
}
