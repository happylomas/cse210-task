using System;

public abstract class Goal
{
    // Encapsulated member variables
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Protected getters for derived classes
    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    // Whether this goal is complete (some derived classes may always be false)
    public abstract bool IsComplete { get; }

    // Called when the user records progress on the goal.
    // Returns the number of points awarded by this event.
    public abstract int RecordEvent();

    // Human readable short status (e.g., "[X] Read scriptures")
    public abstract string GetStatusString();

    // Returns a string that fully describes the object for saving to a file.
    // Format: <Type>:<field1>,<field2>,...
    public abstract string GetStringRepresentation();

    // Factory to re-create Goals from saved strings
    public static Goal CreateFromString(string line)
    {
        // Expecting Type:data1,data2,...
        // Example: Simple:name,desc,points,isComplete
        if (string.IsNullOrWhiteSpace(line)) return null;

        var parts = line.Split(new char[] { ':' }, 2);
        if (parts.Length < 2) return null;

        string type = parts[0];
        string data = parts[1];

        string[] fields = data.Split(',');

        switch (type)
        {
            case "Simple":
                // Simple:name,desc,points,isComplete
                return new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]), bool.Parse(fields[3]));
            case "Eternal":
                // Eternal:name,desc,points
                return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));
            case "Checklist":
                // Checklist:name,desc,points,requiredCount,currentCount,bonus
                return new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));
            default:
                return null;
        }
    }
}
