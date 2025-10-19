using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.IO;
using System.Diagnostics;

namespace SizeFilter
{
    public class MyFilter : IFilter
    {
        private long SizeFrom { get; set; }
        private long SizeTo { get; set; }
        public string Name
        {
            get
            {
                return "Size Filter";
            }
        }

        public bool Enabled { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }

        public MyFilter()
        {
            this.SizeFrom = 0;
            this.SizeTo = -1;
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
                if (fi.Length < this.SizeFrom)
                    return false;
                if (this.SizeTo >= 0)
                {
                    if (fi.Length > this.SizeTo)
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return true;
            }
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
            frm.SizeFrom = this.SizeFrom;
            frm.SizeTo = this.SizeTo;
            System.Windows.Forms.DialogResult res = frm.ShowDialog(owner);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.SizeFrom = frm.SizeFrom;
                this.SizeTo = frm.SizeTo;
            }

            return res;
        }
    }
}
