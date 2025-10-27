using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileOperation
{
    public class DeleteOperator : IOperator
    {
        public bool MoveToTrash { get; set; }
        private bool MultiFiles { get; set; }
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Description { get;private set; }
        public string Status { get;private set;}
        public System.Drawing.Image Image { get; private set; }
        public bool HasSettings { get; private set; }
        public bool HasAbout { get;private set; }
        public bool Enabled { get; set; }
        public string CurrentFilePath { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }

        public DeleteOperator()
        {
            this.Name = "Delete";
            this.Title = "Delete";
            this.Description = "Delete selected files from disk";
            this.Image = Properties.Resources.Cancel;
            this.HasSettings = true;
            this.Enabled = true;
            this.MoveToTrash = true;
        }

        public bool Initialize()
        {
            return true;
        }

        public bool InitializeContextMenu(long fileCount)
        {
            return true;
        }

        public bool PreOperate(long fileCount)
        {
            MultiFiles = fileCount> 1;
            DialogResult confirm = 0;
            if (fileCount > 1)
            {
                confirm = MessageBox.Show("Are you sure to delete selected files?", "Multiple Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                confirm = MessageBox.Show("Are you sure to delete selected file?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (confirm != DialogResult.Yes)
                return false;

            this.Status = string.Empty;
            return true;
        }

        public bool Operate()
        {
            try
            {
                if (this.MoveToTrash)
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(CurrentFilePath, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                else
                    System.IO.File.Delete(this.CurrentFilePath);
                this.CurrentFilePath = string.Empty;
            }
            catch (System.Exception ex)
            {
                this.Status = ex.Message;
                return false;
            }

            return true;
        }

        public  System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner)
        {
            AboutForm frm = new AboutForm();
            return frm.ShowDialog(owner);
        }

        public System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner)
        {
            DeleteOperatorSettingsForm frm = new DeleteOperatorSettingsForm();
            frm.MoveToTrash = this.MoveToTrash;
            DialogResult res = frm.ShowDialog(owner);
            if (res == DialogResult.OK)
            {
                this.MoveToTrash = frm.MoveToTrash;
            }

            return res;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objMoveToTrash = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objMoveToTrash = myKey.GetValue("MoveToTrash");
                    this.MoveToTrash = ((int)objMoveToTrash != 0);

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
                    myKey.SetValue("MoveToTrash", this.MoveToTrash ? 1 : 0, Microsoft.Win32.RegistryValueKind.DWord);
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
