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

        public static void BuildWithoutEmpty()
        {          
            List<NonTerm> useful = new List<NonTerm>();
            // шаг 1: добавляем в список полезных нетерминалы имеющие прямой вывод терминала.
            foreach (var nt in NonTerms)
            {
                if (nt.rule.HasAPartContainingOnly())
                    useful.Add(nt);
            }
            // шаг 2: добавляем рекурсивно в список полезных нетерминалы имеющих прямой вывод блока из терминалов и полезных нетерминалов.
            bool hasChanges = true;
            while (hasChanges)
            {
                hasChanges = false;
                foreach (var nt in NonTerms)
                {
                    if (nt.rule.HasAPartContainingOnly(useful.ToArray()))
                        if (!useful.Contains(nt))
                        {
                            useful.Add(nt);
                            hasChanges = true;
                        }
                }
            }
            //шаг 3: удаляем из правил, содержащих в левой части полезные нетерминалы, блоки с бесполезными нетерминалами в правой части.
            List<NonTerm> useless = NonTerms.Except(useful).ToList(); //вычитаем полезные из общего списка
            foreach (var nt in useful)
            {
                foreach (var nt2 in useless)
                {
                    nt.rule.RemoveBlockWithNonTerm(nt2);
                }
            }
            //шаг 4: заменяем исходную грамматику на новую
            NonTerms = useful;
        }

        public static void BuildWithoutNotAttainable()
        {
            List<NonTerm> useful = new List<NonTerm>();
            // шаг 1: добавляем в список достижимый нетерминал S
            useful.Add(NonTerms.First(x => x.symbol == 'S'));
            // шаг 2: добавляем рекурсивно в список достижимых нетерминалы, достижимые из уже добаленных. 
            bool hasChanges = true;
            while (hasChanges)
            {
                hasChanges = false;
                foreach (var nt in useful)
                {
                    foreach (var nt2 in NonTerms)
                    {
                        if (nt.rule.HasAPartContainingNonTerm(nt2))
                            if (!useful.Contains(nt2))
                            {
                                useful.Add(nt2);
                                hasChanges = true;
                            }
                    }
                    if (hasChanges)
                        break;          
                }
            }           
            //шаг 3: заменяем исходную грамматику на новую
            NonTerms = useful;
        }
    }
}
