using System;

class Running : Activity
{
  private double _distance;

  public Running(string date, int minutes, double distance) : base(date, minutes)
  {
    _distance = distance;
  }

  public override double GetDistance()
  {
    return _distance;
  }

  public override double GetSpeed()
  {
    return _distance / GetMinutes() * 60;
  }

  public override double GetPace()
  {
    return GetMinutes() / _distance;
  }

  public override string GetSummary()
  {
    return $"{GetDate()} Running ({GetMinutes()} min) - Distance: {_distance.ToString("0.0")} miles, Speed: {GetSpeed().ToString("0.0")} mph, Pace: {GetPace().ToString("0.0")} min per mile";
  }
}