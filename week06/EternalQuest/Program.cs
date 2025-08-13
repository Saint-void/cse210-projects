class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.CreateGoal();
                    break;
                case 2:
                    manager.RecordEvent();
                    break;
                case 3:
                    manager.DisplayGoals();
                    break;
                case 4:
                    manager.DisplayScore();
                    break;
                case 5:
                    manager.SaveGoals();
                    break;
                case 6:
                    manager.LoadGoals();
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

/*
CREATIVE ADDITIONS TO EXCEED REQUIREMENTS:

1. Level System:
   - Users level up every 1000 points
   - Visual feedback when leveling up
   - Current level displayed with score

2. Badge Achievement System:
   - "First Step" badge for earning first points
   - "Goal Getter" for completing 3 goals
   - "Eternal Champion" for consistent eternal goals
   - "Checklist Master" for completing checklist goals
   - "Legendary" badge for reaching level 10
   - Badges are displayed with the score

3. Enhanced Progress Tracking:
   - Checklist goals show current/target count
   - Eternal goals have special [∞] indicator
   - Visual [X] or [ ] indicators for completion status

4. Improved User Experience:
   - Clear menu system
   - Detailed feedback when recording events
   - Comprehensive goal display showing all details
*/