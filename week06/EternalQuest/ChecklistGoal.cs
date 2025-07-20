using System;

public class ChecklistGoals : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoals(string name, string description, int points, int target, int bonus, int amountCompleted = 0): base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        int earned = GetPoints();

        if (_amountCompleted == _target)
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status;
        if (IsComplete())
        {
            status = "[X]";
        }
        else
        {
            status = "[ ]";
        }

        return $"{status} {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoals:{GetName()},{GetDescription()},{GetPoints()},{_target},{_bonus},{_amountCompleted}";
    }
}