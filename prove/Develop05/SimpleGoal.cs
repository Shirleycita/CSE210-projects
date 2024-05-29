class SimpleGoal : Goal
{
    private bool _complete = false;

    public override void CreateGoal
        (string name, string description, int points, bool complete, int completionNumber = 0, int currentNumber = 0, int bonusPoints = 0)
    {
        SetGoalType("EternalGoal");
        SetName(name);
        SetDescription(description);
        SetPoints(points);
        _complete = complete;
    }

    public override void SetGoal()
    {
        SetGoalType("SimpleGoal");

        Console.Write("What is the name of your goal? ");
        SetName(Console.ReadLine());

        Console.Write("What is a short description of it? ");
        SetDescription(Console.ReadLine());

        Console.Write("What is the ammount of points assosiated with this goal? ");
        string stringPoints = Console.ReadLine();
        int points = int.Parse(stringPoints);
        SetPoints(points);
    }

    public override int RecordProgress()
    {
        if(!_complete)
        {
            _complete = true;
            return GetPoints();
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
            return 0;
        }
    }

    public override void DisplayProgress()
    {
        if(_complete)
            Console.WriteLine($"[X] {GetName()} ({GetDescription()})");

        else if(!_complete)
            Console.WriteLine($"[ ] {GetName()} ({GetDescription()})");
    }


    public override string SaveGoal()
    {  
        string goalFormat = GetGoalType();
        goalFormat = (goalFormat + "," + GetName());
        goalFormat = (goalFormat + "," + GetDescription());
        goalFormat = (goalFormat + "," + GetPoints());
        goalFormat = (goalFormat + "," + _complete);
        return goalFormat;
    }



    public void SetComplete(bool complete)
    {
        _complete = complete;
    }
    public bool GetComplete()
    {
        return _complete;
    }
}