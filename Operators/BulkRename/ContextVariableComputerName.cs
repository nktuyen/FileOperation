using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableComputerName : ContextVariable
    {
        public ContextVariableComputerName() : base("<COMPUTER_NAME>")
        {
        }

        protected override string ExpandValue()
        {
            return System.Environment.MachineName;
        }
    }
}
