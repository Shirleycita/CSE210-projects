using System;

class Comment
{
    private string _person;
    private string _content;

    public Comment(string person, string content)
    {
        _person = person;
        _content = content;
    }

    public void Display()
    {
        Console.WriteLine($"{_person} - {_content}");
    }
}