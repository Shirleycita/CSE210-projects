class Swimming:Activity
{
    private int _numberOfLaps;
    public Swimming(int laps, string date, int length): base(date,length,"Swimming")
    {
        _numberOfLaps = laps;
    }
    public override float GetDistance()
    {
        return _numberOfLaps*50f/1000f;
    }
    public override float GetSpeed()
    {
        return GetDistance()/GetLength()*60;
    }
    public override float GetPace()
    {
        return GetLength()/GetDistance();
    }
}