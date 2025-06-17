using System;
using System.Threading;

public abstract class Activity
{
  protected string _name;
  protected string _description;
  protected int _duration;

  public Activity(string name, string description)
  {
    _name = name;
    _description = description;
  }

  public void DisplayStartingMessage()
  {
    Console.Clear();
    Console.WriteLine($"Welcome to the {_name} Activity!");
    Console.WriteLine();
    Console.WriteLine(_description);
    Console.WriteLine();
    Console.Write("How long, in second, would you like for your session? ");
    string input = Console.ReadLine();
    int seconds = 0;
    bool IsValidNumber = false;

    for (int i = 0; i < input.Length; i++)
    {
      if (input[i] < '0' || input[i] > '9')
      {
        IsValidNumber = false;
        break;
      }
      else
      {
        IsValidNumber = true;
      }
    }
    if (IsValidNumber)
    {
      seconds = Convert.ToInt32(input);
      _duration = seconds;
    }
    else
    {
      Console.WriteLine("Invalid input. Using default value of 30 seconds.");
      _duration = 30;
    }
    Console.WriteLine("\nGet ready...");
    ShowSpinner(3);
    Console.WriteLine();
    Console.WriteLine();
  }

  public void DisplayEndingMessage()
  {
    Console.WriteLine();
    Console.WriteLine("Well done!");
    ShowSpinner(3);
    Console.WriteLine();
    Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
    ShowSpinner(5);
  }

  protected void ShowSpinner(int seconds)
  {
    string[] spinner = { "|", "/", "-", "\\" };
    DateTime end = DateTime.Now.AddSeconds(seconds);
    int i = 0;
    while (DateTime.Now < end)
    {
      Console.Write(spinner[i]);
      Thread.Sleep(250);
      Console.Write("\b \b");

      i++;

      if (i == spinner.Length)
      {
        i = 0;
      }
    }
  }

  protected void ShowCountDown(int seconds)
  {
    for (int i = seconds; i > 0; i--)
    {
      Console.Write(i);
      Thread.Sleep(1000);
      Console.Write("\b \b");
    }
  }
}