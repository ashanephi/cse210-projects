public class Swimming : Activity
{
    private int _Laps;

    public int GetLaps()
    {
        return _Laps;
    } 

    public void SetLaps(int laps)
    {
        _Laps = laps;
    }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _Laps = laps;
    }

    public override double GetDistance()
    {
        return _Laps * 50 / 1000 * 0.62; // Convert meters to miles
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