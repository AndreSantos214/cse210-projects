using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
  public GratitudeActivity() : base("Gratitude", "This activity helps you focus on positive aspects of your life by listing things you are grateful for. Take a moment to appreciate the good things, big or small.")
  {
  }

  public void Run()
  {
    DisplayStartingMessage();
    Console.WriteLine("List as many things as you are grateful for:");
    Console.WriteLine();
    Console.Write("You may begin in: ");
    ShowCountDown(5);
    Console.WriteLine();

    List<string> gratitudes = new List<string>();
    DateTime end = DateTime.Now.AddSeconds(_duration);
    while (DateTime.Now < end)
    {
      Console.Write("> ");
      string response = Console.ReadLine();

      if (response != null && response != "" && response.Trim() != "")
      {
        gratitudes.Add(response);
      }
    }
    Console.WriteLine();
    Console.WriteLine($"You listed {gratitudes.Count} things you are grateful for!");
    DisplayEndingMessage();
  }
}