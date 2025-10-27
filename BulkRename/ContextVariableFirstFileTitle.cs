using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFirstFileTitle : ContextVariable
    {
        private MyFileInfo _fileInfo = null;
        public ContextVariableFirstFileTitle(MyFileInfo fi) : base("<FILE0.TITLE>")
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
