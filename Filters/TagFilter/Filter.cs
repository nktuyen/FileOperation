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

        public bool HasSettings { get; private set; }

        public bool HasAbout {  get; private set; }

        public Image Image {  get; private set; }

        public IWin32Window MainWnd {  get; set; }

        private TagLib.MediaTypes MediaTypes { get; set; }
        private TimeSpan DurationMin { get; set; }
        private TimeSpan DurationMax { get; set; }

        public MyFilter()
        {
            this.Name = "TagFilter";
            this.Title = "Tag Filter";
            this.Description = "Filter files by tags";
            this.Image = null;
            this.HasAbout = true;
            this.HasSettings = true;
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

        public DialogResult ShowAbout(IWin32Window owner = null)
        {
            AboutForm frm = new AboutForm();
            return frm.ShowDialog();
        }

        public DialogResult ShowSettings(IWin32Window owner = null)
        {
            SettingsForm frm = new SettingsForm();
            frm.MediaTypes = this.MediaTypes;
            frm.DurationMin = this.DurationMin;
            frm.DurationMax = this.DurationMax;
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.MediaTypes = frm.MediaTypes;
                this.DurationMin = frm.DurationMin;
                this.DurationMax = frm.DurationMax;
            }

            return res;
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
