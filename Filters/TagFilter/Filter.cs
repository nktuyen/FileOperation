using Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace TagFilter
{
    public class MyFilter : IFilter
    {
        public string Name { get; private set; }
        public string Title { get;private set; }
        public string Description {  get; private set; }
        public bool Enabled { get; set; }
        public System.Windows.Forms.IWin32Window SettingsForm { get; private set; }
        public System.Windows.Forms.IWin32Window AboutForm {  get; private set; }
        public Image Image {  get; private set; }
        public TagLib.MediaTypes MediaTypes { get; set; }
        public TimeSpan DurationMin { get; set; }
        public TimeSpan DurationMax { get; set; }

        public MyFilter()
        {
            this.Name = "TagFilter";
            this.Title = "Tag Filter";
            this.Description = "Filter files by tags";
            this.Image = null;
            this.AboutForm = new AboutForm(this);
            this.SettingsForm = new SettingsForm(this);
            this.MediaTypes = MediaTypes.None;
        }

        public bool Filter(string filePath)
        {
            TagLib.File mediaFile = null;
            try
            {
                mediaFile = TagLib.File.Create(filePath);
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

            if (mediaFile == null)
                return false;

            if((mediaFile.Properties.MediaTypes & this.MediaTypes) == 0)
                return false;

            if (mediaFile.Properties.Duration < this.DurationMin || mediaFile.Properties.Duration > this.DurationMax)
                return false;

            return true;
        }

        public bool Initialize()
        {
            return true;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objMediaTypes = null;
            object objDurationMin = null;
            object objDurationMax = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objMediaTypes = myKey.GetValue("MediaTypes");
                    objDurationMin = myKey.GetValue("DurationMin");
                    objDurationMax = myKey.GetValue("DurationMax");

                    if (objMediaTypes != null)
                        this.MediaTypes = (TagLib.MediaTypes)(int)objMediaTypes;

                    if (objDurationMin != null)
                        this.DurationMin = TimeSpan.Parse(objDurationMin as string);
                    if (objDurationMax != null)
                        this.DurationMax = TimeSpan.Parse(objDurationMax as string);

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
                    myKey.SetValue("MediaTypes", this.MediaTypes, Microsoft.Win32.RegistryValueKind.DWord);
                    myKey.SetValue("DurationMin", this.DurationMin.ToString(), Microsoft.Win32.RegistryValueKind.String);
                    myKey.SetValue("DurationMax", this.DurationMax.ToString(), Microsoft.Win32.RegistryValueKind.String);

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
