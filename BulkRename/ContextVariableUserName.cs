using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableUserName : ContextVariable
    {
        public ContextVariableUserName() : base("<USERNAME>")
        {
        }

        protected override string ExpandValue()
        {
            return System.Environment.UserName;
        }
    }
}
