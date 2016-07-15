using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            InvokeHello(new A(), "ido");
            InvokeHello(new B(), "ido");
            InvokeHello(new C(), "ido");
        }

        private static void InvokeHello(object obj, string input)
        {
            object[] parametersArray = new object[] { input };
            var type = obj.GetType();            
            var method = type.GetMethod("Hello");
            var result = method.Invoke(obj, parametersArray); ;
            Console.WriteLine(result);
        }
    }
}
