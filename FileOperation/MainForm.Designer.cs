namespace FileOperation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesInFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllFilesToolstripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsOperatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpeartionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutOperatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.bgwAddFiles = new System.ComponentModel.BackgroundWorker();
            this.bgwAddFilesInFolder = new System.ComponentModel.BackgroundWorker();
            this.MainProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.filesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtListViewItem = new System.Windows.Forms.TextBox();
            this.bgwDropFiles = new System.ComponentModel.BackgroundWorker();
            this.dlgOpenList = new System.Windows.Forms.OpenFileDialog();
            this.dlgSaveList = new System.Windows.Forms.SaveFileDialog();
            this.MainImgList = new System.Windows.Forms.ImageList(this.components);
            this.lvwFiles = new FileOperation.ListViewEx();
            this.colNb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAttributes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.settingsToolstripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1008, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFilesInFolderToolStripMenuItem,
            this.removeAllFilesToolstripMenu,
            this.toolStripSeparator1,
            this.loadListToolStripMenuItem,
            this.saveListToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.addFilesToolStripMenuItem.Text = "Add Files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
            // 
            // addFilesInFolderToolStripMenuItem
            // 
            this.addFilesInFolderToolStripMenuItem.Name = "addFilesInFolderToolStripMenuItem";
            this.addFilesInFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.addFilesInFolderToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.addFilesInFolderToolStripMenuItem.Text = "Add Files in Folder";
            this.addFilesInFolderToolStripMenuItem.Click += new System.EventHandler(this.addFilesInFolderToolStripMenuItem_Click);
            // 
            // removeAllFilesToolstripMenu
            // 
            this.removeAllFilesToolstripMenu.Enabled = false;
            this.removeAllFilesToolstripMenu.Name = "removeAllFilesToolstripMenu";
            this.removeAllFilesToolstripMenu.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.removeAllFilesToolstripMenu.Size = new System.Drawing.Size(243, 22);
            this.removeAllFilesToolstripMenu.Text = "Remove All Files";
            this.removeAllFilesToolstripMenu.Click += new System.EventHandler(this.removeAllFilesToolstripMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // loadListToolStripMenuItem
            // 
            this.loadListToolStripMenuItem.Name = "loadListToolStripMenuItem";
            this.loadListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadListToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.loadListToolStripMenuItem.Text = "Load List";
            this.loadListToolStripMenuItem.Click += new System.EventHandler(this.loadListToolStripMenuItem_Click);
            // 
            // saveListToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Enabled = false;
            this.saveListToolStripMenuItem.Name = "saveListToolStripMenuItem";
            this.saveListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.saveListToolStripMenuItem.Text = "Save List";
            this.saveListToolStripMenuItem.Click += new System.EventHandler(this.saveListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Fil&ter";
            // 
            // settingsToolstripMenuItem
            // 
            this.settingsToolstripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsFiltersToolStripMenuItem,
            this.settingsOperatorsToolStripMenuItem});
            this.settingsToolstripMenuItem.Name = "settingsToolstripMenuItem";
            this.settingsToolstripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolstripMenuItem.Text = "&Settings";
            // 
            // settingsFiltersToolStripMenuItem
            // 
            this.settingsFiltersToolStripMenuItem.Name = "settingsFiltersToolStripMenuItem";
            this.settingsFiltersToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.settingsFiltersToolStripMenuItem.Text = "Filters";
            // 
            // settingsOperatorsToolStripMenuItem
            // 
            this.settingsOperatorsToolStripMenuItem.Name = "settingsOperatorsToolStripMenuItem";
            this.settingsOperatorsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.settingsOperatorsToolStripMenuItem.Text = "Operators";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.howToUseToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "H&elp";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpeartionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutFiltersToolStripMenuItem,
            this.aboutOperatorsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // fileOpeartionToolStripMenuItem
            // 
            this.fileOpeartionToolStripMenuItem.Name = "fileOpeartionToolStripMenuItem";
            this.fileOpeartionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.fileOpeartionToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.fileOpeartionToolStripMenuItem.Text = "FileOpeartion";
            this.fileOpeartionToolStripMenuItem.Click += new System.EventHandler(this.fileOpeartionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // aboutFiltersToolStripMenuItem
            // 
            this.aboutFiltersToolStripMenuItem.Name = "aboutFiltersToolStripMenuItem";
            this.aboutFiltersToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.aboutFiltersToolStripMenuItem.Text = "Filters";
            // 
            // aboutOperatorsToolStripMenuItem
            // 
            this.aboutOperatorsToolStripMenuItem.Name = "aboutOperatorsToolStripMenuItem";
            this.aboutOperatorsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.aboutOperatorsToolStripMenuItem.Text = "Operators";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.howToUseToolStripMenuItem.Text = "How to use";
            // 
            // dlgFileOpen
            // 
            this.dlgFileOpen.InitialDirectory = ".\\";
            this.dlgFileOpen.Multiselect = true;
            this.dlgFileOpen.RestoreDirectory = true;
            this.dlgFileOpen.ShowReadOnly = true;
            // 
            // dlgFolderBrowser
            // 
            this.dlgFolderBrowser.ShowNewFolderButton = false;
            // 
            // bgwAddFiles
            // 
            this.bgwAddFiles.WorkerReportsProgress = true;
            this.bgwAddFiles.WorkerSupportsCancellation = true;
            this.bgwAddFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAddFiles_DoWork);
            this.bgwAddFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAddFiles_ProgressChanged);
            this.bgwAddFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAddFiles_RunWorkerCompleted);
            // 
            // bgwAddFilesInFolder
            // 
            this.bgwAddFilesInFolder.WorkerReportsProgress = true;
            this.bgwAddFilesInFolder.WorkerSupportsCancellation = true;
            this.bgwAddFilesInFolder.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAddFilesInFolder_DoWork);
            this.bgwAddFilesInFolder.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwAddFilesInFolder_ProgressChanged);
            this.bgwAddFilesInFolder.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwAddFilesInFolder_RunWorkerCompleted);
            // 
            // MainProgressbar
            // 
            this.MainProgressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MainProgressbar.Location = new System.Drawing.Point(776, 546);
            this.MainProgressbar.Name = "MainProgressbar";
            this.MainProgressbar.Size = new System.Drawing.Size(200, 14);
            this.MainProgressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.MainProgressbar.TabIndex = 3;
            this.MainProgressbar.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImage = global::FileOperation.Properties.Resources.Cancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.Location = new System.Drawing.Point(977, 545);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(16, 16);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnCancel_KeyUp);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 547);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(752, 14);
            this.lblStatus.TabIndex = 5;
            // 
            // filesContextMenuStrip
            // 
            this.filesContextMenuStrip.Name = "filesContextMenuStrip";
            this.filesContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            this.filesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.filesContextMenuStrip_Opening);
            // 
            // txtListViewItem
            // 
            this.txtListViewItem.Location = new System.Drawing.Point(13, 524);
            this.txtListViewItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtListViewItem.Name = "txtListViewItem";
            this.txtListViewItem.Size = new System.Drawing.Size(100, 20);
            this.txtListViewItem.TabIndex = 6;
            this.txtListViewItem.Visible = false;
            this.txtListViewItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtListViewItem_KeyUp);
            // 
            // bgwDropFiles
            // 
            this.bgwDropFiles.WorkerReportsProgress = true;
            this.bgwDropFiles.WorkerSupportsCancellation = true;
            this.bgwDropFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDropFiles_DoWork);
            this.bgwDropFiles.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDropFiles_ProgressChanged);
            this.bgwDropFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDropFiles_RunWorkerCompleted);
            // 
            // dlgOpenList
            // 
            this.dlgOpenList.AddExtension = false;
            this.dlgOpenList.InitialDirectory = ".\\";
            this.dlgOpenList.RestoreDirectory = true;
            this.dlgOpenList.ShowReadOnly = true;
            // 
            // dlgSaveList
            // 
            this.dlgSaveList.DefaultExt = "txt";
            // 
            // MainImgList
            // 
            this.MainImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.MainImgList.ImageSize = new System.Drawing.Size(16, 16);
            this.MainImgList.TransparentColor = System.Drawing.Color.White;
            // 
            // lvwFiles
            // 
            this.lvwFiles.AllowDrop = true;
            this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNb,
            this.colName,
            this.colExtension,
            this.colSize,
            this.colAttributes,
            this.colStatus});
            this.lvwFiles.ContextMenuStrip = this.filesContextMenuStrip;
            this.lvwFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.GridLines = true;
            this.lvwFiles.Location = new System.Drawing.Point(10, 24);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.ShowItemToolTips = true;
            this.lvwFiles.Size = new System.Drawing.Size(984, 521);
            this.lvwFiles.SmallImageList = this.MainImgList;
            this.lvwFiles.TabIndex = 2;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.ItemActivate += new System.EventHandler(this.lvwFiles_ItemActivate);
            this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.lvwFiles_SelectedIndexChanged);
            this.lvwFiles.FontChanged += new System.EventHandler(this.lvwFiles_FontChanged);
            this.lvwFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwFiles_DragDrop);
            this.lvwFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwFiles_DragEnter);
            this.lvwFiles.DoubleClick += new System.EventHandler(this.lvwFiles_DoubleClick);
            this.lvwFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwFiles_KeyUp);
            this.lvwFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwFiles_MouseDoubleClick);
            // 
            // colNb
            // 
            this.colNb.Text = "#";
            this.colNb.Width = 52;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 410;
            // 
            // colExtension
            // 
            this.colExtension.Text = "Extension";
            this.colExtension.Width = 100;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 100;
            // 
            // colAttributes
            // 
            this.colAttributes.Text = "Attributes";
            this.colAttributes.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.txtListViewItem);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.MainProgressbar);
            this.Controls.Add(this.lvwFiles);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File operation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesInFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpeartionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private ListViewEx lvwFiles;
        private System.Windows.Forms.ColumnHeader colNb;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colExtension;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colAttributes;
        private System.Windows.Forms.OpenFileDialog dlgFileOpen;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.ComponentModel.BackgroundWorker bgwAddFiles;
        private System.ComponentModel.BackgroundWorker bgwAddFilesInFolder;
        private System.Windows.Forms.ProgressBar MainProgressbar;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripMenuItem removeAllFilesToolstripMenu;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ContextMenuStrip filesContextMenuStrip;
        private System.Windows.Forms.TextBox txtListViewItem;
        private System.ComponentModel.BackgroundWorker bgwDropFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem loadListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveListToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpenList;
        private System.Windows.Forms.SaveFileDialog dlgSaveList;
        private System.Windows.Forms.ToolStripMenuItem aboutFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutOperatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsOperatorsToolStripMenuItem;
        private System.Windows.Forms.ImageList MainImgList;
    }
}

