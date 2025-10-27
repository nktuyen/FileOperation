using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFirstFilePath : ContextVariable
    {
        private MyFileInfo _fileInfo = null;
        public ContextVariableFirstFilePath(MyFileInfo fi) : base("<FILE0.PARENT_DIRECTORY>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            return _fileInfo.DirectoryName;
        }
    }
}
