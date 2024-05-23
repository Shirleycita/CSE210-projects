using System;

public class Choices
{
    // Attributes 
    private string _menu = $@"
Menu Options
===========================
1. Breathing activity
2. Reflecting activity
3. Listing activity
4. Quit
===========================
Select an option from the menu:  ";

    public string _userInput;
    private int _userChoice = 0;

 
    public int UserChoice()

    {

        Console.Clear();
        Console.Write(_menu);

        _userInput = Console.ReadLine();
        _userChoice = 0;
    
        try
        {
            _userChoice = int.Parse(_userInput);
        }
        catch (FormatException)
        {
            _userChoice = 0;
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"Unexpected error:  {exception.Message}");
        }
        return _userChoice;
    }



}