using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        public struct Rational
        {
            public int numerator;
            public int denominator;
        }

        public Rational rational1;

        public Program(int num, int den)
        {
            rational1.denominator = den;
            rational1.numerator = num;
            Reduce();
        }

        public Program(int num)
        {
            rational1.numerator = num;
            rational1.denominator = 1;
            Reduce();
        }

        public int Numerator { get { return rational1.numerator; } }
        
        public int denominator { get { return rational1.denominator; } }

        public double value { get { return rational1.numerator / rational1.denominator; } }

        public Rational Add(Rational rational2)
        {
            Rational result;

            rational1.numerator *= rational2.denominator;
            rational2.numerator *= rational1.denominator;
            result.numerator = rational1.numerator + rational2.numerator;
            result.denominator = rational1.denominator * rational2.denominator;
            Reduce();
            return result;
        }

        private void Reduce()
        {
            int max = 1;
            Rational result = rational1;
            for (int i = 2; i < result.denominator; i++)
            {
                if (result.denominator % i == 0 && result.numerator % i == 0)
                    max = i;
            }
            result.numerator /= max;
            result.denominator /= max;
            rational1 = result;
        }

        public Rational Mul(Rational rational2)
        {
            Rational result;

            result.numerator = rational1.numerator * rational2.numerator;
            result.denominator = rational1.denominator * rational2.denominator;

            Reduce();
            return result;
        }

        public override String ToString()
        {
            if (rational1.denominator == 0)
                return ("cannot be solved");
            return rational1.numerator + "/" + rational1.denominator + "=" + value;
        }

        public override bool Equals(Object ob)
        {
            var r2 = (Program)ob;
            return (rational1.numerator == r2.rational1.numerator) && (rational1.denominator == r2.rational1.denominator);
        }

        static void Main(string[] args)
        {
            Program program1 = new Program(2, 1);
            Program program2 = new Program(2);
            Console.WriteLine(program1 + " and " + program2);

            program1.rational1 = program1.Add(program2.rational1);
            program1.rational1 = program1.Mul(program2.rational1);

            Console.Write(program1 + " and " + program2 + " is ");
            if (!program1.Equals(program2))
                Console.Write("Not ");
            Console.WriteLine("Equal");
            Console.ReadLine();
        }
    }
}
