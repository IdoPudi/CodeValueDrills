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

        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("The amount must be positive so you can deposit");
            }
            this.balance += money;
        }

        public void Withdraw(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentOutOfRangeException("The amount must be positive so you can deposit");
            }

            if (balance - money > 0)
                balance -= money;
            else
                Console.WriteLine("Nagitive balance you cant withdraw");

        }

        public void Transfer(Account transferToAccount, decimal amount)
        {
            decimal currentAmount = transferToAccount.Balance;
            try
            {
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("The amount must be positive so you can deposit");
                }
                else
                {
                    if (this.balance - amount > 0)
                    {
                        transferToAccount.balance += amount;
                        this.balance -= amount;
                    }
                    else
                        Console.WriteLine("Nagitive balance you cant transfer");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("An attempt to transfer money was done");
                Console.WriteLine($"Amount before transfer : {currentAmount}");
                Console.WriteLine($"Amount after transfer : {transferToAccount.balance}");
            }
        }
    }
}
