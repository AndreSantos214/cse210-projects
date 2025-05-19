using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeString = Console.ReadLine();
        int gradeInt = int.Parse(gradeString);
        string letter = "";

        if (gradeInt >= 90)
        {
            letter = "A";
        }
        else if (gradeInt >= 80)
        {
            letter = "B";
        }
        else if (gradeInt >= 70)
        {
            letter = "C";
        }
        else if (gradeInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is {letter}.");
        if (gradeInt >= 70)
        {
            Console.WriteLine("Congratulations. You have been approved.");
        }
        else
        {
            Console.WriteLine("I'm sorry you didn't get approved. You can try again next semester, but remember that effort brings rewards.");
        }
    }
}