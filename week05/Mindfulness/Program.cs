using System;

/*
    Mindfulness Program - Logging Implementation
    --------------------------------------------
    I added to the program that it now includes a logging feature that records user activities
    in a log file (`mindfulness_log_{DateTime.Now:yyyyMMdd}.txt`). The logging system tracks:

    - When a user starts an activity.
    - The type of activity they choose.
    - The duration of the activity.
    - Any responses provided (for reflection and listing activities).
    - When the activity is completed.

    The Logger class handles writing these logs to a file, appending each 
    entry with a timestamp. 
*/

public class Program
{
    public static void Main(string[] args)
    {
        bool isTrue = true;
        Activity activity = null;
        Logger.Log("Program Started.");

        while(isTrue)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("\t1. Start breathing activity");
            Console.WriteLine("\t2. Start reflecting activity");
            Console.WriteLine("\t3. Start Listing activity");
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            
            switch(choice)
            {
                case "1":
                    Console.WriteLine();
                    activity = new BreathingActivity();
                    ((BreathingActivity)activity).Run();
                    break;
                case "2":
                    Console.WriteLine();
                    activity = new ReflectingActivity();
                    ((ReflectingActivity)activity).Run();
                    break;
                case "3":
                    Console.WriteLine();
                    activity = new ListingActivity();
                    ((ListingActivity)activity).Run();
                    break;
                case "4":
                    Logger.Log("User quits Program");
                    Logger.Log("Program Ended");
                    isTrue = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid user input. Try Again!");
                    break;
            }
        }
    }
}
