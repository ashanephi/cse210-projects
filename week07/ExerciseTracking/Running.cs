public class Running : Activity
{
    private double _distance;

    public override double GetDistance()
    {
        return _distance;
    }

    public void SetDistance(double distance)
    {
        _distance = distance;
    }

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60; // miles per hour
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance; // minutes per mile
    }
}