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
        private bool MultiFiles { get; set; }
        private string _errMessage = string.Empty;
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
        public string ErrorMessage
        {
            get
            {
                return _errMessage;
            }
        }
        public System.Drawing.Bitmap Icon
        { 
            get
            {
                return FileOperation.Properties.Resources.Cancel;
            }
            
        }

        public bool Enabled { get; set; }
        public string FilePath { get; set; }
        public System.Windows.Forms.IWin32Window MainWnd { get; set; }

        public DeleteOperator()
        {
            this.Enabled = true;
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

            _errMessage = string.Empty;
            return true;
        }

        public bool Operate()
        {
            try
            {
                System.IO.File.Delete(this.FilePath);
                this.FilePath = string.Empty;
            }
            catch (System.Exception ex)
            {
                _errMessage = ex.Message;
                return false;
            }

            return true;
        }

        public  System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner)
        {
            return System.Windows.Forms.DialogResult.OK;
        }

        public System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner)
        {
            return System.Windows.Forms.DialogResult.OK;
        }
    }
}
