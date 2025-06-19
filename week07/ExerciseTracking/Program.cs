using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle = new Cycling("03 Nov 2022", 30, 6.0);
        Swimming swim = new Swimming("03 Nov 2022", 30, 20);

        List<Activity> activities = new List<Activity>();
        activities.Add(run);
        activities.Add(cycle);
        activities.Add(swim);

        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine(activities[i].GetSummary());
        }
    }
}