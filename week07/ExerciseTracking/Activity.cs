public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public DateTime GetDate()
    {
        return _date;
    }

    public void SetDate(DateTime date)
    {
        _date = date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public void SetMinutes(int minutes)
    {
        _minutes = minutes;
    }

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();
    public abstract double GetPace(); 

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        
        return $"{GetDate():dd MMM yyyy} {GetType().Name} ({GetMinutes()} min) - " +
               $"Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
    }
}