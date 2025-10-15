using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Add a goal
    public void AddGoal(Goal g)
    {
        if (g != null) _goals.Add(g);
    }

    // List goals with indices
    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
        }
    }

    // Record an event for a selected goal index (1-based)
    public void RecordEvent(int index)
    {
        if (index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var goal = _goals[index - 1];
        int awarded = goal.RecordEvent();
        _score += awarded;

        if (awarded > 0)
            Console.WriteLine($"You earned {awarded} points!");
        else
            Console.WriteLine("No points awarded (goal may already be complete).");
    }

    // Display current score
    public void ShowScore()
    {
        Console.WriteLine($"Current score: {_score}");
    }

    // Save to file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // First line: score
            writer.WriteLine(_score);

            foreach (var g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved to {filename}");
    }

    // Load from file (replaces current goals & score)
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        // First line should be score
        if (!int.TryParse(lines[0], out int loadedScore))
        {
            Console.WriteLine("Invalid file format (score).");
            return;
        }

        _score = loadedScore;
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            var g = Goal.CreateFromString(lines[i]);
            if (g != null) _goals.Add(g);
        }

        Console.WriteLine($"Loaded {_goals.Count} goals and score {_score} from {filename}");
    }
}
