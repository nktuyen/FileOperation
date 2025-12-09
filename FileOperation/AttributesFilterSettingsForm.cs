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

namespace FileOperation
{
    public partial class AttributesFilterSettingsForm : Form
    {
        private AttributesFilter Filter { get; set; }
        public AttributesFilterSettingsForm(AttributesFilter filter = null)
        {
            InitializeComponent();
            this.Filter = filter;
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
            if((this.Filter.Attributes & FileAttributes.Archive) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Compressed.ToString());
            if ((this.Filter.Attributes & FileAttributes.Compressed) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Encrypted.ToString());
            if ((this.Filter.Attributes & FileAttributes.Encrypted) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Hidden.ToString());
            if ((this.Filter.Attributes & FileAttributes.Hidden) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Normal.ToString());
            if ((this.Filter.Attributes & FileAttributes.Normal) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.NotContentIndexed.ToString());
            if ((this.Filter.Attributes & FileAttributes.NotContentIndexed) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.ReadOnly.ToString());
            if ((this.Filter.Attributes & FileAttributes.ReadOnly) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.System.ToString());
            if ((this.Filter.Attributes & FileAttributes.System) != 0)
                item.Checked = true;
            item = lvwFIleAttributes.Items.Add(FileAttributes.Temporary.ToString());
            if ((this.Filter.Attributes & FileAttributes.Temporary) != 0)
                item.Checked = true;

            if (this.Filter.Matching == AttributesFilter.MatchingMode.EQuality)
                radEquality.Checked = true;
            else
                radContains.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Filter.Attributes = 0;
            foreach (ListViewItem item in lvwFIleAttributes.Items)
            {
                if (item.Checked)
                {
                    if (item.Index == 0)
                    {
                        this.Filter.Attributes |= FileAttributes.Archive;
                    }
                    else if (item.Index == 1)
                    {
                        this.Filter.Attributes |= FileAttributes.Compressed;
                    }
                    else if (item.Index == 2)
                    {
                        this.Filter.Attributes |= FileAttributes.Encrypted;
                    }
                    else if (item.Index == 3)
                    {
                        this.Filter.Attributes |= FileAttributes.Hidden;
                    }
                    else if (item.Index == 4)
                    {
                        this.Filter.Attributes |= FileAttributes.Normal;
                    }
                    else if (item.Index == 5)
                    {
                        this.Filter.Attributes |= FileAttributes.NotContentIndexed;
                    }
                    else if (item.Index == 6)
                    {
                        this.Filter.Attributes |= FileAttributes.ReadOnly;
                    }
                    else if (item.Index == 7)
                    {
                        this.Filter.Attributes |= FileAttributes.System;
                    }
                    else if (item.Index == 8)
                    {
                        this.Filter.Attributes |= FileAttributes.Temporary;
                    }
                }
            }

            if (radEquality.Checked)
                this.Filter.Matching = AttributesFilter.MatchingMode.EQuality;
            else
                this.Filter.Matching = AttributesFilter.MatchingMode.Containing;
        }

        private void lvwFIleAttributes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void radEquality_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radContains_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
