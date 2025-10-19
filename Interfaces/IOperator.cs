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
        string Description { get; }
        string ErrorMessage { get; }
        System.Drawing.Bitmap Icon { get; }
        bool Enabled { get; set; }
        string FilePath { get; set; }
        System.Windows.Forms.IWin32Window MainWnd { get; set; }
        bool Initialize();
        bool InitializeContextMenu(bool isMultiple);
        bool PreOperate(bool isMultiple);
        bool Operate();
        System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner);
        System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner);
    }
}
