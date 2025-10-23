using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Windows.Forms;

namespace FileOperation
{
    public class DeleteOperator : IOperator
    {
        public bool MoveToTrash { get; set; }
        private bool MultiFiles { get; set; }
        private string _status = string.Empty;
        public string Name
        {
            get
            {
                return "Delete";
            }
        }
        public string Description 
        {
            get
            {
                return "Delete File";
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
                return FileOperation.Properties.Resources.Cancel;
            }
            
        }
        public bool HasSettings
        {
            get
            {
                return true;
            }
        }

        public bool HasAbout
        {
            get
            {
                return false;
            }
        }

        public bool Enabled { get; set; }
        public string FilePath { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }

        public DeleteOperator()
        {
            this.Enabled = true;
            this.MoveToTrash = true;
        }

        public bool Initialize()
        {
            return true;
        }

        public bool InitializeContextMenu(bool isMultiple)
        {
            return true;
        }

        public bool PreOperate(bool isMultiple)
        {
            MultiFiles = isMultiple;
            DialogResult confirm = 0;
            if (isMultiple)
            {
                confirm = MessageBox.Show("Are you sure to delete selected files?", "Multiple Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                confirm = MessageBox.Show("Are you sure to delete selected file?", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (confirm != DialogResult.Yes)
                return false;

            _status = string.Empty;
            return true;
        }

        public bool Operate()
        {
            try
            {
                if (this.MoveToTrash)
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(FilePath, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                else
                    System.IO.File.Delete(this.FilePath);
                this.FilePath = string.Empty;
            }
            catch (System.Exception ex)
            {
                _status = ex.Message;
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
            return false;
        }

        public bool SaveSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            return false;
        }
    }
}
