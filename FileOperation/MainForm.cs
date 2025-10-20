using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using System.Diagnostics;
using System.Timers;
using System.Xml;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

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

        private Dictionary<Control, bool> EnabledControlsMap { get; set; }
        private List<IFilter> Filters { get; set; }
        private List<IOperator> Operators { get; set; }
        private System.Timers.Timer Timer { get; set; }
        private string WorkingFile { get; set; }
        public MainForm()
        {
            InitializeComponent();
            EnabledControlsMap = new Dictionary<Control, bool>();
            Filters = new List<IFilter>();
            Operators=new List<IOperator>();
            WorkingFile = string.Empty;
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
                deleteOperator.MainWnd = this;
                deleteOperator.Initialize();
                Operators.Add(deleteOperator);

                if (deleteOperator.HasSettings)
                {
                    ToolStripMenuItem operSettingsItem = (ToolStripMenuItem)settingsOperatorsToolStripMenuItem.DropDownItems.Add(deleteOperator.Name);
                    operSettingsItem.Tag = deleteOperator;
                    operSettingsItem.Image = deleteOperator.Image;
                    operSettingsItem.Click += new EventHandler(operSettingsMenuItemToolStripMenuItem_Click);
                }

                if (deleteOperator.HasAbout)
                {
                    ToolStripMenuItem operAboutItem = (ToolStripMenuItem)aboutOperatorsToolStripMenuItem.DropDownItems.Add(deleteOperator.Name);
                    operAboutItem.Tag = deleteOperator;
                    operAboutItem.Image = deleteOperator.Image;
                    operAboutItem.Click += new EventHandler(operAboutMenuItemToolStripMenuItem_Click);
                }

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
                            oper.MainWnd = this;
                            oper.Initialize();
                            Operators.Add(oper);

                            if (oper.HasSettings)
                            {
                                ToolStripMenuItem operSettingsItem = (ToolStripMenuItem)settingsOperatorsToolStripMenuItem.DropDownItems.Add(oper.Name);
                                operSettingsItem.Tag = oper;
                                operSettingsItem.Image = oper.Image;
                                operSettingsItem.Click += new EventHandler(operSettingsMenuItemToolStripMenuItem_Click);
                            }

                            if (oper.HasAbout)
                            {
                                ToolStripMenuItem operAboutItem = (ToolStripMenuItem)aboutOperatorsToolStripMenuItem.DropDownItems.Add(oper.Name);
                                operAboutItem.Tag = oper;
                                operAboutItem.Image = oper.Image;
                                operAboutItem.Click += new EventHandler(operAboutMenuItemToolStripMenuItem_Click);
                            }

                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private int LoadFilters()
        {
            int count = 0;
            Filters.Clear();

            //Add default filter
            IFilter nameFilter = new NameFilter();
            if (nameFilter != null)
            {
                nameFilter.MainWnd = this;
                nameFilter.Initialize();
                Filters.Add(nameFilter);

                ToolStripMenuItem filterItem = (ToolStripMenuItem)filterToolStripMenuItem.DropDownItems.Add(nameFilter.Name);
                filterItem.Checked = nameFilter.Enabled;
                filterItem.Tag = nameFilter;
                filterItem.Click += new EventHandler(filterMenuItemToolStripMenuItem_Click);

                if (nameFilter.HasSettings)
                {
                    ToolStripMenuItem filterSettingsItem = (ToolStripMenuItem)settingsFiltersToolStripMenuItem.DropDownItems.Add(nameFilter.Name);
                    filterSettingsItem.Tag = nameFilter;
                    filterSettingsItem.Click += new EventHandler(filterSettingsMenuItemToolStripMenuItem_Click);
                }

                if (nameFilter.HasAbout)
                {
                    ToolStripMenuItem filterAboutItem = (ToolStripMenuItem)aboutFiltersToolStripMenuItem.DropDownItems.Add(nameFilter.Name);
                    filterAboutItem.Tag = nameFilter;
                    filterAboutItem.Click += new EventHandler(filterAboutMenuItemToolStripMenuItem_Click);
                }

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
                            filter.MainWnd = this;
                            filter.Initialize();
                            Filters.Add(filter);

                            ToolStripMenuItem filterItem = (ToolStripMenuItem)filterToolStripMenuItem.DropDownItems.Add(filter.Name);
                            filterItem.Checked = filter.Enabled;
                            filterItem.Tag = filter;
                            filterItem.Click += new EventHandler(filterMenuItemToolStripMenuItem_Click);
                            

                            if (filter.HasSettings)
                            {
                                ToolStripMenuItem filterSettingsItem = (ToolStripMenuItem)settingsFiltersToolStripMenuItem.DropDownItems.Add(filter.Name);
                                filterSettingsItem.Tag = filter;
                                filterSettingsItem.Click += new EventHandler(filterSettingsMenuItemToolStripMenuItem_Click);
                            }

                            if (filter.HasAbout)
                            {
                                ToolStripMenuItem filterAboutItem = (ToolStripMenuItem)aboutFiltersToolStripMenuItem.DropDownItems.Add(filter.Name);
                                filterAboutItem.Tag = filter;
                                filterAboutItem.Click += new EventHandler(filterAboutMenuItemToolStripMenuItem_Click);
                            }

                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadOperators();
        }

        private void filterAboutMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IFilter filter = (IFilter)menuItem.Tag;
            if (filter != null)
            {
                filter.ShowAbout();
            }
        }

        private void filterSettingsMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IFilter filter = (IFilter)menuItem.Tag;
            if (filter != null)
            {
                filter.ShowSettings();
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
                oper.ShowSettings();
            }
        }

        private void operAboutMenuItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            IOperator oper = (IOperator)menuItem.Tag;
            if (oper != null)
            {
                oper.ShowAbout();
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
                        }
                        else
                        {
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
                    }
                    else
                    {
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

            removeAllFilesToolstripMenu.Enabled = lvwFiles.Items.Count > 0;
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
                            }
                            else
                            {
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
                        }
                        else
                        {
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

            removeAllFilesToolstripMenu.Enabled = lvwFiles.Items.Count > 0;
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

        private void removeAllFilesToolstripMenu_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to remove all files in the list?", "Remove All Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
                return;
            lvwFiles.Items.Clear();
            MainImgList.Images.Clear();
            lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
            removeAllFilesToolstripMenu.Enabled = lvwFiles.Items.Count > 0;
            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
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
                if(!oper.PreOperate(lvwFiles.SelectedItems.Count > 1))
                    return;
                List<ListViewItem> deletedItems =new List<ListViewItem>();
                foreach (ListViewItem item in lvwFiles.SelectedItems)
                {
                    item.SubItems[5].Text=string.Empty;
                    string filePath = item.SubItems[1].Text;
                    oper.FilePath = filePath;
                    if (oper.Operate())
                    {
                        if (oper.FilePath.Length <= 0) //Deleted
                        {
                            deletedItems.Add(item);
                        }
                        else
                        {
                            if (oper.FilePath != filePath) //Name changed
                            {
                                item.SubItems[1].Text = oper.FilePath;
                            }
                        }
                    }
                    item.SubItems[5].Text = oper.Status;

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

                    removeAllFilesToolstripMenu.Enabled = lvwFiles.Items.Count > 0;
                    saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
                    lblStatus.Text = string.Format("Total:{0} file(s)", lvwFiles.Items.Count);
                }
            }
        }

        private void filesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            filesContextMenuStrip.Items.Clear();
            if (lvwFiles.SelectedItems.Count <= 0)
                return;

            foreach (IOperator oper in Operators)
            {
                ToolStripItem operItem = filesContextMenuStrip.Items.Add(oper.Name);
                if (operItem != null)
                {
                    operItem.Tag = oper;
                    operItem.Click += new EventHandler(filesToolStripMenuItem_Click);
                    operItem.Image = oper.Image;
                    if (!oper.InitializeContextMenu(lvwFiles.SelectedItems.Count > 1))
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
                   if (hittestInfo.Item.SubItems.IndexOf(hittestInfo.SubItem) > 0)
                   {
                       txtListViewItem.Parent = lvwFiles;
                       txtListViewItem.ReadOnly = true;
                       txtListViewItem.Font = lvwFiles.Font;
                       txtListViewItem.Location = hittestInfo.SubItem.Bounds.Location;
                       txtListViewItem.Size = hittestInfo.SubItem.Bounds.Size;
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
            foreach (string filePath in paths)
            {
                if (bgwDropFiles.CancellationPending)
                    break;

                if ((System.IO.File.GetAttributes(filePath) & FileAttributes.Directory) != 0)
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
                            item.SubItems.Add(filePath);
                            if (fi != null)
                            {
                                item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                                item.SubItems.Add(AutoFileSize(fi.Length));
                                item.SubItems.Add(fi.Attributes.ToString());
                            }
                            else
                            {
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
                        item.SubItems.Add(filePath);
                        if (fi != null)
                        {
                            item.SubItems.Add(fi.Extension.StartsWith(".") ? fi.Extension.Substring(1) : fi.Extension);
                            item.SubItems.Add(AutoFileSize(fi.Length));
                            item.SubItems.Add(fi.Attributes.ToString());
                        }
                        else
                        {
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                            item.SubItems.Add(string.Empty);
                        }
                        item.SubItems.Add(string.Empty);//Status
                    }
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

            removeAllFilesToolstripMenu.Enabled = lvwFiles.Items.Count > 0;
            saveListToolStripMenuItem.Enabled = lvwFiles.Items.Count > 0;
        }

        private void loadListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpenList.Title = "Open list file";
            dlgOpenList.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            if (dlgOpenList.ShowDialog() != DialogResult.OK)
                return;
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

            lvwFiles.Items.Clear();
            MainImgList.Images.Clear();
            if (bgwAddFiles.IsBusy)
                bgwAddFiles.CancelAsync();
            bgwAddFiles.RunWorkerAsync(files.ToArray());
            this.WorkingFile = dlgFileOpen.FileName;
        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSaveList.Title = "Save list to file";
            dlgSaveList.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            if (dlgSaveList.ShowDialog() != DialogResult.OK)
                return;
            this.WorkingFile = dlgFileOpen.FileName;
            using (StreamWriter writer = new StreamWriter(dlgSaveList.FileName, false, Encoding.UTF8))
            {
                foreach (ListViewItem item in lvwFiles.Items)
                {
                    string filePath = item.SubItems[1].Text;
                    writer.WriteLine(filePath);
                }
                writer.Flush();
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
    }
}
