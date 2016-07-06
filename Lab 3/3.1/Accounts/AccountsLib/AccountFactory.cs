using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class AccountFactory
    {
        static int id = 0;
        public static Account CreateAccount(decimal balance)
        {
            Account newAccount = new Account(id++);
            newAccount.Deposit(balance);
            return newAccount;
        }
    }
}
