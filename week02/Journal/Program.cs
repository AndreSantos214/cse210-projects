// I added "mood" to each jounal entry to provide more personal reflection.
// I wrote something other than "write", "display", "load" and "save". This way, the user doesn't make mistakes while running the program.
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the jounal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");

                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Console.Write("How was your mood today? ");
                string mood = Console.ReadLine();

                Entry newEntry = new Entry(prompt, response, mood);
                journal.AddEntry(newEntry);

            }

            else if (choice == "2")
            {
                Console.WriteLine("\n--- Journal Entries ---");
                journal.DisplayAll();
            }

            else if (choice == "3")
            {
                Console.Write("Enter filename to load: ");
                string loadfile = Console.ReadLine();
                journal.LoadFromFile(loadfile);
                Console.WriteLine("\nJounal loaded!");
            }

            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");
                string saveFile = Console.ReadLine();
                journal.SaveToFile(saveFile);
                Console.WriteLine("Journal saved");
            }

            else if (choice == "5")
            {
                running = false;
            }

            else
            {
                Console.WriteLine("Inavlid option. Try again.");
            }
        }
    }
}