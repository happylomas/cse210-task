using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Console.WriteLine("");

        List<Video> videos = new List<Video>();

        Video v1 = new Video("How to Become Rice as a Programmer", "Prince", 420);
        v1.AddComment(new Comment("Emeka", "This video helped a lot!"));
        v1.AddComment(new Comment("Emmauel", "Nice explanation."));
        v1.AddComment(new Comment("Charlie", "I love this channel!"));

        Video v2 = new Video("Cooking Jollof Rice", "Mama’s Kitchen", 300);
        v2.AddComment(new Comment("Dora", "Looks delicious!"));
        v2.AddComment(new Comment("Eve", "I tried it, turned out great."));
        v2.AddComment(new Comment("Fred", "Can you make Egusi soup next?"));

        Video v3 = new Video("How to find a Wife", "Best Home", 720);
        v3.AddComment(new Comment("Chiboy", "Omo all these ideas don't really work, Just pray to God"));
        v3.AddComment(new Comment("Favour", "This is helpful I will definatly try it out"));
        v3.AddComment(new Comment("Ugochi", "Can you talk about food instead of wife or relationship"));

        
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }

        Console.WriteLine("");
        Console.WriteLine("Thank You Prince Ebere.");

    }
}