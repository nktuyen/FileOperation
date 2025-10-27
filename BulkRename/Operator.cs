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

namespace BulkRename
{
    public class MyOperator : IOperator
    {
        public string Name { get;private set; }

        public string Title { get;private set; }

        public string Description { get;private set; }

        public string Status { get;private set; }

        public Image Image{ get; private set; }

        public bool Enabled { get; set; }

        public bool HasSettings { get; private set;}

        public bool HasAbout { get; private set; }

        public string CurrentFilePath { get; set; }
        public IWin32Window MainWnd { get; set; }
        private string NameTemplate { get; set; }
        private long FileCount { get; set; }
        private long FileIndex { get; set; }
        private Dictionary<string,ContextVariable> ContextVariables { get; set; }
        private MyFileInfo FirstFileInfo { get; set; }
        public MyOperator()
        {
            this.Name = "BuilkRename";
            this.Title = "Bulk Rename";
            this.Description = "Rename multiple files use name template";
            this.Image = Properties.Resources.BulkRename.ToBitmap();
            this.HasAbout = true;
            this.HasSettings = true;
            this.NameTemplate = string.Empty;
            this.ContextVariables = new Dictionary<string, ContextVariable>();
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

        public bool Operate()
        {
            FileInfo fi = null;
            bool res = false;
            try
            {
                fi = new FileInfo(CurrentFilePath);
                string parentDirectory = fi.DirectoryName;
                string fileName = fi.Name;
                string fileExt = fi.Extension;
                string fileTitle = fileName;
                int pos = fileName.LastIndexOf('.');
                if (pos > -1)
                    fileTitle = fileName.Substring(0, pos);

                if (this.FirstFileInfo == null)
                    this.FirstFileInfo = new MyFileInfo(fi);


                List<ContextVariable> contextVars = new List<ContextVariable>();
                contextVars.Add(new ContextVariableComputerName());
                contextVars.Add(new ContextVariableUserName());

                contextVars.Add(new ContextVariableDate(DateTime.Now));
                contextVars.Add(new ContextVariableYear(DateTime.Now));
                contextVars.Add(new ContextVariableMonth(DateTime.Now));
                contextVars.Add(new ContextVariableDay(DateTime.Now));
                contextVars.Add(new ContextVariableHour(DateTime.Now));
                contextVars.Add(new ContextVariableMinute(DateTime.Now));
                contextVars.Add(new ContextVariableSecond(DateTime.Now));

                contextVars.Add(new ContextVariableDate(FirstFileInfo.CreationTime));
                contextVars.Add(new ContextVariableYear(FirstFileInfo.CreationTime));
                contextVars.Add(new ContextVariableMonth(FirstFileInfo.CreationTime));
                contextVars.Add(new ContextVariableDay(FirstFileInfo.CreationTime));
                contextVars.Add(new ContextVariableHour(FirstFileInfo.CreationTime));
                contextVars.Add(new ContextVariableMinute(FirstFileInfo.CreationTime));
                contextVars.Add(new ContextVariableSecond(FirstFileInfo.CreationTime));

                contextVars.Add(new ContextVariableDate(fi.CreationTime));
                contextVars.Add(new ContextVariableYear(fi.CreationTime));
                contextVars.Add(new ContextVariableMonth(fi.CreationTime));
                contextVars.Add(new ContextVariableDay(fi.CreationTime));
                contextVars.Add(new ContextVariableHour(fi.CreationTime));
                contextVars.Add(new ContextVariableMinute(fi.CreationTime));
                contextVars.Add(new ContextVariableSecond(fi.CreationTime));

                contextVars.Add(new ContextVariableFilePath(fi));
                contextVars.Add(new ContextVariableFileName(fi));
                contextVars.Add(new ContextVariableFileTitle(fi));
                contextVars.Add(new ContextVariableFileExtension(fi));
                contextVars.Add(new ContextVariableFileSize(fi));

                contextVars.Add(new ContextVariableFirstFilePath(this.FirstFileInfo));
                contextVars.Add(new ContextVariableFirstFileName(this.FirstFileInfo));
                contextVars.Add(new ContextVariableFirstFileTitle(this.FirstFileInfo));
                contextVars.Add(new ContextVariableFirstFileExtension(this.FirstFileInfo));
                contextVars.Add(new ContextVariableFirstFileSize(this.FirstFileInfo));


                string outputFileName = this.NameTemplate;
                foreach(ContextVariable v in contextVars)
                {
                    outputFileName = outputFileName.Replace(v.Name, v.Value);
                }
                outputFileName = outputFileName.Replace("<FILE.INDEX>", this.FileIndex.ToString());
                outputFileName = outputFileName.Replace("<FILE_COUNT>", this.FileCount.ToString());
                string finalFilePath = System.IO.Path.Combine(parentDirectory, outputFileName);
                fi = null;
                System.IO.File.Move(this.CurrentFilePath, finalFilePath);
            }
            catch(System.Exception ex)
            {
                Debug.Print(ex.Message);
                this.Status = ex.Message;
                res = false;
            }

            this.FileIndex++;
            return res;
        }

        public bool PreOperate(long fileCount)
        {
            this.FileCount = fileCount;
            this.FileIndex = 0;
            this.FirstFileInfo = null;
            this.Status = string.Empty;
            return true;
        }

        public DialogResult ShowAbout(IWin32Window owner = null)
        {
            AboutForm frm = new AboutForm();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                
            }
            return res;
        }

        public DialogResult ShowSettings(IWin32Window owner = null)
        {
            SettingsForm frm = new SettingsForm();
            frm.NameTemplate = this.NameTemplate;
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.NameTemplate = frm.NameTemplate;
            }
            return res;
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objNameTemplate = null;

            try
            {
                Microsoft.Win32.RegistryKey myKey = regKey.OpenSubKey(this.Name);
                if (myKey != null)
                {
                    objNameTemplate = myKey.GetValue("NameTemplate");

                    this.NameTemplate = objNameTemplate as string;

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
                    myKey.SetValue("NameTemplate", this.NameTemplate, RegistryValueKind.String);

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
