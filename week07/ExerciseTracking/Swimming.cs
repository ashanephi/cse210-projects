public class Swimming : Activity
{
    private int _laps;

    public int GetLaps()
    {
        return _laps;
    } 

    public void SetLaps(int laps)
    {
        _laps = laps;
    }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}