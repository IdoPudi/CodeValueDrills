using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DollarStairs
{
    //crashes on invalid input
    class Program
    {
        static void Main(string[] args)
        {
            StartStairs();
        }

        private static void StartStairs()
        {
            int n = 0;
            Console.WriteLine("Please enter a number :");

            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write("$");
                Console.WriteLine("$");
            }
            Console.ReadLine();
        }
    }
}
