// According to many health experts, the "best" breathing rhythm for relaxation and stress relief is to inhale for a count of 4 seconds, hold for a count of 7 seconds, and exhale for a count of 8 seconds - often referred to as the "4-7-8 breathing technique" where you should focus on exhaling longer than inhaling and making a "whoosh" sound with pursed lips. This is the technique that would be implemented here.

public class BreathingActivity : Activity
{
    public BreathingActivity () : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 30)
    {
    }

    public void Run()
    {        
        Console.Clear();
        DisplayStartingMessage();
        int duration;
        duration = int.Parse(Console.ReadLine());
        SetDuration(duration);

        ClearScreen_And_Start();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        while(DateTime.Now < futureTime)
        {
            Console.WriteLine("\n\n");
            Console.Write($"Breathe in... ");
            ShowCountDown(4);  
            Console.WriteLine();    
            Console.Write("Hold");
            ShowDots(7);
            Console.WriteLine();

            Console.Write($"Breathe out...");
            ShowCountDown(8);

        }
        Console.WriteLine();
        DisplayEndingMessage();
    }
}