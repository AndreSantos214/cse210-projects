using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
  private List<Entry> _entries = new List<Entry>();
  public void AddEntry(Entry newEntry)
  {
    _entries.Add(newEntry);
  }

  public void DisplayAll()
  {
    foreach (Entry entry in _entries)
    {
      Console.WriteLine(entry.Display());
    }
  }

  public void SaveToFile(string file)
  {
    using (StreamWriter outputFile = new StreamWriter(file))
    {
      foreach (Entry entry in _entries)
      {
        outputFile.WriteLine(entry.ToFileFormat());
      }
    }
  }

  public void LoadFromFile(string file)
  {
    if (File.Exists(file))
    {
      _entries.Clear();
      string[] lines = File.ReadAllLines(file);
      foreach (string line in lines)
      {
        Entry entry = Entry.FromFileFormat(line);
        if (entry != null)
        {
          _entries.Add(entry);
        }
      }
    }
    else
    {
      Console.WriteLine("Arquivo não encontrado");
    }
  }
}