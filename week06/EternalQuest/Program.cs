//I changed some words in the menu to make it clearer for the user. I also created a 'Level Up' function for every 1000 points, and added some fun titles that change when the user levels up. 
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}