using System;

class Program
{
    static void Main(string[] args)
    {
        Address addy = new Address("174 Calle Santo Toribio", "Los Angeles", "CA", "USA");

        Lecture lecture = new Lecture("Shirley Hatch", 50, "Workshop", "Makeup Tutorial", "April 25", "1:00 PM", addy);
        DisplayEvent(lecture);
        DisplayFullMessage(lecture);
        DisplayStandardMessage(lecture);
        DisplayShortMessage(lecture);

        Reception reception = new Reception("RSVP@gmail.com", "Wedding", "Wedding Reception", "August 30", "7:00 PM", addy);
        DisplayEvent(reception);
        DisplayFullMessage(reception);
        DisplayStandardMessage(reception);
        DisplayShortMessage(reception);

        Outdoor outdoor = new Outdoor("Sunny", "HOA Picnic", "Water Baloon Fight", "September 10", "12:00 PM", addy);
        DisplayEvent(outdoor);
        DisplayFullMessage(outdoor);
        DisplayStandardMessage(outdoor);
        DisplayShortMessage(outdoor);
    }

    static void DisplayEvent(Event eventObj)
    {
        Console.WriteLine($"***{eventObj.GetType().Name}***");
        Console.WriteLine("_______________");
    }

    static void DisplayFullMessage(Event eventObj)
    {
        Console.WriteLine("-------------");
        Console.WriteLine("Full Message");
        Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯");
        Console.WriteLine(eventObj.GetTitle());
        Console.WriteLine(eventObj.GetDescription());
        Console.WriteLine($"{eventObj.GetDate()} {eventObj.GetTime()}");
        Console.WriteLine(eventObj.GetAddress().FullAddress());

        if (eventObj is Lecture lecture)
        {
            Console.WriteLine($"Speaker: {lecture.GetSpeaker()}");
            Console.WriteLine($"Capacity: {lecture.GetCapacity()}");
        }
        else if (eventObj is Reception reception)
        {
            Console.WriteLine($"RSVP: {reception.GetRsvpEmail()}");
        }
        else if (eventObj is Outdoor outdoor)
        {
            Console.WriteLine($"Weather: {outdoor.GetWeatherForecast()}");
        }

        Console.WriteLine("________________");
    }

    static void DisplayStandardMessage(Event eventObj)
    {
        Console.WriteLine("----------------");
        Console.WriteLine("Standard Message");
        Console.WriteLine("¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
        Console.WriteLine(eventObj.GetTitle());
        Console.WriteLine(eventObj.GetDescription());
        Console.WriteLine($"{eventObj.GetDate()} {eventObj.GetTime()}");
        Console.WriteLine(eventObj.GetAddress().FullAddress());
        Console.WriteLine("_________________");
    }

    static void DisplayShortMessage(Event eventObj)
    {
        Console.WriteLine("-------------");
        Console.WriteLine("Short Message");
        Console.WriteLine("-------------");
        Console.WriteLine(eventObj.GetType().Name);
        Console.WriteLine(eventObj.GetTitle());
        Console.WriteLine(eventObj.GetDate());
        Console.WriteLine("_____________");
        Console.WriteLine();
    }
}