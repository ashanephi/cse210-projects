public class ListingActivity : Activity
{
    private int _counts;
    private List<string> _prompts = new List<string>() 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 30)
    {

    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        int duration;
        bool isTrue = true;
        duration = int.Parse(Console.ReadLine());
        SetDuration(duration);        

        ClearScreen_And_Start();

        while(isTrue)
        {
            Console.WriteLine("List as many responses you can to the following prompts: ");
            GetRandomPrompt();
            Console.WriteLine();
            Console.Write("You may begin in: ");
            ShowCountDown(5);

            List<string> userResponses = GetListFromUser(duration);
            _counts = userResponses.Count;

            foreach (string item in userResponses)
            {
                Logger.Log($"User listed: {item}");
            }

            Console.WriteLine($"You listed {_counts} items!");

            DisplayEndingMessage();
            isTrue = false;
        }
    }

    public void GetRandomPrompt()
    {
        Random randomPrompt = new Random();
        string prompt = _prompts[randomPrompt.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        Logger.Log($"User reflected on: {prompt}");
    }

    public List<string> GetListFromUser(int duration)
    {
        List<string> answers = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        Console.WriteLine();
        while(DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            answers.Add(answer);
        }

        return answers;
    }
}