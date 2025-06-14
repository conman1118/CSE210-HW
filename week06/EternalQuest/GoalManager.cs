public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void MainMenu()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nCurrent Score: {_score}");
            Console.WriteLine("Menu:\n1. Create Goal\n2. List Goals\n3. Record Event\n4. Save Goals\n5. Load Goals\n6. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        Console.Write("Choose type: ");
        string type = Console.ReadLine();
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, points));
        else if (type == "2")
            _goals.Add(new EternalGoal(name, points));
        else if (type == "3")
        {
            Console.Write("Enter target count: ");
            int count = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, points, count, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        int earned = _goals[index].RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points!");
    }

    private void SaveGoals()
    {
        Console.Write("Filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
                writer.WriteLine(goal.Serialize());
        }
        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("Filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                if (type == "SimpleGoal")
                    _goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])) { });
                else if (type == "EternalGoal")
                    _goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                else if (type == "ChecklistGoal")
                    _goals.Add(new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[5]))
                    {
                        // loading existing state
                    });
            }
            Console.WriteLine("Goals loaded.");
        }
        else Console.WriteLine("File not found.");
    }
}
