using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DateFilter
{
    public class MyFilter : IFilter
    {
        public string Name
        {
            get
            {
                return "Date Filter";
            }
        }
        public bool HasSettings
        {
            get
            {
                return true;
            }
        }

        public bool HasAbout
        {
            get
            {
                return true;
            }
        }

        public bool Enabled { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }
        public System.Drawing.Image Image 
        {
            get
            {
                return null;
            }
        }
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
