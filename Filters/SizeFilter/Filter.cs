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
        public long SizeFrom { get; set; }
        public long SizeTo { get; set; }
        public SizeUnit UnitFrom { get;set; }
        public SizeUnit UnitTo { get; set; }
        public string Name { get; private set; }
        public string Title { get;private set; }
        public string Description { get; private set; }

        public bool Enabled { get; set; }
        public System.Drawing.Image Image { get;private set; }
        public System.Windows.Forms.IWin32Window SettingsForm { get;private set; }

        public System.Windows.Forms.IWin32Window AboutForm { get;private set; }

        public MyFilter()
        {
            this.Name = "SizeFilter";
            this.Title = "Size Filter";
            this.Description = "Filter files by size";
            this.Image = null;
            this.AboutForm = new AboutForm(this);
            this.SettingsForm = new SettingsForm(this);
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
