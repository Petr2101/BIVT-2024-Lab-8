using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_4 : Green 
    {
        private string[] _output; 
        private string _input; 
        public string[] Output => _output; 

        public Green_4(string i) : base(i) 
        {
            _input = i;
            _output = null;
        }
        public override void Review()

        {
            string[] surname;
            string[] part = _input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            surname = new string[part.Length];

            for (int i = 0; i < part.Length; i++)
            {
                surname[i] = part[i].Trim();
            }
            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < surname.Length-1; i++)
                {
                    if (CompareStrings(surname[i], surname[i+1]) > 0)
                    {
                        string t = surname[i];
                        surname[i] = surname[i+1];
                        surname[i + 1] = t;
                        swap = true;
                    }
                }
            } while (swap);
            _output = surname;
        }

        private int CompareStrings(string a, string b)
        {
            int minlen = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minlen; i++)
            {
                if (a[i] != b[i]) return Math.Sign(a[i] - b[i]);
            }
            return Math.Sign(a.Length - b.Length);
        }

        public override string ToString() 
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(Environment.NewLine, Output);
        }
    }



}