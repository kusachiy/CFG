using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG
{
    class Block
    {
        List<char> terms;
        List<NonTerm> nonterms;
        string block;

        public Block(string block)
        {
            this.block = block;
            terms = new List<char>();
            nonterms = new List<NonTerm>();
            foreach (var letter in block)
            {
                if (letter >= 65 && letter <= 90)
                    nonterms.Add(Grammar.NonTerms.Find(x => x.symbol == letter));
                else
                    terms.Add(letter);
            }
        }

        public int GetCountOfNonTerm { get { return nonterms.Count; } }
        public bool ContainsNonTerm(NonTerm n)
        {
            return nonterms.Contains(n);
        }
        public bool ContainsNonTerms(NonTerm[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                if (!nonterms.Contains(n[i]))
                    return false;
            }
            return true;

        }
        public override string ToString()
        {
            return block;
        }        
    }
}
