using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFileExtension : ContextVariable
    {
        private FileInfo _fileInfo = null;
        public ContextVariableFileExtension(FileInfo fi) : base("<FILE.EXTENSION>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            string res = this._fileInfo.Extension;
            int pos = res.IndexOf('.');
            if ((pos>-1))
            {
                res = res.Substring(pos + 1);
            }
            return res;
        }
    }
}
