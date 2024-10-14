using System;
using System.Collections.Generic;

namespace lab1
{
    
    public class Program
    {
        static GameAccount SelectPlayer(List<GameAccount> accounts, string prompt)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {accounts[i].UserName}");
            }

            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > accounts.Count)
            {
                Console.WriteLine("Invalid choice, please try again.");
            }

            return accounts[index - 1];
        }

        public static void Main(string[] args)
        {
            List<GameAccount> accounts = new List<GameAccount>();
            bool continuePlaying = true;

            while (continuePlaying)
            {
                Console.WriteLine("Choose an option:\n1. Add a new account\n2. Start a game\n3. Exit");
                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Adding new account:");
                            Console.WriteLine("Enter username:");
                            string username = Console.ReadLine();
                            accounts.Add(new GameAccount(username));
                            Console.WriteLine($"Account for {username} has been created.");
                            break;
                        case 2:
                            Console.Clear();
                            if (accounts.Count < 2)
                            {
                                Console.WriteLine("At least two accounts are required to start a game.");
                            }
                            else
                            {
                                GameAccount account1 = SelectPlayer(accounts, "Select the first player:");
                                GameAccount account2 = SelectPlayer(accounts, "Select the second player (must be different):");
                                Console.Clear();
                                while (account1 == account2)
                                {
                                    Console.WriteLine("Second player must be different from the first player. Try again.");
                                    account2 = SelectPlayer(accounts, "Select the second player (must be different):");
                                }

                                Console.WriteLine("How many games would you like to simulate?");
                                int numberOfGames;
                                while (!int.TryParse(Console.ReadLine(), out numberOfGames) || numberOfGames <= 0)
                                {
                                    Console.WriteLine("Please enter a valid positive number.");
                                }

                                Console.WriteLine("Enter the rating for each game:");
                                int rating;
                                while (!int.TryParse(Console.ReadLine(), out rating) || rating <= 0)
                                {
                                    Console.WriteLine("Please enter a valid positive rating.");
                                }

                                Console.WriteLine("\nStarting games ...");
                                for (int i = 0; i < numberOfGames; i++)
                                {
                                    Game.ImitationGame(account1, account2, rating);
                                }

                                Console.WriteLine("\nFinal player stats after all games:");
                                account1.GetStats();
                                account2.GetStats();
                            }
                            break;

                        case 3:
                            Console.WriteLine("Goodbye!");
                            continuePlaying = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}