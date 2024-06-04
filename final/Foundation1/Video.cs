using System;
using System.Collections.Generic;

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public int GetNumOfComments()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"{_title} by {_author} ({_length} sec) {GetNumOfComments()} comments");
        foreach (Comment comment in _comments)
        {
            comment.Display();
        }
    }
}