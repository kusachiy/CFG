using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFG
{
    public partial class Form1 : Form
    {
        string pathInput = "input.txt";
        string pathIntermediate = "intermediate.txt";
        string pathOutput = "output.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void load_data_Click(object sender, EventArgs e)
        {
            Grammar.SetNonTerms(QuickRead());
            StreamReader sr = new StreamReader(pathInput);
            while (!sr.EndOfStream)
            {
                Rule rule;
                char left;
                string right;                
                string[] s = sr.ReadLine().Trim().Replace(" ", string.Empty).Split('>');//без пробелов
                left = s[0][0];              
                right = s[1];
                s = right.Split('|');
                rule = new Rule(left,s);            
            }
            sr.Close();
            label1.Text = "Загружено";
        }

        private void transform_Click(object sender, EventArgs e)
        {
            Grammar.BuildWithoutEmpty();
            StreamWriter sw = new StreamWriter(pathIntermediate);
            foreach (var item in Grammar.NonTerms)
            {
                sw.WriteLine(item.rule.ToString());
            }
            label1.Text = "Преобразовано и получен промежуточный результат";
            sw.Close();
        }

        private void save_data_Click(object sender, EventArgs e)
        {
            Grammar.BuildWithoutNotAttainable();
            StreamWriter sw = new StreamWriter(pathOutput);
            foreach (var item in Grammar.NonTerms)
            {
                sw.WriteLine(item.rule.ToString());
            }
            label1.Text = "Выгружено";
            sw.Close();
        }

        char[] QuickRead()
        {
            StreamReader sr = new StreamReader(pathInput);
            string s = sr.ReadToEnd();
            List<char> nonterms = new List<char>();
            foreach (var chr in s)
            {
                if (chr >= 65 && chr <= 90)
                    if (!nonterms.Contains(chr))
                        nonterms.Add(chr);
            }
            sr.Close();
            return nonterms.ToArray();          
        }

    }
}
