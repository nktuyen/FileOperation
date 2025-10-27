using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableMinute : ContextVariable
    {
        private DateTime _date = DateTime.Now;
        public ContextVariableMinute(DateTime date) : base("<MINUTE>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.Minute.ToString();
        }
    }
}
