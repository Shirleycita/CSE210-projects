using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running(3.2f,"01 Aug", 20); 
        activities.Add(running); 

        Swimming swimming = new Swimming(200,"02 May", 30);
        activities.Add(swimming);

        Cycling cycling = new Cycling(7.5f,"03 Jun", 55);
        activities.Add(cycling);

        foreach (Activity activity in activities)
        {
            System.Console.WriteLine(activity.GetSummary());
        }


    }
}