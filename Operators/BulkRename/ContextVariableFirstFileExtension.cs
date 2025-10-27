using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableFirstFileExtension : ContextVariable
    {
        private MyFileInfo _fileInfo = null;
        public ContextVariableFirstFileExtension(MyFileInfo fi) : base("<FILE0.EXTENSION>")
        {
            this._fileInfo = fi;
        }

        protected override string ExpandValue()
        {
            string res = this._fileInfo.Extension;
            int pos = res.IndexOf('.');
            if ((pos > -1))
            {
                res = res.Substring(pos + 1);
            }
            return res;
        }
    }
}
