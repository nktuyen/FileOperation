using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFirstFileSize : ContextVariable
    {
        private MyFileInfo _fileInfo = null;
        public ContextVariableFirstFileSize(MyFileInfo fi) : base("<FILE0.SIZE>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            return this._fileInfo.Length.ToString();
        }
    }
}
