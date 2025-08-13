public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private Dictionary<string, bool> _badges;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _badges = new Dictionary<string, bool>
        {
            {"First Step", false},
            {"Goal Getter", false},
            {"Eternal Champion", false},
            {"Checklist Master", false},
            {"Legendary", false}
        };
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].DisplayProgress();
        }
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int earned = _goals[choice].RecordEvent();
            _score += earned;
            
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
            Console.WriteLine($"You now have {_score} points.");
            
            CheckLevelUp();
            CheckBadges();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = _score / 1000 + 1;
        if (newLevel > _level)
        {
            Console.WriteLine($"LEVEL UP! You are now level {newLevel}!");
            _level = newLevel;
        }
    }

    private void CheckBadges()
    {
        if (!_badges["First Step"] && _score > 0)
        {
            _badges["First Step"] = true;
            Console.WriteLine("Badge Earned: First Step!");
        }
        
        if (!_badges["Goal Getter"] && _goals.Count(g => g.IsComplete) >= 3)
        {
            _badges["Goal Getter"] = true;
            Console.WriteLine("Badge Earned: Goal Getter!");
        }
        
        if (!_badges["Eternal Champion"] && _goals.OfType<EternalGoal>().Any(g => g.Points * 5 <= _score))
        {
            _badges["Eternal Champion"] = true;
            Console.WriteLine("Badge Earned: Eternal Champion!");
        }
        
        if (!_badges["Checklist Master"] && _goals.OfType<ChecklistGoal>().Count(g => g.IsComplete) >= 2)
        {
            _badges["Checklist Master"] = true;
            Console.WriteLine("Badge Earned: Checklist Master!");
        }
        
        if (!_badges["Legendary"] && _level >= 10)
        {
            _badges["Legendary"] = true;
            Console.WriteLine("Badge Earned: Legendary!");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].DisplayProgress();
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {_level}");
        Console.WriteLine("Badges Earned:");
        foreach (var badge in _badges.Where(b => b.Value))
        {
            Console.WriteLine($"- {badge.Key}");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");
            outputFile.WriteLine($"Level|{_level}");
            
            foreach (var badge in _badges)
            {
                outputFile.WriteLine($"Badge|{badge.Key}|{badge.Value}");
            }
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                
                switch (parts[0])
                {
                    case "Score":
                        _score = int.Parse(parts[1]);
                        break;
                    case "Level":
                        _level = int.Parse(parts[1]);
                        break;
                    case "Badge":
                        _badges[parts[1]] = bool.Parse(parts[2]);
                        break;
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), 
                            int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}