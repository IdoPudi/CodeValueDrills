using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consider : https://msdn.microsoft.com/en-us/library/system.indexoutofrangeexception(v=vs.110).aspx
            string[] dirs = Directory.GetFiles(args[0],args[1]);
            foreach (var item in dirs)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.Length);
            }
        }
    }
}
