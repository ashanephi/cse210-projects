public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        AddXP(20);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You earned {GetPoint()} points!");
        Console.ResetColor();
        ShowMotivationalQuote();
    }

    public override bool IsComplete()
    {
        return false; // Returns false since eternal goals are never completed
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoint()}";
    }
}
