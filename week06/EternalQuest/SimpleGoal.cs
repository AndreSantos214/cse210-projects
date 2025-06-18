using System;

class SimpleGoal : Goal
{
  private bool _isComplete;

  public SimpleGoal(string shortName, string description, int points) : base(shortName, description, points)
  {
    _isComplete = false;
  }

  public override int RecordEvent()
  {
    if (!_isComplete)
    {
      _isComplete = true;
      return _points;
    }
    else
    {
      Console.WriteLine("This goal is already complete.");
      return 0;
    }
  }
  public override bool IsComplete()
  {
    return _isComplete;
  }

  public void SetComplete(bool value)
  {
    _isComplete = value;
  }

  public override string GetStringRepresentation()
  {
    return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
  }
}