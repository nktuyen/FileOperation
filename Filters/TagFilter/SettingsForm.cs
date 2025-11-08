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
        private MyFilter Filter { get; set; }
        public SettingsForm(MyFilter filter = null)
        {
            InitializeComponent();
            this.Filter = filter;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            lvwMediaTypes.Items.Clear();
            ListViewItem item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Audio.ToString());
            if ((this.Filter.MediaTypes & MediaTypes.Audio) != 0)
                item.Checked = true;

            item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Photo.ToString());
            if ((this.Filter.MediaTypes & MediaTypes.Photo) != 0)
                item.Checked = true;

            item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Text.ToString());
            if ((this.Filter.MediaTypes & MediaTypes.Text) != 0)
                item.Checked = true;

            item = lvwMediaTypes.Items.Add(TagLib.MediaTypes.Video.ToString());
            if ((this.Filter.MediaTypes & MediaTypes.Video) != 0)
                item.Checked = true;

            upDownHourMin.Value = this.Filter.DurationMin.Hours;
            upDownMinuteMin.Value = this.Filter.DurationMin.Minutes;
            upDownSecondMin.Value = this.Filter.DurationMin.Seconds;

            upDownHourMax.Value = this.Filter.DurationMax.Hours;
            upDownMinuteMax.Value = this.Filter.DurationMax.Minutes;
            upDownSecondMax.Value = this.Filter.DurationMax.Seconds;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvwMediaTypes.Items)
            {
                if (item.Checked)
                {
                    if (item.Index == 0) //Audio
                    {
                        this.Filter.MediaTypes |= MediaTypes.Audio;
                    }
                    else if (item.Index == 1) //Photo
                    {
                        this.Filter.MediaTypes |= MediaTypes.Photo;
                    }
                    else if (item.Index == 2)//Text
                    {
                        this.Filter.MediaTypes |= MediaTypes.Text;
                    }
                    else if (item.Index == 3) //Video
                    {
                        this.Filter.MediaTypes |= MediaTypes.Video;
                    }
                }
            }

            this.Filter.DurationMin = new TimeSpan((int)upDownHourMin.Value, (int)upDownMinuteMin.Value, (int)upDownSecondMin.Value);
            this.Filter.DurationMax = new TimeSpan((int)upDownHourMax.Value, (int)upDownMinuteMax.Value, (int)upDownSecondMax.Value);
            if (this.Filter.DurationMin > this.Filter.DurationMax)
            {
                MessageBox.Show("Duration range is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                upDownHourMin.Focus();
                return;
            }
        }
    }
}
