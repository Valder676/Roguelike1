using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Bank
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        public List<ATM> ATMs { get; set; }
    }

    public class Account
    {
        public string Number { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }

        public virtual void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawal successful. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }

    public class RegularAccount : Account
    {
        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);
        }
    }

    public class PrivilegedAccount : Account
    {
        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);
        }
    }

    public class ATM
    {
        public string Id { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        static List<Bank> banks = new List<Bank>
        {
            new Bank
            {
                Name = "Bank1",
                Accounts = new List<Account>
                {
                    new RegularAccount { Number = "123456", PinCode = "1111", Balance = 1000 },
                    new PrivilegedAccount { Number = "654321", PinCode = "2222", Balance = 2000 }
                },
                ATMs = new List<ATM>
                {
                    new ATM { Id = "ATM1", Address = "Address1" },
                    new ATM { Id = "ATM2", Address = "Address2" }
                }
            },
            new Bank
            {
                Name = "Bank2",
                Accounts = new List<Account>
                {
                    new RegularAccount { Number = "789012", PinCode = "3333", Balance = 1500 },
                    new PrivilegedAccount { Number = "210987", PinCode = "4444", Balance = 2500 }
                },
                ATMs = new List<ATM>
                {
                    new ATM { Id = "ATM3", Address = "Address3" },
                    new ATM { Id = "ATM4", Address = "Address4" }
                }
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank Search App");
            while (true)
            {
                Console.Write("Do you want to search for something? (y/n): ");
                string searchChoice = Console.ReadLine().ToLower();
                if (searchChoice == "n") break;

                Console.Write("Enter the class to search (Bank, Account, ATM): ");
                string className = Console.ReadLine();

                Console.Write("Enter a keyword to search: ");
                string keyword = Console.ReadLine().ToLower();

                if (className.ToLower() == "bank")
                {
                    SearchBanks(keyword);
                }
                else if (className.ToLower() == "account")
                {
                    SearchAccounts(keyword);
                }
                else if (className.ToLower() == "atm")
                {
                    SearchATMs(keyword);
                }
                else
                {
                    Console.WriteLine("Class not found.");
                }
            }
        }

        static void SearchBanks(string keyword)
        {
            List<Bank> results = new List<Bank>();
            foreach (var bank in banks)
            {
                if (bank.Name.ToLower().Contains(keyword))
                {
                    results.Add(bank);
                }
            }

            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var bank in results)
                {
                    Console.WriteLine($"Bank Name: {bank.Name}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        static void SearchAccounts(string keyword)
        {
            List<Account> results = new List<Account>();
            foreach (var bank in banks)
            {
                foreach (var account in bank.Accounts)
                {
                    if (account.Number.ToLower().Contains(keyword) ||
                        account.PinCode.ToLower().Contains(keyword) ||
                        account.Balance.ToString().Contains(keyword))
                    {
                        results.Add(account);
                    }
                }
            }

            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var account in results)
                {
                    Console.WriteLine($"Account Number: {account.Number}, Balance: {account.Balance}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        static void SearchATMs(string keyword)
        {
            List<ATM> results = new List<ATM>();
            foreach (var bank in banks)
            {
                foreach (var atm in bank.ATMs)
                {
                    if (atm.Id.ToLower().Contains(keyword) ||
                        atm.Address.ToLower().Contains(keyword))
                    {
                        results.Add(atm);
                    }
                }
            }

            if (results.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var atm in results)
                {
                    Console.WriteLine($"ATM ID: {atm.Id}, Address: {atm.Address}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }
    }
}
