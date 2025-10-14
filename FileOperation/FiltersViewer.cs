using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;

namespace FileOperation
{
    public partial class FiltersViewer : UserControl
    {
        public event EventHandler ItemCheckedChanged;
        public event EventHandler ItemSettingsClick;
        public event EventHandler ItemAboutClick;
        private List<IFilter> _filters = new List<IFilter>();
        public List<IFilter> Filters
        {
            get
            {
                return _filters;
            }
        }

        private int _itemHeight = 20;
        [System.ComponentModel.Browsable(true)]
        public int ItemHeight
        {
            get
            {
                return _itemHeight;
            }
            set
            {
                if (value > 10)
                    _itemHeight = value;
                else
                    _itemHeight = 10;
            }
        }
        private bool _integratedHeight = false;
        [System.ComponentModel.Browsable(true)]
        public bool IntergratedHeight
        {
            get
            {
                return _integratedHeight;
            }
            set
            {
                _integratedHeight = value;
                if (_integratedHeight)
                {
                    this.Height = this.ItemHeight * (this.Height / this.ItemHeight);
                }
            }
        }

        public FiltersViewer()
        {
            InitializeComponent();
        }

        private void OnFilterItemCheckedChange(object sender, EventArgs e)
        {
            if (this.ItemCheckedChanged != null)
                this.ItemCheckedChanged(sender, e);
        }

        private void OnFilterItemSettingsClicked(object sender, EventArgs e)
        {
            if (this.ItemSettingsClick != null)
                this.ItemSettingsClick(sender, e);
        }

        private void OnFilterItemAboutClicked(object sender, EventArgs e)
        {
            if (this.ItemAboutClick != null)
                this.ItemAboutClick(sender, e);
        }

        private void FiltersViewer_Load(object sender, EventArgs e)
        {
            Size sz = new Size(this.Width, this.ItemHeight);
            Point loc = new Point(0, 0);
            foreach (IFilter filter in this.Filters)
            {
                FilterItem item = new FilterItem();
                item.Visible = true;
                item.Text = filter.Name;
                item.Enabled = filter.Enabled;
                item.Tag = filter;
                item.Size = sz;
                item.Location = loc;
                item.CheckedChanged += new EventHandler(OnFilterItemCheckedChange);
                item.SettingsClick += new EventHandler(OnFilterItemSettingsClicked);
                item.AboutClick += new EventHandler(OnFilterItemAboutClicked);
                this.Controls.Add(item);
                loc.Y += item.Height;
            }
        }
    }
}
