using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Diagnostics;
using System.IO;

namespace DateFilter
{
    public class MyFilter : IFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool UseDateTo { get; set; }
        public string Name { get; private set; }
        public string Title { get;private set; }
        public string Description { get; private set; }
        public System.Windows.Forms.IWin32Window SettingsForm { get; private set; }
        public System.Windows.Forms.IWin32Window AboutForm { get; private set; }
        public bool Enabled { get; set; }
        public System.Drawing.Image Image { get;private set; }

        public MyFilter()
        {
            this.Name = "DateFilter";
            this.Title = "Date Filter";
            this.Description = "Filter files by created date";
            this.Image = null;
            this.AboutForm = new AboutForm(this);
            this.SettingsForm = new SettingsForm(this);
            this.DateFrom = DateTime.Now;
            this.DateTo = DateTime.Now;
            this.UseDateTo = true;
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
                if (fi.CreationTime >= this.DateFrom)
                {
                    if (this.UseDateTo)
                    {
                        if (fi.CreationTime <= this.DateTo)
                            return true;
                        else
                            return false;
                    }
                    else
                        return true;
                }
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objDateFrom = null;
            object objDateTo = null;
            object objUseDateTo = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objDateFrom = myKey.GetValue("DateFrom");
                    objDateTo = myKey.GetValue("DateTo");
                    objUseDateTo = myKey.GetValue("UseDateTo");

                    this.DateFrom = DateTime.Parse(objDateFrom as string);
                    this.UseDateTo = ((int)objUseDateTo != 0);
                    if (this.UseDateTo)
                        this.DateTo = DateTime.Parse(objDateTo as string);

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
                    myKey.SetValue("DateFrom", this.DateFrom, Microsoft.Win32.RegistryValueKind.String);
                    myKey.SetValue("UseDateTo", this.UseDateTo ? 1 : 0, Microsoft.Win32.RegistryValueKind.DWord);
                    if (this.UseDateTo)
                        myKey.SetValue("DateTo", this.DateTo, Microsoft.Win32.RegistryValueKind.String);

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
