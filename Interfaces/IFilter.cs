using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFilter
    {
        string Name { get; }
        bool Enabled { get; set; }
        System.Windows.Forms.IWin32Window MainWnd { get; set; }
        bool Initialize();
        bool Filter(string filePath);
        System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner = null);
        System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner = null);
    }
}
