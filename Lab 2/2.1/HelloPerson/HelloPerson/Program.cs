using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            string name = string.Empty;
            int number = 0;
            bool isNumber = false;

            Console.WriteLine("Whats's your name?");
            name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            Console.WriteLine("Please enter a number from 1 to 10");
            isNumber = int.TryParse(Console.ReadLine(), out number);

            while (!isNumber || number <= 0 || number > 10)
            {
                Console.WriteLine("Number must be from 1 to 10:");
                isNumber = int.TryParse(Console.ReadLine(), out number);
            }

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(name);
                name = " " + name;
            }
        }
    }
}
