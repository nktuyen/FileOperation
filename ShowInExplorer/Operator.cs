using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Security.Policy;

namespace ShowInExplorer
{
    public class MyOperator : IOperator
    {
        public string Name{ get; private set; }
        public string Title { get;private set; }

        public string Description{get;private set;}
        public string Status{ get; private set; }
        public System.Drawing.Image Image { get; private set; }
        public bool Enabled { get; set; }
        public bool HasSettings { get;private set; }
        public bool HasAbout {  get;private set; } 
        public string FilePath { get; set; }
        public IWin32Window MainWnd { get; set; }
        private bool MultipleFiles { get; set; }
        private bool ShowSelectedState { get; set; }

        public MyOperator()
        {
            this.Name = "ShowInExplorer";
            this.Title = "Show in Explorer";
            this.Description = "Show selected files in Windows Explorer";
            this.HasAbout = true;
            this.HasSettings = true;
            this.Image = Properties.Resources.WindowsExplorer;
            this.ShowSelectedState = true;
        }

        public bool Initialize()
        {
            return true;
        }

        public bool InitializeContextMenu(bool isMultiple = false)
        {
            if(isMultiple)
                this.Enabled = false;
            else
                this.Enabled = true;
            return true;
        }

        public bool Operate()
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo("explorer.exe");
            if (this.ShowSelectedState)
                proc.StartInfo.Arguments = "/select,\"" + this.FilePath + "\"";
            else
            {
                FileInfo fi = null;
                try
                {
                    fi = new FileInfo(this.FilePath);
                    proc.StartInfo.Arguments = fi.DirectoryName;
                }
                catch (System.Exception ex)
                {
                    Debug.Print(ex.Message);
                    this.Status = ex.Message;
                    return false;
                }
            }
            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                this.Status = ex.Message;
                return false;
            }

            return true;
        }

        public bool PreOperate(bool isMultiple = false)
        {
            this.MultipleFiles = isMultiple;
            return true;
        }

        public DialogResult ShowAbout(IWin32Window owner = null)
        {
            AboutForm frm=new AboutForm();
            return frm.ShowDialog(owner);
        }

        public DialogResult ShowSettings(IWin32Window owner = null)
        {
            SettingsForm frm = new SettingsForm();
            frm.Selected = this.ShowSelectedState;
            DialogResult res = frm.ShowDialog(owner);
            if (res == DialogResult.OK)
            {
                this.ShowSelectedState = frm.Selected;
            }
            return res;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objShowSelected = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objShowSelected = myKey.GetValue("ShowSelected");
                    this.ShowSelectedState = ((int)objShowSelected != 0);

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
                    myKey.SetValue("ShowSelected", this.ShowSelectedState ? 1 : 0, Microsoft.Win32.RegistryValueKind.DWord);
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
