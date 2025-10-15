using System;

public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    // New goal constructor
    public ChecklistGoal(string name, string description, int pointsPerEvent, int requiredCount, int currentCount = 0, int bonusPoints = 0)
        : base(name, description, pointsPerEvent)
    {
        _requiredCount = requiredCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }

    public override bool IsComplete => _currentCount >= _requiredCount;

    public override int RecordEvent()
    {
        if (IsComplete) return 0; // Already finished

        _currentCount++;
        int award = Points;

        if (_currentCount >= _requiredCount)
        {
            // Award the bonus when the required count is reached
            award += _bonusPoints;
        }

        return award;
    }

    public override string GetStatusString()
    {
        string mark = IsComplete ? "[X]" : "[ ]";
        return $"{mark} {Name} ({Description}) -- Completed {_currentCount}/{_requiredCount}";
    }

    public override string GetStringRepresentation()
    {
        // Format: Checklist:name,desc,points,requiredCount,currentCount,bonus
        return $"Checklist:{Name},{Description},{Points},{_requiredCount},{_currentCount},{_bonusPoints}";
    }
}
