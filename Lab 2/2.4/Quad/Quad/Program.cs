using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadEquation equation = new QuadEquation();
            double a = 0;
            double b = 0;
            double c = 0;
            double toSqrt = 0;
            string[] stringArguments = { "", "", "" };

            if (!equation.CheckThreeArguments(stringArguments))
                Console.ReadLine();

            if (!equation.CheckParseToDouble(stringArguments, out a, out b, out c))
                Console.ReadLine();

            if (a == 0)
                Console.WriteLine($"X = {equation.FirstSolution(b,c)}");

            if (b == 2 * a * c)
                Console.WriteLine($"X = {equation.SecondSolution(a, c)}");

            if (!equation.NoSolution(a,b,c,out toSqrt))
                Console.ReadLine();
        }
    }
}
