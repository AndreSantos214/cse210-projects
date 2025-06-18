using System;

class CheckListGoal : Goal
{
  private int _amountCompleted;
  private int _target;
  private int _bonus;

  public CheckListGoal(string shortName, string description, int points, int target, int bonus) : base(shortName, description, points)
  {
    _amountCompleted = 0;
    _target = target;
    _bonus = bonus;
  }

  public override int RecordEvent()
  {
    if (_amountCompleted < _target)
    {
      _amountCompleted++;
      if (_amountCompleted == _target)
      {
        return _points + _bonus;
      }
      else
      {
        return _points;
      }
    }
    else
    {
      Console.WriteLine("This checklist goal is already complete.");
      return 0;
    }
  }

  public override bool IsComplete()
  {
    return _amountCompleted >= _target;
  }

  public override string GetDetailString()
  {
    string checkbox = IsComplete() ? "[X]" : "[ ]";
    return $"{checkbox} {_shortName} ({_description}) -- Completed: {_amountCompleted}/{_target}";
  }

  public override string GetStringRepresentation()
  {
    return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
  }
}