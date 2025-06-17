using System;
public class BreathingActivity : Activity
{
  public BreathingActivity()
    : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your ")
  {
  }

  private void ShowBreathingAnimation(string action, int duration)
  {
    int steps = 20;
    int totalMilliseconds = duration * 1000;
    int sleepPerStep = totalMilliseconds / steps;

    for (int i = 1; i <= steps; i++)
    {
      double progress = (double)i / steps;
      int width = (int)(progress * 20);
      Console.Write("\r" + action + new string('.', width));
      Thread.Sleep(sleepPerStep);
    }
    Console.WriteLine();
  }

  public void Run()
  {
    DisplayStartingMessage();
    DateTime end = DateTime.Now.AddSeconds(_duration);
    while (DateTime.Now < end)
    {
      ShowBreathingAnimation("Breathe in", 4);
      ShowBreathingAnimation("Now breathe out", 6);
      Console.WriteLine();
    }
    DisplayEndingMessage();
  }
}