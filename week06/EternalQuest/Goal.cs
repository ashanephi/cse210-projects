public abstract class Goal
{
    private string _shortName;
    private string _description;
    private string _points;
    private int _xp; 
    private static Random _random = new Random(); // This is made random for motivational messages
    
    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _xp = 0;
    }

    public string GetName()
    {
        return _shortName;
    }
    public int GetPoint()
    {
        return int.Parse(_points);
    }

    public void SetName(string name)
    {
        _shortName = name;
    }

    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }

    public void AddXP(int amount)
    {
        _xp += amount;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"You gained {amount} XP!");
        Console.ResetColor();
    }

    // Randomly displays motivational quotes
    public void ShowMotivationalQuote()
    {
        string[] quotes = {
            "Keep pushing forward!",
            "You'll get there",
            "You're closer than you think!",
            "Every step counts!",
            "Greatness takes time!",
            "Believe in yourself!",
            "You're the best",
        };
        int index = _random.Next(quotes.Length);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nMotivation: {quotes[index]}");
        Console.ResetColor();
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }
}
