using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableWeekDay : ContextVariable
    {
        private DateTime _date = DateTime.Now;
        public ContextVariableWeekDay(DateTime date) : base("<WEEKDAY>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.DayOfWeek.ToString();
        }
    }
}
