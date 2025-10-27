using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableDay : ContextVariable
    {
        private DateTime _date = DateTime.Now;
        public ContextVariableDay(DateTime date) : base("<DAY>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.Day.ToString();
        }
    }
}
