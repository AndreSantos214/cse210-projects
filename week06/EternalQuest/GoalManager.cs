using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class GoalManager
{
  private List<Goal> _goals;
  private int _score;
  private int _level;
  private int _pointsToNextLevel;
  private string[] _levelTitles = { "Beginner", "Adventure", "Hero", "Legend", "Eternal Champion" };

  public GoalManager()
  {
    _goals = new List<Goal>();
    _score = 0;
    _level = 1;
    _pointsToNextLevel = 1000;
  }

  public void Start()
  {
    bool quit = false;
    while (!quit)
    {
      Console.Clear();
      ShowPlayerPoints();
      ShowMenu();

      string choice = Console.ReadLine();

      if (choice == "1")
      {
        CreateGoal();
      }
      else if (choice == "2")
      {
        ListGoalDetails();
      }
      else if (choice == "3")
      {
        SaveGoals();
      }
      else if (choice == "4")
      {
        LoadGoals();
      }
      else if (choice == "5")
      {
        RecordEvent();
      }
      else if (choice == "6")
      {
        quit = true;
      }
      else
      {
        Console.WriteLine("Invalid choice. Press Enter to continue.");
        Console.ReadLine();
      }
    }
  }
  private void ShowPlayerPoints()
  {
    int index = _level - 1;

    if (index >= _levelTitles.Length)
    {
      index = _levelTitles.Length - 1;
    }

    string levelTitle = _levelTitles[index];
    Console.WriteLine("===================================");
    Console.WriteLine("            Eternal Quest          ");
    Console.WriteLine("===================================");
    Console.WriteLine($"\nPlayer Points: {_score}");
    Console.WriteLine($"Level: {_level} ({levelTitle})");
    Console.WriteLine();
  }

  private void CheckLevelUp()
  {
    while (_score >= _level * _pointsToNextLevel)
    {
      _level++;
      Console.WriteLine($"\nCongratulations! You leveled up to level {_level}!");
      int index = _level - 1;

      if (index >= _levelTitles.Length)
      {
        index = _levelTitles.Length - 1;
      }

      string levelTitle = _levelTitles[index];
      Console.WriteLine($"New Title: {levelTitle}");
      Console.WriteLine("You earned a bonus of 100 points!");
      _score += 100;
    }
  }

  private void ShowMenu()
  {
    Console.WriteLine();
    Console.WriteLine("Menu Options:");
    Console.WriteLine("1. Create New Goal");
    Console.WriteLine("2. List Goals");
    Console.WriteLine("3. Save Goals");
    Console.WriteLine("4. Load Goals");
    Console.WriteLine("5. Record Event");
    Console.WriteLine("6. Quit");
    Console.Write("Select a choice from the menu: ");
  }

  public void ListGoalDetails()
  {
    Console.Clear();
    ShowPlayerPoints();
    if (_goals.Count == 0)
    {
      Console.WriteLine("No Goals to display.");
    }
    else
    {
      int i = 1;
      foreach (Goal goal in _goals)
      {
        Console.WriteLine($"{i}. {goal.GetDetailString()}");
        i++;
      }
    }
    Console.WriteLine("\nPress Enter to return to the menu.");
    Console.ReadLine();
  }

  public void CreateGoal()
  {
    Console.Clear();
    ShowPlayerPoints();
    Console.WriteLine("The types of Goals are:");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.Write("\nWhich type of goal would you like to create? ");
    string type = Console.ReadLine();

    Console.Write("\nWhat is the name of your goal? ");
    string name = Console.ReadLine();
    Console.Write("\nWhat is a short description of it? ");
    string description = Console.ReadLine();
    Console.Write("\nWhat is the amount of points associated with this goal? ");
    int points = int.Parse(Console.ReadLine());

    if (type == "1")
    {
      SimpleGoal goal = new SimpleGoal(name, description, points);
      _goals.Add(goal);
    }

    else if (type == "2")
    {
      EternalGoal goal = new EternalGoal(name, description, points);
      _goals.Add(goal);
    }

    else if (type == "3")
    {
      Console.Write("\nEnter the target number of times to complete this goal: ");
      int target = int.Parse(Console.ReadLine());
      Console.Write("\nEnter the bonus points for completing the goal: ");
      int bonus = int.Parse(Console.ReadLine());
      CheckListGoal goal = new CheckListGoal(name, description, points, target, bonus);
      _goals.Add(goal);
    }
    else
    {
      Console.WriteLine("Invalid goal type.");
    }
    Console.WriteLine("\nGoal created! Press Enter to return to the menu.");
    Console.ReadLine();
  }

  public void RecordEvent()
  {
    Console.Clear();
    ShowPlayerPoints();
    if (_goals.Count == 0)
    {
      Console.WriteLine("No goals to record.");
      Console.WriteLine("\nPress Enter to return to the menu.");
      Console.ReadLine();
      return;
    }

    Console.WriteLine("Which goal did you accomplish?");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_goals[i].GetDetailString()}");
    }
    Console.Write("\nEnter the number: ");
    int num = int.Parse(Console.ReadLine());
    if (num < 1 || num > _goals.Count)
    {
      Console.WriteLine("Invalid goal number.");
      Console.WriteLine("\nPress Enter to return to the menu.");
      Console.ReadLine();
      return;
    }

    int points = _goals[num - 1].RecordEvent();

    _score += points;
    Console.WriteLine($"\nYou earned {points} points!");
    CheckLevelUp();
    Console.WriteLine($"\nPress Enter to return to the menu.");
    Console.ReadLine();
  }

  public void SaveGoals()
  {
    Console.Clear();
    ShowPlayerPoints();
    Console.Write("Enter the filename to save to: ");
    string filename = Console.ReadLine();

    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      outputFile.WriteLine(_score);
      outputFile.WriteLine(_level);
      foreach (Goal goal in _goals)
      {
        outputFile.WriteLine(goal.GetStringRepresentation());
      }
    }
    Console.WriteLine("Goals saved.");
    Console.WriteLine("\nPress Enter to return to the menu.");
    Console.ReadLine();
  }

  public void LoadGoals()
  {
    Console.Clear();
    ShowPlayerPoints();
    Console.Write("Enter the filename to load from: ");
    string filename = Console.ReadLine();

    if (!File.Exists(filename))
    {
      Console.WriteLine("File does not exist.");
      Console.WriteLine("\nPress Enter to return to the menu.");
      Console.ReadLine();
      return;
    }

    string[] lines = File.ReadAllLines(filename);
    _goals.Clear();
    _score = int.Parse(lines[0]);
    _level = int.Parse(lines[1]);

    for (int i = 2; i < lines.Length; i++)
    {
      string line = lines[i];
      string[] parts = line.Split(':');
      string type = parts[0];
      string[] details = parts[1].Split(',');

      if (type == "SimpleGoal")
      {
        string name = details[0];
        string description = details[1];
        int points = int.Parse(details[2]);
        bool IsComplete = bool.Parse(details[3]);
        SimpleGoal goal = new SimpleGoal(name, description, points);
        goal.SetComplete(IsComplete);
        _goals.Add(goal);
      }

      else if (type == "EternalGoal")
      {
        string name = details[0];
        string description = details[1];
        int points = int.Parse(details[2]);
        EternalGoal goal = new EternalGoal(name, description, points);
        _goals.Add(goal);
      }

      else if (type == "ChecklistGoal")
      {
        string name = details[0];
        string description = details[1];
        int points = int.Parse(details[2]);
        int amoutCompleted = int.Parse(details[3]);
        int target = int.Parse(details[4]);
        int bonus = int.Parse(details[5]);
        CheckListGoal goal = new CheckListGoal(name, description, points, target, bonus);

        for (int j = 0; j < amoutCompleted; j++)
        {
          goal.RecordEvent();
        }
        _goals.Add(goal);
      }
    }
    Console.WriteLine("Goals loaded.");
    Console.WriteLine("\nPress Enter to return to the menu.");
    Console.ReadLine();
  }
}