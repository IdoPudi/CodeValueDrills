using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    public class Account
    {
        public readonly int accountId;
        private decimal balance = 0;

        public Account(int accountId)
        {
            this.accountId = accountId;
        }

        public Account(int accountId, decimal balance)
        {
            this.accountId = accountId;
            this.balance = balance;
        }

        public decimal Balance { get { return balance; } }

        public int AccountId {get { return accountId; } }

        public void Deposit(decimal money) => this.balance += money;

        public void Withdraw(decimal money)
        {
            if (balance - money > 0)
                balance -= money;
            else
                Console.WriteLine("Nagitive balance you cant withdraw");
        }

        public void Transfer(Account transferToAccount, decimal amount)
        {
            if (this.balance - amount > 0)
            {
                transferToAccount.balance += amount;
                this.balance -= amount;
            }
            else
            {
                Console.WriteLine("Nagitive balance you cant transfer");
            }

        }
    }
}
