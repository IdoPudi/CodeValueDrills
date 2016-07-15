using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    public class A
    {
        public A() { }
        public string Hello(string input)
        {
            return $"Hello {input}"; 
        }
    }
}
