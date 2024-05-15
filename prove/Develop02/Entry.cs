using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public override string ToString()
    {
        return ($"Date: {_date} \nPrompt: {_prompt} \nResponse: {_response}");
    }
}
