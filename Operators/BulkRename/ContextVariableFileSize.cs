using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFileSize : ContextVariable
    {
        private FileInfo _fileInfo = null;
        public ContextVariableFileSize(FileInfo fi) : base("<FILE.SIZE>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            return this._fileInfo.Length.ToString();
        }
    }
}
