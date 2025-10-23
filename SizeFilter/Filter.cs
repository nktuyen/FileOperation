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
    public enum SizeUnit { bytes = 0, KB, MB, GB, TB, PB };

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
        public System.Drawing.Image Image
        {
            get
            {
                return null;
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
                return false;
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

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objSizeFrom = null;
            object objSizeTo = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objSizeFrom = myKey.GetValue("SizeFrom");
                    objSizeTo = myKey.GetValue("SizeTo");

                    this.SizeFrom = (long)objSizeFrom;
                    this.SizeTo = (long)objSizeTo;

                    myKey.Close();
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

            return true;
        }

        public bool SaveSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;
            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name, true);
                if (myKey == null)
                    myKey = regKey.CreateSubKey(this.Name);

                if (myKey != null)
                {
                    myKey.SetValue("SizeFrom", this.SizeFrom, Microsoft.Win32.RegistryValueKind.QWord);
                    myKey.SetValue("SizeTo", this.SizeTo, Microsoft.Win32.RegistryValueKind.QWord);

                    myKey.Close();
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

            return true;
        }
    }
}
