public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private int _xp = 0;
    private const int XP_THRESHOLD = 100; // XP needed to level up
    public void Start()
    {
        
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points");
            Console.WriteLine($"Level: {_level} | XP: {_xp}/{_level * XP_THRESHOLD}");
            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("\t1. Create Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Record Event");
            Console.WriteLine("\t4. Save Goals");
            Console.WriteLine("\t5. Load Goals");
            Console.WriteLine("\t6. Edit Goal");
            Console.WriteLine("\t7. Delete Goal");
            Console.WriteLine("\t8. Exit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": EditGoal(); break;
                case "7": DeleteGoal(); break;
                case "8": 
                    Logger.Log("Program ended! Byee"); 
                    Console.ResetColor();
                    return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        int index = 0;
        foreach (Goal goal in _goals)
        {
            index++;
            Console.WriteLine($"{index}. {goal.GetDetailsString()}");
        }
    }

    public void CreateGoal()
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
        string points = Console.ReadLine();

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

    public void RecordEvent()
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
            _xp += 20;
            CheckLevelUp();
            Logger.Log($"Recorded event for goal: {_goals[choice].GetName()}, Points Earned: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("\nEnter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(_xp);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Logger.Log($"Goals saved to file: {filename}");
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
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
            _score = int.TryParse(reader.ReadLine(), out int parsedScore) ? parsedScore : 0;
            _level = int.TryParse(reader.ReadLine(), out int parsedLevel) ? parsedLevel : 1;
            _xp = int.TryParse(reader.ReadLine(), out int parsedXP) ? parsedXP : 0;

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
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
                    string points = parts[3];

                    EternalGoal eternalGoal = new EternalGoal(name, description, points);
                    _goals.Add(eternalGoal);
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    string points = parts[3];
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

    public void EditGoal()
    {
        ListGoalDetails();
        Console.Write("Select a goal to edit: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new description: ");
            string newDescription = Console.ReadLine();
            _goals[choice].SetName(newName);
            _goals[choice].SetDescription(newDescription);
            Logger.Log($"Edited goal: {_goals[choice].GetName()}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void DeleteGoal()
    {
        ListGoalDetails();
        Console.Write("Select a goal to delete: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            _goals.RemoveAt(choice);
            Logger.Log("Goal deleted.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void CheckLevelUp()
    {
        if (_xp >= _level * 100)
        {
            _level++;
            _xp = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🎉 Level Up! You are now Level {_level}!");
            Console.ResetColor();
            Logger.Log($"Leveled up to Level {_level}");
        }
    }

}