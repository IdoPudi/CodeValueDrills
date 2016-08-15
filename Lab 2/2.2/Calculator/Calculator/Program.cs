using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    //Nice idea to create a new class for the logic.
    class Program
    {
        static void Main(string[] args)
        {
            StartCalculator();
        }

        private static void ShowCalcResult(double number1, double number2, string calcOperator)
        {
            Calc calc = new Calc();

            if (calcOperator == "+")
                Console.WriteLine($"{number1} {calcOperator} {number2} = {calc.Add(number1, number2)}");
            else if (calcOperator == "-")
                Console.WriteLine($"{number1} {calcOperator} {number2} = {calc.Subtract(number1, number2)}");
            else if (calcOperator == "*")
                Console.WriteLine($"{number1} {calcOperator} {number2} = {calc.Multiply(number1, number2)}");
            else if (calcOperator == "/")
                Console.WriteLine($"{number1} {calcOperator} {number2} = {calc.Divide(number1, number2)}");
        }

        private static bool IsOperatorValid(string calcOperator)
        {
            //Could be implemented like this:
            //bool operatorValid = calcOperator == "+" || calcOperator == "-" || calcOperator == "*" || calcOperator == "/";

            bool operatorValid = false;

            if (calcOperator == "+" || calcOperator == "-" || calcOperator == "*" || calcOperator == "/")
                operatorValid = true;

            return operatorValid;
        }

        private static void StartCalculator()
        {
            double number1 = 0;
            double number2 = 0;
            
            //consider the use of var.
            string calcOperator = string.Empty;
            bool isOperator = false;

            Console.WriteLine("please enter number 1:");
            number1 = double.Parse(Console.ReadLine());
            Console.WriteLine("please enter number 2:");
            number2 = double.Parse(Console.ReadLine());
            Console.WriteLine("please enter operator +,-,*,/");
            calcOperator = Console.ReadLine();

            if (IsOperatorValid(calcOperator))
                ShowCalcResult(number1, number2, calcOperator);
            else
            {
                while (!isOperator)
                {
                    Console.WriteLine("please enter a valid operator +,-,*,/");
                    calcOperator = Console.ReadLine();
                    isOperator = IsOperatorValid(calcOperator);
                }
                ShowCalcResult(number1, number2, calcOperator);
            }
        }
    }
}
