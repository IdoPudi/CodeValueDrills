using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    //Crashes on invalid input.
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        private static int GetNumber()
        {
            int number = 0;
            Console.WriteLine("Please aenter a number fromm 1 to 100");
            return number = int.Parse(Console.ReadLine());
        }

        private static void StartGame()
        {
            int secret = new Random().Next(1, 101);
            int count = 1;
            int number = 0;

            while (count <= 7)
            {
                count++;
                number = GetNumber();
                if (number == secret)
                    Console.WriteLine($"Congratz you managed to find the number in : {count-1}");
                else if (number > secret)
                    Console.WriteLine($"too big please enter another number");
                else
                    Console.WriteLine($"too small please enter another number");
            }
            if (count == 8)
                Console.WriteLine($"You failed it took you to find the number : {count}");
        }
    }
}
