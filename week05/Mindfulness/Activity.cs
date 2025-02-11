public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public string GetName()
    {
        return _name + " Activity";
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    public void DisplayStartingMessage()
    {
        Logger.Log($"User started the {GetName()}.");
        Console.WriteLine($"Welcome to {GetName()}.\n");
        Console.WriteLine($"{GetDescription()}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!\n");
        ShowSpinner(3);
        Logger.Log($"User completed {GetName()} for {GetDuration()} seconds.");
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the {GetName()}");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationCharacters = new List<string>()
        {
            "/", "-", "\\", "|", "/", "-", "\\", "|", "-"
        };
        int index = 0;

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        
        while(DateTime.Now < futureTime)
        {
            Console.Write(animationCharacters[index]);
            Thread.Sleep(500);
            Console.Write("\b \b");

            index++;
            
            if(index >= animationCharacters.Count)
            {
                index = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int index=seconds; index > 0; index--)
        {
            Console.Write(index);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowDots(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);

        while (DateTime.Now < futureTime)
        {
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.Write("\b\b\b   \b\b\b");
        }
    }

    public void ClearScreen_And_Start()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);     
    }
}