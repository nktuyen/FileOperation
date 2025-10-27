using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal class ContextVariableSecond : ContextVariable
    {
        private DateTime _date = DateTime.Now;
        public ContextVariableSecond(DateTime date) : base("<SECOND>")
        {
            _date = date;
        }

        protected override string ExpandValue()
        {
            return _date.Second.ToString();
        }
    }
}
