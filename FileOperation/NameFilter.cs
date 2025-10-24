using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FileOperation
{
    public class NameFilter : IFilter
    {
        private string Wildcard { get; set; }
        public string Name { get;private set; }
        public string Title { get;private set;}
        public string Description { get;private set;}

        public bool Enabled { get; set; }
        public System.Drawing.Image Image { get;private set ; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }
        public bool HasSettings { get; private set; }
        public bool HasAbout { get;private set; }

        public NameFilter()
        {
            this.Name = "NameFilter";
            this.Title = "Name Filter";
            this.Description = "Filter files' names by wildcard";
            this.Image = null;
            this.Enabled = true;
            this.Wildcard = string.Empty;
        }

        public bool Initialize()
        {
            return true;
        }

        public bool Filter(string filePath)
        {
            if (this.Wildcard == string.Empty || this.Wildcard == "*" || this.Wildcard == "*.*")
                return true;

            string[] wildcards = this.Wildcard.Split(':');
            string regexPattern = string.Empty;
            int nMatched = 0;
            foreach (string wc in wildcards)
            {
                regexPattern = Regex.Escape(wc).Replace(@"\*", ".*").Replace(@"\?", ".");
                regexPattern = "^" + regexPattern + "$";
               if(Regex.IsMatch(filePath, regexPattern, RegexOptions.IgnoreCase))
                    nMatched++;
            }
            return nMatched > 0;
        }

        public System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner)
        {
            AboutForm frm = new AboutForm();
            return frm.ShowDialog(owner);
        }

        public System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner)
        {
            NameFilterSettingsForm frm = new NameFilterSettingsForm();
            frm.Wildcard = this.Wildcard;
            System.Windows.Forms.DialogResult res = frm.ShowDialog(owner);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.Wildcard = frm.Wildcard;
            }

            return res;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objWildcard = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objWildcard = myKey.GetValue("Wildcard");
                    this.Wildcard = objWildcard as string;

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
                    myKey.SetValue("Wildcard", this.Wildcard, Microsoft.Win32.RegistryValueKind.String);
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