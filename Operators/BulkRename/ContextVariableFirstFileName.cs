using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFirstFileName : ContextVariable
    {
        private MyFileInfo _fileInfo = null;
        public ContextVariableFirstFileName(MyFileInfo fi) : base("<FILE0.NAME>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            return this._fileInfo.Name;
        }
    }
}
