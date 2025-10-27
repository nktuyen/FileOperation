using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOperator
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        string Status { get; }
        System.Drawing.Image Image { get; }
        bool Enabled { get; set; }
        bool HasSettings { get; }
        bool HasAbout { get; }
        string CurrentFilePath { get; set; }
        System.Windows.Forms.IWin32Window MainWnd { get; set; }
        bool Initialize();
        bool InitializeContextMenu(long fileCount);
        bool PreOperate(long fileCount);
        bool Operate();
        System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner = null);
        System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner = null);
        bool LoadSettings(Microsoft.Win32.RegistryKey regKey = null);
        bool SaveSettings(Microsoft.Win32.RegistryKey regKey = null);
    }
}
