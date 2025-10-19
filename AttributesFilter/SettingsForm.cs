using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AttributesFilter
{
    public partial class SettingsForm : Form
    {
        public FileAttributes Attributes { get; set; }
        public bool ExactMatch { get; set; }

        public SettingsForm()
        {
            InitializeComponent();
            Attributes = FileAttributes.Archive;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Assembly asm = null;
            try
            {
                asm = Assembly.GetExecutingAssembly();
                if (asm != null)
                {
                    FileVersionInfo ver = FileVersionInfo.GetVersionInfo(asm.Location);
                    this.Text = ver.FileDescription + " - Settings";
                }
            }
            catch (System.Exception ex)
            {
                Debug.Print(ex.Message);
                this.Text = "Settings";
            }

            ListViewItem item = lvwFIleAttributes.Items.Add(FileAttributes.Archive.ToString());
            if((this.Attributes & FileAttributes.Archive) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Compressed.ToString());
            if ((this.Attributes & FileAttributes.Compressed) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Encrypted.ToString());
            if ((this.Attributes & FileAttributes.Encrypted) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Hidden.ToString());
            if ((this.Attributes & FileAttributes.Hidden) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Normal.ToString());
            if ((this.Attributes & FileAttributes.Normal) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.NotContentIndexed.ToString());
            if ((this.Attributes & FileAttributes.NotContentIndexed) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.ReadOnly.ToString());
            if ((this.Attributes & FileAttributes.ReadOnly) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.System.ToString());
            if ((this.Attributes & FileAttributes.System) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Temporary.ToString());
            if ((this.Attributes & FileAttributes.Temporary) != 0)
                item.Checked = true;

            if (this.ExactMatch)
                radEquality.Checked = true;
            else
                radContains.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Attributes = 0;
            foreach (ListViewItem item in lvwFIleAttributes.Items)
            {
                if (item.Checked)
                {
                    if (item.Index == 0)
                    {
                        this.Attributes |= FileAttributes.Archive;
                    }
                    else if (item.Index == 1)
                    {
                        this.Attributes |= FileAttributes.Compressed;
                    }
                    else if (item.Index == 2)
                    {
                        this.Attributes |= FileAttributes.Encrypted;
                    }
                    else if (item.Index == 3)
                    {
                        this.Attributes |= FileAttributes.Hidden;
                    }
                    else if (item.Index == 4)
                    {
                        this.Attributes |= FileAttributes.Normal;
                    }
                    else if (item.Index == 5)
                    {
                        this.Attributes |= FileAttributes.NotContentIndexed;
                    }
                    else if (item.Index == 6)
                    {
                        this.Attributes |= FileAttributes.ReadOnly;
                    }
                    else if (item.Index == 7)
                    {
                        this.Attributes |= FileAttributes.System;
                    }
                    else if (item.Index == 8)
                    {
                        this.Attributes |= FileAttributes.Temporary;
                    }
                }
            }
        }

        private void lvwFIleAttributes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void radEquality_CheckedChanged(object sender, EventArgs e)
        {
            if (radEquality.Checked)
                this.ExactMatch = true;
            else
                this.ExactMatch = false;
        }

        private void radContains_CheckedChanged(object sender, EventArgs e)
        {
            if (radEquality.Checked)
                this.ExactMatch = true;
            else
                this.ExactMatch = false;
        }
    }
}
