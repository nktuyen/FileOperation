using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOperator
    {
        string Name { get; set; }
        bool Enabled { get; set; }
        bool Initialize();
        bool Operate(string filePath);
        System.Windows.Forms.DialogResult ShowAbout(System.Windows.Forms.IWin32Window owner);
        System.Windows.Forms.DialogResult ShowSettings(System.Windows.Forms.IWin32Window owner);
    }
}
