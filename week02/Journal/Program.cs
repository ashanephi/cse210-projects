using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal newJournal = new Journal();
        string choice;
        do
        {
            Console.WriteLine("Welcome to the Journal Program");
            Console.WriteLine("Please select one of the following choice: ");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PromptGenerator randomPrompt = new PromptGenerator();
                    string prompt = randomPrompt.GetRandomPrompt().ToString();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    DateTime theCurrentTime = DateTime.Now;
                    string date = theCurrentTime.ToShortDateString();
                    Entry newEntry = new Entry();
                    newEntry._date = date;
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newJournal.AddEntry(newEntry);
                    break;

                case "2":
                    newJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename: ");
                    string loadFile = Console.ReadLine();
                    newJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename: ");
                    string saveFile = Console.ReadLine();
                    newJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    break;
                
                default:
                    Console.WriteLine("\nInvalid response. Try Again!");
                    Console.WriteLine("\n");
                    break;

            }
        }
        while(choice != "5");  
    }
}