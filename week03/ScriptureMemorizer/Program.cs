
//This program includes an additional class called "ScriptureLibrary", which stores several scriptures and can display a random one to the user.
//I added a feature that allows the program to recognize both "quit" and "QUIT" as valid inputs. If the user types "y", they can continue playing and "n" to finish. All instructions are clearly displayed to the user.
using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        while (true)
        {
            Console.Clear();
            Scripture scripture = library.GetRandomScripture();

            PlayMemorizationGame(scripture);

            Console.WriteLine("\nWould you like to practice another scripture? (y/n):");
            string continueChoice = Console.ReadLine();
            continueChoice = continueChoice.ToLower();
            if (continueChoice == "n" || continueChoice == "no")
            {
                break;
            }
            
        }

        Console.WriteLine("Thank you for practicing scriptures!");

        static void PlayMemorizationGame(Scripture scripture)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords(3);

                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nCongratulations! All words are hidden. You've completed this scripture!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}