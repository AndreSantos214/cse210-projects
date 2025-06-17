//I Added a new "Gratitude Activity" to the program. This feature guides the user to list things they are grateful for. The Main Menu and logic were updated to include this feature.
//I Improved the breathing animation

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start Breathing Activity");
            Console.WriteLine(" 2. Start Reflecting Activity");
            Console.WriteLine(" 3. Start Listing Activity");
            Console.WriteLine(" 4. Start Gratitude Activity");
            Console.WriteLine(" 5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                GratitudeActivity gratitude = new GratitudeActivity();
                gratitude.Run();
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nGoodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}