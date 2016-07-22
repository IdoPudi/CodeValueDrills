using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<FirstToDictionary, StringBuilder> dictionary = new MultiDictionary<FirstToDictionary, StringBuilder>();


            FirstToDictionary first;
            first.number = 1;

            dictionary.CreateNewValue(first);
            foreach (var item in dictionary.Values)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine(dictionary.Count());
        }
    }

    [Key]
    public struct FirstToDictionary
    {
        public int number;
    }
}
