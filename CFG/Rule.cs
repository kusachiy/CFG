using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFG
{

    class Rule
    {
        NonTerm left;
        Block[] right;

        public Rule(char left, params string[] right)
        {
            this.left = Grammar.NonTerms.Find(x => x.symbol == left);
            this.left.rule = this; 
            this.right = new Block[right.Length];
            for (int i = 0; i < right.Length; i++)
            {
                this.right[i] = new Block(right[i]);
            }
        }

        public bool HasAPartContainingOnly()
        {
            foreach (var block in right)
            {
                if (block.GetCountOfNonTerm == 0)
                    return true;
            }
            return false;
        }

        public bool HasAPartContainingOnly(NonTerm[] nts)
        {
            foreach (var block in right)
            {
                if (block.GetCountOfNonTerm == nts.Length)
                    if(block.ContainsNonTerms(nts))
                        return true;
            }
            return false;
        }



        public override string ToString()
        {
            string s = "";
            s += string.Format("{0} => ", left);
            for (int i = 0; i < right.Length-1; i++)
            {
                s += string.Format("{0} | ",right[i].ToString());
            }
            s += right[right.Length - 1].ToString();
            return s;
        }

        public NonTerm GetLeft { get { return left; } }
        public Block[] GetRight { get { return right; } }
    }
}
