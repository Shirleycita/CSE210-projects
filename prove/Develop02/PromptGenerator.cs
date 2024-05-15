using System;
public class PromptGenerator
{
    List<string> prompts = new List<string>()
    {
        "What blessings have I seen in my life today?",
        "What was my favprite scripture I read today?",
        "How did I help someone feel of the Saviors love today?",
        "What have I done today to help my kids gain a testimony of Christ?" 
    };
    public Random random = new Random();
    
    public string _randomPrompt;
    public string Display()
    {
        _randomPrompt = prompts[random.Next(0, prompts.Count)];
        Console.WriteLine($"{_randomPrompt}");
        return _randomPrompt;
    }
     
}
