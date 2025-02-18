public class Running : Activity
{
    private double _Distance;

    public override double GetDistance()
    {
        return _Distance;
    }

    public void SetDistance(double distance)
    {
        _Distance = distance;
    }

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _Distance = distance;
    }

    public override double GetSpeed()
    {
        return (_Distance / GetMinutes()) * 60; // miles per hour
    }

    public override double GetPace()
    {
        return GetMinutes() / _Distance; // minutes per mile
    }
}