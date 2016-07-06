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
            newAcc.Deposit(10);
            Console.WriteLine(newAcc.Balance);
            newAcc.Withdraw(230);

            Account newAcc2 = AccountFactory.CreateAccount(200);
            newAcc.Transfer(newAcc2, 50);
            Console.WriteLine(newAcc2.Balance);
        }
    }
}
