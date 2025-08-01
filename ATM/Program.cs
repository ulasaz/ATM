using System;
using System.ComponentModel.Design;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, ATM> atmNetwork = new();
            
            ATM firstAtm = new ATM(1,1000);
            ATM secondAtm = new ATM(2,5000);
            ATM thirdAtm = new ATM(3,6000);
            
            atmNetwork.Add(firstAtm.Id, firstAtm);
            atmNetwork.Add(secondAtm.Id, secondAtm);
            atmNetwork.Add(thirdAtm.Id, thirdAtm);
            
            ProcessUserInteraction(atmNetwork);
        }
        private static void ProcessUserInteraction(Dictionary<int, ATM> atmNetwork)
        {
            while (true)
            {
                Console.WriteLine("Welcome to ATM network please choose your ATM");

                foreach (var atm in atmNetwork)
                {
                    Console.WriteLine(atm.Key);
                }
                int mainChoice = int.Parse(Console.ReadLine());
                
                ATM mainATM = FindATM(mainChoice, atmNetwork);
                
                Console.WriteLine("Please enter a number of your bank account");
                
                var a = Console.ReadLine();
                int number = int.Parse(a);
                
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Balance");
                    Console.WriteLine("2. Top up");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Transfer");
                    Console.WriteLine("5. Transaction History");
                
                    var choice = Console.ReadLine();
                    MainMenu(choice, mainATM, number , atmNetwork);
            }
        }
        private static void MainMenu(string choice, ATM atm, int number, Dictionary<int, ATM> atmNetwork)
        {
            if (choice == "1")
            {
                Console.WriteLine($"Your current balance is: {atm.GetBalance(number, atm.Id)} $" );
            }
            else if (choice == "2")
            {
                Console.WriteLine("How much money do you want to top up ?");
                int amountOfTopUp = int.Parse(Console.ReadLine());
                atm.TopUp(number, amountOfTopUp, atm.Id);
                
                Console.WriteLine($"Your current balance is: {atm.GetBalance(number, atm.Id)} $");
            }
            else if (choice == "3")
            {
                Console.WriteLine("How much money do you want to withdraw ?");
                int amount = int.Parse(Console.ReadLine());
                double result = atm.Withdraw(number, amount, atm.Id);
                
                if (result == -2)
                {
                    Console.WriteLine("Chosen ATM doesn't have enough money you can choice next ATM");
                    Console.WriteLine(FindAtmWithEnoughMoney(atmNetwork, amount));
                } 
                else if (result == -1)
                    Console.WriteLine("You don't have enough money");
                else
                    Console.WriteLine($"Your current balance is: {atm.GetBalance(number, atm.Id)} $");  
            }
            else if (choice == "4")
            {
                Console.WriteLine("Please write the amount you want to top up");
                int amountOfTransfer = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Please write the account number you want to top up");
                int toNumberAccount = int.Parse(Console.ReadLine());
                
                if (atm.Transfer(number,amountOfTransfer, toNumberAccount, atm.Id) == -1)
                    Console.WriteLine("Please check the information one more time");
                else
                    Console.WriteLine($"Your current balance is: {atm.GetBalance(number, atm.Id)} $");  
            }
            else if (choice == "5")
            {
               List<Transaction> transactions =  TransactionHistory.GetTransactionHistory(number);
               
               PrintTransactionHistory(transactions);
            }
        }
        public static ATM FindATM(int choice, Dictionary<int, ATM> atmNetwork)
        {
            ATM atm = atmNetwork[choice];
            return atm;
        }
        public static int FindAtmWithEnoughMoney(Dictionary<int, ATM> atmNetwork, int amount)
        {
            foreach (var atm in atmNetwork)
            {
                if (atm.Value.TotalBalance > amount)
                    return atm.Value.Id;
            }
            return -1;
        }
        public static void PrintTransactionHistory(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}