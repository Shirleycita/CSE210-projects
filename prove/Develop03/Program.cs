using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        bool continueMemorizing = true;

        while (continueMemorizing)
        {
            Console.WriteLine("Welcome to this tool for learning memorization.");
            Console.WriteLine("Select a scripture you want to memorize:");

            List<Scripture> scriptures = LoadScripturesFromFile("DataText.txt");

            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetShortReference()}");
            }

            int selectedScriptureIndex = -1;
            while (selectedScriptureIndex < 0 || selectedScriptureIndex >= scriptures.Count)
            {
                Console.Write("Choose a scripture number or 'q' to quit: ");
                string userInput = Console.ReadLine();

                if (userInput.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thanks for memorizing.");
                    return;
                }

                if (int.TryParse(userInput, out selectedScriptureIndex) && selectedScriptureIndex >= 1 && selectedScriptureIndex <= scriptures.Count)
                {
                    selectedScriptureIndex--; // Index adjustment to match the list index
                }
                else
                {
                    Console.WriteLine("Invalid scripture number. Please choose a valid scripture.");
                }
            }

            int minutesToAdd = GetMinutesToAdd();
            int totalSeconds = minutesToAdd * 60;
            DateTime endTime = DateTime.Now.AddSeconds(totalSeconds);

            Console.Clear();

            Scripture selectedScripture = scriptures[selectedScriptureIndex];

            while (true)
            {
                Console.Clear();
                TimeSpan remainingTime = endTime - DateTime.Now;

                if (remainingTime <= TimeSpan.Zero)
                {
                    Console.WriteLine("Time's up. Good attempt!");
                    break;
                }

                Console.WriteLine($"Time remaining: {remainingTime.Minutes}:{remainingTime.Seconds:D2}");
                Console.WriteLine($"Scripture: {selectedScripture.GetShortReference()}");
                Console.WriteLine($"Text to memorize: {selectedScripture.GetDisplayText()}");
                Console.WriteLine("Press Enter to hide more words or type 'q' to finish.");

                string userInput = Console.ReadLine();

                if (userInput.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                // Allows the user to press Enter to hide additional words
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    selectedScripture.HideRandomWords(1);
                }

                if (selectedScripture.IsCompletelyHidden())
                {
                    Console.WriteLine($"Congratulations! You have completed memorizing the scripture: {selectedScripture.GetShortReference()}");
                    Console.Write("Do you want to memorize another scripture? (y/yes for yes, q to quit): ");
                    string continueInput = Console.ReadLine();
                    continueMemorizing = continueInput.Equals("y", StringComparison.OrdinalIgnoreCase) || continueInput.Equals("yes", StringComparison.OrdinalIgnoreCase);
                    break;
                }
            }
        }

        Console.WriteLine("Thanks for memorizing.");
    }

    static int GetMinutesToAdd()
    {
        int minutesToAdd;
        while (true)
        {
            Console.Write("How many minutes do you want to add (1-10)? ");
            if (int.TryParse(Console.ReadLine(), out minutesToAdd) && minutesToAdd >= 1 && minutesToAdd <= 10)
            {
                return minutesToAdd;
            }
            else
            {
                Console.WriteLine("Please enter a valid number between 1 and 10.");
            }
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 5)
                {
                    string book = parts[1].Trim();
                    int chapter = int.Parse(parts[2]);
                    string verseStart = parts[3].Trim();
                    string verseEnd = parts[4].Trim();
                    string text = string.Join(" ", parts.Skip(5).ToArray()).Trim();
                    scriptures.Add(new Scripture(book, chapter, verseStart, verseEnd, text));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error loading the file: " + e.Message);
        }

        return scriptures;
    }
}
// I did some research to see ways to do this activity, and what I was able to do to exceed the requirements
// was add a timer using GetMinutesToAdd() :
//- The user specifies how many minutes they want to study a writing in the function
//- The program calculates the end time by adding the number of minutes entered by the user to the current time.
//- During execution, the program displays the remaining time in minutes and seconds.
//- When the time runs out (i.e. reaches zero or becomes negative), the program displays a message and ends memorization.
// Once the time runs out, the program ends the memorization task.