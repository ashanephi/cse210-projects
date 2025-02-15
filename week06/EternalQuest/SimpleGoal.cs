public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        AddXP(30); // XP for completing a Simple Goal
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You earned {GetPoint()} points!");
        Console.ResetColor();
        Console.WriteLine("\n*** Congratulations! Simple Goal Completed! ***");
        ShowMotivationalQuote();
    }

    public void SetComplete(bool isComplete)
    {
        if(isComplete)
        {
            _isComplete = true;
        }
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoint()}|{_isComplete}";
    }
}
