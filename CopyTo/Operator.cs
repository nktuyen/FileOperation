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
    public class CopyToOperator : IOperator
    {
        public string Name { get { return "Copy To"; } }
        public string Description { get { return "Copy files to specified directory"; } }
        private string _status = string.Empty;
        private bool MultiFiles { get; set; }
        private string Destination { get; set; }
        public int FileExistingAction { get; set; }
        private DialogResult FileExistingConfirmation { get; set; }
        private int FileExistingConfirmCount { get; set; }
        public bool HasSettings {
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
        public string Status
        {
            get
            {
                return _status;
            }
        }
        public System.Drawing.Image Image 
        {
            get
            {
                return Properties.Resources.CopyTo;
            }
        }
        public bool Enabled { get; set; }
        public string FilePath { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }

        public CopyToOperator()
        {
            this.FileExistingAction = 1;//Ask
        }

        public bool Initialize()
        {
            return true;
        }
        public bool InitializeContextMenu(bool isMultiple)
        {
            this.Enabled = true;
            return true;
        }
        public bool PreOperate(bool isMultiple)
        {
            MultiFiles = isMultiple;
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.ShowNewFolderButton = true;
            dlgFolder.SelectedPath = this.Description;
            if (dlgFolder.ShowDialog(this.MainWnd) != DialogResult.OK)
                return false;
            this.Destination = dlgFolder.SelectedPath;
            this._status = string.Empty;
            this.FileExistingConfirmation = DialogResult.No;
            this.FileExistingConfirmCount = 0;
            return true;
        }

        public bool Operate()
        {
            FileInfo fi = null;
            try
            {
                fi = new FileInfo(this.FilePath);
                string newPath = System.IO.Path.Combine(this.Destination, fi.Name);
                if (System.IO.File.Exists(newPath))
                {
                    if (this.FileExistingAction == 0)//Ignore
                    {
                        this._status = "Existing => Ignored due to settings";
                        return true;
                    }
                    else if (this.FileExistingAction == 1)//Ask
                    {
                        if (this.FileExistingConfirmCount < 3)
                        {
                            this.FileExistingConfirmation = MessageBox.Show(string.Format("{0} is already exist.\nDo you want to overwrite it?", fi.Name), "File Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            this.FileExistingConfirmCount++;
                        }

                        if (this.FileExistingConfirmation == DialogResult.No)
                        {
                            this._status = "Existing => Ignored due to User confirmed";
                            return true;
                        }
                        else
                            this._status = string.Format("Copied to {0} (overwrite due to User confirmed)", newPath);
                    }
                    else if (this.FileExistingAction == 2)//Overwrite
                    {
                        this._status = string.Format("Copied to {0} (overwrite due to settings)", newPath);
                    }
                }
                else
                    this._status = string.Format("Copied to {0}", newPath);
                System.IO.File.Copy(fi.FullName, newPath, true);
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                _status = ex.Message;
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
            DialogResult res = frm.ShowDialog(owner);
            if (res == DialogResult.OK)
            {
                this.FileExistingAction = frm.FileExistingAction;
            }

            return res;
        }
    }
}
