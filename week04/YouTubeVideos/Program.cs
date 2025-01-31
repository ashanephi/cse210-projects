using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("Intro to Programming", "Nephi Asha", 123000);

        Comment comment1 = new Comment("John", "Doe", "This is a wonderful");
        Comment comment2 = new Comment("Jason", "Friday", "This course is good to go over again");

        video1.AddComment(comment1);
        video1.AddComment(comment2);

        Video video2 = new Video("Learn CSS", "Ronald Regan", 34000);

        Comment comment3 = new Comment("Nephi", "Asha", "This is a useless. He didn't even exlain the basics properly");
        Comment comment4 = new Comment("Magnus", "Friday", "Hated it");

        video2.AddComment(comment3);
        video2.AddComment(comment4);

        videos.Add(video1);
        videos.Add(video2);

        Console.WriteLine();

        foreach(var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();

        }
        
    }
}