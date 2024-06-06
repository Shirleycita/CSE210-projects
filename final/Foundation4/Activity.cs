abstract class  Activity
{
    private string _date;
    private int _length;
    private string _type;
    public Activity(string date, int length, string type)
    {
        _date = date;
        _length = length;
        _type = type;
    }
    public string GetSummary()
    {
        string durationStr = $"{_length}min";
        string paceStr = GetPace().ToString("0.0"); 

        return $"{_date} {_type} ({durationStr})- Distance {GetDistance():0.##} km, Speed {GetSpeed():0.##} kph, Pace {paceStr} min per km";
    }

    public int GetLength() 
    {
        return _length;
    }
    public abstract float GetDistance();
    public abstract float GetSpeed();
    public abstract float GetPace();

}