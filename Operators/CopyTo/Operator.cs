using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CopyTo
{
    public class MyOperator : IOperator
    {
        public string Name { get; private set; }
        public string Title { get;private set; }
        public string Description { get; private set; }
        private bool MultiFiles { get; set; }
        private string Destination { get; set; }
        public int FileExistingAction { get; set; }
        private DialogResult LastConfirmResult { get; set; }
        private int LastConfirmCount { get; set; }
        public bool HasSettings { get; private set; }
        public bool HasAbout { get; private set; }
        public string Status { get; private set; }
        public System.Drawing.Image Image { get; private set; }
        public bool Enabled { get; set; }
        public string CurrentFilePath { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }
        private int BrowserDialogStyle { get; set; }

        public MyOperator()
        {
            this.Name = "CopyTo";
            this.Title = "Copy To";
            this.Description = "Copy selected files to specified directory";
            this.HasAbout = true;
            this.HasSettings = true;
            this.Image = Properties.Resources.CopyTo;
            this.Destination = string.Empty;
            this.FileExistingAction = 1;//Ask
            this.BrowserDialogStyle = 0;    //File Dialog
        }

        public bool Initialize()
        {
            return true;
        }
        public bool InitializeContextMenu(long fileCount)
        {
            this.Enabled = true;
            return true;
        }
        public bool PreOperate(long fileCount)
        {
            MultiFiles = fileCount > 1;
            if (this.BrowserDialogStyle == 0)
            {
                OpenFileDialog dlgFile = new OpenFileDialog();
                dlgFile.InitialDirectory = this.Destination;
                dlgFile.CheckFileExists = true;
                dlgFile.CheckFileExists = true;
                dlgFile.Title = "Choose Destination Directory";
                if (dlgFile.ShowDialog() != DialogResult.OK)
                    return false;
                this.Destination = System.IO.Path.GetDirectoryName(dlgFile.FileName);
            }
            else
            {
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                dlgFolder.ShowNewFolderButton = true;
                dlgFolder.SelectedPath = this.Destination;
                if (dlgFolder.ShowDialog(this.MainWnd) != DialogResult.OK)
                    return false;
                this.Destination = dlgFolder.SelectedPath;
            }
            this.Status = string.Empty;
            this.LastConfirmResult = DialogResult.No;
            this.LastConfirmCount = 0;
            return true;
        }

        public bool Operate()
        {
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(this.CurrentFilePath);
                string newPath = System.IO.Path.Combine(this.Destination, fi.Name);
                if (System.IO.File.Exists(newPath))
                {
                    if (this.FileExistingAction == 0)//Ignore
                    {
                        this.Status = "Existing => Ignored due to settings";
                        return true;
                    }
                    else if (this.FileExistingAction == 1)//Ask
                    {
                        if (this.LastConfirmCount < 3)
                        {
                            DialogResult res = MessageBox.Show(string.Format("{0} is already exist.\nDo you want to overwrite it?", fi.Name), "File Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (this.LastConfirmCount <= 0)
                            {
                                this.LastConfirmCount = 1;
                            }
                            else
                            {
                                if(this.LastConfirmResult != res)
                                {
                                    this.LastConfirmCount = 0; //Reset count due to difference button was confirmed
                                }
                                else
                                {
                                    this.LastConfirmCount++;
                                }
                            }

                            this.LastConfirmResult = res; //Store recent confirmation
                        }

                        if (this.LastConfirmResult == DialogResult.No)
                        {
                            this.Status = "Existing => Ignored due to User confirmed";
                            return true;
                        }
                        else
                            this.Status = string.Format("Copied to {0} (overwrite due to User confirmed)", newPath);
                    }
                    else if (this.FileExistingAction == 2)//Overwrite
                    {
                        this.Status = string.Format("Copied to {0} (overwrite due to settings)", newPath);
                    }
                }
                else
                    this.Status = string.Format("Copied to {0}", newPath);
                System.IO.File.Copy(fi.FullName, newPath, true);
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                this.Status = ex.Message;
                return false;
            }
            return true;
        }

        public System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner)
        {
            AboutForm frm = new AboutForm();
            DialogResult res = frm.ShowDialog(owner);
            if (res == DialogResult.OK)
            {

            }

            return res;
        }

        public System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner)
        {
            SettingsForm frm = new SettingsForm();
            frm.FileExistingAction = this.FileExistingAction;
            frm.BrowserDialogStyle = this.BrowserDialogStyle;

            DialogResult res = frm.ShowDialog(owner);
            if (res == DialogResult.OK)
            {
                this.FileExistingAction = frm.FileExistingAction;
                this.BrowserDialogStyle = frm.BrowserDialogStyle;
            }

            return res;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;
            
            object objDest = null;
            object objFileExistAction = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objDest = myKey.GetValue("Destination");
                    objFileExistAction = myKey.GetValue("FileExistingAction");

                    this.Destination = objDest as string;
                    this.FileExistingAction = (int)objFileExistAction;

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
                    myKey.SetValue("Destination", this.Destination);
                    myKey.SetValue("FileExistingAction", this.FileExistingAction, Microsoft.Win32.RegistryValueKind.DWord);
                    
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
