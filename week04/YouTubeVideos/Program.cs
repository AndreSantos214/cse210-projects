using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>();

        Video firstVideo = new Video("How to Program in C#", "Andre Santos", 600);
        firstVideo.AddComment(new Comment("Mary", "Great Tutorial"));
        firstVideo.AddComment(new Comment("Peter", "Very helpful, thanks!"));
        firstVideo.AddComment(new Comment("Anna", "Clear and simple explanation"));

        Video secondVideo = new Video("Chocolate Cake Recipe", "Chef Andre Santos", 480);
        secondVideo.AddComment(new Comment("Charles", "Ot turned out delicious!"));
        secondVideo.AddComment(new Comment("Lucy", "I'm going to make it today"));
        secondVideo.AddComment(new Comment("Robert", "Easy to find ingredients"));
        secondVideo.AddComment(new Comment("Fernanda", "My family loved it"));

        Video thirdVideo = new Video("Home Workout Tips", "Andre Santos", 720);
        thirdVideo.AddComment(new Comment("Bruno", "Practical exercises"));
        thirdVideo.AddComment(new Comment("Carla", "Perfect for beginners"));
        thirdVideo.AddComment(new Comment("Diego", "I'll start tomorrow"));

        videoList.Add(firstVideo);
        videoList.Add(secondVideo);
        videoList.Add(thirdVideo);

        foreach (Video video in videoList)
        {
            Console.WriteLine($"\nTitle: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Duration: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine($"Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetName()} : {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}