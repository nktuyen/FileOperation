using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFileName : ContextVariable
    {
        private FileInfo _fileInfo = null;
        public ContextVariableFileName(System.IO.FileInfo fi) : base("<FILE.NAME>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            return this._fileInfo.Name;
        }
    }
}
