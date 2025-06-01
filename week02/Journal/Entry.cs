using System;

public class Entry
{
  private string _date;
  private string _promptText;
  private string _entryText;
  private string _mood;

  public Entry(string promptText, string entryText, string mood)
  {
    _date = DateTime.Now.ToString("yyyy-MM-dd");
    _promptText = promptText;
    _entryText = entryText;
    _mood = mood;
  }

  public string Display()
  {
    return $"Date: {_date} \n Prompt: {_promptText} \n Entry: {_entryText} \n Mood: {_mood} \n -------------------------";
  }

  public string ToFileFormat()
  {
    return $"{_date}|{_promptText}|{_entryText}|{_mood}";
  }

  public static Entry FromFileFormat(string line)
  {
    string[] parts = line.Split('|');
    if (parts.Length >= 4)
    {
      Entry entry = new Entry(parts[1], parts[2], parts[3]);
      entry._date = parts[0];
      return entry;
    }

    else
    {
      return null;
    }
    
  }
}