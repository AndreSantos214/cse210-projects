using System;
using System.Collections.Generic;

public class Scripture
{
  private Reference _reference;
  private List<Word> _words;

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    _words = new List<Word>();
    char[] separator = new[] { ' ' };
    string[] separateWords = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

    foreach (string word in separateWords)
    {
      Word newWord = new Word(word);
      _words.Add(newWord);
    }
  }

  public void HideRandomWords(int numberToHide)
  {
    Random random = new Random();
    List<Word> visibleWords = new List<Word>();

    foreach (Word word in _words)
    {
      if (word.IsHidden())
      {

      }

      else
      {
        visibleWords.Add(word);
      }
    }

    int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

    for (int i = 0; i < wordsToHide; i++)
    {
      int randomIndex = random.Next(visibleWords.Count);
      visibleWords[randomIndex].Hide();
      visibleWords.RemoveAt(randomIndex);
    }
  }

  public string GetDisplayText()
  {
    List<string> wordList = new List<string>();

    foreach (Word word in _words)
    {
      string wordText = word.GetDisplayText();
      wordList.Add(wordText);
    }

    string text = string.Join(" ", wordList);
    string reference = _reference.GetDisplayText();
    return $"{reference} {text}";
  }

  public bool IsCompletelyHidden()
  {
    foreach (Word word in _words)
    {
      if (!word.IsHidden())
      {
        return false;
      }
    }
    return true;
  }
}