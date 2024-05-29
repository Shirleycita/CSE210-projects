using System;
//To exceed requirements, I added a level up mechanic in the class GameFunctions that scales with the score. It also saves and loads too.

class Program
{
    static void Main(string[] args)
    {

        GameFunctions game = new GameFunctions();
        List<Goal> goalList = new List<Goal>();

        Dictionary<string, Goal> goals = new Dictionary<string, Goal>();
        goals["1"] = new SimpleGoal();
        goals["2"] = new EternalGoal();
        goals["3"] = new ChecklistGoal();

        string userEntry;
        int userChoice = 0;
        
        do
        {
            game.DisplayScore();
            

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            userEntry = Console.ReadLine();
            userChoice = int.Parse(userEntry);
            string fileName;
            int counter;


            if(userChoice == 1)
            {
                Console.WriteLine("The types of goals are:");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");

                userEntry = Console.ReadLine();
                Goal newGoal = goals[userEntry];
                newGoal.SetGoal();
                goalList.Add(newGoal);
            }


            else if(userChoice == 2)
            {
                counter = 1;
                Console.WriteLine("The goals are:");
                foreach(Goal goal in goalList)
                {
                    Console.Write($"{counter}. ");
                    goal.DisplayProgress();
                    counter ++;
                }
            }


            else if(userChoice == 3)
            {
                Console.Write("What is the filename for the goal file? ");
                fileName = Console.ReadLine();
                fileName = (fileName + ".txt");
                game.Save(fileName, goalList);
            }


            else if(userChoice == 4)
            {
                Console.Write("What is the filename for the goal file? ");
                fileName = Console.ReadLine();
                fileName = (fileName + ".txt");
                game.Load(fileName);
                goalList = game.GetLoadedGoals();
            }


            else if(userChoice == 5)
            {
                counter = 1;
                foreach(Goal goal in goalList)
                {
                    Console.WriteLine($"{counter}. {goal.GetName()}");
                    counter ++;
                }
                Console.Write("Which goal did you Accomplish? ");

                userEntry = Console.ReadLine();
                userChoice = int.Parse(userEntry);
                game.AddPoints(goalList[userChoice -1].RecordProgress());
            }


            else if(userChoice == 6)
                Console.WriteLine("Farewell until next time!");
            

            else
                Console.WriteLine("I'm sorry, but that wasn't a valid entry. Please try again.");

        }while(userChoice != 6);
    }
}