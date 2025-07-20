using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false): base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isComplete}";
    }

        public override string GetDetailsString()
    {
        string status;
        if (_isComplete)
        {
            status = "[X]";
        }
        else
        {
            status = "[ ]";
        }

        return $"{status} {GetName()} ({GetDescription()})";
    }
}