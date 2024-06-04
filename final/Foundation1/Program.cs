using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        List<Comment> comments1 = new List<Comment>();
        Comment comment1_1 = new Comment("Person1", "Comment1");
        Comment comment1_2 = new Comment("Person2", "Comment2");
        Comment comment1_3 = new Comment("Person3", "Comment3");
        comments1.Add(comment1_1);
        comments1.Add(comment1_2);
        comments1.Add(comment1_3);
        Video vid1 = new Video("Video1", "Author1", 30, comments1);
        videos.Add(vid1);

        List<Comment> comments2 = new List<Comment>();
        Comment comment2_1 = new Comment("Person1", "Comment1");
        Comment comment2_2 = new Comment("Person2", "Comment2");
        Comment comment2_3 = new Comment("Person3", "Comment3");
        comments2.Add(comment2_1);
        comments2.Add(comment2_2);
        comments2.Add(comment2_3);
        Video vid2 = new Video("Video2", "Author2", 60, comments2);
        videos.Add(vid2);

        List<Comment> comments3 = new List<Comment>();
        Comment comment3_1 = new Comment("Person1", "Comment1");
        Comment comment3_2 = new Comment("Person2", "Comment2");
        Comment comment3_3 = new Comment("Person3", "Comment3");
        comments3.Add(comment3_1);
        comments3.Add(comment3_2);
        comments3.Add(comment3_3);
        Video vid3 = new Video("Video3", "Author3", 90, comments3);
        videos.Add(vid3);

        List<Comment> comments4 = new List<Comment>();
        Comment comment4_1 = new Comment("Person1", "Comment1");
        Comment comment4_2 = new Comment("Person2", "Comment2");
        Comment comment4_3 = new Comment("Person3", "Comment3");
        comments4.Add(comment4_1);
        comments4.Add(comment4_2);
        comments4.Add(comment4_3);
        Video vid4 = new Video("Video4", "Author4", 120, comments4); 
        videos.Add(vid4);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}