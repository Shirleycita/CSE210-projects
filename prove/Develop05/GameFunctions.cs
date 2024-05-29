class GameFunctions
{
    private int _totalScore = 0;
    private List<Goal> _loadedGoals = new List<Goal>();
    private int _level = 1;
    private int _levelRequirement = 100;

    public void Save(string fileName, List<Goal> goals)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_totalScore);
            outputFile.WriteLine($"Level,{_level},{_levelRequirement}");

            foreach(Goal goal in goals)
            {
                outputFile.WriteLine(goal.SaveGoal());
            }
        }
    }

    public void Load(string fileName)
    {
        Goal goal;
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            string name;
            string description;
            int points;
            string goalType = parts[0];

            if(goalType == "SimpleGoal")
            {
                goal = new SimpleGoal();
                name = parts[1];
                description = parts[2];
                points = int.Parse(parts[3]);
                bool complete = bool.Parse(parts[4]);

                goal.CreateGoal(name, description, points, complete);
                _loadedGoals.Add(goal);
            }

            else if(goalType == "EternalGoal")
            {
                goal = new EternalGoal();
                name = parts[1];
                description = parts[2];
                points = int.Parse(parts[3]);

                goal.CreateGoal(name, description, points);
                _loadedGoals.Add(goal);
            }

            else if(goalType == "ChecklistGoal")
            {
                goal = new ChecklistGoal();
                name = parts[1];
                description = parts[2];
                points = int.Parse(parts[3]);
                int completionNumber = int.Parse(parts[4]);
                int currentNumber = int.Parse(parts[5]);
                int bonusPoints = int.Parse(parts[6]);

                goal.CreateGoal(name, description, points, false, completionNumber, currentNumber, bonusPoints);
                _loadedGoals.Add(goal);
            }

            else if(goalType == "Level")
            {
                _level = int.Parse(parts[1]);
                _levelRequirement = int.Parse(parts[2]);
            }

            else
                _totalScore = int.Parse(parts[0]);
        }
    }

    public void AddPoints(int points)
    {
        _totalScore += points;
    }

    public void DisplayScore()
    {
        int scoreLeft;

        Console.WriteLine();
        Console.WriteLine($"You have {_totalScore} points.");

        if(_totalScore > 0)
            scoreLeft = LevelUp();
        else
            scoreLeft = _levelRequirement;
        Console.WriteLine($"Your current level is {_level}. Only {scoreLeft} points left to reach level {_level + 1}");
        Console.WriteLine();
    }

    private int LevelUp(){
        if (_totalScore >= _levelRequirement)
        {
            _level++;
            _levelRequirement = _levelRequirement + (_level * 150);
        }
        
        int remainder = _totalScore % _levelRequirement;
        return _levelRequirement - remainder;
    }

    public List<Goal> GetLoadedGoals()
    {
        return _loadedGoals;
    }
}