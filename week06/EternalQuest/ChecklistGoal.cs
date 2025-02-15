public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
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
            int totalPoints = _points;
            if (_amountCompleted == _target)
            {
                totalPoints += _bonus;
            }
        }
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        int totalPoints = _points;
        if (_amountCompleted == _target)
        {
            totalPoints += _bonus;
            Console.WriteLine($"Bonus! You earned an extra {_bonus} points!");
        }
        Console.WriteLine($"You earned {totalPoints} points!");
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName}: ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}