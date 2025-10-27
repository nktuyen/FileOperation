using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFileTitle : ContextVariable
    {
        private FileInfo _fileInfo = null;
        public ContextVariableFileTitle(FileInfo fi) : base("<FILE.TITLE>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            string res = _fileInfo.Name;
            int pos = res.LastIndexOf(".");
            if(pos >  -1)
                res = res.Substring(0, pos);
            return res;
        }
    }
}
