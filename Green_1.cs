using System;
using System.Text;

namespace Lab_8
{
    public class Green_1 : Green 
    {
        private (char, double)[] _output; 
        public (char, double)[] Output => _output; 
        public Green_1(string i) : base(i) 
        {
            _output = null;
        }

        public override void Review() 
        {
            string txt = Input.ToLower();
            char[] let = new char[]
            {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
                'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
                'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
            };
            int[] count = new int[let.Length];
            int total = 0;

            for (int i = 0; i < txt.Length; i++)
            {
                char a = txt[i];
                for (int j = 0; j < let.Length; j++)
                {
                    if (a == let[j])
                    {
                        count[j]++;
                        break;
                    }
                }
                if (char.IsLetter(a)) { total++; }
            }

            if (total == 0)
            {
                _output = new (char, double)[0];
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

            (char, double)[] result = new (char, double)[k];
            int ind = 0;
            for (int i = 0; i < let.Length; i++)
            {
                if (count[i] > 0)
                {
                    result[ind] = (let[i], (double)count[i] / total);
                    ind++;
                }
            }
            _output = result;
        }

        public override string ToString() 
        {
            return Output == null || Output.Length == 0
                ? string.Empty
                : string.Join(Environment.NewLine, Array.ConvertAll(Output, item => $"{item.Item1} - {item.Item2:F4}"));
        }

    }



}
