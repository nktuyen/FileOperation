using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Interfaces
{
    public interface IFilter
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        bool Enabled { get; set; }
        System.Windows.Forms.IWin32Window SettingsForm { get; }
        System.Windows.Forms.IWin32Window AboutForm { get; }
        System.Drawing.Image Image { get; }
        bool Initialize();
        bool Filter(string filePath);
        bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null);
        bool SaveSettings(Microsoft.Win32.RegistryKey regKey = null);
    }
}
