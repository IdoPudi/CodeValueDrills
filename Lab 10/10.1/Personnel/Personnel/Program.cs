using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile();
        }

        /**Bug: Application crashes because file is not found (consider not using an absolute path when working with files)
         * Which would have been fine since your code is correct. unfortunately you are not handling exceptions at all, which is expected at this point in the course.
         * Consider this:
         * https://msdn.microsoft.com/en-us/library/ms164917.aspx
         */

        private static void ReadFile()
        {
            List<string> strings = new List<string>();
            string text = string.Empty;
            using( var streamReader = new StreamReader(@"D:\CodeValue\Ready\Lab 10\10.1\names.txt"))
            {
                while (streamReader.Peek() >= 0)
                {
                    text = streamReader.ReadLine();
                    strings.Add(text);
                }
            }
            PrintNames(strings);
        }

        private static void PrintNames(List<string> strings)
        {
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
