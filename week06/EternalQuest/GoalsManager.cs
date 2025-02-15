public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points");
            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("\t1. Create Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Record Event");
            Console.WriteLine("\t4. Save Goals");
            Console.WriteLine("\t5. Load Goals");
            Console.WriteLine("\t6. Exit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": 
                    Logger.Log("Program ended! Byee"); 
                    Console.ResetColor();
                    return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("\t1. Simple Goal");
        Console.WriteLine("\t2. Eternal Goal");
        Console.WriteLine("\t3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Logger.Log($"Created SimpleGoal: {name}");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Logger.Log($"Created SimpleGoal: {name}");
                break;
            case "3":
                Console.Write("Enter target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Logger.Log($"Created ChecklistGoal: {name}");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.Write("Enter choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            _score += _goals[choice].GetPoint();
            _goals[choice].RecordEvent();
            Logger.Log($"Recorded event for goal: {_goals[choice].GetName()}, Points Earned: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("\nEnter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Logger.Log($"Goals saved to file: {filename}");
        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        Console.Write("\nEnter filename to load goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            _score = int.Parse(reader.ReadLine());

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);

                    if (isComplete)
                    {
                        simpleGoal.SetComplete(isComplete);
                    }

                    _goals.Add(simpleGoal);
                }
                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    _goals.Add(eternalGoal);
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int amountCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);

                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);

                    for (int i = 0; i < amountCompleted; i++)
                    {
                        checklistGoal.SetComplete(amountCompleted >= target);
                    }

                    _goals.Add(checklistGoal);
                }
            }
        }
        Logger.Log($"Goals loaded successfully from file: {filename}");
        Console.WriteLine("Goals loaded successfully!");
    }

}