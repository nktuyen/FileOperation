using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace TagFilter
{
    public partial class SettingsForm : Form
    {
        public TagLib.MediaTypes MediaTypes { get; set; }
        public TimeSpan DurationMin { get; set; }
        public TimeSpan DurationMax { get; set; }
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lvwMediaTypes.Items.Clear();
            ListViewItem item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Audio.ToString());
            if ((this.MediaTypes & MediaTypes.Audio) != 0)
                item.Checked = true;

            item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Photo.ToString());
            if ((this.MediaTypes & MediaTypes.Photo) != 0)
                item.Checked = true;

            item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Text.ToString());
            if ((this.MediaTypes & MediaTypes.Text) != 0)
                item.Checked = true;

            item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Video.ToString());
            if ((this.MediaTypes & MediaTypes.Video) != 0)
                item.Checked = true;

            upDownHourMin.Value = this.DurationMin.Hours;
            upDownMinuteMin.Value = this.DurationMin.Minutes;
            upDownSecondMin.Value = this.DurationMin.Seconds;

            upDownHourMax.Value = this.DurationMax.Hours;
            upDownMinuteMax.Value = this.DurationMax.Minutes;
            upDownSecondMax.Value = this.DurationMax.Seconds;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvwMediaTypes.Items)
            {
                if (item.Checked)
                {
                    if (item.Index == 0) //Audio
                    {
                        this.MediaTypes |= MediaTypes.Audio;
                    }
                    else if (item.Index == 1) //Photo
                    {
                        this.MediaTypes |= MediaTypes.Photo;
                    }
                    else if (item.Index == 2)//Text
                    {
                        this.MediaTypes |= MediaTypes.Text;
                    }
                    else if (item.Index == 3) //Video
                    {
                        this.MediaTypes |= MediaTypes.Video;
                    }
                }
            }

            this.DurationMin = new TimeSpan((int)upDownHourMin.Value, (int)upDownMinuteMin.Value, (int)upDownSecondMin.Value);
            this.DurationMax = new TimeSpan((int)upDownHourMax.Value, (int)upDownMinuteMax.Value, (int)upDownSecondMax.Value);
            if (this.DurationMin > this.DurationMax)
            {
                MessageBox.Show("Duration range is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                upDownHourMin.Focus();
                return;
            }
        }
    }
}
