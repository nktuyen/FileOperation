using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableDate : ContextVariable
    {
        DateTime _date = DateTime.Now;
        public ContextVariableDate(DateTime date) : base("<TODAY>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.ToString();
        }
    }
}
