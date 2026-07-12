// ============================================================
// Assignment 21: Basic Number Guessing Challenge vs Computer
// ============================================================
using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main()
        {
            var rnd = new Random();
            bool playAgain = true;

            Console.WriteLine("=== Number Guessing Challenge ===");

            while (playAgain)
            {
                int target = rnd.Next(1, 101); // 1..100 inclusive
                int attemptsLeft = 7;
                bool won = false;

                Console.WriteLine("\nI'm thinking of a number between 1 and 100.");
                Console.WriteLine($"You have {attemptsLeft} attempts.\n");

                while (attemptsLeft > 0)
                {
                    Console.Write($"Attempts left {attemptsLeft}. Your guess: ");
                    if (!int.TryParse(Console.ReadLine(), out int guess))
                    {
                        Console.WriteLine("  Please enter a valid integer.");
                        continue;
                    }

                    if (guess < 1 || guess > 100)
                    {
                        Console.WriteLine("  Out of range (1-100).");
                        continue;
                    }

                    attemptsLeft--;

                    if (guess == target)
                    {
                        Console.WriteLine($"  *** Correct! You guessed it in {7 - attemptsLeft} attempt(s). ***");
                        won = true;
                        break;
                    }
                    if (guess < target)
                        Console.WriteLine("  Too low!");
                    else
                        Console.WriteLine("  Too high!");
                }

                if (!won)
                    Console.WriteLine($"\nOut of attempts! The number was {target}.");

                // Computer's turn — it always guesses optimally via binary search
                Console.WriteLine("\n--- Computer's turn ---");
                ComputerPlays();

                Console.Write("\nPlay again? (y/n): ");
                playAgain = Console.ReadLine()?.Trim().Equals("y", StringComparison.OrdinalIgnoreCase) == true;
            }

            Console.WriteLine("Thanks for playing!");
        }

        static void ComputerPlays()
        {
            var rnd = new Random();
            int secret = rnd.Next(1, 101);
            int low = 1, high = 100, tries = 0;

            Console.WriteLine($"Computer is guessing a secret number in [1,100] (secret = {secret})");
            while (low <= high)
            {
                tries++;
                int guess = (low + high) / 2;
                Console.Write($"  Try {tries}: guess {guess} -> ");
                if (guess == secret)
                {
                    Console.WriteLine("CORRECT!");
                    break;
                }
                if (guess < secret)
                {
                    Console.WriteLine("too low");
                    low = guess + 1;
                }
                else
                {
                    Console.WriteLine("too high");
                    high = guess - 1;
                }
            }
            Console.WriteLine($"  Computer found it in {tries} tries (binary search).");
        }
    }
}
