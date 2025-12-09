using Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace FileOperation
{
    public partial class MainForm : Form
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [Flags]
        enum SHGFI : uint
        {
            /// <summary>get icon</summary>
            Icon = 0x000000100,
            /// <summary>get display name</summary>
            DisplayName = 0x000000200,
            /// <summary>get type name</summary>
            TypeName = 0x000000400,
            /// <summary>get attributes</summary>
            Attributes = 0x000000800,
            /// <summary>get icon location</summary>
            IconLocation = 0x000001000,
            /// <summary>return exe type</summary>
            ExeType = 0x000002000,
            /// <summary>get system icon index</summary>
            SysIconIndex = 0x000004000,
            /// <summary>put a link overlay on icon</summary>
            LinkOverlay = 0x000008000,
            /// <summary>show icon in selected state</summary>
            Selected = 0x000010000,
            /// <summary>get only specified attributes</summary>
            Attr_Specified = 0x000020000,
            /// <summary>get large icon</summary>
            LargeIcon = 0x000000000,
            /// <summary>get small icon</summary>
            SmallIcon = 0x000000001,
            /// <summary>get open icon</summary>
            OpenIcon = 0x000000002,
            /// <summary>get shell size icon</summary>
            ShellIconSize = 0x000000004,
            /// <summary>pszPath is a pidl</summary>
            PIDL = 0x000000008,
            /// <summary>use passed dwFileAttribute</summary>
            UseFileAttributes = 0x000000010,
            /// <summary>apply the appropriate overlays</summary>
            AddOverlays = 0x000000020,
            /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
            OverlayIndex = 0x000000040,
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);

        private const int STATUS_COLUMN_INDEX = 6;
        private Dictionary<Control, bool> EnabledControlsMap { get; set; }
        private List<IFilter> Filters { get; set; }
        private List<IOperator> Operators { get; set; }
        private System.Timers.Timer Timer { get; set; }
        private string WorkingFile { get; set; }
        private string RegistryKeyPath { get; set; }
        private bool LoadRecentFilesAtStartup { get; set; }
        private List<string> RecentFiles { get;set; }
        private ToolStripMenuItem LoadRecentListToolStripMenuItem { get; set; }
        private List<System.Drawing.Image> RecentMenuImages { get; set; }

        private ToolStripItem addFilesMenuItem = null;
        private ToolStripItem addFilesinFolderMenuItem = null;
        private ToolStripItem removeSelectedFilesMenuItem = null;
        private ToolStripItem removeAllFilesMenuItem = null;

        public MainForm()
        {
            InitializeComponent();
            EnabledControlsMap = new Dictionary<Control, bool>();
            Filters = new List<IFilter>();
            Operators=new List<IOperator>();
            WorkingFile = string.Empty;
            RecentFiles = new List<string>();

            RecentMenuImages = new List<Image>();
            RecentMenuImages.Add(Properties.Resources._1);
            RecentMenuImages.Add(Properties.Resources._2);
            RecentMenuImages.Add(Properties.Resources._3);
            RecentMenuImages.Add(Properties.Resources._4);
            RecentMenuImages.Add(Properties.Resources._5);
            RecentMenuImages.Add(Properties.Resources._6);
            RecentMenuImages.Add(Properties.Resources._7);
            RecentMenuImages.Add(Properties.Resources._8);
            RecentMenuImages.Add(Properties.Resources._9);
            RecentMenuImages.Add(Properties.Resources._10);
        }

        private System.Drawing.Icon GetFileIcon(string name)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            uint flags = (uint)SHGFI.SmallIcon | (uint)SHGFI.Icon; // include the small icon flag
            SHGetFileInfo(name, 0, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi), flags);
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            DestroyIcon(shfi.hIcon);
            return icon;

        }
        private void EnableControls(Control ctrl, bool enabled)
        {
            EnabledControlsMap[ctrl] = ctrl.Enabled; //Backup state
            if (ctrl.InvokeRequired)
            {
                ctrl.Invoke(new MethodInvoker(delegate {
                    ctrl.Enabled = enabled; //Change new state
                }));
            }
            else
            {
                ctrl.Enabled = enabled; //Change new state
            }
        }

        private string AutoFileSize(long size)
        {
            string res = string.Empty;
            if (size >= Math.Pow(1024, 1))
            {
                if (size >= Math.Pow(1024, 2))
                {
                    if (size >= Math.Pow(1024, 3))
                    {
                        if (size >= Math.Pow(1024, 4))
                        {
                            if (size >= Math.Pow(1024, 5))
                            {
                                res = string.Format("{0} PB", (long)size / (long)Math.Pow(1024, 5));
                            }
                            else
                                res = string.Format("{0} TB", (long)size / (long)Math.Pow(1024, 4));
                        }
                        else
                            res = string.Format("{0} GB", (long)size / (long)Math.Pow(1024, 3));
                    }
                    else
                        res = string.Format("{0} MB", (long)size / (long)Math.Pow(1024, 2));
                }
                else
                    res = string.Format("{0} KB", (long)size/(long)Math.Pow(1024,1));
            }
            else
                res = string.Format("{0} byte(s)", size);

            return res;
        }

        private void RestoreControlEnabled(Control ctrl)
        {
            if (EnabledControlsMap.ContainsKey(ctrl))
                ctrl.Enabled = EnabledControlsMap[ctrl];
        }

        private int LoadOperators()
        {
            int count = 0;
            Operators.Clear();
            //Add default operator
            IOperator deleteOperator = new DeleteOperator();
            if (deleteOperator != null)
            {
                deleteOperator.Initialize();
                Operators.Add(deleteOperator);
                count++;
            }

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string assemblyPath = executingAssembly.Location;
            int pos = assemblyPath.LastIndexOf("\\");
            if (pos > -1)
                assemblyPath = assemblyPath.Substring(0, pos);
            string opeartorsPath = System.IO.Path.Combine(assemblyPath, "Operators");
            if (!System.IO.Directory.Exists(opeartorsPath))
                return count;

            DirectoryInfo di = new DirectoryInfo(opeartorsPath);
            foreach (FileInfo fi in di.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(fi.FullName);
                if (assembly != null)
                {
                    Type pluginType = null;
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(IOperator).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            pluginType = type;
                            break;
                        }
                    }
                    if (pluginType != null)
                    {
                        IOperator oper = (IOperator)Activator.CreateInstance(pluginType);
                        if (oper != null)
                        {
                            oper.Initialize();
                            Operators.Add(oper);
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private void PopulateOperators()
        {
            foreach(IOperator oper in this.Operators)
            {
                if (oper.SettingsForm != null)
                {
                    ToolStripMenuItem operSettingsItem = (ToolStripMenuItem)settingsOperatorsToolStripMenuItem.DropDownItems.Add(oper.Title);
                    operSettingsItem.Tag = oper;
                    operSettingsItem.Image = oper.Image;
                    operSettingsItem.Click += new EventHandler(operSettingsMenuItemToolStripMenuItem_Click);
                }

                if (oper.AboutForm != null)
                {
                    ToolStripMenuItem operAboutItem = (ToolStripMenuItem)aboutOperatorsToolStripMenuItem.DropDownItems.Add(oper.Title);
                    operAboutItem.Tag = oper;
                    operAboutItem.Image = oper.Image;
                    operAboutItem.Click += new EventHandler(operAboutMenuItemToolStripMenuItem_Click);
                }
            }
        }

        private string[] LoadRecentListFiles(RegistryKey regKey, int max = 10)
        {
            List<string> recentFiles = new List<string>(); 
            if (regKey == null)
                return recentFiles.ToArray();

            object objValueData = null;
            string filePath = string.Empty;
            try
            {
                foreach (string valueName in regKey.GetValueNames())
                {
                    objValueData = regKey.GetValue(valueName);
                    if (objValueData != null)
                    { 
                        filePath = objValueData as string;
                        if (System.IO.File.Exists(filePath))
                        {
                            if (recentFiles.Count < max)
                                recentFiles.Add(objValueData as string);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
            }

            return recentFiles.ToArray();
        }

        public bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null)
        {
            if (regKey == null)
                return false;

            object objWorkingFile = null;
            object objLoadRecentFile = null;

            try
            {
                objWorkingFile = regKey.GetValue("WorkingFile");
                objLoadRecentFile = regKey.GetValue("LoadRecentFile");


                if(objWorkingFile != null)
                    this.WorkingFile = objWorkingFile as string;
                if (!System.IO.File.Exists(this.WorkingFile))
                    this.WorkingFile = string.Empty;

                if (objLoadRecentFile != null)
                    this.LoadRecentFilesAtStartup = ((int)objLoadRecentFile != 0);

                regKey.Close();
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
                if (regKey != null)
                {
                    regKey.SetValue("WorkingFile", this.WorkingFile, Microsoft.Win32.RegistryValueKind.String);
                    regKey.SetValue("LoadRecentFile", this.LoadRecentFilesAtStartup ? 1 : 0, Microsoft.Win32.RegistryValueKind.DWord);

                    regKey.Close();
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

            return true;
        }

        private int LoadFilters()
        {
            int count = 0;
            Filters.Clear();

            //Add default filter
            IFilter nameFilter = new NameFilter();
            if (nameFilter != null)
            {
                nameFilter.Initialize();
                Filters.Add(nameFilter);
                count++;
            }

            IFilter sizeFilter = new SizeFilter();
            if (sizeFilter != null)
            {
                sizeFilter.Initialize();
                Filters.Add(sizeFilter);
                count++;
            }

            IFilter dateFilter = new DateFilter();
            if (dateFilter != null)
            {
                dateFilter.Initialize();
                Filters.Add(dateFilter);
                count++;
            }

            IFilter attrFilter = new AttributesFilter();
            if (attrFilter != null)
            {
                attrFilter.Initialize();
                Filters.Add(attrFilter);
                count++;
            }

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string assemblyPath = executingAssembly.Location;
            int pos = assemblyPath.LastIndexOf("\\");
            if (pos > -1)
                assemblyPath = assemblyPath.Substring(0, pos);
            string filtersPath = System.IO.Path.Combine(assemblyPath, "Filters");
            if (!System.IO.Directory.Exists(filtersPath))
                return count;
            DirectoryInfo di = new DirectoryInfo(filtersPath);
            foreach (FileInfo fi in di.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(fi.FullName);
                if (assembly != null)
                {
                    Type pluginType = null;
                    foreach (Type type in assembly.GetTypes())
                    {
                        if (typeof(IFilter).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            pluginType = type;
                            break;
                        }
                    }
                    if (pluginType != null)
                    {
                        IFilter filter = (IFilter)Activator.CreateInstance(pluginType);
                        if (filter != null)
                        {
                            filter.Initialize();
                            Filters.Add(filter);
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private void PopulateFilters()
        {
            foreach(IFilter filter in this.Filters)
            {
                ToolStripMenuItem filterItem = (ToolStripMenuItem)filterToolStripMenuItem.DropDownItems.Add(filter.Title);
                filterItem.Checked = filter.Enabled;
                filterItem.Tag = filter;
                filterItem.Click += new EventHandler(filterMenuItemToolStripMenuItem_Click);

                if (filter.SettingsForm != null)
                {
                    ToolStripMenuItem filterSettingsItem = (ToolStripMenuItem)settingsFiltersToolStripMenuItem.DropDownItems.Add(filter.Title);
                    filterSettingsItem.Tag = filter;
                    filterSettingsItem.Click += new EventHandler(filterSettingsMenuItemToolStripMenuItem_Click);
                }

                if (filter.AboutForm != null)
                {
                    ToolStripMenuItem filterAboutItem = (ToolStripMenuItem)aboutFiltersToolStripMenuItem.DropDownItems.Add(filter.Title);
                    filterAboutItem.Tag = filter;
                    filterAboutItem.Click += new EventHandler(filterAboutMenuItemToolStripMenuItem_Click);
                }
            }
        }
        private void RecentMenuItemClicked(object sender, EventArgs e)
        {
            ToolStripItem recentItem = sender as ToolStripItem;
            if (recentItem != null)
            {
                string filePath = recentItem.Text;
                if (!System.IO.File.Exists(filePath))
                {
                    MessageBox.Show("The recent file is not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<string> files = new List<string>();
                using (StreamReader fileStream = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line = string.Empty;
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (line.Length > 0)
                        {
                            try
                            {
                                if (Regex.IsMatch(line, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*"))
                                {
                                    files.Add(line);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                Debug.Print(ex.Message);
                                continue;
                            }
                        }
                    }
                }
                this.WorkingFile = dlgOpenList.FileName;
                lvwFiles.Items.Clear();
                MainImgList.Images.Clear();
                if (bgwAddFiles.IsBusy)
                    bgwAddFiles.CancelAsync();
                bgwAddFiles.RunWorkerAsync(files.ToArray());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadOperators();
            Filters.Sort(delegate (IFilter f1, IFilter f2) { return f1.Name.CompareTo(f2.Name); });
            Operators.Sort(delegate (IOperator o1, IOperator o2) { return o1.Name.CompareTo(o2.Name); });
            LoadSettings();
            PopulateFilters();
            PopulateOperators();

            lvwFiles.Items.Clear();
            MainImgList.Images.Clear();
        }

        private void filterAboutMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IFilter filter = (IFilter)menuItem.Tag;
            if (filter != null)
            {
                if (filter.AboutForm != null)
                    ((System.Windows.Forms.Form)filter.AboutForm).ShowDialog(this);
            }
        }

        private void filterSettingsMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IFilter filter = (IFilter)menuItem.Tag;
            if (filter != null)
            {
                if (filter.SettingsForm != null)
                    ((System.Windows.Forms.Form)filter.SettingsForm).ShowDialog(this);
            }
        }

        private void filterMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IFilter filter = (IFilter)menuItem.Tag;
            if (filter != null)
            {
                filter.Enabled = !filter.Enabled;
                menuItem.Checked = filter.Enabled;
            }
        }

        private void operSettingsMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IOperator oper = (IOperator)menuItem.Tag;
            if (oper != null)
            {
                if (oper.SettingsForm != null)
                    ((System.Windows.Forms.Form) oper.SettingsForm).ShowDialog(this);
            }
        }

        private void operAboutMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IOperator oper = (IOperator)menuItem.Tag;
            if (oper != null)
            {
                if(oper.AboutForm != null)
                    ((System.Windows.Forms.Form)oper.AboutForm).ShowDialog(this);
            }
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgFileOpen.Filter = "All Files(*.*)|*.*||";
            if (dlgFileOpen.ShowDialog(this) != DialogResult.OK)
                return;
            if (bgwAddFiles.IsBusy)
                bgwAddFiles.CancelAsync();
            bgwAddFiles.RunWorkerAsync(dlgFileOpen.FileNames);
        }

        private void addFilesInFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgFolderBrowser.ShowDialog(this) != DialogResult.OK)
                return;

            if (bgwAddFilesInFolder.IsBusy)
                bgwAddFilesInFolder.CancelAsync();
            bgwAddFilesInFolder.RunWorkerAsync(dlgFolderBrowser.SelectedPath);
        }

        private void bgwAddFiles_PreDoWork(object sender, DoWorkEventArgs e)
        {
            EnableControls(MainMenu, false);
            EnableControls(filesContextMenuStrip, false);

            string[] files = e.Argument as string[];

            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    MainProgressbar.Style = ProgressBarStyle.Continuous;
                    MainProgressbar.Maximum = files.Length;
                    MainProgressbar.Minimum = 0;
                    MainProgressbar.Visible = true;
                }));
            }
            else
            {
                MainProgressbar.Style = ProgressBarStyle.Continuous;
                MainProgressbar.Maximum = files.Length;
                MainProgressbar.Minimum = 0;
                MainProgressbar.Visible = true;
            }

            if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new MethodInvoker(delegate
                {
                    btnCancel.Visible = true;
                    btnCancel.Focus();
                }));
            }
            else
            {
                btnCancel.Visible = true;
                btnCancel.Focus();
            }

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = string.Empty;
                }));
            }
            else
            {
                lblStatus.Text = string.Empty;
            }

            
        }

        private void bgwAddFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwAddFiles_PreDoWork(sender, e);

            string[] files = e.Argument as string[];
            int percent = 0;
            int count = 0;
            bool bSatisfied = false;
            FileInfo fi = null;
            System.Drawing.Icon fileIcon = null;
            foreach (string filePath in files)
            {
                if (bgwAddFiles.CancellationPending)
                    break;
                percent++;
                bgwAddFiles.ReportProgress(percent, filePath);
                bSatisfied = true;
                foreach (IFilter filter in this.Filters)
                {
                    if (bgwAddFiles.CancellationPending)
                        break;
                    if (filter.Enabled && !filter.Filter(filePath))
                    {
                        bSatisfied = false;
                        break;
                    }
                }

                if (!bSatisfied)
                    continue;

                count++;
                try
                {
                    fi = new FileInfo(filePath);
                    fileIcon = GetFileIcon(filePath);
                }
                catch (System.Exception ex)
                {
                    Debug.Print(ex.Message);
                    fi = null;
                }

                if (lvwFiles.InvokeRequired)
                {
                    lvwFiles.Invoke(new MethodInvoker(delegate
                    {
                        ListViewItem item = lvwFiles.Items.Add(count.ToString());
                        if (fileIcon != null)
                        {
                            item.ImageIndex = MainImgList.Images.Count;
                            MainImgList.Images.Add(fileIcon);
                        }
                        item.SubItems.Add(filePath);
                        if (fi != null)
                        {
                            item.SubItems.Add(fi.Extension.StartsWith(".")?fi.Extension.Substring(1): fi.Extension);
                            item.SubItems.Add(AutoFileSize(fi.Length));
                            item.SubItems.Add(fi.Attributes.ToString());
                            item.SubItems.Add(fi.CreationTime.ToLocalTime().ToString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                        }
                        item.SubItems.Add(string.Empty);//Status
                    }));
                }
                else
                {
                    ListViewItem item = lvwFiles.Items.Add(count.ToString());
                    if (fileIcon != null)
                    {
                        item.ImageIndex = MainImgList.Images.Count;
                        MainImgList.Images.Add(fileIcon);
                    }
                    item.SubItems.Add(filePath);
                    if (fi != null)
                    {
                        item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                        item.SubItems.Add(AutoFileSize(fi.Length));
                        item.SubItems.Add(fi.Attributes.ToString());
                        item.SubItems.Add(fi.CreationTime.ToLocalTime().ToString());
                    }
                    else
                    {
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(string.Empty);
                    }
                    item.SubItems.Add(string.Empty);//Status
                }
            }
        }

        private void bgwAddFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainProgressbar.Value = e.ProgressPercentage;
            string filePath = e.UserState as string;
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = filePath;
                }));
            }
            else
            {
                lblStatus.Text = filePath;
            }
        }

        private void bgwAddFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RestoreControlEnabled(MainMenu);
            RestoreControlEnabled(filesContextMenuStrip);

            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    MainProgressbar.Visible = false;
                }));
            }
            else
            {
                MainProgressbar.Visible = false;
            }

            if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new MethodInvoker(delegate
                {
                    btnCancel.Visible = false;
                }));
            }
            else
            {
                btnCancel.Visible = false;
            }

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
                }));
            }
            else
            {
                lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
            }

            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
        }

        private void bgwAddFilesInFolder_PreDoWork(object sender, DoWorkEventArgs e)
        {
            EnableControls(MainMenu, false);
            EnableControls(filesContextMenuStrip, false);

            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    MainProgressbar.Style = ProgressBarStyle.Marquee;
                    MainProgressbar.Minimum = 0;
                    MainProgressbar.Maximum = 100;
                    MainProgressbar.Value = 0;
                    MainProgressbar.MarqueeAnimationSpeed = 10;
                    MainProgressbar.Visible = true;
                }));
            }
            else
            {
                MainProgressbar.Style = ProgressBarStyle.Marquee;
                MainProgressbar.Minimum = 0;
                MainProgressbar.Maximum = 100;
                MainProgressbar.Value = 0;
                MainProgressbar.MarqueeAnimationSpeed = 10;
                MainProgressbar.Visible = true;
            }

            if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new MethodInvoker(delegate
                {
                    btnCancel.Visible = true;
                    btnCancel.Focus();
                }));
            }
            else
            {
                btnCancel.Visible = true;
                btnCancel.Focus();
            }

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = string.Empty;
                }));
            }
            else
            {
                lblStatus.Text = string.Empty;
            }

            Timer = new System.Timers.Timer(MainProgressbar.MarqueeAnimationSpeed);
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerElapsed);
            Timer.Start();
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    if (MainProgressbar.Value < MainProgressbar.Maximum)
                        MainProgressbar.Value += 10;
                    else
                        MainProgressbar.Value = MainProgressbar.Minimum;
                }));
            }
            else
            {
                if (MainProgressbar.Value < MainProgressbar.Maximum)
                    MainProgressbar.Value += 10;
                else
                    MainProgressbar.Value = MainProgressbar.Minimum;
            }
        }

        private void WalkDir(string dirName, int currentDepth, int maxDepth = -1)
        {
            if (maxDepth != -1 && currentDepth >= maxDepth)
                return;
            int count = lvwFiles.Items.Count;
            FileInfo fi = null;
            bool bSatisfied = false;
            System.Drawing.Icon fileIcon = null;
            try
            {
                foreach (string filePath in Directory.GetFiles(dirName))
                {
                    if (bgwDropFiles.CancellationPending || bgwAddFilesInFolder.CancellationPending)
                        break;
                    bSatisfied = true;
                    foreach (IFilter filter in Filters)
                    {
                        if (bgwDropFiles.CancellationPending || bgwAddFilesInFolder.CancellationPending)
                            break;

                        if (filter.Enabled && !filter.Filter(filePath))
                        {
                            bSatisfied = false;
                            break;
                        }
                    }

                    if (!bSatisfied)
                        continue;

                    count++;
                    try
                    {
                        fi = new FileInfo(filePath);
                        fileIcon = GetFileIcon(filePath);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.Print(ex.Message);
                        fi = null;
                    }
                    if (lvwFiles.InvokeRequired)
                    {
                        lvwFiles.Invoke(new MethodInvoker(delegate
                        {
                            ListViewItem item = lvwFiles.Items.Add(count.ToString());
                            if (fileIcon != null)
                            {
                                item.ImageIndex = MainImgList.Images.Count;
                                MainImgList.Images.Add(fileIcon);
                            }
                            item.SubItems.Add(filePath);
                            if (fi != null)
                            {
                                item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                                item.SubItems.Add(AutoFileSize(fi.Length));
                                item.SubItems.Add(fi.Attributes.ToString());
                                item.SubItems.Add(fi.CreationTime.ToLocalTime().ToString());
                            }
                            else
                            {
                                item.SubItems.Add(string.Empty);
                                item.SubItems.Add(string.Empty);
                                item.SubItems.Add(string.Empty);
                                item.SubItems.Add(string.Empty);
                            }
                            item.SubItems.Add(string.Empty);//Status
                        }));
                    }
                    else
                    {
                        ListViewItem item = lvwFiles.Items.Add(count.ToString());
                        if (fileIcon != null)
                        {
                            item.ImageIndex = MainImgList.Images.Count;
                            MainImgList.Images.Add(fileIcon);
                        }
                        item.SubItems.Add(filePath);
                        if (fi != null)
                        {
                            item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                            item.SubItems.Add(AutoFileSize(fi.Length));
                            item.SubItems.Add(fi.Attributes.ToString());
                            item.SubItems.Add(fi.CreationTime.ToLocalTime().ToString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                        }
                        item.SubItems.Add(string.Empty);//Status
                    }
                    if (bgwAddFilesInFolder.IsBusy)
                        bgwAddFilesInFolder.ReportProgress(count, filePath);
                    else if (bgwDropFiles.IsBusy)
                        bgwDropFiles.ReportProgress(count, filePath);
                }

                foreach (string d in Directory.GetDirectories(dirName))
                {
                    if (bgwDropFiles.CancellationPending || bgwAddFilesInFolder.CancellationPending)
                        break;
                    this.WalkDir(d, currentDepth, maxDepth);
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }

        private void bgwAddFilesInFolder_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwAddFilesInFolder_PreDoWork(sender, e);
            string directoryPath = e.Argument as string;
            WalkDir(directoryPath, 0);
        }

        private void bgwAddFilesInFolder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string filePath = e.UserState as string;

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = filePath;
                }));
            }
            else
            {
                lblStatus.Text = filePath;
            }
        }

        private void bgwAddFilesInFolder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RestoreControlEnabled(MainMenu);
            RestoreControlEnabled(filesContextMenuStrip);

            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    MainProgressbar.Visible = false;
                }));
            }
            else
            {
                MainProgressbar.Visible = false;
            }

            if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new MethodInvoker(delegate
                {
                    btnCancel.Visible = false;
                }));
            }
            else
            {
                btnCancel.Visible = false;
            }

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
                }));
            }
            else
            {
                lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
            }

            if (this.Timer != null)
            {
                this.Timer.Stop();
                this.Timer = null;
            }

            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bgwAddFiles.IsBusy)
            {
                bgwAddFiles.CancelAsync();
            }
            else if (bgwAddFilesInFolder.IsBusy)
            {
                bgwAddFilesInFolder.CancelAsync();
            }
            else if(bgwDropFiles.IsBusy)
                bgwDropFiles.CancelAsync();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCancel.Visible && e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }

        private void lvwFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCancel.Visible && e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.A && e.Control)
            {
                bool bSelectedAll = lvwFiles.SelectedItems.Count == lvwFiles.Items.Count;
                foreach (ListViewItem item in lvwFiles.Items)
                {
                    if (bSelectedAll)
                        item.Selected = false;
                    else
                        item.Selected = true;
                }
            }
            txtListViewItem.Visible = false;
        }

        private void btnCancel_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnCancel.Visible && e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem operItem = (ToolStripItem)sender;
            IOperator oper = null;
            if(operItem != null)
                oper = (IOperator)operItem.Tag;
            if(oper != null)
            {
                if(!oper.PreOperate(lvwFiles.SelectedItems.Count))
                    return;
                List<ListViewItem> deletedItems =new List<ListViewItem>();
                foreach (ListViewItem item in lvwFiles.SelectedItems)
                {
                    item.SubItems[STATUS_COLUMN_INDEX].Text=string.Empty;
                    string filePath = item.SubItems[1].Text;
                    oper.CurrentFilePath = filePath;
                    if (oper.Operate())
                    {
                        if (oper.CurrentFilePath.Length <= 0) //Deleted
                        {
                            deletedItems.Add(item);
                        }
                        else
                        {
                            if (oper.CurrentFilePath != filePath) //Name changed
                            {
                                item.SubItems[1].Text = oper.CurrentFilePath;
                            }
                        }
                    }
                    item.SubItems[STATUS_COLUMN_INDEX].Text = oper.Status;

                }

                if (deletedItems.Count > 0)
                {
                    deletedItems.Sort((a, b) => a.Index.CompareTo(b.Index));
                    int minIndex = deletedItems[0].Index;
                    foreach (ListViewItem item in deletedItems)
                    {
                        lvwFiles.Items.Remove(item);
                    }
                    //Correct Nb column
                    for (int i = minIndex; i < lvwFiles.Items.Count; i++)
                    {
                        minIndex = i+1;
                        ListViewItem item = lvwFiles.Items[i];
                        item.SubItems[0].Text = minIndex.ToString();
                    }

                    saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
                    lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
                }
            }
        }

        private void filesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            filesContextMenuStrip.Items.Clear();
            if(addFilesMenuItem == null)
            {
                addFilesMenuItem = new ToolStripMenuItem("Add Files");
                addFilesMenuItem.Click += addFilesContextMenuItem_Click;
            }
            filesContextMenuStrip.Items.Add(addFilesMenuItem);

            if (addFilesinFolderMenuItem == null)
            {
                addFilesinFolderMenuItem = new ToolStripMenuItem("Add Files in Folder");
                addFilesinFolderMenuItem.Click += addFilesInFolderContextMenuItem_Click;
            }
            filesContextMenuStrip.Items.Add(addFilesinFolderMenuItem);

            if (lvwFiles.Items.Count > 0)
            {
                if (lvwFiles.SelectedItems.Count > 0)
                {
                    if (removeSelectedFilesMenuItem == null)
                    {
                        removeSelectedFilesMenuItem = new ToolStripMenuItem("Remove");
                        removeSelectedFilesMenuItem.Click += removeContextMenuItem_Click;
                    }
                    filesContextMenuStrip.Items.Add(removeSelectedFilesMenuItem);
                }

                if (removeAllFilesMenuItem == null)
                {
                    removeAllFilesMenuItem = new ToolStripMenuItem("Remove All");
                    removeAllFilesMenuItem.Click += removeAllContextMenuItem_Click;
                }
                filesContextMenuStrip.Items.Add(removeAllFilesMenuItem);
            }

            if (lvwFiles.SelectedItems.Count <= 0)
                return;

            filesContextMenuStrip.Items.Add("-");

            foreach (IOperator oper in Operators)
            {
                ToolStripItem operItem = filesContextMenuStrip.Items.Add(oper.Title);
                if (operItem != null)
                {
                    operItem.Tag = oper;
                    operItem.Click += new EventHandler(filesToolStripMenuItem_Click);
                    operItem.Image = oper.Image;
                    if (!oper.InitializeContextMenu(lvwFiles.SelectedItems.Count))
                        filesContextMenuStrip.Items.Remove(operItem);
                    else
                        operItem.Enabled = oper.Enabled;
                }
            }
        }

        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            txtListViewItem.Visible = false;
        }

        private void lvwFiles_ItemActivate(object sender, EventArgs e)
        {
            txtListViewItem.Visible = false;
        }

        private void lvwFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           ListViewHitTestInfo hittestInfo =  lvwFiles.HitTest(e.X, e.Y);
           if (hittestInfo != null)
           {
               if (hittestInfo.Location == ListViewHitTestLocations.Label)
               {
                   if (hittestInfo.Item.SubItems.IndexOf(hittestInfo.SubItem) == 1)
                   {
                       txtListViewItem.Parent = lvwFiles;
                       txtListViewItem.ReadOnly = false;
                       txtListViewItem.Font = lvwFiles.Font;
                       txtListViewItem.Location = hittestInfo.SubItem.Bounds.Location;
                       txtListViewItem.Size = new Size(hittestInfo.SubItem.Bounds.Size.Width, hittestInfo.SubItem.Bounds.Size.Height - 1);
                       txtListViewItem.Visible = true;
                       txtListViewItem.Text = hittestInfo.SubItem.Text;
                       txtListViewItem.Focus();
                   }
               }
           }
        }

        private void txtListViewItem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                txtListViewItem.Visible = false;
            else if (e.KeyCode == Keys.Return)
            {
                ListViewItem selItem = lvwFiles.SelectedItems[0];
                if (selItem == null)
                {
                    txtListViewItem.Visible = false;
                    return;
                }
                string oldCurrentFilePath = selItem.SubItems[1].Text;
                string newCurrentFilePath = txtListViewItem.Text;
                if (string.Compare(oldCurrentFilePath, newCurrentFilePath, true) != 0)//Changed
                {
                    try
                    {
                        System.IO.File.Move(oldCurrentFilePath, newCurrentFilePath);
                        selItem.SubItems[1].Text = newCurrentFilePath;
                        selItem.SubItems[STATUS_COLUMN_INDEX].Text = string.Empty;
                        txtListViewItem.Visible = false;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        selItem.SubItems[STATUS_COLUMN_INDEX].Text = ex.Message;
                        txtListViewItem.Focus();
                    }
                }
            }
        }

        private void lvwFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtListViewItem.Visible = false;
        }

        private void lvwFiles_FontChanged(object sender, EventArgs e)
        {
            txtListViewItem.Visible = false;
        }

        private void lvwFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lvwFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (bgwDropFiles.IsBusy)
                bgwDropFiles.CancelAsync();
            bgwDropFiles.RunWorkerAsync(paths);
        }

        private void bgwDropFiles_PreDoWork(object sender, DoWorkEventArgs e)
        {
            EnableControls(MainMenu, false);
            EnableControls(filesContextMenuStrip, false);

            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    MainProgressbar.Style = ProgressBarStyle.Marquee;
                    MainProgressbar.Minimum = 0;
                    MainProgressbar.Maximum = 100;
                    MainProgressbar.Value = 0;
                    MainProgressbar.MarqueeAnimationSpeed = 10;
                    MainProgressbar.Visible = true;
                }));
            }
            else
            {
                MainProgressbar.Style = ProgressBarStyle.Marquee;
                MainProgressbar.Minimum = 0;
                MainProgressbar.Maximum = 100;
                MainProgressbar.Value = 0;
                MainProgressbar.MarqueeAnimationSpeed = 10;
                MainProgressbar.Visible = true;
            }

            if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new MethodInvoker(delegate
                {
                    btnCancel.Visible = true;
                    btnCancel.Focus();
                }));
            }
            else
            {
                btnCancel.Visible = true;
                btnCancel.Focus();
            }

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = string.Empty;
                }));
            }
            else
            {
                lblStatus.Text = string.Empty;
            }

            Timer = new System.Timers.Timer(MainProgressbar.MarqueeAnimationSpeed);
            Timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerElapsed);
            Timer.Start();
        }

        private void bgwDropFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            bgwDropFiles_PreDoWork(sender, e);
            string[] paths = e.Argument as string[];
            int count = lvwFiles.Items.Count;
            FileInfo fi = null;
            bool satisfied = false;
            System.Drawing.Icon fileIcon = null;
            bool bIsDir = false;
            foreach (string filePath in paths)
            {
                if (bgwDropFiles.CancellationPending)
                    break;

                try
                {
                    bIsDir = ((System.IO.File.GetAttributes(filePath) & FileAttributes.Directory) == FileAttributes.Directory);
                }
                catch (System.Exception ex)
                {
                    Debug.Print(ex.Message);
					continue;
                }

                if (bIsDir)
                {
                    WalkDir(filePath, 0);
                }
                else
                {
                    satisfied = true;
                    foreach (IFilter filter in Filters)
                    {
                        if (bgwDropFiles.CancellationPending)
                        {
                            satisfied = false;
                            break;
                        }
                        if (filter.Enabled && !filter.Filter(filePath))
                        {
                            satisfied = false;
                            break;
                        }
                    }

                    if (!satisfied)
                        continue;

                    try
                    {
                        fi = new FileInfo(filePath);
                        fileIcon = GetFileIcon(filePath);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.Print(ex.Message);
                        fi = null;
                    }

                    count = lvwFiles.Items.Count;
                    count++;
                    if (lvwFiles.InvokeRequired)
                    {
                        lvwFiles.Invoke(new MethodInvoker(delegate
                        {
                            ListViewItem item = lvwFiles.Items.Add(count.ToString());
                            if (fileIcon != null)
                            {
                                item.ImageIndex = MainImgList.Images.Count;
                                MainImgList.Images.Add(fileIcon);
                            }
                            item.SubItems.Add(filePath);
                            if (fi != null)
                            {
                                item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                                item.SubItems.Add(AutoFileSize(fi.Length));
                                item.SubItems.Add(fi.Attributes.ToString());
                                item.SubItems.Add(fi.CreationTime.ToLocalTime().ToString());
                            }
                            else
                            {
                                item.SubItems.Add(string.Empty);
                                item.SubItems.Add(string.Empty);
                                item.SubItems.Add(string.Empty);
                                item.SubItems.Add(string.Empty);
                            }
                            item.SubItems.Add(string.Empty);//Status
                        }));
                    }
                    else
                    {
                        ListViewItem item = lvwFiles.Items.Add(count.ToString());
                        if (fileIcon != null)
                        {
                            item.ImageIndex = MainImgList.Images.Count;
                            MainImgList.Images.Add(fileIcon);
                        }
                        item.SubItems.Add(filePath);
                        if (fi != null)
                        {
                            item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                            item.SubItems.Add(AutoFileSize(fi.Length));
                            item.SubItems.Add(fi.Attributes.ToString());
                            item.SubItems.Add(fi.CreationTime.ToLocalTime().ToString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                        }
                        item.SubItems.Add(string.Empty);//Status
                    }

                    bgwDropFiles.ReportProgress(count, filePath);
                }
            }
        }

        private void bgwDropFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string filePath = e.UserState as string;
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = filePath;
                }));
            }
            else
            {
                lblStatus.Text = filePath;
            }
        }

        private void bgwDropFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RestoreControlEnabled(MainMenu);
            RestoreControlEnabled(filesContextMenuStrip);

            if (MainProgressbar.InvokeRequired)
            {
                MainProgressbar.Invoke(new MethodInvoker(delegate
                {
                    MainProgressbar.Visible = false;
                }));
            }
            else
            {
                MainProgressbar.Visible = false;
            }

            if (btnCancel.InvokeRequired)
            {
                btnCancel.Invoke(new MethodInvoker(delegate
                {
                    btnCancel.Visible = false;
                }));
            }
            else
            {
                btnCancel.Visible = false;
            }

            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new MethodInvoker(delegate
                {
                    lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
                }));
            }
            else
            {
                lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
            }

            if (this.Timer != null)
            {
                this.Timer.Stop();
                this.Timer = null;
            }

            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
        }

        private void loadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpenList.Title = "Open list file";
            dlgOpenList.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            dlgOpenList.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            if (dlgOpenList.ShowDialog() != DialogResult.OK)
                return;
            this.RecentFiles.Add(dlgOpenList.FileName);

            List<string> files = new List<string>();
            using (StreamReader fileStream = new StreamReader(dlgOpenList.FileName, Encoding.UTF8))
            {
                string line=string.Empty;
                while ((line = fileStream.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        try
                        {
                            if (Regex.IsMatch(line, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*"))
                            {
                                files.Add(line);
                            }
                        }
                        catch (System.Exception ex)
                        {
                            Debug.Print(ex.Message);
                            continue;
                        }
                    }
                }
            }
            this.WorkingFile = dlgOpenList.FileName;
            lvwFiles.Items.Clear();
            MainImgList.Images.Clear();
            if (bgwAddFiles.IsBusy)
                bgwAddFiles.CancelAsync();
            bgwAddFiles.RunWorkerAsync(files.ToArray());
        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSaveList.Title = "Save list to file";
            dlgSaveList.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            if (dlgSaveList.ShowDialog() != DialogResult.OK)
                return;
            this.WorkingFile = dlgSaveList.FileName;
            using (StreamWriter writer = new StreamWriter(this.WorkingFile, false, Encoding.UTF8))
            {
                foreach (ListViewItem item in lvwFiles.Items)
                {
                    string filePath = item.SubItems[1].Text;
                    writer.WriteLine(filePath);
                }
                writer.Flush();
            }

            if((!this.RecentFiles.Contains(this.WorkingFile)) && (this.RecentFiles.Count<this.RecentMenuImages.Count))
            {
                int imageIndex = this.RecentFiles.Count;
                this.RecentFiles.Add(this.WorkingFile);
                if (this.LoadRecentListToolStripMenuItem == null)
                {
                    this.LoadRecentListToolStripMenuItem = new ToolStripMenuItem();
                    this.LoadRecentListToolStripMenuItem.Text = "Load Recent List";
                }
                ToolStripItem recentItem = this.LoadRecentListToolStripMenuItem.DropDownItems.Add(this.WorkingFile);
                recentItem.Image = this.RecentMenuImages[imageIndex];
                recentItem.Click += new EventHandler(RecentMenuItemClicked);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileOpeartionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void loadRecentFileAtStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadRecentFilesAtStartup = !this.LoadRecentFilesAtStartup;
            loadRecentFileAtStartupToolStripMenuItem.Checked = this.LoadRecentFilesAtStartup;
        }

        private void addFilesContextMenuItem_Click(object sender, EventArgs e)
        {
            addFilesToolStripMenuItem_Click(sender, e);
        }

        private void addFilesInFolderContextMenuItem_Click(object sender, EventArgs e)
        {
            addFilesInFolderToolStripMenuItem_Click(sender, e);
        }

        private void removeContextMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to remove selected file(s) from list?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
                return;
            foreach(ListViewItem selItem in lvwFiles.SelectedItems)
            {
                lvwFiles.Items.Remove(selItem);
            }

            lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
        }

        private void removeAllContextMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to remove all files in the list?", "Remove All", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
                return;
            lvwFiles.Items.Clear();
            MainImgList.Images.Clear();
            lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
        }
    }
}
