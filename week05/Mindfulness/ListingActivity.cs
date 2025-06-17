using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
  private List<string> _prompts;
  private int _count;

  public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
  {
    _prompts = new List<string>
    {
      "Who are people that you appreciate?",
      "What are personal strengths of yours?",
      "Who are people that you have helped this week?",
      "When have you felt the Holy Ghost this month?",
      "Who are some of your personal heroes?"
    };
    _count = 0;
  }

  private string GetRandomPrompt()
  {
    Random rand = new Random();
    int index = rand.Next(_prompts.Count);
    return _prompts[index];
  }

  private List<string> GetListFromUser()
  {
    List<string> responses = new List<string>();
    DateTime end = DateTime.Now.AddSeconds(_duration);
    while (DateTime.Now < end)
    {
      Console.Write("> ");
      string response = Console.ReadLine();
      if (response != null && response != "" && response.Trim() != "")
      {
        responses.Add(response);
      }
    }
    return responses;
  }

  public void Run()
  {
    DisplayStartingMessage();
    Console.WriteLine("List as many responses as you can to the following prompt:");
    Console.WriteLine();
    Console.WriteLine($"--- {GetRandomPrompt()} ---");
    Console.WriteLine();
    Console.Write("You may begin in: ");
    ShowCountDown(5);
    Console.WriteLine();

    List<string> items = GetListFromUser();
    _count = items.Count;

    Console.WriteLine();
    Console.WriteLine($"You listed {_count} items!");
    DisplayEndingMessage();
  }
}