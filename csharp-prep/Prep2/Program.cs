using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");

        int percentage = int.Parse(Console.ReadLine());
        string letter = "";

        if (percentage >= 90) 
        {
            letter = "A";
        }

        else if(percentage >= 80) 
        {
            letter = "B";
        }

          else if(percentage >= 70) 
        {
            letter = "C";
        }

        else if(percentage >= 60) 
        {
            letter = "D";
        }

        else 
        {
         letter = "F";   
        }

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }

        else 
        {
            Console.WriteLine("Unfortunately, you didn't pass. Keep trying and you succeed next time!");
        }

        Console.WriteLine($"Your grade is '{letter}'.");
    }
}