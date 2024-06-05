class Event
{
    private string _type;
    private string _title;
    private string _date;
    private string _time;
    private string _description;
    private Address _address;
    public Event(string title, string desc, string date, string time, Address addy, string type)
    {
        _title = title;
        _date = date;
        _time = time;
        _description = desc;
        _address = addy;
        _type = type;
    }
    public string GetTitle()
    {
        return _title;
    }
    public string GetDate()
    {
        return _date;
    }
    public string GetTime()
    {
        return _time;
    }
    public string GetDescription()
    {
        return _description;
    }
    public Address GetAddress()
    {
        return _address;
    }
    public void StandardMessage()
    {
        System.Console.WriteLine(_title);
        System.Console.WriteLine(_description);
        System.Console.WriteLine(_date + " " + _time);
        System.Console.WriteLine(_address.FullAddress());
    }
    public void ShortMessage()
    {
        System.Console.WriteLine(_type);
        System.Console.WriteLine(_title);
        System.Console.WriteLine(_date);
    }
}