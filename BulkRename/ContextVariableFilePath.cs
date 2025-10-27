using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFilePath : ContextVariable
    {
        private System.IO.FileInfo _fileInfo = null;
        public ContextVariableFilePath(System.IO.FileInfo fi) : base("<FILE.PARENT_DIRECTORY>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            return _fileInfo.DirectoryName;
        }
    }
}
