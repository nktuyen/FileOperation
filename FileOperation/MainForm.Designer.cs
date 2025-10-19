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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesInFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllFilesToolstripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpeartionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.bgwAddFiles = new System.ComponentModel.BackgroundWorker();
            this.bgwAddFilesInFolder = new System.ComponentModel.BackgroundWorker();
            this.MainProgressbar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
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
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addFilesToolStripMenuItem.Text = "Add Files";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
            // 
            // addFilesInFolderToolStripMenuItem
            // 
            this.addFilesInFolderToolStripMenuItem.Name = "addFilesInFolderToolStripMenuItem";
            this.addFilesInFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addFilesInFolderToolStripMenuItem.Text = "Add Files in Folder";
            this.addFilesInFolderToolStripMenuItem.Click += new System.EventHandler(this.addFilesInFolderToolStripMenuItem_Click);
            // 
            // removeAllFilesToolstripMenu
            // 
            this.removeAllFilesToolstripMenu.Enabled = false;
            this.removeAllFilesToolstripMenu.Name = "removeAllFilesToolstripMenu";
            this.removeAllFilesToolstripMenu.Size = new System.Drawing.Size(171, 22);
            this.removeAllFilesToolstripMenu.Text = "Remove All Files";
            this.removeAllFilesToolstripMenu.Click += new System.EventHandler(this.removeAllFilesToolstripMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Fil&ter";
            // 
            // settingsToolstripMenuItem
            // 
            this.settingsToolstripMenuItem.Name = "settingsToolstripMenuItem";
            this.settingsToolstripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolstripMenuItem.Text = "&Settings";
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
            this.toolStripMenuItem2});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // fileOpeartionToolStripMenuItem
            // 
            this.fileOpeartionToolStripMenuItem.Name = "fileOpeartionToolStripMenuItem";
            this.fileOpeartionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.fileOpeartionToolStripMenuItem.Text = "FileOpeartion";
            this.fileOpeartionToolStripMenuItem.Click += new System.EventHandler(this.fileOpeartionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 6);
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
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
            this.lblStatus.Visible = false;
            // 
            // lvwFiles
            // 
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
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.GridLines = true;
            this.lvwFiles.Location = new System.Drawing.Point(10, 24);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.ShowItemToolTips = true;
            this.lvwFiles.Size = new System.Drawing.Size(984, 521);
            this.lvwFiles.TabIndex = 2;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwFiles_KeyUp);
            // 
            // colNb
            // 
            this.colNb.Text = "#";
            this.colNb.Width = 50;
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
    }
}

