using System;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private int _level;

    public GoalManager()
    {
        _score = 0;
        _level = 1;
    }

    //I decided to use less methods than were in the original design
    //I organized it a little differently, but it works the same

    //The main loop (I included the point count and level count in this)
    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"You are at level {_level}.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
                CreateGoal();

            else if (choice == "2")
                ListGoalDetails();

            else if (choice == "3")
                SaveGoals();

            else if (choice == "4")
                LoadGoals();

            else if (choice == "5")
                RecordEvent();

            else if (choice != "6")
                Console.WriteLine("Please select a number 1-6");
        }

    }

    //This is my stretch(its a level system, so whenever you get 1000 points you will level up)
    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You reached level {_level}!");
        }
    }

    //prints out all of the stored goals
    public void ListGoalDetails()
    {
        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    //creates a new goal object and adds it to the _goals list
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoals(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Please create a goal (only numbers 1-3 work)");
        }
    }

    //lets you pick one of the goals and then awards the proper points, it also checks for a level up
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        Goal selected = _goals[choice - 1];
        int earned = selected.RecordEvent();

        if (earned > 0)
        {
            _score += earned;
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
            UpdateLevel();
        }
    }

    //this asks for a txt file to save to, then it saves the current progress to the txt
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    //asks for and reads the saved goals file then it parses the lines back to the proper subclass
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = int.Parse(lines[0]);
        _level = (_score / 1000) + 1;

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] fields = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                bool done = bool.Parse(fields[3]);
                _goals.Add(new SimpleGoal(name, description, points, done));
            }
            else if (type == "EternalGoal")
            {
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoals")
            {
                string name = fields[0];
                string description = fields[1];
                int points = int.Parse(fields[2]);
                int target = int.Parse(fields[3]);
                int bonus = int.Parse(fields[4]);
                int count = int.Parse(fields[5]);
                _goals.Add(new ChecklistGoals(name, description, points, target, bonus, count));
            }
        }
    }
}