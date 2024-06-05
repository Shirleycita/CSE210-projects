class Reception : Event
{
    private string _rsvpEmail;
    public Reception(string email, string title, string desc, string date, string time, Address addy)
        : base(title, desc, date, time, addy, "Reception Event")
    {
        _rsvpEmail = email;
    }

    public string GetRsvpEmail()
    {
        return _rsvpEmail;
    }

    public void FullMessage()
    {
        Console.WriteLine(GetTitle());
        Console.WriteLine(GetDescription());
        Console.WriteLine(GetDate() + " " + GetTime());
        Console.WriteLine(GetAddress().FullAddress());
        Console.WriteLine("RSVP: " + _rsvpEmail);
    }
}