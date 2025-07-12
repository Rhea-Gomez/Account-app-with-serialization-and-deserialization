using System.Text.Json;
using System.Xml.Serialization;

namespace AccountAppSerializationDeserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            double amount;
            int choice;
            string choice1;
            Console.WriteLine("Welcome! Enter Account Details to create new Account: ");
            do
            {
                
                Console.Write("Enter bank account number: ");
                int accNo = int.Parse(Console.ReadLine());

                Console.Write("Enter Account Holder's Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Name of the Bank: ");
                string bank = Console.ReadLine();

                Console.Write("Enter Opening Balance: ");
                double balance;
                do
                {
                    Console.Write("Your account must have a minimum balance of Rs. 500. \nPlease enter an amount to keep the minimum balance: ");
                    balance = double.Parse(Console.ReadLine());
                } while (balance < 500);

                Account account = new Account(accNo, name, bank, balance);
                Console.WriteLine("Account Created Successfully");
                accounts.Add(account);
                do
                {
                    Console.WriteLine("What do you wish to do? ");
                    Console.WriteLine("1. Deposit Amount \n2. Withdraw Amount \n3. Check Balance \n4. Exit");
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter amount to deposit: ");
                            amount = double.Parse(Console.ReadLine());
                            account.Deposit(amount);
                            break;
                        case 2:
                            Console.Write("Enter amount to withdraw: ");
                            amount = double.Parse(Console.ReadLine());
                            account.Withdraw(amount);
                            break;
                        case 3:
                            account.CheckBalance();
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice!");
                            break;
                    }
                } while (choice != 4);

                Console.WriteLine("Press 'O' to exit or any other key to continue...");
                choice1 = Console.ReadLine();
                switch (choice1)
                {
                    case "0": break;
                    case "1": break;
                    default: 
                        break;
                }
                

            } while (choice1 != "0");
                
                
                

                string path = @"D:\Training\Assignments\AccountAppSerializationDeserialization\SerializeJSONfile.json";

                string jsonString = JsonSerializer.Serialize<List<Account>>(accounts);
                File.WriteAllText(path, jsonString);

                string fileString = File.ReadAllText(path);
                Console.WriteLine(fileString);

                //Deserialize
                List<Account> accountInfo = JsonSerializer.Deserialize<List<Account>>(fileString);

                //Prepare a string to write to the second file
                string contactDetails = string.Join("\n", accounts.Select(c => $"Account Number {c.AccountNo}, Account Holder Name: {c.AccountHolderName}, Bank Name: {c.BankName}, Balance: {c.Balance}"));

                string path2 = @"D:\Training\Day13\DeserializeJSONfile.txt";
                File.WriteAllText(path2, contactDetails);

                //Read and print the text file
                string fileString2 = File.ReadAllText(path2);
                Console.WriteLine(fileString2);

        }
            
    }
}
