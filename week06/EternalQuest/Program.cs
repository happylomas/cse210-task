using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        Console.WriteLine("");

        GoalManager manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event (complete a goal)");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    Pause();
                    break;
                case "3":
                    manager.ListGoals();
                    Console.Write("\nSelect goal number to record an event: ");
                    if (int.TryParse(Console.ReadLine(), out int idx))
                    {
                        manager.RecordEvent(idx);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    Pause();
                    break;
                case "4":
                    manager.ShowScore();
                    Pause();
                    break;
                case "5":
                    Console.Write("Enter filename to save (e.g., save.txt): ");
                    string saveFile = Console.ReadLine();
                    manager.SaveToFile(saveFile);
                    Pause();
                    break;
                case "6":
                    Console.Write("Enter filename to load (e.g., save.txt): ");
                    string loadFile = Console.ReadLine();
                    manager.LoadFromFile(loadFile);
                    Pause();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple Goal (one-time)");
        Console.WriteLine("2. Eternal Goal (repeatable)");
        Console.WriteLine("3. Checklist Goal (complete N times)");
        Console.Write("Selection: ");
        string t = Console.ReadLine();

        Console.Write("Enter name/title: ");
        string name = Console.ReadLine();
        Console.Write("Enter short description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points awarded per event: ");
        int points = int.TryParse(Console.ReadLine(), out int pVal) ? pVal : 0;

        switch (t)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                Console.WriteLine("Simple goal created.");
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                Console.WriteLine("Eternal goal created.");
                break;
            case "3":
                Console.Write("Enter required completions (N): ");
                int required = int.TryParse(Console.ReadLine(), out int rVal) ? rVal : 1;
                Console.Write("Enter bonus points for completion: ");
                int bonus = int.TryParse(Console.ReadLine(), out int bVal) ? bVal : 0;
                manager.AddGoal(new ChecklistGoal(name, desc, points, required, 0, bonus));
                Console.WriteLine("Checklist goal created.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
