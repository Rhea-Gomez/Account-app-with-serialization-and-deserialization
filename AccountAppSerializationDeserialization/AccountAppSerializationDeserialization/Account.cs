using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppSerializationDeserialization
{
    internal class Account
    {
        public int AccountNo { get; set; }
        public string AccountHolderName{ get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }

        public Account()
        {

        }
        public Account(int accNo, string name, string bank, double balance)
        {
            AccountNo = accNo;
            AccountHolderName = name;
            BankName = bank;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("Amount deposited successfully");
            Console.WriteLine("Current Balance: " + Balance);
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            if (Balance < 0)
            {
                Console.WriteLine("Insufficient Balance!");
                Balance += amount;
                Console.WriteLine("Transaction unsuccessful!");
            }
            else
            {
                Console.WriteLine("Amount Withdrawn Successfully");
                Console.WriteLine("Current Balance: " + Balance);
            }



        }

        public void CheckBalance()
        {
            Console.WriteLine("Balance for " + AccountNo + ": " + Balance);
        }
    }
}
