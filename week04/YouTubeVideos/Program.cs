using System;
using System.Collections.Generic;

//I didn't really learn anything new while making this program,
//so that is why I don't have any comments.
//I know I should have comments in a more professional code to avoid confusion,
//but this is a simple enough code that I didn't really bother
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Funniest Cat Videos of 2025", "Catloverdude", 600);
        video1.AddComment(new Comment("Tom", "Great Videos"));
        video1.AddComment(new Comment("Jerry", "Terrible Videos"));
        video1.AddComment(new Comment("Norris", "That snake scared me"));
        videos.Add(video1);

        Video video2 = new Video("Why you should start fishing now!", "TheBackyardFisherman", 480);
        video2.AddComment(new Comment("Tuna", "I'm still not convinced"));
        video2.AddComment(new Comment("Mahi", "I prefer to use worms"));
        video2.AddComment(new Comment("BlueGill", "Why only saltwater?"));
        videos.Add(video2);

        Video video3 = new Video("Why The Sith are Superior", "DarthJarJar", 3600);
        video3.AddComment(new Comment("Anakin", "I couldn't agree more"));
        video3.AddComment(new Comment("luke", "Nah, I'll pass"));
        video3.AddComment(new Comment("yoda", "So long the video did not have to be hmmmmm"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine();

            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine();

            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine();

            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}