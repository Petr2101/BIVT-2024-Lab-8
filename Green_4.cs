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
        public string[] Output => _output;

        public Green_4(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = new string[0];
                return;
            }
            string[] s = Input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            for (int j = 0; j < s.Length; ++j)
            {
                for (int i = j + 1; i < s.Length; ++i)
                {
                    string first = s[j].ToLower();
                    string second = s[i].ToLower();
                    int k = 0;

                    int minimal_len = Math.Min(s[j].Length, s[i].Length);
                    for (int g = 0; g < minimal_len; g++)
                    {
                        if (first[g] != second[g])
                        {
                            if (first[g] > second[g])
                            {
                                (s[j], s[i]) = (s[i], s[j]);
                            }
                            break;
                        }
                        k++;
                    }

                    if (k == minimal_len)
                    {
                        if (s[j].Length > s[i].Length)
                        {
                            string temp = s[j];
                            s[j] = s[i];
                            s[i] = temp;
                        }
                    }
                }
            }
            _output = s;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return "";
            }
            string res = "";

            for (int i = 0; i < _output.Length; i++)
            {
                res += $"{_output[i]}";
                if (i < _output.Length - 1)
                {
                    res += Environment.NewLine;
                }
            }
            return res;
        }
    }



}