using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string sentence = string.Empty;
            Console.WriteLine("Please enter a sentence");

            sentence = Console.ReadLine();
            if (sentence != string.Empty)
            {
                var words = sentence.Split();
                p.CountWords(words);
                p.ReverseWords(words);
                p.SortWords(words);
            }
            else
            {
                Console.WriteLine("you didnt enetred a sentence");
            }
            Console.ReadKey();

        }

        public int CountWords(string[] words)
        {
            Console.WriteLine($"number of words is: {words.Length}");
            return words.Length;
        }

        public string[] ReverseWords(string[] words)
        {
            Array.Reverse(words);
            Console.Write($"Reverse Words:");
            printWords(words);
            return words;
        }

        public string[] SortWords(string[] words)
        {
            Array.Sort(words);
            Console.Write($"Sorted Words:");
            printWords(words);
            return words;
        }

        private static void printWords(string[] words)
        {
            string result = string.Empty;
            foreach (var s in words)
            {
                result = $"{result} {s}";
            }

            Console.WriteLine(result);
        }
    }
}
