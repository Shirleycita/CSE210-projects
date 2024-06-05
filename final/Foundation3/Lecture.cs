class Lecture : Event
{
    private string _speaker;
    private int _capacity;
    public Lecture(string speaker, int capacity, string title, string desc, string date, string time, Address addy)
        : base(title, desc, date, time, addy, "Lecture Event")
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string GetSpeaker()
    {
        return _speaker;
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public void FullMessage()
    {
        Console.WriteLine(GetTitle());
        Console.WriteLine(GetDescription());
        Console.WriteLine(GetDate() + " " + GetTime());
        Console.WriteLine(GetAddress().FullAddress());
        Console.WriteLine("Speaker: " + _speaker);
        Console.WriteLine("Capacity: " + _capacity);
    }
}