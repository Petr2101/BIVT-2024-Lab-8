using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_3 : Green 
    {
        private string[] _output; 
        private string _posled; 
        public string[] Output => _output; 

        public Green_3(string i, string posled) : base(i) 
        {
            _output = null;
            _posled = posled;
        }

        public override void Review() 
        {
            string txt = Input;
            char[] del = { ' ', '.', '!', '?', ',', ':', '\"',';',
                                  '–', '(', ')', '[', ']', '{', '}', '/'};

            string[] word = txt.Split(del, StringSplitOptions.RemoveEmptyEntries);
            int counts = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].IndexOf(_posled, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    counts++;
                }
            }

            string[] Words = new string[counts];
            int ind = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].IndexOf(_posled, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Words[ind] = word[i].ToLower();
                    ind++;
                }
            }
            _output = Words.Distinct().ToArray();
        }

        public override string ToString()
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(Environment.NewLine, Output);
        }
    }



}
