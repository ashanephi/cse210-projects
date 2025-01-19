public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    public string GetRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "If I had one thing I could do over today, what would it be?"
        };     

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        return "" + prompt;
    }
}