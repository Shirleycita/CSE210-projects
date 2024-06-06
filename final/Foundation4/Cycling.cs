class Cycling : Activity
{
    private float _speed;
    public Cycling(float speed, string date, int length):base(date,length,"Cycling") 
    {
        _speed = speed;
    }
    public override float GetSpeed()
    { 
        return _speed;
    }
    public override float GetDistance()
    {
        return _speed/60*GetLength();
    }
    public override float GetPace()
    {
        return 60/_speed;
    }
}