using AccountsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Account newAcc = AccountFactory.CreateAccount(200);
            try
            {
                newAcc.Deposit(10);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(newAcc.Balance);

            try
            {
                newAcc.Withdraw(230);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Account newAcc2 = AccountFactory.CreateAccount(200);
            try
            {
                newAcc.Transfer(newAcc2, 200);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
