﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void load_data_Click(object sender, EventArgs e)
        {
            Grammar.SetNonTerms(QuickRead());
            StreamReader sr = new StreamReader("input.txt");
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

        private void save_data_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("output.txt");
            foreach (var item in Grammar.NonTerms)
            {
                sw.WriteLine(item.rule.ToString());
            }
            label1.Text = "Выгружено";
            sw.Close();
        }

        char[] QuickRead()
        {
            StreamReader sr = new StreamReader("input.txt");
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