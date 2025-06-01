using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
  private List<Scripture> _scriptures;
  private Random _random;

  public ScriptureLibrary()
  {
    _scriptures = new List<Scripture>();
    _random = new Random();
    LoadScriptures();
  }

  private void LoadScriptures()
  {
    _scriptures.Add(new Scripture(
      new Reference("Proverbs", 3, 5, 6),
      "Trust in the Lord with all thine heart and lean not unto thine own understanding."));

    _scriptures.Add(new Scripture(
      new Reference("John", 3, 16),
      "For God so loved the world, that he gave his oly begotten son."));

    _scriptures.Add(new Scripture(
      new Reference("Moses", 1, 39),
      "This is my work and my glory, to bring to pass the immortality and eternal life of man."));

    _scriptures.Add(new Scripture(
      new Reference("1 Nephi", 3, 7),
      "I will go and do the things which the Lord hath commanded."));

    _scriptures.Add(new Scripture(
      new Reference("Doctrine and Covenats", 18, 10, 11),
      "The worth of souls is great in the sight of God."));
  }

  public Scripture GetRandomScripture()
  {
    int randomIndex = _random.Next(_scriptures.Count);
    return _scriptures[randomIndex];
  }


}