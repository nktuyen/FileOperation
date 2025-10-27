using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkRename
{
    internal abstract class ContextVariable
    {
        private string _name = string.Empty;
        public string Name { get { return _name; }  }
        public string Value { get { return this.ExpandValue(); } }
        internal ContextVariable(string name)
        {
            _name = name;
        }

        virtual protected string ExpandValue()
        {
            return string.Empty;
        }
    }
}
