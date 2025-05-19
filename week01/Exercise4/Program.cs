using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number;
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        do
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        if (numbers.Count > 0)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            float average = (float)sum / numbers.Count;

            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine($"\nThe sum is: {sum}");
            Console.WriteLine($"The avarage is: {average}");
            Console.WriteLine($"The slargest number is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}