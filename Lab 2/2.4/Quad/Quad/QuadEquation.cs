using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quad
{
    public class QuadEquation
    {
        public bool CheckThreeArguments(string[] args1)
        {
            bool threeArgs = false;
            if (args1.Length == 3)
                threeArgs = true;

            return threeArgs;
        }

        public bool CheckParseToDouble(string[] args1, out double a, out double b, out double c)
        {
            bool parseToDouble = false;
            if (!double.TryParse(args1[0], out a) || !double.TryParse(args1[1], out b) || !double.TryParse(args1[2], out c))
            {
                Console.WriteLine("Not all Arguments are numbers");
                a = 0;
                b = 0;
                c = 0;
            }
            else
                parseToDouble = true;

            return parseToDouble;
        }

        public double FirstSolution(double b, double c)
        {
            return (-1) * c / b;
        }

        public double SecondSolution(double a, double c)
        {
            return -Math.Sqrt(c) / Math.Sqrt(a);
        }

        public bool NoSolution(double a, double b, double c, out double toSqrt)
        {
            bool isSolution = false;
            toSqrt = Math.Pow(b, 2) - 4 * a * c;

            if (toSqrt < 0)
                Console.WriteLine("No solution");
            else
                isSolution = true;

            return isSolution;
        }

    }
}
