using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG
{
    class NonTerm
    {
        public char symbol { get; set; }
        public Rule rule { get; set; }
        public override string ToString()
        {
            return symbol.ToString();
        }
    }
}
