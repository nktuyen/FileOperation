using Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperation
{
    public class AttributesFilter : IFilter
    {
        public FileAttributes Attributes { get; set; }
        public enum MatchingMode { EQuality, Containing }
        public MatchingMode Matching { get; set; }
        public System.Windows.Forms.IWin32Window SettingsForm { get; private set; }
        public System.Windows.Forms.IWin32Window AboutForm { get; private set; }

        public string Name { get;private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public System.Drawing.Image Image { get; private set; }
        public bool Enabled { get; set; }
        public AttributesFilter()
        {
            this.Name = "AttributesFilter";
            this.Title = "Attributes Filter";
            this.Description = "Filter files by attributes";
            this.Image = null;
            this.AboutForm = null;
            this.SettingsForm = new AttributesFilterSettingsForm(this);
            this.Attributes = FileAttributes.Archive | FileAttributes.Normal;
            this.Matching = MatchingMode.Containing;
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
                if (this.Matching == MatchingMode.EQuality)
                {
                    if ((fi.Attributes == this.Attributes))
                        return true;
                }
                else if (this.Matching == MatchingMode.Containing)
                {
                    if ((fi.Attributes & this.Attributes) != 0)
                        return true;
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

            return false;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objAttributes = null;
            object objMatchingMode = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objAttributes = myKey.GetValue("Attributes");
                    objMatchingMode = myKey.GetValue("MatchingMode");

                    this.Attributes = (FileAttributes)objAttributes;
                    this.Matching = (MatchingMode)objMatchingMode;

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
                    myKey.SetValue("Attributes", this.Attributes, Microsoft.Win32.RegistryValueKind.DWord);
                    myKey.SetValue("MatchingMode", this.Matching, Microsoft.Win32.RegistryValueKind.DWord);

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
