using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor used when creating new goals (default incomplete)
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor used when loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override bool IsComplete => _isComplete;

    public override int RecordEvent()
    {
        if (_isComplete) return 0; // already completed, no further points

        // Mark complete and return points
        _isComplete = true;
        return Points;
    }

    public override string GetStatusString()
    {
        string mark = _isComplete ? "[X]" : "[ ]";
        return $"{mark} {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: Simple:name,desc,points,isComplete
        return $"Simple:{Name},{Description},{Points},{_isComplete}";
    }
}
