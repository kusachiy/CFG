using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG
{    
    static class Grammar
    {       
        public static List<NonTerm> NonTerms;
        static Grammar()
        {
            NonTerms = new List<NonTerm>();
        }
        public static void SetNonTerms(char[] nonterms)
        {
            foreach (var nt in nonterms)
            {
                NonTerms.Add(new NonTerm { symbol = nt });
            }
        }
        public static void Convert()
        {

        }
    }
}
