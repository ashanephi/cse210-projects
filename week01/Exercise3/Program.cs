using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        do 
        {
            int numberOfTries = 1;
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            Console.WriteLine($"Magic number is {randomNumber}");
            Console.WriteLine("Guess a number from (1 - 100)");
            Console.Write("What is your guess? ");
            
            int answer = int.Parse(Console.ReadLine());
            while (answer != randomNumber)
            {
                if (answer < randomNumber)
                {
                    Console.WriteLine("Lower");
                }
                else 
                {
                    Console.WriteLine("Higher");
                }
                Console.Write("Guess again: ");
                numberOfTries++;
                answer = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Correct. You guessed the number after {numberOfTries} tries");
            Console.Write("Do you want to play again? (yes or no)");
            userInput = Console.ReadLine();
        }
        while (userInput == "yes");
    }
}