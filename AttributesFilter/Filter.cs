using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.IO;

namespace AttributesFilter
{
    public class MyFilter : IFilter
    {
        private FileAttributes Attributes { get; set;   }

        public string Name
        {
            get
            {
                return "Attributes Filter";
            }
        }

        public bool Enabled { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }
        public MyFilter()
        {
            this.Attributes = FileAttributes.Archive | FileAttributes.Normal;
        }
        public bool Initialize()
        {
            return true;
        }

        public bool Filter(string filePath)
        {
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(filePath);
                if ((fi.Attributes & this.Attributes) != 0)
                    return true;
            }
            catch (System.Exception ex)
            {
                return true;
            }

            return false;
        }

        public System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner)
        {
            AboutForm frm = new AboutForm();
            return frm.ShowDialog(owner);
        }

        public System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner)
        {
            SettingsForm frm = new SettingsForm();
            frm.Attributes = this.Attributes;
            System.Windows.Forms.DialogResult res = frm.ShowDialog(owner);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.Attributes = frm.Attributes;
            }
            return res;
        }
    }
}
