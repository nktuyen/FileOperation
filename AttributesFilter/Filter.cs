using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace AttributesFilter
{
    public class MyFilter : IFilter
    {
        public string Name
        {
            get
            {
                return "Attributes Filter";
            }
        }

        public bool Enabled { get; set; }

        public bool Initialize()
        {
            return true;
        }

        public bool Filter(string filePath)
        {
            return true;
        }

        public System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner)
        {
            AboutForm frm = new AboutForm();
            return frm.ShowDialog(owner);
        }

        public System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner)
        {
            SettingsForm frm = new SettingsForm();
            return frm.ShowDialog(owner);
        }
    }
}
