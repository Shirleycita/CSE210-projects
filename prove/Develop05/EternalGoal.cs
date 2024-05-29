class EternalGoal : Goal
{
    public override void CreateGoal
        (string name, string description, int points, bool complete = false, int completionNumber = 0, int currentNumber = 0, int bonusPoints = 0)
    {
        SetGoalType("EternalGoal");
        SetName(name);
        SetDescription(description);
        SetPoints(points);
    }

    public override void SetGoal()
    {
        SetGoalType("EternalGoal");

        Console.Write("What is the name of your goal? ");
        SetName(Console.ReadLine());

        Console.Write("What is a short description of it? ");
        SetDescription(Console.ReadLine());

        Console.Write("What is the ammount of points assosiated with this goal? ");
        string stringPoints = Console.ReadLine();
        SetPoints(int.Parse(stringPoints));
    }

    public override string SaveGoal()
    {
        string goalFormat = GetGoalType();
        goalFormat = (goalFormat + "," + GetName());
        goalFormat = (goalFormat + "," + GetDescription());
        goalFormat = (goalFormat + "," + GetPoints());
        return goalFormat;
    }
}