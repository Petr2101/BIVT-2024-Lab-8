using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_2 : Green 
    {
        private char[] _output; 
        public char[] Output => _output; 
        public Green_2(string i) : base(i) 
        {
            _output = null;
        }

        public override void Review()
        {
            string txt = Input.ToLower();
            char[] letter = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                                  'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                                  'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                                  'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                  'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                  'u', 'v', 'w', 'x', 'y', 'z'};

            char[] del = { ' ', '.', '!', '?', ',', ':', '\"',';',
                                  '–', '(', ')', '[', ']', '{', '}', '/'};

            string[] word = txt.Split(del, StringSplitOptions.RemoveEmptyEntries);
            int[] count = new int[letter.Length];
            int total = 0;
            for (int i = 0; i < word.Length; i++)
            {
                char first = word[i][0];
                for (int j = 0; j < letter.Length; j++)
                {
                    if (first == letter[j])
                    {
                        count[j]++;
                        total++;
                        break;
                    }
                }
            }
            if (total == 0)
            {
                _output = new char[0];
                return;
            }

            int k = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    k++;
                }
            }

            (char, int)[] time = new (char, int)[k];
            int ind = 0;
            for (int i = 0; i < letter.Length; i++)
            {
                if (count[i] > 0)
                {
                    time[ind] = (letter[i], count[i]);
                    ind++;
                }
            }

            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < time.Length - 1; i++)
                {
                    if (time[i].Item2 < time[i + 1].Item2 ||
                       (time[i].Item2 == time[i + 1].Item2 && time[i].Item1 > time[i + 1].Item1))
                    {
                        var t = time[i];
                        time[i] = time[i + 1];
                        time[i + 1] = t;
                        swap = true;
                    }
                }

            } while (swap);
            _output = new char[time.Length];
            for (int i = 0; i < time.Length; i++)
            {
                _output[i] = time[i].Item1;
            }
        }

        public override string ToString() 
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(", ", _output);
        }
    }



}