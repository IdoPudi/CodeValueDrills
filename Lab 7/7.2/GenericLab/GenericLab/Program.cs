using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLab
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiDictionary<int, string> dictionary = new MultiDictionary<int, string>();

            AddValues(dictionary);
            PrintTest(dictionary);
        }

        public static void AddValues(MultiDictionary<int, string> dictionary)
        {
            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            dictionary.Add(3, "three");
            dictionary.Add(1, "ich");
            dictionary.Add(2, "nee");
            dictionary.Add(3, "sun");
        }

        public static void PrintTest(MultiDictionary<int, string> dictionary)
        {
            Console.WriteLine($"Number of values: {dictionary.Count}");

            Console.WriteLine("*******Values:*******");
            foreach (var item in dictionary.Values)
            {
                Console.WriteLine(item);
            }

            dictionary.Remove(1);
            Console.WriteLine($"Number of values: {dictionary.Count}");

            dictionary.Remove(2, "nee");
            Console.WriteLine($"Number of values: {dictionary.Count}");

            Console.WriteLine("*******Keys:*******");
            foreach (var item in dictionary.Keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Contains key 2 : {dictionary.ContainsKey(2)}");
            Console.WriteLine($"Contains key 3 with value sun: {dictionary.Contains(3, "sun")}");

            dictionary.Clear();
            Console.WriteLine($"Count after clear: {dictionary.Count}");
        }
    }
}
