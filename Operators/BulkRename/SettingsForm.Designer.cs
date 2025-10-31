namespace BulkRename
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameTemplate = new System.Windows.Forms.TextBox();
            this.contextMenuNameTemplate = new System.Windows.Forms.ContextMenuStrip();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertContextVariablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPUTERNAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSERNAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yEARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mONTHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cURRENTDAYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hOURToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mINUTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sECONDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wEEKDAYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileIndextoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parentDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createdDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileIndexStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileParentDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileFileCreatedDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFiledayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileHourToolStripMenuIte = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileMinuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstFileSecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.contextMenuNameTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name Template:";
            // 
            // txtNameTemplate
            // 
            this.txtNameTemplate.ContextMenuStrip = this.contextMenuNameTemplate;
            this.txtNameTemplate.Location = new System.Drawing.Point(99, 20);
            this.txtNameTemplate.Name = "txtNameTemplate";
            this.txtNameTemplate.Size = new System.Drawing.Size(323, 20);
            this.txtNameTemplate.TabIndex = 0;
            this.txtNameTemplate.TextChanged += new System.EventHandler(this.txtNameTemplate_TextChanged);
            // 
            // contextMenuNameTemplate
            // 
            this.contextMenuNameTemplate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectAllToolStripMenuItem,
            this.insertContextVariablesToolStripMenuItem});
            this.contextMenuNameTemplate.Name = "contextMenuNameTemplate";
            this.contextMenuNameTemplate.Size = new System.Drawing.Size(198, 170);
            this.contextMenuNameTemplate.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuNameTemplate_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // insertContextVariablesToolStripMenuItem
            // 
            this.insertContextVariablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.dateTimeToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.firstFileToolStripMenuItem,
            this.fileCountToolStripMenuItem});
            this.insertContextVariablesToolStripMenuItem.Name = "insertContextVariablesToolStripMenuItem";
            this.insertContextVariablesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.insertContextVariablesToolStripMenuItem.Text = "&Insert Context Variables";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cOMPUTERNAMEToolStripMenuItem,
            this.uSERNAMEToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.systemToolStripMenuItem.Text = "&System";
            // 
            // cOMPUTERNAMEToolStripMenuItem
            // 
            this.cOMPUTERNAMEToolStripMenuItem.Name = "cOMPUTERNAMEToolStripMenuItem";
            this.cOMPUTERNAMEToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cOMPUTERNAMEToolStripMenuItem.Text = "COMPUTER NAME";
            this.cOMPUTERNAMEToolStripMenuItem.Click += new System.EventHandler(this.cOMPUTERNAMEToolStripMenuItem_Click);
            // 
            // uSERNAMEToolStripMenuItem
            // 
            this.uSERNAMEToolStripMenuItem.Name = "uSERNAMEToolStripMenuItem";
            this.uSERNAMEToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.uSERNAMEToolStripMenuItem.Text = "USERNAME";
            this.uSERNAMEToolStripMenuItem.Click += new System.EventHandler(this.uSERNAMEToolStripMenuItem_Click);
            // 
            // dateTimeToolStripMenuItem
            // 
            this.dateTimeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yEARToolStripMenuItem,
            this.mONTHToolStripMenuItem,
            this.cURRENTDAYToolStripMenuItem,
            this.hOURToolStripMenuItem,
            this.mINUTEToolStripMenuItem,
            this.sECONDToolStripMenuItem,
            this.wEEKDAYToolStripMenuItem});
            this.dateTimeToolStripMenuItem.Name = "dateTimeToolStripMenuItem";
            this.dateTimeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.dateTimeToolStripMenuItem.Text = "&Date/Time";
            // 
            // yEARToolStripMenuItem
            // 
            this.yEARToolStripMenuItem.Name = "yEARToolStripMenuItem";
            this.yEARToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.yEARToolStripMenuItem.Text = "YEAR";
            this.yEARToolStripMenuItem.Click += new System.EventHandler(this.yEARToolStripMenuItem_Click);
            // 
            // mONTHToolStripMenuItem
            // 
            this.mONTHToolStripMenuItem.Name = "mONTHToolStripMenuItem";
            this.mONTHToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.mONTHToolStripMenuItem.Text = "MONTH";
            this.mONTHToolStripMenuItem.Click += new System.EventHandler(this.mONTHToolStripMenuItem_Click);
            // 
            // cURRENTDAYToolStripMenuItem
            // 
            this.cURRENTDAYToolStripMenuItem.Name = "cURRENTDAYToolStripMenuItem";
            this.cURRENTDAYToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.cURRENTDAYToolStripMenuItem.Text = "DAY";
            this.cURRENTDAYToolStripMenuItem.Click += new System.EventHandler(this.cURRENTDAYToolStripMenuItem_Click);
            // 
            // hOURToolStripMenuItem
            // 
            this.hOURToolStripMenuItem.Name = "hOURToolStripMenuItem";
            this.hOURToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hOURToolStripMenuItem.Text = "HOUR";
            this.hOURToolStripMenuItem.Click += new System.EventHandler(this.hOURToolStripMenuItem_Click);
            // 
            // mINUTEToolStripMenuItem
            // 
            this.mINUTEToolStripMenuItem.Name = "mINUTEToolStripMenuItem";
            this.mINUTEToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.mINUTEToolStripMenuItem.Text = "MINUTE";
            this.mINUTEToolStripMenuItem.Click += new System.EventHandler(this.mINUTEToolStripMenuItem_Click);
            // 
            // sECONDToolStripMenuItem
            // 
            this.sECONDToolStripMenuItem.Name = "sECONDToolStripMenuItem";
            this.sECONDToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sECONDToolStripMenuItem.Text = "SECOND";
            this.sECONDToolStripMenuItem.Click += new System.EventHandler(this.sECONDToolStripMenuItem_Click);
            // 
            // wEEKDAYToolStripMenuItem
            // 
            this.wEEKDAYToolStripMenuItem.Name = "wEEKDAYToolStripMenuItem";
            this.wEEKDAYToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.wEEKDAYToolStripMenuItem.Text = "WEEK DAY";
            this.wEEKDAYToolStripMenuItem.Click += new System.EventHandler(this.wEEKDAYToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileIndextoolStripMenuItem,
            this.parentDirectoryToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.titleToolStripMenuItem,
            this.extensionToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.attributesToolStripMenuItem,
            this.createdDateToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // fileIndextoolStripMenuItem
            // 
            this.fileIndextoolStripMenuItem.Name = "fileIndextoolStripMenuItem";
            this.fileIndextoolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.fileIndextoolStripMenuItem.Text = "&Index";
            this.fileIndextoolStripMenuItem.Click += new System.EventHandler(this.fileIndextoolStripMenuItem_Click);
            // 
            // parentDirectoryToolStripMenuItem
            // 
            this.parentDirectoryToolStripMenuItem.Name = "parentDirectoryToolStripMenuItem";
            this.parentDirectoryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.parentDirectoryToolStripMenuItem.Text = "Parent Directory";
            this.parentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.parentDirectoryToolStripMenuItem_Click);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.titleToolStripMenuItem.Text = "Title";
            this.titleToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripMenuItem_Click);
            // 
            // extensionToolStripMenuItem
            // 
            this.extensionToolStripMenuItem.Name = "extensionToolStripMenuItem";
            this.extensionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.extensionToolStripMenuItem.Text = "Extension";
            this.extensionToolStripMenuItem.Click += new System.EventHandler(this.extensionToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // attributesToolStripMenuItem
            // 
            this.attributesToolStripMenuItem.Name = "attributesToolStripMenuItem";
            this.attributesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.attributesToolStripMenuItem.Text = "Attributes";
            this.attributesToolStripMenuItem.Click += new System.EventHandler(this.attributesToolStripMenuItem_Click);
            // 
            // createdDateToolStripMenuItem
            // 
            this.createdDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yearToolStripMenuItem1,
            this.monthToolStripMenuItem1,
            this.dayToolStripMenuItem,
            this.hourToolStripMenuItem1,
            this.minuteToolStripMenuItem1,
            this.secondToolStripMenuItem1});
            this.createdDateToolStripMenuItem.Name = "createdDateToolStripMenuItem";
            this.createdDateToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.createdDateToolStripMenuItem.Text = "Created Date";
            this.createdDateToolStripMenuItem.Click += new System.EventHandler(this.createdDateToolStripMenuItem_Click);
            // 
            // yearToolStripMenuItem1
            // 
            this.yearToolStripMenuItem1.Name = "yearToolStripMenuItem1";
            this.yearToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.yearToolStripMenuItem1.Text = "Year";
            this.yearToolStripMenuItem1.Click += new System.EventHandler(this.yearToolStripMenuItem1_Click);
            // 
            // monthToolStripMenuItem1
            // 
            this.monthToolStripMenuItem1.Name = "monthToolStripMenuItem1";
            this.monthToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.monthToolStripMenuItem1.Text = "Month";
            this.monthToolStripMenuItem1.Click += new System.EventHandler(this.monthToolStripMenuItem1_Click);
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.dayToolStripMenuItem.Text = "Day";
            this.dayToolStripMenuItem.Click += new System.EventHandler(this.dayToolStripMenuItem_Click);
            // 
            // hourToolStripMenuItem1
            // 
            this.hourToolStripMenuItem1.Name = "hourToolStripMenuItem1";
            this.hourToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.hourToolStripMenuItem1.Text = "Hour";
            this.hourToolStripMenuItem1.Click += new System.EventHandler(this.hourToolStripMenuItem1_Click);
            // 
            // minuteToolStripMenuItem1
            // 
            this.minuteToolStripMenuItem1.Name = "minuteToolStripMenuItem1";
            this.minuteToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.minuteToolStripMenuItem1.Text = "Minute";
            this.minuteToolStripMenuItem1.Click += new System.EventHandler(this.minuteToolStripMenuItem1_Click);
            // 
            // secondToolStripMenuItem1
            // 
            this.secondToolStripMenuItem1.Name = "secondToolStripMenuItem1";
            this.secondToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.secondToolStripMenuItem1.Text = "Second";
            this.secondToolStripMenuItem1.Click += new System.EventHandler(this.secondToolStripMenuItem1_Click);
            // 
            // firstFileToolStripMenuItem
            // 
            this.firstFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstFileIndexStripMenuItem,
            this.firstFileParentDirectoryToolStripMenuItem,
            this.firstFileNameToolStripMenuItem,
            this.firstFileTitleToolStripMenuItem,
            this.firstFileExtensionToolStripMenuItem,
            this.firstFileSizeToolStripMenuItem,
            this.firstFileAttributesToolStripMenuItem,
            this.fileFileCreatedDateToolStripMenuItem});
            this.firstFileToolStripMenuItem.Name = "firstFileToolStripMenuItem";
            this.firstFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.firstFileToolStripMenuItem.Text = "F&irst File";
            // 
            // firstFileIndexStripMenuItem
            // 
            this.firstFileIndexStripMenuItem.Name = "firstFileIndexStripMenuItem";
            this.firstFileIndexStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileIndexStripMenuItem.Text = "Index";
            this.firstFileIndexStripMenuItem.Click += new System.EventHandler(this.firstFileIndexStripMenuItem_Click);
            // 
            // firstFileParentDirectoryToolStripMenuItem
            // 
            this.firstFileParentDirectoryToolStripMenuItem.Name = "firstFileParentDirectoryToolStripMenuItem";
            this.firstFileParentDirectoryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileParentDirectoryToolStripMenuItem.Text = "Parent Directory";
            this.firstFileParentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.firstFileParentDirectoryToolStripMenuItem_Click);
            // 
            // firstFileNameToolStripMenuItem
            // 
            this.firstFileNameToolStripMenuItem.Name = "firstFileNameToolStripMenuItem";
            this.firstFileNameToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileNameToolStripMenuItem.Text = "Name";
            this.firstFileNameToolStripMenuItem.Click += new System.EventHandler(this.firstFileNameToolStripMenuItem_Click);
            // 
            // firstFileTitleToolStripMenuItem
            // 
            this.firstFileTitleToolStripMenuItem.Name = "firstFileTitleToolStripMenuItem";
            this.firstFileTitleToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileTitleToolStripMenuItem.Text = "Title";
            this.firstFileTitleToolStripMenuItem.Click += new System.EventHandler(this.firstFileTitleToolStripMenuItem_Click);
            // 
            // firstFileExtensionToolStripMenuItem
            // 
            this.firstFileExtensionToolStripMenuItem.Name = "firstFileExtensionToolStripMenuItem";
            this.firstFileExtensionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileExtensionToolStripMenuItem.Text = "Extension";
            this.firstFileExtensionToolStripMenuItem.Click += new System.EventHandler(this.firstFileExtensionToolStripMenuItem_Click);
            // 
            // firstFileSizeToolStripMenuItem
            // 
            this.firstFileSizeToolStripMenuItem.Name = "firstFileSizeToolStripMenuItem";
            this.firstFileSizeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileSizeToolStripMenuItem.Text = "Size";
            this.firstFileSizeToolStripMenuItem.Click += new System.EventHandler(this.firstFileSizeToolStripMenuItem_Click);
            // 
            // firstFileAttributesToolStripMenuItem
            // 
            this.firstFileAttributesToolStripMenuItem.Name = "firstFileAttributesToolStripMenuItem";
            this.firstFileAttributesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.firstFileAttributesToolStripMenuItem.Text = "Attributes";
            this.firstFileAttributesToolStripMenuItem.Click += new System.EventHandler(this.firstFileAttributesToolStripMenuItem_Click);
            // 
            // fileFileCreatedDateToolStripMenuItem
            // 
            this.fileFileCreatedDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstFileYearToolStripMenuItem,
            this.firstFileMonthToolStripMenuItem,
            this.firstFiledayToolStripMenuItem,
            this.firstFileHourToolStripMenuIte,
            this.firstFileMinuteToolStripMenuItem,
            this.firstFileSecondToolStripMenuItem});
            this.fileFileCreatedDateToolStripMenuItem.Name = "fileFileCreatedDateToolStripMenuItem";
            this.fileFileCreatedDateToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.fileFileCreatedDateToolStripMenuItem.Text = "Created Date";
            this.fileFileCreatedDateToolStripMenuItem.Click += new System.EventHandler(this.fileFileCreatedDateToolStripMenuItem_Click);
            // 
            // firstFileYearToolStripMenuItem
            // 
            this.firstFileYearToolStripMenuItem.Name = "firstFileYearToolStripMenuItem";
            this.firstFileYearToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.firstFileYearToolStripMenuItem.Text = "Year";
            this.firstFileYearToolStripMenuItem.Click += new System.EventHandler(this.firstFileYearToolStripMenuItem_Click);
            // 
            // firstFileMonthToolStripMenuItem
            // 
            this.firstFileMonthToolStripMenuItem.Name = "firstFileMonthToolStripMenuItem";
            this.firstFileMonthToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.firstFileMonthToolStripMenuItem.Text = "Month";
            this.firstFileMonthToolStripMenuItem.Click += new System.EventHandler(this.firstFileMonthToolStripMenuItem_Click);
            // 
            // firstFiledayToolStripMenuItem
            // 
            this.firstFiledayToolStripMenuItem.Name = "firstFiledayToolStripMenuItem";
            this.firstFiledayToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.firstFiledayToolStripMenuItem.Text = "Day";
            this.firstFiledayToolStripMenuItem.Click += new System.EventHandler(this.firstFiledayToolStripMenuItem_Click);
            // 
            // firstFileHourToolStripMenuIte
            // 
            this.firstFileHourToolStripMenuIte.Name = "firstFileHourToolStripMenuIte";
            this.firstFileHourToolStripMenuIte.Size = new System.Drawing.Size(113, 22);
            this.firstFileHourToolStripMenuIte.Text = "Hour";
            this.firstFileHourToolStripMenuIte.Click += new System.EventHandler(this.firstFileHourToolStripMenuIte_Click);
            // 
            // firstFileMinuteToolStripMenuItem
            // 
            this.firstFileMinuteToolStripMenuItem.Name = "firstFileMinuteToolStripMenuItem";
            this.firstFileMinuteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.firstFileMinuteToolStripMenuItem.Text = "Minute";
            this.firstFileMinuteToolStripMenuItem.Click += new System.EventHandler(this.firstFileMinuteToolStripMenuItem_Click);
            // 
            // firstFileSecondToolStripMenuItem
            // 
            this.firstFileSecondToolStripMenuItem.Name = "firstFileSecondToolStripMenuItem";
            this.firstFileSecondToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.firstFileSecondToolStripMenuItem.Text = "Second";
            this.firstFileSecondToolStripMenuItem.Click += new System.EventHandler(this.firstFileSecondToolStripMenuItem_Click);
            // 
            // fileCountToolStripMenuItem
            // 
            this.fileCountToolStripMenuItem.Name = "fileCountToolStripMenuItem";
            this.fileCountToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fileCountToolStripMenuItem.Text = "File Cou&nt";
            this.fileCountToolStripMenuItem.Click += new System.EventHandler(this.fileCountToolStripMenuItem_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(424, 19);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(38, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 69);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNameTemplate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.contextMenuNameTemplate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameTemplate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ContextMenuStrip contextMenuNameTemplate;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertContextVariablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMPUTERNAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSERNAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yEARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mONTHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cURRENTDAYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hOURToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mINUTEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sECONDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wEEKDAYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parentDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createdDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileParentDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileAttributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileFileCreatedDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem minuteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secondToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem firstFileYearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFiledayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileHourToolStripMenuIte;
        private System.Windows.Forms.ToolStripMenuItem firstFileMinuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileSecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstFileIndexStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileIndextoolStripMenuItem;
    }
}