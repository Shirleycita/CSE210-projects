class ChecklistGoal : Goal
{
    private int _completionNumber;
    private int _currentNumber = 0;
    private int _bonusPoints;

    //Sets the goal vial loading
    public override void CreateGoal
        (string name, string description, int points, bool complete, int completionNumber, int currentNumber, int bonusPoints)
    {
        SetGoalType("EternalGoal");
        SetName(name);
        SetDescription(description);
        SetPoints(points);
        _completionNumber = completionNumber;
        _currentNumber = currentNumber;
        _bonusPoints = bonusPoints;
    }

    //Sets the goal vial the user
    public override void SetGoal()
    {
        SetGoalType("ChecklistGoal");

        Console.Write("What is the name of your goal? ");
        SetName(Console.ReadLine());

        Console.Write("What is a short description of it? ");
        SetDescription(Console.ReadLine());

        Console.Write("What is the ammount of points assosiated with this goal? ");
        string stringEntry = Console.ReadLine();
        int intEntry = int.Parse(stringEntry);
        SetPoints(intEntry);

        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        stringEntry = Console.ReadLine();
        _completionNumber = int.Parse(stringEntry);
        if(_completionNumber <= 0)
            _completionNumber = 1;

        Console.Write("What is the bonus for accomplishing it that many times? ");
        stringEntry = Console.ReadLine();
        _bonusPoints = int.Parse(stringEntry);
    }

    public override int RecordProgress()
    {
        if(_currentNumber + 1 == _completionNumber)
        {
            _currentNumber ++;
            return (GetPoints() + _bonusPoints);
        }
        else if(_currentNumber != _completionNumber)
        {
            _currentNumber ++;
            return GetPoints();
        }
        else{
            Console.WriteLine("This goal has already been completed.");
            return 0;
        }
    }

    public override void DisplayProgress()
    {
        if(_currentNumber == _completionNumber)
            Console.WriteLine($"[X] {GetName()} ({GetDescription()}) --- Currently Completed: {_currentNumber}/{_completionNumber}");

        else if(_currentNumber != _completionNumber)
            Console.WriteLine($"[ ] {GetName()} ({GetDescription()}) --- Currently Completed: {_currentNumber}/{_completionNumber}");
    }

    //creates a string for a .txt file line
    public override string SaveGoal()
    {
        string goalFormat = GetGoalType();
        goalFormat = (goalFormat + "," + GetName());
        goalFormat = (goalFormat + "," + GetDescription());
        goalFormat = (goalFormat + "," + GetPoints());
        goalFormat = (goalFormat + "," + _completionNumber);
        goalFormat = (goalFormat + "," + _currentNumber);
        goalFormat = (goalFormat + "," + _bonusPoints);
        return goalFormat;
    }


    //Getters & Setters
    public void SetCompletionNumber(int number)
    {
        _completionNumber = number;
    }
    public int GetCompletionNumber()
    {
        return _completionNumber;
    }
    public void SetCurrentNumber(int number)
    {
        _currentNumber = number;
    }
    public int GetCurrentNumber()
    {
        return _currentNumber;
    }
    public void SetBonusPoints(int points)
    {
        _bonusPoints = points;
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
}