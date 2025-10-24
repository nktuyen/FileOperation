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
        bool HasSettings { get; }
        bool HasAbout{ get; }
        System.Drawing.Image Image { get; }
        System.Windows.Forms.IWin32Window MainWnd { get; set; }
        bool Initialize();
        bool Filter(string filePath);
        System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner = null);
        System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner = null);
        bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null);
        bool SaveSettings(Microsoft.Win32.RegistryKey regKey = null);
    }
}
