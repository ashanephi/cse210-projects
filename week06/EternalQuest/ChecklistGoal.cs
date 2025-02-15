public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public void SetComplete(bool isComplete)
    {
        if (isComplete)
        {
            _amountCompleted++;
            int totalPoints = GetPoint();
            if (_amountCompleted == _target)
            {
                totalPoints += _bonus;
                AddXP(50); // This rewards XP for full completion
            }
        }
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        int totalPoints = GetPoint();
        AddXP(10); // XP for each checklist item
        if (_amountCompleted == _target)
        {
            totalPoints += _bonus;
            Console.WriteLine($"Bonus! You earned an extra {_bonus} points!");
            ShowMotivationalQuote();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You earned {totalPoints} points!");
        Console.ResetColor();
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()}: ({GetDescription()}) -- Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoint()}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
