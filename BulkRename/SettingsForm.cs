using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulkRename
{
    public partial class SettingsForm : Form
    {
        public string NameTemplate { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            txtNameTemplate.Text = this.NameTemplate;
            btnOK.Enabled = txtNameTemplate.TextLength > 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.NameTemplate = txtNameTemplate.Text;
        }

        private void txtNameTemplate_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtNameTemplate.TextLength > 0;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(txtNameTemplate.SelectedText);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nSel = txtNameTemplate.SelectionStart;
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
            txtNameTemplate.SelectionStart = nSel;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtNameTemplate.SelectedText.Length==txtNameTemplate.TextLength)
                txtNameTemplate.DeselectAll();
            else
                txtNameTemplate.SelectAll();
        }

        private void yEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<YEAR>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void cOMPUTERNAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<CUMPUTER_NAME>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void uSERNAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<USERNAME>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void mONTHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<MONTH>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void cURRENTDAYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<DAY>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void hOURToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<HOUR>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void mINUTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<MINUTE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void sECONDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<SECOND>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void wEEKDAYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<WEEKDAY>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void contextMenuNameTemplate_Opening(object sender, CancelEventArgs e)
        {
            undoToolStripMenuItem.Enabled = txtNameTemplate.CanUndo;
            cutToolStripMenuItem.Enabled = txtNameTemplate.SelectedText.Length > 0;
            copyToolStripMenuItem.Enabled = txtNameTemplate.SelectedText.Length > 0;
            deleteToolStripMenuItem.Enabled = txtNameTemplate.SelectedText.Length > 0;
            pasteToolStripMenuItem.Enabled=Clipboard.ContainsData(DataFormats.Text) || Clipboard.ContainsData(DataFormats.UnicodeText) || Clipboard.ContainsData(DataFormats.StringFormat);
            selectAllToolStripMenuItem.Enabled = txtNameTemplate.TextLength > 0;
        }

        private void fileCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE_COUNT>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void parentDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.PARENT_DIRECTORY>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.NAME>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.TITLE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void extensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.EXTENSION>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.SIZE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void attributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.ATTRIBUTES>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void createdDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void yearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE.YEAR>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void monthToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE.MONTH>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void dayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE.DAY>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void hourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE.HOUR>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void minuteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE.MINUTE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void secondToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.CREATED_DATE.SECOND>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void fileIndextoolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE.INDEX>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstFileParentDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.PARENT_DIRECTORY>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.NAME>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.TITLE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.EXTENSION>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.SIZE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.ATTRIBUTES>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void fileFileCreatedDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE.YEAR>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE.MONTH>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFiledayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE.DAY>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileHourToolStripMenuIte_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE.HOUR>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileMinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE.MINUTE>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileSecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.CREATED_DATE.SECOND>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }

        private void firstFileIndexStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNameTemplate.Text = txtNameTemplate.Text.Substring(0, txtNameTemplate.SelectionStart) + "<FILE0.INDEX>" + txtNameTemplate.Text.Substring(txtNameTemplate.SelectionStart + txtNameTemplate.SelectionLength);
        }
    }
}
