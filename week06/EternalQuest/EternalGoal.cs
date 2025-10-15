using System;

public class EternalGoal : Goal
{
    // Eternal goals are never "complete" but always award points
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    { }

    public override bool IsComplete => false;

    public override int RecordEvent()
    {
        // Always award the configured points
        return Points;
    }

    public override string GetStatusString()
    {
        // Use [~] to indicate ongoing/eternal
        return $"[~] {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: Eternal:name,desc,points
        return $"Eternal:{Name},{Description},{Points}";
    }
}
