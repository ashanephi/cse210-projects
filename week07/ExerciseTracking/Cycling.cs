public class Cycling : Activity
{
    private double _Speed;

    public override double GetSpeed()
    {
        return _Speed;
    }

    public void SetSpeed(double speed)
    {
        _Speed = speed;
    }

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _Speed = speed;
    }

    public override double GetDistance()
    {
        return (_Speed * GetMinutes()) / 60;
    }

    public override double GetPace()
    {
        return 60 / _Speed;
    }
}