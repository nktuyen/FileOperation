using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Text.RegularExpressions;

namespace NameFilter
{
    public class MyFilter : IFilter
    {
        private string Wildcard { get; set; }
        public string Name
        {
            get
            {
                return "Name Filter";
            }
        }

        public bool Enabled { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }

        public MyFilter()
        {
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
            SettingsForm frm = new SettingsForm();
            frm.Wildcard = this.Wildcard;
            System.Windows.Forms.DialogResult res = frm.ShowDialog(owner);
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                this.Wildcard = frm.Wildcard;
            }

            return res;
        }
    }
}