using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableMonth : ContextVariable
    {
        private DateTime _date = DateTime.Now;
        public ContextVariableMonth(DateTime date) : base("<MONTH>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.Month.ToString();
        }
    }
}
