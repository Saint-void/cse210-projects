using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        // Create a list of videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video { Title = "Intro to C#", Author = "St Void", LengthSeconds = 300 };
        video1.AddComment(new Comment("Alice", "This video is super helpful!"));
        video1.AddComment(new Comment("Bob", "Great explanation, thanks!"));
        video1.AddComment(new Comment("Charlie", "I finally get classes now."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video { Title = "OOP Basics", Author = "St Void", LengthSeconds = 420 };
        video2.AddComment(new Comment("David", "Encapsulation makes sense now."));
        video2.AddComment(new Comment("Ella", "Please make a part 2!"));
        video2.AddComment(new Comment("Frank", "Love your teaching style."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video { Title = "C# Lists Tutorial", Author = "St Void", LengthSeconds = 250 };
        video3.AddComment(new Comment("Grace", "So clear and easy to follow."));
        video3.AddComment(new Comment("Henry", "This saved me before my test."));
        video3.AddComment(new Comment("Ivy", "More examples, please!"));
        videos.Add(video3);

        // Display video info
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
