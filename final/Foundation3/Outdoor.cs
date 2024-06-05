class Outdoor : Event
{
    private string _weatherForecast;
    public Outdoor(string weather, string title, string desc, string date, string time, Address addy)
        : base(title, desc, date, time, addy, "Outdoor Event")
    {
        _weatherForecast = weather;
    }

    public string GetWeatherForecast()
    {
        return _weatherForecast;
    }

    public void FullMessage()
    {
        Console.WriteLine(GetTitle());
        Console.WriteLine(GetDescription());
        Console.WriteLine(GetDate() + " " + GetTime());
        Console.WriteLine(GetAddress().FullAddress());
        Console.WriteLine("Weather: " + _weatherForecast);
    }
}