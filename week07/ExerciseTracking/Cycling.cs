using System;

class Cycling : Activity
{
  private double _speed;
  public Cycling(string date, int minutes, double speed) : base(date, minutes)
  {
    _speed = speed;
  }

  public override double GetSpeed()
  {
    return _speed;
  }

  public override double GetDistance()
  {
    return _speed * GetMinutes() / 60.0;
  }

  public override double GetPace()
  {
    return 60.0 / _speed;
  }

  public override string GetSummary()
  {
    return $"{GetDate()} Cycling ({GetMinutes()} min) - Distance: {GetDistance().ToString("0.0")} miles, Speed: {_speed.ToString("0.0")} mph, Pace {GetPace().ToString("0.0")} min per mile";
  }
}