public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>() {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>() 
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 30)
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

        List<string> askedQuestions = new List<string>();

        while(isTrue)
        {
            Console.WriteLine("\nConsider the following prompt: ");
            Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
            
            Logger.Log($"User reflected on: {GetRandomPrompt()}");

            Console.WriteLine("\nWhen you have something in mind, press enter to continue");
            string userInput = Console.ReadLine();   

            if(String.IsNullOrEmpty(userInput) || userInput.Trim().Length == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Now ponder on each of the following questoins as they are related to this experience.");
                Console.WriteLine();
                Console.Write("You may begin in: ");

                ShowCountDown(5);

                Console.Clear();
                Console.WriteLine();
                DisplayQuestions(duration);
                isTrue = false;         
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nPress enter to continue");
            }
        }

        Console.WriteLine();
        DisplayEndingMessage(); 
    }

    public string GetRandomPrompt()
    {
        Random randomPrompt = new Random();
        string prompt = _prompts[randomPrompt.Next(_prompts.Count)];

        return prompt;
    }

    public string GetRandomQuestions()
    {
        Random randomQuestion = new Random();
        string question = _questions[randomQuestion.Next(_questions.Count)];
        return question;
    }

    public void DisplayQuestions(int duration)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        List<string> askedQuestions = new List<string>();

        while(DateTime.Now < futureTime)
        {
            string question;
            do
            {
                question = GetRandomQuestions();
            } while (askedQuestions.Contains(question));

            askedQuestions.Add(question);
            Console.Write($"> {question} ");
            Logger.Log($"User reflected on: {question}");
            ShowSpinner(10);
            Console.WriteLine();                      
        }        
    }
}