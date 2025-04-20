using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    abstract public class Green 
    {
        private string _input;
        public string Input 
        {
            get { return _input ?? string.Empty; }
        }
        public Green(string i) 
        {
            _input = i;
        }
        public abstract void Review(); 
    }
}
