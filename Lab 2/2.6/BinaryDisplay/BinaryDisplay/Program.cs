using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDisplay
{
    //crashes on invalid input.
    //doesn't print the number of 1's.
    //doesn't print results of negative numbers.
    public class Program
    {
        static void Main(string[] args)
        {
            ConvertNumberToBinary();
        }

        public static void ConvertNumberToBinary()
        {
            Program binaryFunc = new Program();
            int number;
            string binary = string.Empty;

            Console.WriteLine("Please enter a number");
            number = int.Parse(Console.ReadLine());

            binary = binaryFunc.ConvertNumber(number);

            Console.WriteLine(binary);
        }

        public string ConvertNumber(int number)
        {
            string binary = string.Empty;

            while (number > 0)
            {
                binary = (number & 1) + binary;
                number = number >> 1;
            }
            return binary;
        }
    }
}
