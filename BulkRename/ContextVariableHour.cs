using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableHour : ContextVariable
    {
        private DateTime _date = DateTime.Now;
        public ContextVariableHour(DateTime date) : base("<HOUR>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.Hour.ToString();
        }
    }
}
